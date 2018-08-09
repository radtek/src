<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PTAuditList.aspx.cs" Inherits="SysFrame_PTAuditList" %>


<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>待办工作</title>
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
    <%--  <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>--%>
    <%-- <script type="text/javascript" src="../../StockManage/script/JustWinTable.js"></script>--%>
    <%--<script type="text/javascript" src="../../SysFrame/jscript/JsControlMenuTool.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ifshow').hide();
            //alert($("#TextBox1").val());
            if ($("#TextBox1").val() != "") {
                $("#btn2").click();
            }
        });

        //function setHeight() {
        //    var height = document.getElementById("td-auditlist").clientHeight;
        //    document.getElementById("dvDeptBox").style.height = height;
        //}
        //addEvent(window, 'load', function () {
        //    var jwTable = new JustWinTable('gvAuditingList');
        //    replaceEmptyTable('emptyTable', 'gvAuditingList');
        //    setHeight();
        //});
        function view(url, title) {
            $("#TextBox1").val(url);
        }
        function viewOpen() {
            var url = $("#TextBox1").val();
            layer.open({
                type: 2,
                title: '审核内容查看',
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" style="width: 100%; height: 99%">
            <asp:TextBox ID="TextBox1" runat="server" Style="display: none;"></asp:TextBox>
            <tr class="ifshow">
                <td style="height: 27px;">
                    <table cellpadding="0" cellspacing="0" width="90%" border="0">
                        <tr>
                            <td>
                                <table class="queryTable" cellpadding="3px" cellspacing="0px">
                                    <tr>
                                        <td class="descTd">待审事项
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtclassname" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="descTd">发起人
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtorganizer" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td class="descTd">流程状态
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                                                <asp:ListItem Value="1" Text="待审核" />
                                                <asp:ListItem Value="2" Text="已审核" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr><td class="descTd">
                                        </td>
                                        <td >
                                            <asp:Button ID="SearchBt" Text="查询" OnClick="SearchBt_Click" runat="server" />
                                            <input type="button" id="btnUnSelect" value="取消查询" style="width: auto" onclick="ifshow();" />
                                        </td>
                                    </tr>
                    </table>
                </td>
            </tr>
            </table>
                </td>
            </tr>
             <input type="button" id="btnSelect" value="高级查询" style="width: auto" onclick="ifshow();" />
            <input type="button" id="btn2" value="test2" style="width: auto; display: none;" onclick="viewOpen()" />
            <tr>
                <td style="vertical-align: top" id="td-auditlist">
                    <div id="dvDeptBox" style="width: 100%; height: 200px">
                        <!--代办-->
                        <asp:GridView ID="gvAuditingList" AutoGenerateColumns="false" Width="100%" AllowPaging="true" PageSize="20" OnRowDataBound="gvAuditingList_RowDataBoundWX" OnPageIndexChanging="gvAuditingList_PageIndexChanging" DataKeyNames="NoteID" runat="server">
                            <EmptyDataTemplate>
                                <table id="emptyTable" style="width: 100%">
                                    <tr class="header">
                                        <td>序号
                                        </td>
                                        <td>待审事项
                                        </td>
                                        <td>提交时间
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <RowStyle CssClass="rowb"></RowStyle>
                            <HeaderStyle CssClass="header" Font-Bold="false"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="序号" Visible="false">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField HeaderText="待审事项" DataTextField="BusinessClassName" />
                                <asp:BoundField HeaderText="发起人" />
                                <asp:BoundField HeaderText="参与审核人" />
                                <asp:BoundField DataField="ArriveTime" HeaderText="提交时间" />
                            </Columns>
                            <PagerStyle HorizontalAlign="Left"></PagerStyle>
                        </asp:GridView>

                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
