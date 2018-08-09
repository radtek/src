<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocRelation.aspx.cs" Inherits="OA3_FileMsg_UserControl_DocRelation" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>选择关联文档</title>
    <link type="text/css" rel="Stylesheet" href="../../../Script/jquery.tooltip/jquery.tooltip.css" />
	<script type="text/javascript" src="/../Script/jquery.js"></script>
	<script type="text/javascript" src="../../../StockManage/script/Config2.js"></script>
	<script type="text/javascript" src="../../../StockManage/script/JustWinTable.js"></script>
	<script type="text/javascript" src="../../../Script/jquery.tooltip/jquery.tooltip.js"></script>
	<script type="text/javascript" src="../../../Script/jw.js"></script>
     <script language="Javascript" type="text/javascript">
        $(document).ready(function () {
            // 添加验证
            var table = new JustWinTable('gvFile');
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
                <tr style="vertical-align: top">
                    <td style="width: 100%;">
                        <div class="pagediv" style="">
                            <asp:GridView ID="gvFile" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvFile_RowDataBound" DataKeyNames="Id" runat="server">
                                <Columns>
                                       <%--  <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbAllBox" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbBox" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#Eval("pageindex") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            文档类型
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <center><%# Eval("DocTypeName").ToString()%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            文档状态
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <center><%# Eval("DocStatusName").ToString()%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            文档版本
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <center><%# Eval("DocVersionName").ToString()%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            文档编码
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("DocCode").ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="250px">
                                        <HeaderTemplate>
                                            文档名称
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <span class="al tooltip" title='<%# Eval("FileName").ToString() %>'">
                                                <%# StringUtility.GetStr(Eval("FileName").ToString(), 20) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="创建人">
                                        <ItemTemplate>
                                            <center><%# Eval("v_xm").ToString()%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="70px">
                                        <HeaderTemplate>
                                            更新时间
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <center><%# System.Convert.ToDateTime(Eval("DocEditDate")).ToString("yyyy-MM-dd HH:mm") %></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            文档属性
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <center><%# Eval("DocAttributeName").ToString()%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="流程状态" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <center><%# Common2.GetStateNullString(Eval("FlowStatusName").ToString()) %></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="rowa"></RowStyle>
                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
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
            <input id="btnSave" type="button" class="button-normal" value="确 定" disabled="disabled"  onclick="saveEvent();" />
            <input id="btnCancel" type="button" value="取 消" class="button-normal" onclick="top.ui.closeWin();" />
        </div>
        <asp:HiddenField ID="Hid" runat="server" />
        <asp:HiddenField ID="Hname" runat="server" />
    </form>
</body>
</html>
