using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.stockBLL;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class StockManage_Report_StuffSummarizing : NBasePage, IRequiresSessionState
{
	private PT_PrjInfo prjInfo = new PT_PrjInfo();
	private TreasuryStockBll treasuryStockBll = new TreasuryStockBll();
	private DataTable dt = new DataTable();
	private string isWBSRelevance = ConfigHelper.Get("IsWBSRelevance");

	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.hfldIsWBSRelevance.Value = this.isWBSRelevance;
			this.AspNetPager1.PageSize = NBasePage.pagesize;
			this.BindDrop();
			this.BindTree();
			this.hfldPrjId.Value = this.tvProject.SelectedValue;
			this.ComputeTotal();
			this.BindGv();
		}
	}
	public void BindDrop()
	{
		ProjectTree projectTree = new ProjectTree();
		projectTree.BindDlistYears(this.ddlYear, this.Session["PmSet"], base.UserCode, base.Request["year"]);
	}
	protected void BindTree()
	{
		ProjectTree projectTree = new ProjectTree();
		projectTree.BindTreeNodes(this.tvProject, this.Session["PmSet"], base.UserCode, base.Request["prjId"], this.ddlYear.SelectedItem.Text, this.ddlYear.SelectedValue);
	}
	protected void ddlYear_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		this.hfldYear.Value = this.ddlYear.SelectedValue;
		this.txtCode.Text = "";
		this.txtName.Text = "";
		this.BindTree();
		this.ComputeTotal();
		this.BindGv();
	}
	protected void tvProject_SelectedNodeChanged(object sender, System.EventArgs e)
	{
		this.hfldPrjId.Value = this.tvProject.SelectedValue;
		this.txtCode.Text = "";
		this.txtName.Text = "";
		this.ComputeTotal();
		this.BindGv();
	}
	protected void ComputeTotal()
	{
		this.AspNetPager1.CurrentPageIndex = 1;
		DataTable dt1 = this.treasuryStockBll.GetStuffInfo(this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.hfldPrjId.Value.Trim(), 0, 0, this.hfldIsWBSRelevance.Value, this.txtSpecification.Text.Trim(), this.txtBrand.Text.Trim(), this.txtModelNumber.Text.Trim());
        //DataTable stuffInfo = GetStuffInfo(this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.hfldPrjId.Value.Trim(), 0, 0, this.hfldIsWBSRelevance.Value, this.txtSpecification.Text.Trim(), this.txtBrand.Text.Trim(), this.txtModelNumber.Text.Trim());
        string strSql = string.Format(@"          with t1 as( SELECT t.TaskId, t.TaskName,t.ResourceId,t.ResourceCode scode,t.ResourceQuantity,w.numberIng--,sws.number--sum(sws.number) numberIng-- ,sws.wpcode
            FROM (SELECT  PrjGuid,TaskId,ResourceId,TaskName,ResourceCode,sum(ResourceQuantity) ResourceQuantity FROM (
			SELECT btr.PrjGuid,btr.TaskId,btr.ResourceId,bt.TaskName,rs.ResourceCode,btr.ResourceQuantity 
            FROM Bud_TaskResource btr 
            LEFT JOIN Res_Resource rs on btr.ResourceId=rs.ResourceId 
            LEFT JOIN Bud_Task bt on btr.TaskId=bt.TaskId
            where btr.PrjGuid='{0}' 
			UNION ALL SELECT  bm.PrjId,bmt.TaskId,bmts.ResourceId,bt.TaskName,rs.ResourceCode,bmts.ResourceQuantity FROM Bud_ModifyTaskRes bmts 
			LEFT JOIN Bud_ModifyTask bmt ON bmts.ModifyTaskId=bmt.ModifyTaskId 
			LEFT JOIN Bud_Modify bm ON bmt.ModifyId=bm.ModifyId 
			LEFT JOIN Bud_Task bt on bmt.TaskId=bt.TaskId 
			LEFT JOIN Res_Resource rs on bmts.ResourceId=rs.ResourceId 
			WHERE bm.flowstate !=-2 and bm.PrjId='{0}' ) s
			GROUP BY PrjGuid,TaskId,ResourceId,TaskName,ResourceCode )t 
			LEFT JOIN 
            ( SELECT sws.scode,sws.TaskId,sum(sws.number) numberIng from Sm_Wantplan_Stock sws --sw.flowstate,sw.swcode,
			LEFT JOIN  Sm_Wantplan sw ON sws.wpcode=sw.swcode 
			WHERE sw.flowstate !=-2 and sw.swcode !='' 
			GROUP BY sws.scode,sws.TaskId ) w ON w.scode=t.ResourceCode AND w.TaskId=t.TaskId)
          SELECT t1.*,t2.*,rs.ResourceName from t1 LEFT JOIN ( select sws.scode,sum(sws.number) nums,sw.procode,(select sum(sos.number) outNums from Sm_out_Stock sos WHERE sos.wpcode in( select sws.wpcode from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' ) and sos.scode=sws.scode) outNums
												from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' 	
												GROUP BY sws.scode,sw.procode )
												 t2 on t1.scode=t2.scode 	
												 LEFT JOIN Res_Resource rs on t1.ResourceId=rs.ResourceId  ", this.hfldPrjId.Value);
        DataTable dt2 = publicDbOpClass.DataTableQuary(strSql);

        DataTable stuffInfo = new DataTable();
        stuffInfo = dt1.Clone();
        stuffInfo.Columns.Add("nums");
        stuffInfo.Columns["nums"].DataType = Type.GetType("System.Decimal");
        stuffInfo.Columns.Add("outNums");
        stuffInfo.Columns["outNums"].DataType = Type.GetType("System.Decimal");
        
        for (int ii=0;ii<dt1.Rows.Count;ii++) {
            stuffInfo.Rows.Add(dt1.Rows[ii].ItemArray);
        }
        foreach (DataRow dr1 in stuffInfo.Rows)
        {
            foreach (DataRow dr2 in dt2.Rows)
            {
                if (dr1["ResourceCode"].ToString() == dr2["scode"].ToString())
                {
                    if (!string.IsNullOrEmpty(dr2["nums"].ToString()))
                    {
                        dr1["nums"] = Convert.ToDecimal(dr2["nums"].ToString());
                    }
                    else
                    {
                        dr1["nums"] = 0;
                    }

                    if (!string.IsNullOrEmpty(dr2["outNums"].ToString()))
                    {
                        dr1["outNums"] = Convert.ToDecimal(dr2["outNums"].ToString());
                    }
                    else
                    {
                        dr1["outNums"] = 0;
                    }
                }
            }
        }
        foreach (DataRow dr1 in stuffInfo.Rows)
        {
            if (string.IsNullOrEmpty(dr1["nums"].ToString()))
            {
                dr1["nums"] = 0;
            }
            if (string.IsNullOrEmpty(dr1["outNums"].ToString()))
            {
                dr1["outNums"] = 0;
            }
        }

        string[] array = new string[14];
		if (stuffInfo.Rows.Count != 0)
		{
			array[0] = System.Convert.ToDecimal(stuffInfo.Compute("sum(BudQuantity)", "1>0")).ToString("0.000");
			array[1] = System.Convert.ToDecimal(stuffInfo.Compute("sum(BudTotal)", "1>0")).ToString("0.000");
			array[2] = System.Convert.ToDecimal(stuffInfo.Compute("sum(PurchaseNumber)", "1>0")).ToString("0.000");
			array[3] = System.Convert.ToDecimal(stuffInfo.Compute("sum(PurchaseCost)", "1>0")).ToString("0.000");
			array[4] = System.Convert.ToDecimal(stuffInfo.Compute("sum(StorageNumber)", "1>0")).ToString("0.000");
			array[5] = System.Convert.ToDecimal(stuffInfo.Compute("sum(StorageCost)", "1>0")).ToString("0.000");
			array[6] = System.Convert.ToDecimal(stuffInfo.Compute("sum(RealityNumber)", "1>0")).ToString("0.000");
			array[7] = System.Convert.ToDecimal(stuffInfo.Compute("sum(RealityTotal)", "1>0")).ToString("0.000");
			array[8] = System.Convert.ToDecimal(stuffInfo.Compute("sum(ProfitLossNumber)", "1>0")).ToString("0.000");
			array[9] = System.Convert.ToDecimal(stuffInfo.Compute("sum(ProfitLossCost)", "1>0")).ToString("0.000");
			array[10] = System.Convert.ToDecimal(stuffInfo.Compute("sum(BalanceNumber)", "1>0")).ToString("0.000");
			array[11] = System.Convert.ToDecimal(stuffInfo.Compute("sum(BalanceCost)", "1>0")).ToString("0.000");

            array[12] = System.Convert.ToDecimal(stuffInfo.Compute("sum(nums)", "1>0")).ToString("0.000");
            array[13] = System.Convert.ToDecimal(stuffInfo.Compute("sum(outNums)", "1>0")).ToString("0.000");
        }
		else
		{
			array[0] = "0.000";
			array[1] = "0.000";
			array[2] = "0.000";
			array[3] = "0.000";
			array[4] = "0.000";
			array[5] = "0.000";
			array[6] = "0.000";
			array[7] = "0.000";
			array[8] = "0.000";
			array[9] = "0.000";
			array[10] = "0.000";
			array[11] = "0.000";
            array[12] = "0.000";
            array[13] = "0.000";
        }
		this.ViewState["Total"] = array;
	}


    public DataTable GetStuffInfo(string resourceCode, string resourceName, string prjId, int pageIndex, int pageSize, string isWBSRelevance, string specification, string brand, string modelNumber)
    {
        if (pageIndex == 0)
        {
            pageIndex = 1;
        }
        if (pageSize == 0)
        {
            pageSize = 100;
        }
        StringBuilder builder = new StringBuilder();
        List<SqlParameter> list = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(resourceCode))
        {
            builder.AppendFormat(" AND ResourceCode LIKE '%'+@resourceCode+'%' ", new object[0]);
            list.Add(new SqlParameter("@resourceCode", resourceCode));
        }
        if (!string.IsNullOrEmpty(resourceName))
        {
            builder.AppendFormat(" AND ResourceName LIKE '%'+@resourceName+'%' ", new object[0]);
            list.Add(new SqlParameter("@resourceName", resourceName));
        }
        if (!string.IsNullOrEmpty(specification))
        {
            builder.AppendFormat(" AND Specification LIKE '%'+@specification+'%' ", new object[0]);
            list.Add(new SqlParameter("@specification", specification));
        }
        if (!string.IsNullOrEmpty(brand))
        {
            builder.AppendFormat(" AND Brand LIKE '%'+@brand+'%' ", new object[0]);
            list.Add(new SqlParameter("@brand", brand));
        }
        if (!string.IsNullOrEmpty(modelNumber))
        {
            builder.AppendFormat(" AND ModelNumber LIKE '%'+@modelNumber+'%' ", new object[0]);
            list.Add(new SqlParameter("@modelNumber", modelNumber));
        }
        string cmdText = "    \r\n                    --DECLARE @prjId NVARCHAR(50),@StuffCBSCode NVARCHAR(50),@pageSize INT,@pageIndex INT,@version int;\r\n                    --SET @prjId='7ff9b64f-4068-4a99-973b-d18cc8bb749b';\r\n                    --SET @StuffCBSCode='001001002';\r\n                    --SET @pageSize=1000;\r\n                    --SET @pageIndex=1;\r\n                    --set @version=2;\r\n                    WITH BudTask AS\t\t\t\t\t\t--目标成本的用量,价格和小计\r\n                    (\r\n            ";
        if (isWBSRelevance == "1")
        {
            cmdText = cmdText + "    \r\n\t                SELECT ResourceId,Convert(decimal(18,3),SUM(Target)) Total,Convert(decimal(18,3),SUM(ResourceQuantity)) ResourceQuantity,\r\n\t                Convert(decimal(18,3),ISNULL(SUM(Target)/NULLIF(SUM(ResourceQuantity),0),0)) ResourcePrice  FROM \r\n\t                (\r\n\t\t                SELECT ResourceId,ISNULL(ResourceQuantity,0)*ISNULL(ResourcePrice,0) AS Target,\r\n\t\t                ISNULL(ResourceQuantity,0) ResourceQuantity\tFROM Bud_TaskResource TaskRes \r\n\t\t                INNER JOIN Bud_Task AS Task ON Task.TaskId =TaskRes.TaskId \r\n\t\t                INNER JOIN vGetCurBudVersion ON Task.PrjId=vGetCurBudVersion.PrjId AND Version=CurVersion \r\n\t\t                WHERE TaskType='' AND Task.PrjId=@prjId AND \r\n\t\t                dbo.GetResourceType(ResourceId) IN (SELECT ResourceTypeId FROM Res_ResourceType WHERE CBSCode=@StuffCBSCode)\r\n\t\t                UNION\r\n\t\t                SELECT ResourceId,ISNULL(ResourceQuantity,0)*ISNULL(ResourcePrice,0) ModifyAmount, \r\n\t\t                ISNULL(ResourceQuantity,0) ResourceQuantity FROM Bud_ModifyTaskRes modifyTaskRes \r\n\t\t                INNER JOIN Bud_ModifyTask modifyTask ON modifyTask.ModifyTaskId=modifyTaskRes.ModifyTaskId \r\n\t\t                INNER JOIN Bud_Modify modify ON  modify.ModifyId=modifyTask.ModifyId \r\n\t\t                WHERE FlowState=1 AND PrjId=@prjId AND \r\n\t\t                dbo.GetResourceType(ResourceId) IN (SELECT ResourceTypeId FROM Res_ResourceType WHERE CBSCode=@StuffCBSCode)\r\n\t                ) BudTaskRes \r\n\t                GROUP BY ResourceId ";
        }
        else
        {
            cmdText = cmdText + "    \r\n\t                SELECT ResourceId,SUM(ResourceQuantity) ResourceQuantity,SUM(Total) Total,\r\n\t                ISNULL(SUM(Total)/NULLIF(SUM(ResourceQuantity),0),0) ResourcePrice FROM \r\n\t                (\r\n\t\t                SELECT budTaskRes.ResourceId,ISNULL(ResourceQuantity,0) ResourceQuantity,\r\n\t\t                ISNULL(ResourceQuantity,0)*ISNULL(ResourcePrice,0) Total \r\n\t\t                from Bud_TaskResource budTaskRes  \r\n\t\t                INNER JOIN vGetCurBudVersion ON PrjGuid=vGetCurBudVersion.PrjId AND Versions=CurVersion \r\n\t\t                where prjGuid=@prjId  AND \r\n\t\t                dbo.GetResourceType(ResourceId) IN (SELECT ResourceTypeId FROM Res_ResourceType WHERE CBSCode=@StuffCBSCode)\r\n\t\t                UNION ALL\r\n\t\t                SELECT ResourceId,ISNULL(ResourceQuantity,0)*ISNULL(ResourcePrice,0) Total, \r\n\t\t                ISNULL(ResourceQuantity,0) ResourceQuantity FROM Bud_ModifyTaskRes modifyTaskRes \r\n\t\t                INNER JOIN Bud_Modify modify ON modify.ModifyId=modifyTaskRes.ModifyId \r\n\t\t                WHERE FlowState=1 AND PrjId=@prjId AND \r\n\t\t                dbo.GetResourceType(ResourceId) IN (SELECT ResourceTypeId FROM Res_ResourceType WHERE CBSCode=@StuffCBSCode)\r\n\t                ) BudTaskRes GROUP BY ResourceId ";
        }
        cmdText = (cmdText + "\r\n                    ),PurchaseInfo AS\t\t\t\t\t\t--物资采购\r\n                    (\r\n\t                    SELECT ResourceId,SCode,Sprice,Number,PurchaseCost,CBSCode FROM (\r\n\t\t                    SELECT SCode,res.ResourceId,Sprice,Number,PurchaseCost,dbo.ufn_GetRootResTypeId(res.ResourceId) ResourceTypeId FROM (\r\n\t\t\t                    SELECT SCode,Sprice,SUM(Number) Number,Convert(decimal(18,3),SUM(Sprice*Number)) PurchaseCost\r\n\t\t\t                    FROM Sm_Purchase smPurchase\r\n\t\t\t                    INNER JOIN Sm_Purchase_Stock smPurchaseStock on smPurchase.pCode=smPurchaseStock.psCode\r\n\t\t\t                    WHERE Project=@prjId AND FlowState=1\r\n\t\t\t                    GROUP BY SCode,Sprice\r\n\t\t                    ) Purchase\r\n\t\t                    INNER JOIN Res_Resource res ON Purchase.SCode=res.ResourceCode \r\n\t                    ) PurchaseStockType\r\n\t                    INNER JOIN Res_ResourceType resType ON PurchaseStockType.ResourceTypeId=resType.ResourceTypeId\r\n\t                    WHERE CBSCode=@StuffCBSCode\r\n                    ),StorageInfo AS\t\t\t\t\t\t--物资入库\r\n                    (\r\n                    SELECT ResourceId,SCode,Sprice,Number,StorageCost,CBSCode FROM (\r\n\t                    SELECT SCode,res.ResourceId,Sprice,Number,StorageCost,dbo.ufn_GetRootResTypeId(res.ResourceId) ResourceTypeId FROM (\r\n\t\t                    SELECT smStorageStock.SCode,Sprice,SUM(Number) Number,Convert(decimal(18,3),SUM(Sprice*Number)) StorageCost\r\n\t\t                    FROM Sm_Storage smStorage\r\n\t\t                    INNER JOIN Sm_Storage_Stock smStorageStock on smStorage.scode=smStorageStock.stcode\r\n\t\t                    WHERE project=@prjId AND FlowState=1 AND InFlag=1 AND isFirst=0\r\n\t\t                    GROUP BY smStorageStock.SCode,Sprice\r\n\t                    ) Storage\r\n\t                    INNER JOIN Res_Resource res ON Storage.SCode=res.ResourceCode \r\n                    ) StorageStockType\r\n                    INNER JOIN Res_ResourceType resType ON StorageStockType.ResourceTypeId=resType.ResourceTypeId\r\n                    WHERE CBSCode=@StuffCBSCode\r\n                    ),OutInfo AS\t\t\t\t\t\t\t--出库信息\r\n                    (\r\n\t                    SELECT ResourceId,SCode,Sprice,Number,OutCost,CBSCode FROM (\r\n\t\t                    SELECT SCode,res.ResourceId,Sprice,Number,OutCost,dbo.ufn_GetRootResTypeId(res.ResourceId) ResourceTypeId FROM (\r\n\t\t\t\t                    SELECT SCode,Sprice,SUM(Number) Number,Convert(decimal(18,3),SUM(Sprice*Number)) OutCost\r\n\t\t\t\t                    FROM Sm_OutReserve smOutReserve\r\n\t\t\t\t                    INNER JOIN Sm_out_Stock smOutStock on smOutReserve.OrCode=smOutStock.OrCode\r\n\t\t\t\t                    WHERE ProCode=@prjId AND FlowState=1 AND IsOut=1\r\n\t\t\t\t                    GROUP BY SCode,Sprice\r\n\t\t                    ) OutReserve\r\n\t\t                    INNER JOIN Res_Resource res ON OutReserve.SCode=res.ResourceCode \r\n\t                    ) OutReserveStockType\r\n\t                    INNER JOIN Res_ResourceType resType ON OutReserveStockType.ResourceTypeId=resType.ResourceTypeId\r\n\t                    WHERE CBSCode=@StuffCBSCode\r\n                    ),RefundingInfo AS\t\t\t\t\t--退库信息\r\n                    (\r\n\t                    SELECT SCode,Sprice,SUM(Number) Number,Convert(decimal(18,3),\r\n\t                    SUM(Sprice*Number)) RefundingCost FROM Sm_Refunding Refunding\r\n\t                    INNER JOIN Sm_back_Stock backStock ON Refunding.RCode=backStock.RCode\r\n\t                    WHERE ProCode=@prjId AND flowState=1 AND IsIn=1 \r\n\t                    GROUP BY SCode,Sprice    \r\n                    ),RealityInfo AS\t\t\t\t\t--实际用量信息\r\n                    (\r\n\t                    SELECT ResourceId,SCode,Sprice,Number,RealityCost,RealityDetail.ResourceTypeId,CBSCode FROM \r\n\t                    (\r\n\t\t                    SELECT SCode,Sprice,Number,RealityCost,res.ResourceId,dbo.ufn_GetRootResTypeId(res.ResourceId) ResourceTypeId \r\n\t\t                    FROM (\r\n\t\t\t                    SELECT OutInfo.SCode,OutInfo.Sprice,(OutInfo.Number-ISNULL(RefundingInfo.Number,0)) Number,\r\n\t\t\t                    (OutCost-ISNULL(RefundingCost,0)) RealityCost\r\n\t\t\t                    FROM OutInfo LEFT JOIN RefundingInfo ON OutInfo.SCode=RefundingInfo.SCode  AND OutInfo.Sprice=RefundingInfo.Sprice \r\n\t\t\t                    ) RealityCost INNER JOIN Res_Resource res ON RealityCost.SCode=res.ResourceCode \r\n\t                    ) RealityDetail INNER JOIN Res_ResourceType resType ON RealityDetail.ResourceTypeId=resType.ResourceTypeId\r\n\t                    WHERE CBSCode=@StuffCBSCode \r\n                    ),AllRes AS\r\n                    (\r\n\t                    SELECT 0.00 nums,0.00 outNums,ResourceId,ResourcePrice Sprice FROM BudTask \r\n\t                    UNION\r\n\t                    SELECT ResourceId,Sprice FROM PurchaseInfo\r\n\t                    UNION\r\n\t                    SELECT ResourceId,Sprice FROM StorageInfo\r\n\t                    UNION \r\n\t                    SELECT ResourceId,Sprice FROM RealityInfo\r\n                    )\r\n                    SELECT TOP(@pageSize)CONVERT(NVARCHAR(30),Num) Num,ResourceId,ResourceCode,ResourceName,Brand,Specification,\r\n                    ModelNumber,BudQuantity,BudPrice,BudTotal,PurchaseNumber,PurchaseSprice,PurchaseCost,\r\n                    StorageNumber,StorageCost,RealityNumber,RealityPrice,RealityTotal,(BudQuantity-PurchaseNumber) ProfitLossNumber,\r\n                    (BudTotal-PurchaseCost) ProfitLossCost,(PurchaseNumber-OutNumber) BalanceNumber,(PurchaseCost-OutCost) BalanceCost FROM (\r\n                     SELECT Row_Number()over(order by ResourceCode) as Num,ResInfo.* FROM\r\n                    (\r\n\t                    SELECT AllRes.ResourceId,ResourceCode,ResourceName,ISNULL(ResourceQuantity,0) BudQuantity,\r\n\t                    ISNULL(ResourcePrice,0) BudPrice,ISNULL(total,0) BudTotal,ISNULL(RealityInfo.Sprice,0)RealityPrice,\r\n\t                    ISNULL(RealityInfo.Number,0) RealityNumber,ISNULL(RealityCost,0) RealityTotal,\r\n\t                    ISNULL(PurchaseInfo.Number,0) PurchaseNumber,ISNULL(PurchaseInfo.Sprice,0) PurchaseSprice,\r\n\t                    ISNULL(PurchaseInfo.PurchaseCost,0) PurchaseCost,ISNULL(StorageInfo.Number,0) StorageNumber,\r\n\t                    ISNULL(StorageInfo.StorageCost,0) StorageCost,ISNULL(OutInfo.Number,0) OutNumber,ISNULL(OutInfo.OutCost,0) OutCost,\r\n                        res.Brand, res.Specification, res.ModelNumber\r\n\t                    FROM AllRes \r\n\t                    LEFT JOIN BudTask ON AllRes.ResourceId=BudTask.ResourceId AND AllRes.Sprice=BudTask.ResourcePrice\r\n\t                    LEFT JOIN PurchaseInfo ON AllRes.ResourceId=PurchaseInfo.ResourceId AND AllRes.Sprice=PurchaseInfo.Sprice\r\n\t                    LEFT JOIN StorageInfo ON AllRes.ResourceId=StorageInfo.ResourceId AND AllRes.Sprice=StorageInfo.Sprice\r\n\t                    LEFT JOIN OutInfo ON AllRes.ResourceId=OutInfo.ResourceId AND AllRes.Sprice=OutInfo.Sprice\r\n\t                    LEFT JOIN RealityInfo ON AllRes.ResourceId=RealityInfo.ResourceId AND AllRes.Sprice=RealityInfo.Sprice\r\n\t                    INNER JOIN Res_Resource res ON AllRes.ResourceId=res.ResourceId\r\n                        WHERE 1=1  ") + builder.ToString() + " ) ResInfo) DATA WHERE Num>@pageSize*(@pageIndex-1) ";
        list.Add(new SqlParameter("@prjId", prjId));
        list.Add(new SqlParameter("@StuffCBSCode", ConfigHelper.Get("StuffCBSCode")));
        list.Add(new SqlParameter("@pageSize", pageSize));
        list.Add(new SqlParameter("@pageIndex", pageIndex));
        return SqlHelper.ExecuteQuery(CommandType.Text, cmdText, list.ToArray());
    }



    protected void BindGv()
	{
		this.AspNetPager1.RecordCount = this.treasuryStockBll.GetStuffCount(this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.hfldPrjId.Value.Trim(), this.hfldIsWBSRelevance.Value, this.txtSpecification.Text.Trim(), this.txtBrand.Text.Trim(), this.txtModelNumber.Text.Trim());
		DataTable dt1 = this.treasuryStockBll.GetStuffInfo(this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.hfldPrjId.Value.Trim(), this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize, this.hfldIsWBSRelevance.Value, this.txtSpecification.Text.Trim(), this.txtBrand.Text.Trim(), this.txtModelNumber.Text.Trim());

        string strSql = string.Format(@"          with t1 as( SELECT t.TaskId, t.TaskName,t.ResourceId,t.ResourceCode scode,t.ResourceQuantity,w.numberIng--,sws.number--sum(sws.number) numberIng-- ,sws.wpcode
            FROM (SELECT  PrjGuid,TaskId,ResourceId,TaskName,ResourceCode,sum(ResourceQuantity) ResourceQuantity FROM (
			SELECT btr.PrjGuid,btr.TaskId,btr.ResourceId,bt.TaskName,rs.ResourceCode,btr.ResourceQuantity 
            FROM Bud_TaskResource btr 
            LEFT JOIN Res_Resource rs on btr.ResourceId=rs.ResourceId 
            LEFT JOIN Bud_Task bt on btr.TaskId=bt.TaskId
            where btr.PrjGuid='{0}' 
			UNION ALL SELECT  bm.PrjId,bmt.TaskId,bmts.ResourceId,bt.TaskName,rs.ResourceCode,bmts.ResourceQuantity FROM Bud_ModifyTaskRes bmts 
			LEFT JOIN Bud_ModifyTask bmt ON bmts.ModifyTaskId=bmt.ModifyTaskId 
			LEFT JOIN Bud_Modify bm ON bmt.ModifyId=bm.ModifyId 
			LEFT JOIN Bud_Task bt on bmt.TaskId=bt.TaskId 
			LEFT JOIN Res_Resource rs on bmts.ResourceId=rs.ResourceId 
			WHERE bm.flowstate !=-2 and bm.PrjId='{0}' ) s
			GROUP BY PrjGuid,TaskId,ResourceId,TaskName,ResourceCode )t 
			LEFT JOIN 
            ( SELECT sws.scode,sws.TaskId,sum(sws.number) numberIng from Sm_Wantplan_Stock sws --sw.flowstate,sw.swcode,
			LEFT JOIN  Sm_Wantplan sw ON sws.wpcode=sw.swcode 
			WHERE sw.flowstate !=-2 and sw.swcode !='' 
			GROUP BY sws.scode,sws.TaskId ) w ON w.scode=t.ResourceCode AND w.TaskId=t.TaskId)
          SELECT t1.*,t2.*,rs.ResourceName from t1 LEFT JOIN ( select sws.scode,sum(sws.number) nums,sw.procode,(select sum(sos.number) outNums from Sm_out_Stock sos WHERE sos.wpcode in( select sws.wpcode from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' ) and sos.scode=sws.scode) outNums
												from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' 	
												GROUP BY sws.scode,sw.procode )
												 t2 on t1.scode=t2.scode 	
												 LEFT JOIN Res_Resource rs on t1.ResourceId=rs.ResourceId  ", this.hfldPrjId.Value);
        DataTable dt2  = publicDbOpClass.DataTableQuary(strSql);
        DataTable stuffInfo = new DataTable();
        stuffInfo = dt1.Clone();
        stuffInfo.Columns.Add("nums");
        stuffInfo.Columns["nums"].DataType = Type.GetType("System.Decimal");
        stuffInfo.Columns.Add("outNums");
        stuffInfo.Columns["outNums"].DataType = Type.GetType("System.Decimal");

        for (int ii = 0; ii < dt1.Rows.Count; ii++)
        {
            stuffInfo.Rows.Add(dt1.Rows[ii].ItemArray);
        }
        foreach (DataRow dr1 in stuffInfo.Rows)
        {
            foreach (DataRow dr2 in dt2.Rows)
            {
                if (dr1["ResourceCode"].ToString() == dr2["scode"].ToString())
                {
                    if (!string.IsNullOrEmpty(dr2["nums"].ToString()))
                    {
                        dr1["nums"] = Convert.ToDecimal(dr2["nums"].ToString());
                    }
                    else
                    {
                        dr1["nums"] = 0;
                    }

                    if (!string.IsNullOrEmpty(dr2["outNums"].ToString()))
                    {
                        dr1["outNums"] = Convert.ToDecimal(dr2["outNums"].ToString());
                    }
                    else
                    {
                        dr1["outNums"] = 0;
                    }

                }
            }
        }
        foreach (DataRow dr1 in stuffInfo.Rows)
        {
            if (string.IsNullOrEmpty(dr1["nums"].ToString()))
            {
                dr1["nums"] = 0;
            }
            if (string.IsNullOrEmpty(dr1["outNums"].ToString()))
            {
                dr1["outNums"] = 0;
            }
        }
        this.gvStuff.DataSource = stuffInfo;
		this.gvStuff.DataBind();
	}
	protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
	{
		this.BindGv();
	}
	protected void gvStuff_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["id"] = e.Row.RowIndex.ToString();
		}
		if (e.Row.RowType == DataControlRowType.Header)
		{
			TableCellCollection cells = e.Row.Cells;
			cells.Clear();
			cells.Add(new TableHeaderCell());
			cells[0].RowSpan = 2;
			cells[0].Text = "序号";
			cells.Add(new TableHeaderCell());
			cells[1].RowSpan = 2;
			cells[1].Text = "材料编号";
			cells.Add(new TableHeaderCell());
			cells[2].RowSpan = 2;
			cells[2].Text = "材料名称";
			cells.Add(new TableHeaderCell());
			cells[3].RowSpan = 2;
			cells[3].Text = "规格";
			cells.Add(new TableHeaderCell());
			cells[4].RowSpan = 2;
			cells[4].Text = "品牌";
			cells.Add(new TableHeaderCell());
			cells[5].RowSpan = 2;
			cells[5].Text = "型号";
			cells.Add(new TableHeaderCell());
			cells[6].ColumnSpan = 3;
			cells[6].Text = "目标成本";
			cells.Add(new TableHeaderCell());
			cells[7].ColumnSpan = 5;
			cells[7].Text = "在途成本";
			cells.Add(new TableHeaderCell());
			cells[8].ColumnSpan = 3;
			cells[8].Text = "实际成本";
			cells.Add(new TableHeaderCell());
			cells[9].ColumnSpan = 2;
			cells[9].Text = "盈亏";
			cells.Add(new TableHeaderCell());
			cells[10].ColumnSpan = 2;
			cells[10].Text = "结存";
            cells.Add(new TableHeaderCell());
            cells[11].ColumnSpan = 2;
            cells[11].Text = "需求、出库量</th></tr><tr class='header'>";

            cells.Add(new TableHeaderCell());
			cells[12].Text = "目标数量";
			cells.Add(new TableHeaderCell());
			cells[13].Text = "目标价格";
			cells.Add(new TableHeaderCell());
			cells[14].Text = "目标总金额";
			cells.Add(new TableHeaderCell());
			cells[15].Text = "采购数量累计";
			cells.Add(new TableHeaderCell());
			cells[16].Text = "采购价格";
			cells.Add(new TableHeaderCell());
			cells[17].Text = "采购金额累计";
			cells.Add(new TableHeaderCell());
			cells[18].Text = "入库数量累计";
			cells.Add(new TableHeaderCell());
			cells[19].Text = "入库金额累计";
			cells.Add(new TableHeaderCell());
			cells[20].Text = "实际数量";
			cells[20].Attributes.Add("title", "  实际数量 = 出库数量 &ndash; 退库数量 ");
			cells[20].CssClass = "tooltip";
			cells.Add(new TableHeaderCell());
			cells[21].Text = "实际价格";
			cells[21].Attributes.Add("title", "  实际价格 = 编制采购单时的价格 ");
			cells[21].CssClass = "tooltip";
			cells.Add(new TableHeaderCell());
			cells[22].Text = "实际金额";
			cells[22].Attributes.Add("title", "  实际数量 = 出库中成本归集于材料的物资金额 &ndash; 退库中成本归集于材料的物资金额 ");
			cells[22].CssClass = "tooltip";
			cells.Add(new TableHeaderCell());
			cells[23].Text = "数量";
			cells[23].Attributes.Add("title", " 数量 = 目标数量 &ndash; 采购数量 ");
			cells[23].CssClass = "tooltip";
			cells.Add(new TableHeaderCell());
			cells[24].Text = "金额";
			cells[24].Attributes.Add("title", "  金额 = 目标金额 &ndash; 采购金额 ");
			cells[24].CssClass = "tooltip";
			cells.Add(new TableHeaderCell());
			cells[25].Text = "数量";
			cells[25].Attributes.Add("title", "  数量 = 采购数量 &ndash; 出库数量 ");
			cells[25].CssClass = "tooltip";
			cells.Add(new TableHeaderCell());
			cells[26].Text = "金额";
			cells[26].Attributes.Add("title", "  金额 = 采购金额 &ndash;  出库金额 ");
			cells[26].CssClass = "tooltip";

          

            cells.Add(new TableHeaderCell());
            cells[27].Text = "已提需求量";
            //cells[27].Attributes.Add("title", "  金额 = 采购金额 &ndash;  出库金额 ");
            cells[27].CssClass = "tooltip";

            cells.Add(new TableHeaderCell());
            cells[28].Text = "已出库量";
            //cells[28].Attributes.Add("title", "  金额 = 采购金额 &ndash;  出库金额 ");
            cells[28].CssClass = "tooltip";
        }
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			string[] array = (string[])this.ViewState["Total"];
			e.Row.Cells[6].Text = array[0];
			e.Row.Cells[6].Style.Add("text-align", "right");
			e.Row.Cells[6].CssClass = "decimal_input";
			e.Row.Cells[8].Text = array[1];
			e.Row.Cells[8].Style.Add("text-align", "right");
			e.Row.Cells[8].CssClass = "decimal_input";
			e.Row.Cells[9].Text = array[2];
			e.Row.Cells[9].Style.Add("text-align", "right");
			e.Row.Cells[9].CssClass = "decimal_input";
			e.Row.Cells[11].Text = array[3];
			e.Row.Cells[11].Style.Add("text-align", "right");
			e.Row.Cells[11].CssClass = "decimal_input";
			e.Row.Cells[12].Text = array[4];
			e.Row.Cells[12].Style.Add("text-align", "right");
			e.Row.Cells[12].CssClass = "decimal_input";
			e.Row.Cells[13].Text = array[5];
			e.Row.Cells[13].Style.Add("text-align", "right");
			e.Row.Cells[13].CssClass = "decimal_input";
			e.Row.Cells[14].Text = array[6];
			e.Row.Cells[14].Style.Add("text-align", "right");
			e.Row.Cells[14].CssClass = "decimal_input";
			e.Row.Cells[16].Text = array[7];
			e.Row.Cells[16].Style.Add("text-align", "right");
			e.Row.Cells[16].CssClass = "decimal_input";
			e.Row.Cells[17].Text = array[8];
			e.Row.Cells[17].Style.Add("text-align", "right");
			e.Row.Cells[17].CssClass = "decimal_input";
			e.Row.Cells[18].Text = array[9];
			e.Row.Cells[18].Style.Add("text-align", "right");
			e.Row.Cells[18].CssClass = "decimal_input";
			e.Row.Cells[19].Text = array[10];
			e.Row.Cells[19].Style.Add("text-align", "right");
			e.Row.Cells[19].CssClass = "decimal_input";
			e.Row.Cells[20].Text = array[11];
			e.Row.Cells[20].Style.Add("text-align", "right");
			e.Row.Cells[20].CssClass = "decimal_input";


            e.Row.Cells[21].Text = array[12];
            e.Row.Cells[21].Style.Add("text-align", "right");
            e.Row.Cells[21].CssClass = "decimal_input";

            e.Row.Cells[22].Text = array[13];
            e.Row.Cells[22].Style.Add("text-align", "right");
            e.Row.Cells[22].CssClass = "decimal_input";
        }
	}
	protected void btn_Search_Click(object sender, System.EventArgs e)
	{
		this.ComputeTotal();
		this.BindGv();
	}
	protected void btnExcel_Click(object sender, System.EventArgs e)
	{
		DataTable dt1= this.treasuryStockBll.GetStuffInfo(this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.hfldPrjId.Value.Trim(), 0, 0, this.hfldIsWBSRelevance.Value, this.txtSpecification.Text.Trim(), this.txtBrand.Text.Trim(), this.txtModelNumber.Text.Trim());
        string strSql = string.Format(@"          with t1 as( SELECT t.TaskId, t.TaskName,t.ResourceId,t.ResourceCode scode,t.ResourceQuantity,w.numberIng--,sws.number--sum(sws.number) numberIng-- ,sws.wpcode
            FROM (SELECT  PrjGuid,TaskId,ResourceId,TaskName,ResourceCode,sum(ResourceQuantity) ResourceQuantity FROM (
			SELECT btr.PrjGuid,btr.TaskId,btr.ResourceId,bt.TaskName,rs.ResourceCode,btr.ResourceQuantity 
            FROM Bud_TaskResource btr 
            LEFT JOIN Res_Resource rs on btr.ResourceId=rs.ResourceId 
            LEFT JOIN Bud_Task bt on btr.TaskId=bt.TaskId
            where btr.PrjGuid='{0}' 
			UNION ALL SELECT  bm.PrjId,bmt.TaskId,bmts.ResourceId,bt.TaskName,rs.ResourceCode,bmts.ResourceQuantity FROM Bud_ModifyTaskRes bmts 
			LEFT JOIN Bud_ModifyTask bmt ON bmts.ModifyTaskId=bmt.ModifyTaskId 
			LEFT JOIN Bud_Modify bm ON bmt.ModifyId=bm.ModifyId 
			LEFT JOIN Bud_Task bt on bmt.TaskId=bt.TaskId 
			LEFT JOIN Res_Resource rs on bmts.ResourceId=rs.ResourceId 
			WHERE bm.flowstate !=-2 and bm.PrjId='{0}' ) s
			GROUP BY PrjGuid,TaskId,ResourceId,TaskName,ResourceCode )t 
			LEFT JOIN 
            ( SELECT sws.scode,sws.TaskId,sum(sws.number) numberIng from Sm_Wantplan_Stock sws --sw.flowstate,sw.swcode,
			LEFT JOIN  Sm_Wantplan sw ON sws.wpcode=sw.swcode 
			WHERE sw.flowstate !=-2 and sw.swcode !='' 
			GROUP BY sws.scode,sws.TaskId ) w ON w.scode=t.ResourceCode AND w.TaskId=t.TaskId)
          SELECT t1.*,t2.*,rs.ResourceName from t1 LEFT JOIN ( select sws.scode,sum(sws.number) nums,sw.procode,(select sum(sos.number) outNums from Sm_out_Stock sos WHERE sos.wpcode in( select sws.wpcode from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' ) and sos.scode=sws.scode) outNums
												from Sm_Wantplan_Stock sws LEFT JOIN Sm_Wantplan sw ON sws.wpcode=sw.swcode 
												where sw.procode='{0}' 	
												GROUP BY sws.scode,sw.procode )
												 t2 on t1.scode=t2.scode 	
												 LEFT JOIN Res_Resource rs on t1.ResourceId=rs.ResourceId  ", this.hfldPrjId.Value);
        DataTable dt2 = publicDbOpClass.DataTableQuary(strSql);
        DataTable stuffInfo = new DataTable();
        stuffInfo = dt1.Clone();
        stuffInfo.Columns.Add("nums");
        stuffInfo.Columns["nums"].DataType = Type.GetType("System.Decimal");
        stuffInfo.Columns.Add("outNums");
        stuffInfo.Columns["outNums"].DataType = Type.GetType("System.Decimal");

        for (int ii = 0; ii < dt1.Rows.Count; ii++)
        {
            stuffInfo.Rows.Add(dt1.Rows[ii].ItemArray);
        }
        foreach (DataRow dr1 in stuffInfo.Rows)
        {
            foreach (DataRow dr2 in dt2.Rows)
            {
                if (dr1["ResourceCode"].ToString() == dr2["scode"].ToString())
                {
                    if (!string.IsNullOrEmpty(dr2["nums"].ToString()))
                    {
                        dr1["nums"] = Convert.ToDecimal(dr2["nums"].ToString());
                    }
                    else
                    {
                        dr1["nums"] = 0;
                    }

                    if (!string.IsNullOrEmpty(dr2["outNums"].ToString()))
                    {
                        dr1["outNums"] = Convert.ToDecimal(dr2["outNums"].ToString());
                    }
                    else
                    {
                        dr1["outNums"] = 0;
                    }
                }
            }
        }
        foreach (DataRow dr1 in stuffInfo.Rows)
        {
            if (string.IsNullOrEmpty(dr1["nums"].ToString()))
            {
                dr1["nums"] = 0;
            }
            if (string.IsNullOrEmpty(dr1["outNums"].ToString()))
            {
                dr1["outNums"] = 0;
            }
        }

        if (stuffInfo.Rows.Count > 0)
		{
			DataRow dataRow = stuffInfo.NewRow();
			dataRow["Num"] = "合计";
			dataRow["BudQuantity"] = stuffInfo.Compute("sum(BudQuantity)", "1>0");
			dataRow["BudTotal"] = stuffInfo.Compute("sum(BudTotal)", "1>0");
			dataRow["PurchaseNumber"] = stuffInfo.Compute("sum(PurchaseNumber)", "1>0");
			dataRow["PurchaseCost"] = stuffInfo.Compute("sum(PurchaseCost)", "1>0");
			dataRow["StorageNumber"] = stuffInfo.Compute("sum(StorageNumber)", "1>0");
			dataRow["StorageCost"] = stuffInfo.Compute("sum(StorageCost)", "1>0");
			dataRow["RealityNumber"] = stuffInfo.Compute("sum(RealityNumber)", "1>0");
			dataRow["RealityTotal"] = stuffInfo.Compute("sum(RealityTotal)", "1>0");
			dataRow["ProfitLossNumber"] = stuffInfo.Compute("sum(ProfitLossNumber)", "1>0");
			dataRow["ProfitLossCost"] = stuffInfo.Compute("sum(ProfitLossCost)", "1>0");
			dataRow["BalanceNumber"] = stuffInfo.Compute("sum(BalanceNumber)", "1>0");
			dataRow["BalanceCost"] = stuffInfo.Compute("sum(BalanceCost)", "1>0");

            dataRow["nums"] = stuffInfo.Compute("sum(nums)", "1>0");
            dataRow["outNums"] = stuffInfo.Compute("sum(outNums)", "1>0");
            stuffInfo.Rows.Add(dataRow);
		}
        stuffInfo = this.GetTitleByTable(stuffInfo);
		System.Collections.Generic.List<ExcelHeader> list = new System.Collections.Generic.List<ExcelHeader>();
		list.Add(ExcelHeader.Create("目标成本", 1, 3, 6, 0));
		list.Add(ExcelHeader.Create("在途成本", 1, 5, 9, 0));
		list.Add(ExcelHeader.Create("实际成本", 1, 3, 14, 0));
		list.Add(ExcelHeader.Create("盈亏", 1, 2, 17, 0));
		list.Add(ExcelHeader.Create("结存", 1, 2, 19, 0));
		System.Collections.Generic.List<int> list2 = new System.Collections.Generic.List<int>();
		foreach (DataColumn dataColumn in stuffInfo.Columns)
		{
			if (dataColumn.Ordinal >= 6)
			{
				list2.Add(dataColumn.Ordinal);
			}
			if (dataColumn.Ordinal < 6)
			{
				list.Add(ExcelHeader.Create(dataColumn.ColumnName, 2, 0, 0, 2));
			}
			else
			{
				list.Add(ExcelHeader.Create(dataColumn.ColumnName, 2, 0, 0, 0));
			}
		}
		ExcelHelper.ExportExcel(stuffInfo, "材料分析", "材料分析", "材料分析.xls", list, null, 3, base.Request.Browser.Browser);
	}
	public DataTable GetTitleByTable(DataTable dt)
	{
		if (dt.Columns["Num"] != null)
		{
			dt.Columns["Num"].ColumnName = "序号";
		}
		if (dt.Columns["ResourceId"] != null)
		{
			dt.Columns.Remove(dt.Columns["ResourceId"]);
		}
		if (dt.Columns["ResourceCode"] != null)
		{
			dt.Columns["ResourceCode"].ColumnName = "材料编号";
		}
		if (dt.Columns["ResourceName"] != null)
		{
			dt.Columns["ResourceName"].ColumnName = "材料名称";
		}
		if (dt.Columns["Specification"] != null)
		{
			dt.Columns["Specification"].ColumnName = "规格";
		}
		if (dt.Columns["Brand"] != null)
		{
			dt.Columns["Brand"].ColumnName = "品牌";
		}
		if (dt.Columns["ModelNumber"] != null)
		{
			dt.Columns["ModelNumber"].ColumnName = "型号";
		}
		if (dt.Columns["BudQuantity"] != null)
		{
			dt.Columns["BudQuantity"].ColumnName = "目标数量";
		}
		if (dt.Columns["BudPrice"] != null)
		{
			dt.Columns["BudPrice"].ColumnName = "目标价格";
		}
		if (dt.Columns["BudTotal"] != null)
		{
			dt.Columns["BudTotal"].ColumnName = "目标总金额";
		}
		if (dt.Columns["PurchaseNumber"] != null)
		{
			dt.Columns["PurchaseNumber"].ColumnName = "采购数量累计";
		}
		if (dt.Columns["PurchaseSprice"] != null)
		{
			dt.Columns["PurchaseSprice"].ColumnName = "采购价格";
		}
		if (dt.Columns["PurchaseCost"] != null)
		{
			dt.Columns["PurchaseCost"].ColumnName = "采购金额累计";
		}
		if (dt.Columns["StorageNumber"] != null)
		{
			dt.Columns["StorageNumber"].ColumnName = "入库数量累计";
		}
		if (dt.Columns["StorageCost"] != null)
		{
			dt.Columns["StorageCost"].ColumnName = "入库金额累计";
		}
		if (dt.Columns["RealityNumber"] != null)
		{
			dt.Columns["RealityNumber"].ColumnName = "实际数量";
		}
		if (dt.Columns["RealityPrice"] != null)
		{
			dt.Columns["RealityPrice"].ColumnName = "实际价格";
		}
		if (dt.Columns["RealityTotal"] != null)
		{
			dt.Columns["RealityTotal"].ColumnName = "实际金额";
		}
		if (dt.Columns["ProfitLossNumber"] != null)
		{
			dt.Columns["ProfitLossNumber"].ColumnName = "数量";
		}
		if (dt.Columns["ProfitLossCost"] != null)
		{
			dt.Columns["ProfitLossCost"].ColumnName = "金额";
		}
		if (dt.Columns["BalanceNumber"] != null)
		{
			dt.Columns["BalanceNumber"].ColumnName = " 数量 ";
		}
		if (dt.Columns["BalanceCost"] != null)
		{
			dt.Columns["BalanceCost"].ColumnName = " 金额 ";
		}
        if (dt.Columns["nums"] != null)
        {
            dt.Columns["nums"].ColumnName = " 已提需求量 ";
        }
        if (dt.Columns["outNums"] != null)
        {
            dt.Columns["outNums"].ColumnName = " 已出库量 ";
        }
        dt.AcceptChanges();
		return dt;
	}
}


