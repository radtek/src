﻿using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OA3_WorkLog_MyLogDetail : NBasePage, IRequiresSessionState
{
    private OAJournalService pcSer = new OAJournalService();
    private OAJournalAppendService pcSer2 = new OAJournalAppendService();
    PTYhmcService pcSer3 = new PTYhmcService();
    private OAJournalTypeService pcSer5 = new OAJournalTypeService();
    private string action = string.Empty;
    private string Id = string.Empty;
    public string PL = ""; 
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
            int ii = pcSer.ChangeViewTime(base.Request["id"].ToString(), base.UserCode.ToString());//更新当前用户查看日志的时间
            this.Bind(Id);
            BindPF(base.Request["id"].ToString());//绑定评分
            BindPL(base.Request["id"].ToString());//绑定评论
         
            this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "JournalFiles");
            //this.FileUpload3.InnerHtml = this.FilesBind(this.Id, "JournalVoices");
            //this.FileUpload4.InnerHtml = this.FilesBind(this.Id, "JournalVideos");

            this.InitPic();
            this.FileUpload1.RecordCode = this.Id;

            this.InitVoices();
            this.FileUpload3.RecordCode = this.Id;

            this.InitVideos();
            this.FileUpload4.RecordCode = this.Id;
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
                string[] strs=item.Split('/');
                string str = strs[strs.Length - 1];
                string str2 = str.Split('.')[1].ToString();
                videos += @"<video width='300' height='240' controls='controls' style='float:left;margin-left: 15px;'><source src = '" + item + "' type = 'video/"+ str2 + "'></video>";
                list.Add(item);
            }
            //string value = JsonHelper.JsonSerializer<System.Collections.Generic.List<string>>(list);
            //this.hfldVideoPath.Value = value;
           
        }
    }
    //<audio controls><source src =  '" + item + "' type="audio/" + str2 + ""></audio>
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
            OAJournal model = this.pcSer.GetById(Id);
            if (model != null)
            {
                this.type_id.Text = pcSer5.GetById(model.type_id.ToString()).name;//日志类型
                this.creater.Text = pcSer3.GetName(model.creater);//填写人
                this.create_date.Text = Convert.ToDateTime(model.create_date.ToString()).ToString("yyyy-MM-dd HH:mm");//日志更新时间

                this.KeyId.Value = model.Id;//主键
                this.title.Text = model.title;//标题
                this.content.Text = model.content;//内容
                this.start_time.Text = Convert.ToDateTime(model.start_time.ToString()).ToString("yyyy-MM-dd HH:mm");//日志开始时间
                this.end_time.Text = Convert.ToDateTime(model.end_time.ToString()).ToString("yyyy-MM-dd HH:mm");//日志结束时间
                TimeSpan timeSpan = Convert.ToDateTime(model.end_time.ToString()) - Convert.ToDateTime(model.start_time.ToString());
                this.txtValue.Text = timeSpan.TotalMinutes.ToString();///时间差值（分钟）


                //if (model.project_id.ToString()!=null)
                //{
                DataTable dt1 = publicDbOpClass.DataTableQuary("select PrjName from PT_PrjInfo WHERE PrjGuid in (select project_id FROM OA_Journal WHERE id='"+ Id + "') ");
                if (dt1.Rows.Count > 0)
                {
                    this.txtProject.Text = dt1.Rows[0]["PrjName"].ToString();//关联项目
                }
                else
                {
                    this.txtProject.Text = "";//关联任务
                }
                DataTable dt2 = publicDbOpClass.DataTableQuary("select title from OA_Task WHERE id in (select task_id FROM OA_Journal WHERE id='" + Id + "') ");
                if (dt2.Rows.Count > 0)
                {
                    this.task_id.Text = dt2.Rows[0]["title"].ToString();//关联任务
                }
                else
                {
                    this.task_id.Text = "";//关联任务
                }
                //}else
                //{
                //    this.txtProject.Text = "";//关联项目
                //}
                DataTable dt = publicDbOpClass.DataTableQuary(@"select OA_Journal_Append.user_id,OA_Journal_Append.user_type,PT_yhmc.v_xm from OA_Journal_Append 
                                  left join PT_yhmc on OA_Journal_Append.user_id=PT_yhmc.v_yhdm where journal_id='" + model.Id + "'");
                string strSYRID = "", strSYRXM = "", strXGRID = "", strXGRXM = "";
                foreach (DataRow dr in dt.Rows)
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
    public void BindPF(string KeyID)
    {
        DataTable dt2 = publicDbOpClass.DataTableQuary("select top 1 * from OA_Journal_Append where journal_id='" + KeyID + "' and score !='' ");
        if (dt2.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt2.Rows[0]["score"].ToString()))
            {
                if (dt2.Rows[0]["score"].ToString() == "3")
                {
                    Labelscore.Text = "优秀";
                }
                else if (dt2.Rows[0]["score"].ToString() == "2")
                {
                    Labelscore.Text = "良好";
                }
                else if(dt2.Rows[0]["score"].ToString() == "1")
                {
                    Labelscore.Text = "一般";
                }
                else
                {
                    Labelscore.Text = "暂无评价";
                }
            }
            else
            {
                Labelscore.Text = "暂无评价";
            }
        }
    }
    public void BindPL(string KeyID)
    {

        DataTable dtPL = publicDbOpClass.DataTableQuary(@"select OA_Journal_Comment.*,PT_yhmc.v_xm from OA_Journal_Comment left join PT_yhmc on 
                                            OA_Journal_Comment.user_id=PT_yhmc.v_yhdm where journal_id='" + KeyID + "' order by OA_Journal_Comment.time desc");
        if (dtPL.Rows.Count > 0)
        {
            foreach (DataRow dr in dtPL.Rows)
            {
                PL += @"<tr>
                            <td style='width: 10%; text-align: right' rowspan='2'></td>
                            <td style='width: 10%; text-align: left'>" + dr["content"].ToString() +
                             @"</td>
                        </tr>
                        <tr>
                            <td style='text-align: right;border-bottom: 1px solid #cccccc;'>评论时间:" + Convert.ToDateTime(dr["time"].ToString()).ToString("yyyy-MM-dd HH:mm") +
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
}