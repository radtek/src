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

public partial class StaticByXQ : NBasePage, IRequiresSessionState
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
        ////int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        //System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        //System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);
        ////DataTable dt = this.GetMSg(startTime, endTime, this.AspNetPager1.PageSize, currentPageIndex);//有分页
        //DataTable dt = this.GetMSg(startTime, endTime, this.KeyId.Value.ToString());
        //this.AspNetPager1.RecordCount = dt.Rows.Count;
        DataTable dt = this.GetMSg();
        this.GvList.DataSource = dt;
        this.GvList.DataBind();
    }

    private DataTable GetMSg()
    {
        string strSql = string.Format(@"          with t1 as( SELECT t.TaskId, t.TaskName,t.ResourceId,t.ResourceCode scode,t.ResourceQuantity,w.numberIng--,sws.number--sum(sws.number) numberIng-- ,sws.wpcode
            FROM (SELECT  PrjGuid,TaskId,ResourceId,TaskName,ResourceCode,sum(ResourceQuantity) ResourceQuantity FROM (
			SELECT btr.PrjGuid,btr.TaskId,btr.ResourceId,bt.TaskName,rs.ResourceCode,btr.ResourceQuantity 
            FROM Bud_TaskResource btr 
            LEFT JOIN Res_Resource rs on btr.ResourceId=rs.ResourceId 
            LEFT JOIN Bud_Task bt on btr.TaskId=bt.TaskId
            where btr.PrjGuid='{0}' 
			UNION ALL SELECT  bm.PrjId,bmt.TaskId,bmts.ResourceId,bt.TaskName,rs.ResourceCode,bmts.ResourceQuantity FROM Bud_ModifyTaskRes bmts 
			LEFT JOIN Bud_ModifyTask bmt ON bmts.ModifyTaskId=bmt.ModifyTaskId 
			LEFT JOIN Bud_Modify bm ON bmt.ModifyId=bm.ModifyId 
			LEFT JOIN Bud_Task bt on bmt.TaskId=bt.TaskId 
			LEFT JOIN Res_Resource rs on bmts.ResourceId=rs.ResourceId 
			WHERE bm.flowstate !=-2 and bm.PrjId='{0}' ) s
			GROUP BY PrjGuid,TaskId,ResourceId,TaskName,ResourceCode )t 
			LEFT JOIN 
            ( SELECT sws.scode,sws.TaskId,sum(sws.number) numberIng from Sm_Wantplan_Stock sws --sw.flowstate,sw.swcode,
			LEFT JOIN  Sm_Wantplan sw ON sws.wpcode=sw.swcode 
			WHERE sw.flowstate !=-2 and sw.swcode !='' 
			GROUP BY sws.scode,sws.TaskId ) w ON w.scode=t.ResourceCode AND w.TaskId=t.TaskId)
          SELECT t1.*,t2.*,rs.ResourceName from t1 LEFT JOIN ( select sws.scode,sum(sws.number) nums,sw.procode,(select sum(sos.number) outNums from Sm_out_Stock sos WHERE sos.wpcode in( select sws.wpcode from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' ) and sos.scode=sws.scode) outNums
												from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' 	
												GROUP BY sws.scode,sw.procode )
												 t2 on t1.scode=t2.scode 	
												 LEFT JOIN Res_Resource rs on t1.ResourceId=rs.ResourceId  ", base.Request["PrjGuid"].ToString());
        return publicDbOpClass.DataTableQuary(strSql);
    }

    //public DataTable GetMSg( DateTime? startTime, DateTime? endTime,string projectId)
    //{
    //    StringBuilder builder = new StringBuilder();
    //    //builder.AppendFormat("\r\n                select * from (select row_number() over (order by addtime desc)as pageindex,b.*,p.prjname\r\n                from opm_epcm_builddiary as b  inner join pt_prjinfo as p  on  p.prjguid=b.prjid ", new object[0]).AppendLine();
    //    //builder.Append("JOIN PT_yhmc ON b.AddUser=PT_yhmc.v_yhdm AND PT_yhmc.v_xm LIKE '%" + creatorName + "%'").AppendLine();
    //    //builder.Append("where PrjID='" + pc + "'");
    //    //if (!string.IsNullOrEmpty(startTime.ToString()))
    //    //{
    //    //    builder.Append(" AND AddTime >='" + startTime + "'");
    //    //}
    //    //if (!string.IsNullOrEmpty(endTime.ToString()))
    //    //{
    //    //    builder.Append(" AND AddTime<='" + endTime + "'");
    //    //}
    //    //builder.Append(") as result where pageindex between " + str + " and " + str2);
    //    //return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), new SqlParameter[0]);
    //    //string str = ((pagesize * (pageindex - 1)) + 1).ToString();
    //    //string str2 = (pagesize * pageindex).ToString();
    //    string strDate = "";
    //    if (!string.IsNullOrEmpty(startTime.ToString()))
    //    {
    //        strDate+=" AND create_date >='" + startTime + "'";
    //    }
    //    if (!string.IsNullOrEmpty(endTime.ToString()))
    //    {
    //        strDate += " AND create_date<='" + endTime + "'";
    //    }
    //    string strSql = string.Format(@"SELECT creater,v_xm, COUNT(Id) counts, SUM(datediff(minute, start_time, end_time)) sums
    //                    FROM OA_Journal left join PT_yhmc on creater=v_yhdm
    //                    WHERE 1 = 1
    //                        AND status = 1
    //                        AND project_id = '{0}'  {1} 
    //                    GROUP BY creater,v_xm 	
    //                    union all 
				//		SELECT  '' creater,'合计'  v_xm, COUNT(Id) counts, SUM(datediff(minute, start_time, end_time)) sums
    //                    FROM OA_Journal
    //                    WHERE 1 = 1
    //                        AND status = 1
    //                        AND project_id = '{0}' {1}   ", projectId, strDate);
    //    return publicDbOpClass.DataTableQuary(strSql);
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