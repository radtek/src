using ASP;
using cn.justwin.BLL;
using cn.justwin.DAL;
using cn.justwin.Domain.Entities;
using cn.justwin.Domain.Services;
using cn.justwin.stockBLL;
using cn.justwin.Tender;
using cn.justwin.Web;
using com.jwsoft.web.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class Common_DivSelectProject : NBasePage, IRequiresSessionState
{
	protected string[] moduleCodeList;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		this.AspNetPager1.PageSize = NBasePage.pagesize;
		this.moduleCodeList = this.hdnModuleCodeList.Value.Split(new char[]
		{
			'^'
		});
		if (!this.Page.IsPostBack)
		{
			this.ShowTaskList("", "");
		}
	}
	public void ShowTaskList(string prjcode, string prjname)
	{
        string usercode = this.Session["yhdm"].ToString();
        this.AspNetPager1.RecordCount = new PTPrjInfoBll().GetProjectCount(usercode, prjcode, prjname);
        DataTable project = GetProject(usercode, prjcode, prjname, this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize);//new PTPrjInfoBll().GetProject(usercode, prjcode, prjname, this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize);
        project.Columns.Add(new DataColumn("isMainContract", typeof(string)));
        for (int i = 0; i < project.Rows.Count; i++)
        {
            DataRow dataRow = project.Rows[i];
            if (dataRow["TypeCode"].ToString().Length != 5)
            {
                project.Rows[i]["isMainContract"] = "False";
            }
            else
            {
                project.Rows[i]["isMainContract"] = "True";
            }
        }
        project.Columns.Add(new DataColumn("HeadImg", typeof(string)));
        project.Columns.Add(new DataColumn("Display", typeof(string)));
        project.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
        //System.Collections.Generic.IList<SelectProject> project2 = SelectProjectHelper.GetProject(base.UserCode, Parameters.PrjAvaildState5, prjcode, prjname);
        //project2.
        this.grdModules.DataSource = project;
		this.grdModules.DataBind();
	}
    private string isNewProject = ConfigHelper.Get("IsNewProject");
    public DataTable GetProject(string usercode, string prjcode, string prjname, int pageIndex, int pageSize)
    {
        if (pageIndex == 0)
        {
            pageIndex = 1;
        }
        //if (pageSize == 0)
        //{
        //    pageSize = this.GetProjectCount(usercode, prjcode, prjname);
        //}
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("\r\n\t\t\t\tSELECT * FROM(select * from PT_PrjInfo where TypeCode in (\r\n\t\t\t\tselect  TypeCode from (\r\n\t\t\t\tSELECT   *  FROM  PT_PrjInfo WHERE  TypeCode in(SELECT left(TYPECODE,5) FROM  PT_PrjInfo WHERE  i_ChildNum=0 and isvalid=1 AND PrjState not in('1','17','18') AND   ( Podepom LIKE '%{0}%' or  PrjManager LIKE '%{1}%' )) \r\n\t\t\t\tunion SELECT   *  FROM  PT_PrjInfo \r\n\t\t\t\tWHERE len(typecode)=10 and  i_ChildNum=0 and isvalid=1 AND PrjState not in('1','17','18')  AND   ( Podepom LIKE '%{2}%' or  PrjManager LIKE '%{3}%' ) ) as project ", new object[] { usercode, usercode, usercode, usercode });
        builder.AppendLine();
        builder.Append(" where 1=1");
        if (!string.IsNullOrEmpty(prjcode))
        {
            builder.AppendFormat(" and PrjCode like '%{0}%' ", prjcode);
        }
        if (!string.IsNullOrEmpty(prjname))
        {
            builder.AppendFormat(" and PrjName like '%{0}%' ", prjname);
        }
        if (this.isNewProject == "1")
        {
            builder.Append(" AND PrjGuid IN(SELECT PrjGuid FROM PT_PrjInfo_ZTB_Detail WHERE SetUpFlowState=1) ");
        }
        builder.Append(" )");
        builder.Append(") AS Prj");
        builder.AppendFormat(" UNION SELECT * FROM PT_PrjInfo WHERE LEN(typecode)=5 and isvalid=1  AND PrjState not in('1','17','18')  AND ( Podepom LIKE '%{0}%' or  PrjManager LIKE '%{1}%' )", usercode, usercode);
        builder.AppendLine();
        if (!string.IsNullOrEmpty(prjcode))
        {
            builder.AppendFormat(" and PrjCode like '%{0}%' ", prjcode);
        }
        if (!string.IsNullOrEmpty(prjname))
        {
            builder.AppendFormat(" and PrjName like '%{0}%' ", prjname);
        }
        if (this.isNewProject == "1")
        {
            builder.Append(" AND PrjGuid IN(SELECT PrjGuid FROM PT_PrjInfo_ZTB_Detail WHERE SetUpFlowState=1) ");
        }
        builder.Insert(0, "\r\n\t\t\t\tSELECT TOP (@pageSize) * FROM (\r\n\t\t\t\tSELECT Row_Number()over(ORDER BY userDefined_Date DESC,TypeCode ASC) as Num,* FROM \r\n\t\t\t\t(SELECT \r\n\t\t\t\tTResult.TypeCode,TResult.PrjCode,TResult.PrjName,TResult.PrjPlace,TResult.Owner,TResult.OwnerCode,TResult.i_childnum,TResult.startdate,TResult.EndDate,TResult.PrjState,TResult.PrjCost,TResult.prjguid \r\n\t\t\t\t,CASE TResult.i_ChildNum\r\n\t\t\t\t\tWHEN '0' THEN (\r\n\t\t\t\t\t\t\t\t\tCASE LEN(TResult.TypeCode)\r\n\t\t\t\t\t\t\t\t\t\tWHEN '5' THEN TResult.StartDate \r\n\t\t\t\t\t\t\t\t\t\tELSE (SELECT PT1.StartDate FROM  PT_PrjInfo  AS PT1 WHERE PT1.TypeCode = LEFT(TResult.TypeCode,5) AND i_ChildNum > 0 AND IsValid = '1')\r\n\t\t\t\t\t\t\t\t\tEND\r\n\t\t\t\t\t\t\t\t\t)\r\n\t\t\t\t\tELSE TResult.StartDate\r\n\t\t\t\tEND AS userDefined_Date,Detail.SetUpFlowState,PrjKindClass\r\n\t\t\t\tFROM\r\n\t\t\t(");
        builder.Append("\r\n\t\t\t\t) AS TResult LEFT JOIN PT_PrjInfo_ZTB_Detail detail ON TResult.PrjGuid=detail.PrjGuid  WHERE TResult.PrjGuid NOT IN\r\n\t\t\t\t(SELECT info.PrjGuid FROM PT_PrjInfo info left join PT_PrjInfo_ZTB_Detail detail ON info.prjGuid=detail.prjGuid\r\n\t\t\t\twhere SetUpFlowState<>1 AND LEN(TypeCode)=10 AND PrjState not in('1','17','18'))\r\n\r\n\t\t\t\tunion \r\n\t\t\t\tselect '00000' as TypeCode,PrjInfoZTB.PrjCode,PrjInfoZTB.PrjName,PrjInfoZTB.PrjPlace,PrjInfoZTB.Owner,PrjInfoZTB.OwnerCode,0 as i_childnum,\r\n\t\t\t\tPrjInfoZTB.startdate,PrjInfoZTB.EndDate,PrjInfoZTB.PrjState,PrjInfoZTB.PrjCost,PrjInfoZTB.prjguid \r\n\t\t\t\t,PrjInfoZTB.StartDate as userDefined_Date,1 as SetUpFlowState,PrjKindClass\r\n\t\t\t\tfrom \r\n\t\t\t\t(select PT_PrjInfo_ZTB.* from PT_PrjInfo_ZTB \r\n\t\t\t\tjoin PT_PrjInfo_ZTB_Detail on PT_PrjInfo_ZTB.PrjGuid=PT_PrjInfo_ZTB_Detail.PrjGuid\r\n\t\t\t\tand PT_PrjInfo_ZTB_Detail.ProjFlowSate =1\r\n\t\t\t\twhere PT_PrjInfo_ZTB.PrjState=5 and PT_PrjInfo_ZTB.bidFlowState='1' and PT_PrjInfo_ZTB.PrjGuid not in(select PrjGuid from PT_PrjInfo)) PrjInfoZTB\r\n\t\t\t\tjoin Pt_PrjInfo_ZTB_User on PrjInfoZTB.prjguid=Pt_PrjInfo_ZTB_User.prjguid and (Pt_PrjInfo_ZTB_User.UserCode LIKE '%" + usercode + "%')");
        builder.AppendLine();
        builder.Append(" where 1=1");
        if (!string.IsNullOrEmpty(prjcode))
        {
            builder.AppendFormat(" and PrjInfoZTB.PrjCode like '%{0}%' ", prjcode);
        }
        if (!string.IsNullOrEmpty(prjname))
        {
            builder.AppendFormat(" and PrjInfoZTB.PrjName like '%{0}%' ", prjname);
        }
        builder.AppendLine();
        builder.Append("\r\n\t\t\t\t) AS tbPrjInfo\r\n\t\t\t\tleft join (SELECT CodeID,CodeName FROM XPM_Basic_CodeList Where TypeID=(SELECT TypeID FROM XPM_Basic_CodeType Where SignCode='ProjectType') and ISvalid=1) PrjType on tbPrjInfo.PrjKindClass=PrjType.CodeID\r\n\t\t\t\t) AS Tab WHERE Num > @pageSize * (@pageIndex - 1)\r\n\t\t\t");
        SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@pageSize", SqlDbType.Int, 4), new SqlParameter("@pageIndex", SqlDbType.Int, 4) };
        commandParameters[0].Value = pageSize;
        commandParameters[1].Value = pageIndex;
        DataTable table = new DataTable();
        return SqlHelper.ExecuteQuery(CommandType.Text, builder.ToString(), commandParameters);
    }

    protected string GetOwnerName(object ownerId)
    {
        string result;
        try
        {
            XPMBasicContactCorpService xPMBasicContactCorpService = new XPMBasicContactCorpService();
            XPMBasicContactCorp byId = xPMBasicContactCorpService.GetById(System.Convert.ToInt32(ownerId));
            result = byId.CorpName;
        }
        catch
        {
            result = "";
        }
        return result;
    }
    protected override void OnInit(System.EventArgs e)
	{
		this.InitializeComponent();
		base.OnInit(e);
	}
	private void InitializeComponent()
	{
		this.grdModules.ItemDataBound += new DataGridItemEventHandler(this.grd_ModuleList_ItemDataBound);
	}
	private void grd_ModuleList_ItemDataBound(object sender, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
		{
			DataRowView dataRowView = (DataRowView)e.Item.DataItem;
			if (dataRowView["TypeCode"].ToString() == "00")
			{
				e.Item.Attributes["onclick"] = "clickRow(this,'',false,'','','');";
			}
			else
			{
				e.Item.Attributes["onclick"] = string.Concat(new string[]
				{
					"clickRow(this,'",
					dataRowView["TypeCode"].ToString(),
					"',",
					((int)dataRowView["i_childnum"] == 0) ? "true" : "false",
					",'",
					dataRowView["prjguid"].ToString(),
					"','",
					dataRowView["prjname"].ToString(),
					"','",
					dataRowView["prjCode"].ToString(),
					"','",
					dataRowView["CodeName"].ToString(),
					"');"
				});
			}
			e.Item.Attributes["isMainContract"] = ((HiddenField)e.Item.FindControl("hfldIsMainContract")).Value;
			e.Item.Attributes["id"] = dataRowView["prjCode"].ToString();
			e.Item.Attributes["ondblclick"] = string.Concat(new string[]
			{
				"dbClickRow(this,'",
				dataRowView["prjguid"].ToString(),
				"','",
				dataRowView["prjname"].ToString(),
				"','",
				dataRowView["prjCode"].ToString(),
				"','",
				dataRowView["CodeName"].ToString(),
				"',",
				((int)dataRowView["i_childnum"] == 0) ? "true" : "false",
				")"
			});
			e.Item.Cells[8].Text = "";
			if (ConfigHelper.Get("IsNewProject") == "0")
			{
				if (dataRowView["PrjState"].ToString() == "4")
				{
					e.Item.Cells[8].Text = "在建";
				}
				if (dataRowView["PrjState"].ToString() == "-1")
				{
					e.Item.Cells[8].ForeColor = Color.Blue;
					e.Item.Cells[8].Text = "在建";
				}
				if (dataRowView["PrjState"].ToString() == "0")
				{
					e.Item.Cells[8].Text = "";
				}
				if (dataRowView["TypeCode"].ToString() == "00")
				{
					e.Item.Attributes["onclick"] = "clickRow(this,'',false,'','','');";
				}
				else
				{
					e.Item.Attributes["onclick"] = string.Concat(new string[]
					{
						"clickRow(this,'",
						dataRowView["TypeCode"].ToString(),
						"',",
						((int)dataRowView["i_childnum"] == 0) ? "true" : "false",
						",'",
						dataRowView["prjguid"].ToString(),
						"','",
						dataRowView["prjname"].ToString(),
						"','",
						dataRowView["prjCode"].ToString(),
						"','",
						dataRowView["CodeName"].ToString(),
						"');"
					});
				}
				e.Item.Attributes["ondblclick"] = string.Concat(new string[]
				{
					"dbClickRow(this,'",
					dataRowView["prjguid"].ToString(),
					"','",
					dataRowView["prjname"].ToString(),
					"','",
					dataRowView["prjCode"].ToString(),
					"','",
					dataRowView["CodeName"].ToString(),
					"',",
					((int)dataRowView["i_childnum"] == 0) ? "true" : "false",
					")"
				});
			}
			else
			{
				try
				{
					int code = System.Convert.ToInt32(dataRowView["PrjState"]);
					e.Item.Cells[8].Text = TypeList.GetNameByCode(code);
				}
				catch
				{
				}
			}
			if (dataRowView["TypeCode"].ToString().Length > 3)
			{
				e.Item.Cells[1].Text = dataRowView["TypeCode"].ToString().Substring(0, 3) + "<font color=\"#ff0000\">" + dataRowView["TypeCode"].ToString().Substring(3, dataRowView["TypeCode"].ToString().Length - 3) + "</font>";
			}
			e.Item.Cells[3].Text = StringUtility.GetStr(dataRowView["Owner"].ToString(), 0, 6);
			e.Item.Cells[7].Text = StringUtility.GetStr(dataRowView["PrjPlace"].ToString(), 0, 6);
			e.Item.Attributes["id"] = dataRowView["prjGuid"].ToString();
		}
	}
	protected void SearchBt_Click(object sender, System.EventArgs e)
	{
		this.AspNetPager1.CurrentPageIndex = 0;
		this.ShowTaskList(this.prjcode.Text.Trim(), this.prjname.Text.Trim());
	}
	protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
	{
		this.ShowTaskList(this.prjcode.Text.Trim(), this.prjname.Text.Trim());
	}
}


