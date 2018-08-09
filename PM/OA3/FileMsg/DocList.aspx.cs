using cn.justwin.BLL;
using System.Data;
using System.Web.UI.WebControls;
using System;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System.Data.SqlClient;
using cn.justwin.DAL;
using System.Web;
using System.Text;
using System.IO;
using System.Windows.Forms;

public partial class OA3_FileMsg_DocList : NBasePage
{
    BonkerZip zip = new BonkerZip();
    private string hid = string.Empty;
    private string prjId = string.Empty;
    private string action = string.Empty;

    protected override void OnInit(System.EventArgs e)
    {
        this.hid = base.Request["hid"];
        this.action = base.Request["action"];
        try
        {
            this.prjId = base.Request["prjId"];
        }
        catch
        {
            this.prjId = "";
        }

        base.OnInit(e);
    }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            BindDropDownList("DocVersion");//绑定 文档版本
            BindDropDownList("DocType");//绑定 文档类型
            BindDropDownList("DocStatus");//绑定 文档状态
            FileService.UpdateDataStatus();
            this.DataBinds();
            if (!string.IsNullOrEmpty(prjId))
            {
                btnDown.Visible = true;
            }
            else
            {
                btnDown.Visible = false;
            }
            
        }
    }
    /// <summary>
    /// 绑定文档版本、文档类型、文档状态//、文档变更类型
    /// </summary>
    /// <param name="strType">类型关键字</param>
    private void BindDropDownList(string strType)
    {
        DataTable dt = publicDbOpClass.DataTableQuary("select * from XPM_Basic_CodeList WHERE SignCode2='" + strType + "' order by I_xh asc");
        //if (strType == "DocChangeType")
        //{
        //    this.DocChangeTypeID.DataSource = dt;
        //    this.DocChangeTypeID.DataValueField = "NoteID";
        //    this.DocChangeTypeID.DataTextField = "CodeName";
        //    this.DocChangeTypeID.DataBind();
        //    //this.DocChangeType.Items.Insert(0, new ListItem("请选择", ""));
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr["IsDefault"].ToString() == "True")
        //        {
        //            DocChangeTypeID.SelectedValue = dr["NoteID"].ToString();
        //            break;
        //        }
        //    }
        //}
        if (strType == "DocVersion")
        {
            this.DocVersionID.DataSource = dt;
            this.DocVersionID.DataValueField = "NoteID";
            this.DocVersionID.DataTextField = "CodeName";
            this.DocVersionID.DataBind();
            this.DocVersionID.Items.Insert(0, new ListItem("请选择", ""));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["IsDefault"].ToString() == "True")
            //    {
            //        DocVersionID.SelectedValue = dr["NoteID"].ToString();
            //        break;
            //    }
            //}
        }
        if (strType == "DocType")
        {
            this.DocTypeID.DataSource = dt;
            this.DocTypeID.DataValueField = "NoteID";
            this.DocTypeID.DataTextField = "CodeName";
            this.DocTypeID.DataBind();
            this.DocTypeID.Items.Insert(0, new ListItem("请选择", ""));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["IsDefault"].ToString() == "True")
            //    {
            //        DocTypeID.SelectedValue = dr["NoteID"].ToString();
            //        break;
            //    }
            //}
        }
        if (strType == "DocStatus")
        {
            this.DocStatusID.DataSource = dt;
            this.DocStatusID.DataValueField = "NoteID";
            this.DocStatusID.DataTextField = "CodeName";
            this.DocStatusID.DataBind();
            this.DocStatusID.Items.Insert(0, new ListItem("请选择", ""));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["IsDefault"].ToString() == "True")
            //    {
            //        DocStatusID.SelectedValue = dr["NoteID"].ToString();
            //        break;
            //    }
            //}
        }
    }
    /// <summary>
    /// 设置文档列表按钮的显隐
    /// </summary>
    /// <param name="a">文档属性</param>
    private void SetbBtnIfShow(string a)
    {
        if (a == "0")//文档初版 审批
        {
            this.WF1.BusiCode = "173";
            this.btnAdd.Visible = true;
            this.btnCopy.Visible = true;
            this.btnChange.Visible = false;
            this.btnUp.Visible = false;
            this.btnEdit.Visible = true;
            this.btnSC.Visible = true;
            this.WF1.Visible = true;
        }
        else if (a == "1")//文档升版 审批
        {
            this.WF1.BusiCode = "174";
            this.btnAdd.Visible = false;
            this.btnCopy.Visible = false;
            this.btnChange.Visible = false;
            this.btnUp.Visible = true;
            this.btnEdit.Visible = false;
            this.btnSC.Visible = false;
            this.WF1.Visible = true;
        }
        else if (a == "2")//文档变更 无审批
        {
            this.WF1.BusiCode = "173";
            this.btnAdd.Visible = false;
            this.btnCopy.Visible = false;
            this.btnChange.Visible = true;
            this.btnUp.Visible = false;
            this.btnEdit.Visible = false;
            this.btnSC.Visible = false;
            this.WF1.Visible = false;
        }
        else //文档查看
        {

            this.WF1.BusiCode = "173";
            this.btnAdd.Visible = false;
            this.btnCopy.Visible = false;
            this.btnChange.Visible = false;
            this.btnUp.Visible = false;
            this.btnEdit.Visible = false;
            this.btnSC.Visible = false;
            this.WF1.Visible = false;
        }
    }
    protected void DataBinds()
    {

        this.hdSeleValue.Value = hid;
        string strUsers = string.Empty;
        if (action == "write")
        {
            strUsers = FileService.GetWriteByMenuID(hid);//获取该目录的有写入的权限用户
        }
        else if (action == "read")
        {
            strUsers = FileService.GetReadByMenuID(hid);//获取该目录的有读取的权限用户
        }

        if ((!string.IsNullOrEmpty(strUsers) && strUsers.Contains(this.UserCode)) || !string.IsNullOrEmpty(prjId))
        {
            if (!string.IsNullOrEmpty(base.Request["DocAttribute"]))
            {
                this.SetbBtnIfShow(base.Request["DocAttribute"].ToString());
            }
            else
            {
                this.SetbBtnIfShow("");
            }
            int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
            string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
            string str2 = (pagesize * currentPageIndex).ToString();
            DataTable dtA = FileService.GetFileInfo(strWhere());
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
            if (dtA.Rows.Count == 0)
            {
                this.lblMsgAleave.Text = "<div style='margin-left:20px; margin-top:20px; '>该目录中没有文档信息。</div>";
            }
            else
            {
                this.lblMsgAleave.Text = "";
            }
            return;
        }
        else
        {
            this.SetbBtnIfShow("");
            this.gvFile.DataBind();
            this.btnQuery.Enabled = false;
            this.lblMsgAleave.Text = "<div style='color:Red; margin-left:20px; margin-top:20px; '>您没有该目录的读写权限，请与系统管理员联系。</div>";
        }

    }

    private string strWhere()
    {
        string strWhere = " ";// and ...
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);
        if (startTime.HasValue)
        {
            strWhere += " and DocEditDate >='" + startTime.Value + "'";
        }
        if (endTime.HasValue)
        {
            strWhere += " and DocEditDate <'" + endTime.Value.AddDays(1.0) + "'";
        }

        if (!string.IsNullOrEmpty(DocCode.Text))
        {
            strWhere += " and DocCode like '%" + DocCode.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(FileName.Text))
        {
            strWhere += " and OA_File.FileName like '%" + FileName.Text.ToString().Trim() + "%'";
        }
        if (DocTypeID.SelectedValue != "")
        {
            strWhere += " and DocTypeID ='" + DocTypeID.SelectedValue + "'";
        }
        if (DocStatusID.SelectedValue != "")
        {
            strWhere += " and DocStatusID ='" + DocStatusID.SelectedValue + "'";
        }
        if (DocVersionID.SelectedValue != "")
        {
            strWhere += " and DocVersionID ='" + DocVersionID.SelectedValue + "'";
        }
        if (!string.IsNullOrEmpty(hid)) //(hid != "")
        {
            strWhere += " and ParentId ='" + hid + "'";
        }
        else
        {
            if (!string.IsNullOrEmpty(prjId))
            {
                string strIDs = string.Empty;
                string strIDs2 = string.Empty;
                System.Collections.Generic.List<FileModel> listArray = FileService.GetListArray(" where  FileType!=0  and IsValid=0  order by CreateTime desc");//ParentId = Id and
                foreach (FileModel current in listArray)
                {
                    string strUsers = FileService.GetReadByMenuID(current.Id);//获取该目录的有读取的权限用户
                    if (!string.IsNullOrEmpty(strUsers) && strUsers.Contains(this.UserCode))
                    {
                        strIDs += "'" + current.Id + "',";
                    }
                }
                if (strIDs.Length > 0)
                {
                    strWhere += " and ParentId in (" + strIDs.Substring(0, strIDs.Length - 1) + ")";
                }
            }
            else
            {
                strWhere += " and ParentId ='未选中目录'";
            }
        }
        if (!string.IsNullOrEmpty(prjId))
        {
            strWhere += " and project_id ='" + prjId + "'";
        }
        string a = base.Request["DocAttribute"].ToString();
        if (a == "0")//文档初版 
        {
            strWhere += " and (DocAttribute ='" + a + "' or (DocAttribute ='1' and DocCBFlowStatus='1') or DocAttribute ='2')";
        }
        else if (a == "1")//文档升版 
        {
            strWhere += " and (DocAttribute ='" + a + "' or (DocAttribute ='0' and DocCBFlowStatus='1') or DocAttribute ='2')";
        }
        else if (a == "2")//文档变更 
        {
            strWhere += " and (DocAttribute ='" + a + "' or (DocAttribute ='0' and DocCBFlowStatus='1') or (DocAttribute ='1' and DocSBFlowStatus='1'))";
        }

        strWhere += " and OA_File.IsValid=0 and FileType=0 ";
        return strWhere;
    }
    protected void gvFile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = this.gvFile.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
            }
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }
    protected void btnSC_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.KeyId.Value.ToString()))
        {
            base.RegisterShow("系统提示", "没有获取到选中项,请重新选择！");
            return;
        }
        string strTemp = this.KeyId.Value.ToString();
        string strIDs = "";
        if (strTemp.Split(',').Length > 1)
        {
            strIDs = strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }
        else
        {
            strIDs = " ('" + strTemp + "')";//strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }
        string strSqlIF = "select * FROM OA_File where DocCBFlowStatus !=-1 and DocSBFlowStatus !=-1 and Id in " + strIDs;
        DataTable dt = publicDbOpClass.DataTableQuary(strSqlIF);
        if (dt.Rows.Count > 0)
        {
            base.RegisterShow("系统提示", "只能删除状态为\"未提交\"的数据,请重新选择！");
            return;
        }
        string strSql = string.Format(@"UPDATE [OA_File] SET [IsValid] = 1 WHERE [id] in {0}", strIDs);
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                base.RegisterShow("系统提示", "操作成功！");
                this.DataBinds();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\操作失败！" + ex.Message.ToString() + "');");
            }
        }
    }

    #region 参考,代码
    //protected void btnDel_Click(object sender, System.EventArgs e)
    //{
    // string value = this.hfldPurchaseChecked.Value;
    //System.Collections.Generic.List<string> listFromJson = JsonHelper.GetListFromJson(value);
    //string text = "已成功删除！";
    //try
    //{
    //    foreach (string current in listFromJson)
    //    {
    //        FileService.MoveRecycle(current);
    //    }
    //}
    //catch
    //{
    //    text = "删除失败！";
    //}
    //base.RegisterLoadEvent(string.Concat(new object[]
    //{
    //    "function() {alert('系统提示：\\n\\n",
    //    text,
    //    "');location='FileInfoList.aspx?id=",
    //    this.tvFile.SelectedValue,
    //    //"&did=",
    //    //this.ddlScope.SelectedValue,
    //    "&search=",
    //    this.ViewState["search"],
    //    "'}"
    //}));
    //}
    //public void DelFile(System.Collections.Generic.List<string> listId)
    //{
    //    foreach (string current in listId)
    //    {
    //        if (!string.IsNullOrEmpty(current))
    //        {
    //            FileModel model = FileService.GetModel(current);
    //            if (model.FileType == "0")
    //            {
    //                string path = base.Server.MapPath("~/UploadFiles/FileInfo/" + model.FileNewName);
    //                if (System.IO.File.Exists(path))
    //                {
    //                    System.IO.File.Delete(path);
    //                }
    //            }
    //        }
    //    }
    //}
    //private void DownLoad(string path)
    //{
    //    path = base.Server.MapPath(path);
    //    if (path != null && System.IO.File.Exists(path))
    //    {
    //        System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
    //        base.Response.Clear();
    //        base.Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileInfo.Name, System.Text.Encoding.UTF8));
    //        base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
    //        base.Response.ContentType = "application/octet-stream";
    //        base.Response.WriteFile(fileInfo.FullName);
    //        base.Response.End();
    //    }
    //}
    //protected DataTable GetTreeNode()
    //{
    //    DataTable dataTable = new DataTable();
    //    dataTable.Columns.Add("FileName");
    //    dataTable.Columns.Add("Id");
    //    string b = "/images/tree/FileInfo/folder.gif";
    //    foreach (TreeNode treeNode in this.tvFile.Nodes)
    //    {
    //        if (treeNode.ImageUrl == b)
    //        {
    //            DataRow dataRow = dataTable.NewRow();
    //            dataRow["FileName"] = treeNode.Text;
    //            dataRow["Id"] = treeNode.Value;
    //            dataTable.Rows.Add(dataRow);
    //        }
    //        this.AddChildNodes(treeNode, dataTable);
    //    }
    //    return dataTable;
    //}
    //protected void btnUpLoad_Click(object sender, System.EventArgs e)
    //{
    //    base.RegisterScript("location='FileInfoList.aspx?id=" + this.tvFile.SelectedValue + "'");
    //}
    #endregion
    protected void btnDown_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.KeyId.Value.ToString()))
        {
            base.RegisterShow("系统提示", "没有获取到选中项,请重新选择！");
            return;
        }
        string strTemp = this.KeyId.Value.ToString();
        string strIDs = "";
        if (strTemp.Split(',').Length > 1)
        {
            strIDs = strTemp.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ');
        }
        else
        {
            strIDs = strTemp; //" ('" + strTemp + "')";//strTemp.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        }
        string[] strs = strIDs.Split(',');

        SaveFileDialog s = new SaveFileDialog();
       
        s.FileName = "project_documents_"+DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss") + ".zip";
        s.InitialDirectory = "C:\\PM_Download\\";
        bool result = false;
       
        foreach (string consID in strs)
        {
            string[] files = null;
            try
            {
                files = Directory.GetFiles(base.Server.MapPath(ConfigHelper.Get("DocFiles")) + consID.ToString().Trim());
            }
            catch (Exception ex)
            {

            }
            string[] array = files;
            if (array !=null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    zip.AddFile(array[i]);
                }
            }

        }
        result = zip.CompressionZip(s.InitialDirectory+s.FileName);//压缩后文件的绝对路径
        if (!result)
        {
            base.RegisterScript("alert('系统提示：\\n\\操作失败,请稍后重试或联系技术人员！'" + zip.errorMsg + ");");
        }
        else
        {
            //MessageBox.Show("保存成功!");
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(s.InitialDirectory + s.FileName);
            base.Response.Clear();
            base.Response.AddHeader("Content-Disposition", "attachment;filename=" + this.EncodeFileName(s.InitialDirectory + fileInfo.Name));
            base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            base.Response.ContentType = "application/octet-stream";
            base.Response.WriteFile(fileInfo.FullName);
            base.Response.End();
            //deleteFiles(s.FileName);//删除压缩包
        }
    }
    private string EncodeFileName(string fileName)
    {
        string browser = base.Request.Browser.Browser;
        if (browser.ToUpper() == "IE" || browser.ToUpper() == "CHROME")
        {
            fileName = HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
        }
        fileName = fileName.Replace("+", "%20");
        fileName = fileName.Replace("%2b", "+");
        return fileName;
    }
    public static string deleteFiles(string path)
    {
        try
        {
            if (File.Exists(path) && (File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                File.SetAttributes(path, FileAttributes.Normal);
            }
            string str1 = HttpContext.Current.Server.MapPath("/");
            File.Delete(str1.Substring(0, str1.Length - 1).Replace("\\", "/") + path);
        }
        catch (Exception ex)
        {
            return "0";
        }
        return "1";
    }
}


