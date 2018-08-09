<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocSign.aspx.cs" Inherits="OA3_FileMsg_DocSign_DocSign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />


    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="js/BootstrapMenu.min.js" type="text/javascript"></script>


    <script type="text/javascript" src="style/jquery.js"></script>
    <script type="text/javascript" src="style/jquery.mousewheel.min.js"></script>
    <script type="text/javascript" src="style/jquery.iviewer.js"></script>
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        //标注信息
        function signInfoAdd(name, x, y, id) {
            top.ui._DocSign = window;
            var url = "";
            if ($("#ReID").val() == "") {
                url = '/OA3/FileMsg/DocSign/SignEdit.aspx?action=add&name=' + name + '&x=' + x + '&y=' + y + '&id=' + id + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
                title = '添加标注';
            } else {
                url = '/OA3/FileMsg/DocSign/SignEdit.aspx?action=Reedit&name=' + name + '&x=' + x + '&y=' + y + '&id=' + $("#ReID").val() + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
                title = '重新标注';
            }
            top.ui.openWin({ title: title, url: url, width: 960 });
        }
        function signInfoReEdit(id) {
            $("#ReID").val(id);
            $("#ifOn").val(1);
        }
        function signInfoEdit(id) {
            top.ui._DocSign = window;
            var url = '/OA3/FileMsg/DocSign/SignEdit.aspx?action=edit&name=&x=&y=&id=' + id + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
            title = '编辑标注_' + $("#title" + id).val();
            top.ui.openWin({ title: title, url: url, width: 960 });
            //toolbox_oncommand(url, title);
        }
        function signInfoView(id) {
            top.ui._DocSign = window;
            var url = '/OA3/FileMsg/DocSign/SignView.aspx?action=edit&name=&x=&y=&id=' + id + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
            title = '查看标注_' + $("#title" + id).val();
            //toolbox_oncommand(url, title);
            top.ui.openWin({ title: title, url: url, width: 960 });
        }
    </script>
    <title>图纸标注</title>
    <script type="text/javascript">
        var points = [];
        var isLoading = 0;
        var pointsLength = points.length;
        var $ = jQuery;
        function changeMe(imgId, b, c, object) {
            var offset = object.imageToContainer(b, c);
            var percent = object.get_percent();
            var containerOffset = object.container.offset();

            offset.x += containerOffset.left;
            offset.y += containerOffset.top;

            var pointer = $(imgId + "_img");
            pointer.css('display', 'block');
            pointer.css('left', offset.x + 'px');
            pointer.css('top', offset.y + 'px');

            var pointer2 = $(imgId + "_span");
            pointer2.css('display', 'block');
            pointer2.css('left', offset.x + 'px');
            pointer2.css('top', offset.y + 'px');
        }
        function changeAll(object) {

            for (var i = 0; i < points.length; i++) {
                var imgId = "";
                if (points[i].hasOwnProperty("id")) {
                    imgId = "#" + points[i].id;
                } else {
                    imgId = "#sign" + (i + 1);
                }
                changeMe(imgId, points[i].x, points[i].y, object);
            }
        }
        //function addPoints(coords, object) {
        //    if ($("#ifOn").val() == "1") {
        //        var imgId = "sign" + (pointsLength + 1);
        //        points.push({ x: coords.x, y: coords.y });
        //        var img = "<img src=\"style/sign.png\" id=\"" + imgId + "_img\" class=\"pointerImg\"  onClick=\"signInfoView(" + (pointsLength + 1) + ");\"><span class=\"pointerSpan\" id=\"" + imgId + "_span\" onClick=\"signInfoView('" + (pointsLength + 1) + "');\">我的标注</span>";
        //        $("#sign").append(img);
        //        //addMarker(imgId + "_img", "我的标注" + imgId, coords.x, coords.y, (pointsLength + 1));
        //        addMarker("我的标注" + imgId, coords.x, coords.y, (pointsLength + 1));
        //        pointsLength++;
        //        changeAll(object);
        //        offPoint();
        //        signInfoAdd("我的标注" + imgId, coords.x, coords.y, (pointsLength + 1));
        //    }
        //}
        function addPoints(coords, object) {
            if ($("#ifOn").val() == "1") {
                var imgId = "sign" + (pointsLength + 1);
                signInfoAdd("我的标注" + imgId, coords.x, coords.y, (pointsLength + 1));

            }
        }
        var config = {
            index: 0
        };
        //function showInfo(id) {
        //    alert(id);
        //    var title = $("#title" + id).val();
        //    var remark = $("#remark" + id).val();
        //    alert(title + "," + remark);
        //}
        // 初始名称,x坐标, y坐标 ,标注id
        function addMarker(name, x, y, id) {
            //if (!name) {
            //    name = ;
            //}
            //$('<div class="marker" onclick="return false" id="marker' + imgId + '" data-id="' + imgId + '" title="' + name + '" style="left:' + (x - 50) + 'px;top:' + (y - 8) + 'px"><i></i><span>' + name + '</span><em></em></div>').appendTo($("#allmap"));
            //$("#items").append('<li id="li' + imgId + '" data-option="x:' + x + ',y:' + y + ',id:' + id + '"><input type="text" onchange="setMarkerValue(' + imgId + ',this.value)" id="markername' + imgId + '"  value="' + name + '" /> <span id="sp' + imgId + '">X：' + x + ' Y: ' + y + '</span> <a href="javascript:del(' + imgId + ')">删除</a></li>');
            $('<div class="marker" onclick="return false" id="marker' + id + '" data-id="' + id + '" title="' + name + '" style="left:' + (x - 50) + 'px;top:' + (y - 8) + 'px"><i></i><span>' + name + '</span><em></em></div>').appendTo($("#allmap"));
            $("#items").append('<li id="li' + id + '" data-option="x:' + x + ',y:' + y + ',id:' + id + "_img" + '"><input type="text" id="title' + id + '"  value="' + name + '" style="width:120px;" readonly/><input type="hidden"  id="remark' + id + '"  value=" " style="width:180px;" /><input type="hidden"  id="x' + id + '"  value="' + x + '" style="width:50px;"/><input type="hidden"  id="y' + id + '"  value="' + y + '" style="width:50px;"/>&nbsp;<a href="javascript:signInfoEdit(' + id + ')">编辑</a>&nbsp;<a href="javascript:signInfoView(' + id + ')">查看</a>&nbsp;<a href="javascript:del(' + id + ')">删除</a></li>');
        }
        function setMarkerValue(id, value) {

        }
        function del(id) {
            if (!confirm('确定删除选中的标注信息吗?')) {
                return false;
            }
            else {
                if (id.length > 20) {
                    $.ajax({
                        type: "POST",
                        url: "../DocSign/DocSign.aspx/delData",
                        data: "{id: '" + id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function Success(data) {
                            if (data.d != "") {
                                alert('删除成功!');
                                $('#li' + id).remove();
                                $("#" + id + "_img").remove();
                                $("#" + id + "_span").remove();
                            }
                            else {
                                alert('删除失败,请刷新重试!');
                            }
                        }
                    });
                }
                else {
                    $('#li' + id).remove();
                    $("#sign" + id + "_img").remove();
                    $("#sign" + id + "_span").remove();
                }
            }
        }
        $(function () {
            $("#items").append($("#liInfo").val());
            var str = $("#liPoint").val();
            if (str.length > 0) {
                var strs = new Array(); //定义一数组 
                strs = str.substring(0, str.length - 1).split(";"); //字符分割 
                for (i = 0; i < strs.length ; i++) {
                    points.push({ x: strs[i].split(",")[0], y: strs[i].split(",")[1], id: strs[i].split(",")[2], name: strs[i].split(",")[3], v_xm: strs[i].split(",")[4] });
                }
                isLoading = 1;
            } else {
                isLoading = 0;
            }
            pointsLength = points.length;

            $("#viewer1").iviewer({
                src: $("#DocPath").val(),
                onClick: function (coords) {
                    addPoints(coords, this);
                },
                onMouseMove: function (coords) {
                    //$('#status').html('You are in ('+coords.x.toFixed(1)+', '+coords.y.toFixed(1)+'). This is empty space');
                },
                onBeforeDrag: function (coords) {
                    //                        $('#pointer').css('display', 'none');
                    //                        return whereIam(coords.x, coords.y) ? false : true;
                },
                onZoom: function () {
                    changeAll(this);
                    if (isLoading == 1) {
                        loading(this);
                    }
                },
                onDrag: function () {
                    changeAll(this);
                    if (isLoading == 1) {
                        loading(this);
                    }
                },
                initCallback: function () {
                    this.container.context.iviewer = this;
                }
            });
        });
        function loading(object) {
            for (var i = 0; i < points.length; i++) {
                //var imgId = "sign" + (i + 1);
                // var img = "<img src=\"__TMPL__Public/resource/js/style/sign.png\" id=\"" + imgId + "_img\" class=\"pointerImg\"  onClick=\"showInfo(" + (i + 1) + ");\">";
                var img = "<div id=\"" + points[i].id + "\"><img src=\"style/sign.png\" id=\"" + points[i].id + "_img\" class=\"pointerImg\"  onClick=\"signInfoView('" + points[i].id + "');\"><span class=\"pointerSpan\" id=\"" + points[i].id + "_span\" onClick=\"signInfoView('" + points[i].id + "');\">" + points[i].name + "[" + points[i].v_xm + "]</span></div>";
                $("#sign").append(img);
                //addMarker(imgId + "_img", '', coords.x, coords.y, (pointsLength + 1));
                //pointsLength++;
                changeAll(object);
                //offPoint();
            }
            isLoading = 0;
        }
        function onPoint() {
            $("#ifOn").val(1);
            $('#signTxt').css('color', 'wheat');
        }
        function offPoint() {
            $("#ifOn").val(0);
            $('#signTxt').css('color', 'white');
        }
    </script>
    <style>
        html, body {
            height: 100%;
            padding: 0;
            margin: 0;
        }

        .viewer {
            height: 100%;
            position: relative;
            background-color: white;
        }

        .wrapper {
            /*margin-right: 280px;*/
            margin-top: 36px;
            position: absolute;
            top: 1px;
            left: 1px;
            bottom: 1px;
            right: 1px;
            overflow: hidden; /*for opera*/
        }

        .toolbar {
            border: 1px solid black;
            position: absolute;
            top: 1em;
            left: 1em;
            right: 1em;
            height: 3em;
        }

        .pointerSpan {
            position: absolute;
            overflow: hidden;
            border: 1px solid #95b8e7;
            padding: 1px;
            margin-left: 12px;
            margin-top: -18px;
            font-size: 10px;
            background-color: #ecf3ff;
            cursor: pointer;
        }

        .pointerImg {
            background-image: url('style/sign.png');
            /*width: 8px;
            height: 14px; background-position: -36px -22px;*/
            width: 18px;
            height: 26px;
            margin-top: -25px;
            margin-left: -8px;
            position: absolute;
            overflow: hidden;
            display: none;
            cursor: pointer;
        }

        .iviewer_common {
            position: absolute;
            bottom: 10px;
            border: 1px solid #000;
            height: 28px;
            z-index: 5000;
        }

        .iviewer_cursor {
            cursor: -moz-grab;
        }

        .iviewer_drag_cursor {
            cursor: -moz-grabbing;
        }

        .iviewer_button {
            width: 28px;
            cursor: pointer;
            background-position: center center;
            background-repeat: no-repeat;
        }

        .iviewer_zoom_in {
            left: 20px;
            background: url(style/iviewer.zoom_in.gif);
        }

        .iviewer_zoom_out {
            left: 55px;
            background: url(style/iviewer.zoom_out.gif);
        }

        .iviewer_zoom_zero {
            left: 90px;
            background: url(style/iviewer.zoom_zero.gif);
        }

        .iviewer_zoom_fit {
            left: 125px;
            background: url(style/iviewer.zoom_fit.gif);
        }

        .iviewer_zoom_status {
            left: 160px;
            font: 1em/28px Sans;
            color: #000;
            background-color: #fff;
            text-align: center;
            width: 60px;
        }

        .item ul li {
            float: right;
            margin-bottom: 5px;
            border-bottom: 1px solid #1e9fff;
        }

        .userTagPanl {
            float: right;
            display: inline;
            border-color: #1E9FFF;
            background-color: #1E9FFF;
            height: 28px;
            line-height: 28px;
            margin: 10px 10px 0 180px;
            padding: 0 5px;
            border: 1px solid #bcbcbc;
            color: #333;
            border-radius: 2px;
            font-weight: 400;
            cursor: pointer;
            text-decoration: none;
        }
    </style>

