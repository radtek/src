using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public partial class oa_JournalManage_JournalByProjectStatisticsList : NBasePage, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.AspNetPager1.PageSize = NBasePage.pagesize;
            this.KeyId.Value = base.Request["PrjGuid"].ToString();
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
        DataTable dt = this.GetMSg(startTime, endTime, this.KeyId.Value.ToString());
        //this.AspNetPager1.RecordCount = dt.Rows.Count;
        this.GvList.DataSource = dt;
        this.GvList.DataBind();
    }
    public DataTable GetMSg( DateTime? startTime, DateTime? endTime,string projectId)
    {
        StringBuilder builder = new StringBuilder();
        //builder.AppendFormat("\r\n                select * from (select row_number() over (order by addtime desc)as pageindex,b.*,p.prjname\r\n                from opm_epcm_builddiary as b  inner join pt_prjinfo as p  on  p.prjguid=b.prjid ", new object[0]).AppendLine();
        //builder.Append("JOIN PT_yhmc ON b.AddUser=PT_yhmc.v_yhdm AND PT_yhmc.v_xm LIKE '%" + creatorName + "%'").AppendLine();
        //builder.Append("where PrjID='" + pc + "'");
        //if (!string.IsNullOrEmpty(startTime.ToString()))
        //{
        //    builder.Append(" AND AddTime >='" + startTime + "'");
        //}
        //if (!string.IsNullOrEmpty(endTime.ToString()))
        //{
        //    builder.Append(" AND AddTime<='" + endTime + "'");
        //}
        //builder.Append(") as result where pageindex between " + str + " and " + str2);
        //return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), new SqlParameter[0]);
        //string str = ((pagesize * (pageindex - 1)) + 1).ToString();
        //string str2 = (pagesize * pageindex).ToString();
        string strDate = "";
        if (!string.IsNullOrEmpty(startTime.ToString()))
        {
            strDate+=" AND create_date >='" + startTime + "'";
        }
        if (!string.IsNullOrEmpty(endTime.ToString()))
        {
            strDate += " AND create_date<='" + endTime + "'";
        }
        string strSql = string.Format(@"SELECT creater,v_xm, COUNT(Id) counts, SUM(datediff(minute, start_time, end_time)) sums
                        FROM OA_Journal left join PT_yhmc on creater=v_yhdm
                        WHERE 1 = 1
                            AND status = 1
                            AND project_id = '{0}'  {1} 
                        GROUP BY creater,v_xm 	
                        union all 
						SELECT  '' creater,'合计'  v_xm, COUNT(Id) counts, SUM(datediff(minute, start_time, end_time)) sums
                        FROM OA_Journal
                        WHERE 1 = 1
                            AND status = 1
                            AND project_id = '{0}' {1}   ", projectId, strDate);
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