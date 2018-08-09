using cn.justwin.BLL;
using cn.justwin.contractBLL;
using cn.justwin.contractModel;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.PrjManager;
using cn.justwin.stockBLL;
using cn.justwin.stockBLL.Domain;
using cn.justwin.Tender;
using cn.justwin.Web;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Linq;
using System.Web.UI.WebControls;
using com.jwsoft.pm.data;

public partial class PrjManager_PrjInfoView : NBasePage, IRequiresSessionState
{
    private DataTable dtCount = new DataTable();
    private IncometContractBll incometContractBll = new IncometContractBll();
    private BudContractConsReportService rptSev = new BudContractConsReportService();
    private System.Collections.Generic.List<PayoutContractModel> contracts;
    private PayoutContract payoutContract = new PayoutContract();
    private readonly Purchase purchase = new Purchase();
    private readonly PurchaseStock purchaseStock = new PurchaseStock();
    private BudIndirectDiaryCostService budInCostSer = new BudIndirectDiaryCostService();
    private BudIndirectDiaryDetailsService indirDetailSer = new BudIndirectDiaryDetailsService();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["ic"]))
        {
            this.BindLbl(base.Request["ic"].ToString());
            this.upload.InnerHtml = this.FilesBind(base.Request["ic"].ToString());
            this.BindGv();

            DataTable dtcontract = this.SearchContracts();
                this.DataBindContracts(dtcontract);
            BindGv2(base.Request["ic"].ToString());
            tenderBondSelect(base.Request["ic"].ToString());//绑定投标保证金
        }
    }
    public string FilesBind(string recordCode)
    {
        string text = ConfigHelper.Get("ProjectFile");
        string result;
        try
        {
            string[] files = System.IO.Directory.GetFiles(base.Server.MapPath(text) + recordCode);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            string[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                string text2 = array[i];
                string text3 = string.Empty;
                text3 = text2.Substring(text2.LastIndexOf("\\") + 1);
                string str = text + "/" + recordCode;
                string str2 = str + "/" + text3;
                text3 = string.Concat(new string[]
                {
                    "<a  class=\"link\" target=_blank  href=\"../../Common/DownLoad.aspx?path=",
                    HttpUtility.UrlEncode(str2),
                    "\"  >",
                    text3,
                    "</a>"
                });
                stringBuilder.Append(text3);
                stringBuilder.Append(", ");
            }
            string text4 = string.Empty;
            if (stringBuilder.Length > 2)
            {
                text4 = stringBuilder.ToString().Substring(0, stringBuilder.Length - 2);
            }
            result = text4;
        }
        catch
        {
            result = "";
        }
        return result;
    }

    public string ReplaceTxt(string str)
    {
        if (!string.IsNullOrEmpty(str))
        {
            str = str.Replace(" ", "&nbsp;&nbsp;");
            str = str.Replace("\r\n", "<br/>");
        }
        return str;
    }
    private void BindLbl(string PrjId)
    {
        ProjectInfo byId = ProjectInfo.GetById(PrjId);
        if (byId != null)
        {
         
             this.lblPrjId.Text = PrjId.ToString();
            this.lblBllProducer.Text = byId.GetUserName(base.UserCode);
            this.lblPrintDate.Text = System.DateTime.Now.ToShortDateString();
            this.lblPrjState.Text = TypeList.GetTypeName(byId.PrjState.ToString(), "2", "ProjectState");
            this.lblBudgetWay.Text = TypeList.GetTypeName(byId.BudgetWay, "1", "ysType");
            this.lblContractWay.Text = TypeList.GetTypeName(byId.ContractWay, "1", "cbType");
            this.lblKeyPart.Text = TypeList.GetTypeName(byId.KeyPart, "1", "primaryGrade");
            this.lblPayCondition.Text = TypeList.GetTypeName(byId.PayCondition, "1", "payment");
            this.lblPayWay.Text = TypeList.GetTypeName(byId.PayWay, "1", "jsType");
            if (byId.PrjTypes != null)
            {
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                System.Text.StringBuilder stringBuilder2 = new System.Text.StringBuilder();
                foreach (ProjectKind current in byId.PrjTypes)
                {
                    stringBuilder2.Append(current.ProfessionalCost.ToString()).Append("<br />");
                    stringBuilder.Append(TypeList.GetTypeName(current.PrjKind, "1", "ProjectType")).Append("<br />");
                }
                this.lblPrjKindClass.Text = stringBuilder.ToString();
                this.lblPrjProfessionalCost.Text = stringBuilder2.ToString();
            }
            this.lblProperty.Text = TypeList.GetTypeName(byId.PrjProperty, "1", "ProjectProperty");
            this.lblInfoOrigin.Text = this.ReplaceTxt(byId.ProjInfoOrigin);
            this.lblElseRequest.Text = this.ReplaceTxt(byId.ProjElseRequest);
            this.lblQualityClass.Text = TypeList.GetTypeName(byId.QualityClass, "1", "ProjectQuality");
            if (byId.PrjRanks != null)
            {
                System.Text.StringBuilder stringBuilder3 = new System.Text.StringBuilder();
                foreach (ProjectRank current2 in byId.PrjRanks)
                {
                    stringBuilder3.Append(TypeList.GetTypeName(current2.Rank, "1", "zzGrade") + " " + current2.RankLevel).Append("<br />");
                }
                this.lblRank.Text = stringBuilder3.ToString();
            }
            this.lblTenderWay.Text = TypeList.GetTypeName(byId.TenderWay, "1", "zbType");
            this.lblXmgroup.Text = TypeList.GetXmlGroupName(byId.Xmgroup);
            if (byId.EngineeringTypes != null)
            {
                System.Text.StringBuilder stringBuilder4 = new System.Text.StringBuilder();
                foreach (EngineeringType current3 in byId.EngineeringTypes)
                {
                    stringBuilder4.Append(current3.ToString()).Append("<br />");
                }
                this.lblBuildingType.Text = stringBuilder4.ToString();
            }
            this.lblTelphone.Text = byId.Telephone;
            if (byId.ProgAgent != "")
            {
                this.lblAgent.Text = byId.ProgAgentName;
            }
            this.lblBuildingArea.Text = byId.BuildingArea;
            this.lblDesigner.Text = byId.Designer;
            this.lblDuration.Text = byId.Duration;
            this.lblEndDate.Text = Common2.GetTime(byId.EndDate);
            this.lblgrade.Text = byId.PrjGrade;
            this.lblInspector.Text = byId.Inspector;
            this.lblOtherStatement.Text = StringUtility.ReplaceTxt(byId.OtherStatement);
            this.lblPrjCode.Text = byId.PrjCode;
            if (byId.PrjCost.ToString() != "0" && byId.PrjCost.ToString() != "")
            {
                this.lblPrjCost.Text = byId.PrjCost.ToString();
            }
            this.lblPrjFundInfo.Text = byId.PrjFundInfo;
            this.lblPrjInfo.Text = StringUtility.ReplaceTxt(byId.PrjInfo);
            if (byId.PrjManager != "")
            {
                this.lblPrjManager.Text = byId.PrjManagerName;
            }
            if (byId.Businessman != "")
            {
                this.lblBusinessman.Text = byId.BusinessmanName;
            }
            this.lblPrjName.Text = byId.PrjName;
            this.lblPrjPlace.Text = byId.PrjPlace;
            this.lblRemark1.Text = StringUtility.ReplaceTxt(byId.Remark);
            this.lblStartDate.Text = Common2.GetTime(byId.StartDate);
            this.lblTotalHouseNum.Text = byId.TotalHouseNum;
            this.lblUndergroundArea.Text = byId.UndergroundArea;
            this.lblUsegrounArea.Text = byId.UsegrounArea;
            this.lblAfforestArea.Text = byId.AfforestArea;
            this.lblParkArea.Text = byId.ParkArea;
            if (byId.WorkUnit != "")
            {
                this.lblWorkUnit.Text = byId.WorkUnitName;
            }
            this.lblForecastProfitRate.Text = byId.ForecastProfitRate.ToString();
            this.lblEngineeringEstimates.Text = byId.EngineeringEstimates;
            if (byId.PrjDutyPerson != "")
            {
                this.lblDutyPerson.Text = byId.PrjDutyPersonName;
            }
            this.lblApprovalOf.Text = byId.PrjApprovalOf;
            this.lblFundWorkable.Text = byId.PrjFundWorkable;
            this.lblManagementMargin.Text = byId.ManagementMargin.ToString();
            this.lblMigrantQualityMarginRate.Text = byId.MigrantQualityMarginRate.ToString();
            this.lblWithholdingTaxRate.Text = byId.WithholdingTaxRate.ToString();
            this.lblPerformanceBond.Text = byId.PerformanceBond.ToString();
            this.lblElseMargin.Text = byId.ElseMargin.ToString();
            this.lblOwner.Text = byId.OwnerName;
            this.lblOwnerLinkMan.Text = byId.OwnerLinkMan;
            this.lblOwnerLinkManPhone.Text = byId.OwnerLinkPhone;
            this.lblOwnerAddress.Text = byId.OwnerAddress;
            this.lblCorp.Text = byId.ProjPeopleCorp;
            this.lblPhone.Text = byId.ProjPeopleTel;
            this.lblDuty.Text = byId.ProjPeopleDuty;
            this.lblName.Text = byId.ProjPeopleUserName;
            this.lblPrjManagerRequire.Text = byId.PrjManagerRequire;
            this.lblTechnicalLeaderRequire.Text = byId.TechnicalLeaderRequire;
            this.lblPrjReadOne.Text = WebUtil.GetUserNames(byId.PrjReadOne);
            if (!string.IsNullOrEmpty(byId.Province))
            {
                if (byId.City == "北京" || byId.City == "上海" || byId.City == "天津" || byId.City == "重庆" || byId.City == "香港" || byId.City == "澳门")
                {
                    this.lblArea.Text = byId.City;
                    return;
                }
                this.lblArea.Text = byId.Province + byId.City;
            }
        }
    }



    public string GetParty(string party)
    {
        PayoutContract payoutContract = new PayoutContract();
        DataTable dataTable = new DataTable();
        string result = string.Empty;
        if (!string.IsNullOrEmpty(party))
        {
            dataTable = payoutContract.GetBName(party.Split(new char[]
            {
                ','
            })[0]);
        }
        if (dataTable.Rows.Count > 0)
        {
            result = dataTable.Rows[0]["CorpName"].ToString();
        }
        return result;
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindGv();
    }
    public void BindGv()
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.Append(" and IsArchived='false' ");
        //if (this.txtSignPeople.Value.Trim() != "")
        //{
        //    stringBuilder.AppendFormat("AND v_xm LIKE '%{0}%'", this.Replace(this.txtSignPeople.Value.Trim()));
        //}
        //if (this.txtParty.Value.Trim() != "")
        //{
        //    stringBuilder.AppendFormat("AND Party LIKE '%{0}%'", this.Replace(this.txtParty.Value.Trim()));
        //}
        //if (this.txtCParty.Text.Trim() != "")
        //{
        //    stringBuilder.AppendFormat("AND CParty LIKE '%{0}%'", this.Replace(this.txtCParty.Text.Trim()));
        //}
        // this.dtCount = this.incometContractBll.GetTbByParam(this.Replace(this.txtContractCode.Text.Trim()), this.Replace(this.txtContractName.Text.Trim()), this.Replace(this.txtConType.Text.Trim()), this.txtStartSignedTime.Text.Trim(), this.txtEndSignedTime.Text.Trim(), this.txtStartContractPrice.Text.Trim(), this.txtEndContractPrice.Text.Trim(), this.txtProject.Text.Trim(), base.UserCode, stringBuilder.ToString());
        this.dtCount = this.incometContractBll.GetTbByParam("", "", "", "", "", "", "", this.lblPrjName.Text.Trim(), base.UserCode, stringBuilder.ToString());
        this.AspNetPager1.RecordCount = this.dtCount.Rows.Count;
        //this.BindGv(this.incometContractBll.GetTbByParamSort(this.Replace(this.txtContractCode.Text.Trim()), this.Replace(this.txtContractName.Text.Trim()), this.Replace(this.txtConType.Text.Trim()), this.txtStartSignedTime.Text.Trim(), this.txtEndSignedTime.Text.Trim(), this.txtStartContractPrice.Text.Trim(), this.txtEndContractPrice.Text.Trim(), this.txtProject.Text.Trim(), base.UserCode, stringBuilder.ToString(), this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize));
        this.BindGv(this.incometContractBll.GetTbByParamSort("", "", "", "", "", "", "", this.lblPrjName.Text.Trim(), base.UserCode, stringBuilder.ToString(), this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize));
    }
    public void BindGv(DataTable storageDataSource)
    {
        if (storageDataSource.Rows.Count == 0)
        {
            storageDataSource.Rows.Add(storageDataSource.NewRow());
            this.gvConract.DataSource = storageDataSource;
            this.gvConract.DataBind();
            this.gvConract.HeaderRow.Cells[0].Visible = false;
            this.gvConract.Rows[0].Visible = false;
            gvConract.Visible = false;
            return;
        }
        this.gvConract.DataSource = storageDataSource;
        this.gvConract.DataBind();
        decimal d = 0m;
        for (int i = 0; i < this.dtCount.Rows.Count; i++)
        {
            d += System.Convert.ToDecimal(WebUtil.GetEnPrice(this.dtCount.Rows[i]["ContractPrice"].ToString(), this.dtCount.Rows[i]["ContractId"].ToString()));
        }
        string[] value = new string[]
        {
            d.ToString()
        };
        int[] index = new int[]
        {
            4
        };
        GridViewUtility.AddTotalRow(this.gvConract, value, index);
    }
    public string Replace(string sourceStr)
    {
        sourceStr = sourceStr.Replace("'", "''");
        sourceStr = sourceStr.Replace("%", "[%]");
        return sourceStr;
    }
    protected void gvPurchaseplan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            try
            {
                e.Row.Attributes["id"] = this.gvConract.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["guid"] = this.gvConract.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["prjGuid"] = this.gvConract.DataKeys[e.Row.RowIndex].Values[3].ToString();
                if (this.gvConract.DataKeys[e.Row.RowIndex].Values[1].ToString() == "False")
                {
                    e.Row.Attributes["bstate"] = "False";
                }
                e.Row.Attributes["isMainContract"] = this.gvConract.DataKeys[e.Row.RowIndex].Values[1].ToString();
                e.Row.Attributes["FlowState"] = this.gvConract.DataKeys[e.Row.RowIndex].Values[2].ToString();
            }
            catch
            {
            }
        }
    }



    protected void AspNetPager2_PageChanged(object sender, System.EventArgs e)
    {
        DataTable dtcontract = this.SearchContracts();
        this.DataBindContracts(dtcontract);
    }
    //protected void btnSearch_Click(object sender, System.EventArgs e)
    //{
    //    this.AspNetPager2.CurrentPageIndex = 1;
    //    DataTable dtcontract = this.SearchContracts();
    //    this.DataBindContracts(dtcontract);
    //}
    private DataTable SearchContracts()
    {
        System.DateTime startDate = new System.DateTime(1753, 1, 1);
        System.DateTime endDate = new System.DateTime(9999, 12, 31);
        decimal startMoney = new decimal(-999999999999999L);
        decimal endMoney = new decimal(999999999999999L);
        //string text = string.Format(" AND (Con_Payout_Contract.BName like '%{0}%' OR CorpName like '%{1}%' ) \n", this.txtBName.Text.Trim(), this.txtBName.Text.Trim());
        //if (!string.IsNullOrEmpty(this.txtSignPersonName.Text.Trim()))
        //{
        //    text += string.Format(" AND YH.v_xm LIKE '%{0}%' \n", this.txtSignPersonName.Text.Trim());
        //}
        //this.contracts = this.payoutContract.SelectLedger(startDate, endDate, startMoney, endMoney, this.txtContractCode.Text.Trim(), this.txtContractName.Text.Trim(), this.txtConType.Text.Trim(), this.txtProject.Text.Trim(), base.UserCode, text);
        this.contracts = this.payoutContract.SelectLedger(startDate, endDate, startMoney, endMoney, "", "","", this.lblPrjName.Text.Trim(), base.UserCode, "");
        if (this.contracts == null || this.contracts.Count < 1)
        {
            this.AspNetPager1.RecordCount = 1;
        }
        else
        {
            this.AspNetPager1.RecordCount = this.contracts.Count;
        }
       // return this.payoutContract.SelectLedger(startDate, endDate, startMoney, endMoney, this.txtContractCode.Text.Trim(), this.txtContractName.Text.Trim(), this.txtConType.Text.Trim(), this.txtProject.Text.Trim(), base.UserCode, text, this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize);
        return this.payoutContract.SelectLedger(startDate, endDate, startMoney, endMoney, "", "", "", this.lblPrjName.Text.Trim(), base.UserCode, "", this.AspNetPager2.CurrentPageIndex, this.AspNetPager2.PageSize);
    }
    private void DataBindContracts(DataTable dtcontract)
    {
        this.gvwContract.DataSource = dtcontract;
        this.gvwContract.DataBind();
        decimal d = 0m;
        for (int i = 0; i < this.contracts.Count; i++)
        {
            d += System.Convert.ToDecimal(this.contracts[i].ModifiedMoney);
        }
        string[] value = new string[]
        {
            d.ToString()
        };
        int[] index = new int[]
        {
            4
        };
        GridViewUtility.AddTotalRow(this.gvwContract, value, index);
    }
    protected void gvwContract_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["id"] = this.gvwContract.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes["guid"] = this.gvwContract.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes["isMainContract"] = this.gvwContract.DataKeys[e.Row.RowIndex].Values[1].ToString();
            e.Row.Attributes["prjGuid"] = this.gvwContract.DataKeys[e.Row.RowIndex].Values[2].ToString();
            e.Row.Attributes["auditContent"] = "支出合同 ：" + this.gvwContract.DataKeys[e.Row.RowIndex].Values[3].ToString();
        }
    }

    public void BindGv2(string prjId)
    {
        string text = new System.DateTime(1753, 1, 1).ToString();
        string text2 = new System.DateTime(9999, 12, 31).ToString();
        this.AspNetPager3.PageSize = NBasePage.pagesize;
        //string person = this.txtPerson.Text.Trim();
        //string userName = string.Empty;
        //if (base.UserCode != "00000000")
        //{
        //    userName = WebUtil.GetUserNames(base.UserCode);
        //}
        //string text = this.txtStartDate.Text;
        //string text2 = this.txtEndDate.Text;
        //string deparment = this.txtDeparment.Text.Trim();
        //string name = this.txtName.Text.Trim();
        decimal? totalAmount = null;
        decimal? endCash = null;
        //if (!string.IsNullOrEmpty(this.txtTotalAmount.Text))
        //{
        //    totalAmount = new decimal?(System.Convert.ToDecimal(this.txtTotalAmount.Text));
        //}
        //if (!string.IsNullOrEmpty(this.txtEndCash.Text))
        //{
        //    endCash = new decimal?(System.Convert.ToDecimal(this.txtEndCash.Text));
        //}
        //int count = CostDiary.GetCount(this.prjId, person, text, text2, userName, deparment, this.txtName.Text, this.ddlFlowState.SelectedValue, totalAmount, endCash, this.costType);
        //DataTable diaries = CostDiary.GetDiaries(this.prjId, person, text, text2, userName, deparment, this.txtName.Text, this.ddlFlowState.SelectedValue, totalAmount, endCash, this.costType, this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex);
        int count = CostDiary.GetCount(prjId, "", text, text2, "", "", "", "", totalAmount, endCash, "P");
        DataTable diaries = CostDiary.GetDiaries(prjId, "", text, text2, "", "", "", "", totalAmount, endCash, "P", this.AspNetPager3.PageSize, this.AspNetPager3.CurrentPageIndex);
        this.AspNetPager3.RecordCount = count;
        this.gvBudget.DataSource = diaries;
        this.gvBudget.DataBind();
        //this.hfldPurchaseChecked.Value = string.Empty;
        if (this.gvBudget.Rows.Count > 0)
        {
            //base.RegisterScript("fillTotalAmount('" + CostDiary.GetDiariesTotal(this.prjId, person, userName, name, this.ddlFlowState.SelectedValue, text, text2, deparment, this.costType, totalAmount, endCash).ToString("#,##0.000") + "');showDetails();");
            //base.RegisterScript("fillTotalAmount('" + CostDiary.GetDiariesTotal(prjId, "", text, text2, "", "", "", "", "P", totalAmount, endCash).ToString("#,##0.000") + "');showDetails();");
            return;
        }
        //base.RegisterScript("showDetails();");
    }
    private void tenderBondSelect(string prjId)
    {
        string strSql = string.Format(@"
        SELECT [Id]
              ,[project_id]
              ,[money]
              ,[inDate]
              ,[inUserId]
              ,PT_yhmc.v_xm
              ,[ifNotice]
              ,[outDate]
              ,[useing]
              ,[remark]
          FROM [tenderBond] 
         LEFT JOIN PT_yhmc ON tenderBond.inUserId=PT_yhmc.v_yhdm
         WHERE [project_id] = '{0}' ", prjId);
        DataTable dt = publicDbOpClass.DataTableQuary(strSql);
        if (dt.Rows.Count > 0)
        {
            //tenderBondID.Text = dt.Rows[0]["Id"].ToString();
            money.Text = dt.Rows[0]["money"].ToString();
            inDate.Text = dt.Rows[0]["inDate"].ToString();
            //inUserId.Text = dt.Rows[0]["inUserId"].ToString();
            inUser.Text = dt.Rows[0]["v_xm"].ToString();
            if (dt.Rows[0]["ifNotice"].ToString()=="0")
            {
                ifNotice.Text = "是";
            }
            else if (dt.Rows[0]["ifNotice"].ToString() == "1")
            {
                ifNotice.Text = "否";
            }
            else
            {
                ifNotice.Text = "";
            }
            //ifNotice.Text = dt.Rows[0]["ifNotice"].ToString();
            outDate.Text = dt.Rows[0]["outDate"].ToString();
            useing.Text = dt.Rows[0]["useing"].ToString();
            remark.Text = dt.Rows[0]["remark"].ToString();
        }
        else
        {

        }
    }
    protected void AspNetPager3_PageChanged(object sender, System.EventArgs e)
    {
        this.BindGv2(this.lblPrjId.Text.ToString());
    }
    protected void gvBudget_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["id"] = this.gvBudget.DataKeys[e.Row.RowIndex]["InDiaryId"].ToString();
            e.Row.Attributes["guid"] = this.gvBudget.DataKeys[e.Row.RowIndex]["InDiaryId"].ToString();
        }
    }
    
    public decimal GetAmountSum(string Id)
    {
        return (
            from p in indirDetailSer
            where p.InDiaryId == Id
            select p.Amount).ToList<decimal>().Sum();
    }
    public decimal GetAuditAmountSum(string Id)
    {
        return (
            from p in this.indirDetailSer
            where p.InDiaryId == Id
            select p.AuditAmount).ToList<decimal>().Sum();
    }
    public string IsAudit(string Id)
    {
        BudIndirectDiaryCost byId = this.budInCostSer.GetById(Id);
        if (byId == null)
        {
            return string.Empty;
        }
        if (!byId.IsAudit)
        {
            return "未核销";
        }
        return "已核销";
    }
}


