using cn.justwin.BLL;
using cn.justwin.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeChat_writeName_writeName :  Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveImg();
    }
    private void saveImg()
    {
        string strID = base.Request["orid"].ToString();
        string strImg = dataUrl.Value.ToString();
        string strSql = "update Sm_OutReserve set writeName='"+ strImg + "' where orid='"+ strID + "'";
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                sqlTransaction.Commit();
                //var url = "/WeChat/writeName/writeName.aspx?orid=" + ss + "&prjGuid=" + document.getElementById("prjGuid").innerHTML + "&=" + $("#txtPPcode").val() + "&=" + $("#txtStartTime").val() + "&=" + $("#txtEndTime").val() + "&=" + $("#txtPeople").val() + "&=" + $("#hfldTrea").val() + "&=" + $("#status").val();
                string prjGuid = base.Request["prjGuid"].ToString();
                string txtPPcode = base.Request["txtPPcode"].ToString();
                string txtStartTime = base.Request["txtStartTime"].ToString();
                string txtEndTime = base.Request["txtEndTime"].ToString();
                string txtPeople = base.Request["txtPeople"].ToString();
                string txtTrea = base.Request["txtTrea"].ToString();
                string status = base.Request["status"].ToString();
                //string strUrl = "location='/StockManage/SmOutReserve/QOutReserveWX.aspx?prjGuid=" + prjGuid + "&txtPPcode=" + txtPPcode + "&txtStartTime=" + txtStartTime + "&txtEndTime=" + txtEndTime + "&txtPeople=" + txtPeople + "&txtTrea=" + txtTrea + "&status=" + status + "'";
                string strUrl = "location='/StockManage/SmOutReserve/QOutReserveWX.aspx?prjGuid=" + prjGuid + "'";

                RegisterScript(strUrl);
            }
            catch
            {
                sqlTransaction.Rollback();
               RegisterScript("alert('系统提示：\\n\\保存失败！');");
            }
        }
    }
    protected void RegisterScript(string message)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<script type='text/javascript'>").Append(Environment.NewLine).Append(message).Append("</script>");
        base.ClientScript.RegisterStartupScript(base.GetType(), Guid.NewGuid().ToString(), builder.ToString());
    }

}