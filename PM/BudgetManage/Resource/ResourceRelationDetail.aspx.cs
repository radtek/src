using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain;
using cn.justwin.Domain.Services;
using com.jwsoft.pm.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class ResourceRelationDetail : NBasePage, IRequiresSessionState
{
    public static cn.justwin.BLL.Resource resource = new cn.justwin.BLL.Resource();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindGv();
        }

        // 

        //base.RegisterScript("alert('系统提示：\\n\\n该资源已经使用，不能删除！');");

        if (!string.IsNullOrEmpty(base.Request["id"].ToString()))
        {
            DataTable dt = publicDbOpClass.DataTableQuary("select * from Sm_Wantplan_Stock WHERE scode in (select ResourceCode from Res_Resource where ResourceId='" + base.Request["id"].ToString() + "')");
            if (dt.Rows.Count > 0)
            {
                btnEdit.Visible = false;
                selectResource.Visible = false;
                selectResource4.Visible = false;
                btnDel.Visible = false;
                Label1.Text = "该组装材料已经在物资需求计划中被使用，不能编辑！";
            }
            else
            {
                btnEdit.Visible = true;
                selectResource4.Visible = true;
                selectResource.Visible = true;
                btnDel.Visible = true;
                Label1.Text = "";
            }
        }
        else
        {
            btnEdit.Visible = false;
            selectResource4.Visible = false;
            selectResource.Visible = false;
            btnDel.Visible = false;
        }
    }
    public void BindGv()
    {
        if (!string.IsNullOrEmpty(base.Request["id"].ToString()))
        {
            string strWhere = "AND r.ResourceId IN ( select CID from Res_ResourceRelation where FID='" + base.Request["id"].ToString() + "')";
            //string strWhere = " AND r.ResourceId IN ('067ef1eb-3386-4a00-8133-d33154337057','0842da52-2cf1-40ba-86e4-058a1e8fc16d')";
            cn.justwin.BLL.Resource resource = new cn.justwin.BLL.Resource();
            DataTable table = resource.Query(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, strWhere, "");//string condition, string priceTypeCondition);
            System.Collections.Generic.IList<PriceType> priceTypes = PriceType.GetPriceTypes(base.UserCode);
            if (this.gvResource.Columns.Count < 14 + priceTypes.Count)
            {
                int num = 9;
                foreach (PriceType current in priceTypes)
                {
                    BoundField boundField = new BoundField();
                    boundField.DataField = current.PriceTypeName;
                    boundField.HeaderText = current.PriceTypeName;
                    this.gvResource.Columns.Insert(num++, boundField);
                }
            }
            //table.Columns.Remove("采购价");
            //table.Columns.Remove("目标成本价");
            //table.Columns.Remove("最后采购价");

            table.Columns.Add("NUM");
            foreach (DataRow dr in table.Rows)
            {
                DataTable dt = publicDbOpClass.DataTableQuary("select NUM from Res_ResourceRelation where CID ='" + dr["ResourceId"].ToString() + "' and FID='" + base.Request["id"].ToString() + "'");
                if (dt.Rows.Count == 1)
                {
                    dr["NUM"] = dt.Rows[0]["NUM"];
                }
                else
                {
                    dr["NUM"] = "0";
                }
            }
            this.gvResource.DataSource = table;
            this.gvResource.DataBind();
        }
        else
        {
            this.gvResource.DataSource = null;
            this.gvResource.DataBind();
        }
    }


    protected void btnDel_Click(object sender, System.EventArgs e)
    {
        string[] strs = this.hfldPurchaseChecked.Value.Split(',');
        string stra = string.Empty;
        if (strs.Length > 1)
        {
            stra = this.hfldPurchaseChecked.Value.Replace("[", "").Replace("]", "").Replace("\"", "'");
        }
        else
        {
            stra = "'" + this.hfldPurchaseChecked.Value + "'";
        }
        string strSql0 = "DELETE from Res_ResourceRelation where FID='" + base.Request["id"].ToString() + "' and CID IN (" + stra + ")";
        using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql0);
                sqlTransaction.Commit();
                base.RegisterScript("window.location.href = window.location.href");
            }
            catch
            {
                sqlTransaction.Rollback();
                base.RegisterScript("alert('系统提示：\\n\\删除失败！');");
            }
        }
        //new EquEquipmentService();
        //System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
        //if (this.hfldPurchaseChecked.Value.Contains("["))
        //{
        //    list = JsonHelper.GetListFromJson(this.hfldPurchaseChecked.Value);
        //}
        //else
        //{
        //    list.Add(this.hfldPurchaseChecked.Value);
        //}
        //using (pm2Entities pm2Entities = new pm2Entities())
        //{
        //    foreach (string id in list)
        //    {
        //        try
        //        {
        //            IQueryable<Res_Price> queryable =
        //                from p in pm2Entities.Res_Price
        //                where p.ResourceId == id
        //                select p;
        //            foreach (Res_Price current in queryable)
        //            {
        //                pm2Entities.DeleteObject(current);
        //            }
        //            Res_Resource res_Resource = (
        //                from r in pm2Entities.Res_Resource
        //                where r.ResourceId == id
        //                select r).FirstOrDefault<Res_Resource>();
        //            if (res_Resource != null)
        //            {
        //                pm2Entities.DeleteObject(res_Resource);
        //            }
        //            pm2Entities.SaveChanges();
        //            base.RegisterScriptRefresh();
        //        }
        //        catch
        //        {
        //            base.RegisterScript("alert('系统提示：\\n\\n该资源已经使用，不能删除！');");
        //        }
        //    }
        //}
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {
        this.BindGv();
    }
    protected void gvPurchaseplan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            try
            {
                e.Row.Attributes["id"] = this.gvResource.DataKeys[e.Row.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }
    }
    protected void TreeView_SelectedNodeChanged(object sender, System.EventArgs e)
    {
        this.BindGv();
        //this.hdParentId.Value = this.tvResource.SelectedValue;
    }
    protected void btnBindResource_Click(object sender, System.EventArgs e)
    {
        //this.InitResource(this.hfldResourceId.Value);
        string strS = Info(this.hfldResourceId.Value);
        if (!string.IsNullOrEmpty(strS))
        {
            //string strSql0 = "DELETE from Res_ResourceRelation where FID='" + this.tvResource.SelectedValue + "'";
            string strSql1 = @"INSERT INTO [Res_ResourceRelation]
                               ([ID]
                               ,[FID]
                               ,[CID]
                                ,[NUM]
		                       )
                                VALUES" + strS;
            using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                try
                {
                    //SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql0);
                    SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql1);
                    sqlTransaction.Commit();
                    base.RegisterScript("window.location.href = window.location.href");
                    //base.RegisterScript("top.ui.tabSuccess({parentName:'_Task'});");
                }
                catch
                {
                    sqlTransaction.Rollback();
                    base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
                }
            }
        }
        else
        {

        }

    }
    private string Info(string Ids)
    {
        string strs = string.Empty;
        if (!string.IsNullOrEmpty(Ids))
        {
            string[] stra = Ids.Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
            foreach (string str in stra)
            {
                DataTable dt = publicDbOpClass.DataTableQuary("select CID from Res_ResourceRelation where FID='" + str + "'");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        strs += string.Format(@"(
             '{0}'
           , '{1}'
           , '{2}'
,1
		   ),", Guid.NewGuid().ToString(), base.Request["id"].ToString(), dr["CID"].ToString().Trim());
                    }
                }
                else
                {
                    strs += string.Format(@"(
             '{0}'
           , '{1}'
           , '{2}'
,1
		   ),", Guid.NewGuid().ToString(), base.Request["id"].ToString(), str.ToString().Trim());
                }

            }
            return strs.Substring(0, strs.Length - 1) + ";";
        }
        else
        {
            return null;
        }

    }

    protected void btnSaveNUM_Click(object sender, EventArgs e)
    {
        string strFID = base.Request["id"].ToString();
        string strCID = CID.Value;
        string strNUM = NUM.Value;
        try
        {
            int iNUM = Convert.ToInt32(strNUM);
            if (iNUM > 0)
            {

                string strSql = "update Res_ResourceRelation set NUM=" + iNUM + " where CID='" + strCID + "' and FID='" + strFID + "'";
                using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
                {
                    sqlConnection.Open();
                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                    try
                    {
                        SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSql);
                        sqlTransaction.Commit();
                        base.RegisterScript("window.location.href = window.location.href");
                        //base.RegisterScript("top.ui.tabSuccess({parentName:'_Task'});");
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
                        base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
                    }
                }
            }
            else
            {
                base.RegisterScript("alert('系统提示：\\n\\请检查填写的数据,请填写非负数！');window.location.href = window.location.href");
            }
        }
        catch
        {
            base.RegisterScript("alert('系统提示：\\n\\请检查填写的数据,请填写非负数！');window.location.href = window.location.href");
        }
        //if (this.gvResource.Rows.Count > 0)
        //{
        //    foreach (GridViewRow gridViewRow in this.gvResource.Rows)
        //    {
        //        TextBox textBox = (TextBox)gridViewRow.FindControl("txtNumber");
        //        Label label = (Label)gridViewRow.FindControl("lblCode");
        //        string strNUM = textBox.Text;
        //        string strCID = label.Text;

        //    }
        //}
    }
}


