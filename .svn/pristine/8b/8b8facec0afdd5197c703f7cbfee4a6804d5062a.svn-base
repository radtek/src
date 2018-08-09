<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AsTestDetail.aspx.cs" Inherits="AsTestDetail" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_audit_ascx" Src="~/UserControl/Audit.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>证书查看</title><link rel="Stylesheet" type="text/css" href="/Script/Print/css/print-preview.css" media="screen" />
<link rel="Stylesheet" type="text/css" href="/Script/Print/css/print.css" media="print" />

	
	<script type="text/javascript" src="/Script/jquery.js"></script>
	<script type="text/javascript" src="/Script/Print/jquery.print-preview.js" charset="utf-8"></script>
	<script type="text/javascript" src="/Script/jw.js"></script>
	<script type="text/javascript" src="/Script/Print/jw.print.js"></script>
	<script type="text/javascript" src="/Script/DecimalInput.js"></script>
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
	<script type="text/javascript" src="../../StockManage/script/JustWinTable.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        // 显示大写金额
	        $('#spanCashWords').html(jw.amountInWords($('#lblCash').html()));

	        // 初始化打印页面样式
	        initialPrint();
	        // 打印
	        $('.tabHeader').css('width', '650px');
	        $('.tab2').css('width', '650px');
	        $('#tabAudit').css('border-top','none');

	        // 打印预览
	        $('#btnPrint').printPreview();
	    });
	</script>
    <script type="text/javascript">
        function printURL() {
            var id = $('#hfldPettyCashIds').val();
            //window.open("/PettyCash/PettyCashDetail2.aspx?showAudit=' + $('#hfldshowAudit').val() + '&ic=" + id);
            var url = '/PettyCash/PettyCashDetail2.aspx?ic=' + id;
            viewopen(url);
        }
    </script>
</head>
<body id="print">
	<form id="form1" runat="server">
	<div style="overflow: auto;">

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


		<MyUserControl:usercontrol_audit_ascx ID="Audit1" runat="server" />
	</div>
    <asp:HiddenField ID="hfldPettyCashIds" runat="server" />
    <asp:HiddenField ID="hfldshowAudit" runat="server" />
	</form>
</body>
</html>
