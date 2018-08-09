<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignEdit.aspx.cs" Inherits="SignEdit" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx1" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx2" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx3" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx4" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Script/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Script/jquery.js"></script>
    <script type="text/javascript" src="../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../Script/jquery.ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../Script/jquery.ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../Script/jquery.ui/jquery.ui.mouse.js"></script>
    <script type="text/javascript" src="../Script/jquery.ui/jquery.ui.draggable.js"></script>
    <script type="text/javascript" src="../Script/jquery.ui/jquery.ui.position.js"></script>
    <script type="text/javascript" src="../Script/jquery.ui/jquery.ui.resizable.js"></script>
    <script type="text/javascript" src="../Script/jquery.ui/jquery.ui.dialog.js"></script>
    <script type="text/javascript" src="../Script/jw.js"></script>
    <script type="text/javascript" src="../Script/jwJson.js"></script>
    <script type="text/javascript" src="../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="../StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="../StockManage/script/Validation.js"></script>
    <script type="text/javascript" src="../Script/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $('#DocRelationName').attr('readOnly', true);
        //});
        ////选择项目
        //function selectDoc() {
        //    var action = getRequestParam('action');
        //    if (action != 'view') {
        //        jw.selectDoc({ idinput: 'DocRelationIDs', nameinput: 'DocRelationName' });
        //    }
        //}
        //表单验证
        function valForm() {
            if ($('#name').val() == "") {
                alert("系统提示：\n标注名称必须输入！");
                document.getElementById("name").focus();
                return false;
            }
            return true;
        }
        function successed() {
            top.ui.show('保存成功');
            top.ui.closeWin();
            var url = { "url": "/OA3/FileMsg/DocSign/DocSign.aspx?doc_name=" + $("#DocName").val() + "&doc_Id=" + $("#DocId").val() + "&path=" + $("#DocPath").val() };
            top.ui.reloadTab(url);
        }
        function closeTab() {
            top.ui.closeWin();
            if ($("#DocAction").val() != "edit") {
                var url = { "url": "/OA3/FileMsg/DocSign/DocSign.aspx?doc_name=" + $("#DocName").val() + "&doc_Id=" + $("#DocId").val() + "&path=" + $("#DocPath").val() };
                top.ui.reloadTab(url);
            }
        }
    </script>
    <form id="form1" runat="server">
        <input id="hfldTo" type="hidden" style="width: 1px" runat="server" />
        <input id="hfldCopyto" type="hidden" style="width: 1px" runat="server" />
        <div style="height: 95%; overflow: auto; width: 100%">
            <div align="center" id="mTable" style="margin-top: 5px; vertical-align: top;">
                <div style="vertical-align: top;">
                    <table class="tableContent2" cellpadding="5px" cellspacing="0" style="vertical-align: middle; width: 95%">
                        <tr>
                            <td  style=" text-align: right;width: 5%;">标注名称
                            </td>
                            <td class="txt mustInput">
                                <asp:TextBox ID="name" Height="100%" Width="100%" runat="server" class="mustInput"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  style=" text-align: right">标注说明</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="remark" Style="overflow: auto; line-height: 1.25" Height="120px" Width="99%"  Wrap="true" Rows="15" TextMode="MultiLine" runat="server"></asp:TextBox><%--BorderStyle="None"--%>
                            </td>
                        </tr>
                       <tr>
                            <td style="text-align: right;">相关图片
                            </td>
                            <td style="text-align: left"  colspan="3">
                                <MyUserControl:usercontrol_fileupload_fileupload_ascx1 ID="FileUpload1" Name="图片" FileType="*.jpg;*.gif;*.png" Class="SignPhotos" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">相关音频
                            </td>
                            <td style="text-align: left"  colspan="3">
                                <MyUserControl:usercontrol_fileupload_fileupload_ascx3 ID="FileUpload3" Name="音频"  Class="SignVoices" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">相关视频
                            </td>
                            <td style="text-align: left"  colspan="3">
                                <MyUserControl:usercontrol_fileupload_fileupload_ascx4 ID="FileUpload4" Name="视频"  Class="SignVideos" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">相关附件
                            </td>
                            <td style="text-align: left"  colspan="3">
                                <MyUserControl:usercontrol_fileupload_fileupload_ascx2 ID="FileUpload2" Name="附件" Class="SignFiles" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="divFooter2">
            <table class="tableFooter2">
                <tr>
                    <td>
                        <asp:Button ID="btnSave" Text="保存" OnClientClick="return valForm()" OnClick="btnSave_Click" runat="server" Style="width: auto;" />
                        <input type="button" id="btnCancel" value="取消" onclick="closeTab();" />
                    </td>
                </tr>
            </table>
        </div>
    <div id="divFram" title="" style="display: none"><iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe></div>
        <input type="hidden" id="KeyId" runat="server" value="主键ID" />
           <input type="hidden" id="DocId" value="" runat="server"/>
         <input type="hidden" id="DocName" value="" runat="server"/>
         <input type="hidden" id="DocPath" value="" runat="server"/>
         <input type="hidden" id="DocAction" value="" runat="server"/>
    </form>
</body>
</html>

