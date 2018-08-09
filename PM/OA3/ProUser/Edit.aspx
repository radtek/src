<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="OA3_ProUser_Edit" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>EditLinkman</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />

    <script type="text/javascript" src="../../../Script/jquery.js"></script>
    <script type="text/javascript" src="../../../Script/jw.js"></script>
    <JWControl:JavaScriptControl ID="js" runat="server"></JWControl:JavaScriptControl>
    <script type="text/javascript">
        function successed() {
            top.ui.show('保存成功');
            top.ui.closeWin();
            top.ui.callback();
            //var url = { "url": "/OA3/ProUser/List.aspx?PrjGuid=" + $("#PrjGuid").val() };
            //top.ui.reloadTab(url);
        }
    </script>
</head>
<body class="body_clear" scroll="no">
    <form id="Form1" runat="server">
       <div style="padding: 15PX;">
            <table class="table-normal" id="Table1" cellspacing="1" cellpadding="1" width="100%" align="center" border="1" runat="server" style="border: 1px solid #95b8e7;">
                <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">姓名：
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="xm" MaxLength="10" runat="server" style="width: auto;height: auto;"></asp:TextBox><asp:RequiredFieldValidator ID="rfvName" ControlToValidate="xm" ErrorMessage="RequiredFieldValidator" runat="server">必填</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">性别：
                    </td>
                    <td runat="server">
                        <asp:RadioButtonList ID="sex" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="m" Selected="true" Text="男" />
                            <asp:ListItem Value="f" Text="女" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                
                  <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">分组：
                    </td>
                    <td runat="server">
                        <asp:DropDownList ID="group" Width="138px"  runat="server"></asp:DropDownList>
                    </td>
                </tr><tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">类型：
                    </td>
                    <td runat="server">
                        <asp:DropDownList ID="type" Width="138px"  runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">序号：
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="sort" MaxLength="6" runat="server"  style="width: auto;height: auto;"></asp:TextBox><input id="hdnSerial" type="hidden" name="Hidden1" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="数字,且小于5位" ControlToValidate="sort" ValidationExpression="\d{1,4}" runat="server"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" id="zhiwu" runat="server">电话
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="tel" MaxLength="20" runat="server"  style="width: auto;height: auto;"></asp:TextBox>
                    </td>
                </tr>
                <tr height="25" runat="server">
                    <td style="width: 127px; height: 25px;text-align: right;" runat="server">手机：
                    </td>
                    <td style="height: 25px" runat="server">
                        <asp:TextBox ID="phone" MaxLength="20" runat="server" style="width: auto;height: auto;"></asp:TextBox>
                    </td>
                </tr>
               
                <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">邮箱:
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="mail" MaxLength="20" runat="server" style="width: auto;height: auto;"></asp:TextBox><asp:RegularExpressionValidator ID="revEmail" ControlToValidate="mail" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server">不合法</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">QQ:
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="qq" MaxLength="15" runat="server" style="width: auto;height: auto;"></asp:TextBox>
                    </td>
                </tr>
                 <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">微信:
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="wx" MaxLength="15" runat="server" style="width: auto;height: auto;"></asp:TextBox>
                    </td>
                </tr> <tr height="25" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">地址：
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="ads" MaxLength="20" runat="server" style="width: auto;height: auto;"></asp:TextBox>
                    </td>
                </tr>
                <tr height="70" runat="server">
                    <td style="width: 127px;text-align: right;" runat="server">备注：
                    </td>
                    <td runat="server">
                        <asp:TextBox ID="remark" Width="272px" Height="76px" TextMode="MultiLine" MaxLength="50" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr height="25" runat="server" id="btns">
                    <td colspan="2" align="center" class="td-submit" runat="server">
                        <asp:Button ID="btnSave" Text=" 确 定 " CssClass="button-normal" OnClick="btnSave_Click" runat="server" />&nbsp;
                        <input id="btnClose" type="button" value=" 取 消 " class="button-normal" onclick="top.ui.closeWin();" runat="server" />
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="KeyId" runat="server" />
            <asp:HiddenField ID="PrjGuid" runat="server" />
           </div>
    </form>
</body>
</html>

