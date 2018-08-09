using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Services;
using cn.justwin.stockBLL;
using cn.justwin.stockModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class StockManage_SmOutReserve_QOutReserve : NBasePage, IRequiresSessionState
{
	private OutReserveBll outReserveBll = new OutReserveBll();
	private OutStockBll outStockBll = new OutStockBll();
	private TreasuryStockBll treasuryStockBll = new TreasuryStockBll();
	private string prjId = string.Empty;

	protected override void OnInit(EventArgs e)
	{
		this.gvOutReserve.PageSize = NBasePage.pagesize;
		if (!string.IsNullOrEmpty(base.Request["prjGuid"]))
		{
			this.prjId = base.Request["prjGuid"].ToString();
		}
		base.OnInit(e);
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.BindGv();
			PTPrjInfoService pTPrjInfoService = new PTPrjInfoService();
			this.lblProject.Text = pTPrjInfoService.GetById(this.prjId).PrjName;

            this.prjGuid.Text = base.Request["prjGuid"].ToString();
        }
	}
	public void BindGv()
	{
        //string PrjGuid = base.Request["prjGuid"].ToString();
        //try
        //{
        //    txtPPcode.Text = base.Request["txtPPcode"].ToString();
        //    txtStartTime.Text = base.Request["txtStartTime"].ToString();
        //    txtEndTime.Text = base.Request["txtEndTime"].ToString();
        //    txtPeople.Value = base.Request["txtPeople"].ToString();
        //    txtTrea.Text = base.Request["txtTrea"].ToString();
        //    //string status = base.Request["status"].ToString();
        //    status.SelectedValue = base.Request["status"].ToString();
        //}
        //catch
        //{

        //}



        string str = string.Empty;
		if (!string.IsNullOrEmpty(this.prjId))
		{
			str = " and procode='" + this.prjId + "'";
		}
		else
		{
			str = " and procode is null ";
		}
        string ss = status.SelectedValue.ToString();

        //< asp:ListItem Value = "wqr" > 未确认 </ asp:ListItem >

        //                                              < asp:ListItem Value = "wqm" > 未签名 </ asp:ListItem >

        //                                                     < asp:ListItem Value = "all" > 全部 </ asp:ListItem >
        string strwhere = string.Empty;
        if (ss == "wqr")
        {
            strwhere = " and p1.isout='false' ";
        }
        else if (ss == "wqm")
        {
            strwhere = " and p1.writeName is null ";
        }
        //else if (ss == "all")
        //{
        //    strwhere = " ";
        //}
        else
        {
            strwhere = " ";
        }
        //DataTable dt = this.outReserveBll.GetListByParm(this.txtPPcode.Text.Trim(), this.txtStartTime.Text, this.txtEndTime.Text, this.txtPeople.Value.Trim(), "", this.hfldTrea.Value, " and p1.flowstate=1 and p1.isout='false' " + str);

        DataTable dt = GetListByParm2(this.txtPPcode.Text.Trim(), this.txtStartTime.Text, this.txtEndTime.Text, this.txtPeople.Value.Trim(), "", this.hfldTrea.Value, " and p1.flowstate=1 " + strwhere + str);
        this.BindGv(dt);
	}

    public DataTable GetListByParm2(string orcode, string startTime, string endTime, string person, string procode, string tname, string strWhere)
    {//writeName is null
        StringBuilder builder = new StringBuilder();
        List<SqlParameter> list = new List<SqlParameter>();
        builder.Append("select p1.orid,p1.orcode,p1.procode,p1.tcode,p1.flowstate,p1.isout,p1.person,p1.intime,p1.annx,p1.PickingPeople,p1.PickingSector,p1.explain,p1.writeName,p2.tname,p3.prjName ");
        builder.Append(" FROM Sm_OutReserve as p1");
        builder.Append(" inner join dbo.Sm_Treasury as p2 on p1.tcode=p2.tcode");
        builder.Append(" inner join dbo.PT_PrjInfo as p3 on p1.procode=p3.prjGuid");
        builder.Append("  where p1.orcode like @orcode ");
        builder.Append("  and p1.person like @person ");
        builder.Append(strWhere);
        list.Add(new SqlParameter("@orcode", '%' + orcode + '%'));
        list.Add(new SqlParameter("@person", '%' + person + '%'));
        if (!string.IsNullOrEmpty(procode))
        {
            builder.Append(" and p1.procode=@procode");
            list.Add(new SqlParameter("@procode", procode));
        }
        if (!string.IsNullOrEmpty(tname))
        {
            builder.Append(" and p2.tname LIKE @tname");
            list.Add(new SqlParameter("@tname", '%' + tname + '%'));
        }
        if (!string.IsNullOrEmpty(startTime))
        {
            builder.Append(" and p1.intime>=@startTime");
            list.Add(new SqlParameter("@startTime", startTime));
        }
        if (!string.IsNullOrEmpty(endTime))
        {
            builder.Append(" and p1.intime<=@endTime");
            list.Add(new SqlParameter("@endTime", endTime + " 23:59:59"));
        }
        builder.Append(" order by intime desc");
        return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), list.ToArray());
    }
    public void BindGv(DataTable storageDataSource)
	{
		if (storageDataSource.Rows.Count == 0)
		{
			storageDataSource.Rows.Add(storageDataSource.NewRow());
			this.gvOutReserve.DataSource = storageDataSource;
			this.gvOutReserve.DataBind();
			this.gvOutReserve.HeaderRow.Cells[0].Visible = false;
			this.gvOutReserve.Rows[0].Visible = false;
			return;
		}
		this.gvOutReserve.DataSource = storageDataSource;
		this.gvOutReserve.DataBind();
	}
	protected void gvPurchaseplan_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		this.gvOutReserve.PageIndex = e.NewPageIndex;
		this.BindGv();
	}
	protected void btn_Search_Click(object sender, EventArgs e)
	{
		this.BindGv();
	}
    protected void btnOkAfter_Click(object sender, EventArgs e)
    {
        saveImg("pc");
    }

    private void saveImg(string v)
    {
        string strImg = dataUrl.Value.ToString();
        string strKeyId = KeyId.Value.ToString();
        OutReserveModel model2 = this.outReserveBll.GetModelByIc(strKeyId);
        //model2.isout = true;
        //model2.IsOutTime = DateTime.Now;
        model2.writeName = strImg;
        int num2 = this.outReserveBll.Update(null, model2);
        if (num2 > 0)
        {
            base.RegisterScript("alert('系统提示：\\n\\n操作成功');");
        }
        else
        {
            base.RegisterScript("alert('系统提示：\\n\\n操作失败');");
        }
        if (v=="pc")
        {
            base.RegisterScript("location='QOutReserve.aspx?prjGuid=" + base.Request["prjGuid"].ToString() + "'");
        }
        if (v == "wx") {
            base.RegisterScript("location='QOutReserveWX.aspx?prjGuid=" + base.Request["prjGuid"].ToString() + "'");
        }
     
    }

    protected void btnOkAfterWX_Click(object sender, EventArgs e)
    {
        saveImg("wx");
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        save("pc");
    }

    protected void btnOkWX_Click(object sender, EventArgs e)
    {
        save("wx");
    }
    private void save(string v)
    {
    string strImg = dataUrl.Value.ToString();
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                foreach (GridViewRow gridViewRow in this.gvOutReserve.Rows)
                {
                    CheckBox checkBox = gridViewRow.FindControl("cbBox") as CheckBox;
                    if (checkBox != null && checkBox.Checked)
                    {
                        List<OutStockModel> listArray = this.outStockBll.GetListArray(" where orcode='" + checkBox.ToolTip + "'");
                        OutReserveModel model = this.outReserveBll.GetModel(checkBox.ToolTip);
                        foreach (OutStockModel current in listArray)
                        {
                            List<TreasuryStockModel> listArray2 = this.treasuryStockBll.GetListArray(string.Concat(new object[]
                            {
                                " where scode='",
                                current.scode,
                                "' and sprice=",
                                current.sprice,
                                " and corp='",
                                current.corp,
                                "' and tcode='",
                                model.tcode,
                                "'  order by intime asc"
                            }));
                            decimal num = 0m;
                            foreach (TreasuryStockModel current2 in listArray2)
                            {
                                num += current2.snumber;
                            }
                            if (current.number > num)
                            {
                                base.RegisterScript("alert('库存量不足!!')");
                                //base.RegisterScript("location='QOutReserve.aspx?prjGuid=" + base.Request["prjGuid"].ToString() + "'");
                                if (v == "wx")
                                {
                                    base.RegisterScript("location='QOutReserveWX.aspx?prjGuid=" + base.Request["prjGuid"].ToString() + "'");
                                }
                                if (v == "pc")
                                {
                                    base.RegisterScript("location='QOutReserve.aspx?prjGuid=" + base.Request["prjGuid"].ToString() + "'");
                                }
                                return;
                            }
                            foreach (TreasuryStockModel current3 in listArray2)
                            {
                                if (current3.snumber >= current.number)
                                {
                                    current3.snumber -= current.number;
                                    if (current3.snumber == 0m)
                                    {
                                        this.treasuryStockBll.Delete(current3.tsid);
                                    }
                                    else
                                    {
                                        this.treasuryStockBll.Update(current3);
                                    }
                                    Common2.AlarmMethod(current3.tcode, current3.scode);
                                    break;
                                }
                                if (current3.snumber < current.number)
                                {
                                    current.number -= current3.snumber;
                                    this.treasuryStockBll.Delete(current3.tsid);
                                }
                            }
                        }
                        OutReserveModel model2 = this.outReserveBll.GetModel(checkBox.ToolTip);
                        model2.isout = true;
                        model2.IsOutTime = DateTime.Now;
                        model2.writeName = strImg;
                        int num2 = this.outReserveBll.Update(null, model2);
                        if (num2 > 0)
                        {
                            base.RegisterScript("alert('系统提示：\\n\\n操作成功');");
                        }
                        else
                        {
                            base.RegisterScript("alert('系统提示：\\n\\n操作失败');");
                        }
                    }
                }
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\n出库出现异常,出库失败！');");
            }
        }
        if (v == "wx")
        {
            base.RegisterScript("location='QOutReserveWX.aspx?prjGuid=" + base.Request["prjGuid"].ToString() + "'");
        }
            if (v == "pc")
            {
            base.RegisterScript("location='QOutReserve.aspx?prjGuid=" + base.Request["prjGuid"].ToString() + "'");
        }
           
    }
	protected void gvOutReserve_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex > -1)
		{
			try
			{
				e.Row.Attributes["id"] = this.gvOutReserve.DataKeys[e.Row.RowIndex].Value.ToString();
			}
			catch
			{
			}
		}
	}
}


