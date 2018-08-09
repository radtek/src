<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JournalTypeList.aspx.cs" Inherits="oa_JournalManage_JournalTypeList" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WF.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工作日志类型管理</title>
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
            top.ui._JournalType = window;
            var url = '/oa/JournalManage/JournalTypeEdit.aspx?action=add';
            title = '新增工作日志类型';
            toolbox_oncommand(url, title);
            //top.ui.openWin({ title: title, url: url });
        }
        function edit() {
            top.ui._JournalType = window;
            var url = '/oa/JournalManage/JournalTypeEdit.aspx?action=edit&id=' + document.getElementById('KeyId').value;
            title = '编辑工作日志类型';
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
                            <td class="descTd" style="white-space: nowrap;">类型名称
                            </td>
                            <td>
                                <asp:TextBox ID="name" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">是否启用
                            </td>
                            <td>
                                <asp:DropDownList ID="is_use" Width="100%" runat="server">
                                    <asp:ListItem Value="">  </asp:ListItem>
                                    <asp:ListItem Value="0">停用</asp:ListItem>
                                    <asp:ListItem Value="1">启用</asp:ListItem>
                                </asp:DropDownList>
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
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="Id" runat="server">
                            <EmptyDataTemplate>
                                <table class="gvdata" id="gvId" cellspacing="0" rules="all" border="0" cellpadding="0"
                                    style="border-collapse: collapse;">
                                    <tr class="header">
                                        <th scope="col" style="width: 20px;"></th>
                                        <th>排序
                                        </th>
                                        <th>日志类型状态
                                        </th>
                                        <th>日志类型名称
                                        </th>
                                        <th>日志标题缺省值
                                        </th>
                                        <th>日志内容缺省值
                                        </th>
                                        <th>备注
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

                                <%--<asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%> 
                                <asp:TemplateField HeaderText="排序"  HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Eval("sort").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志类型状态" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <%# (Eval("is_use").ToString() == "0") ? "停用": "启用" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="日志类型名称" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("name").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志标题缺省值" >
                                    <ItemTemplate>
                                        <%# Eval("title_temp").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志内容缺省值" >
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("content_temp") %>">
                                            <%# StringUtility.GetStr(Eval("content_temp").ToString(), 40) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" >
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("remark") %>">
                                            <%# StringUtility.GetStr(Eval("remark").ToString(), 100) %>
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
