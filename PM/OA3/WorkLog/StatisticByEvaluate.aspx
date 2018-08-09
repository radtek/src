<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatisticByEvaluate.aspx.cs" Inherits="OA3_WorkLog_StatisticByEvaluate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>日志统计(按评价)</title>
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
        <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtTo').attr('readOnly', true);
        });
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
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="vertical-align: top;">
                    <table class="queryTable">
                        <tr style="display:" >  
                            <td class="descTd" style="white-space: nowrap;">日志日期
                            </td>
                            <td>
                                <asp:TextBox ID="stime" Width="100%" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="txt mustInput" data-options="required:true" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                         <td>
                                <asp:TextBox ID="etime" Width="100%" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="txt mustInput" data-options="required:true" runat="server"></asp:TextBox>
                            </td>

                               <td class="descTd" style="white-space: nowrap;">填写人
                            </td>
                            <td>
                               <span class="spanSelect" style="width: 100%">
                                    <asp:TextBox ID="txtTo" Style="width: 70%; height: 15px; border: none; line-height: 16px; margin: 1px 2px"
                                        runat="server"></asp:TextBox>
                                    <img src="../../images/icon_17.bmp" style="float: right; border: none;" alt="选择" id="imgName" onclick="jw.selectMultiUser({ nameinput: 'txtTo', codeinput: 'hfldTo' });" runat="server" />

                                </span>
                                <input id="hfldTo" type="hidden" style="width: 1px" runat="server" />
                            </td>
                            <td style="white-space: nowrap;"></td>

                            <td>
                               &nbsp; &nbsp; <asp:Button ID="btnQuery" Text="查询" OnClick="btnQuery_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="divFooter">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="填写人" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                           <%# Eval("v_xm")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="一般" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                           <%# Eval("status1")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="良好" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("status2") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="优秀" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("status3") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="未评价" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("status0") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="总计" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("statusAll") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                            <SelectedRowStyle BackColor="Red"></SelectedRowStyle>
                            <HeaderStyle CssClass="header"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                        </asp:GridView>
                        <%--<asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="creater" runat="server">
                            <EmptyDataTemplate>
                                <table class="gvdata" id="gvId" cellspacing="0" rules="all" border="0" cellpadding="0"
                                    style="border-collapse: collapse;">
                                    <tr class="header">
                                        <th>序号
                                        </th>
                                        <th>日志评价
                                        </th>
                                          <th>填写人
                                        </th>
                                        <th>日志总数
                                        </th>
                                        <th>日志总时长(分钟)
                                        </th>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志评价" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                           <%# Eval("scoreName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="填写人" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                           <%# Eval("v_xm")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志总数" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("counts") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志总时长(分钟)" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("sums") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                            <SelectedRowStyle BackColor="Red"></SelectedRowStyle>
                            <HeaderStyle CssClass="header"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                        </asp:GridView>--%>
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
