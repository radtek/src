<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="WeChat_doc_show" %>

<%@ Register TagPrefix="MyUserControl" TagName="stockmanage_common_showaudit_ascx" Src="~/StockManage/Common/ShowAudit.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Import Namespace="cn.justwin.BLL" %>
<head runat="server">
    <title>工程文档</title>
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
        <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>
        <style>
        .am-breadcrumb {
            padding: .5em .5em;
            list-style: none;
            cursor: pointer;
            background-color: whitesmoke;
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
    <script>
        function showPic(url, title) {
            window.location = url;
            //layer.open({
            //    type: 2,
            //    title: title,
            //    shadeClose: true,
            //    shade: 0.8,
            //    area: ['100%', '100%'],
            //    content: url
            //});
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
                        <ol class="am-breadcrumb" id="mlname">
                            <%=mlname %>
                        </ol>
                        <div class="f-item f-item-select" id="Div1" runat="server">
                            <div class="inner-f-item item-text flexbox" style="display: none;">
                                <span class="f-item-title" style="margin-top: 5px;">创建人</span>
                                <div class="flexItem">
                                    <asp:Label ID="v_xm" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                                <span class="f-item-title" style="margin-top: 3px;">创建时间</span>
                                <div class="flexItem">
                                    <asp:Label ID="CreateTime" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item f-item-select" id="Div2" runat="server">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 2px;">编辑人</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocEditUserName" runat="server" Style="color: #333; font-size: 14px;"></asp:Label>&nbsp;&nbsp;
                                     <asp:Label ID="DocEditDate" runat="server" Style="color: #333; font-size: 14px;"></asp:Label>
                                </div>
                                <%-- <span class="f-item-title" style="margin-top: 3px;">编辑时间</span>
                                <div class="flexItem">
                                   
                                </div>--%>
                            </div>
                        </div>

                        <div class="f-item" id="change1" runat="server">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">变更类型</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocChangeTypeName" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item" id="change2" runat="server">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">变更说明</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocChangeRemark" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档名称</span>
                                <div class="flexItem">
                                    <asp:Label ID="FileName" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档序号</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocSort" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档编号</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocCode" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档版本</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocVersionName" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档类型</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocTypeName" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档状态</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocStatusName" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档作者</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocAuthor" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">文档文件</span>
                                <div class="flexItem" id="FileUpload2" runat="server" >
                                    <%--<asp:Label ID="FileUpload2" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>--%>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">关联文档</span>
                                <div class="flexItem">
                                    <asp:Label ID="DocRelationIDs" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item">
                            <div class="inner-f-item item-text flexbox">
                                <span class="f-item-title" style="margin-top: 5px;">备注说明</span>
                                <div class="flexItem">
                                    <asp:Label ID="Remark" runat="server" Style="color: #333; font-size: 20px;"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="f-item" id="t1" runat="server">
                            <div class="inner-f-item item-text flexbox">
                                <MyUserControl:stockmanage_common_showaudit_ascx ID="ShowAudit1" BusiClass="001" runat="server" />
                            </div>
                        </div>
                        <div class="f-item" id="t2" runat="server">
                            <div class="inner-f-item item-text flexbox">
                                <%--   <span class="f-item-title">文档历史</span>
                                <div class="flexItem">--%>
                                <table style="width: 100%;">
                                    <tr style="width: 100%; margin-top: 10px;">
                                        <td>
                                            <table id="tableHeader" cellpadding="0" cellspacing="0" style="width: 100%; margin-top: 10px;" runat="server">
                                                <tr style="height: 20px;" runat="server">
                                                    <td style="font-size: 13px; font-weight: bold; text-align: center; position: relative" runat="server">文档历史
                <div class="noprint" style="height: 20px; width: 100%; left: 0px; bottom: 0px; text-align: right; position: absolute; font-weight: normal;">
                </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; margin-top: 10px;">
                                        <td>
                                            <asp:GridView ID="gvFile" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id" runat="server">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            文档编码
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("DocCode").ToString()%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            文档名称
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <a class="link" title='<%# Eval("FileName").ToString() %>' onclick="showDoc('<%# Eval("Id") %>')">
                                                                <%# StringUtility.GetStr(Eval("FileName").ToString(), 20) %>
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            文档属性
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <center><%# Eval("DocAttributeName").ToString()%></center>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            更新时间
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <center><%# System.Convert.ToDateTime(Eval("DocEditDate")).ToString("yyyy-MM-dd HH:mm") %></center>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="rowa"></RowStyle>
                                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                                <HeaderStyle CssClass="header"></HeaderStyle>
                                                <FooterStyle CssClass="footer"></FooterStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>

                                <%-- </div>
                                   </div>--%>
                            </div>
                        </div>
                    <div class="detail-score ohidden" style="display: block;">
                        <div class="comments-box" id="comments-box">
                            <div class="letter_bar first_top">
                                <span id="commentCount">评论</span>
                            </div>
                            <div class="lastComment" id="commentCount0" style="">暂无评论</div>
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
            getPLById($("#KeyId").val());//根据ID获取评论
            getDepts();//获取部门信息
            getUsers();//获取人员信息

            $.hidePreloader();
        });

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
                data: "{AgentId: '1000012'}",
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
        //详情页  type 0 草稿,1已提交
        function showDoc(id) {
            $.showPreloader('加载中');
            window.location.href = '../doc/show.aspx?ic=' + id;
            $.hidePreloader();//隐藏加载提示
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
                data: "{Id: '" + id + "',mk:'doc'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function Success(data) {
                    var listHtml = "";
                    if (data.d != "") {
                        var res = eval("(" + data.d + ")");
                        if (res) {
                            var d = res;
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
            $.showPreloader('发表中');
            var ypl = $("#inputDiv").val();
            var atr = $("input[name='atPersonName']").val();
            if (typeof (atr) == "undefined") {
                atr = "";
            }
            var pl = ypl + atr;
            var id = GetQueryString("id");
            var atPersonId = $("input[name='atPersonId']").val();
            if (typeof (atPersonId) == "undefined") {
                atPersonId = "";
            }
            $.ajax({
                type: "POST",
                url: "../Ajax/AjaxGetMsg.aspx/savePLById",
                data: "{id: '" + id + "',pl:'" + pl + "',userID:'" + $("#UserID").val() + "',title:'" + $("#title").val() + "',atPersonId:'" + atPersonId + "',mk:'doc'}",
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
            //TODO
        });
        $("#sendmsg_qx").click(function () {
            $("#inputDiv").val("");
            removeActive();
        });
    </script>
    <script type="text/javascript">
        $('#usersSelect').load('../../WeChat/log/selectUsers.html');
    </script>
</body>
</html>
