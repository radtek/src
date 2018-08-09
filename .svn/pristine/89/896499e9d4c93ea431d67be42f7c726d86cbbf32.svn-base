<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QoRefundingList.aspx.cs" Inherits="StockManage_Refunding_QoRefundingList" %>

<%@ Import Namespace="cn.justwin.BLL" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>退库单列表</title>
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
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            parent.$('.layout-panel-center').css({ "left": "0px", "width": "100%" });
            parent.$('.panel-body-noheader').css({ "width": "100%" });
            $('.ifshow').hide();
            var jwTable = new JustWinTable('gvRefunding');
            jwTable.registClickSingleCHKListener(function () {
                if (jwTable.getCheckedChk().length != 1) {
                    document.getElementById("btnOk").disabled = true;
                }
                else {
                    document.getElementById("btnOk").disabled = false;
                }
            });
            jwTable.registClickAllCHKLitener(function () {
                if (jwTable.getCheckedChk().length == 0) {
                    document.getElementById("btnOk").disabled = false;
                } else {
                    document.getElementById("btnOk").disabled = true;
                }
            });
            jwTable.registClickTrListener(function () {
                document.getElementById("btnOk").disabled = false;
            });
            showTooltip('tooltip', 15);
        });

        // 选择人员
        function selectUser() {
            jw.selectOneUser({ codeinput: 'hdnPeople', nameinput: 'txtPeople' });
        }

        function selectTrea() {
            jw.selectTreasury({ codeinput: 'hfldTrea', nameinput: 'txtTrea' });
        }
        function rowQuery(id) {
            var url = 'ViewRefundingWX.aspx?ic=' + id;
            layer.open({
                type: 2,
                title: '查看退库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
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
    <form id="form1"  runat="server" style="word-break: normal; font-family: -apple-system-font, 'Helvetica Neue', 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', sans-serif; background-size: cover; word-wrap: break-word; word-break: break-all; background: #f5f5f5 no-repeat center;">
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr class="ifshow">
                <td style="width: 100%; vertical-align: top;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr style="height: 25px">
                            <td class="descTd">退库单号
                            </td>
                            <td>
                                <asp:TextBox ID="txtPPcode" Width="120px" runat="server"></asp:TextBox>
                            </td>
                              </tr>
                        <tr style="height: 25px;">
                            <td class="descTd">起始日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>
                              </tr>
                        <tr style="height: 25px;">
                            <td class="descTd">结束日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 25px;">
                            <td class="descTd">录 入 &nbsp;人
                            </td>
                            <td>
                                 <input type="text" style="width: 120px;" id="txtPeople"  runat="server" />
                               <%-- <input type="text" style="width: 120px;" id="txtPeople" class="select_input" imgclick="selectUser" runat="server" />--%>

                                <asp:HiddenField ID="hdnPeople" runat="server" />
                            </td>
                              </tr>
                        <tr style="height: 25px;">
                            <td class="descTd">仓库名称
                            </td>
                            <td>
                                 <asp:TextBox ID="txtTrea"  Width="120px"  runat="server"></asp:TextBox>
                               <%-- <asp:TextBox ID="txtTrea" CssClass="select_input" Width="120px" imgclick="selectTrea" runat="server"></asp:TextBox>--%>
                                <asp:HiddenField ID="hfldTrea" runat="server" />
                            </td>
                              </tr>
                        <tr style="height: 25px;">
                            <td colspan="2">
                                <asp:Button ID="btn_Search" Text="查询" Style="cursor: pointer;" OnClick="btn_Search_Click" runat="server" />
                                 <input type="button" id="btnUnSelect" value="取消查询" style="width: auto" onclick="ifshow();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <table class="tab" style="vertical-align: top;">
                        <tr>
                            <td class="divFooter" style="text-align: left">
                                <input type="button" id="btnSelect" value="高级查询" style="width: auto" onclick="ifshow();" />
                                <asp:Button ID="btnOk" Text="确认退库" Width="80px" Enabled="false" OnClick="btnOk_Click" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%; vertical-align: top;">
                                <div class="">
                                    <asp:GridView ID="gvRefunding" AutoGenerateColumns="false" class="gvdata" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPurchaseplan_PageIndexChanging" OnRowDataBound="gvRefunding_RowDataBound" DataKeyNames="rcode" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="20px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbBox" ToolTip='<%# Convert.ToString(Eval("rcode")) %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" Visible="False">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="退库编号">
                                                <ItemTemplate>
                                                    <%--<span class="al" onclick="viewopen('ViewRefunding.aspx?ic=<%# Eval("rid") %>&BusiCode=077&BusiClass=001',820,500)">
                                                        <%# Eval("rcode") %>
                                                    </span>--%>
                                                     <div style="position: absolute; margin-top: 5px;">
                                                        <span class="al" onclick="rowQuery('<%# Eval("rid") %>')" style="font-size: 16px; text-decoration: none;">
                                                            <%# Eval("rcode") %>
                                                        </span>
                                                    </div>
                                                    <div style="float: right; color: #999999; font-size: 12px;">
                                                        <span style="float: right;"><%# Eval("tname") %></span>
                                                        </br>
                                                        <span><%# Eval("person") %>    <%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="录入人" Visible="False">
                                                <ItemTemplate>
                                                    <%# Eval("person") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="仓库名称" Visible="False">
                                                <ItemTemplate>
                                                    <%# Eval("tname") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="录入时间" Visible="False">
                                                <ItemTemplate>
                                                    <%# Common2.GetTime(Eval("intime").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="流程状态">
                                                <ItemTemplate>
                                                    <%# Common2.GetState(Eval("flowstate").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="附件" Visible="False">
                                                <ItemTemplate>
                                                    <%# GetAnnx(Convert.ToString(Eval("rid"))) %>
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
    </form>
</body>
</html>
