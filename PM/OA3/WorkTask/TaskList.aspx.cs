using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class OA3_WorkTask_TaskList : NBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.btnSC.Attributes.Add("onclick", "if(!confirm('确定删除选中的工作任务吗?')) return false;");
            this.btnWC.Attributes.Add("onclick", "if(!confirm('确定完成选中的工作任务吗?')) return false;");
            this.btnGB.Attributes.Add("onclick", "if(!confirm('确定关闭选中的工作任务吗?')) return false;");
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
            //    HyperLink hyperLink = (HyperLink)e.Row.Cells[1].FindControl("HyperLink1");
            //    hyperLink.NavigateUrl = "javascript:toolbox_oncommand('/OA3/WorkTask/TaskView.aspx?action=view&id=" + this.GvList.DataKeys[e.Row.RowIndex].Values[0].ToString() + "','查看工作任务');";
            //    hyperLink.ForeColor = Color.Blue;
            }
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
        if (base.UserCode != "00000000")
        {
            strWhere += " and creater_id ='" + UserCode + "'";
        }
        strWhere += " and status !='5'";
        string strRYS = hfldTo.Value.ToString();//执行人
        if (!string.IsNullOrEmpty(strRYS))
        {
            string[] strXGR = strRYS.Split(',');
            string strs = "";
            foreach (string str in strXGR)
            {
                strs += "'" + str + "',";
            }
            strWhere += " and OA_Task.Id in (SELECT task_id FROM OA_Task_Append where user_id in (" + strs.Substring(0,strs.Length-1) + ") and (user_type=0 OR user_type=2))";
        }
                return strWhere;
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
    protected void btnWC_Click(object sender, EventArgs e)
    {
        toIng(3);
    }
    protected void btnGB_Click(object sender, EventArgs e)
    {
        toIng(4);
    }
    protected void btnSC_Click(object sender, EventArgs e)
    {
        toIng(5);
    }
    private void toIng(int status)
    {
        if (string.IsNullOrEmpty(this.KeyId.Value.ToString()))
        {
            base.RegisterShow("系统提示", "没有获取到选中项,请重新选择！");
            return;
        }
        string strTemp = this.KeyId.Value.ToString();
        string strIDs = "";
        if (strTemp.Split(',').Length>1)
        {
             strIDs = strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }
        else
        {
            strIDs = " ('" + strTemp + "')";//strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }
        
        if (status == 3 || status == 4)
        {
            string strSqlIF = "select * FROM OA_Task where status !=2 and Id in " + strIDs;
            DataTable dt = publicDbOpClass.DataTableQuary(strSqlIF);
            if (dt.Rows.Count > 0)
            {
                if (status == 3)
                {
                    base.RegisterShow("系统提示", "只能完成状态为\"执行中\"的数据,请重新选择！");
                    return;
                }
                if (status == 4)
                {
                    base.RegisterShow("系统提示", "只能关闭状态为\"执行中\"的数据,请重新选择！");
                    return;
                }
               
            }
        }
        if (status == 5)
        {
            string strSqlIF = "select * FROM OA_Task where status !=0 and Id in " + strIDs;
            DataTable dt = publicDbOpClass.DataTableQuary(strSqlIF);
            if (dt.Rows.Count > 0)
            {
                base.RegisterShow("系统提示", "只能删除状态为\"草稿中\"的数据,请重新选择！");
                return;
            }
        }
        string strSql = string.Format(@"UPDATE [OA_Task] SET [status] = '{1}',complete_time='{2}' WHERE [id] in {0}", strIDs, status,DateTime.Now);
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
            catch(Exception ex)
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\操作失败！"+ex.Message.ToString()+"');");
            }
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
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