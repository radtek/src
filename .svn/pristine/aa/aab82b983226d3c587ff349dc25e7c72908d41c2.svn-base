using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using PMBase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WX_WxTemp : System.Web.UI.Page
{
    string code = string.Empty;
    string type = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.code = base.Request["code"];
        this.type = base.Request["type"];
        if (HttpContext.Current.Session["yhdm"] == null || HttpContext.Current.Session["yhdm"].ToString().Length > 10)
        {
            try
            {
                string UserID = "";
                if (type== "refundingListWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000020");// "00200002";//
                }
                if (type == "qoRefundingListWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000020");// "00200002";//
                }
                if (type == "outReserveWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000021");// "00200002";//
                }
                if (type == "qOutReserveWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000021");// "00200002";//
                }
                if (type == "wantPlanWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000022");// "00200002";//
                }
                if (type == "purchasePlanWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000022");// "00200002";//
                }
                if (type == "purchaseWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000022");// "00200002";//
                }
                if (type == "planPlaitWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000023");// "00200002";//
                }
                if (type == "planActualRptWX")
                {
                    UserID = WXAPI.getUserIdByCode(code, "1000023");// "00200002";//
                }
                HttpContext.Current.Session["yhdm"] = UserID;
                //HttpContext.Current.Session["PmSet"] = 1;
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            //HttpContext.Current.Session["yhdm"] = "00200002";
            //this.Session["PmSet"] = 1;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.BindProject2(this.prjcode.Text.Trim(), this.prjname.Text.Trim());
            PageType.Value = type;
            UserCode.Value = HttpContext.Current.Session["yhdm"].ToString();
        }
        //RegisterScript("reURl('"+ type + "','"+ HttpContext.Current.Session["yhdm"].ToString() + "');");
    }
    private void BindProject2(string code, string name)
    {
        System.Collections.Generic.IList<SelectProject> project = SelectProjectHelper.GetProject(HttpContext.Current.Session["yhdm"].ToString(), Parameters.PrjAvaildState5, code, name);
        this.gvwPrj.DataSource = project;
        this.gvwPrj.DataBind();
    }
    protected string GetOwnerName(object ownerId)
    {
        string result;
        try
        {
            XPMBasicContactCorpService xPMBasicContactCorpService = new XPMBasicContactCorpService();
            XPMBasicContactCorp byId = xPMBasicContactCorpService.GetById(System.Convert.ToInt32(ownerId));
            result = byId.CorpName;
        }
        catch
        {
            result = "";
        }
        return result;
    }
    protected void SearchBt_Click(object sender, System.EventArgs e)
    {
        this.BindProject2(this.prjcode.Text.Trim(), this.prjname.Text.Trim());
    }
    protected void gvwPrj_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvwPrj.PageIndex = e.NewPageIndex;
        this.BindProject2(this.prjcode.Text.Trim(), this.prjname.Text.Trim());
    }
    protected void gvwPrj_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["id"] = this.gvwPrj.DataKeys[e.Row.RowIndex]["Id"].ToString();
            e.Row.Attributes["code"] = this.gvwPrj.DataKeys[e.Row.RowIndex]["Code"].ToString();
            e.Row.Attributes["name"] = this.gvwPrj.DataKeys[e.Row.RowIndex]["Name"].ToString();
            e.Row.Attributes["typeCode"] = this.gvwPrj.DataKeys[e.Row.RowIndex]["TypeCode"].ToString();
            bool flag = System.Convert.ToBoolean(this.gvwPrj.DataKeys[e.Row.RowIndex]["IsParent"]);
            e.Row.Attributes["isMainContract"] = flag.ToString();
        }
    }
    protected void RegisterScript(string message)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<script type='text/javascript'>").Append(Environment.NewLine).Append(message).Append("</script>");
        base.ClientScript.RegisterStartupScript(base.GetType(), Guid.NewGuid().ToString(), builder.ToString());
    }
}