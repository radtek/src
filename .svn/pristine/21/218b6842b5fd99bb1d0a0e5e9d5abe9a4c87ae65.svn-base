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
    public class OAJournalAppendService : Repository<OAJournalAppend>
    {
        public void Delete(IList<string> idLst)
        {
            foreach (string str in idLst)
            {
                base.Delete(this.GetById(str));
            }
        }
        public void DeleteByJournalId(string JournalId)
        {
                base.Delete(this.GetByJournalId(JournalId));
        }
        [WebGet(UriTemplate= "/JournalAppend/{id}", ResponseFormat=WebMessageFormat.Json), OperationContract]
        public OAJournalAppend GetById(string id)
        {
            return (from pc in this
                where pc.Id == id
                select pc).FirstOrDefault<OAJournalAppend>();
        }
        public OAJournalAppend GetByJournalId(string JournalId)
        {
            return (from pc in this
                    where pc.journal_id == JournalId
                    select pc).FirstOrDefault<OAJournalAppend>();
        }

        public DataTable resulet(string user_id, string JournalId)
        {
            string strSql = string.Format(@"select * from OA_Journal_Append  where user_id='{0}' and journal_id='{1}'  ", user_id, JournalId);
            DataTable dt= publicDbOpClass.DataTableQuary(strSql);
            return dt;
        }
    }
}

