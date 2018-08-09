namespace cn.justwin.Domain.Services
{
    using cn.justwin.Domain.Entities;
    using cn.justwin.Domain.Repositories;
    using com.jwsoft.pm.data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using WcfNHibernate;

    [NHibernateContext, ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall), AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed), ServiceContract]
    public class OAJournalService : Repository<OAJournal>
    {
        //public void Delete(IList<string> idLst)
        //{
        //    foreach (string str in idLst)
        //    {
        //        base.Delete(this.GetById(str));
        //    }
        //}
        //[WebGet(UriTemplate= "/Journal/{id}", ResponseFormat=WebMessageFormat.Json), OperationContract]
        public OAJournal GetById(string id)
        {
            return (from pc in this
                where pc.Id == id
                select pc).FirstOrDefault<OAJournal>();
        }
        public int ChangeViewTime(string KeyID, string UserCode)
        {
            return publicDbOpClass.ExecuteSQL("update OA_Journal_Append set look_time='" + DateTime.Now + "' where journal_id='" + KeyID + "' and user_id='" + UserCode + "'");
        }

        public DataTable GetMsgTable(string strWhere, string UserCode)
        {
            string strSql = string.Format(@"SELECT * FROM (
                                        SELECT row_number() over (ORDER BY OA_Journal.create_date desc,OA_Journal.id desc) as 
                                         pageindex--��� 
                                        ,OA_Journal.Id--����ID
                                        ,OA_Journal.type_id--��־����ID
                                        ,OA_Journal_Type.name typeName--��־��������
                                        ,OA_Journal.project_id--��ĿID
                                        ,PT_PrjInfo.PrjName --��Ŀ����
                                        ,OA_Journal.title--����
                                        ,OA_Journal.creater--������ID
                                        ,PT_yhmc.v_xm--������
                                        ,OA_Journal.status--��־״̬(0:�ݸ�;1���ύ;2������)
                                        ,OA_Journal.start_time--��ʼʱ��
                                        ,OA_Journal.end_time--����ʱ��
                                        ,datediff(minute, OA_Journal.start_time,OA_Journal.end_time) longs--�������ٷ���
                                        ,CONVERT(VARCHAR(50),OA_Journal.start_time,108) t1
										,CONVERT(VARCHAR(50),OA_Journal.end_time,108) t2
										,'' ifkt
                                        ,'' ifjb
                                        ,OA_Journal.content--����
                                        ,OA_Journal.task_id--��������ID
                                       ,OA_Task.title taskName--������������
                                        ,OA_Journal.create_date--����ʱ��
                                        ,(SELECT top 1 PT_yhmc.v_xm FROM OA_Journal_Append  LEFT JOIN PT_yhmc ON OA_Journal_Append.user_id=PT_yhmc.v_yhdm WHERE OA_Journal_Append.journal_id=OA_Journal.Id and (user_type=0 OR user_type=2)) syr --������
										,(SELECT PT_yhmc.v_xm+' ' FROM OA_Journal_Append LEFT JOIN PT_yhmc ON OA_Journal_Append.user_id=PT_yhmc.v_yhdm WHERE OA_Journal_Append.journal_id=OA_Journal.Id and user_type=1 FOR XML PATH('')) xgr --�����
                                        ,(SELECT  top 1 CASE WHEN look_time IS NOT NULL THEN 1 ELSE 0 END ifck FROM OA_Journal_Append	WHERE user_id='{1}' and OA_Journal_Append.journal_id=OA_Journal.Id ORDER BY	look_time DESC) ifck--�Ƿ�鿴����־
																				,(SELECT  COUNT(Id) plAll  FROM OA_Journal_Comment WHERE OA_Journal_Comment.journal_id=OA_Journal.Id) plAll--��������
																					,(SELECT  COUNT(Id) plNew  FROM OA_Journal_Comment WHERE OA_Journal_Comment.journal_id=OA_Journal.Id  and [time] >(SELECT top 1 look_time FROM OA_Journal_Append	WHERE user_id='{1}' and OA_Journal_Append.journal_id=OA_Journal.Id ORDER BY	look_time DESC)) plNew--����������
																				FROM OA_Journal 
                                        LEFT JOIN OA_Journal_Type ON OA_Journal.type_id=OA_Journal_Type.Id
                                        LEFT JOIN PT_yhmc ON OA_Journal.creater=PT_yhmc.v_yhdm
                                        LEFT JOIN PT_PrjInfo ON OA_Journal.project_id=PT_PrjInfo.PrjGuid
                                        LEFT JOIN OA_Task ON OA_Journal.task_id=OA_Task.id
                                        WHERE 1 = 1 {0}
                                        ) t ORDER BY pageindex ", strWhere, UserCode);
            return publicDbOpClass.DataTableQuary(strSql);
        }
    }
}

