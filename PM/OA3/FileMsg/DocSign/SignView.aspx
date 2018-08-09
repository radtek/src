<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignView.aspx.cs" Inherits="SignView" %>

<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../../Script/jquery.js"></script>
    <%--<script type="text/javascript" src="../../../Script/jw.js"></script>--%>
    <script type="text/javascript" src="../../../StockManage/script/Config2.js"></script>
    <link href="/StyleExt/CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/StockManage/skins/sm4.css" rel="stylesheet" type="text/css" />
    <link href="/StyleCss/Common.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript" src="../../../Script/DecimalInput.js"></script>--%>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            getImgPath();
        });
        var imgArr = new Array();
        var imgLength = 0;
        function showImg(imgUrl, imgIndex) {
            var img3 = parseInt($('#img3').attr('alt'));
            if (imgIndex == 1) {
                imgIndex = img3 - 1;
            }
            else {

                if (imgIndex == 2) {
                    imgIndex = img3;
                }
                else {
                    if (imgIndex == 3) {
                        imgIndex = 4;
                    }
                }
            }
            var url = '/EPC/BuildDiary/ShowImg.aspx?imgUrl=' + imgUrl + '&imgIndex=' + imgIndex + '&imgPath=' + $('#hfldImgPath').val();
            top.ui.openWin({ title: '相关图片', url: url, width: 950 });
            //title = '相关图片';
            //toolbox_oncommand(url, title);
        }
        function getImgPath() {
            var str = $('#hfldImgPath').val();
            if (str.length <= 2) {
                $('#photo').hide();
            }
            JSON.parse(str, function (k, v) {
                if (v != ',') {
                    imgArr.push(v);
                }
            });
            if (imgArr.length >= 3) {
                imgLength = imgArr.length - 1;
            }
            else {
                imgLength = imgArr.length;
            }
            if (imgLength > 0) {
                if (imgLength == 1) {
                    $('#img1').attr('src', imgArr[0]);
                    $('#img2').hide();
                    $('#img3').hide();
                    $('#img3').attr('alt', 1);
                }
                if (imgLength == 2) {
                    $('#img1').attr('src', imgArr[0]);
                    $('#img2').attr('src', imgArr[1]);
                    $('#img3').hide();
                    $('#img3').attr('alt', 2);
                }
                if (imgLength >= 3) {
                    $('#img1').attr('src', imgArr[0]);
                    $('#img2').attr('src', imgArr[1]);
                    $('#img3').attr('src', imgArr[2]);
                    $('#img3').attr('alt', 3);
                }
            }
        }
        //向后翻
        function next() {
            var imgIndex = parseInt($('#img3').attr('alt'));
            if (imgLength <= 3 || imgIndex < 3) {
                return;
            }
            else {
                if (imgLength == imgIndex) {
                    $('#img1').attr('src', imgArr[0]);
                    $('#img2').attr('src', imgArr[1]);
                    $('#img3').attr('src', imgArr[2]);
                    $('#img3').attr('alt', 3);
                    $('#img2').show();
                    $('#img3').show();
                    return false;
                }
                if (imgLength - imgIndex == 1) {
                    $('#img1').attr('src', imgArr[imgIndex]);
                    $('#img2').hide();
                    $('#img3').hide();
                    $('#img3').attr('alt', ++imgIndex);
                    return false;
                }
                if (imgLength - imgIndex == 2) {
                    $('#img1').attr('src', imgArr[imgIndex]);
                    $('#img2').attr('src', imgArr[++imgIndex]);
                    $('#img3').hide();
                    $('#img3').attr('alt', ++imgIndex);
                    $('#img2').show();
                    return false;
                }
                if (imgLength - imgIndex >= 3) {
                    $('#img1').attr('src', imgArr[imgIndex]);
                    $('#img2').attr('src', imgArr[++imgIndex]);
                    $('#img3').attr('src', imgArr[++imgIndex]);
                    $('#img3').attr('alt', ++imgIndex);
                    $('#img2').show();
                    $('#img3').show();
                    return false;
                }
            }
        }
        //向前翻
        function pre() {
            var img1Index;
            if (imgLength <= 3) {
                return;
            }
            else {
                var imgIndex = parseInt($('#img3').attr('alt'));
                if (imgIndex == 3) {
                    img1Index = imgLength - 1;
                    $('#img1').attr('src', imgArr[img1Index]);
                    $('#img3').attr('alt', ++img1Index);
                    $('#img2').hide();
                    $('#img3').hide();
                    return;
                }
                if (imgLength == imgIndex) {
                    img1Index = imgIndex - 5;
                    $('#img1').attr('src', imgArr[img1Index]);
                    $('#img2').attr('src', imgArr[++img1Index]);
                    $('#img3').attr('src', imgArr[++img1Index]);
                    $('#img3').attr('alt', ++img1Index);
                    $('#img2').show();
                    $('#img3').show();
                    return false;
                }
                if (imgLength - imgIndex == 1) {
                    img1Index = imgIndex;
                    $('#img1').attr('src', imgArr[img1Index]);
                    $('#img3').attr('alt', ++img1Index);
                    $('#img2').hide();
                    $('#img3').hide();
                    return;
                }
                if (imgLength - imgIndex == 2) {
                    img1Index = imgIndex;
                    $('#img1').attr('src', imgArr[img1Index]);
                    $('#img2').attr('src', imgArr[++img1Index]);
                    $('#img3').attr('alt', ++img1Index);
                    $('#img2').show();
                    $('#img3').hide();
                    return false;
                }
                if (imgLength - imgIndex >= 3) {
                    img1Index = imgLength - 4;
                    $('#img1').attr('src', imgArr[img1Index]);
                    $('#img2').attr('src', imgArr[++img1Index]);
                    $('#img3').attr('src', imgArr[++img1Index]);
                    $('#img3').attr('alt', ++img1Index);
                    $('#img2').show();
                    $('#img3').show();
                    return false;
                }
            }
        }
    </script>
