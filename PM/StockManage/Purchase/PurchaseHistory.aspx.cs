using cn.justwin.BLL;
using cn.justwin.stockBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockManage_Purchase_PurchaseHistory : System.Web.UI.Page
{
    private SmPurchaseplanStockBll purchaseplanStockBll = new SmPurchaseplanStockBll();
    public string scode = string.Empty;

    protected override void OnInit(System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request["scode"]))
        {
            this.scode = base.Request["scode"];
        }
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Resource resource = new Resource();
        DataTable dataTable = resource.GetResourceHistory(scode); 
        if (dataTable.Rows.Count > 0)
        {
            this.gvwPurchaseplanStock.DataSource = dataTable;
            this.gvwPurchaseplanStock.DataBind();
        }
    }
    protected void gvwPurchaseplanStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Attributes["id"] = this.gvwPurchaseplanStock.DataKeys[e.Row.RowIndex].Value.ToString();
        }
    }
}