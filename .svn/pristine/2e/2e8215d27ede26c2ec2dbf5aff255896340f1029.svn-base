<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocEdit.aspx.cs" Inherits="OA3_FileMsg_DocEdit" %>

<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx1" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx2" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx3" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx4" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#DocRelationName').attr('readOnly', true);
        });
        //选择
        function selectDoc() {
            var action = getRequestParam('action');
            if (action != 'view' && action != 'up') {
                jw.selectDoc({ idinput: 'DocRelationIDs', nameinput: 'DocRelationName' });
            }
        }
        function clearD() {
            $("#DocRelationIDs").val("");
            $("#DocRelationName").val("");
        }
        //选择项目
        function openProjPicker() {
            var action = getRequestParam('action');
            if (action != 'view') {
                jw.selectOneProject({ idinput: 'hdnProjectCode', nameinput: 'txtProject' });
            }
        }
        function clearP() {
            $("#hdnProjectCode").val("");
            $("#txtProject").val("");
        }
       
        //表单验证
        function valForm() {
            if ($('#FileName').val() == "") {
                alert("系统提示：\n文档名称必须输入！");
                document.getElementById("FileName").focus();
                return false;
            }
            else if ($('#DocSort').val() == "") {
                alert("系统提示：\n文档序号必须输入！");
                document.getElementById("DocSort").focus();
                return false;
            }
            else if (document.getElementById("DocCode").value == "") {
                alert("系统提示：\n文档编码必须输入！");
                document.getElementById("DocCode").focus();
                return false;
            } 
            return true;
        }
    </script>
    <form id="form1" runat="server">
        <input id="hfldTo" type="hidden" style="width: 1px" runat="server" />
        <input id="hfldCopyto" type="hidden" style="width: 1px" runat="server" />
        <div style="height: 95%; overflow: auto; width: 100%">
            <div align="center" id="mTable" style="margin-top: 5px; vertical-align: top;">
                <div style="vertical-align: top;">
                    <table class="tableContent2" cellpadding="5px" cellspacing="0" style="vertical-align: middle; width: 80%">
                        <tr id="change1" runat="server">
                            <td  style="width: 10%; text-align: right">变更类型</td>
                            <td class="txt mustInput" colspan="2">
                                <asp:DropDownList ID="DocChangeTypeID" runat="server" Width="99%"  class="mustInput"></asp:DropDownList>
                            </td>
                            <td  style="width: 10%; text-align: right">&nbsp;</td>
                            <td class="txt mustInput" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr  id="change2" runat="server">
                            <td  style="width: 10%; text-align: right">变更说明</td>
                            <td class="txt mustInput" colspan="5">
                                <asp:TextBox ID="DocChangeRemark" Height="100%" Width="99%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  style="width: 10%; text-align: right">文档名称
                            </td>
                            <td class="txt mustInput" colspan="2">
                                <asp:TextBox ID="FileName" Height="100%" Width="99%" runat="server" class="mustInput"></asp:TextBox>
                            </td>
                            <td  style="width: 10%; text-align: right">文档序号</td>
                            <td class="txt mustInput" colspan="2">
                                <asp:TextBox ID="DocSort" Height="100%" Width="99%" runat="server" class="mustInput" onkeyup="this.value=this.value.replace(/[^\d]/g,'') " onblur="this.value=this.value.replace(/[^\d]/g,'') "></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  style="width: 10%; text-align: right">文档编码</td>
                            <td style="width: 40%; text-align: left" class="mustInput" colspan="2" >
                                <asp:TextBox ID="DocCode" Height="100%" Width="99%" runat="server"></asp:TextBox>
                            </td>
                            <td  style="width: 10%; text-align: right">文档版本</td>
                            <td style="width: 40%; text-align: left" class="mustInput" colspan="2">
                                <asp:DropDownList ID="DocVersionID" runat="server" Width="99%"></asp:DropDownList>
                            </td>
                        </tr>
                          <tr>
                            <td  style="width: 10%; text-align: right">文档类型</td>
                            <td class="txt mustInput" colspan="2">
                                <asp:DropDownList ID="DocTypeID" runat="server" Width="99%"  class="mustInput"></asp:DropDownList>
                            </td>
                            <td  style="width: 10%; text-align: right">文档状态</td>
                            <td class="txt mustInput" colspan="2">
                                <asp:DropDownList ID="DocStatusID" runat="server" Width="99%" class="mustInput"></asp:DropDownList>
                            </td>
                        </tr>
                      
                        <tr>
                            <td  style="width: 10%; text-align: right">文件作者</td>
                            <td style="text-align: left;" colspan="5" >
                                <asp:TextBox ID="DocAuthor" Height="100%" Width="99%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  style="width: 10%; text-align: right">文档文件 </td>
                            <td style="text-align: left" colspan="5">
                                <MyUserControl:usercontrol_fileupload_fileupload_ascx2 ID="FileUpload2" Name="文件" Class="DocFiles" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td  style="width: 10%; text-align: right">关联文档</td>
                            <td style="text-align: left" class="auto-style2">
                                  <input type="text" id="DocRelationName" readonly="readonly" class="select_input" imgclick="selectDoc" runat="server" />
                                <asp:HiddenField ID="DocRelationIDs" runat="server" />
                            </td>
                            <td style="text-align: left" class="auto-style2">
                                  <input type="button" value="清空" onclick="clearD();" /></td>
                            <td  style="width: 10%; text-align: right">关联项目</td>
                            <td style="text-align: left" class="auto-style2">
                                  <input type="text" id="txtProject" readonly="readonly" class="select_input" imgclick="openProjPicker" runat="server" />
                                <asp:HiddenField ID="hdnProjectCode" runat="server" />
                            </td>
                            <td style="text-align: left" class="auto-style2">
                                   <input type="button" value="清空" onclick="clearP();" /></td>
                        </tr>  
                        <tr>
                            <td  style="width: 10%; text-align: right">备注说明</td>
                            <td style="text-align: left;" colspan="5" >
                                <asp:TextBox ID="Remark" Style="/*background-image: url(img/Txt_bg.jpg); */ overflow: auto; line-height: 1.25" Height="120px" Width="100%"  Wrap="true" Rows="15" TextMode="MultiLine" runat="server"></asp:TextBox><%--BorderStyle="None"--%>
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
                        <input type="button" id="btnCancel" value="取消" onclick="top.ui.closeTab();" />
                    </td>
                </tr>
            </table>
        </div>
        <%--<div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" s rc=""></iframe>
        </div>--%>
        <input type="hidden" id="ParentID" runat="server" value="文件夹ID" />
         <input type="hidden" id="DocAncestorID" runat="server" value="文档原始ID" />
        <input type="hidden" id="KeyId" runat="server" value="主键ID" />
    </form>
</body>
</html>

