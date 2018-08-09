using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Tender;
using com.jwsoft.pm.data;
using PMBase.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class OA3_WorkLog_MyLogEdit : NBasePage, IRequiresSessionState
{
    private OAJournalService pcSer = new OAJournalService();
    private OAJournalAppendService pcSer2 = new OAJournalAppendService();
    private string action = string.Empty;
    private string Id = string.Empty;

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
            dropBind();
            if (this.action == "add")
            {
                this.KeyId.Value = System.Guid.NewGuid().ToString();
                DataTable dt = publicDbOpClass.DataTableQuary("select top 1 * from OA_Journal where creater = '" + this.UserCode + "' order by create_date desc");
                if (dt.Rows.Count > 0)
                {
                    this.Bind(dt.Rows[0]["Id"].ToString(), action);
                }
                LogType.Text = "add";
                userCode.Text = this.UserCode;
            }
            else if (this.action == "edit")
            {
                this.KeyId.Value = Id;
                this.Bind(Id, action);
                LogType.Text = "edit";
                userCode.Text = this.UserCode;
            }
            try
            {
                DataTable dt0 = publicDbOpClass.DataTableQuary("select ParaValue from Basic_Config WHERE ParaName='journalIfCheckTime'");
                if (dt0.Rows.Count > 0)
                {
                    CheckTime.Text = dt0.Rows[0]["ParaValue"].ToString();
                }
            }catch{
                CheckTime.Text = "1";
            }
           
            this.FileUpload1.RecordCode = this.KeyId.Value;//绑定图片
            this.FileUpload2.RecordCode = this.KeyId.Value;//绑定附件
            this.FileUpload3.RecordCode = this.KeyId.Value;//绑定音频
            this.FileUpload4.RecordCode = this.KeyId.Value;//绑定视频
        }
    }
    private void Bind(string Id, string action)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            OAJournal model = this.pcSer.GetById(Id);
            if (model != null)
            {
                this.type_id.SelectedValue = model.type_id.ToString();//日志类型
                if (this.action == "add")
                {
                    this.start_time.Text = Convert.ToDateTime(model.end_time.ToString()).AddMinutes(1).ToString("yyyy-MM-dd HH:mm");//开始时间//DateTime.Now.ToString("yyyy-MM-dd HH:mm");//开始时间
                    this.end_time.Text = Convert.ToDateTime(model.end_time.ToString()).AddMinutes(61).ToString("yyyy-MM-dd HH:mm");//结束时间
                    this.txtValue.Text = "60";//持续时间（分钟）
                    this.ddl.SelectedValue = "60";
                    DataTable dt0 = publicDbOpClass.DataTableQuary(@"select* from OA_Journal_Type  where Id='" + model.type_id.ToString() + "'");
                    this.title.Text = dt0.Rows[0]["title_temp"].ToString();//标题
                    this.content.Text = dt0.Rows[0]["content_temp"].ToString();//内容
                }
                else
                {
                    this.KeyId.Value = model.Id;//主键
                    this.title.Text = model.title;//标题
                    this.content.Text = model.content;//内容
                    this.start_time.Text = Convert.ToDateTime(model.start_time.ToString()).ToString("yyyy-MM-dd HH:mm");//开始时间
                    this.end_time.Text = Convert.ToDateTime(model.end_time.ToString()).ToString("yyyy-MM-dd HH:mm");//结束时间

                    TimeSpan timeSpan = Convert.ToDateTime(model.end_time.ToString()) - Convert.ToDateTime(model.start_time.ToString());
                    this.txtValue.Text = timeSpan.TotalMinutes.ToString();///持续时间（分钟）
                }

                if (!string.IsNullOrEmpty(model.project_id))
                {
                    this.hdnProjectCode.Value = model.project_id;//关联项目ID
                    DataTable dt1 = publicDbOpClass.DataTableQuary("select PrjName from PT_PrjInfo WHERE PrjGuid='" + model.project_id + "'");
                    if (dt1.Rows.Count > 0)
                    {
                        this.txtProject.Value = dt1.Rows[0]["PrjName"].ToString();//关联项目
                    }
                    else
                    {
                        this.txtProject.Value = "";//关联项目
                    }
                }
                else
                {
                    this.txtProject.Value = "";//关联项目
                }
                if (!string.IsNullOrEmpty(model.task_id))
                {
                    this.hdntask_id.Value = model.task_id;//关联任务ID
                    DataTable dt1 = publicDbOpClass.DataTableQuary("select title from OA_Task WHERE id='" + model.task_id + "'");
                    if (dt1.Rows.Count > 0)
                    {
                        this.task_id.Value = dt1.Rows[0]["title"].ToString();//关联任务
                    }
                    else
                    {
                        this.task_id.Value = "";//关联任务
                    }
                }
                else
                {
                    this.task_id.Value = "";//关联任务
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
                this.hfldTo.Value = strSYRID;
                this.txtTo.Text = strSYRXM;
                //相关人
                if (strXGRID.Length > 0)
                {
                    this.hfldCopyto.Value = strXGRID.Substring(0, strXGRID.Length - 1);
                    this.txtCopyto.Text = strXGRXM.Substring(0, strXGRXM.Length - 1);
                }

            }
        }
    }
    public void dropBind()
    {
        this.BindType();
    }
    public void BindType()
    {
        DataTable aLLProvince = publicDbOpClass.DataTableQuary("select * from OA_Journal_Type where is_use = 1 ORDER BY sort desc");
        this.type_id.DataSource = aLLProvince;
        this.type_id.DataValueField = "id";
        this.type_id.DataTextField = "name";
        this.type_id.DataBind();
        this.type_id.Items.Insert(0, new ListItem("请选择", ""));
    }
    protected OAJournal GetModel(int ii)
    {
        OAJournal model = new OAJournal();
        model.Id = this.KeyId.Value;
        model.title = this.title.Text;//标题
        model.type_id = this.type_id.SelectedValue.ToString();//日志类型
        model.start_time = Convert.ToDateTime(start_time.Text.ToString()); ;//日志开始时间
        model.end_time = Convert.ToDateTime(end_time.Text.ToString());//日志结束时间
        model.content = this.content.Text;//内容
        model.status = ii;//日志状态(0草稿;1提交)
        model.creater = base.UserCode.ToString();//创建人ID
        model.create_date = DateTime.Now;//创建时间
        if (!string.IsNullOrEmpty(hdnProjectCode.Value.ToString()))
        {
            model.project_id = hdnProjectCode.Value.ToString();//关联项目ID
        }
        if (!string.IsNullOrEmpty(hdntask_id.Value.ToString()))
        {
            model.task_id = hdntask_id.Value.ToString();//关联任务ID
        }
        
        //model.voices = "";//关联语音
        //model.vidios = "";//关联视频
        //model.cover = "";//封面
        return model;
    }
    protected void btnSaveCG_Click(object sender, EventArgs e)
    {
        saveData(0);
    }
    protected void btnSaveTJ_Click(object sender, EventArgs e)
    {
        saveData(1);
    }
    public void saveData(int ii)
    {
        OAJournal model = this.GetModel(ii);

        if (this.action == "add")
        {
            this.pcSer.Add(model);
            saveRY(model.Id);
        }
        else if (this.action == "edit")
        {
            this.pcSer.Update(model);
            publicDbOpClass.ExecSqlString("DELETE from OA_Journal_Append where journal_id='" + model.Id + "'");
            saveRY(model.Id);
        }
        if (ii == 1)
        {
            string strSYR = hfldTo.Value.ToString();//审阅人
            string strXGRS = hfldCopyto.Value.ToString();//相关人
            //发送微信消息
            WXAPI.sendWeChatMsg(UserCode.ToString(), strSYR, strXGRS, "log", model.Id.ToString(), model.title.ToString(), model.create_date.ToString());
            //string strUsers = "";
            //if (!string.IsNullOrEmpty(strSYR))
            //{
            //    strUsers += "'" + strSYR + "'";
            //}
            //if (!string.IsNullOrEmpty(strXGRS))
            //{
            //    string[] strXGR = strXGRS.Split(',');
            //    strUsers += "," + "'" + strXGRS + "'";
            //    //strUsers += "|"+ strXGRS.Replace(',','|');
            //}
            //string strSQL1 = "select * from PT_yhmc where v_yhdm ='" + base.UserCode + "'";
            //DataTable dt1 = publicDbOpClass.DataTableQuary(strSQL1);
            //string strSQL = "select * from PT_yhmc where v_yhdm in(" + strUsers + ")";
            //DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
            ////string wxUsers = "";
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        //    wxUsers += dr["WXID"] + "|";
            //        //}
            //        //string str0 = "";//"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx251384a873c4d422&redirect_uri=";
            //        string str1 = new BasicConfigService().GetValue("domain");
            //        string str2 = "/WeChat/log/show.html?id=" + model.Id + "&userType=tj&userID="+ dr["v_yhdm"];
            //        // string str3 = "";//"&action=add&response_type=code&scope=snsapi_base#wechat_redirect";

            //        // string str4 = System.Web.HttpUtility.UrlEncode(str1 + str2);//System.Web.HttpUtility.UrlDecode("");
            //        // string str4 = str1 + str2;
            //        //string strURL = str0 + str4 + str3;

            //        //WXAPI.sendText(1000008, "您有新的工作日志待查阅\n" + model.title.ToString() + model.start_time.ToString() + "\n", strURL, wxUsers.Substring(0, wxUsers.Length - 1));
            //        //WXAPI.sendText(1000008, "您有新的工作日志待查阅\n<h2><b>" + model.title.ToString() + "</b></h2>[填写人:" + dt1.Rows[0]["v_xm"].ToString() + "]\n", strURL, dr["WXID"].ToString());
            //        //string description = "< div class=\"gray\">[填写人:" + dt1.Rows[0]["v_xm"].ToString() + "] " + model.create_date.ToString() + "</div> <div class=\"normal\">"+ model.content.ToString()+ "</div><div class=\"highlight\">请于2016年10月10日前联系行政同事领取</div>";
            //        string strURL = str1 + str2;
            //        string strTitle = "您有新的工作日志待查阅";
            //        string description = "<div class=\\\"highlight\\\">" + model.title.ToString() + "</div><div class=\\\"gray\\\">[填写人:" + dt1.Rows[0]["v_xm"].ToString() + "] " + model.create_date.ToString() + "</div>";
            //        string btntxt = "点击查看";
            //        WXAPI.sendTextCard(strTitle, 1000008, description, strURL, dr["WXID"].ToString(), btntxt);
            //    }
            // }
        }
        base.RegisterScript("top.ui.tabSuccess({parentName:'_Journal'});");
    }

   

    /// <summary>
    /// 保存 提交人、审阅人及相关人
    /// </summary>
    /// <param name="Id">日志ID</param>
    public void saveRY(string Id)
    {
        OAJournalAppend model2 = new OAJournalAppend();
        int ii = 0;
        string strSYR = hfldTo.Value.ToString();//审阅人
        string strXGRS = hfldCopyto.Value.ToString();//相关人
        if (!string.IsNullOrEmpty(strXGRS))
        {
            string[] strXGR = strXGRS.Split(',');
            foreach (string str in strXGR)
            {
                model2.Id = Guid.NewGuid().ToString();//主键
                model2.journal_id = Id;//日志ID
                model2.user_id = str;//审阅人ID
                if (str == strSYR)
                {
                    model2.user_type = 2;//3 提交人、0 审阅人、1相关人、2审阅及相关人;
                    ii = 1;//为1时,同时保存审阅人
                }
                else
                {
                    model2.user_type = 1;// 3 提交人、0 审阅人、1相关人、2审阅及相关人;
                }
                //model2.score = null;//评价/评分
                //model2.look_time = null;//查阅时间
                this.pcSer2.Add(model2);
            }
        }
        if (!string.IsNullOrEmpty(strSYR))
        {
            if (ii == 0)
            {
                model2.Id = Guid.NewGuid().ToString();//主键
                model2.journal_id = Id;//日志ID
                model2.user_id = strSYR;//审阅人ID
                model2.user_type = 0;//3 提交人、0 审阅人、1相关人、2审阅及相关人;
              //model2.score = null;//评价/评分
              //model2.look_time = null;//查阅时间
                this.pcSer2.Add(model2);
            }
        }

        //保存 提交人(为了评论提醒功能)
        model2.Id = Guid.NewGuid().ToString();//主键
        model2.journal_id = Id;//日志ID
        model2.user_id = base.UserCode;//审阅人ID
        model2.user_type = 3;//3 提交人、0 审阅人、1相关人、2审阅及相关人;
      //model2.score = null;//评价/评分
        model2.look_time = DateTime.Now;//查阅时间
        this.pcSer2.Add(model2);
    }
}