using ASP;
using cn.justwin.BLL;
using cn.justwin.contractDAL;
using cn.justwin.contractModel;
using cn.justwin.stockBLL;
using cn.justwin.stockModel;
using cn.justwin.Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class StockManage_Purchase_PurchaseView : NBasePage, IRequiresSessionState
{
	private readonly Purchase purchase = new Purchase();
	private readonly PurchaseStock purchaseStock = new PurchaseStock();
	private string isWBSRelevance = ConfigHelper.Get("IsWBSRelevance");
	private readonly PTPrjInfoBll ptPrjInfo = new PTPrjInfoBll();
	private static readonly string resourceDataSourceName = "Resource";
	private string ic = string.Empty;
	private string pcode = string.Empty;
	private MeterialPlanStock meterialPlanStock = new MeterialPlanStock();
    private MeterialPlanStock materialStock = new MeterialPlanStock();
    protected override void OnInit(System.EventArgs e)
	{
		if (!string.IsNullOrEmpty(base.Request["ic"]))
		{
			this.ic = base.Request["ic"];
			this.pcode = this.purchase.GetCodeByGuid(this.ic);
		}
		if (!string.IsNullOrEmpty(base.Request["Pcode"]))
		{
			this.pcode = base.Request["Pcode"];
		}
		base.OnInit(e);
	}
	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.hfldIsWBSRelevance.Value = this.isWBSRelevance;
			if (!string.IsNullOrEmpty(this.pcode))
			{
				PurchaseModel model;
				if (this.pcode.Contains("["))
				{
					model = this.purchase.GetModel(JsonHelper.GetListFromJson(this.pcode)[0]);
				}
				else
				{
					model = this.purchase.GetModel(this.pcode);
				}
				this.lblPpcode.Text = model.pcode;
				this.DateInTime.Text = model.intime.ToString("yyyy-MM-dd");
				this.txtPerson.Text = model.person;
				this.lblExplain.Text = model.explain;
				if (!string.IsNullOrEmpty(model.Project))
				{
					PrjInfoModel modelByPrjGuid = this.ptPrjInfo.GetModelByPrjGuid(model.Project);
					if (modelByPrjGuid != null)
					{
						this.lblProject.Text = modelByPrjGuid.PrjName;
                      

                    }
					else
					{
						DataTable tableByPrjGuid = this.ptPrjInfo.GetTableByPrjGuid(model.Project);
						if (tableByPrjGuid.Rows.Count > 0)
						{
							this.lblProject.Text = tableByPrjGuid.Rows[0]["prjName"].ToString().Trim();
						}
					}
                }
				if (!string.IsNullOrEmpty(model.contract))
				{
					PayoutContract payoutContract = new PayoutContract();
					PayoutContractModel model2 = payoutContract.GetModel(model.contract);
					if (model2 != null)
					{
						this.lblContract.Text = model2.ContractName;
					}
				}
				DataTable prjID = this.purchaseStock.GetPrjID(this.pcode);
				string strPrjId = prjID.Rows[0][0].ToString();
				DataTable purchaseStockByPscode = this.purchaseStock.GetPurchaseStockByPscode(this.pcode, strPrjId, this.hfldIsWBSRelevance.Value);
                //预算数量
                DataColumn dataColumn6 = new DataColumn("BugetNum", typeof(string));
                dataColumn6.DefaultValue = 0.00;
                purchaseStockByPscode.Columns.Add(dataColumn6);
                //预算单价
                DataColumn dataColumn7 = new DataColumn("BugetPrice", typeof(string));
                dataColumn7.DefaultValue = 0.00;
                purchaseStockByPscode.Columns.Add(dataColumn7);
                //预算合计
                DataColumn dataColumn8 = new DataColumn("BugetSum", typeof(string));
                dataColumn8.DefaultValue = 0.00;
                purchaseStockByPscode.Columns.Add(dataColumn8);
                for (int i = 0; i < purchaseStockByPscode.Rows.Count; i++)
                {
                    DataRow dataRow = purchaseStockByPscode.Rows[i];
                    try
                    {
                        DataTable resByBud = this.materialStock.GetResByBud("", "", "", "", strPrjId, 1, 9999999, 1, isWBSRelevance, "");
                        if (resByBud.Rows.Count > 0)
                        {
                            DataRow[] drs = resByBud.Select(" ResourceCode='" + dataRow["ResourceCode"].ToString() + "'");
                            if (drs.Length > 0)
                            {
                                string BugetNum = drs[0]["ResourceQuantity"].ToString() == "" ? "0" : drs[0]["ResourceQuantity"].ToString();
                                string BugetPrice = drs[0]["ResourcePrice"].ToString() == "" ? "0" : drs[0]["ResourcePrice"].ToString();
                                if (!string.IsNullOrEmpty(BugetNum))
                                {
                                    dataRow["BugetNum"] = Convert.ToDecimal(BugetNum);
                                    dataRow["BugetPrice"] = Convert.ToDecimal(BugetPrice);
                                    dataRow["BugetSum"] = Convert.ToDecimal(BugetNum) * Convert.ToDecimal(BugetPrice);
                                }
                                else
                                {
                                    dataRow["BugetNum"] = 0.00;
                                    dataRow["BugetPrice"] = 0.00;
                                    dataRow["BugetSum"] = 0.00;
                                }
                            }
                        }
                        else
                        {
                            dataRow["BugetNum"] = 0.00;
                            dataRow["BugetPrice"] = 0.00;
                            dataRow["BugetSum"] = 0.00;
                        }
                    }
                    catch
                    {
                    }
                }


                this.ViewState[StockManage_Purchase_PurchaseView.resourceDataSourceName] = purchaseStockByPscode;
				this.DataBindPurchaseplanStock();
				this.DataBindDiff(prjID.Rows[0][1].ToString(), this.pcode);
				this.flAnnx.MID = 1801;
				this.flAnnx.FID = model.pid;
				this.flAnnx.Type = 1;
				this.lblBllProducer.Text = model.person;
				this.lblPrintDate.Text = System.DateTime.Now.ToShortDateString();
			}
		}
	}
	private void DataBindPurchaseplanStock()
	{
		if (this.ViewState[StockManage_Purchase_PurchaseView.resourceDataSourceName] is DataTable)
		{
			DataTable dataTable = this.ViewState[StockManage_Purchase_PurchaseView.resourceDataSourceName] as DataTable;
			if (dataTable.Rows.Count > 0)
			{
				GridViewUtility.DataBind(this.gvwPurchaseplanStock, dataTable);
				string total = System.Convert.ToDecimal(dataTable.Compute("SUM(Total)", string.Empty)).ToString("0.000");
				GridViewUtility.AddTotalRow(this.gvwPurchaseplanStock, total, 11);
				return;
			}
			this.gvwPurchaseplanStock.DataSource = null;
			this.gvwPurchaseplanStock.DataBind();
		}
	}
	private void DataBindDiff(string contractID, string strpcode)
	{
		DataTable diff = this.purchaseStock.GetDiff(contractID, strpcode, this.hfldIsWBSRelevance.Value);
		this.gvwDiff.DataSource = diff;
		this.gvwDiff.DataBind();
		if (diff.Rows.Count == 0)
		{
			this.diffTitle.Visible = false;
		}
	}
    protected void gvwPurchaseplanStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Attributes["id"] = this.gvwPurchaseplanStock.DataKeys[e.Row.RowIndex].Value.ToString();
            //GridViewRow row = e.Row;
            //判断是否为数据行（排除头部和底部）
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //找到所在单元格，索引从0开始
                string Total = this.gvwPurchaseplanStock.DataKeys[e.Row.RowIndex]["Total"].ToString() == "" ? "0" : this.gvwPurchaseplanStock.DataKeys[e.Row.RowIndex]["Total"].ToString();
                string BugetSum = this.gvwPurchaseplanStock.DataKeys[e.Row.RowIndex]["BugetSum"].ToString() == "" ? "0" : this.gvwPurchaseplanStock.DataKeys[e.Row.RowIndex]["BugetSum"].ToString();
                if (Convert.ToDecimal(BugetSum) == 0)
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
                else if (Convert.ToDecimal(BugetSum) < Convert.ToDecimal(Total))
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
                //e.Row.ForeColor = System.Drawing.Color.Red;                                                        
                //e.Row.Cells[17].ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnExecl_Click(object sender, System.EventArgs e)
    {
        DataTable dt = this.ViewState[StockManage_Purchase_PurchaseView.resourceDataSourceName] as DataTable;
        dt.Columns.Remove("psid");
        dt.Columns.Remove("pscode");
        dt.Columns.Remove("corp");
        dt.Columns.Remove("ResourceId");
        dt.Columns.Remove("arrivalDate1");
        dt.Columns.Remove("ReadyNumber");
        dt.Columns.Remove("Price");
        dt.Columns.Remove("scode");

        dt.Columns["ResourceCode"].ColumnName = "物资编号"; dt.Columns["物资编号"].SetOrdinal(0);
        dt.Columns["ResourceName"].ColumnName = "物资名称"; dt.Columns["物资名称"].SetOrdinal(1);
        dt.Columns["Specification"].ColumnName = "规格"; dt.Columns["规格"].SetOrdinal(2);
        dt.Columns["ModelNumber"].ColumnName = "型号"; dt.Columns["型号"].SetOrdinal(3);
        dt.Columns["brand"].ColumnName = "品牌"; dt.Columns["品牌"].SetOrdinal(4);
        dt.Columns["TechnicalParameter"].ColumnName = "技术参数"; dt.Columns["技术参数"].SetOrdinal(5);
        dt.Columns["Name"].ColumnName = "单位"; dt.Columns["单位"].SetOrdinal(6);
        //dt.Columns["scode"].ColumnName = "库存量";
        dt.Columns["number"].ColumnName = "数量"; dt.Columns["数量"].SetOrdinal(7);
        dt.Columns["sprice"].ColumnName = "采购价格"; dt.Columns["采购价格"].SetOrdinal(8);
        dt.Columns["Total"].ColumnName = "小计"; dt.Columns["小计"].SetOrdinal(9);
        dt.Columns["CorpName"].ColumnName = "供应商"; dt.Columns["供应商"].SetOrdinal(10);
        dt.Columns["arrivalDate"].ColumnName = "实际到货日期"; dt.Columns["实际到货日期"].SetOrdinal(11);
        dt.Columns["BugetNum"].ColumnName = "预算数量"; dt.Columns["预算数量"].SetOrdinal(12);
        dt.Columns["BugetPrice"].ColumnName = "预算价格"; dt.Columns["预算价格"].SetOrdinal(13);
        dt.Columns["BugetSum"].ColumnName = "预算小计"; dt.Columns["预算小计"].SetOrdinal(14);




        new Common2().ExportToExecelAll(dt, "编号_" + lblPpcode.Text.ToString() + "_物资采购列表"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls", base.Request.Browser.Browser);
    }
}


