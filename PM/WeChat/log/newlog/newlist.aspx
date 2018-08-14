<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newlist.aspx.cs" Inherits="WeChat_log_newlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作日志</title>
    <meta name="description" content=""/>
    <meta name="HandheldFriendly" content="True"/>
    <meta name="MobileOptimized" content="320"/>
    <meta name="viewport"
          content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"/>
    <meta content="telephone=no" name="format-detection"/>
    <meta content="email=no" name="format-detection"/>
    <link rel="stylesheet" href="../resource/css/light7.min.css"/>
    <link rel="stylesheet" href="../resource/css/light7-swiper.min.css"/>
    <link rel="stylesheet" href="../resource/css/ku.css" />
    <link rel="stylesheet" href="../resource/css/font-awesome.min.css" />
    <script src="../resource/js/jquery-1.7.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div id="wrap_main" class="wrap page">
        <div class="searchbar_wrap fixed">
            <div class="search_bar">
                <div class="search_outer">
                    <div class="search_Title qw-search_Title">
                        <a class="onetitle ellipsis">标题</a>
                    </div>
                    <div class="search_inner pl75">
                        <a><i class="icon_search" onclick="search()"></i></a>
                        <a><i class="icon_del qw-icon_del" onclick="qk()"></i></a>
                        <div id="temp">
                            <input type="text" class="search_input qw-search_input" name="search" id="search" placeholder="搜索标题">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="main" class="wrap_inner content infinite-scroll pull-to-refresh-content">
            <!-- 下拉刷新 -->
            <div class="pull-to-refresh-layer">
                <div class="preloader"></div>
                <div class="pull-to-refresh-arrow"></div>
            </div>
            <!--内容部分-->
            <div class="search_box_height"></div>
            <div class="address_list list-block infinite-scroll">

                <!-- 模板数据 -->
                <!--<div class="settings-item"><span class="time">11-28</span>
                    <div class="inner-settings-item flexbox">
                        <div class="user_select_icon actived"
                             ><label><input type="checkbox" name="diary" value="" onclick="deleteDiary()"><span></span></label></div>
                        <div class="title description_title flexItem">
                            <p class="name">日报_雲潇_20171128</p>
                            <p class="description description_ellipsis">123131</p></div>
                    </div>
                </div>-->
            </div>
            <div class="warp-no-data" id="warp-no-data" style="display:none;">
                <i class="icon-no-data icon-text"></i>
                <p class="fz16 c999 none" id="noMsg">无记录</p>
                <p class="mt20 f-color-aaa" id="nodataDiv">无记录</p>
            </div>
            <div class="all_pull" id="showMoreDiv" style="display: none;">
                <p class="lastComment" id="moreTip">已没有更多</p>
            </div>
            <div class="footheight" id="footheight" style="height: 60px"></div>
            <div class="footheight"></div>
        </div>
        <div class="foot_bar" id="deleteDiary" style="display: none;position: fixed">
            <div class="foot_bar_inner flexbox" style="padding: 8px 15px;">
                <a class="flexItem btn delete_btn " onclick="doDeleteDiary()">删除选中日志</a>
            </div>
        </div>
    </div>
    <script type='text/javascript' src='../resource/js/light7.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='../resource/js/light7-swiper.min.js' charset='utf-8'></script>
        <script>
        var UserID = "";
        $(document).ready(function () {
            UserID = getUserIdBycode();
            if (typeof (UserID) == "undefined") {
                UserID = getUserIdBycode();
                if (typeof (UserID) == "undefined") {
                    location.reload();
                } else {
                    if (UserID == 'no_user') {
                        alert("无法获取用户信息,请联系管理员进行人员同步!");
                        return
                    }
                }
            } else {
                if (UserID == 'no_user') {
                    alert("无法获取用户信息,请联系管理员进行人员同步!");
                    return
                }
            }
            //默认加载第一页
            addItems(rows, page);
        });
        //获取url参数
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        var loading = false;
        var maxItems = 0;//记录总数
        var rows = 10;//每页记录数(自定义)
        var page = 1;//页数
        var type = "load";

        //var temp = getUserIdBycode();


        var userType = GetQueryString("userType");//cg 草稿 tj已提交 sy 我审阅的 xg 相关的

        //获取列表数据
        function addItems(rows, page) {//获取数据函数
            //alert(UserID);
            $(".infinite-scroll-preloader").show();
            //搜索条件
            var search = $("#search").val();
            $.showPreloader('加载中');
            $.ajax({
                type: "POST",   //请求方式
                url: "../Ajax/AjaxGetMsg.aspx/getlogList",    //请求的url地址
                //status 日志状态 0 草稿 1已提交  ,status: '" + GetQueryString("status") + "'
                data: "{userId: '" + UserID + "',userType:'" + userType + "',rows: " + rows + ",page: " + page + ",search: '" + search + "'}", //data: { "rows": rows, "page": page, "search": search },   //参数值
                contentType: "application/json; charset=utf-8",
                dataType: "json",   //返回格式为json
                async: true, //请求是否异步，默认为异步，这也是ajax重要特性
                success: function Success(data) {
                    //返回数据格式
                    //               [{total:"记录总数",data:"[
                    //                {id:'id',title:'标题',content:'内容',create_date:'创建日期'},
                    //                {id:'id',title:'标题',content:'内容',create_date:'创建日期'},
                    //                {id:'id',title:'标题',content:'内容',create_date:'创建日期'},
                    //                {id:'id',title:'标题',content:'内容',create_date:'创建日期'}
                    //                ]"}]
                    //返回数据格式
                    var listHtml = "";
                    if (data.d != "") {
                        console.log(data.d);
                        var res = eval("(" + data.d + ")");
                        if (res[0].data) {
                            var d = res[0].data;
                            for (var i = 0; i < d.length; i++) {
                                var content = d[i].content;
                                if (content.length > 20) {
                                    content = content.substring(0, 20) + "...";
                                }
                                if (!content) {
                                    content = "无";
                                }
                                var title = d[i].title;
                                if (d[i].ifck == 0 || d[i].ifck == '0') {
                                    title = "<b>" + title + "</b>";
                                }
                                console.log(content);
                                listHtml += "<div class=\"settings-item\">" +
                                    "<span class=\"time\">" +
                                        "<span style=\"float: right\">" + d[i].create_date + "</span>" +
                                        "<span style=\"float:right;margin-top:17px;margin-right:-118px\">评论数：" + d[i].plAll + "，最新评论数：" + d[i].plNew + "</span>" +
                                    "</span>" +
                                         "<div class=\"inner-settings-item flexbox\">" +
                                                "<div class=\"user_select_icon actived\"" +
                                                " ><label><input type=\"checkbox\" name=\"diary\" value=\"" + d[i].id + "\" onclick=\"deleteDiary()\"><span></span></label></div>" +
                                                "<div class=\"title description_title flexItem\"  onclick=\"gotoDetail('" + d[i].id + "')\">" +
                                                "<p class=\"name\">" + title + "</p>" +
                                                "<p class=\"description description_ellipsis\">" + content + "</p></div>" +
                                                "</div>" +
                                           "</div>";
                            }
                        }
                        if (type == "load") {
                            $('.address_list').append(listHtml);
                            $(".infinite-scroll-preloader").hide();
                        } else {
                            $('.address_list').html(listHtml);
                            $(".infinite-scroll-preloader").hide();
                            type = "load";
                        }
                        maxItems = res[0].total;
                    }
                    else {
                        listHtml = "";
                    }
                    $.hidePreloader();//隐藏加载提示
                    if (listHtml.length <= 0) {
                        $('.address_list').html("");
                        if (page <= 1) {
                            $("#warp-no-data").show();
                        } else {
                            $("#showMoreDiv").show();
                        }
                    } else {
                        $("#warp-no-data").hide();
                        $("#showMoreDiv").hide();
                    }
                    if (userType != 'cg') {

                        $("input[name='diary']").each(function () {

                            $(this).parent().hide();
                            $(this).hide();
                        });
                    }
                }
            });
        }

        //注册上拉滚动事件
        $(document).on('infinite', '.infinite-scroll', function () {
            // 如果正在加载，则退出
            if (loading) return;
            // 设置flag
            loading = true;
            loading = false;
            if (rows * page >= maxItems) {//每页记录数乘以当前加载到的页数大于等于记录总数则全部加载完毕
                $.detachInfiniteScroll($('.infinite-scroll'));
                $('.infinite-scroll-preloader').remove();
                return;
            }
            page += 1;
            //showIndicator
            addItems(rows, page);
        });
        //下拉刷新
        // 添加'refresh'监听器
        $(document).on('refresh', '.pull-to-refresh-content', function (e) {
            //$.showIndicator();//显示加载提示
            page = 1;
            type = "refresh";
            addItems(rows, page);
            // 加载完毕需要重置
            $.pullToRefreshDone('.pull-to-refresh-content');
        });
        //搜索列表数据
        function search() {
            // $.showIndicator();//显示加载提示
            page = 1;
            type = "search";
            addItems(rows, page);
        }
        //清空搜索列表数据
        function qk() {
            $("#search").val("");
        }
        //删除按钮显隐
        function deleteDiary() {
            var flag = true;
            $("input[name='diary']").each(function () {
                if ($(this).prop("checked")) {
                    $("#deleteDiary").show();
                    flag = false;
                    return false;
                }
            });
            if (flag) {
                $("#deleteDiary").hide();
            }

        }
        //详情页  type 0 草稿,1已提交
        function gotoDetail(id) {
            $.showPreloader('加载中');
            //userType   //cg 草稿 tj 已提交 sy 我审阅的 xg 相关的
            if (userType == "cg") {
                window.location.href = '../log/edit.html?action=edit&id=' + id + "&userID=" + UserID;
            }
            if (userType == "tj") {
                window.location.href = '../log/show.html?id=' + id + "&userType=tj&userID=" + UserID;
            }
            if (userType == "sy") {
                window.location.href = '../log/show.html?id=' + id + "&userType=sy&userID=" + UserID;
            }
            if (userType == "xg") {
                window.location.href = '../log/show.html?id=' + id + "&userType=xg&userID=" + UserID;
            }
            $.hidePreloader();//隐藏加载提示
        }
        function getUserIdBycode() {
            var id = GetQueryString("userId");
            if (id == null || id == "") {
                var code = GetQueryString("code");
                var UserId = getCookieValue("UserId");
                if (UserId == "" || UserId == null || typeof (UserId) == "undefined") {
                    $.ajax({
                        type: "POST",
                        url: "../Ajax/AjaxGetMsg.aspx/getUserIdBycode",
                        data: "{code: '" + code + "',AgentId: '1000008'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function Success(data) {
                            if (data.d != "") {
                                return data.d;
                            }
                            else {
                                //alldepts=[];
                            }
                        }
                    });
                } else {
                    return UserId;
                }
            } else {
                return id;
            }

        }
        //获取cookie
        function getCookieValue(cookieName) {
            var cookieValue = document.cookie;
            var cookieStartAt = cookieValue.indexOf("" + cookieName + "=");
            if (cookieStartAt == -1) {
                cookieStartAt = cookieValue.indexOf(cookieName + "=");
            }
            if (cookieStartAt == -1) {
                cookieValue = null;
            }
            else {
                cookieStartAt = cookieValue.indexOf("=", cookieStartAt) + 1;
                cookieEndAt = cookieValue.indexOf(";", cookieStartAt);
                if (cookieEndAt == -1) {
                    cookieEndAt = cookieValue.length;
                }
                cookieValue = unescape(cookieValue.substring(cookieStartAt, cookieEndAt));//解码latin-1
            }
            return cookieValue;
        }
        //删除列表数据
        function doDeleteDiary() {
            $.showPreloader('删除中');
            var deleteIds = "";
            $("input[name='diary']").each(function () {
                if ($(this).prop("checked")) {
                    deleteIds += $(this).val() + ",";
                }
            });
            if (deleteIds.length > 0) {
                deleteIds = deleteIds.substring(0, deleteIds.length - 1);
            }
            //alert(deleteIds);
            //执行删除ajax
            $.ajax({
                type: "POST",
                url: "../Ajax/AjaxGetMsg.aspx/deleteInfoByIds",
                data: "{ids: '" + deleteIds + "',type: 'log'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        page = 1;
                        type = "search";
                        addItems(rows, page);
                        $.hidePreloader();//隐藏加载提示
                        alert("操作成功");
                    }
                    else {
                        //alldepts=[];
                    }
                }
            });
        }
        $.init();
    </script>
    </form>
</body>
</html>
