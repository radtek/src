<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogFrame.aspx.cs" Inherits="OA3_WorkLog_LogFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日志管理</title>
    <link href="/Script/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../UserControl/FileUpload/GetFiles.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //按钮的点击后的样式
            function funonclickCss(name) {
                document.getElementById(name).style.background = 'url(/images1/email/over.gif) repeat-x';
                document.getElementById(name).style.fontWeight = 'bold';
                document.getElementById(name).style.color = '#004592';
            }
            //按钮的点击前的样式
            function funfrontCss(name) {
                document.getElementById(name).style.background = 'url(/images1/email/understood.gif) repeat-x';
                document.getElementById(name).style.fontWeight = 'normal';
                document.getElementById(name).style.color = '#333';
            }
            // 我的日志 
            $('#my').click(function () {
                funonclickCss('my');
                funfrontCss('sy');
                funfrontCss('xg');
                $('#frmPage').attr('src', 'MyLogList.aspx');
            });
            // 我审阅的
            $('#sy').click(function () {
                funfrontCss('my');
                funonclickCss('sy');
                funfrontCss('xg');
                $('#frmPage').attr('src', 'CheckList.aspx?userType=sy');
            });
            //我相关的 
            $('#xg').click(function () {
                funfrontCss('my');
                funfrontCss('sy');
                funonclickCss('xg');
                $('#frmPage').attr('src', 'CheckList.aspx?userType=xg');
            })
            showMailCount();
            setInterval('showMailCount();', 3000);
        });

        // 显示数量
        function showMailCount() {
            try {
                $.ajax({
                    //type: 'GET',
                    //async: true,
                    //url: 'Handler/GetMailCount.ashx?' + new Date().getTime(),
                    //success: function (data) {
                    //    var obj = eval('(' + data + ')');
                    //    //$('#inbox').val('收件箱(' + obj[0] + ')')
                    //    //$('#draft').val('草稿箱(' + obj[1] + ')')
                    //    //$('#repeal').val('撤回邮件(' + obj[2] + ')')
                    //    //$('#outbox').val('已发送邮件(' + obj[3] + ')')
                    //    //$('#deleted').val('已删除邮件(' + obj[4] + ')')
                    //}
                });
            }
            catch (e) {
            }
        }
        //我的日志
        function funimginbox() {
            $('#my').click();
        }

        //我审阅的
        function funimgdraft() {
            $('#sy').click();
        }

        //我相关的
        function funimgrepeal() {
            $('#xg').click();
        }
    </script>
</head>
<body style="margin: 0;">
	<form id="form1" runat="server">
		<table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="100%">
			<tr>
                <td style="width: 200px;">
                    <div style="margin-bottom: 200px;"><%--140--%>

                       <%-- <span class="spanSelect" id="spanwrite_mail" style="width: 100%; height: 25px; border: 0; background: url(~/images1/email/understood.gif) repeat-x;">--%>
                           <%-- <img src="../../images1/email/1.gif" style="float: left; margin: 8px 2px 0 5%;" id="imgwritemal" onclick="funimgwritemail();" runat="server" />--%>
                           <%-- <input type="button" id="write_mail" value="    写日志" style="line-height: 25px; border: 0px; height: 25px; font-size: 12px; text-align: left; color: #333; float: left; width: 100%; background: url(/images1/email/understood.gif) repeat-x;" />
                        </span>--%>
                        
                        <span class="spanSelect" id="spaninbox" style="width: 100%; height: 25px; border: 0; background: url(/images1/email/over.gif) repeat-x;" onclick="funimginbox();">
                           <input type="button" id="my" value=" 我的日志" style="line-height: 25px; border: 0px; height: 25px; color: #004592; font-weight: bold; text-align: left; width: 100%; background: url(/images1/email/over.gif) repeat-x;"
                                runat="server" />
                        </span>
                        
                        <span class="spanSelect" id="spandraft" style="display:none;width: 100%; height: 25px; border: 0; background: url(/images1/email/understood.gif) repeat-x;" onclick="funimgdraft();">
                            <input type="button" id="sy" value=" 日志审阅" style="line-height: 25px; border: 0px; width: 100%; height: 25px; text-align: left; color: #333; background: url(/images1/email/understood.gif) repeat-x;"
                                runat="server" />
                        </span>
                        
                        <span class="spanSelect" id="spanrepeal" style="display:none;width: 100%; height: 25px; border: 0; background: url(/images1/email/understood.gif) repeat-x;" onclick="funimgrepeal();">
                           <input type="button" id="xg" value=" 日志查阅" style="line-height: 25px; border: 0px; width: 100%; height: 25px; text-align: left; color: #333; background: url(/images1/email/understood.gif) repeat-x;"
                                runat="server" />
                        </span>
                        <%-- <span class="spanSelect" id="spanrepeal2" style="width: 100%; height: 25px; border: 0; background: url(/images1/email/understood.gif) repeat-x;">
                            <input type="button" id="tj" value=" 评论中@我的" style="line-height: 25px; border: 0px; width: 100%; height: 25px; text-align: left; color: #333; background: url(/images1/email/understood.gif) repeat-x;"
                                runat="server" />
                        </span>--%>
                    </div>
                    <div style="color: #727faa;text-align: center;font-weight:normal;">我的工作日志日历</div>
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#d4e3fe" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle BackColor="#eaf3ff" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#c1c1c1"  ForeColor="White" /><%--Font-Bold="True"--%>
                        <SelectorStyle BackColor="#eaf3ff" />
                        <TitleStyle BackColor="#d4e3fe" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#3399ff" ForeColor="white"/>
                        <WeekendDayStyle BackColor="#fbfbfb" />
                    </asp:Calendar> 
                    <div style="color: #808080;text-align: center;background-color: #fbfbfb;">[注:红色日期表示该日有工作日志]</div>
				</td>
				<td width="*" rowspan="2">
					 <iframe id="frmPage" width="100%" height="100%" frameborder="0" src="MyLogList.aspx" runat="server"></iframe>
				</td>
			</tr>
			<tr>
                <td style="width: 200px;height: 10px;">
                    &nbsp;</td>
			</tr>
		</table>
 <asp:HiddenField ID="KeyID" runat="server" />
        </form>
</body>
</html>
