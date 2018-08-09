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
    public class PCCautionMoneyService : Repository<PCCautionMoney>
    {
        public void Delete(IList<string> idLst)
        {
            foreach (string str in idLst)
            {
                base.Delete(this.GetById(str));
            }
        }

        [WebGet(UriTemplate="/PCCautionMoney/{id}", ResponseFormat=WebMessageFormat.Json), OperationContract]
        public PCCautionMoney GetById(string id)
        {
            return (from pc in this
                where pc.Id == id
                select pc).FirstOrDefault<PCCautionMoney>();
        }

        //public decimal GetCashTotal(int year, string userCode)
        //{
        //    decimal num = 0M;
        //    IQueryable<decimal> source = from p in this
        //        where ((p.ApplicationDate.Year == year) && (p.ApplicantId == userCode)) && (p.FlowState == 1)
        //        select p.Cash;
        //    if (source.Count<decimal>() > 0)
        //    {
        //        num = source.Sum();
        //    }
        //    return num;
        //}

        //public DataTable GetMonthCash(int year, string userCode)
        //{
           // List<PCCautionMoney> source = (from p in this
           //    // where ((p.ApplicationDate.Year == year) && (p.ApplicantId == userCode)) && (p.FlowState == 1)
           //     select p).ToList<PCCautionMoney>();
           // DataTable table = new DataTable();
           // table.Columns.Add(new DataColumn("No"));
           // table.Columns.Add(new DataColumn("Date"));
           //// table.Columns.Add(new DataColumn("Matter"));
           // table.Columns.Add(new DataColumn("Cash", typeof(decimal)));
           // //Func<PCCautionMoney, bool> predicate = null;
           // //for (int i = 1; i <= 12; i++)
           // //{
           // //    if (predicate == null)
           // //    {
           // //        predicate = p => p.ApplicationDate.Month == i;
           // //    }
           // //    List<PCCautionMoney> list2 = source.Where<PCCautionMoney>(predicate).ToList<PCCautionMoney>();
           // //   // List<string> values = (from p in list2 select p.Matter).ToList<string>();
           // //    decimal num = ((IEnumerable<decimal>) (from p in list2 select p.Cash).ToList<decimal>()).Sum();
           // //    DataRow row = table.NewRow();
           // //    row["No"] = i;
           // //    row["Date"] = string.Format("{0}年{1}月", year, i);
           // //    //row["Matter"] = string.Join("<br />", values);
           // //    row["Cash"] = num;
           // //    table.Rows.Add(row);
           // //}
           // return table;
        //}
    }
}

