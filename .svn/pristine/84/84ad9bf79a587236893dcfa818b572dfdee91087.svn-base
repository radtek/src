using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.stockBLL;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public partial class OA3_WorkLog_JournalByProjectCost : NBasePage, IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.AspNetPager1.PageSize = NBasePage.pagesize;
            //this.KeyId.Value = base.Request["PrjGuid"].ToString();
            txtStartTime.Text = DateTime.Now.ToString("yyyy-MM"); 
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
    private PtYhmcBll ptyhBll = new PtYhmcBll();
    BasicConfigService basicConfigService = new BasicConfigService();
    protected void DataBinds()
    {
        //int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);//(this.txtEndTime.Text);
        //DataTable dt = this.GetMSg(startTime, endTime, this.AspNetPager1.PageSize, currentPageIndex);//有分页
        DataTable dt = this.GetMSg(startTime, endTime, this.hfldTo.Value.ToString());
        DataTable dataTable = this.ptyhBll.GetSaMonthInfoReport("1", "", "", Convert.ToDateTime(startTime).Year, Convert.ToDateTime(startTime).Month, "", 0, 0);//(this.DepartmentId, userCode, userName, year, month, this.ddlIsPayoff.SelectedValue.Trim(), 0, 0);
        dt.Columns.Add("sfgz");//实发工资
        dt.Columns.Add("gsgz");//工时工资(分钟)
        dt.Columns.Add("rgcb");//人工成本
        try
        {
            int hour = Convert.ToInt32(basicConfigService.GetValue("workHours"));
            int day = Convert.ToInt32(basicConfigService.GetValue("workDays"));
            if (dt.Rows.Count>0) {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["creater"].ToString()))
                    {
                        string str = string.Empty;//月 实发工资
                        DataRow[] drs = dataTable.Select(" v_yhdm='"+ dr["creater"].ToString() + "' ");
                        if (drs.Length > 0)
                        {
                            foreach (DataRow drN in drs)
                            {
                                str = drN["实发工资"].ToString();
                                break;
                            }
                        }
                        Double de = 0.00;
                        try
                        {
                            de = Convert.ToDouble(str);
                        }
                        catch
                        {
                            de = 0.00;
                        }
                        Double d2 = de / (day * hour * 60);
                        dr["sfgz"]= str.ToString();//实发工资
                        dr["gsgz"]= d2.ToString();//工时工资(分钟)
                        dr["rgcb"] = d2 * Convert.ToDouble(dr["sums"].ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            base.RegisterScript("alert('系统提示：\\n\\出现异常,请稍后重试或联系技术人员！'" + ex.Message + ");");
        }
        

        this.GvList.DataSource = dt;
        this.GvList.DataBind();
    }
    public DataTable GetMSg(DateTime? startTime, DateTime? endTime, string UsertId)
    {
        StringBuilder builder = new StringBuilder();
        string str = "";
        if (!string.IsNullOrEmpty(startTime.ToString()))
        {
            str += " AND start_time >='" + startTime + "'";
        }
        if (!string.IsNullOrEmpty(endTime.ToString()))
        {
            str += " AND start_time <'" + Convert.ToDateTime(endTime).AddMonths(1) + "'";
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