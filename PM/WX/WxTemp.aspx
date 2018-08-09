<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxTemp.aspx.cs" Inherits="WX_WxTemp" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请先选择项目</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />

    <link type="text/css" rel="stylesheet" href="../../Script/jquery.tooltip/jquery.tooltip.css" />
    <script src="/Web_Client/Tree.js" type="text/javascript"></script>
    <script src="/Script/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script src="/StockManage/script/JustWinTable.js" type="text/javascript"></script>
    <script src="/StockManage/script/Config2.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Script/json2.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <style>
        .GridView {
            border: none;
            margin-top: 95px;
            font-size: 12px;
            color: blue;
        }

            .GridView .header {
                display: none;
            }

            .GridView tr {
                border: solid 1px #999999;
                border-left: none;
                border-right: none;
                height: 40px;
            }

                .GridView tr td {
                    border: solid 1px #999999;
                    border-left: none;
                    border-right: none;
                }

        .head {
            position: fixed;
            background-color: white;
            height: 95px;
            width: 95%;
            border: 1px solid #999999;
            margin-top: -95px;
            font-size: 12px;
        }
    </style>
    <script>
        $(document).ready(function () {
            jw.tooltip();
            var prjTab = new JustWinTable('gvwPrj');
            formateTable('gvwPrj', 1);

            clickTr();
            dbclickTr();
        });

        function clickTr() {
            $('#gvwPrj TR[id]').click(function () {
                var prjObj = {
                    prjId: $(this).attr('id'),
                    prjName: $(this).attr('name'),
                    typeCode: $(this).attr('typeCode')
                };

                $('#hdPrjInfo').val(JSON.stringify(prjObj));

                $("#btnSave").removeAttr('disabled');
            });
        }

        function dbclickTr() {
            $('#gvwPrj TR[id]').dblclick(function () {
                okEvent();
            });
        }

        // 确定事件
        function okEvent() {
            //if (top.ui.callback != null) {
            var prj = JSON.parse($('#hdPrjInfo').val());
            // console.log(prj);
            //alert(prj.prjId);
            //alert($("#PageType").val());
            //alert($("#UserCode").val());
            reURl(prj.prjId, $("#PageType").val(), $("#UserCode").val())
            //top.ui.callback(prj);
            //}
            //top.ui.closeWin({ winNo: getRequestParam('winNo') });
        }
        //function reURl(type,userID) {
        //    alert(userID);
        //}
        function reURl(prjId, type, userID) {
            //alert(userID);
            var strUrl = "";
            //退库管理
            if (type == 'refundingListWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=refundingListWX";
                strUrl = "/StockManage/Refunding/RefundingListWX.aspx?PrjGuid=" + prjId;
            }
            //退库确认
            if (type == 'qoRefundingListWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=qoRefundingListWX";
                strUrl = "/StockManage/Refunding/QoRefundingListWX.aspx?PrjGuid=" + prjId;
            }
            //出库管理
            if (type == 'outReserveWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=outReserveWX";
                strUrl = "/StockManage/SmOutReserve/SmOutReserveListWX.aspx?PrjGuid=" + prjId;
            }
            //出库确认
            if (type == 'qOutReserveWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=qOutReserveWX";
                strUrl = "/StockManage/SmOutReserve/QOutReserveWX.aspx?PrjGuid=" + prjId;
            }
            //物资需求计划
            if (type == 'wantPlanWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=wantPlanWX&prjId=";
                strUrl = "/StockManage/basicset/SmWantPlanListWX.aspx?prjId=" + prjId;
            }
            //物资采购计划  *
            if (type == 'purchasePlanWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=purchasePlanWX";
                strUrl = "/StockManage/SmPurchaseplan/SmPurchaseplanListWX.aspx?PrjGuid=" + prjId;
            }
            //施工计划查看
            if (type == 'planPlaitWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=planPlaitWX";
                //strUrl = "/StockManage/Purchase/PurchaseWX.aspx?PrjGuid=" + prjId;
                strUrl = "/ProgressManagement/Plan/PlanWX.aspx?PrjGuid=" + prjId;
            }
            //施工计划上报
            if (type == 'planActualRptWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=planActualRptWX";
                strUrl = "/ProgressManagement/Actual/ActualReportWX.aspx?year=&prjId=" + prjId;
            }
            //采购单
            if (type == 'purchaseWX') {
                //strUrl = "/StockManage/ProjectFrameWX.aspx?path=purchaseWX";
                strUrl = "/StockManage/Purchase/PurchaseWX.aspx?PrjGuid=" + prjId;
            }
            window.location.href = strUrl + "&stime=" + 10000 * Math.random();
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table2" class="head">
            <tr>
                <td style="text-align: left; height: 25px;">项目编号：<asp:TextBox ID="prjcode" Width="180px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 25px;">项目名称：<asp:TextBox ID="prjname" Width="180px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 25px;">
                    &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="SearchBt" Text="查 询" OnClick="SearchBt_Click" runat="server" /> &nbsp; &nbsp; <input id="btnSave" type="button" value="确定选择" onclick="okEvent();" disabled="disabled" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvwPrj" CellPadding="0" Width="100%" AutoGenerateColumns="false" CssClass="GridView" AllowPaging="true" PageSize="999999" OnPageIndexChanging="gvwPrj_PageIndexChanging" OnRowDataBound="gvwPrj_RowDataBound" DataKeyNames="Id,Code,Name,State,IsParent,TypeCode" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="项目编号" ItemStyle-Width="30px">
                                    <ItemTemplate>
                                        <span style="float: left; color: #999999; font-size: 12px;"><%# Eval("Code") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目名称" >
                                    <ItemTemplate>
                                        <span "> <%# Eval("Name") %></span>
                                          <%-- <span class="tooltip" title='<%# Eval("Name") %>'>
                                             <%# Eval("Code") %>&nbsp;<%# Eval("Name") %>
                                         <%# StringUtility.GetStr(Eval("Name"), 15) %>
                                        </span>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="建设单位" Visible="false">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# GetOwnerName(Eval("OwnerCode")) %>'>
                                            <%# StringUtility.GetStr(base.GetOwnerName(Eval("OwnerCode")), 10) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目地点" Visible="false">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("Place").ToString() %>'>
                                            <%# StringUtility.GetStr(Eval("Place"), 15) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" Visible="false">
                                    <ItemTemplate>
                                        <%# ProjectStateHelper.GetName(Eval("State")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                            <HeaderStyle CssClass="header"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                        </asp:GridView>
        <div style="text-align: left">

            <%--<input id="btnCancel" type="button" value="取 消" onclick="top.ui.closeWin({ winNo: getRequestParam('winNo') });" />--%>
        </div>
        <input id="hdnModuleCodeList" style="width: 10px" type="hidden" name="hdnModuleCodeList" runat="server" />

        <asp:HiddenField ID="hdName" runat="server" />
        <asp:HiddenField ID="hdCode" runat="server" />
        <asp:HiddenField ID="hdPrjCode" runat="server" />
        <asp:HiddenField ID="hdPrjInfo" runat="server" />
        <asp:HiddenField ID="hdCodeName" runat="server" />

        <asp:HiddenField ID="PageType" runat="server" />
        <asp:HiddenField ID="UserCode" runat="server" />
    </form>
</body>
</html>
