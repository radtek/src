using cn.justwin.BLL;
using cn.justwin.DAL;
using com.jwsoft.pm.data;
using DomainServices.cn.justwin.Domain.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class OA3_ProUser_List : NBasePage
{
    public string prjGuid;
    public string action;
    
    protected override void OnInit(System.EventArgs e)
    {
        prjGuid = base.Request["PrjGuid"];
        action = base.Request["action"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.PrjGuid.Value = prjGuid;
            BindDropDownList("ProType");//绑定 项目通讯录类型
            BindDropDownList("ProGroup");//绑定 项目通讯录分组
            this.DataBinds();
            if (action=="edit")
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDel.Visible = true;
            }
            if (action == "view")
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDel.Visible = false;
            }
        }
    }
    protected void DataBinds()
    {
        int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
        string str2 = (pagesize * currentPageIndex).ToString();
        DataTable dtA = TaskService.GetProUserTable(strWhere(), UserCode);
        DataRow[] rows = dtA.Select(" pageindex >=" + str + " and  pageindex<=" + str2);
        DataTable dtB = dtA.Clone();
        foreach (DataRow row in rows)
        {
            dtB.Rows.Add(row.ItemArray);
        }
        this.AspNetPager1.PageSize = NBasePage.pagesize;
        this.AspNetPager1.RecordCount = dtA.Rows.Count;
        this.GvList.DataSource = dtB;
        this.GvList.DataBind();
    }
    public string strWhere()
    {
        string strWhere = " ";// and ...
        if (!string.IsNullOrEmpty(group.SelectedValue.ToString()))
        {
            strWhere += " and [group]  ='" + group.SelectedValue.ToString() + "'";
        }
        if (!string.IsNullOrEmpty(type.SelectedValue.ToString()))
        {
            strWhere += " and [type]  ='" + type.SelectedValue.ToString() + "'";
        }
        if (!string.IsNullOrEmpty(xm.Text.ToString().Trim()))
        {
            strWhere += " and xm like '%" + xm.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(tel.Text.ToString().Trim()))
        {
            strWhere += " and tel like '%" + tel.Text.ToString().Trim() + "%'";
        }

        if (!string.IsNullOrEmpty(phone.Text.ToString().Trim()))
        {
            strWhere += " and phone like '%" + phone.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(qq.Text.ToString().Trim()))
        {
            strWhere += " and qq like '%" + qq.Text.ToString().Trim() + "%'";
        }

        if (!string.IsNullOrEmpty(wx.Text.ToString().Trim()))
        {
            strWhere += " and wx like '%" + wx.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(mail.Text.ToString().Trim()))
        {
            strWhere += " and mail like '%" + mail.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(ads.Text.ToString().Trim()))
        {
            strWhere += " and ads like '%" + ads.Text.ToString().Trim() + "%'";
        }

        if (!string.IsNullOrEmpty(PrjGuid.Value))
        {
            strWhere += " and prjId  ='" + PrjGuid.Value + "'";
        }
        return strWhere;
    }
    private void BindDropDownList(string strType)
    {
        DataTable dt = publicDbOpClass.DataTableQuary("select * from XPM_Basic_CodeList WHERE SignCode2='" + strType + "' order by I_xh asc");
        if (strType == "ProType")
        {
            this.type.DataSource = dt;
            this.type.DataValueField = "NoteID";
            this.type.DataTextField = "CodeName";
            this.type.DataBind();
            this.type.Items.Insert(0, new ListItem("请选择", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IsDefault"].ToString() == "True")
                {
                    type.SelectedValue = dr["NoteID"].ToString();
                    break;
                }
            }
        }
        if (strType == "ProGroup")
        {
            this.group.DataSource = dt;
            this.group.DataValueField = "NoteID";
            this.group.DataTextField = "CodeName";
            this.group.DataBind();
            this.group.Items.Insert(0, new ListItem("请选择", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IsDefault"].ToString() == "True")
                {
                    group.SelectedValue = dr["NoteID"].ToString();
                    break;
                }
            }
        }
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string value = this.GvList.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        string strTemp = this.KeyId.Value.ToString();
        string strIDs = "";
        if (strTemp.Split(',').Length > 1)
        {
            strIDs = strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }
        else
        {
            strIDs = " ('" + strTemp + "')";
        }
        string strSql = string.Format(@"delete from [Pro_User]  WHERE [id] in {0}", strIDs);
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                base.RegisterShow("系统提示", "操作成功！");
                this.DataBinds();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\操作失败！" + ex.Message.ToString() + "');");
            }
        }
    }
}