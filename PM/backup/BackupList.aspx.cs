using ASP;
using cn.justwin.BLL;
using cn.justwin.Web;
using SQLDMO;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class backup_BackupList : NBasePage, IRequiresSessionState
{
	public static string filepath = ConfigHelper.Get("BackupSql");
	public static string pstr = ConfigurationManager.ConnectionStrings["Sql"].ToString().ToLower();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.Init();
			this.hfldFolder.Value = backup_BackupList.filepath;
		}
	}
	protected void btnback_Click(object sender, EventArgs e)
	{
		string url = backup_BackupList.filepath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss");
		if (!this.DbBackup(url))
		{
			base.RegisterShow("系统提示", "备份数据库时出错,请用数据库管理工具管理数据库备份和恢复！");
			return;
		}
		base.RegisterScript("startBackUp('1')");
		this.Init();
		base.RegisterShow("系统提示", "备份成功！");
	}
	public bool DbBackup(string url)
	{
		bool result = true;
		Backup backup = new BackupClass();
		SQLServer sQLServer = new SQLServerClass();
		try
		{
			sQLServer.LoginSecure = false;
			string[] array = backup_BackupList.pstr.Split(new char[]
			{
				';'
			});
			sQLServer.Connect(array[0].Split(new char[]
			{
				'='
			})[1], array[3].Split(new char[]
			{
				'='
			})[1], array[4].Split(new char[]
			{
				'='
			})[1]);
			backup.Action = SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
			backup.Database = array[1].Split(new char[]
			{
				'='
			})[1];
			url = url + array[1].Split(new char[]
			{
				'='
			})[1] + ".bak";
			backup.Files = url;
			backup.BackupSetName = array[1].Split(new char[]
			{
				'='
			})[1];
			backup.BackupSetDescription = DateTime.Now.ToString("yyyyMMddHHmm") + "数据库备份";
			backup.Initialize = true;
			backup.SQLBackup(sQLServer);
		}
		catch (Exception)
		{
			result = false;
			throw;
		}
		finally
		{
			sQLServer.DisConnect();
		}
		return result;
	}
	private new void Init()
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(backup_BackupList.filepath);
			FileInfo[] files = directoryInfo.GetFiles();
			int num = 1;
			FileInfo[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				FileInfo fileInfo = array[i];
				base.RegisterScript(string.Concat(new object[]
				{
					"uploadbind(",
					num,
					",'<a  class=\"link\" target=_blank  href=\"../../Common/DownLoad.aspx?path=",
					HttpUtility.UrlEncode(backup_BackupList.filepath + "/" + fileInfo.Name),
					"\"  >",
					fileInfo.Name,
					"</a>','",
					Math.Round((double)fileInfo.Length / 1024.0 / 1024.0, 2, MidpointRounding.AwayFromZero),
					"M','",
					backup_BackupList.filepath,
					"');"
				}));
				num++;
			}
		}
		catch
		{
		}
	}
}


