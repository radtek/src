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
public partial class AsTestEdit : NBasePage, IRequiresSessionState
{
	private AsTestService AstSer = new AsTestService();
	private string type = string.Empty;
	private string Id = string.Empty;

	protected override void OnInit(System.EventArgs e)
	{
		this.type = base.Request["action"];
		this.Id = base.Request["id"];
		base.OnInit(e);
	}
	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			if (this.type == "Add")
			{
				this.hlfUserCode.Value = base.UserCode;
				this.ApplicantId.Text = base.UserCode;
				return;
			}
			if (this.type == "Edit")
			{
				this.Bindpage();
			}
		}
	}
	protected void Bindpage()
	{
		if (!string.IsNullOrEmpty(this.Id))
		{
			AsTest byId = this.AstSer.GetById(this.Id);
			if (byId != null)
			{
				this.hlfUserCode.Value = byId.ApplicantId;
				this.ApplicantId.Text = byId.ApplicantId;
                this.Cash.Text = byId.Cash.ToString();
				this.ApplicationReason.Text = byId.ApplicationReason.ToString();
			}
		}
	}
	protected AsTest GetModel()
	{
        AsTest asTest = new AsTest();
		asTest.Id = (string.IsNullOrEmpty(this.Id) ? System.Guid.NewGuid().ToString() : this.Id);
        asTest.ApplicationDate = DateTime.Now;
		asTest.ApplicantId = this.hlfUserCode.Value.Trim();
		decimal num = string.IsNullOrEmpty(this.Cash.Text.Trim()) ? 0m : System.Convert.ToDecimal(this.Cash.Text.Trim());
		asTest.Cash = num;
        asTest.FlowState = -1;
        asTest.ApplicationReason = string.IsNullOrEmpty(this.ApplicationReason.Text.Trim()) ? "" : System.Convert.ToString(this.ApplicationReason.Text.Trim());
        return asTest;
	}
	protected void btnSave_Click(object sender, System.EventArgs e)
	{
        AsTest model = this.GetModel();
		if (this.type == "Add")
		{
			this.AstSer.Add(model);
		}
		else if (this.type == "Edit")
		{
			this.AstSer.Update(model);
		}
		base.RegisterScript("top.ui.tabSuccess({parentName:'_AsTestList'});");
	}
}