</head>
<body style="background-color: rgb(223, 232, 246); font: 12px tahoma, arial, helvetica, sans-serif;">

    <div style="position: absolute; width: 100%;">
        <form id="form1" runat="server">
            <table style="height: 100%; background-color: white;" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" style="height: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 100%; vertical-align: top;">
                                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                                        <tr><td>&nbsp;</td><td>&nbsp;</td>
                                            <td class="descTd" style="white-space: nowrap;">标注人:</td>
                                            <td>
                                                <asp:DropDownList ID="user_Id" Width="100%" runat="server"></asp:DropDownList>
                                            </td><td>&nbsp;</td><td>&nbsp;</td>
                                            <td class="descTd" style="white-space: nowrap;">标注时间:</td>
                                            <td>
                                                <asp:TextBox ID="txtStartTime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                                            </td><td>&nbsp;</td>
                                            <td class="descTd" style="white-space: nowrap;">至</td><td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtEndTime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server"></asp:TextBox>
                                            </td><td>&nbsp;</td><td>&nbsp;</td>
                                            <td>标注名称:</td>
                                            <td>
                                                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td><td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnQuery" Text="查询" runat="server" OnClick="btnQuery_Click" />
                                            </td>
                                            <td>&nbsp;</td><td>&nbsp;</td>
                                            <td>
                                                <input type="button" value="添加标注" onclick="onPoint()" style="width: auto;" />
                                                <ul id="items" style="background-color: rgb(223, 232, 246); font-size: 12px; padding-left: 12px; padding: 5px; width: 275px; float: right; display: none;"></ul>
                                            </td> 
                                            <%--<td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button1" Text="隐藏文字" runat="server" OnClick="btnHidden_Click" Style="width: auto;" />
                                            </td>
                                             <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button2" Text="显示文字" runat="server" OnClick="btnShow_Click" Style="width: auto;" />
                                            </td>--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="item" style="position: absolute; margin-top: 40px; float: right; width: 100%;"></div>
                    </td>
                </tr>
            </table>
        </form>
    </div>
    <%----------------%>
    <div class="container">
        <div class="row collapsibleContainer">
            <div id="demo1Box" class="text-center" style="border: 6px solid #ddd">
                <%----------------%>
                <div class="wrapper">
                    <div id="viewer1" class="viewer" style="overflow: hidden; background-color: white; border: 1px solid #95B8E7; margin: 5px;"></div>
                </div>
                <div id="sign">
                </div>
                <%-----------------%>
            </div>
        </div>
    </div>
    <%----------------%>



    <script>
        //4c447496-f1b5-4d53-8cc6-375d194e7d2a_span     pointerImg
        //var menu = new BootstrapMenu('#4c447496-f1b5-4d53-8cc6-375d194e7d2a_img', {
        //    actions: [{
        //        name: 'jQuery特效',
        //        onClick: function () {
        //            alert('jQuery特效');
        //            //toastr.info("'jQuery特效");
        //        }
        //    }, {
        //        name: '百度',
        //        onClick: function () {
        //            alert('百度');
        //            //toastr.info("'打开百度");
        //        }
        //    }, {
        //        name: '提示层',
        //        onClick: function () {
        //            alert('提示层');
        //            //toastr.info("'提示层");
        //        }
        //    }]
        //});
        <%=jsIn%>
    </script>


    <input type="hidden" id="ifOn" value="" />
    <input type="hidden" id="DocId" value="" runat="server" />
    <input type="hidden" id="DocName" value="" runat="server" />
    <input type="hidden" id="DocPath" value="" runat="server" />
    <input type="hidden" id="userCode" value="" runat="server" />
    <input type="hidden" id="liInfo" value="" runat="server" />
    <input type="hidden" id="liPoint" value="" runat="server" />
    <input type="hidden" id="liCount" value="" runat="server" />

    <input type="hidden" id="ReID" value="" runat="server" /><%--重新标记的ID,有值,为重新标记--%>
</body>
</html>
