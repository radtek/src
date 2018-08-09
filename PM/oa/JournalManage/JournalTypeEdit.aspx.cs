using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Tender;
using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class oa_JournalManage_JournalTypeEdit : NBasePage, IRequiresSessionState
{
    private OAJournalTypeService pcSer = new OAJournalTypeService();
    private string action = string.Empty;
    private string Id = string.Empty;

    protected override void OnInit(System.EventArgs e)
    {
        this.action = base.Request["action"];
        this.Id = base.Request["id"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            //dropBind();
            if (this.action == "add")
            {
                return;
            }
            if (this.action == "edit")
            {
                this.KeyId.Value = Id;
                this.Bind(Id);
            }
        }
    }
    private void Bind(string Id)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            OAJournalType model = this.pcSer.GetById(Id);
            if (model != null)
            {
                this.KeyId.Value = model.Id;//主键
                this.name.Text = model.name;//类型名称
                this.is_use.SelectedValue = model.is_use.ToString();//是否启用
                title_temp.Text = model.title_temp;//日志标题缺省值
                content_temp.Text = model.content_temp;//日志内容缺省值
                this.sort.Text = model.sort.ToString();//序号
                remark.Text = model.remark;//备注
            }
        }
    }
    protected OAJournalType GetModel()
    {
        OAJournalType model = new OAJournalType();
        model.Id = this.KeyId.Value;
        model.name = this.name.Text;//类型名称
        model.is_use = Convert.ToInt32(this.is_use.SelectedValue);//是否启用
        model.title_temp = title_temp.Text;//日志标题缺省值
        model.content_temp = content_temp.Text;//日志内容缺省值
        model.sort = Convert.ToInt32(this.sort.Text);//序号
        model.remark = remark.Text;//备注

        return model;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveData();
    }
    public void saveData()
    {
        OAJournalType model = this.GetModel();

        if (this.action == "add")
        {
            this.pcSer.Add(model);
        }
        else if (this.action == "edit")
        {
            this.pcSer.Update(model);
        }
        base.RegisterScript("top.ui.tabSuccess({parentName:'_JournalType'});");
    }
}