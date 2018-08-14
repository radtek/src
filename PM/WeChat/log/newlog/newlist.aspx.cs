using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.jwsoft.pm.data;
using PMBase.Basic;
using System.Data;
using System.Web.Services;
public partial class WeChat_log_newlist : System.Web.UI.Page
{

    public string userID = string.Empty;
    public string mlname = string.Empty;
    public string keyID = string.Empty;
    public string code = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.code = base.Request["code"];
        this.userID = base.Request["userID"];
        this.keyID = base.Request["Id"];
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(userID))
        {
            UserID.Value = userID;
        }
        else
        {
            //1000012 appid
            UserID.Value = WXAPI.getUserIdByCode(code, "1000012"); //"00200002";//WXAPI.getUserIdByCode(code, "1000012"); //"00200002";//
        }

        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(keyID))
            {
                string strSql = "select top 1 Id from OA_File where Id=ParentId";
                DataTable dt = publicDbOpClass.DataTableQuary(strSql);
                if (dt.Rows.Count > 0)
                {
                    KeyId.Value = dt.Rows[0]["Id"].ToString();
                    //ParentId.Value = dt.Rows[0]["ParentId"].ToString();
                }
                else
                {
                    KeyId.Value = "";
                    //ParentId.Value = "";
                }
                bindMenuHead(dt.Rows[0]["Id"].ToString(), 0);
            }
            else
            {
                KeyId.Value = keyID.ToString();
                bindMenuHead(keyID, 1);
            }
        }
    }
    List<String> ls = new List<string>();
    private void bindMenuHead(string keyId, int ii)
    {
        string strWhere = string.Empty;
        if (ii == 0)
        {
            //strWhere = " and Id='" + keyId + "'";
            //DataTable dtA = FileService.GetFileInfo(strWhere);
            //String name = dtA.Rows[0]["FileName"].ToString();
            mlname = "<li onclick=\"window.location.href='../doc/list.aspx?id='\"><a>根目录</a></li>";
        }
        else
        {
            strWhere = " and Id='" + keyId + "' and ParentId !='" + keyId + "'";
            DataTable dtA = FileService.GetFileInfo(strWhere);
            if (dtA.Rows.Count > 0)
            {
                String name = dtA.Rows[0]["FileName"].ToString();
                if (name.Length > 5)
                {
                    name = name.Substring(0, 5) + "..";//目录名称长度大于5则截取5
                }
                ls.Add("<li onclick=\"window.location.href='../doc/list.aspx?id=" + dtA.Rows[0]["Id"].ToString() + "'\"><a>" + name + "</a></li>");//向集合中加入面包屑li元素
                bindMenuHead(dtA.Rows[0]["ParentId"].ToString(), 1);
            }
            else
            {
                if (ls.Count > 0)
                {
                    mlname = "<li onclick=\"window.location.href='../doc/list.aspx?id='\"><a>根目录</a></li>";
                    if (ls.Count <= 2)
                    {
                        for (int i = ls.Count - 1; i >= 0; i--)
                        {
                            mlname += ls[i];
                        }
                    }
                    else if (ls.Count > 2)
                    {
                        mlname = "<li onclick=\"window.location.href='../doc/list.aspx?id='\"><a>根目录</a></li><li><a >...</a></li>";
                        mlname += ls[1];
                        mlname += ls[0];
                        //for (int i = ls.Count - 1; i >= 0; i--)
                        //{
                        //    if (ls.Count - i == 0)
                        //    {
                        //        mlname += ls[i];
                        //        mlname += "<li><a >...</a></li>";
                        //    }
                        //}
                        //for (int i = ls.Count - 1; i >= 0; i--)
                        //{
                        //    if (ls.Count - i == 0)
                        //    {
                        //        mlname += ls[i];
                        //        mlname += "<li><a >...</a></li>";
                        //    }
                        //    if (i <= 1)
                        //        mlname += ls[i];
                        //}
                    }
                }
            }
        }
    }
    [WebMethod]//标示为web服务方法属性
    public static string getList(string UserID, string KeyId, int rows, int page, string search)
    {
        if (!string.IsNullOrEmpty(KeyId))
        {
            //string strRes1 = " [{\"total\":\"15\",\"data\":[";
            string strRes2 = "";
            string strRes3 = "]}]";
            string strW = "";
            string strSearch = "";
            //userType   //my 我已提交 ;sy 我执行的 ;xg 我相关的
            //if (userType == "cg") { strTemp = " and creater_id='" + userId + "' and status='0'"; }

            //if (userType == "tj") { strTemp = " and creater_id='" + userId + "' and status ='" + status + "'"; }

            //if (userType == "sy") { strTemp = " and OA_Task.Id IN(select task_id from OA_Task_Append where user_id='" + userId + "' and (user_type='0' or user_type='2')) and status ='" + status + "'"; }

            //if (userType == "xg") { strTemp = " and OA_Task.Id IN(select task_id from OA_Task_Append where user_id='" + userId + "' and (user_type='1' or user_type='2')) and status !='0' and status !='5'"; }
            string str1 = ((rows * (page - 1)) + 1).ToString();
            string str2 = (rows * page).ToString();
            //string strs = "  and  pageindex between " + str1 + " and " + str2;  
            strW = " and ParentId='" + KeyId + "' and Id !='" + KeyId + "' and OA_File.IsValid=0  ";

            if (!string.IsNullOrEmpty(search))
            {
                strSearch = " and title like '%" + search + "%'";
            }
            string strWhere = strW + strSearch;
            DataTable dtA = FileService.GetFileInfo(strWhere);
            DataRow[] rowAs = dtA.Select(" pageindex >=" + str1 + " and  pageindex<=" + str2);
            DataTable dtB = dtA.Clone();
            foreach (DataRow row in rowAs)
            {
                dtB.Rows.Add(row.ItemArray);
            }
            if (dtB.Rows.Count > 0)
            {
                foreach (DataRow dr in dtB.Rows)
                {
                    strRes2 += "{ \"id\": \"" + dr["Id"] + "\", \"title\": \"" + dr["FileName"] + "\", \"CreateTime\": \"" + dr["CreateTime"] + "\", \"fileType\": \"" + dr["FileType"] + "\", \"ext\": \"WJJ\" },";
                }
                string strRes = " [{\"total\":\"" + dtA.Rows.Count + "\",\"data\":[" + strRes2.Substring(0, strRes2.Length - 1) + strRes3;
                return strRes;
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }

}