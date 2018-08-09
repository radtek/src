<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckView.aspx.cs" Inherits="OA3_WorkLog_CheckView" %>

<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--    <title></title>
    <link href="/Script/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.mouse.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.draggable.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.position.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.resizable.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.dialog.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="/Script/jwJson.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/StockManage/script/Validation.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>

    <link href="/StyleExt/CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/StockManage/skins/sm4.css" rel="stylesheet" type="text/css" />
    <link href="/StyleCss/Common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtTo').attr('readOnly', true);
            $('#Copyto').attr('readOnly', true);
        });
    </script>--%>
    <title></title>
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <link href="/StyleExt/CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/StockManage/skins/sm4.css" rel="stylesheet" type="text/css" />
    <link href="/StyleCss/Common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtTo').attr('readOnly', true);
            $('#Copyto').attr('readOnly', true);
            replaceEmptyTable('emptyTable', 'gvDiary_MX');
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
            top.ui.openWin({ title: '相关图片', url: url, width: 450, height: 450 });
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
<body id="print1" style="overflow-y: auto; height: auto;">
    <form id="form1" runat="server">
        <div class="VPage">
            <table class="tabCss" style="vertical-align: top; border-collapse: collapse;">
                <tr>
                    <td class="title-divHeader">工作日志详情
           <%-- <input type="button" style="float: right;" class="noprint" onclick="winPrint()" value=" 打 印 " />--%>
                    </td>
                </tr>
                <tr style="height: 1px;">
                    <td>
                        <table id="bllProducer" cellpadding="0" cellspacing="0" style="border-style: none; width: 100%;">
                            <tr>
                                <td style="border-style: none;">填写人:&nbsp;&nbsp;
                                    <asp:Label ID="creater" runat="server"></asp:Label>
                                </td>
                                <td style="border-style: none; text-align: right">填写时间:&nbsp;&nbsp;
                                    <asp:Label ID="create_date" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">工作日志详情</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="tabCss" style="vertical-align: top; border-collapse: collapse;">
                <%-- <tr>
                    <td class="descTd">填写人</td>
                    <td class="elemTd">
                       
                    </td>
                </tr>
                <tr>
                    <td class="descTd">填写时间
                    </td>
                    <td class="elemTd">
                       
                    </td>
                </tr>--%>
                <tr>
                    <td class="descTd">日志类型</td>
                    <td class="elemTd">
                        <%-- <asp:DropDownList ID="type_id"  runat="server" Width="99%" onchange="typeChange()"></asp:DropDownList>--%>
                        <asp:Label ID="type_id" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">日志标题
                    </td>
                    <td class="elemTd">
                        <%--<asp:TextBox ID="title" Height="100%" Width="99%" runat="server"></asp:TextBox>--%>
                        <asp:Label ID="title" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">开始时间
                    </td>
                    <td class="elemTd">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="start_time" runat="server"></asp:Label>
                                </td>
                                <td style="width: 5px;"></td>
                                <td style="background-color: #fafafa;">持续<asp:Label ID="txtValue" runat="server"></asp:Label>
                                    分钟
                                </td>
                                <td style="width: 5px;"></td>

                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">结束时间
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="end_time" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="descTd">日志内容
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="content" Style="background-color: #fafafa;" Height="120px" Width="100%" BorderStyle="None" Wrap="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">审阅人
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="txtTo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">相关人
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="txtCopyto" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr id="photo" style="height: 150px;">
                        <td class="descTd" valign="middle" align="center">
                            相关图片
                        </td>
                        <td  style="vertical-align: middle">
                            <div style="width: 35px; float: left; padding-top: 60px;">
                                <input class="noprint" type="button" value="<<" onclick="pre();" style="width: 35px" /></div>
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
                                <input class="noprint" type="button" value=">>" onclick="next();" style="width: 35px" /></div>
                        </td>
                    </tr>
             <%--   <tr>
                    <td class="descTd">相关图片
                    </td>
                    <td class="elemTd" id="FileUpload1" runat="server"></td>
                </tr>--%>
                 <tr id="videos">
                        <td class="descTd" valign="middle" align="center">
                            相关音频
                        </td>
                        <td   class="elemTd">
                            <%=voices %>
                        </td>
                    </tr>
                      <tr id="voices">
                        <td class="descTd" valign="middle" align="center">
                            相关视频
                        </td>
                        <td   class="elemTd">
                            <%=videos %>
                        </td>
                    </tr>
           <%--     <tr>
                    <td class="descTd">相关音频
                    </td>
                    <td class="elemTd" id="FileUpload3" runat="server"></td>
                </tr>
                <tr>
                    <td class="descTd">相关视频
                    </td>
                    <td class="elemTd" id="FileUpload4" runat="server"></td>
                </tr>--%>
                <tr>
                    <td class="descTd">相关附件
                    </td>
                    <td class="elemTd" id="FileUpload2" runat="server"></td>
                </tr>
                <tr>
                    <td class="descTd">关联项目</td>
                    <td class="elemTd">
                        <asp:Label ID="txtProject" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">关联任务
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="tasks" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr id="PFLabel" runat="server">

                    <td class="descTd">日志评价
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="Labelscore" runat="server"></asp:Label></td>
                </tr>


                <tr id="PLtitle" runat="server">
                    <td class="descTd" colspan="2">
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">工作日志评论</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                    </td>
                </tr>
                <%=PL %>


                <%--<tr>
                            <td style='width: 10%; text-align: right'></td>
                            <td style='text-align: left' class='auto-style3'>无</td>
                        </tr>--%>

                <%--<tr>
                            <td style='width: 10%; text-align: right' rowspan='2'></td>
                            <td style='width: 10%; text-align: left'>
                                评论内容
                            </td>
                        </tr>
                        <tr>
                            <td style='text-align: right' class='auto-style3'>评论时间:2017-12-04 23:20:06
                                &nbsp;&nbsp;评论人:张三</td>
                        </tr>--%>
                <tr id="Tr1" runat="server">
                    <td class="descTd" colspan="2">
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">发表评论</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                    </td>
                </tr>
                <tr id="PF" runat="server">
                    <td class="descTd">工作日志评价
                    </td>
                    <td class="elemTd">
                        <asp:RadioButtonList ID="score" runat="server" RepeatDirection="Horizontal" Style="float: left;">
                            <asp:ListItem Value="3">优秀</asp:ListItem>
                            <asp:ListItem Value="2">良好</asp:ListItem>
                            <asp:ListItem Value="1">一般</asp:ListItem>
                        </asp:RadioButtonList>
                        <input id="SubmitPF" name="submit" type="submit" value="提交评价" style="width: auto; float: left; margin-top: 5px;margin-left: 20px;" onserverclick="SubmitPF_Click" runat="server" />
                    </td>
                </tr>


                <tr>

                    <td class="descTd">评论内容
                    </td>
                    <td class="descTd">
                        <asp:TextBox ID="comment_content" Style="background-image: url(img/Txt_bg.jpg); overflow: auto; line-height: 1.25" Height="120px" Width="100%" BorderStyle="None" Wrap="true" Rows="15" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">评论中@相关人
                    </td>
                    <td class="descTd">
                        <span class="spanSelect" style="width: 100%;">
                            <asp:TextBox ID="Copyto" Style="width: 90%; height: 12px; border: none; line-height: 12px; margin: 1px 2px" runat="server"></asp:TextBox>
                            <img src="../../images/icon_17.bmp" style="float: right;" alt="选择" id="img1" onclick="jw.selectMultiUser({ nameinput: 'Copyto', codeinput: 'hfldCopyto' });" runat="server" />
                        </span>
                        <input id="hfldCopyto" type="hidden" style="width: 1px" runat="server" />
                    </td>
                </tr>
                <tr>

                    <td class="descTd"></td>
                    <td class="descTd">
                        <table class="tableFooter2">
                            <tr>
                                <td>
                                    <input id="btnSave" name="submit" type="submit" value="提交评论" style="width: auto;" onserverclick="btnSave_Click" runat="server" />
                                    <input type="button" id="btnCancel" value="关闭" onclick="top.ui.closeTab();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>

        <div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
        <input type="hidden" id="KeyId" runat="server" />
     <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload1" Name="图片" FileType="*.jpg;*.gif;*.png" Class="JournalPhotos" Visible="false" runat="server" />
     <asp:HiddenField ID="hfldImgPath" Value="" runat="server" />

     <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload3" Name="音频"  Class="JournalVoices" Visible="false" runat="server" />

     <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload4" Name="视频" Class="JournalVideos" Visible="false" runat="server" />
    </form>
</body>
</html>
 