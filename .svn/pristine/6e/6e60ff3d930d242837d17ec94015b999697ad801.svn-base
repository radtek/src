using PMBase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WX_WxTest : System.Web.UI.Page
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
                string UserID = WXAPI.getUserIdByCode(code, "1000008");// "00200002";//
                HttpContext.Current.Session["yhdm"] = UserID;
                this.Session["PmSet"] = 0;
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            //HttpContext.Current.Session["yhdm"] = "00200002";
            //this.Session["PmSet"] = 0;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterScript("reURl('" + type + "','" + HttpContext.Current.Session["yhdm"] + "');");
    }
    protected void RegisterScript(string message)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<script type='text/javascript'>").Append(Environment.NewLine).Append(message).Append("</script>");
        base.ClientScript.RegisterStartupScript(base.GetType(), Guid.NewGuid().ToString(), builder.ToString());
    }
}