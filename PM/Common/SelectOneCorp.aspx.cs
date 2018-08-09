using ASP;
using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class Common_SelectOneSupplier : NBasePage, IRequiresSessionState
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.AspNetPager1.PageSize = NBasePage.pagesize;
			this.InitPage();
		}
	}
	protected void btnQuery_Click(object sender, System.EventArgs e)
	{
		this.AspNetPager1.CurrentPageIndex = 1;
		this.BindCorp();
	}
	protected void gvwCodeList_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["id"] = this.gvwCodeList.DataKeys[e.Row.RowIndex]["CorpID"].ToString();
			e.Row.Attributes["name"] = this.gvwCodeList.DataKeys[e.Row.RowIndex]["CorpName"].ToString();
		}
	}
	protected void dropType_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		this.AspNetPager1.CurrentPageIndex = 1;
		this.BindCorp();
	}
	private void InitPage()
	{
		this.BindCorpType();
		this.BindCorp();
	}
	private void BindCorpType()
	{
        //string sqlString = "select codeid,CodeName from dbo.XPM_Basic_CodeList where typeId=4 and IsValid=1 and IsVisible=1";
        //DataTable dataSource = publicDbOpClass.DataTableQuary(sqlString);
        //this.ddlCorpType.DataSource = dataSource;
        //this.ddlCorpType.DataValueField = "codeid";
        //this.ddlCorpType.DataTextField = "CodeName";
        //this.ddlCorpType.DataBind();
        //this.ddlCorpType.Items.Insert(0, "请选择类别");
        //if (base.Request["t"] != null || base.Request["ci"] != null || base.Request["cti"] != null)
        //{
        //    base.DealType = (OpType)Enum.Parse(typeof(OpType), base.Request["t"]);
        //    this.CorpID = Convert.ToInt32(base.Request["ci"]);
        //    this.TypeID = Convert.ToInt32(base.Request["cti"]);
        //}
        //this.Custom_PageInit();
        //if (base.DealType == OpType.Upd)
        //{
        //    this.CorpInfoBind();
        //}

        XPMBasicCodeTypeService xPMBasicCodeTypeService = new XPMBasicCodeTypeService();
		XPMBasicCodeType bySignCode = xPMBasicCodeTypeService.GetBySignCode("CorpType");
		XPMBasicCodeListService xPMBasicCodeListService = new XPMBasicCodeListService();
		System.Collections.Generic.IList<XPMBasicCodeList> byTypeId = xPMBasicCodeListService.GetByTypeId(bySignCode.TypeID, base.UserCode);
		this.dropType.DataSource = byTypeId;
		this.dropType.DataBind();
	}
	private void BindCorp()
	{
		if (!string.IsNullOrEmpty(this.dropType.SelectedValue))
		{
			XPMBasicContactCorpService xPMBasicContactCorpService = new XPMBasicContactCorpService();
			int corpTypeId = System.Convert.ToInt32(this.dropType.SelectedValue);
			System.Collections.Generic.IList<XPMBasicContactCorp> list = xPMBasicContactCorpService.GetByCorpTypeId(corpTypeId);
			string corpName = this.txtName.Text.Trim();
			if (!string.IsNullOrEmpty(corpName))
			{
				list = (
					from c in list
					where c.CorpName.Contains(corpName)
					select c).ToList<XPMBasicContactCorp>();
			}
			this.AspNetPager1.RecordCount = list.Count;
			this.gvwCodeList.DataSource = list.Skip((this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).Take(this.AspNetPager1.PageSize);
			this.gvwCodeList.DataBind();
		}
	}
	protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
	{
		this.BindCorp();
	}
}


