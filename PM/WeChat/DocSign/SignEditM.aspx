<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="SignEditM.aspx.cs" Inherits="WeChat_DocSign_SignEditM" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />

    <title></title>
    <link rel="stylesheet" href="../resource/css/ku.css" />
    <link rel="stylesheet" href="../resource/css/font-awesome.min.css" />
    <script src="../resource/js/jquery-12.4.min.js"></script>
    <script src="../resource/js/selectUsers.js"></script>
    <script src="../resource/js/jquery.ui.widget.js"></script>
    <script src="../resource/js/jquery.iframe-transport.js"></script>
    <script src="../resource/js/jquery.fileupload.js"></script>
    <script src="../resource/js/jquery.xdr-transport.js"></script>
    <script src="../resource/js/ajaxfileupload.js"></script>
    <script src="../resource/js/guid.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
    <script>
        ////注意：parent 是 JS 自带的全局对象，可用于操作父页面
        //var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        //// 关闭
        //function page_close() {
        //    parent.layer.close(index);
        //}
        function reURl(userID, doc_name, doc_Id, path) {
            var strUrl = "DocSignM.aspx?userID=" + userID + "&doc_name=" + doc_name + "&doc_Id=" + doc_Id + "&path=" + path + "";
            //alert(strUrl);
            window.location.href = strUrl + "&stime=" + 10000 * Math.random();
        }
        function pageClose() {
            var strUrl = "DocSignM.aspx?userID=" + $("#UserID").val() + "&doc_name=" + $("#DocName").val() + "&doc_Id=" + $("#DocId").val() + "&path=" + $("#DocPath").val() + "";
            alert(strUrl);
            window.location.href = strUrl + "&stime=" + 10000 * Math.random();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrap_main" class="wrap page-group">
            <div id="main" class="wrap_inner page" style="">
                <input type="hidden" name="tbQyDiaryPO.currentDay" id="currentDate" />
                <div class="detaildata">
                    <!--任务标题-->
                    <div class="f-item">
                        <div class="inner-f-item">
                            <div class="flexItem" style="padding-right: 40px;">
                                 <asp:TextBox ID="name" Height="100%" Width="100%" runat="server" placeholder="请输入标注名称" class="item-select inputStyle item-title" ></asp:TextBox>
                               <%-- <input type="text" name="name" value="" id="name" placeholder="请输入标注名称" class="item-select inputStyle item-title" runat="server" />--%>
                            </div>
                        </div>
                    </div>
                    <!--任务标题-->
                    <!--任务内容-->
                    <div class="f-item">
                        <div class="inner-f-item tapeBox">
                            <div class="text_div">
                                <asp:TextBox ID="remark" class="item-select inputStyle item-content" cols="30" rows="2" placeholder="请输入标注内容" style="height: 42px;" runat="server"></asp:TextBox><%--BorderStyle="None"--%>
                                <%--<textarea class="item-select inputStyle item-content" name="remark" id="remark" cols="30" rows="2" placeholder="请输入标注内容" style="height: 42px;" runat="server"></textarea>--%>
                            </div>
                        </div>
                    </div>
                    <!--任务内容-->
                    <!--上传图片部分-->
                    <div class="f-item">
                        <div class="loadImg clearfix">
                            <div class="f-add-user-list" style="margin: 0;">
                                <ul id="addImg" class="clearfix1">
                                    <li class="f-user-add" onclick="chooseImg()"></li>
                                    <li class="f-user-remove" onclick="removeImg()"></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--上传图片部分-->

                    <!--上传音频部分-->
                    <div class="f-item">
                        <div class="loadImg clearfix">
                            <div class="f-add-user-list" style="margin: 0;">
                                <ul id="addVoice" class="clearfix1">
                                    <li id="voiceLi">
                                        <img src="../resource/images/voice.png" style="margin-left: 10px; width: 42px; height: 42px;" onclick="startVoice()" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--浮动窗口-->
                    <div class="overlay" id="iosMask" style="display: none;"></div>
                    <div class="popBox1 tapePop" style="display: none;">
                        <div class="popBox_title"></div>
                        <div class="popBox1_con tcenter">
                            <img src="../resource/images/tapePlay.gif" />
                            <div class="tapeTime">01:00</div>
                        </div>
                        <div class="popBox_error"></div>
                        <div class="popBox_foot flexbox">
                            <a class="popBox_cancel_btn flexItem" onclick="stopVoice(0)">取消</a>
                            <a class="popBox_submit_btn flexItem" onclick="stopVoice(1)">说完了</a>
                        </div>
                    </div>
                    <!--浮动窗口-->
                    <!--上传音频部分-->

                    <!--上传视频部分-->
                    <div class="f-item">
                        <div class="loadImg clearfix">
                            <div class="f-add-user-list" style="margin: 0;">
                                <ul id="addvideo" class="clearfix1">
                                    <li>
                                        <img src="../resource/images/video.png"
                                            style="margin-left: 10px; width: 42px; height: 42px;" onclick="addVideo()" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div style="margin-top: 10px; display: none" id="sp">
                    </div>
                    <!-- 上传进度条及状态： -->
                    <div class="progress">
                        <div class="bar" style="width: 0%; display: none;"></div>
                        <div class="upstatus" style="margin-top: 10px;"></div>
                    </div>
                    <!-- 预览框： -->
                    <div class="preview"></div>
                    <!--上传视频部分-->

                    <!--上传附件部分-->
                    <div class="form-style" id="medialist">
                        <div class="letter_bar file_top borderBottommNone">
                            <span class="file_top_tit">附件</span>
                            <span class="file_top_btn" onclick="addFile()">
                                <!--<input type="file" name="file" id="files" class="upload_file_input"/>-->
                                <i>+</i>添加
                            </span>
                            <span id="fileInput" style="display: none"></span>
                        </div>
                    </div>
                    <div class="settings-item" id="fj">
                    </div>
                    <div class="form_btns mt10">
                        <div class="inner_form_btns">
                            <div class="fbtns flexbox">
                                <input type="hidden" name="tbQyDiaryPO.diaryStatus" id="taskStatus" value="" />
                                <a class="fbtn btn qwui-btn_default flexItem" style="margin-right: 5px;" onclick="pageClose();">
                                    <!--href="javascript:commitTask('0')"-->
                                    取 消</a>
                                <a class="fbtn btn flexItem" style="margin-left: 5px; color: white" onclick="commitTask()">
                                    <!--href="javascript:commitTask('1')"-->
                                    保 存</a> 
                            </div>
                            <div class="fbtns_desc"></div>
                        </div>
                          <div style="display: none;">
            主键ID<input type="text" value="" id="KeyId" runat="server" />
            用户ID<input type="text" value="" id="UserID" runat="server" />
            <input type="text" value="" id="imgId" runat="server" />
            <input type="text" value="" id="voiceId" runat="server" />
            <input type="text" value="" id="submitType" runat="server" />
            <input type="hidden" id="DocId" value="" runat="server" />
            <input type="hidden" id="DocName" value="" runat="server" />
            <input type="hidden" id="DocPath" value="" runat="server" />
            <input type="hidden" id="DocAction" value="" runat="server" />
            <asp:Button ID="btnSave" Text="保存"  OnClick="btnSave_Click" runat="server" Style="width: auto;" />
          
        </div>
                    </div>
                </div>
            </div>
        </div> 
      
    </form>
    <link rel="stylesheet" href="../resource/css/light7.min.css" />
    <link rel="stylesheet" href="../resource/css/light7-swiper.min.css" />
    <script type='text/javascript' src='../resource/js/light7.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='../resource/js/light7-swiper.min.js' charset='utf-8'></script>


    <!--数据加载js-->
    <script type='text/javascript'>
        $.showPreloader('加载中...');
        var UserID = "";
        var audio = "";
        $(document).ready(function () {
            UserID = $("#UserID").val();//getUserIdBycode(); //"00300005";//
            if (typeof (UserID) == "undefined") {
                alert("无法获取用户信息,请重新加载!");
                return;
            } else {
                if (UserID == 'no_user') {
                    alert("无法获取用户信息,请联系管理员进行人员同步!");
                    return
                }
            }
            //getDepts();//获取部门信息
            //getUsers();//获取人员信息
            getJSSDK();//获取jssdk
            //getUsersById($("#KeyId").val(), 'syr');//根据ID获取审阅人
            //getUsersById($("#KeyId").val(), 'xgr');//根据ID获取相关人
            getSrcFiles($("#KeyId").val(), "SignPhotos");//获取 图片
            getSrcFiles($("#KeyId").val(), "SignFiles");//获取 附件
            getSrcFiles($("#KeyId").val(), "SignVoices");//获取 语音
            getSrcFiles($("#KeyId").val(), "SignVideos");//获取 视频

            $.hidePreloader();
        });
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
                url: "/WeChat/Ajax/AjaxGetMsg.aspx/getSrcFiles",
                data: "{diaryId: '" + diaryId + "',type: '" + type + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {

                    if (data.d != "") {
                        var res = eval("(" + data.d + ")");

                        if (type == 'SignPhotos') {
                            var addHtml = "";
                            for (var i = 0; i < res.length; i++) {
                                addHtml += "<li>" +
                                "<a class=\"remove_icon\" name='removeImgA' onclick=\"deleteAllFiles('" + res[i].Path + res[i].Name + "','SignPhotos',$(this))\"  bdId=\"\" style=\"display: none;\"></a>" +
                                "<p class=\"img\">" +
                                "<img name=\"toUpLoadImg\" src=\"" + res[i].Path + res[i].Name + "\" alt=\"\">" +
                                "</p>" +
                                "</li>";

                            }
                            $("#addImg").prepend(addHtml);
                        }
                        if (type == 'SignFiles') {
                            var addHtml = "";
                            for (var i = 0; i < res.length; i++) {
                                addHtml += "<div class=\"inner-settings-item flexbox fujian\">" +
                                               // "<p class=\""+cl+"\"></p>" +
                                                "<div class=\"fujian_text flexItem\">" +
                                                "<p class=\"name\">" + res[i].Name + "</p>" +
                                                "<p class=\"fujian_size\">" + res[i].Length + " K</p>" +
                                                "<p class=\"arrow\">" +
                                                "<span class=\"wrap\"  onclick=\"deleteAllFiles('" + res[i].Path + res[i].Name + "','SignFiles',$(this))\" style=\"margin-top: 11px\">" +
                                                "<i class=\"qw-operate-icon qw-operate-icon-del\"></i>" +
                                                "</span>" +
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
                                               "<a class=\"remove_icon\" onclick=\"deleteAllFiles('" + res[i].Path + res[i].Name + "','SignVoices,$(this)')\" bdvId=\"\"   style=\"display: block;\"></a>" +
                                               "<p class=\"img\">" +
                                               "<img name='editVoice' src=\"../resource/images/voiceFile.png\" imgSrc='" + res[i].Path + res[i].Name + "'  style=\"margin-left:10px;width: 42px;height: 42px;\" onclick='editPlay($(this))'>" +
                                               "</p>" +
                                           "</li>";
                                $("#addVoice").prepend(addHtml);
                            }
                        }
                        if (type == 'SignVideos') {
                            var addHtml = "";
                            for (var i = 0; i < res.length; i++) {
                                $(".preview").append("<div style='margin-top:10px;'>" +
                                    "<video src='" + res[i].Path + res[i].Name + "' controls='controls' width='70' height='50'>" +
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
        //function getUsersById(Id, userType) {
        //    $.ajax({
        //        type: "POST",
        //        url: "/WeChat/Ajax/AjaxGetMsg.aspx/getUsersById",
        //        data: "{Id: '" + Id + "',userType: '" + userType + "',mk: 'task'}",
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        async: false,
        //        success: function Success(data) {
        //            if (data.d != "") {
        //                checkedAllUsers = eval("(" + data.d + ")");
        //                selectType = userType;
        //                okChecked();
        //            }
        //            else {

        //            }
        //        }
        //    });
        //}
       
        

        var diaryId;
        //获取url参数
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        //提交保存 type:0 草稿;1 提交;    新增or修改
        function commitTask() {
           // $.showPreloader('提交中');
            //var strSYR = $("input[name='syr']").val();
            //var strXGR = $("input[name='xgr']").val();
            //if (typeof (strSYR) == "undefined") {
            //    strSYR = "";
            //}
            //if (typeof (strXGR) == "undefined") {
            //    strXGR = "";
            //}
            // $("#hfldTo").val();

            //$("#hfldTo").val(strSYR);
            //$("#hfldCopyto").val();

           // $("#hfldCopyto").val(strXGR);
            //图片
            var imgIds2 = "";
            if (typeof (imgIds) != "undefined") {
                for (var i = 0; i < imgIds.length; i++) {
                    imgIds2 += imgIds[i].fwqId + ',';
                }
            }
            //语音
            var voiceIds2 = "";
            if (typeof (voiceIds) != "undefined") {
                for (var i = 0; i < voiceIds.length; i++) {
                    voiceIds2 += voiceIds[i].fwqId + ',';
                }
            }
            $("#imgId").val(imgIds2);
            $("#voiceId").val(voiceIds2);

            //alert(imgIds2);
            //alert(voiceIds2);
            //alert(1122);
            $("#btnSave").click();
            //if (type == "0") {
            //    $("#submitType").val(0);
            //    $("#form1").submit();
            //}
            //if (type == "1") {
            //    $("#submitType").val(1);
            //    $("#form1").submit();
            //}
        }
        //公共删除方法
        function deleteAllFiles(path, type, e) {
            $.showPreloader('删除中');
            $.ajax({
                type: "POST",
                url: "/WeChat/Ajax/AjaxGetMsg.aspx/deleteFiles",
                data: "{path: '" + path + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        $.hidePreloader();
                    }
                    else {
                        $.hidePreloader();
                    }
                }
            });

            //成功后回调函数执行内容
            if (type == 'SignPhotos') {
                e.parent().remove();
            }
            if (type == 'SignFiles') {
                e.parent().parent().parent().remove();
            }
            if (type == 'SignVoices') {
                e.parent().remove();
            }
            if (type == 'SignVideos') {

            }
            //成功后回调函数执行内容
        }
    </script>
    <!--/数据加载js-->

    <!--图片部分js-->
    <script type="text/javascript">
        function getJSSDK() {
            //var ii="../WeChat/Ajax/AjaxGetMsg.aspx/getJSSDK";
            var strUrl = window.location.href;
            //console.log(strUrl);
            //alert(strUrl);
            $.ajax({
                type: "POST",
                url: "/WeChat/Ajax/AjaxGetMsg.aspx/getJSSDK",
                data: "{strUrl: '" + strUrl + "',AgentId: '1000012'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        var das = eval("(" + data.d + ")");
                        //console.log(das[0].url);
                        //console.log(das[0].jsapiTicket);
                        //console.log(das[0].timestamp);
                        //console.log(das[0].nonceStr);
                        //console.log(das[0]);
                        initWxApi(das[0].appid, das[0].timestamp, das[0].nonceStr, das[0].signature)
                    }
                    else {
                    }
                }
            });
        }
        //初始化微信api
        function initWxApi(appid, timestamp, nonceStr, signature) {
            wx.config({
                beta: true,// 必须这么写，否则在微信插件有些jsapi会有问题
                debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: appid, // 必填，企业微信的cropID
                timestamp: timestamp, // 必填，生成签名的时间戳
                nonceStr: nonceStr, // 必填，生成签名的随机串
                signature: signature,// 必填，签名，见[附录1](#11974)
                jsApiList: [ // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
                    "openEnterpriseChat",
                    "openEnterpriseContact",
                    "onMenuShareTimeline",
                    "onMenuShareAppMessage",
                    "onMenuShareQQ",
                    "onMenuShareWeibo",
                    "onMenuShareQZone",
                    "startRecord",
                    "stopRecord",
                    "onVoiceRecordEnd",
                    "playVoice",
                    "pauseVoice",
                    "stopVoice",
                    "onVoicePlayEnd",
                    "uploadVoice",
                    "downloadVoice",
                    "chooseImage",
                    "previewImage",
                    "uploadImage",
                    "downloadImage",
                    "translateVoice",
                    "getNetworkType",
                    "openLocation",
                    "getLocation",
                    "hideOptionMenu",
                    "showOptionMenu",
                    "hideMenuItems",
                    "showMenuItems",
                    "hideAllNonBaseMenuItem",
                    "showAllNonBaseMenuItem",
                    "closeWindow",
                    "scanQRCode"
                ]
            });
            wx.error(function (res) {
                alert('js授权出错,请检查域名授权设置和参数是否正确');
            });
        }
        //wx.ready(function(res){
        var imgIds = [];
        function chooseImg() {
            wx.chooseImage({
                count: 9, // 默认9
                sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有
                sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有
                success: function (res) {
                    var localIds = res.localIds; // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片
                    if (localIds.length > 0) {
                        var addImgHtml = "";
                        for (var i = 0; i < localIds.length; i++) {
                            var src = localIds[i];
                            addImgHtml += "<li>" +
                                "<a class=\"remove_icon\" name='removeImgA' onclick=\"deleteImg(this)\"  bdId=\"" + src + "\" style=\"display: none;\"></a>" +
                                "<p class=\"img\">" +
                                "<img name=\"toUpLoadImg\" src=\"" + src + "\" alt=\"\">" +
                                "</p>" +
                                "</li>";
                            imgUpLoad(src);
                        }
                        //addImgHtml += "<li class=\"f-user-add\" onclick=\"chooseImg()\"></li>" +
                        //    "<li class=\"f-user-remove\" onclick=\"removeImg()\"></li>";
                        $("#addImg").prepend(addImgHtml);
                    } else {
                        alert("未选择图片");
                    }
                }
            });
        }
        function imgUpLoad(bendiId) {
            wx.uploadImage({
                localId: bendiId, // 需要上传的图片的本地ID，由chooseImage接口获得
                isShowProgressTips: 1,// 默认为1，显示进度提示
                success: function (res) {
                    var serverId = res.serverId; // 返回图片的服务器端ID.
                    if (serverId) {
                        imgIds.push({ bdId: bendiId, fwqId: serverId });
                    }
                }
            });
        }
        var removeImgStatus = 0;

        function removeImg() {
            if (removeImgStatus == 0) {
                $("a[name='removeImgA']").show();
                removeImgStatus = 1;
            } else {
                $("a[name='removeImgA']").hide();
                removeImgStatus = 0;
            }
        }

        function deleteImg(e) {
            var thisId = $(e).attr("bdId");
            for (var i = 0; i < imgIds.length; i++) {
                if (imgIds[i].bdId == thisId || imgIds[i].bdId.toString() == thisId.toString()) {
                    imgIds.splice(i, 1);
                }
            }
            $(e).parent().remove();
        }
    </script>
    <!--/图片部分js-->

    <!--音频部分js-->
    <script>
        var beginVoice;
        function startVoice() {
            $("#iosMask").show();
            $(".popBox1").show();
            beginVoice = setInterval(timeLess, 1000);
            wx.startRecord();
            wx.onVoiceRecordEnd({
                // 录音时间超过一分钟没有停止的时候会执行 complete 回调
                complete: function (res) {
                    upLoadVoice(res.localId);
                }
            });
        }
        var voiceIds = [];

        function stopVoice(type) {
            $("#iosMask").hide();
            $(".popBox1").hide();
            clearInterval(beginVoice);
            $(".tapeTime").html("01:00");
            time = 59;
            wx.stopRecord({
                success: function (res) {
                    if (type == 1) {
                        var html = "<li>" +
                            "<a class=\"remove_icon\" onclick=\"deleteVoice(this)\"  bdvId=\"" + res.localId + "\" style=\"display: block;\"></a>" +
                            "<p class=\"img\">" +
                            "<img  src=\"../resource/images/voiceFile.png\" style=\"margin-left:10px;width: 42px;height: 42px;\" onclick='playVoice(" + res.localId + ")'>" +
                            "</p>" +
                            "</li>";
                        $("#addVoice").prepend(html);
                        upLoadVoice(res.localId);
                    }
                }
            });
        }
        function playVoice(id) {
            wx.playVoice({
                localId: id // 需要播放的音频的本地ID，由stopRecord接口获得
            });
        }
        function upLoadVoice(bdvId) {
            wx.uploadVoice({
                localId: bdvId, // 需要上传的音频的本地ID，由stopRecord接口获得
                isShowProgressTips: 1,// 默认为1，显示进度提示
                success: function (res) {
                    var serverId = res.serverId; // 返回音频的服务器端ID
                    voiceIds.push({ bdId: bdvId, fwqId: serverId });
                }
            });
        }
        function deleteVoice(e) {
            var thisId = $(e).attr("bdvId");
            for (var i = 0; i < imgIds.length; i++) {
                if (voiceIds[i].bdvId == thisId) {
                    voiceIds.splice(i, 1);
                }
            }
            $(e).parent().remove();
        }
        var time = 59;

        function timeLess() {
            $(".tapeTime").html("00:" + time);
            if (time <= 0) {
                stopVoice();
            }
            time--;
        }
    </script>
    <!--/音频部分js-->

    <!--视频部分js-->
    <script>
        var nowVideoCount = 1;
        function addVideo() {
            var nowVideoId = "video" + nowVideoCount;
            var inputVideo = "<input type='file' id='" + nowVideoId + "' name='" + nowVideoId + "' capture='camera' accept='video/*'>";

            $("#sp").append(inputVideo);
            $("#" + nowVideoId).click();
            $("#" + nowVideoId).change(function () {

                ajaxVideoUpload(nowVideoId);
            });
            nowVideoCount++;
        }
        function ajaxVideoUpload(videoId) {
            $.showPreloader('上传中');
            var Id = $("#KeyId").val();
            $.ajaxFileUpload({
                url: "/WeChat/Ajax/upload.aspx?id=" + Id + "&type=SignVideos", //用于文件上传的服务器端请求地址
                type: 'post',
                secureuri: false, //一般设置为false
                fileElementId: videoId, //文件上传空间的id属性  <input type="file" id="file" name="file" />
                dataType: 'json', //返回值类型 一般设置为json
                success: function (data, status) {  //服务器成功响应处理函数
                    var res = eval("(" + data + ")")[0];
                    //alert(res.path + res.name)//data.result.previewSrc
                    // 上传成功：
                    $(".preview").append("<div style='margin-top:10px;'><embed src=" + res.path + res.name
                        + " allowscriptaccess='always' " +
                        "allowfullscreen='true' wmode='opaque' width='180' height='180'>" +
                        "</embed></div>");
                    alert("上传成功");
                    $.hidePreloader();
                    var file = $("#fileupload")
                    file.after(file.clone().val(""));
                    file.remove();
                },
                error: function (data, status, e)//服务器响应失败处理函数
                {  // 上传失败：
                    alert("上传失败,请重试!");
                    $.hidePreloader();
                    var file = $("#fileupload")
                    file.after(file.clone().val(""));
                    file.remove();
                }
            });
        };

    </script>
    <!--/视频部分js-->

    <!--附件部分js-->
    <script>
        var nowFileCount = 1;
        function addFile() {
            var nowFileId = "file" + nowFileCount;
            var inputFile = "<input type=\"file\" id=\"" + nowFileId + "\" name=\"" + nowFileId + "\">";
            $("#fileInput").append(inputFile);
            $("#" + nowFileId).click();
            $("#" + nowFileId).change(function () {

                ajaxFileUpload(nowFileId);
            });
            nowFileCount++;
        }
        function ajaxFileUpload(fileId) {
            $.showPreloader('上传中');
            var Id = $("#KeyId").val();
            $.ajaxFileUpload({
                url: "/WeChat/Ajax/upload.aspx?id=" + Id + "&type=SignFiles", //用于文件上传的服务器端请求地址
                type: 'post',
                secureuri: false, //一般设置为false
                fileElementId: fileId, //文件上传空间的id属性  <input type="file" id="file" name="file" />
                dataType: 'json', //返回值类型 一般设置为json
                success: function (data, status) {  //服务器成功响应处理函数
                    var res = eval("(" + data + ")")[0];
                    var html = "<div class=\"inner-settings-item flexbox fujian\">" +
                        //"<p class=\""+cl+"\"></p>" +
                        "<div class=\"fujian_text flexItem\">" +
                        "<p class=\"name\">" + res.name + "</p>" +
                        "<p class=\"fujian_size\">" + res.size + " K</p>" +
                        "<p class=\"arrow\">" +
                        "<span class=\"wrap\" onclick=\"deleteAllFiles('" + res.path + res.name + "','SignFiles',$(this))\" style=\"margin-top: 11px\">" +
                        "<i class=\"qw-operate-icon qw-operate-icon-del\"></i>" +
                        "</span>" +
                        "</p>" +
                        "</div>" +
                        "</div>";
                    $("#fj").append(html);
                    alert("上传成功");
                    $.hidePreloader();
                },
                error: function (data, status, e)//服务器响应失败处理函数
                {
                    alert("上传失败,请重试!");
                    $.hidePreloader();
                }
            }
                )
            return false;
        }
    </script>
    <!--/附件部分js-->
</body>
</html>

