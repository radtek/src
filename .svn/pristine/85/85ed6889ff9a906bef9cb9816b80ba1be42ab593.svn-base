<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="WeChat_doc_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工程文档</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <link type="text/css" rel="stylesheet" href="../resource/css/light7.min.css" />
    <link type="text/css" rel="stylesheet" href="../resource/css/light7-swiper.min.css" />
    <link type="text/css" rel="stylesheet" href="../resource/css/ku.css" />
    <link type="text/css" rel="stylesheet" href="../resource/css/font-awesome.min.css" />
    <script type="text/javascript" src="../resource/js/jquery-1.7.2.min.js"></script>
    <style>
        .am-breadcrumb {
            padding: .5em .5em;
            list-style: none;
            cursor: pointer;
            background-color: transparent;
            border-radius: 0;
            font-size: 66%;
        }

            .am-breadcrumb > li {
                display: inline-block;
            }

                .am-breadcrumb > li [class*="am-icon-"]:before {
                    color: #999999;
                    margin-right: 5px;
                }

                .am-breadcrumb > li + li:before {
                    content: "\00bb\00a0";
                    padding: 0 8px;
                    color: #cccccc;
                }

            .am-breadcrumb > .am-active {
                color: #999999;
            }

        .am-breadcrumb-slash > li + li:before {
            content: "/\00a0";
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: none;">
            <br />
            主键ID<input type="text" value="" id="KeyId" runat="server" />
          <%--    <br />
            上级ID<input type="text" value="" id="ParentId" runat="server" />--%>
            <br />
            用户ID<input type="text" value="" id="UserID" runat="server" />
        </div>
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
                <ol class="am-breadcrumb" id="mlname">
                    <%=mlname %>
                </ol>
                <div class="list-block infinite-scroll" style="margin-top: 0px">
                </div>
                <div class="warp-no-data" id="warp-no-data" style="display: none;">
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
            <%--<div class="foot_bar" id="deleteDiary" style="display: none; position: fixed">
                <div class="foot_bar_inner flexbox" style="padding: 8px 15px;">
                    <a class="flexItem btn delete_btn " onclick="doDeleteDiary()">删除选中</a>
                </div>
            </div>--%>
        </div>
    </form>
    <script type='text/javascript' src='../resource/js/light7.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='../resource/js/light7-swiper.min.js' charset='utf-8'></script>
    <script>
        $(document).ready(function () {
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
        //获取列表数据
        function addItems(rows, page) {
            //alert(UserID);
            $(".infinite-scroll-preloader").show();
            //搜索条件
            var search = $("#search").val();
            $.showPreloader('加载中');
            $.ajax({
                type: "POST",   //请求方式
                url: "../doc/list.aspx/getList",    //请求的url地址
                data: "{UserID: '" + $("#UserID").val() + "',KeyId:'" + $("#KeyId").val() + "',rows: " + rows + ",page: " + page + ",search: '" + search + "'}", //data: { "rows": rows, "page": page, "search": search },   //参数值
                contentType: "application/json; charset=utf-8",
                dataType: "json",   //返回格式为json
                async: true, //请求是否异步，默认为异步，这也是ajax重要特性
                success: function Success(data) {
                    //返回数据格式
                    var listHtml = "";
                    if (data.d != "") {
                        var res = eval("(" + data.d + ")");
                        if (res[0].data) {
                            var d = res[0].data;
                            console.log(d);
                            for (var i = 0; i < d.length; i++) {
                                var title = d[i].title;
                                if (title.length > 10) {
                                    title = title.substring(0, 10) + "...";
                                }
                                    if (d[i].fileType == 2 || d[i].fileType == '2') {
                                        listHtml += "<div class=\"settings-item cfile-info\"  onclick=\"gotoDetail('" + d[i].id + "',2)\">" +
                                            " <div class=\"link_row\">" +
                                            "  <div class=\"inner_link_row flexbox\">" +
                                            "<div class=\"flexItem a_link_wrap\"><span ></span></div>" +
                                            "</div>" +
                                            "</div>" +
                                            "<div class=\"inner-settings-item flexbox\">" +
                                            "<div class=\"icon-folder mr10\"><img src=\"../resource/images/icon-folder.png\" width=\"35\" style=\"margin-top:5px\"></div>" +
                                            "<div class=\"title description_title flexItem\"><p class=\"name\">" + title + "</p>" +
                                            "<p class=\"description description_ellipsis\">" + d[i].CreateTime + "</p></div>" +
                                            "</div>" +
                                            "</div>";
                                    } else {
                                        listHtml += "<div class=\"settings-item cfile-info\"  onclick=\"gotoDetail('" + d[i].id + "',0)\">" +
                                            "<div class=\"inner-settings-item flexbox\">" +
                                            "<div class=\"fujian\">" +
                                            "<p class=\"" + d[i].ext + "\" style=\"width: 35px;height: 35px;margin-top: 5px;\"></p>" +
                                            "</div>" +
                                            "<div class=\"title description_title flexItem\">" +
                                            "<p class=\"name\">" + title + "</p>" +
                                            "<p class=\"description description_ellipsis\">" + d[i].CreateTime + "</p></div>" +
                                            "</div>" +
                                            "</div>";
                                    }
                            }
                            maxItems = res[0].total;
                            $('.list-block').append(listHtml);
                        }
                    }
                    else {
                        listHtml = "";
                    }
                    $.hidePreloader();
                   
                    if (listHtml.length <= 0) {
                        $('.list-block').html("");
                        if (page <= 1) {
                            $("#warp-no-data").show();
                        } else {
                            $("#showMoreDiv").show();
                        }
                    } else {
                        $("#warp-no-data").hide();
                        $("#showMoreDiv").hide();
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
            //每页记录数乘以当前加载到的页数大于等于记录总数则全部加载完毕
            if (rows * page >= maxItems) {
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
        $.init();

        //详情页  type 0 草稿,1已提交
        function gotoDetail(id,type) {
            $.showPreloader('加载中');
            if (type == "2") {
                window.location.href = '../doc/list.aspx?Id=' + id;
            }
            else {
                window.location.href = '../doc/show.aspx?ic=' + id + '&userID' + $("#UserID").val();
            }
            $.hidePreloader();//隐藏加载提示
        }
    </script>
</body>
</html>
