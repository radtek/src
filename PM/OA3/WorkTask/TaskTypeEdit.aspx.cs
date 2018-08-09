using cn.justwin.BLL;
using cn.justwin.DAL;
using DomainServices.cn.justwin.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OA3_WorkTask_TaskTypeEdit : NBasePage
{
    TaskService pcSer = new TaskService();
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
            DataTable dt = pcSer.GetTaskTypeTable(strWhere(Id), UserCode);
            if (dt.Rows.Count > 0)
            {
                this.KeyId.Value = dt.Rows[0]["id"].ToString();//主键
                this.name.Text = dt.Rows[0]["name"].ToString();//类型名称
                this.is_use.SelectedValue = dt.Rows[0]["is_use"].ToString();//是否启用
                title_temp.Text = dt.Rows[0]["title_temp"].ToString();//日志标题缺省值
                content_temp.Text = dt.Rows[0]["content_temp"].ToString();//日志内容缺省值
                this.sort.Text = dt.Rows[0]["sort"].ToString();//序号
                remark.Text = dt.Rows[0]["remark"].ToString();//备注
            }
        }
    }

    private string strWhere(string Id)
    {
        string strWhere = " ";// and ...
        if (!string.IsNullOrEmpty(Id.ToString()))
        {
            strWhere += " and id  ='" + Id + "'";
        }
        return strWhere;
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
                                            INSERT INTO [OA_Task_Type]
                                                       ([id]
                                                       ,[name]
                                                       ,[sort]
                                                       ,[title_temp]
                                                       ,[content_temp]
                                                       ,[is_use]
                                                       ,[remark])
                                                 VALUES
                                                       ('{0}'
                                                       ,'{1}'
                                                       ,{2}
                                                       ,'{3}'
                                                       ,'{4}'
                                                       ,{5}
                                                       ,'{6}')
        ", Guid.NewGuid().ToString(), this.name.Text.ToString(), this.sort.Text.ToString(), this.title_temp.Text.ToString(), this.content_temp.Text.ToString(), this.is_use.SelectedValue.ToString(), this.remark.Text.ToString());

        }
        else if (this.action == "edit")
        {
            strSql = string.Format(@" UPDATE [OA_Task_Type]
                                       SET [name] = '{1}'
                                          ,[sort] = {2}
                                          ,[title_temp] = '{3}'
                                          ,[content_temp] = '{4}'
                                          ,[is_use] = {5}
                                          ,[remark] = '{6}'
                                       WHERE id='{0}'
        ", this.KeyId.Value.ToString(), this.name.Text.ToString(), this.sort.Text.ToString(), this.title_temp.Text.ToString(), this.content_temp.Text.ToString(), this.is_use.SelectedValue.ToString(), this.remark.Text.ToString());
        }

        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                base.RegisterScript("top.ui.tabSuccess({parentName:'_TaskType'});");
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }
}