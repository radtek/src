<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StorageView.aspx.cs" Inherits="StockManage_Storage_StorageView" %>

<%@ Register TagPrefix="MyUserControl" TagName="stockmanage_common_showaudit_ascx" Src="~/StockManage/Common/ShowAudit.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_filelink_ascx" Src="~/EPC/UserControl1/FileLink.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>入库单</title>
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script src="../../Script/DecimalInput.js" type="text/javascript"></script>
    <script src="../../Script/jw.js" type="text/javascript"></script>
    <script type="text/javascript">
        addEvent(window, 'load', function () {
            setAnnxReadOnly('flAnnx');
            replaceEmptyTable('emptyStorageStock', 'gvwStorageStock')
        });
    </script>
    <style type="text/css">
         .descTd1{
            width:60px;
text-align: right;
    text-align: left;
    vertical-align: bottom;
    text-indent: 3px;
    border-bottom: 1px solid rgb(151, 203, 255);
        }
         .elemTd1{
            
text-align: left;
    text-align: left;
    vertical-align: bottom;
    text-indent: 3px;
    border-bottom: 1px solid rgb(151, 203, 255);
        }

        .descTd2{
            width:60px;
text-align: right;
    text-align: left;
    vertical-align: bottom;
    text-indent: 3px;
    border-bottom: 1px solid rgb(204, 204, 204);
        }
         .elemTd2{
            
text-align: left;
    text-align: left;
    vertical-align: bottom;
    text-indent: 3px;
    border-bottom: 1px solid rgb(204, 204, 204);
        }
         .tabCss {
    width: 100%;
    height: 100%;
    border-collapse: collapse;
    vertical-align: top;
    margin: 0px;
    padding: 0px;
    border-spacing: 0px;
    border-width: 0px;
}
         .tabCss tr {
    cursor: default;
    line-height: 22px;
    height: 30px;
    padding: 5px;
}
              .tabTitleCss{
                  width: 60px;
                  text-align: left;
border-style: none;
    margin-bottom: 0px;
    border-bottom: 1px solid rgb(151, 203, 255);
              }
    </style>
