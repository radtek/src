<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuffList.aspx.cs" Inherits="StockManage_SmOutReserve_StuffList" %>

<%@ Import Namespace="cn.justwin.BLL" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>从仓库选择物资</title>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <script type="text/javascript" src="/Script/jquery-3.2.1.min.js"></script>
   <script type="text/javascript" src="/Script/layer_v3.1.1/layer/layer.js"></script>
    <link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
<%--    <script type="text/javascript" src="/Script/jquery.js"></script>--%>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var jwTable = new JustWinTable('gvNeedNote');
            jwTable.registClickTrListener(trClickEvent);
            $('#gvNeedNote a').click(function () {
                $("#hdtp").val("1");
            });
            $('#gvNeedNote input').click(function () {
                $("#hdtp").val("0");
            });

            showTooltip('tooltip', 10);
        });

        function trClickEvent() {
            var chk;
            var inputs = this.getElementsByTagName('INPUT');
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].getAttribute('type') == 'checkbox') {
                    chk = inputs[i];
                }
            }
            if (chk) {
                chk.click();
            }
        }

        // 保存
        function saveEvent() {
            //if (typeof top.ui.callback == 'function') {
            //    top.ui.callback({ id: $('#hdTsid').val() });
            //}
            parent.$('#hdTsid').val($('#hdTsid').val());
            parent.$('#btnShowGv').click();
            page_close();
        }
        //注意：parent 是 JS 自带的全局对象，可用于操作父页面
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        // 关闭
        function page_close() {
            parent.layer.close(index);
        }
        // 选择供应商
        function pickCorp() {
            jw.selectOneCorp({ idinput: 'hfldCorp', nameinput: 'txtCorp', winNo: 2 });
        }

        //                str.Append("$(parent.document).find('.ui-icon-closethick')[0].click();");
        //        str.Append("parent.document.getElementById('hdTsid').value=document.getElementById('hdTsid').value;");
        //        str.Append("parent.document.getElementById('btnShowGv').click();");    
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
</head>
<body>
    <form id="form1" runat="server">
        <table class="tab" border="0" cellpadding="0" style="width: 100%;" cellspacing="0">
            <tr style="display: none;">
                <td class="divHeader">仓库物资
                </td>
            </tr>
            <tr>
                <td style="height: 30px;">
                    <table class="queryTable" cellpadding="3px" cellspacing="0px">
                        <tr>
                            <td class="descTd">物资编号
                            </td>
                            <td>
                                <asp:TextBox ID="txtScode" Width="120px" runat="server"></asp:TextBox>
                            </td>
                            </tr><tr>
                            <td class="descTd">&nbsp; 物资名称
                            </td>
                            <td>
                                <asp:TextBox ID="txtResourceName" Width="120px" runat="server"></asp:TextBox>
                            </td> </tr><tr>
                            <td class="descTd">&nbsp; 供应商
                            </td>
                            <td><asp:TextBox ID="txtCorp" Width="120px" runat="server"></asp:TextBox>
                                <%--<span id="spanPrj" class="spanSelect" style="width: 122px;">
                                    <asp:TextBox ID="txtCorp" CssClass="txtreadonly" Style="border: none; line-height: 16px; margin: 1px  0px 1px 2px; width: 90px;"
                                        ToolTip="请选择" runat="server"></asp:TextBox>
                                    <img src="../../images/icon.bmp" style="float: right" alt="选择供应商" id="imgPrj" onclick="pickCorp();" />
                                </span>--%>
                                <asp:HiddenField ID="hfldCorp" Value="" runat="server" />
                            </td></tr><tr>
                            <td>&nbsp;
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Search" Text="查询" Style="cursor: pointer;" OnClick="btn_Search_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="width: 100%; height: 88%; vertical-align: top;">
                <td>
                    <div class="pagediv" style="height: 350px; width: 100%;">
                        <asp:GridView ID="gvNeedNote" CssClass="gvw" Width="100%" AllowPaging="true" AutoGenerateColumns="false"  OnPageIndexChanging="gvNeed_PageIndexChanging" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="20px">
                                    <HeaderTemplate>
                                        <asp:CheckBox AutoPostBack="true" ID="cbAllBox" OnCheckedChanged="chkBox_CheckedChanged" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbBox" AutoPostBack="true" OnCheckedChanged="chkBox_CheckedChanged" runat="server" />
                                        <asp:HiddenField ID="hdScode" Value='<%# Convert.ToString(Eval("scode")) %>' runat="server" />
                                        <asp:HiddenField ID="hdSprice" Value='<%# Convert.ToString(Eval("sprice")) %>' runat="server" />
                                        <asp:HiddenField ID="hdCorp" Value='<%# Convert.ToString(Eval("corp")) %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="物资编号">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" Text='<%# Convert.ToString(Eval("scode")) %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="物资名称">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("ResourceName").ToString() %>'>
                                            <%# StringUtility.GetStr(Eval("ResourceName").ToString(), 10) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="规格">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("Specification") %>'>
                                            <%# StringUtility.GetStr(Eval("Specification"), 10) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="型号">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("ModelNumber") %>'>
                                            <%# StringUtility.GetStr(Eval("ModelNumber"), 10) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="品牌">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("brand") %>'>
                                            <%# StringUtility.GetStr(Eval("brand").ToString(), 10) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="技术参数">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("TechnicalParameter") %>'>
                                            <%# StringUtility.GetStr(Eval("TechnicalParameter"), 10) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单位" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%# Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="库存数量" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <%# Eval("snumber") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单价">
                                    <ItemTemplate>
                                        <%# Eval("sprice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="供应商">
                                    <ItemTemplate>
                                        <span class="tooltip" title='<%# Eval("CorpName").ToString() %>'>
                                            <%# StringUtility.GetStr(Eval("CorpName").ToString(), 10) %>
                                        </span>
                                        <input type="hidden" id="HdnCorpID" value='<%# Convert.ToString(Eval("corp")) %>' runat="server" />

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
            <tr>
                <td style="height: 20px; text-align: left;" class="bottonrow1">

                    <input type="button" id="btnSave" value="保存" onclick="saveEvent();" style="cursor: pointer;" />
                    <input type="button" id="btnCancel" value="取消" style="cursor: pointer;" onclick="page_close();" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdTsid" runat="server" />
        <asp:HiddenField ID="hdtp" Value="0" runat="server" />
    </form>
</body>
</html>
