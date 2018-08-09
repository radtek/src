<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocView.aspx.cs" Inherits="OA3_FileMsg_DocView" %>
<%@ Register TagPrefix="MyUserControl" TagName="stockmanage_common_showaudit_ascx" Src="~/StockManage/Common/ShowAudit.ascx" %>

<!DOCTYPE html>
<%@ Import Namespace="cn.justwin.BLL" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/Script/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript" src="../../Script/jw.js"></script>
    <script type="text/javascript" src="../../StockManage/script/Config2.js"></script>
    <link href="/StyleExt/CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="all" />
    <link href="/StockManage/skins/sm4.css" rel="stylesheet" type="text/css" />
    <link href="/StyleCss/Common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Script/DecimalInput.js"></script>
    <script type="text/javascript" src="/SysFrame/jscript/JsControlMenuTool.js"></script>
    <script type="text/javascript">
     function add() {
            top.ui._DocList = window;
            var url = '/OA3/FileMsg/DocEdit.aspx?action=add&PId=' + document.getElementById('hdSeleValue').value;
            title = '标注';
            toolbox_oncommand(url, title);
     }
     function showDoc(id, DocAttribute) {
         ///toolbox_oncommand('
         top.ui._DocList = window;
         var url = "/OA3/FileMsg/DocView.aspx?ic=" + id + "&DocAttribute=" + DocAttribute + "";
         title = '查看文档';
         toolbox_oncommand(url, title);
     }

    </script>
