using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// TaskService 工作任务 方法类
/// </summary>
public class TaskService
{
    public DataTable GetTaskTypeTable(string strWhere, string UserCode)
    {
        string strSql = string.Format(@"SELECT * FROM (
                                         SELECT row_number() over (ORDER BY OA_Task_Type.sort asc,OA_Task_Type.id desc) as  
                                         pageindex--序号 
                                        , OA_Task_Type.content_temp,--任务内容模板
	                                            OA_Task_Type.id,--工作任务类型表_主键ID
	                                            OA_Task_Type.is_use,--是否启用 0停用;1启用
	                                            OA_Task_Type.name,--类型名称
	                                            OA_Task_Type.remark,--备注说明
	                                            OA_Task_Type.sort,--序号
	                                            OA_Task_Type.title_temp--任务标题模板 
                                            FROM
	                                            OA_Task_Type 
                                            WHERE 1 = 1  {0}  ) t ORDER BY sort DESC 
	                                       ", strWhere);
        return publicDbOpClass.DataTableQuary(strSql);
    }

    public static DataTable GetProUserTable(string strWhere, string userCode)
    {
        string strSql = string.Format(@"SELECT * FROM (
                                         SELECT row_number() over (ORDER BY sort asc,id desc) as  
                                         pageindex--序号 
                                        ,  id,--	主键ID
                                            xm,--	姓名
                                            tel,--	电话
                                            phone,--	手机
                                            ads,--	地址
                                            type,--	类型
                                            xbcType.CodeName typeName,--类型名称
                                            qq,--	QQ
                                            wx,--	微信
                                            mail,--	Email
                                            [group],--	分组
                                            xbcGroup.CodeName groupName,--分组名称
                                            remark,--	备注
                                            sort,--	序号
                                            prjId,--	项目ID
                                            sex--	性别
                                            FROM Pro_User 
                                            LEFT JOIN XPM_Basic_CodeList xbcGroup ON Pro_User.[group]=xbcGroup.NoteID
                                            LEFT JOIN XPM_Basic_CodeList xbcType ON Pro_User.[type]=xbcType.NoteID
                                            WHERE 1 = 1  {0} ) t ORDER BY sort DESC 
	                                       ", strWhere);
        return publicDbOpClass.DataTableQuary(strSql);
    }

