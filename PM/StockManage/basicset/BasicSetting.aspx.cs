using ASP;
using cn.justwin.BLL;
using cn.justwin.stockBLL;
using cn.justwin.stockModel;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class StockManage_basicset_BasicSetting : NBasePage, IRequiresSessionState
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!this.Page.IsPostBack)
		{
			this.InitState();
		}
	}
	protected void butSubmit_Click(object sender, System.EventArgs e)
	{
		StockParameter.IsLowAlarm = this.cbNumAlarm.Checked;
		StockParameter.DepotType = this.rbModel.SelectedValue;
		StockParameter.DepotBindType = this.chkBind.Checked;
		StockParameter.ProjectTransparentSet = this.chkTransparent.Checked;
		StockParameter.ProjectAlarm = (this.chkRefuse.Checked ? ProjectAlarm.UnAlarm.ToString() : ProjectAlarm.Alarm.ToString());
		StockParameter.IsHighPlanAlarm = this.chkHighAlarm.Checked;
        if (!string.IsNullOrEmpty(this.txtHighAlarmLimit.Text.Trim()))
		{
			StockParameter.HighPlanAlarmLimit = double.Parse(this.txtHighAlarmLimit.Text.Trim());
		}
		StockParameter.IsMidPlanAlarm = this.chkMidAlarm.Checked;
		if (!string.IsNullOrEmpty(this.txtMidAlarmLowerLimit.Text.Trim()))
		{
			StockParameter.MidPlanAlarmLowerLimit = double.Parse(this.txtMidAlarmLowerLimit.Text.Trim());
		}
		if (!string.IsNullOrEmpty(this.txtMidAlarmUpperLimit.Text.Trim()))
		{
			StockParameter.MidPlanAlarmUpperLimit = double.Parse(this.txtMidAlarmUpperLimit.Text.Trim());
		}
		StockParameter.IsLowPlanAlarm = this.chkLowAlarm.Checked;
		if (!string.IsNullOrEmpty(this.txtLowAlarmLowerLimit.Text.Trim()))
		{
			StockParameter.LowPlanAlarmLowerLimit = double.Parse(this.txtLowAlarmLowerLimit.Text.Trim());
		}
		if (!string.IsNullOrEmpty(this.txtLowAlarmUpperLimit.Text.Trim()))
		{
			StockParameter.LowPlanAlarmUpperLimit = double.Parse(this.txtLowAlarmUpperLimit.Text.Trim());
		}
		StockParameter.IsContainPending = this.chkContainPending.Checked;
        #region
        StockParameter.ProjectAlarm2 = (this.chkRefuse2.Checked ? ProjectAlarm2.UnAlarm2.ToString() : ProjectAlarm2.Alarm2.ToString());
        StockParameter.IsHighPlanAlarm2 = this.chkHighAlarm2.Checked;
        if (!string.IsNullOrEmpty(this.txtHighAlarmLimit2.Text.Trim()))
        {
            StockParameter.HighPlanAlarmLimit2 = double.Parse(this.txtHighAlarmLimit2.Text.Trim());
        }
        StockParameter.IsMidPlanAlarm2 = this.chkMidAlarm2.Checked;
        if (!string.IsNullOrEmpty(this.txtMidAlarmLowerLimit2.Text.Trim()))
        {
            StockParameter.MidPlanAlarmLowerLimit2 = double.Parse(this.txtMidAlarmLowerLimit2.Text.Trim());
        }
        if (!string.IsNullOrEmpty(this.txtMidAlarmUpperLimit2.Text.Trim()))
        {
            StockParameter.MidPlanAlarmUpperLimit2 = double.Parse(this.txtMidAlarmUpperLimit2.Text.Trim());
        }
        StockParameter.IsLowPlanAlarm2 = this.chkLowAlarm2.Checked;
        if (!string.IsNullOrEmpty(this.txtLowAlarmLowerLimit2.Text.Trim()))
        {
            StockParameter.LowPlanAlarmLowerLimit2 = double.Parse(this.txtLowAlarmLowerLimit2.Text.Trim());
        }
        if (!string.IsNullOrEmpty(this.txtLowAlarmUpperLimit2.Text.Trim()))
        {
            StockParameter.LowPlanAlarmUpperLimit2 = double.Parse(this.txtLowAlarmUpperLimit2.Text.Trim());
        }
        StockParameter.IsContainPending2 = this.chkContainPending2.Checked;
        #endregion


        string str = string.Empty;
		if (StockParameter.DepotType == "TotalMode")
		{
			Treasury treasury = new Treasury();
			TreasuryModel treasuryModel = treasury.GetTotalTreasury();
			if (treasuryModel == null)
			{
				treasuryModel = treasury.SetTotalTreasuryByMinTcode();
				if (treasuryModel == null)
				{
					base.RegisterScript("top.ui.alert('总分模式必须设置一个总库，总库不能关联项目!')");
					StockParameter.DepotType = "ParallelMode";
					this.rbModel.SelectedValue = StockParameter.DepotType;
					return;
				}
				str = "总库名称为：" + treasuryModel.tname;
			}
			else
			{
				str = "总库名称为：" + treasuryModel.tname;
			}
			treasury.DelContrast();
		}
		int num = StockParameter.UpdateDatabase();
		if (num != 0)
		{
			base.ClientScript.RegisterStartupScript(base.GetType(), "", "top.ui.show('保存成功!<br>" + str + "');location='BasicSetting.aspx'", true);
			return;
		}
		base.ClientScript.RegisterStartupScript(base.GetType(), "", "top.ui.alert('保存失败！')", true);
	}
	protected void butReset_Click(object sender, System.EventArgs e)
	{
		this.InitState();
	}
	private void InitState()
	{
		this.cbNumAlarm.Checked = StockParameter.IsLowAlarm;
		this.rbModel.SelectedValue = StockParameter.DepotType;
		this.chkBind.Checked = StockParameter.DepotBindType;
		this.chkTransparent.Checked = StockParameter.ProjectTransparentSet;
		this.btnSetNum.Disabled = !this.cbNumAlarm.Checked;
		this.radlAlarm.SelectedValue = StockParameter.ProjectAlarm;
		this.chkHighAlarm.Checked = StockParameter.IsHighPlanAlarm;
		this.chkMidAlarm.Checked = StockParameter.IsMidPlanAlarm;
		this.chkLowAlarm.Checked = StockParameter.IsLowPlanAlarm;
		this.chkContainPending.Checked = StockParameter.IsContainPending;

        #region
        this.radlAlarm2.SelectedValue = StockParameter.ProjectAlarm2;
        this.chkHighAlarm2.Checked = StockParameter.IsHighPlanAlarm2;
        this.chkMidAlarm2.Checked = StockParameter.IsMidPlanAlarm2;
        this.chkLowAlarm2.Checked = StockParameter.IsLowPlanAlarm2;
        this.chkContainPending2.Checked = StockParameter.IsContainPending2;
        #endregion

        if (StockParameter.ProjectAlarm == ProjectAlarm.UnAlarm.ToString())
		{
			this.SetAlarmEnabled(false);
			this.chkRefuse.Checked = true;
			this.chkAlarm.Checked = false;
			this.txtHighAlarmLimit.Enabled = false;
			this.txtMidAlarmLowerLimit.Enabled = false;
			this.txtMidAlarmUpperLimit.Enabled = false;
			this.txtLowAlarmLowerLimit.Enabled = false;
			this.txtLowAlarmUpperLimit.Enabled = false;
			this.radlAlarm.SelectedValue = "UnAlarm";
        }
		else
		{
			this.SetAlarmEnabled(true);
			this.chkRefuse.Checked = false;
			this.chkAlarm.Checked = true;
			this.txtHighAlarmLimit.Enabled = true;
			this.txtMidAlarmLowerLimit.Enabled = true;
			this.txtMidAlarmUpperLimit.Enabled = true;
			this.txtLowAlarmLowerLimit.Enabled = true;
			this.txtLowAlarmUpperLimit.Enabled = true;
			this.radlAlarm.SelectedValue = "Alarm";
        }
        if (StockParameter.ProjectAlarm2 == ProjectAlarm2.UnAlarm2.ToString())
        {
            this.SetAlarmEnabled2(false);
            #region
            this.chkRefuse2.Checked = true;
            this.chkAlarm2.Checked = false;
            this.txtHighAlarmLimit2.Enabled = false;
            this.txtMidAlarmLowerLimit2.Enabled = false;
            this.txtMidAlarmUpperLimit2.Enabled = false;
            this.txtLowAlarmLowerLimit2.Enabled = false;
            this.txtLowAlarmUpperLimit2.Enabled = false;
            this.radlAlarm2.SelectedValue = "UnAlarm2";
            #endregion
        }
        else
        {
            this.SetAlarmEnabled2(true);
            #region
            this.chkRefuse2.Checked = false;
            this.chkAlarm2.Checked = true;
            this.txtHighAlarmLimit2.Enabled = true;
            this.txtMidAlarmLowerLimit2.Enabled = true;
            this.txtMidAlarmUpperLimit2.Enabled = true;
            this.txtLowAlarmLowerLimit2.Enabled = true;
            this.txtLowAlarmUpperLimit2.Enabled = true;
            this.radlAlarm2.SelectedValue = "Alarm2";
            #endregion
        }
        if (this.chkHighAlarm.Checked)
		{
			this.chkAlarm.Checked = true;
		}
		else
		{
			this.chkAlarm.Checked = false;
		}

        if (this.chkHighAlarm2.Checked)
        {
            this.chkAlarm2.Checked = true;
        }
        else
        {
            this.chkAlarm2.Checked = false;
        }
        this.txtHighAlarmLimit.Text = StockParameter.HighPlanAlarmLimit.ToString();
		this.txtMidAlarmLowerLimit.Text = StockParameter.MidPlanAlarmLowerLimit.ToString();
		this.txtMidAlarmUpperLimit.Text = StockParameter.MidPlanAlarmUpperLimit.ToString();
		this.txtLowAlarmLowerLimit.Text = StockParameter.LowPlanAlarmLowerLimit.ToString();
		this.txtLowAlarmUpperLimit.Text = StockParameter.LowPlanAlarmUpperLimit.ToString();

        #region
        if (this.chkHighAlarm2.Checked)
        {
            this.chkAlarm2.Checked = true;
        }
        else
        {
            this.chkAlarm2.Checked = false;
        }
        this.txtHighAlarmLimit2.Text = StockParameter.HighPlanAlarmLimit2.ToString();
        this.txtMidAlarmLowerLimit2.Text = StockParameter.MidPlanAlarmLowerLimit2.ToString();
        this.txtMidAlarmUpperLimit2.Text = StockParameter.MidPlanAlarmUpperLimit2.ToString();
        this.txtLowAlarmLowerLimit2.Text = StockParameter.LowPlanAlarmLowerLimit2.ToString();
        this.txtLowAlarmUpperLimit2.Text = StockParameter.LowPlanAlarmUpperLimit2.ToString();
        #endregion
    }
	private void SetAlarmEnabled(bool b)
	{
		this.chkAlarm.Enabled = b;
		this.chkHighAlarm.Enabled = b;
		this.chkMidAlarm.Enabled = b;
		this.chkLowAlarm.Enabled = b;
    }
    private void SetAlarmEnabled2(bool b)
    {
        this.chkAlarm2.Enabled = b;
        this.chkHighAlarm2.Enabled = b;
        this.chkMidAlarm2.Enabled = b;
        this.chkLowAlarm2.Enabled = b;
    }
    protected void chkRefuse_CheckedChanged(object sender, System.EventArgs e)
	{
		this.chkAlarm.Enabled = !this.chkRefuse.Checked;
		this.chkHighAlarm.Enabled = !this.chkRefuse.Checked;
		this.chkMidAlarm.Enabled = !this.chkRefuse.Checked;
		this.chkLowAlarm.Enabled = !this.chkRefuse.Checked;
		if (!this.chkRefuse.Checked)
		{
			this.txtHighAlarmLimit.Enabled = true;
			this.txtMidAlarmLowerLimit.Enabled = true;
			this.txtMidAlarmUpperLimit.Enabled = true;
			this.txtLowAlarmLowerLimit.Enabled = true;
			this.txtLowAlarmUpperLimit.Enabled = true;
			return;
		}
		this.txtHighAlarmLimit.Enabled = false;
		this.txtMidAlarmLowerLimit.Enabled = false;
		this.txtMidAlarmUpperLimit.Enabled = false;
		this.txtLowAlarmLowerLimit.Enabled = false;
		this.txtLowAlarmUpperLimit.Enabled = false;
	}
    protected void chkRefuse2_CheckedChanged(object sender, System.EventArgs e)
    {
        this.chkAlarm2.Enabled = !this.chkRefuse2.Checked;
        this.chkHighAlarm2.Enabled = !this.chkRefuse2.Checked;
        this.chkMidAlarm2.Enabled = !this.chkRefuse2.Checked;
        this.chkLowAlarm2.Enabled = !this.chkRefuse2.Checked;
        if (!this.chkRefuse2.Checked)
        {
            this.txtHighAlarmLimit2.Enabled = true;
            this.txtMidAlarmLowerLimit2.Enabled = true;
            this.txtMidAlarmUpperLimit2.Enabled = true;
            this.txtLowAlarmLowerLimit2.Enabled = true;
            this.txtLowAlarmUpperLimit2.Enabled = true;
            return;
        }
        this.txtHighAlarmLimit2.Enabled = false;
        this.txtMidAlarmLowerLimit2.Enabled = false;
        this.txtMidAlarmUpperLimit2.Enabled = false;
        this.txtLowAlarmLowerLimit2.Enabled = false;
        this.txtLowAlarmUpperLimit2.Enabled = false;
    }
    protected void chkAlarm_CheckedChanged(object sender, System.EventArgs e)
	{
		this.chkHighAlarm.Checked = this.chkAlarm.Checked;
		this.chkMidAlarm.Checked = this.chkAlarm.Checked;
		this.chkLowAlarm.Checked = this.chkAlarm.Checked;
	}
    protected void chkAlarm2_CheckedChanged(object sender, System.EventArgs e)
    {
        this.chkHighAlarm2.Checked = this.chkAlarm2.Checked;
        this.chkMidAlarm2.Checked = this.chkAlarm2.Checked;
        this.chkLowAlarm2.Checked = this.chkAlarm2.Checked;
    }
    protected void chkHighAlarm_CheckedChanged(object sender, System.EventArgs e)
	{
	}
	protected void chkMidAlarm_CheckedChanged(object sender, System.EventArgs e)
	{
	}
	protected void chkLowAlarm_CheckedChanged(object sender, System.EventArgs e)
	{
	}

    protected void chkHighAlarm2_CheckedChanged(object sender, System.EventArgs e)
    {
    }
    protected void chkMidAlarm2_CheckedChanged(object sender, System.EventArgs e)
    {
    }
    protected void chkLowAlarm2_CheckedChanged(object sender, System.EventArgs e)
    {
    }

    protected void radlAlarm_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		this.chkAlarm.Enabled = !this.chkRefuse.Checked;
		this.chkHighAlarm.Enabled = !this.chkRefuse.Checked;
		this.chkMidAlarm.Enabled = !this.chkRefuse.Checked;
		this.chkLowAlarm.Enabled = !this.chkRefuse.Checked;
		if (this.radlAlarm.SelectedValue == "UnAlarm")
		{
			this.chkRefuse.Checked = true;
			this.chkAlarm.Checked = false;
			this.txtHighAlarmLimit.Enabled = false;
			this.txtMidAlarmLowerLimit.Enabled = false;
			this.txtMidAlarmUpperLimit.Enabled = false;
			this.txtLowAlarmLowerLimit.Enabled = false;
			this.txtLowAlarmUpperLimit.Enabled = false;
			return;
		}
		this.chkAlarm.Checked = true;
		this.chkRefuse.Checked = false;
		this.chkHighAlarm.Checked = this.chkAlarm.Checked;
		this.chkMidAlarm.Checked = this.chkAlarm.Checked;
		this.chkLowAlarm.Checked = this.chkAlarm.Checked;
		this.txtHighAlarmLimit.Enabled = true;
		this.txtMidAlarmLowerLimit.Enabled = true;
		this.txtMidAlarmUpperLimit.Enabled = true;
		this.txtLowAlarmLowerLimit.Enabled = true;
		this.txtLowAlarmUpperLimit.Enabled = true;
	}

    protected void radlAlarm2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.chkAlarm2.Enabled = !this.chkRefuse2.Checked;
        this.chkHighAlarm2.Enabled = !this.chkRefuse2.Checked;
        this.chkMidAlarm2.Enabled = !this.chkRefuse2.Checked;
        this.chkLowAlarm2.Enabled = !this.chkRefuse2.Checked;
        if (this.radlAlarm2.SelectedValue == "UnAlarm2")
        {
            this.chkRefuse2.Checked = true;
            this.chkAlarm2.Checked = false;
            this.txtHighAlarmLimit2.Enabled = false;
            this.txtMidAlarmLowerLimit2.Enabled = false;
            this.txtMidAlarmUpperLimit2.Enabled = false;
            this.txtLowAlarmLowerLimit2.Enabled = false;
            this.txtLowAlarmUpperLimit2.Enabled = false;
            return;
        }
        this.chkAlarm2.Checked = true;
        this.chkRefuse2.Checked = false;
        this.chkHighAlarm2.Checked = this.chkAlarm2.Checked;
        this.chkMidAlarm2.Checked = this.chkAlarm2.Checked;
        this.chkLowAlarm2.Checked = this.chkAlarm2.Checked;
        this.txtHighAlarmLimit2.Enabled = true;
        this.txtMidAlarmLowerLimit2.Enabled = true;
        this.txtMidAlarmUpperLimit2.Enabled = true;
        this.txtLowAlarmLowerLimit2.Enabled = true;
        this.txtLowAlarmUpperLimit2.Enabled = true;
    }
}


