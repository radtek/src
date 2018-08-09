<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmWastageEdit.aspx.cs" Inherits="StockManage_SmWastage_SmWastageEdit" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx" Src="~/UserControl/FileUpload/FileUpload.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报损出库</title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
   <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>

    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="stylesheet" type="text/css" />

<%--    <script type="text/javascript" src="/Script/jquery.js"></script>--%>
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../script/ValidateInput.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="/Script/DecimalInput.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            replaceEmptyTable('emptyWastageStock', 'gvWastageStock');
            var jwTable = new JustWinTable('gvWastageStock');
            showTooltip('tooltip', 10);
        });


        //表单验证
        function valForm() {
            if (document.getElementById("hfldTrea").value == "") {
                top.ui.alert("请先选择仓库");
                return false;
            }
            if (document.getElementById("hdTsid").value == "") {
                top.ui.alert("请选择资源");
                return false;
            }
            return true;
        }

       
        function openkc() {
            if (document.getElementById("hfldTrea").value == "") {
                alert("请先选择仓库");
            } else {
                var url = '/StockManage/SmOutReserve/StuffListWX.aspx?tcode=' + $('#hfldTrea').val();
                //top.ui.callback = function (o) {
                //    $('#hdTsid').val(o.id);
                //    $('#btnShowGv').click();
                //}
                //top.ui.openWin({ title: '选择资源', url: url, width: 900, height: 500 });
                layer.open({
                    type: 2,
                    title: '从仓库选择物资',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['100%', '100%'],
                    content: url
                });
            }
        }

        //比较出库数量
        function chkNum(index, num1, num2) {
            var temp1 = num1.value.replace(',', '');
            var temp2 = num2.value.replace(',', '');
            if (parseFloat(temp1) < 0) {
                top.ui.alert('系统提示:出库数量不能小于零!');
                temp1 = 0.000;
                return;
            }
            if (parseFloat(temp1) > parseFloat(temp2)) {
                top.ui.alert('系统提示:\n\n出库数量超过了库存数量!');
                temp1 = 0.000;
                return;
            }
            var number = 0.00;
            var sprice = 0.00;
            var rowTotal = 0.00;
            var allTotal = 0.00;
            $('#gvWastageStock tr[id]').each(function () {
                number = $(this).find('input[id$=txtCNum]').val();
                sprice = $(this).find('input[id$=hdSprice]').val();
                rowTotal = number * sprice;
                $(this).find('span[id$=lbTotal]').text(rowTotal.toFixed(3));
                allTotal += rowTotal;
            });
            $('#gvWastageStock').find('span[class=_total_]').text(allTotal.toFixed(3));
        }

        // 选择仓库
        //function selectTrea() {
        //    jw.selectTreasury({
        //        codeinput: 'hfldTrea',
        //        nameinput: 'txtTrea',
        //        func: function () {
        //            $('#btnModifyTreasury').click();
        //        }
        //    });
        //}
        function selectTreaWX() {
            var url = "/Common/SelectTreasuryWX.aspx?module=import";
            layer.open({
                type: 2,
                title: '选择仓库',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
        //注意：parent 是 JS 自带的全局对象，可用于操作父页面
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        // 关闭
        function page_close() {
            parent.layer.close(index);
        }
    </script>
    <style type="text/css">
        .gvw{
            min-width: 700px;
        }
        .gvw tr{
            height: 30px;
        }
        .footerM {
            /*color:red;*/
        }
         .footerM td table tbody tr td span{
            font-size: 12px;
    margin: 5px;
    border: 1px solid #b5b2b2;
    padding: 3px;
    margin-left: 10px;
    background-color: #fbfbfb;
    color:red;
        }
         .footerM td table tbody tr td a {
            font-size: 12px;
    margin: 5px;
    border: 1px solid #b5b2b2;
    padding: 3px;
    margin-left: 10px;
    background-color: #fbfbfb;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divHeader2" style="display:none;">
            <table class="tableHeader">
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" Font-Bold="true" Text="" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="divContent2">
            <table class="tableContent2" style="margin-left: auto" cellpadding="5px" cellspacing="0">
                <tr style="display:none;">
                    <td class="word" style="white-space: nowrap;">附件
                    </td>
                    <td colspan="3">
                        <MyUserControl:usercontrol_fileupload_fileupload_ascx ID="FileUpload1" Name="附件" FileType="*.*" Class="Wastage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="word" style="white-space: nowrap;">单据号
                    </td>
                    <td class="txt readonly">
                        <asp:TextBox ID="txtWastageCode" Width="100%" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td class="word" style="white-space: nowrap;">选择仓库
                    </td>
                    <td class="txt mustInput">
                        <asp:TextBox ID="txtTrea" CssClass="select_input" imgclick="selectTreaWX" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hfldTrea" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="word" style="white-space: nowrap;">说明
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtExplain" Style="width: 100%;" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="word" style="white-space: nowrap;">录入人
                    </td>
                    <td class="txt readonly">
                        <input type="text" readonly="readonly" id="txtPeople" runat="server" />

                    </td>
                    <td class="word" style="white-space: nowrap;">录入时间
                    </td>
                    <td class="txt readonly">
                        <asp:TextBox ID="txtInTime" Width="100%" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px">
                        <hr class="sp" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="headerDiv" style="text-align: left;">
                            <input type="button" id="btnSelectByd" value="从仓库选择资源" onclick="openkc()" style="width: 100px;" runat="server" />

                            <asp:Button ID="btnDel" Style="width: 100px;" Text="删除资源" OnClick="btnDel_Click" runat="server" />
                            <asp:Button ID="btnShowGv" Text="显示" Style="display: none;" OnClick="btnShowGv_Click" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="pagediv">
                            
                        </div>
                    </td>
                </tr>
            </table><asp:GridView ID="gvWastageStock" CssClass="gvw"  Width="100%" AutoGenerateColumns="false" OnRowDataBound="gvWastageStock_RowDataBound" DataKeyNames="ResourceCode" runat="server">
                                <EmptyDataTemplate>
                                    <table id="emptyWastageStock" class="gvdata">
                                        <tr class="header">
                                            <th scope="col" style="width: 20px;">
                                                <input id="chk1" type="checkbox" />
                                            </th>
                                            <th scope="col" style="width: 25px;">序号
                                            </th>
                                            <th scope="col">物资编号
                                            </th>
                                            <th scope="col">物资名称
                                            </th>
                                            <th scope="col">规格
                                            </th>
                                            <th scope="col">单位
                                            </th>
                                            <th scope="col">库存数量
                                            </th>
                                            <th scope="col">出库数量
                                            </th>
                                            <th scope="col">单价
                                            </th>
                                            <th scope="col">小计
                                            </th>
                                            <th scope="col">供应商
                                            </th>
                                            <th scope="col">型号
                                            </th>
                                            <th scope="col">品牌
                                            </th>
                                            <th scope="col">技术参数
                                            </th>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="20px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkBox" ToolTip='<%# System.Convert.ToString(Eval("ResourceCode"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                    <asp:TemplateField HeaderText="单位" HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%# Eval("Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="库存数量" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="decimal_input" Style="text-align: right;" ID="txtSnumber" Enabled="false" Text='<%# System.Convert.ToString(Eval("snumber"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="出库数量" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCNum" Style="text-align: right;" CssClass="decimal_input" Text='<%# System.Convert.ToString(Eval("number"), System.Globalization.CultureInfo.CurrentCulture) %>' ToolTip='<%# System.Convert.ToString(Eval("ResourceCode"), System.Globalization.CultureInfo.CurrentCulture) %>' No='<%# System.Convert.ToString(Container.DataItemIndex, System.Globalization.CultureInfo.CurrentCulture) %>' runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdScode" Value='<%# System.Convert.ToString(Eval("ResourceCode"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                            <asp:HiddenField ID="hdSprice" Value='<%# System.Convert.ToString(Eval("sprice"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                            <asp:HiddenField ID="hdCorp" Value='<%# System.Convert.ToString(Eval("corpId"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="sprice" HeaderText="单价" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input" />
                                    <asp:TemplateField HeaderText="出库小计" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbTotal" CssClass="decimal_input" Text='<%# System.Convert.ToString((Eval("Total").ToString() == "") ? "0.000" : System.Convert.ToDecimal(Eval("Total")).ToString("0.000"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="供应商">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("CorpName").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("CorpName").ToString(), 10) %>
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
                                </Columns>
                                <RowStyle CssClass="rowa"></RowStyle>
                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                <HeaderStyle CssClass="header"></HeaderStyle>
                                <FooterStyle CssClass="footer"></FooterStyle>
                            </asp:GridView>
        </div>
        <div class="divFooter2">
            <table class="tableFooter2">
                <tr>
                    <td>
                        <asp:Button ID="btnSave" Text="保存" OnClientClick="return valForm()" OnClick="btnSaveWX_Click" runat="server" />
                        <input type="button" id="btnCancel" value="取消" onclick="page_close();" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hdwzId" runat="server" />
        <asp:HiddenField ID="hdGuid" runat="server" />
        <asp:HiddenField ID="hdTsid" runat="server" />
        <asp:HiddenField ID="hdflowstate" Value="-1" runat="server" />
        <asp:Button ID="btnModifyTreasury" Style="display: none;" OnClick="btnModifyTreasury_Click" runat="server" />
    </form>
</body>
</html>
