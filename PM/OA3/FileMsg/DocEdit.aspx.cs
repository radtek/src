using cn.justwin.BLL;
using cn.justwin.DAL;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class OA3_FileMsg_DocEdit : NBasePage
{
    private string action = string.Empty;
    private string Id = string.Empty;
    private string PId = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.action = base.Request["action"];
        this.Id = base.Request["id"];
        this.PId = base.Request["PId"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            BindDropDownList("DocVersion");//绑定 文档版本
            BindDropDownList("DocType");//绑定 文档类型
            BindDropDownList("DocStatus");//绑定 文档状态
            BindDropDownList("DocChangeType");//绑定 文档变更类型
            if (this.action == "add")
            {
                string strDocSort = string.Empty;
                change1.Visible = false;
                change2.Visible = false;
                ParentID.Value = PId;
                string strWhere = " and OA_File.ParentId='" + PId + "'";
                DataTable dt = FileService.GetFileInfo(strWhere);
                if (dt.Rows.Count > 0)
                {
                    strDocSort = dt.Rows[0]["DocSort"].ToString();
                }
                else
                {
                    strDocSort = string.Empty;
                }
                if (!string.IsNullOrEmpty(strDocSort))
                {
                    this.DocSort.Text = Convert.ToString(Convert.ToInt32(strDocSort) + 1);
                }
                else
                {
                    this.DocSort.Text = "1";
                }

                string strGUID = System.Guid.NewGuid().ToString();
                this.KeyId.Value = strGUID;
                this.DocAncestorID.Value = strGUID;
            }
            else
            {
                this.BindDatas(Id, action);
            }
            if (this.action == "up")
            {
                this.FileName.ReadOnly = true;
                //this.DocSort.Text = dt.Rows[0]["DocSort"].ToString();
                this.DocCode.ReadOnly = true;
                //this.Remark.Text = dt.Rows[0]["Remark"].ToString();
                this.DocAuthor.ReadOnly = true;
                //this.DocVersionID.SelectedValue = dt.Rows[0]["DocVersionID"].ToString();
                this.DocStatusID.Enabled = false;
                this.DocTypeID.Enabled = false;
                this.DocChangeTypeID.Enabled = false;
                this.DocChangeRemark.ReadOnly = true;
            }
        }
        this.FileUpload2.RecordCode = this.KeyId.Value;//绑定附件
    }
    /// <summary>
    /// 绑定文档版本、文档类型、文档状态、文档变更类型
    /// </summary>
    /// <param name="strType">类型关键字</param>
    private void BindDropDownList(string strType)
    {
        DataTable dt = publicDbOpClass.DataTableQuary("select * from XPM_Basic_CodeList WHERE SignCode2='" + strType + "' order by I_xh asc");
        if (strType == "DocChangeType")
        {
            this.DocChangeTypeID.DataSource = dt;
            this.DocChangeTypeID.DataValueField = "NoteID";
            this.DocChangeTypeID.DataTextField = "CodeName";
            this.DocChangeTypeID.DataBind();
            //this.DocChangeType.Items.Insert(0, new ListItem("请选择", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IsDefault"].ToString() == "True")
                {
                    DocChangeTypeID.SelectedValue = dr["NoteID"].ToString();
                    break;
                }
            }
        }
        if (strType == "DocVersion")
        {
            this.DocVersionID.DataSource = dt;
            this.DocVersionID.DataValueField = "NoteID";
            this.DocVersionID.DataTextField = "CodeName";
            this.DocVersionID.DataBind();
            //this.DocVersionID.Items.Insert(0, new ListItem("请选择", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IsDefault"].ToString() == "True")
                {
                    DocVersionID.SelectedValue = dr["NoteID"].ToString();
                    break;
                }
            }
        }
        if (strType == "DocType")
        {
            this.DocTypeID.DataSource = dt;
            this.DocTypeID.DataValueField = "NoteID";
            this.DocTypeID.DataTextField = "CodeName";
            this.DocTypeID.DataBind();
            //this.DocTypeID.Items.Insert(0, new ListItem("请选择", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IsDefault"].ToString() == "True")
                {
                    DocTypeID.SelectedValue = dr["NoteID"].ToString();
                    break;
                }
            }
        }
        if (strType == "DocStatus")
        {
            this.DocStatusID.DataSource = dt;
            this.DocStatusID.DataValueField = "NoteID";
            this.DocStatusID.DataTextField = "CodeName";
            this.DocStatusID.DataBind();
            //this.DocStatusID.Items.Insert(0, new ListItem("请选择", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IsDefault"].ToString() == "True")
                {
                    DocStatusID.SelectedValue = dr["NoteID"].ToString();
                    break;
                }
            }
        }
    }
    public string GetAndSaveFiles(string oldID, string NewID)
    {
        return "";
    }
    private void BindDatas(string Id, string action)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            string strWhere = " and OA_File.id='" + Id + "'";
            DataTable dt = FileService.GetFileInfo(strWhere);
            if (dt.Rows.Count > 0)
            {
                this.FileName.Text = dt.Rows[0]["FileName"].ToString();
                this.DocSort.Text = dt.Rows[0]["DocSort"].ToString();
                this.DocCode.Text = dt.Rows[0]["DocCode"].ToString();
                this.Remark.Text = dt.Rows[0]["Remark"].ToString();
                this.DocAuthor.Text = dt.Rows[0]["DocAuthor"].ToString();
                this.DocVersionID.SelectedValue = dt.Rows[0]["DocVersionID"].ToString();
                this.DocStatusID.SelectedValue = dt.Rows[0]["DocStatusID"].ToString();
                this.DocTypeID.SelectedValue = dt.Rows[0]["DocTypeID"].ToString();

                this.DocRelationIDs.Value = dt.Rows[0]["DocRelationIDs"].ToString();
                this.DocRelationName.Value = dt.Rows[0]["DocRelationName"].ToString();

                this.hdnProjectCode.Value = dt.Rows[0]["project_id"].ToString();
                this.txtProject.Value = dt.Rows[0]["PrjName"].ToString();

                this.DocChangeTypeID.SelectedValue = dt.Rows[0]["DocChangeTypeID"].ToString();
                this.DocChangeRemark.Text = dt.Rows[0]["DocChangeRemark"].ToString();
                if (this.action == "copy")
                {
                    change1.Visible = false;
                    change2.Visible = false;
                    ParentID.Value = PId;
                    string strGUID = System.Guid.NewGuid().ToString();
                    this.KeyId.Value = strGUID;
                    this.DocAncestorID.Value = strGUID;
                }
                else if (this.action == "up")//文档升版
                {
                    if (dt.Rows[0]["DocAttribute"].ToString() == "0")//初版
                    {
                        string statusCB = FileService.selectCBStatus(Id);
                        if (statusCB != "1")
                        {
                            base.RegisterScript("alert('系统提示：只能升版状态为\"已审核\"的数据,请重新选择！');top.ui.closeTab();");
                            return;
                        }
                    }
                    else if (dt.Rows[0]["DocAttribute"].ToString() == "1")//升版
                    {
                        string statusSB = FileService.selectSBStatus(Id);
                        if (statusSB != "1")
                        {
                            base.RegisterScript("alert('系统提示：只能升版状态为\"已审核\"的数据,请重新选择！');top.ui.closeTab();");
                            return;
                        }
                    }
                    else if (dt.Rows[0]["DocAttribute"].ToString() == "2")//变更
                    {
                        //base.RegisterScript("alert('系统提示：不能编辑变更后的文档,请重新选择！');top.ui.closeTab();");
                        //return;
                    }

                    change1.Visible = false;
                    change2.Visible = false;
                    ParentID.Value = PId;
                    this.KeyId.Value = System.Guid.NewGuid().ToString();
                    this.DocAncestorID.Value = dt.Rows[0]["DocAncestorID"].ToString();
                    GetAndSaveFiles(Id, this.KeyId.Value);

                    int ii = 0;
                    DataTable dt1 = publicDbOpClass.DataTableQuary("select I_xh from XPM_Basic_CodeList where NoteID='" + dt.Rows[0]["DocVersionID"].ToString() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        ii = Convert.ToInt32(dt1.Rows[0]["I_xh"].ToString());
                    }
                    int iis = ii + 1;
                    DataTable dt2 = publicDbOpClass.DataTableQuary("select * from XPM_Basic_CodeList WHERE SignCode2='DocVersion' and I_xh=" + iis + " order by I_xh asc");
                    if (dt2.Rows.Count > 0)
                    {
                        DocStatusID.SelectedValue = dt2.Rows[0]["NoteID"].ToString();
                    }
                }
                else if (this.action == "change")//文档变更
                {
                    if (dt.Rows[0]["DocAttribute"].ToString() == "0")//初版
                    {
                        string statusCB = FileService.selectCBStatus(Id);
                        if (statusCB != "1")
                        {
                            base.RegisterScript("alert('系统提示：只能变更状态为\"已审核\"的数据,请重新选择！');top.ui.closeTab();");
                            return;
                        }
                    }
                    if (dt.Rows[0]["DocAttribute"].ToString() == "1")//升版
                    {
                        string statusSB = FileService.selectSBStatus(Id);
                        if (statusSB != "1")
                        {
                            base.RegisterScript("alert('系统提示：只能变更状态为\"已审核\"的数据,请重新选择！');top.ui.closeTab();");
                            return;
                        }
                    }
                    //if (dt.Rows[0]["DocAttribute"].ToString() == "2")//变更
                    //{
                    //    base.RegisterScript("alert('系统提示：不能编辑变更后的文档,请重新选择！');top.ui.closeTab();");
                    //    return;
                    //}

                    change1.Visible = true;
                    change2.Visible = true;
                    ParentID.Value = PId;
                    this.KeyId.Value = System.Guid.NewGuid().ToString();
                    this.DocAncestorID.Value = dt.Rows[0]["DocAncestorID"].ToString();
                    GetAndSaveFiles(Id, this.KeyId.Value);
                }

                else if (this.action == "edit")//文档编辑
                {
                    if (dt.Rows[0]["DocAttribute"].ToString() == "2")
                    {
                        change1.Visible = true;
                        change2.Visible = true;
                    }
                    else
                    {
                        change1.Visible = false;
                        change2.Visible = false;
                    }
                    if (dt.Rows[0]["DocAttribute"].ToString() == "0")//初版
                    {
                        string statusCB = FileService.selectCBStatus(Id);
                        if (statusCB != "-1")
                        {
                            base.RegisterScript("alert('系统提示：只能编辑状态为\"未提交\"的数据,请重新选择！');top.ui.closeTab();");
                            return;
                        }
                    }
                    if (dt.Rows[0]["DocAttribute"].ToString() == "1")//升版
                    {
                        string statusSB = FileService.selectSBStatus(Id);
                        if (statusSB != "-1")
                        {
                            base.RegisterScript("alert('系统提示：只能编辑状态为\"未提交\"的数据,请重新选择！');top.ui.closeTab();");
                            return;
                        }
                    }
                    if (dt.Rows[0]["DocAttribute"].ToString() == "2")//变更
                    {
                        base.RegisterScript("alert('系统提示：不能编辑变更后的文档,请重新选择！');top.ui.closeTab();");
                        return;
                    }
                    this.KeyId.Value = Id;
                    this.DocAncestorID.Value = dt.Rows[0]["DocAncestorID"].ToString();
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveData();
    }
    /// <summary>
    /// 保存数据
    /// </summary>
    public void saveData()
    {
        string strSql = "";
        //string strSqlUp = "";
        string strSqlChange = "";
        if (this.action != "edit")
        {
            string DocCBFlowStatus = "";
            string DocSBFlowStatus = "";
            string DocAttribute = "";// 文档属性(0原版  1 升版  2 变更)
            string DocChangeTypeID = "";
            string DocChangeRemark = "";
            if (this.action == "add" || this.action == "copy")
            {
                DocCBFlowStatus = "-1";
                DocSBFlowStatus = "-1"; //DocSBFlowStatus = "-10";
                DocAttribute = "0";
            }
            if (this.action == "up")
            {
                DocCBFlowStatus = "-1"; //DocCBFlowStatus = "-10";
                DocSBFlowStatus = "-1";
                DocAttribute = "1";
            }
            //if (this.action == "up")
            //{
            //    strSqlUp = @" UPDATE [OA_File]  SET [IsValid] = 1 WHERE [id]= '" + Id + "'";
            //}

            if (this.action == "change")
            {
                DocCBFlowStatus = "-1";//DocCBFlowStatus = "-10";
                DocSBFlowStatus = "-1";//DocSBFlowStatus = "-10";
                DocAttribute = "2";

                DocChangeTypeID = this.DocChangeTypeID.SelectedValue.ToString();
                DocChangeRemark = this.DocChangeRemark.Text.ToString();

                strSqlChange = @" UPDATE [OA_File]  SET [IsValid] = 1 WHERE [DocAncestorID]= '" + DocAncestorID.Value.ToString() + "' and Id !='" + this.KeyId.Value + "'";
            }
            //--,[UserCodes]
            //--,[AncestorInfo]
            //--,[FileNewName]
            //--,[FileSize]   this.hdnProjectCode.Value = dt.Rows[0]["project_id"].ToString();
            strSql = string.Format(@"
            INSERT INTO [OA_File]
           ([Id]
           ,[FileName]
           ,[FileOwner]
           ,[ParentId]
           ,[FileType]
           ,[CreateTime]
           ,[IsValid]
           ,[Remark]
           ,[DocTypeID]
           ,[DocAuthor]
           ,[DocStatusID]
           ,[DocSort]
           ,[DocEditDate]
           ,[DocCode]
           ,[DocVersionID]
           ,[DocRelationIDs]
           ,[DocCBFlowStatus]
           ,[DocSBFlowStatus]
		   ,[DocAncestorID]
            ,[DocEditUserID]
            ,[DocAttribute]
		   ,[DocChangeTypeID]
            ,[DocChangeRemark]
,project_id
		   )
     VALUES
           ('{0}'--<Id, nvarchar(64),>
           ,'{1}'--<FileName, nvarchar(max),>
           ,'{2}'--<FileOwner, nvarchar(64),>
           ,'{3}'--<ParentId, nvarchar(64),>
           ,'{4}'--<FileType, nvarchar(64),>
           ,'{5}'--<CreateTime, datetime,>
           ,{6}--<IsValid, bit,>
           ,'{7}'--<Remark, nvarchar(64),>
           ,'{8}'--<DocTypeID, nvarchar(64),>
           ,'{9}'--<DocAuthor, nvarchar(max),>
           ,'{10}'--<DocStatusID, nvarchar(64),>
           ,{11}--<DocSort, int,>
           ,'{12}'--<DocEditDate, datetime,>
           ,'{13}'--<DocCode, nvarchar(max),>
           ,'{14}'--<DocVersionID, nvarchar(64),>
           ,'{15}'--<DocRelationIDs, nvarchar(max),>
           ,{16}--<DocCBFlowStatus, int,>
           ,{17}--<DocSBFlowStatus, int,>
		   ,'{18}'--<DocAncestorID, int,>
           ,'{19}'--<DocEditUserID, nvarchar(64),>
		   ,{20}--<DocAttribute, int,>
           ,'{21}'--<DocChangeTypeID, nvarchar(64),>
           ,'{22}'--<DocChangeRemark, nvarchar(64),>
           ,'{23}'
		   )"
       , this.KeyId.Value
       , FileName.Text.ToString()
       , this.UserCode.ToString()
       , ParentID.Value.ToString()
       , "0"
       , DateTime.Now.ToString()
       , "0"
       , Remark.Text.ToString()
       , DocTypeID.SelectedValue.ToString()
       , DocAuthor.Text.ToString()
       , DocStatusID.SelectedValue.ToString()
       , DocSort.Text.ToString()
       , DateTime.Now.ToString()
       , DocCode.Text.ToString()
       , DocVersionID.SelectedValue.ToString()
       , DocRelationIDs.Value.ToString()
       , DocCBFlowStatus
       , DocSBFlowStatus
       , DocAncestorID.Value.ToString()
       , this.UserCode.ToString()
       , DocAttribute
        , DocChangeTypeID
        , DocChangeRemark
        , this.hdnProjectCode.Value
       );
        }
        else if (this.action == "edit")
        {

            //--,[ParentId] = '{}'--<ParentId, nvarchar(64),>
            //--,[FileType] = '{}'--<FileType, nvarchar(64),>
            //--,[FileOwner] = '{}'--<FileOwner, nvarchar(64),>
            //--,[CreateTime] = '{}'--<CreateTime, datetime,>
            //--,[IsValid] = '{}'--<IsValid, bit,>
            //--,[DocCBFlowStatus] = '{}'--<DocCBFlowStatus, int,>
            //--,[DocSBFlowStatus] = '{}'--<DocSBFlowStatus, int,>
            //--,[DocAncestorID] = '{}'--<DocAncestorID, int,>
            //-- [Id] = '{}'--<Id, nvarchar(64),>
            //--,[FileNewName] = '{}'--<FileNewName, nvarchar(max),>
            //--,[FileSize] = '{}'--<FileSize, nvarchar(64),>
            //--,[UserCodes] = '{}'--<UserCodes, nvarchar(max),>
            //--,[AncestorInfo] = '{}'--<AncestorInfo, nvarchar(max),>
            //        ,[DocAttribute]
            //,[DocChangeTypeID]
            //       ,[DocChangeRemark]
            strSql = string.Format(@"
               UPDATE [OA_File]
   SET [FileName] = '{1}'--<FileName, nvarchar(max),>
      ,[Remark] = '{2}'--<Remark, nvarchar(64),>
      ,[DocTypeID] = '{3}'--<DocTypeID, nvarchar(64),>
      ,[DocAuthor] = '{4}'--<DocAuthor, nvarchar(max),>
      ,[DocStatusID] = '{5}'--<DocStatusID, nvarchar(64),>
      ,[DocSort] = {6}--<DocSort, int,>
      ,[DocEditDate] = '{7}'--<DocEditDate, datetime,>
      ,[DocCode] = '{8}'--<DocCode, nvarchar(max),>
      ,[DocVersionID] = '{9}'--<DocVersionID, nvarchar(64),>
      ,[DocRelationIDs] = '{10}'--<DocRelationIDs, nvarchar(max),>
      ,[DocEditUserID] = '{11}'--<DocEditUserID, nvarchar(64),>
,[project_id] = '{12}'
         WHERE [id]= '{0}' "
                , this.KeyId.Value
                , this.FileName.Text.ToString()
                , this.Remark.Text.ToString()
                , this.DocTypeID.SelectedValue.ToString()
                , this.DocAuthor.Text.ToString()
                , this.DocStatusID.SelectedValue.ToString()
                , this.DocSort.Text.ToString()
                , DateTime.Now.ToString()
                , this.DocCode.Text.ToString()
                , this.DocVersionID.SelectedValue.ToString()
                , this.DocRelationIDs.Value.ToString()
                , this.UserCode.ToString()
                  , this.hdnProjectCode.Value
                );
        }

        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                if (this.action == "change")
                {
                    SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSqlChange);
                }
                sqlTransaction.Commit();
                base.RegisterScript("top.ui.tabSuccess({parentName:'_DocList'});");
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }


}