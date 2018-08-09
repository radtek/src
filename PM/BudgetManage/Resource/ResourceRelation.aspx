<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceRelation.aspx.cs" Inherits="ResourceRelation" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>组装材料</title>
    <link rel="stylesheet" type="text/css" href="../../Script/lightbox/jquery.lightbox-0.5.css" media="screen" />
    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%; height: 100%;">
            <tr>
                <td style="width: 220px; vertical-align: top; height: 100%;">
                    <div class="pagediv" style="width: 220px; height: 105%;" id="div1" runat="server">
                        <asp:TreeView ID="tvResource" ShowLines="true" ExpandDepth="2" OnSelectedNodeChanged="TreeView_SelectedNodeChanged" runat="server">
                            <SelectedNodeStyle CssClass="trvw_select" />
                        </asp:TreeView>
                    </div>
                </td>
                <td style="width: 100%; vertical-align: top; height: 100%; border-left: solid 2px #CADEED;">
                    <iframe id="iframe1" width="100%" height="100%" frameborder="0" src="ResourceRelationDetail.aspx?id=" runat="server"></iframe>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
