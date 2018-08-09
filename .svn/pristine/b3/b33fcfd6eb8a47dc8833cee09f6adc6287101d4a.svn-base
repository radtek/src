<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JournalCheckDetail.aspx.cs" Inherits="oa_JournalManage_JournalCheckDetail" %>

<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Script/jquery.js"></script>
    <script type="text/javascript" src="../StockManage/script/Config2.js"></script>
    <script src="../Script/jw.js" type="text/javascript"></script>
    <script src="../Script/DecimalInput.js" type="text/javascript"></script>

    <link href="../Script/Print/css/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="../Script/Print/css/PrjManager-Print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="../Script/Print/css/print-preview.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../Script/ViewOfficeOnline.js"></script>
    <script src="../Script/Print/jquery.print-preview.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Script/Print/jw.print.js" type="text/javascript"></script>
    <link href="/StyleExt/CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/StockManage/skins/sm4.css" rel="stylesheet" type="text/css" />
    <link href="/StyleCss/Common.css" rel="stylesheet" type="text/css" />
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //打印预览
            $('#btnDy').printPreview();
        });
    </script>
</head>
<body id="print1" style="overflow-y: auto; height: auto;">
    <form id="form1" runat="server">
        <div class="VPage">
            <%-- <div align="center" id="mTable" style="margin-top: 5px; vertical-align: top;">
                <div style="vertical-align: top;">--%>
            <table class="tabCss" style="vertical-align: top; border-collapse: collapse;">
                <tr>
                    <td class="title-divHeader">工作日志信息查阅
                
                <%--<input type="button" style="float: right;" class="noprint" onclick="winPrint()" value=" 打 印 " />
               <input type="button" id="btnDy" style="float: right;" class="noprint" value=" 打 印 "/>--%>
                    </td>
                </tr>
                <tr style="height: 1px;">
                    <td>
                        <table id="bllProducer" cellpadding="0" cellspacing="0" style="border-style: none; width: 100%;">
                            <tr>
                                <td style="border-style: none;">填写人:&nbsp;&nbsp; <asp:Label ID="creater" runat="server"></asp:Label>
                                </td>
                                <td style="border-style: none; text-align: right">填写时间:&nbsp;&nbsp; <asp:Label ID="create_date" runat="server"></asp:Label>
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
                    <td class="descTd">标题
                    </td>
                    <td class="elemTd">
                        <%--<asp:TextBox ID="title" Height="100%" Width="99%" runat="server"></asp:TextBox>--%>
                        <asp:Label ID="title" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">日志开始时间
                    </td>
                    <td class="elemTd">
                        <table>
                            <tr>
                                <td>
                                    <%-- <asp:TextBox ID="start_time" onchange="controlDate()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" CssClass="easyui-validatebox" style="width: 120px;" data-options="required:true" runat="server"></asp:TextBox>--%>
                                    <asp:Label ID="start_time" runat="server"></asp:Label>
                                </td>
                                <td style="width: 5px;"></td>
                                <td style="background-color: #fafafa;">持续
                                            <%--<asp:TextBox ID="txtValue" runat="server" onkeyup="AddOption();" sucmsg="填写正确" Style="text-align: right; width: 40px;" Width="50px" />--%>
                                    <asp:Label ID="txtValue" runat="server"></asp:Label>
                                    <%--<asp:DropDownList ID="ddl" onchange="checkTime()" runat="server" CssClass="ddcss" Width="20px">
                                                <asp:ListItem Value="30">  30分钟(0.5小时)</asp:ListItem>
                                                <asp:ListItem Value="60">  60分钟(1.0小时)</asp:ListItem>
                                                <asp:ListItem Value="90">  90分钟(1.5小时)</asp:ListItem>
                                                <asp:ListItem Value="120">120分钟(2.5小时)</asp:ListItem>
                                                <asp:ListItem Value="150">150分钟(2.5小时)</asp:ListItem>
                                                <asp:ListItem Value="180">180分钟(3.0小时)</asp:ListItem>
                                                <asp:ListItem Value="210">210分钟(3.5小时)</asp:ListItem>
                                                <asp:ListItem Value="240">240分钟(4.0小时)</asp:ListItem>
                                                <asp:ListItem Value="270">270分钟(4.5小时)</asp:ListItem>
                                                <asp:ListItem Value="300">300分钟(5.0小时)</asp:ListItem>
                                                <asp:ListItem Value="330">330分钟(5.5小时)</asp:ListItem>
                                                <asp:ListItem Value="360">360分钟(6.0小时)</asp:ListItem>
                                                <asp:ListItem Value="390">390分钟(6.5小时)</asp:ListItem>
                                                <asp:ListItem Value="420">420分钟(7.0小时)</asp:ListItem>
                                                <asp:ListItem Value="450">450分钟(7.5小时)</asp:ListItem>
                                                <asp:ListItem Value="480">480分钟(8.0小时)</asp:ListItem>
                                            </asp:DropDownList>--%>
                                            分钟
                                </td>
                                <td style="width: 5px;"></td>

                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">日志结束时间
                    </td>
                    <td class="elemTd">
                        <%--<asp:TextBox ID="end_time" onchange="controlDate()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" CssClass="easyui-validatebox" style="width: 120px;" data-options="required:true" runat="server"></asp:TextBox>--%>
                        <asp:Label ID="end_time" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="descTd">内容
                    </td>
                    <td class="elemTd">
                        <%--<asp:TextBox ID="content" TextMode="MultiLine" Height="100px" Width="100%" runat="server"></asp:TextBox>--%>
                        <%--<asp:TextBox ID="content" Style="background-image: url(img/Txt_bg.jpg); overflow: auto; line-height: 1.25" Height="120px" Width="100%" BorderStyle="None" Wrap="true" Rows="15" TextMode="MultiLine" runat="server"></asp:TextBox>--%>
                        <asp:Label ID="content" Style="background-color: #fafafa;" Height="120px" Width="100%" BorderStyle="None" Wrap="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <%--                        <tr>
                            <td  style="text-align: right;" class="auto-style1">封面图片
                            </td>
                            <td  style="text-align: left" class="auto-style2">
                               <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload0" Name="图片" FileType="*.jpg;*.gif;*.png" Class="BuildDiaryPhoto" runat="server" />
                            </td>
                        </tr>--%>

                <tr>
                    <td class="descTd">审阅人
                    </td>
                    <td class="elemTd">
                        <%-- <span class="spanSelect" style="width: 90%">
                                    <asp:TextBox ID="txtTo" Style="width: 90%; height: 15px; border: none; line-height: 16px; margin: 1px 2px"
                                        runat="server"></asp:TextBox>
                                    <img src="../../images1/email/add.jpg" style="float: right; border: none;" alt="选择" id="imgName" onclick="jw.selectOneUser({ nameinput: 'txtTo', codeinput: 'hfldTo' });" runat="server" />

                                </span>
                                <input id="hfldTo" type="hidden" style="width: 1px" runat="server" />--%>
                        <asp:Label ID="txtTo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">相关人
                    </td>
                    <td class="elemTd">
                        <%--<span class="spanSelect" style="width: 90%;">
                                    <asp:TextBox ID="txtCopyto" Style="width: 90%; height: 15px; border: none; line-height: 16px; margin: 1px 2px"
                                        runat="server"></asp:TextBox>
                                    <img src="../../images1/email/add.jpg" style="float: right;" alt="选择" id="img1" onclick="jw.selectMultiUser({ nameinput: 'txtCopyto', codeinput: 'hfldCopyto' });" runat="server" />

                                </span>
                                <input id="hfldCopyto" type="hidden" style="width: 1px" runat="server" />--%>
                        <asp:Label ID="txtCopyto" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">相关图片
                    </td>
                    <td class="elemTd" id="FileUpload1" runat="server"></td>
                </tr>
                <tr>
                    <td class="descTd">相关附件
                    </td>
                    <td class="elemTd" id="FileUpload2" runat="server"></td>
                </tr>
                <tr>
                    <td class="descTd">关联项目</td>
                    <td class="elemTd">
                        <%--<input type="text" id="txtProject" readonly="readonly" class="select_input" imgclick="openProjPicker" runat="server" />

                                <asp:HiddenField ID="hdnProjectCode" runat="server" />--%>
                        <asp:Label ID="txtProject" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">关联任务
                    </td>
                    <td class="elemTd">
                        <%-- <input type="text" id="tasks" readonly="readonly" class="select_input" imgclick="openProjPicker" runat="server" />
					<asp:HiddenField ID="HiddenField1" runat="server" />--%>
                        <asp:Label ID="tasks" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr id="PFLabel" runat="server">

                    <td class="descTd">评分
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="Labelscore" runat="server"></asp:Label></td>
                </tr>


                <tr id="PLtitle" runat="server">
                    <td  class="descTd" colspan="2"> 
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




                <tr id="PF" runat="server">

                    <td class="descTd">审阅人评分
                    </td>
                    <td class="elemTd">
                        <asp:RadioButtonList ID="score" runat="server" RepeatDirection="Horizontal" style="float: left;">
                            <asp:ListItem Value="10">10分</asp:ListItem>
                            <asp:ListItem Value="9">9分</asp:ListItem>
                            <asp:ListItem Value="8">8分</asp:ListItem>
                            <asp:ListItem Value="7">7分</asp:ListItem>
                            <asp:ListItem Value="6">6分</asp:ListItem>
                            <asp:ListItem Value="5">5分</asp:ListItem>
                            <asp:ListItem Value="4">4分</asp:ListItem>
                            <asp:ListItem Value="3">3分</asp:ListItem>
                            <asp:ListItem Value="2">2分</asp:ListItem>
                            <asp:ListItem Value="1">1分</asp:ListItem>
                            <asp:ListItem Value="0">0分</asp:ListItem>
                        </asp:RadioButtonList>
                        <input id="SubmitPF" name="submit" type="submit" value="提交评分" style="width: auto;float: right;margin-top: 5px;" onserverclick="SubmitPF_Click" runat="server" />
                    </td>
                </tr>
                <tr>

                    <td class="descTd">发表评论
                    </td>
                    <td class="descTd">
                        <asp:TextBox ID="comment_content" Style="background-image: url(img/Txt_bg.jpg); overflow: auto; line-height: 1.25" Height="120px" Width="100%" BorderStyle="None"  Wrap="true" Rows="15" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>

                  <tr>

                    <td class="descTd">
                    </td>
                    <td class="descTd">
                        <table class="tableFooter2">
                <tr> <td>
                        <input id="btnSave" name="submit" type="submit" value="提交评论" style="width: auto;" onserverclick="btnSave_Click" runat="server" />
                        <input type="button" id="btnCancel" value="关闭" onclick="top.ui.closeTab();" />
                     </td>
                </tr>
            </table>
                        <%--<div class="divFooter2">
            <table class="tableFooter2">
                <tr> <td>
                    </td>
                </tr>
            </table>
        </div>--%>
                          </td>
                </tr>
            </table>
        </div>
        
        <div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
        <input type="hidden" id="KeyId" runat="server" />
        <input type="hidden" id="hdnDelPlanId" runat="server" />
    </form>
</body>
</html>
