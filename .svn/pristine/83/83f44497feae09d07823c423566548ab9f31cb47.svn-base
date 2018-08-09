<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AsTestEdit.aspx.cs" Inherits="AsTestEdit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/StockManage/script/Validation.js" charset="gb2312"></script>
    <script type="text/javascript" src="../Script/DecimalInput.js"></script>
    <script type="text/javascript" src="../Script/jw.js"></script>
    <script type="text/javascript" src="../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            Val.validate('form1', 'btnSave');

        });

        function selectOneUser() {

            jw.selectOneUser({ codeinput: 'hlfUserCode', nameinput: 'txtUserName' });
        }

        //取消按钮事件
        function CancelClick() {
            winclose('AsTestEdit.aspx', 'AsTestEdit.aspx', false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr style="height: 100%;">
                    <td style="height: 100%; vertical-align: top;">
                        <div id="divScroll" runat="server">
                            <table width="100%" cellpadding="0" cellspacing="0" id="tb">
                                <tr>
                                    <td>
                                        <fieldset style="width: 85%; margin: auto; text-align: center">
                                            <legend>编辑</legend>
                                            <table id="table5" class="tableContent2" style="width: 95%" cellpadding="5px" cellspacing="0">
                                                <tr>
                                                    <td class="word">申请人
                                                    </td>
                                             
                                                    <td class="txt">
                                                        <asp:TextBox ID="ApplicantId" ReadOnly="true" CssClass="select_input" imgclick="selectOneUser" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="hlfUserCode" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="word">申请金额
                                                    </td>
                                               
                                                    <td class="txt mustInput">
                                                        <asp:TextBox ID="Cash" class="decimal_input {required:true, messages:{required:'金额不能为空'}}" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="word">申请缘由
                                                    </td>
                                              
                                                    <td class="txt ">
                                                        <asp:TextBox ID="ApplicationReason" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="Div1" class="divFooter2" runat="server">
                            <table class="tableFooter2">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" />
                                        <input type="button" id="btnCancel" value="取消" onclick="CancelClick()" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
