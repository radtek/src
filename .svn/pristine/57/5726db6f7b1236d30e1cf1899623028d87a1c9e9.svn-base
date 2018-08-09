using cn.justwin.BLL;
using System;
using System.Web.UI.WebControls;

public partial class OA3_FileMsg_MenuPowerFream :  NBasePage
{
    //private string action = string.Empty;
    //private string DocAttribute = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        //this.action = base.Request["action"];
        //this.DocAttribute = base.Request["DocAttribute"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindTree();
        }
    }
    public void BindTree()
    {
        System.Collections.Generic.List<FileModel> listArray = FileService.GetListArray(" where ParentId = Id and FileType!=0  and IsValid=0  order by CreateTime desc");
        foreach (FileModel current in listArray)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Value = current.Id;
            treeNode.Text = current.FileName;
            if (base.Request.QueryString["PId"] != null && base.Request.QueryString["PId"] == current.Id)
            {
                treeNode.Select();
            }
            treeNode.ImageUrl = "/images/tree/FileInfo/folder.gif";
            this.AddNode(treeNode);
            this.tvFile.Nodes.Add(treeNode);
        }
        if (this.tvFile.Nodes.Count > 0 && this.tvFile.SelectedValue == "")
        {
            this.tvFile.Nodes[0].Select();
            this.tvFile.Nodes[0].ImageUrl = "/images/tree/FileInfo/folder.gif";
        }
        BindUrl(this.tvFile.SelectedValue.ToString());
    }

    public TreeNode AddNode(TreeNode node)
    {
        System.Collections.Generic.List<FileModel> listArray = FileService.GetListArray(" where ParentId='" + node.Value + "' and id != parentId and FileType!=0  and IsValid=0  order by CreateTime desc");
        foreach (FileModel current in listArray)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.ImageUrl = this.imageUrl(current.Id);
            treeNode.Value = current.Id;
            treeNode.Text = current.FileName;
            node.ChildNodes.Add(treeNode);
            if (base.Request["id"] == current.Id)
            {
                treeNode.Select();
                this.ExpandSelectNode(treeNode);
            }
            this.AddNode(treeNode);
        }
        return node;
    }
    protected void ExpandSelectNode(TreeNode node)
    {
        if (node != null)
        {
            TreeNode parent = node.Parent;
            if (node.Depth == 1 || parent == null)
            {
                node.ExpandAll();
                return;
            }
            if (parent.Depth == 1)
            {
                parent.ExpandAll();
                return;
            }
            this.ExpandSelectNode(parent);
        }
    }
    protected void tvFile_SelectedNodeChanged(object sender, System.EventArgs e)
    {
        BindUrl(this.tvFile.SelectedValue.ToString());
    }
    public string imageUrl(string id)
    {
        string result = "/images/tree/FileInfo/folderSubtract.png";
        if (FileService.GetListArray(" where parentId='" + id + "' AND FileType=2 AND IsValid=0").Count > 0)
        {
            result = "/images/tree/FileInfo/folderAdd.png";
        }
        return result;
    }
    /// <summary>
    /// 绑定ifream(文档页面) 的url
    /// </summary>
    /// <param name="hid">目录ID</param>
    private void BindUrl(string hid)
    {
        iframe1.Attributes["src"] = "MenuPowerList.aspx?hid=" + hid;
    }
}