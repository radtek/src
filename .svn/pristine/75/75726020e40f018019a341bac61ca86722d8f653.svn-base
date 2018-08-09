namespace cn.justwin.Domain.Services
{
    using cn.justwin.Domain.Entities;
    using cn.justwin.Domain.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using WcfNHibernate;

    [NHibernateContext, ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall), AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed), ServiceContract]
    public class OAJournalTypeService : Repository<OAJournalType>
    {
        public void Delete(IList<string> list)
        {
            foreach (string str in list)
            {
                base.Delete(this.GetById(str));
            }
        }
        [WebGet(UriTemplate= "/Journal/{id}", ResponseFormat=WebMessageFormat.Json), OperationContract]
        public OAJournalType GetById(string id)
        {
            return (from pc in this
                where pc.Id == id
                select pc).FirstOrDefault<OAJournalType>();
        }

        public void Update(List<string> list, int v)
        {
            foreach (string str in list)
            {
                base.Update(this.GetById(str));
            }
        }
    }
}

