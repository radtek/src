<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="OA3_ProUser_List" %>

<!DOCTYPE html>
<%@ Import Namespace="cn.justwin.BLL" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>项目人员</title>
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
            //top.ui._proList = window; 
            var url = '/OA3/ProUser/Edit.aspx?action=add&id=&pid=' + document.getElementById('PrjGuid').value;
            title = '新增';
            // toolbox_oncommand(url, title);
            top.ui.callback = refresh;
            top.ui.openWin({ title: title, url: url, width: 400 });
        }
        function edit() {
            //top.ui._proList = window;
            var url = '/OA3/ProUser/Edit.aspx?action=edit&id=' + document.getElementById('KeyId').value + '&pid=' + document.getElementById('PrjGuid').value;
            title = '编辑';
            //toolbox_oncommand(url, title);
            top.ui.callback = refresh;
            top.ui.openWin({ title: title, url: url, width: 400 });
        }

        function view(id) {
            var url = '/OA3/ProUser/Edit.aspx?action=view&id=' + id + '&pid=' + document.getElementById('PrjGuid').value;
            title = '查看';
            top.ui.openWin({ title: title, url: url, width: 400 });
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
                        <tr style="height: 25px;">
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;分组
                            </td>
                            <td>
                                <asp:DropDownList ID="group" Width="100%" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;类型
                            </td>
                            <td>
                                <asp:DropDownList ID="type" Width="100%" runat="server">
                                </asp:DropDownList>
                            </td>

                        </tr>
                        <tr style="height: 25px;">
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;姓名
                            </td>
                            <td>
                                <asp:TextBox ID="xm" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;电话
                            </td>
                            <td>
                                <asp:TextBox ID="tel" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;手机
                            </td>
                            <td>
                                <asp:TextBox ID="phone" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 25px;">
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;QQ
                            </td>
                            <td>
                                <asp:TextBox ID="qq" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;微信
                            </td>
                            <td>
                                <asp:TextBox ID="wx" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;邮箱
                            </td>
                            <td>
                                <asp:TextBox ID="mail" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">&nbsp;&nbsp;地址
                            </td>
                            <td>
                                <asp:TextBox ID="ads" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;&nbsp;<asp:Button ID="btnQuery" Text="查询" OnClick="btnQuery_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="divFooter">
                    <input type="button" id="btnAdd" value="新增" runat="server" />
                    <input type="button" id="btnEdit" value="编辑" disabled="disabled" runat="server" />
                    <asp:Button ID="btnDel" Text="删除" Enabled="false" runat="server" OnClick="btnDel_Click" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="Id" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="20px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbAllBox" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbBox" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="排序" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Eval("sort").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="分组">
                                    <ItemTemplate>
                                        <%# Eval("groupName").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类型">
                                    <ItemTemplate>
                                        <%# Eval("typeName").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="姓名" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <span class="al tooltip" title='<%# Eval("xm").ToString() %>' onclick="view('<%# Eval("id") %>')">
                                            <%# StringUtility.GetStr(Eval("xm").ToString(), 20) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- top.ui.openWin('/OA3/ProUser/Edit.aspx?action=view&id=<%# Eval("id") %>','查看')--%>
                                <asp:TemplateField HeaderText="电话" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("tel").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="手机">
                                    <ItemTemplate>
                                        <%# Eval("phone").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="QQ">
                                    <ItemTemplate>
                                        <%# Eval("qq").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="微信">
                                    <ItemTemplate>
                                        <%# Eval("wx").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="邮箱">
                                    <ItemTemplate>
                                        <%# Eval("mail").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="地址">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("ads") %>">
                                            <%# StringUtility.GetStr(Eval("ads").ToString(), 40) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注">
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
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" ShowPageIndexBox="Always" UrlPaging="false" PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" SubmitButtonText="确定" SubmitButtonStyle="width:40px; vertical-align:top;" TextAfterPageIndexBox="页" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                        </webdiyer:AspNetPager>
                    </div>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="KeyId" runat="server" />
        <asp:HiddenField ID="PrjGuid" runat="server" />
    </form>
</body>
</html>
