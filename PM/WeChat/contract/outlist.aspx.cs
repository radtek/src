using cn.justwin.BLL;
using cn.justwin.contractBLL;
using cn.justwin.PrjManager;
using com.jwsoft.pm.data;
using DomainServices.cn.justwin.Domain.Services;
using PMBase.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeChat_contract_outlist : Page
{
    public string code = string.Empty;
    public string userType = string.Empty;
    public string status = string.Empty;
    public string userID = string.Empty;
    private static PayoutContract payoutContract = new PayoutContract();
    protected override void OnInit(System.EventArgs e)
    {
        this.code = base.Request["code"];
        if (HttpContext.Current.Session["yhdm"] == null || HttpContext.Current.Session["yhdm"].ToString().Length > 10)
        {
            try
            {
                string UserID = WXAPI.getUserIdByCode(code, "1000014");// "00200002";//
                HttpContext.Current.Session["yhdm"] = UserID;
            }
            catch (Exception ex)
            {

            }
        }
        //this.userType = base.Request["userType"];//用户类型
        //this.status = base.Request["status"];//任务状态
        this.userID = HttpContext.Current.Session["yhdm"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID.Value = userID;
    }

    [WebMethod]//标示为web服务方法属性
    public static string getList(string userId, string userType, string status,int rows, int page, string search)
    {
        string strRes2 = "";
        string strRes3 = "]}]";
        System.DateTime startDate = new System.DateTime(1753, 1, 1);
        System.DateTime endDate = new System.DateTime(9999, 12, 31);
        decimal startMoney = new decimal(-999999999999999L);
        decimal endMoney = new decimal(999999999999999L);
        //this.payoutContract.SelectLedger(startDate, endDate, startMoney, endMoney, this.txtContractCode.Text.Trim(), this.txtContractName.Text.Trim(), this.txtConType.Text.Trim(), this.txtProject.Text.Trim(), base.UserCode, text, this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize);
        DataTable dt = payoutContract.SelectLedger(startDate, endDate, startMoney, endMoney, "", search, "", "", userId, "", page, rows);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                strRes2 += "{\"ContractId\":\"" + dr["ContractID"] + "\",\"ContractCode\":\"" + dr["ContractCode"] + "\",\"ContractName\":\"" + dr["ContractName"] + "\",\"prjName\":\"" + dr["PrjName"] + "\",\"fictitious\":\"" + dr["fictitious"] + "\",\"TypeName\":\"" + dr["TypeName"] + "\",\"SignDate\":\"" + Common2.GetTime(dr["SignDate"]) + "\"},";
            }
            string strRes = " [{\"total\":\"" + dt.Rows.Count + "\",\"data\":[" + strRes2.Substring(0, strRes2.Length - 1) + strRes3;
            return strRes;
        }
        else
        {
            return "";
        }
    }
    /// <summary>
    /// 格式化字符串
    /// </summary>
    /// <param name="AStr"></param>
    /// <returns></returns>
    public static string GetFormatStr(string AStr)
    {

        if ("" == AStr)
            return "";

        else
        {
            AStr = AStr.Replace("\n", "<p>");
            AStr = AStr.Replace("\r", "<br>");
            AStr = AStr.Replace(" ", "&nbsp;&nbsp;");
            //AStr = AStr.Replace("<", "&lt;");
            //AStr = AStr.Replace(">", "&gt;");
            //AStr = AStr.Replace("'", "&apos;");
            //AStr = AStr.Replace("\"", "&quot;");
            //AStr = AStr.Replace("\"", "&quot;");
            //AStr = AStr.Replace("×", "&times;");
            //AStr = AStr.Replace("÷", "&divide;");
            return AStr;
        }
    }
    [WebMethod]//标示为web服务方法属性
    //删除方法 
    public static string deleteInfoByIds(string ids, string type)
    {
        string strWhere = " in (\'" + ids.Replace(",", "','") + "\')";
        if (type == "task")
        {
            string StrSql = "update OA_Task set status= 5 where id " + strWhere + ";";
            int ii = publicDbOpClass.ExecSqlString(StrSql);
            return ii.ToString();
        }
        else
        {
            return "";
        }
    }
}