using cn.justwin.BLL;
using cn.justwin.DAL;
using com.jwsoft.pm.data;
using DomainServices.cn.justwin.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OA3_ProUser_Edit : NBasePage
{
   
    private string action = string.Empty;
    private string Id = string.Empty;
    private string prjGuid = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.action = base.Request["action"];
        this.Id = base.Request["id"];
        prjGuid = base.Request["pid"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            if (this.action == "add")
            {
                this.PrjGuid.Value = prjGuid;
                BindDropDownList("ProType");//绑定 项目通讯录类型
                BindDropDownList("ProGroup");//绑定 项目通讯录分组
            }
            if (this.action == "edit"|| action == "view")
            {
                BindDropDownList("ProType");//绑定 项目通讯录类型
                BindDropDownList("ProGroup");//绑定 项目通讯录分组
                this.Binds(Id);
            }
            if (action == "view")
            {
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
            }
        }
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
            //this.DocChangeType.Items.Insert(0, new ListItem("请选择", ""));
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
            //this.DocVersionID.Items.Insert(0, new ListItem("请选择", ""));
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

    private void Binds(string Id)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            DataTable dt = TaskService.GetProUserTable(strWhere(Id), UserCode);
            if (dt.Rows.Count > 0)
            {
                this.KeyId.Value = dt.Rows[0]["id"].ToString();
                this.xm.Text = dt.Rows[0]["xm"].ToString();
                this.sex.SelectedValue = dt.Rows[0]["sex"].ToString();
                type.SelectedValue = dt.Rows[0]["type"].ToString();
                group.SelectedValue = dt.Rows[0]["group"].ToString();
                sort.Text = dt.Rows[0]["sort"].ToString();
                tel.Text = dt.Rows[0]["tel"].ToString();
                phone.Text = dt.Rows[0]["phone"].ToString();
                mail.Text = dt.Rows[0]["mail"].ToString();
                qq.Text = dt.Rows[0]["qq"].ToString();
                wx.Text = dt.Rows[0]["wx"].ToString();
                ads.Text = dt.Rows[0]["ads"].ToString();
                remark.Text = dt.Rows[0]["remark"].ToString();
                this.PrjGuid.Value = dt.Rows[0]["prjId"].ToString();
            }
        }
    }

    private string strWhere(string Id)
    {
        string strWhere = " ";// and ...
        if (!string.IsNullOrEmpty(Id.ToString()))
        {
            strWhere += " and id  ='" + Id + "'";
        }
        return strWhere;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveData();
    }
    public void saveData()
    {
        string strSql = "";
        if (this.action == "add")
        {
            strSql = string.Format(@"
                                            INSERT INTO [Pro_User]
                                                       (id
                                                        ,xm
                                                        ,tel
                                                        ,phone
                                                        ,ads
                                                        ,type
                                                        ,qq
                                                        ,wx
                                                        ,mail
                                                        ,[group]
                                                        ,remark
                                                        ,sort
                                                        ,prjId
                                                        ,sex)
                                                 VALUES
                                                       ('{0}'
                                                       ,'{1}'
                                                       ,'{2}'
                                                       ,'{3}'
                                                       ,'{4}'
                                                       ,'{5}'
                                                       ,'{6}'
                                                        ,'{7}'
                                                        ,'{8}'
                                                        ,'{9}'
                                                        ,'{10}'
                                                        ,{11}
                                                        ,'{12}'
                                                        ,'{13}')
                                                        ", Guid.NewGuid().ToString()
                                                       , xm.Text.ToString()
                                                       , tel.Text.ToString()
                                                       , phone.Text.ToString()
                                                       , ads.Text.ToString()
                                                       , type.SelectedValue.ToString()
                                                       , qq.Text.ToString()
                                                       , wx.Text.ToString()
                                                       , mail.Text.ToString()
                                                       , group.SelectedValue.ToString()
                                                       , remark.Text.ToString()
                                                       , sort.Text.ToString()
                                                       , PrjGuid.Value.ToString()
                                                       , sex.SelectedValue.ToString());

        }
        else if (this.action == "edit")
        {
            strSql = string.Format(@" UPDATE [Pro_User]
                                       SET [xm] = '{1}'
                                           ,[tel] = '{2}'
                                          ,phone= '{3}'
                                                        ,ads= '{4}'
                                                        ,type= '{5}'
                                                        ,qq= '{6}'
                                                        ,wx= '{7}'
                                                        ,mail= '{8}'
                                                        ,[group]= '{9}'
                                                        ,remark= '{10}'
                                                        ,sort= {11}
                                                        ,prjId= '{12}'
                                                        ,sex= '{13}'
                                       WHERE id='{0}'
        ", this.KeyId.Value.ToString(),xm.Text.ToString()
                                                        , tel.Text.ToString()
                                                        , phone.Text.ToString()
                                                        , ads.Text.ToString()
                                                        , type.SelectedValue.ToString()
                                                        , qq.Text.ToString()
                                                        , wx.Text.ToString()
                                                        , mail.Text.ToString()
                                                        , group.SelectedValue.ToString()
                                                        , remark.Text.ToString()
                                                        , sort.Text.ToString()
                                                        , PrjGuid.Value.ToString()
                                                        , sex.SelectedValue.ToString());
        }

        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                base.RegisterScript("successed();");
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }
}