    public int ChangeViewTime(string KeyID, string UserCode)
    {
        return publicDbOpClass.ExecuteSQL("update OA_Task_Append set look_time='" + DateTime.Now + "' where task_id='" + KeyID + "' and user_id='" + UserCode + "'");
    }
    public static void upDateStatus()
    {
        string strSql = "update OA_Task set status=2 where id in (select id from OA_Task where status=1 and start_time <='" + DateTime.Now+ "')";
        publicDbOpClass.ExecuteSQL(strSql);
    }
    public static string selectStatus(string ID)
    {
        string strSql = "select status from OA_Task where id ='" + ID + "'";
       DataTable dt= publicDbOpClass.DataTableQuary(strSql);
        return dt.Rows[0]["status"].ToString();
    }
    public static DataTable GetTaskListTable(string strWhere, string userCode)
    {
        upDateStatus();
        string strSql = string.Format(@"SELECT * FROM ( 
                                        SELECT row_number() over (ORDER BY status asc,XPM_Basic_CodeList.I_xh asc,create_time desc,OA_Task.id desc) as 
                                         pageindex--序号 
										,OA_Task.id	--工作任务表_主键ID
										,type_id	--任务类型ID
										,OA_Task_Type.name typeName--任务类型名称
										,title	--任务名称
										,[content]	--任务详细内容
										,creater_id	--创建人ID
										,PT_yhmc.v_xm--创建人
										,create_time	--最后修改时间
										,status	--任务状态( 0草稿、1未开始、2执行中、3已完成、4已关闭、5已删除 )
                                       ,CASE WHEN status=0 THEN '<span style=''color:#050505;''>草稿中</span>'  WHEN status=1 THEN '<span style=''color:#914229;''>未开始</span>' WHEN status=2 THEN '<span style=''color:#030310;''>执行中</span>' WHEN status=3 THEN '<span style=''color:#008B45;''>已完成</span>' WHEN status=4 THEN '<span style=''color:#dadada;''>已关闭</span>' END status_name 
										,start_time	--任务开始时间
										,end_time	--任务结束时间
										,datediff(minute, start_time,end_time) longs--持续多少分钟
										,complete_time	--任务完成时间
										,priority_id	--任务优先级 id
                                        ,if_send --是否通知 执行人更新任务进度时,是否发送微信消息给任务创建人
										,XPM_Basic_CodeList.CodeName--任务优先级名称
										,XPM_Basic_CodeList.I_xh--任务优先级排序
										--,OA_Task_Append.progress--任务进度百分比
										--,OA_Task_Append.up_time--任务最新提交时间
										--,OA_Task_Append.remark--任务进度备注说明
										,case when (SELECT top 1 progress FROM OA_Task_Progress_History WHERE head_id=OA_Task.Id order by time desc,OA_Task_Progress_History.id desc) is null then '0' else (SELECT top 1 progress FROM OA_Task_Progress_History WHERE head_id=OA_Task.Id order by time desc,OA_Task_Progress_History.id desc) end progress--任务进度百分比
										,(SELECT top 1 time FROM OA_Task_Progress_History WHERE head_id=OA_Task.Id order by time desc,OA_Task_Progress_History.id desc) up_time--任务最新提交时间
										,(SELECT top 1 content FROM OA_Task_Progress_History WHERE head_id=OA_Task.Id order by time desc,OA_Task_Progress_History.id desc) remark--任务进度备注说明
                                        ,(SELECT top 1 PT_yhmc.v_yhdm FROM OA_Task_Append  LEFT JOIN PT_yhmc ON OA_Task_Append.user_id=PT_yhmc.v_yhdm WHERE OA_Task_Append.Task_id=OA_Task.Id and (user_type=0 OR user_type=2) order by OA_Task_Append.id desc) syrID --执行人ID 
                                        ,(SELECT top 1 PT_yhmc.v_xm FROM OA_Task_Append  LEFT JOIN PT_yhmc ON OA_Task_Append.user_id=PT_yhmc.v_yhdm WHERE OA_Task_Append.Task_id=OA_Task.Id and (user_type=0 OR user_type=2) order by OA_Task_Append.id desc) syr --执行人名称
										,(SELECT PT_yhmc.v_xm+' ' FROM OA_Task_Append LEFT JOIN PT_yhmc ON OA_Task_Append.user_id=PT_yhmc.v_yhdm WHERE OA_Task_Append.Task_id=OA_Task.Id and user_type=1 FOR XML PATH('')) xgr --相关人
                                        ,(SELECT  top 1 CASE WHEN look_time IS NOT NULL THEN 1 ELSE 0 END ifck FROM OA_Task_Append	WHERE user_id='{1}' and OA_Task_Append.Task_id=OA_Task.Id ORDER BY	look_time DESC) ifck--是否查看该信息
										,(SELECT  COUNT(Id) plAll  FROM OA_Comment WHERE OA_Comment.head_id=OA_Task.Id) plAll--评论总数
										,(SELECT  COUNT(Id) plNew  FROM OA_Comment WHERE OA_Comment.head_id=OA_Task.Id  and [time] >(SELECT top 1 look_time FROM OA_Task_Append	WHERE user_id='{1}' and OA_Task_Append.Task_id=OA_Task.Id ORDER BY	look_time DESC)) plNew--新评论数量
										FROM OA_Task 
                                        LEFT JOIN OA_Task_Type ON OA_Task.type_id=OA_Task_Type.Id
                                        LEFT JOIN PT_yhmc ON OA_Task.creater_id=PT_yhmc.v_yhdm
                                        LEFT JOIN XPM_Basic_CodeList ON OA_Task.priority_id=XPM_Basic_CodeList.NoteID
                                        WHERE 1 = 1 and status !=5 {0}
                                        ) t ORDER BY pageindex asc", strWhere, userCode);
        return publicDbOpClass.DataTableQuary(strSql);
    }

    //case "-1":
    //                return "<span style='color:#050505;' state='-1'>草稿中</span>";

    //            case "0":
    //                return "<span style='color:#030310;' state='0'>审核中</span>";

    //            case "1":
    //                return "<span style='color:#008B45;' state='1'>已审核</span>";

    //            case "-2":
    //                return "<span style='color:#ff0000;' state='-2'>驳回</span>";

    //            case "-3":
    //                return "<span style='color:#914229;' state='-3'>重报</span>";
    //            case "-4":
    //                return "<span style='color:#dadada;' state='-4'>无流程</span>";
}