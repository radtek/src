using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using System.Data;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI.WebControls;
public partial class CautionMoneyList : NBasePage, IRequiresSessionState
{
    private PCCautionMoneyService pcSer = new PCCautionMoneyService();
    private string userCode = string.Empty;

    protected override void OnInit(System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request["userCode"]))
        {
            this.userCode = base.Request["userCode"];
        }
        else
        {
            this.userCode = base.UserCode;
        }
        base.OnInit(e);
    }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.AspNetPager1.PageSize = NBasePage.pagesize;
            this.BindCautionMoney();
            this.hfldUserName.Value = base.GetUserName(this.userCode);
        }
    }
    protected void gvwPettyCash_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string value = this.gvwPettyCash.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindCautionMoney();
    }
    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        //System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
        //string value = this.hfldPettyCashIds.Value;
        //if (value.Contains("["))
        //{
        //	list = JsonHelper.GetListFromJson(value);
        //}
        //else
        //{
        //	list.Add(value);
        //}
        //this.pcSer.Delete(list);
        //base.RegisterShow("系统提示", "删除成功！");
        //this.BindCautionMoney();
    }
    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        this.BindCautionMoney();
    }
    protected void btnExportExcel_Click(object sender, System.EventArgs e)
    {
        //IQueryable<PCCautionMoney> source = this.Queryable();
        //source =
        //	from p in source
        //	orderby p.ApplicationDate descending
        //	orderby p.InputDate descending
        //	select p;
        //DataTable dataTable = new DataTable();
        //dataTable.Columns.Add("序号");
        //dataTable.Columns.Add("申请日期");
        //dataTable.Columns.Add("申请金额");
        //dataTable.Columns.Add("事项");
        //dataTable.Columns.Add("用款日期");
        //dataTable.Columns.Add("流程状态");
        //dataTable.Columns.Add("项目");
        //int num = source.Count<PCCautionMoney>();
        //System.Collections.Generic.List<PCCautionMoney> list = source.ToList<PCCautionMoney>();
        //for (int i = 0; i < num; i++)
        //{
        //	PCCautionMoney PCCautionMoney = list[i];
        //	DataRow dataRow = dataTable.NewRow();
        //	dataRow["序号"] = i + 1;
        //	dataRow["申请日期"] = PCCautionMoney.ApplicationDate.ToString("yyyy-MM-dd");
        //	dataRow["申请金额"] = PCCautionMoney.Cash;
        //	dataRow["事项"] = PCCautionMoney.Matter;
        //	dataRow["用款日期"] = PCCautionMoney.CashDate.ToString("yyyy-MM-dd");
        //	dataRow["流程状态"] = Common2.GetStateNoColor(PCCautionMoney.FlowState.ToString());
        //	if (PCCautionMoney.Project != null)
        //	{
        //		dataRow["项目"] = PCCautionMoney.Project.PrjName;
        //	}
        //	dataTable.Rows.Add(dataRow);
        //}
        //string text = "备用金申请.xls";
        //if (base.Request.Browser.Browser.ToUpper() != "SAFARI")
        //{
        //	text = HttpUtility.UrlEncode(text, System.Text.Encoding.UTF8);
        //}
        //ExcelHelper.ExportDataTableToExcel(dataTable, text, "");
    }
    private void BindCautionMoney()
    {
        IQueryable<PCCautionMoney> source = this.Queryable();
        this.AspNetPager1.RecordCount = source.Count<PCCautionMoney>();
        source =
            from p in source
            orderby p.ApplicationDate descending
            orderby p.InputDate descending
            select p;
        IQueryable<PCCautionMoney> dataSource = source.Skip((this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).Take(this.AspNetPager1.PageSize);
        this.gvwPettyCash.DataSource = dataSource;
        this.gvwPettyCash.DataBind();
    }
    private IQueryable<PCCautionMoney> Queryable()
    {
        //System.DateTime? startDate = DateTimeHelper.GetDateTime(this.txtStartDate.Text);
        //System.DateTime? endDate = DateTimeHelper.GetDateTime(this.txtEndDate.Text);
        //decimal? startCash = DecimalUtility.ConvertDecimal(this.txtStartCash.Text);
        //decimal? endCash = DecimalUtility.ConvertDecimal(this.txtEndCash.Text);
        //string matter = this.txtMatter.Text.Trim();
        IQueryable<PCCautionMoney> queryable =
            from p in this.pcSer
                //where p.FlowState==-1
            select p;
        //if (startDate.HasValue)
        //{
        //    queryable =
        //        from p in queryable
        //        where p.ApplicationDate >= startDate.Value
        //        select p;
        //}
        //if (endDate.HasValue)
        //{
        //    queryable =
        //        from p in queryable
        //        where p.ApplicationDate < endDate.Value.AddDays(1.0)
        //        select p;
        //}
        //if (startCash.HasValue)
        //{
        //    queryable =
        //        from p in queryable
        //        where p.Cash >= startCash.Value
        //        select p;
        //}
        //if (endCash.HasValue)
        //{
        //    queryable =
        //        from p in queryable
        //        where p.Cash <= endCash.Value
        //        select p;
        //}
        //if (!string.IsNullOrWhiteSpace(matter))
        //{
        //    queryable =
        //        from p in queryable
        //        where p.Matter.Contains(matter)
        //        select p;
        //}
        //if (this.userCode != "00000000")
        //{
        //    queryable =
        //        from p in queryable
        //        where p.ApplicantId == this.userCode
        //        select p;
        //}
        return queryable;
    }
}


