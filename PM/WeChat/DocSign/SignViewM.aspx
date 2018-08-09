<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="SignViewM.aspx.cs" Inherits="WeChat_DocSign_SignViewM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        function editSign(){
            page_close();
            parent.signInfoEdit($("#KeyId").val());
        }
        function reEditSign() {
            page_close();
            parent.signInfoReEdit($("#KeyId").val());
        }
        function delSign() {
            var id = $("#KeyId").val();
            if (!confirm('确定删除该标注信息吗?')) {
                return false;
            }
            else {
                if (id.length > 20) {
                    $.ajax({
                        type: "POST",
                        url: "/OA3/FileMsg/DocSign/DocSign.aspx/delData",
                        data: "{id: '" + id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function Success(data) {
                            if (data.d != "") {
                                alert('删除成功!');
                                page_close();
                                parent.location.reload();
                                //$('#li' + id).remove();
                                //$("#" + id + "_img").remove();
                                //$("#" + id + "_span").remove();
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
           
        //注意：parent 是 JS 自带的全局对象，可用于操作父页面
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        // 关闭
        function page_close() {
            parent.layer.close(index);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       
        <div id="wrap_main" class="wrap page-group">
            <div class="wrap_inner page">
                <div class="article_detail">
                    <div class="article-detail">
                        <div id="ifWrite" runat="server" style="text-align: right;">
                            <span style="position: inherit;" class="file_top_btn" onclick="editSign()">编辑标记</span>
                            <span style="position: inherit;" class="file_top_btn" onclick="reEditSign()">重新标记</span>
                            <span style="position: inherit;" class="file_top_btn" onclick="delSign()">删除标记</span>
                        </div>
                         <div style="display: none;">
            <input id="hfldTo" type="hidden" runat="server" />
            <input id="hfldCopyto" type="hidden" runat="server" />
            <input type="text" id="KeyId" runat="server" />
            <input type="text" id="UserID" runat="server" />
            <input type="text" id="DocId" runat="server" />
            <input type="text" id="DocName" runat="server" />
            <input type="text" id="DocPath" runat="server" />
        </div>
                        <div style="padding: 5px 0 5px;" class="detail-title" id="name" runat="server"></div>
                        <div style="color: #a2a2a2;font-size: 12px;" id="sign_time" runat="server"></div>
                        <div class="detail-content article_content">
                            <div id="remark" runat="server"></div>
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
                            <!--上传附件部分-->
                        </div>
                      
                    </div>
                      
                    </div>
                </div>
            </div>
        <%--<div class="overlay" id="overlayImage" style="display: none;"></div>
        <div class="commentBtnBoxBg" style="display: none;"></div>--%>
       
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
            //$("#up1").hide();
            //$("#upShow").hide();
            //var diaryId = GetQueryString("id");
            //document.getElementById("KeyId").value = diaryId;
            ////此页面为update页面
            //if (diaryId) {
            //getDataById(diaryId);//根据ID获取基本数据
            //BindJD();//获取更新进度
           // getUsersById($("#KeyId").val(), 'syr');//根据ID获取执行人
            //getUsersById($("#KeyId").val(), 'xgr');//根据ID获取相关人
            //alert(diaryId);
            //getPFById($("#KeyId").val());//根据ID获取评价
            //getPLById($("#KeyId").val());//根据ID获取评论

            getSrcFiles($("#KeyId").val(), "SignPhotos");//获取 图片
            getSrcFiles($("#KeyId").val(), "SignFiles");//获取 附件
            getSrcFiles($("#KeyId").val(), "SignVoices");//获取 语音
            getSrcFiles($("#KeyId").val(), "SignVideos");//获取 视频
            //}
            //else//新增
            //{
            //    //getTypes("");//获取日志类型信息
            //}
            //getDepts();//获取部门信息
            //getUsers();//获取人员信息
            $.hidePreloader();
        });
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
                        if (type == 'SignPhotos') {
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
                        if (type == 'SignFiles') {
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
                        if (type == 'SignVoices') {
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
                        if (type == 'SignVideos') {
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
    </script>
</body>
</html>
