using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public partial class oa_JournalManage_JournalCheckList : NBasePage, IRequiresSessionState
{
    private OAJournalService pcSer = new OAJournalService();
    private OAJournalAppendService pcSer2 = new OAJournalAppendService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            dropBind();
            this.DataBinds();
        }
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = this.GvList.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
            }

            HyperLink hyperLink = (HyperLink)e.Row.Cells[1].FindControl("HyperLink1");
            hyperLink.NavigateUrl = "javascript:toolbox_oncommand('/oa/JournalManage/JournalCheckDetail.aspx?action=view&id=" + this.GvList.DataKeys[e.Row.RowIndex].Values[0].ToString() + "','查看工作日志');";
            hyperLink.ForeColor = Color.Blue;
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        
        this.DataBinds();
    }

    private void dropBind()
    {
        DataTable aLLProvince = publicDbOpClass.DataTableQuary("select * from OA_Journal_Type where is_use = 1");
        this.type_id.DataSource = aLLProvince;
        this.type_id.DataValueField = "id";
        this.type_id.DataTextField = "name";
        this.type_id.DataBind();
        this.type_id.Items.Insert(0, new ListItem("请选择", ""));
    }
    public string[] ReStrs()
    {
        string str = "";
        string strSql = "select DISTINCT journal_id from OA_Journal_Append where user_id='" + base.UserCode + "'";
        DataTable dt = publicDbOpClass.DataTableQuary(strSql);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                str += "" + dr["journal_id"].ToString() + ",";
            }
        }
        //return str.Substring(0, str.Length - 1);
        string str1 = str.Substring(0, str.Length - 1);
        string[] strs= str1.Split(',');
        return strs;
    }

protected void DataBinds()
    {
        IQueryable<OAJournal> source = this.Queryable();
        this.AspNetPager1.RecordCount = source.Count<OAJournal>();
        source =
            from p in source
            orderby p.start_time descending
            select p;
        IQueryable<OAJournal> dataSource = source.Skip((this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).Take(this.AspNetPager1.PageSize);
        this.GvList.DataSource = dataSource;
        this.GvList.DataBind();
    }
    protected string BackType(string type_id)
    {
        string sqlString = "select name from OA_Journal_Type where Id='" + type_id + "'";
        DataTable dataTable = publicDbOpClass.DataTableQuary(sqlString);
        if (dataTable.Rows.Count > 0)
        {
            return dataTable.Rows[0]["name"].ToString();
        }
        return "";
    }
    protected string BackSYR(string ID)
    {
        DataTable dt = publicDbOpClass.DataTableQuary(@"select OA_Journal_Append.user_id,OA_Journal_Append.user_type,PT_yhmc.v_xm from OA_Journal_Append 
                                  left join PT_yhmc on OA_Journal_Append.user_id=PT_yhmc.v_yhdm where journal_id='" + ID + "'");
        string strSYRXM = "";
        foreach (DataRow dr in dt.Rows)
        {
            //0 审阅人、1相关人、2审阅及相关人;
            if (dr["user_type"].ToString() == "0")
            {
                strSYRXM = dr["v_xm"].ToString();
            }
            if (dr["user_type"].ToString() == "2")
            {
                strSYRXM = dr["v_xm"].ToString();
            }
        }
        //审阅人
        return strSYRXM;

    }
    protected string BackXGR(string ID)
    {
        DataTable dt = publicDbOpClass.DataTableQuary(@"select OA_Journal_Append.user_id,OA_Journal_Append.user_type,PT_yhmc.v_xm from OA_Journal_Append 
                                  left join PT_yhmc on OA_Journal_Append.user_id=PT_yhmc.v_yhdm where journal_id='" + ID + "'");
        string strXGRXM = "";
        foreach (DataRow dr in dt.Rows)
        {
            //0 审阅人、1相关人、2审阅及相关人;

            if (dr["user_type"].ToString() == "1")
            {
                strXGRXM += dr["v_xm"].ToString() + ",";
            }
            if (dr["user_type"].ToString() == "2")
            {
                strXGRXM += dr["v_xm"].ToString() + ",";
            }
        }
        //相关人
        if (strXGRXM.Length > 0)
        {
            return strXGRXM.Substring(0, strXGRXM.Length - 1);
        }
        else
        {
            return "";
        }

    }
    private IQueryable<OAJournal> Queryable()
    {
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);

        IQueryable<OAJournal> queryable =
            from p in this.pcSer
                where p.status==1
            select p;

        IQueryable<OAJournalAppend> queryable2 =
            from px in pcSer2
            where px.user_id ==this.UserCode
            select px;

        if (startTime.HasValue)
        {
            queryable =
                from p in queryable
                where p.start_time >= startTime.Value
                select p;
        }
        if (endTime.HasValue)
        {
            queryable =
                from p in queryable
                where p.start_time < endTime.Value.AddDays(1.0)
                select p;
        }
        if (!string.IsNullOrEmpty(txtTitle.Text))
        {
            queryable = 
                from p in queryable
                where p.title == txtTitle.Text
                select p;
        }
        if (type_id.SelectedValue!="")
        {
            queryable =
                from p in queryable
                where p.type_id == type_id.SelectedValue
                select p;
        }
        if (status.SelectedValue != "")
        {
            queryable =
                from p in queryable
                where p.status == Convert.ToInt32(status.SelectedValue)
                select p;
        }
        if (base.UserCode != "00000000")
        {
            queryable =
                from p in queryable
                where ReStrs().Contains(p.Id)
               // where ("a7927cdf-dc0d-4a0c-b3aa-85bf4eef0822,af147fa8-04ea-47ef-ad7d-ac551f43dddc,6c765ee7-c616-428d-8a28-44e8bcf38846").Contains(p.Id)
               //from px in queryable2
               // join px in queryable2 
               //on p.Id equals(string)(px.journal_id)
               //where (new string[] { "bd55dfb6-3634-4a3e-84b7-35dc9194792d", "54525a9e-8298-4575-aedb-c69e8260e1ef" }).Contains(p.Id)
               // where (strs()).Contains(p.Id)
               //from px in queryable2
               //where p.Id from px.journal_id.ToString() //("select journal_id from OA_Journal_Type where Id='" + type_id + "'")
            select p;
        }
        return queryable;
    }

    //protected void btnDel_Click(object sender, EventArgs e)
    //{
    //    System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
    //    string value = this.KeyId.Value;
    //    if (value.Contains("["))
    //    {
    //        list = JsonHelper.GetListFromJson(value);
    //    }
    //    else
    //    {
    //        list.Add(value);
    //    }
    //    this.pcSer.Delete(list);
    //    base.RegisterShow("系统提示", "删除成功！");
    //    this.DataBinds();
    //}

    protected void GvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvList.PageIndex = e.NewPageIndex;
        this.DataBinds();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
}