</head>
<body id="print1">
    <form id="form1" runat="server">  
        <div class="VPage" style="padding: 5px; margin: 0px;">
        <table class="tab" >
            <tr style="display:none;">
                <td class="divHeader">
                    <asp:Label ID="lblTitle" Text="" runat="server"></asp:Label>
                    <input type="button" id="btnDy" style="float: right;display:none;" class="noprint" onclick="winPrint()"
                        value=" 打 印 " />
                </td>
            </tr>
            <tr style="height: 1px;">
                <td>
                    <table id="bllProducer" cellpadding="0" cellspacing="0" style="border-style: none;"
                        class="tabCss">
                        <tr>
                             <td class="descTd1" style="text-align: right;" >制单人:
                            </td>
                            <td class="elemTd1">
                               <asp:Label ID="lblBllProducer" runat="server"></asp:Label>
                            </td>
                           <%-- <td class="tabTitleCss">制单人:<asp:Label ID="lblBllProducer" runat="server"></asp:Label>
                            </td>--%>
                            <td style="border-style: none; text-align: right;display:none;">打印日期:&nbsp;&nbsp;<asp:Label ID="lblPrintDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <table cellpadding="0" cellspacing="0" class="tabCss">
                        <tr>
                            <td class="descTd2" style="text-align: right;" >入库编号:
                            </td>
                            <td class="elemTd2">
                                <asp:Label ID="lblScode" Text="" runat="server"></asp:Label>
                            </td>
                               </tr>
                        <tr>
                            <td class="descTd2" style="text-align: right;" >入库日期:
                            </td>
                            <td class="elemTd2">
                                <asp:Label ID="DateInTime" Text="" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd2" style="text-align: right;" >仓库名称:
                            </td>
                            <td class="elemTd2">
                                <asp:Label ID="lblTreasury" Text="" runat="server"></asp:Label>
                            </td>
                               </tr>
                        <tr>
                            <td class="descTd2" style="text-align: right;" >项目:
                            </td>
                            <td class="elemTd2">
                                <asp:Label ID="lblProject" Text="" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd2" style="text-align: right;" >验收人:
                            </td>
                            <td class="elemTd2">
                                <asp:Label ID="lblPerson" Text="" runat="server"></asp:Label>
                            </td>
                               </tr>
                        <tr>
                            <td class="descTd2" style="text-align: right;" >附件:
                            </td>
                            <td class="elemTd2">
                                <MyUserControl:epc_usercontrol1_filelink_ascx ID="flAnnx" runat="server" />
                            </td>
                        </tr>
                        <tr id="trd" runat="server">
                            <td class="descTd2" runat="server" style="text-align: right;" >移交人:
                            </td>
                            <td class="elemTd2" runat="server">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </td>
                               </tr>
                        <tr>
                            <td class="descTd2" runat="server" style="text-align: right;" >监理:
                            </td>
                            <td class="elemTd2" runat="server">
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd2" style="text-align: right;" >说明:
                            </td>
                            <td   class="elemTd2">
                                <asp:Label ID="lblExplain" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" style="margin-top: 10px;" border="0">

                        <tr>
                            <td style="vertical-align: top;">
                                <asp:GridView ID="gvwStorageStock" CssClass="viewTable" AutoGenerateColumns="false" runat="server">
                         <%--           <EmptyDataTemplate>
                                        <table  id="emptyStorageStock">
                                            <tr class="header">
                                                <td style="width: 59px">序号
                                                </td>
                                                <td style="width: 160px;">物资编号
                                                </td>
                                                <td style="width: 160px">物资名称
                                                </td>
                                                <td style="width: 160px">规格
                                                </td>
                                                <td style="width: 80px">型号
                                                </td>
                                                <td style="width: 80px">品牌
                                                </td>
                                                <td style="width: 80px">技术参数
                                                </td>
                                                <td style="width: 70px">单位
                                                </td>
                                                <td style="width: 25px">合同数量
                                                </td>
                                                <td style="width: 25px">累计已入库数量
                                                </td>
                                                <td style="width: 70px">数量
                                                </td>
                                                <td style="width: 25px">价格
                                                </td>
                                                <td style="width: 20px">小计
                                                </td>
                                                <td style="width: 120px">供应商
                                                </td>
                                                <td style="width: 30px">验收情况
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="序号">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="物资编号">
                                            <ItemTemplate>
                                                <div style="word-break: break-all;min-width: 50px;">
                                                    <%# Eval("ResourceCode") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="物资名称" >
                                            <ItemTemplate>
                                                <div style="word-break: break-all; min-width: 50px;">
                                                    <%# Eval("ResourceName") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="规格" >
                                            <ItemTemplate>
                                                <div style="word-break: break-all; min-width: 20px;">
                                                    <%# Eval("Specification") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="型号" >
                                            <ItemTemplate>
                                                <div style="word-break: break-all;min-width: 20px;">
                                                    <%# Eval("ModelNumber") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="品牌" >
                                            <ItemTemplate>
                                                <div style="word-break: break-all;min-width: 20px;">
                                                    <%# Eval("brand") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="技术参数" >
                                            <ItemTemplate>
                                                <div style="word-break: break-all;min-width: 50px;">
                                                    <%# Eval("TechnicalParameter") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="单位" >
                                            <ItemTemplate>
                                                <div style="word-break: break-all;min-width: 20px;">
                                                    <%# Eval("UnitName") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="合同数量" ItemStyle-CssClass="decimal_input">
                                            <ItemTemplate>
                                                <%# System.Convert.ToDecimal(Eval("ContractNumber")).ToString("0.000") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="累计已入库数量" ItemStyle-CssClass="decimal_input">
                                            <ItemTemplate>
                                                <%# System.Convert.ToDecimal(Eval("AllInNumber")).ToString("0.000") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="数量" ItemStyle-CssClass="decimal_input">
                                            <ItemTemplate>
                                                <%# System.Convert.ToDecimal(Eval("number")).ToString("0.000") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="价格" ItemStyle-CssClass="decimal_input">
                                            <ItemTemplate>
                                                <%# System.Convert.ToDecimal(Eval("sprice")).ToString("0.000") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="小计" ItemStyle-CssClass="decimal_input">
                                            <ItemTemplate>
                                                <%# System.Convert.ToDecimal(Eval("Total")).ToString("0.000").Trim() %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="供应商" Visible="false">
                                            <ItemTemplate>
                                                <div style="word-break: break-all;">
                                                    <%# Eval("CorpName") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="验收情况">
                                            <ItemTemplate>
                                                <div style="word-break: break-all;min-width: 50px;">
                                                    <%# Eval("checkCondition") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="rowa"></RowStyle>
                                    <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                    <HeaderStyle CssClass="header"></HeaderStyle>
                                    <FooterStyle CssClass="footer"></FooterStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trAudit" style="vertical-align: top; width: 100%;">
                <td style="width: 100%;">
                    <MyUserControl:stockmanage_common_showaudit_ascx ID="ShowAudit1" BusiCode="074" BusiClass="001" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
        </div>
        <!--项目编码-->
        <asp:HiddenField ID="hfldPid" runat="server" />
        <asp:HiddenField ID="hfldProject" runat="server" />
        <asp:HiddenField ID="hfldPurchaseCode" runat="server" />
        <asp:HiddenField ID="hfldResourceCode" runat="server" />
    </form>
</body>
</html>