</head>
<body id="print1" style="overflow-y: auto; height: auto; min-width: 920px;">
    <form id="form1" runat="server">
        <div class="VPage">
            <table class="tableContent2" cellpadding="5px" cellspacing="0" style="vertical-align: middle; width: 100%">
                <tr>
                    <td style="text-align: right; width: 5%;">标注名称
                    </td>
                    <td class="txt mustInput"><asp:Label ID="name" runat="server" Text=""></asp:Label>
                       <%-- <asp:TextBox ID="name" Height="100%" Width="100%" runat="server" class="mustInput" ReadOnly></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">标注说明</td>
                    <td style="text-align: left;"><asp:Label ID="remark" runat="server" Text=""></asp:Label>
                        <%--<asp:TextBox ID="remark" Style="overflow: auto; line-height: 1.25" Height="120px" Width="99%" Wrap="true" Rows="15" TextMode="MultiLine" runat="server" ReadOnly></asp:TextBox>--%><%--BorderStyle="None"--%>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align: right; width: 5%;">标注时间
                    </td>
                    <td class="txt mustInput">
                        <asp:Label ID="sign_time" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="photo" style="height: 150px;">
                    <td class="descTd" valign="middle" align="center">相关图片
                    </td>
                    <td style="vertical-align: middle">
                        <div style="width: 35px; float: left; padding-top: 60px;">
                            <input class="noprint" type="button" value="<<" onclick="pre();" style="width: 35px" />
                        </div>
                        <div style="width: 600px; height: 140px; float: left; padding-left: 13px; padding-top: 5px; padding-bottom: 5px; overflow: hidden;">
                            <table style="border: none; border-width: 0px; text-align: right;">
                                <tr>
                                    <td style="border: none; border-width: 0px; width: 200px;">
                                        <img alt="" id="img1" style="height: 140px; width: 200px;" src="" onclick="showImg(this.src,1)" />
                                    </td>
                                    <td style="border: none; border-width: 0px; width: 200px;">
                                        <img alt="" id="img2" style="height: 140px; width: 200px;" src="" onclick="showImg(this.src,2)" />
                                    </td>
                                    <td style="border: none; border-width: 0px; width: 200px;">
                                        <img alt="" id="img3" style="height: 140px; width: 200px;" src="" onclick="showImg(this.src,3)" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        &nbsp
                            <div style="width: 35px; float: right; padding-top: 60px;">
                                <input class="noprint" type="button" value=">>" onclick="next();" style="width: 35px" />
                            </div>
                    </td>
                </tr>
                <tr id="videos">
                    <td class="descTd" valign="middle" align="center">相关音频
                    </td>
                    <td class="elemTd">
                        <%=voices %>
                    </td>
                </tr>
                <tr id="voices"><%--style="height: 150px;"--%>
                    <td class="descTd" valign="middle" align="center">相关视频
                    </td>
                    <td class="elemTd">
                        <%=videos %>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">相关附件
                    </td>
                    <td class="elemTd" id="FileUpload2" runat="server"></td>
                </tr>
            </table>
        </div>
        <div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>

        <input id="hfldTo" type="hidden" style="width: 1px" runat="server" />
        <input id="hfldCopyto" type="hidden" style="width: 1px" runat="server" />
        <input type="hidden" id="KeyId" runat="server" value="主键ID" />
        <input type="hidden" id="DocId" value="" runat="server" />
        <input type="hidden" id="DocName" value="" runat="server" />
        <input type="hidden" id="DocPath" value="" runat="server" />
        <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload1" Name="图片" FileType="*.jpg;*.gif;*.png" Class="SignPhotos" Visible="false" runat="server" />
        <asp:HiddenField ID="hfldImgPath" Value="" runat="server" />
        <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload3" Name="音频" Class="SignVoices" Visible="false" runat="server" />
        <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload4" Name="视频" Class="SignVideos" Visible="false" runat="server" />
    </form>
</body>
</html>

