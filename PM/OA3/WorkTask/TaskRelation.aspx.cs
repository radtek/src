using ASP;
using cn.justwin.BLL;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using com.jwsoft.pm.entpm.action;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class TaskRelation : NBasePage, IRequiresSessionState
{
    private ContAction contaction = new ContAction();
    private string prjId = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        //if (!string.IsNullOrEmpty(base.Request["PrjGuid"]))
        //{
        //    this.prjId = base.Request["PrjGuid"].ToString();
        //}
        base.OnInit(e);
    }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            dropBind();
            this.DataBinds();
        }
    }
    protected void DataBinds()
    {
        int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
        string str2 = (pagesize * currentPageIndex).ToString();
        DataTable dtA = TaskService.GetTaskListTable(strWhere(), UserCode);
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
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);
        if (startTime.HasValue)
        {
            strWhere += " and start_time >='" + startTime.Value + "'";
        }
        if (endTime.HasValue)
        {
            strWhere += " and start_time <'" + endTime.Value.AddDays(1.0) + "'";
        }
        System.DateTime? stime = DateTimeHelper.GetDateTime(this.stime.Text);
        System.DateTime? etime = DateTimeHelper.GetDateTime(this.etime.Text);
        if (stime.HasValue)
        {
            strWhere += " and create_time >='" + stime.Value + "'";
        }
        if (etime.HasValue)
        {
            strWhere += " and create_time <'" + etime.Value.AddDays(1.0) + "'";
        }

        if (!string.IsNullOrEmpty(txtTitle.Text))
        {
            strWhere += " and title like '%" + txtTitle.Text.ToString().Trim() + "%'";
        }
        if (type_id.SelectedValue != "")
        {
            strWhere += " and type_id ='" + type_id.SelectedValue + "'";
        }
        if (status.SelectedValue != "")
        {
            strWhere += " and status ='" + Convert.ToInt32(status.SelectedValue) + "'";
        }
        //if (base.UserCode != "00000000")
        //{
        //    strWhere += " and creater_id ='" + UserCode + "'";
        //}
        //任务状态   0草稿、1未开始、2执行中、3已完成、4已关闭、5已删除 
        strWhere += " and status !='5' and status !='0' and status !='3' and status !='4'";
        //string strRYS = hfldTo.Value.ToString();//执行人
        //if (!string.IsNullOrEmpty(strRYS))
        //{
        //    string[] strXGR = strRYS.Split(',');
        //    string strs = "";
        //    foreach (string str in strXGR)
        //    {
        //        strs += "'" + str + "',";
        //    }
        //关联 任务执行人
            strWhere += " and OA_Task.Id in (SELECT task_id FROM OA_Task_Append where (user_type=0 or user_type=2 ) and user_id ='" + UserCode.ToString()+"') ";
        //}
        return strWhere;
    }
    private void dropBind()
    {
        DataTable aLLProvince = publicDbOpClass.DataTableQuary("select * from OA_Task_Type where is_use = 1");
        this.type_id.DataSource = aLLProvince;
        this.type_id.DataValueField = "id";
        this.type_id.DataTextField = "name";
        this.type_id.DataBind();
        this.type_id.Items.Insert(0, new ListItem("", ""));
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dv = (DataRowView)e.Row.DataItem;
                e.Row.Attributes["id"] = dv["Id"].ToString();
                e.Row.Attributes["name"] = dv["title"].ToString();
            }
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
}
