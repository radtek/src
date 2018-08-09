<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Storage.aspx.cs" Inherits="StockManage_Report_Storage" %>

<%@ Import Namespace="cn.justwin.BLL" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>入库信息报表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />

    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.easyui/themes/icon.css" />
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />


       <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>

    <%-- <script type="text/javascript" src="/Script/jquery.js"></script>--%>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script src="../../Script/DecimalInput.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ifshow').hide();
            // 添加验证
            $('#btnSearch')[0].onclick = function () { if (!$('#form1').form('validate')) return false; }
            var jwTable = new JustWinTable('gvwStorage');
            showTooltip('tooltip', 10);
        });

        function pickCorp() {
            jw.selectOneCorp({ nameinput: 'txtCorpName' });
        }

        function openProjPicker() {
            jw.selectOneProject({ nameinput: 'txtProjectName' });
        }

        function selectTrea() {
            jw.selectTreasury({ codeinput: 'hfldTrea', nameinput: 'txtTrea' });
        }
        function ifshow() {
            if ($('.ifshow').is(':hidden')) {
                $('.ifshow').show();
                $("#btnSelect").hide();
            }
            else {
                $('.ifshow').hide();
                $("#btnSelect").show();
            }
        }
        //查看
        function rowQuery(id) {
            ///onclick="viewopen('../Storage/StorageView.aspx?ic=<%# Eval("sid") %>&Action=Query','','')">
            var url = '/StockManage/Storage/StorageViewWX.aspx?ic=' + id + "&Action=Query";;
            layer.open({
                type: 2,
                title: '查看入库报表',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
    </script>
        <style type="text/css">
        .gvw{
            min-width: 900px;
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
    <form id="form1" runat="server">  <div class="VPage" style="padding: 5px; margin: 0px;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="vertical-align: top;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr  class="ifshow">
                            <td>
                                <table class="queryTable" cellpadding="3px" cellspacing="0px">
                                    <tr>
                                        <td class="descTd">起始时间
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                                        </td> </tr>
                        <tr>
                                        <td class="descTd">结束时间
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="descTd">资源名称
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResourceName" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                        </td> </tr>
                        <tr>
                                        <td class="descTd">资源编号
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResourceCode" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td class="descTd">单据编号
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPurchaseCode" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                        </td> </tr>
                        <tr>
                                        <td class="descTd">供应商
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCorpName" Style="width: 120px;" CssClass="easyui-validatebox " data-options="validType:'validQueryChars[50]'" imgclick="pickCorp" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="descTd">项目名称
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtProjectName" Style="width: 120px;" CssClass="easyui-validatebox " data-options="validType:'validQueryChars[50]'" imgclick="openProjPicker" runat="server"></asp:TextBox>
                                        </td> </tr>
                        <tr>
                                        <td class="descTd">仓库名称
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTrea" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                            <%--<asp:TextBox ID="txtTrea" CssClass="select_input" Width="120px" imgclick="selectTrea" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hfldTrea" runat="server" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="descTd">资源类别
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCategory" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                        </td> </tr>
                        <tr>
                                        <td class="descTd">规格
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSpecification" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="descTd">品牌
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBrand" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                        </td> </tr>
                        <tr>
                                        <td class="descTd">型号
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtModelNumber" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="descTd">
                                        </td>
                                        <td>
                                           <asp:DropDownList ID="dropIsFirst" runat="server" Style="display: none;">
                                    <asp:ListItem Value="2" Text="全部" />
                                    <asp:ListItem Value="1" Text="甲供" />
                                    <asp:ListItem Value="0" Text="非甲供" />
                                </asp:DropDownList>
                                <asp:Button ID="btnSearch" Text="查询" Style="cursor: pointer;" OnClick="btnSearch_Click" runat="server" />
                                 <input type="button" id="btnUnSelect" value="取消查询" style="width:auto" onclick="ifshow();" />
                                        </td>
                                        <td class="descTd">
                                        </td>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="divFooter" style="text-align: left;">
                                <input type="button" id="btnSelect" value="高级查询" style="width:auto" onclick="ifshow();" />
                                <asp:Button ID="btnExcel" Width="80px" Text="导出Excel" OnClick="btnExcel_Click" runat="server" Style="display: none;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%;">
                                <div class="">
                                    <asp:GridView ID="gvwStorage" CssClass="gvw"  Width="100%" AllowPaging="true" AutoGenerateColumns="false" EnableViewState="false" OnPageIndexChanging="gvwPurchase_PageIndexChanging" DataKeyNames="StorageCode,sid" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" HeaderStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="单据号">
                                                <ItemTemplate>
                                                    <span class="al" onclick="rowQuery('<%# Eval("sid") %>')">
                                                        <%# Eval("StorageCode") %>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ResourceCode" HeaderText="资源编号" />
                                            <asp:TemplateField HeaderText="资源名称">
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("ResourceName").ToString() %>'>
                                                        <%# StringUtility.GetStr(Eval("resourceName").ToString(), 10) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="资源类别">
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("ResourceTypeName").ToString() %>'>
                                                        <%# StringUtility.GetStr(Eval("ResourceTypeName").ToString(), 10) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="规格">
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("Specification").ToString() %>'>
                                                        <%# StringUtility.GetStr(Eval("Specification").ToString(), 10) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="品牌">
                                                <ItemTemplate>
                                                    <%# Eval("Brand") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ModelNumber" HeaderText="型号" />
                                            <asp:BoundField DataField="TechnicalParameter" HeaderText="技术参数" />
                                            <asp:BoundField DataField="UnitName" HeaderText="单位" />
                                            <asp:BoundField DataField="sprice" HeaderText="单价" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input" />
                                            <asp:BoundField DataField="number" HeaderText="数量" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input" />
                                            <asp:BoundField DataField="total" HeaderText="小计" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input" />
                                            <asp:TemplateField HeaderText="供应商">
                                                <ItemTemplate>
                                                    <%# StringUtility.GetStr(Eval("CorpName").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="项目名称">
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("Specification").ToString() %>'>
                                                        <%# StringUtility.GetStr(Eval("PrjName").ToString(), 10) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="intime" HeaderText="入库日期" />
                                            <asp:BoundField DataField="tname" HeaderText="仓库名称" />
                                           
                                        </Columns>
                                              <PagerStyle CssClass="footerM" />
                                        <RowStyle CssClass="rowa"></RowStyle>
                                        <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                        <HeaderStyle CssClass="header"></HeaderStyle>
                                        <FooterStyle CssClass="footer"></FooterStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
