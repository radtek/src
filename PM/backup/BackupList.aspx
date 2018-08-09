<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BackupList.aspx.cs" Inherits="backup_BackupList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>    
    <script type="text/javascript" src="/Script/jquery.js"></script>
    <!-- jQuery.EasyUI-->
    <link type="text/css" rel="Stylesheet" href="../Script/jquery.easyui/themes/default/easyui.css" />
<link type="text/css" rel="Stylesheet" href="../Script/jquery.easyui/themes/icon.css" />

    <script type="text/javascript" src="../Script/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.easyui/jquery.easyui.extension.js"></script>
    <script type="text/javascript" src="../Script/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <!-- jQuery.EasyUI-->   
    <link href="css/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
<link href="css/main.css" rel="stylesheet" type="text/css" />

    
    <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="js/script.js"></script>
    <script type="text/javascript" src="../Script/jw.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });

        //后台绑定附件
        function uploadbind(num, file, fileSize, filepath) {
            var $tr
            if (num % 2) {
                $tr = $('<tr class="rowb"></tr>');
            }
            else {
                $tr = $('<tr class="rowa"></tr>');
            }
            var $tdNum = $('<td align="right" style="width: 25px;">' + num + '</td>');
            var $tdName = $('<td >' + file + '</td>');
            var $tdSize = $('<td align="center" style="width: 30%;">' + fileSize + '</td>');
            var $tdDel = $('<td align="center" style="width: 40px;"></td>');
            var $img = $('<img class="deleteAnnex" style="cursor:pointer" src="/images/cancel_2.png" alt="删除" />');
            $img.click(function () {
                deleteAnnexBind(this, filepath);
            });
            $tdDel.append($img);
            $tr.append($tdNum);
            $tr.append($tdName);
            $tr.append($tdSize);
            $tr.append($tdDel);
            $('#annexTab').append($tr);
        }

        // 后台绑定附件删除
        function deleteAnnexBind(img) {
            var $tr = $(img).parent().parent();
            var annexName = $tr.find('td:eq(1)').find('a').html();
            $.get('/UserControl/FileUpload/DeleteFile.ashx?' + new Date().getTime(), { File: $('#hfldFolder').val() + '/' + annexName }, function (data) {
                if (data == '1') {
                    $tr.remove();
                }
                else {
                    alert('系统提示：\n\n删除失败！');
                }
            });
        }

        //设置进度条的宽度      
        function startBackUp(isFinish) {
            if (isFinish == 0) {
                $('#TRplan').show();
                $('#progress1').anim_progressbar();
            }
            else {
                $(this).children('.pbar').children('.ui-progressbar-value').css('width', 100 + '%');
                $(this).children('.percent').html('<b>100%</b>');
                $(this).children('.elapsed').html('Finished');
                $('#TRplan').removeAttr('show');
            }
        }
    </script>
</head>
<body>
    <form id="form1" style="background-color: White;" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="divFooter" style="text-align: left">
                <asp:Button ID="btnback" Text="备份" OnClientClick="startBackUp(0)" Style="height: 21px" OnClick="btnback_Click" runat="server" />
                <asp:Label ID="label_percent" Visible="false" Text="Label" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="TRplan" style="display: none;" runat="server"><td runat="server">
                <div class="example" style="width: 200px; height: 100%">
                    <div id="progress1" style="width: 200px; height: 100%">
                        <div class="percent" style="width: 200px;">
                        </div>
                        <div class="pbar" style="width: 200px;">
                        </div>
                        <div class="elapsed" style="width: 200px;">
                        </div>
                    </div>
                </div>
            </td></tr>
        <tr id="TRUpload" style="width: 100%;" runat="server"><td id="upload" style="width: 100%;" runat="server">
                <table id="annexTab" class="gvdata" cellpadding="0" rules="all" border="1" style="width: 100%; border-collapse: collapse;" runat="server"><tr class="header" runat="server"><td scope="col" style="width: 25px;" runat="server">
                            序号
                        </td><td scope="col" runat="server">
                            名称
                        </td><td scope="col" align="center" style="width: 30%;" runat="server">
                            大小
                        </td><td scope="col" align="center" style="width: 40px;" runat="server">
                            删除
                        </td></tr></table>
            </td></tr>
    </table>
    <asp:HiddenField ID="hfldFolder" runat="server" />
    </form>
</body>
</html>
