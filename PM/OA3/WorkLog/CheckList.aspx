<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckList.aspx.cs" Inherits="OA3_WorkLog_CheckList" %>

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

        //function add() {
        //    top.ui._Journal = window;
        //    var url = '/OA3/WorkLog/MyLogEdit.aspx?action=add';
        //    title = '新增工作日志';
        //    this.location.href = url;
        //    //toolbox_oncommand(url, title);
        //    //top.ui.openWin({ title: title, url: url });
        //}
        //function edit() {
        //    top.ui._Journal = window;
        //    var url = '/OA3/WorkLog/MyLogEdit.aspx?action=edit&id=' + document.getElementById('KeyId').value;
        //    title = '编辑工作日志';
        //    this.location.href = url;
        //}
        function view() {
            top.ui._Journal = window;
            var url = "/OA3/WorkLog/CheckView.aspx?action=view&id=" + document.getElementById('KeyId').value;
            title = '查看工作日志';
            toolbox_oncommand(url, title);
        }
        function rowClick(id, IsOk, count) {
            document.getElementById('KeyId').value = id;
        }
        function viewInfo(id) {
            top.ui._Journal = window;
            var url = '/OA3/WorkLog/CheckView.aspx?action=view&id=' + id;
            title = '查看工作日志';
            toolbox_oncommand(url, title);
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
<%--                    <table class="queryTable">
                        <tr>
                            <td class="descTd" style="white-space: nowrap;display:none;">日志状态
                            </td>
                            <td style="display:none;">
                                <asp:DropDownList ID="status" Width="100%" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem Value="0">草  稿</asp:ListItem>
                                    <asp:ListItem Value="1">已提交</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">日志标题
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">日志类型
                            </td>
                            <td>
                                <asp:DropDownList ID="type_id" Width="100%" runat="server"></asp:DropDownList>
                            </td>

                            <td class="descTd" style="white-space: nowrap;">日志日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Style="width: 110px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Style="width: 110px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" runat="server"></asp:TextBox>
                            </td>

                             <td class="descTd" style="white-space: nowrap;">填写时间
                            </td>
                            <td>
                                <asp:TextBox ID="stime" Style="width: 110px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                            <td>
                                <asp:TextBox ID="etime" Style="width: 110px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>
                            <td style="white-space: nowrap;"></td>
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
                            <td>
                                <asp:Button ID="btnQuery" Text="查询" OnClick="btnQuery_Click" runat="server" />
                            </td>
                        </tr>
                    </table>--%>
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
            <tr>
                <td style="text-align: left;" class="divFooter">
                    <div style="display:none">
                    <input type="button" id="btnAdd" value="新增" />
                    <input type="button" id="btnEdit" value="编辑" disabled="disabled" />
                    <asp:Button ID="btnDel" Text="删除" Enabled="false" OnClick="btnDel_Click" runat="server" />
                     </div>
                   <%-- <input type="button" id="btnView" value="查阅" OnClick="view()"/>--%>
                   <asp:Button ID="btnExecl" CssClass="button-normal" Text="导出Excel" Width="80px" OnClick="btnExecl_Click" runat="server" />
                    <div style="float: right;">颜色说明：
                        <label style="color: red;">
                            跨天日志：红色；</label>
                        <label style="color: green;">
                            加班日志：绿色；</label>
                        <label style="color: orange;">
                            同时跨天、加班：橙色；</label>
                    </div>

                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="Id,ifck,ifkt,ifjb" runat="server">
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
                               <%-- <asp:TemplateField HeaderText="日志状态" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                         <center><%# (Eval("status").ToString() == "0") ? "草稿中": "已提交" %></center>
                                    </ItemTemplate>
                                </asp:TemplateField> --%> 
                                <asp:TemplateField HeaderText="日志类型" HeaderStyle-Width="80px">
                                    <ItemTemplate><asp:Label ID="typeName" Width="100%" runat="server">
                                           <%# Eval("typeName").ToString() %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="提交人" HeaderStyle-Width="80px">
                                    <ItemTemplate>  
                                        <asp:Label ID="v_xm" Width="100%" runat="server">
                                        <%#Eval("v_xm") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                                <asp:TemplateField HeaderText="日志标题" HeaderStyle-Width="180px">
                                    <ItemTemplate> 
                                            <span class="tooltip" title="<%# Eval("title") %>">
                                            <asp:HyperLink ID="HyperLink1" Text=' <%# StringUtility.GetStr(Eval("title").ToString(), 20) %> ' runat="server"></asp:HyperLink>
                                        </span>
                                      <%--  <asp:Label ID="title" Width="100%" onclick="viewInfo(<%# Eval("id") %>)" runat="server">
                                        <%#Eval("title") %></asp:Label>--%>

                                       <%-- <span class="tooltip" id="title" title="<%# Eval("title") %>"  runat="server">
                                              <%# StringUtility.GetStr(Eval("title").ToString(), 15) %> 
                                       </span>--%>
                                       <%--  <asp:Label class="tooltip" id="title" title="<%# Eval("title") %>" onclick="viewInfo('<%# Eval("id") %>')" runat="server">  --%>
                                              <%--<%# StringUtility.GetStr(Eval("title").ToString(), 15) %> --%>
                                        <%-- </asp:Label>--%>

                                       <%-- <asp:Label ID="title" class="al" Width="100%" runat="server" onclick="viewInfo('<%#Eval("Id")%>');">
                                         <%# StringUtility.GetStr(Eval("title").ToString(), 15) %> 
                                        </asp:Label>--%>
                                       <%-- <span class="al" onclick="viewInfo('<%# Eval("id") %>')" id="title">
													
												</span>--%>
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
                                   <asp:TemplateField HeaderText="是否跨天" Visible="false">
                                    <ItemTemplate>
                                          <asp:Label ID="ifkt" Width="100%" runat="server">
                                        <%# (Eval("ifkt").ToString() == "0") ? "<span style='color:red;'>否</span>": "<span style='color:green;'>是</span>" %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否加班" Visible="false">
                                    <ItemTemplate>
                                          <asp:Label ID="ifjb" Width="100%" runat="server">
                                        <%# (Eval("ifjb").ToString() == "0") ? "<span style='color:red;'>否</span>": "<span style='color:green;'>是</span>" %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日志内容" HeaderStyle-Width="200px" Visible="false">
                                    <ItemTemplate>
                                        <span class="tooltip" title="<%# Eval("content") %>" >
                                         
                                        <asp:Label ID="content" Width="100%" runat="server">
                                            <%# StringUtility.GetStr(Eval("content").ToString(), 30) %>
                                        </asp:Label> 
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="填写时间">
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("create_date")).ToString("yyyy-MM-dd HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审阅人">
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
                          <asp:TemplateField HeaderText="是否已读" Visible="false">
                                    <ItemTemplate>
                                          <asp:Label ID="ifck" Width="100%" runat="server">
                                        <%# (Eval("ifck").ToString() == "0") ? "未读": "已读" %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <%--  <asp:TemplateField HeaderText="评论总数" >
                                    <ItemTemplate>
                                     <%#Eval("plAll") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="最新评论数" >
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
    </form>
</body>
</html>
