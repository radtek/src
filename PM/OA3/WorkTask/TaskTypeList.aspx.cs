using cn.justwin.BLL;
using DomainServices.cn.justwin.Domain.Services;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class OA3_WorkTask_TaskTypeList : NBasePage
{
    private TaskService pcSer = new TaskService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.DataBinds();
        }
    }
    protected void DataBinds()
    {
        int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
        string str2 = (pagesize * currentPageIndex).ToString();
        DataTable dtA = pcSer.GetTaskTypeTable(strWhere(), UserCode);
        DataRow[] rows = dtA.Select(" pageindex >=" + str + " and  pageindex<=" + str2);
        DataTable dtB = dtA.Clone();
        foreach (DataRow row in rows)
        {
            dtB.Rows.Add(row.ItemArray);
        }
        this.AspNetPager1.PageSize = NBasePage.pagesize;
        this.AspNetPager1.RecordCount = dtA.Rows.Count;
        this.GvList.DataSource = dtB;
        this.GvList.DataBind();
    }
    public string strWhere()
    {
        string strWhere = " ";// and ...
        if (!string.IsNullOrEmpty(this.name.Text))
        {
            strWhere += " and name like '%" + name.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(is_use.SelectedValue.ToString()))
        {
            strWhere += " and is_use  =" + is_use.SelectedValue + "";
        }
        return strWhere;
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string value = this.GvList.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
    }
}