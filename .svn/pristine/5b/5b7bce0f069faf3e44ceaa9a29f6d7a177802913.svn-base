using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using com.jwsoft.pm.data;
using DomainServices.cn.justwin.Domain.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;


public partial class OA3_WorkTask_TaskEdit : NBasePage
{
    private string action = string.Empty;
    private string Id = string.Empty;
    TaskService pcSer = new TaskService();
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
            this.BindType(); //绑定任务类型
            this.BindPriority();//绑定任务优先级

            if (this.action == "add")
            {
                this.KeyId.Value = System.Guid.NewGuid().ToString();
                DataTable dt = publicDbOpClass.DataTableQuary("select top 1 * from OA_Task where creater_id = '" + this.UserCode + "' order by create_time desc");
                if (dt.Rows.Count > 0)
                {
                    this.Bind(dt.Rows[0]["Id"].ToString(), action);
                }
            }
            else if (this.action == "edit")
            {
               string status= TaskService.selectStatus(Id);
                if(status != "0")
                {
                    base.RegisterScript("alert('系统提示：只能编辑状态为\"草稿中\"的数据,请重新选择！');");
                    //base.RegisterShow("系统提示", "只能编辑状态为\"草稿中\"的数据,请重新选择！"); 
                    base.RegisterScript("top.ui.closeTab();");
                    return;
                }
                this.KeyId.Value = Id;
                this.Bind(Id, action);
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
            string strWhere = " and OA_Task.id='" + Id + "'";
            DataTable dt = TaskService.GetTaskListTable(strWhere, UserCode);
            if (dt.Rows.Count > 0)
            {
                this.type_id.SelectedValue = dt.Rows[0]["type_id"].ToString();//任务类型
                this.priority_id.SelectedValue = dt.Rows[0]["priority_id"].ToString();//任务优先级
                this.if_send.SelectedValue= dt.Rows[0]["if_send"].ToString();//是否发送微信通知
                if (this.action == "add")
                {
                    this.start_time.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00");//开始时间
                    this.end_time.Text = DateTime.Now.AddHours(1).ToString("yyyy-MM-dd 00:00");//结束时间
                    //this.start_time.Text = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()).AddMinutes(1).ToString("yyyy-MM-dd HH:mm");//开始时间//DateTime.Now.ToString("yyyy-MM-dd HH:mm");//开始时间
                    //this.end_time.Text = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()).AddMinutes(61).ToString("yyyy-MM-dd HH:mm");//结束时间
                    this.txtValue.Text = "60";//持续时间（分钟）
                    this.ddl.SelectedValue = "60";
                    DataTable dtTemp = publicDbOpClass.DataTableQuary(@"select* from OA_Task_Type where Id='" + dt.Rows[0]["type_id"].ToString() + "'");
                    this.title.Text = dtTemp.Rows[0]["title_temp"].ToString();//标题
                    this.content.Text = dtTemp.Rows[0]["content_temp"].ToString();//内容
                }
                else
                {
                    this.KeyId.Value = dt.Rows[0]["id"].ToString();//主键
                    this.title.Text = dt.Rows[0]["title"].ToString();//标题
                    this.content.Text = dt.Rows[0]["content"].ToString();//内容
                    this.start_time.Text = Convert.ToDateTime(dt.Rows[0]["start_time"].ToString()).ToString("yyyy-MM-dd HH:mm");//开始时间
                    this.end_time.Text = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()).ToString("yyyy-MM-dd HH:mm");//结束时间
                    TimeSpan timeSpan = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()) - Convert.ToDateTime(dt.Rows[0]["start_time"].ToString());
                    this.txtValue.Text = timeSpan.TotalMinutes.ToString();///持续时间（分钟）
                }

