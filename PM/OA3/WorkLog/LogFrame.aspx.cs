using cn.justwin.Domain.Services;
using com.jwsoft.common.baseclass;
using com.jwsoft.pm.entpm.action;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class OA3_WorkLog_LogFrame : BasePage, IRequiresSessionState
{
    private OAJournalService pcSer = new OAJournalService();
    string[,,] SpecialDays = new string[3000, 13, 32];
    public int a, b, c;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request["id"]))
        {
            this.KeyID.Value = base.Request["id"];
        }
        if (!base.IsPostBack)
        {
            Calendar1.VisibleDate = Calendar1.TodaysDate;
        }
        string strWhere = " and creater ='" + UserCode + "'";
        DataTable dt = pcSer.GetMsgTable(strWhere, UserCode);
        foreach (DataRow dr in dt.Rows)
        {
            a = int.Parse(DateTime.Parse(dr["start_time"].ToString()).Year.ToString());
            b = int.Parse(DateTime.Parse(dr["start_time"].ToString()).Month.ToString());
            c = int.Parse(DateTime.Parse(dr["start_time"].ToString()).Day.ToString());
            SpecialDays[a, b, c] = "";
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DisplaySelection();
    }
    private void DisplaySelection()
    {
        string str1 = Calendar1.SelectedDate.Date.ToString();

        string strMonth = null;
        if (Calendar1.SelectedDate.Month.ToString().Length < 2)
        {
            strMonth = "0" + Calendar1.SelectedDate.Month.ToString();
        }
        else
        {
            strMonth = Calendar1.SelectedDate.Month.ToString();
        }
        string strDay = null;
        if (Calendar1.SelectedDate.Day.ToString().Length < 2)
        {
            strDay = "0" + Calendar1.SelectedDate.Day.ToString();
        }
        else
        {
            strDay = Calendar1.SelectedDate.Day.ToString();
        }
        string str2 = Calendar1.SelectedDate.Year.ToString() + "-" + strMonth + "-" + strDay;
        this.frmPage.Attributes["src"] = "MyLogList.aspx?time=" + str2;
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth) {
            e.Cell.Controls.Clear();
        }
        else
        {
            Style SpecialDayStyle = new Style();
            //SpecialDayStyle.BackColor = System.Drawing.Color.FromArgb(0x55, 0xAF, 0xEB);
            SpecialDayStyle.ForeColor = System.Drawing.Color.Red;
            //SpecialDayStyle.BorderColor = System.Drawing.Color.FromArgb(0xE1, 0xE1, 0xE1);
            //SpecialDayStyle.Font.Size = FontUnit.Parse("12pt");

            try
            {
                string MyDay = SpecialDays[e.Day.Date.Year, e.Day.Date.Month, e.Day.Date.Day];

                if (MyDay != null)
                {

                    e.Cell.ApplyStyle(SpecialDayStyle);
                }
            }
            catch (Exception exc)
            {
                Response.Write(exc.ToString());
            }

        }
    }
}