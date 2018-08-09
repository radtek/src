using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public partial class StatisticByTaskList : NBasePage, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.AspNetPager1.PageSize = NBasePage.pagesize;
            TaskService.upDateStatus();
            //this.txtStartTime.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");//开始日期
            //this.txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");//结束日期
            //this.KeyId.Value = base.Request["PrjGuid"].ToString();
            this.DataBinds();
        }
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string value = this.GvList.DataKeys[e.Row.RowIndex].Value.ToString();
        //    e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
        //}
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
    }
    protected void DataBinds()
    {
        //int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        //System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        //System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);
        //DataTable dt = this.GetMSg(startTime, endTime, this.AspNetPager1.PageSize, currentPageIndex);//有分页
        DataTable dt = this.GetMSg();
        //this.AspNetPager1.RecordCount = dt.Rows.Count;
        this.GvList.DataSource = dt;
        this.GvList.DataBind();
    }
    public DataTable GetMSg()
    {
        StringBuilder builder = new StringBuilder();
        string str = "";//"creater_id='00000000' and type_id !='' and 1=1";
        //if (!string.IsNullOrEmpty(startTime.ToString()))
        //{
        //    str+= " AND ot.start_time >='" + startTime + "'";
        //}
        //if (!string.IsNullOrEmpty(endTime.ToString()))
        //{
        //    str += " AND ot.start_time<='" + endTime.Value.AddDays(1.0) + "'";
        //}
        
        if (!string.IsNullOrEmpty(title.Text.ToString()))
        {
            str += " and  ot.title like '%" + title.Text.ToString().Trim() + "%'";
        }
        if (status.SelectedValue != "")
        {
            str += " and ot.status ='" + Convert.ToInt32(status.SelectedValue) + "'";
        }
        //if (!string.IsNullOrEmpty(UsertId))
        //{
        //    str += " AND ot.creater_id ='" + UsertId + "'";
        //}
        string strSql = string.Format(@"SELECT t.*,ot.id,ot.title,ot.creater_id,PT_yhmc.v_xm,ot.status,CASE WHEN ot.status=0 THEN '<span style=''color:#050505;''>草稿中</span>'  WHEN ot.status=1 THEN '<span style=''color:#914229;''>未开始</span>' WHEN ot.status=2 THEN '<span style=''color:#030310;''>执行中</span>' WHEN ot.status=3 THEN '<span style=''color:#008B45;''>已完成</span>' WHEN ot.status=4 THEN '<span style=''color:#dadada;''>已关闭</span>' END status_name, 
ot.start_time,ot.end_time
,(SELECT top 1 PT_yhmc.v_xm FROM OA_Task_Append  LEFT JOIN PT_yhmc ON OA_Task_Append.user_id=PT_yhmc.v_yhdm WHERE OA_Task_Append.Task_id=ot.Id and (user_type=0 OR user_type=2) order by OA_Task_Append.id desc) syr --执行人名称

FROM ( SELECT  task_id,count(Id) counts, SUM(datediff(minute, start_time, end_time)) sums
                        FROM OA_Journal WHERE task_id is not NULL
												GROUP BY task_id )t 
												left join OA_Task ot on t.task_id=ot.id  
												 LEFT JOIN PT_yhmc ON ot.creater_id=PT_yhmc.v_yhdm where 1=1 {0}", str);
        return publicDbOpClass.DataTableQuary(strSql);
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