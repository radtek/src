<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QOutReserve.aspx.cs" Inherits="StockManage_SmOutReserve_QOutReserve" %>

<%@ Import Namespace="cn.justwin.BLL" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>确认出库</title>
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
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../Script/jwJson.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
/**
 * 禁止浏览器下拉回弹
 */
function stopDrop() {
    var lastY;//最后一次y坐标点
    $(document.body).on('touchstart', function(event) {
        lastY = event.originalEvent.changedTouches[0].clientY;//点击屏幕时记录最后一次Y度坐标。
    });
    $(document.body).on('touchmove', function(event) {
        var y = event.originalEvent.changedTouches[0].clientY;
        var st = $(this).scrollTop(); //滚动条高度  
        if (y >= lastY && st <= 10) {//如果滚动条高度小于0，可以理解为到顶了，且是下拉情况下，阻止touchmove事件。
            lastY = y;
            event.preventDefault();
        }
        lastY = y;
 
    });
}
</script>
    <script type="text/javascript">
        $(document).ready(function () {
            stopDrop();// 禁止浏览器下拉回弹
            parent.$('.layout-panel-center').css({ "left": "0px", "width": "100%" });
            parent.$('.panel-body-noheader').css({ "width": "100%" });
            $('.ifshow').hide();
            var jwTable = new JustWinTable('gvOutReserve');
            jwTable.registClickSingleCHKListener(function () {
                if (jwTable.getCheckedChk().length != 1) {
                    document.getElementById("btnOk").disabled = true;
                }
                else {
                    document.getElementById("btnOk").disabled = false;
                }
            });
            jwTable.registClickAllCHKLitener(function () {
                if (jwTable.getCheckedChk().length == 0) {
                    document.getElementById("btnOk").disabled = false;
                } else {
                    document.getElementById("btnOk").disabled = true;
                }
            });
            jwTable.registClickTrListener(function () {
                document.getElementById("btnOk").disabled = false;
            });
            showTooltip('tooltip', 15);
        });

        function rowQuery(id) {
            var url = 'ViewReserveWX.aspx?ic=' + id;
            layer.open({
                type: 2,
                title: '查看出库单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
        }
        // 选择人员
        function selectUser() {
            jw.selectOneUser({ codeinput: 'hdnPeople', nameinput: 'txtPeople' });
        }

        function selectTrea() {
            jw.selectTreasury({ codeinput: 'hfldTrea', nameinput: 'txtTrea' });
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
        function writeName(ss, type) {
            //if (type == "签名出库") {
            //    //prjGuid
            //    var url = "/WeChat/writeName/writeName.aspx?orid=" + ss + "&type=before";
            //    ////$("#KeyId").val(ss);
            //    //layer.open({
            //    //    type: 2,
            //    //    title: '签名出库',
            //    //    shadeClose: true,
            //    //    shade: 0.8,
            //    //    area: ['100%', '100%'],//['380px', '90%'],
            //    //    content: url//'mobile/' //iframe的url
            //    //});
            //    window.location.href = url;
            //}
            if (type == "签名") {
                //prjGuid
                //var url = "/WeChat/writeName/writeName.aspx?orid=" + ss + "&type=after";
                //alert(document.getElementById("prjGuid").innerHTML);
                var url = "/WeChat/writeName/writeName.aspx?orid=" + ss + "&prjGuid=" + document.getElementById("prjGuid").innerHTML + "&txtPPcode=" + $("#txtPPcode").val() + "&txtStartTime=" + $("#txtStartTime").val() + "&txtEndTime=" + $("#txtEndTime").val() + "&txtPeople=" + $("#txtPeople").val() + "&txtTrea=" + $("#txtTrea").val() + "&status=" + $("#status").val();
                //$("#KeyId").val(ss);       
                //layer.open({
                //    type: 2,
                //   title: '补充签名',
                //   shadeClose: true,
                //   shade: 0.8,
                //  area: ['100%', '100%'],//['380px', '90%'],
                //  content: url//'mobile/' //iframe的url
                // });
                window.location.href = url;
            }
        }
        function showName(ss) {
            var url = "/WeChat/writeName/showName.aspx?orid=" + ss;// + "&img=" + img;
            //$("#KeyId").val(ss);
            layer.open({
                type: 2,
                title: '查看签名',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }
    </script>

</head>
<body>
   <form id="form1"  runat="server" style="word-break: normal; font-family: -apple-system-font, 'Helvetica Neue', 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', sans-serif; background-size: cover; word-wrap: break-word; word-break: break-all; background: #f5f5f5 no-repeat center;">
        <input id="dataUrl" type="hidden" runat="server" />   
        <input type="hidden" id="KeyId" runat="server" />
       <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr style="height: 20px;">
                <td class="divHeader">
                    <asp:Label ID="lblProject" runat="server"></asp:Label>
                     <asp:Label ID="prjGuid" runat="server" style="display:none;"></asp:Label>
                </td>
            </tr>
            <tr class="ifshow">
                <td style="vertical-align: top;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr style="height: 25px;">
                            <td class="descTd">出库单号
                            </td>
                            <td>
                                <asp:TextBox ID="txtPPcode" Height="15px" Width="120px" runat="server"></asp:TextBox>
                            </td></tr>
                        <tr>
                            <td class="descTd">起始日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td></tr>
                        <tr>
                            <td class="descTd">结束日期
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndTime" Width="120px" onclick="WdatePicker()" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 25px;">
                            <td class="descTd">录 入 &nbsp;人
                            </td>
                            <td>
                                 <input type="text" style="width: 120px;" id="txtPeople"   runat="server" />
                                <%--<input type="text" style="width: 120px;" id="txtPeople" class="select_input" imgclick="selectUser" runat="server" />--%>

                                <asp:HiddenField ID="hdnPeople" runat="server" />
                            </td></tr>
                        <tr>
                            <td class="descTd">仓库名称
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrea"  Width="120px" runat="server"></asp:TextBox>
                               <%-- <asp:TextBox ID="txtTrea" CssClass="select_input" Width="120px" imgclick="selectTrea" runat="server"></asp:TextBox>--%>
                                <asp:HiddenField ID="hfldTrea" runat="server" />
                            </td></tr>
                        <tr>
                             <td>单据状态</td>
                            <td>
                                <asp:DropDownList ID="status" runat="server" CssClass="ddcss" Width="120px">
                                    <asp:ListItem Value="wqr">未确认</asp:ListItem>
                                    <asp:ListItem Value="wqm">未签名</asp:ListItem>
                                    <asp:ListItem Value="all">全部</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
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
                                 <asp:Button ID="btnOkAfter" Text="补充签名" Width="80px"  OnClick="btnOkAfterWX_Click" runat="server"  style="display:none;"/>
                                <asp:Button ID="btnOk" Text="确认出库" Width="80px" Enabled="false" OnClick="btnOkWX_Click" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 100%; vertical-align: top;">
                                <div class="">
                                    <asp:GridView ID="gvOutReserve" AutoGenerateColumns="false"  CssClass="gvdata"  AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPurchaseplan_PageIndexChanging" OnRowDataBound="gvOutReserve_RowDataBound" DataKeyNames="orcode" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="20px" >
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbBox" ToolTip='<%# Convert.ToString(Eval("orcode")) %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px" Visible="False">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="出库编号">
                                                <ItemTemplate>
                                                   <%-- <span class="al" onclick="viewopen('ViewReserve.aspx?ic=<%# Eval("orid") %>&BusiCode=076&BusiClass=001',820,500);">
                                                        <%# Eval("orcode") %>
                                                    </span>--%>
                                                      <div style="position: absolute; margin-top: 1px;">
                                                        <span class="al" onclick="rowQuery('<%# Eval("orid") %>')" style="font-size: 16px; text-decoration: none;">
                                                            <%# Eval("orcode") %>
                                                        </span>
                                                    </div>
                                                    <div style="float: right; color: #999999; font-size: 12px;">
                                                        <span style="float: right;"><%# Eval("tname") %></span>
                                                        </br>
                                                        <span><%# Eval("person") %>    <%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="录入人" Visible="False">
                                                <ItemTemplate>
                                                    <%# Eval("person") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="仓库名称" Visible="False">
                                                <ItemTemplate>
                                                    <%# Eval("tname") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="录入时间" Visible="False">
                                                <ItemTemplate>
                                                    <%# Common2.GetTime(Eval("intime").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="流程状态">
                                                <ItemTemplate>
                                                    <%# Common2.GetState(Eval("flowstate").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="手写签名">
                                                <ItemTemplate>
                                                   <%--  <span class="al tooltip" onclick="writeName('<%# Eval("orid") %>','签名出库')" style="display: <%# (Eval("isout").ToString() == "False") ? "": "none" %>">签名并出库
                                                    </span>&nbsp;--%>
                                                    <span class="al tooltip" onclick="writeName('<%# Eval("orid") %>','签名')" style="display: <%# (Eval("writeName").ToString() == "") ? "": "none" %>">签名
                                                    </span>&nbsp;
                                                    <span class="al tooltip" onclick="showName('<%# Eval("orid") %>')" style="display: <%# (Eval("writeName").ToString() != "") ? "": "none" %>">查看签名
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="附件" Visible="False">
                                                <ItemTemplate>
                                                    <%# GetAnnx(Convert.ToString(Eval("orid"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="说明" Visible="False">
                                                <ItemTemplate>
                                                    <span class="tooltip" title='<%# Eval("explain") %>'>
                                                        <%# StringUtility.GetStr(Eval("explain").ToString()) %>
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
                </td>
            </tr>
        </table>
        <div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
        <div id="divFramPrj" title="" style="display: none">
            <iframe id="ifFramPrj" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
    </form>
</body>
</html>
