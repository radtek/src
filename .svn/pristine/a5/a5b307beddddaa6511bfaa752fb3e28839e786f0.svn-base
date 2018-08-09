<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmPurchaseplanList.aspx.cs" Inherits="StockManage_SmPurchaseplan_SmPurchaseplanList" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_wf_ascx" Src="~/EPC/UserControl1/WFWX.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请单列表</title>
    <link href="/Script/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/Script/jquery.treeview/jquery.treeview.css" rel="Stylesheet" type="text/css" />
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
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.mouse.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.draggable.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.position.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.resizable.js"></script>
    <script type="text/javascript" src="/Script/jquery.ui/jquery.ui.dialog.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="../../Script/wf.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            parent.$('.layout-panel-center').css({ "left": "0px", "width": "100%" });
            parent.$('.panel-body-noheader').css({ "width": "100%" });
            $('.ifshow').hide();
            var purchasePlanTable = new JustWinTable('gvPurchaseplan');

            // 保存guid
            purchasePlanTable.registClickTrListener(function () {
                $('#btnLook').attr('guid', $(this).attr('guid'));
            });
            purchasePlanTable.registClickSingleCHKListener(function () {
                var tr = jw.getParentUntil('TR')
                $('#btnLook').attr('guid', $(tr).attr('guid'));
            });

            setButton(purchasePlanTable, 'btnDel', 'btnEdit', 'btnLook', 'hfldPurchaseChecked');
            addEvent(document.getElementById('btnEdit'), 'click', rowEdit);
            addEvent(document.getElementById('btnLook'), 'click', rowQuery);
            addEvent(document.getElementById('btnAdd'), 'click', rowAdd);
            setWfButtonState2(purchasePlanTable, 'WF1');
            showTooltip('tooltip', 15);
            function rowAdd() {
               // parent.parent.desktop.AddSmPurchaseplan = window;
                var url = "/StockManage/Smpurchaseplan/AddSmpurchaseplanWX.aspx?prjId=" + document.getElementById("hfldPrjId").value;
                //toolbox_oncommand(url, "新增采购计划");
                layer.open({
                    type: 2,
                    title: '新增采购计划',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['100%', '100%'],//['380px', '90%'],
                    content: url//'mobile/' //iframe的url
                });
            }
            function rowEdit() {
                //parent.parent.desktop.AddSmPurchaseplan = window;
                var url = "/StockManage/Smpurchaseplan/AddSmpurchaseplanWX.aspx?id=" + document.getElementById("hfldPurchaseChecked").value;
                // toolbox_oncommand(url, "编辑采购计划");
                layer.open({
                    type: 2,
                    title: '编辑采购计划',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['100%', '100%'],//['380px', '90%'],
                    content: url//'mobile/' //iframe的url
                });
            }
            function rowQuery() {
                //var guid = $(this).attr('guid');
                //var url = "ViewSmPurchaseplan.aspx?t=1&ic=" + guid + "&BusiCode=072&BusiClass=001";
                //viewopen(url, 820, 500);
            }

            $('#txtStartTime').blur(function () {
                controlDate(this);
            })
            $('#txtEndTime').blur(function () {
                controlDate(this);
            })
        });

        //选择人员
        function selectUser() {
            jw.selectOneUser({ codeinput: 'hdnPeople', nameinput: 'txtPeople' });
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
                    alert('系统提示\n\n起始日期输入时间格式不正确！');
                    para.value = '';
                    return;
                }
            }
            if (endDates != '') {
                if (endDate == 'NaN') {
                    alert('系统提示\n\n结束日期输入时间格式不正确！');
                    para.value = '';
                    return;
                }
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
            <tr style="height: 20px;">
                <td class="divHeader">
                    <asp:Label ID="lblProject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="ifshow">
                <td style="width: 100%; vertical-align: top;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr>
                            <td class="descTd">起始日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd">结束日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd">计划编号
                            </td>
                            <td>
                                <asp:TextBox ID="txtPPcode" Height="15px" Width="120px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="descTd">录 &nbsp; 入 人
                            </td>
                            <td>
                                <%--<input type="text" style="width: 120px;" id="txtPeople" class="select_input" imgclick="selectUser" runat="server" />--%>
                                <input type="text" style="width: 120px;" id="txtPeople" runat="server" />
                                <asp:HiddenField ID="hdnPeople" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
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
                                <input type="button" id="btnAdd" value="新增" />
                                <input type="button" id="btnEdit" disabled="disabled" value="编辑" />
                                <asp:Button ID="btnDel" Text="删  除" disabled="disabled" OnClientClick="return confirm('您确定要删除吗??')" OnClick="btnDel_Click" runat="server" />
                                <input type="button" id="btnLook" disabled="disabled" value="查看"  style="display:none;"/>
                                <%--  <input type="button" id="btnLook2"  value="查看"  onclick="rowQuery('1122');"/>--%>
                                <MyUserControl:epc_usercontrol1_wf_ascx ID="WF1" BusiCode="072" BusiClass="001" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="">
                                    <asp:GridView ID="gvPurchaseplan" AutoGenerateColumns="false" CssClass="gvdata" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPurchaseplan_PageIndexChanging" OnRowDataBound="gvPurchaseplan_RowDataBound" DataKeyNames="ppcode,ppid,project" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="20px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbBox" ToolTip='<%# Convert.ToString(Eval("ppcode")) %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" Visible="False">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="计划编号">
                                                <ItemTemplate>
                                                   <%-- <span class="al" onclick="viewopen('ViewSmPurchaseplan.aspx?ic=<%# Eval("ppid") %>',820,500)">
                                                        <%# Eval("ppcode") %>
                                                    </span>--%>
                                                    <div style="position: absolute; margin-top: 5px;">
                                                        <span class="al" onclick="showViewIng1122('<%# Eval("ppid") %>')" style="font-size: 16px; text-decoration: none;">
                                                            <%# Eval("ppcode") %>
                                                        </span>
                                                    </div>
                                                    <div style="float: right; color: #999999; font-size: 12px;">
                                                        <span style="float: right;">是否受理:&nbsp;  <%# (System.Convert.ToInt32(Eval("acceptstate")) == 0) ? "否" : "是" %></span>
                                                        </br>
                                                        <span><%# Eval("person") %>   <%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="录入人" Visible="False">
                                                <ItemTemplate>
                                                    <%# Eval("person") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                            <asp:TemplateField HeaderText="附件" Visible="False">
                                                <ItemTemplate>
                                                    <%# GetAnnx(Convert.ToString(Eval("ppid"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="说明" Visible="False">
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("explain") %>'>
                                                        <%# StringUtility.GetStr(Convert.ToString(Eval("explain"))) %>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="项目名称" Visible="false">
                                                <ItemTemplate>
                                                    <%# WebUtil.GetPrjNameByproject(Eval("project")) %>
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
        <div id="divFramPrj" title="" style="display: none">
            <iframe id="ifFramPrj" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
        <asp:HiddenField ID="hfldPurchaseChecked" runat="server" />
        <asp:HiddenField ID="hfldPrjId" runat="server" />
       
    </form>
     <script type="text/javascript">
            function showViewIng1122(id) {
                //alert(id);
                // var url = "ViewSmPurchaseplanWX.aspx?t=1&ic=" + id + "&BusiCode=072&BusiClass=001";
                var url = "ViewSmPurchaseplanWX.aspx?ic=" + id + "";
                layer.open({
                    type: 2,
                    title: '查看采购计划',
                    shadeClose: true,
                    shade: 0.8,
                    area: ['100%', '100%'],
                    content: url
                });
            }
        </script>
</body>
</html>
