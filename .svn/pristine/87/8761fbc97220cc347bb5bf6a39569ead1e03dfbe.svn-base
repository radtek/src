<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="SysSet_edit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Script/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.mouse.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.draggable.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.position.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.resizable.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.dialog.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="/Script/jwJson.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/StockManage/script/Validation.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <title></title>
<script type="text/javascript">
        function successed() {
            top.ui.show('保存成功');
            top.ui.closeWin();
            top.ui.callback();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 100%; overflow: auto; width: 100%">
            <div id="mTable" style="margin-top: 5px; vertical-align: top;">
                <div style="vertical-align: top;">
                    <table class="tableContent2" style="vertical-align: middle; width: 100%">
                        <tr>
                            <td style="text-align: right;">参数说明
                            </td>
                            <td style="text-align: left" class="auto-style2">
                                <asp:TextBox ID="Note" Height="100%" Width="99%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">参数名称
                            </td>
                            <td style="text-align: left" class="auto-style2">
                                <asp:TextBox ID="ParaName" Height="100%" Width="99%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">参数数值
                            </td>
                            <td style="text-align: left" class="auto-style2">
                                <asp:TextBox ID="ParaValue" Height="100%" Width="99%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="divFooter2">
            <table class="tableFooter2">
                <tr>
                    <td>
                        <input id="btnSave" name="submit" type="submit" value="保存" style="width: auto; height: 21px;" onserverclick="btnSave_Click" runat="server" />
                        <input type="button" id="btnCancel" value="取消" onclick="top.ui.closeWin();" />
                    </td>
                </tr>
            </table>
        </div>
        <input type="hidden" id="KeyId" runat="server" />
    </form>
</body>
</html>

