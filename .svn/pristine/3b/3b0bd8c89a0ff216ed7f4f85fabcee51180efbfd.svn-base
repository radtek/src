using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Serialize;
using cn.justwin.stockBLL;
using cn.justwin.stockModel;
using cn.justwin.Web;
using com.jwsoft.pm.data;
using com.jwsoft.pm.entpm;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class StockManage_basicset_SmWantPlan : NBasePage, IRequiresSessionState
{
    private class ResInfo
    {
        public string scode
        {
            get;
            set;
        }
        public decimal sprice
        {
            get;
            set;
        }
        public decimal quantity
        {
            get;
            set;
        }
        public string taskId
        {
            get;
            set;
        }
        public string resId
        {
            get;
            set;
        }
        public string taskName
        {
            get;
            set;
        }
    }
    private MaterialWantPlan materialWant = new MaterialWantPlan();
    private MeterialPlanStock materialStock = new MeterialPlanStock();
    private string isWBSRelevance = ConfigHelper.Get("IsWBSRelevance");
    private string wantplanCode = string.Empty;
    private string projectCode = string.Empty;
    private string opType = string.Empty;
    private string prjId = string.Empty;

    protected override void OnInit(System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request.QueryString["swcode"]))
        {
            this.wantplanCode = base.Request.QueryString["swcode"];
        }
        if (!string.IsNullOrEmpty(base.Request["pcode"]))
        {
            this.projectCode = base.Request["pcode"];
            this.prjId = base.Request["pcode"];
        }
        if (!string.IsNullOrEmpty(base.Request["optype"]))
        {
            this.opType = base.Request["optype"];
        }
        if (!string.IsNullOrEmpty(base.Request["prjId"]))
        {
            this.prjId = base.Request["prjId"];
        }
        base.OnInit(e);
    }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            base.Response.Cache.SetNoStore();
            base.Response.Clear();
            PTPrjInfoBll pTPrjInfoBll = new PTPrjInfoBll();
            string prjName = pTPrjInfoBll.GetModelByPrjGuid(base.Request.QueryString["pcode"]).PrjName;
            this.txtProName.Value = prjName;
            this.hdnProjectCode.Value = base.Request.QueryString["pcode"];
            this.txtCode.Text = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            this.txtInputDate.Text = System.DateTime.Now.ToShortDateString();
            string a = base.Request.QueryString["optype"];
            this.txtPerson.Text = PageHelper.QueryUser(this, base.UserCode);
            if (a == "add")
            {
                this.hfldWantPlanGuid.Value = System.Guid.NewGuid().ToString();
                this.chkContainPending.Checked = StockParameter.IsContainPending;
                this.gvSmWantPlanStock.DataSource = null;
                this.gvSmWantPlanStock.DataBind();
            }
            if (a == "update" || a == "look")
            {
                this.setControlsValue();
            }
            this.FileLink1.MID = 1803;
            this.FileLink1.FID = this.hfldWantPlanGuid.Value;
            this.FileLink1.Type = 1;
            this.getMateriaPlanTable();
            this.SetBudFlowState();
        }
    }

    protected void btnSaveWX_ServerClick(object sender, System.EventArgs e)
    {
        BasicConfigService basicConfigService = new BasicConfigService();
        string strIF = basicConfigService.GetValue("ifMoreBudget");
        //需求时，是否可超预算  0不可以  1可以
        if (strIF == "0")
        {
            int ii = 0;
            if (this.gvSmWantPlanStock.Rows.Count > 0)
            {
                System.Collections.Generic.List<MaterialPlanStockModel> list = new System.Collections.Generic.List<MaterialPlanStockModel>();
                System.Collections.Generic.Dictionary<string, decimal> dictionary = new System.Collections.Generic.Dictionary<string, decimal>();
                foreach (GridViewRow gridViewRow in this.gvSmWantPlanStock.Rows)
                {
                    TextBox txtNumber = (TextBox)gridViewRow.FindControl("txtNumber");
                    Label ResourceQuantity = (Label)gridViewRow.FindControl("ResourceQuantity");
                    Label numberIng = (Label)gridViewRow.FindControl("numberIng");

                    Decimal num = System.Convert.ToDecimal(txtNumber.Text);//需求数量
                    Decimal rq = System.Convert.ToDecimal(ResourceQuantity.Text);//预算数量
                    Decimal ni = System.Convert.ToDecimal(numberIng.Text);//在途数量
                    //在途+需求 >预算
                    if ((ni + num) > rq)
                    {
                        ii++;
                    }
                }
            }
            if (ii > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("alert('需求时，不能超预算数量!');");
                base.RegisterScript(stringBuilder.ToString());
            }
            else
            {
                save("wx");
            }
        }
        else
        {
            save("wx");
        }

    }
    protected void btnSave_ServerClick(object sender, System.EventArgs e)
    {
        BasicConfigService basicConfigService = new BasicConfigService();
        string strIF = basicConfigService.GetValue("ifMoreBudget");
        //需求时，是否可超预算  0不可以  1可以
        if (strIF == "0")
        {
            int ii = 0;
            if (this.gvSmWantPlanStock.Rows.Count > 0)
            {
                System.Collections.Generic.List<MaterialPlanStockModel> list = new System.Collections.Generic.List<MaterialPlanStockModel>();
                System.Collections.Generic.Dictionary<string, decimal> dictionary = new System.Collections.Generic.Dictionary<string, decimal>();
                try
                {
                    foreach (GridViewRow gridViewRow in this.gvSmWantPlanStock.Rows)
                    {
                        TextBox txtNumber = (TextBox)gridViewRow.FindControl("txtNumber");
                        Label ResourceQuantity = (Label)gridViewRow.FindControl("ResourceQuantity");
                        Label numberIng = (Label)gridViewRow.FindControl("numberIng");

                        string strNum = txtNumber.Text.ToString().Trim();//需求数量
                        string strRQ = ResourceQuantity.Text.ToString().Trim();//预算数量
                        string strNI = numberIng.Text.ToString().Trim();//在途数量
                        Decimal num = 0;
                        Decimal rq = 0;
                        Decimal ni = 0;
                        if (!string.IsNullOrEmpty(strNum))
                        {
                             num = System.Convert.ToDecimal(txtNumber.Text);//需求数量
                        }
                        if (!string.IsNullOrEmpty(strRQ))
                        {
                            rq = System.Convert.ToDecimal(ResourceQuantity.Text);//预算数量
                        }
                        if (!string.IsNullOrEmpty(strNI))
                        {
                             ni = System.Convert.ToDecimal(numberIng.Text);//在途数量
                        }
                        if ((ni + num) > rq && !string.IsNullOrEmpty(strRQ) && !string.IsNullOrEmpty(strNI))
                        {
                            //    txtNumber.Font.Bold = true;
                            txtNumber.ForeColor = Color.FromName("#FF7D00");
                            //    ResourceQuantity.Font.Bold = true;
                            //    ResourceQuantity.ForeColor = Color.FromName("#FF7D00");
                            //numberIng.Font.Bold = true;
                            //numberIng.ForeColor = Color.FromName("#FF7D00");
                            ii++;
                        }
                    }
                }
                catch
                {
                    ii = 0;
                }
            }
            if (ii>0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("alert('需求时，不能超预算数量!');");
                base.RegisterScript(stringBuilder.ToString());
            }
            else
            {
                save("pc");
            }
        }
        else
        {
            save("pc");
        }
    }
    private void save(string type)
    {
        if (this.opType == "add")
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                try
                {
                    MaterialWantPlanModel materialWantPlanModel = new MaterialWantPlanModel();
                    this.setModelValue(materialWantPlanModel);
                    this.materialWant.Add(sqlTransaction, materialWantPlanModel);
                    string empty = string.Empty;
                    if (this.addMaterialList(sqlTransaction, ref empty))
                    {
                        if (!string.IsNullOrEmpty(empty))
                        {
                            if (type == "pc")
                            {
                                base.RegisterScript(string.Concat(new string[]
                            {
                                "top.ui.show('",
                                empty,
                                "<br />添加成功');winclose('SmWantPlan', 'SmWantPlanList.aspx?prjId=",
                                this.projectCode,
                                "', true)"
                            }));
                            }
                            else
                            {
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append("alert('添加成功');");
                                stringBuilder.Append("parent.location.reload();");
                                base.RegisterScript(stringBuilder.ToString());
                            }
                        }
                        else
                        {
                            if (type == "pc")
                            {
                                base.RegisterScript("top.ui.show('添加成功');winclose('SmWantPlan', 'SmWantPlanList.aspx?prjId=" + this.projectCode + "', true)");
                            }
                            else
                            {
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append("alert('添加成功');");
                                stringBuilder.Append("parent.location.reload();");
                                base.RegisterScript(stringBuilder.ToString());
                            }
                        }
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        if (type == "pc")
                        {
                            base.RegisterScript("top.ui.show('" + empty + "<br />添加失败');");
                        }
                        else
                        {
                            base.RegisterScript("alert('系统提示：\\n\\n添加失败！');");
                        }
                        sqlTransaction.Rollback();
                    }
                }
                catch (System.Exception ex)
                {
                    sqlTransaction.Rollback();
                    if (type == "pc")
                    {
                        base.RegisterScript("top.ui.show('添加失败');winclose('SmWantPlan', 'SmWantPlanList.aspx?prjId=" + this.projectCode + "', true)");
                    }
                    else
                    {
                        base.RegisterScript("alert('系统提示：\\n\\n添加失败！');");
                    }
                }
                return;
            }
        }
        using (SqlConnection sqlConnection2 = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection2.Open();
            SqlTransaction sqlTransaction2 = sqlConnection2.BeginTransaction();
            try
            {
                MaterialWantPlanModel model = this.materialWant.GetModel(this.wantplanCode);
                model.swcode = this.txtCode.Text;
                model.procode = this.hdnProjectCode.Value;
                model.person = this.txtPerson.Text;
                model.intime = this.txtInputDate.Text;
                model.explain = this.txtRemark.Text;
                model.ContainPending = this.chkContainPending.Checked;
                model.EquipmentId = this.hfldEquId.Value;
                this.materialWant.Update(sqlTransaction2, model);
                this.materialStock.DeleteByWantplanCode(sqlTransaction2, this.wantplanCode);
                string empty2 = string.Empty;
                if (this.addMaterialList(sqlTransaction2, ref empty2))
                {
                    if (!string.IsNullOrEmpty(empty2))
                    {
                        if (type == "pc")
                        {
                            base.RegisterScript(string.Concat(new string[]
                        {
                            "top.ui.show('",
                            empty2,
                            "<br />修改成功');winclose('SmWantPlan', 'SmWantPlanList.aspx?prjId=",
                            this.projectCode,
                            "', true)"
                        }));
                        }
                        else
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("alert('添加成功');");
                            stringBuilder.Append("parent.location.reload();");
                            base.RegisterScript(stringBuilder.ToString());
                        }
                    }
                    else
                    {
                        if (type == "pc")
                        {
                            base.RegisterScript("top.ui.show('修改成功');winclose('SmWantPlan', 'SmWantPlanList.aspx?prjId=" + this.projectCode + "', true)");
                        }
                        else
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("alert('添加成功');");
                            stringBuilder.Append("parent.location.reload();");
                            base.RegisterScript(stringBuilder.ToString());
                        }
                    }
                    sqlTransaction2.Commit();
                }
                else
                {
                    if (type == "pc")
                    {
                        base.RegisterScript("top.ui.show('" + empty2 + "<br />修改失败');");
                    }
                    else
                    {
                        base.RegisterScript("alert('系统提示：\\n\\n添加失败！');");
                    }
                    sqlTransaction2.Rollback();
                }
            }
            catch (System.Exception)
            {
                sqlTransaction2.Rollback();
                if (type == "pc")
                {
                    base.RegisterScript("top.ui.show('修改失败');winclose('SmWantPlan', 'SmWantPlanList.aspx?prjId=" + this.projectCode + "', true)");
                }
                else
                {
                    base.RegisterScript("alert('系统提示：\\n\\n添加失败！');");
                }
            }
        }
    }
    protected void gvSmWantPlanStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Attributes["id"] = this.gvSmWantPlanStock.DataKeys[e.Row.RowIndex].Value.ToString();
        }
    }
    protected void btnDelMaterial_ServerClick(object sender, System.EventArgs e)
    {
        hfldResourceIds.Value = "";
        hfldResourceIdsZZCL.Value = "";
        this.UpdateSelectResources();
        this.delRow();
    }
    protected void btnSaveDesignCode_Click(object sender, System.EventArgs e)
    {
        this.UpdateSelectResources();
        DataTable dataTable = this.ViewState["ResourcesTable"] as DataTable;
        if (dataTable != null && this.gvSmWantPlanStock.Rows.Count > 0)
        {
            string value = string.Empty;
            foreach (GridViewRow gridViewRow in this.gvSmWantPlanStock.Rows)
            {
                CheckBox checkBox = (CheckBox)gridViewRow.FindControl("chkBox");
                if (checkBox.Checked)
                {
                    value = checkBox.ToolTip.Trim();
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["wpsid"].ToString().Equals(value))
                        {
                            dataRow["DesignCode"] = this.txtDesignCode.Text.Trim();
                            break;
                        }
                    }
                }
            }
        }
        this.ViewState["ResourcesTable"] = dataTable;
        DataTable dtCopy = dataTable.Copy();
        try
        {
           
            DataColumn dataColumn1 = new DataColumn();
            dataColumn1.ColumnName = "ResourceQuantity";
            dataColumn1.DataType = System.Type.GetType("System.String");
            dtCopy.Columns.Add(dataColumn1);

            DataColumn dataColumn2 = new DataColumn();
            dataColumn2.ColumnName = "numberIng";
            dataColumn2.DataType = System.Type.GetType("System.String");
            dtCopy.Columns.Add(dataColumn2);
        }
        catch
        {

        }
        //DataTable dt = dtNum();
        foreach (DataRow drc in dtCopy.Rows)
        {
            foreach (DataRow dr in dtNum().Rows)
            {
                if (drc["ResourceCode"].ToString().Trim() == dr["scode"].ToString().Trim())
                {
                    drc["ResourceQuantity"] = dr["ResourceQuantity"];
                    drc["numberIng"] = dr["numberIng"];
                }
            }
        }
        this.gvSmWantPlanStock.DataSource = dtCopy;
        //this.gvSmWantPlanStock.DataSource = (DataTable)this.ViewState["ResourcesTable"];
        this.gvSmWantPlanStock.DataBind();
    }
    protected void btnBindResource_Click(object sender, System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.hfldResourceIds.Value))
        {
            ISerializable serializable = new cn.justwin.Serialize.JsonSerializer();
            string[] array = serializable.Deserialize<string[]>(this.hfldResourceIds.Value);
            if (array != null)
            {
                this.UpdateSelectResources();
                DataTable dataTable = this.materialStock.showMaterialListForAdd(DBHelper.GetInParameterSql(array), this.prjId, string.Empty, 0);
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = "TaskName";
                dataColumn.DataType = System.Type.GetType("System.String");
                dataTable.Columns.Add(dataColumn);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    dataRow["TaskId"] = string.Empty;
                    dataRow["TaskName"] = string.Empty;
                    dataRow["number"] = 0m;
                    dataRow["arrivalDate"] = System.DBNull.Value;
                }
                dataTable.AcceptChanges();
                DataTable dataTable2 = this.ViewState["ResourcesTable"] as DataTable;
                if (dataTable2 != null)
                {
                    dataTable2.PrimaryKey = new DataColumn[]
                    {
                        dataTable2.Columns["ResourceCode"],
                        dataTable2.Columns["TaskId"]
                    };
                    dataTable.PrimaryKey = new DataColumn[]
                    {
                        dataTable.Columns["ResourceCode"],
                        dataTable.Columns["TaskId"]
                    };
                    dataTable2.Merge(dataTable, true);
                    dataTable = dataTable2;
                }
                //this.ViewState["ResourcesTable"] = dataTable;
                DataTable dtCopy = dataTable.Copy();
                try
                {
                    
                    DataColumn dataColumn1 = new DataColumn();
                    dataColumn1.ColumnName = "ResourceQuantity";
                    dataColumn1.DataType = System.Type.GetType("System.String");
                    dtCopy.Columns.Add(dataColumn1);

                    DataColumn dataColumn2 = new DataColumn();
                    dataColumn2.ColumnName = "numberIng";
                    dataColumn2.DataType = System.Type.GetType("System.String");
                    dtCopy.Columns.Add(dataColumn2);
                }
                catch
                {

                }
                //DataTable dt = dtNum();
                foreach (DataRow drc in dtCopy.Rows)
                {
                    foreach (DataRow dr in dtNum().Rows)
                    {
                        if (drc["ResourceCode"].ToString().Trim() == dr["scode"].ToString().Trim())
                        {
                            drc["ResourceQuantity"] = dr["ResourceQuantity"];
                            drc["numberIng"] = dr["numberIng"];
                        }
                    }
                }
                this.gvSmWantPlanStock.DataSource = dtCopy;
                //this.gvSmWantPlanStock.DataSource = dataTable;
                this.gvSmWantPlanStock.DataBind();
            }
        }
        this.hfldResourceIds.Value = string.Empty;
    }

    protected void btnBindResourceZZCL_Click(object sender, System.EventArgs e)
    {
        DataTable dt = null;
        //["4b0ae68c-ff0b-403c-bcd5-39a0d07a7ee0|000400002|99","82eddac8-0546-447f-b96b-eacd75d7d9f1|000400001|66"]
        if (!string.IsNullOrEmpty(this.hfldResourceIdsZZCL.Value))
        {
            ISerializable serializable = new cn.justwin.Serialize.JsonSerializer();
            string[] array = serializable.Deserialize<string[]>(this.hfldResourceIdsZZCL.Value);
            //4b0ae68c - ff0b - 403c - bcd5 - 39a0d07a7ee0 | 000400002 | 99
            //82eddac8 - 0546 - 447f - b96b - eacd75d7d9f1 | 000400001 | 66
            string[] array2 = null;
            if (array != null)
            {
                string strIDS = string.Empty;
                foreach (string str in array)
                {
                    strIDS += "'" + str.Split('|')[0].ToString() + "',";
                }
                string strSQL = "select FID,CID,NUM from Res_ResourceRelation where FID in (" + strIDS.Substring(0, strIDS.Length - 1) + ")";
                dt = publicDbOpClass.DataTableQuary(strSQL);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        foreach (string str in array)
                        {
                            string strID = str.Split('|')[0].ToString();
                            string strNUM = str.Split('|')[2].ToString();
                            if (dr["FID"].ToString() == strID)
                            {
                                try
                                {
                                    dr["NUM"] = Convert.ToString(Convert.ToDouble(dr["NUM"].ToString()) * Convert.ToDouble(strNUM));
                                }
                                catch
                                {

                                }

                            }
                        }
                    }

                    array2 = new string[dt.Rows.Count];
                    int ii = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        array2[ii] = dr["CID"].ToString();
                        ii++;
                    }
                }
            }
            //string[] array2 = new string[dt.Rows.Count];
            if (array2 != null)
            {
                this.UpdateSelectResources();
                //showMaterialListForAdd
                DataTable dataTable = this.materialStock.showMaterialListForAdd(DBHelper.GetInParameterSql(array2), this.prjId, string.Empty, 0);
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = "TaskName";
                dataColumn.DataType = System.Type.GetType("System.String");
                dataTable.Columns.Add(dataColumn);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    dataRow["TaskId"] = string.Empty;
                    dataRow["TaskName"] = string.Empty;
                    dataRow["number"] = 0m;
                    dataRow["arrivalDate"] = System.DBNull.Value;
                }
                dataTable.AcceptChanges();
                DataTable dataTable2 = this.ViewState["ResourcesTable"] as DataTable;
                if (dataTable2 != null)
                {
                    dataTable2.PrimaryKey = new DataColumn[]
                    {
                        dataTable2.Columns["ResourceCode"],
                        dataTable2.Columns["TaskId"]
                    };
                    dataTable.PrimaryKey = new DataColumn[]
                    {
                        dataTable.Columns["ResourceCode"],
                        dataTable.Columns["TaskId"]
                    };
                    dataTable2.Merge(dataTable, true);
                    dataTable = dataTable2;
                }

                if (dt != null && dt.Rows.Count > 0 && dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drA in dataTable.Rows)
                    {
                        foreach (DataRow drB in dt.Rows)
                        {
                            string number = drA["number"].ToString();
                            string ResourceId = drA["ResourceId"].ToString();

                            string NUM = drB["NUM"].ToString();
                            string CID = drB["CID"].ToString();
                            if (ResourceId == CID)
                            {
                                try
                                {
                                    double db = Convert.ToDouble(drA["number"].ToString());
                                    db += Convert.ToDouble(NUM);
                                    drA["number"] = db.ToString();
                                }
                                catch
                                {

                                }

                            }
                        }
                    }
                }
                this.ViewState["ResourcesTable"] = dataTable;
                DataTable dtCopy = dataTable.Copy();
                try
                {
                    
                    DataColumn dataColumn1 = new DataColumn();
                    dataColumn1.ColumnName = "ResourceQuantity";
                    dataColumn1.DataType = System.Type.GetType("System.String");
                    dtCopy.Columns.Add(dataColumn1);

                    DataColumn dataColumn2 = new DataColumn();
                    dataColumn2.ColumnName = "numberIng";
                    dataColumn2.DataType = System.Type.GetType("System.String");
                    dtCopy.Columns.Add(dataColumn2);
                }
                catch
                {

                }
                //DataTable dt = dtNum();

                //foreach (DataRow drc in dtCopy.Rows)
                //{
                //    foreach (DataRow dr in dtNum().Rows)
                //    {
                //        if (drc["ResourceCode"].ToString().Trim() == dr["scode"].ToString().Trim())
                //        {
                //            drc["ResourceQuantity"] = dr["ResourceQuantity"];
                //            drc["numberIng"] = dr["numberIng"];
                //        }
                //    }
                //}

                this.gvSmWantPlanStock.DataSource = dtCopy;
                //this.gvSmWantPlanStock.DataSource = dataTable;
                this.gvSmWantPlanStock.DataBind();
            }
        }
        this.hfldResourceIdsZZCL.Value = string.Empty;
    }
    protected void setModelValue(MaterialWantPlanModel modelPlan)
    {
        modelPlan.swid = this.hfldWantPlanGuid.Value;
        modelPlan.swcode = this.txtCode.Text;
        modelPlan.procode = this.hdnProjectCode.Value;
        modelPlan.person = this.txtPerson.Text;
        modelPlan.intime = System.DateTime.Now.ToString();
        modelPlan.explain = this.txtRemark.Text;
        modelPlan.ContainPending = this.chkContainPending.Checked;
        modelPlan.EquipmentId = this.hfldEquId.Value;
        modelPlan.annx = "";
    }
    protected void setControlsValue()
    {
        MaterialWantPlanModel model = this.materialWant.GetModel(this.wantplanCode);
        this.hfldWantPlanGuid.Value = model.swid;
        this.txtCode.Text = model.swcode;
        this.hdnProjectCode.Value = model.procode;
        this.txtPerson.Text = model.person;
        this.txtInputDate.Text = model.intime.Replace("0:00:00", "").Trim();
        this.txtRemark.Text = model.explain;
        this.chkContainPending.Checked = model.ContainPending;
        string equipmentId = model.EquipmentId;
        if (!string.IsNullOrEmpty(equipmentId))
        {
            this.hfldEquId.Value = equipmentId;
            EquEquipmentService equEquipmentService = new EquEquipmentService();
            EquEquipment byId = equEquipmentService.GetById(equipmentId);
            if (byId != null)
            {
                this.txtEquCode.Value = byId.EquCode;
            }
        }
        DataTable dataTable = this.materialStock.showMaterialListForUpdate(this.wantplanCode);
        //this.ViewState["ResourcesTable"] = dataTable;
        DataTable dtCopy = dataTable.Copy();
        try
        {
            
            DataColumn dataColumn1 = new DataColumn();
            dataColumn1.ColumnName = "ResourceQuantity";
            dataColumn1.DataType = System.Type.GetType("System.String");
            dtCopy.Columns.Add(dataColumn1);

            DataColumn dataColumn2 = new DataColumn();
            dataColumn2.ColumnName = "numberIng";
            dataColumn2.DataType = System.Type.GetType("System.String");
            dtCopy.Columns.Add(dataColumn2);
        }
        catch
        {

        }
        //DataTable dt = dtNum();
        foreach (DataRow drc in dtCopy.Rows)
        {
            foreach (DataRow dr in dtNum().Rows)
            {
                if (drc["ResourceCode"].ToString().Trim() == dr["scode"].ToString().Trim())
                {
                    drc["ResourceQuantity"] = dr["ResourceQuantity"];
                    drc["numberIng"] = dr["numberIng"];
                }
            }
        }
        this.ViewState["ResourcesTable"] = dtCopy;
        this.gvSmWantPlanStock.DataSource = dtCopy;
        //this.gvSmWantPlanStock.DataSource = dataTable;
        this.gvSmWantPlanStock.DataBind();
    }
    private bool addMaterialList(SqlTransaction trans, ref string message)
    {
        bool result = true;
        if (this.gvSmWantPlanStock.Rows.Count > 0)
        {
            System.Collections.Generic.List<MaterialPlanStockModel> list = new System.Collections.Generic.List<MaterialPlanStockModel>();
            System.Collections.Generic.Dictionary<string, decimal> dictionary = new System.Collections.Generic.Dictionary<string, decimal>();
            foreach (GridViewRow gridViewRow in this.gvSmWantPlanStock.Rows)
            {
                MaterialPlanStockModel materialPlanStockModel = new MaterialPlanStockModel();
                TextBox textBox = (TextBox)gridViewRow.FindControl("txtNumber");
                Label label = (Label)gridViewRow.FindControl("lblCode");
                Label label2 = (Label)gridViewRow.FindControl("lblDesignCode1");
                TextBox textBox2 = (TextBox)gridViewRow.FindControl("txtarrivalDate");
                TextBox textBox21 = (TextBox)gridViewRow.FindControl("txtarrivalDateNeed");
                TextBox textBox3 = (TextBox)gridViewRow.FindControl("txtRemark");
                materialPlanStockModel.scode = label.Text;
                materialPlanStockModel.wpcode = this.txtCode.Text;
                materialPlanStockModel.number = System.Convert.ToDecimal(textBox.Text);
                if (textBox2.Text.Trim().ToString() != "")
                {
                    materialPlanStockModel.ArrivalDate = textBox2.Text.Trim().ToString();
                }
                if (textBox21.Text.Trim().ToString() != "")
                {
                    materialPlanStockModel.ArrivalDateNeed = textBox21.Text.Trim().ToString();
                }
                materialPlanStockModel.DesignCode = label2.Text.Trim();
                materialPlanStockModel.Remark = textBox3.Text.Trim();
                HiddenField hiddenField = gridViewRow.FindControl("hfldTaskId") as HiddenField;
                if (!string.IsNullOrEmpty(hiddenField.Value.Trim()))
                {
                    materialPlanStockModel.TaskId = hiddenField.Value.Trim();
                }
                else
                {
                    materialPlanStockModel.TaskId = string.Empty;
                }
                list.Add(materialPlanStockModel);
                foreach (string current in dictionary.Keys)
                {
                    if (current == materialPlanStockModel.scode)
                    {
                        decimal dl = dictionary[materialPlanStockModel.scode];
                        dictionary[materialPlanStockModel.scode] = dl + materialPlanStockModel.number;
                    }
                    else
                    {
                        dictionary.Add(materialPlanStockModel.scode, materialPlanStockModel.number);
                    }
                }

            }
            string str1 = StockParameter.ProjectAlarm;
            string str2 = ProjectAlarm.UnAlarm.ToString();
            if (str1 == str2)
            // if (StockParameter.ProjectAlarm == ProjectAlarm.UnAlarm.ToString())
            {
                DataTable dataTable = this.ViewState["MaterialPlanTable"] as DataTable;
                DataTable resourcesTable = this.ViewState["ResourcesTable"] as DataTable;
                if (dataTable != null && dataTable.Rows.Count != 0)
                {
                    foreach (string current in dictionary.Keys)
                    {
                        DataRow[] array = dataTable.Select(string.Format("rCode = '{0}'", current));
                        if (array != null && array.Length != 0)
                        {
                            decimal d = System.Convert.ToDecimal(array[0]["fNumber"]);
                            decimal d2 = System.Convert.ToDecimal(array[0]["aNumber"]);
                            decimal d3 = dictionary[current];
                            if (d < d2 + d3)
                            {
                                message = message + this.getResourcesName(current, resourcesTable) + " 超出预算数量";
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            this.materialStock.Add(trans, list);
        }
        return result;
    }
    private void getMateriaPlanTable()
    {
        DataTable materialPlanInfo = this.materialWant.GetMaterialPlanInfo(this.wantplanCode, this.prjId, this.isWBSRelevance);
        this.ViewState["MaterialPlanTable"] = materialPlanInfo;
    }
    private string getResourcesName(string resourcesCode, DataTable resourcesTable)
    {
        DataRow[] array = resourcesTable.Select(string.Format("ResourceCode={0}", resourcesCode));
        if (array != null && array.Length > 0)
        {
            return array[0]["ResourceName"].ToString();
        }
        return string.Empty;
    }
    protected void delRow()
    {
        DataTable dataTable = (DataTable)this.ViewState["ResourcesTable"];//this.materialStock.showMaterialListForUpdate(this.wantplanCode);//



        ////string a = base.Request.QueryString["optype"];
        //if (base.Request.QueryString["optype"] == "add")
        //{
        //    //this.hfldWantPlanGuid.Value = System.Guid.NewGuid().ToString();
        //    //this.chkContainPending.Checked = StockParameter.IsContainPending;
        //    //this.gvSmWantPlanStock.DataSource = null;
        //    //this.gvSmWantPlanStock.DataBind();
        //}
        //if (base.Request.QueryString["optype"] == "update" || base.Request.QueryString["optype"] == "look")
        //{
        //   // this.setControlsValue();
        //}







        if (this.gvSmWantPlanStock.Rows.Count > 0)
        {
            for (int i = this.gvSmWantPlanStock.Rows.Count - 1; i >= 0; i--)
            {
                GridViewRow gridViewRow = this.gvSmWantPlanStock.Rows[i];
                CheckBox checkBox = (CheckBox)gridViewRow.FindControl("chkBox");
                if (checkBox.Checked)
                {
                    dataTable.Rows.RemoveAt(gridViewRow.RowIndex);
                }
            }
            this.ViewState["ResourcesTable"] = dataTable;

            //DataTable dtCopy = dataTable.Copy();
            //DataColumn dataColumn1 = new DataColumn();
            //dataColumn1.ColumnName = "ResourceQuantity";
            //dataColumn1.DataType = System.Type.GetType("System.String");
            //dtCopy.Columns.Add(dataColumn1);

            //DataColumn dataColumn2 = new DataColumn();
            //dataColumn2.ColumnName = "numberIng";
            //dataColumn2.DataType = System.Type.GetType("System.String");
            //dtCopy.Columns.Add(dataColumn2);
            ////DataTable dt = dtNum();
            //foreach (DataRow drc in dtCopy.Rows)
            //{
            //    foreach (DataRow dr in dtNum().Rows)
            //    {
            //        if (drc["ResourceCode"].ToString().Trim() == dr["scode"].ToString().Trim())
            //        {
            //            drc["ResourceQuantity"] = dr["ResourceQuantity"];
            //            drc["numberIng"] = dr["numberIng"];
            //        }
            //    }
            //}
            //this.gvSmWantPlanStock.DataSource = dtCopy;
            this.gvSmWantPlanStock.DataSource = (DataTable)this.ViewState["ResourcesTable"];
            this.gvSmWantPlanStock.DataBind();
        }
    }
    protected void UpdateSelectResources()
    {
        DataTable dataTable = this.ViewState["ResourcesTable"] as DataTable;
        if (dataTable != null && dataTable.Rows.Count == this.gvSmWantPlanStock.Rows.Count)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                GridViewRow gridViewRow = this.gvSmWantPlanStock.Rows[i];
                TextBox textBox = (TextBox)gridViewRow.FindControl("txtNumber");
                if (textBox != null)
                {
                    dataRow["number"] = textBox.Text.Trim();
                }
                TextBox textBox2 = (TextBox)gridViewRow.FindControl("txtarrivalDate");
                if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    dataRow["arrivalDate"] = textBox2.Text.Trim();
                }
                TextBox textBox21 = (TextBox)gridViewRow.FindControl("txtarrivalDateNeed");
                if (!string.IsNullOrEmpty(textBox21.Text.Trim()))
                {
                    dataRow["arrivalDateNeed"] = textBox21.Text.Trim();
                }
                TextBox textBox3 = (TextBox)gridViewRow.FindControl("txtRemark");
                dataRow["Remark"] = textBox3.Text.Trim();
            }
        }
    }
    private void SetBudFlowState()
    {
        BudTaskChangeService budTaskChangeService = new BudTaskChangeService();
        BudTaskChange byPrj = budTaskChangeService.GetByPrj(this.prjId);
        if (byPrj != null && byPrj.FlowState.HasValue)
        {
            this.hfldBudFlowState.Value = byPrj.FlowState.ToString();
        }
    }
    protected void btnBind_ServerClick(object sender, System.EventArgs e)
    {
        string value = this.HdnViewCodeList.Value.Trim();
        string text = this.hfldResourceIds.Value.Trim();
        string text1 = string.Empty;
        string text2 = string.Empty;
        DataTable dataTable = new DataTable();

        if (text != "")
        {
            this.UpdateSelectResources();
            System.Collections.Generic.List<StockManage_basicset_SmWantPlan.ResInfo> list = JsonConvert.DeserializeObject<System.Collections.Generic.List<StockManage_basicset_SmWantPlan.ResInfo>>(value);
            if (list.Count == 1)
            {
                text1 = "'" + list[0].resId + "'";
                text2 = "'" + list[0].taskId + "'";
                dataTable = this.materialStock.showMaterialListForAdd(text1, this.prjId, text2, list.Count);
            }
            else
            {
                text1 = "'" + list[0].resId + "'";
                text2 = "'" + list[0].taskId + "'";
                dataTable = this.materialStock.showMaterialListForAdd(text1, this.prjId, text2, list.Count);
                DataTable dt2 = new DataTable();

                for (int i = 1; i < list.Count; i++)
                {
                    text1 = "'" + list[i].resId + "'";
                    text2 = "'" + list[i].taskId + "'";
                    dt2 = this.materialStock.showMaterialListForAdd(text1, this.prjId, text2, list.Count);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        //dataTable.Rows.Add(dr2);
                        dataTable.Rows.Add(dr2.ItemArray);
                    }
                    dt2.Clear();
                }
            }

            //         foreach (StockManage_basicset_SmWantPlan.ResInfo current in list)
            //{
            //             text1 = text1 + "'" + current.resId + "',";
            //             text2 = text2 + "'" + current.taskId + "',";
            //         }
            //         text1 = text1.Remove(text1.Length - 1);
            //         text2 = text2.Remove(text2.Length - 1);
            //DataTable dataTable = this.materialStock.showMaterialListForAdd(text1, this.prjId, text2, list.Count);
            DataColumn dataColumn = new DataColumn();
            dataColumn.ColumnName = "TaskName";
            dataColumn.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(dataColumn);
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            foreach (StockManage_basicset_SmWantPlan.ResInfo current2 in list)
            {
                string key = current2.taskId + current2.scode;
                StockManage_basicset_SmWantPlan.ResInfo resInfo = (StockManage_basicset_SmWantPlan.ResInfo)hashtable[key];
                if (resInfo != null)
                {
                    resInfo.quantity += current2.quantity;
                    hashtable.Remove(key);
                    hashtable.Add(key, resInfo);
                }
                else
                {
                    hashtable.Add(key, current2);
                }
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string key2 = dataRow["TaskId"].ToString() + dataRow["ResourceCode"].ToString();
                StockManage_basicset_SmWantPlan.ResInfo resInfo2 = (StockManage_basicset_SmWantPlan.ResInfo)hashtable[key2];
                if (resInfo2 != null)
                {
                    dataRow["Price"] = resInfo2.sprice;
                    dataRow["number"] = resInfo2.quantity;
                    dataRow["TaskId"] = resInfo2.taskId;
                    dataRow["TaskName"] = resInfo2.taskName;
                    dataRow["arrivalDate"] = System.DBNull.Value;
                }
                else
                {
                    dataRow.Delete();
                }
            }
            DataTable dataTable2 = this.ViewState["ResourcesTable"] as DataTable;
            if (dataTable2 == null)
            {
                this.ViewState["ResourcesTable"] = dataTable;
            }
            else
            {
                if (dataTable2 != null)
                {
                    dataTable2.PrimaryKey = new DataColumn[]
                    {
                        dataTable2.Columns["ResourceCode"],
                        dataTable2.Columns["TaskId"]
                    };
                    dataTable.PrimaryKey = new DataColumn[]
                    {
                        dataTable.Columns["ResourceCode"],
                        dataTable.Columns["TaskId"]
                    };
                    dataTable2.Merge(dataTable, true);
                    dataTable = dataTable2;
                }
            }
            this.ViewState["ResourcesTable"] = dataTable;
            DataTable dtCopy = dataTable.Copy();
            try
            {
                
                DataColumn dataColumn1 = new DataColumn();
                dataColumn1.ColumnName = "ResourceQuantity";
                dataColumn1.DataType = System.Type.GetType("System.String");
                dtCopy.Columns.Add(dataColumn1);

                DataColumn dataColumn2 = new DataColumn();
                dataColumn2.ColumnName = "numberIng";
                dataColumn2.DataType = System.Type.GetType("System.String");
                dtCopy.Columns.Add(dataColumn2);
            }
            catch
            {

            }

            //DataTable dt = dtNum();
            foreach (DataRow drc in dtCopy.Rows)
            {
                foreach (DataRow dr in dtNum().Rows)
                {
                    if (drc["ResourceCode"].ToString().Trim() == dr["scode"].ToString().Trim() && drc["TaskId"].ToString().Trim() == dr["TaskId"].ToString().Trim())
                    {
                        drc["ResourceQuantity"] = dr["ResourceQuantity"].ToString().Trim();
                        drc["numberIng"] = dr["numberIng"].ToString().Trim();
                        try
                        {
                            if (drc["number"].ToString().Trim() == dr["ResourceQuantity"].ToString().Trim())
                            {
                                drc["number"] = Convert.ToString(Convert.ToDouble(dr["ResourceQuantity"].ToString().Trim()) - Convert.ToDouble(dr["numberIng"].ToString().Trim()));
                            }
                            else
                            {

                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            this.ViewState["ResourcesTable"] = dtCopy;
            this.gvSmWantPlanStock.DataSource = dtCopy;
            this.gvSmWantPlanStock.DataBind();
        }
    }

    public DataTable dtNum()
    {
        string strSql = string.Format(
            @"
            -----------------获取 物资需求计划的 需求数量和在途数量(除了审批驳回状态外的已提交的物资需求计划数量)-------------------------
            SELECT t.TaskId, t.TaskName,t.ResourceId,t.ResourceCode scode,t.ResourceQuantity,w.numberIng--,sws.number--sum(sws.number) numberIng-- ,sws.wpcode
            FROM (SELECT  PrjGuid,TaskId,ResourceId,TaskName,ResourceCode,sum(ResourceQuantity) ResourceQuantity FROM (
			SELECT btr.PrjGuid,btr.TaskId,btr.ResourceId,bt.TaskName,rs.ResourceCode,btr.ResourceQuantity 
            FROM Bud_TaskResource btr 
            LEFT JOIN Res_Resource rs on btr.ResourceId=rs.ResourceId 
            LEFT JOIN Bud_Task bt on btr.TaskId=bt.TaskId
            where btr.PrjGuid='{0}' 
			UNION ALL SELECT  bm.PrjId,bmt.TaskId,bmts.ResourceId,bt.TaskName,rs.ResourceCode,bmts.ResourceQuantity FROM Bud_ModifyTaskRes bmts 
			LEFT JOIN Bud_ModifyTask bmt ON bmts.ModifyTaskId=bmt.ModifyTaskId 
			LEFT JOIN Bud_Modify bm ON bmt.ModifyId=bm.ModifyId 
			LEFT JOIN Bud_Task bt on bmt.TaskId=bt.TaskId 
			LEFT JOIN Res_Resource rs on bmts.ResourceId=rs.ResourceId 
			WHERE bm.flowstate !=-2 and bm.PrjId='{0}' ) s
			GROUP BY PrjGuid,TaskId,ResourceId,TaskName,ResourceCode )t 
			LEFT JOIN 
            ( SELECT sws.scode,sws.TaskId,sum(sws.number) numberIng from Sm_Wantplan_Stock sws --sw.flowstate,sw.swcode,
			LEFT JOIN  Sm_Wantplan sw ON sws.wpcode=sw.swcode 
			WHERE sw.flowstate !=-2 and sw.swcode !='{1}' 
			GROUP BY sws.scode,sws.TaskId ) w ON w.scode=t.ResourceCode AND w.TaskId=t.TaskId
            ORDER BY t.ResourceCode;
            -------------------------------------------------------------------------------------------------------------------------------
            ", prjId, wantplanCode);
        DataTable dt = publicDbOpClass.DataTableQuary(strSql);
        if (dt.Rows.Count>0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (string.IsNullOrEmpty(dr["numberIng"].ToString()))
                {
                    dr["numberIng"] = "0.00";
                }
            }
        }
       
        return dt;
    }
}


