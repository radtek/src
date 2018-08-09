<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceRelationDetail.aspx.cs" Inherits="ResourceRelationDetail" %>

<%@ Import Namespace="cn.justwin.BLL" %>
<%@ Import Namespace="Wuqi.Webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>组装材料</title>
    <link rel="stylesheet" type="text/css" href="../../Script/lightbox/jquery.lightbox-0.5.css" media="screen" />
    <script type="text/javascript" src="/Script/jquery.js"></script>
    <script type="text/javascript" src="/StockManage/script/Config2.js"></script>
    <script type="text/javascript" src="/StockManage/script/JustWinTable.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript" src="/Script/jw.js"></script>
    <style type="text/css">
        #gallery img {
            border: 1px solid #3e3e3e;
            border-width: 5px 5px 20px;
        }

        .gv_corp {
            color: Blue;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var jwTable = new JustWinTable('gvResource');
            setButton(jwTable, 'btnDel', 'btnEdit', 'btnLook', 'hfldPurchaseChecked');
            addEvent(document.getElementById('btnEdit'), 'click', rowEdit);
            //addEvent(document.getElementById('btnLook'), 'click', rowQuery);
            addEvent(document.getElementById('selectResource'), 'click', selectResource);
            addEvent(document.getElementById('selectResource4'), 'click', selectResource4);
            function rowEdit() {
                //var url = "/BudgetManage/Resource/ResourceTypeEdit.aspx?id=" + document.getElementById("hfldPurchaseChecked").value + "&parentId=" + document.getElementById("hdParentId").value;
                ////winopen(url)
                //top.ui.openWin({ title: '资源类型', url: url, width: 600, height: 370 });
                var hdTypeValue = 'edit';
                var Dgtitle = '组件数量';
                //if (type != undefined && type == 'add') {
                //    hdTypeValue = 'add';
                //    Dgtitle = "组件数量";
                //}
                //document.getElementById("hdType").value = hdTypeValue
                //			document.getElementById("txtFileInfo").value = "";

                top.ui.prompt(Dgtitle, '组件数量', function (r) {
                    if (r) {
                        var CID = document.getElementById("hfldPurchaseChecked").value;
                        //alert(r);
                        //alert(CID);
                        $('#NUM').val(r);
                        $('#CID').val(CID);
                        //document.getElementById("hfldPurchaseChecked").value;
                        $('#btnSaveNUM').click();
                    }
                });
            }

            function selectResource() {

                var typeCode = '0002,0003';
                var src = '/StockManage/UserControl/SelectResource.aspx?type=2&TypeCode=' + typeCode;
                top.ui.callback = function (obj) {
                   
                    $('#hfldResourceId').val(obj.id);
                    $('#btnBindResource').click();
                }
                top.ui.openWin({ title: '选择资源', url: src, width: 1010, height: 500 });
            }
            function selectResource4() {

                var typeCode = '0004';
                var src = '/StockManage/UserControl/SelectResource.aspx?type=2&TypeCode=' + typeCode;
                top.ui.callback = function (obj) {

                    $('#hfldResourceId').val(obj.id);
                    $('#btnBindResource').click();
                }
                top.ui.openWin({ title: '选择组装材料', url: src, width: 1010, height: 500 });
            }
            //var url = "/BudgetManage/Resource/ResourceTypeEdit.aspx?parentId=" + document.getElementById("hdParentId").value;
            //top.ui.openWin({title: '资源类型', url: url, width: 600, height: 370});

            //function rowQuery() {
            //    var url = "/BudgetManage/Resource/ResourceTypeEdit.aspx?t=1&id=" + document.getElementById("hfldPurchaseChecked").value;
            //    winopen(url)
            //}
            $('.gallery').each(function () {
                $(this).find('a').lightBox({
                    overlayBgColor: '#555',
                    imageLoading: '../../Script/lightbox/images/lightbox-ico-loading.gif',
                    imageBtnPrev: '../../Script/lightbox/images/lightbox-btn-prev.png',
                    imageBtnNext: '../../Script/lightbox/images/lightbox-btn-next.png',
                    imageBtnClose: '../../Script/lightbox/images/lightbox-btn-close.jpg',
                    txtImage: '图片',
                    txtOf: '共',
                    maxWidth: 600,
                    maxHeight: 600
                });
            });
            //页面加载时从cookie取滚动条位置信息，然后附值给滚动条
            //var arr = getCookie('scrollTop');
            //document.getElementById('div1').scrollTop = parseInt(arr);
        }


        //页面刷新前保存滚动条位置信息到cookie
        //window.onbeforeunload = function () {
        //    var scrollPos;
        //    scrollPos = document.getElementById('div1').scrollTop;
        //    document.cookie = "scrollTop=" + scrollPos;
        //}

        //获取Cookie
        //function getCookie(name) {
        //    var start = document.cookie.indexOf(name + "=");
        //    var len = start + name.length + 1;
        //    if ((!start) && (name != document.cookie.substring(0, name.length))) {
        //        return null;
        //    }
        //    if (start == -1) return null;
        //    var end = document.cookie.indexOf(';', len);
        //    if (end == -1) end = document.cookie.length;
        //    return unescape(document.cookie.substring(len, end));
        //}
       
    </script>