                DataTable dt2 = publicDbOpClass.DataTableQuary(@"select OA_Task_Append.user_id,OA_Task_Append.user_type,PT_yhmc.v_xm from OA_Task_Append 
                                  left join PT_yhmc on OA_Task_Append.user_id=PT_yhmc.v_yhdm where task_id='" + dt.Rows[0]["id"].ToString() + "'");
                string strSYRID = "", strSYRXM = "", strXGRID = "", strXGRXM = "";
                foreach (DataRow dr in dt2.Rows)
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
    
    private void BindPriority()
    {
        DataTable dt = publicDbOpClass.DataTableQuary("select * from XPM_Basic_CodeList WHERE SignCode2='Task_Priority' order by I_xh asc");
        this.priority_id.DataSource = dt;
        this.priority_id.DataValueField = "NoteID";
        this.priority_id.DataTextField = "CodeName";
        this.priority_id.DataBind();
        this.priority_id.Items.Insert(0, new ListItem("请选择", ""));

        foreach (DataRow dr in dt.Rows)
        {
            if (dr["IsDefault"].ToString() == "1")
            {
                priority_id.SelectedValue = dr["NoteID"].ToString();
                break;
            }
        }
    }
    public void BindType()
    {
        DataTable aLLProvince = publicDbOpClass.DataTableQuary("select * from OA_Task_Type where is_use = 1");
        this.type_id.DataSource = aLLProvince;
        this.type_id.DataValueField = "id";
        this.type_id.DataTextField = "name";
        this.type_id.DataBind();
        this.type_id.Items.Insert(0, new ListItem("请选择", ""));
    }
    //保存为草稿
    protected void btnSaveCG_Click(object sender, EventArgs e)
    {
        saveData(0);
    }
    //保存并提交
    protected void btnSaveTJ_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(start_time.Text.ToString())>=DateTime.Now)
        {
            saveData(1);
        }
        else
        {
            saveData(2);
        }
    }

    /// <summary>
    /// 保存页面数据
    /// </summary>
    /// <param name="status">0草稿、1未开始、2执行中、3已完成、4已关闭、5已删除  </param>
    public void saveData(int status)
    {
        string strSql = "";
        string strSql1 = "";
        if (this.action == "add")
        {
            strSql = string.Format(@"
            INSERT INTO [OA_Task]
           ([id]
           ,[type_id]
           ,[title]
           ,[content]
           ,[creater_id]
           ,[create_time]
           ,[status]
           ,[start_time]
           ,[end_time]
           --,[complete_time]
           ,[priority_id]
           ,if_send
)
     VALUES
           ('{0}'--<id, varchar(50),>
           ,'{1}'--<type_id, varchar(50),>
           ,'{2}'--<title, nvarchar(50),>
           ,'{3}'--<content, text,>
           ,'{4}'--<creater_id, varchar(50),>
           ,'{5}'--<create_time, datetime,>
           ,{6}--<status, int,>
           ,'{7}'--<start_time, datetime,>
           ,'{8}'--<end_time, datetime,>
          --,[complete_time] = '{9}'--<complete_time, datetime,>
           ,'{9}'--<priority_id, varchar(50),>
            ,{10}--<if_send, int,>
		   )", this.KeyId.Value, type_id.SelectedValue, title.Text.ToString(), content.Text.ToString(),
           base.UserCode.ToString(), DateTime.Now, status, start_time.Text.ToString(), end_time.Text.ToString(), priority_id.Text.ToString(), if_send.SelectedValue.ToString());

            strSql1 = @"INSERT INTO [OA_Task_Append]
           ([id]
           ,[task_id]
           ,[user_id]
           --,[look_time]
           --,[progress]
           --,[remark]
           ,[user_type]
           ,[up_time]
		   )
     VALUES" + RYinfo(this.KeyId.Value);
        }
        else if (this.action == "edit")
        {
            strSql = string.Format(@"
       UPDATE [OA_Task]
       SET --[id] = <id, varchar(50),>
      --,
	   [type_id] ='{1}'-- <type_id, varchar(50),>
      ,[title] = '{2}'--<title, nvarchar(50),>
      ,[content] = '{3}'--<content, text,>
      ,[creater_id] ='{4}'-- <creater_id, varchar(50),>
      ,[create_time] ='{5}'-- <create_time, datetime,>
      ,[status] = '{6}'--<status, int,>
      ,[start_time] = '{7}'--<start_time, datetime,>
      ,[end_time] = '{8}'--<end_time, datetime,>
       --,[complete_time] = '{9}'--<complete_time, datetime,>
      ,[priority_id] = '{9}'--<priority_id, varchar(50),>
      ,if_send= '{10}'--<if_send, int,>
 WHERE [id]= '{0}'", this.KeyId.Value, type_id.SelectedValue, title.Text.ToString(), content.Text.ToString(),
           base.UserCode.ToString(), DateTime.Now, status, start_time.Text.ToString(), end_time.Text.ToString(), priority_id.Text.ToString(), if_send.SelectedValue.ToString());
            strSql1 = "DELETE from OA_Task_Append where task_id='" + this.KeyId.Value + "';" + @"INSERT INTO [OA_Task_Append]
           ([id]
           ,[task_id]
           ,[user_id]
           --,[look_time]
           --,[progress]
           --,[remark]
           ,[user_type]
           ,[up_time]
		   )
     VALUES" + RYinfo(this.KeyId.Value);
        }
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql1);
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
    //获取负责人及相关人并拼接sql
    private string RYinfo(string Id)
    {
        int ii = 0;
        string strs = "";
        string strSYR = hfldTo.Value.ToString();//审阅人
        string strXGRS = hfldCopyto.Value.ToString();//相关人
        if (!string.IsNullOrEmpty(strXGRS))
        {
            string[] strXGR = strXGRS.Split(',');
            foreach (string str in strXGR)
            {
                int user_type = 1;
                if (str == strSYR)
                {
                    user_type = 2;//3 提交人、0 审阅人、1相关人、2审阅及相关人;
                    ii = 1;//为1时,同时保存审阅人
                }
                else
                {
                    user_type = 1;// 3 提交人、0 审阅人、1相关人、2审阅及相关人;
                }
                //
                // --,< progress, int,>
                //  --,< remark, varchar(50),>
                //--,< up_time, datetime2(7),>
                strs += string.Format(@"(
             '{0}'--<id, varchar(50),>
           , '{1}'--<task_id, varchar(50),>
           , '{2}'--<user_id, varchar(50),>
           , {3}--<user_type, int,>
           , {4}--,< look_time, datetime,>
		   ),", Guid.NewGuid().ToString(), Id, str, user_type, "null");
            }
        }
        if (!string.IsNullOrEmpty(strSYR))
        {
            if (ii == 0)
            {
                strs += string.Format(@"(
             '{0}'--<id, varchar(50),>
           , '{1}'--<task_id, varchar(50),>
           , '{2}'--<user_id, varchar(50),>
           , {3}--<user_type, int,>
            , {4}--,< look_time, datetime,>
		   ),", Guid.NewGuid().ToString(), Id, strSYR, 0, "null");
            }
        }
        //保存 提交人(为了评论提醒功能) user_type = 3;//3 提交人、0 审阅人、1相关人、2审阅及相关人;
        strs += string.Format(@"(
             '{0}'--<id, varchar(50),>
           , '{1}'--<task_id, varchar(50),>
           , '{2}'--<user_id, varchar(50),>
           , {3}--<user_type, int,>
           , '{4}'--,< look_time, datetime,>
		   ),", Guid.NewGuid().ToString(), Id, this.UserCode.ToString(), 3, DateTime.Now);

        return strs.Substring(0, strs.Length - 1) + ";";
    }
    //ajax 根据任务类型获取任务类型模版中任务标题及任务内容模版
    [WebMethod]//标示为web服务方法属性
    public static string getTaskTemps(string typeId)
    {
        string strRes3 = "";
        DataTable dt = publicDbOpClass.DataTableQuary("select * from OA_Task_Type where Id='" + typeId + "'");
        foreach (DataRow dr in dt.Rows)
        {
            strRes3 = dr["title_temp"].ToString() + ";" + dr["content_temp"].ToString();
        }
        return strRes3;
    }
}