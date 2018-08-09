using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using com.jwsoft.pm.data;
using com.jwsoft.pm.entpm.action;
using PMBase.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class WxSet : System.Web.UI.Page
{
    BasicConfigService basicConfigService = new BasicConfigService();
    PTYhmcService PTYhmcService = new PTYhmcService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            domain.Text = basicConfigService.GetValue("domain");
            corpId.Text = basicConfigService.GetValue("corpId");
            corpSecret.Text = basicConfigService.GetValue("corpSecret");
            journalIfCheckTime.SelectedValue= basicConfigService.GetValue("journalIfCheckTime");
            journalIfScore.SelectedValue = basicConfigService.GetValue("journalIfScore");
            ifMoreBudget.SelectedValue = basicConfigService.GetValue("ifMoreBudget");
            AgentId_log.Text = basicConfigService.GetValue("AgentId_log");

            Secret_log.Text = basicConfigService.GetValue("Secret_log");

            AgentId_task.Text = basicConfigService.GetValue("AgentId_task");

            Secret_task.Text = basicConfigService.GetValue("Secret_task");

            AgentId_doc.Text = basicConfigService.GetValue("AgentId_doc");

            Secret_doc.Text = basicConfigService.GetValue("Secret_doc");

            Secret_txl.Text = basicConfigService.GetValue("Secret_txl");

            workHours.Text = basicConfigService.GetValue("workHours");

            workDays.Text = basicConfigService.GetValue("workDays");

            AgentId_Treasury.Text = basicConfigService.GetValue("AgentId_Treasury");

            Secret_Treasury.Text = basicConfigService.GetValue("Secret_Treasury");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strdomain = domain.Text.Trim().ToString();
        string strcorpId = corpId.Text.Trim().ToString();
        string strcorpSecret = corpSecret.Text.Trim().ToString();
        try
        {
            BasicConfig byName = basicConfigService.GetByName("domain");
            byName.ParaValue = domain.Text.Trim().ToString();
            basicConfigService.Update(byName);

            BasicConfig byName2 = basicConfigService.GetByName("corpId");
            byName2.ParaValue = corpId.Text.Trim().ToString();
            basicConfigService.Update(byName2);

            BasicConfig byName3 = basicConfigService.GetByName("corpSecret");
            byName3.ParaValue = corpSecret.Text.Trim().ToString();
            basicConfigService.Update(byName3);

            BasicConfig byName4 = basicConfigService.GetByName("journalIfCheckTime");
            byName4.ParaValue = journalIfCheckTime.SelectedValue.ToString();
            basicConfigService.Update(byName4);

            BasicConfig byName5 = basicConfigService.GetByName("journalIfScore");
            byName5.ParaValue = journalIfScore.SelectedValue.ToString();
            basicConfigService.Update(byName5);


            BasicConfig byName6 = basicConfigService.GetByName("AgentId_log");
            byName6.ParaValue = AgentId_log.Text.Trim().ToString();
            basicConfigService.Update(byName6);

            BasicConfig byName7 = basicConfigService.GetByName("Secret_log");
            byName7.ParaValue = Secret_log.Text.Trim().ToString();
            basicConfigService.Update(byName7);

            BasicConfig byName8 = basicConfigService.GetByName("AgentId_task");
            byName8.ParaValue = AgentId_task.Text.Trim().ToString();
            basicConfigService.Update(byName8);

            BasicConfig byName9 = basicConfigService.GetByName("Secret_task");
            byName9.ParaValue = Secret_task.Text.Trim().ToString();
            basicConfigService.Update(byName9);

            BasicConfig byName10 = basicConfigService.GetByName("AgentId_doc");
            byName10.ParaValue = AgentId_doc.Text.Trim().ToString();
            basicConfigService.Update(byName10);

            BasicConfig byName11 = basicConfigService.GetByName("Secret_doc");
            byName11.ParaValue = Secret_doc.Text.Trim().ToString();
            basicConfigService.Update(byName11);

            BasicConfig byName12 = basicConfigService.GetByName("Secret_txl");
            byName12.ParaValue = Secret_txl.Text.Trim().ToString();
            basicConfigService.Update(byName12);

            BasicConfig byName13 = basicConfigService.GetByName("workHours");
            byName13.ParaValue = workHours.Text.Trim().ToString();
            basicConfigService.Update(byName13);

            BasicConfig byName14 = basicConfigService.GetByName("workDays");
            byName14.ParaValue = workDays.Text.Trim().ToString();
            basicConfigService.Update(byName14);


            BasicConfig byName15 = basicConfigService.GetByName("AgentId_Treasury");
            byName15.ParaValue = AgentId_Treasury.Text.Trim().ToString();
            basicConfigService.Update(byName15);

            BasicConfig byName16 = basicConfigService.GetByName("Secret_Treasury");
            byName16.ParaValue = Secret_Treasury.Text.Trim().ToString();
            basicConfigService.Update(byName16);

            BasicConfig byName17 = basicConfigService.GetByName("ifMoreBudget");
            byName17.ParaValue = ifMoreBudget.SelectedValue.ToString();
            basicConfigService.Update(byName17);
            
            string script = "\r\n\t\t\t\t\t<script>\r\n\t\t\t\t\t\ttop.ui.show( '设置成功!');\r\n\t\t\t\t\t</script>\r\n\t\t\t\t";
            base.ClientScript.RegisterStartupScript(base.GetType(), Guid.NewGuid().ToString(), script);
        }
        catch
        {
            string script2 = "\r\n\t\t\t\t\t<script>\r\n\t\t\t\t\t\ttop.ui.show( '设置失败!');\r\n\t\t\t\t\t</script>\r\n\t\t\t\t";
            base.ClientScript.RegisterStartupScript(base.GetType(), Guid.NewGuid().ToString(), script2);
        }
        return;
    }
    
    protected void btnToBD_Click(object sender, EventArgs e)
    {
        //string strToken = WXAPI.getToken();
    }
    protected void btnToWX_Click(object sender, EventArgs e)
    {
        //string strToken = WXAPI.getToken();
        //Hashtable allUser = base.Cache["USERLIST"] as Hashtable;
        //if (allUser == null)
        //{
        //    allUser = PTYhmcService.GetAllUser();
        //}

        //DataTable dt = PersonnelAction.QueryPersonnelById(SqlStringConstructor.GetQuotedString(array[1]));
        //string strRe = WXAPI.createWXry(dt.Rows[0]);
        //if (strRe != "0")
        //{
        //    //this.JS.Text = "top.ui.alert('同步到微信失败！');";
        //}
        //else { }

        //foreach (DictionaryEntry de in allUser)
        //{
        //    //Console.WriteLine("Key：" + de.Key + " | Values：" + de.Value);
        //}
    }
}


