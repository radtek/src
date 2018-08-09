using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using DomainServices.cn.justwin.Domain.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;

public partial class OA3_WorkTask_TaskView : NBasePage
{
    TaskService pcSer = new TaskService();
    private string action = string.Empty;
    private string Id = string.Empty;
    public string PL = "";
    public string JD = "";
    public string voices = "";
    public string videos = "";
    protected override void OnInit(System.EventArgs e)
    {
        this.action = base.Request["action"];
        this.Id = base.Request["id"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int ii = pcSer.ChangeViewTime(base.Request["id"].ToString(), base.UserCode.ToString());//更新当前用户查看的时间
            this.Bind(Id);
            //BindPL(base.Request["id"].ToString());//绑定评论
            //this.FileUpload1.InnerHtml = this.FilesBind(this.Id, "TaskPhotos");
            //this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "TaskFiles");
            //this.FileUpload3.InnerHtml = this.FilesBind(this.Id, "TaskVoices");
            //this.FileUpload4.InnerHtml = this.FilesBind(this.Id, "TaskVideos");
            BindJD(base.Request["id"].ToString());//绑定任务进度
            BindPL(base.Request["id"].ToString());//绑定回复

            this.InitPic();
            this.FileUpload1.RecordCode = this.Id;

            this.InitVoices();
            this.FileUpload3.RecordCode = this.Id;

            this.InitVideos();
            this.FileUpload4.RecordCode = this.Id;

            this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "TaskFiles");
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
                    "<a  class=\"link\" target=_blank  href=\"../../Common/DownLoad.aspx?path=",
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
    private void Bind(string Id)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            string strWhere = " and OA_Task.id='" + Id + "'";
            DataTable dt = TaskService.GetTaskListTable(strWhere, UserCode);
            if (dt.Rows.Count > 0)
            {
                //status	--任务状态( 0草稿、1未开始、2执行中、3已完成、4已关闭、5已删除 )
                if (dt.Rows[0]["status"].ToString() == "2")
                {
                    btnWCorGB.Visible = true;
                }
                else
                {
                    btnWCorGB.Visible = false;
                }

                this.type_id.Text = dt.Rows[0]["typeName"].ToString(); ;//日志类型
                CodeName.Text = dt.Rows[0]["CodeName"].ToString(); ;//任务优先级
                this.creater.Text = dt.Rows[0]["v_xm"].ToString(); ;//填写人
                this.create_date.Text = Convert.ToDateTime(dt.Rows[0]["create_time"].ToString()).ToString("yyyy-MM-dd HH:mm");//日志更新时间
                this.progress.Text = dt.Rows[0]["progress"].ToString(); ;//任务进度百分比
                this.KeyId.Value = Id;//主键
                this.title.Text = dt.Rows[0]["title"].ToString(); ;//标题
                this.content.Text = dt.Rows[0]["content"].ToString(); ;//内容
                this.start_time.Text = Convert.ToDateTime(dt.Rows[0]["start_time"].ToString()).ToString("yyyy-MM-dd HH:mm");//日志开始时间
                this.end_time.Text = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()).ToString("yyyy-MM-dd HH:mm");//日志结束时间
                TimeSpan timeSpan = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()) - Convert.ToDateTime(dt.Rows[0]["start_time"].ToString());
                this.txtValue.Text = timeSpan.TotalMinutes.ToString();///时间差值（分钟）
                this.status_name.Text = dt.Rows[0]["status_name"].ToString();//任务状态
                
