<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrjInfoView.aspx.cs" Inherits="PrjManager_PrjInfoView" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>
<%@ Register TagPrefix="MyUserControl" TagName="usercontrol_fileupload_fileupload_ascx" Src="~/UserControl/FileUpload/FileUpload.ascx" %>
<%@ Register TagPrefix="MyUserControl" TagName="stockmanage_common_showaudit_ascx" Src="~/StockManage/Common/ShowAudit.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目信息查看</title>
    <script type="text/javascript" src="../Script/jquery.js"></script>
    <script type="text/javascript" src="../StockManage/script/Config2.js"></script>
    <script src="../Script/jw.js" type="text/javascript"></script>
    <script src="../Script/DecimalInput.js" type="text/javascript"></script>


    <link href="../Script/Print/css/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="../Script/Print/css/PrjManager-Print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="../Script/Print/css/print-preview.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../Script/ViewOfficeOnline.js"></script>
    <script src="../Script/Print/jquery.print-preview.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Script/Print/jw.print.js" type="text/javascript"></script>
    <link href="/StyleExt/CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/StockManage/skins/sm4.css" rel="stylesheet" type="text/css" />
    <link href="/StyleCss/Common.css" rel="stylesheet" type="text/css" />
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //打印预览
            $('#btnDy').printPreview();
        });
        function viewopen_n(url) {
            viewopen(url);
        }
        function setWidthHeight() {
            // $('#divBudget').height($(this).height() - 105);
            //$('#divBudget').height(100);
            //$('#divDetails').height(60);
            //$('#divDiaries').height($('#divBudget').height() - $('#divDetails').height());

            //$('#div_project').height($(this).height() - 20);
            // $('#divBudget').width($('#divContent').width() - $('#td_Left').width() - 7);
        }
        //点击行绑定日记明细
        function showDetails(id) {
            var src = '../BudgetManage/Cost/IFCostDetails.aspx?id=' + id + '&year=2016';
            viewopen(src, "费用明细");
            // $('#ifDetails').attr('src', src);
        }
        //合计
        //function fillTotalAmount(total) {
        //    var trText = '<tr><td align="center">合计</td><td></td><td></td><td></td><td></td><td></td><td></td><td align="right">' + total + '</td><td></td><td></td><td></td></tr>';
        //    if ($('#gvBudget')) {
        //        var tab = $('#gvBudget').get(0);
        //        var lastRowId = tab.rows[tab.rows.length - 1].id;
        //        $('#' + lastRowId).after(trText);
        //    }
        //}

        function openDetails2(id, title) {
            // var ddlValue = jw.getRequestParam('year');
            var url = '/BudgetManage/Cost/CostVerifyRecord.aspx?costType=P&ic=';
            //if (ddlValue == 'zzjg')
            //    url = '/BudgetManage/Cost/OrgVerifyRecord.aspx?ic=';
            url += id;
            title += '明细';
            viewopen(url, title);
        }
        //function openDetails2(id, title) {
        //    var ddlValue = jw.getRequestParam('year');
        //    var url = '/BudgetManage/Cost/CostVerifyRecord.aspx?costType=P&ic=';
        //    if (ddlValue == 'zzjg')
        //        url = '/BudgetManage/Cost/OrgVerifyRecord.aspx?ic=';
        //    url += id;
        //    title += '明细';
        //    toolbox_oncommand(url, title);
        //}
    </script>
