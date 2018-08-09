<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskByUsersStatisticsList.aspx.cs" Inherits="OA3_WorkTask_TaskByUsersStatisticsList" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WF.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工作任务统计</title>
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
        addEvent(window, 'load', function () {
            addEvent(document.getElementById('btnAdd'), 'click', add);
            addEvent(document.getElementById('btnEdit'), 'click', edit);
            addEvent(document.getElementById('btnView'), 'click', view);
            var jwtable = new JustWinTable('GvList');
            //setButton(jwtable, 'btnDel', 'btnEdit', 'btnView', 'KeyId');
            replaceEmptyTable('gvId', 'GvList');
            showTooltip('tooltip', 15);
        });

        //function add() {
        //    top.ui._Journal = window;
        //    var url = '/oa/JournalManage/JournalEdit.aspx?action=add';
        //    title = '新增工作日志';
        //    toolbox_oncommand(url, title);
        //    //top.ui.openWin({ title: title, url: url });
        //}
        //function edit() {
        //    top.ui._Journal = window;
        //    var url = '/oa/JournalManage/JournalEdit.aspx?action=edit&id=' + document.getElementById('KeyId').value;
        //    title = '编辑工作日志';
        //    toolbox_oncommand(url, title);
        //}
        //function view() {
        //    top.ui._Journal = window;
        //    var url = "/oa/JournalManage/JournalDetail.aspx?action=view&id=" + document.getElementById('KeyId').value;
        //    title = '查看工作日志';
        //    toolbox_oncommand(url, title);
        //}
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
                         <%--   <td class="descTd" style="white-space: nowrap;">标题
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">日志类型
                            </td>
                            <td>
                                <asp:DropDownList ID="type_id" Width="100%" runat="server"></asp:DropDownList>
                            </td>
                            <td></td>--%>
                               <td class="descTd" style="white-space: nowrap;">任务创建人
                            </td>
                            <td>
                               <span class="spanSelect" style="width: 100%">
                                    <asp:TextBox ID="txtTo" Style="width: 70%; height: 15px; border: none; line-height: 16px; margin: 1px 2px"
                                        runat="server"></asp:TextBox>
                                    <img src="../../images/icon_17.bmp" style="float: right; border: none;" alt="选择" id="imgName" onclick="jw.selectOneUser({ nameinput: 'txtTo', codeinput: 'hfldTo' });" runat="server" />

                                </span>
                                <input id="hfldTo" type="hidden" style="width: 1px" runat="server" />
                            </td>
                            <td style="white-space: nowrap;"></td>
                             <td class="descTd" style="white-space: nowrap;">创建日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="100%" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="txt mustInput" data-options="required:true" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>  <td>
                                <asp:TextBox ID="txtEndTime" Width="100%" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="txt mustInput" data-options="required:true" runat="server"></asp:TextBox>
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
                     <%-- <input type="button" id="btnAdd" value="新增" />
                    <input type="button" id="btnEdit" value="编辑" disabled="disabled" />
                    <asp:Button ID="btnDel" Text="删除" Enabled="false"  OnClick="btnDel_Click" runat="server" />
                    <input type="button" id="btnView" value="查看" />
                   <input id="btnSumm" type="button" value="写总结" disabled="true" style="width: 80px;" runat="server" />

                    <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiClass="001" runat="server" />--%>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="" runat="server">
                            <EmptyDataTemplate>
                                <table class="gvdata" id="gvId" cellspacing="0" rules="all" border="0" cellpadding="0"
                                    style="border-collapse: collapse;">
                                    <tr class="header">
                                        <th>序号
                                        </th>
                                        <th>执行人
                                        </th>
                                          <th>未开始
                                        </th>
                                        <th>执行中
                                        </th>
                                         <th>已完成
                                        </th>
                                         <th>已关闭
                                        </th> 
                                        <th>总计
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
                                <asp:TemplateField HeaderText="责任人" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                           <%# Eval("v_xm")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="未开始" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                           <%# Eval("status1")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="执行中" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("status2") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="已完成" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("status3") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已关闭" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("status4") %>
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
