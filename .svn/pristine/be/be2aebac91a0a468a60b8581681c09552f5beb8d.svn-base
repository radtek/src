using cn.justwin.DAL;
using com.jwsoft.pm.data;
using PMBase.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeChat_DocSign_SignEditM : System.Web.UI.Page
{
    public string code = string.Empty;
    private string userID = string.Empty;

    private string action = string.Empty;
    private string Id = string.Empty;
    private string Name = string.Empty;
    private string x = string.Empty;
    private string y = string.Empty;
    private string doc_Id = string.Empty;
    private string doc_name = string.Empty;
    private string path = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.code = base.Request["code"];
        this.userID = base.Request["userID"];//用户ID'

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
            //if (!string.IsNullOrEmpty(userID))
            //{
                UserID.Value = userID;//WXAPI.getUserIdByCode(code); 
            //}
            //else
            //{
            //    UserID.Value = WXAPI.getUserIdByCode(code, "1000012"); //"00200002";// WXAPI.getUserIdByCode(code); //"00200002";//
            //    //RegisterScript(UserID.Value);
            //}

            this.DocId.Value = doc_Id;
            this.DocName.Value = doc_name;
            this.DocPath.Value = path;
            DocAction.Value = action;
            if (this.action == "add")
            {
                string strGUID = System.Guid.NewGuid().ToString();
                this.KeyId.Value = strGUID;
            }
            else
            {
                this.KeyId.Value = Id;
                this.BindDatas(Id, action);
            }
        }
        //this.FileUpload1.RecordCode = this.KeyId.Value;//绑定图片
        //this.FileUpload2.RecordCode = this.KeyId.Value;//绑定附件
        //this.FileUpload3.RecordCode = this.KeyId.Value;//绑定音频
        //this.FileUpload4.RecordCode = this.KeyId.Value;//绑定视频
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
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveData();
    }
    public void saveData()
    {
        string strSql = "";
        if (this.action == "add")
        {
            strSql = string.Format(@"INSERT INTO [OA_File_Sign]
           ([Id]
           ,[doc_Id]
           ,[doc_name]
           ,[name]
           ,[user_Id]
           ,[sign_x]
           ,[sign_y]
           ,[remark]
           ,[if_del]
           ,[sign_time])
     VALUES
           (
		    '{0}'
           ,'{1}'
           ,'{2}'
           ,'{3}'
           ,'{4}'
           ,'{5}'
           ,'{6}'
           ,'{7}'
            ,{8}
           ,'{9}');", this.KeyId.Value, doc_Id, doc_name, this.name.Text.ToString(), this.userID, x, y, this.remark.Text.ToString(), 0, DateTime.Now);
        }
        else if (this.action == "edit")
        {
            strSql = string.Format(@"
               UPDATE [OA_File_Sign]
                  SET [name] = '{1}' 
                     ,[remark] = '{2}' 
                      ,sign_time='{3}' 
                WHERE [Id]= '{0}' "
                , this.KeyId.Value
                , this.name.Text.ToString()
                , this.remark.Text.ToString()
                , DateTime.Now.ToString()
                );
        }
        else if (this.action == "Reedit")
        {
            strSql = string.Format(@"
               UPDATE [OA_File_Sign]
                  SET [name] = '{1}' 
                     ,[remark] = '{2}' 
                      ,sign_time='{3}'
                     ,[sign_x]='{4}'
                    ,[sign_y] ='{5}'
                WHERE [Id]= '{0}' "
                , this.KeyId.Value
                , this.name.Text.ToString()
                , this.remark.Text.ToString()
                , DateTime.Now.ToString(), x, y
                );
        }
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();

                #region 保存 图片及音频
                string imgIds = imgId.Value.ToString();
                string voiceIds = voiceId.Value.ToString();
                if (action == "add")
                {
                    if (!string.IsNullOrEmpty(imgIds))
                    {
                        saveImgOrVoice(imgIds, this.KeyId.Value, "img");
                    }
                    if (!string.IsNullOrEmpty(voiceIds))
                    {
                        saveImgOrVoice(voiceIds, this.KeyId.Value, "voice");
                    }
                }
                else if (action == "edit" || action == "Reedit")
                {
                    if (!string.IsNullOrEmpty(imgIds))
                    {
                        saveImgOrVoice(imgIds, this.KeyId.Value, "img");
                    }
                    if (!string.IsNullOrEmpty(voiceIds))
                    {
                        saveImgOrVoice(voiceIds, this.KeyId.Value, "voice");
                    }
                }
                #endregion 保存 图片及音频
                RegisterScript("alert('系统提示：\\n\\保存成功！');reURl('"+ userID + "','"+ doc_name + "','"+ doc_Id + "','"+ path + "');");// parent.location.reload();
                //stringBuilder.Append("parent.location.reload();");
                //base.RegisterScript("top.ui.tabSuccess({parentName:'_DocList'});");
            }
            catch
            {
                sqlTransaction.Rollback();
                RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }
    /// <summary>
    /// 保存图片 or 语音
    /// </summary>
    /// <param name="Ids">服务器文件ID</param>
    /// <param name="KeyId">ID</param>
    /// <param name="type">img 图片;voice 语音</param>
    private static void saveImgOrVoice(string Ids, string KeyId, string type)
    {
        if (!string.IsNullOrEmpty(Ids))
        {
            string[] strImgs = Ids.Substring(0, Ids.Length - 1).Split(',');
            HttpContext context = HttpContext.Current;
            string str1 = HttpContext.Current.Server.MapPath("/");
            string str3 = KeyId;
            string str2 = "";//ConfigHelper.Get("JournalVoices");
            string pathTemp = "";
            string path = "";
            if (type == "img")
            {
                str2 = "/UploadFiles/SignPhotos/";//ConfigHelper.Get("JournalPhotos");
                pathTemp = str1.Substring(0, str1.Length - 1) + str2 + str3 + "\\";
            }
            else if (type == "voice")
            {
                str2 = "/UploadFiles/SignVoices/";//ConfigHelper.Get("JournalVoices");
                pathTemp = str1.Substring(0, str1.Length - 1) + str2 + str3 + "Temp\\";
                path = str1.Substring(0, str1.Length - 1) + str2 + str3 + "\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            if (!Directory.Exists(pathTemp))
            {
                Directory.CreateDirectory(pathTemp);
            }
            foreach (string strID in strImgs)
            {
                //string  str11 = "BdlTq2kWT4JhM_YsLdJIgg_xBhWa3-3ZyCXMBilIFdqNx2Sen2AdDO5QDY2XDCvW";
                string tagUrl = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token=" + WXAPI.getTokenByAgentId(1000012) + "&media_id=" + strID + "";
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, null);
                string str = response.Headers.ToString();
                string strfwqFilename = str.Split('"')[1];//文件名及后缀
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                Stream stream = new FileStream(pathTemp + strfwqFilename, FileMode.Create);//保存文件到服务器目录
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                stream.Close();
                responseStream.Close();
                if (type == "voice")
                {
                    string paths = str1.Substring(0, str1.Length - 1).Replace("\\", "/");// paths = "C:\\ffmpeg.exe";
                    string pathBefore = pathTemp + strfwqFilename;//"D:\\VOICE_001.amr";
                    string pathLater = path + strfwqFilename.Split('.')[0] + ".mp3";//"D:\\VOICE_001.mp3";
                    WavConvertToAmr toamr = new WavConvertToAmr();
                    toamr.ConvertToMp3(paths, pathBefore, pathLater);
                }
            }

        }
    }
    protected void RegisterScript(string message)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<script type='text/javascript'>").Append(Environment.NewLine).Append(message).Append("</script>");
        base.ClientScript.RegisterStartupScript(base.GetType(), Guid.NewGuid().ToString(), builder.ToString());
    }
}