<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckList.aspx.cs" Inherits="OA3_WorkTask_CheckList" %>

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
            var jwtable = new JustWinTable('GvList');
            replaceEmptyTable('gvId', 'GvList');
            showTooltip('tooltip', 15);
        });
        function rowClick(id, IsOk, count) {
            document.getElementById('KeyId').value = id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="vertical-align: top;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr>
                            <td class="descTd" style="white-space: nowrap;">任务状态
                            </td>
                            <td>
                                <asp:DropDownList ID="status" Width="100%" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="0">草  稿</asp:ListItem>
                                    <asp:ListItem Value="1">已提交</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">任务类型
                            </td>
                            <td>
                                <asp:DropDownList ID="type_id" Width="100%" runat="server"></asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">任务标题
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">任务名称
                            </td>
                            <td>
                                <asp:TextBox ID="taskName" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd" style="white-space: nowrap;">任务日期
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
            <tr>
                <td style="text-align: left;" class="divFooter">
                    <asp:Button ID="btnExecl" CssClass="button-normal" Text="导出Excel" Width="80px" OnClick="btnExecl_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
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
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%#Eval("pageindex") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="任务状态" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <center><%# Eval("status_name").ToString()%></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="任务类型" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <center><%# Eval("typeName").ToString() %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="执行人" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%#Eval("syr") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="任务名称">
                                   <%-- <ItemTemplate>
                                        <span class="al tooltip" title='<%# Eval("title").ToString() %>' onclick="toolbox_oncommand('/OA3/WorkTask/CheckView.aspx?action=view&id=<%# Eval("id") %>','查看工作任务')">
                                            <%# StringUtility.GetStr(Eval("title").ToString(), 20) %>
                                        </span>
                                    </ItemTemplate>--%>
                                     <ItemTemplate> 
                                         <span class="tooltip" style="cursor: pointer;" title="<%# Eval("title") %>" onclick="toolbox_oncommand('/OA3/WorkTask/CheckView.aspx?action=view&id=<%# Eval("id") %>','查看工作任务')">
                                          <asp:HyperLink ID="HyperLink1" Text=' <%# StringUtility.GetStr(Eval("title").ToString(), 20) %> ' runat="server"  style="color: Blue;"></asp:HyperLink>
                                       </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="任务优先级" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <center><%# Eval("CodeName").ToString() %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="任务日期">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("start_time")).ToString("yyyy-MM-dd") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开始时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("start_time")).ToString("HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="结束时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("end_time")).ToString("HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="持续(分钟)">
                                    <ItemTemplate>
                                        <center><%#Eval("longs") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="任务内容" HeaderStyle-Width="280px">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("content") %>">
                                            <%# StringUtility.GetStr(Eval("content").ToString(), 30) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="任务进度(%)">
                                    <ItemTemplate>
                                        <%#Eval("progress").ToString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="完成时间">
                                    <ItemTemplate>
                                        <%--<center><%# System.Convert.ToDateTime(Eval("complete_time")).ToString("yyyy-MM-dd HH:mm") %></center>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建人" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label ID="v_xm" Width="100%" runat="server">
                                        <%#Eval("v_xm") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("create_time")).ToString("yyyy-MM-dd HH:mm") %></center>
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
                                <%-- <asp:TemplateField HeaderText="回复总数">
                                    <ItemTemplate>
                                        <%#Eval("plAll") %>
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
    </form>
</body>
</html>
