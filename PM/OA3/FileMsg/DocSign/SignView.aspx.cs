using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

public partial class SignView : NBasePage
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
            this.BindDatas(Id, action);
        }

        this.InitPic();
        this.FileUpload1.RecordCode = this.Id;

        this.InitVoices();
        this.FileUpload3.RecordCode = this.Id;

        this.InitVideos();
        this.FileUpload4.RecordCode = this.Id;

        this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "SignFiles");
    }
    private void BindDatas(string Id, string action)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            string strSql = "select * from OA_File_Sign where Id='" + Id + "'";
            DataTable dt = publicDbOpClass.DataTableQuary(strSql);
            if (dt.Rows.Count > 0)
            {
                this.name.Text = dt.Rows[0]["name"].ToString();
                this.remark.Text = dt.Rows[0]["remark"].ToString();
                this.sign_time.Text = dt.Rows[0]["sign_time"].ToString();
            }
        }
    }
    public void InitPic()
    {
         string stra = base.Server.MapPath(base.Request.ApplicationPath);
        string path = stra.Substring(0,stra.Length-1) + this.FileUpload1.Folder + this.Id;
        if (System.IO.Directory.Exists(path))
        {
            string[] files = System.IO.Directory.GetFiles(path);
            string item = string.Empty;
            string text = string.Empty;
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            string[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                string path2 = array[i];
                text = System.IO.Path.GetFileName(path2);
                item = string.Concat(new string[]
                {
                    "../../..",
                    this.FileUpload1.Folder,
                    this.Id,
                    "/",
                    text
                });
                list.Add(item);
            }
            string value = JsonHelper.JsonSerializer<System.Collections.Generic.List<string>>(list);
            this.hfldImgPath.Value = value;
        }
    }
    private void InitVoices()//3
    {//+ base.Request.ApplicationPath
        string stra = base.Server.MapPath(base.Request.ApplicationPath);
        string path = stra.Substring(0,stra.Length-1) + this.FileUpload3.Folder + this.Id;
        if (System.IO.Directory.Exists(path))
        {
            string[] files = System.IO.Directory.GetFiles(path);
            string item = string.Empty;
            string text = string.Empty;
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            string[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                string path2 = array[i];
                text = System.IO.Path.GetFileName(path2);
                item = string.Concat(new string[]
                {
                    "../../..",
                    this.FileUpload3.Folder,
                    this.Id,
                    "/",
                    text
                });
                string[] strs = item.Split('/');
                string str = strs[strs.Length - 1];
                string str2 = str.Split('.')[1].ToString();
                voices += @"<audio controls style='float:left;margin-left: 15px;'><source src='" + item + "' type='audio/" + str2 + "'></audio>";
                list.Add(item);
            }
        }
    }
    private void InitVideos()//4
    {
        string stra = base.Server.MapPath(base.Request.ApplicationPath);
        string path = stra.Substring(0, stra.Length - 1) + this.FileUpload4.Folder + this.Id;
        if (System.IO.Directory.Exists(path))
        {
            string[] files = System.IO.Directory.GetFiles(path);
            string item = string.Empty;
            string text = string.Empty;
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            string[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                string path2 = array[i];
                text = System.IO.Path.GetFileName(path2);
                item = string.Concat(new string[]
                {
                     "../../..",
                    this.FileUpload4.Folder,
                    this.Id,
                    "/",
                    text
                });
                string[] strs = item.Split('/');
                string str = strs[strs.Length - 1];
                string str2 = str.Split('.')[1].ToString();
                videos += @"<video width='300' height='240' controls='controls' style='float:left;margin-left: 15px;'><source src = '" + item + "' type = 'video/" + str2 + "'></video>";
                list.Add(item);
            }
        }
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
                string text2 = array[i];
                string text3 = string.Empty;
                text3 = text2.Substring(text2.LastIndexOf("\\") + 1);
                string str = text + "/" + consID;
                string str2 = str + "/" + text3;
                text3 = string.Concat(new string[]
                {
                    "<a  class=\"link\" target=_blank  href=\"../../../Common/DownLoad.aspx?path=..",
                    HttpUtility.UrlEncode(str2),
                    "\"  >",
                    text3,
                    "</a>"
                });
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