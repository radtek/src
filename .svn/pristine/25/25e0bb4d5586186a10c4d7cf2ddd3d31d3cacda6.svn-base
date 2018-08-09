<%@ Page Language="C#" AutoEventWireup="true" CodeFile="writeName.aspx.cs" Inherits="WeChat_writeName_writeName" %>

<!DOCTYPE html>

<html lang="zh">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />

    <title>手写签名</title>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.2.0/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="css/default.css">
    <script src="js/jquery-1.11.0.min.js"></script>
    <script src="js/jq-signature.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            stopDrop();
        });
        /**
         * 禁止浏览器下拉回弹
         */
        function stopDrop() {
            var lastY;//最后一次y坐标点
            $(document.body).on('touchstart', function (event) {
                lastY = event.originalEvent.changedTouches[0].clientY;//点击屏幕时记录最后一次Y度坐标。
            });
            $(document.body).on('touchmove', function (event) {
                var y = event.originalEvent.changedTouches[0].clientY;
                var st = $(this).scrollTop(); //滚动条高度  
                if (y >= lastY && st <= 10) {//如果滚动条高度小于0，可以理解为到顶了，且是下拉情况下，阻止touchmove事件。
                    lastY = y;
                    event.preventDefault();
                }
                lastY = y;

            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="word-break: normal; font-family: -apple-system-font, 'Helvetica Neue', 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', sans-serif; background-size: cover; word-wrap: break-word; word-break: break-all; background: #f5f5f5 no-repeat center;">
        <input id="dataUrl" type="hidden" runat="server" />
        <asp:Button ID="btnSave" runat="server" Text="Button" OnClick="btnSave_Click" Style="display: none;" />
    </form>

    <div class="htmleaf-container">
        <div class="container">
            <div class="row" style="display: none;">
                <div class="col-xs-12">
                    <div class="js-signature"></div>
                </div>
            </div>
            <div class="row" style="margin-top: 20px;">
                <div class="col-xs-12">
                    <div class="js-signature" data-width="600" data-height="300" data-border="1px solid black" data-line-color="#bc0000" data-auto-fit="true"></div>
                    <p>
                        <button id="clearBtn" class="btn btn-default" onclick="clearCanvas();">清空签名</button>
                        &nbsp;
                    <button id="saveBtn" class="btn btn-default" onclick="saveSignature();" disabled>保存签名</button>
                    </p>
                    <div id="signature" style="display: none;">
                        <p>当您单击“生成签名”时，您的签名会出现在这里</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).on('ready', function () {
            if ($('.js-signature').length) {
                $('.js-signature').jqSignature();
            }
        });
        function clearCanvas() {
            $('#signature').html('<p>当您单击“生成签名”时，您的签名会出现在这里</p>');
            $('.js-signature').eq(1).jqSignature('clearCanvas');
            $('#saveBtn').attr('disabled', true);
        }
        //获取url参数
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        function saveSignature() {
            $('#signature').empty();
            var dataUrl = $('.js-signature').eq(1).jqSignature('getDataURL');
            //alert(dataUrl);
            $('#dataUrl').val(dataUrl);
            $('#btnSave').click();


            //$('#signature').empty();
            //var dataUrl = $('.js-signature').eq(1).jqSignature('getDataURL');
            //console.log(dataUrl);
            //parent.

            //var type = GetQueryString("type");
            //if (type == "before") {
            //    parent.$('#btnOk').click();
            //}
            //if (type == "after") {
            //    parent.$('#btnOkAfter').click();
            //}
            //page_close();
            //var img = $('<img>').attr('src', dataUrl);
            //$('#signature').append($('<p>').text("生成的签名:"));
            //$('#signature').append(img);
        }

        $('.js-signature').eq(1).on('jq.signature.changed', function () {
            $('#saveBtn').attr('disabled', false);
        });
        //注意：parent 是 JS 自带的全局对象，可用于操作父页面
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        // 关闭
        function page_close() {
            parent.layer.close(index);
        }
        // 选择供应商
        function pickCorp() {
            jw.selectOneCorp({ idinput: 'hfldCorp', nameinput: 'txtCorp', winNo: 2 });
        }
    </script>
</body>
</html>
