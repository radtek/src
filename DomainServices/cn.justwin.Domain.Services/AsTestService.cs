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
    public class AsTestService : Repository<AsTest>
    {
        public void Delete(IList<string> idLst)
        {
            foreach (string str in idLst)
            {
                base.Delete(this.GetById(str));
            }
        }

        [WebGet(UriTemplate="/AsTest/{id}", ResponseFormat=WebMessageFormat.Json), OperationContract]
        public AsTest GetById(string id)
        {
            return (from pc in this
                where pc.Id == id
                select pc).FirstOrDefault<AsTest>();
        }
    }
}

