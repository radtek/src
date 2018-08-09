using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Serialize;
using cn.justwin.stockBLL;
using cn.justwin.stockModel;
using com.jwsoft.pm.entpm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class StockManage_Storage_StorageEdit : NBasePage, IRequiresSessionState
{
	private readonly Treasury treasury = new Treasury();
	private string action = string.Empty;
	private string storageCode = string.Empty;
	private SmEnum.SmSetValue manageMode;
	private Storage storage = new Storage();
	private StorageStock storageStock = new StorageStock();
	private Purchase purchase = new Purchase();
	private PurchaseStock purhaseStock = new PurchaseStock();
	private readonly PTPrjInfoBll ptPrjInfo = new PTPrjInfoBll();
	private readonly string stockDataSourceName = "Stock";

	protected override void OnInit(System.EventArgs e)
	{
		this.manageMode = this.treasury.GetManageMode();
		if (base.Request["Action"] != null)
		{
			this.action = base.Request["Action"];
		}
		if (base.Request["StorageCode"] != null)
		{
			if (base.Request["StorageCode"].Contains("["))
			{
				this.storageCode = JsonHelper.GetListFromJson(base.Request["StorageCode"])[0];
			}
			else
			{
				this.storageCode = base.Request["StorageCode"];
			}
		}
        if (HttpContext.Current.Session["yhdm"] == null)
        {
            try
            {
                string UserID = "00000000";//WXAPI.getUserIdByCode(code, "1000010");//
                HttpContext.Current.Session["yhdm"] = UserID;
            }
            catch
            {

            }
        }
        this.gvwStorageStock.PageSize = NBasePage.pagesize;
		base.OnInit(e);
        //base.InitBasePage();
    }
	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
            //dropProject 
            //dropTrea

            if (this.action.Equals("Add"))
			{
				this.hfldPid.Value = System.Guid.NewGuid().ToString();
				this.txtScode.Text = System.DateTime.Now.ToString("yyyyMMddHHmmss");
				this.txtInputDate.Text = System.DateTime.Today.ToShortDateString();
				this.txtPerson.Text = PageHelper.QueryUser(this, base.UserCode);
				DataTable storageStockDataSource = this.storageStock.GetStorageStockDataSource(string.Empty);
				this.ViewState[this.stockDataSourceName] = storageStockDataSource;
				this.gvwStorageStock.DataSource = storageStockDataSource;
				this.gvwStorageStock.DataBind();
				if (this.manageMode != SmEnum.SmSetValue.ParallelMode)
				{
					string totalCode = this.treasury.GetTotalCode();
					this.hfldTrea.Value = totalCode;
					this.txtTrea.Text = this.GetTreasuryNameByCode(totalCode);
				}
			}
			else
			{
				StorageModel model = this.storage.GetModel(this.storageCode);
				this.hfldPid.Value = model.sid;
				this.txtScode.Text = model.scode;
				this.txtInputDate.Text = model.intime.ToShortDateString();
				this.txtPerson.Text = model.person;
				this.hfldTrea.Value = model.tcode;
				this.txtTrea.Text = this.GetTreasuryNameByCode(model.tcode);
				this.txtExplain.Text = model.explain;
				if (!string.IsNullOrEmpty(model.project))
				{
					this.hfldProject.Value = model.project;
					PrjInfoModel modelByPrjGuid = this.ptPrjInfo.GetModelByPrjGuid(model.project);
					if (modelByPrjGuid != null)
					{
						this.txtProject.Text = modelByPrjGuid.PrjName;
					}
				}
				DataTable storageStockDataSource2 = this.storageStock.GetStorageStockDataSource(this.storageCode);
				this.ViewState[this.stockDataSourceName] = storageStockDataSource2;
				this.gvwStorageStock.DataSource = storageStockDataSource2;
				this.gvwStorageStock.DataBind();
				string total = System.Convert.ToDecimal(storageStockDataSource2.Compute("SUM(Total)", string.Empty)).ToString("0.000");
				GridViewUtility.AddTotalRow(this.gvwStorageStock, total, 13);
				if (storageStockDataSource2.Rows.Count > 0)
				{
					this.hfldPurchaseCode.Value = storageStockDataSource2.Rows[0]["linkcode"].ToString();
				}
			}
			if (this.manageMode == SmEnum.SmSetValue.TotalMode)
			{
				this.hfldStorageMode.Value = "1";
			}
			else
			{
				this.hfldStorageMode.Value = "0";
			}
			this.flAnnx.MID = 1802;
			this.flAnnx.FID = this.hfldPid.Value;
			this.flAnnx.Type = 1;
		}
	}
	protected void btnDelete_Click(object sender, System.EventArgs e)
	{
		this.UpdateStorageStockDataSource();
		if (this.ViewState[this.stockDataSourceName] is DataTable)
		{
			DataTable dataTable = this.ViewState[this.stockDataSourceName] as DataTable;
			for (int i = this.gvwStorageStock.Rows.Count - 1; i >= 0; i--)
			{
				GridViewRow gridViewRow = this.gvwStorageStock.Rows[i];
				CheckBox checkBox = gridViewRow.FindControl("chkSelectSingle") as CheckBox;
				if (checkBox.Checked)
				{
					dataTable.Rows.RemoveAt(i);
				}
			}
			dataTable.AcceptChanges();
			this.ViewState[this.stockDataSourceName] = dataTable;
			this.DataBindStorageStock();
		}
	}
	protected void btnBindResource_Click(object sender, System.EventArgs e)
	{
		this.UpdateStorageStockDataSource();
		DataTable dataTable = this.ViewState[this.stockDataSourceName] as DataTable;
		if (dataTable != null)
		{
			ISerializable serializable = new JsonSerializer();
            string[] array = serializable.Deserialize<string[]>(this.hfldResourceCode.Value);
            //string[] array2 = serializable.Deserialize<string[]>(this.hfldResourceCode2.Value);
            if (array != null)
			{
				DataTable purchaseInfoByStorgeStock = this.purhaseStock.GetPurchaseInfoByStorgeStock(array);
                foreach (DataRow row in purchaseInfoByStorgeStock.Rows)
				{
					this.SetResourceTable(row, dataTable);
				}
				this.gvwStorageStock.DataSource = dataTable;
				this.gvwStorageStock.DataBind();
				if (dataTable.Rows.Count > 0)
				{
					string total = System.Convert.ToDecimal(dataTable.Compute("SUM(Total)", string.Empty)).ToString("0.000");
					GridViewUtility.AddTotalRow(this.gvwStorageStock, total, 13);
				}
			}
		}
	}
 //   public DataTable GetPurchaseInfoByStorgeStock1(string[] pscodes)
 //   {
 //       StringBuilder builder = new StringBuilder();
 //       builder.AppendFormat("WITH ctePurchaseStock AS\r\n                                    (\r\n\t                                    --采购单信息\r\n                                        SELECT scode,pscode,SUM(number) ContractNumber,sprice,corp FROM\r\n\t                                    (\r\n\t\t                                    SELECT * FROM Sm_Purchase_Stock\r\n\t\t                                    WHERE pscode in ({0})\r\n\t                                    ) PurchaseStock GROUP BY scode,pscode,sprice,corp\r\n                                    )\r\n                                    , cteAllInStorgeStock AS\r\n                                    (\r\n\t                                    --采购但材料已经入库的信息\r\n                                        SELECT scode,SUM(number) AllInNumber,sprice,corp FROM\r\n\t                                    (\r\n\t\t                                    SELECT storgeStock.* FROM ctePurchaseStock INNER JOIN Sm_Storage_Stock storgeStock \r\n\t\t                                    ON storgeStock.linkCode=ctePurchaseStock.pscode\r\n\t\t                                    AND storgeStock.Scode=ctePurchaseStock.Scode \r\n\t\t                                    AND storgeStock.sprice=ctePurchaseStock.sprice \r\n\t\t                                    AND storgeStock.corp=ctePurchaseStock.corp\r\n\t\t                                    LEFT JOIN Sm_Storage storage ON storgeStock.stCode=storage.sCode\r\n\t\t                                    WHERE FlowState=1 AND Inflag=1\r\n\t                                    ) allInStorgeStock GROUP BY scode,sprice,corp\r\n                                    )", DBHelper.GetInParameterSql(pscodes)).AppendLine();
 //       builder.AppendLine("SELECT ResourceId, currentStorageStock.pscode,ISNULL(ContractNumber,0) ContractNumber,ISNULL(AllInNumber,0) AllInNumber,");
 //       builder.AppendLine("currentStorageStock.number,currentStorageStock.sprice, (currentStorageStock.number*currentStorageStock.sprice) Total, ResourceCode, ResourceName, ");
 //       builder.AppendLine("Specification, Name as UnitName,currentStorageStock.Corp, CorpName,arrivalDate ,Res_Resource.Brand,ModelNumber,TechnicalParameter ");
 //       builder.AppendLine("FROM Res_Resource ");
 //       builder.AppendLine("INNER JOIN Sm_Purchase_Stock currentStorageStock ON currentStorageStock.scode = Res_Resource.ResourceCode ");
 //       builder.AppendLine("LEFT JOIN Res_Unit on Res_Unit.UnitId = Res_Resource.Unit ");
 //       builder.AppendLine("LEFT JOIN XPM_Basic_ContactCorp on currentStorageStock.corp = XPM_Basic_ContactCorp.CorpID ");
 //       builder.AppendLine("LEFT JOIN ctePurchaseStock ON ResourceCode=ctePurchaseStock.scode \r\n                                AND currentStorageStock.sprice=ctePurchaseStock.sprice \r\n                                AND currentStorageStock.corp=ctePurchaseStock.corp \r\n                                LEFT JOIN cteAllInStorgeStock ON ResourceCode=cteAllInStorgeStock.scode \r\n                                AND currentStorageStock.sprice=cteAllInStorgeStock.sprice \r\n                                AND currentStorageStock.corp=cteAllInStorgeStock.corp ");
 //       builder.AppendLine("WHERE currentStorageStock.pscode IN(").Append(DBHelper.GetInParameterSql(pscodes)).Append(")");
 //       builder.AppendLine(" ORDER BY ResourceCode DESC ");
 //       return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), null);
 //   }

    //protected void btnBindResource2_Click(object sender, System.EventArgs e)
    //{
    //    this.UpdateStorageStockDataSource();
    //    DataTable dataTable = this.ViewState[this.stockDataSourceName] as DataTable;
    //    if (dataTable != null)
    //    {
    //        ISerializable serializable = new JsonSerializer();
    //        string[] array1 = serializable.Deserialize<string[]>(this.hfldResourceCode.Value);
    //        string[] array2 = serializable.Deserialize<string[]>(this.hfldResourceCode2.Value);
    //        int ii1 = array1 == null ? 0 : array1.Length;
    //        int ii2 = array2 == null ? 0 : array2.Length;
    //        string[] array = new string[ii1 + ii2];
    //        if (array1 != null)
    //        {
    //            array1.CopyTo(array, 0);
    //            if (array2 != null)
    //            {
    //                array2.CopyTo(array, array1.Length);
    //            }
    //        }
    //        else
    //        {
    //            if (array2 != null)
    //            {
    //                array2.CopyTo(array, array1.Length);
    //            }
    //        }

    //        if (array != null)
    //        {
    //            DataTable purchaseInfoByStorgeStock = this.purhaseStock.GetPurchaseInfoByStorgeStock(array);
    //            foreach (DataRow row in purchaseInfoByStorgeStock.Rows)
    //            {
    //                this.SetResourceTable(row, dataTable);
    //            }
    //            this.gvwStorageStock.DataSource = dataTable;
    //            this.gvwStorageStock.DataBind();
    //            if (dataTable.Rows.Count > 0)
    //            {
    //                string total = System.Convert.ToDecimal(dataTable.Compute("SUM(Total)", string.Empty)).ToString("0.000");
    //                GridViewUtility.AddTotalRow(this.gvwStorageStock, total, 13);
    //            }
    //        }
    //    }
    //}
    private void SetResourceTable(DataRow row, DataTable hasResourceTable)
	{
		int num = DataTableUtility.IndexOf(row, "ResourceCode", hasResourceTable);
		if (num == -1)
		{
			hasResourceTable.Rows.Add(this.SetNewRow(hasResourceTable, row));
			return;
		}
		DataRow dataRow = hasResourceTable.Rows[num];
		if (dataRow["sprice"].Equals(row["sprice"]))
		{
			dataRow["number"] = System.Convert.ToDecimal(dataRow["number"]) + System.Convert.ToDecimal(row["number"]);
			dataRow["Total"] = System.Convert.ToDecimal(dataRow["number"]) * System.Convert.ToDecimal(dataRow["sprice"]);
			return;
		}
		hasResourceTable.Rows.Add(this.SetNewRow(hasResourceTable, row));
	}
	private DataRow SetNewRow(DataTable hasResourceTable, DataRow dbRow)
	{
		DataRow dataRow = hasResourceTable.NewRow();
		dataRow["ResourceCode"] = dbRow["ResourceCode"];
		dataRow["ResourceName"] = dbRow["ResourceName"];
		dataRow["Specification"] = dbRow["Specification"];
		dataRow["UnitName"] = dbRow["UnitName"];
		dataRow["ContractNumber"] = dbRow["ContractNumber"];
		dataRow["AllInNumber"] = dbRow["AllInNumber"];
		dataRow["number"] = dbRow["number"];
		dataRow["sprice"] = dbRow["sprice"];
		dataRow["Total"] = System.Convert.ToDecimal(dataRow["number"]) * System.Convert.ToDecimal(dataRow["sprice"]);
		dataRow["corp"] = dbRow["corp"];
		dataRow["CorpName"] = dbRow["CorpName"];
		dataRow["linkcode"] = dbRow["pscode"];
		return dataRow;
	}
	private bool IsExists(DataTable target, DataRow row, string primarykey)
	{
		foreach (DataRow dataRow in target.Rows)
		{
			if (dataRow[primarykey].ToString() == row[primarykey].ToString())
			{
				return true;
			}
		}
		return false;
	}
	protected void gvwStorageStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		this.gvwStorageStock.PageIndex = e.NewPageIndex;
		this.DataBindStorageStock();
	}
	protected void gvwStorageStock_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex > -1)
		{
			e.Row.Attributes["id"] = this.gvwStorageStock.DataKeys[e.Row.RowIndex].Value.ToString();
		}
	}
    
     protected void btnSaveWX_Click(object sender, System.EventArgs e)
    {
        if (this.action.Equals("Add"))
        {
            this.AddWX();
            return;
        }
        this.UpdateWX();
    }
    protected void btnSave_Click(object sender, System.EventArgs e)
	{
		if (this.action.Equals("Add"))
		{
			this.Add();
			return;
		}
		this.Update();
	}
	private void DataBindStorageStock()
	{
		if (this.ViewState[this.stockDataSourceName] is DataTable)
		{
			DataTable dataTable = this.ViewState[this.stockDataSourceName] as DataTable;
			this.gvwStorageStock.DataSource = dataTable;
			this.gvwStorageStock.DataBind();
			if (dataTable.Rows.Count > 0)
			{
				string total = System.Convert.ToDecimal(dataTable.Compute("SUM(Total)", string.Empty)).ToString("0.000");
				GridViewUtility.AddTotalRow(this.gvwStorageStock, total, 13);
				return;
			}
		}
		else
		{
			this.gvwStorageStock.DataSource = null;
			this.gvwStorageStock.DataBind();
		}
	}
	private void Add()
	{
		using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
		{
			sqlConnection.Open();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			try
			{
				this.AddStorage(sqlTransaction);
				this.AddStorageStock(sqlTransaction);
				this.UpdatePurchaseAccepteState(sqlTransaction);
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				stringBuilder.Append("top.ui.show('添加成功');").Append(System.Environment.NewLine);
				stringBuilder.Append("winclose('StorageEdit', 'Storage.aspx', true)");
				base.RegisterScript(stringBuilder.ToString());
				sqlTransaction.Commit();
			}
			catch
			{
				sqlTransaction.Rollback();
				base.RegisterScript("top.ui.show('系统提示：\\n\\n添加失败！');");
			}
		}
	}
    private void AddWX()
    {
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string str = HttpContext.Current.Session["yhdm"].ToString();
                this.AddStorage(sqlTransaction);
                this.AddStorageStock(sqlTransaction);
                this.UpdatePurchaseAccepteState(sqlTransaction);
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                //stringBuilder.Append("top.ui.show('添加成功');").Append(System.Environment.NewLine);
                //stringBuilder.Append("winclose('StorageEdit', 'Storage.aspx', true)");
                //stringBuilder.Append("alert('添加成功');");
                //stringBuilder.Append("window.location='StorageWX.aspx'");

                stringBuilder.Append("alert('添加成功');");
                //stringBuilder.Append("window.close();");
                stringBuilder.Append("parent.location.reload();");
                base.RegisterScript(stringBuilder.ToString());
                sqlTransaction.Commit();
            }
            catch
            {
                sqlTransaction.Rollback();
                //base.RegisterScript("top.ui.show('系统提示：\\n\\n添加失败！');");
                base.RegisterScript("alert('系统提示：\\n\\n添加失败！');");
            }
        }
    }
    private void AddStorage(SqlTransaction trans)
	{
		StorageModel storageModel = new StorageModel();
		storageModel.sid = this.hfldPid.Value;
		storageModel.scode = this.txtScode.Text.Trim();
		storageModel.tcode = this.hfldTrea.Value;
		storageModel.flowstate = -1;
		storageModel.person = this.txtPerson.Text.Trim();
		storageModel.intime = System.DateTime.Now;
		storageModel.inflag = false;
		storageModel.annx = string.Empty;
		storageModel.explain = this.txtExplain.Text.Trim();
		storageModel.project = this.hfldProject.Value;
		storageModel.isfirst = false;
		storageModel.Supervisor = "";
		storageModel.Trustee = "";
		this.storage.Add(trans, storageModel);
	}
	private void AddStorageStock(SqlTransaction trans)
	{
		if (this.ViewState[this.stockDataSourceName] is DataTable)
		{
			this.UpdateStorageStockDataSource();
			DataTable dataTable = this.ViewState[this.stockDataSourceName] as DataTable;
			System.Collections.Generic.List<StorageStockModel> list = new System.Collections.Generic.List<StorageStockModel>();
			foreach (DataRow dataRow in dataTable.Rows)
			{
				list.Add(new StorageStockModel
				{
					ssid = System.Guid.NewGuid().ToString(),
					scode = dataRow["ResourceCode"].ToString(),
					stcode = this.txtScode.Text.Trim(),
					number = System.Convert.ToDecimal(dataRow["number"].ToString()),
					sprice = System.Convert.ToDecimal(dataRow["sprice"].ToString()),
					corp = dataRow["corp"].ToString(),
					intype = string.Empty,
					linkcode = dataRow["linkcode"].ToString(),
					CheckCondition = ""
				});
			}
			this.storageStock.Add(trans, list);
		}
	}
	private void Update()
	{
		using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
		{
			sqlConnection.Open();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			try
			{
				this.UpdateStorage(sqlTransaction);
				this.UpdateStorageStock(sqlTransaction);
				this.UpdatePurchaseAccepteState(sqlTransaction);
				sqlTransaction.Commit();
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				stringBuilder.Append("top.ui.show('修改成功');").Append(System.Environment.NewLine);
				stringBuilder.Append("winclose('StorageEdit', 'Storage.aspx', true)");
				base.RegisterScript(stringBuilder.ToString());
			}
			catch
			{
				base.RegisterScript("top.ui.show('修改失败');");
			}
		}
	}
    private void UpdateWX()
    {
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                this.UpdateStorage(sqlTransaction);
                this.UpdateStorageStock(sqlTransaction);
                this.UpdatePurchaseAccepteState(sqlTransaction);
                sqlTransaction.Commit();
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                // stringBuilder.Append("top.ui.show('修改成功');").Append(System.Environment.NewLine);
                //stringBuilder.Append("winclose('StorageEdit', 'Storage.aspx', true)");
                //window.location = url
                stringBuilder.Append("alert('修改成功');");//parent.location.reload(); //stringBuilder.Append("window.location='StorageWX.aspx'");
                //stringBuilder.Append("window.close();");
                stringBuilder.Append("parent.location.reload();");
                base.RegisterScript(stringBuilder.ToString());
            }
            catch
            {
                //base.RegisterScript("top.ui.show('修改失败');");
                base.RegisterScript("alert('修改失败');");
            }
        }
    }
    private void UpdateStorage(SqlTransaction trans)
	{
		StorageModel model = this.storage.GetModel(this.storageCode);
		model.tcode = this.hfldTrea.Value;
		model.person = this.txtPerson.Text.Trim();
		model.explain = this.txtExplain.Text.Trim();
		model.project = this.hfldProject.Value;
		this.storage.Update(trans, model);
	}
	private void UpdateStorageStock(SqlTransaction trans)
	{
		this.storageStock.DeleteByStorageCode(trans, this.storageCode);
		this.AddStorageStock(trans);
	}
	private void UpdateStorageStockDataSource()
	{
		if (this.ViewState[this.stockDataSourceName] is DataTable)
		{
			DataTable dataTable = this.ViewState[this.stockDataSourceName] as DataTable;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				GridViewRow gridViewRow = this.gvwStorageStock.Rows[i];
				if (gridViewRow.FindControl("txtNumber") is TextBox)
				{
					TextBox textBox = gridViewRow.FindControl("txtNumber") as TextBox;
					decimal num = System.Convert.ToDecimal(textBox.Text.Trim());
					dataRow["number"] = num;
					decimal d = System.Convert.ToDecimal(dataRow["sprice"]);
					dataRow["Total"] = num * d;
				}
			}
			this.ViewState[this.stockDataSourceName] = dataTable;
		}
	}
	private void UpdatePurchaseAccepteState(SqlTransaction trans)
	{
		DataTable dataTable = this.ViewState[this.stockDataSourceName] as DataTable;
		if (dataTable != null)
		{
			try
			{
				System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (!list.Contains(dataTable.Rows[i]["linkcode"].ToString()))
					{
						list.Add(dataTable.Rows[i]["linkcode"].ToString());
					}
				}
				this.purchase.UpdateAcceptState(trans, list.ToArray());
			}
			catch (System.Exception)
			{
				throw new System.ApplicationException("找不到关联的采购编号");
			}
		}
	}
	private string GetTreasuryNameByCode(string code)
	{
		string result = string.Empty;
		SmTreasuryService smTreasuryService = new SmTreasuryService();
		SmTreasury byCode = smTreasuryService.GetByCode(code);
		if (byCode != null)
		{
			result = byCode.tname;
		}
		return result;
	}
}


