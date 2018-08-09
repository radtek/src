<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLogList.aspx.cs" Inherits="OA3_WorkLog_MyLogList" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WF.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2C.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        addEvent(window, 'load', function () {
            addEvent(document.getElementById('btnAdd'), 'click', add);
            addEvent(document.getElementById('btnEdit'), 'click', edit);
            addEvent(document.getElementById('btnView'), 'click', view);
            var jwtable = new JustWinTable('GvList');
            setButton(jwtable, 'btnDel', 'btnEdit', 'btnView', 'KeyId');
            replaceEmptyTable('gvId', 'GvList');
            showTooltip('tooltip', 15);
        });

        function add() {
            top.ui._Journal = window;
            var url = '/OA3/WorkLog/MyLogEdit.aspx?action=add';
            title = '新增工作日志';
            toolbox_oncommand(url, title);
            ////top.ui.openWin({ title: title, url: url });

            //parent.parent.desktop.PrjInfoAdd = window;
            //var url = '/OA3/WorkLog/MyLogEdit.aspx?action=add';
            //window.location.href = url;

        }
        function edit() {
            top.ui._Journal = window;
            var url = '/OA3/WorkLog/MyLogEdit.aspx?action=edit&id=' + document.getElementById('KeyId').value;
            title = '编辑工作日志';
            toolbox_oncommand(url, title);
        }
        function view() {
            top.ui._Journal = window;
            var url = "/OA3/WorkLog/MyLogView.aspx?action=view&id=" + document.getElementById('KeyId').value;
            title = '查看工作日志';
            toolbox_oncommand(url, title);
        }
        function rowClick(id, IsOk, count) {
            document.getElementById('KeyId').value = id;
        }
        function cale() {
            if($('#cale').is(':hidden')){
                $("#cale").show();
            }else{
                $("#cale").hide();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--        <div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="vertical-align: top;"></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </div>--%>

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <%--            <tr>
                <td class="divHeader">填写工作日志
                </td>
            </tr>--%>
            <tr id="t1" runat="server">
                <td style="vertical-align: top;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr> 
                             <td class="descTd" style="white-space: nowrap;">日志状态
                            </td>
                            <td>
                                <asp:DropDownList ID="status" Width="100%" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem Value="0">草稿中</asp:ListItem>
                                    <asp:ListItem Value="1">已提交</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">日志类型
                            </td>
                            <td>
                                <asp:DropDownList ID="type_id" Width="100%"  runat="server"></asp:DropDownList>
                            </td> 
                            <td class="descTd" style="white-space: nowrap;">日志标题
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">项目名称
                            </td>
                            <td>
                                <asp:TextBox ID="proName" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">任务名称
                            </td>
                            <td>
                                <asp:TextBox ID="taskName" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                           </tr>
                        <tr>  
                            <td class="descTd" style="white-space: nowrap;">日志日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" runat="server"></asp:TextBox>
                            </td> 
                            <td class="descTd" style="white-space: nowrap;">填写时间
                            </td>
                            <td>
                                <asp:TextBox ID="stime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                            <td>
                                <asp:TextBox ID="etime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnQuery" Text="查询" OnClick="btnQuery_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="t2" runat="server">
                <td style="text-align: left;" class="divFooter">
                    <input type="button" id="btnAdd" value="新增" />
                    <input type="button" id="btnEdit" value="编辑" disabled="disabled" />
                    <asp:Button ID="btnDel" Text="删除" Enabled="false" OnClick="btnDel_Click" runat="server" />
                    <input type="button" id="btnView" value="查看" disabled="disabled" />
                    <asp:Button ID="btnExecl" CssClass="button-normal" Text="导出Excel" Width="80px" OnClick="btnExecl_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="Id" runat="server">
<%--                            <EmptyDataTemplate>
                                <table class="gvdata" id="gvId" cellspacing="0" rules="all" border="0" cellpadding="0"
                                    style="border-collapse: collapse;">
                                    <tr class="header">
                                        <th></th>
                                        <th>序号
                                        </th>
                                        <th>日志状态
                                        </th>
                                        <th>日志类型
                                        </th>
                                        <th>日志标题
                                        </th>
                                        <th>日志日期
                                        </th>
                                        <th>开始时间
                                        </th>
                                        <th>结束时间
                                        </th>
                                        <th>持续(分钟)
                                        </th>
                                        <th>日志内容
                                        </th>
                                        <th>填写时间
                                        </th>
                                        <th>审阅人
                                        </th>
                                        <th>相关人
                                        </th>
                                          <th>是否已读
                                        </th>
                                        <th>评论总数
                                        </th>
                                        <th>最新评论数
                                        </th>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>--%>
                            <Columns>

                                <asp:TemplateField HeaderStyle-Width="20px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbAllBox" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbBox" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%#Eval("pageindex") %>
                                        <%--  <%# Container.ItemIndex + 1 + (this.AspNetPager1.CurrentPageIndex - 1) * 15 %>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志状态" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <center><%# (Eval("status").ToString() == "0") ? "草稿中": "已提交" %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志类型" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <center><%# Eval("typeName").ToString() %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志标题">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("title") %>">
                                            <asp:HyperLink ID="HyperLink1" Text=' <%# StringUtility.GetStr(Eval("title").ToString(), 20) %> ' runat="server"></asp:HyperLink>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="日志日期">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("start_time")).ToString("yyyy-MM-dd") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开始时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("start_time")).ToString("HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="结束时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("end_time")).ToString("HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="持续(分钟)">
                                    <ItemTemplate>
                                        <center><%#Eval("longs") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="日志内容" HeaderStyle-Width="380px">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("content") %>">
                                           
                                            <%# StringUtility.GetStr(Eval("content").ToString(), 30) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField> --%><%--  <%#Eval("content").ToString().Substring(0,30) %>--%>
                                <asp:TemplateField HeaderText="填写时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("create_date")).ToString("yyyy-MM-dd HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审阅人" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%#Eval("syr") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="相关人" HeaderStyle-Width="180px">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("xgr") %>">
                                            <%# StringUtility.GetStr(Eval("xgr").ToString(), 20) %> 
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="是否已读">
                                    <ItemTemplate>
                                      <%# (Eval("ifck").ToString() == "0") ? "未读": "已读" %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                              <%--  <asp:TemplateField HeaderText="评论总数">
                                    <ItemTemplate>
                                        <%#Eval("plAll") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最新评论数">
                                    <ItemTemplate>
                                        <%#Eval("plNew") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="回复数(最新/总数)">
                                    <ItemTemplate>
                                        <%#Eval("plNew") %>/<%#Eval("plAll") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                            <SelectedRowStyle BackColor="Red"></SelectedRowStyle>
                            <HeaderStyle CssClass="header"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                        </asp:GridView>
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" ShowPageIndexBox="Always" UrlPaging="false" PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" SubmitButtonText="确定" SubmitButtonStyle="width:40px; vertical-align:top;" TextAfterPageIndexBox="页" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                        </webdiyer:AspNetPager>
                    </div>
                </td>
            </tr>
            
        </table>
        <input id="KeyId" type="hidden" runat="server" />
        <div id="cale" style="display: none; z-index: 999999;position:relative;float: left;">
                        <div style="color: #727faa; text-align: center; font-weight: normal; background-color: #fbfbfb; border: 1px solid #cadeed; margin-top: 5px;width: 298px; border-bottom-style: none;">我的工作日志日历</div>
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#d4e3fe" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" Width="300px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged">
                            <DayHeaderStyle BackColor="#eaf3ff" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#c1c1c1" ForeColor="White" />
                            <%--Font-Bold="True"--%>
                            <SelectorStyle BackColor="#eaf3ff" />
                            <TitleStyle BackColor="#d4e3fe" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#3399ff" ForeColor="white" />
                            <WeekendDayStyle BackColor="#fbfbfb" />
                        </asp:Calendar>
                        <div style="color: #808080; text-align: center; background-color: #fbfbfb; border: 1px solid #cadeed; border-top-style: none;width: 298px;">[注:红色日期表示该日有工作日志]</div>
                    </div>
    </form>
</body>
</html>
