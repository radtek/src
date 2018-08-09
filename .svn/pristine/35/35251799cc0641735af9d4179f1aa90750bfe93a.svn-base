<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuPowerFream.aspx.cs" Inherits="OA3_FileMsg_MenuPowerFream" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
          <table width="100%" style="height: 100%;" cellpadding="0" cellspacing="0">
            <tr>
                <td rowspan="2" style="width: 180px; height: 100%; vertical-align: top; border-right: solid 1px #AAAAAA;">
                    <div id="departmentDiv" style="width: 180px; height: 100%; border: solid 0px red; overflow: auto;">
                        <asp:TreeView ID="tvFile" ExpandDepth="1" ShowLines="true" OnSelectedNodeChanged="tvFile_SelectedNodeChanged" runat="server">
                            <NodeStyle HorizontalPadding="5px" />
                            <SelectedNodeStyle HorizontalPadding="5px" BackColor="#3399FF" ForeColor="White" />
                        </asp:TreeView>
                    </div>
                </td>
                <td valign="top" style="height: 100%;">
                     <iframe id="iframe1" width="100%" height="100%" frameborder="0" src="DocList.aspx?hid=" runat="server"></iframe>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
