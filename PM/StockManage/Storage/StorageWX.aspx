<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Storage.aspx.cs" Inherits="StockManage_Storage_Storage" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WFWX.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>入库单管理</title>
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
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".window").css("display", "none");
            $('.ifshow').hide();
           // $('.panel window').css("display","none");
           
            addEvent(document.getElementById('btnAdd'), 'click', addStorage);
            addEvent(document.getElementById('btnUpdate'), 'click', updateStorage);
            //必需这样写
            document.getElementById('btnDelete').onclick = deleteStorage;
            addEvent(document.getElementById('btnQuery'), 'click', queryStorage);

            var storageTable = new JustWinTable('gvwStorage');
            setButton(storageTable, 'btnDelete', 'btnUpdate', 'btnQuery', 'hfldStorageCode');
            setWfButtonState2(storageTable, 'WF1');
        });

        function addStorage() {
            var url = '/StockManage/Storage/StorageEditWX.aspx?Action=Add';
            // viewopen(url);
            //iframe层
            layer.open({
                type: 2,
                title: '新增入库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }

        function updateStorage() {
            var url = '/StockManage/Storage/StorageEditWX.aspx?Action=Update&StorageCode=' + encodeURI(document.getElementById('hfldStorageCode').value);
            layer.open({
                type: 2,
                title: '编辑入库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
        //查看
        function queryStorage() {
            var url = 'StorageViewWX.aspx?ic=' + this.guid;
            layer.open({
                type: 2,
                title: '查看入库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
        function rowQuery(id) {
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
        function deleteStorage() {
            if (!confirm("确定要删除吗？")) {
                return false;
            }
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
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd">入库编号
                            </td>
                            <td>
                                <asp:TextBox ID="txtStorage" Width="120px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd">仓库名称
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrea" Width="120px" runat="server"></asp:TextBox>
                                <%-- <asp:TextBox ID="txtTrea" CssClass="select_input" Width="120px" imgclick="selectTrea" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hfldTrea" runat="server" />--%>
                            </td>
                            <td></td>
                        </tr>
                        <tr style="height: 30px;">
                            <td class="descTd">录入人
                            </td>
                            <td>
                                <asp:TextBox ID="txtPeople" CssClass="txtreadonly" Style="width: 120px;" class="select_input" imgclick="selectUser" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Button ID="btnSearch" Text="查询" Style="cursor: pointer;" OnClick="btnSearch_Click" runat="server" />
                                <input type="button" id="btnUnSelect" value="取消查询" style="width:auto" onclick="ifshow();" />
                            </td>
                            <td></td>
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
                                <input type="button" id="btnAdd" value="新增" />
                                <input type="button" id="btnUpdate" value="编辑" disabled="disabled" />
                                <asp:Button ID="btnDelete" Text="删除" disabled="disabled" OnClick="btnDelete_Click" runat="server" />
                                <input type="button" id="btnQuery" disabled="disabled" value="查看"  style="display:none;"/>&nbsp;
							<MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiCode="074" BusiClass="001" runat="server" />
                            </td>
                        </tr>
                        <tr style="height: 100%; vertical-align: top">
                            <td>
                                <div class="">
                                    <asp:GridView ID="gvwStorage" Width="100%" AutoGenerateColumns="false" AllowPaging="true" OnRowDataBound="gvwStorage_RowDataBound" OnPageIndexChanging="gvwStorage_PageIndexChanging" DataKeyNames="scode,sid,project" runat="server" BorderColor="#DFDFDD" BorderStyle="Solid" BorderWidth="1px">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="20px" >
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
                                            <asp:TemplateField HeaderText="入库编号">
                                                <ItemTemplate>
                                                    <div style="position: absolute; margin-top: 5px;">
                                                        <span class="al" onclick="rowQuery('<%# Eval("sid") %>')" style="font-size: 16px; text-decoration: none;">
                                                            <%# Eval("scode") %>
                                                        </span>
                                                    </div>
                                                    <div style="float: right; color: #999999; font-size: 12px;">
                                                        <span style="float: right;"><%# Eval("tname") %></span>
                                                        </br>
                                                        <span><%# Eval("person") %>   <%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                                    </div>



                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="tname" HeaderText="仓库名称" Visible="False"/>
                                            <asp:BoundField DataField="person" HeaderText="录入人" Visible="False"/>
                                            <asp:BoundField DataField="intime" HeaderText="录入时间" Visible="False"/>
                                            <asp:TemplateField HeaderText="流程状态" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Common2.GetState(Eval("flowstate").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="附件" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px" Visible="False">
                                                <ItemTemplate>
                                                    <%# GetAnnx(System.Convert.ToString(Eval("sid"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="说明" Visible="False">
                                                <ItemTemplate>
                                                    <%# StringUtility.GetStr(Eval("explain").ToString()) %>
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
        <div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
        <asp:HiddenField ID="hfldStorageCode" runat="server" />
    </form>
</body>
</html>
