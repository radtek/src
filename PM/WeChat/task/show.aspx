<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="WeChat_task_show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作任务</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />


    <link rel="stylesheet" href="../resource/css/ku.css" />
    <link rel="stylesheet" href="../resource/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../resource/css/light7.min.css" />
    <link rel="stylesheet" href="../resource/css/light7-swiper.min.css" />
    <script src="../resource/js/jquery-1.7.2.min.js"></script>
    <script src="../resource/js/selectUsers.js"></script>
    <script>
        function upProgress() {
            if ($("#up1").is(":hidden")) {
                $("#up1").show();
                $("#upShow").hide();
            } else {
                $("#up1").hide();
            }
        }
        function upProgressShow() {
            if ($("#upShow").is(":hidden")) {
                $("#upShow").show();    //如果元素为隐藏,则将它显现
            } else {
                $("#upShow").hide();     //如果元素为显现,则将其隐藏
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: none;">
            <%-- <input type="text" value="" id="UID" style="display: none;" />--%>
            <input type="text" value="" id="KeyId" runat="server" />
            <input type="text" value="" id="UserID" runat="server" />
            <%-- <input type="text" value="" id="hfldTo" runat="server" />
            <input type="text" value="" id="hfldCopyto" runat="server" />
            <input type="text" value="" id="imgId" runat="server" />
            <input type="text" value="" id="voiceId" runat="server" />
             <input type="text" value="" id="submitType" runat="server" />--%>
        </div>
        <div id="wrap_main" class="wrap page-group">
            <div class="wrap_inner page">
                <div class="article_detail">
                    <div class="article-detail">


                        <!--任务类型-->
                        <div class="f-item f-item-select">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title">任务类型</span>
                                <div class="flexItem">
                                    <div style="color: #333; font-size: 20px;" id="type_id" runat="server"></div>
                                </div>
                            </div>
                        </div>
                        <!--任务类型-->
                        <!--任务优先级-->
                        <div class="f-item f-item-select">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title">任务优先级</span>
                                <div class="flexItem">
                                    <div style="color: #333; font-size: 20px;" id="priority_id" runat="server"></div>
                                </div>
                            </div>
                        </div>
                        <!--任务优先级-->

                        <div class="detail-title" id="title" runat="server"></div>
                        <div class="detail-small-title">
                            <span id="start_time" runat="server"></span>至<span id="end_time" runat="server"></span>
                            <br />
                            [持续<span id="cxsj" runat="server"></span>分钟]

                           <span id="creater" runat="server"></span>

                            <!--<a onclick="editDiary()" id="editbtnDiv_id" style="display: none">编辑</a>
                        <a onclick="editDiary()" style="">复制</a>-->
                        </div>
                        <div class="detail-content article_content">

                            <div id="content" runat="server"></div>

                            <!--上传图片部分-->
                            <div class="f-item">
                                <div class="loadImg clearfix">
                                    <div class="f-add-user-list" style="margin: 0;">
                                        <ul id="addImg" class="clearfix"></ul>
                                    </div>
                                </div>
                            </div>
                            <!--上传图片部分-->

                            <!--上传音频部分-->
                            <div class="f-item">
                                <div class="loadImg clearfix">
                                    <div class="f-add-user-list" style="margin: 0;">
                                        <ul id="addVoice" class="clearfix"></ul>
                                    </div>
                                </div>
                            </div>
                            <!--浮动窗口-->
                            <!--上传音频部分-->

                            <!--上传视频部分-->
                            <!-- 预览框： -->
                            <div class="preview"></div>
                            <!--上传视频部分-->

                            <!--上传附件部分-->
                            <div class="form-style" id="medialist">
                                <div class="letter_bar file_top borderBottommNone">
                                    <span class="file_top_tit">附件</span>

                                    <span id="fileInput" style="display: none"></span>
                                </div>
                            </div>
                            <div class="settings-item" id="fj">
                            </div>
                            <div class="separate_bar separate_bar_h15"></div>
                            <!--上传附件部分-->

                            <div class="detail_tapeEndBox" id="voicelist" style="display: none;"></div>
                            <div>
                                <div class="mb5 c999"><span>任务状态</span></div>
                                <div style="color: #333; font-size: 20px;" id="status_name" runat="server"></div>
                            </div>

                            <div>
                                <div class="mb5 c999"><span id="pingfenId">任务进度</span></div>
                                <div style="color: #333; font-size: 20px;" id="progress" runat="server"></div>

                                <span onclick="upProgress()" style="margin-left: 10px;" runat="server" id="upProgress">[更新进度]</span>   <span onclick="upProgressShow()" style="margin-left: 10px;">[更新记录]</span>
                            </div>

                            <%-- 创建人更新任务进度--%>
                            <div class="form_btns mt10" id="btns" runat="server">
                                <div class="inner_form_btns">
                                    <div class="fbtns flexbox">
                                        <input type="hidden" name="tbQyDiaryPO.diaryStatus" id="taskStatus" value="" />
                                        <a class="fbtn btn flexItem" style="margin-right: 5px; color: white;" onclick="changeStatus(3)">完成任务</a>
                                        <a class="fbtn btn qwui-btn_default flexItem" style="margin-left: 5px;" onclick="changeStatus(4)">关闭任务</a>
                                    </div>
                                    <div class="fbtns_desc"></div>
                                </div>
                            </div>
                            <%--/创建人更新任务进度--%>

                            <div id="btn_div_per1">
                                <div class="flexbox mt15" id="upShow">
                                    <ul id="upList">
                                    </ul>
                                </div>
                                <div id="up1">
                                    <!--任务进度-->
                                    <div class="f-item">
                                        <div class="inner-f-item">
                                            <div class="flexItem" style="padding-right: 40px;">
                                                <input type="text" name="title" value="" id="t1" placeholder="请输入任务进度,请填写数字" class="item-select inputStyle item-title" runat="server" />%
                                            </div>
                                        </div>
                                    </div>
                                    <!--任务进度-->
                                    <!--进度说明-->
                                    <div class="f-item">
                                        <div class="inner-f-item">
                                            <div class="flexItem" style="padding-right: 40px;">
                                                <input type="text" name="title" value="" id="t2" placeholder="请输入进度说明" class="item-select inputStyle item-title" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <!--进度说明-->
                                    <div class="flexbox mt15">
                                        <a class="btn flexItem" id="startTaskBtn2" onclick="submitUp()">更新进度</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--评价部分-->
                    </div>
                    <div class="detail-title" id="if_send" runat="server" style="font-size: 14px;"></div>
                    <div class="letter_bar first_top" id="syrCount">执行人</div>
                    <div class="f-item" id="tolist" style="">
                        <a href="javascript:searchList('to');" class="quick_tel w45" id="toarrow"
                            style="display: none;"></a>
                        <div class="f-add-user clearfix">
                            <div class="inner-f-add-user">
                                <div class="f-add-user-list">
                                    <ul id="syr"></ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="letter_bar" id="xgrCount">相关人</div>
                    <div class="f-item" id="cclist" style="border-bottom: none;">
                        <a href="javascript:searchList('cc');" class="quick_tel w45" id="ccarrow"
                            style="display: none;"></a>
                        <div class="f-add-user clearfix" style="border-bottom: none">
                            <div class="inner-f-add-user">
                                <div class="f-add-user-list">
                                    <ul id="xgr"></ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--<div class="pageNumber">
                        <div class="prev" onclick="showAnother('pre')">上一篇</div>
                        <div class="next" onclick="showAnother('next')">下一篇</div>
                    </div>-->
                    <!--评价部分-->
                    <div class="detail-score ohidden" style="display: block;">
                        <div class="comments-box" id="comments-box">
                            <div class="letter_bar first_top">
                                <span id="commentCount">评论</span>
                            </div>
                            <div class="lastComment" id="commentCount0" style="">暂无回复</div>
                            <div class="comment_list clearfix" id="comments">
                                <ul id="commentList">
                                </ul>
                            </div>
                        </div>
                        <div class="all_pull">
                            <p class="lastComment" id="noneMore" style="display: none;">没有更多评论啦</p>
                        </div>



                        <div class="footheight" style=""></div>
                    </div>
                </div>

                <div class="foot_bar commentBtnBox " style="position: fixed;">
                    <div class="foot_bar_inner" id="main">
                        <div class="foot_input_bar">
                            <div class="flexbox">
                                <div class="comment_input flexItem">
                                    <textarea class="text_input" id="inputDiv"></textarea>
                                </div>
                                <div class="submit_btn">
                                    <a id="sendmsg_qx" class="btn white_btn comment_btn" style="margin-top: 1px; display: none;">取 消</a>
                                    <a id="sendmsg" class="btn white_btn comment_btn" style="margin-top: 1px">发 表</a>
                                </div>
                                <div id="atPersonId" style="display: none"></div>
                            </div>
                            <div class="positionInfo " style="display: none">正在获取定位信息...</div>
                        </div>
                        <div class="foot_plus_bar">
                            <div id="plus_btns" class="plus_btns_wrap hide" style="display: none;">
                                <div class="plus_btns">
                                    <ul class="clearfix flexbox">
                                        <li>
                                            <div style="float: left;">
                                                <div class="plus_btn_img nameIcon"
                                                    onclick="selectUsers('at')">
                                                    <!-- <i class="fa fa-user"></i> -->
                                                </div>
                                                <div class="plus_btn_txt" onclick="selectUsers('at')">点名@人</div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="f-item">

                                <div class="f-add-user clearfix">
                                    <div class="inner-f-add-user">
                                        <div class="f-add-user-list">
                                            <ul id="atUl"></ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>




                    <!--引入选择人员部分-->
                    <div id="usersSelect" style="display: none">
                    </div>
                    <!--引入选择人员部分-->
                </div>
            </div>

        </div>
        <div class="overlay" id="overlayImage" style="display: none;"></div>
        <div class="commentBtnBoxBg" style="display: none;"></div>
    </form>
    <script type='text/javascript' src='../resource/js/light7.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='../resource/js/light7-swiper.min.js' charset='utf-8'></script>
    <script>
        $.showPreloader('加载中');
        function GetQueryString(name) {//获取url参数
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }
        var UserId = "";
        $(document).ready(function () {
            $("#up1").hide();
            $("#upShow").hide();
            //var diaryId = GetQueryString("id");
            //document.getElementById("KeyId").value = diaryId;
            ////此页面为update页面
            //if (diaryId) {
            //getDataById(diaryId);//根据ID获取基本数据
            BindJD();//获取更新进度
            getUsersById($("#KeyId").val(), 'syr');//根据ID获取执行人
            getUsersById($("#KeyId").val(), 'xgr');//根据ID获取相关人
            //alert(diaryId);
            //getPFById($("#KeyId").val());//根据ID获取评价
            getPLById($("#KeyId").val());//根据ID获取评论

            getSrcFiles($("#KeyId").val(), "TaskPhotos");//获取 图片
            getSrcFiles($("#KeyId").val(), "TaskFiles");//获取 附件
            getSrcFiles($("#KeyId").val(), "TaskVoices");//获取 语音
            getSrcFiles($("#KeyId").val(), "TaskVideos");//获取 视频
            //}
            //else//新增
            //{
            //    //getTypes("");//获取日志类型信息
            //}
            getDepts();//获取部门信息
            getUsers();//获取人员信息
            $.hidePreloader();
        });
        //提交保存 type:3 完成;4 关闭;  
        function changeStatus(status) {
            //alert(status);
            $.ajax({
                type: "POST",
                url: "../task/show.aspx/changeStatus",
                data: "{Id: '" + $("#KeyId").val() + "',status: '" + status + "',userID:'" + $("#UserID").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d == "3") {
                        alert("操作成功");
                        $("#btns").hide();
                        $("#upProgress").hide();
                        $("#up1").hide();
                        //$("#status_name").val("");
                        $("#status_name").html("已完成");
                    }
                    else if (data.d == "4") {
                        alert("操作成功");
                        $("#btns").hide();
                        $("#upProgress").hide();
                        $("#up1").hide();
                        //$("#status_name").val("");
                        $("#status_name").html("已关闭");
                    } else {
                        alert("操作失败,请重试!");
                        //$("#btns").hide();
                    }
                }
            });
        }
        function getDepts() {
            $.ajax({
                type: "POST",
                url: "../Ajax/AjaxGetMsg.aspx/getDepts",
                // data: "{helpId: '" + helpId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        alldepts = eval("(" + data.d + ")").alldepts;
                    }
                    else {
                        //alldepts=[];
                    }
                }
            });
        }
        function getUsers() {
            $.ajax({
                type: "POST",
                url: "../Ajax/AjaxGetMsg.aspx/getUsers",
                data: "{AgentId: '1000008'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        allusers = eval("(" + data.d + ")").allusers;
                        changeType(this, 'ry');
                        allUsers();
                    }
                    else {
                        //allusers = [];
                    }
                }
            });
        }
        var audio = null;
        function editPlay(e) {
            if (audio) {
                audio.currentTime = 0;
                audio.pause();
                $("img[name='editVoice']").each(function () {
                    $(this).attr("src", "../resource/images/voiceFile.png");
                });
                audio = null;
            } else {
                audio = document.createElement("audio");
                audio.src = e.attr("imgSrc");
                e.attr("src", "../resource/images/playVoice.gif");
                audio.play();
            }
        }

        function getSrcFiles(diaryId, type) {
            $.ajax({
                type: "POST",
                url: "../Ajax/AjaxGetMsg.aspx/getSrcFiles",
                data: "{diaryId: '" + document.getElementById("KeyId").value + "',type: '" + type + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        var res = eval("(" + data.d + ")");
                        if (type == 'TaskPhotos') {
                            var addHtml = "";
                            var photos = [];
                            for (var i = 0; i < res.length; i++) {
                                addHtml += "<li>" +
                                    "<p class=\"img\">" +
                                    "<img name=\"toUpLoadImg\" class=\"ylt\" src=\"" + res[i].Path + res[i].Name + "\" alt=\"\">" +
                                    "</p>" +
                                    "</li>";
                                var src = res[i].Path + res[i].Name;
                                photos.push(src);
                            }
                            $("#addImg").prepend(addHtml);
                            var myPhotoBrowserStandalone = $.photoBrowser({
                                photos: photos
                            });
                            //点击时打开图片浏览器
                            $(document).on('click', '.ylt', function () {
                                myPhotoBrowserStandalone.open();
                            });
                        }
                        if (type == 'TaskFiles') {
                            var addHtml = "";
                            for (var i = 0; i < res.length; i++) {
                                var cl = res[i].Name.toUpperCase().split('.')[1];

                                addHtml += "<div class=\"inner-settings-item flexbox fujian\">" +
                                    "<p class=\"" + cl + "\"></p>" +
                                    "<div class=\"fujian_text flexItem\">" +
                                    "<p class=\"name\">" + res[i].Name + "</p>" +
                                    "<p class=\"fujian_size\">" + res[i].Length + " K</p>" +
                                    "<p class=\"arrow\">" +

                                    "</p>" +
                                    "</div>" +
                                    "</div>";
                            }

                            $("#fj").prepend(addHtml);
                        }
                        if (type == 'TaskVoices') {
                            var addHtml = "";
                            for (var i = 0; i < res.length; i++) {
                                addHtml = "<li>" +
                                    "<p class=\"img\">" +
                                    "<img name='editVoice' src=\"../resource/images/voiceFile.png\" imgSrc='" + res[i].Path + res[i].Name + "' style=\"margin-left:10px;width: 42px;height: 42px;\" onclick='editPlay($(this))'>" +

                                    "</p>" +
                                    "</li>";
                                $("#addVoice").prepend(addHtml);
                            }
                        }
                        if (type == 'TaskVideos') {
                            var addHtml = "";
                            for (var i = 0; i < res.length; i++) {
                                $(".preview").append("<div style='margin-top:10px;'><video src='" + res[i].Path + res[i].Name + "'  controls='controls' width='180' height='180'>" +
                                    "</video></div>");
                            }
                        }
                    }
                    else {
                        //allusers = [];
                    }
                }
            });
        }

        function getUsersById(Id, userType) {
            $.ajax({
                type: "POST",
                url: "../Ajax/AjaxGetMsg.aspx/getUsersById",
                data: "{Id: '" + Id + "',userType: '" + userType + "',mk: 'task'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "" && data.d != "无") {
                        var RY = eval("(" + data.d + ")");
                        if (userType == "syr") {
                            //处理审阅人
                            var syr = RY;
                            $("#syrCount").html("执行人（" + syr.length + "）");
                            if (syr.length > 0) {
                                var syrHtml = "";
                                for (var i = 0; i < syr.length; i++) {

                                    var userId = syr[i].id;
                                    var userName = syr[i].name;
                                    var userUrl = syr[i].url;
                                    syrHtml += "<li>" +
                                        "<p class=\"img\">" +
                                        "<img src=\"" + userUrl + "\" alt=\"\">" +
                                        "</p>" +
                                        "<p class=\"name\">" + userName + "</p>" +
                                        "</li>";
                                }
                                $("#syr").html(syrHtml);
                            }

                        }
                        if (userType == "xgr") {
                            //处理相关人
                            var xgr = RY;
                            $("#xgrCount").html("相关人（" + xgr.length + "）");
                            if (xgr.length > 0) {
                                var xgrHtml = "";
                                for (var i = 0; i < xgr.length; i++) {
                                    var userId = xgr[i].id;
                                    var userName = xgr[i].name;
                                    var userUrl = xgr[i].url;
                                    xgrHtml += "<li>" +
                                        "<p class=\"img\">" +
                                        "<img src=\"" + userUrl + "\" alt=\"\">" +
                                        "</p>" +
                                        "<p class=\"name\">" + userName + "</p>" +
                                        "</li>";
                                }
                                $("#xgr").html(xgrHtml);
                            }
                        }
                    }
                    else {

                    }
                }
            });
        }
        function getPLById(id) {
            $.ajax({
                type: "POST",
                url: "../Ajax/AjaxGetMsg.aspx/getPLById",
                data: "{Id: '" + id + "',mk:'task'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function Success(data) {
                    var listHtml = "";
                    if (data.d != "") {
                        var res = eval("(" + data.d + ")");
                        if (res) {
                            var d = res;
                            //console.log(d);
                            for (var i = 0; i < d.length; i++) {
                                listHtml += "<li class='flexbox'>" +
                                    "<div class='avator'><img src='" + d[i].img + "' alt=''>" +
                                    "</div><div class='comment_content flexItem mapItem'>" +
                                    "<h3 class='clearfix'><span class='title'>" + d[i].v_xm + "</span><span class='time'>" + d[i].time + "</span>" +
                                    "<input type='hidden' value='" + d[i].id + "'>" +
                                    "</h3><p class='@class'>" + d[i].content + "</p></div> </li>";
                            }

                            $('#commentList').html(listHtml);
                            if (listHtml.length <= 0) {
                                $("#commentCount0").show();
                            } else {
                                $("#commentCount0").hide();
                            }
                        }
                    }
                    else {

                    }
                }
            });
        }
        function showAnother(type) {//type(prev,next):上一篇，下一篇
            //TODO
        }
        $("#inputDiv").focus(function () {
            $(".foot_bar").addClass("active");
            $(".commentBtnBoxBg").show();
            $("#plus_btns").show();
            $("#sendmsg_qx").css("display", "block");
        });

        function removeActive() {
            $(".foot_bar").removeClass("active");
            $(".commentBtnBoxBg").hide();
            $("#plus_btns").hide();
            $("#sendmsg_qx").css("display", "none");
            $("#atUl").html("");
        }

        //发表评论
        $("#sendmsg").click(function () {
            if ($("#inputDiv").val().length == 0) {
                alert("请输入评论内容!");
            } else {
                $.showPreloader('发表中');
                var atr = $("input[name='atPersonName']").val();
                if (typeof (atr) == "undefined") {
                    atr = "";
                }
                var pl = $("#inputDiv").val() + atr;
                var id = GetQueryString("id");
                var atPersonId = $("input[name='atPersonId']").val();
                if (typeof (atPersonId) == "undefined") {
                    atPersonId = "";
                }
                $.ajax({
                    type: "POST",
                    url: "../Ajax/AjaxGetMsg.aspx/savePLById",
                    data: "{id: '" + id + "',pl:'" + pl + "',userID:'" + $("#UserID").val() + "',title:'" + $("#title").val() + "',atPersonId:'" + atPersonId + "',mk:'task'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function Success(data) {
                        ///var pf = data.d.split(",")[1];
                        if (data.d == "1") {
                            $("#inputDiv").val("");
                            removeActive();
                            getPLById(id);
                            getUsersById(id, 'xgr');//根据日志ID获取相关人
                            alert("发表成功");
                            $.hidePreloader();
                            //此时有评价
                            //canScore = 1;
                            //changeScore($("img[alt='" + pf + "']"));
                            //canScore = 0;
                        } else {
                            $.hidePreloader();
                            alert("评论提交失败");

                        }

                    }
                });
            }
            //TODO
        });
        $("#sendmsg_qx").click(function () {
            $("#inputDiv").val("");
            removeActive();
        });
        //提交进度
        function submitUp() {
            $.showPreloader('提交中');
            $.ajax({
                type: "POST",
                url: "../task/show.aspx/submitUp",
                data: "{Id: '" + $("#KeyId").val() + "',userID: '" + $("#UserID").val() + "',t1:'" + $("#t1").val() + "',t2:'" + $("#t2").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != null) {
                        //保存成功时
                        if (data.d) {
                            //此时有评价
                            $("#up1").hide();
                            $("#t1").val("")
                            $("#t2").val("");
                            BindJD();
                            $("#upShow").show();
                            $.hidePreloader();
                            alert("操作成功");
                        } else {
                            $.hidePreloader();
                            alert("操作失败");
                        }
                    }
                }
            });
        }
        function BindJD() {
            $.ajax({
                type: "POST",
                url: "../task/show.aspx/BindJD",
                data: "{Id: '" + $("#KeyId").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        $('#progress').val("");
                        $('#progress').html(data.d.split('|')[0]);
                        $('#upList').html(data.d.split('|')[1]);
                    }
                    else {
                        $("#progress").val("0%");
                        $('#upList').html();
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        $('#usersSelect').load('../../WeChat/log/selectUsers.html');
    </script>
</body>
</html>
