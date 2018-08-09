using cn.justwin.BLL;
using cn.justwin.DAL;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class SignEdit : NBasePage
{
    private string action = string.Empty;
    private string Id = string.Empty;
    private string Name = string.Empty;
    private string x = string.Empty;
    private string y = string.Empty;
    private string doc_Id = string.Empty;
    private string doc_name = string.Empty;
    private string path = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.action = base.Request["action"];
        this.Id = base.Request["id"];
        this.Name = base.Request["name"];
        this.x = base.Request["x"];
        this.y = base.Request["y"];
        this.doc_Id = base.Request["doc_Id"];
        this.doc_name = base.Request["doc_name"];
        this.path = base.Request["path"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.DocId.Value = doc_Id;
            this.DocName.Value = doc_name;
            this.DocPath.Value = path;
            DocAction.Value = action;
            if (this.action == "add")
            {
                string strGUID = System.Guid.NewGuid().ToString();
                this.KeyId.Value = strGUID;
            }
            else
            {
                this.KeyId.Value = Id;
                this.BindDatas(Id, action);
            }
        }
        this.FileUpload1.RecordCode = this.KeyId.Value;//绑定图片
        this.FileUpload2.RecordCode = this.KeyId.Value;//绑定附件
        this.FileUpload3.RecordCode = this.KeyId.Value;//绑定音频
        this.FileUpload4.RecordCode = this.KeyId.Value;//绑定视频
    }
    public string GetAndSaveFiles(string oldID, string NewID)
    {
        return "";
    }
    private void BindDatas(string Id, string action)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            string strSql = "select * from OA_File_Sign where Id='" + Id + "'";
            DataTable dt = publicDbOpClass.DataTableQuary(strSql);
            if (dt.Rows.Count > 0)
            {
                this.name.Text = dt.Rows[0]["name"].ToString();
                this.remark.Text = dt.Rows[0]["remark"].ToString();
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
        if (this.action == "add")
        {
            strSql = string.Format(@"INSERT INTO [OA_File_Sign]
           ([Id]
           ,[doc_Id]
           ,[doc_name]
           ,[name]
           ,[user_Id]
           ,[sign_x]
           ,[sign_y]
           ,[remark]
           ,[if_del]
           ,[sign_time])
     VALUES
           (
		    '{0}'
           ,'{1}'
           ,'{2}'
           ,'{3}'
           ,'{4}'
           ,'{5}'
           ,'{6}'
           ,'{7}'
            ,{8}
           ,'{9}');", this.KeyId.Value, doc_Id, doc_name, this.name.Text.ToString(), this.UserCode, x, y, this.remark.Text.ToString(), 0, DateTime.Now);
        }
        else if (this.action == "edit")
        {
            strSql = string.Format(@"
               UPDATE [OA_File_Sign]
                  SET [name] = '{1}' 
                     ,[remark] = '{2}' 
                      ,sign_time='{3}' 
                WHERE [Id]= '{0}' "
                , this.KeyId.Value
                , this.name.Text.ToString()
                , this.remark.Text.ToString()
                , DateTime.Now.ToString()
                );
        }
        else if (this.action == "Reedit")
        {
            strSql = string.Format(@"
               UPDATE [OA_File_Sign]
                  SET [name] = '{1}' 
                     ,[remark] = '{2}' 
                      ,sign_time='{3}'
                     ,[sign_x]='{4}'
                    ,[sign_y] ='{5}'
                WHERE [Id]= '{0}' "
                , this.KeyId.Value
                , this.name.Text.ToString()
                , this.remark.Text.ToString()
                , DateTime.Now.ToString(), x, y
                );
        }
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                base.RegisterScript("successed();");
                //base.RegisterScript("alert('系统提示：\\n\\保存成功！');");
                //base.RegisterScript("top.ui.tabSuccess({parentName:'_DocList'});");
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }


}