//		httpCookie.Expires = DateTime.MaxValue;
//		base.Response.Cookies.Set(httpCookie);

//    POST数据到HTTPS站点，用它来登录百度：

//string loginUrl = "https://passport.baidu.com/?login";  
//string userName = "userName";  
//string password = "password";  
//string tagUrl = "http://cang.baidu.com/"+userName+"/tags";  
//Encoding encoding = Encoding.GetEncoding("gb2312");  

//IDictionary<string, string> parameters = new Dictionary<string, string>();  
//parameters.Add("tpl", "fa");  
//parameters.Add("tpl_reg", "fa");  
//parameters.Add("u", tagUrl);  
//parameters.Add("psp_tt", "0");  
//parameters.Add("username", userName);  
//parameters.Add("password", password);  
//parameters.Add("mem_pass", "1");  
//HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, null, null, encoding, null);  
//string cookieString = response.Headers["Set-Cookie"]; 

//发送GET请求到HTTP站点
//    string userName = "userName";
//string tagUrl = "http://cang.baidu.com/" + userName + "/tags";
//CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
//response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, cookies);  

//    发送POST请求到HTTP站点
//        string loginUrl = "http://home.51cto.com/index.php?s=/Index/doLogin";
//    string userName = "userName";
//    string password = "password";

//    IDictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("email", userName);  
//parameters.Add("passwd", password);  

//HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, null, null, Encoding.UTF8, null);
