using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain;
using cn.justwin.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class ResourceRelation : NBasePage, IRequiresSessionState
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindTv();
        }
    }
    public void BindTv()
    {
        TreeNode treeNode = new TreeNode("组装材料", "");
        if (base.Request["id"] == "")
        {
            treeNode.Select();
        }
        string arg_42_0 = base.Request["id"];
        DataTable resZZCL = cn.justwin.BLL.Resource.GetResZZCL();
    
            foreach (DataRow dr in resZZCL.Rows)
            {
                TreeNode treeNode2 = new TreeNode();
                treeNode2.PopulateOnDemand = true;
                treeNode2.Value = dr["ResourceId"].ToString();
                treeNode2.Text = dr["ResourceName"].ToString();
                if (base.Request["id"] == treeNode2.Value)
                {
                    treeNode2.Select();
                }
                treeNode.ChildNodes.Add(treeNode2);
            }
        this.tvResource.Nodes.Add(treeNode);
        if (base.Request["id"] == null && this.tvResource.Nodes.Count > 0)
        {
            this.tvResource.Nodes[0].Select();
        }
    }
    protected void TreeView_SelectedNodeChanged(object sender, System.EventArgs e)
    {
        iframe1.Attributes["src"] = "ResourceRelationDetail.aspx?id=" + this.tvResource.SelectedValue ;
    }
}