</head>
<body>
    <form id="form1" runat="server">
<%--        <div class="divHeader">
            <table class="tableHeader">
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" Font-Bold="true" Text="资源类型设置" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>--%>
        <table style="width: 100%; height: 100%;">
            <tr>
                <%--<td style="width: 220px; vertical-align: top; height: 100%;display:none;">
                    <div class="pagediv" style="width: 220px; height: 105%;" id="div1" runat="server">
                        <asp:TreeView ID="tvResource" ShowLines="true" ExpandDepth="2" OnSelectedNodeChanged="TreeView_SelectedNodeChanged" runat="server">
                            <SelectedNodeStyle CssClass="trvw_select" />
                        </asp:TreeView>
                    </div>
                </td>--%>
                <td style="width: 100%; vertical-align: top; height: 100%; border-left: solid 2px #CADEED;">
                    <table border="0" class="tab">
                        <tr>
                            <td class="divFooter" style="text-align: left;">
                                <input type="button" id="selectResource" value="添加材料组成" style="width:auto;" runat="server"/>
                                <input type="button" id="selectResource4" value="复制组装材料的组成" style="width:auto;" runat="server"/>
                                <input type="button" id="btnEdit" disabled="disabled" value="编辑组件数量" runat="server" style="width:auto;" />
                                 <asp:Button ID="btnSaveNUM" Text="组成数量"  runat="server" OnClick="btnSaveNUM_Click" style="display:none;"/>
                                <asp:Button ID="btnDel" Text="删  除" disabled="disabled" OnClientClick="return confirm('您确定要删除吗??')" OnClick="btnDel_Click" runat="server" />
                                <input type="button" id="btnLook" style="display: none;" disabled="disabled" value="查看" />
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <%-- <tr>
                        <td style="height: 100%; vertical-align: top;">
                            <div class="pagediv">
                                <asp:GridView ID="gvResource" AutoGenerateColumns="false" CssClass="gvdata" OnRowDataBound="gvPurchaseplan_RowDataBound" DataKeyNames="resourcetypeid" runat="server"><Columns><asp:TemplateField HeaderStyle-Width="20px"><HeaderTemplate>
                                                <asp:CheckBox ID="cbAllBox" runat="server" />
                                            </HeaderTemplate><ItemTemplate>
                                                <asp:CheckBox ID="cbBox" ToolTip='<%# System.Convert.ToString(Eval("resourcetypeid"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server" />
                                            </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px"><ItemTemplate>
                                                <%# Container.DataItemIndex + (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + 1 %>
                                            </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="资源分类名称"><ItemTemplate>
                                                <%# Eval("ResourceTypeName") %>
                                            </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="资源分类编码"><ItemTemplate>
                                                <%# Eval("ResourceTypeCode") %>
                                            </ItemTemplate></asp:TemplateField></Columns><RowStyle CssClass="rowa"></RowStyle><AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle><HeaderStyle CssClass="header"></HeaderStyle><FooterStyle CssClass="footer"></FooterStyle></asp:GridView>
                                <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" UrlPaging="false" ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Right" EnableTheming="true" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                                </webdiyer:AspNetPager>
                            </div>
                        </td>
                    </tr>--%>
                        <tr>
                            <td style="height: 100%; width: 100%; vertical-align: top;">
                                <div id="divBudget" style="width: 100%; height: 100%">
                                    <asp:GridView ID="gvResource" AutoGenerateColumns="false" CssClass="gvdata" OnRowDataBound="gvPurchaseplan_RowDataBound" DataKeyNames="ResourceId,CorpID,Note" runat="server">
