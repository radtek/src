<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectTreasury.aspx.cs" Inherits="Common_SelectTreasury" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择仓库</title>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
        <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
   <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>

    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/icon.css" />
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/jquery.easyui.extension.css" />

    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="/Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript">
        var tcode = "";
        var tflag = "";
        $(document).ready(function () {
            var data = eval($('#hfldTreasuryJson').val());
            $('#treasury_tree').tree({
                data: data,
                onClick: function (node) {
                    $('#hfldTreasuryId').val(node.id);
                    $('#hfldTreasuryName').val(node.text);
                },
                onDblClick: save
            });
        });
        
        // 保存
        function save() {
            var id = $('#hfldTreasuryId').val();
            var name = $('#hfldTreasuryName').val();
            getTreasuryInfo(id);
            if (!validate(id)) {
                return false;
            } else {
                if (tflag == '1') {
                    var index = name.lastIndexOf("(总库)");
                    name = name.substring(0, index);
                }
                parent.$('#hfldTrea').val(tcode);
                parent.$('#txtTrea').val(name);
                page_close();
            }
        }
            //if (trea.tflag == '1') {
            //    var index = name.lastIndexOf("(总库)");
            //    name = name.substring(0, index);
            //}
            //parent.$('#hfldTrea').val(trea.tcode);
            //parent.$('#txtTrea').val(name);
           
           
       
        //注意：parent 是 JS 自带的全局对象，可用于操作父页面
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        // 关闭
        function page_close() {
            parent.layer.close(index);
        }


        // 查找仓库信息
        function getTrea(id) {
           
            var trea = null;
            var url = '../SmTreasuryService.svc/Treasury/' + id;
            $.ajax({
                url: url,
                contenttype: 'application/json',
                async: false,
                success: function (data) {
                    trea = data;
                },
                error: function (ex) { alert(JSON.stringify(ex)); }
            });
            return trea;
        }

        // 验证
        function validate(id) {
            if (jw.getRequestParam('module') == 'import') {
                // 入库
                if ($('#hfldDepotType').val() == '0') {
                    // 平行模式
                } else {
                    // 总分模式
                    //var trea = getTrea(id);
                    //if (trea.tflag == '1') {
                    //    //top.ui.alert('总分模式下，总库不能入库');
                    //    alert('总分模式下，总库不能入库');
                    //    return false;
                    //}
                    if (tflag == '1') {
                        alert('总分模式下，总库不能入库');
                        return false;
                    }
                }
            }
            return true;
        }
        function getTreasuryInfo(id) {
            $.ajax({
                type: "POST",
                url: "/WeChat/Ajax/AjaxGetMsg.aspx/getTreasuryInfo",
                data: "{id: '" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function Success(data) {
                    if (data.d != "" && data.d != "0") {
                         tcode = data.d.split(',')[0];
                         tflag = data.d.split(',')[1];
                    }
                    else {
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 420px; overflow: auto;">
            <ul id="treasury_tree">
            </ul>
        </div>
        <div style="padding-top: 10px; padding-right: 20px; text-align: right;">
            <input type="button" value="确定" onclick="save();" />
            <input type="button" value="取消" onclick="page_close()" />
        </div>
        <asp:HiddenField ID="hfldTreasuryJson" runat="server" />
        <asp:HiddenField ID="hfldTreasuryId" runat="server" />
        <asp:HiddenField ID="hfldTreasuryName" runat="server" />
        <!-- 仓库模式-->
        <asp:HiddenField ID="hfldDepotType" runat="server" />
    </form>
</body>
</html>
