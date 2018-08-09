/**
 * Created by zhengjiana on 2017/10/12.
 */
var isPhoto;//是否开启图片必填，1开启，0不开启
function init() {
    //显示类型字典
    showTypeDict();
    wxqyh_uploadfile.agent = "diary";//应用code
    wxqyh_uploadfile.init();
}

//显示联系人按钮
function removePersons(obj, type) {
    var arry;
    if (type == "taskto") {
        arry = $("#toPersonList").find("a");
    } else {
        arry = $("#ccPersonList").find("a");
    }
    var show = $(obj).attr("show");
    if (show == 0) {
        $(obj).attr("show", "1");
        for (var i = 0; i < arry.length; i++) {
            $(arry[i]).show();
        }
    } else {
        $(obj).attr("show", "0");
        for (var i = 0; i < arry.length; i++) {
            $(arry[i]).hide();
        }
    }
}

// 用开关控制加载上一次负责相关人
function selectFormCcOrTo(selectType) {
    $.ajax({
        url: baseURL + "/portal/diaryAction!getOldGivenList.action",
        type: "POST",
        data: {"type": selectType},
        dataType: "json",
        success: function (result) {
            if (result.code == "0") {
                var ccOrTolist = result.data.ccOrTolist;
                if (ccOrTolist && ccOrTolist.length > 0 && "0" == selectType) {//上一次任务负责人
                    selectConfig.toPersonList.userSelected.length = 0;
                    for (var i = 0; i < ccOrTolist.length; i++) {
                        selectConfig.toPersonList.userSelected.push(ccOrTolist[i])
                    }
                }

                if (ccOrTolist && ccOrTolist.length > 0 && "1" == selectType) {//上一次任务相关人
                    selectConfig.ccPersonList.userSelected.length = 0;
                    for (var i = 0; i < ccOrTolist.length; i++) {
                        selectConfig.ccPersonList.userSelected.push(ccOrTolist[i])
                    }
                }
            }
        },
        error: function () {
            _alert("提示", internetErrorMsg, "确认");
        }
    });
}

//提交任务
function commitTask(status) {
    $("#taskStatus").val(status);
    if ($("#taskType").val() == "") {
        _alert("提示", "请选择日志类型", "确认", function () {
            restoreSubmit();
        });
        return;
    }
    if ($("#title").val().length > 100) {
        _alert("提示", "标题过长，请重新编辑", "确认", function () {
            restoreSubmit();
        });
        return;
    }
    if ($("#content").val().replace(/[ ]/g, "").replace(/[\r\n]/g, "") == "") {
        _alert("", "请输入日志内容", "确认", function () {
            restoreSubmit();
        });
        return;
    }
    if (isPhoto == "1" && $("#imglist").children("li").length <= 2) {
        _alert("", "请上传图片", "确认", function () {
            restoreSubmit();
        });
        return;
    }
    if (status == "1" && selectConfig.toPersonList.userSelected.length == 0) {
        _alert("提示", "你还没有选择负责人，确认提交吗？", "取消|确认", {
            ok: function (result) {
                saveDiary(status);
            },
            fail: function (result) {
                restoreSubmit();
            }
        });
    } else {
        saveDiary(status)
    }
}