<%--                                        <EmptyDataTemplate>
                                            <table id="emptyTable">
                                                <tr class="header">
                                                    <th scope="col" style="width: 20px;"></th>
                                                    <th scope="col">序号
                                                    </th>
                                                    <th scope="col">资源编号
                                                    </th>
                                                    <th scope="col">资源名称
                                                    </th>
                                                      <th scope="col">组成数量
                                                    </th>
                                                    <th scope="col">规格
                                                    </th>
                                                    <th scope="col">品牌
                                                    </th>
                                                    <th scope="col">税率
                                                    </th>
                                                    <th scope="col">技术参数
                                                    </th>
                                                    <th scope="col">单位
                                                    </th>
                                                    <th scope="col">供应商
                                                    </th>
                                                    <th scope="col">系列
                                                    </th>
                                                    <th scope="col">型号
                                                    </th>
                                                    <th scope="col">备注
                                                    </th>
                                                    <th scope="col">图片
                                                    </th>
                                                    <th scope="col">成本价
                                                    </th>
                                                    <th scope="col">目标成本价
                                                    </th>
                                                    <th scope="col">采购价
                                                    </th>
                                                    <th scope="col">售价
                                                    </th>
                                                    <th scope="col">出厂价
                                                    </th>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>--%>
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="20px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="cbAllBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbBox" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="序号" DataField="Number" />
                                            <asp:BoundField HeaderText="材料编号" DataField="ResourceCode" />
                                            <asp:BoundField HeaderText="材料名称" DataField="ResourceName" />
                                            <asp:TemplateField HeaderText="组成数量" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px">
                                                <ItemTemplate>
                                                    <%#Eval("NUM")%>
                                                 <%--   <asp:TextBox Style="text-align: right;" Width="70px" Height="15px" ID="txtNumber" CssClass="decimal_input" Text='<%# System.Convert.ToString((Eval("NUM").ToString() == "") ? "0.000" : Eval("NUM"), System.Globalization.CultureInfo.CurrentCulture) %>' runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="lblCode" Value='<%#Eval("ResourceId")%>' runat="server" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="规格" DataField="Specification" />
                                            <asp:BoundField HeaderText="型号" DataField="ModelNumber" />
                                            <asp:BoundField HeaderText="品牌" DataField="Brand" />
                                            <asp:BoundField HeaderText="单位" DataField="Name" />
                                            <asp:BoundField HeaderText="供应商" DataField="CorpName" ItemStyle-CssClass="gv_corp" />
                                            <asp:BoundField HeaderText="系列" DataField="Series" Visible="false"/>
                                            <asp:BoundField HeaderText="技术参数" DataField="TechnicalParameter" Visible="false"/>
                                            <asp:BoundField HeaderText="税率" DataField="TaxRate" Visible="false"/>
                                            <asp:TemplateField HeaderText="备注" Visible="false">
                                                <ItemTemplate>
                                                    <%# StringUtility.GetStr(Eval("Note").ToString(), 10) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="图片" Visible="false">
                                                <ItemTemplate>
                                                    <%# ResourceImage.GetImages(System.Convert.ToString(Eval("ResourceId"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="rowa"></RowStyle>
                                        <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                        <HeaderStyle CssClass="header"></HeaderStyle>
                                        <FooterStyle CssClass="footer"></FooterStyle>
                                    </asp:GridView>
                                    <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" ShowPageIndexBox="Always" UrlPaging="false" PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" SubmitButtonText="确定" SubmitButtonStyle="width:40px; vertical-align:top;" TextAfterPageIndexBox="页" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                                    </webdiyer:AspNetPager>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfldPurchaseChecked" runat="server" />
        <asp:HiddenField ID="hdParentId" runat="server" />
        <asp:HiddenField ID="hfldPriceTypeId" runat="server" />
        <asp:HiddenField ID="NUM" runat="server" />
        <asp:HiddenField ID="CID" runat="server" />
        <!--从采购计划中选择物资的物资ID-->
        <asp:HiddenField ID="hfldResourceId" runat="server" />
         <!--从采购计划中选择物资后执行-->
        <asp:Button ID="btnBindResource" Text="Button" OnClick="btnBindResource_Click" runat="server" style="display:none;"/>
    </form>
</body>
</html>
