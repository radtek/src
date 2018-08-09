using cn.justwin.BLL;
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

public partial class oa_JournalManage_JournalDetail : NBasePage, IRequiresSessionState
{
    private OAJournalService pcSer = new OAJournalService();
    private OAJournalAppendService pcSer2 = new OAJournalAppendService();
    PTYhmcService pcSer3 = new PTYhmcService();
    //OAJournalCommentService pcSer4 = new OAJournalCommentService();
    private OAJournalTypeService pcSer5 = new OAJournalTypeService();
    private string action = string.Empty;
    private string Id = string.Empty;
    public string PL = "";
    protected override void OnInit(System.EventArgs e)
    {
        this.action = base.Request["action"];
        this.Id = base.Request["id"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Bind(Id);
        bind1();//绑定评分
        bind2();//绑定评论
        this.FileUpload1.InnerHtml = this.FilesBind(this.Id, "JournalPhotos");
        this.FileUpload2.InnerHtml = this.FilesBind(this.Id, "JournalFiles");
        //this.FileUpload1.RecordCode = this.KeyId.Value;
        //this.FileUpload2.RecordCode = this.KeyId.Value;
    }
    public string FilesBind(string consID,string config)
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
                //if (this.action == "add")
                //{
                //    this.start_time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");//日志开始时间
                //    this.end_time.Text = DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm");//日志结束时间
                //    //TimeSpan timeSpan = Convert.ToDateTime(model.end_time.ToString()) - Convert.ToDateTime(model.start_time.ToString());
                //    this.txtValue.Text = "60";///时间差值（分钟）
                //    DataTable dt0 = publicDbOpClass.DataTableQuary(@"select* from OA_Journal_Type  where Id='" + model.type_id.ToString() + "'");
                //    this.title.Text = dt0.Rows[0]["title_temp"].ToString();//标题
                //    this.content.Text = dt0.Rows[0]["content_temp"].ToString();//内容
                //}
                //else
                //{
                this.creater.Text = pcSer3.GetName(model.creater);//填写人
                this.create_date.Text = Convert.ToDateTime(model.create_date.ToString()).ToString("yyyy-MM-dd HH:mm");//日志更新时间

                this.KeyId.Value = model.Id;//主键
                    this.title.Text = model.title;//标题
                    this.content.Text = model.content;//内容
                    this.start_time.Text = Convert.ToDateTime(model.start_time.ToString()).ToString("yyyy-MM-dd HH:mm");//日志开始时间
                    this.end_time.Text = Convert.ToDateTime(model.end_time.ToString()).ToString("yyyy-MM-dd HH:mm");//日志结束时间
                    TimeSpan timeSpan = Convert.ToDateTime(model.end_time.ToString()) - Convert.ToDateTime(model.start_time.ToString());
                    this.txtValue.Text = timeSpan.TotalMinutes.ToString();///时间差值（分钟）
                //}
                //this.hdnProjectCode.Text = model.project_id;//关联项目ID
                DataTable dt1 = publicDbOpClass.DataTableQuary("select PrjName from PT_PrjInfo WHERE PrjGuid='" + model.project_id + "'");
                if (dt1.Rows.Count > 0)
                {
                    this.txtProject.Text = dt1.Rows[0]["PrjName"].ToString();//关联项目
                }
                else
                {
                    this.txtProject.Text = "";//关联项目
                }

                //model.status = ii;//日志状态(0草稿;1提交)
                //model.creater = base.UserCode.ToString();//创建人ID
                //model.create_date = DateTime.Now;//创建时间
                //model.voices = "";//关联语音
                //model.vidios = "";//关联视频
                //model.cover = "";//封面
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
                //this.hfldTo.Value = strSYRID;
                this.txtTo.Text = strSYRXM;
                //相关人
                if (strXGRID.Length > 0)
                {
                    //this.hfldCopyto.Value = strXGRID.Substring(0, strXGRID.Length - 1);
                    this.txtCopyto.Text = strXGRXM.Substring(0, strXGRXM.Length - 1);
                }
            }
        }
    }
    public void bind1()
    {
        DataTable dt2 = publicDbOpClass.DataTableQuary("select * from OA_Journal_Append where journal_id='" + base.Request["id"] + "' and user_id='" + base.UserCode.ToString() + "'");
        if (dt2.Rows.Count > 0)
        {
            if (string.IsNullOrEmpty(dt2.Rows[0]["look_time"].ToString()))
            {
                int ii = publicDbOpClass.ExecuteSQL("update OA_Journal_Append set look_time='" + DateTime.Now + "' where journal_id='" + base.Request["id"] + "' and user_id='" + base.UserCode.ToString() + "'");
            }

            if (!string.IsNullOrEmpty(dt2.Rows[0]["score"].ToString()))
            {
                Labelscore.Text = dt2.Rows[0]["score"].ToString();
            }
            else
            {
                Labelscore.Text = "无";
            }
        }
    }
    private void bind2()
    {

        DataTable dtPL = publicDbOpClass.DataTableQuary(@"select OA_Journal_Comment.*,PT_yhmc.v_xm from OA_Journal_Comment left join PT_yhmc on 
                                            OA_Journal_Comment.user_id=PT_yhmc.v_yhdm where journal_id='" + base.Request["id"] + "' order by OA_Journal_Comment.time desc");
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
            PL = "";//@"<tr>< td style = 'width: 10%; text-align: right' ></ td >< td style = 'text-align: left' class='auto-style3'>无</td></tr>";
            PLtitle.Visible = false;
        }
    }
}