</head>
<body id="print1" style="overflow-y: auto; height: auto;">
    <form id="form1" runat="server" name="form1" style="min-width: 700px;">
        <div class="VPage" style="border: 0; margin: 0; padding: 0;">
            <table class="tabCss" style="vertical-align: top; border-collapse: collapse;">
                <tr style="display: none;">
                    <td class="title-divHeader">项目信息查看
                
                <%--<input type="button" style="float: right;" class="noprint" onclick="winPrint()" value=" 打 印 " />--%>
                        <input type="button" id="btnDy" style="float: right;" class="noprint" value=" 打 印 " />
                    </td>
                </tr>
                <tr style="height: 1px;">
                    <td>
                        <table id="bllProducer" cellpadding="0" cellspacing="0" style="border-style: none; width: 100%;">
                            <tr>
                                <td style="border-style: none;">制单人:&nbsp;&nbsp;<asp:Label ID="lblBllProducer" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td style="border-style: none; text-align: right">打印日期:&nbsp;&nbsp;<asp:Label ID="lblPrintDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <%-- <div class="groupInfo" style="text-align: center; margin-bottom: 5px;">
                    立项人基本资料
                </div>--%>
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">立项基本资料</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                        <table cellpadding="0" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td class="descTd">立项人
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">部门/单位
                                </td>
                                <td class="elemTd
                        ">
                                    <asp:Label ID="lblCorp" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">岗位
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblDuty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">联系方式
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <%--  <div class="groupInfo" style="text-align: center; margin-bottom: 5px; margin-top: 5px;">
                    建设单位基本资料
                </div>--%>
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">建设单位基本资料</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="descTd">建设单位
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblOwner" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">联系人
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblOwnerLinkMan" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">联系方式
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblOwnerLinkManPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">联系地址
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblOwnerAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <%--  <div class="groupInfo" style="text-align: center; margin-bottom: 5px;">
                    基本要求
                </div>--%>
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">基本要求</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>

                        <table cellpadding="0" cellspacing="0" width="100%">

                            <tr>
                                <td class="descTd">项目编号
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjCode" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目名称
                                </td>
                                <td class="elemTd">
                                    <div style="width: 95%; word-break: break-all;">
                                        <asp:Label ID="lblPrjName" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap">计划开始日期
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap">计划结束日期
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">所属区域
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目地点
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjPlace" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">工程工期
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblDuration" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">工程量估算
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblEngineeringEstimates" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目造价
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjCost" CssClass="decimal_input" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">预测利润率
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblForecastProfitRate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目类型
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjKindClass" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">专业造价
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjProfessionalCost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">质量等级
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblQualityClass" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">设计单位
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblDesigner" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目属性
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblProperty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目审核情况
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblApprovalOf" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td class="descTd">监理单位
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblInspector" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目状态
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjState" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">经办人
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblAgent" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目责任人
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblDutyPerson" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="descTd">实施项目部
                                </td>
                                <td class="elemTd" colspan="3">
                                    <asp:Label ID="lblXmgroup" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">项目经理要求
                                </td>
                                <td class="elemTd" colspan="3">
                                    <asp:Label ID="lblPrjManagerRequire" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">技术负责人要求
                                </td>
                                <td class="elemTd" colspan="3">
                                    <asp:Label ID="lblTechnicalLeaderRequire" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目简介
                                </td>
                                <td class="elemTd" colspan="3">
                                    <div style="width: 95%; word-break: break-all;">
                                        <asp:Label ID="lblPrjInfo" Text="" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">信息来源
                                </td>
                                <td class="elemTd" colspan="3">
                                    <div style="width: 95%; word-break: break-all;">
                                        <asp:Label ID="lblInfoOrigin" Text="" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">其他特殊要求
                                </td>
                                <td class="elemTd" colspan="3">
                                    <div style="width: 95%; word-break: break-all;">
                                        <asp:Label ID="lblElseRequest" Text="" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">备注
                                </td>
                                <td class="elemTd" colspan="3">
                                    <div style="width: 95%; word-break: break-all;">
                                        <asp:Label ID="lblRemark1" Text="" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">附件
                                </td>
                                <td class="elemTd" colspan="3" id="upload" runat="server"></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <%-- <div class="groupInfo" style="text-align: center; margin-bottom: 5px; margin-top: 5px;">
                    商务要求
                </div>--%>
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">商务要求</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>

                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="descTd">资质要求
                                </td>
                                <td class="elemTd" colspan="3">
                                    <asp:Label ID="lblRank" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">承包方式
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblContractWay" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">付款条件
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPayCondition" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">招标方式
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblTenderWay" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">结算方式
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPayWay" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">预算方式
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblBudgetWay" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">重要程度
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblKeyPart" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">项目经理
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjManager" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">业务经理
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblBusinessman" runat="server"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td class="descTd">主要负责人
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblWorkUnit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">主要负责人联系电话
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblTelphone" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <%--   <div class="groupInfo" style="text-align: center; margin-bottom: 5px; margin-top: 5px;">
                    补充内容
                </div>--%>
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">补充内容</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>

                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="descTd">工程类型
                                </td>
                                <td class="elemTd" colspan="3">
                                    <asp:Label ID="lblBuildingType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">规模
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblTotalHouseNum" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">等级
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblgrade" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">资金来源
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjFundInfo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">资金落实情况
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblFundWorkable" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">建筑面积
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblBuildingArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">占地面积
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblUsegrounArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">地下面积
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblUndergroundArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">阅知人
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPrjReadOne" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">绿化面积
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblAfforestArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">园林面积
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblParkArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">其他说明
                                </td>
                                <td colspan="3">
                                    <div style="width: 95%; word-break: break-all;">
                                        <asp:Label ID="lblOtherStatement" Text="" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <%--  <div class="groupInfo" style="text-align: center; margin-bottom: 5px; margin-top: 5px;">
                    管理参数
                </div>--%>
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">管理参数</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>

                        <table cellpadding="0" cellspacing="0" width="100%"> 
                            <tr>
                                <td class="descTd">管理保证金
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblManagementMargin" CssClass="decimal_input" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">民工工资保证金
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblMigrantQualityMarginRate" CssClass="decimal_input" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">预扣税率
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblWithholdingTaxRate" CssClass="decimal_input" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">履约保证金
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblPerformanceBond" CssClass="decimal_input" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">其他（保证金）
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="lblElseMargin" CssClass="decimal_input" runat="server"></asp:Label>
                                </td>    </tr>
                            </table>
                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">投标保证金</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>

                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="descTd">投标保证金
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="money" CssClass="decimal_input" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">保证金用途
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="useing" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">缴款日期
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="inDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">退还日期
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="outDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">到期是否提醒(微信)
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="ifNotice" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="descTd">提醒接收人</td>
                                <td class="elemTd">
                                    <asp:Label ID="inUser" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="descTd" style="white-space: nowrap;">其他说明	
                                </td>
                                <td class="elemTd">
                                    <asp:Label ID="remark" runat="server"></asp:Label>
                                </td>    </tr>
                            </table>





                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">收入合同</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="">
                                        <asp:GridView ID="gvConract" AutoGenerateColumns="false" OnRowDataBound="gvPurchaseplan_RowDataBound" DataKeyNames="ContractId,isFContract,FlowState,Project" runat="server">
                                            <%--CssClass="gvdata"--%>
                                            <Columns>
                                                <%--  <asp:TemplateField HeaderStyle-Width="20px">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cbAllBox" runat="server" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbBox" ToolTip='<%# System.Convert.ToString(Eval("ContractId"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("Num").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="合同编号">
                                                    <ItemTemplate>
                                                        <span class="tooltip" title='<%# Eval("ContractCode").ToString() %>'>
                                                            <%# StringUtility.GetStr(Eval("ContractCode"), 30) %>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="合同名称">
                                                    <ItemTemplate>
                                                        <span class="link tooltip" title='<%# Eval("ContractName").ToString() %>' onclick="viewopen_n ('/ContractManage/IncometContract/IncometContractQuery.aspx?ic=<%# Eval("ContractId") %>', '收入合同查看')">
                                                            <%# StringUtility.GetStr(Eval("ContractName").ToString(), 25) %>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="合同金额" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input">
                                                    <ItemTemplate>
                                                        <%# WebUtil.GetEnPrice(Eval("ContractPrice").ToString(), Eval("ContractId").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="合同类型">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("TypeName").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="签订类型" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="labsign" Text='<%# System.Convert.ToString((Eval("sign").ToString() == "1") ? "已签订" : "未签订", System.Globalization.CultureInfo.CurrentCulture) %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="甲方">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(base.GetParty(Eval("Party").ToString())) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="结算方式">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("BMode").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="付款方式">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("PMode").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="合同状态" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# WebUtil.GetConState(Eval("conState").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="签订人">
                                                    <ItemTemplate>
                                                        <%# Eval("SignPeopleName") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="签约日期">
                                                    <ItemTemplate>
                                                        <%# Common2.GetTime(Eval("SignedTime").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--  <asp:TemplateField HeaderText="项目">
                                                    <ItemTemplate>
                                                        <span class="tooltip" title='<%# Eval("prjName").ToString() %>'>
                                                            <%# StringUtility.GetStr(Eval("prjName").ToString()) %>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="附件">
                                                    <ItemTemplate>
                                                        <%# GetAnnx(System.Convert.ToString(Eval("ContractId"))) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="流程状态">
                                                    <ItemTemplate>
                                                        <%# Common2.GetState(Eval("FlowState").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="丙方">
                                                    <ItemTemplate>
                                                        <span class="tooltip" title='<%# Eval("CParty").ToString() %>'>
                                                            <%# StringUtility.GetStr(Eval("CParty").ToString(), 25) %>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="备注">
                                                    <ItemTemplate>
                                                        <span class="tooltip" title='<%# Eval("Remark").ToString() %>'>
                                                            <%# StringUtility.GetStr(Eval("Remark").ToString(), 25) %>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="rowa"></RowStyle>
                                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                            <HeaderStyle CssClass="header"></HeaderStyle>
                                            <FooterStyle CssClass="footer"></FooterStyle>
                                        </asp:GridView>
                                        <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" UrlPaging="false" ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                                        </webdiyer:AspNetPager>
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">支出合同</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="">
                                        <asp:GridView ID="gvwContract" AutoGenerateColumns="false" OnRowDataBound="gvwContract_RowDataBound" DataKeyNames="ContractID,IsMainContract,PrjGuid,ContractCode" runat="server">
                                            <Columns>
                                                <%--<asp:TemplateField HeaderStyle-Width="20px" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("Num").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ContractCode" HeaderText="合同编号" />
                                                <asp:TemplateField HeaderText="合同名称">
                                                    <ItemTemplate>
                                                        <span class="link tooltip" title='<%# Eval("ContractName").ToString() %>' onclick="viewopen_n ('/ContractManage/PayoutContract/ParyoutContractQuery.aspx?bc=081&bcl=001&ic=<%# Eval("ContractID") %>', '支出合同查看')">
                                                            <%# StringUtility.GetStr(Eval("ContractName").ToString(), 25) %>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ModifiedMoney" ItemStyle-HorizontalAlign="Right" HeaderText="最终金额" ItemStyle-CssClass="decimal_input" />
                                                <asp:TemplateField HeaderText="合同类型">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("TypeName").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="虚拟合同" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="labfictitious" Text='<%# System.Convert.ToString((Eval("fictitious").ToString() == "1") ? "否" : "是", System.Globalization.CultureInfo.CurrentCulture) %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="乙方">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("CorpName").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="结算方式">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("BalanceModeName").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="付款方式">
                                                    <ItemTemplate>
                                                        <%# StringUtility.GetStr(Eval("PayModeName").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="流程状态">
                                                    <ItemTemplate>
                                                        <%# Common2.GetState(Eval("FlowState").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="合同状态" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# WebUtil.GetConState(Eval("conState").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="签约时间">
                                                    <ItemTemplate>
                                                        <%# Common2.GetTime(Eval("SignDate").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="签订人" DataField="SignPersonName" />
                                                <%-- <asp:TemplateField HeaderText="项目">
                                                <ItemTemplate>
                                                    <%# StringUtility.GetStr(Eval("PrjName").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="附件" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# GetAnnx(System.Convert.ToString(Eval("ContractID"))) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="rowa"></RowStyle>
                                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                            <HeaderStyle CssClass="header"></HeaderStyle>
                                            <FooterStyle CssClass="footer"></FooterStyle>
                                        </asp:GridView>
                                        <webdiyer:AspNetPager ID="AspNetPager2" Width="100%" UrlPaging="false" ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                                        </webdiyer:AspNetPager>
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <div class="cell_title_blue_line">
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">成本费用</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                        <table>
                            <tr>
                                <td>
                                    <div id="divBudget" style="overflow: hidden;">
                                        <div id="divDiaries" style="overflow: auto;">
                                            <asp:GridView ID="gvBudget" CssClass="gvdata" AutoGenerateColumns="false" OnRowDataBound="gvBudget_RowDataBound" DataKeyNames="InDiaryId" runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="序号">
                                                        <ItemTemplate>
                                                            <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="费用名称">
                                                        <ItemTemplate>
                                                            <span class="tooltip" title='<%# Eval("Name") %>'>
                                                                <%# StringUtility.GetStr(Eval("Name"), 20) %>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="发生单位" DataField="Department" />
                                                    <asp:TemplateField HeaderText="发生时间">
                                                        <ItemTemplate>
                                                            <%# Common2.GetTime(Eval("InputDate")) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="填报人" DataField="InputUser" />
                                                    <asp:BoundField HeaderText="经手人" DataField="IssuedBy" />
                                                    <asp:TemplateField HeaderText="流程状态" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <%# Common2.GetState(Eval("FlowState").ToString()) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="金额" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input">
                                                        <ItemTemplate>
                                                            <%# Eval("TotalAmount") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="月度差额比例" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <span class="link" onclick="openDetails2('<%# Eval("InDiaryId") %>','<%# Eval("Name") %>')">
                                                                <%# (decimal.Parse(Eval("MonthBudgetAmount").ToString()) > 0m) ? ((decimal.Parse(Eval("MonthBudgetAmount").ToString()) - decimal.Parse(Eval("MothDiaryAlreadyAmount").ToString())) / decimal.Parse(Eval("MonthBudgetAmount").ToString())).ToString("P2") : 0m.ToString("P2") %>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--  <asp:TemplateField HeaderText="所属项目">
                                                                    <ItemTemplate>
                                                                        <%# this.hfldPrjName.Value %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="核销金额" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input">
                                                        <ItemTemplate>
                                                            <%# GetAuditAmountSum(Eval("InDiaryId").ToString()).ToString("#,##0.000") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="是否核销">
                                                        <ItemTemplate>
                                                            <%# IsAudit(Eval("InDiaryId").ToString()) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="费用详情">
                                                        <ItemTemplate>
                                                            <span class="link" onclick="showDetails('<%# Eval("InDiaryId") %>')">查看
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="rowa"></RowStyle>
                                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                                <HeaderStyle CssClass="header"></HeaderStyle>
                                                <FooterStyle CssClass="footer"></FooterStyle>
                                            </asp:GridView>
                                            <webdiyer:AspNetPager ID="AspNetPager3" Width="100%" UrlPaging="false" ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Right" EnableTheming="true" OnPageChanged="AspNetPager3_PageChanged" runat="server">
                                            </webdiyer:AspNetPager>
                                        </div>
                                        <%--<div id="divDetails" style="border-style: none; border-top: solid 1px #CADEED; margin-top: 1px;">
                                                        <iframe id="ifDetails" style="width: 800px; height: 150px;" frameborder="none" border="0"></iframe>
                                                    </div>--%>
                                    </div>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr id="trAudit" style="vertical-align: top;">
                    <td>
                        <MyUserControl:stockmanage_common_showaudit_ascx ID="ShowAudit1" BusiCode="122" BusiClass="001" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hfldPurchaseChecked" runat="server" />
        <asp:Label ID="lblPrjId" runat="server" Text="" Style="display: none;"></asp:Label>
    </form>
</body>
</html>
