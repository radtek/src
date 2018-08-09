<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JournalList.aspx.cs" Inherits="oa_JournalManage_JournalList" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WF.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工作日志填写</title>
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
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
            var url = '/oa/JournalManage/JournalEdit.aspx?action=add';
            title = '新增工作日志';
            toolbox_oncommand(url, title);
            //top.ui.openWin({ title: title, url: url });
        }
        function edit() {
            top.ui._Journal = window;
            var url = '/oa/JournalManage/JournalEdit.aspx?action=edit&id=' + document.getElementById('KeyId').value;
            title = '编辑工作日志';
            toolbox_oncommand(url, title);
        }
        function view() {
            top.ui._Journal = window;
            var url = "/oa/JournalManage/JournalDetail.aspx?action=view&id=" + document.getElementById('KeyId').value;
            title = '查看工作日志';
            toolbox_oncommand(url, title);
        }
        function rowClick(id, IsOk, count) {
            alert(id);
            document.getElementById('KeyId').value = id;
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
            <tr>
                <td style="vertical-align: top;">
                    <table class="queryTable">
                        <tr>
                            <td class="descTd" style="white-space: nowrap;">日志状态
                            </td>
                            <td>
                                <asp:DropDownList ID="status" Width="100%" runat="server">
                                    <asp:ListItem Value="">  </asp:ListItem>
                                    <asp:ListItem Value="0">草  稿</asp:ListItem>
                                    <asp:ListItem Value="1">已提交</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">标题
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">日志类型
                            </td>
                            <td>
                                <asp:DropDownList ID="type_id" Width="100%" runat="server"></asp:DropDownList>
                            </td>
                            <td></td>

                            <td class="descTd" style="white-space: nowrap;">日志时间
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Style="width: 110px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Style="width: 110px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>


                            <td style="white-space: nowrap;"></td>

                            <td>
                                <asp:Button ID="btnQuery" Text="查询" OnClick="btnQuery_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="divFooter">
                    <input type="button" id="btnAdd" value="新增" />
                    <input type="button" id="btnEdit" value="编辑" disabled="disabled" />
                    <asp:Button ID="btnDel" Text="删除" Enabled="false" OnClick="btnDel_Click" runat="server" />
                    <input type="button" id="btnView" value="查看" />
                    <%-- <input id="btnSumm" type="button" value="写总结" disabled="true" style="width: 80px;" runat="server" />

                    <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiClass="001" runat="server" />--%>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="Id" runat="server">
                            <EmptyDataTemplate>
                                <table class="gvdata" id="gvId" cellspacing="0" rules="all" border="0" cellpadding="0"
                                    style="border-collapse: collapse;">
                                    <tr class="header">
                                        <th scope="col" style="width: 20px;"></th>
                                        <th>序号
                                        </th>
                                        <th>日志状态
                                        </th>
                                        <th>标题
                                        </th>
                                        <th>日志类型
                                        </th>
                                        <th>开始时间
                                        </th>
                                        <th>结束时间
                                        </th>
                                        <th>日志内容
                                        </th>
                                        <th>填写时间
                                        </th>
                                        <th>审阅人
                                        </th>
                                        <th>相关人
                                        </th>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>

                                <asp:TemplateField HeaderStyle-Width="20px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbAllBox" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbBox" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志状态" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <%# (Eval("status").ToString() == "0") ? "草稿": "已提交" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("title") %>">
                                            <%# StringUtility.GetStr(Eval("title").ToString(), 20) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志类型" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%--  <%# BackType(Eval("type_id").ToString()) %>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开始时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("start_time")).ToString("yyyy-MM-dd HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结束时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("end_time")).ToString("yyyy-MM-dd HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志内容" HeaderStyle-Width="380px">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("content") %>">
                                            <%# StringUtility.GetStr(Eval("content").ToString(), 30) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="填写时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("create_date")).ToString("yyyy-MM-dd HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审阅人" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%--  <%# BackSYR(Eval("Id").ToString()) %>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="相关人" HeaderStyle-Width="180px">
                                    <ItemTemplate>
                                        <span class="tooltip" title=" <%# BackXGR(Eval("Id").ToString()) %>">
                                            <%-- <%# StringUtility.GetStr(BackXGR(Eval("Id").ToString()), 30) %>--%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                            <SelectedRowStyle BackColor="Red"></SelectedRowStyle>
                            <HeaderStyle CssClass="header"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                        </asp:GridView>
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" UrlPaging="false" ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                        </webdiyer:AspNetPager>
                    </div>
                </td>
            </tr>
        </table>
        <input id="KeyId" type="hidden" runat="server" />
    </form>
</body>
</html>
