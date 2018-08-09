<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="SysSet_list" %>
<!DOCTYPE html>
<%@ Import Namespace="cn.justwin.BLL" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统参数管理</title>
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript">
        addEvent(window, 'load', function () {
            addEvent(document.getElementById('btnAdd'), 'click', add);
            addEvent(document.getElementById('btnEdit'), 'click', edit);
            //addEvent(document.getElementById('btnView'), 'click', view);
            var jwtable = new JustWinTable('GvList');
            setButton(jwtable, 'btnDel', 'btnEdit', 'btnView', 'KeyId');
            replaceEmptyTable('gvId', 'GvList');
            showTooltip('tooltip', 15);
        });

        function add() {
            //top.ui._TaskType = window;
            var url = '/SysSet/edit.aspx?action=add';
            title = '新增';
            //toolbox_oncommand(url, title);
            top.ui.callback = refresh;
            top.ui.openWin({ title: title, url: url, width: 600, height: 200 });
        }
        function edit() {
            //top.ui._TaskType = window;
            var url = '/SysSet/edit.aspx?action=edit&Id=' + document.getElementById('KeyId').value;
            title = '编辑';
            //toolbox_oncommand(url, title);
            top.ui.callback = refresh;
            top.ui.openWin({ title: title, url: url, width: 600, height: 200 });
        }
        function view() {

        }
        function refresh() {
            $('#btnQuery').click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="vertical-align: top;">
                    <table class="queryTable">
                        <tr> <td class="descTd" style="white-space: nowrap;">参数说明
                            </td>
                            <td>
                                <asp:TextBox ID="Note" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">参数名称
                            </td>
                            <td>
                                <asp:TextBox ID="ParaName" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
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
               </td>
            </tr>
            <tr>
                <td>
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="Id" runat="server">
                            <EmptyDataTemplate>
                                <table class="gvdata" id="gvId" style="border-collapse: collapse;">
                                    <tr class="header">
                                        <th scope="col" style="width: 20px;"></th>
                                        <th>序号
                                        </th>
                                        <th>参数说明
                                        </th>
                                        <th>参数名称
                                        </th>
                                        <th>参数数值
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
                                       <%# Eval("pageindex").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="参数说明" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("Note").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="参数名称" >
                                    <ItemTemplate>
                                        <%# Eval("ParaName").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="参数数值" >
                                    <ItemTemplate>
                                     <%# Eval("ParaValue").ToString() %>
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
    </form>
</body>
</html>