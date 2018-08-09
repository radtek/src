<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmWantPlanList.aspx.cs" Inherits="StockManage_basicset_SmWantPlanList" EnableEventValidation="true" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WFWX.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>物资需求计划</title>
    <link href="/Script/jquery.treeview/jquery.treeview.css" rel="Stylesheet" type="text/css" />
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="/Script/jquery.easyui/themes/icon.css" />

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
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="../../Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            parent.$('.layout-panel-center').css({ "left": "0px", "width": "100%" });
            parent.$('.panel-body-noheader').css({ "width": "100%" });
            $('.ifshow').hide();
            // 添加验证
            $('#btnSearch')[0].onclick = function () { if (!$('#form1').form('validate')) return false; }
            var wantPlanTable = new JustWinTable('gvSm_Wantplan');
            replaceEmptyTable('emptySm_Wantplan', 'gvSm_Wantplan');
            addEvent(document.getElementById('btnAdd'), 'click', openWindow);
            addEvent(document.getElementById('btnLook'), 'click', queryWantplan);
            setButton(wantPlanTable, "btnDel", "btnUpdate", "btnLook", "hfldWantPlanCheckedID")
            setWfButtonState2(wantPlanTable, 'WF1');
            showTooltip('tooltip', 15);
            $('#txtStartTime').blur(function () {
                controlDate(this);
            })
            $('#txtEndTime').blur(function () {
                controlDate(this);
            })
        });

        function openWindow() {
            var pname = document.getElementById('hdnProname').value;
            var pcode = document.getElementById('hndProCode').value;
            var swcode = document.getElementById('hdnSwid').value;
            //parent.parent.desktop.SmWantPlan = window;
            var url = "/StockManage/basicset/SmWantPlanWX.aspx?pcode=" + pcode + "&swcode=" + swcode + "&optype=add";
            //toolbox_oncommand(url, "新增需求计划单");
            layer.open({
                type: 2,
                title: '新增需求计划单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }
        //编辑查看验证
        function checkCount() {
            var chk = new JustWinTable('gvSm_Wantplan');
            if (chk.getCheckedChk().length > 1) {
                top.ui.alert('编辑或者查看时，只能选择单行！');
                return false;
            }
            if (chk.getCheckedChk().length == 0) {
                top.ui.alert('请选择要操作的行！');
                return false;
            }
            return true;
        }
        //删除验证
        function delCheck() {
            var chk = new JustWinTable('gvSm_Wantplan');
            if (chk.getCheckedChk().length == 0) {
                top.ui.alert('请选择要操作的行！');
                return false;
            }
            else {
                return confirm("确定删除吗？");
            }

        }

        function openPerson() {
            winopen("/CommonWindow/PickSinglePerson.aspx?sm");
        }

        function queryWantplan() {
            var id = $('#hfldWantPlanCheckedID').val();
            $('#' + id).find('.al').click();
            //			viewopen('WantplanView.aspx?ic=' + this.guid, 820, 500);
        }
        function rowQuery(id) {
            var url = 'WantplanViewWX.aspx?ic=' + id + '&prjId=' + $('#hndProCode').val();
            layer.open({
                type: 2,
                title: '查看需求计划单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
        //选择人员
        function selectUser() {
            jw.selectOneUser({ nameinput: 'txtPeople' });
        }

        //管理时间
        function controlDate(para) {
            var startDates = document.getElementById('txtStartTime').value;
            var startDateList = startDates.split('-');
            var startDate = new Date(startDateList[0], startDateList[1] - 1, startDateList[2]);

            var endDates = document.getElementById('txtEndTime').value;
            var endDatesList = endDates.split('-');
            var endDate = new Date(endDatesList[0], endDatesList[1] - 1, endDatesList[2]);
            if (startDates != '') {
                if (startDate == 'NaN') {
                    top.ui.alert('起始日期输入时间格式不正确！');
                    para.value = '';
                    return;
                }
            }
            if (endDates != '') {
                if (endDate == 'NaN') {
                    top.ui.alert('结束日期输入时间格式不正确！');
                    para.value = '';
                    return;
                }
            }
        }
        function update(url, title) {
            //alert(url);
            layer.open({
                type: 2,
                title: '编辑需求计划单',
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
        function show(swid) {
            var url = 'WantplanView.aspx?ic=' + swid + '&prjId=' + $('#hndProCode').val();
            viewopen(url, 820, 500);
        }

    </script>
</head>
<body>
   <form id="form1" runat="server" style="word-break: normal; font-family: -apple-system-font, 'Helvetica Neue', 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', sans-serif; background-size: cover; word-wrap: break-word; word-break: break-all; background: #f5f5f5 no-repeat center;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="divHeader" style="letter-spacing: normal">
                    <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr  class="ifshow">
                <td style="height: 96%; width: 100%;">
                    <input id="hdnSwid" type="hidden" runat="server" />

                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr>
                            <td class="descTd">录入日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td> </tr>
                        <tr>
                            <td class="descTd">至
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td> </tr>
                        <tr>
                            <td class="descTd">计划编号
                            </td>
                            <td>
                                <asp:TextBox ID="txtSwcode" Width="120px" CssClass="easyui-validatebox" data-options="validType:'validChars[50]'" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd">录入人
                            </td>
                            <td>
                                <asp:TextBox ID="txtPeople" Style="width: 120px;" CssClass="easyui-validatebox" data-options="validType:'validChars[50]'"  runat="server"></asp:TextBox>
                            </td> </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Button ID="btnSearch" Text="查询" Style="cursor: pointer;" OnClick="btnSearch_Click" runat="server" />
                            <input type="button" id="btnUnSelect" value="取消查询" style="width: auto" onclick="ifshow();" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="divFooter" style="text-align: left;">
                    <input type="button" id="btnSelect" value="高级查询" style="width: auto" onclick="ifshow();" />
                    <input id="btnAdd" type="button" value="新增" />
                    <input id="btnUpdate" type="button" value="编辑" disabled="true" onserverclick="btnUpdateWX_ServerClick" runat="server" />

                    <input id="btnDel" type="button" value="删除" disabled="true" onserverclick="btnDel_ServerClick" runat="server" />

                    <input id="btnLook" type="button" value="查看" disabled="disabled" style="display:none;"/>
                    <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiCode="071" BusiClass="001" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 100%;">
                    <div class="">
                        <asp:GridView ID="gvSm_Wantplan" AutoGenerateColumns="false" CssClass="gvdata" AllowPaging="true" OnRowDataBound="gvSm_Wantplan_RowDataBound" OnPageIndexChanging="gvSm_Wantplan_PageIndexChanging" DataKeyNames="swcode,swid,procode" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="20px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" Width="20px" runat="server" />
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBox" Width="20px" ToolTip='<%# System.Convert.ToString(Eval("swcode"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" Visible="False">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="计划编号">
                                    <ItemTemplate>
                                       <%-- <span class="al" onclick="show('<%# Eval("swid") %>')">
                                            <%# Eval("swcode") %>
                                        </span>--%>
                                         <div style="position: absolute; margin-top: 5px;">
                                            <span class="al" onclick="rowQuery('<%# Eval("swid") %>')" style="font-size: 16px; text-decoration: none;">
                                                <%# Eval("swcode") %>
                                            </span>
                                        </div>
                                        <div style="float: right; color: #999999; font-size: 12px;">
                                            <span style="float: right;">是否受理:&nbsp; <%# Common2.GetAcceptState(Eval("acceptstate").ToString()) %></span>
                                            </br>
                                                        <span><%# Eval("person") %>   <%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="录入人" DataField="person" Visible="False"/>
                                <asp:TemplateField HeaderText="录入时间" Visible="False">
                                    <ItemTemplate>
                                        <%# Common2.GetTime(Eval("intime").ToString()) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="流程状态" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Common2.GetState(Eval("flowstate").ToString()) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="附件" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px" Visible="False">
                                    <ItemTemplate>
                                        <%# GetAnnx(System.Convert.ToString(Eval("swid"))) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="说明" Visible="False">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("explain") %>'>
                                            <%# StringUtility.GetStr(System.Convert.ToString(Eval("explain"))) %>
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
        <input id="hdnProname" type="hidden" runat="server" />

        <input id="hndProCode" type="hidden" runat="server" />

        <asp:HiddenField ID="hfldWantPlanCheckedID" runat="server" />
    </form>
</body>
</html>
