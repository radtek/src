<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="StockManage_Purchase_Purchase" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WFWX.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.easyui/themes/icon.css" />
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="stylesheet" type="text/css" />

   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />

    <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>

    <%-- <script type="text/javascript" src="/Script/jquery.js"></script>--%>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            parent.$('.layout-panel-center').css({ "left": "0px", "width": "100%" });
            parent.$('.panel-body-noheader').css({ "width": "100%" });
            $('.ifshow').hide();
            // 添加验证
            $('#btnSearch')[0].onclick = function () { if (!$('#form1').form('validate')) return false; }
            addEvent(document.getElementById('btnAdd'), 'click', addPurchase);
            addEvent(document.getElementById('btnQuery'), 'click', queryPurchase);
            document.getElementById('btnDelete').onclick = deletePurchase;
            addEvent(document.getElementById('btnUpdate'), 'click', updatePurchase);
            var jwTable = new JustWinTable('gvwPurchase');
            setButton(jwTable, 'btnDelete', 'btnUpdate', 'btnQuery', 'hfldPurchaseChecked');
            setWfButtonState2(jwTable, 'WF_1');
            showTooltip('tooltip', 15);
        });

        function addPurchase() {
            //parent.parent.desktop.PurchaseEdit = window;
            var url = "/StockManage/Purchase/PurchaseEditWX.aspx?Action=Add&prjId=" + document.getElementById('hfldPrjId').value;
            //toolbox_oncommand(url, "新增采购单");
            layer.open({
                type: 2,
                title: '新增采购单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }

        function queryPurchase() {
        //    if (!document.getElementById('hfldPurchaseChecked')) return false;
        //    //viewopen('PurchaseView.aspx?ic=' + this.guid, 820, 500);
        //    var url = 'PurchaseViewWX.aspx?ic=' + this.guid;
        //    layer.open({
        //        type: 2,
        //        title: '查看采购单',
        //        shadeClose: true,
        //        shade: 0.8,
        //        area: ['100%', '100%'],
        //        content: url
        //    });
        }
        function rowQuery(id) {
            var url = 'PurchaseViewWX.aspx?ic=' + id;
            layer.open({
                type: 2,
                title: '查看入库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
        function deletePurchase() {
            if (!document.getElementById('hfldPurchaseChecked')) return false;
            if (!confirm("确定要删除吗？")) {
                return false;
            }
        }

        function updatePurchase() {
            //parent.parent.desktop.PurchaseEdit = window;
            var url = "/StockManage/Purchase/PurchaseEditWX.aspx?Action=Update&Pcode=" + document.getElementById('hfldPurchaseChecked').value;
            if (!document.getElementById('hfldPurchaseChecked')) return false;
            //toolbox_oncommand(url, "编辑采购单");
            layer.open({
                type: 2,
                title: '编辑采购单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }

        // 选择人员
        function selectUser() {
            jw.selectOneUser({ nameinput: 'txtPeople' });
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
    </script>
</head>
<body>
     <form id="form1" runat="server" style="word-break: normal; font-family: -apple-system-font, 'Helvetica Neue', 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', sans-serif; background-size: cover; word-wrap: break-word; word-break: break-all; background: #f5f5f5 no-repeat center;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="divHeader">
                    <asp:Label ID="lblProject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr >
                <td style="height: 96%; width: 100%;">
                    <table class="queryTable ifshow" cellpadding="3px" cellspacing="0px">
                        <tr>
                            <td class="descTd">起始时间
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>  </tr>
                        <tr>
                            <td class="descTd">结束时间
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>  </tr>
                        <tr>
                            <td class="descTd">采购编号
                            </td>
                            <td>
                                <asp:TextBox ID="txtPcode" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="descTd">录入人
                            </td>
                            <td>
                                <asp:TextBox ID="txtPeople" CssClass="easyui-validatebox " data-options="validType:'validQueryChars[50]'" Style="width: 120px;"  runat="server"></asp:TextBox>
                            </td>  </tr>
                        <tr>
                            <td class="descTd">合同名称
                            </td>
                            <td>
                                <asp:TextBox ID="txtConName" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validQueryChars[50]'" runat="server"></asp:TextBox>
                            </td>  </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" Text="查询" Style="cursor: pointer;" OnClick="btnSearch_Click" runat="server" />
                                 <input type="button" id="btnUnSelect" value="取消查询" style="width:auto" onclick="ifshow();" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <table class="tab">
                        <tr>
                            <td class="divFooter" style="text-align: left;">
                                  <input type="button" id="btnSelect" value="高级查询" style="width:auto" onclick="ifshow();" />
                                <input type="button" id="btnAdd" value="新增" />
                                <input type="button" id="btnUpdate" value="编辑" disabled="disabled" />
                                <asp:Button ID="btnDelete" Text="删除" disabled="disabled" OnClick="btnDelete_Click" runat="server" />
                                <input type="button" id="btnQuery" disabled="disabled" value="查看" style="display:none;"/>
                                <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiCode="073" BusiClass="001" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%;">
                                <div class="">
                                    <asp:GridView ID="gvwPurchase" CssClass="gvdata" Width="100%" AllowPaging="true" AutoGenerateColumns="false" OnPageIndexChanging="gvwPurchase_PageIndexChanging" OnRowDataBound="gvwPurchase_RowDataBound" DataKeyNames="pcode,pid,Project" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="20px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelectSingle" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" Visible="False">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="采购编号">
                                                <ItemTemplate>
                                                   <%-- <span class="al" onclick="viewopen('PurchaseView.aspx?ic=<%# Eval("pid") %>',820,500)">
                                                        <%# Eval("pcode") %>
                                                    </span>--%>
                                                     <div style="position: absolute; margin-top: 5px;">
                                                        <span class="al" onclick="rowQuery('<%# Eval("pid") %>')" style="font-size: 16px; text-decoration: none;">
                                                            <%# Eval("pcode") %>
                                                        </span>
                                                    </div>
                                                    <div style="float: right; color: #999999; font-size: 12px;margin-top: 10px;">
                                                        <span style="float: right;"><%# Eval("ContractName") %></span>
                                                        </br>
                                                        <span><%# Eval("person") %>   <%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ContractName" HeaderText="采购合同" Visible="False"/>
                                            <asp:BoundField DataField="PrjName" HeaderText="项目" Visible="false" />
                                            <asp:BoundField DataField="person" HeaderText="录入人" Visible="False"/>
                                            <asp:BoundField DataField="intime" HeaderText="录入时间" Visible="False"/>
                                            <asp:TemplateField HeaderText="流程状态" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Common2.GetState(Eval("flowstate").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="附件" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px" Visible="False">
                                                <ItemTemplate>
                                                    <%# GetAnnx(System.Convert.ToString(Eval("pid"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="说明" Visible="False">
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("explain") %>'>
                                                        <%# StringUtility.GetStr(Eval("explain").ToString()) %>
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
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfldPurchaseChecked" runat="server" />
        <asp:HiddenField ID="hfldPrjId" runat="server" />
    </form>
</body>
</html>
