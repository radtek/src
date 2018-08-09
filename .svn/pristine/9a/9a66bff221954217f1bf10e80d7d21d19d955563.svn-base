<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskRelation.aspx.cs" Inherits="TaskRelation" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>选择关联任务</title>
<%--    <link type="text/css" rel="Stylesheet" href="../../../Script/jquery.tooltip/jquery.tooltip.css" />
    <script type="text/javascript" src="/../Script/jquery.js"></script>
    <script type="text/javascript" src="../../../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="../../../StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../../Script/jw.js"></script>--%>

    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
        <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script language="Javascript" type="text/javascript">
        $(document).ready(function () {
            // 添加验证
            var table = new JustWinTable('GvList');
            registerConTypeClickListener(table);        //注册单击事件
            registerConTypeDbClickListener(table);      //注册双击事件
            jw.tooltip();
            $('#btnSave').click(function () {
                saveEvent();
            });
            showTooltip('tooltip', 15);
        });
        //注册单击事件
        function registerConTypeClickListener(jwTable) {
            jwTable.registClickTrListener(function () {
                var id = this.id;
                var name = $(this).attr('name')
                setHd(id, name);
            });
        }
        //注册双击事件
        function registerConTypeDbClickListener(jwTable) {
            jwTable.registDbClickListener(function () {
                saveEvent();
            });
        }
        function setHd(theId, theName) {
            $('#Hid').val(theId);
            $('#Hname').val(theName);
            document.getElementById("btnSave").disabled = false;
        }
        function saveEvent() {
            if (typeof top.ui.callback == 'function') {
                var con = {};
                con.id = $('#Hid').val();
                con.name = $('#Hname').val();

                top.ui.callback(con);
                top.ui.callback = null;
            }
            top.ui.closeWin();
        }
        //双击获得信息
        function doDblClickRow(ContCode) {
            $('#btnSave').click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divContent">
            <table class="tableContent" cellpadding="2px" cellspacing="0" style="margin-left: auto;">
                 <tr>
                <td style="vertical-align: top;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr>
                            <td class="descTd" style="white-space: nowrap;">任务状态
                            </td>
                            <td>
                                <asp:DropDownList ID="status" Width="100%" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <%--<asp:ListItem Value="0">草稿中</asp:ListItem>--%>
                                    <asp:ListItem Value="1">未开始</asp:ListItem>
                                     <asp:ListItem Value="2">执行中</asp:ListItem>
                                   <%--  <asp:ListItem Value="3">已完成</asp:ListItem>
                                    <asp:ListItem Value="4">已关闭</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">任务类型
                            </td>
                            <td>
                                <asp:DropDownList ID="type_id" Width="100%" runat="server"></asp:DropDownList>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">任务名称
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                           <%-- <td class="descTd" style="white-space: nowrap;">执行人
                            </td>
                            <td>
                                 <span class="spanSelect" style="width: 100%">
                                    <asp:TextBox ID="txtTo" Style="width: 70%; height: 15px; border: none; line-height: 16px; margin: 1px 2px"
                                        runat="server"></asp:TextBox>
                                    <img src="../../images/icon_17.bmp" style="float: right; border: none;" alt="选择" id="imgName" onclick="jw.selectMultiUser({ nameinput: 'txtTo', codeinput: 'hfldTo' });" runat="server" />

                                </span>
                                <input id="hfldTo" type="hidden" style="width: 1px" runat="server" />
                            </td>--%>
                        </tr>
                        <tr>
                            <td class="descTd" style="white-space: nowrap;">任务日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" style="width: 120px;"  CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" style="width: 120px;"  CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">创建时间
                            </td>
                            <td>
                                <asp:TextBox ID="stime"  style="width: 120px;" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>
                            <td class="descTd" style="white-space: nowrap;">至
                            </td>
                            <td>
                                <asp:TextBox ID="etime"  style="width: 120px;" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnQuery" Text="查询" OnClick="btnQuery_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
                <tr style="vertical-align: top">
                    <td style="width: 100%;">
                        <div class="pagediv" style="">
                            <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="Id" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="序号">
                                        <ItemTemplate>
                                            <%#Eval("pageindex") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="任务状态">
                                        <ItemTemplate>
                                            <center><%# Eval("status_name").ToString()%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="任务类型">
                                        <ItemTemplate>
                                            <center><%# Eval("typeName").ToString() %></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="执行人" HeaderStyle-Width="80px" Visible="false">
                                        <ItemTemplate>
                                            <%#Eval("syr") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="任务进度(%)">
                                        <ItemTemplate>
                                            <%#Eval("progress").ToString() %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="任务名称">
                                        <ItemTemplate>
                                                <%#Eval("title").ToString() %>
                                            <%--<span class="tooltip" style="cursor: pointer;" title="<%# Eval("title") %>" onclick="toolbox_oncommand('/OA3/WorkTask/TaskView.aspx?action=view&id=<%# Eval("id") %>','查看工作任务')">
                                                <asp:HyperLink ID="HyperLink1" Text=' <%# StringUtility.GetStr(Eval("title").ToString(), 20) %> ' runat="server" Style="color: Blue;"></asp:HyperLink>
                                            </span>--%>
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
                                    <asp:TemplateField HeaderText="开始时间" Visible="false">
                                        <ItemTemplate>
                                            <center><%# System.Convert.ToDateTime(Eval("start_time")).ToString("HH:mm") %></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="结束时间" Visible="false">
                                        <ItemTemplate>
                                            <center><%# System.Convert.ToDateTime(Eval("end_time")).ToString("HH:mm") %></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="持续(分钟)">
                                        <ItemTemplate>
                                            <center><%#Eval("longs") %></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="任务内容" HeaderStyle-Width="280px" Visible="false">
                                        <ItemTemplate>
                                            <span class="tooltip" title="<%# Eval("content") %>">
                                                <%# StringUtility.GetStr(Eval("content").ToString(), 30) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="完成/关闭时间" Visible="false">
                                        <ItemTemplate>
                                            <center><%# (Eval("complete_time").ToString() == "") ? "": System.Convert.ToDateTime(Eval("complete_time")).ToString("yyyy-MM-dd HH:mm")%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="创建时间">
                                        <ItemTemplate>
                                            <center><%# System.Convert.ToDateTime(Eval("create_time")).ToString("yyyy-MM-dd HH:mm") %></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="相关人" HeaderStyle-Width="180px" Visible="false">
                                        <ItemTemplate>
                                            <span class="tooltip" title="<%# Eval("xgr") %>">
                                                <%# StringUtility.GetStr(Eval("xgr").ToString(), 20) %> 
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
                            <asp:Label ID="lblMsgAleave" Text="" runat="server"></asp:Label>
                            <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" ShowPageIndexBox="Always" UrlPaging="false" PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" SubmitButtonText="确定" SubmitButtonStyle="width:40px; vertical-align:top;" TextAfterPageIndexBox="页" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                            </webdiyer:AspNetPager>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: right">
            <input id="btnSave" type="button" class="button-normal" value="确 定" disabled="disabled" onclick="saveEvent();" />
            <input id="btnCancel" type="button" value="取 消" class="button-normal" onclick="top.ui.closeWin();" />
        </div>
        <asp:HiddenField ID="Hid" runat="server" />
        <asp:HiddenField ID="Hname" runat="server" />
    </form>
</body>
</html>
