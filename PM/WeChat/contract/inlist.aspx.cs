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

public partial class WeChat_contract_inlist : Page
{
    public string code = string.Empty;
    public string userType = string.Empty;
    public string status = string.Empty;
    public string userID = string.Empty;
    private static IncometContractBll incometContractBll = new IncometContractBll();
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
        ////string strRes1 = " [{\"total\":\"15\",\"data\":[";
        string strRes2 = "";
        string strRes3 = "]}]";
        //string strTemp = "";
        ////userType   //my 我已提交 ;sy 我执行的 ;xg 我相关的
        //if (userType == "cg") { strTemp = " and creater_id='" + userId + "' and status='0'"; }

        //if (userType == "tj") { strTemp = " and creater_id='" + userId + "' and status ='"+ status + "'"; }

        //if (userType == "sy") { strTemp = " and OA_Task.Id IN(select task_id from OA_Task_Append where user_id='" + userId + "' and (user_type='0' or user_type='2')) and status ='" + status + "'"; }

        //if (userType == "xg") { strTemp = " and OA_Task.Id IN(select task_id from OA_Task_Append where user_id='" + userId + "' and (user_type='1' or user_type='2')) and status !='0' and status !='5'"; }
        //string str1 = ((rows * (page - 1)) + 1).ToString();
        //string str2 = (rows * page).ToString();
        //string strs = "  and  pageindex between " + str1 + " and " + str2;
        //string str3 = "";
        //if (!string.IsNullOrEmpty(search))
        //{
        //    str3 = " and title like '%" + search + "%'";
        //}
        //string strWhere = strTemp + str3;
        //DataTable dtA = TaskService.GetTaskListTable(strWhere, userId);
        //DataRow[] rowAs = dtA.Select(" pageindex >=" + str1 + " and  pageindex<=" + str2);
        //DataTable dtB = dtA.Clone();
        //foreach (DataRow row in rowAs)
        //{
        //    dtB.Rows.Add(row.ItemArray);
        //}


        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.Append(" and IsArchived='false' ");
        //if (this.txtSignPeople.Value.Trim() != "")
        //{
        //    stringBuilder.AppendFormat("AND v_xm LIKE '%{0}%'", this.Replace(this.txtSignPeople.Value.Trim()));
        //}
        //if (this.txtParty.Value.Trim() != "")
        //{
        //    stringBuilder.AppendFormat("AND Party LIKE '%{0}%'", this.Replace(this.txtParty.Value.Trim()));
        //}
        //if (this.txtCParty.Text.Trim() != "")
        //{
        //    stringBuilder.AppendFormat("AND CParty LIKE '%{0}%'", this.Replace(this.txtCParty.Text.Trim()));
        //}
        // DataTable dt= incometContractBll.GetTbByParamSort(this.Replace(this.txtContractCode.Text.Trim()), this.Replace(this.txtContractName.Text.Trim()), this.Replace(this.txtConType.Text.Trim()), this.txtStartSignedTime.Text.Trim(), this.txtEndSignedTime.Text.Trim(), this.txtStartContractPrice.Text.Trim(), this.txtEndContractPrice.Text.Trim(), this.txtProject.Text.Trim(), base.UserCode, stringBuilder.ToString(), this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize);
        DataTable dt= incometContractBll.GetTbByParamSort("", search, "", "", "", "", "", "", userId, stringBuilder.ToString(), page, rows);
        
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                strRes2 += "{\"ContractId\":\"" + dr["ContractId"] + "\",\"ContractCode\":\"" + dr["ContractCode"] + "\",\"ContractName\":\"" + dr["ContractName"] + "\",\"prjName\":\"" + dr["prjName"] + "\",\"sign\":\"" + dr["sign"] + "\",\"TypeName\":\"" + dr["TypeName"] + "\",\"SignedTime\":\"" + Common2.GetTime(dr["SignedTime"]) + "\"},";
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