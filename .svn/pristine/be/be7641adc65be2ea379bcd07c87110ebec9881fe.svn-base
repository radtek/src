using ASP;
using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using com.jwsoft.pm.data;
using com.jwsoft.pm.entpm.action;
using PMBase.Basic;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class oa_SysAdmin_DeptSet_depedit : NBasePage, IRequiresSessionState
{
	private string action = string.Empty;
	private int sjdm;
	private int id;
	private PTdbmService dSer = new PTdbmService();

	protected override void OnInit(EventArgs e)
	{
		if (!string.IsNullOrEmpty(base.Request["action"]))
		{
			this.action = base.Request["action"];
		}
		if (!string.IsNullOrEmpty(base.Request["sjdm"]))
		{
			this.sjdm = Convert.ToInt32(base.Request["sjdm"]);
		}
		if (!string.IsNullOrEmpty(base.Request["id"]))
		{
			this.id = Convert.ToInt32(base.Request["id"]);
		}
		base.OnInit(e);
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack && this.action == "edit")
		{
			PTdbm byId = this.dSer.GetById(this.id);
			this.txtNo.Text = byId.I_xh.Value.ToString();
			this.txtName.Text = byId.V_BMMC;
		}
	}
	protected void btnOk_Click(object sender, EventArgs e)
	{
		if (this.action == "add")
		{
			this.AddDep();
			return;
		}
		if (this.action == "edit")
		{
			this.EditDep();
		}
	}
    private PTDUTYAction hrAction = new PTDUTYAction();
    private void AddDep()
    {
        int iNumber = Convert.ToInt32(this.txtNo.Text.Trim());
        string strDeptName = this.txtName.Text.Trim();
        DeptManageDb deptManageDb = new DeptManageDb();
        bool flag = deptManageDb.AddDepart(strDeptName, iNumber, this.sjdm, "");
        if (flag)
        {
            //int depID = Convert.ToInt32(publicDbOpClass.QuaryMaxid("pt_d_bm", "i_bmdm"));
            //DataTable dt = publicDbOpClass.DataTableQuary("select * from PT_d_bm where i_bmdm = " + depID);
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dataRow in dt.Rows)
            //    {
            //        try
            //        {
            //            string strResult = WXAPI.createWXdpt(dt.Rows[0]);
            //            if (strResult == "0")
            //            {
                            base.RegisterScript("addSucessed();");
            //            }
            //            else
            //            {
            //                base.RegisterScript("top.ui.show( '添加成功,同步到微信失败'); \n top.ui.closeWin(); \n");
            //            }
            //        }
            //        catch
            //        {
            //            base.RegisterScript("top.ui.show( '添加成功'); \n top.ui.closeWin(); \n");
            //        }
            //    }
            //}
            //else
            //{
            //    base.RegisterScript("top.ui.show( '添加成功,同步到微信失败'); \n top.ui.closeWin(); \n");
            //}
        }
        else
        {
            base.RegisterScript("top.ui.show( '添加失败'); \n top.ui.closeWin(); \n");
        }
    }
    private void EditDep()
	{
		try
		{
			int value = Convert.ToInt32(this.txtNo.Text.Trim());
			string v_BMMC = this.txtName.Text.Trim();
			PTdbm byId = this.dSer.GetById(this.id);
			byId.I_xh = new int?(value);
			byId.V_BMMC = v_BMMC;
			this.dSer.Update(byId);

            DataTable dt = publicDbOpClass.DataTableQuary("select * from PT_d_bm where i_bmdm = " + this.id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    try
                    {
                        string strResult = WXAPI.createWXdpt(dt.Rows[0]);
                        if (strResult == "0")
                        {
                            base.RegisterScript("editSucessed();");
                        }
                        else
                        {
                            base.RegisterScript("top.ui.show( '编辑成功,同步到微信失败'); \n top.ui.closeWin(); \n");
                        }
                    }
                    catch
                    {
                        base.RegisterScript("top.ui.show( '编辑成功,同步到微信失败'); \n top.ui.closeWin(); \n");
                    }
                }
            }
            else
            {
                base.RegisterScript("top.ui.show( '编辑成功,同步到微信失败'); \n top.ui.closeWin(); \n");
            }
           
		}
		catch
		{
			base.RegisterScript("top.ui.show( '编辑失败'); \n top.ui.closeWin(); \n");
		}
	}
}


