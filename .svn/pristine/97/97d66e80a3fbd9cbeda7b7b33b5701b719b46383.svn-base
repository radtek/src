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

public partial class OA3_WorkTask_TaskByUsersStatisticsList : NBasePage, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.AspNetPager1.PageSize = NBasePage.pagesize;
            TaskService.upDateStatus();
            this.txtStartTime.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");//开始日期
            this.txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");//结束日期
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
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);
        //DataTable dt = this.GetMSg(startTime, endTime, this.AspNetPager1.PageSize, currentPageIndex);//有分页
        DataTable dt = this.GetMSg(startTime, endTime, this.hfldTo.Value.ToString());
        //this.AspNetPager1.RecordCount = dt.Rows.Count;
        this.GvList.DataSource = dt;
        this.GvList.DataBind();
    }
    public DataTable GetMSg(DateTime? startTime, DateTime? endTime, string UsertId)
    {
        StringBuilder builder = new StringBuilder();
        string str = "";//"creater_id='00000000' and type_id !='' and 1=1";
        if (!string.IsNullOrEmpty(startTime.ToString()))
        {
            str+= " AND create_time >='" + startTime + "'";
        }
        if (!string.IsNullOrEmpty(endTime.ToString()))
        {
            str += " AND create_time<='" + endTime.Value.AddDays(1.0) + "'";
        }
        if (!string.IsNullOrEmpty(UsertId))
        {
            str += " AND OA_Task.creater_id ='" + UsertId + "'";
        }
        string strSql = string.Format(@"with t as(select 
--OA_Task.id,
--type_id,
--title,
--content,
--creater_id,
OA_Task_Append.user_id fzr_id,v_xm,
--create_time,
status,
count(OA_Task.id) counts
--start_time,
--end_time,
--complete_time,
--priority_id 
from OA_Task 
left join  OA_Task_Append on OA_Task.id=OA_Task_Append.task_id  
left join PT_yhmc on OA_Task_Append.user_id=v_yhdm 
where OA_Task.status!=0 and OA_Task.status!=7 and (OA_Task_Append.user_type='0' or OA_Task_Append.user_type='2') {0} 
 group by OA_Task_Append.user_id,status,v_xm )
 select fzr_id,v_xm
,max(case status when '1' then counts else 0 end) status1 --1未开始
,max(case status when '2' then counts else 0 end) status2 --2执行中
,max(case status when '3' then counts else 0 end) status3 --3已完成
,max(case status when '4' then counts else 0 end) status4 --4已关闭
--,max(case status when '5' then counts else 0 end) status5 --5逾期完成
--,max(case status when '6' then counts else 0 end) status6 --6已关闭
,sum(counts) statusAll --总计
 from t  group by  fzr_id,v_xm order by fzr_id", str);
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