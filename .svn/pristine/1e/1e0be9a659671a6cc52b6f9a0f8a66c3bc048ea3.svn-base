namespace cn.justwin.Domain.Services
{
    using cn.justwin.Domain.Entities;
    using cn.justwin.Domain.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using WcfNHibernate;

    [ServiceContract, ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall), AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed), NHibernateContext]
    public class PTPrjInfoZTBDetailService : Repository<PTPrjInfoZTBDetail>
    {
        public void ChangeFlowSateByPrjId(string prjid, int changeFlowState)
        {
            Guid prjGuid = new Guid(prjid);
            PTPrjInfoZTBDetail item = (from p in this
                where p.PrjGuid == prjGuid
                select p).FirstOrDefault<PTPrjInfoZTBDetail>();
            if (item != null)
            {
                item.ProjFlowSate = new int?(changeFlowState);
                base.Update(item);
            }
        }

        public void Delete(string prjGuid)
        {
            string sql = string.Format("DELETE FROM PT_PrjInfo_ZTB_Detail WHERE PrjGuid = '{0}'", prjGuid);
            base.ExcuteSql(sql);
        }

        [OperationContract, WebGet(UriTemplate="/Project/{id}", ResponseFormat=WebMessageFormat.Json)]
        public PTPrjInfoZTBDetail GetById(string id)
        {
            Guid guid = new Guid(id);
            return (from p in this
                where p.PrjGuid == guid
                select p).FirstOrDefault<PTPrjInfoZTBDetail>();
        }

        public IList<string> GetGuidByPrjProperty(string userCode, string tableName)
        {
            string sql = string.Format("SELECT prjGuid FROM PT_PrjInfo_ZTB_Detail \r\n                                                WHERE prjProperty IN\r\n                                                (\r\n                                                   SELECT codeID FROM XPM_Basic_CodeList \r\n                                                   where NoteID IN \r\n                                                  (\r\n\t                                                SELECT DISTINCT RelationsKey\r\n\t                                                FROM Basic_Privilege\r\n\t                                                WHERE RelationsKey IN\r\n\t\t                                                (\r\n\t\t                                                SELECT NoteID FROM XPM_Basic_CodeList-- where TypeID='184'\r\n                                                        JOIN XPM_Basic_CodeType ON SignCode='ProjectProperty'\r\n                                                        WHERE XPM_Basic_CodeList.TypeID=XPM_Basic_CodeType.TypeID\r\n\t\t                                                )\r\n                                                     AND UserCode='{0}' AND RelationsTable='{1}'\r\n\t                                                )\r\n                                                )", userCode, tableName);
            IList<object> list = base.ExcuteSql(sql);
            List<string> list2 = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                list2.Add(list[i].ToString().ToUpper());
            }
            return list2;
        }

        public List<string> getUserCodesByIDThroughPrjProperty(string prjGuid)
        {
            List<string> list = new List<string>();
            PTPrjInfoZTBDetail byId = this.GetById(prjGuid);
            List<object> list2 = new List<object>();
            if (!string.IsNullOrEmpty(byId.PrjProperty))
            {
                string sql = string.Format("SELECT DISTINCT UserCode\r\n                                FROM Basic_Privilege \r\n                                JOIN XPM_Basic_CodeList on Basic_Privilege.RelationsKey=XPM_Basic_CodeList.NoteID\r\n                                JOIN XPM_Basic_CodeType ON SignCode='ProjectProperty'\r\n                                WHERE XPM_Basic_CodeList.TypeID=XPM_Basic_CodeType.TypeID\r\n                                AND XPM_Basic_CodeList.CodeID='{0}'", byId.PrjProperty);
                list2 = base.ExcuteSql(sql).ToList<object>();
            }
            for (int i = 0; i < list2.Count; i++)
            {
                list.Add(list2[i].ToString());
            }
            return list;
        }
    }
}

