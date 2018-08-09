<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSmPurchaseplan.aspx.cs" Inherits="StockManage_SmPurchaseplan_AddSmPurchaseplan" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Register TagPrefix="MyUserControl" TagName="epc_usercontrol1_filelink2_ascx" Src="~/EPC/UserControl1/FileLink2.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购计划单</title>
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
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/Script/jquery.tooltip/jquery.tooltip.js"></script>
    <script type="text/javascript" src="../script/JustWinTable.js"></script>
    <script type="text/javascript" src="../script/ValidateInput.js"></script>
    <script type="text/javascript" src="../../Script/DecimalInput.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            replaceEmptyTable('emptyContractType', 'gvNeedNote');
            var ab = new JustWinTable('gvNeedNote');

            showTooltip('tooltip', 10);
            $('#btnShowList').hide();
        });

        // 选择项目
        function openProjPicker() {
            jw.selectOneProject({ idinput: 'hdnProjectCode', nameinput: 'txtProjectName' });
        }

        function openPerson() {
            var url = "/CommonWindow/PickSinglePerson.aspx?sm";
            window.open(url, '', "height=450, width= 600, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no,center:yes")
        }
        // 表单验证
        function valForm() {
            if (document.getElementById('gvNeedNote').rows.length <= 1) {
                alert("系统提示:\n\n请选择采购物资");
                return false;
            }
            if (document.getElementById("hdnProjectCode").value == "") {
                alert("系统提示:\n\n请选择项目");
                return false;
            }
            var inputs = document.getElementById('gvNeedNote').getElementsByTagName('INPUT');
            return true;
        }

        // 显示物资需求计划
        function displaySelectFromPurchase() {
            getPurchaseNums();//
            //var url = '/StockManage/ProjectFrameWX.aspx?path=selectWantPlanWX'
            var url = '/StockManage/SmPurchaseplan/SelectByNoteListWX.aspx?PrjGuid=' + $("#hdnProjectCode").val();
            layer.open({
                type: 2,
                title: '从需求计划单中选择',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
            //top.ui.callback = function (obj) {
            //    $('#hdwzId').val(obj.id);
            //    $('#hdlfWantplanCodes').val(obj.code);
            //    $('#btnShowGv').click();
            //}
            //top.ui.openWin({ title: '从需求计划中选择', url: url, width: 920, height: 500 });
        }

        // 从材料库中选择资源
        function selectResourceWX() {
            //alert(1);
            getPurchaseNums();
            var typeCode = '0002,0003';
            var url = '/StockManage/UserControl/SelectResourceWX.aspx?type=2&TypeCode=' + typeCode;
            layer.open({
                type: 2,
                title: '选择资源',
                shadeClose: true,
                shade: 0.8,
                area: ['100%', '100%'],
                content: url
            });
            //top.ui.callback = function (obj) {
            //    $('#hfldResourceCode').val(obj.code);
            //    $('#btnShowList').click();
            //}
            //top.ui.openWin({ title: '选择资源', url: url, width: 1010, height: 500 });
        }

        function getPurchaseNums() {
            var arr = new Array();
            $('#gvNeedNote tr[id]').each(function () {
                var obj = {};
                obj.scode = $(this).find('span[id$=lbscode]').text();
                obj.num = $(this).find('input[id$=txtNum]').val();
                obj.date = $(this).find('input[id$=txtarrivalDate]').val();
                obj.note = $(this).find('input[id$=txtRemark]').val();
                arr.push(obj);
            });
            var json = JSON.stringify(arr);
            $('#hdfdInputValues').val(json);
        }
    </script>
    <style type="text/css">
        #FileLink1_But_UpFile {
            width: auto;
        }

        #FileLink1_Btn_Upload {
            width: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divHeader2">
            <table class="tableHeader">
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" Font-Bold="true" Text="" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="divContent2">
            <table class="tableContent2" cellpadding="5px" cellspacing="0">
                <tr style="display:none;">
                    <td class="word" style="white-space: nowrap;">附件
                    </td>
                    <td colspan="3" style="width: 100%;">
                        <MyUserControl:epc_usercontrol1_filelink2_ascx ID="FileLink1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="word" style="white-space: nowrap;">单据号
                    </td>
                    <td class="txt readonly">
                        <asp:TextBox ID="txtPPCode" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td class="word" style="white-space: nowrap;">项目
                    </td>
                    <td class="txt mustInput">
                        <input type="text" readonly="readonly" id="txtProjectName" class="select_input" imgclick="openProjPicker" runat="server" />

                        <input id="hdnProjectCode" type="hidden" name="hdnProjectCode" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td align="right" style="white-space: nowrap;">说明
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtExplain" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="word" style="white-space: nowrap;">录入人
                    </td>
                    <td class="txt readonly">
                        <input type="text" readonly="readonly" class="txtreadonly" id="txtPeople" runat="server" />

                    </td>
                    <td class="word" style="white-space: nowrap;">录入时间
                    </td>
                    <td class="txt readonly">
                        <asp:TextBox ID="txtInTime" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px">
                        <hr class="sp" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="headerDiv" style="text-align: left;">
                            <input type="button" id="btnSelectByd" value="从需求计划单中选择" onclick="displaySelectFromPurchase();" style="width: 120px;" runat="server" />

                            <input type="button" value="从材料库中选择" id="btnSelectResource" onclick="selectResourceWX();"
                                style="width: 90px;" />
                            <asp:Button ID="btnDel" Style="width: 60px;" Text="删除材料" OnClick="btnDel_Click" runat="server" />
                            <asp:Button ID="btnShowGv" Text="显示需求计划" Style="display: none;" OnClick="btnShowGv_Click" runat="server" />
                            <asp:Button ID="btnShowList" Text="显示" OnClick="btnShowList_Click" runat="server" stye="display:none;"/>
                        </div>
                    </td>
                </tr>
            </table>
            <div>
                <table class="tableContent2" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td>
                            <asp:GridView ID="gvNeedNote" Width="100%" AutoGenerateColumns="false" CssClass="gvdata" OnRowDataBound="gvNeedNote_RowDataBound" DataKeyNames="scode" runat="server">
                                <EmptyDataTemplate>
                                    <table id="emptyContractType" class="gvdata">
                                        <tr class="header">
                                            <th scope="col" style="width: 20px;">
                                                <input id="chk1" type="checkbox" />
                                            </th>
                                            <th scope="col" style="width: 25px;">序号
                                            </th>
                                            <th scope="col">物资编号
                                            </th>
                                            <th scope="col">物资名称
                                            </th>
                                            <th scope="col">规格
                                            </th>
                                            <th scope="col">型号
                                            </th>
                                            <th scope="col">品牌
                                            </th>
                                            <th scope="col">技术参数
                                            </th>
                                            <th scope="col">单位
                                            </th>
                                            <th scope="col">库存量
                                            </th>
                                            <th scope="col">采购数量
                                            </th>
                                              <th scope="col">需求到货日期
                                            </th>
                                            <th scope="col">实际到货日期
                                            </th>

                                             <th scope="col">预算数量
                                            </th>
                                            <th scope="col">预算价格
                                            </th>
                                            <th scope="col">预算小计
                                            </th>

                                            <th scope="col">备注
                                            </th>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="20px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkBox" ToolTip='<%# Convert.ToString(Eval("scode")) %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="物资编号">
                                        <ItemTemplate>
                                            <asp:Label ID="lbscode" Text='<%# Convert.ToString(Eval("scode")) %>' runat="server"></asp:Label>
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
                                            <span class="tooltip" title='<%# Eval("Specification").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("Specification").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="型号">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("ModelNumber").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("ModelNumber").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="品牌">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("brand").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("brand").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="技术参数">
                                        <ItemTemplate>
                                            <span class="tooltip" title='<%# Eval("TechnicalParameter").ToString() %>'>
                                                <%# StringUtility.GetStr(Eval("TechnicalParameter").ToString(), 10) %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="单位" HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%# Eval("Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="库存量" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="decimal_input">
                                        <ItemTemplate>
                                            <%# WebUtil.GetStockNumberByCode(Eval("scode").ToString()).ToString() %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="采购数量" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox Style="text-align: right;" Width="70px" ID="txtNum" CssClass="decimal_input" ToolTip='<%# Convert.ToString(Eval("scode")) %>' Text='<%# Convert.ToString(Eval("number")) %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="需求到货日期" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtarrivalDateNeed" onclick="WdatePicker()" Width="70px" Height="15px" Text='<%# Convert.ToString((Eval("arrivalDateNeed").ToString() == "") ? "" : Eval("arrivalDateNeed").ToString().Substring(0, Eval("arrivalDateNeed").ToString().LastIndexOf(" ") + 1)) %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="实际到货日期" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtarrivalDate" onclick="WdatePicker()" Width="70px" Height="15px" Text='<%# Convert.ToString((Eval("arrivalDate").ToString() == "") ? "" : Eval("arrivalDate").ToString().Substring(0, Eval("arrivalDate").ToString().LastIndexOf(" ") + 1)) %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="预算数量" ItemStyle-CssClass="decimal_input">
                                        <ItemTemplate>
                                            <%# System.Convert.ToDecimal(Eval("BugetNum")).ToString("0.000") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="预算价格" ItemStyle-CssClass="decimal_input">
                                        <ItemTemplate>
                                            <%# System.Convert.ToDecimal(Eval("BugetPrice")).ToString("0.000") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="预算小计" ItemStyle-CssClass="decimal_input">
                                        <ItemTemplate>
                                            <%# Eval("BugetSum") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemark" Text='<%# Convert.ToString(Eval("Remark")) %>' ToolTip='<%# Convert.ToString(Eval("scode")) %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="rowa"></RowStyle>
                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                <HeaderStyle CssClass="header"></HeaderStyle>
                                <FooterStyle CssClass="footer"></FooterStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="divFooter2">
            <table class="tableFooter2">
                <tr>
                    <td>
                        <asp:Button ID="btnSave" Text="保存" OnClientClick="return valForm()" OnClick="btnSaveWX_Click" runat="server" />
                        <input type="button" id="btnCancel" value="取消" onclick="winclose('AddSmPurchaseplan', 'IncometContractList.aspx', false)" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divSelectFromPurchase" title="从需求计划单中选择" style="display: none">
            <iframe id="ifResoueceFromPurchase" frameborder="0" width="100%" height="100%" src="SelectByNote.aspx"></iframe>
        </div>
        <div id="divFram" title="" style="display: none">
            <iframe id="ifFram" frameborder="0" width="100%" height="100%" src=""></iframe>
        </div>
        <asp:HiddenField ID="hdwzId" runat="server" />
        <asp:HiddenField ID="hdGuid" runat="server" />
        <asp:HiddenField ID="hdnCodeList" runat="server" />

        <asp:HiddenField ID="hdlfWantplanCodes" runat="server" />
        <asp:HiddenField ID="hdRsID" runat="server" />

        <asp:HiddenField ID="hdflowstate" Value="-1" runat="server" />
        <asp:HiddenField ID="hfldResourceCode" runat="server" />
        <asp:HiddenField ID="hdfdInputValues" runat="server" />
    </form>
</body>
</html>
