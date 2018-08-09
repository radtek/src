<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualReport.aspx.cs" Inherits="ProgressManagement_Actual_Report" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>实际进度上报</title>
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
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="../../SysFrame/jscript/JsControlMenuTool.js"></script>
    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.tooltip/jquery.tooltip.css" />

    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            parent.$('.layout-panel-center').css({ "left": "0px", "width": "100%" });
            parent.$('.panel-body-noheader').css({ "width": "100%" });
            $('.ifshow').hide();
            var jwTable = new JustWinTable('gvwPlans');
            setWidthHeight();
            showTooltip("tooltip", 25);
            setButton(jwTable, 'btnEmpty', 'btnEmpty', 'btnEmpty', 'hfldChecked');
            replaceEmptyTable('tblEmpty', 'gvwPlans');
            //首次默认第一个计划
            if ($('#gvwPlans')[0].rows.length > 1) {
                $('#gvwPlans')[0].rows[1].click();
            }
        });

        //设置高度和宽度
        function setWidthHeight() {
            $('#divBudget').height($(this).height() - 255);
            $('#divBudget').width($('#divContent').width() - $('#td_Left').width() - 7);
            $('#div_project').height($(this).height() - 20);
            //$('#divIfReports').width($('#divContent').width() - $('#td_Left').width() - 7);
            //$('#divIfReports').height($(this).height() - $('#divBudget').height() - 5);
        }

        //查看进度计划
        function lookInfo(progressId) {
            var url = '/ProgressManagement/Modify/ApplyView.aspx?ic=' + progressId;
            //var titleText = '查看进度计划';
            //toolbox_oncommand(url, titleText);
            layer.open({
                type: 2,
                title: '查看进度计划',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }

        //点击行
        function clickTr(id) {
            $('#ifReports').attr('src', 'ReportsWX.aspx?' + new Date().getTime() + '&id=' + id);
        }
        function ifshow() {
            if ($('.ifshow').is(':hidden')) {
                $('.ifshow').show();
                //$("#btnSelect").hide();
            }
            else {
                $('.ifshow').hide();
               // $("#btnSelect").show();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="word-break: normal; font-family: -apple-system-font, 'Helvetica Neue', 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', sans-serif; background-size: cover; word-wrap: break-word; word-break: break-all; background: #f5f5f5 no-repeat center;">
        <div id="divContent" class="divContent2" style="width: 100%; height: 100%; overflow: hidden;">
            <div style="width:100%">
 <input type="button" id="btnSelect" value="显隐计划" style="width:auto" onclick="ifshow();" />
            </div>
           
            <table style="
    height: 100%;
    width: 100%;
">
                <tr>
                    <td style="width: 100%; height: 100%;">
                        <table style="width: 100%; height: 100%;">
                            <tr>

                                <td style="width: 100%; vertical-align: top; height: 100%; border-left: solid 2px #CADEED;">
                                    <table class="tab">
                                        <tr class="ifshow">
                                            <td style="vertical-align: top;" colspan="3">
                                                <div id="divBudget" class="pagediv " style="overflow: hidden;">
                                                    <asp:GridView ID="gvwPlans" CssClass="gvdata" AutoGenerateColumns="false" OnRowDataBound="gvwPlans_RowDataBound" DataKeyNames="ProgressVersionId" runat="server">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="序号" DataField="No" HeaderStyle-Width="20px" Visible="False"/>
                                                            <asp:TemplateField HeaderText="计划名称" HeaderStyle-Width="320px">
                                                                <ItemTemplate>
                                                                    <%--<a class="link tooltip" title='<%# Eval("VersionName") %>' onclick="lookInfo('<%# Eval("ProgressVersionId") %>')">
                                                                        <%# StringUtility.GetStr(Eval("VersionName"), 25) %></a>--%>
                                                                    <div style="position: absolute; margin-top: 5px;">
                                                                        <span class="al" onclick="lookInfo('<%# Eval("ProgressVersionId") %>')" style="font-size: 16px; text-decoration: none;">
                                                                            <%# StringUtility.GetStr(Eval("VersionName"), 20) %>
                                                                        </span>
                                                                    </div>
                                                                    <div style="float: right; color: #999999; font-size: 12px;">
                                                                        <span style="float: right;">版本号:<%# Eval("VersionCode") %></span><br>
                                                                        </br>
                                                        <span><%# Eval("UserName") %>   <%# Common2.GetTime(Eval("InputDate").ToString()) %></span>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="版本号" DataField="VersionCode" Visible="False"/>
                                                            <asp:BoundField HeaderText="主计划" DataField="Main" HeaderStyle-Width="30px" />
                                                            <asp:BoundField HeaderText="计划编制人" DataField="UserName" Visible="False"/>
                                                            <asp:BoundField HeaderText="计划编制日期" HeaderStyle-Width="80px" DataField="InputDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Visible="False" />
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
                                        <tr>
                                            <td style="vertical-align: top;width: 100%;" colspan="3">
                                                <div id="divIfReports" class="pagediv "  style="overflow: hidden;width: 100%; height: 100%;">
                                                    <iframe id="ifReports" src="ReportsWX.aspx" frameborder="0" style="width: 100%; height: 100%; min-height: 500px;border-top: solid #CADEED 2px; overflow: auto;"></iframe>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hfldChecked" runat="server" />
        <input type="button" id="btnEmpty" style="display: none;" />
    </form>
</body>
</html>
