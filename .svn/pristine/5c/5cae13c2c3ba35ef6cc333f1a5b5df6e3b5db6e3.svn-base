namespace cn.justwin.PrjManager
{
    using cn.justwin.BLL;
    using cn.justwin.DAL;
    using cn.justwin.Domain.Services;
    using cn.justwin.Tender;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Web.UI.WebControls;

    public class ProjectInfo
    {
        private IList<cn.justwin.Tender.EngineeringType> engineeringTypes;
        private static string IsIncomeContractApprove = ConfigHelper.Get("IsIncomeContractApprove");
        private IList<ProjectRank> prjRanks;
        private IList<ProjectKind> prjTypes;

        public void Add(ProjectInfo model)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                if (model != null)
                {
                    int? nullable = (from m in entities.PT_PrjInfo select m.i_xh).Max<int?>();
                    if (!nullable.HasValue)
                    {
                        nullable = 0;
                    }
                    PT_PrjInfo info = new PT_PrjInfo {
                        PrjGuid = new Guid?(model.PrjGuid),
                        TypeCode = model.TypeCode,
                        i_xh = nullable + 1,
                        IsValid = "1",
                        i_ChildNum = 0,
                        PrjCode = model.PrjCode,
                        PrjName = model.PrjName,
                        RecordDate = new DateTime?(DateTime.Now),
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        ComputeClass = "1",
                        RationClass = "",
                        PrjCost = model.PrjCost,
                        ContractSum = "",
                        Duration = model.Duration,
                        QualityClass = model.QualityClass,
                        Area = model.Area,
                        PrjPlace = model.PrjPlace,
                        Remark1 = model.Remark,
                        Counsellor = model.Counsellor,
                        Designer = model.Designer,
                        Inspector = model.Inspector,
                        PrjInfo = model.PrjInfo,
                        PrjState = model.PrjState,
                        OwnerCode = model.OwnerCode,
                        MarketInfoGuid = new Guid?(Guid.Empty),
                        BudgetWay = model.BudgetWay,
                        ContractWay = model.ContractWay,
                        PayCondition = model.PayCondition,
                        TenderWay = model.TenderWay,
                        PayWay = model.PayWay,
                        KeyPart = model.KeyPart,
                        WorkUnit = model.WorkUnit,
                        LinkMan = model.LinkMan,
                        PrjManager = model.PrjManager,
                        TotalHouseNum = model.TotalHouseNum,
                        BuildingArea = model.BuildingArea,
                        UsegrounArea = model.UsegrounArea,
                        UndergroundArea = model.UndergroundArea,
                        PrjFundInfo = model.PrjFundInfo,
                        OtherStatement = model.OtherStatement,
                        xmgroup = model.Xmgroup,
                        grade = model.PrjGrade,
                        businessman = model.Businessman,
                        telephone = model.Telephone,
                        UserCode = model.UserCode
                    };
                    entities.AddToPT_PrjInfo(info);
                    PT_PrjInfo_ZTB_Detail detail = new PT_PrjInfo_ZTB_Detail {
                        PrjGuid = model.PrjGuid,
                        ProgAgent = model.ProgAgent,
                        ProjFlowSate = -1,
                        EngineeringType = model.EngineeringType,
                        EngineeringSubType = model.EngineeringSubType,
                        Grade = model.Grade,
                        IsTender = false,
                        ProjPeopleName = model.ProjPeopleUserName,
                        ProjPeopleDep = model.ProjPeopleCorp,
                        ProjPeopleDuty = model.ProjPeopleDuty,
                        ProjPeopleTel = model.ProjPeopleTel,
                        OwnerLinkMan = model.OwnerLinkMan,
                        OwnerLinkPhone = model.OwnerLinkPhone,
                        OwnerAddress = model.OwnerAddress,
                        ForecastProfitRate = model.ForecastProfitRate,
                        EngineeringEstimates = model.EngineeringEstimates,
                        PrjDutyPerson = model.PrjDutyPerson,
                        PrjApprovalOf = model.PrjApprovalOf,
                        PrjFundWorkable = model.PrjFundWorkable,
                        ManagementMargin = model.ManagementMargin,
                        MigrantQualityMarginRate = model.MigrantQualityMarginRate,
                        WithholdingTaxRate = model.WithholdingTaxRate,
                        PerformanceBond = model.PerformanceBond,
                        ElseMargin = model.ElseMargin,
                        InputUser = model.InputUser,
                        InputDate = model.InputDate,
                        ActualRunDate = model.ActualRunDate,
                        PrjReadOne = model.PrjReadOne,
                        ProjInfoOrigin = model.ProjInfoOrigin,
                        ProjElseRequest = model.ProjElseRequest,
                        Telephone = model.Telephone,
                        PrjProperty = model.PrjProperty,
                        MemberFlowState = -1,
                        CompletedFlowState = -1,
                        PrjManagerRequire = model.PrjManagerRequire,
                        TechnicalLeaderRequire = model.TechnicalLeaderRequire,
                        Province = model.Province,
                        City = model.City,
                        SetUpFlowState = -1,
                        AfforestArea = model.AfforestArea,
                        ParkArea = model.ParkArea
                    };
                    entities.AddToPT_PrjInfo_ZTB_Detail(detail);
                    entities.SaveChanges();
                    this.AddDefaultLimit(model);
                    cn.justwin.Tender.EngineeringType.UpdateEngineerType(model.EngineeringTypes, model.PrjGuid.ToString(), entities);
                    ProjectKind.Update(model.PrjGuid.ToString(), model.PrjTypes, entities);
                    ProjectRank.Update(model.PrjGuid.ToString(), model.prjRanks, entities);
                    string typecode = model.TypeCode;
                    if (typecode.Length > 5)
                    {
                        int num = (from n in entities.PT_PrjInfo
                            where n.TypeCode.StartsWith(typecode.Substring(0, 5)) && (n.TypeCode.Length == typecode.Length)
                            select n).Count<PT_PrjInfo>();
                        (from a in entities.PT_PrjInfo
                            where a.TypeCode == typecode.Substring(0, 5)
                            select a).FirstOrDefault<PT_PrjInfo>().i_ChildNum = new int?(num);
                    }
                    entities.SaveChanges();
                }
            }
        }

        public int AddByTender(string PrjId, string UpPrjGuid, string xmgroup, string date)
        {
            string typeCode = GetTypeCode(UpPrjGuid);
            string str2 = "";
            using (pm2Entities entities = new pm2Entities())
            {
                str2 = (from m in entities.PT_PrjInfo select m.i_xh).Max<int?>().ToString();
                entities.SaveChanges();
            }
            if (string.IsNullOrEmpty(str2))
            {
                str2 = "1";
            }
            else
            {
                str2 = (int.Parse(str2) + 1).ToString();
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("\r\n\t\t\t\tDECLARE @user AS nvarchar(4000)\r\t\t\t\tSELECT @user= ISNULL(@user + ',' ,',') + UserCode \r\t\t\t\tFROM (\r\t\t\t\t\tSELECT DISTINCT UserCode FROM PT_PrjInfo_ZTB_User \r\t\t\t\t\tWHERE PrjGuid = '" + PrjId + "'\r\t\t\t\t)AS T\r\t\t\t\tSELECT @user AS users");
            string str3 = string.Empty;
            try
            {
                str3 = SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), new SqlParameter[0]).ToString();
            }
            catch
            {
            }
            StringBuilder builder2 = new StringBuilder();
            builder2.AppendFormat(" INSERT INTO PT_PrjInfo (TypeCode,i_xh,PrjState,xmgroup,UserCode,PrjCode,PrjGuid,PrjName,StartDate,EndDate,ComputeClass,RationClass,PrjCost,ContractSum,Duration,QualityClass,\r\nArea,PrjKindClass,PrjPlace,Remark1,Owner,Counsellor,Designer,Inspector,PrjInfo,OwnerCode,MarketInfoGuid,Rank,BudgetWay,\r\nContractWay,PayCondition,TenderWay,PayWay,KeyPart,WorkUnit,LinkMan,PrjManager,BuildingType,TotalHouseNum,BuildingArea,\r\nUsegrounArea,UndergroundArea,PrjFundInfo,OtherStatement,Podepom\r\n)\r\nSELECT '{0}','{1}',5,'{2}',InputUser, PrjCode,PT_PrjInfo_ZTB.PrjGuid,PrjName,StartDate,EndDate,ComputeClass,RationClass,PrjCost,ContractSum,Duration,QualityClass,\r\nArea,PrjKindClass,PrjPlace,Remark,Owner,Counsellor,Designer,Inspector,PrjInfo,OwnerCode,MarketInfoGuid,Rank,BudgetWay,\r\nContractWay,PayCondition,TenderWay,PayWay,KeyPart,WorkUnit,LinkMan,PrjManager,BuildingType,TotalHouseNum,BuildingArea,\r\nUsegrounArea,UndergroundArea,PrjFundInfo,OtherStatement,'{4}' FROM PT_PrjInfo_ZTB \r\nLEFT JOIN  PT_PrjInfo_ZTB_Detail ON PT_PrjInfo_ZTB.PrjGuid=PT_PrjInfo_ZTB_Detail.PrjGuid  WHERE PT_PrjInfo_ZTB.PrjGuid='{3}'", new object[] { typeCode, str2, xmgroup, PrjId, str3 });
            if (!string.IsNullOrEmpty(date))
            {
                builder2.AppendFormat("UPDATE PT_PrjInfo_ZTB_Detail SET ActualRunDate= '{0}' WHERE PrjGuid='{1}'", date, PrjId);
            }
            builder2.AppendFormat("UPDATE PT_PrjInfo_ZTB_Detail SET SetUpFlowState=1 WHERE PrjGuid='{0}'", PrjId);
            if (!string.IsNullOrEmpty(UpPrjGuid))
            {
                builder2.AppendFormat("UPDATE Pt_PrjInfo SET i_ChildNum=i_ChildNum+1 WHERE PrjGuid='{0}'", UpPrjGuid);
            }
            return SqlHelper.ExecuteNonQuery(CommandType.Text, builder2.ToString(), new SqlParameter[0]);
        }

        private void AddDefaultLimit(ProjectInfo mode)
        {
            List<string> source = new List<string> { "00000000" };
            if (!string.IsNullOrEmpty(mode.UserCode))
            {
                source.Add(mode.UserCode);
            }
            if (!string.IsNullOrEmpty(mode.PrjDutyPerson))
            {
                source.Add(mode.PrjDutyPerson);
            }
            if (!string.IsNullOrEmpty(mode.ProgAgent))
            {
                source.Add(mode.ProgAgent);
            }
            if (!string.IsNullOrEmpty(mode.Businessman))
            {
                source.Add(mode.Businessman);
            }
            if (!string.IsNullOrEmpty(mode.PrjReadOne))
            {
                source.Add(mode.PrjReadOne);
            }
            string prjGuid = mode.PrjGuid.ToString();
            foreach (string str2 in source.Distinct<string>().ToList<string>())
            {
                TenderUser.Add(prjGuid, str2);
            }
        }

        public static void BindPrj(DropDownList drop)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                List<PT_PrjInfo> list = (from m in entities.PT_PrjInfo
                    join n in entities.PT_PrjInfo_ZTB_Detail on m.PrjGuid equals (Guid?) n.PrjGuid into n
                    where (m.TypeCode.Length == 5) && n.IsTender
                    select m).ToList<PT_PrjInfo>();
                drop.DataSource = list;
                drop.DataTextField = "PrjName";
                drop.DataValueField = "PrjGuid";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("", ""));
            }
        }

        public static void Del(IList<string> idList)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                if (idList.Count == 1)
                {
                    Del(idList[0], entities);
                }
                else
                {
                    Del(idList, entities);
                }
                entities.SaveChanges();
            }
        }

        public static void Del(string id)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Del(id, entities);
            }
        }

        private static void Del(IList<string> idlist, pm2Entities context)
        {
            foreach (string str in idlist)
            {
                Del(str, context);
            }
        }

        private static void Del(string id, pm2Entities context)
        {
            Guid guid = new Guid(id);
            PT_PrjInfo entity = (from m in context.PT_PrjInfo
                where m.PrjGuid == guid
                select m).FirstOrDefault<PT_PrjInfo>();
            if (entity != null)
            {
                if (GetChildPrjByTypeCode(entity.TypeCode).Count > 0)
                {
                    throw new Exception("请先删除子项目！");
                }
                cn.justwin.Tender.EngineeringType.Delete(id, context);
                context.DeleteObject(entity);
                string typeCode = entity.TypeCode;
                if (typeCode.Length == 10)
                {
                    string parCode = typeCode.Substring(0, 5);
                    PT_PrjInfo info2 = (from m in context.PT_PrjInfo
                        where m.TypeCode == parCode
                        select m).FirstOrDefault<PT_PrjInfo>();
                    if (info2 != null)
                    {
                        info2.i_ChildNum -= 1;
                    }
                }
                PT_PrjInfo_ZTB_Detail detail = (from m in context.PT_PrjInfo_ZTB_Detail
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo_ZTB_Detail>();
                if (detail != null)
                {
                    context.DeleteObject(detail);
                }
                new PTPrjInfoZTBUserService().Delete(guid.ToString());
            }
        }

        public static DataTable GetAllTenderPrjReport(string prjCode, string prjName, string prjManager, string prjKindClass, string startDate, string endDate, string owner, string prjState, string userCode, int pageNo, int pageSize, string IsTender, ref int refRowCount)
        {
            DataTable table = new DataTable();
            string str = "TypeCode,Primit,i_ChildNum,PrjGuid,PrjCode,InputDate,PrjName,StartDate,EndDate,PrjCost,Duration,Owner,PrjMangerName,PrjStateName,PrjKindName,IsTender\r\n,CASE IsTender \r\n\tWHEN 1 THEN 1\r\n\tELSE SetUpFlowState\r\nEND AS SetUpFlowState";
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter item = new SqlParameter("@rowCount", SqlDbType.Int) {
                Direction = ParameterDirection.Output
            };
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.AppendFormat(" AND PrjCode like  '%{0}%' ", prjCode);
            }
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.AppendFormat(" AND PrjName like  '%{0}%' ", prjName);
            }
            if (!string.IsNullOrEmpty(prjManager))
            {
                builder.AppendFormat(" AND PrjMangerName like  '%{0}%' ", prjManager);
            }
            if (!string.IsNullOrEmpty(prjKindClass))
            {
                builder.AppendFormat(" AND  PrjKindClass='{0}'", prjKindClass);
            }
            if (!string.IsNullOrEmpty(owner))
            {
                builder.AppendFormat(" AND Owner like  '%{0}%' ", owner);
            }
            if (!string.IsNullOrEmpty(prjState))
            {
                builder.AppendFormat(" AND PrjState={0}", prjState);
            }
            else
            {
                builder.AppendFormat(" AND PrjState in(5,7,8,9,10,11,12,13,17) ", new object[0]);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                builder.AppendFormat(" AND InputDate >= '{0}' ", startDate);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                builder.AppendFormat(" AND InputDate <= '{0}' ", endDate + " 23:59:59");
            }
            list.Add(new SqlParameter("@userCode", userCode));
            list.Add(new SqlParameter("@isTender", IsTender));
            list.Add(new SqlParameter("@columns", str));
            list.Add(new SqlParameter("@condition", builder.ToString()));
            list.Add(new SqlParameter("@pageIndex", pageNo));
            list.Add(new SqlParameter("@pageSize", pageSize));
            list.Add(item);
            table = SqlHelper.ExecuteQuery(CommandType.StoredProcedure, "uspGetAllProject", list.ToArray());
            refRowCount = Convert.ToInt32(item.Value);
            return table;
        }

        public static ProjectInfo GetById(string id)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression6;
                Guid prjGuid = new Guid(id);
                return (from m in entities.PT_PrjInfo
                    join d in entities.PT_PrjInfo_ZTB_Detail on m.PrjGuid equals (Guid?) d.PrjGuid into d
                    where (m.PrjGuid == prjGuid) && (d.PrjGuid == prjGuid)
                    select <>h__TransparentIdentifier17).Select(Expression.Lambda(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(ProjectInfo..ctor), new Expression[0]), new MemberBinding[] { 
                    Expression.Bind((MethodInfo) methodof(ProjectInfo.set_TypeCode), Expression.Property(Expression.Property(expression6 = Expression.Parameter(typeof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>), "<>h__TransparentIdentifier17"), (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_TypeCode))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjCode), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjCode))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjName), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjName))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_StartDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_StartDate))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_EndDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_EndDate))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjCost), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjCost))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Duration), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_Duration))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_QualityClass), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_QualityClass))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Area), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_Area))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjKindClass), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjKindClass))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjPlace), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjPlace))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Remark), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_Remark1))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Rank), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_Rank))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_BudgetWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_BudgetWay))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ContractWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_ContractWay))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PayCondition), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PayCondition))), 
                    Expression.Bind((MethodInfo) methodof(ProjectInfo.set_TenderWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_TenderWay))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PayWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PayWay))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_KeyPart), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_KeyPart))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_WorkUnit), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_WorkUnit))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_LinkMan), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_LinkMan))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjManager), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjManager))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_BuildingType), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_BuildingType))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_TotalHouseNum), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_TotalHouseNum))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_BuildingArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_BuildingArea))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_UsegrounArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_UsegrounArea))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_UndergroundArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_UndergroundArea))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjFundInfo), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjFundInfo))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_OtherStatement), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_OtherStatement))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Xmgroup), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_xmgroup))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjGrade), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_grade))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Businessman), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_businessman))), 
                    Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Telephone), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_Telephone))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ProjElseRequest), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjElseRequest))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ProjInfoOrigin), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjInfoOrigin))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjReadOne), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjReadOne))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ProgAgent), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProgAgent))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_EngineeringType), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_EngineeringType))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_EngineeringSubType), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_EngineeringSubType))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Grade), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_Grade))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjInfo), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjInfo))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjState), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjState))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjGuid), Expression.Coalesce(Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_PrjGuid)), Expression.Field(null, fieldof(Guid.Empty)))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Designer), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_Designer))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Counsellor), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_Counsellor))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Inspector), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_Inspector))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_OwnerCode), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo.get_OwnerCode))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_OwnerLinkMan), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OwnerLinkMan))), 
                    Expression.Bind((MethodInfo) methodof(ProjectInfo.set_OwnerLinkPhone), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OwnerLinkPhone))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_OwnerAddress), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OwnerAddress))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ProjPeopleUserName), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleName))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ProjPeopleCorp), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleDep))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ProjPeopleDuty), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleDuty))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ProjPeopleTel), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleTel))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ForecastProfitRate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ForecastProfitRate))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_EngineeringEstimates), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_EngineeringEstimates))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjDutyPerson), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjDutyPerson))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjApprovalOf), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjApprovalOf))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjFundWorkable), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjFundWorkable))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ManagementMargin), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ManagementMargin))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_MigrantQualityMarginRate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_MigrantQualityMarginRate))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_WithholdingTaxRate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_WithholdingTaxRate))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PerformanceBond), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PerformanceBond))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ElseMargin), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ElseMargin))), 
                    Expression.Bind((MethodInfo) methodof(ProjectInfo.set_IsTender), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_IsTender))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ActualRunDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ActualRunDate))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjManagerRequire), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjManagerRequire))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_TechnicalLeaderRequire), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TechnicalLeaderRequire))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_PrjProperty), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjProperty))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_Province), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_Province))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_City), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_City))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_AfforestArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_AfforestArea))), Expression.Bind((MethodInfo) methodof(ProjectInfo.set_ParkArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ParkArea)))
                 }), new ParameterExpression[] { expression6 })).FirstOrDefault<ProjectInfo>();
            }
        }

        public static IList<string> GetChildPrjByTypeCode(string typeCode)
        {
            IList<string> list = new List<string>();
            using (pm2Entities entities = new pm2Entities())
            {
                return (from m in entities.PT_PrjInfo
                    where (m.TypeCode.Length == 10) && (m.TypeCode.Substring(0, 5) == typeCode)
                    select m.TypeCode).ToList<string>();
            }
        }

        private string GetCorpName(string code)
        {
            string str2;
            pm2Entities entities = new pm2Entities();
            try
            {
                int id = Convert.ToInt32(code);
                str2 = (from m in entities.XPM_Basic_ContactCorp
                    where m.CorpID == id
                    select m.CorpName).FirstOrDefault<string>() ?? string.Empty;
            }
            catch
            {
                str2 = string.Empty;
            }
            finally
            {
                if (entities != null)
                {
                    entities.Dispose();
                }
            }
            return str2;
        }

        public static DataTable GetPrjByCondition(string prjName, string prjCode, string prjManager, string prjPlace, string prjDutyPerson, string startDate, string endDate, string userCode, int pageSize, int pageIndex)
        {
            if (pageSize == 0)
            {
                pageSize = GetPrjCountByCondition(prjName, prjCode, prjManager, prjPlace, prjDutyPerson, startDate, endDate, userCode);
            }
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            List<SqlParameter> list = new List<SqlParameter>();
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.Append("\r\n\t\t\tAND PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName));
            }
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.Append("\r\n\t\t\tAND PrjCode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode));
            }
            if (!string.IsNullOrEmpty(prjManager))
            {
                builder.AppendFormat(" \r\n\t\t\tAND PrjMangerName LIKE '%'+@prjManager+'%' ", new object[0]);
                list.Add(new SqlParameter("@prjManager", prjManager));
            }
            if (!string.IsNullOrEmpty(prjDutyPerson))
            {
                builder.AppendFormat(" \r\n\t\t\tAND prjDutyName LIKE '%'+@prjDutyPerson+'%' ", new object[0]);
                list.Add(new SqlParameter("@prjDutyPerson", prjDutyPerson));
            }
            if (!string.IsNullOrEmpty(prjPlace))
            {
                builder.AppendFormat(" \r\n\t\t\tAND prjPlace LIKE '%'+@prjPlace+'%' ", prjPlace);
                list.Add(new SqlParameter("@prjPlace", prjPlace));
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                builder.Append("\r\n\t\t\tAND FirstContract.SignedTime >= @startDate ");
                list.Add(new SqlParameter("@startDate", startDate));
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                builder.Append("\r\n\t\t\tAND FirstContract.SignedTime <= @endDate ");
                list.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
            }
            DataTable table = new DataTable();
            StringBuilder builder2 = new StringBuilder();
            builder2.AppendLine("WITH IncometCon AS      --收入合同的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(ContractPrice) ContractPrice,Project FROM Con_Incomet_Contract ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ), IncometModify AS   --收入合同变更的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(ChangePrice) ChangePrice,Project FROM Con_Incomet_Modify AS Modify ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Modify.ContractId=Incomet.ContractId ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("), BudRes AS          --目标成本的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT ResTotal,BudVersion.PrjId FROM ( ");
            builder2.AppendLine("SELECT SUM(ResourceQuantity*ResourcePrice) ResTotal,PrjId,Version FROM Bud_TaskResource AS TaskRes INNER JOIN   ");
            builder2.AppendLine("Bud_Task Task ON TaskRes.TaskId=Task.TaskId  GROUP BY PrjId,Version) BudTotalVersion INNER JOIN vGetCurBudVersion BudVersion ");
            builder2.AppendLine("ON BudTotalVersion.PrjId=BudVersion.PrjId AND Version=CurVersion ");
            builder2.AppendLine("),BudIndirect AS      --预算间接成本的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT ProjectId,SUM(AccountAmount) BudIndirectAmount FROM Bud_IndirectBudget WHERE State=2 GROUP BY ProjectId ");
            builder2.AppendLine("), ConsRes AS         --施工报量的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(UnitPrice*ISNULL(Bud_ConsTaskRes.AccountingQuantity,0)) ConsResTotal,PrjId FROM Bud_ConsTaskRes  ");
            builder2.AppendLine("INNER JOIN Bud_ConsTask ON Bud_ConsTaskRes.ConsTaskId=Bud_ConsTask.ConsTaskId ");
            builder2.AppendLine("INNER JOIN Bud_ConsReport ON Bud_ConsTask.ConsReportId=Bud_ConsReport.ConsReportId  ");
            builder2.AppendLine("WHERE IsValid=1 AND FlowState=1 GROUP BY PrjId ");
            builder2.AppendLine("),IndirectDiary AS    --间接成本日记账的金融之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(Amount) IndirectTotal,ProjectId FROM Bud_IndirectDiaryDetails DiaryDetails  ");
            builder2.AppendLine("INNER JOIN Bud_IndirectDiaryCost DiaryCost ON DiaryDetails.InDiaryId=DiaryCost.InDiaryId ");
            builder2.AppendLine("WHERE FlowState=1 GROUP BY ProjectId ");
            builder2.AppendLine("),FirstContractId AS  -- 第一个合同Id ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT MIN(RegisterTime) MinRegisterTime,Project,MAX(ContractId) ContractId FROM Con_Incomet_Contract  ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("),FirstContract AS    --第一个合同 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT IncometContract.* FROM Con_Incomet_Contract IncometContract INNER JOIN FirstContractId  ");
            builder2.AppendLine("ON FirstContractId.ContractId=IncometContract.ContractId ");
            builder2.AppendLine("),PayMode AS          --付款方式列表 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT NoteId,CodeName FROM XPM_Basic_CodeList CodeList INNER JOIN XPM_Basic_CodeType CodeType ");
            builder2.AppendLine("ON CodeList.TypeId=CodeType.TypeId WHERE SignCode='payment' AND CodeList.IsValid=1 ");
            builder2.AppendLine("),IncometBalance AS   --所有结算的汇总 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(ClearingPrice) ClearingPrice,Project FROM Con_Incomet_Balance AS Balance ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Balance.ContractId=Incomet.ContractId ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("), IncometPaymentCurrent AS --本月收入合同收款的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(CllectionPrice) CllectionPrice,Project FROM Con_Incomet_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Payment.ContractId=Incomet.ContractId ");
            builder2.AppendLine("WHERE DATEDIFF(MONTH,CllectionTime,GETDATE())=0 ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" AND FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("),IncometPayment AS        --收入合同收款的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(CllectionPrice) CllectionPrice,Project FROM Con_Incomet_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Payment.ContractId=Incomet.ContractId ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ),PayoutPaymentCurrent AS  --本月支出合同支出的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(PaymentMoney) PaymentMoney,PrjGuid FROM Con_Payout_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Payout_Contract AS Payout ON Payment.ContractId=Payout.ContractId ");
            builder2.AppendLine("WHERE  Payment.FlowState=1 AND Payout.FlowState=1 AND DATEDIFF(MONTH,PaymentDate,GETDATE())=0 ");
            builder2.AppendLine("GROUP BY PrjGuid ");
            builder2.AppendLine("),PayoutPayment AS         --支出合同支出的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(PaymentMoney) PaymentMoney,PrjGuid FROM Con_Payout_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Payout_Contract AS Payout ON Payment.ContractId=Payout.ContractId ");
            builder2.AppendLine("WHERE  Payment.FlowState=1 AND Payout.FlowState=1 ");
            builder2.AppendLine("GROUP BY PrjGuid ");
            builder2.AppendLine("),ctePrj AS          --全部项目的信息 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT vProject.*,FirstContract.SignedTime,FirstContract.StartDate ContractStartDate,FirstContract.EndDate Contractenddate, ");
            builder2.AppendLine("FirstContract.QualityPeriod,PayMode.CodeName FROM vProject LEFT JOIN FirstContract ON vProject.PrjGuid=FirstContract.Project ");
            builder2.AppendLine("LEFT JOIN PayMode ON FirstContract.PayMode=PayMode.NoteId  ");
            builder2.AppendLine("),FilterPrj AS      --通过过滤条件的项目 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT vProject.TypeCode, vProject.PrjGuid, vProject.PrjName FROM vProject LEFT JOIN FirstContract ON vProject.PrjGuid=FirstContract.Project ");
            builder2.AppendLine("LEFT JOIN PayMode ON FirstContract.PayMode=PayMode.NoteId  ");
            builder2.AppendLine("INNER JOIN PT_PrjInfo_ZTB_User ZTBUser ON vProject.PrjGuid=ZTBUser.PrjGuid ");
            builder2.AppendFormat("WHERE ZTBUser.Usercode='{0}' ", userCode).AppendLine();
            builder2.AppendLine(builder.ToString());
            builder2.AppendLine("),mergeParent AS --查询出符合条件的项目及其主项目 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT vProject.TypeCode,vProject.PrjGuid,vProject.PrjName FROM FilterPrj INNER JOIN vProject ON SUBSTRING(FilterPrj.TypeCode, 1, 5)=  ");
            builder2.AppendLine("SUBSTRING(vProject.TypeCode, 1, 5) WHERE len(vProject.TypeCode) = 5 ");
            builder2.AppendLine("UNION ");
            builder2.AppendLine("SELECT * FROM FilterPrj ");
            builder2.AppendLine(") ");
            builder2.AppendFormat("SELECT TOP({0}) Convert(Nvarchar(30),Num) as Num,TypeCode,PrjGuid,PrjName,PrjCode, PrjType,ProjPeopleDep, ", pageSize).AppendLine();
            builder2.AppendLine("PrjDutyName,PrjMangerName,Telephone,CorpName,PrjPlace,PrjFundInfo, ContractPrice,BudTotal, ConsTotal, ");
            builder2.AppendLine("SignedTime,StartDate,EndDate,ActualRunDate,CompletedDate,QualityPeriod, PayMode,Convert(decimal(18,3),ConsResTotal) ConsResTotal,ClearingPrice, ");
            builder2.AppendLine("SurplusClearingPrice,CurrentCllectionPrice,CllectionPrice,CurrentPaymentMoney,PaymentMoney,ManagementMargin, ");
            builder2.AppendLine("MigrantQualityMarginRate,WithholdingTaxRate,PerformanceBond,ElseMargin,UserDefined_Date  FROM ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT Row_Number()OVER(ORDER BY UserDefined_Date DESC,TypeCode) AS Num,TypeCode,PrjGuid,PrjName,PrjCode, ");
            builder2.AppendLine("'' PrjType,ProjPeopleDep,PrjDutyName,PrjMangerName,Telephone,CorpName,PrjPlace,PrjFundInfo, ");
            builder2.AppendLine("(ContractPrice+ChangePrice) ContractPrice,(BudResTotal+BudIndirectAmount) BudTotal, ");
            builder2.AppendLine("(ConsResTotal+IndirectTotal) ConsTotal,SignedTime,StartDate,EndDate,ActualRunDate,CompletedDate,QualityPeriod, ");
            builder2.AppendLine("PayMode,ConsResTotal,ClearingPrice,(ClearingPrice-CllectionPrice) SurplusClearingPrice,CurrentCllectionPrice, ");
            builder2.AppendLine("CllectionPrice,CurrentPaymentMoney,PaymentMoney,ManagementMargin,MigrantQualityMarginRate,WithholdingTaxRate, ");
            builder2.AppendLine("PerformanceBond,ElseMargin,UserDefined_Date  FROM ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT *,CASE Tab.i_ChildNum ");
            builder2.AppendLine("WHEN '0' THEN ( ");
            builder2.AppendLine("CASE LEN(Tab.TypeCode) ");
            builder2.AppendLine("WHEN '5' THEN Tab.InputDate  ");
            builder2.AppendLine("ELSE (SELECT InputDate FROM PT_PrjInfo_ZTB_Detail WHERE PT_PrjInfo_ZTB_Detail.PrjGuid =(SELECT PT1.PrjGuid FROM PT_PrjInfo AS PT1 WHERE PT1.TypeCode = LEFT(Tab.TypeCode,5) AND i_ChildNum > 0 AND IsValid = '1')) ");
            builder2.AppendLine("END ");
            builder2.AppendLine(") ");
            builder2.AppendLine("ELSE Tab.InputDate ");
            builder2.AppendLine("END AS UserDefined_Date  ");
            builder2.AppendLine("FROM  ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT ctePrj.TypeCode,i_ChildNum,ctePrj.PrjGuid,ctePrj.PrjCode,ctePrj.PrjName,PrjPlace,OwnerCode, ");
            builder2.AppendLine("ISNULL(CorpName,'') CorpName,ISNULL(PrjMangerName,'') PrjMangerName,ctePrj.InputDate,ISNULL(ctePrj.telephone,'') Telephone, ");
            builder2.AppendLine("ISNULL(ProjPeopleName,'') ProjPeopleName,ISNULL(Detail.ProjPeopleDep,'') ProjPeopleDep,ISNULL(PrjDutyName,'') PrjDutyName, ");
            builder2.AppendLine("PrjFundInfo,ISNULL(IncometCon.ContractPrice,0) ContractPrice,ISNULL(ChangePrice,0) ChangePrice, ");
            builder2.AppendLine("ISNULL(BudRes.ResTotal,0) BudResTotal,ISNULL(BudIndirect.BudIndirectAmount,0) BudIndirectAmount, ");
            builder2.AppendLine("ISNULL(ConsRes.ConsResTotal,0) ConsResTotal,ISNULL(IndirectDiary.IndirectTotal,0) IndirectTotal,ctePrj.ActualRunDate, ");
            builder2.AppendLine("ctePrj.CompletedDate,SignedTime,StartDate,EndDate,ISNULL(QualityPeriod,'') QualityPeriod,ISNULL(CodeName,'') PayMode, ");
            builder2.AppendLine("ISNULL(IncometBalance.ClearingPrice,0) ClearingPrice,ISNULL(IncometPaymentCurrent.CllectionPrice,0) CurrentCllectionPrice, ");
            builder2.AppendLine("ISNULL(IncometPayment.CllectionPrice,0) CllectionPrice,ISNULL(PayoutPaymentCurrent.PaymentMoney,0) CurrentPaymentMoney, ");
            builder2.AppendLine("ISNULL(PayoutPayment.PaymentMoney,0) PaymentMoney,ISNULL(ManagementMargin,0) ManagementMargin, ");
            builder2.AppendLine("ISNULL(MigrantQualityMarginRate,0) MigrantQualityMarginRate,ISNULL(WithholdingTaxRate,0) WithholdingTaxRate, ");
            builder2.AppendLine("ISNULL(PerformanceBond,0) PerformanceBond,ISNULL(ElseMargin,0) ElseMargin FROM mergeParent INNER JOIN ctePrj  ");
            builder2.AppendLine("ON mergeParent.PrjGuid=ctePrj.PrjGuid  ");
            builder2.AppendLine("LEFT JOIN PT_PrjInfo_ZTB_Detail AS Detail ON ctePrj.PrjGuid=Detail.PrjGuid ");
            builder2.AppendLine("LEFT JOIN XPM_Basic_ContactCorp ON ctePrj.OwnerCode=CorpId  ");
            builder2.AppendLine("LEFT JOIN IncometCon ON ctePrj.PrjGuid=IncometCon.Project  ");
            builder2.AppendLine("LEFT JOIN IncometModify ON ctePrj.PrjGuid=IncometModify.Project  ");
            builder2.AppendLine("LEFT JOIN BudRes ON ctePrj.PrjGuid=BudRes.PrjId  ");
            builder2.AppendLine("LEFT JOIN BudIndirect ON Convert(NVARCHAR(50),ctePrj.PrjGuid)=BudIndirect.ProjectId  ");
            builder2.AppendLine("LEFT JOIN ConsRes ON ctePrj.PrjGuid=ConsRes.PrjId  ");
            builder2.AppendLine("LEFT JOIN IndirectDiary ON ctePrj.PrjGuid=IndirectDiary.ProjectId  ");
            builder2.AppendLine("LEFT JOIN IncometBalance ON ctePrj.PrjGuid=IncometBalance.Project  ");
            builder2.AppendLine("LEFT JOIN IncometPaymentCurrent ON ctePrj.PrjGuid=IncometPaymentCurrent.Project  ");
            builder2.AppendLine("LEFT JOIN IncometPayment ON ctePrj.PrjGuid=IncometPayment.Project  ");
            builder2.AppendLine("LEFT JOIN PayoutPaymentCurrent ON ctePrj.PrjGuid=PayoutPaymentCurrent.PrjGuid  ");
            builder2.AppendLine("LEFT JOIN PayoutPayment ON ctePrj.PrjGuid=PayoutPayment.PrjGuid  WHERE Detail.SetUpFlowState=1");
            builder2.AppendFormat(") Tab ) Tab1 ) Tab2 WHERE Num> {0}*({1}-1) ", pageSize, pageIndex).AppendLine();
            return SqlHelper.ExecuteQuery(CommandType.Text, builder2.ToString(), list.ToArray());
        }

        public static int GetPrjCountByCondition(string prjName, string prjCode, string prjManager, string prjPlace, string prjDutyPerson, string startDate, string endDate, string userCode)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.Append("\r\n\t\t\tAND PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName));
            }
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.Append("\r\n\t\t\tAND PrjCode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode));
            }
            if (!string.IsNullOrEmpty(prjManager))
            {
                builder.AppendFormat(" \r\n\t\t\tAND PrjMangerName LIKE '%'+@prjManager+'%' ", new object[0]);
                list.Add(new SqlParameter("@prjManager", prjManager));
            }
            if (!string.IsNullOrEmpty(prjDutyPerson))
            {
                builder.AppendFormat(" \r\n\t\t\tAND prjDutyName LIKE '%'+@prjDutyPerson+'%' ", new object[0]);
                list.Add(new SqlParameter("@prjDutyPerson", prjDutyPerson));
            }
            if (!string.IsNullOrEmpty(prjPlace))
            {
                builder.AppendFormat(" \r\n\t\t\tAND prjPlace LIKE '%'+@prjPlace+'%' ", prjPlace);
                list.Add(new SqlParameter("@prjPlace", prjPlace));
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                builder.Append("\r\n\t\t\tAND FirstContract.SignedTime >= @startDate ");
                list.Add(new SqlParameter("@startDate", startDate));
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                builder.Append("\r\n\t\t\tAND FirstContract.SignedTime <= @endDate ");
                list.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
            }
            StringBuilder builder2 = new StringBuilder();
            builder2.AppendLine("WITH IncometCon AS      --收入合同的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(ContractPrice) ContractPrice,Project FROM Con_Incomet_Contract ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine(" GROUP BY Project ), IncometModify AS   --收入合同变更的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(ChangePrice) ChangePrice,Project FROM Con_Incomet_Modify AS Modify ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Modify.ContractId=Incomet.ContractId ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("), BudRes AS          --目标成本的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(ResourceQuantity*ResourcePrice) ResTotal,PrjId FROM Bud_TaskResource AS TaskRes INNER JOIN  ");
            builder2.AppendLine("Bud_Task Task ON TaskRes.TaskId=Task.TaskId  GROUP BY PrjId ");
            builder2.AppendLine("),BudIndirect AS      --预算间接成本的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT ProjectId,SUM(AccountAmount) BudIndirectAmount FROM Bud_IndirectBudget WHERE State=2 GROUP BY ProjectId ");
            builder2.AppendLine("), ConsRes AS         --施工报量的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(UnitPrice*ISNULL(Bud_ConsTaskRes.AccountingQuantity,0)) ConsResTotal,PrjId FROM Bud_ConsTaskRes  ");
            builder2.AppendLine("INNER JOIN Bud_ConsTask ON Bud_ConsTaskRes.ConsTaskId=Bud_ConsTask.ConsTaskId ");
            builder2.AppendLine("INNER JOIN Bud_ConsReport ON Bud_ConsTask.ConsReportId=Bud_ConsReport.ConsReportId  ");
            builder2.AppendLine("WHERE IsValid=1 AND FlowState=1 GROUP BY PrjId ");
            builder2.AppendLine("),IndirectDiary AS    --间接成本日记账的金融之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(Amount) IndirectTotal,ProjectId FROM Bud_IndirectDiaryDetails DiaryDetails  ");
            builder2.AppendLine("INNER JOIN Bud_IndirectDiaryCost DiaryCost ON DiaryDetails.InDiaryId=DiaryCost.InDiaryId ");
            builder2.AppendLine("WHERE FlowState=1 GROUP BY ProjectId ");
            builder2.AppendLine("),FirstContractId AS  -- 第一个合同Id ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT MIN(RegisterTime) MinRegisterTime,Project,MAX(ContractId) ContractId FROM Con_Incomet_Contract  ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("),FirstContract AS    --第一个合同 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT IncometContract.* FROM Con_Incomet_Contract IncometContract INNER JOIN FirstContractId  ");
            builder2.AppendLine("ON FirstContractId.ContractId=IncometContract.ContractId ");
            builder2.AppendLine("),PayMode AS          --付款方式列表 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT NoteId,CodeName FROM XPM_Basic_CodeList CodeList INNER JOIN XPM_Basic_CodeType CodeType ");
            builder2.AppendLine("ON CodeList.TypeId=CodeType.TypeId WHERE SignCode='payment' AND CodeList.IsValid=1 ");
            builder2.AppendLine("),IncometBalance AS   --所有结算的汇总 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(ClearingPrice) ClearingPrice,Project FROM Con_Incomet_Balance AS Balance ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Balance.ContractId=Incomet.ContractId ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("), IncometPaymentCurrent AS --本月收入合同收款的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(CllectionPrice) CllectionPrice,Project FROM Con_Incomet_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Payment.ContractId=Incomet.ContractId ");
            builder2.AppendLine("WHERE DATEDIFF(MONTH,CllectionTime,GETDATE())=0 ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" AND FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project ");
            builder2.AppendLine("),IncometPayment AS        --收入合同收款的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(CllectionPrice) CllectionPrice,Project FROM Con_Incomet_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Incomet_Contract AS Incomet ON Payment.ContractId=Incomet.ContractId ");
            if (IsIncomeContractApprove == "1")
            {
                builder2.AppendLine(" WHERE FlowState=1 ");
            }
            builder2.AppendLine("GROUP BY Project),PayoutPaymentCurrent AS  --本月支出合同支出的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(PaymentMoney) PaymentMoney,PrjGuid FROM Con_Payout_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Payout_Contract AS Payout ON Payment.ContractId=Payout.ContractId ");
            builder2.AppendLine("WHERE  Payment.FlowState=1 AND Payout.FlowState=1 ");
            builder2.AppendLine("GROUP BY PrjGuid ");
            builder2.AppendLine("),PayoutPayment AS         --支出合同支出的金额之和 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT SUM(PaymentMoney) PaymentMoney,PrjGuid FROM Con_Payout_Payment AS Payment ");
            builder2.AppendLine("INNER JOIN Con_Payout_Contract AS Payout ON Payment.ContractId=Payout.ContractId ");
            builder2.AppendLine("WHERE  Payment.FlowState=1 AND Payout.FlowState=1 AND DATEDIFF(DAY,PaymentDate,GETDATE())>=0 ");
            builder2.AppendLine("GROUP BY PrjGuid ");
            builder2.AppendLine("),ctePrj AS          --全部项目的信息 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT vProject.*,FirstContract.SignedTime,FirstContract.StartDate ContractStartDate,FirstContract.EndDate Contractenddate, ");
            builder2.AppendLine("FirstContract.QualityPeriod,PayMode.CodeName FROM vProject LEFT JOIN FirstContract ON vProject.PrjGuid=FirstContract.Project ");
            builder2.AppendLine("LEFT JOIN PayMode ON FirstContract.PayMode=PayMode.NoteId  ");
            builder2.AppendLine("),FilterPrj AS      --通过过滤条件的项目 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT vProject.TypeCode, vProject.PrjGuid, vProject.PrjName FROM vProject LEFT JOIN FirstContract ON vProject.PrjGuid=FirstContract.Project ");
            builder2.AppendLine("LEFT JOIN PayMode ON FirstContract.PayMode=PayMode.NoteId  ");
            builder2.AppendLine("INNER JOIN PT_PrjInfo_ZTB_User ZTBUser ON vProject.PrjGuid=ZTBUser.PrjGuid ");
            builder2.AppendFormat("WHERE ZTBUser.Usercode='{0}' ", userCode).AppendLine();
            builder2.AppendLine(builder.ToString());
            builder2.AppendLine("),mergeParent AS --查询出符合条件的项目及其主项目 ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT vProject.TypeCode,vProject.PrjGuid,vProject.PrjName FROM FilterPrj INNER JOIN vProject ON SUBSTRING(FilterPrj.TypeCode, 1, 5)=  ");
            builder2.AppendLine("SUBSTRING(vProject.TypeCode, 1, 5) WHERE len(vProject.TypeCode) = 5 ");
            builder2.AppendLine("UNION ");
            builder2.AppendLine("SELECT * FROM FilterPrj ");
            builder2.AppendLine(") ");
            builder2.AppendLine("SELECT COUNT(*) FROM ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT *,CASE Tab.i_ChildNum ");
            builder2.AppendLine("WHEN '0' THEN ( ");
            builder2.AppendLine("CASE LEN(Tab.TypeCode) ");
            builder2.AppendLine("WHEN '5' THEN Tab.InputDate  ");
            builder2.AppendLine("ELSE (SELECT InputDate FROM PT_PrjInfo_ZTB_Detail WHERE PT_PrjInfo_ZTB_Detail.PrjGuid =(SELECT PT1.PrjGuid FROM PT_PrjInfo AS PT1 WHERE PT1.TypeCode = LEFT(Tab.TypeCode,5) AND i_ChildNum > 0 AND IsValid = '1')) ");
            builder2.AppendLine("END ");
            builder2.AppendLine(") ");
            builder2.AppendLine("ELSE Tab.InputDate ");
            builder2.AppendLine("END AS UserDefined_Date  ");
            builder2.AppendLine("FROM  ");
            builder2.AppendLine("( ");
            builder2.AppendLine("SELECT ctePrj.TypeCode,i_ChildNum,ctePrj.PrjGuid,ctePrj.PrjCode,ctePrj.PrjName,PrjPlace,OwnerCode, ");
            builder2.AppendLine("ISNULL(CorpName,'') CorpName,ISNULL(PrjMangerName,'') PrjMangerName,ctePrj.InputDate,ISNULL(ctePrj.telephone,'') Telephone, ");
            builder2.AppendLine("ISNULL(ProjPeopleName,'') ProjPeopleName,ISNULL(Detail.ProjPeopleDep,'') ProjPeopleDep,ISNULL(PrjDutyName,'') PrjDutyName, ");
            builder2.AppendLine("PrjFundInfo,ISNULL(IncometCon.ContractPrice,0) ContractPrice,ISNULL(ChangePrice,0) ChangePrice, ");
            builder2.AppendLine("ISNULL(BudRes.ResTotal,0) BudResTotal,ISNULL(BudIndirect.BudIndirectAmount,0) BudIndirectAmount, ");
            builder2.AppendLine("ISNULL(ConsRes.ConsResTotal,0) ConsResTotal,ISNULL(IndirectDiary.IndirectTotal,0) IndirectTotal,ctePrj.ActualRunDate, ");
            builder2.AppendLine("ctePrj.CompletedDate,SignedTime,StartDate,EndDate,ISNULL(QualityPeriod,'') QualityPeriod,ISNULL(CodeName,'') PayMode, ");
            builder2.AppendLine("ISNULL(IncometBalance.ClearingPrice,0) ClearingPrice,ISNULL(IncometPaymentCurrent.CllectionPrice,0) CurrentCllectionPrice, ");
            builder2.AppendLine("ISNULL(IncometPayment.CllectionPrice,0) CllectionPrice,ISNULL(PayoutPaymentCurrent.PaymentMoney,0) CurrentPaymentMoney, ");
            builder2.AppendLine("ISNULL(PayoutPayment.PaymentMoney,0) PaymentMoney,ISNULL(ManagementMargin,0) ManagementMargin, ");
            builder2.AppendLine("ISNULL(MigrantQualityMarginRate,0) MigrantQualityMarginRate,ISNULL(WithholdingTaxRate,0) WithholdingTaxRate, ");
            builder2.AppendLine("ISNULL(PerformanceBond,0) PerformanceBond,ISNULL(ElseMargin,0) ElseMargin FROM mergeParent INNER JOIN ctePrj  ");
            builder2.AppendLine("ON mergeParent.PrjGuid=ctePrj.PrjGuid  ");
            builder2.AppendLine("LEFT JOIN PT_PrjInfo_ZTB_Detail AS Detail ON ctePrj.PrjGuid=Detail.PrjGuid ");
            builder2.AppendLine("LEFT JOIN XPM_Basic_ContactCorp ON ctePrj.OwnerCode=CorpId  ");
            builder2.AppendLine("LEFT JOIN IncometCon ON ctePrj.PrjGuid=IncometCon.Project  ");
            builder2.AppendLine("LEFT JOIN IncometModify ON ctePrj.PrjGuid=IncometModify.Project  ");
            builder2.AppendLine("LEFT JOIN BudRes ON ctePrj.PrjGuid=BudRes.PrjId  ");
            builder2.AppendLine("LEFT JOIN BudIndirect ON Convert(NVARCHAR(50),ctePrj.PrjGuid)=BudIndirect.ProjectId  ");
            builder2.AppendLine("LEFT JOIN ConsRes ON ctePrj.PrjGuid=ConsRes.PrjId  ");
            builder2.AppendLine("LEFT JOIN IndirectDiary ON ctePrj.PrjGuid=IndirectDiary.ProjectId  ");
            builder2.AppendLine("LEFT JOIN IncometBalance ON ctePrj.PrjGuid=IncometBalance.Project  ");
            builder2.AppendLine("LEFT JOIN IncometPaymentCurrent ON ctePrj.PrjGuid=IncometPaymentCurrent.Project  ");
            builder2.AppendLine("LEFT JOIN IncometPayment ON ctePrj.PrjGuid=IncometPayment.Project  ");
            builder2.AppendLine("LEFT JOIN PayoutPaymentCurrent ON ctePrj.PrjGuid=PayoutPaymentCurrent.PrjGuid  ");
            builder2.AppendLine("LEFT JOIN PayoutPayment ON ctePrj.PrjGuid=PayoutPayment.PrjGuid  WHERE Detail.SetUpFlowState=1");
            builder2.AppendLine(") Tab ) Tab1 ");
            return DBHelper.GetInt(SqlHelper.ExecuteScalar(CommandType.Text, builder2.ToString(), list.ToArray()));
        }

        public static DataTable GetPrjPrivilege(string prjCode, string prjName, string startDate, string endDate, string prjManager, string prjState, string userCode, int pageNo, int pageSize, string IsTender, string prjProperty, string setUpDep, string kind, ref int refRowCount)
        {
            DataTable table = new DataTable();
            string str = "TypeCode,Primit,i_ChildNum,PrjGuid,PrjCode,PrjName,InputDate,StartDate,EndDate,PrjMangerName,PrjStateName,IsTender,PrjPropertyName,ProjPeopleDep";
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter item = new SqlParameter("@rowCount", SqlDbType.Int) {
                Direction = ParameterDirection.Output
            };
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.AppendFormat(" AND PrjCode like  '%{0}%' ", prjCode);
            }
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.AppendFormat(" AND PrjName like  '%{0}%' ", prjName);
            }
            if (!string.IsNullOrEmpty(prjManager))
            {
                builder.AppendFormat(" AND PrjMangerName like  '%{0}%' ", prjManager);
            }
            if (!string.IsNullOrEmpty(prjState))
            {
                builder.AppendFormat(" AND PrjState={0}", prjState);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                builder.AppendFormat(" AND InputDate >= '{0}' ", startDate);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                builder.AppendFormat(" AND InputDate <= '{0}' ", endDate + " 23:59:59");
            }
            if (!string.IsNullOrEmpty(prjProperty))
            {
                builder.AppendFormat(" AND PrjProperty = '{0}' ", prjProperty);
            }
            if (!string.IsNullOrWhiteSpace(setUpDep))
            {
                builder.AppendFormat(" AND ProjPeopleDep LIKE '%{0}%' \n ", setUpDep);
            }
            if (!string.IsNullOrWhiteSpace(kind))
            {
                builder.AppendFormat("  AND P.PrjGuid IN (SELECT PrjGuid FROM PT_PrjInfo_Kind WHERE PrjGuid = P.PrjGuid AND PrjKind = '{0}') \n", kind);
            }
            list.Add(new SqlParameter("@userCode", userCode));
            list.Add(new SqlParameter("@isTender", IsTender));
            list.Add(new SqlParameter("@columns", str));
            list.Add(new SqlParameter("@condition", builder.ToString()));
            list.Add(new SqlParameter("@pageIndex", pageNo));
            list.Add(new SqlParameter("@pageSize", pageSize));
            list.Add(item);
            table = SqlHelper.ExecuteQuery(CommandType.StoredProcedure, "uspGetProject", list.ToArray());
            refRowCount = Convert.ToInt32(item.Value);
            return table;
        }

        public static DataTable GetProjectDate(string prjId)
        {
            DataTable table = new DataTable();
            string cmdText = "SELECT StartDate,EndDate FROM PT_PrjInfo WHERE PrjGuid=@PrjId";
            SqlParameter parameter = new SqlParameter("@PrjId", prjId);
            return SqlHelper.ExecuteQuery(CommandType.Text, cmdText, new SqlParameter[] { parameter });
        }

        public static DataTable GetProjectInfo(string userCode)
        {
            string cmdText = "\r\n\t\t\t\t--DECLARE @UserCode nvarchar(8)\r\n\t\t\t\t--SET @UserCode = '00000000';\r\n\t\t\t\tWITH cte_PrjInfo AS\r\n\t\t\t\t(\r\n\t\t\t\t\tSELECT prjInfo.PrjGuid,PrjCode,PrjName,ISNULL(City,'') City,PrjPlace,ISNULL(itemName,'') PrjState \r\n\t\t\t\t\tFROM PT_PrjInfo AS prjInfo\r\n\t\t\t\t\tINNER JOIN PT_PrjInfo_ZTB_User AS prjUser ON prjInfo.PrjGuid=prjUser.PrjGuid\r\n\t\t\t\t\tLEFT JOIN (\r\n\t\t\t\t\t\tSELECT ItemCode,ItemName FROM Basic_CodeList WHERE TypeCode='ProjectState') stateList\r\n\t\t\t\t\t\tON prjInfo.PrjState=stateList.ItemCode\r\n\t\t\t\t\tLEFT JOIN PT_PrjInfo_ZTB_Detail AS detail ON prjInfo.PrjGuid=detail.PrjGuid\r\n\t\t\t\t\tWHERE IsValid=1 AND prjUser.UserCode=@UserCode\r\n\t\t\t\t)\r\n\t\t\t\tSELECT * FROM cte_PrjInfo\r\n\t\t\t\tORDER BY PrjCode\r\n\t\t\t";
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserCode", userCode) };
            return SqlHelper.ExecuteQuery(CommandType.Text, cmdText, commandParameters);
        }

        public static string GetProjectName(string prjId)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Guid guid = new Guid(prjId);
                return (from m in entities.PT_PrjInfo
                    where m.PrjGuid == guid
                    select m.PrjName).FirstOrDefault<string>();
            }
        }

        public int GetStartWorkPrjCount(string prjName, string prjCode, DateTime? start, DateTime? end, string flowState, int? prjState, string userCode, string prjManagerName)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.AppendFormat(" AND PrjCode LIKE '%'+@prjCode+'%' ", new object[0]);
                list.Add(new SqlParameter("@prjCode", prjCode));
            }
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.AppendFormat(" AND PrjName LIKE '%' + @prjName + '%' ", new object[0]);
                list.Add(new SqlParameter("@prjName", prjName));
            }
            if (!string.IsNullOrEmpty(prjManagerName))
            {
                builder.AppendFormat(" AND PrjManager LIKE '%' + @prjManagerName + '%' ", new object[0]);
                list.Add(new SqlParameter("@prjManagerName", prjManagerName));
            }
            if (prjState.HasValue)
            {
                builder.AppendFormat(" AND PrjState= @prjState ", new object[0]);
                list.Add(new SqlParameter("@prjState", prjState));
            }
            if (start.HasValue)
            {
                builder.AppendFormat(" AND P.InputDate >= @start ", new object[0]);
                list.Add(new SqlParameter("@start", Common2.GetTime(start)));
            }
            if (end.HasValue)
            {
                builder.AppendFormat(" AND P.InputDate < @end ", new object[0]);
                list.Add(new SqlParameter("@end", Common2.GetTime(end)));
            }
            if (flowState != null)
            {
                if (!string.IsNullOrEmpty(flowState))
                {
                    builder.AppendFormat(" AND FlowState= @flowState  ", new object[0]);
                    list.Add(new SqlParameter("@flowState", flowState));
                }
                else
                {
                    builder.AppendFormat(" AND FlowState IS NULL ", new object[0]);
                }
            }
            list.Add(new SqlParameter("@userCode", userCode));
            string cmdText = " \r\n                --declare @UserCode nvarchar(500);\r\n                --declare @prjCode nvarchar(500),@prjName nvarchar(500), @start Datetime,@end Datetime;\r\n                --declare @flowState nvarchar(60),@prjState int,@prjManagerName;\r\n                --set @UserCode='00000000';\r\n                --set @prjCode='';\r\n                --set @prjName='';\r\n                --set @start='';\r\n                --set @end='';\r\n                --set @flowState='';\r\n                --set @prjState=;\r\n                --set @prjManagerName='';\r\n                WITH Project AS\r\n                (\r\n\t                SELECT P.PrjGuid, P.TypeCode\r\n\t                FROM vProject AS P\r\n                    LEFT JOIN PT_StartReport StartReport ON P.PrjGuid=StartReport.PrjGuid\r\n\t                WHERE P.PrjGuid IN (SELECT DISTINCT PrjGuid FROM PT_PrjInfo_ZTB_User WHERE UserCode = @UserCode) \r\n\t                AND SetUpFlowState=1 AND (PrjState=7 OR PrjState=17 OR prjState=5) ";
            cmdText = cmdText + builder.ToString() + "\r\n                )\r\n                ,DirectProject AS\r\n                (\r\n\t                SELECT Primit,TypeCode,PrjGuid,PrjCode,PrjName,PrjManager AS Person,PrjState,\r\n\t                CASE LEN(TypeCode) \r\n\t                WHEN 10 THEN (\r\n\t                SELECT InputDate FROM vProject AS V1 WHERE V1.TypeCode = SUBSTRING(D.TypeCode, 1, 5)\r\n\t                )\r\n\t                WHEN 5 THEN InputDate\r\n\t                END AS InputDate\r\n\t                FROM (\r\n\t                SELECT C.Primit, vProject.* \r\n\t                FROM (\r\n\t                SELECT pro.*, 1 AS Primit \r\n\t                FROM (SELECT * FROM Project) AS pro\r\n\t                UNION\r\n\t                SELECT P.PrjGuid, P.TypeCode, \r\n\t                (SELECT COUNT(*) FROM \r\n\t                --不符合条件的PrjGuid\r\n\t                (SELECT prjGuid FROM vProject WHERE prjGuid IN\r\n\t                (SELECT DISTINCT PrjGuid FROM PT_PrjInfo_ZTB_User WHERE UserCode = @UserCode)\r\n\t                AND SetUpFlowState=1 ) \r\n\t                 AS PP WHERE PP.PrjGuid = P.PrjGuid) AS Primit\r\n\t                FROM PT_PrjInfo AS P\r\n\t                WHERE P.TypeCode IN (\r\n\t                SELECT DISTINCT LEFT(TypeCode, 5) ParentTypeCode\r\n\t                FROM (SELECT * FROM Project) AS pro\r\n\t                WHERE LEN(pro.TypeCode) = 10\r\n\t                )\r\n\t                ) AS C\r\n\t                INNER JOIN vProject ON vProject.PrjGuid = C.PrjGuid ) AS D \r\n                )\r\n\r\n                SELECT COUNT(*)\r\n                FROM(\r\n                SELECT * FROM DirectProject\r\n                ) AS NewProjectList ";
            return DBHelper.GetInt(SqlHelper.ExecuteScalar(CommandType.Text, cmdText, list.ToArray()));
        }

        public DataTable GetStartWorkPrjInfos(string prjName, string prjCode, DateTime? start, DateTime? end, string flowState, int? prjState, string userCode, string prjManagerName, int pageSize, int pageIndex)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.AppendFormat(" AND PrjCode LIKE '%'+@prjCode+'%' ", new object[0]);
                list.Add(new SqlParameter("@prjCode", prjCode));
            }
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.AppendFormat(" AND PrjName LIKE '%' + @prjName + '%' ", new object[0]);
                list.Add(new SqlParameter("@prjName", prjName));
            }
            if (!string.IsNullOrEmpty(prjManagerName))
            {
                builder.AppendFormat(" AND PrjManager LIKE '%' + @prjManagerName + '%' ", new object[0]);
                list.Add(new SqlParameter("@prjManagerName", prjManagerName));
            }
            if (prjState.HasValue)
            {
                builder.AppendFormat(" AND PrjState= @prjState ", new object[0]);
                list.Add(new SqlParameter("@prjState", prjState));
            }
            if (start.HasValue)
            {
                builder.AppendFormat(" AND P.InputDate >= @start ", new object[0]);
                list.Add(new SqlParameter("@start", Common2.GetTime(start)));
            }
            if (end.HasValue)
            {
                builder.AppendFormat(" AND P.InputDate < @end ", new object[0]);
                list.Add(new SqlParameter("@end", Common2.GetTime(end)));
            }
            if (flowState != null)
            {
                if (!string.IsNullOrEmpty(flowState))
                {
                    builder.AppendFormat(" AND FlowState= @flowState  ", new object[0]);
                    list.Add(new SqlParameter("@flowState", flowState));
                }
                else
                {
                    builder.AppendFormat(" AND FlowState IS NULL ", new object[0]);
                }
            }
            list.Add(new SqlParameter("@userCode", userCode));
            list.Add(new SqlParameter("@pageIndex", pageIndex));
            list.Add(new SqlParameter("@pageSize", pageSize));
            string cmdText = " \r\n                --declare @UserCode nvarchar(500),@pageSize int, @pageIndex int;\r\n                --declare @prjCode nvarchar(500),@prjName nvarchar(500), @start Datetime,@end Datetime;\r\n                --declare @flowState nvarchar(60),@prjState int,@prjManagerName;\r\n                --set @UserCode='00000000';\r\n                --set @pageSize=1000;\r\n                --set @pageIndex=1;\r\n                --set @prjCode='';\r\n                --set @prjName='';\r\n                --set @start='';\r\n                --set @end='';\r\n                --set @flowState='';\r\n                --set @prjState='';\r\n                --set @prjManagerName='';\r\n                WITH Project AS\r\n                (\r\n\t                SELECT P.PrjGuid, P.TypeCode\r\n\t                FROM vProject AS P\r\n                    LEFT JOIN PT_StartReport StartReport ON P.PrjGuid=StartReport.PrjGuid\r\n\t                WHERE P.PrjGuid IN (SELECT DISTINCT PrjGuid FROM PT_PrjInfo_ZTB_User WHERE UserCode = @UserCode) \r\n\t                AND SetUpFlowState=1 AND (PrjState=7 OR PrjState=17 OR prjState=5) ";
            cmdText = cmdText + builder.ToString() + "\r\n                )\r\n                ,DirectProject AS\r\n                (\r\n\t                SELECT Primit,TypeCode,PrjGuid,PrjCode,PrjName,PrjManager AS Person,PrjState,\r\n\t                CASE LEN(TypeCode) \r\n\t                WHEN 10 THEN (\r\n\t                SELECT InputDate FROM vProject AS V1 WHERE V1.TypeCode = SUBSTRING(D.TypeCode, 1, 5)\r\n\t                )\r\n\t                WHEN 5 THEN InputDate\r\n\t                END AS InputDate\r\n\t                FROM (\r\n\t                SELECT C.Primit, vProject.* \r\n\t                FROM (\r\n\t                SELECT pro.*, 1 AS Primit \r\n\t                FROM (SELECT * FROM Project) AS pro\r\n\t                UNION\r\n\t                SELECT P.PrjGuid, P.TypeCode, \r\n\t                (SELECT COUNT(*) FROM \r\n\t                --不符合条件的PrjGuid\r\n\t                (SELECT prjGuid FROM vProject WHERE prjGuid IN\r\n\t                (SELECT DISTINCT PrjGuid FROM PT_PrjInfo_ZTB_User WHERE UserCode = @UserCode)\r\n\t                AND SetUpFlowState=1 ) \r\n\t                 AS PP WHERE PP.PrjGuid = P.PrjGuid) AS Primit\r\n\t                FROM PT_PrjInfo AS P\r\n\t                WHERE P.TypeCode IN (\r\n\t                SELECT DISTINCT LEFT(TypeCode, 5) ParentTypeCode\r\n\t                FROM (SELECT * FROM Project) AS pro\r\n\t                WHERE LEN(pro.TypeCode) = 10\r\n\t                )\r\n\t                ) AS C\r\n\t                INNER JOIN vProject ON vProject.PrjGuid = C.PrjGuid ) AS D \r\n                )\r\n\r\n                SELECT TOP (@pageSize) * FROM \r\n                (\r\n                SELECT ROW_NUMBER() OVER(ORDER BY NewProjectList.InputDate DESC, NewProjectList.TypeCode ASC) AS No,NewProjectList.*,\r\n                ProjectState.ItemName,ISNULL(ReportId,'') ReportId,SP.FlowState\r\n                FROM(\r\n                SELECT * FROM DirectProject\r\n                ) AS NewProjectList \r\n                LEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS ProjectState \r\n                ON NewProjectList.PrjState=ProjectState.ItemCode \r\n                LEFT JOIN PT_StartReport SP ON NewProjectList.PrjGuid=SP.PrjGuid\r\n                ) AS AllProjectInfo WHERE [No]>@pageSize*(@pageIndex-1) ";
            return SqlHelper.ExecuteQuery(CommandType.Text, cmdText, list.ToArray());
        }

        public static DataTable GetTenderPrjReport(string prjCode, string prjName, string prjManager, string prjKindClass, string startDate, string endDate, string owner, string prjState, string userCode, int pageNo, int pageSize, string IsTender, ref int refRowCount)
        {
            DataTable table = new DataTable();
            string str = "TypeCode,Primit,i_ChildNum,PrjGuid,PrjCode,PrjName,InputDate,StartDate,EndDate,PrjCost,Duration,Owner,PrjMangerName,PrjStateName,PrjKindName,IsTender\r\n,CASE IsTender \r\n\tWHEN 1 THEN 1\r\n\tELSE SetUpFlowState\r\nEND AS SetUpFlowState";
            SqlParameter item = new SqlParameter("@rowCount", SqlDbType.Int) {
                Direction = ParameterDirection.Output
            };
            List<SqlParameter> list = new List<SqlParameter>();
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.AppendFormat(" AND PrjCode like  '%{0}%' ", prjCode);
            }
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.AppendFormat(" AND PrjName like  '%{0}%' ", prjName);
            }
            if (!string.IsNullOrEmpty(prjManager))
            {
                builder.AppendFormat(" AND PrjMangerName like  '%{0}%' ", prjManager);
            }
            if (!string.IsNullOrEmpty(prjKindClass))
            {
                builder.AppendFormat(" AND  PrjKindClass='{0}'", prjKindClass);
            }
            if (!string.IsNullOrEmpty(owner))
            {
                builder.AppendFormat(" AND Owner like  '%{0}%' ", owner);
            }
            if (!string.IsNullOrEmpty(prjState))
            {
                builder.AppendFormat(" AND PrjState={0}", prjState);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                builder.AppendFormat(" AND InputDate >= '{0}' ", startDate);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                builder.AppendFormat(" AND InputDate <= '{0}' ", endDate + " 23:59:59");
            }
            list.Add(new SqlParameter("@userCode", userCode));
            list.Add(new SqlParameter("@isTender", IsTender));
            list.Add(new SqlParameter("@columns", str));
            list.Add(new SqlParameter("@condition", builder.ToString()));
            list.Add(new SqlParameter("@pageIndex", pageNo));
            list.Add(new SqlParameter("@pageSize", pageSize));
            list.Add(item);
            table = SqlHelper.ExecuteQuery(CommandType.StoredProcedure, "uspGetProject", list.ToArray());
            refRowCount = Convert.ToInt32(item.Value);
            return table;
        }

        public static string GetTypeCode(string prjGuid)
        {
            string str = "00001";
            using (pm2Entities entities = new pm2Entities())
            {
                if (string.IsNullOrEmpty(prjGuid))
                {
                    string str2 = (from m in entities.PT_PrjInfo
                        where m.TypeCode.Length == 5
                        orderby m.TypeCode descending
                        select m.TypeCode).FirstOrDefault<string>();
                    if (!string.IsNullOrEmpty(str2))
                    {
                        int num = Convert.ToInt32(str2) + 1;
                        str = num.ToString().PadLeft(5, '0');
                    }
                    return str;
                }
                Guid guid = new Guid(prjGuid);
                string parentCode = (from n in entities.PT_PrjInfo
                    where n.PrjGuid == guid
                    select n.TypeCode).FirstOrDefault<string>();
                string str3 = (from m in entities.PT_PrjInfo
                    where m.TypeCode.StartsWith(parentCode) && ((m.TypeCode.Length - 5) == parentCode.Length)
                    orderby m.TypeCode descending
                    select m.TypeCode).FirstOrDefault<string>();
                if (string.IsNullOrEmpty(str3))
                {
                    return (parentCode + str);
                }
                int num2 = Convert.ToInt32(str3.Substring(str3.Length - 5)) + 1;
                return (parentCode + num2.ToString().PadLeft(5, '0'));
            }
        }

        public string GetUserName(string userCode)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                return ((from m in entities.PT_yhmc
                    where m.v_yhdm == userCode
                    select m.v_xm).FirstOrDefault<string>() ?? string.Empty);
            }
        }

        public static bool IsSameCode(string prjCode)
        {
            int num = 0;
            using (pm2Entities entities = new pm2Entities())
            {
                num = (from m in entities.PT_PrjInfo
                    where m.PrjCode == prjCode
                    select m).Count<PT_PrjInfo>();
            }
            return (num > 0);
        }

        public void Update(ProjectInfo model, string prjGuid)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Guid guid = new Guid(prjGuid);
                PT_PrjInfo info = (from m in entities.PT_PrjInfo
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo>();
                if (info != null)
                {
                    info.PrjCode = model.PrjCode;
                    info.PrjName = model.PrjName;
                    info.StartDate = model.StartDate;
                    info.EndDate = model.EndDate;
                    info.PrjCost = model.PrjCost;
                    info.Duration = model.Duration;
                    info.QualityClass = model.QualityClass;
                    info.Area = model.Area;
                    info.PrjPlace = model.PrjPlace;
                    info.Remark1 = model.Remark;
                    info.Counsellor = model.Counsellor;
                    info.Designer = model.Designer;
                    info.Inspector = model.Inspector;
                    info.PrjInfo = model.PrjInfo;
                    info.PrjState = model.PrjState;
                    info.OwnerCode = model.OwnerCode;
                    info.BudgetWay = model.BudgetWay;
                    info.ContractWay = model.ContractWay;
                    info.PayCondition = model.PayCondition;
                    info.TenderWay = model.TenderWay;
                    info.PayWay = model.PayWay;
                    info.KeyPart = model.KeyPart;
                    info.WorkUnit = model.WorkUnit;
                    info.LinkMan = model.LinkMan;
                    info.PrjManager = model.PrjManager;
                    info.BuildingType = model.BuildingType;
                    info.TotalHouseNum = model.TotalHouseNum;
                    info.BuildingArea = model.BuildingArea;
                    info.UsegrounArea = model.UsegrounArea;
                    info.UndergroundArea = model.UndergroundArea;
                    info.PrjFundInfo = model.PrjFundInfo;
                    info.OtherStatement = model.OtherStatement;
                    info.xmgroup = model.Xmgroup;
                    info.grade = model.PrjGrade;
                    this.UpdateUserPrimit(info.businessman, model.Businessman, guid);
                    info.businessman = model.Businessman;
                    PT_PrjInfo_ZTB_Detail detail = (from n in entities.PT_PrjInfo_ZTB_Detail
                        where n.PrjGuid == guid
                        select n).FirstOrDefault<PT_PrjInfo_ZTB_Detail>();
                    this.UpdateUserPrimit(detail.ProgAgent, model.ProgAgent, guid);
                    detail.ProgAgent = model.ProgAgent;
                    detail.EngineeringType = model.EngineeringType;
                    detail.EngineeringSubType = model.EngineeringSubType;
                    detail.Grade = model.Grade;
                    detail.ProjPeopleName = model.ProjPeopleUserName;
                    detail.ProjPeopleDep = model.ProjPeopleCorp;
                    detail.ProjPeopleDuty = model.ProjPeopleDuty;
                    detail.ProjPeopleTel = model.ProjPeopleTel;
                    detail.OwnerLinkMan = model.OwnerLinkMan;
                    detail.OwnerLinkPhone = model.OwnerLinkPhone;
                    detail.OwnerAddress = model.OwnerAddress;
                    detail.ForecastProfitRate = model.ForecastProfitRate;
                    detail.EngineeringEstimates = model.EngineeringEstimates;
                    detail.AfforestArea = model.AfforestArea;
                    detail.ParkArea = model.ParkArea;
                    this.UpdateUserPrimit(detail.PrjDutyPerson, model.PrjDutyPerson, guid);
                    detail.PrjDutyPerson = model.PrjDutyPerson;
                    detail.PrjApprovalOf = model.PrjApprovalOf;
                    detail.PrjFundWorkable = model.PrjFundWorkable;
                    detail.ManagementMargin = model.ManagementMargin;
                    detail.MigrantQualityMarginRate = model.MigrantQualityMarginRate;
                    detail.WithholdingTaxRate = model.WithholdingTaxRate;
                    detail.PerformanceBond = model.PerformanceBond;
                    detail.ElseMargin = model.ElseMargin;
                    detail.ActualRunDate = model.ActualRunDate;
                    detail.PrjManagerRequire = model.PrjManagerRequire;
                    detail.TechnicalLeaderRequire = model.TechnicalLeaderRequire;
                    detail.Province = model.Province;
                    detail.City = model.City;
                    this.UpdateUserPrimit(detail.PrjReadOne, model.PrjReadOne, guid);
                    detail.PrjReadOne = model.PrjReadOne;
                    detail.ProjInfoOrigin = model.ProjInfoOrigin;
                    detail.ProjElseRequest = model.ProjElseRequest;
                    detail.Telephone = model.Telephone;
                    detail.PrjProperty = model.PrjProperty;
                    ProjectKind.Update(prjGuid.ToString(), model.PrjTypes, entities);
                    ProjectRank.Update(prjGuid.ToString(), model.prjRanks, entities);
                    cn.justwin.Tender.EngineeringType.UpdateEngineerType(model.EngineeringTypes, model.PrjGuid.ToString(), entities);
                    entities.SaveChanges();
                }
            }
        }

        public static bool UpdateIsSameCode(string oldCode, string newCode)
        {
            int num = 0;
            using (pm2Entities entities = new pm2Entities())
            {
                num = (from m in entities.PT_PrjInfo
                    where (m.PrjCode != oldCode) && (m.PrjCode == newCode)
                    select m).Count<PT_PrjInfo>();
            }
            return (num > 0);
        }

        public static void UpdatePrjGroup(string prjId, string prjGroup)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                (from m in entities.PT_PrjInfo
                    where m.PrjGuid == new Guid(prjId)
                    select m).FirstOrDefault<PT_PrjInfo>().xmgroup = prjGroup;
                entities.SaveChanges();
            }
        }

        public static void UpdatePrjState(string prjGuid, string prjState)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Guid guid = new Guid(prjGuid);
                (from m in entities.PT_PrjInfo
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo>().PrjState = new int?(int.Parse(prjState));
                entities.SaveChanges();
            }
        }

        public static void UpdateProjectDate(string prjId, DateTime? startDate, DateTime? endDate)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Guid guid = new Guid(prjId);
                PT_PrjInfo info = (from m in entities.PT_PrjInfo
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo>();
                if (info != null)
                {
                    info.StartDate = startDate;
                    info.EndDate = endDate;
                    entities.SaveChanges();
                }
            }
        }

        private void UpdateUserPrimit(string oldCode, string newCode, Guid prjGuid)
        {
            if ((!string.IsNullOrEmpty(newCode) && (newCode != oldCode)) && ((newCode != "00000000") && !TenderUser.isExist(prjGuid, newCode)))
            {
                TenderUser.Add(prjGuid.ToString(), newCode);
            }
        }

        public void UpdatTenderAndProjectStartDate(string prjGuid, DateTime? startDate)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Guid guid = new Guid(prjGuid);
                PT_PrjInfo_ZTB o_ztb = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo_ZTB>();
                if (o_ztb != null)
                {
                    o_ztb.StartDate = startDate;
                }
                PT_PrjInfo info = (from m in entities.PT_PrjInfo
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo>();
                if (info != null)
                {
                    info.StartDate = startDate;
                }
                entities.SaveChanges();
            }
        }

        public DateTime? ActualRunDate { get; set; }

        public string AfforestArea { get; set; }

        public string Area { get; set; }

        public string BudgetWay { get; set; }

        public string BuildingArea { get; set; }

        public string BuildingType { get; set; }

        public int BuildingTypeNo { get; set; }

        public string Businessman { get; set; }

        public string BusinessmanName
        {
            get
            {
                return this.GetUserName(this.Businessman);
            }
        }

        public string City { get; set; }

        public string ComputeClass { get; set; }

        public string ContractSum { get; set; }

        public string ContractWay { get; set; }

        public string Counsellor { get; set; }

        public string Designer { get; set; }

        public string Duration { get; set; }

        public decimal? ElseMargin { get; set; }

        public DateTime? EndDate { get; set; }

        public string EngineeringEstimates { get; set; }

        public string EngineeringSubType { get; set; }

        public string EngineeringType { get; set; }

        public IList<cn.justwin.Tender.EngineeringType> EngineeringTypes
        {
            get
            {
                if (this.engineeringTypes == null)
                {
                    this.engineeringTypes = cn.justwin.Tender.EngineeringType.GetByPrjGuid(this.PrjGuid.ToString());
                }
                return this.engineeringTypes;
            }
            set
            {
                this.engineeringTypes = value;
            }
        }

        public string FileName { get; set; }

        public string FileURL { get; set; }

        public decimal? ForecastProfitRate { get; set; }

        public string Grade { get; set; }

        public int I_ChildNum { get; set; }

        public int I_xh { get; set; }

        public DateTime? InputDate { get; set; }

        public string InputUser { get; set; }

        public string Inspector { get; set; }

        public bool IsConfirm { get; set; }

        public bool IsTender { get; set; }

        public string IsValid { get; set; }

        public string KeyPart { get; set; }

        public string LinkMan { get; set; }

        public string LinkManUserName
        {
            get
            {
                return this.GetUserName(this.LinkMan);
            }
        }

        public decimal? ManagementMargin { get; set; }

        public string MarketInfoGuid { get; set; }

        public decimal? MigrantQualityMarginRate { get; set; }

        public string OtherStatement { get; set; }

        public string OwnerAddress { get; set; }

        public int? OwnerCode { get; set; }

        public string OwnerLinkMan { get; set; }

        public string OwnerLinkPhone { get; set; }

        public string OwnerName
        {
            get
            {
                string str = !this.OwnerCode.HasValue ? string.Empty : this.OwnerCode.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    return this.GetCorpName(str);
                }
                return string.Empty;
            }
        }

        public string ParkArea { get; set; }

        public string PayCondition { get; set; }

        public string PayWay { get; set; }

        public decimal? PerformanceBond { get; set; }

        public string Podepom { get; set; }

        public string PrjApprovalOf { get; set; }

        public string PrjCode { get; set; }

        public double? PrjCost { get; set; }

        public string PrjDutyPerson { get; set; }

        public string PrjDutyPersonName
        {
            get
            {
                return this.GetUserName(this.PrjDutyPerson);
            }
        }

        public string PrjFundInfo { get; set; }

        public string PrjFundWorkable { get; set; }

        public string PrjGrade { get; set; }

        public Guid PrjGuid { get; set; }

        public string PrjInfo { get; set; }

        public string PrjKindClass { get; set; }

        public string PrjManager { get; set; }

        public string PrjManagerName
        {
            get
            {
                return this.PrjManager;
            }
        }

        public string PrjManagerRequire { get; set; }

        public string PrjName { get; set; }

        public string PrjPlace { get; set; }

        public string PrjProperty { get; set; }

        public IList<ProjectRank> PrjRanks
        {
            get
            {
                if (this.prjRanks == null)
                {
                    this.prjRanks = ProjectRank.GetRanks(this.PrjGuid);
                }
                return this.prjRanks;
            }
            set
            {
                this.prjRanks = value;
            }
        }

        public string PrjReadOne { get; set; }

        public int? PrjState { get; set; }

        public string PrjStateRemark { get; set; }

        public IList<ProjectKind> PrjTypes
        {
            get
            {
                if (this.prjTypes == null)
                {
                    this.prjTypes = ProjectKind.GetProjectKinds(this.PrjGuid);
                }
                return this.prjTypes;
            }
            set
            {
                this.prjTypes = value;
            }
        }

        public string ProgAgent { get; set; }

        public string ProgAgentName
        {
            get
            {
                return this.GetUserName(this.ProgAgent);
            }
        }

        public string ProjElseRequest { get; set; }

        public int ProjFlowSate { get; set; }

        public string ProjInfoOrigin { get; set; }

        public string ProjPeopleCode { get; set; }

        public string ProjPeopleCorp { get; set; }

        public string ProjPeopleDuty { get; set; }

        public string ProjPeopleTel { get; set; }

        public string ProjPeopleUserName { get; set; }

        public string Province { get; set; }

        public decimal QualificationMargin { get; set; }

        public string QualificationReadOne { get; set; }

        public string QualityClass { get; set; }

        public string Rank { get; set; }

        public string RationClass { get; set; }

        public string RecordDate { get; set; }

        public string Remark { get; set; }

        public DateTime? StartDate { get; set; }

        public string TechnicalLeaderRequire { get; set; }

        public string Telephone { get; set; }

        public DateTime? TenderProspect { get; set; }

        public string TenderReadOne { get; set; }

        public string TenderWay { get; set; }

        public string TotalHouseNum { get; set; }

        public string TypeCode { get; set; }

        public string UndergroundArea { get; set; }

        public string UsegrounArea { get; set; }

        public string UserCode { get; set; }

        public decimal? WithholdingTaxRate { get; set; }

        public string WorkUnit { get; set; }

        public string WorkUnitName
        {
            get
            {
                return this.WorkUnit;
            }
        }

        public string Xmgroup { get; set; }
    }
}

