using ASP;
using cn.justwin.BLL;
using cn.justwin.stockBLL;
using com.jwsoft.pm.entpm.action;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class PurchaseHistory : NBasePage, IRequiresSessionState
{
    private SmPurchaseplanStockBll purchaseplanStockBll = new SmPurchaseplanStockBll();
    public string scode = string.Empty;
    Resource resource = new Resource();
    protected override void OnInit(System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request["scode"]))
        {
            this.scode = base.Request["scode"];
        }
        base.OnInit(e);
    }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindView();
        }
    }
    private void BindView()
    {
        this.gvwPurchaseplanStock.DataSource = resource.GetResourceHistory(strWhere());
        this.gvwPurchaseplanStock.DataBind();
    }

    private string strWhere()
    {
        string str = " AND scode = '" + scode + "'";
        if (!string.IsNullOrEmpty(Brand.Text.ToString()))
        {
            str = str + " AND Res_Resource.Brand='" + Brand.Text.ToString() + "' ";
        }
        if (!string.IsNullOrEmpty(ModelNumber.Text.ToString()))
        {
            str = str + " AND Res_Resource.ModelNumber='" + ModelNumber.Text.ToString() + "' ";
        }
        return str;
    }

    protected void searcheBt_Click(object sender, System.EventArgs e)
    {
        this.BindView();
    }
    protected void btnExecl_Click(object sender, System.EventArgs e)
    {
        DataTable dt = resource.GetResourceHistory(strWhere()); 
        dt.Columns.Remove("psid");
        dt.Columns["ResourceCode"].ColumnName = "物资编号";
        dt.Columns["ResourceName"].ColumnName = "物资名称";
        dt.Columns["Specification"].ColumnName = "规格";
        dt.Columns["ModelNumber"].ColumnName = "型号";
        dt.Columns["brand"].ColumnName = "品牌";
        dt.Columns["TechnicalParameter"].ColumnName = "技术参数";
        dt.Columns["number"].ColumnName = "数量";
        dt.Columns["sprice"].ColumnName = "采购价格";
        dt.Columns["Total"].ColumnName = "小计";
        dt.Columns["CorpName"].ColumnName = "供应商";
        dt.Columns["arrivalDate"].ColumnName = "实际到货日期";
        new Common2().ExportToExecelAll(dt, "历史采购价.xls", base.Request.Browser.Browser);
    }
}
