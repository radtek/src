using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI.WebControls;

public partial class oa_JournalManage_JournalTypeList : NBasePage, IRequiresSessionState
{
    private OAJournalTypeService pcSer = new OAJournalTypeService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.DataBinds();
        }
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string value = this.GvList.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        //dropBind();
        this.DataBinds();
    }

    //private void dropBind()
    //{
    //    DataTable aLLProvince = publicDbOpClass.DataTableQuary("select * from OA_Journal_Type where is_use = 1");
    //    this.type_id.DataSource = aLLProvince;
    //    this.type_id.DataValueField = "id";
    //    this.type_id.DataTextField = "name";
    //    this.type_id.DataBind();
    //    this.type_id.Items.Insert(0, new ListItem("请选择", ""));
    //}

    protected void DataBinds()
    {
        IQueryable<OAJournalType> source = this.Queryable();
        this.AspNetPager1.RecordCount = source.Count<OAJournalType>();
        source =
            from p in source
            orderby p.sort descending
            select p;
        IQueryable<OAJournalType> dataSource = source.Skip((this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize).Take(this.AspNetPager1.PageSize);
        this.GvList.DataSource = dataSource;
        this.GvList.DataBind();
    }
    private IQueryable<OAJournalType> Queryable()
    {
        IQueryable<OAJournalType> queryable =
            from p in this.pcSer
            select p;
        if (!string.IsNullOrEmpty(name.Text))
        {
            queryable = 
                from p in queryable
                where p.name == name.Text
                select p;
        }
        if (is_use.SelectedValue != "")
        {
            queryable =
                from p in queryable
                where p.is_use == Convert.ToInt32(is_use.SelectedValue)
                select p;
        }
        return queryable;
    }

    protected void GvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvList.PageIndex = e.NewPageIndex;
        this.DataBinds();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }

    //protected void btnOn_Click(object sender, EventArgs e)
    //{
    //    System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
    //    string value = this.KeyId.Value;
    //    //if (value.Contains("["))
    //    //{
    //    //    list = JsonHelper.GetListFromJson(value);
    //    //    //this.pcSer.Update(model);
    //    //}
    //    //else
    //    //{
    //    //    list.Add(value);
    //    //}
    //    //this.pcSer.Update(list,1);
    //    base.RegisterShow("系统提示", "启用成功！");
    //    this.DataBinds();
    //}

    //protected void btnStop_Click(object sender, EventArgs e)
    //{
        
    //}
}