function saveDiary(status) {
    var status = $("#taskStatus").val();
    if (!status || status.length > 1) {
        $("#taskStatus").val(status)
    }
    //去掉select的disable属性，否则无法数据无法传递
    $("#taskType").removeAttr("disabled");
    showLoading("正在提交...");
    $.ajax({
        url: baseURL + "/portal/diaryAction!ajaxAdd.action",
        type: "POST",
        data: $("#taskform").serialize(),
        dataType: "json",
        success: function (result) {
            $("#imgFileLoadDiv").hide();
            if (result.code == "0") {
                //提交完成后清除缓存
                removeStorage();
                if (status == "0") {
                    //提交草稿跳转到草稿列表
                    window.location.href = baseURL + "/jsp/wap/diary/list.jsp?type=1&status=0&agentCode=diary&abc=1";
                } else {
                    //提交发布跳转到已提交列表
                    if (getParam("uncommitted") && !getParam("unSubmitNum")) {
                        window.location.href = baseURL + "/jsp/wap/diary/list_uncommitted.jsp";
                    } else {
                        window.location.href = baseURL + "/jsp/wap/diary/list.jsp?type=1&status=1&agentCode=diary&abc=1";
                    }
                }
            } else {
                _alert("提示", "新建日志失败", "确认", function () {
                    restoreSubmit();
                });
            }
            hideLoading();
        },
        error: function () {
            _alert("提示", internetErrorMsg, "确认", function () {
                restoreSubmit();
            });
        }
    });
}
var templateMap = new Map();
var userName = "";
function showTypeDict() {
    $.ajax({
        url: baseURL + "/portal/diaryAction!getDiaryTemplate.action",
        type: "get",
        async: false,
        dataType: "json",
        success: function (result) {
            if (result.code == "0") {
                var templatelist = result.data.template;
                userName = result.data.user;
                var html = "<option value=''>请选择</option>";
                if (templatelist.length <= 0) {
                    html = "<option value=''>请选择类型(后台可设置类型)</option>";
                }
                //指定默认选中的任务类型
                var diaryType = getParam("diaryType");
                for (var i = 0; i < templatelist.length; i++) {
                    var template = templatelist[i];
                    templateMap.put(template.id, template);
                    if (template.id == diaryType) {
                        document.title = "新建" + template.name;
                        html += "<option selected='true' value='" + template.id + "'>" + template.name + "</option>";
                    } else {
                        html += "<option value='" + template.id + "'>" + template.name + "</option>";
                    }
                }
                $("#taskType").append(html);
                var toList = result.data.tolist;
                if (toList.length > 0) {
                    selectConfig.toPersonList.userSelected = toList;
                }
                var ccList = result.data.cclist;
                if (ccList.length > 0) {
                    selectConfig.ccPersonList.userSelected = ccList;
                }
                storage();//H5缓存调用
                $('textarea.inputStyle').trigger('click');
                if ($("#taskType").val() != "") {
                    var template = templateMap.get($("#taskType").val());
                    if (template) {
                        isPhoto = template.isPhoto;
                    }
                }
                //统计未提交人员自动选中该日志类型
                var diaryId = getParam("diaryId");
                if (diaryId) {
                    $("#taskType").val(diaryId);
                    autoInput(diaryId);
                }
                //判断是否金卡vip
                wxqyhConfig.ready(function () {
                    if (isVipGold(interfaceCode.INTERFACE_CODE_DIARY)) {
                        //是否有未提交日志
                        if (result.data.unSubmitNum && result.data.unSubmitNum > 0 && !getParam("uncommitted")) {
                            $("#isUnSubmit").show();
                            $("#isUnSubmit").click(function () {
                                if (result.data.unSubmitNum > 1) {
                                    window.location.href = baseURL + "/jsp/wap/diary/list_uncommitted.jsp";
                                } else {
                                    window.location.href = baseURL + "/jsp/wap/diary/add.jsp?uncommitted=1&unSubmitNum=1";
                                }
                            })
                        }
                        //判断是否是补交日志
                        isUncommittedDiary();
                    }
                });
            }
        },
        error: function () {
            _alert("提示", internetErrorMsg, "确认");
        }
    });
}
//判断是否是补交日志
function isUncommittedDiary() {
    var personId;
    if (getParam("uncommitted") == 1) {
        $(".loadlast_onoff").hide();
        $(".ico-add").hide();
        if (getParam("unSubmitNum") == "1") {
            $.ajax({
                url: baseURL + "/portal/diaryAction!getAllUnSubmitByPerson.action",
                type: "post",
                dataType: "json",
                success: function (result) {
                    if ("0" == result.code) {
                        var list = result.data.pageDate.pageData;
                        var title = list[0].title;
                        var countDay = list[0].countDay.split(" ")[0];
                        personId = list[0].personId;
                        if (title != "") {
                            title = title.replace("xxx", userName).replace("yyyyMMdd", new Date(countDay).Format("yyyyMMdd"));
                            $("#title").val(title);
                        }
                        $("#taskType").val(list[0].diaryId).attr("disabled", "disabled").css({
                            "background": "#f5f5f5",
                            "color": "#999"
                        });
                        $("#currentDate").val(new Date(countDay).Format("yyyy-MM-dd"));
                        setUserMsg(personId);
                    }
                }
            })
        } else {
            personId = getParam("personId");
            $("#currentDate").val(getParam("countDay"));
            $("#title").val(getParam("diaryTitle"));
            $("#taskType").val(getParam("diaryId")).attr("disabled", "disabled").css({
                "background": "#f5f5f5",
                "color": "#999"
            });
            setUserMsg(personId);
        }
    }
}
function setUserMsg(personId) {
    if ($("#taskType").val() == "") {
        _alert("提示", "无法使用该日志类型模板，请联系管理员添加进使用范围", "确认");
    }
    $.ajax({
        url: baseURL + "/portal/contactAction!ajaxGetUserInfoByUserId.action",
        type: "get",
        data: {userId: personId},
        success: function (result) {
            var data = JSON.parse(result);
            if (data.code == "0") {
                var personMsg = data.data.userInfo;
                selectConfig.toPersonList.userSelected.length = 1;
                var template = ''
                    + '<ul class="clearfix"><li>'
                    + '<input type="hidden" name="incharges" value="@userId">'
                    + '    <p class="img"> '
                    + '        <img src="@HeadPic" alt="" /> '
                    + '    </p> '
                    + '    <p class="name">@UserName</p> '
                    + '</li></ul>';
                if (personMsg.headPic == 0) {
                    template = template.replace("@HeadPic", baseURL + '/jsp/wap/images/img/touxiang02.png');
                } else {
                    template = template.replace("@HeadPic", personMsg.headPic);
                }
                template = template.replace("@userId", personMsg.userId);
                template = template.replace("@UserName", personMsg.personName);
                $("#toPersonList").prepend(template);

            }
        }
    })
}
function showDelete(obj) {
    $($(obj).find("a")[0]).toggle();
}
function autoInput(value) {
    var template = templateMap.get(value);
    if (!template) {
        return;
    }
    isPhoto = template.isPhoto;
    var title = template.title.replace("xxx", userName).replace("yyyyMMdd", new Date().Format("yyyyMMdd"));
    $("#title").val(title);
    var content = $("#content").val();
    if (!content) {
        $("#content").val(template.content)
    } else {
        if (!!template.content) {
            _alert("提示", "是否用[" + template.name + "]的模板内容替换正文内容？", "不替换|替换",
                {
                    'ok': function (json) {
                        $("#content").val(template.content)
                    },
                    'fail': function () {
                        $("#showMsg_div").hide();
                        $(".overlay").hide();
                    }
                });
        }
    }
    $("#content").trigger('click');
    $("#content").focus();
    var defaultCclist = template.defaultCclist;
    if (defaultCclist && defaultCclist.length > 0) {
        selectConfig.ccPersonList.userSelected.length = 0;
        for (var i = 0; i < defaultCclist.length; i++) {
            selectConfig.ccPersonList.userSelected.push(defaultCclist[i])
        }
    }
}

