<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="ProgressManagement_Actual_Reports" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WFWX.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>实际进度上报单据</title>
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
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="../../StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="../../SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <link rel="Stylesheet" type="text/css" href="../../Script/jquery.tooltip/jquery.tooltip.css" />

    <script type="text/javascript" src="../../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var jwTable = new JustWinTable('gvwReports');
            replaceEmptyTable('gvEmpty', 'gvwReports')
            //进度计划VerId
            var id = getRequestParam('id');
            if (id != '')
                $('#btnAdd').removeAttr('disabled');
            //新增进度上报
            $('#btnAdd').bind('click', function () {
                //top.ui._ReportEdit = window;
                var url = '/ProgressManagement/Actual/ReportEditWX.aspx?id=' + id + '&type=add';
                //toolbox_oncommand(url, "新增进度上报");
                layer.open({
                    type: 2,
                    title: '新增进度上报',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['100%', '100%'],//['380px', '90%'],
                    content: url//'mobile/' //iframe的url
                });
            });
            //编辑进度上报
            $('#btnEdit').bind('click', function () {

                //top.ui._ReportEdit = window;
                var reportId = $('#' + $('#hfldCheckedIds').val()).attr('id');
                var url = '/ProgressManagement/Actual/ReportEditWX.aspx?reportId=' + reportId + '&id=' + id + '&type=edit';
                //toolbox_oncommand(url, "编辑进度上报");
                layer.open({
                    type: 2,
                    title: '编辑进度上报',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['100%', '100%'],//['380px', '90%'],
                    content: url//'mobile/' //iframe的url
                });

            });
            //查看进度上报
            $('#btnView').bind('click', function () {
                var reportId = $('#' + $('#hfldCheckedIds').val()).attr('id');
                var url = '/ProgressManagement/Actual/ReportView.aspx?ic=' + reportId;
                //viewopen(url, '实际进度上报信息查看');
                layer.open({
                    type: 2,
                    title: '实际进度上报信息查看',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['100%', '100%'],//['380px', '90%'],
                    content: url//'mobile/' //iframe的url
                });
            });

            setButton(jwTable, 'btnDel', 'btnEdit', 'btnView', 'hfldCheckedIds');
            setWfButtonState2(jwTable, 'WF_1');
            showTooltip('tooltip', 25);

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divButtons" class="divFooter" style="text-align: left;">
            <input type="button" id="btnAdd" value="新增" disabled="disabled" />
            <input type="button" id="btnEdit" value="编辑" disabled="disabled" />
            <input type="button" id="btnView" value="查看" disabled="disabled" />
            <asp:Button ID="btnDel" Text="删除" disabled="disabled" OnClientClick="return confirm('您确定要删除吗？');" OnClick="btnDel_Click" runat="server" />
            <input type="button" id="btnWaste" style="display: none;" value="无用按钮" />
            <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiCode="111" BusiClass="001" runat="server" />
        </div>
        <div id="divGvwReports" style="
    margin-top: 20px;
">
            <asp:GridView ID="gvwReports" CssClass="gvdata" AutoGenerateColumns="false" OnRowDataBound="gvwReports_RowDataBound" DataKeyNames="Id" runat="server">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="20px">
                        <HeaderTemplate>
                            <asp:CheckBox ID="cbAllBox" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbBox" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="序号" DataField="No" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Right" Visible="False"/>
                    <asp:BoundField HeaderText="上报日期" DataField="InputDate" ItemStyle-Width="100px" DataFormatString="{0:yyyy-MM-dd}" Visible="False"/>
                    <asp:BoundField HeaderText="记录人" DataField="UserName" ItemStyle-Width="100px" Visible="False"/>
                    <asp:TemplateField HeaderText="上报日期" ItemStyle-Width="80px">
                        <ItemTemplate>
                            <%--<%# Common2.GetState(Eval("InputDate").ToString()) %>--%>
                            <div style="position: absolute; margin-top: 5px;">
                                <span class="al"  style="font-size: 16px; text-decoration: none;">
                                    <%# Common2.GetTime(Eval("InputDate").ToString()) %>
                                </span>
                            </div>
                            <div style="float: right; color: #999999; font-size: 12px;">
                                <span style="float: right;"><%# StringUtility.GetStr(StringUtility.StripTagsCharArray(Eval("Note").ToString()), 25) %></span>
                                </br><span><%# Eval("UserName") %>  </span>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="流程状态" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Common2.GetState(Eval("FlowState").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" Visible="False">
                        <ItemTemplate>
                            <span class="tooltip" title='<%# StringUtility.StripTagsCharArray(Eval("Note").ToString()) %>'>
                                <%# StringUtility.GetStr(StringUtility.StripTagsCharArray(Eval("Note").ToString()), 25) %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="header"></HeaderStyle>
                <EmptyDataRowStyle CssClass="header"></EmptyDataRowStyle>
                <RowStyle CssClass="rowa"></RowStyle>
                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
            </asp:GridView>
        </div>
        <asp:HiddenField ID="hfldCheckedIds" runat="server" />
    </form>
</body>
</html>
