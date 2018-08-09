<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectFrame.aspx.cs" Inherits="StockManage_ProjectFrame" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/icon.css" />
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/jquery.easyui.extension.css" />

     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />

   <%-- <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>--%>

     <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="/Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="/Script/ProjectTree.js" charset="UTF-8"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.layout-split-west').hide();
            $('.layout-panel-center').css({ "left": "0px", "width": "100%" });
            $('.panel-body-noheader').css({ "width": "100%" });
        });
        function ifshow() {
            if ($('.layout-split-west').is(':hidden')) {
                $('.layout-split-west').show();
                // $("#btnSelect").hide();
                $('.layout-panel-west').css({ "width": "100%" });
            }
            else {
                $('.layout-split-west').hide();
                //$("#btnSelect").show();
            }
        }
    </script>
</head>
<body class="easyui-layout" >
    <form id="form1" style="overflow: hidden" runat="server">
        <div data-options="region:'west',split:true,title:''" style="width: 250px; padding: 10px;width: 100%;">
            <asp:DropDownList ID="dropYear" AutoPostBack="true" OnSelectedIndexChanged="dropYear_SelectedIndexChanged" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtPjr" Width="90px" runat="server"></asp:TextBox>
            <asp:Button ID="btnQuery" Text="查询" Width="40px" UseSubmitBehavior="true" OnClick="btnQuery_Click" runat="server" />
             <input type="button" id="btnSelect2" value="确认选择" style="width:auto" onclick="ifshow();" />
            <ul id="prj_tree">
            </ul>
        </div>
        <div data-options="region:'center',title:''" >
             <input type="button" id="btnSelect" value="更换项目" style="width:auto" onclick="ifshow();" />
            <iframe id="ifram" frameborder="0" width="100%" height="98%" runat="server"></iframe>
        </div>
        <asp:HiddenField ID="hfldStateType" Value="1" runat="server" />
        <asp:HiddenField ID="hfldProjectJson" runat="server" />
        <asp:HiddenField ID="hfldSubUrl" runat="server" />
        <asp:HiddenField ID="hfldContainsOrg" Value="0" runat="server" />
    </form>
</body>
</html>
