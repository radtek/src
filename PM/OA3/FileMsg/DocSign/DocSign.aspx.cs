using cn.justwin.BLL;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OA3_FileMsg_DocSign_DocSign : NBasePage
{
    private string doc_name = string.Empty;
    private string doc_Id = string.Empty;
    private string path = string.Empty;
    public string jsIn = string.Empty;
    protected override void OnInit(System.EventArgs e)
    {
        this.doc_name = base.Request["doc_name"];
        this.doc_Id = base.Request["doc_Id"];
        this.path = base.Request["path"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DocId.Value = doc_Id;
        DocName.Value = doc_name;
        DocPath.Value = path;
        userCode.Value = this.UserCode.ToString();
        if (!base.IsPostBack)
        {
            BindData();
            BindList();
        }
    }

    private void BindList()
    {
        string strSql2 = " select DISTINCT [user_Id],v_xm from OA_File_Sign left join PT_yhmc on PT_yhmc.v_yhdm=user_Id  where doc_Id='" + doc_Id + "' and doc_name='" + doc_name + "' and if_del=0  order by user_Id desc";
        DataTable dt2 = publicDbOpClass.DataTableQuary(strSql2);
        if (dt2.Rows.Count > 0)
        {
            this.user_Id.DataSource = dt2;
            this.user_Id.DataValueField = "user_Id";
            this.user_Id.DataTextField = "v_xm";
            this.user_Id.DataBind();
        }
        this.user_Id.Items.Insert(0, new ListItem("请选择", ""));
    }
    private string strWhere()
    {
        string strWhere = " ";// and ...
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);
        if (startTime.HasValue)
        {
            strWhere += " and sign_time >='" + startTime.Value + "'";
        }
        if (endTime.HasValue)
        {
            strWhere += " and sign_time <'" + endTime.Value.AddDays(1.0) + "'";
        }

        if (!string.IsNullOrEmpty(name.Text))
        {
            strWhere += " and name like '%" + name.Text.ToString().Trim() + "%'";
        }
       
        if (user_Id.SelectedValue != "")
        {
            strWhere += " and user_Id ='" + user_Id.SelectedValue + "'";
        }
        return strWhere;
    }
    private void BindData()
    {
        string str = "";
        string strPoint = "";
        string strSql = " select [Id],[doc_Id],[doc_name],[name],[user_Id],v_xm,[sign_x],[sign_y],[remark],[if_del],[sign_time] from OA_File_Sign left join PT_yhmc on PT_yhmc.v_yhdm=user_Id  where doc_Id='" + doc_Id + "' and doc_name='" + doc_name + "' and if_del=0 " + strWhere() + " order by user_Id desc,sign_time desc";
        DataTable dt = publicDbOpClass.DataTableQuary(strSql);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["user_Id"].ToString() == UserCode.ToString())
                {
                    // str += "<li id='li"+ dr["id"] + "' data-option='x:"+dr["sign_x"] +",y:"+ dr["sign_y"] + ",id:"+ dr["id"] + "'><input type='text' id='title" + dr["id"] + "'  value='" + dr["name"] + "' style='width:120px;' readonly /><input type='hidden'  id='remark" + dr["id"] + "'  value=' ' style='width:180px;'/><input type='hidden'  id='x" + dr["id"] + "'  value='" + dr["sign_x"] + "' style='width:50px;'/><input type='hidden'  id='y" + dr["id"] + "'  value='" + dr["sign_y"] + "' style='width:50px;'/>&nbsp;<a href=\"javascript:signInfoEdit('" + dr["id"] + "')\">编辑</a>&nbsp;<a href=\"javascript:signInfoView('" + dr["id"] + "')\">查看</a>&nbsp;<a href=\"javascript:del('" + dr["id"] + "')\">删除</a></li>";
                    str += "<li id='li" + dr["id"] + "' data-option='x:" + dr["sign_x"] + ",y:" + dr["sign_y"] + ",id:" + dr["id"] + "'><input type='text' id='title" + dr["id"] + "'  value='" + dr["name"] + "' style='width:145px;' readonly />&nbsp;<a href=\"javascript:signInfoEdit('" + dr["id"] + "')\">[编辑]</a>&nbsp;<a href=\"javascript:signInfoView('" + dr["id"] + "')\">[查看]</a>&nbsp;<a href=\"javascript:del('" + dr["id"] + "')\">[删除]</a></li>";
                    jsIn += "   var menu = new BootstrapMenu('#" + dr["id"] + "', {actions: [{name: '编辑',onClick: function() {signInfoEdit('" + dr["id"] + "');}}, {name: '查看',onClick: function() {signInfoView('" + dr["id"] + "');}}, {name: '重新标记',onClick: function() {signInfoReEdit('" + dr["id"] + "');}}]}); ";//
                }
                else
                {
                    str += "<li id='li" + dr["id"] + "' data-option='x:" + dr["sign_x"] + ",y:" + dr["sign_y"] + ",id:" + dr["id"] + "'><input type='text' id='title" + dr["id"] + "'  value='" + dr["name"] + "' style='width:145px;' readonly />&nbsp;<a href=\"javascript:signInfoView('" + dr["id"] + "')\">[查看]</a></br> <span style='background-color: wheat;'>标记人:" + dr["v_xm"] + "&nbsp;；标记时间:" + dr["sign_time"] + "</span></li>";
                    jsIn += "   var menu = new BootstrapMenu('#" + dr["id"] + "', {actions: [ {name: '查看',onClick: function() {signInfoView('" + dr["id"] + "');}}]}); ";//
                }
                //strPoint += "<img src=\'style/sign.png\' id=\'" + dr["id"] + "_img\' class=\'pointerImg\' onClick=\'showInfo(" + dr["id"] + ");\'>";
                //strPoint += "<img src=\'style/sign.png\' id='" + dr["id"] + "_img' class='pointerImg' onclick='showInfo(" + dr["id"] + "); ' style='display: block; left:" + dr["sign_x"] + "px; top:" + dr["sign_y"] + "px; '>";
                strPoint += dr["sign_x"] + "," + dr["sign_y"] + "," + dr["id"] + "," + dr["name"] + "," + dr["v_xm"] + ";";
                

            }
        }
        else
        {

        }
        //jsIn = "var menu = new BootstrapMenu('#4c447496-f1b5-4d53-8cc6-375d194e7d2a', {actions: [{name: '谷歌',onClick: function() {alert('谷歌');}}, {name: '百度',onClick: function() {alert('百度');}}]}); ";

        liInfo.Value = str;
        liPoint.Value = strPoint;
        liCount.Value = dt.Rows.Count.ToString();
    }
    [WebMethod]//标示为web服务方法属性
    //删除标记 
    public static string delData(string id)
    {
        string strSqlDel = "update OA_File_Sign set if_del=1 where Id='" + id + "' ";
        int ii =  publicDbOpClass.ExecSqlString(strSqlDel);
        return ii.ToString();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnHidden_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
}