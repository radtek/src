<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnsureStorage.aspx.cs" Inherits="StockManage_Storage_EnsureStorage" %>

<%@ Import Namespace="cn.justwin.BLL" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>确认入库</title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />   
       <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>

    <style type="text/css">
        #btnEnsure {
            background: #fff url(/images1/btnBack.jpg);
            text-align: center;
            vertical-align: middle;
            width: 75px;
            height: 20px;
            border-style: none;
        }
    </style>
<%--    <script type="text/javascript" src="../../Script/jquery.js"></script>--%>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ifshow').hide();
            var storageTable = new JustWinTable('gvwStorage');

            storageTable.registClickTrListener(function () {
                $('#hfldStorageCode').val(this.id);
                $('#btnEnsure').removeAttr('disabled');
                if ($(this).attr('isfirst') == 'True') {
                    $('#hfldIsFirst').val('F');
                } else {
                    $('#hfldIsFirst').val('S');
                }
            });
        });

        //选择人员
        function selectUser() {
            jw.selectOneUser({ nameinput: 'txtPeople' });
        }

        function selectTrea() {
            jw.selectTreasury({ nameinput: 'txtTrea' });
        }
        function queryStorageOnline(id) {
            var url = 'StorageViewWX.aspx?ic=' + id;
            layer.open({
                type: 2,
                title: '查看入库单',
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
    <form id="form1" runat="server" style="word-break: normal; font-family: -apple-system-font, 'Helvetica Neue', 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', sans-serif; background-size: cover; word-wrap: break-word; word-break: break-all; background: #f5f5f5 no-repeat center;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr class="ifshow">
                <td>
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr>
                            <td class="descTd">起始时间
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>
                            </tr>
                        <tr>
                            <td class="descTd">结束时间
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td> </tr>
                        <tr>
                            <td class="descTd">入库编号
                            </td>
                            <td>
                                <asp:TextBox ID="txtStorage" Width="120px" runat="server"></asp:TextBox>
                            </td> </tr>
                        <tr>
                            <td class="descTd">仓库名称
                            </td>
                            <td><asp:TextBox ID="txtTrea" Width="120px" runat="server"></asp:TextBox>
                                <%--<asp:TextBox ID="txtTrea" CssClass="select_input" Width="120px" imgclick="selectTrea" runat="server"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr style="height: 30px;">
                            <td class="descTd">录入人
                            </td>
                            <td><asp:TextBox ID="txtPeople" Width="120px" runat="server"></asp:TextBox>
                               <%-- <asp:TextBox ID="txtPeople" CssClass="txtreadonly select_input" Style="width: 120px;" imgclick="selectUser" runat="server"></asp:TextBox>--%>
                            </td>
                            <td style="text-align: left">
                                <asp:Button ID="btnSearch" Text="查询" Style="cursor: pointer;" OnClick="btnSearch_Click" runat="server" />
                                 <input type="button" id="btnUnSelect" value="取消查询" style="width:auto" onclick="ifshow();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 96%; width: 100%;">
                    <table class="tab" style="vertical-align: top;">
                        <tr style="vertical-align: top;">
                            <td class="divFooter" style="text-align: left;">
                                <input type="button" id="btnSelect" value="高级查询" style="width:auto" onclick="ifshow();" />
                                <asp:Button ID="btnEnsure" Text="确认入库" CssClass="btn4c" disabled="disabled" OnClick="btnEnsureWX_Click" runat="server" />
                            </td>
                        </tr>
                        <tr style="vertical-align: top; height: 100%">
                            <td>
                                <div class="">
                                    <asp:GridView ID="gvwStorage" CssClass="gvdata" Width="100%" AutoGenerateColumns="false" AllowPaging="true" OnRowDataBound="gvwStorage_RowDataBound" OnPageIndexChanging="gvwStorage_PageIndexChanging" DataKeyNames="scode,isfirst" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="序号" Visible="False">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="入库编号">
                                                <ItemTemplate>
                                                    <%--<span class="al" onclick="viewopen('StorageView.aspx?&ic=<%# Eval("sid") %>')">
                                                        <%# Eval("scode") %>
                                                    </span>--%>
                                                    <div style="position: absolute; margin-top: 5px;">
                                                        <span class="al" onclick="queryStorageOnline('<%# Eval("sid") %>')" style="font-size: 16px; text-decoration: none;">
                                                            <%# Eval("scode") %>
                                                        </span>
                                                    </div>
                                                    <div style="float: right; color: #999999; font-size: 12px;">
                                                        <span style="float: right;"><%# Eval("tname") %></span>
                                                        </br>
                                                        <span><%# Eval("person") %>  <%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="tname" HeaderText="仓库名称"  Visible="False"/>
                                            <asp:BoundField DataField="person" HeaderText="录入人"  Visible="False"/>
                                            <asp:BoundField DataField="intime" HeaderText="录入时间"  Visible="False"/>
                                            <asp:TemplateField HeaderText="流程状态" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Common2.GetState(Eval("flowstate").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="甲供"  ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# (Eval("isfirst").ToString() == "True") ? "是" : "否" %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="附件"  Visible="False">
                                                <ItemTemplate>
                                                    <%# GetAnnx(System.Convert.ToString(Eval("sid"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="explain" HeaderText="说明"  Visible="False"/>
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

        <asp:HiddenField ID="hfldStorageCode" runat="server" />

        <asp:HiddenField ID="hfldIsFirst" runat="server" />
        <div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
    </form>
</body>
</html>
