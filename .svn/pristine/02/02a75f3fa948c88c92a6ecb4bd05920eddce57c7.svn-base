using cn.justwin.BLL;
using cn.justwin.DAL;
using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysSet_edit : NBasePage
{
    private string action = string.Empty;
    private string Id = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        action = base.Request["action"];
        Id = base.Request["Id"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            if (this.action == "add")
            {
                return;
            }
            if (this.action == "edit")
            {
                this.KeyId.Value = Id;
                this.Binds(Id);
            }
        }
    }
    private void Binds(string Id)
    {
        if (!string.IsNullOrEmpty(Id))
        {
            string strSQL = @"select row_number() over (ORDER BY Id desc) as pageindex,
                          Id,ParaName,ParaValue,Note from Basic_Config where 1=1 and Id='"+ Id + "'";
            DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
            if (dt.Rows.Count > 0)
            {
                this.KeyId.Value = dt.Rows[0]["Id"].ToString();//主键
                this.ParaName.Text = dt.Rows[0]["ParaName"].ToString();//参数名称
                this.ParaValue.Text = dt.Rows[0]["ParaValue"].ToString();//参数数值
                this.Note.Text = dt.Rows[0]["Note"].ToString();//参数说明
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveData();
    }
    public void saveData()
    {
        string strSql = "";
        if (this.action == "add")
        {
            strSql = string.Format(@"
                                            INSERT INTO [Basic_Config]
                                                       ([Id]
                                                       ,[ParaName]
                                                       ,[ParaValue]
                                                       ,[Note])
                                                 VALUES
                                                       ('{0}'
                                                       ,'{1}'
                                                       ,'{2}'
                                                       ,'{3}')
        ", Guid.NewGuid().ToString().Trim(), this.ParaName.Text.ToString().Trim(), this.ParaValue.Text.ToString().Trim(), this.Note.Text.ToString().Trim());

        }
        else if (this.action == "edit")
        {
            strSql = string.Format(@" UPDATE [Basic_Config]
                                       SET [ParaName] = '{1}'
                                          ,[ParaValue] = '{2}'
                                          ,[Note] = '{3}'
                                       WHERE Id='{0}'
       ", Id, this.ParaName.Text.ToString().Trim(), this.ParaValue.Text.ToString().Trim(), this.Note.Text.ToString().Trim());
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
                //base.RegisterScript("top.ui.tabSuccess({parentName:'_TaskType'});");
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }
}