using cn.justwin.BLL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OA3_WorkLog_CheckList : NBasePage, IRequiresSessionState
{
    private OAJournalService pcSer = new OAJournalService();
    private string userType = string.Empty;

    protected override void OnInit(System.EventArgs e)
    {
        this.userType = base.Request["userType"];
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
           // this.btnDel.Attributes.Add("onclick", "if(!confirm('确定删除该工作日志吗?')) return false;");
            dropBind();
            this.DataBinds();
        }
    }
    protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = this.GvList.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["guid"] = (e.Row.Attributes["id"] = value);
            }
            //string str=e.Row.Cells[13].Text;
            HyperLink hyperLink = (HyperLink)e.Row.Cells[1].FindControl("HyperLink1");
            hyperLink.NavigateUrl = "javascript:toolbox_oncommand('/OA3/WorkLog/CheckView.aspx?action=view&id=" + this.GvList.DataKeys[e.Row.RowIndex].Values[0].ToString() + "','查阅工作日志');";
            hyperLink.ForeColor = Color.Blue;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //找到所在单元格，索引从0开始
            string ifck = this.GvList.DataKeys[e.Row.RowIndex]["ifck"].ToString() == "" ? "0" : this.GvList.DataKeys[e.Row.RowIndex]["ifck"].ToString();//是否查看
            string ifkt = this.GvList.DataKeys[e.Row.RowIndex]["ifkt"].ToString() == "" ? "0" : this.GvList.DataKeys[e.Row.RowIndex]["ifkt"].ToString();//是否跨天
            string ifjb = this.GvList.DataKeys[e.Row.RowIndex]["ifjb"].ToString() == "" ? "0" : this.GvList.DataKeys[e.Row.RowIndex]["ifjb"].ToString();//是否加班

            //if (Convert.ToDecimal(ifck) == 0)
            //{
            //    //e.Row.Font.Bold = true;
            //    //e.Row.Style.Value = "table.gvdata td";
            //    //e.Row.CssClass= "table.gvdata td";
            //}
            //else
            //{
            //    //e.Row.CssClass = "";
            //}
            if (ifck == "0")
            {
                //e.Row.Style.Add("font-weight", "bolder;");//.Attributes.Add("class", "yellow");
                HyperLink HyperLink1 = (HyperLink)e.Row.FindControl("HyperLink1");
                //Label content = (Label)e.Row.FindControl("content");

                Label title = (Label)e.Row.FindControl("title");
                Label typeName = (Label)e.Row.FindControl("typeName");
                Label v_xm = (Label)e.Row.FindControl("v_xm");
                //Label ck = (Label)e.Row.FindControl("ifck");
                HyperLink1.Font.Bold = true;
                //content.Font.Bold = true;
                //title.Font.Bold = true;
                typeName.Font.Bold = true;
                v_xm.Font.Bold = true;
                //ck.Font.Bold = true;
                //ck.ForeColor = Color.FromName("#FF7D00");
                //e.Row.Attributes.Add("style", "font-weight:bolder;");//.Cells[i].Attributes.Add("style", "font-weight:bolder;");
            }
            if (Convert.ToDecimal(ifkt) == 1 && Convert.ToDecimal(ifjb) == 1)
            {
                e.Row.ForeColor = System.Drawing.Color.Orange;
            }
            else if (Convert.ToDecimal(ifkt) == 1)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (Convert.ToDecimal(ifjb) == 1)
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                e.Row.ForeColor = System.Drawing.Color.Black;
            }

            ////if (e.Row.Cells[13].Text.ToString().Trim() == "0")
            ////{
            ////    //e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
            ////    e.Row.Cells[i].Attributes.Add("style", "font-weight:bolder;");
            ////}

            //string ifck = DataBinder.Eval(e.Row.DataItem, "ifck").ToString();
            //if (ifck == "0")
            //{
            //    //e.Row.Style.Add("font-weight", "bolder;");//.Attributes.Add("class", "yellow");
            //    //HyperLink HyperLink1 = (HyperLink)e.Row.FindControl("HyperLink1");
            //    //Label content = (Label)e.Row.FindControl("content");

            //    //Label title = (Label)e.Row.FindControl("title");
            //    Label typeName = (Label)e.Row.FindControl("typeName");
            //    Label v_xm = (Label)e.Row.FindControl("v_xm");
            //    Label ck = (Label)e.Row.FindControl("ifck");
            //    //HyperLink1.Font.Bold = true;
            //    //content.Font.Bold = true;
            //   // title.Font.Bold = true;
            //    typeName.Font.Bold = true;
            //    v_xm.Font.Bold = true;
            //    ck.Font.Bold = true;
            //    ck.ForeColor = Color.FromName("#FF7D00");
            //    //e.Row.Attributes.Add("style", "font-weight:bolder;");//.Cells[i].Attributes.Add("style", "font-weight:bolder;");
            //}

            ////for (int i = 0; i < GvList.Rows.Count; i++)
            ////{
            ////    if (GvList.Rows[i].Cells[13].Text == "0")
            ////    {
            ////        //将当行设置为红色
            ////        //GvList.Rows[i].Cells[13].BackColor = System.Drawing.Color.Red;

            ////    }
            ////}

            ////for (int i = 0; i < GvList.Rows.Count; i++)
            ////{
            ////    if (GvList.Rows[i].Cells[13].Text == "0")
            ////    {
            ////        GvList.Rows[i].Attributes.Add("style", "font-weight:bolder;");//BackColor = System.Drawing.Color.Red;
            ////    }
            ////}
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        // string value = this.GvList.DataKeys[e.Row.RowIndex].Values[13].ToString();
        //e.Row.Attributes["id"] = value;
        //e.Row.Attributes["AnnexId"] = this.GvList.DataKeys[e.Row.RowIndex].Values[1].ToString();
        //this.hfldAnnexId.Value = this.GvList.DataKeys[e.Row.RowIndex].Values[1].ToString();
        //if (this.GvList.DataKeys[e.Row.RowIndex].Values[3].ToString() == "True")
        //{
        //e.Row.Cells[4].Text = "已读";
        // return;
        // }
        //e.Row.Cells[4].Text = "未读";
        //e.Row.Cells[4].ForeColor = Color.FromName("#FF7D00");
        //    for (int i = 0; i < e.Row.Cells.Count; i++)
        //    {
        //        //if (i == 2)
        //        //{
        //        HyperLink hl= (HyperLink)e.Row.FindControl("HyperLink1");
        //            Label ll = (Label)e.Row.FindControl("content");
        //            hl.Font.Bold = true;
        //            ll.Font.Bold = true;
        //        //}
        //        //else
        //        //{
        //            e.Row.Cells[i].Attributes.Add("style", "font-weight:bolder;");
        //        //}
        //    }
        //}


    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.DataBinds();
    }

    private void dropBind()
    {
        DataTable aLLProvince = publicDbOpClass.DataTableQuary("select * from OA_Journal_Type where is_use = 1");
        this.type_id.DataSource = aLLProvince;
        this.type_id.DataValueField = "id";
        this.type_id.DataTextField = "name";
        this.type_id.DataBind();
        this.type_id.Items.Insert(0, new ListItem("请选择", ""));
    }
    
    protected void DataBinds()
    {
        BasicConfigService basicConfigService = new BasicConfigService();
        // //ifkt crossTime
        string crossTime= basicConfigService.GetValue("crossTime");//是否跨天的标记
        string overtime = basicConfigService.GetValue("overtime");//是否加班的标记
        
        string strCT = "2018-03-26 " + crossTime;
        string strOT = "2018-03-26 " + overtime;
        int currentPageIndex = this.AspNetPager1.CurrentPageIndex;
        string str = ((pagesize * (currentPageIndex - 1)) + 1).ToString();
        string str2 = (pagesize * currentPageIndex).ToString();
        DataTable dtA = pcSer.GetMsgTable(strWhere(), UserCode);
        foreach (DataRow dr in dtA.Rows)
        {
            string strA = "2018-03-26 " + dr["t1"].ToString();
            string strB = "2018-03-26 " + dr["t2"].ToString();
            if (Convert.ToDateTime(strA) > Convert.ToDateTime(strCT) && Convert.ToDateTime(strB) > Convert.ToDateTime(strCT))
            {
                dr["ifkt"] = "1";
            }
            else
            {
                dr["ifkt"] = "0";
            }

            string strA1 = "2018-03-26 " + dr["t1"].ToString();
            string strB1 = "2018-03-26 " + dr["t2"].ToString();
            if (Convert.ToDateTime(strA1) > Convert.ToDateTime(strOT) && Convert.ToDateTime(strB1) > Convert.ToDateTime(strOT))
            {
                dr["ifjb"] = "1";
            }
            else
            {
                dr["ifjb"] = "0";
            }
        }

        DataRow[] rows = dtA.Select(" pageindex >=" + str + " and  pageindex<=" + str2);
        DataTable dtB = dtA.Clone();
        foreach (DataRow row in rows)
        {
            dtB.Rows.Add(row.ItemArray);
        }
        this.AspNetPager1.PageSize = NBasePage.pagesize;
        this.AspNetPager1.RecordCount = dtA.Rows.Count;
        this.GvList.DataSource = dtB;
        this.GvList.DataBind();
    }
    public string strWhere()
    {
        string strWhere = " ";// and ...
        System.DateTime? startTime = DateTimeHelper.GetDateTime(this.txtStartTime.Text);
        System.DateTime? endTime = DateTimeHelper.GetDateTime(this.txtEndTime.Text);
        if (startTime.HasValue)
        {
            strWhere += " and OA_Journal.start_time >='" + startTime.Value + "'";
        }
        if (endTime.HasValue)
        {
            strWhere += " and OA_Journal.start_time <'" + endTime.Value.AddDays(1.0) + "'";
        }
        System.DateTime? stime = DateTimeHelper.GetDateTime(this.stime.Text);
        System.DateTime? etime = DateTimeHelper.GetDateTime(this.etime.Text);
        if (stime.HasValue)
        {
            strWhere += " and OA_Journal.create_date >='" + stime.Value + "'";
        }
        if (etime.HasValue)
        {
            strWhere += " and OA_Journal.create_date <'" + etime.Value.AddDays(1.0) + "'";
        }

        if (!string.IsNullOrEmpty(txtTitle.Text))
        {
            strWhere += " and OA_Journal.title like '%" + txtTitle.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(proName.Text))
        {
            strWhere += " and PT_PrjInfo.PrjName like '%" + proName.Text.ToString().Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(taskName.Text))
        {
            //strWhere += " and title like '%" + taskName.Text.ToString().Trim() + "%'";
        }

        if (type_id.SelectedValue != "")
        {
            strWhere += " and OA_Journal.type_id ='" + type_id.SelectedValue + "'";
        }
        if (status.SelectedValue != "")
        {
            strWhere += " and OA_Journal.status ='" + Convert.ToInt32(status.SelectedValue) + "'";
        }
        if (base.UserCode != "00000000")
        {
            //strWhere += " and creater ='" + UserCode + "'";
        }
        if (!string.IsNullOrEmpty(ReStrs()))
        {
            strWhere += " and OA_Journal.Id IN (" + ReStrs() + ")";
        }else
        {
            strWhere += " and OA_Journal.Id IN ('无相关数据')";
        }
        return strWhere;
    }

    public string ReStrs()
    {
        string strWhere = "";
        if (!string.IsNullOrEmpty(userType))
        {
            if (userType == "sy")
            {
                strWhere = " and user_id='" + base.UserCode + "' and (user_type=0 or user_type=2) ";
            }
            if (userType == "xg")
            {
                strWhere = " and user_id='" + base.UserCode + "' and (user_type=1 or user_type=2)";
            }
            string str = "";
            string strSql = "select DISTINCT journal_id from OA_Journal_Append where 1=1 " + strWhere + "";
            DataTable dt = publicDbOpClass.DataTableQuary(strSql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str += "'" + dr["journal_id"].ToString() + "',";
                }
            }
            if (!string.IsNullOrEmpty(str))
            {
                string strs = str.Substring(0, str.Length - 1);
                return strs;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }

    }
    protected void btnExecl_Click(object sender, System.EventArgs e)
    {
        DataTable dt = pcSer.GetMsgTable(strWhere(), UserCode);
        dt.Columns.Remove("Id");
        dt.Columns.Remove("type_id");
        dt.Columns.Remove("project_id");
        dt.Columns.Remove("creater");
        dt.Columns.Remove("task_id");
        dt.Columns.Remove("ifck");
        dt.Columns.Remove("plAll");
        dt.Columns.Remove("plNew");
        dt.Columns["pageindex"].ColumnName = "序号";
        dt.Columns["typeName"].ColumnName = "日志类型名称";
        dt.Columns["PrjName"].ColumnName = "项目名称";
        dt.Columns["title"].ColumnName = "日志标题";
        dt.Columns["v_xm"].ColumnName = "创建人";
        dt.Columns["status"].ColumnName = "日志状态";
        dt.Columns["start_time"].ColumnName = "开始时间";
        dt.Columns["end_time"].ColumnName = "结束时间";
        dt.Columns["longs"].ColumnName = "持续时间(分钟)";
        dt.Columns["content"].ColumnName = "日志内容";
        dt.Columns["create_date"].ColumnName = "填写时间";
        dt.Columns["syr"].ColumnName = "审阅人";
        dt.Columns["xgr"].ColumnName = "相关人";
        new Common2().ExportToExecelAll(dt, "日志信息.xls", base.Request.Browser.Browser);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        //System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
        //string value = this.KeyId.Value;
        //string str = value.Replace('[', '(').Replace(']', ')').Replace('"', '\'');
        //string strSql = "select * FROM OA_Journal where status=1 and Id in " + str;
        //DataTable dt = publicDbOpClass.DataTableQuary(strSql);
        //if (dt.Rows.Count > 0)
        //{
        //    base.RegisterShow("系统提示", "已提交的日志不能删除,请重新选择！");
        //    return;
        //}
        //if (value.Contains("["))
        //{
        //    list = JsonHelper.GetListFromJson(value);
        //}
        //else
        //{
        //    list.Add(value);
        //}
        //this.pcSer.Delete(list);
        //base.RegisterShow("系统提示", "删除成功！");
        //this.DataBinds();
    }

    protected void GvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GvList.PageIndex = e.NewPageIndex;
        this.DataBinds();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataBinds();
    }

}