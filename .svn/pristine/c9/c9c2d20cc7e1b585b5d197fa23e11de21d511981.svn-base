using ASP;
using cn.justwin.BLL;
using com.jwsoft.pm.entpm.action;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class OA3_FileMsg_UserControl_DocRelation : NBasePage, IRequiresSessionState
{
    private ContAction contaction = new ContAction();
    private string prjId = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        //if (!string.IsNullOrEmpty(base.Request["PrjGuid"]))
        //{
        //    this.prjId = base.Request["PrjGuid"].ToString();
        //}
        base.OnInit(e);
    }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindView();
        }
    }
    private void BindView()
    {
        int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
        string str2 = (pagesize * currentPageIndex).ToString();
        string strW = " and OA_File.IsValid=0 and FileType=0 ";
        DataTable dtA = FileService.GetFileInfo(strW);
        DataRow[] rows = dtA.Select(" pageindex >=" + str + " and  pageindex<=" + str2);
        DataTable dtB = dtA.Clone();
        foreach (DataRow row in rows)
        {
            dtB.Rows.Add(row.ItemArray);
        }
        this.AspNetPager1.PageSize = NBasePage.pagesize;
        this.AspNetPager1.RecordCount = dtA.Rows.Count;
        this.gvFile.DataSource = dtB;
        this.gvFile.DataBind();
    }

    protected void gvFile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex > -1)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string value = this.gvFile.DataKeys[e.Row.RowIndex].Value.ToString();
        //        e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
        //    }
        //}

        //if (e.Row.RowIndex > -1)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataRowView dataRowView = (DataRowView)e.Row.DataItem;
        //        e.Row.Attributes["id"] = dataRowView["Id"].ToString();
        //        e.Row.Attributes["onclick"] = string.Concat(new object[]
        //        {
        //        "doClick(this,'",
        //        this.gvFile.ClientID,
        //        "');clickRow('",
        //        dataRowView["Id"],
        //        "','",
        //        dataRowView["FileName"],
        //        "');"
        //        });
        //        //e.Row.Attributes["onmouseover"] = "doMouseOver(this);";
        //        //e.Row.Attributes["onmouseout"] = "doMouseOut(this);";
        //        e.Row.Attributes["ondblclick"] = "doDblClickRow('" + dataRowView["Id"] + "');";
        //    }
        //}

        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dv = (DataRowView)e.Row.DataItem;
                e.Row.Attributes["id"] = dv["Id"].ToString();
                e.Row.Attributes["name"] = dv["FileName"].ToString();
            }
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindView();
    }
}
