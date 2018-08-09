<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workloglist.aspx.cs" Inherits="workLogList" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>workLogList</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <font face="宋体">
            <div align="center">
                <img height="27" src="img/diary.gif" width="245"></div>
            <br>
            <table width="75%" align="center">
                <tr>
                    <td align="right" colspan="2">从
							<asp:TextBox ID="startDate" Width="100px" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="startDate" ErrorMessage="*" Display="Dynamic" runat="server"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator1" ControlToValidate="startDate" ErrorMessage="无效日期" Type="Date" MinimumValue="1900-01-1" MaximumValue="9999-12-31" Display="Dynamic" runat="server"></asp:RangeValidator><input id="searchFlag" type="hidden" size="1" value="flase" name="serchFlag" runat="server" />

                        到
							<asp:TextBox ID="endDate" Width="100px" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="endDate" ErrorMessage="*" Display="Dynamic" runat="server"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator2" ControlToValidate="endDate" ErrorMessage="无效日期" Type="Date" MinimumValue="1900-01-1" MaximumValue="9999-12-31" Display="Dynamic" runat="server"></asp:RangeValidator>
                        <asp:Button ID="btnSearch" Text="查询" CssClass="button-normal" OnClick="btnSearch_Click" runat="server" /><input id="hidStart" type="hidden" name="hidStart" runat="server" />

                        <input id="hidEnd" type="hidden" name="hidEnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2"><a oncontextmenu="javascript:window.event.cancelBubble = true;" onclick="javascript:return false;"
                        href="workLogSaveAs.aspx">保存本人日志到本地(右键另存为，将文件名更改为*.htm即可)</a>
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="2">
                        <asp:DataGrid ID="DataGrid1" Width="100%" AutoGenerateColumns="false" DataKeyField="dtm_zxsj" PageSize="16" AllowPaging="true" CellPadding="5" runat="server">
                            <HeaderStyle HorizontalAlign="Center" CssClass="grid_head"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="内容摘要">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Convert.ToString(Eval("i_gzrz_id", "workLogPreview.aspx?id={0}")) %>' runat="server"><%# Convert.ToString(base.truncString(Eval("txt_rznr").ToString().Trim(), 50)) %></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="操作命令">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Convert.ToString(Eval("i_gzrz_id", "workLogUpdate.aspx?id={0}")) %>' runat="server">已归档
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="dtm_zxsj" HeaderText="撰写时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="dtm_xgsj" HeaderText="修改时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle NextPageText="下一页" PrevPageText="上一页" HorizontalAlign="Right"></PagerStyle>
                        </asp:DataGrid></td>
                </tr>
            </table>
        </font>
    </form>
</body>
</html>
