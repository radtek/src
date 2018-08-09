<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxSet.aspx.cs" Inherits="WxSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<head runat="server">
<title>参数配置</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="pagediv" style="height: 49%; border-bottom: solid 2px #CADEED;">
            <table class="gvdata" style="width: 100%; margin: auto;border-collapse: collapse;" border="1">
                <tr>
                    <td style="text-align: left;font-weight: bold;color: #6384dd;" colspan="2">企业号相关参数配置</td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 150px">可信域名
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="domain" runat="server" placeholder="请输入可信域名" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">corpId
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="corpId" runat="server" placeholder="请输入corpId" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;" class="auto-style1">corpSecret
                    </td>
                    <td style="text-align: left;" class="auto-style2">
                        <asp:TextBox ID="corpSecret" runat="server" placeholder="请输入corpSecret" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color: #e0ecff;">
                    <td style="text-align: left;" colspan="2">通讯录</td>
                </tr>
                <tr>
                    <td style="text-align: right;">Secret
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="Secret_txl" runat="server" placeholder="请输入 Secret" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color: #e0ecff;">
                    <td style="text-align: left;" colspan="2">工作日志</td>
                </tr>
                <tr>
                    <td style="text-align: right;">AgentId
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="AgentId_log" runat="server" placeholder="请输入 AgentId" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">Secret
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="Secret_log" runat="server" placeholder="请输入 Secret" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color: #e0ecff;">
                    <td style="text-align: left;" colspan="2">工作任务</td>
                </tr>
                <tr>
                    <td style="text-align: right;">AgentId
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="AgentId_task" runat="server" placeholder="请输入 AgentId" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">Secret
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="Secret_task" runat="server" placeholder="请输入 Secret" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color: #e0ecff;">
                    <td style="text-align: left;" colspan="2">工程文档</td>
                </tr>
                <tr>
                    <td style="text-align: right;">AgentId
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="AgentId_doc" runat="server" placeholder="请输入 AgentId" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">Secret
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="Secret_doc" runat="server" placeholder="请输入 Secret" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color: #e0ecff;">
                    <td style="text-align: left;" colspan="2">库存信息</td>
                </tr>
                <tr>
                    <td style="text-align: right;">AgentId
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="AgentId_Treasury" runat="server" placeholder="请输入 AgentId" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">Secret
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="Secret_Treasury" runat="server" placeholder="请输入 Secret" Width="600px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="background-color: #e0ecff;">
                    <td style="text-align: left;font-weight: bold;color: #6384dd;" colspan="2">工作日志参数配置</td>
                </tr>
                <tr>
                    <td style="text-align: right;" class="auto-style1">日志填写时,</br>是否做时间重复检查
                    </td>
                    <td style="text-align: left;" class="auto-style2">
                        <asp:RadioButtonList ID="journalIfCheckTime" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;" class="auto-style1">日志查阅时,</br>是否开启评分功能
                    </td>
                    <td style="text-align: left;" class="auto-style2">
                        <asp:RadioButtonList ID="journalIfScore" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr style="background-color: #e0ecff;">
                    <td style="text-align: left;font-weight: bold;color: #6384dd;" colspan="2">人工费用报表参数</td>
                </tr>
                <tr>
                    <td style="text-align: right;">日工作小时(小时)
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="workHours" runat="server" placeholder="请输入 日工作小时" Width="100px"></asp:TextBox>
                        请填写数字</td>
                </tr>
                <tr>
                    <td style="text-align: right;">月工作天数(天)
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="workDays" runat="server" placeholder="请输入 月工作日数" Width="100px"></asp:TextBox>
                        请填写数字</td>
                </tr>
                   <tr>
                    <td style="text-align: right;" class="auto-style1">需求时，是否可超预算 
                    </td>
                    <td style="text-align: left;" class="auto-style2">
                        <asp:RadioButtonList ID="ifMoreBudget" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right;">
                        <asp:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <%--  <div class="pagediv" style="height: 49%; border-bottom: solid 2px #CADEED;">
            <table class="gvdata" cellspacing="0px" border="1px" style="width: 100%; margin: auto; border-collapse: collapse;">
                <tr>
                    <td colspan="2" style="text-align: left;">
                        <asp:Button ID="btnToBD" Text="同步通讯录(同步到本地)" runat="server" OnClick="btnToBD_Click" />
                    </td>
                    <td colspan="2" style="text-align: left;">
                        <asp:Button ID="btnToWX" Text="同步通讯录(同步到微信)" runat="server" OnClick="btnToWX_Click" />
                    </td>
                </tr>
            </table>
        </div>--%>
    </form>
</body>
</html>
