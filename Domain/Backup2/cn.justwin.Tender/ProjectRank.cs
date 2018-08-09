namespace cn.justwin.Tender
{
    using cn.justwin.DAL;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ProjectRank
    {
        public static IList<ProjectRank> GetRanks(Guid prjGuid)
        {
            IList<ProjectRank> list = new List<ProjectRank>();
            using (pm2Entities entities = new pm2Entities())
            {
                foreach (PT_PrjInfo_Rank rank in from r in entities.PT_PrjInfo_Rank
                    where r.PrjGuid == prjGuid
                    select r)
                {
                    ProjectRank item = new ProjectRank {
                        Rank = rank.PrjRank,
                        RankLevel = rank.RankLevel
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public static void Update(string prjGuid, IList<ProjectRank> rankList)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                string commandText = string.Format("DELETE FROM PT_PrjInfo_Rank WHERE PrjGuid = '{0}'", prjGuid);
                entities.ExecuteStoreCommand(commandText, new object[0]);
                if (rankList != null)
                {
                    foreach (ProjectRank rank in rankList)
                    {
                        PT_PrjInfo_Rank rank2 = new PT_PrjInfo_Rank {
                            RankId = Guid.NewGuid().ToString(),
                            PrjGuid = new Guid(prjGuid),
                            PrjRank = rank.Rank,
                            RankLevel = rank.RankLevel
                        };
                        entities.AddToPT_PrjInfo_Rank(rank2);
                    }
                }
            }
        }

        public static void Update(string prjGuid, IList<ProjectRank> rankList, pm2Entities pm2)
        {
            string commandText = string.Format("DELETE FROM PT_PrjInfo_Rank WHERE PrjGuid = '{0}'", prjGuid);
            pm2.ExecuteStoreCommand(commandText, new object[0]);
            if (rankList != null)
            {
                foreach (ProjectRank rank in rankList)
                {
                    PT_PrjInfo_Rank rank2 = new PT_PrjInfo_Rank {
                        RankId = Guid.NewGuid().ToString(),
                        PrjGuid = new Guid(prjGuid),
                        PrjRank = rank.Rank,
                        RankLevel = rank.RankLevel
                    };
                    pm2.AddToPT_PrjInfo_Rank(rank2);
                }
            }
        }

        public string Rank { get; set; }

        public string RankLevel { get; set; }
    }
}

