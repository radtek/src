<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PickMaterialsOfDepository.aspx.cs" Inherits="StockManage_Allocation_PickMaterialsOfDepository" %>
<%@ Import Namespace="cn.justwin.BLL"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>资源选择</title><link href="../../Script/jquery.tooltip/jquery.tooltip.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../script/Config2.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var jwTable = new JustWinTable('GVMaterialList');
            showTooltip('tooltip', 10);
            jwTable.registClickTrListener(trClickEvent);
            $('#GVMaterialList a').click(function () {
                $("#hdtp").val("1");
            });
            $('#GVMaterialList input').click(function () {
                $("#hdtp").val("0");
            });
        });

        // 保存事件
        function saveEvent() {
            var tsid = eval($("#hdTsid").val());
            var codelist = "";
            for (var i = 0; i < tsid.length; i++) {
                var val = tsid[i].split('|');
                codelist += "(scode='" + val[0] + "' and sprice='" + val[1] + "' and corp='" + val[2] + "') or ";
            }
            codelist += "(scode='-1' and sprice='-1' and corp='-1')";

            //if (typeof top.ui.callback == 'function') {
            //    top.ui.callback({ code: codelist });
            //    top.ui.callback == null;
            //}
            $('#HdnViewCodeList').val(codelist.code);
            //top.ui.closeWin();
            parent.$('#btnBind').click();
            page_close();
        }

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
        //function saveEvent() {
        //    parent.$('#hfldResourceCode').val($('#hfldOldCodes').val());
        //    parent.$('#btnBindResource').click();
        //    page_close();
        //}
        //注意：parent 是 JS 自带的全局对象，可用于操作父页面
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        // 关闭
        function page_close() {
            parent.layer.close(index);
        }
    </script>
         <style type="text/css">
        .gvw{
            min-width: 700px;
        }
        .gvw tr{
            height: 30px;
        }
        .footerM {
            /*color:red;*/
        }
         .footerM td table tbody tr td span{
            font-size: 12px;
    margin: 5px;
    border: 1px solid #b5b2b2;
    padding: 3px;
    margin-left: 10px;
    background-color: #fbfbfb;
    color:red;
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
    <table class="tab" cellspacing="0">
        <tr style="display: none;">
            <th class="headerrow">
                资源选择
            </th>
        </tr>
        <tr style="height: 30px;">
            <td>
                物资编号<asp:TextBox ID="txtResCode" Width="120px" runat="server"></asp:TextBox>
                    </td>
        </tr>  <tr style="height: 30px;">
            <td>
                物资名称<asp:TextBox ID="txtResName" Width="120px" runat="server"></asp:TextBox>
            </td>
        </tr>  <tr style="height: 30px;">
            <td>
                供应商<asp:TextBox ID="txtSupply" Width="120px" runat="server"></asp:TextBox>
                <asp:Button ID="btnSertch" Text="查询" OnClick="btnSertch_Click" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height: 350px;">
                <div class="pagediv" style="height: 350px; width: 100%;">
                    <asp:GridView ID="GVMaterialList" Width="100%" CssClass="gvw"   AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="GVMaterialList_RowDataBound" OnPageIndexChanging="GVMaterialList_PageIndexChanging" runat="server"><Columns><asp:TemplateField HeaderStyle-Width="20px"><HeaderTemplate>
                                    <asp:CheckBox ID="chkHdSelectIt" AutoPostBack="true" OnCheckedChanged="chkSelectIt_CheckedChanged" runat="server" />
                                </HeaderTemplate><ItemTemplate>
                                    <asp:CheckBox ID="chkSelectIt" AutoPostBack="true" OnCheckedChanged="chkSelectIt_CheckedChanged" runat="server" />
                                    <asp:HiddenField ID="hdScode" Value='<%# Convert.ToString(Eval("ResourceCode")) %>' runat="server" />
                                    <asp:HiddenField ID="hdSprice" Value='<%# Convert.ToString(Eval("sprice")) %>' runat="server" />
                                    <asp:HiddenField ID="hdCorp" Value='<%# Convert.ToString(Eval("corpID")) %>' runat="server" />
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="序号">
<ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server"></asp:Label>
                                </ItemTemplate>
</asp:TemplateField><asp:TemplateField HeaderText="物资编号"><ItemTemplate>
                                    <asp:Label ID="Label1" Text='<%# Convert.ToString(Eval("ResourceCode")) %>' runat="server"></asp:Label>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="物资名称"><ItemTemplate>
                                    <span class="tooltip" title='<%# Eval("ResourceName").ToString() %>'>
                                        <%# StringUtility.GetStr(Eval("ResourceName").ToString(), 10) %>
                                    </span>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="规格"><ItemTemplate>
                                    <span class="tooltip" title='<%# Eval("Specification").ToString() %>'>
                                        <%# StringUtility.GetStr(Eval("Specification").ToString(), 10) %>
                                    </span>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="型号"><ItemTemplate>
                                    <span class="tooltip" title='<%# Eval("ModelNumber").ToString() %>'>
                                        <%# StringUtility.GetStr(Eval("ModelNumber").ToString(), 10) %>
                                    </span>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="品牌"><ItemTemplate>
                                    <span class="tooltip" title='<%# Eval("brand").ToString() %>'>
                                        <%# StringUtility.GetStr(Eval("brand").ToString(), 10) %>
                                    </span>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="技术参数"><ItemTemplate>
                                    <span class="tooltip" title='<%# Eval("TechnicalParameter").ToString() %>'>
                                        <%# StringUtility.GetStr(Eval("TechnicalParameter").ToString(), 10) %>
                                    </span>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="单位"><ItemTemplate>
                                    <asp:Label ID="lblUnit" runat="server"></asp:Label>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="采购价" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
                                    <asp:Label ID="txtUnitPrice" Width="80px" Text='<%# Convert.ToString(Eval("sprice")) %>' runat="server"></asp:Label>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="库存数量" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
                                    <asp:Label ID="Label4" Text='<%# Convert.ToString(Eval("snumber")) %>' runat="server"></asp:Label>
                                </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="供应商"><ItemTemplate>
                                    <span class="tooltip" title='<%# Eval("CorpName").ToString() %>'>
                                        <%# StringUtility.GetStr(Eval("CorpName").ToString(), 10) %>
                                    </span>
                                    <input type="hidden" id="HdnCorpID" value='<%# Convert.ToString(Eval("corpID")) %>' runat="server" />

                                </ItemTemplate></asp:TemplateField></Columns><RowStyle CssClass="rowa"></RowStyle><AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle><HeaderStyle CssClass="header"></HeaderStyle><FooterStyle CssClass="footer"></FooterStyle></asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td class="bottonrow2" style="height: 30px" align="left">
                <input id="btnSave" type="button" value="保 存" style="cursor: pointer;" onclick="saveEvent();" runat="server" />

                <input id="btnCancel" type="button" value="取 消" style="cursor: pointer;" onclick=" page_close();" />
            </td>
        </tr>
    </table>
    <input id="HdnIsPage" type="hidden" value="" style="width: 1px;" runat="server" />

    <asp:HiddenField ID="hdTsid" runat="server" />
    <asp:HiddenField ID="hdtp" Value="0" runat="server" />
    <input id="Hdnacode" type="hidden" style="width: 1px" runat="server" />

    <input id="HdnOperator" type="hidden" style="width: 1px" runat="server" />

    </form>
</body>
</html>
