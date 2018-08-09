using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.WebControls;


public partial class OA3_WorkLog_MyLogList : NBasePage, IRequiresSessionState
{
    private OAJournalService pcSer = new OAJournalService();
    private string time = string.Empty;

    private string action = string.Empty;
    private string taskId = string.Empty;
    string[,,] SpecialDays = new string[3000, 13, 32];
    public int a, b, c;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.btnDel.Attributes.Add("onclick", "if(!confirm('确定删除该工作日志吗?')) return false;");
            dropBind();
            try
            {
                time = base.Request["time"].ToString();
                action = base.Request["action"].ToString();
                taskId = base.Request["taskId"].ToString();
                if (!string.IsNullOrEmpty(time))
                {
                    txtStartTime.Text = time;
                    txtEndTime.Text = time;
                }
            }
            catch(Exception ex)
            {
               
            }
            if (action == "view")
            {
                t1.Visible = false;
                t2.Visible = false;
            }
            else
            {
                t1.Visible = true;
                t2.Visible = true;
            }
            this.DataBinds();
            Calendar1.VisibleDate = Calendar1.TodaysDate;
        }
        string strWhere = " and creater ='" + UserCode + "'";
        DataTable dt = pcSer.GetMsgTable(strWhere, UserCode);
        foreach (DataRow dr in dt.Rows)
        {
            a = int.Parse(DateTime.Parse(dr["start_time"].ToString()).Year.ToString());
            b = int.Parse(DateTime.Parse(dr["start_time"].ToString()).Month.ToString());
            c = int.Parse(DateTime.Parse(dr["start_time"].ToString()).Day.ToString());
            SpecialDays[a, b, c] = "";
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DisplaySelection();
    }
    private void DisplaySelection()
    {
        string str1 = Calendar1.SelectedDate.Date.ToString();

        string strMonth = null;
        if (Calendar1.SelectedDate.Month.ToString().Length < 2)
        {
            strMonth = "0" + Calendar1.SelectedDate.Month.ToString();
        }
        else
        {
            strMonth = Calendar1.SelectedDate.Month.ToString();
        }
        string strDay = null;
        if (Calendar1.SelectedDate.Day.ToString().Length < 2)
        {
            strDay = "0" + Calendar1.SelectedDate.Day.ToString();
        }
        else
        {
            strDay = Calendar1.SelectedDate.Day.ToString();
        }
        string str2 = Calendar1.SelectedDate.Year.ToString() + "-" + strMonth + "-" + strDay;
        Response.Redirect("MyLogList.aspx?time=" + str2);
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Controls.Clear();
        }
        else
        {
            Style SpecialDayStyle = new Style();
            //SpecialDayStyle.BackColor = System.Drawing.Color.FromArgb(0x55, 0xAF, 0xEB);
            SpecialDayStyle.ForeColor = System.Drawing.Color.Red;
            //SpecialDayStyle.BorderColor = System.Drawing.Color.FromArgb(0xE1, 0xE1, 0xE1);
            //SpecialDayStyle.Font.Size = FontUnit.Parse("12pt");

            try
            {
                string MyDay = SpecialDays[e.Day.Date.Year, e.Day.Date.Month, e.Day.Date.Day];

                if (MyDay != null)
                {

                    e.Cell.ApplyStyle(SpecialDayStyle);
                }
            }
            catch (Exception exc)
            {
                Response.Write(exc.ToString());
            }

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
            hyperLink.NavigateUrl = "javascript:toolbox_oncommand('/OA3/WorkLog/MyLogView.aspx?action=view&id=" + this.GvList.DataKeys[e.Row.RowIndex].Values[0].ToString() + "','查看工作日志');";
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
        this.type_id.Items.Insert(0, new ListItem("", ""));
    }
   
    protected void DataBinds()
    {
        int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
        string str2 = (pagesize * currentPageIndex).ToString();
        DataTable dtA = pcSer.GetMsgTable(strWhere(), UserCode);
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
            strWhere += " and OA_Journal.start_time >='" + startTime.Value + "'";
        }
        if (endTime.HasValue)
        {
            strWhere += " and OA_Journal.start_time <'" + endTime.Value.AddDays(1.0) + "'";
        }
        System.DateTime? stime = DateTimeHelper.GetDateTime(this.stime.Text);
        System.DateTime? etime = DateTimeHelper.GetDateTime(this.etime.Text);
        if (stime.HasValue)
        {
            strWhere += " and OA_Journal.create_date >='" + stime.Value + "'";
        }
        if (etime.HasValue)
        {
            strWhere += " and OA_Journal.create_date <'" + etime.Value.AddDays(1.0) + "'";
        }

        if (!string.IsNullOrEmpty(txtTitle.Text))
        {
            strWhere += " and OA_Journal.title like '%" + txtTitle.Text .ToString().Trim()+ "%'";
        }
        if (!string.IsNullOrEmpty(proName.Text))
        {
            strWhere += " and PT_PrjInfo.PrjName like '%" + proName.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(taskName.Text))
        {
            strWhere += " and OA_Task.title like '%" + taskName.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(taskId)) 
        {
            strWhere += " and OA_Task.id = '" + taskId + "'";
        }
        if (type_id.SelectedValue != "")
        {
            strWhere += " and OA_Journal.type_id ='" + type_id.SelectedValue + "'";
        }
        if (status.SelectedValue != "")
        {
            strWhere += " and OA_Journal.status ='" + Convert.ToInt32(status.SelectedValue) + "'";
        }
        if (base.UserCode != "00000000" && action != "view")
        {
            strWhere += " and OA_Journal.creater ='" + UserCode + "'";
        }
        return strWhere;
    }
   

    protected void btnExecl_Click(object sender, System.EventArgs e)
    {
        DataTable dt = pcSer.GetMsgTable(strWhere(), UserCode);
        dt.Columns.Remove("Id");
        dt.Columns.Remove("type_id");
        dt.Columns.Remove("project_id");
        dt.Columns.Remove("creater");
        dt.Columns.Remove("task_id");
        dt.Columns.Remove("ifck");
        dt.Columns.Remove("plAll");
        dt.Columns.Remove("plNew");
        dt.Columns["pageindex"].ColumnName = "序号";
        dt.Columns["typeName"].ColumnName = "日志类型名称";
        dt.Columns["PrjName"].ColumnName = "项目名称";
        dt.Columns["title"].ColumnName = "日志标题";
        dt.Columns["v_xm"].ColumnName = "创建人";
        dt.Columns["status"].ColumnName = "日志状态";
        dt.Columns["start_time"].ColumnName = "开始时间";
        dt.Columns["end_time"].ColumnName = "结束时间";
        dt.Columns["longs"].ColumnName = "持续时间(分钟)";
        dt.Columns["content"].ColumnName = "日志内容";
        dt.Columns["taskName"].ColumnName = "任务名称";
        dt.Columns["create_date"].ColumnName = "填写时间"; 
        dt.Columns["syr"].ColumnName = "审阅人";
        dt.Columns["xgr"].ColumnName = "相关人";
        new Common2().ExportToExecelAll(dt, "日志信息.xls", base.Request.Browser.Browser);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
        //string value = this.KeyId.Value;
        // string str = value.Replace('[','(').Replace(']', ')').Replace('"','\'');
        string strTemp = this.KeyId.Value.ToString();
        string strIDs = "";
        if (strTemp.Split(',').Length > 1)
        {
            strIDs = strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }
        else
        {
            strIDs = " ('" + strTemp + "')";//strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }

        string strSqlA = "select * FROM OA_Journal where status=1 and Id in " + strIDs;
        DataTable dt = publicDbOpClass.DataTableQuary(strSqlA);
        if(dt.Rows.Count>0)
       {
            base.RegisterShow("系统提示", "已提交的日志不能删除,请重新选择！");
            return;
        }

        string strSql = "DELETE FROM OA_Journal where Id in " + strIDs;
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
        //if (value.Contains("["))
        //{
        //    list = JsonHelper.GetListFromJson(value);
        //}
        //else
        //{
        //    list.Add(value);
        //}
        //this.pcSer.Delete(list);
        //base.RegisterShow("系统提示", "删除成功！");
       
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