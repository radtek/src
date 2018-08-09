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

public partial class oa_JournalManage_JournalByUsersStatisticsList : NBasePage, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.AspNetPager1.PageSize = NBasePage.pagesize;
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
        string str = "";
        if (!string.IsNullOrEmpty(startTime.ToString()))
        {
            str+= " AND create_date >='" + startTime + "'";
        }
        if (!string.IsNullOrEmpty(endTime.ToString()))
        {
            str += " AND create_date<='" + endTime + "'";
        }
        if (!string.IsNullOrEmpty(UsertId))
        {
            str += " AND creater ='" + UsertId + "'";
        }
        string strSql = string.Format(@"SELECT creater,v_xm, COUNT(Id) counts, SUM(datediff(minute, start_time, end_time)) sums
                        FROM OA_Journal 
												left join PT_yhmc on creater=v_yhdm 
                        WHERE 1 = 1
                            AND status = 1 {0}
                        GROUP BY creater,v_xm
												
 												union all 
SELECT '' creater,'合计 ' v_xm, COUNT(Id) counts, SUM(datediff(minute, start_time, end_time)) sums
                        FROM OA_Journal 
												left join PT_yhmc on creater=v_yhdm 
                        WHERE 1 = 1 {0}
                            AND status = 1  
												", str);
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