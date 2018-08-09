using cn.justwin.DAL;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using Newtonsoft.Json.Linq;
using PMBase.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeChat_doc_show : Page
{
    //public string code = string.Empty;
    //public string action = string.Empty;
    public string Id = string.Empty;
    private string userID = string.Empty;
    //public string JD = string.Empty;
    public string mlname = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        //this.code = base.Request["code"];
        //this.action = base.Request["action"];
        this.Id = base.Request["ic"];
        this.userID = base.Request["userID"];//用户ID
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            //if (!string.IsNullOrEmpty(userID))
            //{
                UserID.Value = userID;//WXAPI.getUserIdByCode(code); 
            //}
            //else
            //{
            //    UserID.Value = WXAPI.getUserIdByCode(code, "1000010"); //"00200002";//WXAPI.getUserIdByCode(code); //"00200002";//WXAPI.getUserIdByCode(code); 
            //}
            this.KeyId.Value = Id;
            this.BindDatas(Id);
        }
        this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "DocFiles");
    }
    public string FilesBind(string consID, string config)
    {
        string text = ConfigHelper.Get(config);
        string result;
        try
        {
            string[] files = Directory.GetFiles(base.Server.MapPath(text) + consID);
            StringBuilder stringBuilder = new StringBuilder();
            string[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                string text2 = array[i];//E:\001.WORK\001.projects\001.工程项目管理系统(DX0316)\pm.src\PM\UploadFiles\DocFiles\6a768995-a6eb-4e6a-9f54-8d1840511aa5\wjj.svg
                string text3 = string.Empty;
                text3 = text2.Substring(text2.LastIndexOf("\\") + 1);
                string docType = text3.Split('.')[1].ToString();
                string str = text + "/" + consID;
                string str2 = str + "/" + text3;
                if (docType == "svg" || docType == "jpg")
                {
                    text3 = string.Concat(new string[]
                                   {
                                       //onclick="toolbox_oncommand('/OA3/FileMsg/DocSign/DocSign.aspx?id="+HttpUtility.UrlEncode(text3)+"&hid="+consID+"&path="+HttpUtility.UrlEncode(str2)+"\',\'标注\')
                    //"<a  class=\"link\" target=_blank  href=\"../../OA3/FileMsg/DocSign/DocSign.aspx?id="+HttpUtility.UrlEncode(text3)+"&hid="+consID+"&path="+HttpUtility.UrlEncode(str2)+"\">"+ text3+"[标注] </a>"
                    "<a  class=\"link\" onclick=\"showPic('/WeChat/DocSign/DocSignM.aspx?userID="+this.userID+"&doc_name="+HttpUtility.UrlEncode(text3)+"&doc_Id="+consID+"&path="+HttpUtility.UrlEncode(str2)+"\',\'标注_"+HttpUtility.UrlEncode(text3)+"\')\">"+ text3+"[标注] </a></br>"
                                   });
                }
                else
                {
                    text3 = string.Concat(new string[]
                {
                    "<a  class=\"link\" target=_blank  href=\"../../Common/DownLoad.aspx?path=",
                    HttpUtility.UrlEncode(str2),
                    "\"  >",
                    text3,
                    "</a>"
                });
                }

                stringBuilder.Append(text3);
                stringBuilder.Append(", ");
            }
            string text4 = string.Empty;
            if (stringBuilder.Length > 2)
            {
                text4 = stringBuilder.ToString().Substring(0, stringBuilder.Length - 2);
            }
            result = text4;
        }
        catch
        {
            result = "";
        }
        return result;
    }
    private void BindDatas(string Id)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            bindMenuHead(Id, 1);
            string strWhere = " and OA_File.id='" + Id + "'";
            DataTable dt = FileService.GetFileInfo(strWhere);
            if (dt.Rows.Count > 0)
            {
                this.KeyId.Value = Id;
                this.v_xm.Text = dt.Rows[0]["v_xm"].ToString();
                this.CreateTime.Text = dt.Rows[0]["CreateTime"].ToString();
                this.DocEditUserName.Text = dt.Rows[0]["DocEditUserName"].ToString();
                this.DocEditDate.Text = dt.Rows[0]["DocEditDate"].ToString();
                this.FileName.Text = dt.Rows[0]["FileName"].ToString();
                this.DocSort.Text = dt.Rows[0]["DocSort"].ToString();
                this.DocCode.Text = dt.Rows[0]["DocCode"].ToString();
                this.Remark.Text = dt.Rows[0]["Remark"].ToString();
                this.DocAuthor.Text = dt.Rows[0]["DocAuthor"].ToString();
                this.DocVersionName.Text = dt.Rows[0]["DocVersionName"].ToString();
                this.DocStatusName.Text = dt.Rows[0]["DocStatusName"].ToString();
                this.DocTypeName.Text = dt.Rows[0]["DocTypeName"].ToString();
                this.DocChangeTypeName.Text = dt.Rows[0]["DocChangeTypeName"].ToString();
                this.DocChangeRemark.Text = dt.Rows[0]["DocChangeRemark"].ToString();
                //this.DocRelationIDs.Text = "<a  class=\"link\" target=_blank onclick=\'toolbox_oncommand(\'\\OA3\\FileMsg\\DocView.aspx?ic="+ dt.Rows[0]["DocRelationIDs"].ToString() + "&DocAttribute="+ dt.Rows[0]["DocAttribute"].ToString() + "\' href =\"#\">"+ dt.Rows[0]["DocRelationName"].ToString() + " </a>";//dt.Rows[0]["DocRelationIDs"].ToString();
                this.DocRelationIDs.Text = "<a class=\"link\" onclick=showDoc('" + dt.Rows[0]["DocRelationIDs"].ToString() + "')>" + dt.Rows[0]["DocRelationName"].ToString() + "</a>";
                //int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
                //string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
                //string str2 = (pagesize * currentPageIndex).ToString();
                string strW = " and DocAncestorID ='" + dt.Rows[0]["DocAncestorID"].ToString() + "' and OA_File.id !='" + Id + "' ";
                DataTable dtA = FileService.GetFileInfo(strW);
                //DataRow[] rows = dtA.Select(" pageindex >=" + str + " and  pageindex<=" + str2);
                //DataTable dtB = dtA.Clone();
                //foreach (DataRow row in rows)
                //{
                //    dtB.Rows.Add(row.ItemArray);
                //}
                //this.AspNetPager1.PageSize = NBasePage.pagesize;
                //this.AspNetPager1.RecordCount = dtA.Rows.Count;
                this.gvFile.DataSource = dtA;// dtB;
                this.gvFile.DataBind();
                if (dtA.Rows.Count > 0)
                {
                    t1.Visible = true;
                    t2.Visible = true;
                }
                else
                {
                    t1.Visible = false;
                    t2.Visible = false;
                }
                if (dt.Rows[0]["DocAttribute"].ToString() == "2")//文档变更
                {
                    change1.Visible = true;
                    change2.Visible = true;
                    this.ShowAudit1.BusiCode = "173";
                    ShowAudit1.Visible = false;
                }
                else
                {
                    change1.Visible = false;
                    change2.Visible = false;
                    if (dt.Rows[0]["DocAttribute"].ToString() == "0")//初版审批
                    {
                        this.ShowAudit1.BusiCode = "173";
                    }
                    else if (dt.Rows[0]["DocAttribute"].ToString() == "1")//升版审批
                    {
                        this.ShowAudit1.BusiCode = "174";
                    }
                    else
                    {
                        this.ShowAudit1.BusiCode = "173";
                        ShowAudit1.Visible = false;
                    }
                }
               
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
                if (dtA.Rows[0]["FileType"].ToString()=="2")
                {
                    ls.Add("<li onclick=\"window.location.href='../doc/list.aspx?id=" + dtA.Rows[0]["Id"].ToString() + "'\"><a>" + name + "</a></li>");//向集合中加入面包屑li元素
                }
                else
                {
                    ls.Add("<li onclick=\"window.location.href='../doc/show.aspx?ic=" + dtA.Rows[0]["Id"].ToString() + "'\"><a>" + name + "</a></li>");//向集合中加入面包屑li元素
                }
               
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
}