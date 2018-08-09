<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AsTestList.aspx.cs" Inherits="AsTestList" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WF.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>
    <link href="../Script/jquery.tooltip/jquery.tooltip.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../Script/jquery.js"></script>
    <script type="text/javascript" src="../Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="../Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../Script/jw.js"></script>
    <script type="text/javascript" src="../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="../StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="../Script/DecimalInput.js"></script>
    <script type="text/javascript" src="../Script/wf.js"></script>
    <script type="text/javascript" src="Script/PettyCashList.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
               


            var justTable = new JustWinTable('gvwAsTest');
            replaceEmptyTable('emptyTable', 'gvwAsTest');
            setWfButtonState2(justTable, 'WF1');             // 控制流程按钮
            justTable.registClickTrListener(function () {
                $('#btnAdd').attr('disabled', 'disabled');
                $('#btnEdit').removeAttr('disabled');
                $('#asTestId').val($(this).attr('id'));

            });
            justTable.registClickSingleCHKListener(function () {
                var checkedChk = justTable.getCheckedChk();
                if (checkedChk.length == 1) {
                    $('#btnAdd').attr('disabled', 'disabled');
                    $('#btnEdit').removeAttr('disabled');
                    var Tr = getFirstParentElement(checkedChk[0].parentNode, 'TR');
                    $('#asTestId').val($(Tr).attr('id'));
                }
                else if (checkedChk.length != 1) {
                    $('#btnAdd').removeAttr('disabled');
                    $('#btnEdit').attr('disabled', 'disabled');
                    var ids = "";
                    for (var i = 0; i < checkedChk.length; i++) {
                        var trs = getFirstParentElement(checkedChk[i].parentNode, 'TR');
                        ids += trs.id + ",";
                    }
                    $('#asTestId').val(ids);
                }
            });

            justTable.registClickAllCHKLitener(function () {
                if (justTable.isCheckedAll()) {
                    $('#btnAdd').attr('disabled', 'disabled');
                    $('#btnEdit').attr('disabled', 'disabled');
                    var checkedChk = justTable.getAllChk();
                    var ids = "";
                    for (var i = 0; i < checkedChk.length; i++) {
                        var tr = getFirstParentElement(checkedChk[i].parentNode, 'TR');
                        ids += tr.id + ",";
                    }
                    $('#asTestId').val(ids);
                }
                else {
                    $('#btnAdd').removeAttr('disabled');
                    $('#btnEdit').attr('disabled', 'disabled');
                }
            });

            $('#btnAdd').click(addPrjMilest);
            $('#btnEdit').click(EditPrjMilest);
        });
        //新增
        function addPrjMilest() {
            top.ui._AsTestList = window;
            var url = '/AsTest/AsTestEdit.aspx?action=Add';
            //top.ui.openTab({ url: url, title: '新增九个里程碑' });
            toolbox_oncommand(url, "新增");
        }
        //编辑
        function EditPrjMilest() {
            top.ui._AsTestList = window;
            var url = '/AsTest/AsTestEdit.aspx?action=Edit&Id=' + $('#asTestId').val();
            //top.ui.openTab({ url: url, title: '编辑九个里程碑' });
            toolbox_oncommand(url, "编辑");
        }
        //选择人员
        function selectOneUser() {

            jw.selectOneUser({ codeinput: 'hlfuserCode', nameinput: 'txtuserName' });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td>
                        <table class="queryTable" cellpadding="3px" cellspacing="0px">
                            <tr>
                                <td class="descTd" style="width: 50px;">申请日期
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" onclick="WdatePicker()" runat="server"></asp:TextBox>
                                </td>
                                <td class="descTd" style="width: 50px;">至
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" onclick="WdatePicker()" runat="server"></asp:TextBox>
                                </td>
                                -<td class="descTd" style="width: 50px;">
								金额
							</td>
							<td>
								<asp:TextBox ID="txtStartCash" CssClass="easyui-numberbox" data-options="min:0,max:9999999999,precision:3,groupSeparator:','" runat="server"></asp:TextBox>
							</td>
							<td class="descTd" style="width: 50px;">
								至
							</td>
							<td>
								<asp:TextBox ID="txtEndCash" CssClass="easyui-numberbox" data-options="min:0,max:9999999999,precision:3,groupSeparator:','" runat="server"></asp:TextBox>
							</td>
                                <td>
                                    <asp:Button ID="btnSearch" Text="查询" OnClick="btnSearch_Click" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td id="td_buttons" class="divFooter" style="text-align: left;">
                        <span id="span_buttons">
                            <input type="button" id="btnAdd" value="新增" />
                            <input type="button" id="btnEdit" value="编辑" disabled="disabled" />
                            <asp:Button ID="btnDelete" Text="删除" Enabled="false" OnClick="btnDelete_Click" runat="server" />
                            <input type="button" id="btnQuery" value="查看" disabled="disabled" />
                            <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiCode="172" BusiClass="001" runat="server" />
                            <asp:Label ID="lblUserName" Visible="false" runat="server"></asp:Label>
                        </span>
                        <asp:Button ID="btnExportExcel" Text="导出Excel" Width="70px" OnClick="btnExportExcel_Click" runat="server" />
                        <span id="span_user"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvwAsTest" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvwAsTest_RowDataBound" DataKeyNames="Id" runat="server">
                            <EmptyDataTemplate>
                                <table class="gvdata" cellspacing="0" rules="all" border="1" id="gvwPettyCashEmpty"
                                    style="width: 100%; border-collapse: collapse;">
                                    <tr class="header">
                                        <th scope="col" style="width: 20px;">
                                            <input id="chkAll" type="checkbox" />
                                        </th>
                                        <th scope="col" style="width: 25px;">序号
                                        </th>
                                        <th scope="col" style="width: 80px;">申请缘由
                                        </th>
                                        <th scope="col" style="width: 80px;">申请费用
                                        </th>
                                        <th scope="col" style="width: 200px;">申请人
                                        </th>
                                        <th scope="col" style="width: 100px;">申请日期
                                        </th>
                                        <th scope="col" style="width: 80px;">流程状态
                                        </th>
                                       <%-- <th scope="col" style="width: 80px;">流程状态
                                        </th>--%>
                                       <%-- <th scope="col">项目
                                        </th>--%>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="20px" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectSingle" runat="server" />
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" HeaderStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" Width="25px"></HeaderStyle>
                                </asp:TemplateField>
                                 <%--<asp:TemplateField HeaderText="保证金编号" HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                           <%# StringUtility.GetStr(Eval("Number").ToString(), 50) %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                               <%-- <asp:TemplateField HeaderText="项目名称" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <span class="tooltip" title='<%# (Eval("ProjectId") == null) ? "" : Eval("ProjectId.PrjName").ToString() %>'>
                                            <%# (Eval("ProjectId") == null) ? "" : StringUtility.GetStr(Eval("ProjectId.PrjName"), 20) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                   <asp:TemplateField HeaderText="申请缘由" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                         <%# Eval("ApplicationReason").ToString() %>
                                    </ItemTemplate>

                                    <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="申请费用" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                         <%# Eval("cash").ToString() %>
                                    </ItemTemplate>

                                    <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请人" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                         <%# GetUserName(Eval("ApplicantId").ToString()) %>
                                    </ItemTemplate>

                                    <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请日期" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <span class="link"><%# System.Convert.ToDateTime(Eval("ApplicationDate")).ToString("yyyy-MM-dd") %></span>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="流程状态" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Common2.GetState(Eval("FlowState").ToString()) %>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                            <HeaderStyle CssClass="header"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                        </asp:GridView>
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" UrlPaging="false" ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hfldUserName" runat="server" />
        <asp:HiddenField ID="hfldPettyCashIds" runat="server" />
    </form>
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/icon.css" />
</body>
</html>
