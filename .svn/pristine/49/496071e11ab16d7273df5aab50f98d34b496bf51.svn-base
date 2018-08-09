<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="MenuPowerList.aspx.cs" Inherits="OA3_FileMsg_MenuPowerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>目录权限</title>
    <script type="text/javascript" src="../../Script/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#TvBranch input[type=checkbox]').click(function () {
                selectChe();
            });
        });

        // 点击树节点
        function OnTreeNodeChecked() {
            //单击父节点子结点选中的代码
            var ele = event.srcElement;
            if (ele.type == 'checkbox') {
                var childrenDivID = ele.id.replace('CheckBox', 'Nodes');
                var div = document.getElementById(childrenDivID);
                if (div != null) {
                    var checkBoxs = div.getElementsByTagName('INPUT');
                    for (var i = 0; i < checkBoxs.length; i++) {
                        if (checkBoxs[i].type == 'checkbox')
                            checkBoxs[i].checked = ele.checked;
                    }
                }
            }
        }

        function selectChe() {
            var checkBoxs = document.getElementsByTagName('INPUT');
            for (var i = 0; i < checkBoxs.length; i++) {
                if (checkBoxs[i].type == "checkbox" && checkBoxs[i].id.length > 9 && checkBoxs[i].id.substring(0, 9) == "TvBranchn") {
                    document.getElementById("hdBranchList").value = "";
                    document.getElementById("lblBranchList").innerHTML = "";
                }
            }
            var ca = "";
            for (var i = 0; i < checkBoxs.length; i++) {
                if (checkBoxs[i].type == "checkbox") {
                    if (checkBoxs[i].id.length > 9 && checkBoxs[i].id.substring(0, 9) == "TvBranchn") {
                        if (checkBoxs[i].checked == true) {
                            spIdVal = document.getElementById("hdBranchList").value.split(',');
                            cb = false;
                            for (j = 0; j < spIdVal.length; j++) {

                                if (spIdVal[j] == getIdBycId(checkBoxs[i].id + ",")) {
                                    cb = true;
                                }
                            }
                            if (cb == false) {
                                document.getElementById("lblBranchList").innerHTML += getTitleBycId(checkBoxs[i].id + ",");
                                document.getElementById("hdBranchList").value += getIdBycId(checkBoxs[i].id + ",");

                            }
                        }
                        if (checkBoxs[i].checked == false) {
                            ftxt = document.getElementById("hdBranchList").value; //ID
                            fname = document.getElementById("lblBranchList").innerHTML;
                            if (ftxt.indexOf(getIdBycId(checkBoxs[i].id + ",")) != -1) {   //ID                                   
                                bfore = ftxt.substring(0, ftxt.indexOf(getIdBycId(checkBoxs[i].id + ",")));
                                ene = ftxt.substring((bfore.length + getIdBycId(checkBoxs[i].id + ",").length + 1), ftxt.length);
                                document.getElementById("hdBranchList").value = bfore + ene;
                                //名称
                                bfore2 = fname.substring(0, fname.indexOf(checkBoxs[i].title));
                                ene2 = fname.substring((bfore2.length + checkBoxs[i].title.length + 1), fname.length);
                                document.getElementById("lblBranchList").innerHTML = bfore2 + ene2;
                            }
                        }
                    }
                }
            }
            document.getElementById("hdBranchName").value = document.getElementById("lblBranchList").innerHTML;
        }

        function getIdBycId(cId) {
            return document.getElementById("TvBrancht" + cId.substring(9, cId.length - 9)).title + ",";
        }

        function getTitleBycId(cId) {
            var branch = document.getElementById("TvBrancht" + cId.substring(9, cId.length - 9));
            return branch.innerText + "&nbsp;&nbsp;读取权限:<input type='checkbox' name='" + branch.title + "_BranchRead' checked>&nbsp;&nbsp;写入权限:<input type='checkbox' name='" + branch.title + "_BranchWrite' checked><span style=' cursor:pointer;' onclick=\"delUser(" + branch.title + ",'hdBranchList','lblBranchList')\">×</span>；</br>";
        }
        //单击子节点父节点选中
        function selparent(obj) {
            var p = obj.parentNode.parentNode.parentNode.parentNode.parentNode;
            var pCheckNodeID = p.id.replace("Nodes", "CheckBox");
            var checkNode = document.getElementById(pCheckNodeID);
            if (checkNode) {
                checkNode.checked = true;
                selparent(checkNode);
            }
        }
        //删除
        function delUser(id, hdUser, lblUser) {
            document.getElementById("lblBranchList2").value = document.getElementById("lblBranchList").innerHTML;
            document.getElementById("hdDelId").value = id;
            document.getElementById("hdType").value = hdUser;
            console.log(id);
            console.log(hdUser);
            document.getElementById("btnRe").click();
            selectChe();
        }
        function GetCheck() {
            //alert(0000);
            document.getElementById("tbRW").value = "";
            var id1 = document.getElementById("lblUserList");
            var id2 = document.getElementById("lblBranchList");
            var id3 = document.getElementById("lblPostList");
            var id4 = document.getElementById("lblRoleList");
            var id5 = document.getElementById("lblProjectList");

            var ckb = document.getElementsByTagName("INPUT");
            for (i = 0; i < ckb.length; i++) {
                if (ckb[i].type == "checkbox") {
                    if (ckb[i].parentNode == id1 || ckb[i].parentNode == id2 || ckb[i].parentNode == id3 || ckb[i].parentNode == id4 || ckb[i].parentNode == id5) {
                        if (ckb[i].checked) {
                            //alert(ckb[i].name);
                            document.getElementById("tbRW").value += ckb[i].name+'|';
                        }
                    }
                }
            }
            document.getElementById("btnSave").click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display:none;">
         <asp:TextBox ID="lblBranchList2" runat="server"></asp:TextBox>
        <asp:TextBox ID="tbRW" runat="server"></asp:TextBox>
            </div>
         <%--<asp:HiddenField ID="hdRW" runat="server" />--%>
        <table class="tab" width="100%">
            <tr>
                <td style="height: 96%; width: 100%;">
                    <table class="tab" cellpadding="0" cellspacing="0">
                        <tr>
                        <%--    <td rowspan="2" style="width: 155px; height: 100%; vertical-align: top; border: solid 1px #AAAAAA;">
                                <asp:TreeView ID="tvFile" ExpandDepth="1" ShowLines="true" Style="overflow: auto; width: 155px; height: 100%;"
                                    OnSelectedNodeChanged="tvFile_SelectedNodeChanged" runat="server">
                                    <SelectedNodeStyle CssClass="trvw_select" />
                                </asp:TreeView>
                            </td>
                            <td class="bottonrow" >
                                
                            </td>--%>
                            <td class="bottonrow" style="text-align: left;">
                                <asp:DropDownList ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Value="Person" Text="--人员--" />
                                    <asp:ListItem Value="Department" Text="--部门--" />
                                    <asp:ListItem Value="Post" Text="--岗位--" />
                                    <asp:ListItem Value="Role" Text="--角色--" />
                                    <asp:ListItem Value="Project" Text="--项目成员--" />
                                </asp:DropDownList>
                                <input id="btnGetCheck" type="button" value="保存" onclick="GetCheck()" />
                                <asp:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" style="display:none;"/>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 55%; height: 100%; vertical-align: top; border: solid 0px #AAAAAA;">
                                <table class="tab" style="border: solid 0px green;" cellspacing="0">
                                    <tr>

                                        <td id="tdTree" style="border-right: solid 1px #AAAAAA; border-top: solid 1px #AAAAAA; width: 10%; vertical-align: top;" runat="server">
                                            <asp:TreeView ID="TvBranch" ExpandDepth="1" onclick="OnTreeNodeChecked()" ShowLines="true" OnSelectedNodeChanged="TvBranch_SelectedNodeChanged" runat="server">
                                                <SelectedNodeStyle CssClass="trvw_select" />
                                            </asp:TreeView>
                                        </td>

                                        <td id="tdGv" style="width: 60%; vertical-align: top; padding: 0px;" runat="server">

                                            <asp:GridView CssClass="gvdata" ID="gvBranch" AutoGenerateColumns="false" runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="20px">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllBox" AutoPostBack="true" OnCheckedChanged="cbAllBox_CheckedChanged" runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox AutoPostBack="true" ID="cbBox" ToolTip='<%# Convert.ToString(Eval("v_yhdm")) %>' OnCheckedChanged="cbBox_CheckedChanged" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            姓名
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("v_xm") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="rowa"></RowStyle>
                                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                                <HeaderStyle CssClass="header"></HeaderStyle>
                                                <FooterStyle CssClass="footer"></FooterStyle>
                                            </asp:GridView>


                                            <asp:GridView CssClass="gvdata" Width="100%" Visible="false" ID="gvPost" AutoGenerateColumns="false" runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="20px">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllBoxPost" AutoPostBack="true" OnCheckedChanged="cbAllBoxPost_CheckedChanged" runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox AutoPostBack="true" ID="cbPost" ToolTip='<%# Convert.ToString(Eval("I_DUTYID")) %>' OnCheckedChanged="cbBox_CheckedChanged2" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            岗位
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("DutyName").ToString() %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="rowa"></RowStyle>
                                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                                <HeaderStyle CssClass="header"></HeaderStyle>
                                                <FooterStyle CssClass="footer"></FooterStyle>
                                            </asp:GridView>

                                            <asp:GridView CssClass="gvdata" Width="100%" Visible="false" ID="gvRole" AutoGenerateColumns="false" runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="20px">
                                                       <%-- <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllBoxRole" AutoPostBack="true" OnCheckedChanged="cbAllBoxRole_CheckedChanged" runat="server" />
                                                        </HeaderTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:CheckBox AutoPostBack="true" ID="cbRole" ToolTip='<%# Convert.ToString(Eval("Id")) %>' OnCheckedChanged="cbBox_CheckedChanged3" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            角色
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("Name").ToString() %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="rowa"></RowStyle>
                                                <AlternatingRowStyle CssClass="rowb"></AlternatingRowStyle>
                                                <HeaderStyle CssClass="header"></HeaderStyle>
                                                <FooterStyle CssClass="footer"></FooterStyle>
                                            </asp:GridView>

                                            <asp:GridView CssClass="gvdata" ID="gvProject" AutoGenerateColumns="false" runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="20px">
                                                       <%-- <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAllBox" AutoPostBack="true" OnCheckedChanged="cbAllProject_CheckedChanged" runat="server" />
                                                        </HeaderTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:CheckBox AutoPostBack="true" ID="cbProject" ToolTip='<%# Convert.ToString(Eval("v_yhdm")) %>' OnCheckedChanged="cbBox_CheckedChanged4" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            项目成员(项目权限中的成员)
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("v_xm") %>
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
                            </td>
                            <td width="30%" valign="top" style="border: solid 1px #AAAAAA; height: 100%;">
                                <table class="tab" style="vertical-align: top; background-color: #aaaaaa;" border="0"
                                    cellpadding="0" cellspacing="1">
                                    <tr style="background-color: #fff;">
                                        <td style="height: 5%;" valign="top">
                                            <asp:Label ID="lblMsg" Font-Bold="true" Text="以下是您选择的信息：" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #fff;">
                                        <td style="height: 15%; vertical-align: top;">
                                            <span style="font-weight: bold;">人员信息:</span></br>
                                                <asp:Label ID="lblUserList" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdUserList" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="background-color: #fff;">
                                        <td style="height: 15%; vertical-align: top;">
                                            <span style="font-weight: bold;">部门信息:</span></br>
                                             <div id="Branch">
                                                 <asp:Label ID="lblBranchList" runat="server"></asp:Label>
                                                 <asp:HiddenField ID="hdBranchList" runat="server" />
                                                 <asp:HiddenField ID="hdBranchName" runat="server" />
                                             </div>

                                        </td>
                                    </tr>
                                    <tr style="background-color: #fff;">
                                        <td style="height: 15%; vertical-align: top;">
                                            <span style="font-weight: bold;">岗位信息:</span></br>
                                               <div id="Post">
                                                   <asp:Label ID="lblPostList" runat="server"></asp:Label>
                                                   <asp:HiddenField ID="hdPostList" runat="server" />
                                               </div>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #fff;">
                                        <td style="height: 15%; vertical-align: top;">
                                            <span style="font-weight: bold;">角色信息:</span></br>
                                             <div id="Role">
                                                 <asp:Label ID="lblRoleList" runat="server"></asp:Label>
                                                 <asp:HiddenField ID="hdRoleList" runat="server" />
                                             </div>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #fff;">
                                        <td style="height: 15%; vertical-align: top;">
                                            <span style="font-weight: bold;">项目成员信息:</span></br>
                                              <div id="Project">
                                                  <asp:Label ID="lblProjectList" runat="server"></asp:Label>
                                                  <asp:HiddenField ID="hdProjectList" runat="server" />
                                              </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnRe" Style="display: none;" OnClick="btnRe_Click" runat="server" />
        <asp:HiddenField ID="hdDelId" runat="server" />
        <asp:HiddenField ID="hdType" runat="server" />
         <asp:HiddenField ID="hdSeleValue" runat="server" />
        <asp:Button Style="display: none;" ID="btnTree" runat="server" />
    </form>
</body>
</html>