var selectConfig = {
    "toPersonList": {
        "selectType": "user",
        "userName": "incharges",
        "userSelected": [],
        "callBack": {
            "confirm": null
        }
    },
    "ccPersonList": {
        "selectType": "user",
        "userName": "relatives",
        "userSelected": [],
        "callBack": {
            "confirm": null
        }
    }
}

var isSummary = getParam("isSummary");
//因为init()方法里需要加载agentCode,而上传图片需要设置agentCode,所以这个必须在uploadImage.jsp之前
$(document).ready(function () {
    agentCode_to = "diary";
    agentCode_cc = "diary";
    showLoading();
    init();

    if (isSummary == "1") {
        var ids = sessionStorage.getItem("diaryIds");
        sessionStorage.removeItem("diaryIds");
        $.ajax({
            url: baseURL + "/portal/diaryAction!summaryDiaries.action",
            type: "post",
            data: {
                "ids": ids
            },
            dataType: "json",
            traditional: true,
            success: function (result) {
                if (result.code == "0") {
                    var diaryList = result.data.summaryDiaryList;
                    var targetStr = "";
                    for (var i = 0; i < diaryList.length; i++) {
                        var isLast = (i != diaryList.length - 1) ? "\r\n" : "";
                        targetStr += diaryList[i].title + "\r\n" + diaryList[i].content + isLast;
                    }
                    var oldContent = sessionStorage.getItem("oldContent");
                    sessionStorage.removeItem("oldContent");
                    if (oldContent != "" && oldContent != null) {
                        targetStr = oldContent + "\r\n" + targetStr;
                    }
                    $("#content").val(targetStr);
                    $('textarea.inputStyle').trigger('click');
                    hideLoading();
                } else {
                    hideLoading();
                    _alert("提示", result.desc, "确认");
                }
            },
            error: function () {
                hideLoading();
                _alert("提示", internetErrorMsg, "确认");
            }
        });
    } else {
        hideLoading();
    }

    makeSelectEnt("ccPersonList");
    if (!getParam("uncommitted")) {
        makeSelectEnt("toPersonList");
    }

    //点击加载上一次负责人
    $('#onOff2').click(function () {
        if ($(this).attr('class') == 'onOff') {
            $(this).attr('class', 'onOff_on');
            $(this).children('.onOff_off').addClass('active');
            $("#toSelectId").val("1");
            selectFormCcOrTo("0");//0表示负责人
        } else {
            $(this).attr('class', 'onOff');
            $(this).children('.onOff_off').removeClass('active');
            $("#toSelectId").val("0");

            selectConfig.toPersonList.userSelected.splice(0);
        }
    });
    //点击加载上一次相关人
    $('#onOff3').click(function () {
        if ($(this).attr('class') == 'onOff') {
            $(this).attr('class', 'onOff_on');
            $(this).children('.onOff_off').addClass('active');
            $("#ccSelectId").val("1");
            selectFormCcOrTo("1");//1表示相关人
        } else {
            $(this).attr('class', 'onOff');
            $(this).children('.onOff_off').removeClass('active');
            $("#ccSelectId").val("0");

            selectConfig.ccPersonList.userSelected.splice(0);
        }
    });
});

function summaryMy(type, status) {
    // type=1 status=1 ->我发起的-已提交日志
    // type=2 status=3 ->相关日志- 我负责的
    var content = $("#content").val();
    sessionStorage.setItem("oldContent", content);
    window.location.href = "list.jsp?isSummary=1&from=add&status=" + status + "&type=" + type;
}