                DataTable dt0 = publicDbOpClass.DataTableQuary(@"select OA_Task_Append.user_id,OA_Task_Append.user_type,PT_yhmc.v_xm from OA_Task_Append 
                                  left join PT_yhmc on OA_Task_Append.user_id=PT_yhmc.v_yhdm where task_id='" + Id + "'");
                string strSYRID = "", strSYRXM = "", strXGRID = "", strXGRXM = "";
                foreach (DataRow dr in dt0.Rows)
                {
                    //0 审阅人、1相关人、2审阅及相关人;
                    if (dr["user_type"].ToString() == "0")
                    {
                        strSYRID = dr["user_id"].ToString();
                        strSYRXM = dr["v_xm"].ToString();
                    }
                    if (dr["user_type"].ToString() == "1")
                    {
                        strXGRID += dr["user_id"].ToString() + ",";
                        strXGRXM += dr["v_xm"].ToString() + ",";
                    }
                    if (dr["user_type"].ToString() == "2")
                    {
                        strSYRID = dr["user_id"].ToString();
                        strSYRXM = dr["v_xm"].ToString();
                        strXGRID += dr["user_id"].ToString() + ",";
                        strXGRXM += dr["v_xm"].ToString() + ",";
                    }
                }
                //审阅人
                this.txtTo.Text = strSYRXM;
                //相关人
                if (strXGRID.Length > 0)
                {
                    this.txtCopyto.Text = strXGRXM.Substring(0, strXGRXM.Length - 1);
                }
            }
        }
    }
    public void BindJD(string KeyID)
    {
        DataTable dtJD = publicDbOpClass.DataTableQuary(@"select OA_Task_Progress_History.*,PT_yhmc.v_xm from OA_Task_Progress_History left join PT_yhmc on 
                                            OA_Task_Progress_History.user_id=PT_yhmc.v_yhdm where head_id='" + KeyID + "' order by OA_Task_Progress_History.time desc");
        string strs = "";
        if (dtJD.Rows.Count > 0)
        {
            foreach (DataRow dr in dtJD.Rows)
            {
                strs += @"<tr>
                            <td style='width: 100%; text-align: left'>进度:" + dr["progress"].ToString() + "% " + dr["content"].ToString() +
                             @"</td>
                        </tr>
                        <tr>
                            <td style='text-align: right;border-bottom: 1px solid #cccccc;'>提交时间:" + Convert.ToDateTime(dr["time"].ToString()).ToString("yyyy-MM-dd HH:mm") +
                             @"&nbsp;&nbsp;提交人:" + dr["v_xm"].ToString() +
                             @"</td>
                        </tr>";
            }
            JD = "<table style='width:100%;'>" + strs + "</table>";
        }
        else
        {
            JD = "<table style='width:100%;'><tr><td style='width: 100%;text-align:left'> 暂无更新记录</td></tr></table>";

        }
    }
    public void BindPL(string KeyID)
    {
        DataTable dtPL = publicDbOpClass.DataTableQuary(@"select OA_Comment.*,PT_yhmc.v_xm from OA_Comment left join PT_yhmc on 
                                            OA_Comment.user_id=PT_yhmc.v_yhdm where head_id='" + KeyID + "' order by OA_Comment.time desc");
        if (dtPL.Rows.Count > 0)
        {
            foreach (DataRow dr in dtPL.Rows)
            {
                PL += @"<tr>
                            <td style='width: 10%; text-align: right' rowspan='2'></td>
                            <td style='width: 10%; text-align: left' colspan='3' >" + dr["content"].ToString() +
                             @"</td>
                        </tr>
                        <tr>
                            <td style='text-align: right;border-bottom: 1px solid #cccccc;' colspan='3' >评论时间:" + Convert.ToDateTime(dr["time"].ToString()).ToString("yyyy-MM-dd HH:mm") +
                             @"&nbsp;&nbsp;评论人:" + dr["v_xm"].ToString() +
                             @"</td>
                        </tr>";
            }
            PLtitle.Visible = true;
        }
        else
        {
            PL = "";
            PLtitle.Visible = false;
        }
    }
    //保存并完成
    protected void btnSaveWC_Click(object sender, EventArgs e)
    {
        saveData(3);
    }
    //保存并关闭
    protected void btnSaveGB_Click(object sender, EventArgs e)
    {
        saveData(4);
    }
    /// <summary>
    /// 保存页面数据
    /// </summary>
    /// <param name="status">0草稿、1未开始、2执行中、3已完成、4已关闭、5已删除  </param>
    private void saveData(int status)
    {
       string strSql = string.Format(@"UPDATE [OA_Task] SET [status] = '{1}' WHERE [id]= '{0}'", this.KeyId.Value,status);
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                base.RegisterScript("top.ui.tabSuccess({parentName:'_Task'});");
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }
    public void InitPic()
    {
        string path = base.Server.MapPath(base.Request.ApplicationPath) + base.Request.ApplicationPath + this.FileUpload1.Folder + this.Id;
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
                    "../..",
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
    {
        string path = base.Server.MapPath(base.Request.ApplicationPath) + base.Request.ApplicationPath + this.FileUpload3.Folder + this.Id;
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
                    "../..",
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
            //string value = JsonHelper.JsonSerializer<System.Collections.Generic.List<string>>(list);
            //this.hfldVoicesPath.Value = value;
        }
    }
    private void InitVideos()//4
    {
        string path = base.Server.MapPath(base.Request.ApplicationPath) + base.Request.ApplicationPath + this.FileUpload4.Folder + this.Id;
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
                    "../..",
                    this.FileUpload4.Folder,
                    this.Id,
                    "/",
                    text
                });
                //../../UploadFiles/JournalVideos/0481c5ea-9133-c9c3-abd7-a9e65d2e867d/movie.mp4
                string[] strs = item.Split('/');
                string str = strs[strs.Length - 1];
                string str2 = str.Split('.')[1].ToString();
                videos += @"<video width='300' height='240' controls='controls' style='float:left;margin-left: 15px;'><source src = '" + item + "' type = 'video/" + str2 + "'></video>";
                list.Add(item);
            }
            //string value = JsonHelper.JsonSerializer<System.Collections.Generic.List<string>>(list);
            //this.hfldVideoPath.Value = value;

        }
    }
}