<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmInDepository.aspx.cs" Inherits="StockManage_Allocation_ConfirmInDepository" %>

<%@ Import Namespace="cn.justwin.BLL" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>接收确认</title>
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
 <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>

    <%--   <script type="text/javascript" src="/Script/jquery.js"></script>--%>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var jwTable = new JustWinTable('GVAllocationList');
        });

        function chkClick(isSure, checked, ac) {
            if (isSure == "True")
                document.getElementById("btnConfirm").disabled = true;
            else {
                if (checked) {
                    document.getElementById("HdnAcodeList").value = ac;
                }
            }
        }
        function rowClick(isSure, ac) {
            if (isSure == "True")
                document.getElementById("btnConfirm").disabled = true;
            else {
                document.getElementById("btnConfirm").disabled = false;
                document.getElementById("HdnAcode").value = ac;
                document.getElementById("HdnAcodeList").value = ac;
            }
        }

    </script>
    <style type="text/css">
        .gvw {
            min-width: 700px;
        }

            .gvw tr {
                height: 30px;
            }

        .footerM {
            /*color:red;*/
        }

            .footerM td table tbody tr td span {
                font-size: 12px;
                margin: 5px;
                border: 1px solid #b5b2b2;
                padding: 3px;
                margin-left: 10px;
                background-color: #fbfbfb;
                color: red;
            }

            .footerM td table tbody tr td a {
                font-size: 12px;
                margin: 5px;
                border: 1px solid #b5b2b2;
                padding: 3px;
                margin-left: 10px;
                background-color: #fbfbfb;
            }
    </style>
    </script>
            <style type="text/css">
                .gvw {
                    min-width: 400px;
                }

                    .gvw tr {
                        height: 40px;
                    }

                .footerM {
                    /*color:red;*/
                }

                    .footerM td table tbody tr td span {
                        font-size: 12px;
                        margin: 5px;
                        border: 1px solid #b5b2b2;
                        padding: 3px;
                        margin-left: 10px;
                        background-color: #fbfbfb;
                        color: red;
                    }

                    .footerM td table tbody tr td a {
                        font-size: 12px;
                        margin: 5px;
                        border: 1px solid #b5b2b2;
                        padding: 3px;
                        margin-left: 10px;
                        background-color: #fbfbfb;
                    }
            </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%">

            <tr>
                <td class="divFooter" style="text-align: left;">
                    <asp:Button ID="btnConfirm" Style="width: 100px;" Text="确认接收" Enabled="false" OnClick="btnConfirmWX_Click" runat="server" />
                    <input type="hidden" id="HdnAcode" style="width: 1px;" runat="server" />

                    <input type="hidden" id="HdnAcodeList" style="width: 1px" runat="server" />

                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div class="pagediv">
                        <asp:GridView ID="GVAllocationList" CssClass="gvw" Width="100%" AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="GVAllocationList_RowDataBound" OnPageIndexChanging="GVAllocationList_PageIndexChanging" DataKeyNames="acode,tcodea,tcodeb" runat="server">
                            <EmptyDataTemplate>
                                <table class="tab">
                                    <tr class="header">
                                        <th style="width: 20px"></th>
                                        <%-- <th scope="col">
                                        序号
                                    </th>--%>
                                        <th scope="col">调拨单号
                                        </th>
                                        <th scope="col">调出库
                                        </th>
                                        <th scope="col">调入库
                                        </th>
                                        <%--  <th scope="col">
                                        调拨时间
                                    </th>--%>
                                        <th scope="col">是否调出
                                        </th>
                                        <th scope="col">是否接收
                                        </th>
                                        <th scope="col">流程状态
                                        </th>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectIt" runat="server" />
                                    </ItemTemplate>

                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" Visible="false" runat="server" />
                                    </HeaderTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" Visible="False">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="调拨单号" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                        <%-- <asp:HyperLink ID="HyperLink1" NavigateUrl="" Text="" runat="server"></asp:HyperLink>--%>
                                          <div style="position: absolute; margin-top: 5px;">
                                            <span class="al" onclick="rowQuery1122('<%# Eval("aid") %>')" style="font-size: 16px; text-decoration: none;">
                                                <%# Eval("acode") %>
                                            </span>
                                            <asp:HyperLink ID="HyperLink1" NavigateUrl="" Text="" runat="server" Visible="false"></asp:HyperLink>
                                        </div>
                                        <div style="float: right; color: #999999; font-size: 12px;">
                                            <span style="float: right;"></span>
                                            </br> </br>
                                                        <span><%# Common2.GetTime(Eval("intime").ToString()) %></span>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="调出库" ItemStyle-Width="50px"/>
                                <asp:BoundField HeaderText="调入库" ItemStyle-Width="50px"/>
                                <asp:BoundField DataField="intime" HeaderText="调拨时间" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd}" Visible="false"/>
                                <asp:BoundField HeaderText="是否调出" ItemStyle-Width="40px"/>
                                <asp:BoundField HeaderText="是否接收" ItemStyle-Width="40px"/>
                                <asp:TemplateField HeaderText="流程状态" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <%# Common2.GetState(Eval("flowstate").ToString()) %>
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
    </form>
     <script type="text/javascript">
        function rowQuery1122(id) {
            var url = 'AuditPageWX.aspx?ic=' + id + '&BusiClass=001&BusiCode=075';
            //viewopen(url, 820, 500);
            layer.open({
                type: 2,
                title: '查看调拨单',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],//['380px', '90%'],
                content: url//'mobile/' //iframe的url
            });
        }
    </script>
</body>
</html>