</head>
<body id="print1" style="overflow-y: auto; height: auto;min-width:920px;">
    <form id="form1" runat="server">
        <div class="VPage">
            <%-- <div align="center" id="mTable" style="margin-top: 5px; vertical-align: top;">
                <div style="vertical-align: top;">--%>
            <table class="tabCss" style="vertical-align: top; border-collapse: collapse;">
           <tr>
             <td class="title-divHeader">
                文档信息详情
                <%--<input type="button" style="float: right;" class="noprint" onclick="winPrint()" value=" 打 印 " />
               <input type="button" id="btnDy" style="float: right;" class="noprint" value=" 打 印 "/>--%>
            </td>
        </tr>
        <tr style="height: 1px;">
            <td>
                <table id="bllProducer" cellpadding="0" cellspacing="0" style="border-style: none;width: 100%;">
                    <tr style="display:none">
                        <td style="border-style: none;">
                            创建人:&nbsp;&nbsp;<asp:Label ID="v_xm" runat="server"></asp:Label>
                        </td>
                        <td style="border-style: none; text-align: right">
                            创建时间:&nbsp;&nbsp;<asp:Label ID="CreateTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td style="border-style: none;">
                            编辑人:&nbsp;&nbsp;<asp:Label ID="DocEditUserName" runat="server"></asp:Label>
                        </td>
                        <td style="border-style: none; text-align: right">
                            编辑时间:&nbsp;&nbsp;<asp:Label ID="DocEditDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                <tr>
                    <td style="vertical-align: top">
                        <div class="cell_title_blue_line" >
                            <div class="cell_title_blue_left">
                            </div>
                            <div class="cell_title_blue_bg">
                                <span class="titlespan">文档详情</span>
                            </div>
                            <div class="cell_title_blue_right">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="tabCss" style="vertical-align: top; border-collapse: collapse;">
                <tr id="change1" runat="server">
                    <td class="descTd">变更类型
                    </td>
                    <td class="elemTd" colspan="3">
                        <asp:Label ID="DocChangeTypeName" runat="server"></asp:Label>
                    </td>
                </tr>   
                <tr id="change2" runat="server">
                    <td class="descTd">变更说明
                    </td>
                    <td class="elemTd" colspan="3">
                        <asp:Label ID="DocChangeRemark" runat="server"></asp:Label>
                    </td>
                </tr>   
                <tr>
                    <td class="descTd">文档名称</td>
                    <td class="elemTd">
                        <asp:Label ID="FileName" runat="server"></asp:Label>
                    </td>
                    <td class="descTd">文档序号</td>
                    <td class="elemTd">
                        <asp:Label ID="DocSort" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">文档编码</td>
                    <td class="elemTd">
                        <asp:Label ID="DocCode" runat="server"></asp:Label>
                    </td>
                    <td class="descTd">文档版本</td>
                    <td class="elemTd">
                        <asp:Label ID="DocVersionName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">文档类型</td>
                    <td class="elemTd">
                        <asp:Label ID="DocTypeName" runat="server"></asp:Label>
                    </td>
                    <td class="descTd">文档状态</td>
                    <td class="elemTd">
                        <asp:Label ID="DocStatusName" runat="server"></asp:Label>
                    </td>
                </tr>  <tr>
                    <td class="descTd">文件作者
                    </td>
                    <td class="elemTd" colspan="3">
                        <asp:Label ID="DocAuthor" runat="server"></asp:Label>
                    </td>
                </tr>     <tr>
                    <td class="descTd">文档文件
                    </td>
                    <td class="elemTd" id="FileUpload2" runat="server" colspan="3"></td>
                </tr> <tr>
                    <td class="descTd">关联文档
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="DocRelationIDs" runat="server"></asp:Label>
                    </td>
                   <td class="descTd">关联项目
                    </td>
                    <td class="elemTd">
                        <asp:Label ID="PrjName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="descTd">备注说明
                    </td>
                    <td class="elemTd" colspan="3">
                        <asp:Label ID="Remark" Style="background-color: #fafafa;" Height="120px" Width="100%" Wrap="true" runat="server"></asp:Label>
                    </td>
                </tr>
              
                 <tr>
                    <td class="elemTd" colspan="4">
                        <MyUserControl:stockmanage_common_showaudit_ascx ID="ShowAudit1"  BusiClass="001" runat="server" />
                    </td>
                </tr>
                <tr id="t1" runat="server">
                    <td style="font-size: 13px; font-weight: bold; text-align: center; position: relative" runat="server" colspan="4">文档历史
                    </td>
                </tr>
                <tr  id="t2" runat="server">
                    <td class="elemTd" colspan="4">
                        <asp:GridView ID="gvFile" CssClass="gvdata" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvFile_RowDataBound" DataKeyNames="Id" runat="server">
                            <Columns>
                             <%--   <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbAllBox" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbBox" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#Eval("pageindex") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        文档类型
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <center><%# Eval("DocTypeName").ToString()%></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        文档状态
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <center><%# Eval("DocStatusName").ToString()%></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        文档版本
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <center><%# Eval("DocVersionName").ToString()%></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        文档编码
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("DocCode").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="250px">
                                    <HeaderTemplate>
                                        文档名称
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <span class="al tooltip" title='<%# Eval("FileName").ToString() %>' onclick="toolbox_oncommand('/OA3/FileMsg/DocView.aspx?ic=<%# Eval("Id") %>&DocAttribute=<%# Eval("DocAttribute") %>','查看文档')">
                                            <%# StringUtility.GetStr(Eval("FileName").ToString(), 20) %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建人">
                                    <ItemTemplate>
                                        <center><%# Eval("v_xm").ToString()%></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="70px">
                                    <HeaderTemplate>
                                        更新时间
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <center><%# System.Convert.ToDateTime(Eval("DocEditDate")).ToString("yyyy-MM-dd HH:mm") %></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        文档属性
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <center><%# Eval("DocAttributeName").ToString()%></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="流程状态" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <center><%# Common2.GetStateNullString(Eval("FlowStatusName").ToString()) %></center>
                                        <%--  <center><%# (Eval("DocAttribute").ToString() == "0") ? Common2.GetStateNullString(Eval("DocCBFlowStatus").ToString()) : Common2.GetStateNullString(Eval("DocSBFlowStatus").ToString())%></center>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="rowa"></RowStyle>
                            <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                            <HeaderStyle CssClass="header"></HeaderStyle>
                            <FooterStyle CssClass="footer"></FooterStyle>
                        </asp:GridView>
                        <asp:Label ID="lblMsgAleave" Text="" runat="server"></asp:Label>
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="100%" ShowPageIndexBox="Always" UrlPaging="false" PageIndexBoxType="TextBox" TextBeforePageIndexBox="转到: " FirstPageText="首页" LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" HorizontalAlign="Left" EnableTheming="true" SubmitButtonText="确定" SubmitButtonStyle="width:40px; vertical-align:top;" TextAfterPageIndexBox="页" OnPageChanged="AspNetPager1_PageChanged" runat="server">
                        </webdiyer:AspNetPager>

                    </td>
                </tr>
           
            </table>
        </div>

         <%--<div class="divFooter2">
            <table class="tableFooter2">
                <tr>
                    <td>
                        <input type="button" id="btnCancel" value="关闭" onclick="top.ui.closeTab();" />
                    </td>
                </tr>
            </table>
        </div>--%>
        <input type="hidden" id="KeyId" runat="server" />
    </form>
</body>
</html>
