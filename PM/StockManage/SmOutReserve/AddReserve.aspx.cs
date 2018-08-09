using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.Serialize;
using cn.justwin.stockBLL;
using cn.justwin.stockDAL;
using cn.justwin.stockModel;
using com.jwsoft.pm.data;
using com.jwsoft.pm.entpm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class StockManage_SmOutReserve_AddReserve : NBasePage, IRequiresSessionState
{
    private PTPrjInfoBll pTPrjInfoBll = new PTPrjInfoBll();
    private TreasuryStockBll treasuryStockBll = new TreasuryStockBll();
    private cn.justwin.stockBLL.Treasury treasury = new cn.justwin.stockBLL.Treasury();
    private OutReserveBll outReserveBll = new OutReserveBll();
    private OutStockBll outStockBll = new OutStockBll();
    private string prjId = string.Empty;

    protected override void OnInit(EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request["prjId"]))
        {
            this.prjId = base.Request["prjId"].ToString();
            this.hfldPrjId.Value = base.Request["prjId"].ToString();
        }
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtTrea.Attributes.Add("ReadOnly", "true");
        this.txtEquCode.Attributes.Add("ReadOnly", "true");
        if (!base.IsPostBack)
        {
            this.InitPage();
        }
    }
    public void InitPage()
    {
        if (base.Request.QueryString["t"] != null)
        {
            this.btnDel.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnSelectByd.Disabled = true;
        }
        if (base.Request.QueryString["id"] != null)
        {
            this.lblTitle.Text = "编辑出库单";
            OutReserveModel model = this.outReserveBll.GetModel(base.Request.QueryString["id"]);
            this.hdTsid.Value = "1";
            this.txtExplain.Text = model.explain;
            this.txtInTime.Text = model.intime.ToString();
            this.txtPeople.Value = model.person;
            this.txtPPCode.Text = model.orcode;
            this.txtPickingPeople.Text = model.PickingPeople;
            this.txtPickingSector.Text = model.PickingSector;
            this.txtProjectName.Value = this.pTPrjInfoBll.GetModelByPrjGuid(model.procode).PrjName;
            this.hdGuid.Value = model.orid;
            this.hdflowstate.Value = model.flowstate.ToString();
            this.hfldTrea.Value = model.tcode;
            this.txtTrea.Text = this.treasury.GetModel(model.tcode).tname;
            string equipmentId = model.EquipmentId;
            if (!string.IsNullOrEmpty(equipmentId))
            {
                this.hfldEquId.Value = equipmentId;
                EquEquipmentService equEquipmentService = new EquEquipmentService();
                EquEquipment byId = equEquipmentService.GetById(equipmentId);
                if (byId != null)
                {
                    this.txtEquCode.Text = byId.EquCode;
                }
            }
            List<OutStockModel> listArray = this.outStockBll.GetListArray(" where orcode='" + model.orcode + "'");
            string text = "";
            foreach (OutStockModel current in listArray)
            {
                text = text + "'" + current.scode + "',";
            }
            if (text != "")
            {
                text = text.Substring(0, text.Length - 1);
            }
            this.ViewState["DataTable"] = this.outStockBll.GetTableByOrcode(model.orcode, model.tcode);
            this.BindGv();
        }
        else
        {
            this.lblTitle.Text = "新增出库单";
            this.txtProjectName.Value = this.pTPrjInfoBll.GetModelByPrjGuid(this.prjId).PrjName;
            this.txtPPCode.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.txtInTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.hdGuid.Value = Guid.NewGuid().ToString();
            this.txtPeople.Value = PageHelper.QueryUser(this, base.UserCode);
            this.ViewState["DataTable"] = this.outStockBll.GetTableByOrcode("''", "");
            this.BindGv();
        }
        this.FileLink1.MID = 1804;
        this.FileLink1.FID = this.hdGuid.Value;
        this.FileLink1.Type = 1;
    }
    public string GetNumByScodeAndOrcode(string scode)
    {
        OutStockModel modelByWhere = this.outStockBll.GetModelByWhere(string.Concat(new string[]
        {
            " where orcode='",
            this.txtPPCode.Text,
            "' and scode='",
            scode,
            "'"
        }));
        if (modelByWhere != null)
        {
            return modelByWhere.number.ToString();
        }
        return string.Concat(0);
    }
    //public DataTable GetTable()
    //{
    //    DataTable dt = 
    //    return dt;
    //}


    public DataTable GetTable2()
    {
        //DataTable dtA = this.treasuryStockBll.GetListByTsid(this.hdTsid.Value, this.hfldTrea.Value);//获取仓库数据
        DataTable dtA = GetListByTsid(this.hdTsid.Value, this.hfldTrea.Value);//获取仓库数据
        DataTable dtB = getResources(hfldResourceIdsZZCL.Value);//获取组装材料数据
        //hfldResourceIdsZZCL.Value = "";
        //hdTsid.Value = "";
        if (dtA != null && dtB != null)
        {
            dtB.Columns.Remove("ResourceId");
            dtB.AcceptChanges();
            foreach (DataRow dra in dtA.Rows)
            {
                //foreach (DataRow drb in dtB.Rows)
                for (int ii = dtB.Rows.Count - 1; ii >= 0; ii--)
                {
                    if (dra["scode"].ToString() == dtB.Rows[ii]["scode"].ToString())
                    {
                        double iia = 0.00;
                        double iib = 0.00;
                        double iis = 0.00;
                        try
                        {
                            iia = Convert.ToDouble(dra["number"].ToString().Trim());
                        }
                        catch
                        {
                            iia = 0.00;
                        }
                        try
                        {
                            iib = Convert.ToDouble(dtB.Rows[ii]["number"].ToString().Trim());
                        }
                        catch
                        {
                            iib = 0.00;
                        }
                        try
                        {
                            iis = Convert.ToDouble(dtB.Rows[ii]["snumber"].ToString().Trim());
                        }
                        catch
                        {
                            iis = 0.00;
                        }
                        double db = iia + iib;
                        if (db < iis)
                        {
                            dra["number"] = db;
                        }
                        else
                        {
                            dra["number"] = iis;
                        }
                        dtB.Rows.Remove(dtB.Rows[ii]);
                        dtB.AcceptChanges();
                    }
                    else
                    {

                    }
                }
            }

            DataTable newDataTable = dtA.Clone();

            object[] obj = new object[newDataTable.Columns.Count];

            for (int i = 0; i < dtA.Rows.Count; i++)
            {
                dtA.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }

            for (int i = 0; i < dtB.Rows.Count; i++)
            {
                dtB.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }
            return newDataTable;
        }
        else if (dtA != null && dtB == null)
        {
            return dtA;
        }
        else if (dtA == null && dtB != null)
        {
            dtB.Columns.Remove("ResourceId");
            dtB.AcceptChanges();
            return dtB;
        }
        else
        {
            return null;
        }
    }

    private TreasuryStock treasuryStock2 = new TreasuryStock();
    public DataTable GetListByTsid(string tsid, string tcode)
    {
        string str = "''";
        if (!string.IsNullOrEmpty(tsid))
        {
            str = "";
            foreach (string str2 in JsonHelper.GetListFromJson(tsid))
            {
                string[] strArray = str2.Split(new char[] { '|' });
                str = str + treasuryStock2.GetTsidBySSc(strArray[0], strArray[1], strArray[2], tcode);
            }
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
            }
        }
        return this.GetListByTsid(str);
    }
    private DataTable GetList(string ids)
    {
        string strIDs = string.Empty;
        //DataTable dataTable = null;
        //["4b0ae68c-ff0b-403c-bcd5-39a0d07a7ee0|000400002|99","82eddac8-0546-447f-b96b-eacd75d7d9f1|000400001|66"]
        if (!string.IsNullOrEmpty(ids))
        {
            //b89b1b0c - 6d3b - 4b37 - a5f1 - eafdd81f0acb | 000400005 | 1,a7ca9325 - 91dd - 4026 - 9dd6 - fbd4482c81a8 | 000400002 | 1,563c0bc1 - f223 - 4db9 - 928d - 2177e1d1e0c0 | 000400004 | 1
            ISerializable serializable = new cn.justwin.Serialize.JsonSerializer();
            string[] array = serializable.Deserialize<string[]>(ids);
            //string[] array = strIDs.Split(','); ;
            //4b0ae68c - ff0b - 403c - bcd5 - 39a0d07a7ee0 | 000400002 | 99
            //82eddac8 - 0546 - 447f - b96b - eacd75d7d9f1 | 000400001 | 66
            //string[] array2 = null;
            if (array != null)
            {
                //string strIDS = string.Empty;
                foreach (string str2 in array)
                {
                    strIDs += "'" + str2.Split('|')[0].ToString().Trim() + "',";
                }
                strIDs = strIDs.Substring(0, strIDs.Length - 1);
            }
            else
            {
                strIDs = "''";
            }
            string strSQLA = string.Format(@"--with t as (select FID,CID,NUM NUM from Res_ResourceRelation where FID in ({0})) 
                                        select distinct p1.ResourceId, 0.000 NUM,0.000 as number,p1.ResourceCode scode,0.000 sprice,0.000 Total, 
                                        '' CorpId ,'' Corp,0.000 snumber,p1.ResourceName,p1.Specification,p4.Name 
                                        ,p1.Brand,ModelNumber,TechnicalParameter   
                                        from dbo.Res_Resource as p1  
                                        left join Res_Unit as p4 on p1.Unit=p4.UnitID
                                        --left join  t on t.CID=p1.ResourceId 
                                        left join  Sm_Treasury_Stock s on s.scode= p1.ResourceCode
                                        WHERE 1 = 1  and p1.ResourceId in(
                                        select CID from Res_ResourceRelation where FID in ({0})) order by scode asc", strIDs);
            DataTable dtA = publicDbOpClass.DataTableQuary(strSQLA);
            //-----------------------------------------------------------------
            string strSQLB = "select FID,CID,NUM from Res_ResourceRelation where FID in (" + strIDs + ")";
            DataTable dtB = publicDbOpClass.DataTableQuary(strSQLB);
            if (dtB != null && dtB.Rows.Count > 0)
            {
                foreach (DataRow dr in dtB.Rows)
                {
                    foreach (string str in array)
                    {
                        string strID = str.Split('|')[0].ToString();
                        string strNUM = str.Split('|')[2].ToString();
                        if (dr["FID"].ToString() == strID)
                        {
                            try
                            {
                                dr["NUM"] = Convert.ToString(Convert.ToDouble(dr["NUM"].ToString().Trim()) * Convert.ToDouble(strNUM));
                            }
                            catch
                            {

                            }

                        }
                    }
                }
            }


            if (dtA != null && dtA.Rows.Count > 0 && dtB != null && dtB.Rows.Count > 0)
            {
                foreach (DataRow drA in dtA.Rows)
                {
                    foreach (DataRow drB in dtB.Rows)
                    {
                        string number = drA["NUM"].ToString();
                        string ResourceId = drA["ResourceId"].ToString();

                        string NUM = drB["NUM"].ToString();
                        string CID = drB["CID"].ToString();
                        if (ResourceId == CID)
                        {
                            try
                            {
                                double db = Convert.ToDouble(drA["NUM"].ToString());
                                db += Convert.ToDouble(NUM);
                                drA["NUM"] = db.ToString();
                            }
                            catch
                            {

                            }

                        }
                    }
                }
            }
            return dtA;
        }
        else
        {
            return null;
        }
    }




    //if (dt.Rows.Count > 0)
    //{
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        foreach (string str3 in array)
    //        {
    //            string strID = str3.Split('|')[0].ToString();
    //            string strNUM = str3.Split('|')[2].ToString();
    //            if (dr["FID"].ToString() == strID)
    //            {
    //                try
    //                {
    //                    dr["NUM"] = Convert.ToString(Convert.ToDouble(dr["NUM"].ToString().Trim()) * Convert.ToDouble(strNUM));
    //                }
    //                catch
    //                {

    //                }

    //            }
    //        }
    //    }
    //}
    //return dt;
    //}

    private DataTable GetList(string tsid, string tcode, string ids)
    {
        string str = "''";
        if (!string.IsNullOrEmpty(tsid))
        {
            str = "";
            foreach (string str2 in JsonHelper.GetListFromJson(tsid))
            {
                string[] strArray = str2.Split(new char[] { '|' });
                str = str + treasuryStock2.GetTsidBySSc(strArray[0], strArray[1], strArray[2], tcode);
            }
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
            }
        }
        else
        {
            str = "''";
        }
        string strIDs = string.Empty;
        //DataTable dataTable = null;
        //["4b0ae68c-ff0b-403c-bcd5-39a0d07a7ee0|000400002|99","82eddac8-0546-447f-b96b-eacd75d7d9f1|000400001|66"]
        if (!string.IsNullOrEmpty(ids))
        {
            //b89b1b0c - 6d3b - 4b37 - a5f1 - eafdd81f0acb | 000400005 | 1,a7ca9325 - 91dd - 4026 - 9dd6 - fbd4482c81a8 | 000400002 | 1,563c0bc1 - f223 - 4db9 - 928d - 2177e1d1e0c0 | 000400004 | 1
            ISerializable serializable = new cn.justwin.Serialize.JsonSerializer();
            string[] array = serializable.Deserialize<string[]>(ids);
            //string[] array = strIDs.Split(','); ;
            //4b0ae68c - ff0b - 403c - bcd5 - 39a0d07a7ee0 | 000400002 | 99
            //82eddac8 - 0546 - 447f - b96b - eacd75d7d9f1 | 000400001 | 66
            //string[] array2 = null;
            if (array != null)
            {
                //string strIDS = string.Empty;
                foreach (string str2 in array)
                {
                    strIDs += "'" + str2.Split('|')[0].ToString().Trim() + "',";
                }
                strIDs = strIDs.Substring(0, strIDs.Length - 1);
            }
            else
            {
                strIDs = "''";
            }

        }
        else
        {
            strIDs = "''";
        }
        string strXQID = "";
        DataTable dtTemp = BindNeedNote();
        if (dtTemp != null && dtTemp.Rows.Count > 0)
        {
            foreach (DataRow dr in dtTemp.Rows)
            {
                strXQID += "'" + dr["scode"].ToString() + "',";
            }
            strXQID = strXQID.Substring(0, strXQID.Length - 1);
        }else
        {
            strXQID = "''";
        }
        // string strSQL = "select FID,CID,NUM from Res_ResourceRelation where FID in (" + strIDS.Substring(0, strIDS.Length - 1) + ")";


        //  string strSQL1 = string.Format(@"--with t as 
        //                         select distinct --s.tsid,s.scode,s.snumber,t.NUM,p1.ResourceId,
        //                               0.000 as number,p1.ResourceCode scode,s.sprice sprice,(0*s.sprice) Total, 
        //                          ISNULL(s.Corp,'') as CorpId ,p5.corpName Corp,s.snumber snumber,p1.ResourceName,p1.Specification,p4.Name 
        //                              ,p1.Brand,ModelNumber,TechnicalParameter   
        //                             from dbo.Res_Resource as p1  
        //                              left join Res_Unit as p4 on p1.Unit=p4.UnitID
        //left join (select FID,CID,NUM NUM from Res_ResourceRelation where FID in ({0})) t on t.CID=p1.ResourceId 
        //right join  Sm_Treasury_Stock s on s.scode= p1.ResourceCode 
        //left join dbo.XPM_Basic_ContactCorp as p5 on ISNULL(s.corp,'') = p5.CorpId   
        //                              WHERE 1 = 1 and  ((s.tcode= '{1}' and p1.ResourceId in(
        //select CID from Res_ResourceRelation where FID in ({0}))) 
        //or (s.tsid in({2}))) order by scode asc; ", strIDs, tcode, str);
        string strSQL = string.Format(@"SELECT number,scode,sprice,Total,CorpId,Corp,SUM(snumber) snumber,ResourceName,Specification,Name,Brand,ModelNumber,TechnicalParameter from (
		                                 select distinct --s.tsid,s.scode,s.snumber,t.NUM,p1.ResourceId,
                                         0.000 as number,p1.ResourceCode scode,s.sprice sprice,(0*s.sprice) Total, 
                                    ISNULL(s.Corp,'') as CorpId ,p5.corpName Corp,s.snumber snumber,p1.ResourceName,p1.Specification,p4.Name 
                                        ,p1.Brand,ModelNumber,TechnicalParameter   
                                       from dbo.Res_Resource as p1  
                                        left join Res_Unit as p4 on p1.Unit=p4.UnitID
										left join  (select FID,CID,NUM NUM from Res_ResourceRelation where FID in ({0})) t  on t.CID=p1.ResourceId 
										right join  Sm_Treasury_Stock s on s.scode= p1.ResourceCode 
										left join dbo.XPM_Basic_ContactCorp as p5 on ISNULL(s.corp,'') = p5.CorpId   
                                        WHERE 1 = 1 and  ((s.tcode= '{1}' and (p1.ResourceId in(
										select CID from Res_ResourceRelation where FID in ({0})) or p1.ResourceCode in({3}))
                                        ) or (s.tsid in({2}))) ) t 
										GROUP BY number,scode,sprice,Total,CorpId,Corp,ResourceName,Specification,Name,Brand,ModelNumber,TechnicalParameter
										order by scode asc; ", strIDs, tcode, str, strXQID);
        DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
        return dt;
        #region 
        //if (dt.Rows.Count > 0)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        foreach (string str3 in array)
        //        {
        //            string strID = str3.Split('|')[0].ToString();
        //            string strNUM = str3.Split('|')[2].ToString();
        //            if (dr["ResourceId"].ToString() == strID)
        //            {
        //                try
        //                {
        //                    dr["NUM"] = Convert.ToString(Convert.ToDouble(dr["NUM"].ToString().Trim()) * Convert.ToDouble(strNUM));
        //                }
        //                catch
        //                {

        //                }

        //            }
        //        }
        //    }
        //}





        // return publicDbOpClass.DataTableQuary(strSQL);

        //string strIDs = ids;
        //DataTable dataTable = null;
        ////["4b0ae68c-ff0b-403c-bcd5-39a0d07a7ee0|000400002|99","82eddac8-0546-447f-b96b-eacd75d7d9f1|000400001|66"]
        //if (!string.IsNullOrEmpty(strIDs))
        //{
        //    //b89b1b0c - 6d3b - 4b37 - a5f1 - eafdd81f0acb | 000400005 | 1,a7ca9325 - 91dd - 4026 - 9dd6 - fbd4482c81a8 | 000400002 | 1,563c0bc1 - f223 - 4db9 - 928d - 2177e1d1e0c0 | 000400004 | 1
        //    ISerializable serializable = new cn.justwin.Serialize.JsonSerializer();
        //    string[] array = serializable.Deserialize<string[]>(strIDs);
        //    //string[] array = strIDs.Split(','); ;
        //    //4b0ae68c - ff0b - 403c - bcd5 - 39a0d07a7ee0 | 000400002 | 99
        //    //82eddac8 - 0546 - 447f - b96b - eacd75d7d9f1 | 000400001 | 66
        //    string[] array2 = null;
        //    if (array != null)
        //    {
        //        string strIDS = string.Empty;
        //        foreach (string str in array)
        //        {
        //            strIDS += "'" + str.Split('|')[0].ToString().Trim() + "',";
        //        }
        //        string strSQL = "select FID,CID,NUM from Res_ResourceRelation where FID in (" + strIDS.Substring(0, strIDS.Length - 1) + ")";
        //        DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                foreach (string str in array)
        //                {
        //                    string strID = str.Split('|')[0].ToString();
        //                    string strNUM = str.Split('|')[2].ToString();
        //                    if (dr["FID"].ToString() == strID)
        //                    {
        //                        try
        //                        {
        //                            dr["NUM"] = Convert.ToString(Convert.ToDouble(dr["NUM"].ToString().Trim()) * Convert.ToDouble(strNUM));
        //                        }
        //                        catch
        //                        {

        //                        }

        //                    }
        //                }
        //            }

        //            array2 = new string[dt.Rows.Count];
        //            int ii = 0;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                array2[ii] = dr["CID"].ToString().Trim();
        //                ii++;
        //            }
        //            string str2 = "select CID from Res_ResourceRelation where FID in (" + strIDS.Substring(0, strIDS.Length - 1) + ")";
        //            string strSql2 = @"select distinct p1.ResourceId, 0.000 as number,p1.ResourceCode scode,0.000 sprice,0.000 Total, 
        //                                '' CorpId ,'' Corp,0.000 snumber,p1.ResourceName,p1.Specification,p4.Name 
        //                                ,p1.Brand,ModelNumber,TechnicalParameter   
        //                                from dbo.Res_Resource as p1  
        //                                left join Res_Unit as p4 on p1.Unit=p4.UnitID
        //                                WHERE 1 = 1 and p1.ResourceId in(" + str2 + ")";
        //            dataTable = publicDbOpClass.DataTableQuary(strSql2);

        //            if (dt != null && dt.Rows.Count > 0 && dataTable != null && dataTable.Rows.Count > 0)
        //            {
        //                foreach (DataRow drA in dataTable.Rows)
        //                {
        //                    foreach (DataRow drB in dt.Rows)
        //                    {
        //                        string number = drA["number"].ToString();
        //                        string ResourceId = drA["ResourceId"].ToString();

        //                        string NUM = drB["NUM"].ToString();
        //                        string CID = drB["CID"].ToString();
        //                        if (ResourceId == CID)
        //                        {
        //                            try
        //                            {
        //                                double db = Convert.ToDouble(drA["number"].ToString());
        //                                db += Convert.ToDouble(NUM);
        //                                drA["number"] = db.ToString();
        //                            }
        //                            catch
        //                            {

        //                            }

        //                        }
        //                    }
        //                }
        //            }

        //        }
        //    }

        //}

        //return null;
        #endregion
    }


    public DataTable GetListByTsid(string tsid)
    {
        if (string.IsNullOrEmpty(tsid))
        {
            tsid = "''";
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("select distinct 0.000 as number,p2.scode,p2.sprice,(0*p2.sprice) Total, \n");
        builder.Append("\tISNULL(p2.Corp,'') as CorpId ,p5.corpName as Corp,p0.snumber,p1.ResourceName,p1.Specification,p4.Name \n");
        builder.Append(",p1.Brand,ModelNumber,TechnicalParameter   \n");
        builder.Append("from dbo.Res_Resource as p1  \n");
        builder.Append("left join dbo.Sm_Treasury_Stock as p2 on p1.resourceCode=p2.scode  \n");
        builder.Append("left join Res_Unit as p4 on p1.Unit=p4.UnitID   \n");
        builder.Append("join (select scode,sum(snumber) as snumber,sprice,ISNULL(corp,'') corp   \n");
        builder.Append("\t  from ( select p2.*,p1.ResourceName,p1.Specification,p4.Name  \n");
        builder.Append("\t\t\t from dbo.Res_Resource as p1  \n");
        builder.Append("\t\t\t left join dbo.Sm_Treasury_Stock as p2 on p1.resourceCode=p2.scode  \n");
        builder.Append("\t\t\t left join Res_Unit as p4 on p1.Unit=p4.UnitID  \n");
        builder.Append("\t\t\t where p2.tsid in(" + tsid + ") ) a \n");
        builder.Append("\t  group by scode,sprice,Corp) as p0  \n");
        builder.Append("\ton p2.scode=p0.scode and p2.sprice=p0.sprice and ISNULL(p2.corp,'') = p0.corp  \n");
        builder.Append("left join dbo.XPM_Basic_ContactCorp as p5 on ISNULL(p2.corp,'') = p5.CorpId  \n");
        builder.Append("where p2.tsid in(" + tsid + ") \n");
        string strSQL = builder.ToString();
        return publicDbOpClass.DataTableQuary(strSQL);

        //return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), new SqlParameter[0]);
    }

    public void BindGv()
    {
        DataTable dataTable = (DataTable)this.ViewState["DataTable"];
        if (dataTable.Rows.Count == 0)
        {
            this.gvNeedNote.DataSource = dataTable;
            this.gvNeedNote.DataBind();
            //return;
        }
        else
        {
            this.gvNeedNote.DataSource = dataTable;
            this.gvNeedNote.DataBind();
            string total = Convert.ToDecimal(dataTable.Compute("SUM(Total)", string.Empty)).ToString("0.000");
            GridViewUtility.AddTotalRow(this.gvNeedNote, total, 9);
        }


        DataTable dt2 = GetList(hfldResourceIdsZZCL.Value.ToString());
        if (dt2 != null && dt2.Rows.Count > 0)
        {
            this.gvNeedNote2.DataSource = dt2;
            this.gvNeedNote2.DataBind();
            div.Visible = true;
        }
        else
        {
            div.Visible = false;
        }

        DataTable dt3 = BindNeedNote();
        if (dt3 != null && dt3.Rows.Count > 0)
        {
            this.gvNeedNote3.DataSource = dt3;
            this.gvNeedNote3.DataBind();
            div3.Visible = true;
        }
        else
        {
            div3.Visible = false;
        }
    }
    protected void btnShowGv_Click(object sender, EventArgs e)
    {
        this.UpdateDataSource();
        DataTable dataTable = this.ViewState["DataTable"] as DataTable;
        dataTable.Clear();
        DataTable table = GetList(this.hdTsid.Value, this.hfldTrea.Value, hfldResourceIdsZZCL.Value);//获取仓库数据

        DataColumn dataColumn = new DataColumn();
        dataColumn.ColumnName = "TaskId";
        dataColumn.DataType = Type.GetType("System.String");
        dataColumn.DefaultValue = string.Empty;
        table.Columns.Add(dataColumn);

        DataColumn dataColumn1 = new DataColumn();
        dataColumn1.ColumnName = "needNums";
        dataColumn1.DataType = Type.GetType("System.String");
        dataColumn1.DefaultValue = string.Empty;
        table.Columns.Add(dataColumn1);

        DataColumn dataColumn2 = new DataColumn();
        dataColumn2.ColumnName = "wpcode";
        dataColumn2.DataType = Type.GetType("System.String");
        dataColumn2.DefaultValue = string.Empty;
        table.Columns.Add(dataColumn2);

        if (dataTable != null && table != null)
        {
            if (dataTable.Rows.Count == 1 && string.IsNullOrEmpty(dataTable.Rows[0]["scode"].ToString()))
            {
                dataTable.Rows.RemoveAt(0);
            }
            dataTable.PrimaryKey = new DataColumn[]
            {
                dataTable.Columns["scode"],
                dataTable.Columns["CorpId"],
                dataTable.Columns["sprice"],
                dataTable.Columns["TaskId"]
            };
            table.PrimaryKey = new DataColumn[]
            {
                table.Columns["scode"],
                table.Columns["CorpId"],
                table.Columns["sprice"],
                table.Columns["TaskId"]
            };
            dataTable.Merge(table, true);




            DataTable dtTemp = BindNeedNote();//需求量
            if (dataTable != null && dataTable.Rows.Count > 0 && dtTemp != null && dtTemp.Rows.Count > 0)
            {
                foreach (DataRow drA in dataTable.Rows)
                {
                    foreach (DataRow drB in dtTemp.Rows)
                    {
                        if (drA["scode"].ToString() == drB["scode"].ToString())
                        {
                            drA["wpcode"] = drB["wpcode"];
                            try
                            {
                                double d1 = 0;
                                //double d2 = 0;
                                if (!string.IsNullOrEmpty(drB["outNums"].ToString()))
                                {
                                    d1 = Convert.ToDouble(drB["outNums"].ToString());
                                }
                                else
                                {
                                    d1 = 0;
                                }
                                double db = Convert.ToDouble(drB["number"].ToString()) - d1;
                                drA["needNums"] = db.ToString(); //outNums
                            }
                            catch
                            {
                                drA["needNums"] = "0";
                            }
                        }
                    }
                }
            }

            this.ViewState["DataTable"] = dataTable;
        }
        this.BindGv();
    }
    protected void btnBindResourceZZCL_Click(object sender, System.EventArgs e)
    {
        DataTable dtB = getResources(hfldResourceIdsZZCL.Value);

    }
    public static DataTable getResources(string ids)
    {
        string strIDs = ids;
        DataTable dataTable = null;
        //["4b0ae68c-ff0b-403c-bcd5-39a0d07a7ee0|000400002|99","82eddac8-0546-447f-b96b-eacd75d7d9f1|000400001|66"]
        if (!string.IsNullOrEmpty(strIDs))
        {
            //b89b1b0c - 6d3b - 4b37 - a5f1 - eafdd81f0acb | 000400005 | 1,a7ca9325 - 91dd - 4026 - 9dd6 - fbd4482c81a8 | 000400002 | 1,563c0bc1 - f223 - 4db9 - 928d - 2177e1d1e0c0 | 000400004 | 1
            ISerializable serializable = new cn.justwin.Serialize.JsonSerializer();
            string[] array = serializable.Deserialize<string[]>(strIDs);
            //string[] array = strIDs.Split(','); ;
            //4b0ae68c - ff0b - 403c - bcd5 - 39a0d07a7ee0 | 000400002 | 99
            //82eddac8 - 0546 - 447f - b96b - eacd75d7d9f1 | 000400001 | 66
            string[] array2 = null;
            if (array != null)
            {
                string strIDS = string.Empty;
                foreach (string str in array)
                {
                    strIDS += "'" + str.Split('|')[0].ToString().Trim() + "',";
                }
                string strSQL = "select FID,CID,NUM from Res_ResourceRelation where FID in (" + strIDS.Substring(0, strIDS.Length - 1) + ")";
                DataTable dt = publicDbOpClass.DataTableQuary(strSQL);
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
                                    dr["NUM"] = Convert.ToString(Convert.ToDouble(dr["NUM"].ToString().Trim()) * Convert.ToDouble(strNUM));
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
                        array2[ii] = dr["CID"].ToString().Trim();
                        ii++;
                    }
                    string str2 = "select CID from Res_ResourceRelation where FID in (" + strIDS.Substring(0, strIDS.Length - 1) + ")";
                    string strSql2 = @"select distinct p1.ResourceId, 0.000 as number,p1.ResourceCode scode,0.000 sprice,0.000 Total, 
                                        '' CorpId ,'' Corp,0.000 snumber,p1.ResourceName,p1.Specification,p4.Name 
                                        ,p1.Brand,ModelNumber,TechnicalParameter   
                                        from dbo.Res_Resource as p1  
                                        left join Res_Unit as p4 on p1.Unit=p4.UnitID
                                        WHERE 1 = 1 and p1.ResourceId in(" + str2 + ")";
                    dataTable = publicDbOpClass.DataTableQuary(strSql2);

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

                }
            }

        }
        return dataTable;
    }

    //获取需求的资源
    public DataTable BindNeedNote()
    {
        string strIDs = hdlfWantplanCodes.Value.ToString();
        if (!string.IsNullOrEmpty(strIDs))
        {
            string strSQL = string.Format(@" select p2.wpcode,p2.scode,p2.arrivalDateNeed,p2.arrivalDate,p2.Remark,p1.ResourceName,
                        p1.Specification,p4.Name,sum(p2.number) as number 
                        ,p1.Brand,ModelNumber,TechnicalParameter 
,(select sum(number) from Sm_out_Stock sos left join Sm_OutReserve so on sos.orcode=so.orcode WHERE sos.wpcode=p2.wpcode and p2.scode=sos.scode and so.flowstate !=-2 and so.orcode !='{1}') outNums 
                        from dbo.Res_Resource as p1 
                        join dbo.Sm_Wantplan_Stock as p2 on p1.resourceCode=p2.scode 
                        left join Res_Unit as p4 on p1.unit=p4.UnitID 
                        where p2.wpcode in({0}) 
                        group by p2.wpcode,p2.scode,p2.arrivalDateNeed,p2.arrivalDate,p2.Remark,p1.ResourceName,p1.Specification,p4.Name 
                        ,p1.Brand,ModelNumber,TechnicalParameter  
                        ORDER BY p2.scode DESC ", strIDs, txtPPCode.Text.ToString());
            return publicDbOpClass.DataTableQuary(strSQL);
        }
        else
        {
            return null;
        }
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        //hfldResourceIdsZZCL.Value = "";
        //hdTsid.Value = "";
        this.UpdateDataSource();
        DataTable dataTable = (DataTable)this.ViewState["DataTable"];
        foreach (GridViewRow gridViewRow in this.gvNeedNote.Rows)
        {
            CheckBox checkBox = gridViewRow.FindControl("chkBox") as CheckBox;
            HiddenField hiddenField = gridViewRow.FindControl("hdSprice") as HiddenField;
            HiddenField hiddenField2 = gridViewRow.FindControl("hdCorp") as HiddenField;
            if (checkBox != null && checkBox.Checked)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (checkBox.ToolTip == dataTable.Rows[i]["scode"].ToString() && hiddenField.Value == dataTable.Rows[i]["Sprice"].ToString() && hiddenField2.Value == dataTable.Rows[i]["CorpId"].ToString())
                    {
                        ((DataTable)this.ViewState["DataTable"]).Rows.Remove(dataTable.Rows[i]);
                    }
                }
            }
        }
        if (dataTable.Rows.Count == 1 && dataTable.Rows[0]["scode"].ToString() == "")
        {
            ((DataTable)this.ViewState["DataTable"]).Rows.Remove(dataTable.Rows[0]);
        }
        this.BindGv();
    }
    public decimal GetNumByOrsid(string scode, string sprice, string corp)
    {
        string value = "";
        DataTable arg_1B_0 = (DataTable)this.ViewState["DataTable"];
        foreach (GridViewRow gridViewRow in this.gvNeedNote.Rows)
        {
            TextBox textBox = gridViewRow.FindControl("txtCNum") as TextBox;
            HiddenField hiddenField = gridViewRow.FindControl("hdScode") as HiddenField;
            HiddenField hiddenField2 = gridViewRow.FindControl("hdSprice") as HiddenField;
            HiddenField hiddenField3 = gridViewRow.FindControl("hdCorp") as HiddenField;
            if (hiddenField.Value == scode && hiddenField2.Value == sprice && hiddenField3.Value == corp)
            {
                value = textBox.Text;
            }
        }
        return Convert.ToDecimal(value);
    }
    protected void btnSaveWX_Click(object sender, System.EventArgs e)
    {
        //if (this.action.Equals("Add"))
        //{
        //    this.AddWX();
        //    return;
        //}
        //this.UpdateWX();
        save("wx");

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        save("pc");
    }
    private void save(string type)
    {
        int ii = 0;
        DataTable dataTable = (DataTable)this.ViewState["DataTable"];
        foreach (DataRow dr in dataTable.Rows)
        {
            if (Convert.ToDouble(dr["number"].ToString()) > Convert.ToDouble(dr["snumber"].ToString()))
            {
                ii = 1;
                break;
            }
            if (Convert.ToDouble(dr["number"].ToString()) < 0)
            {
                ii = 2;
                break;
            }
        }
        if (ii == 1)
        {
            if (type == "pc")
            {
                base.RegisterScript("top.ui.show('出库数量超过了库存数量！');");
            }
            else
            {
                base.RegisterScript("alert('出库数量超过了库存数量！');");
            }
        }
        else if (ii == 2)
        {
            if (type == "pc")
            {
                base.RegisterScript("top.ui.show('出库数量不能小于零！');");
            }
            else
            {
                base.RegisterScript("alert('出库数量不能小于零！');");
            }
        }
        else
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                try
                {
                    OutReserveModel outReserveModel = new OutReserveModel();
                    outReserveModel.annx = "";
                    outReserveModel.explain = this.txtExplain.Text;
                    outReserveModel.flowstate = Convert.ToInt32(this.hdflowstate.Value);
                    outReserveModel.intime = Convert.ToDateTime(this.txtInTime.Text);
                    outReserveModel.isout = false;
                    outReserveModel.orcode = this.txtPPCode.Text;
                    outReserveModel.orid = this.hdGuid.Value;
                    outReserveModel.person = this.txtPeople.Value;
                    outReserveModel.procode = this.prjId;
                    outReserveModel.tcode = this.hfldTrea.Value;
                    outReserveModel.PickingSector = this.txtPickingSector.Text;
                    outReserveModel.PickingPeople = this.txtPickingPeople.Text;
                    outReserveModel.EquipmentId = this.hfldEquId.Value;
                    int num;
                    if (base.Request.QueryString["id"] != null)
                    {
                        num = this.outReserveBll.Update(sqlTransaction, outReserveModel);
                    }
                    else
                    {
                        num = this.outReserveBll.Add(sqlTransaction, outReserveModel);
                    }
                    if (num != 0)
                    {
                        this.outStockBll.DeleteByWhere(sqlTransaction, " where orcode='" + outReserveModel.orcode + "'");
                        this.UpdateDataSource();
                        //DataTable dataTable = (DataTable)this.ViewState["DataTable"];
                        if (dataTable != null)
                        {
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                //OutStockModel outStockModel = new OutStockModel();
                                //outStockModel.corp = dataRow["CorpId"].ToString();
                                decimal dc= this.GetNumByOrsid(dataRow["scode"].ToString(), dataRow["sprice"].ToString(), dataRow["corpId"].ToString());
                                //outStockModel.number = dc;
                                //outStockModel.orcode = this.txtPPCode.Text;
                                //outStockModel.orsid = Guid.NewGuid().ToString();
                                //outStockModel.scode = dataRow["scode"].ToString();
                                //outStockModel.sprice = Convert.ToDecimal(dataRow["sprice"]);
                                //outStockModel.TaskId = dataRow["TaskId"].ToString();

                                //


                                string strSQL=string.Format(@"insert into Sm_out_Stock (orsid,orcode,scode,sprice,number,corp,TaskId,wpcode) values (
                                                    '{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}')", Guid.NewGuid().ToString(), this.txtPPCode.Text, dataRow["scode"].ToString(), 
                                                    Convert.ToDecimal(dataRow["sprice"]), dc, dataRow["CorpId"].ToString(), dataRow["TaskId"].ToString(), dataRow["wpcode"].ToString());
                                //publicDbOpClass.ExecSqlString(strSQL);
                                    //try
                                    //{
                                        SqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, strSQL);
                                        //sqlTransaction.Commit();
                                       // base.RegisterScript("top.ui.tabSuccess({parentName:'_Task'});");
                                    //}
                                    //catch
                                    //{
                                    //    sqlTransaction.Rollback();
                                    //    //base.RegisterScript("alert('系统提示：\\n\\保存失败！');");
                                    //}
                                
                                //string strSql = "UPDATE Sm_Wantplan_Stock set outNums = ("+ dc + " + outNums)  where wpcode = '"+ dataRow["wpcode"].ToString() + "' and scode = '" + dataRow["scode"].ToString() + "'";
                                // publicDbOpClass.ExecSqlString(strSql);
                                //this.outStockBll.Add(sqlTransaction, outStockModel);
                            }
                        }
                    }
                    sqlTransaction.Commit();
                    StringBuilder stringBuilder = new StringBuilder();
                    if (type == "pc")
                    {
                        stringBuilder.Append("top.ui.show('" + this.SetMsg() + "成功！');").Append(Environment.NewLine);
                        if (base.Request["ifXQ"].ToString()== "byXQ")
                        {
                            stringBuilder.Append("winclose('AddReserve','SmOutReserveListByXQ.aspx?prjGuid=" + this.prjId + "',true)");
                        }
                        else
                        {
                            stringBuilder.Append("winclose('AddReserve','SmOutReserveList.aspx?prjGuid=" + this.prjId + "',true)");
                        }
                        
                    }
                    else
                    {
                        stringBuilder.Append("alert('添加成功');");
                        stringBuilder.Append("parent.location.reload();");
                    }
                    base.RegisterScript(stringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    if (type == "pc")
                    {
                        base.RegisterScript("top.ui.show('" + this.SetMsg() + "失败！');");
                    }
                    else
                    {
                        base.RegisterScript("alert('系统提示：\\n\\n添加失败！');");
                    }
                }
            }
        }
    }
    protected void gvNeedNote_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            e.Row.Attributes["id"] = this.gvNeedNote.DataKeys[e.Row.RowIndex].Value.ToString();
        }
        TextBox textBox = e.Row.FindControl("txtSnumber") as TextBox;
        TextBox textBox2 = e.Row.FindControl("txtCNum") as TextBox;
        if (textBox != null)
        {
            textBox2.Attributes["onblur"] = "chkNum(this.No,this," + textBox.ClientID + ")";
        }
    }

    public string SetMsg()
    {
        if (base.Request.QueryString["id"] != null)
        {
            return "更新";
        }
        return "添加";
    }
    private void UpdateDataSource()
    {
        if (this.ViewState["DataTable"] is DataTable)
        {
            DataTable dataTable = this.ViewState["DataTable"] as DataTable;
            string value = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                GridViewRow gridViewRow = this.gvNeedNote.Rows[i];
                Control control = gridViewRow.FindControl("txtCNum");
                if (control is TextBox)
                {
                    value = (control as TextBox).Text.Trim();
                    if (!string.IsNullOrEmpty(value))
                    {
                        dataRow["number"] = Convert.ToDecimal(value);
                    }
                    else
                    {
                        dataRow["number"] = 0m;
                    }
                    decimal d = Convert.ToDecimal(dataRow["sprice"]);
                    dataRow["Total"] = Convert.ToDecimal(value) * d;
                    TextBox textBox = gridViewRow.FindControl("txtTask") as TextBox;
                    HiddenField hiddenField = gridViewRow.FindControl("hfldTask") as HiddenField;
                    if (!string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        dataRow["TaskId"] = hiddenField.Value.Trim();
                    }
                    else
                    {
                        dataRow["TaskId"] = string.Empty;
                    }
                }
            }
            this.ViewState["DataTable"] = dataTable;
        }
    }
}


