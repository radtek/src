<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaticByXQ.aspx.cs" Inherits="StaticByXQ" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WF.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>需求计划执行情况统计</title>
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

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <table border="0" cellpadding="0" cellspacing="0" width="100%">

            <tr>
                <td style="text-align: left;" class="divFooter">
                   
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GvList" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GvList_RowDataBound" DataKeyNames="ResourceId" runat="server">
                            <EmptyDataTemplate>
                                <table class="gvdata" id="gvId" cellspacing="0" rules="all" border="0" cellpadding="0"
                                    style="border-collapse: collapse;">
                                    <tr class="header">
                                       <th>序号
                                        </th>
                                        <th>资源编号
                                        </th>
                                        <th>资源名称
                                        </th>
                                        <th>预算成本量
                                        </th>
                                        <th>已提需求量
                                        </th>
                                        <th>已出库量
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
                                <asp:TemplateField HeaderText="资源编号" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                           <%# Eval("scode")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="资源名称" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%# Eval("ResourceName") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="预算成本量" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("ResourceQuantity") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已提需求量" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("nums") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已出库量" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                     <%# Eval("outNums") %>
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
