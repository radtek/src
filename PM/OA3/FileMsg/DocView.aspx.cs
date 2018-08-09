using cn.justwin.Web;
using System;
using System.Data;
using System.Web;
using System.IO;
using System.Text;
using cn.justwin.BLL;
using System.Web.UI.WebControls;

public partial class OA3_FileMsg_DocView : NBasePage
{
    private string Id = string.Empty;
    protected override void OnInit(EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request["id"]))
        {
            this.Id = base.Request["id"].ToString();
        }
        if (!string.IsNullOrEmpty(base.Request["ic"]))
        {
            this.Id = base.Request["ic"].ToString();
        }
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            if (!string.IsNullOrEmpty(base.Request["DocAttribute"]))
            {
                string a = base.Request["DocAttribute"].ToString();
                if (a == "0")//初版审批
                {
                    this.ShowAudit1.BusiCode = "173";
                }
                if (a == "1")//升版审批
                {
                    this.ShowAudit1.BusiCode = "174";
                }
                if (a == "2")//文档变更 无审批
                {
                    this.ShowAudit1.BusiCode = "173";
                    ShowAudit1.Visible = false;
                }
            }
            else
            {
                this.ShowAudit1.BusiCode = "173";
                ShowAudit1.Visible = false;
            }
            this.BindDatas(Id);
        }
        this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "DocFiles");
    }
    private void BindDatas(string Id)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            string strWhere = " and OA_File.id='" + Id + "'";
            DataTable dt = FileService.GetFileInfo(strWhere);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DocAttribute"].ToString() == "2")//文档变更
                {
                    change1.Visible = true;
                    change2.Visible = true;
                }
                else
                {
                    change1.Visible = false;
                    change2.Visible = false;
                }
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
                this.DocRelationIDs.Text = "<a class=\"link\" onclick=showDoc('"+ dt.Rows[0]["DocRelationIDs"].ToString() + "','"+dt.Rows[0]["DocAttribute"].ToString()+"')>" + dt.Rows[0]["DocRelationName"].ToString()+"</a>";
                this.PrjName.Text= dt.Rows[0]["PrjName"].ToString();
                int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
                string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
                string str2 = (pagesize * currentPageIndex).ToString();
                string strW = " and DocAncestorID ='" + dt.Rows[0]["DocAncestorID"].ToString() + "' and OA_File.id !='" + Id + "' ";
                DataTable dtA = FileService.GetFileInfo(strW);
                DataRow[] rows = dtA.Select(" pageindex >=" + str + " and  pageindex<=" + str2);
                DataTable dtB = dtA.Clone();
                foreach (DataRow row in rows)
                {
                    dtB.Rows.Add(row.ItemArray);
                }
                this.AspNetPager1.PageSize = NBasePage.pagesize;
                this.AspNetPager1.RecordCount = dtA.Rows.Count;
                this.gvFile.DataSource = dtB;
                this.gvFile.DataBind();
                if (dtA.Rows.Count>0)
                {
                    t1.Visible = true;
                    t2.Visible = true;
                }else
                {
                    t1.Visible = false;
                    t2.Visible = false;
                }
            }
        }
    }
    protected void gvFile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = this.gvFile.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
            }
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindDatas(Id);
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
                    "<a  class=\"link\" onclick=\"toolbox_oncommand('/OA3/FileMsg/DocSign/DocSign.aspx?doc_name="+HttpUtility.UrlEncode(text3)+"&doc_Id="+consID+"&path="+HttpUtility.UrlEncode(str2)+"\',\'标注_"+HttpUtility.UrlEncode(text3)+"\')\">"+ text3+"[标注] </a>"
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
}