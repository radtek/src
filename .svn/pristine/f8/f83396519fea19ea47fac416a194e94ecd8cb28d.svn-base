<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="DocSignM.aspx.cs"  Inherits="WeChat_DocSign_DocSignM" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <title>图纸标注</title>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
        <link rel="stylesheet" href="css/bootstrap.min.css" />
       <%-- <script src="js/BootstrapMenu.min.js" type="text/javascript"></script>--%>
        <%--<script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>

    <script type="text/javascript" src="style/jquery.js"></script>
    <script type="text/javascript" src="style/jquery.mousewheel.mobile.min.js"></script>
    <script type="text/javascript" src="style/jquery.iviewer.mobile.js"></script>
    <script type="text/javascript" src="style/jquery.iviewer.mobilestart.js"></script>
    <script type="text/javascript" src="style/jquery.iviewer.mobileend.js"></script>


    <script type="text/javascript">
        function btn() {
            $("#btnQuery").click();
        }
        //$(document).ready(function () {
        //    //$('.ifshow').hide();
        //    //$('.wrapper').css('margin-top', '28px');
        //});
        //function ifshow() {
        //    if ($('.ifshow').is(':hidden')) {
        //        $('.ifshow').show();
        //        //$('.wrapper').css("margin-top:140px")
        //        $('.wrapper').css('margin-top', '150px');
        //        $("#btnSelect").hide();
        //    }
        //    else {
        //        $('.ifshow').hide();
                
        //        $('.wrapper').css('margin-top', '28px');
        //        $("#btnSelect").show();
        //    }
        //}
    </script>

        <script type="text/javascript">
        //标注信息
            function signInfoAdd(name, x, y, id) {
                //alert('添加标注');
            //top.ui._DocSign = window;
                var url = "";
                var title = "";
            if ($("#ReID").val() == "") {
                url = '/WeChat/DocSign/SignEditM.aspx?action=add&name=' + name + '&x=' + x + '&y=' + y + '&id=' + id + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
                //url = '/WeChat/DocSign/SignEditM.aspx?action=add';
                //http://pmg.ddhome.org/WeChat/log/edit.html?action=add
                //url = '/WeChat/log/edit.html?action=add';
                title = '添加标注';
            } else {
                url = '/WeChat/DocSign/SignEditM.aspx?action=Reedit&name=' + name + '&x=' + x + '&y=' + y + '&id=' + $("#ReID").val() + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
                title = '重新标注';
            }
            //layer.open({
            //    type: 2,
            //    title: title,
            //    shadeClose: true,
            //    shade: 0.8,
            //    area: ['100%', '100%'],
            //    content: url
                //});
            window.location = url;
            //top.ui.openWin({ title: title, url: url, width: 960 });
        }
        function signInfoReEdit(id) {
            $("#ReID").val(id);
            $("#ifOn").val(1);
            canSign = 1;
        }
        function signInfoEdit(id) {
            ////top.ui._DocSign = window;
            var url = '/WeChat/DocSign/SignEditM.aspx?action=edit&name=&x=&y=&id=' + id + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
            var title = '编辑标注_' + $("#title" + id).val();
            //layer.open({
            //    type: 2,
            //    title: title,
            //    shadeClose: true,
            //    shade: 0.8,
            //    area: ['100%', '100%'],
            //    content: url
            //});
            window.location = url;
            ////top.ui.openWin({ title: title, url: url, width: 960 });
            //////toolbox_oncommand(url, title);
        }
        function signInfoView(id) {
            //alert('查看标注');
            //top.ui._DocSign = window;
            var url = '/WeChat/DocSign/SignViewM.aspx?action=view&userID=' + $("#UserID").val() + '&name=&x=&y=&id=' + id + '&doc_Id=' + $("#DocId").val() + '&doc_name=' + $("#DocName").val() + '&path=' + $("#DocPath").val();
            var title = '查看标注_' + $("#title" + id).val();
            layer.open({
                type: 2,
                title: title,
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
            ////toolbox_oncommand(url, title);
            //top.ui.openWin({ title: title, url: url, width: 960 });
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
            margin-top: 70px;
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
    <%--    <style>
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

        .pointerImg {
            /* background-image: url('/style/sign.png'); */
            width: 30px;
            /*height: 14px;*/
            position: absolute;
            display: none;
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

        .item {
            position: absolute;
        }

        .item-btn {
            border: none;
            outline: none;
            background: #00A3E8;
            font-size: 14px;
            color: seashell;
            line-height: 28px;
            padding: 5px 10px;
            margin: 5px;
            transition: 0.5s;
        }

            .item-btn:hover {
                background: seashell;
                color: #00A3E8;
            }

        .item-select {
            padding: 5px 10px;
            margin: 5px;
            font-size: 14px;
            line-height: 28px;
            height: 38px;
        }

        #menu {
            height: 60px;
            width: 100px;
            color: seashell;
            /* border: 1px solid gray; */
            background-color: #00A3E8;
            padding: 5px;
            display: none;
            position: absolute;
        }

            #menu ul, #menu li {
                margin: 0;
                padding: 0;
                text-align: center;
                list-style-type: none;
                line-height: 30px;
                transition: 0.5s;
            }

                #menu li:hover {
                    background: seashell;
                    color: #00A3E8;
                }
        /*   .imgxxx{
         filter: drop-shadow(0px 0px 3px red);
         }  */
        .auto-style1 {
            height: 25px;
        }
    </style>--%>
</head>
<body style="background-color: rgb(223, 232, 246); font: 12px tahoma, arial, helvetica, sans-serif;">
    <%--  <div class="wrapper">
        <div id="viewer1" class="viewer" style="overflow: hidden;"></div>
    </div>
    <div id="sign">
    </div>
    <div class="item">
        <input type="button" class="item-btn" onclick="onPoint()" value="开始标注" />
        <input type="button" class="item-btn" value="结束标注" onclick="offPoint()" />
        <!-- <ul id="items" style="border:1px solid #707070;background-color:white;font-size:12px;margin-left:-35px;min-height:150px;"></ul> -->
    </div>--%>

    <div style="position: absolute; width: 100%;" class="ifshow">
        <form id="form1" runat="server">
            <table style="height: 100%; background-color: white;" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" style="height: 100%;">
                        <table style="width: 100%;">
                               <div style="display:none;">
  <input type="text" id="ifOn" value="" />
    <input type="text" id="DocId" value="" runat="server" />
    <input type="text" id="DocName" value="" runat="server" />
    <input type="text" id="DocPath" value="" runat="server" />
    <input type="text" id="UserID" value="" runat="server" />
    <input type="text" id="liInfo" value="" runat="server" />
    <input type="text" id="liPoint" value="" runat="server" />
    <input type="text" id="liCount" value="" runat="server" />
    <input type="text" id="ReID" value="" runat="server" /><%--重新标记的ID,有值,为重新标记--%>
    </div>
                              <tr>
                                            <td style="text-align: right;">标注人</td>
                                            <td >
                                                <asp:DropDownList ID="user_Id" runat="server" style="width: 110px;margin-bottom: 3px;"></asp:DropDownList>
                                            </td>
                                            <td style="text-align: right;">标注名称</td>
                                            <td >
                                                 <asp:TextBox ID="name" runat="server" style="width: 110px;margin-bottom: 3px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1" style="white-space: nowrap;text-align: right;">标注时间</td>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="txtStartTime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server" style="width: 110px;margin-bottom: 3px;"></asp:TextBox>
                                            </td>
                                            <td class="descTd" style="white-space: nowrap;text-align: right;">至</td>
                                            <td>
                                                <asp:TextBox ID="txtEndTime" CssClass="easyui-validatebox" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" runat="server" style="width: 110px;margin-bottom: 3px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td colspan="2" style="text-align: left;margin-bottom: 3px;">
                                                <input type="button" value="添加标注" onclick="onPoint()" style="
    /*position: absolute;*/
    right: 15px;
    background-color: #fbfafc;
    color: #666;
    font-size: 13px;
    cursor: pointer;
    text-align: center;
    height: 25px;
    line-height: 22px;
    border: 1px #d6d5d6 solid;
    border-radius: 2px;
    min-width: 55px;
    padding: 0 5px;
    box-sizing: border-box;
    margin-left: 10px;
"/>
                                              
                                               <%-- <input type="button" id="btnUnSelect" value="取消查询" style="width: auto" onclick="ifshow();" />--%>

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
                                            <td colspan="2" style="text-align:right;margin-bottom: 3px;">
                                                <asp:Button ID="btnQuery" class="file_top_btn"  Text="查询" runat="server" OnClick="btnQuery_Click" style="
    /*position: absolute;*/
    right: 15px;
    background-color: #fbfafc;
    color: #666;
    font-size: 13px;
    cursor: pointer;
    text-align: center;
    height: 25px;
    line-height: 22px;
    border: 1px #d6d5d6 solid;
    border-radius: 2px;
    min-width: 55px;
    padding: 0 5px;
    box-sizing: border-box;
"/>
                                                &nbsp; </td>
                                        </tr>
                          <%--  <tr>
                                <td style="width: 100%; vertical-align: top;">
                                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                                      
                                    </table>
                                </td>
                            </tr>--%>
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
            <div id="demo1Box" class="text-center" style="border: 6px solid #dfe8f6">
                <%-- <input type="button" id="btnSelect" value="高级查询" style="width: auto;float: left;" onclick="ifshow();" />--%>
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

    <!-- 右键菜单 -->
    <%-- <div id="menu">
        <ul>
            <!-- <li>修改</li> -->
            <li onclick="">删除</li>
        </ul>
    </div>--%>
    
    <script type="text/javascript">
        //var $ = jQuery;
        //var src = "style/wjj.svg";//待修改
        //var signIcon = "style/sign.png";
        //var points = [];
        //points.push({ imgId: "sign1", x: 675.1880574893196, y: 250.3509234828496 });
        //points.push({ imgId: "sign2", x: 617.5759202861534, y: 162.73878627968338 });
        //var isLoading = 1;
        var canSign = 0;
        //var pointsLength = 0;
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

            //var pointer = $(imgId + "_img");
            //pointer.css('display', 'block');
            //pointer.css('left', offset.x + 'px');
            //pointer.css('top', offset.y + 'px');
            //pointer.css("margin-top", "-15px");
            //pointer.css("margin-left", "-15px");


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
            //for (var i = 0; i < points.length; i++) {
            //    var imgId = "#sign" + (i + 1);
            //    changeMe(imgId, points[i].x, points[i].y, object);
            //}
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
        //function loading(object) {
        //    if (points) {
        //        for (var i = 0; i < points.length; i++) {
        //            var imgId = "sign" + (i + 1);
        //            var img = "<img src=\"" + signIcon + "\" id=\"" + imgId + "_img\" class=\"pointerImg\" onclick=\"alert('点击')\" title=\"aaaaaa\">";
        //            //points.push({imgId:imgId,x:signedPoints[i].x,y:signedPoints[i].y,deviceTypeId:signedPoints[i].deviceTypeId,deviceId:signedPoints[i].deviceId,fileId:signedPoints[i].fileId});
        //            $("#sign").append(img);
        //        }
        //        pointsLength = points.length;
        //        changeAll(object);
        //    }
        //    isLoading = 0;
        //}
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
        //function addPoints(coords, object) {
        //    if (canSign == 1) {
        //        var imgId = "sign" + (pointsLength + 1);
        //        points.push({ imgId: imgId, x: coords.x, y: coords.y });
        //        var img = "<img src=\"" + signIcon + "\" id=\"" + imgId + "_img\" class=\"pointerImg\"  onClick=\"del('" + imgId + "')\"  title=\"bbbbbbbbb\">";
        //        $("#sign").append(img);
        //        pointsLength++;
        //        changeAll(object);
        //    }
        //    canSign = 0;
        //}
        function addPoints(coords, object) {
            if ($("#ifOn").val() == "1") {
                var imgId = "sign" + (pointsLength + 1);
                signInfoAdd("mySign" + imgId, coords.x, coords.y, (pointsLength + 1));
            }
        }
        var config = {
            index: 0
        };
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
                src: $("#DocPath").val(), //src,
                onClick: function (coords) {
                    addPoints(coords, this);
                },
                onBeforeDrag: function (coords) {
                },
                //初始化
                onZoom: function () {
                    changeAll(this);
                    if (isLoading == 1) {
                        loading(this);
                    }
                },
                //移动
                onDrag: function () {
                    changeAll(this);
                    if (isLoading == 1) {
                        loading(this);
                    }
                },
                //放大缩小
                onTouchMove: function () {
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
        function onPoint() {
            $("#ifOn").val(1);
            canSign = 1;
            $('#signTxt').css('color', 'wheat');
        }
        function offPoint() {
            $("#ifOn").val(0);
            canSign = 0;
            $('#signTxt').css('color', 'white');
        }
        //function onPoint() {
        //    canSign = 1;
        //}
        //function offPoint() {
        //    canSign = 0;
        //}
    </script>
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
       <%-- <%=jsIn%>--%>
    </script>

  
</body>
</html>

