using cn.justwin.BLL;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public partial class OA3_WorkLog_StatisticByEvaluate : NBasePage, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.stime.Text = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd");//开始时间//DateTime.Now.ToString("yyyy-MM-dd HH:mm");//开始时间
            this.etime.Text = DateTime.Now.ToString("yyyy-MM-dd");//开始时间//DateTime.Now.ToString("yyyy-MM-dd HH:mm");//开始时间
            this.DataBinds();
        }
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
    }
    protected void DataBinds()
    {
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.stime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.etime.Text);
        this.GvList.DataSource = this.GetMSg(startTime, endTime, this.hfldTo.Value.ToString());
        this.GvList.DataBind();
    }
    public DataTable GetMSg(DateTime? startTime, DateTime? endTime, string UsertId)
    {
       
        StringBuilder builder = new StringBuilder();
        string str = ""; 
        //     if (!string.IsNullOrEmpty(score.SelectedValue.ToString()))
        //{
        //    if (score.SelectedValue.ToString()!="0")
        //    {
        //        str += " AND score ='" + score.SelectedValue.ToString() + "'";
        //    }
        //    else
        //    {
        //        str += " AND score is NULL ";
        //    }
        //}
        if (!string.IsNullOrEmpty(startTime.ToString()))
        {
            str += " AND start_time >='" + startTime + "'";
        }
        if (!string.IsNullOrEmpty(endTime.ToString()))
        {
            str += " AND start_time<='" + endTime.Value.AddDays(1.0) + "'";
        }
        if (!string.IsNullOrEmpty(UsertId))
        {
            string strs = "'" + UsertId.Replace(",", "','") + "'";
            str += " AND creater in (" + strs + ")";
        }

        string strSql = string.Format(@" select creater,v_xm
 ,max(case score when '1' then counts else 0 end) status1 --1未开始
,max(case score when '2' then counts else 0 end) status2 --2执行中
,max(case score when '3' then counts else 0 end) status3 --3已完成
,max(case score when '0' then counts else 0 end) status0 --4已关闭
,sum(counts) statusAll --总计
 from (
   select creater,v_xm,score,count(Id) counts from (
 select OA_Journal.*,v_xm,(select top 1  case when score is null then '0' else score  end score from OA_Journal_Append where journal_id=OA_Journal.id and (user_type=0 or user_type=2)) score from OA_Journal 
    left join PT_yhmc on OA_Journal.creater=v_yhdm 
 where OA_Journal.status!=0  {0}
   ) t
   group by creater,v_xm,score 
   ) ss group by  creater,v_xm order by creater", str);
        DataTable dt = publicDbOpClass.DataTableQuary(strSql);
        //DataTable dt2 = publicDbOpClass.DataTableQuary(strSql2);
       // DataTable dts = dt.Copy();// + dt2.Copy();
        //foreach (DataRow row in dt2.Rows)
        //{
        //    dts.Rows.Add(row.ItemArray);
        //}
        return dt;
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