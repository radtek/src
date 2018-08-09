namespace cn.justwin.stockBLL
{
    using cn.justwin.stockDAL;
    using System;
    using System.Collections.Specialized;

    public static class StockParameter
    {
        public static bool DepotBindType;
        public static string DepotType;
        public static bool IsLowAlarm;
        public static bool ProjectTransparentSet;

        public static double HighPlanAlarmLimit;
        public static bool IsContainPending;
        public static bool IsHighPlanAlarm;
        public static bool IsLowPlanAlarm;
        public static bool IsMidPlanAlarm;
        public static double LowPlanAlarmLowerLimit;
        public static double LowPlanAlarmUpperLimit;
        public static double MidPlanAlarmLowerLimit;
        public static double MidPlanAlarmUpperLimit;
        public static string ProjectAlarm;

        public static double HighPlanAlarmLimit2;
        public static bool IsContainPending2;
        public static bool IsHighPlanAlarm2;
        public static bool IsLowPlanAlarm2;
        public static bool IsMidPlanAlarm2;
        public static double LowPlanAlarmLowerLimit2;
        public static double LowPlanAlarmUpperLimit2;
        public static double MidPlanAlarmLowerLimit2;
        public static double MidPlanAlarmUpperLimit2;
        public static string ProjectAlarm2;


        static StockParameter()
        {
            Init();
        }

        public static string getSm_setValue(string paraname)
        {
            return basicSetDal.getSm_setValue(paraname);
        }

        private static void Init()
        {
            NameValueCollection basicParameters = basicSetBLL.GetBasicParameters();
            DepotType = basicParameters["DepotType"];
            DepotBindType = basicParameters["DepotBindType"] == "Bind";
            ProjectTransparentSet = basicParameters["ProjectTransparentSet"] == "Transparent";
            IsLowAlarm = basicParameters["IsLowAlarm"] == "1";

            ProjectAlarm = basicParameters["ProjectAlarm"];
            IsHighPlanAlarm = basicParameters["IsHighPlanAlarm"] == "1";
            HighPlanAlarmLimit = double.Parse(basicParameters["HighPlanAlarmLimit"]);
            IsMidPlanAlarm = basicParameters["IsMidPlanAlarm"] == "1";
            MidPlanAlarmUpperLimit = double.Parse(basicParameters["MidPlanAlarmUpperLimit"]);
            MidPlanAlarmLowerLimit = double.Parse(basicParameters["MidPlanAlarmLowerLimit"]);
            IsLowPlanAlarm = basicParameters["IsLowPlanAlarm"] == "1";
            LowPlanAlarmUpperLimit = double.Parse(basicParameters["LowPlanAlarmUpperLimit"]);
            LowPlanAlarmLowerLimit = double.Parse(basicParameters["LowPlanAlarmLowerLimit"]);
            IsContainPending = basicParameters["IsContainPending"] == "1";


            ProjectAlarm2 = basicParameters["ProjectAlarm2"];
            IsHighPlanAlarm2 = basicParameters["IsHighPlanAlarm2"] == "1";
            HighPlanAlarmLimit2 = double.Parse(basicParameters["HighPlanAlarmLimit2"]);
            IsMidPlanAlarm2 = basicParameters["IsMidPlanAlarm2"] == "1";
            MidPlanAlarmUpperLimit2 = double.Parse(basicParameters["MidPlanAlarmUpperLimit2"]);
            MidPlanAlarmLowerLimit2 = double.Parse(basicParameters["MidPlanAlarmLowerLimit2"]);
            IsLowPlanAlarm2 = basicParameters["IsLowPlanAlarm2"] == "1";
            LowPlanAlarmUpperLimit2 = double.Parse(basicParameters["LowPlanAlarmUpperLimit2"]);
            LowPlanAlarmLowerLimit2 = double.Parse(basicParameters["LowPlanAlarmLowerLimit2"]);
            IsContainPending2 = basicParameters["IsContainPending2"] == "1";
        }

        public static void Update()
        {
            Init();
        }

        public static int UpdateDatabase()
        {
            int num = 1;
            try
            {
                UpdateVal("DepotType", DepotType);
                UpdateVal("DepotBindType", DepotBindType ? "Bind" : "UnBind");
                UpdateVal("ProjectTransparentSet", ProjectTransparentSet ? "Transparent" : "UnTransparent");
                UpdateVal("IsLowAlarm", IsLowAlarm ? "1" : "0");

                UpdateVal("ProjectAlarm", ProjectAlarm);
                UpdateVal("IsHighPlanAlarm", IsHighPlanAlarm ? "1" : "0");
                UpdateVal("HighPlanAlarmLimit", HighPlanAlarmLimit.ToString());
                UpdateVal("IsMidPlanAlarm", IsMidPlanAlarm ? "1" : "0");
                UpdateVal("MidPlanAlarmUpperLimit", MidPlanAlarmUpperLimit.ToString());
                UpdateVal("MidPlanAlarmLowerLimit", MidPlanAlarmLowerLimit.ToString());
                UpdateVal("IsLowPlanAlarm", IsLowPlanAlarm ? "1" : "0");
                UpdateVal("MidPlanAlarmUpperLimit", MidPlanAlarmUpperLimit.ToString());
                UpdateVal("MidPlanAlarmLowerLimit", MidPlanAlarmLowerLimit.ToString());
                UpdateVal("IsContainPending", IsContainPending ? "1" : "0");

                UpdateVal("ProjectAlarm2", ProjectAlarm2);
                UpdateVal("IsHighPlanAlarm2", IsHighPlanAlarm2 ? "1" : "0");
                UpdateVal("HighPlanAlarmLimit2", HighPlanAlarmLimit2.ToString());
                UpdateVal("IsMidPlanAlarm2", IsMidPlanAlarm2 ? "1" : "0");
                UpdateVal("MidPlanAlarmUpperLimit2", MidPlanAlarmUpperLimit2.ToString());
                UpdateVal("MidPlanAlarmLowerLimit2", MidPlanAlarmLowerLimit2.ToString());
                UpdateVal("IsLowPlanAlarm2", IsLowPlanAlarm2 ? "1" : "0");
                UpdateVal("MidPlanAlarmUpperLimit2", MidPlanAlarmUpperLimit2.ToString());
                UpdateVal("MidPlanAlarmLowerLimit2", MidPlanAlarmLowerLimit2.ToString());
                UpdateVal("IsContainPending2", IsContainPending2 ? "1" : "0");
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        public static int UpdateVal(string key, string val)
        {
            return basicSetDal.UpdateSetByKeyVal(key, val);
        }
    }
}

