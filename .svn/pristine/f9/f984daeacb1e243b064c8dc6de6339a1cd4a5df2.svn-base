using cn.justwin.BLL;
using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysSet_list : NBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.DataBinds();
        }
    }

    private void DataBinds()
    {
        int pagesize = 999;
        int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
        string str2 = (pagesize * currentPageIndex).ToString();
        DataTable dtA = GetTaskTypeTable(strWhere(), UserCode);
        DataRow[] rows = dtA.Select(" pageindex >=" + str + " and  pageindex<=" + str2);
        DataTable dtB = dtA.Clone();
        foreach (DataRow row in rows)
        {
            dtB.Rows.Add(row.ItemArray);
        }
        this.AspNetPager1.PageSize = pagesize;//NBasePage.pagesize;
        this.AspNetPager1.RecordCount = dtA.Rows.Count;
        this.GvList.DataSource = dtB;
        this.GvList.DataBind();
    }

    private string strWhere()
    {
        string strWhere = " ";// and ...
      
        if (!string.IsNullOrEmpty(Note.Text))
        {
            strWhere += " and Note like '%" + Note.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(ParaName.Text))
        {
            strWhere += " and ParaName like '%" + ParaName.Text.ToString().Trim() + "%'";
        }
        strWhere += " order by Id desc";
        return strWhere;
    }

    private DataTable GetTaskTypeTable(string strWhere, string userCode)
    {
        string strSQL = @"select row_number() over (ORDER BY Id desc) as pageindex,
                          Id,ParaName,ParaValue,Note from Basic_Config where 1=1 " + strWhere;
        return publicDbOpClass.DataTableQuary(strSQL);
    }

    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = this.GvList.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
            }
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        DataBinds();
    }
}