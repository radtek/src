using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]//标示为web服务方法属性
    public static string getImg(string orid)
    { 
        DataTable dt = publicDbOpClass.DataTableQuary("select writeName from Sm_OutReserve where orid='"+ orid + "'");
        if (dt.Rows.Count>0)
        {
            return dt.Rows[0]["writeName"].ToString();
        }else
        {
            return "";
        }
        //return "{\"alldepts\":[{\"id\":2,\"name\":\"开发部1\",\"fid\":1},{\"id\":3,\"name\":\"测试部1\",\"fid\":1},{\"id\":4,\"name\":\"销售部1\",\"fid\":1},{\"id\":5,\"name\":\"运营部1\",\"fid\":1},{\"id\":6,\"name\":\"维护部1\",\"fid\":1},{\"id\":7,\"name\":\"人事部1\",\"fid\":1},{\"id\":8,\"name\":\"财务部1\",\"fid\":1}]}";
    }
}