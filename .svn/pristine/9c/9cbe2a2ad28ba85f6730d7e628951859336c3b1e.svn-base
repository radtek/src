namespace cn.justwin.Tender
{
    using cn.justwin.DAL;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ProjectKind
    {
        public static IList<ProjectKind> GetProjectKinds(Guid prjGuid)
        {
            IList<ProjectKind> list = new List<ProjectKind>();
            using (pm2Entities entities = new pm2Entities())
            {
                foreach (PT_PrjInfo_Kind kind in from k in entities.PT_PrjInfo_Kind
                    where k.PrjGuid == prjGuid
                    select k)
                {
                    ProjectKind item = new ProjectKind {
                        PrjKind = kind.PrjKind,
                        ProfessionalCost = kind.ProfessionalCost
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public static void Update(string prjGuid, IList<ProjectKind> kindList)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                string commandText = string.Format("DELETE FROM PT_PrjInfo_Kind WHERE PrjGuid = '{0}'", prjGuid);
                entities.ExecuteStoreCommand(commandText, new object[0]);
                if (kindList != null)
                {
                    foreach (ProjectKind kind in kindList)
                    {
                        PT_PrjInfo_Kind kind2 = new PT_PrjInfo_Kind {
                            KindId = Guid.NewGuid().ToString(),
                            PrjGuid = new Guid(prjGuid),
                            PrjKind = kind.PrjKind,
                            ProfessionalCost = kind.ProfessionalCost
                        };
                        entities.AddToPT_PrjInfo_Kind(kind2);
                    }
                }
            }
        }

        public static void Update(string prjGuid, IList<ProjectKind> kindList, pm2Entities pm2)
        {
            string commandText = string.Format("DELETE FROM PT_PrjInfo_Kind WHERE PrjGuid = '{0}'", prjGuid);
            pm2.ExecuteStoreCommand(commandText, new object[0]);
            if (kindList != null)
            {
                foreach (ProjectKind kind in kindList)
                {
                    PT_PrjInfo_Kind kind2 = new PT_PrjInfo_Kind {
                        KindId = Guid.NewGuid().ToString(),
                        PrjGuid = new Guid(prjGuid),
                        PrjKind = kind.PrjKind,
                        ProfessionalCost = kind.ProfessionalCost
                    };
                    pm2.AddToPT_PrjInfo_Kind(kind2);
                }
            }
        }

        public string PrjKind { get; set; }

        public decimal ProfessionalCost { get; set; }
    }
}

