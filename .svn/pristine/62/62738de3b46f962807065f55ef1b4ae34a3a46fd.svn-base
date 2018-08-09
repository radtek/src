<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmWastageList.aspx.cs" Inherits="StockManage_SmWastage_SmWastageList" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WFWX.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报损出库单</title>
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

    <%--<script type="text/javascript" src="/Script/jquery.js"></script>--%>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ifshow').hide();
            var wastageReserve = new JustWinTable('gvWastage');
            setButton(wastageReserve, 'btnDel', 'btnEdit', 'btnLook', 'hfldWastage');
            addEvent(document.getElementById('btnEdit'), 'click', rowEdit);
            addEvent(document.getElementById('btnLook'), 'click', rowQuery);
            addEvent(document.getElementById('btnAdd'), 'click', rowAdd);
            showTooltip('tooltip', 10);
            setWfButtonState2(wastageReserve, 'WF1');
        });

        function rowAdd() {
            //parent.desktop.AddReserve = window;
            var url = "/StockManage/SmWastage/SmWastageEditWX.aspx";
            //toolbox_oncommand(url, "新增报损出库单");
            layer.open({
                type: 2,
                title: '新增报损出库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }

        function rowEdit() {
           // parent.desktop.AddReserve = window;
            var url = "/StockManage/SmWastage/SmWastageEditWX.aspx?id=" + document.getElementById("hfldWastage").value;
            //toolbox_oncommand(url, "编辑报损出库单");
            layer.open({
                type: 2,
                title: '编辑报损出库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }

        function rowQuery() {
            var url = "ViewWastageWX.aspx?t=1&ic=" + document.getElementById("hfldWastage").value;
            //viewopen(url, 820, 500);
            layer.open({
                type: 2,
                title: '查看报损出库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }
        function rowQuery(id) {
            var url = "ViewWastageWX.aspx?t=1&ic=" + id;
            layer.open({
                type: 2,
                title: '查看报损出库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
        //// 选择人员
        //function selectUser() {
        //    jw.selectOneUser({ codeinput: 'hdnPeople', nameinput: 'txtPeople' });
        //}

        //function selectTrea() {
        //    jw.selectTreasury({ codeinput: 'hfldTrea', nameinput: 'txtTrea' });
        //}
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
                <td style="vertical-align: top;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr style="height: 25px;">
                            <td class="descTd">出库单号
                            </td>
                            <td>
                                <asp:TextBox ID="txtWastageCode" Height="15px" Width="120px" runat="server"></asp:TextBox>
                            </td>   </tr>
                        <tr>
                            <td class="descTd">起始日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>   </tr>
                        <tr>
                            <td class="descTd">结束日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>   </tr>
                        <tr>
                            <td class="descTd">录 入 &nbsp;人
                            </td>
                            <td><input type="text" style="width: 120px;" id="txtPeople"  runat="server" />
                                <%--<input type="text" style="width: 120px;" id="txtPeople" class="select_input" imgclick="selectUser" runat="server" />--%>

                                <asp:HiddenField ID="hdnPeople" runat="server" />
                            </td>
                        </tr>
                        <tr style="height: 25px;">
                            <td class="descTd">仓库名称
                            </td>
                            <td><asp:TextBox ID="txtTrea" Width="120px" runat="server"></asp:TextBox>
                                <%--<asp:TextBox ID="txtTrea" CssClass="select_input" Width="120px" imgclick="selectTrea" runat="server"></asp:TextBox>--%>
                                <asp:HiddenField ID="hfldTrea" runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btn_Search" Text="查询" Style="cursor: pointer;" OnClick="btn_Search_Click" runat="server" />
                                <input type="button" id="btnUnSelect" value="取消查询" style="width:auto" onclick="ifshow();" />
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
                                <input type="button" id="btnSelect" value="高级查询" style="width:auto" onclick="ifshow();" />
                                <input type="button" id="btnAdd" value="新增" />
                                <input type="button" id="btnEdit" disabled="disabled" value="编辑" />
                                <asp:Button ID="btnDel" Text="删  除" disabled="disabled" OnClientClick="return confirm('您确定要删除吗??')" OnClick="btnDel_Click" runat="server" />
                                <input type="button" id="btnLook" disabled="disabled" value="查看" style="display:none;"/>
                                <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiCode="125" BusiClass="001" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%; vertical-align: top;">
                                <div class="">
                                    <asp:GridView ID="gvWastage" Width="100%" AutoGenerateColumns="false"  OnRowDataBound="gvWastage_RowDataBound" DataKeyNames="WastageId,WastageCode" runat="server" BorderColor="#DFDFDD" BorderStyle="Solid" BorderWidth="1px">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="20px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbBox" ToolTip='<%# System.Convert.ToString(Eval("WastageCode"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" Visible="False">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="报损出库单">
                                                <ItemTemplate>
                                                    <%--<span class="al" onclick="viewopen('ViewWastage.aspx?ic=<%# Eval("WastageId") %>',820,500);">
                                                        <%# Eval("WastageCode") %>
                                                    </span>--%>
                                                       <div style="position: absolute; margin-top: 5px;">
                                                        <span class="al" onclick="rowQuery('<%# Eval("WastageId") %>')" style="font-size: 16px; text-decoration: none;">
                                                            <%# Eval("WastageCode") %>
                                                        </span>
                                                    </div>
                                                    <div style="float: right; color: #999999; font-size: 12px;">
                                                        <span style="float: right;"><%# Eval("TreasuryName") %></span>
                                                        </br>
                                                        <span><%# Eval("InputPerson") %>   <%# Eval("InputDate") %></span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="录入人" Visible="False">
                                                <ItemTemplate>
                                                    <%# Eval("InputPerson") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="仓库名称" Visible="False">
                                                <ItemTemplate>
                                                    <%# Eval("TreasuryName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="录入时间" Visible="False">
                                                <ItemTemplate>
                                                    <%# Common2.GetTime(Eval("InputDate").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="流程状态"  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Common2.GetState(Eval("Flowstate").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="说明" Visible="False"> 
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("explain").ToString() %>'>
                                                        <%# StringUtility.GetStr(Eval("explain").ToString(), 10) %>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="rowa"></RowStyle>
                                        <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                        <HeaderStyle CssClass="header"></HeaderStyle>
                                        <FooterStyle CssClass="footer"></FooterStyle>
                                    </asp:GridView>
                                    <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" UrlPaging="false" ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Right" EnableTheming="true" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                                    </webdiyer:AspNetPager>
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
        <asp:HiddenField ID="hfldWastage" runat="server" />
    </form>
</body>
</html>
