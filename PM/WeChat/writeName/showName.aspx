<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showName.aspx.cs" Inherits="showName" %>

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
        <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript">
        //获取url参数
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        $(document).ready(function () {
            var orid = GetQueryString("orid");
            var img = "";
            $.ajax({
                type: "POST",
                url: "/WeChat/writeName/showName.aspx/getImg",
                data: "{orid: '" + orid + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function Success(data) {
                    if (data.d != "") {
                        //alert(data.d);
                        img = $('<img>').attr('src', data.d);
                        $('#signature').empty();
                        $('#signature').append($('<p>').text(""));
                        $('#signature').append(img);
                    } else {
                    }
                }
            });
           
           
        });
    </script>
</head>
<body>
    <div class="htmleaf-container">
        <div class="container">
            <div class="row" style="display:none;">
                <div class="col-xs-12">
                    <div class="js-signature"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <div style="display:none;" class="js-signature" data-width="600" data-height="200" data-border="1px solid black" data-line-color="#bc0000" data-auto-fit="true"></div>
                    <p style="display:none;">
                    <button id="clearBtn" class="btn btn-default" onclick="clearCanvas();">清空签名</button>
                        &nbsp;
                    <button id="saveBtn" class="btn btn-default" onclick="saveSignature();" disabled>保存签名</button>
                    </p>
                    <div id="signature" style="display:;">
                        <p></p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="js/jquery-1.11.0.min.js"></script>
    <script src="js/jq-signature.js"></script>
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

        function saveSignature() {
            $('#signature').empty();
            var dataUrl = $('.js-signature').eq(1).jqSignature('getDataURL');
            console.log(dataUrl);
            parent.$('#dataUrl').val(dataUrl);
            parent.$('#btnOk').click();
            page_close();
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
