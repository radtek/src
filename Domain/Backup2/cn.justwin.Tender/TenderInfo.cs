namespace cn.justwin.Tender
{
    using cn.justwin.BLL;
    using cn.justwin.DAL;
    using cn.justwin.Domain.Services;
    using cn.justwin.Project;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class TenderInfo
    {
        private IList<cn.justwin.Tender.EngineeringType> engineeringTypes;
        private IList<ProjectKind> prjKinds;
        private IList<ProjectRank> prjRanks;

        public void Add(TenderInfo model)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                if (model != null)
                {
                    PT_PrjInfo_ZTB o_ztb = new PT_PrjInfo_ZTB {
                        ComputeClass = model.ComputeClass,
                        ContractSum = model.ContractSum,
                        FileName = model.FileName,
                        FileURL = model.FileURL,
                        RationClass = model.RationClass,
                        MarketInfoGuid = model.MarketInfoGuid,
                        OwnerCode = model.OwnerCode,
                        PrjGuid = model.PrjGuid,
                        PrjCode = model.PrjCode,
                        PrjName = model.PrjName,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        Duration = model.Duration,
                        PrjCost = model.PrjCost,
                        PrjKindClass = model.PrjKindClass,
                        PrjPlace = model.PrjPlace,
                        PrjState = new int?(model.PrjState),
                        Area = model.Area,
                        Designer = model.Designer,
                        Counsellor = model.Counsellor,
                        Inspector = model.Inspector,
                        PrjInfo = model.PrjInfo,
                        QualityClass = model.QualityClass,
                        Remark = model.Remark,
                        Rank = model.Rank,
                        BudgetWay = model.BudgetWay,
                        PayWay = model.PayWay,
                        KeyPart = model.KeyPart,
                        ContractWay = model.ContractWay,
                        PayCondition = model.PayCondition,
                        PrjManager = model.PrjManager,
                        TenderWay = model.TenderWay,
                        WorkUnit = model.WorkUnit,
                        BuildingType = model.BuildingType,
                        BuildingArea = model.BuildingArea,
                        OtherStatement = model.OtherStatement,
                        PrjFundInfo = model.PrjFundInfo,
                        TotalHouseNum = model.TotalHouseNum,
                        UndergroundArea = model.UndergroundArea,
                        UsegrounArea = model.UsegrounArea
                    };
                    entities.AddToPT_PrjInfo_ZTB(o_ztb);
                    PT_PrjInfo_ZTB_Detail detail = new PT_PrjInfo_ZTB_Detail {
                        PrjGuid = model.PrjGuid,
                        InputUser = model.InputUser,
                        InputDate = model.InputDate,
                        ProjFlowSate = -1,
                        MemberFlowState = -1,
                        CompletedFlowState = -1,
                        ProjPeopleName = model.ProjPeopleUserName,
                        ProjPeopleDep = model.ProjPeopleCorp,
                        ProjPeopleDuty = model.ProjPeopleDuty,
                        ProjPeopleTel = model.ProjPeopleTel,
                        OwnerLinkMan = model.OwnerLinkManName,
                        OwnerLinkPhone = model.OwnerLinkPhone,
                        OwnerAddress = model.OwnerAddress,
                        PrjDutyPerson = model.PrjDutyPerson,
                        PrjApprovalOf = model.PrjApprovalOf,
                        EngineeringEstimates = model.EngineeringEstimates,
                        ForecastProfitRate = model.ForecastProfitRate,
                        ProjInfoOrigin = model.ProjInfoOrigin,
                        ProjElseRequest = model.ProjElseRequest,
                        Telephone = model.Telephone,
                        EngineeringType = model.EngineeringType,
                        EngineeringSubType = model.EngineeringSubType,
                        Grade = model.Grade,
                        BuildingTypeNo = new int?(model.BuildingTypeNo),
                        PrjFundWorkable = model.PrjFundWorkable,
                        AfforestArea = model.AfforestArea,
                        ParkArea = model.ParkArea,
                        ManagementMargin = model.ManagementMargin,
                        MigrantQualityMarginRate = model.MigrantQualityMarginRate,
                        WithholdingTaxRate = model.WithholdingTaxRate,
                        PerformanceBond = model.PerformanceBond,
                        ElseMargin = model.ElseMargin,
                        IsTender = true,
                        PrjManagerRequire = model.PrjManagerRequire,
                        TechnicalLeaderRequire = model.TechnicalLeaderRequire,
                        Province = model.Province,
                        City = model.City,
                        PrjProperty = model.PrjProperty,
                        PrjReadOne = model.PrjReadOne,
                        QualificationMargin = model.QualificationMargin,
                        QualificationReadOne = model.QualificationReadOne,
                        TenderProspect = model.TenderProspect,
                        TenderReadOne = model.TenderReadOne
                    };
                    entities.AddToPT_PrjInfo_ZTB_Detail(detail);
                    cn.justwin.Tender.EngineeringType.UpdateEngineerType(model.EngineeringTypes, model.PrjGuid.ToString(), entities);
                    ProjectKind.Update(model.PrjGuid.ToString(), model.prjKinds, entities);
                    ProjectRank.Update(model.PrjGuid.ToString(), model.prjRanks, entities);
                    entities.SaveChanges();
                    this.AddDefaultLimit(model);
                }
            }
        }

        private void AddDefaultLimit(TenderInfo mode)
        {
            List<string> source = new List<string>();
            if (!string.IsNullOrEmpty(mode.InputUser))
            {
                source.Add(mode.InputUser);
            }
            if (mode.InputUser != "00000000")
            {
                source.Add("00000000");
            }
            if (!string.IsNullOrEmpty(mode.ProgAgent))
            {
                source.Add(mode.ProgAgent);
            }
            if (!string.IsNullOrEmpty(mode.BusinessManager))
            {
                source.Add(mode.BusinessManager);
            }
            if (!string.IsNullOrEmpty(mode.PrjDutyPerson))
            {
                source.Add(mode.PrjDutyPerson);
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

        public static void Del(string id)
        {
            Guid guid = new Guid(id);
            using (pm2Entities entities = new pm2Entities())
            {
                PT_PrjInfo_ZTB entity = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo_ZTB>();
                entities.DeleteObject(entity);
                if ((from m in entities.PT_PrjInfo
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo>() == null)
                {
                    PT_PrjInfo_ZTB_Detail detail = (from m in entities.PT_PrjInfo_ZTB_Detail
                        where m.PrjGuid == guid
                        select m).FirstOrDefault<PT_PrjInfo_ZTB_Detail>();
                    entities.DeleteObject(detail);
                }
                cn.justwin.Tender.EngineeringType.Delete(id, entities);
                new PTPrjInfoZTBUserService().Delete(id);
                entities.SaveChanges();
            }
        }

        private static string GenerateGetTenderPrivilegeSql(string prjCode, string prjName, string startDate, string endDate, string prjManageName, string prjState, string userCode, string kind, string setUpDep, string prjProperty)
        {
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.AppendFormat(" AND V.PrjCode LIKE '%{0}%'  \n ", prjCode);
            }
            if (!string.IsNullOrEmpty(prjName))
            {
                builder.AppendFormat(" AND V.PrjName LIKE '%{0}%'  \n ", prjName);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                builder.AppendFormat(" AND V.InputDate >= '{0}'  \n ", startDate);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                builder.AppendFormat(" AND V.InputDate < '{0}' \n ", endDate);
            }
            if (!string.IsNullOrEmpty(prjManageName))
            {
                builder.AppendFormat(" AND V.PrjMangerName LIKE '%{0}%'  \n ", prjManageName);
            }
            if (!string.IsNullOrEmpty(prjState))
            {
                builder.AppendFormat(" AND V.PrjState = '{0}'  \n ", prjState);
            }
            if (!string.IsNullOrWhiteSpace(setUpDep))
            {
                builder.AppendFormat(" AND V.ProjPeopleDep LIKE '%{0}%' \n ", setUpDep);
            }
            if (!string.IsNullOrWhiteSpace(prjProperty))
            {
                builder.AppendFormat(" AND V.PrjProperty = '{0}' \n ", prjProperty);
            }
            if (!string.IsNullOrWhiteSpace(kind))
            {
                builder.AppendFormat(" AND V.PrjGuid IN (SELECT PrjGuid FROM PT_PrjInfo_Kind WHERE PrjGuid = V.PrjGuid AND PrjKind = '{0}') \n", kind);
            }
            if (!string.IsNullOrEmpty(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND V.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND V.PrjGuid IN({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            return builder.ToString();
        }

        private static string GenerateGetTendersSql(string code, string name, string setUpPerson, string setUpDep, string kind, string startDate, string endDate, string unitName, string flowState, string property, string userCode)
        {
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(code))
            {
                builder.AppendFormat(" AND PrjCode LIKE '%{0}%' \n", code);
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                builder.AppendFormat(" AND Prjname LIKE '%{0}%' \n", name);
            }
            if (!string.IsNullOrWhiteSpace(setUpPerson))
            {
                builder.AppendFormat(" AND ProjPeopleName LIKE '%{0}%' \n", setUpPerson);
            }
            if (!string.IsNullOrWhiteSpace(setUpDep))
            {
                builder.AppendFormat(" AND ProjPeopleDep LIKE '%{0}%' \n", setUpDep);
            }
            if (!string.IsNullOrWhiteSpace(kind))
            {
                builder.AppendFormat(" AND PrjGuid IN (SELECT PrjGuid FROM PT_PrjInfo_Kind WHERE PrjGuid = vTender.PrjGuid AND PrjKind = '{0}') \n", kind);
            }
            if (!string.IsNullOrWhiteSpace(startDate))
            {
                builder.AppendFormat(" AND InputDate >= '{0}' \n", startDate);
            }
            if (!string.IsNullOrWhiteSpace(endDate))
            {
                builder.AppendFormat(" AND InputDate <= '{0}' \n", endDate + " 23:59:59");
            }
            if (!string.IsNullOrWhiteSpace(unitName))
            {
                builder.AppendFormat(" AND WorkUnitName LIKE '%{0}%' \n", unitName);
            }
            if (!string.IsNullOrWhiteSpace(flowState))
            {
                builder.AppendFormat(" AND ProjFlowSate = '{0}' \n", flowState);
            }
            if (!string.IsNullOrWhiteSpace(property))
            {
                builder.AppendFormat(" AND PrjProperty LIKE '%{0}%' \n", property);
            }
            if (!string.IsNullOrWhiteSpace(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND PrjGuid is null  \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            builder.AppendFormat(" AND PrjState IN ('1','2') ", new object[0]);
            return builder.ToString();
        }

        public static DataTable GetAll(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, bool isDisplayFlowState, int personType, int pageNo, int pageSize, string OldState, string flowStateName)
        {
            DataTable table = new DataTable();
            StringBuilder builder = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            builder.Append("\r\nSELECT * FROM(\r\nSELECT ROW_NUMBER() OVER (ORDER BY TDetail.InputDate DESC ) AS No\r\n,Tender.PrjGuid                  --项目Guid\r\n,Tender.PrjCode                  --项目编码\r\n,Tender.PrjName                  --项目名称\r\n,prjType.CodeName AS PrjTypeName --项目类型\r\n,Corp.CorpName AS WorkUnitName  --建设单位名称\r\n --立项申请时间\r\n,CONVERT(VARCHAR(100), TDetail.InputDate,23) AS InputDate");
            if (personType == 1)
            {
                builder.Append(",TDetail.ProjPeopleName AS  Person");
            }
            else if (personType == 3)
            {
                builder.Append(",Tender.PrjManager AS Person");
            }
            else
            {
                builder.Append(",YHMC.v_xm AS Person ");
            }
            builder.Append("\r\n,Tender.PrjState                --项目状态编码\r\n--,CASE ISNULL(CListPrjInfo.ItemName,'')\r\n\t--WHEN '' THEN  CListZTB.ItemName\r\n   -- ELSE\r\n        --CASE PrjInfo.PrjState\r\n            --WHEN '5' THEN CListZTB.ItemName\r\n        --ELSE\r\n           -- CASE Tender.PrjState\t\r\n\t\t\t   -- WHEN '5' THEN(CListZTB.ItemName+'('+CListPrjInfo.ItemName+')')\r\n               -- ELSE\r\n                  --  CListZTB.ItemName\r\n           -- END\r\n       -- END\t\r\n--END\r\n  ,CASE CListZTB.ItemCode\r\n\t\t            WHEN '5' THEN \r\n\t\t\t            CASE WHEN CListPrjInfo.ItemCode in(7,8,9,10,11,12,13,17) \r\n\t\t\t\t            THEN CListZTB.ItemName + '(' + CListPrjInfo.ItemName + ')'\r\n\t\t\t\t            ELSE CListZTB.ItemName\r\n\t\t\t            END                             \r\n\t\t            ELSE \r\n\t\t\t            CListZTB.ItemName\r\n\t            END\r\nAS StateText                    --项目状态Text\r\n,PrjInfo.PrjState AS PrjInfoState --项目开工状态\r\n,Tender.Duration                --工程工期");
            if (isDisplayFlowState)
            {
                builder.Append("\r\n--流程状态\r\n,ISNULL(TDetail.ProjFlowSate,-1) AS   ProjFlowSate ");
            }
            builder.Append("\r\n--,Tender.StartDate               --开始日期\r\n--,Tender.EndDate                 --结束日期\r\n,Tender.OldState                --放弃状态\r\n,Tender.InitiateFlowState       --报名状态\r\n,Tender.PftFlowState            --资格预审流程状态\r\n,Tender.BidFlowState            --中标流程状态   \r\n,Tender.GiveUpFlowState         --放弃流程状态\r\n,Tender.ChangeFlowSate          --状态变更流程状态\r\n,Tender.IsGiveUp                --是否放弃\r\n,CONVERT(DECIMAL(18,3),ISNULL(Tender.PrjCost,'0.000')) AS PrjCost  --造价 \r\nFROM PT_PrjInfo_ZTB AS Tender\r\nLEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\nLEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\nLEFT JOIN (SELECT PrjGuid,CodeID,CodeName FROM XPM_Basic_CodeList\r\nLEFT JOIN PT_PrjInfo_Kind AS PrjKind ON PrjKind.PrjKind= CodeID\r\n WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n) AS prjType ON Tender.PrjGuid=prjType.PrjGuid\r\nLEFT JOIN PT_PrjInfo AS PrjInfo ON  Tender.PrjGuid=PrjInfo.PrjGuid\r\nLEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS CListZTB ON Tender.PrjState=CListZTB.ItemCode\r\nLEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS CListPrjInfo ON PrjInfo.PrjState=CListPrjInfo.ItemCode");
            if (personType != 1)
            {
                if (personType == 2)
                {
                    builder.Append("\r\nLEFT JOIN PT_yhmc AS YHMC ON TDetail.BusinessManager =YHMC.v_yhdm");
                }
                else if ((personType != 3) && (personType == 4))
                {
                    builder.Append("\r\nLEFT JOIN PT_yhmc AS YHMC ON TDetail.PrjDutyPerson=YHMC.v_yhdm");
                }
            }
            builder.Append("\r\nWHERE 1=1 ");
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append("\r\nAND Tender.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjCode))
            {
                builder.Append("\r\nAND Tender.PrjCode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjKindClass))
            {
                builder.Append(" AND Tender.PrjGuid IN ( \n").Append("\tSELECT PrjGuid FROM PT_PrjInfo_Kind \n").AppendFormat("\tWHERE PrjGuid = Tender.PrjGuid AND PrjKind = @prjKindClass \n", new object[0]).Append(" ) \n");
                list.Add(new SqlParameter("@prjKindClass", prjKindClass));
            }
            if (!string.IsNullOrWhiteSpace(buildUnit))
            {
                builder.Append("\r\nAND Corp.CorpName LIKE '%'+ @buildUnit + '%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit.Trim()));
            }
            if (!string.IsNullOrEmpty(flowStateName))
            {
                builder.Append(" AND Tender." + flowStateName + "=1  ");
            }
            if ((flowState != null) && (flowState.Count > 0))
            {
                string search = GetSearch(flowState);
                if (flowState.Contains(-1))
                {
                    builder.AppendFormat(" \r\nAND (TDetail.ProjFlowSate IN ({0}) OR TDetail.ProjFlowSate IS NULL) ", search);
                }
                else
                {
                    builder.AppendFormat(" \r\nAND TDetail.ProjFlowSate IN ({0})", search);
                }
            }
            if ((prjState != null) && (prjState.Count > 0))
            {
                string str2 = GetSearch(prjState);
                if (string.IsNullOrEmpty(OldState))
                {
                    builder.AppendFormat("  AND Tender.PrjState IN ({0}) ", str2);
                }
                else if (prjState.Count == 1)
                {
                    if (str2 == "'18'")
                    {
                        builder.AppendFormat(" AND (Tender.PrjState=18 and Tender.OldState='" + OldState + "')", str2);
                    }
                    else
                    {
                        builder.AppendFormat("  AND Tender.PrjState IN ({0}) ", str2);
                    }
                }
                else
                {
                    builder.AppendFormat(" AND (Tender.PrjState IN ({0}) or (Tender.PrjState=18 and Tender.OldState='" + OldState + "'))", str2);
                }
            }
            if (!string.IsNullOrWhiteSpace(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND Tender.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND Tender.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrWhiteSpace(start))
            {
                builder.Append("\r\nAND TDetail.InputDate >= @start ");
                list.Add(new SqlParameter("@start", start.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(end))
            {
                builder.Append("\r\nAND  TDetail.InputDate <= @end ");
                list.Add(new SqlParameter("@end", end.Trim() + " 23:59:59"));
            }
            if ((personType == 1) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND  TDetail.ProjPeopleName LIKE'%'+@setUpPerson+'%'");
                list.Add(new SqlParameter("@setUpPerson", person.Trim()));
            }
            if ((personType == 2) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND  YHMC.v_xm LIKE '%'+@businessManager+'%'");
                list.Add(new SqlParameter("@businessManager", person.Trim()));
            }
            if ((personType == 3) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND Tender.PrjManager LIKE '%'+@prjManager+'%'");
                list.Add(new SqlParameter("@prjManager", person.Trim()));
            }
            if ((personType == 4) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND YHMC.v_xm LIKE '%'+@prjDuty+'%'");
                list.Add(new SqlParameter("@prjDuty", person.Trim()));
            }
            builder.Append("\r\n)AS T WHERE T.No BETWEEN (@pageNo-1)*@pageSize+1 AND @pageNo*@pageSize ");
            list.Add(new SqlParameter("@pageNo", pageNo));
            list.Add(new SqlParameter("@pageSize", pageSize));
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static DataTable GetAllAtChgState(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, bool isDisplayFlowState, int personType, int pageNo, int pageSize, string flowStateField)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\r\n                    SELECT * FROM(\r\n                    SELECT ROW_NUMBER() OVER (ORDER BY TDetail.InputDate DESC ) AS No\r\n                    ,Tender.PrjGuid                  --项目Guid\r\n                    ,Tender.PrjCode                  --项目编码\r\n                    ,Tender.PrjName                  --项目名称\r\n                    ,prjType.CodeName AS PrjTypeName --项目类型\r\n                    ,Corp.CorpName AS WorkUnitName  --建设单位名称\r\n                     --立项申请时间\r\n                    ,CONVERT(VARCHAR(100), TDetail.InputDate,23) AS InputDate");
            if (personType == 1)
            {
                builder.Append(",TDetail.ProjPeopleName AS  Person");
            }
            else if (personType == 3)
            {
                builder.Append(",Tender.PrjManager AS Person");
            }
            else
            {
                builder.Append(",YHMC.v_xm AS Person ");
            }
            builder.Append("\r\n                    ,Tender.PrjState                --项目状态编码\r\n             ,CASE CListZTB.ItemCode\r\n\t\t            WHEN '5' THEN \r\n\t\t\t            CASE WHEN CListPrjInfo.ItemCode in(7,8,9,10,11,12,13,17) \r\n\t\t\t\t            THEN CListZTB.ItemName + '(' + CListPrjInfo.ItemName + ')'\r\n\t\t\t\t            ELSE CListZTB.ItemName\r\n\t\t\t            END                             \r\n\t\t            ELSE \r\n\t\t\t            CListZTB.ItemName\r\n\t            END AS StateText                    --项目状态Text\r\n                    ,PrjInfo.PrjState AS PrjInfoState --项目开工状态\r\n                    ,Tender.Duration                --工程工期");
            if (isDisplayFlowState)
            {
                builder.Append("\r\n                    --流程状态\r\n                    ,ISNULL(TDetail.ProjFlowSate,-1) AS   ProjFlowSate ");
            }
            builder.Append("\r\n                --,Tender.StartDate               --开始日期\r\n                --,Tender.EndDate                 --结束日期\r\n                ,Tender.OldState                --放弃状态\r\n                ,Tender.InitiateFlowState       --报名状态\r\n                ,Tender.PftFlowState            --资格预审流程状态\r\n                ,Tender.BidFlowState            --中标流程状态   \r\n                ,Tender.GiveUpFlowState         --放弃流程状态\r\n                ,Tender.ChangeFlowSate          --状态变更流程状态\r\n                ,PrjInfo_StateChange.changeState as changeState --变更的项目状态\r\n                ,CONVERT(DECIMAL(18,3),ISNULL(Tender.PrjCost,'0.000')) AS PrjCost  --造价 \r\n                FROM PT_PrjInfo_ZTB AS Tender\r\n                LEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\n                LEFT JOIN PT_PrjInfo_StateChange AS PrjInfo_StateChange ON Tender.PrjGuid=PrjInfo_StateChange.PrjId AND PrjInfo_StateChange.flowState<>1\r\n                LEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\n                LEFT JOIN (SELECT CodeID,CodeName FROM XPM_Basic_CodeList WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n                ) AS prjType ON Tender.PrjKindClass=CONVERT(VARCHAR(100),prjType.CodeID)\r\n                LEFT JOIN PT_PrjInfo AS PrjInfo ON  Tender.PrjGuid=PrjInfo.PrjGuid\r\n                LEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS CListZTB ON Tender.PrjState=CListZTB.ItemCode\r\n                LEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS CListPrjInfo ON PrjInfo.PrjState=CListPrjInfo.ItemCode");
            string str = GetTenderSqlCondition(prjName, prjCode, buildUnit, prjKindClass, start, end, prjState, flowState, userCode, person, personType, flowStateField);
            builder.Append(str);
            builder.AppendFormat(")AS T WHERE T.No BETWEEN ({0}-1)*{1}+1 AND {0}*{1} ", pageNo, pageSize);
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), new SqlParameter[0]);
        }

        public static DataTable GetAllAtGiveUp(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, bool isDisplayFlowState, int personType, int pageNo, int pageSize)
        {
            DataTable table = new DataTable();
            StringBuilder builder = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            builder.Append("\r\nSELECT * FROM(\r\nSELECT ROW_NUMBER() OVER (ORDER BY TDetail.InputDate DESC ) AS No\r\n,Tender.PrjGuid                  --项目Guid\r\n,Tender.PrjCode                  --项目编码\r\n,Tender.PrjName                  --项目名称\r\n,prjType.CodeName AS PrjTypeName --项目类型\r\n,Corp.CorpName AS WorkUnitName  --建设单位名称\r\n --立项申请时间\r\n,CONVERT(VARCHAR(100), TDetail.InputDate,23) AS InputDate");
            if (personType == 1)
            {
                builder.Append(",TDetail.ProjPeopleName AS  Person");
            }
            else if (personType == 3)
            {
                builder.Append(",Tender.PrjManager AS Person");
            }
            else
            {
                builder.Append(",YHMC.v_xm AS Person ");
            }
            builder.Append("\r\n,Tender.PrjState                --项目状态编码\r\n--,CASE ISNULL(CListPrjInfo.ItemName,'')\r\n\t--WHEN '' THEN  CListZTB.ItemName\r\n   -- ELSE\r\n        --CASE PrjInfo.PrjState\r\n            --WHEN '5' THEN CListZTB.ItemName\r\n        --ELSE\r\n           -- CASE Tender.PrjState\t\r\n\t\t\t   -- WHEN '5' THEN(CListZTB.ItemName+'('+CListPrjInfo.ItemName+')')\r\n               -- ELSE\r\n                  --  CListZTB.ItemName\r\n           -- END\r\n       -- END\t\r\n--END\r\n  ,CASE CListZTB.ItemCode\r\n\t\t            WHEN '5' THEN \r\n\t\t\t            CASE WHEN CListPrjInfo.ItemCode in(7,8,9,10,11,12,13,17) \r\n\t\t\t\t            THEN CListZTB.ItemName + '(' + CListPrjInfo.ItemName + ')'\r\n\t\t\t\t            ELSE CListZTB.ItemName\r\n\t\t\t            END                             \r\n\t\t            ELSE \r\n\t\t\t            CListZTB.ItemName\r\n\t            END\r\nAS StateText                    --项目状态Text\r\n,PrjInfo.PrjState AS PrjInfoState --项目开工状态\r\n,Tender.Duration                --工程工期");
            if (isDisplayFlowState)
            {
                builder.Append("\r\n--流程状态\r\n,ISNULL(TDetail.ProjFlowSate,-1) AS   ProjFlowSate ");
            }
            builder.Append("\r\n--,Tender.StartDate               --开始日期\r\n--,Tender.EndDate                 --结束日期\r\n,Tender.OldState                --放弃状态\r\n,Tender.InitiateFlowState       --报名状态\r\n,Tender.PftFlowState            --资格预审流程状态\r\n,Tender.BidFlowState            --中标流程状态   \r\n,Tender.GiveUpFlowState         --放弃流程状态\r\n,Tender.ChangeFlowSate          --状态变更流程状态\r\n,Tender.IsGiveUp                --是否放弃\r\n,CONVERT(DECIMAL(18,3),ISNULL(Tender.PrjCost,'0.000')) AS PrjCost  --造价 \r\nFROM PT_PrjInfo_ZTB AS Tender\r\nLEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\nLEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\nLEFT JOIN (SELECT CodeID,CodeName FROM XPM_Basic_CodeList WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n) AS prjType ON Tender.PrjKindClass=CONVERT(VARCHAR(100),prjType.CodeID)\r\nLEFT JOIN PT_PrjInfo AS PrjInfo ON  Tender.PrjGuid=PrjInfo.PrjGuid\r\nLEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS CListZTB ON Tender.PrjState=CListZTB.ItemCode\r\nLEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS CListPrjInfo ON PrjInfo.PrjState=CListPrjInfo.ItemCode");
            if (personType != 1)
            {
                if (personType == 2)
                {
                    builder.Append("\r\nLEFT JOIN PT_yhmc AS YHMC ON TDetail.BusinessManager =YHMC.v_yhdm");
                }
                else if ((personType != 3) && (personType == 4))
                {
                    builder.Append("\r\nLEFT JOIN PT_yhmc AS YHMC ON TDetail.PrjDutyPerson=YHMC.v_yhdm");
                }
            }
            builder.Append("\r\nWHERE 1=1 ");
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append("\r\nAND Tender.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjCode))
            {
                builder.Append("\r\nAND Tender.PrjCode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjKindClass))
            {
                builder.Append(" AND Tender.PrjGuid IN ( \n").Append("\tSELECT PrjGuid FROM PT_PrjInfo_Kind \n").AppendFormat("\tWHERE PrjGuid = Tender.PrjGuid AND PrjKind = @prjKindClass \n", new object[0]).Append(" ) \n");
                list.Add(new SqlParameter("@prjKindClass", prjKindClass));
            }
            if (!string.IsNullOrWhiteSpace(buildUnit))
            {
                builder.Append("\r\nAND Corp.CorpName LIKE '%'+ @buildUnit + '%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit.Trim()));
            }
            builder.Append(" AND ((TDetail.ProjFlowSate in(-1,-2,-3) and Tender.InitiateFlowState=-1 and Tender.PftFlowState=-1) or (TDetail.ProjFlowSate=1 and Tender.InitiateFlowState in(-1,-2,-3) and Tender.PftFlowState=-1) or (TDetail.ProjFlowSate=1 and Tender.InitiateFlowState=1 and Tender.PftFlowState in(-1,-2,-3)) or (TDetail.ProjFlowSate=1 and Tender.InitiateFlowState=1 and Tender.PftFlowState=1)) ");
            if ((prjState != null) && (prjState.Count > 0))
            {
                string searchAtGiveUp = GetSearchAtGiveUp(prjState);
                builder.AppendFormat("  AND Tender.PrjState IN ({0}) ", searchAtGiveUp);
            }
            if (!string.IsNullOrWhiteSpace(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND Tender.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND Tender.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrWhiteSpace(start))
            {
                builder.Append("\r\nAND TDetail.InputDate >= @start ");
                list.Add(new SqlParameter("@start", start.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(end))
            {
                builder.Append("\r\nAND  TDetail.InputDate <= @end ");
                list.Add(new SqlParameter("@end", end.Trim() + " 23:59:59"));
            }
            if ((personType == 1) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND  TDetail.ProjPeopleName LIKE'%'+@setUpPerson+'%'");
                list.Add(new SqlParameter("@setUpPerson", person.Trim()));
            }
            if ((personType == 2) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND  YHMC.v_xm LIKE '%'+@businessManager+'%'");
                list.Add(new SqlParameter("@businessManager", person.Trim()));
            }
            if ((personType == 3) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND Tender.PrjManager LIKE '%'+@prjManager+'%'");
                list.Add(new SqlParameter("@prjManager", person.Trim()));
            }
            if ((personType == 4) && !string.IsNullOrWhiteSpace(person))
            {
                builder.Append("\r\nAND YHMC.v_xm LIKE '%'+@prjDuty+'%'");
                list.Add(new SqlParameter("@prjDuty", person.Trim()));
            }
            builder.Append("\r\n)AS T WHERE T.No BETWEEN (@pageNo-1)*@pageSize+1 AND @pageNo*@pageSize ");
            list.Add(new SqlParameter("@pageNo", pageNo));
            list.Add(new SqlParameter("@pageSize", pageSize));
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static TenderInfo GetById(string id)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                ParameterExpression expression6;
                Guid prjGuid = new Guid(id);
                return (from m in entities.PT_PrjInfo_ZTB
                    join d in entities.PT_PrjInfo_ZTB_Detail on m.PrjGuid equals d.PrjGuid into d
                    where (m.PrjGuid == prjGuid) && (d.PrjGuid == prjGuid)
                    select <>h__TransparentIdentifier2).Select(Expression.Lambda(Expression.MemberInit(Expression.New((ConstructorInfo) methodof(TenderInfo..ctor), new Expression[0]), new MemberBinding[] { 
                    Expression.Bind((MethodInfo) methodof(TenderInfo.set_Area), Expression.Property(Expression.Property(expression6 = Expression.Parameter(typeof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>), "<>h__TransparentIdentifier2"), (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_Area))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_BudgetWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_BudgetWay))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_BuildingArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_BuildingArea))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_BuildingType), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_BuildingType))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_BuildingTypeNo), Expression.Coalesce(Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_BuildingTypeNo)), Expression.Constant(0, typeof(int)))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ComputeClass), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_ComputeClass))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ContractSum), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_ContractSum))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ContractWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_ContractWay))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Counsellor), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_Counsellor))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Designer), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_Designer))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Duration), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_Duration))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_EndDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_EndDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_FileName), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_FileName))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_FileURL), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_FileURL))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Inspector), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_Inspector))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_KeyPart), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_KeyPart))), 
                    Expression.Bind((MethodInfo) methodof(TenderInfo.set_MarketInfoGuid), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_MarketInfoGuid))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OtherStatement), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_OtherStatement))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjCode), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjCode))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjCost), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjCost))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjFundInfo), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjFundInfo))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OutBidIsReturn), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OutBidIsReturn))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OutBidDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OutBidDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OutBidRemark), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OutBidRemark))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OwnerCode), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_OwnerCode))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OwnerLinkManName), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OwnerLinkMan))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OwnerLinkPhone), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OwnerLinkPhone))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_OwnerAddress), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_OwnerAddress))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PayCondition), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PayCondition))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PayWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PayWay))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjGuid), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjGuid))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjInfo), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjInfo))), 
                    Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjKindClass), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjKindClass))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjManager), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjManager))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjName), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjName))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjPlace), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjPlace))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjState), Expression.Coalesce(Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_PrjState)), Expression.Constant(0, typeof(int)))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_QualityClass), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_QualityClass))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Rank), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_Rank))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_RationClass), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_RationClass))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Remark), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_Remark))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_StartDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_StartDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_TenderWay))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TotalHouseNum), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_TotalHouseNum))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_UndergroundArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_UndergroundArea))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_UsegrounArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_UsegrounArea))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_WorkUnit), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_m, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB.get_WorkUnit))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjFlowSate), Expression.Coalesce(Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjFlowSate)), Expression.Constant(-1, typeof(int)))), 
                    Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjPeopleUserName), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleName))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjPeopleCorp), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleDep))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjPeopleDuty), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleDuty))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjPeopleTel), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjPeopleTel))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjStartDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjStartDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjStartRemark), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjStartRemark))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderAnswerDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderAnswerDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderBeginDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderBeginDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderContent), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderContent))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderCostContent), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderCostContent))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderEarnestMoney), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderEarnestMoney))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderPayWay), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderPayWay))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderRemark), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderRemark))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_SuccessBidDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_SuccessBidDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_SuccessBidPrice), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_SuccessBidPrice))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_SuccessBidRemark), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_SuccessBidRemark))), 
                    Expression.Bind((MethodInfo) methodof(TenderInfo.set_BusinessManager), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_BusinessManager))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProgAgent), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProgAgent))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjApplyDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjApplyDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjApprovalDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjApprovalDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjElseRequest), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjElseRequest))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjInfoOrigin), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjInfoOrigin))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjRegistDeadline), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjRegistDeadline))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ProjTenderDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ProjTenderDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderAppraiseMethod), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TenderAppraiseMethod))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderAverage), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TenderAverage))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderCeilingPrice), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TenderCeilingPrice))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderQuote), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TenderQuote))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderUnit), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TenderUnit))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Telephone), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_Telephone))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Grade), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_Grade))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_EngineeringType), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_EngineeringType))), 
                    Expression.Bind((MethodInfo) methodof(TenderInfo.set_EngineeringSubType), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_EngineeringSubType))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_InputDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_InputDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_InputUser), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_InputUser))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ActualRunDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ActualRunDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjDutyPerson), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjDutyPerson))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjApprovalOf), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjApprovalOf))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjFundWorkable), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjFundWorkable))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ForecastProfitRate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ForecastProfitRate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_EngineeringEstimates), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_EngineeringEstimates))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ManagementMargin), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ManagementMargin))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_MigrantQualityMarginRate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_MigrantQualityMarginRate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_WithholdingTaxRate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_WithholdingTaxRate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PerformanceBond), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PerformanceBond))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ElseMargin), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ElseMargin))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjManagerRequire), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjManagerRequire))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TechnicalLeaderRequire), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TechnicalLeaderRequire))), 
                    Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrequalificationRequire), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrequalificationRequire))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_QualificationPassDate), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_QualificationPassDate))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_QualificationPassReason), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_QualificationPassReason))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_QualificationFailData), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_QualificationFailData))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_QualificationFailReason), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_QualificationFailReason))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_Province), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_Province))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_City), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_City))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjProperty), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjProperty))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_PrjReadOne), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_PrjReadOne))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_QualificationMargin), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_QualificationMargin))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_QualificationReadOne), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_QualificationReadOne))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderProspect), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TenderProspect))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_TenderReadOne), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_TenderReadOne))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_AfforestArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_AfforestArea))), Expression.Bind((MethodInfo) methodof(TenderInfo.set_ParkArea), Expression.Property(Expression.Property(expression6, (MethodInfo) methodof(<>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>.get_d, <>f__AnonymousType25<PT_PrjInfo_ZTB, PT_PrjInfo_ZTB_Detail>)), (MethodInfo) methodof(PT_PrjInfo_ZTB_Detail.get_ParkArea)))
                 }), new ParameterExpression[] { expression6 })).FirstOrDefault<TenderInfo>();
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

        public static int GetCount(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType, string OldState, string flowStateName)
        {
            object obj2 = GetCountOrSumTotal(prjName, prjCode, buildUnit, prjKindClass, start, end, prjState, flowState, userCode, person, personType, "COUNT(*)", OldState, flowStateName);
            return ((obj2 == null) ? 0 : Convert.ToInt32(obj2));
        }

        public static int GetCountAtChgState(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType, string flowStateField)
        {
            prjName = prjName.Trim();
            prjCode = prjCode.Trim();
            buildUnit = buildUnit.Trim();
            start = start.Trim();
            end = end.Trim();
            person = person.Trim();
            StringBuilder builder = new StringBuilder();
            builder.Append("\r\n                SELECT COUNT(*)\r\n                FROM PT_PrjInfo_ZTB AS Tender\r\n                LEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\n                LEFT JOIN PT_PrjInfo_StateChange AS PrjInfo_StateChange ON Tender.PrjGuid=PrjInfo_StateChange.PrjId AND PrjInfo_StateChange.flowState<>1\r\n                LEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\n                LEFT JOIN (SELECT CodeID,CodeName FROM XPM_Basic_CodeList WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n                ) AS prjType ON Tender.PrjKindClass=CONVERT(VARCHAR(100),prjType.CodeID)");
            string str = GetTenderSqlCondition(prjName, prjCode, buildUnit, prjKindClass, start, end, prjState, flowState, userCode, person, personType, flowStateField);
            builder.Append(str);
            return DBHelper.GetInt(SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), new SqlParameter[0]));
        }

        public static int GetCountAtGiveUp(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType)
        {
            object obj2 = GetCountOrSumTotalAtGiveUp(prjName, prjCode, buildUnit, prjKindClass, start, end, prjState, flowState, userCode, person, personType, "COUNT(*)");
            return ((obj2 == null) ? 0 : Convert.ToInt32(obj2));
        }

        private static object GetCountOrSumTotal(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType, string expression, string OldState, string flowStateName)
        {
            prjName = prjName.Trim();
            prjCode = prjCode.Trim();
            buildUnit = buildUnit.Trim();
            start = start.Trim();
            end = end.Trim();
            person = person.Trim();
            StringBuilder builder = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            builder.Append("\r\n                    SELECT " + expression + "\r\n                FROM PT_PrjInfo_ZTB AS Tender\r\n                LEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\n                LEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\n                LEFT JOIN (SELECT CodeID,CodeName FROM XPM_Basic_CodeList WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n                ) AS prjType ON Tender.PrjKindClass=CONVERT(VARCHAR(100),prjType.CodeID)");
            if (personType != 1)
            {
                if (personType == 2)
                {
                    builder.Append("\r\nLEFT JOIN PT_yhmc AS YHMC ON TDetail.BusinessManager =YHMC.v_yhdm");
                }
                else if ((personType != 3) && (personType == 4))
                {
                    builder.Append("\r\nLEFT JOIN PT_yhmc AS YHMC ON TDetail.PrjDutyPerson =YHMC.v_yhdm ");
                }
            }
            builder.Append("\r\nWHERE 1=1");
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append("\r\nAND Tender.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName));
            }
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.Append("\r\nAND Tender.PrjCode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode));
            }
            if (!string.IsNullOrEmpty(prjKindClass))
            {
                builder.Append(" AND Tender.PrjGuid IN ( \n").Append("\tSELECT PrjGuid FROM PT_PrjInfo_Kind \n").AppendFormat("\tWHERE PrjGuid = Tender.PrjGuid AND PrjKind = @prjKindClass \n", new object[0]).Append(" ) \n");
                list.Add(new SqlParameter("@prjKindClass", prjKindClass));
            }
            if (!string.IsNullOrEmpty(buildUnit))
            {
                builder.Append("\r\nAND Corp.CorpName LIKE '%'+@buildUnit +'%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit));
            }
            if (!string.IsNullOrEmpty(flowStateName))
            {
                builder.Append(" AND tender." + flowStateName + "=1  ");
            }
            if ((flowState != null) && (flowState.Count > 0))
            {
                string search = GetSearch(flowState);
                if (flowState.Contains(-1))
                {
                    builder.AppendFormat(" \r\nAND (TDetail.ProjFlowSate IN ({0}) OR TDetail.ProjFlowSate IS NULL) ", search);
                }
                else
                {
                    builder.AppendFormat(" AND TDetail.ProjFlowSate IN ({0})", search);
                }
            }
            if ((prjState != null) && (prjState.Count > 0))
            {
                string str2 = GetSearch(prjState);
                if (string.IsNullOrEmpty(OldState))
                {
                    builder.AppendFormat("  AND Tender.PrjState IN ({0}) ", str2);
                }
                else if (prjState.Count == 1)
                {
                    if (str2 == "'18'")
                    {
                        builder.AppendFormat(" AND (Tender.PrjState=18 and Tender.OldState='" + OldState + "')", str2);
                    }
                    else
                    {
                        builder.AppendFormat("  AND Tender.PrjState IN ({0}) ", str2);
                    }
                }
                else
                {
                    builder.AppendFormat(" AND (Tender.PrjState IN ({0}) or (Tender.PrjState=18 and Tender.OldState='" + OldState + "'))", str2);
                }
            }
            if (!string.IsNullOrEmpty(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND Tender.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND Tender.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrEmpty(start))
            {
                builder.Append(" AND  TDetail.InputDate >= @start ");
                list.Add(new SqlParameter("@start", start));
            }
            if (!string.IsNullOrEmpty(end))
            {
                builder.Append(" AND TDetail.InputDate <= @end ");
                list.Add(new SqlParameter("@end", end + " 23:59:59"));
            }
            if ((personType == 1) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND  TDetail.ProjPeopleName LIKE'%'+@setUpPerson+'%'", person);
                list.Add(new SqlParameter("@setUpPerson", person));
            }
            if ((personType == 2) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND  YHMC.v_xm LIKE '%'+@businessManager+'%'", person);
                list.Add(new SqlParameter("@businessManager", person));
            }
            if ((personType == 3) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND Tender.PrjManager LIKE '%'+@prjManager+'%'", person);
                list.Add(new SqlParameter("@prjManager", person));
            }
            if ((personType == 4) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND YHMC.v_xm LIKE '%'+@prjDuty+'%'", person);
                list.Add(new SqlParameter("@prjDuty", person));
            }
            return SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), list.ToArray());
        }

        private static object GetCountOrSumTotalAtGiveUp(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType, string expression)
        {
            prjName = prjName.Trim();
            prjCode = prjCode.Trim();
            buildUnit = buildUnit.Trim();
            start = start.Trim();
            end = end.Trim();
            person = person.Trim();
            StringBuilder builder = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            builder.Append("\r\n                    SELECT " + expression + "\r\n                FROM PT_PrjInfo_ZTB AS Tender\r\n                LEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\n                LEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\n                LEFT JOIN (SELECT CodeID,CodeName FROM XPM_Basic_CodeList WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n                ) AS prjType ON Tender.PrjKindClass=CONVERT(VARCHAR(100),prjType.CodeID)");
            if (personType != 1)
            {
                if (personType == 2)
                {
                    builder.Append(" LEFT JOIN PT_yhmc AS YHMC ON TDetail.BusinessManager =YHMC.v_yhdm");
                }
                else if ((personType != 3) && (personType == 4))
                {
                    builder.Append(" LEFT JOIN PT_yhmc AS YHMC ON TDetail.PrjDutyPerson =YHMC.v_yhdm ");
                }
            }
            builder.Append(" WHERE 1=1");
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append(" AND Tender.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName));
            }
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.Append(" AND Tender.PrjCode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode));
            }
            if (!string.IsNullOrEmpty(prjKindClass))
            {
                builder.Append(" AND Tender.PrjGuid IN ( \n").Append("\tSELECT PrjGuid FROM PT_PrjInfo_Kind \n").AppendFormat("\tWHERE PrjGuid = Tender.PrjGuid AND PrjKind = @prjKindClass \n", new object[0]).Append(" ) \n");
                list.Add(new SqlParameter("@prjKindClass", prjKindClass));
            }
            if (!string.IsNullOrEmpty(buildUnit))
            {
                builder.Append(" AND Corp.CorpName LIKE '%'+@buildUnit +'%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit));
            }
            builder.Append(" AND ((TDetail.ProjFlowSate in(-1,-2,-3) and Tender.InitiateFlowState=-1 and Tender.PftFlowState=-1) or (TDetail.ProjFlowSate=1 and Tender.InitiateFlowState in(-1,-2,-3) and Tender.PftFlowState=-1) or (TDetail.ProjFlowSate=1 and Tender.InitiateFlowState=1 and Tender.PftFlowState in(-1,-2,-3)) or (TDetail.ProjFlowSate=1 and Tender.InitiateFlowState=1 and Tender.PftFlowState=1)) ");
            if ((prjState != null) && (prjState.Count > 0))
            {
                string searchAtGiveUp = GetSearchAtGiveUp(prjState);
                builder.AppendFormat(" AND Tender.PrjState IN ({0}) ", searchAtGiveUp);
            }
            if (!string.IsNullOrEmpty(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND Tender.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND Tender.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrEmpty(start))
            {
                builder.Append(" AND  TDetail.InputDate >= @start ");
                list.Add(new SqlParameter("@start", start));
            }
            if (!string.IsNullOrEmpty(end))
            {
                builder.Append(" AND TDetail.InputDate <= @end ");
                list.Add(new SqlParameter("@end", end + " 23:59:59"));
            }
            if ((personType == 1) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND  TDetail.ProjPeopleName LIKE'%'+@setUpPerson+'%'", person);
                list.Add(new SqlParameter("@setUpPerson", person));
            }
            if ((personType == 2) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND  YHMC.v_xm LIKE '%'+@businessManager+'%'", person);
                list.Add(new SqlParameter("@businessManager", person));
            }
            if ((personType == 3) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND Tender.PrjManager LIKE '%'+@prjManager+'%'", person);
                list.Add(new SqlParameter("@prjManager", person));
            }
            if ((personType == 4) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND YHMC.v_xm LIKE '%'+@prjDuty+'%'", person);
                list.Add(new SqlParameter("@prjDuty", person));
            }
            return SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static DataTable GetDtblProjectCode(string tableName, string prjCode)
        {
            DataTable table = new DataTable();
            return SqlHelper.ExecuteQuery(CommandType.Text, "SELECT PrjCode FROM " + tableName + " WHERE PrjCode like '%" + prjCode + "%'", null);
        }

        public static DataTable GetFlowStateSummarizingInfo(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string setUpPerson, string businessManager, string prjManager)
        {
            DataTable table = new DataTable();
            StringBuilder builder = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            builder.Append("\r\nSELECT * FROM (\r\n--100 代表未知状态,FlowState=null\r\nSELECT ISNULL(ProjFlowSate,100) AS ProjFlowSate,COUNT(ProjFlowSate) AS FCount \r\nFROM PT_PrjInfo_ZTB AS Tender\r\nLEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\nLEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\nLEFT JOIN (SELECT CodeID,CodeName FROM XPM_Basic_CodeList WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n) AS prjType ON Tender.PrjKindClass=CONVERT(VARCHAR(100),prjType.CodeID)\r\nLEFT JOIN (SELECT * FROM Basic_CodeList WHERE TypeCode='ProjectState') AS CListZTB ON Tender.PrjState=CListZTB.ItemCode\r\n--项目经理\r\n--LEFT JOIN PT_yhmc AS YHMC1 ON Tender.PrjManager =YHMC1.v_yhdm\r\n--项目跟进人\r\nLEFT JOIN PT_yhmc AS YHMC2 ON TDetail.BusinessManager =YHMC2.v_yhdm");
            builder.Append("\r\nWHERE 1=1 ");
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append("\r\nAND Tender.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjCode))
            {
                builder.Append("\r\nAND Tender.PrjCode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjKindClass))
            {
                builder.Append("\r\nAND Tender.PrjKindClass = @prjKindClass  ");
                list.Add(new SqlParameter("@prjKindClass", prjKindClass));
            }
            if (!string.IsNullOrWhiteSpace(buildUnit))
            {
                builder.Append("\r\nAND Corp.CorpName LIKE '%'+ @buildUnit + '%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit.Trim()));
            }
            if ((flowState != null) && (flowState.Count > 0))
            {
                string search = GetSearch(flowState);
                if (flowState.Contains(-1))
                {
                    builder.AppendFormat(" \r\nAND (TDetail.ProjFlowSate IN ({0}) OR TDetail.ProjFlowSate IS NULL) ", search);
                }
                else
                {
                    builder.AppendFormat(" \r\nAND TDetail.ProjFlowSate IN ({0})", search);
                }
            }
            if (!string.IsNullOrWhiteSpace(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND Tender.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND Tender.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrWhiteSpace(start))
            {
                builder.Append("\r\nAND TDetail.InputDate >= @start ");
                list.Add(new SqlParameter("@start", start.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(end))
            {
                builder.Append("\r\nAND  TDetail.InputDate <= @end ");
                list.Add(new SqlParameter("@end", end.Trim() + " 23:59:59"));
            }
            if ((prjState != null) && (prjState.Count > 0))
            {
                string str2 = GetSearch(prjState);
                builder.AppendFormat(" \r\nAND Tender.PrjState IN ({0}) ", str2);
            }
            if (!string.IsNullOrWhiteSpace(setUpPerson))
            {
                builder.Append("\r\nAND  TDetail.ProjPeopleName LIKE '%'+@setUpPerson+'%'");
                list.Add(new SqlParameter("@setUpPerson", setUpPerson.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(businessManager))
            {
                builder.Append("\r\nAND  YHMC2.v_xm LIKE '%' +@businessManager+ '%'");
                list.Add(new SqlParameter("@businessManager", businessManager.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjManager))
            {
                builder.Append("\r\nAND Tender.PrjManager LIKE '%' +@prjManager+ '%'");
                list.Add(new SqlParameter("@prjManager", prjManager.Trim()));
            }
            builder.Append("\r\nGROUP BY TDetail.ProjFlowSate\r\n) AS FlowStateInfo \r\nPIVOT\r\n(\r\n MAX(FlowStateInfo.FCount) FOR FlowStateInfo.ProjFlowSate IN ([100],[-3],[-2],[-1],[0],[1])\r\n) AS FlowState");
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static DataTable GetOwnerInfo(string ownerName)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("SELECT LinkMan,Telephone,Address FROM XPM_Basic_ContactCorp WHERE CorpName='{0}'", ownerName);
            DataTable table = new DataTable();
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), new SqlParameter[0]);
        }

        public static DataTable GetPartTender(string guid, string part, string userCode)
        {
            DataTable table = new DataTable();
            StringBuilder builder = new StringBuilder();
            builder.Append("\r\n\r\n--DECLARE @prjGuid VARCHAR(100),@userCode VARCHAR(100)\r\n--SET @prjGuid='0B4A47C2-681F-480F-ACA5-0492FBF0A78A'\r\n--SET @userCode='00000000'\r\n\r\nSELECT \r\nTender.PrjManager --项目经理\r\n,Tender.PrjManager AS PrjManagerName --项目经理");
            if ((part == ProjectParameter.Initiate) || (part == ProjectParameter.InitiateFail))
            {
                builder.Append("\r\n--启动\r\n,TDetail.ProjStartDate  --报名通过时间\r\n,TDetail.ProjApplyDate --报名时间\r\n--,TDetail.BusinessManager --业务跟进人\r\n--,Yh2.v_xm AS BusinessManagerName --业务跟进人\r\n,TDetail.PrjDutyPerson --项目项目跟踪人 \r\n,Yh4.v_xm AS PrjDutyPersonName --项目跟踪人名称\r\n,TDetail.ProjStartRemark --启动备注");
            }
            else if (part == ProjectParameter.Bid)
            {
                builder.Append("\r\n--投标\r\n,TDetail.ProjTenderBeginDate --开标时间\r\n,TDetail.TenderCeilingPrice --最高限价\r\n,TDetail.TenderUnit --单位\r\n,TDetail.TenderQuote --报价\r\n,TDetail.TenderAppraiseMethod --评比方法\r\n,TDetail.TenderAverage --平均价\r\n,TDetail.ProjTenderCostContent --投标现场费内容\r\n,TDetail.ProjTenderAnswerDate --投标答疑时间\r\n,TDetail.ProjTenderEarnestMoney --投标保证金\r\n,TDetail.ProjTenderPayWay --保证金缴纳方式\r\n,TDetail.ProjTenderContent --投标标书内容\r\n,TDetail.ProjTenderRemark   --投标备注\r\n,TDetail.TenderProspect     --现场勘察时间\r\n,TDetail.TenderReadOne      --投标阅知人\r\n,(SELECT v_xm FROM PT_yhmc WHERE v_yhdm = TDetail.TenderReadOne) AS TReadOneName --投标阅知人名称\r\n                ");
            }
            else if (part == ProjectParameter.WinBid)
            {
                builder.Append("\r\n--中标\r\n,TDetail.SuccessBidDate --中标时间\r\n,TDetail.SuccessBidPrice --中标价格\r\n,TDetail.SuccessBidRemark --中标备注");
            }
            else if (part == ProjectParameter.OutBid)
            {
                builder.Append("\r\n--落标\r\n,TDetail.OutBidDate --落标时间\r\n,TDetail.OutBidIsReturn  --落标保证金是否退取\r\n,TDetail.OutBidRemark  --落标备注");
            }
            else if (part == ProjectParameter.Prequalification)
            {
                builder.Append("\r\n--资格预审\r\n,TDetail.ProjApplyDate --报名日期\r\n,TDetail.ProjApprovalDate --预审日期\r\n,TDetail.ProjTenderDate  --投标日期\r\n,TDetail.ProjRegistDeadline --登记期限\r\n,TDetail.PrequalificationRequire --资格预审要求\r\n,TDetail.ProgAgent --经办人\r\n,TDetail.QualificationMargin    --预审保证金\r\n,TDetail.QualificationReadOne   --预审阅知人\r\n,(SELECT v_xm FROM PT_yhmc WHERE v_yhdm = TDetail.QualificationReadOne) AS QReadOneName --预审阅知人名称\r\n,Yh3.v_xm AS ProgAgentName --经办人名称\r\n--,TDetail.PrjDutyPerson --项目责任人 \r\n--,Yh4.v_xm AS PrjDutyPersonName --项目责任人名称");
            }
            else if (part == ProjectParameter.QualificationPass)
            {
                builder.Append("\r\n--预审通过\r\n,TDetail.ProjApplyDate --报名日期\r\n,TDetail.ProjApprovalDate --预审日期\r\n,TDetail.ProjTenderDate  --投标日期\r\n,TDetail.ProjRegistDeadline --登记期限\r\n,TDetail.PrequalificationRequire --资格预审要求\r\n,TDetail.ProgAgent --经办人\r\n,TDetail.QualificationMargin    --预审保证金\r\n,Yh3.v_xm AS ProgAgentName --经办人名称\r\n--,TDetail.PrjDutyPerson --项目责任人 \r\n--,Yh4.v_xm AS PrjDutyPersonName --项目责任人名称\r\n,TDetail.QualificationPassDate --预审通过日期\r\n,TDetail.QualificationReadOne  --预审阅知人\r\n,(SELECT v_xm FROM PT_yhmc WHERE v_yhdm = TDetail.QualificationReadOne) AS QReadOneName --预审阅知人名称\r\n,TDetail.QualificationPassReason --说明");
            }
            else if (part == ProjectParameter.QualificationFail)
            {
                builder.Append("\r\n--预审失败\r\n,TDetail.ProjApplyDate --报名日期\r\n,TDetail.ProjApprovalDate --预审日期\r\n,TDetail.ProjTenderDate  --投标日期\r\n,TDetail.ProjRegistDeadline --登记期限\r\n,TDetail.PrequalificationRequire --资格预审要求\r\n,TDetail.ProgAgent --经办人\r\n,TDetail.QualificationMargin    --预审保证金\r\n,TDetail.TenderProspect         --现场勘查时间 \r\n,Yh3.v_xm AS ProgAgentName --经办人名称\r\n--,TDetail.PrjDutyPerson --项目责任人 \r\n--,Yh4.v_xm AS PrjDutyPersonName --项目责任人名称\r\n,TDetail.QualificationFailData --预审失败日期\r\n,TDetail.QualificationReadOne --预审阅知人\r\n,(SELECT v_xm FROM PT_yhmc WHERE v_yhdm = TDetail.QualificationReadOne) AS QReadOneName --预审阅知人名称\r\n,TDetail.QualificationFailReason --理由");
            }
            builder.Append("\r\nFROM PT_PrjInfo_ZTB AS Tender\r\nLEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\n--JOIN PT_PrjInfo_ZTB_User AS Limit ON Tender.PrjGuid=Limit.PrjGuid\r\n--LEFT JOIN PT_yhmc AS Yh1 ON Tender.PrjManager=Yh1.v_yhdm --项目经理\r\nLEFT JOIN PT_yhmc AS Yh2 ON TDetail.BusinessManager=Yh2.v_yhdm --启动业务跟进人\r\nLEFT JOIN PT_yhmc AS Yh3 ON TDetail.ProgAgent=Yh3.v_yhdm --经办人\r\nLEFT JOIN PT_yhmc AS Yh4 ON TDetail.PrjDutyPerson=Yh4.v_yhdm --项目责任人\r\nWHERE Tender.PrjGuid=@prjGuid --AND Limit.UserCode=@userCode\r\n");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@prjGuid", guid), new SqlParameter("@userCode", userCode) };
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), commandParameters);
        }

        public static string GetPrjState(string prjGuid)
        {
            Guid guid = new Guid(prjGuid);
            using (pm2Entities entities = new pm2Entities())
            {
                return (from m in entities.PT_PrjInfo
                    join n in entities.Basic_CodeList on m.PrjState equals (int?) n.ItemCode into n
                    where (n.TypeCode == "ProjectState") && (m.PrjGuid == guid)
                    select n.ItemName).FirstOrDefault<string>();
            }
        }

        public static string GetProjectName(string prjGuid)
        {
            Guid guid = new Guid(prjGuid);
            using (pm2Entities entities = new pm2Entities())
            {
                return (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjGuid == guid
                    select m.PrjName).FirstOrDefault<string>();
            }
        }

        public static string GetProjectState(string prjId)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                Guid guid = new Guid(prjId);
                string str = string.Empty;
                int? nullable = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjGuid == guid
                    select m.PrjState).FirstOrDefault<int?>();
                if (nullable.HasValue)
                {
                    str = nullable.ToString();
                }
                return str;
            }
        }

        private static string GetSearch(List<int> obj)
        {
            string str = "";
            List<int> list = new List<int>(obj.ToArray());
            if (list.Count > 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int num2 = list[i];
                    if (num2 == 0x12)
                    {
                        list.RemoveAt(i);
                        break;
                    }
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                foreach (int num3 in list)
                {
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, "'", num3, "'," });
                }
            }
            else
            {
                str = "''";
            }
            return str.Substring(0, str.Length - 1);
        }

        private static string GetSearchAtGiveUp(List<int> obj)
        {
            string str = "";
            if ((obj != null) && (obj.Count > 0))
            {
                foreach (int num in obj)
                {
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, "'", num, "'," });
                }
            }
            else
            {
                str = "''";
            }
            return str.Substring(0, str.Length - 1);
        }

        public static string GetStartDate(string prjGuid)
        {
            string str = string.Empty;
            using (pm2Entities entities = new pm2Entities())
            {
                Guid guid = new Guid(prjGuid);
                DateTime? nullable = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjGuid == guid
                    select m.StartDate).FirstOrDefault<DateTime?>();
                if (nullable.HasValue)
                {
                    str = nullable.Value.ToString("yyyy-M-d");
                }
            }
            return str;
        }

        public static DataTable GetSummarizingInfo(string prjCode, string prjName, string prjType, string prjManagaer, string businessManager, string setUpPerson, string prjState, string startDate, string endDate, string buildUnit, string ProjPeopleDep, string dropPrjProperty, string principal, string userCode, string PrjStateChangeTimeStart, string PrjStateChangeTimeEnd)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM(\r\nSELECT ZTB.PrjState,COUNT(ZTB.PrjState) AS CountPrjState\r\n\tFROM PT_PrjInfo_ZTB ZTB \r\n\tLEFT JOIN PT_PrjInfo_ZTB_Detail Detail ON ZTB.PrjGuid=Detail.PrjGuid  \r\n\tLEFT JOIN (SELECT CodeId,CodeName FROM XPM_Basic_CodeList WHERE TYPEID=\r\n\t\t(SELECT TypeId FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND ISVALID='1') CodeList  \r\n\t\tON ZTB.PrjKindClass=CAST(CodeList.CodeId AS NVARCHAR(30))  \r\n\tLEFT JOIN XPM_Basic_ContactCorp Corp ON ZTB.OwnerCode=Corp.CorpID \r\n\tLEFT JOIN (SELECT ItemCode,ItemName FROM Basic_CodeList WHERE TypeCode='ProjectState') CostList  \r\n\t\tON ZTB.PrjState=CostList.ItemCode \r\n\tLEFT JOIN Pt_PrjInfo PrjInfo ON ZTB.PrjGuid=PrjInfo.PrjGuid \r\n\tLEFT JOIN (SELECT ItemCode,ItemName FROM Basic_CodeList WHERE TypeCode='ProjectState') CostPrjList  \r\n\t\tON PrjInfo.PrjState=CostPrjList.ItemCode \r\n    --项目经理\r\n\t--LEFT JOIN PT_yhmc AS YHMC1 ON ZTB.PrjManager =YHMC1.v_yhdm\r\n\t--项目跟进人\r\n\tLEFT JOIN PT_yhmc AS YHMC2 ON Detail.BusinessManager =YHMC2.v_yhdm\r\n\tWHERE  ZTB.PrjState!=1 ");
            if (!string.IsNullOrEmpty(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND ZTB.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND ZTB.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrWhiteSpace(prjCode))
            {
                builder.Append(" AND ZTB.Prjcode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append(" AND ZTB.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjType))
            {
                builder.Append(" AND ZTB.PrjKindClass = @prjType ");
                list.Add(new SqlParameter("@prjType", prjType));
            }
            if (!string.IsNullOrWhiteSpace(prjManagaer))
            {
                builder.Append(" AND ZTB.PrjManager LIKE '%'+@prjManagaer+'%' ");
                list.Add(new SqlParameter("@prjManagaer", prjManagaer.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjState))
            {
                builder.Append(" AND ZTB.prjState = @prjState ");
                list.Add(new SqlParameter("@prjState", prjState));
            }
            if (!string.IsNullOrWhiteSpace(startDate))
            {
                builder.Append(" AND InputDate >= @startDate ");
                list.Add(new SqlParameter("@startDate", startDate.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(endDate))
            {
                builder.Append(" AND InputDate <= @endDate ");
                list.Add(new SqlParameter("@endDate", endDate.Trim() + " 23:59:59"));
            }
            if (!string.IsNullOrWhiteSpace(buildUnit))
            {
                builder.Append(" AND CorpName LIKE  '%'+  @buildUnit +'%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(setUpPerson))
            {
                builder.Append(" AND ProjPeopleName LIKE  '%'+  @setUpPerson +'%' ");
                list.Add(new SqlParameter("@setUpPerson", setUpPerson.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(businessManager))
            {
                builder.Append(" AND YHMC2.v_xm LIKE  '%'+  @businessManager +'%' ");
                list.Add(new SqlParameter("@businessManager", businessManager.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(ProjPeopleDep))
            {
                builder.Append(" AND Detail.ProjPeopleDep LIKE '%'+ @ProjPeopleDep +'%'");
                list.Add(new SqlParameter("@ProjPeopleDep", ProjPeopleDep.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(dropPrjProperty))
            {
                builder.Append(" AND Detail.PrjProperty LIKE '%'+ @dropPrjProperty +'%'");
                list.Add(new SqlParameter("@dropPrjProperty", dropPrjProperty.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(principal))
            {
                builder.Append(" AND ZTB.WorkUnit LIKE '%'+ @principal +'%'");
                list.Add(new SqlParameter("@principal", principal.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(PrjStateChangeTimeStart))
            {
                builder.AppendFormat(" AND PrjStateChangeTime >='{0}' ", PrjStateChangeTimeStart);
            }
            if (!string.IsNullOrWhiteSpace(PrjStateChangeTimeEnd))
            {
                builder.AppendFormat(" AND PrjStateChangeTime <='{0}' ", PrjStateChangeTimeEnd + " 23:59:59");
            }
            list.Add(new SqlParameter("@userCode", userCode));
            builder.Append("\r\n\t\t\t\t\tGROUP BY ZTB.PrjState\r\n\t\t\t\t)AS PrjStateInfo\r\n\t\t\t\t PIVOT(\r\n\t\t\t\t\tMAX(PrjStateInfo.CountPrjState) FOR PrjStateInfo.PrjState IN ([2],[3],[4],[5],[6],[14],[15],[16],[18],[19])\r\n\t\t\t\t) AS PrjStatColumns\r\n\t\t\t");
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static decimal GetSumTotal(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType, string OldState, string flowStateName)
        {
            object obj2 = GetCountOrSumTotal(prjName, prjCode, buildUnit, prjKindClass, start, end, prjState, flowState, userCode, person, personType, "ISNULL(SUM(ISNULL(PrjCost,0)),0)", OldState, flowStateName);
            return ((obj2 == null) ? 0M : decimal.Parse(obj2.ToString()));
        }

        public static decimal GetSumTotalAtChgState(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType, string flowStateField)
        {
            prjName = prjName.Trim();
            prjCode = prjCode.Trim();
            buildUnit = buildUnit.Trim();
            start = start.Trim();
            end = end.Trim();
            person = person.Trim();
            StringBuilder builder = new StringBuilder();
            builder.Append("\r\n                SELECT ISNULL(SUM(ISNULL(PrjCost,0)),0)\r\n                FROM PT_PrjInfo_ZTB AS Tender\r\n                LEFT JOIN PT_PrjInfo_ZTB_Detail AS TDetail ON Tender.PrjGuid=TDetail.PrjGuid\r\n                LEFT JOIN XPM_Basic_ContactCorp AS Corp ON Tender.OwnerCode=CONVERT(VARCHAR(20),Corp.CorpID)\r\n                LEFT JOIN (SELECT CodeID,CodeName FROM XPM_Basic_CodeList WHERE TypeID=(SELECT TypeID FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND IsValid='1'\r\n                ) AS prjType ON Tender.PrjKindClass=CONVERT(VARCHAR(100),prjType.CodeID)");
            string str = GetTenderSqlCondition(prjName, prjCode, buildUnit, prjKindClass, start, end, prjState, flowState, userCode, person, personType, flowStateField);
            builder.Append(str);
            return DBHelper.GetDecimal(SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), new SqlParameter[0]));
        }

        public static decimal GetSumTotalAtGiveUp(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType)
        {
            object obj2 = GetCountOrSumTotalAtGiveUp(prjName, prjCode, buildUnit, prjKindClass, start, end, prjState, flowState, userCode, person, personType, "ISNULL(SUM(ISNULL(PrjCost,0)),0)");
            return ((obj2 == null) ? 0M : decimal.Parse(obj2.ToString()));
        }

        public static DataTable GetTenderPrivilege(string prjCode, string prjName, string startDate, string endDate, string prjManageName, string prjState, string userCode, string kind, string setUpDep, string prjProperty, int pageNo, int pageSize)
        {
            new DataTable();
            List<SqlParameter> list = new List<SqlParameter>();
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("\r\n\t\t\t\tSELECT TOP({0}) * FROM (\r\n\t\t\t\t\tSELECT ROW_NUMBER() OVER(ORDER BY V.InputDate DESC) AS Num, V.* FROM vTender AS V WHERE 1 = 1 \r\n\t\t\t", pageSize);
            string str = GenerateGetTenderPrivilegeSql(prjCode, prjName, startDate, endDate, prjManageName, prjState, userCode, kind, setUpDep, prjProperty);
            builder.Append(str);
            builder.AppendFormat(") AS T WHERE T.Num > ({0} - 1) * {1}", pageNo, pageSize);
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static int GetTenderPrivilegeCount(string prjCode, string prjName, string startDate, string endDate, string prjManageName, string prjState, string userCode, string kind, string setUpDep, string prjProperty)
        {
            StringBuilder builder = new StringBuilder();
            string str = GenerateGetTenderPrivilegeSql(prjCode, prjName, startDate, endDate, prjManageName, prjState, userCode, kind, setUpDep, prjProperty);
            builder.Append("SELECT COUNT(*) FROM vTender AS V WHERE 1 = 1 ");
            builder.Append(str);
            return DBHelper.GetInt(SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), null));
        }

        public static DataTable GetTenderReport(string prjCode, string prjName, string prjType, string prjManager, string dutyPersonName, string setUpPerson, string prjState, string startDate, string endDate, string buildUnit, string ProjPeopleDep, string dropPrjProperty, string principal, int pageNo, int pageSize, string userCode, string PrjStateChangeTimeStart, string PrjStateChangeTimeEnd)
        {
            StringBuilder builder = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            builder.Append("SELECT  * FROM(\r\n    SELECT Row_Number() OVER(ORDER BY InputDate DESC) AS No,ZTB.PrjGuid,ZTB.PrjCode,ZTB.PrjName,ZTB.PrjManager AS PrjManagerName,ZTB.WorkUnit\r\n--\t,ZTB.PrjKindClass\r\n\t,ISNULL(CodeName,'') CodeName\r\n\t,ISNULL(CorpName,'') AS CorpName\r\n\t,CONVERT(DECIMAL(18,3),ISNULL(ZTB.PrjCost,0)) AS PrjCost\r\n   \t,ISNULL(Detail.SuccessBidPrice, 0.000) AS SuccessBidPrice           --中标价格\r\n\t,CASE ISNULL(CostPrjList.ItemName,'')\r\n\t\tWHEN '' THEN  CostList.ItemName\r\n\t\tELSE\r\n\t\t\tCASE PrjInfo.PrjState\r\n\t\t\t\tWHEN '5' THEN CostList.ItemName\r\n\t\t\tELSE\r\n\t\t\t\tCASE ZTB.PrjState\t\r\n\t\t\t\t\tWHEN '5' THEN(CostList.ItemName+'('+CostPrjList.ItemName+')')\r\n\t\t\t\t\tELSE\r\n\t\t\t\t\t\tCostList.ItemName\r\n\t\t\t\tEND\r\n\t\t\tEND\t\r\n\tEND AS ItemName\r\n    ,ISNULL((SELECT TOP(1) ProfessionalCost FROM PT_PrjInfo_Kind WHERE PrjGuid = ZTB.PrjGuid AND PrjKind = @prjType ),0) AS ProfessionalCost      --专业造价\r\n\t,CONVERT(VARCHAR(20),Detail.InputDate,23) AS InputDate,ISNULL(YHMC3.v_xm,'') PrjDutyName\r\n\t,CASE ZTB.PrjState WHEN '2' THEN '1' END AS 'PrjSetUp'\r\n\t,CASE ZTB.PrjState WHEN '3' THEN '1' END AS 'PrjStart' \r\n    ,(CASE WHEN ZTB.PrjState='14' OR ZTB.PrjState='15' OR ZTB.PrjState='16' THEN '1'  END) as 'PrjYs'\r\n    --,(case when ZTB.PrjState='14' then '1' when ZTB.PrjState='15' then '2' when ZTB.PrjState='16' then '3'  end) as 'PrjYs'\r\n\t,CASE ZTB.PrjState WHEN '4' THEN '1' END AS 'PrjTender'\r\n\t,CASE ZTB.PrjState WHEN '5' THEN '1' END AS 'Winbid'\r\n\t,CASE ZTB.PrjState WHEN '6' THEN '1' END AS 'Outbid' \r\n    ,CASE ZTB.PrjState WHEN '19' THEN '1' END AS 'PrjStartNO'\r\n    ,CASE ZTB.PrjState WHEN '18' THEN '1' END AS 'PrjGiveUp'  \r\n\tFROM PT_PrjInfo_ZTB ZTB \r\n\tLEFT JOIN PT_PrjInfo_ZTB_Detail Detail ON ZTB.PrjGuid=Detail.PrjGuid  \r\n\tLEFT JOIN (SELECT CodeId,CodeName FROM XPM_Basic_CodeList WHERE TYPEID=\r\n\t\t(SELECT TypeId FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND ISVALID='1') CodeList  \r\n\t\tON ZTB.PrjKindClass=CAST(CodeList.CodeId AS NVARCHAR(30))  \r\n\tLEFT JOIN XPM_Basic_ContactCorp Corp ON ZTB.OwnerCode=Corp.CorpID \r\n\tLEFT JOIN (SELECT ItemCode,ItemName FROM Basic_CodeList WHERE TypeCode='ProjectState') CostList  \r\n\t\tON ZTB.PrjState=CostList.ItemCode \r\n\tLEFT JOIN Pt_PrjInfo PrjInfo ON ZTB.PrjGuid=PrjInfo.PrjGuid \r\n\tLEFT JOIN (SELECT ItemCode,ItemName FROM Basic_CodeList WHERE TypeCode='ProjectState') CostPrjList  \r\n\t\tON PrjInfo.PrjState=CostPrjList.ItemCode \r\n\t--项目跟进人\r\n\tLEFT JOIN PT_yhmc AS YHMC2 ON Detail.BusinessManager =YHMC2.v_yhdm\r\n    --项目跟踪人\r\n\tLEFT JOIN PT_yhmc AS YHMC3 ON Detail.PrjDutyPerson =YHMC3.v_yhdm\r\n\tWHERE  ZTB.PrjState!=1 ");
            if (!string.IsNullOrEmpty(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND ZTB.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND ZTB.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrWhiteSpace(prjCode))
            {
                builder.Append(" AND ZTB.Prjcode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append(" AND ZTB.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjType))
            {
                builder.Append(" AND ZTB.PrjGuid IN ( \n").Append("\tSELECT PrjGuid FROM PT_PrjInfo_Kind \n").AppendFormat("\tWHERE PrjGuid = ZTB.PrjGuid AND PrjKind = @prjType \n", new object[0]).Append(" ) \n");
            }
            if (!string.IsNullOrWhiteSpace(prjManager))
            {
                builder.Append(" AND ZTB.PrjManager LIKE '%'+@prjManagaer+'%' ");
                list.Add(new SqlParameter("@prjManagaer", prjManager.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjState))
            {
                builder.Append(" AND ZTB.prjState = @prjState ");
                list.Add(new SqlParameter("@prjState", prjState));
            }
            if (!string.IsNullOrWhiteSpace(startDate))
            {
                builder.Append(" AND InputDate >= @startDate ");
                list.Add(new SqlParameter("@startDate", startDate.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(endDate))
            {
                builder.Append(" AND InputDate <= @endDate ");
                list.Add(new SqlParameter("@endDate", endDate.Trim() + " 23:59:59"));
            }
            if (!string.IsNullOrWhiteSpace(buildUnit))
            {
                builder.Append(" AND CorpName LIKE  '%'+  @buildUnit +'%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(setUpPerson))
            {
                builder.Append(" AND ProjPeopleName LIKE  '%'+  @setUpPerson +'%' ");
                list.Add(new SqlParameter("@setUpPerson", setUpPerson.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(dutyPersonName))
            {
                builder.Append(" AND YHMC3.v_xm LIKE  '%'+  @dutyPersonName +'%' ");
                list.Add(new SqlParameter("@dutyPersonName", dutyPersonName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(ProjPeopleDep))
            {
                builder.Append(" AND Detail.ProjPeopleDep LIKE '%'+ @ProjPeopleDep +'%'");
                list.Add(new SqlParameter("@ProjPeopleDep", ProjPeopleDep.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(dropPrjProperty))
            {
                builder.Append(" AND Detail.PrjProperty LIKE '%'+ @dropPrjProperty +'%'");
                list.Add(new SqlParameter("@dropPrjProperty", dropPrjProperty.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(principal))
            {
                builder.Append(" AND ZTB.WorkUnit LIKE '%'+ @principal +'%'");
                list.Add(new SqlParameter("@principal", principal.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(PrjStateChangeTimeStart))
            {
                builder.AppendFormat(" AND PrjStateChangeTime >='{0}' ", PrjStateChangeTimeStart);
            }
            if (!string.IsNullOrWhiteSpace(PrjStateChangeTimeEnd))
            {
                builder.AppendFormat(" AND PrjStateChangeTime <='{0}' ", PrjStateChangeTimeEnd + " 23:59:59");
            }
            builder.Append(" ) AS PrjInfo WHERE  No BETWEEN (@pageNo-1)*@pageSize+1 AND @pageNo*@pageSize");
            list.Add(new SqlParameter("@prjType", prjType));
            list.Add(new SqlParameter("@userCode", userCode));
            list.Add(new SqlParameter("@pageNo", pageNo));
            list.Add(new SqlParameter("@pageSize", pageSize));
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static int GetTenderReportCount(string prjCode, string prjName, string prjType, string prjManager, string businessManager, string setUpPerson, string prjState, string startDate, string endDate, string buildUnit, string ProjPeopleDep, string dropPrjProperty, string principal, string userCode, string PrjStateChangeTimeStart, string PrjStateChangeTimeEnd)
        {
            object obj2 = GetTenderReportSumTotalOrCount(prjCode, prjName, prjType, prjManager, businessManager, setUpPerson, prjState, startDate, endDate, buildUnit, ProjPeopleDep, dropPrjProperty, principal, userCode, false, PrjStateChangeTimeStart, PrjStateChangeTimeEnd);
            return ((obj2 == null) ? 0 : Convert.ToInt32(obj2));
        }

        public static decimal GetTenderReportSumTotal(string prjCode, string prjName, string prjType, string prjManagaer, string businessManager, string setUpPerson, string prjState, string startDate, string endDate, string buildUnit, string ProjPeopleDep, string dropPrjProperty, string principal, string userCode, string PrjStateChangeTimeStart, string PrjStateChangeTimeEnd)
        {
            object obj2 = GetTenderReportSumTotalOrCount(prjCode, prjName, prjType, prjManagaer, businessManager, setUpPerson, prjState, startDate, endDate, buildUnit, ProjPeopleDep, dropPrjProperty, principal, userCode, true, PrjStateChangeTimeStart, PrjStateChangeTimeEnd);
            return ((obj2 == null) ? 0M : decimal.Parse(obj2.ToString()));
        }

        private static object GetTenderReportSumTotalOrCount(string prjCode, string prjName, string prjType, string prjManager, string dutyPersonName, string setUpPerson, string prjState, string startDate, string endDate, string buildUnit, string ProjPeopleDep, string dropPrjProperty, string principal, string userCode, bool isSumTotal, string PrjStateChangeTimeStart, string PrjStateChangeTimeEnd)
        {
            StringBuilder builder = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            if (isSumTotal)
            {
                builder.Append("SELECT CONVERT(DECIMAL(18,3),SUM(ISNULL(ZTB.PrjCost,0))) ");
            }
            else
            {
                builder.Append("SELECT COUNT(*) ");
            }
            builder.Append("\r\n\tFROM PT_PrjInfo_ZTB ZTB  \r\n\tLEFT JOIN PT_PrjInfo_ZTB_Detail Detail ON ZTB.PrjGuid=Detail.PrjGuid  \r\n\tLEFT JOIN (SELECT CodeId,CodeName FROM XPM_Basic_CodeList WHERE TYPEID=\r\n\t\t(SELECT TypeId FROM XPM_Basic_CodeType WHERE SignCode='ProjectType') AND ISVALID='1') CodeList  \r\n\t\tON ZTB.PrjKindClass=CAST(CodeList.CodeId AS NVARCHAR(30))  \r\n\tLEFT JOIN XPM_Basic_ContactCorp Corp ON ZTB.OwnerCode=Corp.CorpID \r\n\tLEFT JOIN (SELECT ItemCode,ItemName FROM Basic_CodeList WHERE TypeCode='ProjectState') CostList  \r\n\t\tON ZTB.PrjState=CostList.ItemCode \r\n\tLEFT JOIN Pt_PrjInfo PrjInfo ON ZTB.PrjGuid=PrjInfo.PrjGuid \r\n\tLEFT JOIN (SELECT ItemCode,ItemName FROM Basic_CodeList WHERE TypeCode='ProjectState') CostPrjList  \r\n\t\tON PrjInfo.PrjState=CostPrjList.ItemCode \r\n    --项目经理\r\n\t--LEFT JOIN PT_yhmc AS YHMC1 ON ZTB.PrjManager =YHMC1.v_yhdm\r\n\t--项目跟进人\r\n\tLEFT JOIN PT_yhmc AS YHMC2 ON Detail.BusinessManager =YHMC2.v_yhdm\r\n    --项目跟踪人\r\n\tLEFT JOIN PT_yhmc AS YHMC3 ON Detail.PrjDutyPerson =YHMC3.v_yhdm\r\n\r\n\tWHERE  ZTB.PrjState!=1 ");
            if (!string.IsNullOrEmpty(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND ZTB.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND ZTB.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.Append(" AND ZTB.Prjcode LIKE '%'+@prjCode+'%' ");
                list.Add(new SqlParameter("@prjCode", prjCode.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.Append(" AND ZTB.PrjName LIKE '%'+@prjName+'%' ");
                list.Add(new SqlParameter("@prjName", prjName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjType))
            {
                list.Add(new SqlParameter("@prjType", prjType));
                builder.Append(" AND ZTB.PrjGuid IN ( \n").Append("\tSELECT PrjGuid FROM PT_PrjInfo_Kind \n").AppendFormat("\tWHERE PrjGuid = ZTB.PrjGuid AND PrjKind = @prjType \n", new object[0]).Append(" ) \n");
            }
            if (!string.IsNullOrWhiteSpace(prjManager))
            {
                builder.Append(" AND ZTB.PrjManager LIKE '%'+@prjManagaer+'%' ");
                list.Add(new SqlParameter("@prjManagaer", prjManager.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(prjState))
            {
                builder.Append(" AND ZTB.prjState = @prjState ");
                list.Add(new SqlParameter("@prjState", prjState));
            }
            if (!string.IsNullOrWhiteSpace(startDate))
            {
                builder.Append(" AND InputDate >= @startDate ");
                list.Add(new SqlParameter("@startDate", startDate.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(endDate))
            {
                builder.Append(" AND InputDate <= @endDate ");
                list.Add(new SqlParameter("@endDate", endDate.Trim() + " 23:59:59"));
            }
            if (!string.IsNullOrWhiteSpace(buildUnit))
            {
                builder.Append(" AND CorpName LIKE  '%'+  @buildUnit +'%' ");
                list.Add(new SqlParameter("@buildUnit", buildUnit.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(setUpPerson))
            {
                builder.Append(" AND ProjPeopleName LIKE  '%'+  @setUpPerson +'%' ");
                list.Add(new SqlParameter("@setUpPerson", setUpPerson.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(dutyPersonName))
            {
                builder.Append(" AND YHMC3.v_xm LIKE  '%'+  @dutyPersonName +'%' ");
                list.Add(new SqlParameter("@dutyPersonName", dutyPersonName.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(ProjPeopleDep))
            {
                builder.Append(" AND Detail.ProjPeopleDep LIKE '%'+ @ProjPeopleDep +'%'");
                list.Add(new SqlParameter("@ProjPeopleDep", ProjPeopleDep.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(dropPrjProperty))
            {
                builder.Append(" AND Detail.PrjProperty LIKE '%'+ @dropPrjProperty +'%'");
                list.Add(new SqlParameter("@dropPrjProperty", dropPrjProperty.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(principal))
            {
                builder.Append(" AND ZTB.WorkUnit LIKE '%'+ @principal +'%'");
                list.Add(new SqlParameter("@principal", principal.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(PrjStateChangeTimeStart))
            {
                builder.AppendFormat(" AND PrjStateChangeTime >='{0}' ", PrjStateChangeTimeStart);
            }
            if (!string.IsNullOrWhiteSpace(PrjStateChangeTimeEnd))
            {
                builder.AppendFormat(" AND PrjStateChangeTime <='{0}' ", PrjStateChangeTimeEnd + " 23:59:59");
            }
            return SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), list.ToArray());
        }

        public static DataTable GetTenders(string code, string name, string setUpPerson, string setUpDep, string kind, string startDate, string endDate, string unitName, string flowState, string property, string userCode, int pageSize, int pageIndex)
        {
            string str = GenerateGetTendersSql(code, name, setUpPerson, setUpDep, kind, startDate, endDate, unitName, flowState, property, userCode);
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("  SELECT TOP({0}) * FROM ( \n", pageSize).Append("      SELECT ROW_NUMBER() OVER(ORDER BY InputDate DESC)AS No,PrjGuid,PrjCode,PrjName,PrjState,StartDate,EndDate,Duration, \n").Append("      ISNULL(PrjCost,0) PrjCost,ProjFlowSate,ISNULL(SuccessBidPrice,0) SuccessBidPrice,InputDate,ProjPeopleName,ProjPeopleDep, \n").Append("      PrjProperty,PropertyName,WorkUnitName,StateText FROM vTender \n").Append("      WHERE 1 = 1 ").Append(str).Append("      ) v \n").AppendFormat("  WHERE No > ({0} - 1) * {1} \n", pageIndex, pageSize);
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), new SqlParameter[0]);
        }

        public static int GetTendersCount(string code, string name, string setUpPerson, string setUpDep, string kind, string startDate, string endDate, string unitName, string flowState, string property, string userCode)
        {
            string str = GenerateGetTendersSql(code, name, setUpPerson, setUpDep, kind, startDate, endDate, unitName, flowState, property, userCode);
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT COUNT(*) FROM vTender \n");
            builder.Append(" WHERE 1 = 1 \n");
            builder.Append(str);
            return DBHelper.GetInt(SqlHelper.ExecuteScalar(CommandType.Text, builder.ToString(), new SqlParameter[0]));
        }

        private static string GetTenderSqlCondition(string prjName, string prjCode, string buildUnit, string prjKindClass, string start, string end, List<int> prjState, List<int> flowState, string userCode, string person, int personType, string flowStateField)
        {
            StringBuilder builder = new StringBuilder();
            if (personType == 1)
            {
                builder.Append(" LEFT JOIN PT_yhmc AS YHMC ON TDetail.ProjPeopleName = YHMC.v_yhdm \n");
            }
            else if (personType == 2)
            {
                builder.Append(" LEFT JOIN PT_yhmc AS YHMC ON TDetail.BusinessManager = YHMC.v_yhdm \n");
            }
            else if (personType == 3)
            {
                builder.Append(" LEFT JOIN PT_yhmc AS YHMC ON Tender.PrjManager = YHMC.v_yhdm \n");
            }
            else if (personType == 4)
            {
                builder.Append(" LEFT JOIN PT_yhmc AS YHMC ON TDetail.PrjDutyPerson = YHMC.v_yhdm \n");
            }
            builder.Append(" WHERE 1=1 ");
            if (!string.IsNullOrWhiteSpace(prjName))
            {
                builder.AppendFormat(" AND Tender.PrjName LIKE '%{0}%' \n", prjName.Trim());
            }
            if (!string.IsNullOrEmpty(prjCode))
            {
                builder.AppendFormat(" AND Tender.PrjCode LIKE '%{0}%' \n", prjCode.Trim());
            }
            if (!string.IsNullOrEmpty(prjKindClass))
            {
                builder.Append(" AND Tender.PrjGuid IN ( \n").Append("\tSELECT PrjGuid FROM PT_PrjInfo_Kind \n").AppendFormat("\tWHERE PrjGuid = Tender.PrjGuid AND PrjKind ={0} \n", prjKindClass).Append(" ) \n");
            }
            if (!string.IsNullOrEmpty(buildUnit))
            {
                builder.AppendFormat(" AND Corp.CorpName LIKE '%{0}%' \n", buildUnit);
            }
            if ((flowState != null) && (flowState.Count > 0))
            {
                string search = GetSearch(flowState);
                if (flowState.Contains(-1))
                {
                    builder.AppendFormat(" AND (Tender.{0} IN ({1}) OR Tender.{0} IS NULL) \n", flowStateField, search);
                }
                else
                {
                    builder.AppendFormat(" AND Tender.{0} IN ({1}) \n", flowStateField, search);
                }
            }
            if ((prjState != null) && (prjState.Count > 0))
            {
                string str2 = GetSearch(prjState);
                builder.AppendFormat(" AND Tender.PrjState IN ({0}) \n", str2);
            }
            else
            {
                builder.AppendFormat(" AND Tender.PrjState not IN ('18','5') \n", new object[0]);
            }
            if (!string.IsNullOrEmpty(userCode))
            {
                string[] arr = PrivHelper.GetBusiDataId("project", userCode).ToArray<string>();
                if (arr.Length == 0)
                {
                    builder.AppendFormat(" AND Tender.PrjGuid is null \n", new object[0]);
                }
                else
                {
                    builder.AppendFormat(" AND Tender.PrjGuid IN ({0}) \n", DBHelper.GetInParameterSql(arr));
                }
            }
            if (!string.IsNullOrEmpty(start))
            {
                builder.AppendFormat(" AND  TDetail.InputDate >= '{0}' \n", start);
            }
            if (!string.IsNullOrEmpty(end))
            {
                builder.AppendFormat(" AND TDetail.InputDate <= '{0}' \n", end + " 23:59:59");
            }
            if ((personType == 1) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND  TDetail.ProjPeopleName LIKE '%{0}%' \n", person);
            }
            if ((personType == 2) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND  YHMC.v_xm LIKE '%{0}%' \n", person);
            }
            if ((personType == 3) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND Tender.PrjManager LIKE '%{0}%' \n", person);
            }
            if ((personType == 4) && !string.IsNullOrEmpty(person))
            {
                builder.AppendFormat(" AND YHMC.v_xm LIKE '%{0}%' \n", person);
            }
            return builder.ToString();
        }

        public static DataTable GetUserInfo(string usercode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT  MobilePhoneCode AS Phone,\t\t\t\t\t\t--电话 \n");
            builder.Append("\t    v_xm AS UserName,\t\t\t\t\t\t\t\t\t--用户名 \n");
            builder.Append(" \tdbo.ufnRootDepName(PT_yhmc.i_bmdm) AS CorpName,\t\t--部门 \n");
            builder.Append(" \tdutyName AS Duty\t\t\t\t\t\t--岗位 \n");
            builder.Append("FROM PT_yhmc   \n");
            builder.Append("INNER JOIN PT_DUTY ON PT_yhmc.I_DUTYID = PT_DUTY.I_DUTYID \n");
            builder.Append("WHERE v_yhdm=@UserCode \n");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserCode", usercode) };
            return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), commandParameters);
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
                num = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjCode == prjCode
                    select m).Count<PT_PrjInfo_ZTB>();
            }
            return (num > 0);
        }

        public static bool IsSameName(string prjName)
        {
            int num = 0;
            int num2 = 0;
            using (pm2Entities entities = new pm2Entities())
            {
                num = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjName == prjName
                    select m).Count<PT_PrjInfo_ZTB>();
                num2 = (from m in entities.PT_PrjInfo
                    where m.PrjName == prjName
                    select m).Count<PT_PrjInfo>();
            }
            if ((num <= 0) && (num2 <= 0))
            {
                return false;
            }
            return true;
        }

        private void SetPrjManager(TenderInfo model)
        {
            if (model != null)
            {
                using (pm2Entities entities = new pm2Entities())
                {
                    PT_PrjInfo_ZTB o_ztb = (from m in entities.PT_PrjInfo_ZTB
                        where m.PrjGuid == model.PrjGuid
                        select m).FirstOrDefault<PT_PrjInfo_ZTB>();
                    if (o_ztb != null)
                    {
                        string prjManager = o_ztb.PrjManager;
                        string str = model.PrjManager;
                        o_ztb.PrjManager = str;
                        entities.SaveChanges();
                    }
                }
            }
        }

        public static bool UpdateIsSameCode(string oldCode, string newCode)
        {
            int num = 0;
            using (pm2Entities entities = new pm2Entities())
            {
                num = (from m in entities.PT_PrjInfo_ZTB
                    where (m.PrjCode != oldCode) && (m.PrjCode == newCode)
                    select m).Count<PT_PrjInfo_ZTB>();
            }
            return (num > 0);
        }

        public static bool UpdateIsSameName(string oldName, string newName)
        {
            int num = 0;
            int num2 = 0;
            using (pm2Entities entities = new pm2Entities())
            {
                num = (from m in entities.PT_PrjInfo_ZTB
                    where (m.PrjName != oldName) && (m.PrjName == newName)
                    select m).Count<PT_PrjInfo_ZTB>();
                num2 = (from m in entities.PT_PrjInfo
                    where (m.PrjName != oldName) && (m.PrjName == newName)
                    select m).Count<PT_PrjInfo>();
            }
            if ((num <= 0) && (num2 <= 0))
            {
                return false;
            }
            return true;
        }

        public void UpdateMultiplePart(TenderInfo model, string type)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                PT_PrjInfo_ZTB o_ztb = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjGuid == model.PrjGuid
                    select m).FirstOrDefault<PT_PrjInfo_ZTB>();
                if (o_ztb != null)
                {
                    o_ztb.Area = model.Area;
                    o_ztb.BudgetWay = model.BudgetWay;
                    o_ztb.BuildingArea = model.BuildingArea;
                    o_ztb.BuildingType = model.BuildingType;
                    o_ztb.PrjCode = model.PrjCode;
                    o_ztb.PrjCost = model.PrjCost;
                    o_ztb.PrjFundInfo = model.PrjFundInfo;
                    o_ztb.PrjInfo = model.PrjInfo;
                    o_ztb.PrjKindClass = model.PrjKindClass;
                    o_ztb.PrjManager = model.PrjManager;
                    o_ztb.PrjName = model.PrjName;
                    o_ztb.PrjPlace = model.PrjPlace;
                    o_ztb.QualityClass = model.QualityClass;
                    o_ztb.Rank = model.Rank;
                    o_ztb.RationClass = model.RationClass;
                    o_ztb.Remark = model.Remark;
                    o_ztb.StartDate = model.StartDate;
                    o_ztb.EndDate = model.EndDate;
                    o_ztb.TenderWay = model.TenderWay;
                    o_ztb.TotalHouseNum = model.TotalHouseNum;
                    o_ztb.UndergroundArea = model.UndergroundArea;
                    o_ztb.UsegrounArea = model.UsegrounArea;
                    o_ztb.WorkUnit = model.WorkUnit;
                    o_ztb.Duration = model.Duration;
                    o_ztb.Designer = model.Designer;
                    o_ztb.Inspector = model.Inspector;
                    o_ztb.Counsellor = model.Counsellor;
                    o_ztb.OwnerCode = model.OwnerCode;
                    o_ztb.ContractWay = model.ContractWay;
                    o_ztb.PayWay = model.PayWay;
                    o_ztb.KeyPart = model.KeyPart;
                    o_ztb.PayCondition = model.PayCondition;
                    o_ztb.OtherStatement = model.OtherStatement;
                    PT_PrjInfo_ZTB_Detail detail = (from m in entities.PT_PrjInfo_ZTB_Detail
                        where m.PrjGuid == model.PrjGuid
                        select m).FirstOrDefault<PT_PrjInfo_ZTB_Detail>();
                    if (detail == null)
                    {
                        detail = new PT_PrjInfo_ZTB_Detail {
                            PrjGuid = model.PrjGuid,
                            ProjFlowSate = -1
                        };
                        entities.AddToPT_PrjInfo_ZTB_Detail(detail);
                    }
                    detail.ProjPeopleName = model.ProjPeopleUserName;
                    detail.ProjPeopleDep = model.ProjPeopleCorp;
                    detail.ProjPeopleDuty = model.ProjPeopleDuty;
                    detail.ProjPeopleTel = model.ProjPeopleTel;
                    detail.ProjInfoOrigin = model.ProjInfoOrigin;
                    detail.ProjElseRequest = model.ProjElseRequest;
                    detail.Grade = model.Grade;
                    detail.Telephone = model.Telephone;
                    detail.EngineeringType = model.EngineeringType;
                    detail.EngineeringSubType = model.EngineeringSubType;
                    detail.BuildingTypeNo = new int?(model.BuildingTypeNo);
                    detail.OwnerLinkMan = model.OwnerLinkManName;
                    detail.OwnerLinkPhone = model.OwnerLinkPhone;
                    detail.OwnerAddress = model.OwnerAddress;
                    this.UpdateUser(detail.PrjDutyPerson, model.PrjDutyPerson, model.PrjGuid);
                    detail.PrjDutyPerson = model.PrjDutyPerson;
                    detail.PrjApprovalOf = model.PrjApprovalOf;
                    detail.PrjFundWorkable = model.PrjFundWorkable;
                    detail.ForecastProfitRate = model.ForecastProfitRate;
                    detail.EngineeringEstimates = model.EngineeringEstimates;
                    detail.ManagementMargin = model.ManagementMargin;
                    detail.MigrantQualityMarginRate = model.MigrantQualityMarginRate;
                    detail.WithholdingTaxRate = model.WithholdingTaxRate;
                    detail.PerformanceBond = model.PerformanceBond;
                    detail.ElseMargin = model.ElseMargin;
                    cn.justwin.Tender.EngineeringType.UpdateEngineerType(model.EngineeringTypes, model.PrjGuid.ToString(), entities);
                    detail.PrjManagerRequire = model.PrjManagerRequire;
                    detail.TechnicalLeaderRequire = model.TechnicalLeaderRequire;
                    detail.Province = model.Province;
                    detail.City = model.City;
                    detail.PrjProperty = model.PrjProperty;
                    this.UpdateUser(detail.PrjReadOne, model.PrjReadOne, model.PrjGuid);
                    detail.PrjReadOne = model.PrjReadOne;
                    detail.QualificationMargin = model.QualificationMargin;
                    this.UpdateUser(detail.QualificationReadOne, model.QualificationReadOne, model.PrjGuid);
                    detail.QualificationReadOne = model.QualificationReadOne;
                    detail.TenderProspect = model.TenderProspect;
                    this.UpdateUser(detail.TenderReadOne, model.TenderReadOne, model.PrjGuid);
                    detail.TenderReadOne = model.TenderReadOne;
                    ProjectKind.Update(model.PrjGuid.ToString(), model.prjKinds, entities);
                    ProjectRank.Update(model.PrjGuid.ToString(), model.prjRanks, entities);
                    if (type == ProjectParameter.Initiate)
                    {
                        detail.ProjStartDate = model.ProjStartDate;
                        this.UpdateUser(detail.BusinessManager, model.BusinessManager, model.PrjGuid);
                        detail.BusinessManager = model.BusinessManager;
                        detail.ProjStartRemark = model.ProjStartRemark;
                    }
                    if (type == ProjectParameter.Prequalification)
                    {
                        detail.ProjStartDate = model.ProjStartDate;
                        this.UpdateUser(detail.BusinessManager, model.BusinessManager, model.PrjGuid);
                        detail.BusinessManager = model.BusinessManager;
                        detail.ProjStartRemark = model.ProjStartRemark;
                        detail.ProjTenderDate = model.ProjTenderDate;
                        detail.ProjApplyDate = model.ProjApplyDate;
                        detail.ProjApprovalDate = model.ProjApprovalDate;
                        detail.ProjRegistDeadline = model.ProjRegistDeadline;
                        this.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                        detail.ProgAgent = model.ProgAgent;
                        detail.PrequalificationRequire = model.PrequalificationRequire;
                    }
                    if (type == ProjectParameter.QualificationPass)
                    {
                        detail.ProjStartDate = model.ProjStartDate;
                        this.UpdateUser(detail.BusinessManager, model.BusinessManager, model.PrjGuid);
                        detail.BusinessManager = model.BusinessManager;
                        detail.ProjStartRemark = model.ProjStartRemark;
                        detail.ProjTenderDate = model.ProjTenderDate;
                        detail.ProjApplyDate = model.ProjApplyDate;
                        detail.ProjApprovalDate = model.ProjApprovalDate;
                        detail.ProjRegistDeadline = model.ProjRegistDeadline;
                        this.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                        detail.ProgAgent = model.ProgAgent;
                        detail.PrequalificationRequire = model.PrequalificationRequire;
                        detail.QualificationPassDate = model.QualificationPassDate;
                        detail.QualificationPassReason = model.QualificationPassReason;
                    }
                    if (type == ProjectParameter.QualificationFail)
                    {
                        detail.ProjStartDate = model.ProjStartDate;
                        this.UpdateUser(detail.BusinessManager, model.BusinessManager, model.PrjGuid);
                        detail.BusinessManager = model.BusinessManager;
                        detail.ProjStartRemark = model.ProjStartRemark;
                        detail.ProjTenderDate = model.ProjTenderDate;
                        detail.ProjApplyDate = model.ProjApplyDate;
                        detail.ProjApprovalDate = model.ProjApprovalDate;
                        detail.ProjRegistDeadline = model.ProjRegistDeadline;
                        this.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                        detail.ProgAgent = model.ProgAgent;
                        detail.PrequalificationRequire = model.PrequalificationRequire;
                        detail.QualificationFailData = model.QualificationFailData;
                        detail.QualificationFailReason = model.QualificationFailReason;
                    }
                    if (type == ProjectParameter.Bid)
                    {
                        detail.ProjStartDate = model.ProjStartDate;
                        this.UpdateUser(detail.BusinessManager, model.BusinessManager, model.PrjGuid);
                        detail.BusinessManager = model.BusinessManager;
                        detail.ProjStartRemark = model.ProjStartRemark;
                        detail.ProjTenderDate = model.ProjTenderDate;
                        detail.ProjApplyDate = model.ProjApplyDate;
                        detail.ProjApprovalDate = model.ProjApprovalDate;
                        detail.ProjRegistDeadline = model.ProjRegistDeadline;
                        this.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                        detail.ProgAgent = model.ProgAgent;
                        detail.PrequalificationRequire = model.PrequalificationRequire;
                        detail.QualificationPassDate = model.QualificationPassDate;
                        detail.QualificationPassReason = model.QualificationPassReason;
                        detail.ProjTenderBeginDate = model.ProjTenderBeginDate;
                        detail.TenderCeilingPrice = model.TenderCeilingPrice;
                        detail.TenderQuote = model.TenderQuote;
                        detail.TenderAppraiseMethod = model.TenderAppraiseMethod;
                        detail.TenderAverage = model.TenderAverage;
                        detail.ProjTenderCostContent = model.ProjTenderCostContent;
                        detail.ProjTenderAnswerDate = model.ProjTenderAnswerDate;
                        detail.ProjTenderEarnestMoney = model.ProjTenderEarnestMoney;
                        detail.ProjTenderPayWay = model.ProjTenderPayWay;
                        detail.ProjTenderContent = model.ProjTenderContent;
                        detail.ProjTenderRemark = model.ProjTenderRemark;
                    }
                    if (type == ProjectParameter.WinBid)
                    {
                        detail.ProjStartDate = model.ProjStartDate;
                        this.UpdateUser(detail.BusinessManager, model.BusinessManager, model.PrjGuid);
                        detail.BusinessManager = model.BusinessManager;
                        detail.ProjStartRemark = model.ProjStartRemark;
                        detail.ProjTenderDate = model.ProjTenderDate;
                        detail.ProjApplyDate = model.ProjApplyDate;
                        detail.ProjApprovalDate = model.ProjApprovalDate;
                        detail.ProjRegistDeadline = model.ProjRegistDeadline;
                        this.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                        detail.ProgAgent = model.ProgAgent;
                        detail.PrequalificationRequire = model.PrequalificationRequire;
                        detail.QualificationPassDate = model.QualificationPassDate;
                        detail.QualificationPassReason = model.QualificationPassReason;
                        detail.ProjTenderBeginDate = model.ProjTenderBeginDate;
                        detail.TenderCeilingPrice = model.TenderCeilingPrice;
                        detail.TenderQuote = model.TenderQuote;
                        detail.TenderAppraiseMethod = model.TenderAppraiseMethod;
                        detail.TenderAverage = model.TenderAverage;
                        detail.ProjTenderCostContent = model.ProjTenderCostContent;
                        detail.ProjTenderAnswerDate = model.ProjTenderAnswerDate;
                        detail.ProjTenderEarnestMoney = model.ProjTenderEarnestMoney;
                        detail.ProjTenderPayWay = model.ProjTenderPayWay;
                        detail.ProjTenderContent = model.ProjTenderContent;
                        detail.ProjTenderRemark = model.ProjTenderRemark;
                        detail.SuccessBidDate = model.SuccessBidDate;
                        detail.SuccessBidPrice = model.SuccessBidPrice;
                        detail.SuccessBidRemark = model.SuccessBidRemark;
                    }
                    if (type == ProjectParameter.OutBid)
                    {
                        detail.ProjStartDate = model.ProjStartDate;
                        this.UpdateUser(detail.BusinessManager, model.BusinessManager, model.PrjGuid);
                        detail.BusinessManager = model.BusinessManager;
                        detail.ProjStartRemark = model.ProjStartRemark;
                        detail.ProjTenderDate = model.ProjTenderDate;
                        detail.ProjApplyDate = model.ProjApplyDate;
                        detail.ProjApprovalDate = model.ProjApprovalDate;
                        detail.ProjRegistDeadline = model.ProjRegistDeadline;
                        this.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                        detail.ProgAgent = model.ProgAgent;
                        detail.PrequalificationRequire = model.PrequalificationRequire;
                        detail.QualificationPassDate = model.QualificationPassDate;
                        detail.QualificationPassReason = model.QualificationPassReason;
                        detail.ProjTenderBeginDate = model.ProjTenderBeginDate;
                        detail.TenderCeilingPrice = model.TenderCeilingPrice;
                        detail.TenderQuote = model.TenderQuote;
                        detail.TenderAppraiseMethod = model.TenderAppraiseMethod;
                        detail.TenderAverage = model.TenderAverage;
                        detail.ProjTenderCostContent = model.ProjTenderCostContent;
                        detail.ProjTenderAnswerDate = model.ProjTenderAnswerDate;
                        detail.ProjTenderEarnestMoney = model.ProjTenderEarnestMoney;
                        detail.ProjTenderPayWay = model.ProjTenderPayWay;
                        detail.ProjTenderContent = model.ProjTenderContent;
                        detail.ProjTenderRemark = model.ProjTenderRemark;
                        detail.OutBidDate = model.OutBidDate;
                        detail.OutBidIsReturn = model.OutBidIsReturn;
                        detail.OutBidRemark = model.OutBidRemark;
                    }
                    entities.SaveChanges();
                }
            }
        }

        public void UpdatePart(TenderInfo model, string type)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                PT_PrjInfo_ZTB_Detail detail = (from m in entities.PT_PrjInfo_ZTB_Detail
                    where m.PrjGuid == model.PrjGuid
                    select m).FirstOrDefault<PT_PrjInfo_ZTB_Detail>();
                if (detail == null)
                {
                    detail = new PT_PrjInfo_ZTB_Detail {
                        PrjGuid = model.PrjGuid,
                        ProjFlowSate = -1
                    };
                    entities.AddToPT_PrjInfo_ZTB_Detail(detail);
                }
                int state = 2;
                TenderInfo info = new TenderInfo();
                if (type == ProjectParameter.Initiate)
                {
                    detail.ProjStartDate = model.ProjStartDate;
                    string prjDutyPerson = detail.PrjDutyPerson;
                    string newCode = model.PrjDutyPerson;
                    info.UpdateUser(prjDutyPerson, newCode, model.PrjGuid);
                    detail.PrjDutyPerson = model.PrjDutyPerson;
                    detail.ProjStartRemark = model.ProjStartRemark;
                    state = int.Parse(ProjectParameter.Initiate);
                }
                else if (type == ProjectParameter.Bid)
                {
                    detail.ProjTenderBeginDate = model.ProjTenderBeginDate;
                    detail.TenderCeilingPrice = model.TenderCeilingPrice;
                    detail.TenderQuote = model.TenderQuote;
                    detail.TenderAppraiseMethod = model.TenderAppraiseMethod;
                    detail.TenderAverage = model.TenderAverage;
                    detail.ProjTenderCostContent = model.ProjTenderCostContent;
                    detail.ProjTenderAnswerDate = model.ProjTenderAnswerDate;
                    detail.ProjTenderEarnestMoney = model.ProjTenderEarnestMoney;
                    detail.ProjTenderPayWay = model.ProjTenderPayWay;
                    detail.ProjTenderContent = model.ProjTenderContent;
                    detail.ProjTenderRemark = model.ProjTenderRemark;
                    detail.TenderUnit = model.TenderUnit;
                    detail.TenderProspect = model.TenderProspect;
                    info.UpdateUser(detail.TenderReadOne, model.TenderReadOne, model.PrjGuid);
                    detail.TenderReadOne = model.TenderReadOne;
                    state = int.Parse(ProjectParameter.Bid);
                }
                else if (type == ProjectParameter.WinBid)
                {
                    detail.SuccessBidDate = model.SuccessBidDate;
                    detail.SuccessBidPrice = model.SuccessBidPrice;
                    detail.SuccessBidRemark = model.SuccessBidRemark;
                    state = int.Parse(ProjectParameter.WinBid);
                }
                else if (type == ProjectParameter.OutBid)
                {
                    detail.OutBidDate = model.OutBidDate;
                    detail.OutBidIsReturn = model.OutBidIsReturn;
                    detail.OutBidRemark = model.OutBidRemark;
                    state = int.Parse(ProjectParameter.OutBid);
                }
                else if (type == ProjectParameter.Prequalification)
                {
                    detail.ProjApplyDate = model.ProjApplyDate;
                    detail.ProjApprovalDate = model.ProjApprovalDate;
                    detail.ProjTenderDate = model.ProjTenderDate;
                    detail.ProjRegistDeadline = model.ProjRegistDeadline;
                    detail.PrequalificationRequire = model.PrequalificationRequire;
                    info.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                    detail.ProgAgent = model.ProgAgent;
                    detail.QualificationMargin = model.QualificationMargin;
                    info.UpdateUser(detail.QualificationReadOne, model.QualificationReadOne, model.PrjGuid);
                    detail.QualificationReadOne = model.QualificationReadOne;
                    state = int.Parse(ProjectParameter.Prequalification);
                }
                else if (type == ProjectParameter.QualificationPass)
                {
                    detail.ProjApplyDate = model.ProjApplyDate;
                    detail.ProjApprovalDate = model.ProjApprovalDate;
                    detail.ProjTenderDate = model.ProjTenderDate;
                    detail.ProjRegistDeadline = model.ProjRegistDeadline;
                    detail.PrequalificationRequire = model.PrequalificationRequire;
                    info.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                    detail.ProgAgent = model.ProgAgent;
                    detail.QualificationMargin = model.QualificationMargin;
                    info.UpdateUser(detail.QualificationReadOne, model.QualificationReadOne, model.PrjGuid);
                    detail.QualificationReadOne = model.QualificationReadOne;
                    detail.QualificationPassDate = model.QualificationPassDate;
                    detail.QualificationPassReason = model.QualificationPassReason;
                    state = int.Parse(ProjectParameter.QualificationPass);
                }
                else if (type == ProjectParameter.QualificationFail)
                {
                    detail.ProjApplyDate = model.ProjApplyDate;
                    detail.ProjApprovalDate = model.ProjApprovalDate;
                    detail.ProjTenderDate = model.ProjTenderDate;
                    detail.ProjRegistDeadline = model.ProjRegistDeadline;
                    detail.PrequalificationRequire = model.PrequalificationRequire;
                    info.UpdateUser(detail.ProgAgent, model.ProgAgent, model.PrjGuid);
                    detail.ProgAgent = model.ProgAgent;
                    detail.QualificationMargin = model.QualificationMargin;
                    info.UpdateUser(detail.QualificationReadOne, model.QualificationReadOne, model.PrjGuid);
                    detail.QualificationReadOne = model.QualificationReadOne;
                    detail.QualificationFailData = model.QualificationFailData;
                    detail.QualificationFailReason = model.QualificationFailReason;
                    state = int.Parse(ProjectParameter.QualificationFail);
                }
                if ((type == ProjectParameter.Initiate.ToString()) || (type == ProjectParameter.Bid.ToString()))
                {
                    this.SetPrjManager(model);
                }
                entities.SaveChanges();
                UpdatePrjState(model.PrjGuid, state);
            }
        }

        public static void UpdatePrjState(Guid guid, int state)
        {
            using (pm2Entities entities = new pm2Entities())
            {
                PT_PrjInfo_ZTB o_ztb = (from m in entities.PT_PrjInfo_ZTB
                    where m.PrjGuid == guid
                    select m).FirstOrDefault<PT_PrjInfo_ZTB>();
                if (o_ztb != null)
                {
                    o_ztb.PrjState = new int?(state);
                    entities.SaveChanges();
                }
            }
        }

        private void UpdateUser(string oldCode, string newCode, Guid guid)
        {
            if ((!string.IsNullOrEmpty(newCode) && (newCode != oldCode)) && ((newCode != "00000000") && !TenderUser.isExist(guid, newCode)))
            {
                TenderUser.Add(guid.ToString(), newCode);
            }
        }

        public DateTime? ActualRunDate { get; set; }

        public string AfforestArea { get; set; }

        public string Area { get; set; }

        public string BudgetWay { get; set; }

        public string BuildingArea { get; set; }

        public string BuildingType { get; set; }

        public int BuildingTypeNo { get; set; }

        public string BusinessManager { get; set; }

        public string BusinessManagerName
        {
            get
            {
                return this.GetUserName(this.BusinessManager);
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

        public DateTime? InputDate { get; set; }

        public string InputUser { get; set; }

        public string Inspector { get; set; }

        public string KeyPart { get; set; }

        public decimal? ManagementMargin { get; set; }

        public Guid? MarketInfoGuid { get; set; }

        public decimal? MigrantQualityMarginRate { get; set; }

        public string OtherStatement { get; set; }

        public DateTime? OutBidDate { get; set; }

        public bool? OutBidIsReturn { get; set; }

        public string OutBidRemark { get; set; }

        public string OwnerAddress { get; set; }

        public int? OwnerCode { get; set; }

        public string OwnerLinkManName { get; set; }

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

        public string PrequalificationRequire { get; set; }

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

        public Guid PrjGuid { get; set; }

        public string PrjInfo { get; set; }

        public string PrjKindClass { get; set; }

        public IList<ProjectKind> PrjKinds
        {
            get
            {
                if (this.prjKinds == null)
                {
                    this.prjKinds = ProjectKind.GetProjectKinds(this.PrjGuid);
                }
                return this.prjKinds;
            }
            set
            {
                this.prjKinds = value;
            }
        }

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

        public int PrjState { get; set; }

        public string ProgAgent { get; set; }

        public string ProgAgentName
        {
            get
            {
                return this.GetUserName(this.ProgAgent);
            }
        }

        public DateTime? ProjApplyDate { get; set; }

        public DateTime? ProjApprovalDate { get; set; }

        public string ProjElseRequest { get; set; }

        public int ProjFlowSate { get; set; }

        public string ProjInfoOrigin { get; set; }

        public string ProjPeopleCode { get; set; }

        public string ProjPeopleCorp { get; set; }

        public string ProjPeopleDuty { get; set; }

        public string ProjPeopleTel { get; set; }

        public string ProjPeopleUserName { get; set; }

        public int? ProjRegistDeadline { get; set; }

        public DateTime? ProjStartDate { get; set; }

        public string ProjStartRemark { get; set; }

        public DateTime? ProjTenderAnswerDate { get; set; }

        public DateTime? ProjTenderBeginDate { get; set; }

        public string ProjTenderContent { get; set; }

        public string ProjTenderCostContent { get; set; }

        public DateTime? ProjTenderDate { get; set; }

        public decimal? ProjTenderEarnestMoney { get; set; }

        public string ProjTenderPayWay { get; set; }

        public string ProjTenderRemark { get; set; }

        public string Province { get; set; }

        public DateTime? QualificationFailData { get; set; }

        public string QualificationFailReason { get; set; }

        public decimal QualificationMargin { get; set; }

        public DateTime? QualificationPassDate { get; set; }

        public string QualificationPassReason { get; set; }

        public string QualificationReadOne { get; set; }

        public string QualityClass { get; set; }

        public string Rank { get; set; }

        public string RationClass { get; set; }

        public string Remark { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? SuccessBidDate { get; set; }

        public decimal? SuccessBidPrice { get; set; }

        public string SuccessBidRemark { get; set; }

        public string TechnicalLeaderRequire { get; set; }

        public string Telephone { get; set; }

        public string TenderAppraiseMethod { get; set; }

        public decimal? TenderAverage { get; set; }

        public decimal? TenderCeilingPrice { get; set; }

        public DateTime? TenderProspect { get; set; }

        public decimal? TenderQuote { get; set; }

        public string TenderReadOne { get; set; }

        public string TenderUnit { get; set; }

        public string TenderWay { get; set; }

        public string TotalHouseNum { get; set; }

        public string UndergroundArea { get; set; }

        public string UsegrounArea { get; set; }

        public decimal? WithholdingTaxRate { get; set; }

        public string WorkUnit { get; set; }

        public string WorkUnitName
        {
            get
            {
                return this.WorkUnit;
            }
        }
    }
}

