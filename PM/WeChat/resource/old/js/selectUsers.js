//定义部门人员数组
var alldepts = [];
var allusers = [];
//测试数据（部门）
// alldepts.push({id:"2",name:"开发部",fid:"1"});
// alldepts.push({id:"3",name:"测试部",fid:"2"});
// alldepts.push({id:"4",name:"销售部",fid:"3"});
// alldepts.push({id:"5",name:"运营部",fid:"4"});
// alldepts.push({id:"6",name:"维护部",fid:"2"});
// alldepts.push({id:"7",name:"人事部",fid:"1"});
// alldepts.push({id:"8",name:"财务部",fid:"1"});
//测试数据（人员）
// allusers.push({dept:"1",first:"Z",id:"1",name:"张三",tel:"13804093570",url:"http://p.qlogo.cn/bizmail/uqibPEIicNrjEErw2dcgln6868Micl38EWF1VfWlQOcHgQUEJE2D26lmA/100"});
// allusers.push({dept:"2",first:"L",id:"2",name:"李四",tel:"13804093571",url:"http://p.qlogo.cn/bizmail/uqibPEIicNrjEErw2dcgln6868Micl38EWF1VfWlQOcHgQUEJE2D26lmA/100"});
// allusers.push({dept:"2",first:"W",id:"3",name:"王五",tel:"13804093572",url:"http://p.qlogo.cn/bizmail/uqibPEIicNrjEErw2dcgln6868Micl38EWF1VfWlQOcHgQUEJE2D26lmA/100"});
// allusers.push({dept:"3",first:"Z",id:"4",name:"赵六",tel:"13804093573",url:"http://p.qlogo.cn/bizmail/uqibPEIicNrjEErw2dcgln6868Micl38EWF1VfWlQOcHgQUEJE2D26lmA/100"});
// allusers.push({dept:"4",first:"Q",id:"5",name:"青野",tel:"13804093574",url:"http://p.qlogo.cn/bizmail/uqibPEIicNrjEErw2dcgln6868Micl38EWF1VfWlQOcHgQUEJE2D26lmA/100"});
//定义部门人员数组
//初始化人员列表
var words=["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
function allUsers(){
    var allusershtml = "";
    for(var i=0;i<words.length;i++){
        var flag = true;
        for(var j=0;j<allusers.length;j++) {
            if(allusers[j].first==words[i]){
                allusershtml +="<div class=\"settings-item\">";
                if(flag){
                    allusershtml +="<div class=\"letter_bar\" style=\"padding: 0px 15px;\">"+words[i]+"</div>";
                }
                allusershtml +="<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                    "<div class=\"user_select_icon ccuser_select_icon active\">" +
                    "<label><input type=\"checkbox\" name=\"checkUsers\" value=\""+allusers[j].id+"\" userName=\""+allusers[j].name+"\" url=\""+allusers[j].url+"\"><span></span></label>" +
                    "</div>" +
                    "<div class=\"avator\">"     +
                    "<img src=\""+allusers[j].url+"\"" +
                    " alt=\"\">" +
                    "</div>" +
                    "<div class=\"title flexItem\">" +
                    "<p class=\"name\">"+allusers[j].name+"</p>" +
                    "</div>" +
                    "</div>";
                allusershtml+="</div>";
                flag = false;
            }
        }
    }
    $("#allUsers").html(allusershtml);
}
//初始化人员列表
//初始化部门列表
function allDepts(fid){
    if(!fid){
        fid=1;
    }
    var mbxhtml="";
    var folderCount = getDeptIdByFidCount(fid,1);
    if(folderCount==2){
        mbxhtml="<div class=\"itemTitle bottom_boder clearfix\">" +
            "<div class=\"fl\" style=\"width: 35px;\">" +
            "<span class=\"fl cblue\" onclick='allDepts(1)'>全部</span>" +
            "</div>"+getDeptIdByFid(fid,"")+"</div>";
    }
    if(folderCount==3){
        mbxhtml = "<div class=\"itemTitle bottom_boder clearfix\">" +
            "<div class=\"fl\" style=\"width: 120px;\">" +
            "<span class=\"fl cblue\" onclick='allDepts(1)'>全部&nbsp;&gt;</span>" +
            "<span class=\"fl\">" +
            "<span class=\"cblue\" onclick=\"backdept("+fid+")\">&nbsp;返回上一级</span>" +
            "</span>" +
            "</div>"+getDeptIdByFid(fid,"")+"</div>";
    }
    if(folderCount>3){
        mbxhtml = "<div class=\"itemTitle bottom_boder clearfix\">" +
            "<div class=\"fl\" style=\"width: 150px;\">" +
            "<span class=\"fl cblue\" onclick='allDepts(1)'>全部</span>" +
            "<span class=\"fl\">" +
            "<span class=\"lh20 c999 ml5\">&gt; ... &gt; </span>" +
            "<span class=\"cblue\" onclick=\"backdept("+fid+")\">返回上一级</span>" +
            "</span>" +
            "</div>"+getDeptIdByFid(fid,"")+"</div>";
    }
    hid=fid;
    var alldeptshtml = mbxhtml;
    for(var i=0;i<alldepts.length;i++) {
        if(alldepts[i].fid==fid){//获取子部门
            var countDept=0;
            var countUser=0;
            for(var j=0;j<alldepts.length;j++) {//获取子部门数量
                if(alldepts[j].fid==alldepts[i].id){
                    countDept++;
                }
            }
            for(var k=0;k<allusers.length;k++) {//获取子人员数量
                if(allusers[k].dept==alldepts[i].id){
                    countUser++;
                }
            }
            alldeptshtml +="<div class=\"settings-item\"><a class=\"rightLink\">&gt;</a>" +
                "<div class=\"inner-settings-item-dept flexbox\" onclick=\"allDepts("+alldepts[i].id+")\" style=\"cursor: pointer;\">" +
                "<div class=\"avator org\"><img src=\"../wxqyh/images/aa.jpg\" alt=\"\"></div>" +
                "<div class=\"title flexItem\"><p class=\"lh20\">"+alldepts[i].name+"</p>" +
                "<p class=\"lh20 fz13 c999\">("+countDept+")部门,("+countUser+")人员</p></div>" +
                "</div>" +
                "</div>";
        }
    }
    for(var i=0;i<allusers.length;i++) {
        if(allusers[i].dept==fid){//获取部门人员
            alldeptshtml +="<div class=\"settings-item\">" +
                "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"checkUsers\" value=\""+allusers[i].id+"\" userName=\""+allusers[i].name+"\" url=\""+allusers[i].url+"\"><span></span></label></div>" +
                "<div class=\"avator\">" +
                "<img src=\""+allusers[i].url+"\" alt=\"\">" +
                "</div>" +
                "<div class=\"title flexItem\"><p class=\"name\">"+allusers[i].name+"</p></div>" +
                "</div>" +
                "</div>";
        }
    }
    $("#allDepts").html(alldeptshtml);
}
function getDeptIdByFid(fid,mbx){
    for (var i = 0;i<alldepts.length;i++){
        if(alldepts[i].id==fid){
            mbx="<div class=\"ellipsis2 c999\">&gt; "+alldepts[i].name+"</div>";
            return mbx;
        }
    }
    return mbx;
}
function getDeptIdByFidCount(fid,count){
    for (var i = 0;i<alldepts.length;i++){
        if(alldepts[i].id==fid){
            count++;
            return getDeptIdByFidCount(alldepts[i].fid,count);
        }
    }
    return count;
}
function backdept(fid){
    for (var i = 0;i<alldepts.length;i++){
        if(alldepts[i].id==fid){
            allDepts(alldepts[i].fid);
        }
    }
}
//初始化部门列表
//搜索人员
var type="ry";
var hid=1;
var firstword="";
$("#search").click(function(){
    if(firstword!=""&&firstword!=null){//判断是否按首字母查询
        searchUsers(firstword,"first");
    }else{
        var search = $(".search_input").val();//获取搜索框的值
        if(search==''||search==null){//搜索全部
            searchUsers(search,"all");
        }else{
            var reNum=/^\d*$/;//判断输入是否为数字正则表达式
            if(reNum.test(search)){//如果是数字按手机号处理
                searchUsers(search,"tel");
            }else {//如果非数字按姓名处理
                searchUsers(search,"name");
            }
        }
    }
});
function searchUsers(str,tp){//参数str搜索字符串，type为搜索类型
    //字符串方法indexOf
    var len = allusers.length;
    var searchResultHtml="";
    if(type=='bm'){
        if(tp=='tel'){
            for(var i=0;i<len;i++){
                //如果字符串中不包含目标字符会返回-1
                if((allusers[i].tel+"").indexOf(str)>=0&&allusers[i].dept==hid){
                    searchResultHtml+="<div class=\"settings-item\">" +
                        "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                        "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\""+allusers[i].id+"\"><span></span></label></div>" +
                        "<div class=\"avator\">" +
                        "<img src=\""+allusers[i].url+"\" alt=\"\">" +
                        "</div>" +
                        "<div class=\"title flexItem\"><p class=\"name\">"+allusers[i].name+"</p></div>" +
                        "</div>" +
                        "</div>";
                }
            }
        }
        if(tp=='name'){
            for(var i=0;i<len;i++){
                //如果字符串中不包含目标字符会返回-1
                if((allusers[i].name).indexOf(str)>=0&&allusers[i].dept==hid){
                    searchResultHtml+="<div class=\"settings-item\">" +
                        "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                        "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\""+allusers[i].id+"\"><span></span></label></div>" +
                        "<div class=\"avator\">" +
                        "<img src=\""+allusers[i].url+"\" alt=\"\">" +
                        "</div>" +
                        "<div class=\"title flexItem\"><p class=\"name\">"+allusers[i].name+"</p></div>" +
                        "</div>" +
                        "</div>";
                }
            }
        }
        if(tp=='all'){
            for(var i=0;i<len;i++){
                if(allusers[i].dept==hid){
                    //如果字符串中不包含目标字符会返回-1
                    searchResultHtml+="<div class=\"settings-item\">" +
                        "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                        "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\""+allusers[i].id+"\"><span></span></label></div>" +
                        "<div class=\"avator\">" +
                        "<img src=\""+allusers[i].url+"\" alt=\"\">" +
                        "</div>" +
                        "<div class=\"title flexItem\"><p class=\"name\">"+allusers[i].name+"</p></div>" +
                        "</div>" +
                        "</div>";
                }
            }
        }
        if(tp=='first'){
            for(var i=0;i<len;i++){
                //如果字符串中不包含目标字符会返回-1
                if(allusers[i].first==str&&allusers[i].dept==hid) {
                    searchResultHtml += "<div class=\"settings-item\">" +
                        "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                        "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\"" + allusers[i].id + "\"><span></span></label></div>" +
                        "<div class=\"avator\">" +
                        "<img src=\"" + allusers[i].url + "\" alt=\"\">" +
                        "</div>" +
                        "<div class=\"title flexItem\"><p class=\"name\">" + allusers[i].name + "</p></div>" +
                        "</div>" +
                        "</div>";
                }
            }
        }
    }else{
        if(tp=='tel'){
            for(var i=0;i<len;i++){
                //如果字符串中不包含目标字符会返回-1
                if((allusers[i].tel+"").indexOf(str)>=0){
                    searchResultHtml+="<div class=\"settings-item\">" +
                        "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                        "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\""+allusers[i].id+"\"><span></span></label></div>" +
                        "<div class=\"avator\">" +
                        "<img src=\""+allusers[i].url+"\" alt=\"\">" +
                        "</div>" +
                        "<div class=\"title flexItem\"><p class=\"name\">"+allusers[i].name+"</p></div>" +
                        "</div>" +
                        "</div>";
                }
            }
        }
        if(tp=='name'){
            for(var i=0;i<len;i++){
                //如果字符串中不包含目标字符会返回-1
                if((allusers[i].name).indexOf(str)>=0){
                    searchResultHtml+="<div class=\"settings-item\">" +
                        "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                        "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\""+allusers[i].id+"\"><span></span></label></div>" +
                        "<div class=\"avator\">" +
                        "<img src=\""+allusers[i].url+"\" alt=\"\">" +
                        "</div>" +
                        "<div class=\"title flexItem\"><p class=\"name\">"+allusers[i].name+"</p></div>" +
                        "</div>" +
                        "</div>";
                }
            }
        }
        if(tp=='all'){
            for(var i=0;i<len;i++){
                //如果字符串中不包含目标字符会返回-1
                searchResultHtml+="<div class=\"settings-item\">" +
                    "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                    "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\""+allusers[i].id+"\"><span></span></label></div>" +
                    "<div class=\"avator\">" +
                    "<img src=\""+allusers[i].url+"\" alt=\"\">" +
                    "</div>" +
                    "<div class=\"title flexItem\"><p class=\"name\">"+allusers[i].name+"</p></div>" +
                    "</div>" +
                    "</div>";
            }
        }
        if(tp=='first'){
            for(var i=0;i<len;i++){
                //如果字符串中不包含目标字符会返回-1
                if(allusers[i].first==str) {
                    searchResultHtml += "<div class=\"settings-item\">" +
                        "<div class=\"inner-settings-item flexbox\" onclick='rowsChecked(this)'>" +
                        "<div class=\"user_select_icon ccuser_select_icon\"><label><input type=\"checkbox\" name=\"searchUsers\" value=\"" + allusers[i].id + "\"><span></span></label></div>" +
                        "<div class=\"avator\">" +
                        "<img src=\"" + allusers[i].url + "\" alt=\"\">" +
                        "</div>" +
                        "<div class=\"title flexItem\"><p class=\"name\">" + allusers[i].name + "</p></div>" +
                        "</div>" +
                        "</div>";
                }
            }
        }
    }
    $("#searchResult").html(searchResultHtml);
    if(searchResultHtml.length>0){//搜索结果有数据时
    }else{//搜索结果无数据时
        $("#noSearchResult").show();
    }
    firstword="";//查询完毕清空首字母
}
$(".icon_del").click(function(){//搜索框删除按钮点击函数
    $(".search_input").val("");
});
//首字母过滤部分
$(".search_letter_btn").click(function (){
    var firstDiv = $(this).next();
    if(firstDiv.css("display")=='none'){
        firstDiv.show();
    }else{
        firstDiv.hide();
    }
    $("ul li a").click(function (){
        if($(this).html()=="*"){
            $(".search_button").click();
            $("#search").click();
        }else{
            firstword = $(this).html();
            $(".search_button").click();
            $("#search").click();
        }
        firstDiv.hide();
    });
});

//首字母过滤部分
//搜索人员
//定义已选中人员数组
var checkedAllUsers=[];
//定义已选中人员数组
$(".search_button").click(function (){
    $("#searchUsers").show();
    $("#checkUsers").hide();
    //查询页面初始化清空上一次待选项和搜索内容
    $("#searchResult").html("");
    $(".search_input").val("");
    $("#noSearchResult").hide();
    //查询页面初始化清空上一次待选项和搜索内容
});
$("#selectCheckedOk").click(function (){//搜索人员并选择完成时点击确定按钮执行函数
    $("#searchUsers").hide();//隐藏搜索页面
    $("#checkUsers").show();//显示字母排序页面
    checkedSearchedUsersOk();//执行搜索页面选择完成事件函数
    changeUsersArray();//执行选中人员数组添加函数
});
function changeUsersArray(){
    $("input[name='checkUsers']").each(function () {
        var userid = $(this).val();
        var userName = $(this).attr("userName");
        var url = $(this).attr("url");
        if($(this).prop("checked")){
            checkedAllUsers.push({id:userid,name:userName,url:url});
            checkedAllUsers=uniquexxx(checkedAllUsers);
        }else{
            for (var i=0;i<checkedAllUsers.length;i++){
                if(checkedAllUsers[i].id==userid){
                    checkedAllUsers.splice(i,1);
                }
            }
        }
    });
    checkedAllUsers=uniquexxx(checkedAllUsers);
       console.log(checkedAllUsers);
    addChangeChecked();
}
function addChangeChecked(){
    //添加选中人员和人数效果
    var allCheckedHtml="";
    if(checkedAllUsers.length==1){
        allCheckedHtml="<p class=\"c999 fz12\">已选择</p>" +
            "<p class=\"cblue fz14\">" +
            "<span>"+checkedAllUsers[0].name+"</span>" +
            "</p>";
    }else if(checkedAllUsers.length>1){
        allCheckedHtml="<p class=\"c999 fz12\">已选择</p>" +
            "<p class=\"cblue fz14\">" +
            "<span>"+checkedAllUsers.length+"人</span>" +
            "</p>";
    }
    $("#checked").html(allCheckedHtml);
    //添加选中人员和人数效果
}
function uniquexxx(array) {//数组去重复
    var r = [];
    for(var i = 0, l = array.length; i < l; i++) {
        for(var j = i + 1; j < l; j++)
            if (array[i].id == array[j].id||array[i].id.toString() == array[j].id.toString()) j = ++i;
        r.push(array[i]);
    }
    return r;
}
function checkedSearchedUsersOk(){//搜索页面选择完成执行函数
    $("input[name='searchUsers']:checked").each(function () {
        var userId = $(this).val();
        $("input[name='checkUsers'][value='"+userId+"']").prop("checked",true);
    });
}
//添加整行选中效果
function rowsChecked(e){
    var ckbx = $(e).find("input[type='checkbox']");
    if(ckbx.prop("checked")){
        ckbx.prop("checked",false);
    }else{
        ckbx.prop("checked",true);
    }
    if(ckbx.attr("name")=="checkUsers"){//判断是否是有效选择checkbox变动
        changeUsersArray();
    }
}
//变更选择方式
function changeType(e,t){
    if(t=='bm'){
        $('#depts').show();
        $('#users').hide();
        $(e).hide();
        $(e).next().show();
        $('#allDepts').html("");
        $('#allUsers').html("");
        allDepts();
        type="bm";
        checkedAllUsers=[];//清空选人数组
        addChangeChecked();
    }
    if(t=='ry'){
        $('#users').show();
        $('#depts').hide();
        $(e).hide();
        $(e).prev().show();
        $('#allDepts').html("");
        $('#allUsers').html("");
        allUsers();
        type="ry";
        checkedAllUsers=[];//清空选人数组
        addChangeChecked();
    }
}
$(function () {
    allUsers();
});
//触发选人模块
var selectType="";
function selectUsers(t){
    selectType=t;
    if(selectType=="syr"){
        $("input[name='checkUsers']").prop("checked",false);
        checkedAllUsers=[];
        $(".remove_icon_syr").each(function () {
            var syrId = $(this).attr("id");
            $("input[name='checkUsers'][value='"+syrId+"']").prop("checked",true);
            for(var i=0;i<allusers.length;i++){
                if(allusers[i].id==syrId){
                    checkedAllUsers.push({id:allusers[i].id,name:allusers[i].name,url:allusers[i].url});
                }
            }
        });
    }
    if(selectType=="xgr"){
        $("input[name='checkUsers']").prop("checked",false);
        checkedAllUsers=[];
        $(".remove_icon_xgr").each(function () {
            var xgrId = $(this).attr("id");
            $("input[name='checkUsers'][value='"+xgrId+"']").prop("checked",true);
            for(var i=0;i<allusers.length;i++){
                if(allusers[i].id==xgrId){
                    checkedAllUsers.push({id:allusers[i].id,name:allusers[i].name,url:allusers[i].url});
                }
            }
        });
    }
    addChangeChecked();
    $("#main").hide();
    $("#usersSelect").show();
}
//选择人员完成时
function okChecked(){
    if(checkedAllUsers.length>0){
        var okhtml="";
        var syrForSubmit="";
        var xgrForSubmit="";
        for(var i=0;i<checkedAllUsers.length;i++){
            var classa = "remove_icon";
            if(selectType=="syr"){
                syrForSubmit+=checkedAllUsers[i].id+",";
                classa="remove_icon_syr";
            }
            if(selectType=="xgr"){
                syrForSubmit+=checkedAllUsers[i].id+",";
                classa="remove_icon_xgr";
            }
            okhtml+="<li>" +
                        "<a class=\""+classa+"\" onclick=\"deleteOne(this)\" id=\""+checkedAllUsers[i].id+"\" style=\"display: inline;\"></a>" +
                        "<p class=\"img\">" +
                        "<img src=\""+checkedAllUsers[i].url+"\" alt=\"\">" +
                        "</p>" +
                        "<p class=\"name\">"+checkedAllUsers[i].name+"</p>" +
                    "</li>";
            }
            if(syrForSubmit.length>0){
                syrForSubmit=syrForSubmit.substring(0,syrForSubmit.length-1);
            }
            if(xgrForSubmit.length>0){
                xgrForSubmit=xgrForSubmit.substring(0,xgrForSubmit.length-1);
            }
            if(selectType=="syr"){
                okhtml+="<li class=\"ico-add\" onclick=\"selectUsers('syr')\"></li>";
                okhtml+="<input type=\"hidden\" name=\"syr\" value='\""+syrForSubmit+"\"'>";
                $("#syrUl").html(okhtml);
            }
            if(selectType=="xgr"){
                okhtml+="<li class=\"ico-add\" onclick=\"selectUsers('xgr')\"></li>";
                okhtml+="<input type=\"hidden\" name=\"xgr\" value='\""+xgrForSubmit+"\"'>";
                $("#xgrUl").html(okhtml);
            }
        }
    $("#main").show();
    $("#usersSelect").hide();
}
//选择人员取消时
function closeChecked(){
    // checkedAllUsers=[];//清空已选人员数组
    $("#main").show();
    $("#usersSelect").hide();
}
//选人完成时点击删除图标触发删除单个人员函数
function deleteOne(e){
    $(e).parent().remove();
}