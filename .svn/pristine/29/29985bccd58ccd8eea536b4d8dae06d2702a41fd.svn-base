using ASP;
using cn.justwin.BLL;
using cn.justwin.stockBLL;
using com.jwsoft.pm.data;
using PMBase.Basic;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class StockManage_Report_Treasury : NBasePage, IRequiresSessionState
{
    string code = string.Empty;
    private TreasuryStockBll treasuryStock = new TreasuryStockBll();
    protected override void OnInit(System.EventArgs e)
    {
        this.code = base.Request["code"];
        if (HttpContext.Current.Session["yhdm"] == null || HttpContext.Current.Session["yhdm"].ToString().Length>10)
        {
            try
            {
                string UserID = WXAPI.getUserIdByCode(code, "1000015");// "00200002";//
                HttpContext.Current.Session["yhdm"] = UserID;
               // TextBox1.Text = UserID;
            }
            catch (Exception ex)
            {
                //TextBox1.Text = ex.Message.ToString();
            }
        }
       
        base.OnInit(e);
        base.InitBasePage();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.gvwTreasury.PageSize = NBasePage.pagesize;
		if (!base.IsPostBack)
		{
			this.DataBindTreasury(this.treasuryStock.GetReportDataSource(string.Empty, base.UserCode));
		}
        TextBox1.Text = HttpContext.Current.Session["yhdm"].ToString();

    }
	protected void btnSearch_Click(object sender, EventArgs e)
	{
		this.DataBindTreasury(this.GetTreasuryDataSource());
	}
	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable exportDataSource = this.GetExportDataSource();
		Common2 common = new Common2();
		common.ExportToExecelAll(exportDataSource, "仓库信息—按批次.xls", base.Request.Browser.Browser);
	}
	protected void gvwPurchase_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		this.gvwTreasury.PageIndex = e.NewPageIndex;
		this.DataBindTreasury(this.GetTreasuryDataSource());
	}
	private void DataBindTreasury(DataTable table)
	{
		if (table.Rows.Count == 0)
		{
			table.Rows.Add(table.NewRow());
			this.gvwTreasury.DataSource = table;
			this.gvwTreasury.DataBind();
			this.gvwTreasury.Rows[0].Visible = false;
			return;
		}
		this.gvwTreasury.DataSource = table;
		this.gvwTreasury.DataBind();
		string total = Convert.ToString(table.Compute("Sum(total)", string.Empty));
		GridViewUtility.AddTotalRow(this.gvwTreasury, total, 10);
	}
	private DataTable GetTreasuryDataSource()
	{
		DateTime startDate = string.IsNullOrEmpty(this.txtStartTime.Text.Trim()) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(this.txtStartTime.Text.Trim());
		DateTime endDate = string.IsNullOrEmpty(this.txtEndTime.Text.Trim()) ? new DateTime(2079, 6, 6) : Convert.ToDateTime(this.txtEndTime.Text.Trim()).AddDays(1.0);
		return this.treasuryStock.GetReportDataSource(startDate, endDate, this.txtResourceName.Text.Trim(), this.txtResourceCode.Text.Trim(), this.txtCorpName.Text.Trim(), this.txtTrea.Text.Trim(), this.txtCategory.Text.Trim(), base.UserCode, this.txtSpecification.Text.Trim(), this.txtBrand.Text.Trim(), this.txtModelNumber.Text.Trim());
	}
	public DataTable GetExportDataSource()
	{
		DataTable treasuryDataSource = this.GetTreasuryDataSource();
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("序号");
		dataTable.Columns.Add("资源编号");
		dataTable.Columns.Add("资源名称");
		dataTable.Columns.Add("规格");
		dataTable.Columns.Add("品牌");
		dataTable.Columns.Add("型号");
		dataTable.Columns.Add("技术参数");
		dataTable.Columns.Add("单位");
		dataTable.Columns.Add("单价");
		dataTable.Columns.Add("数量");
		dataTable.Columns.Add("小计");
		dataTable.Columns.Add("供应商");
		dataTable.Columns.Add("入库时间");
		dataTable.Columns.Add("仓库名称");
		if (treasuryDataSource.Rows.Count != 0)
		{
			int num = 0;
			foreach (DataRow dataRow in treasuryDataSource.Rows)
			{
				num++;
				DataRow dataRow2 = dataTable.NewRow();
				dataRow2["序号"] = num.ToString();
				dataRow2["资源编号"] = dataRow["scode"];
				dataRow2["资源名称"] = dataRow["resourceName"];
				dataRow2["规格"] = dataRow["Specification"];
				dataRow2["品牌"] = dataRow["Brand"];
				dataRow2["型号"] = dataRow["ModelNumber"];
				dataRow2["技术参数"] = dataRow["TechnicalParameter"];
				dataRow2["单位"] = dataRow["Name"];
				dataRow2["单价"] = dataRow["sprice"];
				dataRow2["数量"] = dataRow["snumber"];
				dataRow2["小计"] = dataRow["total"];
				dataRow2["供应商"] = dataRow["CorpName"];
				dataRow2["入库时间"] = dataRow["intime"];
				dataRow2["仓库名称"] = dataRow["tname"];
				dataTable.Rows.Add(dataRow2);
			}
			DataRow dataRow3 = dataTable.NewRow();
			dataRow3["序号"] = "合计";
			dataRow3["资源编号"] = "";
			dataRow3["资源名称"] = "";
			dataRow3["规格"] = "";
			dataRow3["品牌"] = "";
			dataRow3["型号"] = "";
			dataRow3["技术参数"] = "";
			dataRow3["单位"] = "";
			dataRow3["单价"] = "";
			dataRow3["数量"] = "";
			dataRow3["小计"] = treasuryDataSource.Compute("sum(total)", string.Empty).ToString();
			dataRow3["供应商"] = "";
			dataRow3["入库时间"] = "";
			dataRow3["仓库名称"] = "";
			dataTable.Rows.Add(dataRow3);
		}
		return dataTable;
	}
}


