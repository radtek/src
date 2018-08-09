using cn.justwin.BLL;
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

public partial class WeChat_project_list : Page
{
    public string code = string.Empty;
    public string userType = string.Empty;
    public string status = string.Empty;
    public string userID = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.code = base.Request["code"];
        if (HttpContext.Current.Session["yhdm"] == null || HttpContext.Current.Session["yhdm"].ToString().Length > 10)
        {
            try
            {
                string UserID = WXAPI.getUserIdByCode(code, "1000013");// "00200002";//
                HttpContext.Current.Session["yhdm"] = UserID;
            }
            catch (Exception ex)
            {

            }
        }
        //this.userType = base.Request["userType"];//用户类型
        //this.status = base.Request["status"];//任务状态
        this.userID = HttpContext.Current.Session["yhdm"].ToString(); //HttpContext.Current.Session["yhdm"].ToString();//用户ID
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(userID))
        //{
            UserID.Value = userID;//WXAPI.getUserIdByCode(code); 
        //}
        //else
        //{
        //    UserID.Value = WXAPI.getUserIdByCode(code, "1000010"); //"00200002";//WXAPI.getUserIdByCode(code); //"00200002";//WXAPI.getUserIdByCode(code); 
        //}

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

        //DataTable allTenderPrjReport = ProjectInfo.GetAllTenderPrjReport(this.txtPrjCode.Text.Trim(), this.txtPrjName.Text.Trim(), this.txtName.Text.Trim(), this.dropPrjKindClass.SelectedValue, this.txtStartTime.Text.Trim(), this.txtEndTime.Text.Trim(), this.txtOwner.Text.Trim(), this.dropPrjState.SelectedValue, base.UserCode, this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize, this.dropPrjSource.SelectedValue, ref recordCount);
        int recordCount = 0;
        DataTable allTenderPrjReport = ProjectInfo.GetAllTenderPrjReport("", search, "", "", "", "", "", "", userId, page, rows, "", ref recordCount);
        if (allTenderPrjReport.Rows.Count > 0)
        {
            foreach (DataRow dr in allTenderPrjReport.Rows)
            {
                strRes2 += "{\"PrjGuid\":\"" + dr["PrjGuid"] + "\",\"PrjCode\":\"" + dr["PrjCode"] + "\",\"PrjName\":\"" + dr["PrjName"] + "\",\"PrjCost\":\"" + dr["PrjCost"] + "\",\"PrjStateName\":\"" + dr["PrjStateName"] + "\",\"Owner\":\"" + dr["Owner"] + "\",\"StartDate\":\"" + Common2.GetTime(dr["StartDate"]) + "\",\"IsTender\":\"" +dr["IsTender"] + "\"},";
            }
            string strRes = " [{\"total\":\"" + allTenderPrjReport.Rows.Count + "\",\"data\":[" + strRes2.Substring(0, strRes2.Length - 1) + strRes3;
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