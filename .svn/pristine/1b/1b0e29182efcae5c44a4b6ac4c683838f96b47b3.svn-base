<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseHistory.aspx.cs" Inherits="PurchaseHistory" %>

<%@ Import Namespace="cn.justwin.BLL" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.easyui/themes/icon.css" />
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="../../StockManage/script/JustWinTable.js"></script>
    <script language="Javascript" type="text/javascript" src="../../Web_Client/Tree.js"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script language="Javascript" type="text/javascript">
        $(document).ready(function () {
            // 添加验证
            $('#searcheBt')[0].onclick = function () { if (!$('#form1').form('validate')) return false; }
            var gvw = new JustWinTable('GridView1');
            replaceEmptyTable('emptyTable', 'GridView1');
            showTooltip('tooltip', 10);
        });

        function saveEvent() {
            if (typeof top.ui.callback == 'function') {
                var con = {};
                con.id = $('#hfldContractId').val();
                con.name = $('#hfldContractName').val();
                con.bname = $('#hfldBName').val();
                con.prjId = $('#hfldPrjID').val();
                con.prjName = $('#hfldPrjName').val();
                top.ui.callback(con);
                top.ui.callback = null;
            }
            top.ui.closeWin();
        }

        function clickRow(theId, theName, theBName, prjID, prjName) {
            document.getElementById("btnSave").disabled = false;
            $('#hfldContractId').val(theId);
            $('#hfldContractName').val(theName);
            $('#hfldBName').val(theBName);
            $('#hfldPrjID').val(prjID);
            $('#hfldPrjName').val(prjName);
        }
        //双击获得合同信息
        function doDblClickRow(ContCode) {
            $('#btnSave').click();
        }
    </script>
    <style type="text/css">
        .button-normal {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divContent">
            <table class="tableContent" cellpadding="2px" cellspacing="0" style="margin-left: auto;">
                <tr>
                    <td>
                        <table style="border-collapse: separate; border-spacing: 0px; border-width: 0px;">
                            <tr style="height: 25px;">
                                <td>&nbsp;&nbsp;品牌&nbsp;
                                <asp:TextBox ID="Brand" Width="80px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td>&nbsp;&nbsp;型号&nbsp;
                                <asp:TextBox ID="ModelNumber" Width="80px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td>&nbsp;&nbsp;
                                <asp:Button ID="searcheBt" CssClass="button-normal" Text="查询" OnClick="searcheBt_Click" runat="server" Width="40px" />
                                </td> 
                                <td style="display: none;">&nbsp;&nbsp;<asp:Button ID="btnExecl" CssClass="button-normal" Text="导出" OnClick="btnExecl_Click" runat="server" /></td>
                                </tr>
                        </table>
                    </td>
                </tr>
                <tr style="vertical-align: top">
                    <td style="width: 100%;">
                        <div class="pagediv" style="">
                            <asp:GridView ID="gvwPurchaseplanStock" AutoGenerateColumns="false"   DataKeyNames="ResourceCode" runat="server">
                                <EmptyDataTemplate>
                                    <table id="emptyStock" class="tab">
                                        <tr class="header">
                                            <th scope="col" style="width: 25px;">序号
                                            </th>
                                            <th scope="col">物资编号
                                            </th>
                                            <th scope="col">物资名称
                                            </th>
                                            <th scope="col">规格
                                            </th>
                                            <th scope="col">型号
                                            </th>
                                            <th scope="col">品牌
                                            </th>
                                            <th scope="col">技术参数
                                            </th>
                                            <th scope="col">单位
                                            </th>
                                            <th scope="col">数量
                                            </th>
                                            <th scope="col">采购价格
                                            </th>
                                            <th scope="col">供应商
                                            </th>
                                            <th scope="col">实际到货日期
                                            </th>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="物资编号">
                                        <ItemTemplate>
                                            <%# Eval("ResourceCode") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="物资名称">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("ResourceName").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("ResourceName").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="规格">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("Specification").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("Specification").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="型号">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("ModelNumber").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("ModelNumber").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="品牌">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("brand").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("brand").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="技术参数">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("TechnicalParameter").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("TechnicalParameter").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="数量">
                                        <ItemTemplate>
                                            <%# System.Convert.ToDecimal(Eval("number")).ToString("0.000") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="采购价格">
                                        <ItemTemplate>
                                            <%# System.Convert.ToDecimal(Eval("sprice")).ToString("0.000") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="小计" ItemStyle-CssClass="decimal_input">
                                        <ItemTemplate>
                                            <%# System.Convert.ToDecimal(Eval("Total")).ToString("0.000") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="供应商">
                                        <ItemTemplate>
                                         <%# System.Convert.ToString(Eval("CorpName"), System.Globalization.CultureInfo.CurrentCulture) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="采购编号">
                                        <ItemTemplate>
                                             <%# Eval("pscode") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="录入时间">
                                        <ItemTemplate>
                                           <%# System.Convert.ToString((Eval("intime").ToString() == "") ? "" : Eval("intime").ToString().Substring(0, Eval("intime").ToString().LastIndexOf(" ") + 1), System.Globalization.CultureInfo.CurrentCulture) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="到货日期">
                                        <ItemTemplate>
                                           <%# System.Convert.ToString((Eval("arrivalDate").ToString() == "") ? "" : Eval("arrivalDate").ToString().Substring(0, Eval("arrivalDate").ToString().LastIndexOf(" ") + 1), System.Globalization.CultureInfo.CurrentCulture) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="rowa"></RowStyle>
                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                <HeaderStyle CssClass="header"></HeaderStyle>
                                <FooterStyle CssClass="footer"></FooterStyle>
                            </asp:GridView>

                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: right;display:none;">
            <input id="btnSave" type="button" class="button-normal" value="确 定" disabled="disabled"
                onclick="saveEvent();" />
            <input id="btnCancel" type="button" value="取 消" class="button-normal" onclick="top.ui.closeWin();" />
        </div>
        <asp:HiddenField ID="hfldContractId" runat="server" />
        <asp:HiddenField ID="hfldContractName" runat="server" />
        <asp:HiddenField ID="hfldBName" runat="server" />
        <asp:HiddenField ID="hfldPrjID" runat="server" />
        <asp:HiddenField ID="hfldPrjName" runat="server" />
    </form>
</body>
</html>
