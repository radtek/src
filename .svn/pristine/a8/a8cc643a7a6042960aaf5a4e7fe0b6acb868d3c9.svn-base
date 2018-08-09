using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeChat_DocSign_SignViewM : System.Web.UI.Page
{
    private string action = string.Empty;
    private string Id = string.Empty;
    private string Name = string.Empty;
    private string x = string.Empty;
    private string y = string.Empty;
    private string doc_Id = string.Empty;
    private string doc_name = string.Empty;
    private string path = string.Empty;
    public string voices = string.Empty;
    public string videos = string.Empty;
    public string userID = string.Empty;
    
    protected override void OnInit(System.EventArgs e)
    {
        this.action = base.Request["action"];
        this.Id = base.Request["id"];
        this.Name = base.Request["name"];
        this.x = base.Request["x"];
        this.y = base.Request["y"];
        this.doc_Id = base.Request["doc_Id"];
        this.doc_name = base.Request["doc_name"];
        this.path = base.Request["path"];
        this.userID = base.Request["userID"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.DocId.Value = doc_Id;
            this.DocName.Value = doc_name;
            this.DocPath.Value = path;
            this.KeyId.Value = Id;
            this.UserID.Value = userID;
            this.BindDatas(Id, action);
        }

        //this.InitPic();
        //this.FileUpload1.RecordCode = this.Id;

        //this.InitVoices();
        //this.FileUpload3.RecordCode = this.Id;

        //this.InitVideos();
        //this.FileUpload4.RecordCode = this.Id;

        //this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "SignFiles");
    }
    private void BindDatas(string Id, string action)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            string strSql = "select * from OA_File_Sign where Id='" + Id + "'";
            DataTable dt = publicDbOpClass.DataTableQuary(strSql);
            if (dt.Rows.Count > 0)
            {
                this.name.InnerHtml = dt.Rows[0]["name"].ToString();
                this.remark.InnerHtml = dt.Rows[0]["remark"].ToString();
                this.sign_time.InnerHtml = dt.Rows[0]["sign_time"].ToString();
                if (dt.Rows[0]["user_Id"].ToString()== this.userID.ToString()) {
                    this.ifWrite.Visible = true;
                }else
                {
                    this.ifWrite.Visible = false;
                }
            }
        }
    }
}