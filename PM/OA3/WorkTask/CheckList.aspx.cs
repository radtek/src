using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using DomainServices.cn.justwin.Domain.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class OA3_WorkTask_CheckList : NBasePage
{
    private TaskService pcSer = new TaskService();
    private string userType = string.Empty;

    protected override void OnInit(System.EventArgs e)
    {
        this.userType = base.Request["userType"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            TaskService.upDateStatus();
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

                string ifck = DataBinder.Eval(e.Row.DataItem, "ifck").ToString();
                if (ifck == "0")
                {
                    //e.Row.Style.Add("font-weight", "bolder;");//.Attributes.Add("class", "yellow");
                    HyperLink HyperLink1 = (HyperLink)e.Row.FindControl("HyperLink1");
                    //Label content = (Label)e.Row.FindControl("content");
                    //Label typeName = (Label)e.Row.FindControl("typeName");
                    //Label v_xm = (Label)e.Row.FindControl("v_xm");
                    //Label ck = (Label)e.Row.FindControl("ifck");
                    HyperLink1.Font.Bold = true;
                    //content.Font.Bold = true;
                    //typeName.Font.Bold = true;
                    //v_xm.Font.Bold = true;
                    //ck.Font.Bold = true;
                    //ck.ForeColor = Color.FromName("#FF7D00");
                }
            }
            //HyperLink hyperLink = (HyperLink)e.Row.Cells[1].FindControl("HyperLink1");
            //hyperLink.NavigateUrl = "javascript:toolbox_oncommand('/OA3/WorkTask/TaskView.aspx?action=view&id=" + this.GvList.DataKeys[e.Row.RowIndex].Values[0].ToString() + "','查看工作任务');";
            //hyperLink.ForeColor = Color.Blue;
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
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
            strWhere += " and create_date >='" + stime.Value + "'";
        }
        if (etime.HasValue)
        {
            strWhere += " and create_date <'" + etime.Value.AddDays(1.0) + "'";
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
        if (base.UserCode != "00000000")
        {
            //strWhere += " and creater_id ='" + UserCode + "'";
        }
        if (!string.IsNullOrEmpty(ReStrs()))
        {
            strWhere += " and OA_Task.Id IN (" + ReStrs() + ")";
        }
        return strWhere;
    }
    public string ReStrs()
    {
        string strWhere = "";
        if (userType == "sy")
        {
            strWhere = " and user_id='" + base.UserCode + "' and (user_type=0 or user_type=2) ";
        }
        if (userType == "xg")
        {
            strWhere = " and user_id='" + base.UserCode + "' and (user_type=1 or user_type=2)";
        }
        string str = "";
        string strSql = "select DISTINCT Task_id from OA_Task_Append where 1=1 " + strWhere + "";
        DataTable dt = publicDbOpClass.DataTableQuary(strSql);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                str += "'" + dr["Task_id"].ToString() + "',";
            }
        }
        if (!string.IsNullOrEmpty(str))
        {
            string strs = str.Substring(0, str.Length - 1);
            return strs;
        }
        else
        {
            return "'无'";
        }
    }

    protected void btnExecl_Click(object sender, System.EventArgs e)
    {
        DataTable dt = TaskService.GetTaskListTable(strWhere(), UserCode);
        dt.Columns.Remove("Id");
        dt.Columns.Remove("type_id");
        dt.Columns.Remove("creater_id");
        dt.Columns.Remove("priority_id");
        dt.Columns.Remove("I_xh");
        dt.Columns.Remove("ifck");
        dt.Columns.Remove("plAll");
        dt.Columns.Remove("plNew");
        dt.Columns.Remove("up_time");
        dt.Columns.Remove("remark");
        dt.Columns.Remove("if_send");
        dt.Columns["pageindex"].ColumnName = "序号";
        dt.Columns["typeName"].ColumnName = "任务类型";
        dt.Columns["title"].ColumnName = "任务标题";
        dt.Columns["v_xm"].ColumnName = "创建人";
        dt.Columns["status"].ColumnName = "任务状态";
        dt.Columns["start_time"].ColumnName = "开始时间";
        dt.Columns["end_time"].ColumnName = "结束时间";
        dt.Columns["longs"].ColumnName = "持续时间(分钟)";
        dt.Columns["content"].ColumnName = "任务内容";
        dt.Columns["create_time"].ColumnName = "创建时间";
        dt.Columns["complete_time"].ColumnName = "完成/关闭时间";
        dt.Columns["CodeName"].ColumnName = "任务优先级";
        dt.Columns["syr"].ColumnName = "执行人";
        dt.Columns["xgr"].ColumnName = "相关人";
        dt.Columns["progress"].ColumnName = "任务进度(%)";
        //dt.Columns["up_time"].ColumnName = "任务提交时间";
        //dt.Columns["remark"].ColumnName = "任务进度备注";
        new Common2().ExportToExecelAll(dt, "任务信息.xls", base.Request.Browser.Browser);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
        string value = this.KeyId.Value;
        string str = value.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        string strSqlA = "select * FROM OA_Task where status !=0 and Id in " + str;
        DataTable dt = publicDbOpClass.DataTableQuary(strSqlA);
        if (dt.Rows.Count > 0)
        {
            base.RegisterShow("系统提示", "只能删除任务状态为草稿中的,请重新选择！");
            return;
        }
        string strSql = "DELETE FROM OA_Task where Id in " + str;
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                base.RegisterShow("系统提示", "删除成功！");
                this.DataBinds();
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\删除失败！');");
            }
        }
    }

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