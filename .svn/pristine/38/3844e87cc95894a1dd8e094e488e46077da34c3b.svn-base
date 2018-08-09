/**
 * Created by linyue on 2017/8/7.
 */
if(!_userOrDept_select){
    var _userOrDept_select = null;
}
function openSelectUser(el,config,callBack){
    if(!_userOrDept_select){
        _userOrDept_select = new userOrDept_select();
    }
    _userOrDept_select.changeConfig(el,config[el]);
    var index = 0;
    $(".wrap").each(function(i){
        if(!$(this).is(":hidden")){
            index = i;
            return false;
        }
    });
    _userOrDept_select.configData.demoIndex = index;
    $("#userOrDept_select").show();
    $(".wrap").eq(index).hide();
    if(callBack){callBack();}
}


function userOrDept_select(){
    var _this = this;
    this.vue = null;
    this.actions = {//接口
        "loadDeptUrl":"/portal/departmentAction!getChildDept.action",//部门
        "searchTagPage":"/portal/tagAction!searchTagPage.action",//常用群组和标签
        "getCommonList":"/portal/selectUserAction!getCommonList.action",//常用联系人
        "userList":"/portal/selectUserAction!ajaxGetUserListByOrgID.action",//按字母顺序的人员数据
        "deptAndUser":"/portal/departmentAction!getChildDeptAndPerson.action",//按组织获取人员数据及子部门
        "getUserForTag":"/portal/tagAction!searchTagGroupRefPage.action",//获取标签下的人员数据
        "getUserForGroup":"/portal/selectUserAction!getUserGroupPerson.action",//获取群组下的人员数据
        "keyWordSearch":"/portal/selectUserAction!searchByNameOrPhone.action",//拼音/手机/名字搜索人员
        "letterSearch":"/portal/selectUserAction!searchFirstLetter.action",//头字母搜索
    };
    this.configData = {
        "selectType":'',
        "tab":{
            "active":"group",
            "group":{
                show:true
            },
            "user":{
                show:true
            },
            "dept":{
                show:true
            },
            "len":3
        },
        //选人上限(选配，不配置默认1000，配1为单选)
        "userRestriction":1000,
        //选部门上限(选配，不配置默认500，配1为单选)
        "deptRestriction":500,
        //标签列表显示
        "tagShow":false,
        //常用群组列表显示
        "groupShow":false,
        //结果页显示隐藏
        "resultDemo":false,
        //选择结果页
        "resultShow":false,
        //字母搜索列表
        letterList:false,
        //搜索数据
        "searchData":{
            //接口
            "url":'',
            //输入框关键字
            "keyWord":'',
            //入参关键字
            "searchKeyWord":'',
            //结果数据
            "data":[],
            //当前页数
            "page":1,
            //最大页数
            "maxPage":1,
            //阻止多次请求
            "lock_roll":false,
            //输入框是否失焦
            "focus":false
        },
        //人员组织结构和按字母排序互相切换
        "userStructure":1,//1:按字母；2:按组织结构
        //常用列表数据
        "groupData":{

        },
        //标签列表数据
        "tagData":{

        },
        //常用联系人
        "commonList":{
            "data":[]
        },
        //范围选人数据
        "rangData":{
            "data":[]
        },
        //按字母顺序的人员数据
        "userList":{
            "data":[],
            "page":1,
            "maxPage":1,
            "lock_roll":false
        },
        //组织选人数据
        "orgUserList":{
            //数据缓存
            "cacheData":{},
            //第一级数据
            "firstOrg":null,
            //上一级id
            "upperLevel":[],
            //当前部门id
            "deptId":'',
            //当前部门名称
            "deptName":'',
            //组织选人当前部门数据
            "deptList_d":[],
            //组织选人当前人员数据
            "userList_d":[],
        },
        "deptList":{
            //数据缓存
            "cacheData":{},
            //第一级数据
            "firstOrg":null,
            //上一级id
            "upperLevel":[],
            //当前部门id
            "deptId":'',
            //当前部门名称
            "deptName":'',
            //当前部门数据
            "data":[]
        },
        //已选群组标签
        "groupDataSelected":{
            "data":{},
            "idStr":''
        },
        //已选人员
        "userSelected":{
            "data":[],
            "idStr":''
        },
        //已选部门
        "deptSelected":{
            "data":[],
            "idStr":''
        },
        //字母数组
        "letter":["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "*"],
        //回调
        "callBack":{
            "confirm":null,
            "close":null
        },

        //当前第几个页面是显示的
        "demoIndex":0,
        //当前选人节点id
        "el":''
    };
    var htmlTemp = '<div id="userOrDept_select" class="userOrDept_select none" @click="closeLetterList($event)"><div class="wrap" v-show="!resultDemo">'+
        '<div class="selectTab bottom_boder flexbox" v-if="tab.len!=1" @click="switchTab($event)">'+
        '   <div class="selectTab_item flexItem" :class="{active:tab.active==\'group\'}" dataType = "group" v-if="tab.group.show">常用</div>'+
        '   <div class="selectTab_item flexItem" :class="{active:tab.active==\'user\'}" dataType = "user" v-if="tab.user.show">人员</div>'+
        '   <div class="selectTab_item flexItem" :class="{active:tab.active==\'dept\'}" dataType = "dept" v-if="tab.dept.show">部门</div>'+
        '</div>'+
        '<div id="userOrDept_select_s" class="wrap_inner">'+
        '   <div class="search_box_height" v-if="tab.len>1"></div>'+
        '   <div class="selectMain">'+
        '      <div class="selectMain_item" v-show="tab.active==\'group\'">' +
        '          <div class="itemTitle bottom_boder c999" @click="tagShowFunc">标签(<span>{{tagData.length}}</span>)<i class="icon-slide" :class="tagShow?\'icon-slideUp\':\'icon-slideDown\'"></i></div>' +
        '          <mb-tagdata v-show="tagShow" :message="tagData" :selectdata="groupDataSelected" :userselected="userSelected">' +
        '          </mb-tagdata>'+
        '          <div class="itemTitle bottom_boder c999" @click="groupShowFunc">常用群组(<span>{{groupData.length}}</span>)<i class="icon-slide" :class="groupShow?\'icon-slideUp\':\'icon-slideDown\'"></i></div>' +
        '          <mb-groupdata v-show="groupShow" :message="groupData" :selectdata="groupDataSelected" :userselected="userSelected">' +
        '          </mb-groupdata>'+
        '          <div class="itemTitle bottom_boder c999">常用联系人</div>' +
        '          <mb-commonlist :message="commonList.data" :selectdata="groupDataSelected" :userselected="userSelected"></mb-commonlist>' +
        '      </div>'+
        '      <div class="selectMain_item" v-show="tab.active==\'user\'">' +
        '          <div class="selectSearch bottom_boder flexbox">' +
        '              <div class="search_button" @click="showSearch">'+
        '                  <i class="icon_search"></i>'+
        '                  <span>姓名/拼音/手机号</span>'+
        '              </div>' +
        '              <div class="search_more" @click="letterListShow">'+
        '                   <a id="ccletter_search" href="#" class="search_letter_btn"><i class="ic_letterList"></i></a>'+
        '                   <div class="letter_list" v-show="letterList" style="z-index: 9;top:44px">'+
        '                       <ul class="clearfix">'+
        '                           <li v-for="item in letter" @click="letterSearch(item)"><a>{{item}}</a></li>'+
        '                       </ul>'+
        '                   </div>'+
        '              </div>' +
        '          </div>'+
        '          <div class="itemTitle bottom_boder bgfff ku_right fz16" style="line-height: 45px;" v-if="selectType!=\'onlyUser\'" @click="controlUserStructure">{{userStructure==1?\'按组织架构选人\':\'按成员名称选人\'}}</div>' +
        '          <div class="" v-show="userStructure==1">' +
        '               <mb-userlist-h  :message="userList.data" :selectdata="groupDataSelected" :userselected="userSelected"></mb-userlist-h>' +
        '          </div>' +
        '          <div class="" v-show="userStructure==2">' +
        '               <div class="itemTitle bottom_boder clearfix" v-if="orgUserList.upperLevel.length!=0">' +
        '                   <div class="fl" :style="{width:orgUserList.upperLevel[orgUserList.upperLevel.length-1].id!=\'\'?\'150px\':\'30px\'}">' +
        '                       <span class="fl cblue" @click="userStructureInit(\'\')">全部</span>' +
        '                       <span class="fl" v-if="orgUserList.upperLevel[orgUserList.upperLevel.length-1].id!=\'\'" @click="goBack_user(orgUserList.upperLevel)">' +
        '                          <span class="lh20 c999 ml5">&gt; ... &gt; </span>' +
        '                          <span class="cblue">返回上一级</span>' +
        '                       </span>' +
        '                   </div>' +
        '                   <div class="ellipsis2 c999" v-show="orgUserList.deptName">&gt; {{orgUserList.deptName}}</div>' +
        '               </div>' +
        '               <mb-deptlist-d  :message="orgUserList"></mb-deptlist-d>' +
        '               <mb-userlist-d  :message="orgUserList.userList_d" :selectdata="groupDataSelected" :userselected="userSelected"></mb-userlist-d>' +
        '               <p class="text-center c999 mt30 pt20" v-show="orgUserList.userList_d.length==0&&orgUserList.deptList_d==0">无更多联系人信息</p>' +
        '          </div>' +
        '      </div>'+
        '      <div class="selectMain_item" v-show="tab.active==\'dept\'">' +
        '           <div class="itemTitle bottom_boder clearfix" v-if="deptList.upperLevel.length!=0">' +
        '               <div class="fl" :style="{width:deptList.upperLevel[deptList.upperLevel.length-1].id!=\'\'?\'150px\':\'30px\'}">' +
        '                   <span class="fl cblue" @click="deptListInit(\'\')">全部</span>' +
        '                   <span class="fl" v-if="deptList.upperLevel[deptList.upperLevel.length-1].id!=\'\'" @click="goBack_dept(deptList.upperLevel)">' +
        '                      <span class="lh20 c999 ml5">&gt; ... &gt; </span>' +
        '                      <span class="cblue">返回上一级</span>' +
        '                   </span>' +
        '               </div>' +
        '               <div class="ellipsis2 c999" v-show="deptList.deptName">&gt; {{deptList.deptName}}</div>' +
        '           </div>' +
        '           <mb-deptlist :message="deptList" :deptselected="deptSelected"></mb-deptlist>' +
        '           <p class="text-center c999 mt30 pt20" v-show="deptList.data.length==0">无更多部门信息</p>' +
        '       </div>'+
        '       <div class="selectMain_item" v-show="tab.active==\'rang\'">' +
        '          <mb-rang :message="rangData.data" :selectdata="groupDataSelected" :userselected="userSelected"></mb-rang>'+
        '       </div>'+
        '   </div>'+
        '   <div class="footheight mt20"></div>'+
        '</div>'+
        '<div class="foot_bar foot_bar_user">'+
        '   <div class="foot_bar_inner flexbox">'+
        '      <div class="flexItem"><a class="btn qwui-btn_default" @click="cancel">取消</a></div>' +
        '      <div class="selected mt5" @click="showResult">' +
        '         <p class="c999 fz12" v-if="userSelected.data.length>0||deptSelected.data.length>0">已选择</p>' +
        '         <p class="cblue fz14">' +
        '            <span class="" v-if="userSelected.data.length>1">{{userSelected.data.length}}人</span>' +
        '            <span class="" v-if="userSelected.data.length==1">{{userSelected.data[0].personName}}</span>' +
        '            <span class="" v-if="userSelected.data.length>0&&deptSelected.data.length>0">,</span>' +
        '            <span class="" v-if="deptSelected.data.length>0">{{deptSelected.data.length}}部门</span>' +
        '         </p>' +
        '      </div>' +
        '      <div class="flexItem"><a class="btn fr" @click="confirm">确定</a></div>'+
        '   </div>'+
        '</div>' +
        '</div>'+
        '<div class="wrap" v-show="resultDemo">' +
        '   <div class="selectSearch bottom_boder flexbox selectSearchBox" v-show="!resultShow">' +
        '       <div class="search_outer">'+
        '            <div class="search_inner">'+
        '                <a @click="enterSearch"><i class="icon_search"></i></a>'+
        '                <a @click="clearInputVal"><i class="icon_del"></i></a>'+
        '                <input type="search" class="search_input" @keyup.enter="enterSearch" v-model="searchData.keyWord" v-focus="searchData.focus" placeholder="姓名/拼音/手机号" required="">'+
        '            </div>'+
        '       </div>' +
        '       <div class="search_more" @click="letterListShow">'+
        '            <a id="ccletter_search" href="#" class="search_letter_btn"><i class="ic_letterList"></i></a>'+
        '            <div class="letter_list" v-show="letterList" style="z-index: 9;top:44px">'+
        '                <ul class="clearfix">'+
        '                    <li v-for="item in letter" @click="letterSearch(item)"><a>{{item}}</a></li>'+
        '                </ul>'+
        '            </div>'+
        '       </div>' +
        '   </div>' +
        '<div id="userOrDept_select_r" class="wrap_inner">' +
        '   <div v-show="!resultShow"><div class="search_box_height"></div>' +
        '          <mb-loadsearch :message="searchData.data" :selectdata="groupDataSelected" :userselected="userSelected"></mb-loadSearch>'+
        '          <p class="text-center c999 mt30 pt20" v-show="searchData.data.length==0&&searchData.searchKeyWord!=\'\'">没有搜索到任何数据，换别的关键字试试</p>' +
        '   <div class="footheight"></div></div>' +
        '   <div class="f-add-user" v-show="resultShow">' +
        '   <div class="c999 pt10" v-if="userSelected.data.length>0||deptSelected.data.length>0">已选择' +
        '          <span class="" v-if="userSelected.data.length>1">{{userSelected.data.length}}人</span>' +
        '          <span class="" v-if="userSelected.data.length==1">{{userSelected.data[0].personName}}</span>' +
        '          <span class="" v-if="userSelected.data.length>0&&deptSelected.data.length>0">,</span>' +
        '          <span class="" v-if="deptSelected.data.length>0">{{deptSelected.data.length}}部门</span>' +
        '   </div>' +
        '       <mb-result :userselected="userSelected" :deptselected="deptSelected" :selectdata="groupDataSelected"></mb-result>' +
        '   <div class="footheight"></div></div>' +
        '</div>' +
        '   <div class="foot_bar foot_bar_result">' +
        '      <div class="foot_bar_inner flexbox">' +
        '         <a class="flexItem btn" @click="closeShowResult">确定</a>' +
        '      </div>' +
        '   </div>' +
        '</div>' +
        '</div>'
    $("body").append(htmlTemp);
    $("#userOrDept_select_s,#userOrDept_select_r").height($(window).height());
    var userTemp = '<div>' +
        '<div class="settings-item" v-for="(item, index) in message">' +
        '    <div class="inner-settings-item flexbox" @click="selectThis(item.userId)">' +
        '        <div class="user_select_icon ccuser_select_icon" :class="{active:userselected.idStr.indexOf(item.userId)!=-1}">' +
        '            <i class="fa"></i>' +
        '        </div>' +
        '        <div class="avator">' +
        '            <img :src="item.headPic==0?baseURL+\'/jsp/wap/images/img/touxiang02.png\':item.headPic" alt="">' +//
        '        </div>' +
        '        <div class="title flexItem">' +
        '            <p class="name">{{item.personName}}</p>' +
        '        </div>' +
        '    </div>' +
        '</div>'+
        '</div>';
    var userTemp_h = '<div>' +
        '<div class="settings-item" v-for="(item, index) in message">' +
        '<div class="letter_bar" style="padding: 0 15px" v-if="(message[index-1]&&item.pinyin.toUpperCase().substr(0, 1)!=message[index-1].pinyin.toUpperCase().substr(0, 1))||index==0">{{item.pinyin.toUpperCase().substr(0, 1)}}</div>' +
        '    <div class="inner-settings-item flexbox" @click="selectThis(item.userId)">' +
        '        <div class="user_select_icon ccuser_select_icon" :class="{active:userselected.idStr.indexOf(item.userId)!=-1}">' +
        '            <i class="fa"></i>' +
        '        </div>' +
        '        <div class="avator">' +
        '            <img :src="item.headPic==0?baseURL+\'/jsp/wap/images/img/touxiang02.png\':item.headPic" alt="">' +//
        '        </div>' +
        '        <div class="title flexItem">' +
        '            <p class="name">{{item.personName}}</p>' +
        '        </div>' +
        '    </div>' +
        '</div>'+
        '</div>';
    var groupTemp = '<div>' +
        '<div class="settings-item" v-for="item in message">' +
        '    <div class="inner-settings-item flexbox" @click="selectThis(item.id)">' +
        '       <div class="user_select_icon ccuser_select_icon" :class="{active:selectdata.idStr.indexOf(item.id)!=-1}">' +
        '           <i class="fa"></i>' +
        '       </div>' +
        '       <div class="avator org">' +
        '           <img src="'+baseURL+'/jsp/wap/images/img/aa.jpg" alt="">' +
        '       </div>' +
        '       <div class="title flexItem">' +
        '             <p class="name">{{item.tagName}}</p>' +
        '       </div>' +
        '    </div>' +
        '</div>'+
        '</div>';
    var resultTemp = '<ul class="f-add-user-list clearfix">' +
        '   <li v-for="item in deptselected.data">' +
        '        <a class="remove_icon" style="display: inline;" @click="selectThisDept(item.id)"></a>' +
        '        <p class="img">' +
        '            <img :src="baseURL+\'/jsp/wap/images/img/aa.jpg\'" alt="">' +
        '        </p>' +
        '        <p class="name">{{item.departmentName}}</p>' +
        '   </li>' +
        '   <li v-for="item in userselected.data">' +
        '        <a class="remove_icon" style="display: inline;" @click="selectThisUser(item.userId)"></a>' +
        '        <p class="img">' +
        '            <img :src="item.headPic==0?baseURL+\'/jsp/wap/images/img/touxiang02.png\':item.headPic" alt="">' +
        '        </p>' +
        '        <p class="name">{{item.personName}}</p>' +
        '   </li>' +
        '</ul>';
    var user_deptTemp = '<div><div class="settings-item" v-for="item in message.deptList_d">' +
        ' <a class="rightLink"></a>' +
        '<div class="inner-settings-item flexbox" style="cursor: pointer;" @click="userStructureInit(item.id,item.departmentName)">' +
        '      <div class="avator org"><img :src="baseURL+\'/jsp/wap/images/img/aa.jpg\'" alt=""></div>' +
        '      <div class="title flexItem">' +
        '          <p class="lh20">{{item.departmentName}}</p>' +
        '          <p class="lh20 fz13 c999">{{item.totalUser}}人</p>' +
        '      </div>' +
        '</div>' +
        '</div></div>'
    var deptTemp = '<div><div class="settings-item ku_arrow" v-for="item in message.data">' +
        '  <a class="a_link" style="margin-left: 35px;" @click="deptListInit(item.id,item.departmentName)"></a>' +
        '  <div class="inner-settings-item flexbox">' +
        '      <div class="user_select_icon" :class="{active:deptselected.idStr.indexOf(item.id)!=-1}" @click="selectThis(item.id)">' +
        '          <i class="fa"></i>' +
        '      </div>' +
        '      <div class="avator org"><img :src="baseURL+\'/jsp/wap/images/img/aa.jpg\'" alt=""></div>' +
        '      <div class="title flexItem">' +
        '          <p class="lh20">{{item.departmentName}}</p>' +
        '          <p class="lh20 fz13 c999">{{item.totalUser}}人</p>' +
        '      </div>' +
        '</div>' +
        '</div></div>'
    this.vue = new Vue({
        el: '#userOrDept_select',
        data:_this.configData,
        created:function(){//实例已经创建完成之后被调用。在这一步，实例已完成以下的配置：数据观测(data observer)，属性和方法的运算， watch/event 事件回调。然而，挂载阶段还没开始，$el 属性目前不可见
            this.groupDataInit();
            this.commonUserInit();
            this.userListInit();
        },
        mounted:function(){//el 被新创建的 vm.$el 替换，并挂载到实例上去之后调用该钩子
            var $frame_s = $("#userOrDept_select_s");
            var self = this;
            //字母排序人员下拉监听
            $frame_s.on("scroll",function(){
                if(self.tab.active=='user'&&self.userStructure==1){
                    if ($(this)[0].scrollTop + $frame_s.height() >= $(this)[0].scrollHeight) {
                        // 触发事件，AJAX加载下页的数据
                        if(!self.userList.lock_roll){
                            self.userList.lock_roll=true;
                            if(self.userList.page<self.userList.maxPage){
                                self.userList.page++;
                                self.userListInit();
                            }
                        }
                    };
                }
            })
            //搜索结果人员排序下拉监听
            var $frame_r = $("#userOrDept_select_r");
            $frame_r.on("scroll",function(){
                if(!self.resultShow){
                    if ($(this)[0].scrollTop + $frame_r.height() >= $(this)[0].scrollHeight) {
                        // 触发事件，AJAX加载下页的数据
                        if(!self.searchData.lock_roll){
                            self.searchData.lock_roll=true;
                            if(self.searchData.page<self.searchData.maxPage){
                                self.searchData.page++;
                                self.loadSearch();
                            }
                        }
                    };
                }
            })
        },
        components: {
            'mb-groupdata': {
                props: ['message','selectdata','userselected'],
                template:groupTemp,
                methods: {
                    //选择群组
                    selectThis:function(id){
                        var self = this;
                        selGroupAndTag(self,id,"group")
                    }
                }
            },
            'mb-tagdata': {
                props: ['message','selectdata','userselected'],
                template:groupTemp,
                methods: {
                    //选择标签
                    selectThis:function(id){
                        var self = this;
                        selGroupAndTag(self,id,"tag")
                    }
                }
            },
            'mb-commonlist': {
                props: ['message','selectdata','userselected'],
                template:userTemp,
                methods: {
                    //选择人员
                    selectThis:function(id){
                        selUser(this,id);
                    }
                }
            },
            'mb-result': {
                props: ['userselected','deptselected','selectdata'],
                template:resultTemp,
                methods: {
                    //选择人员
                    selectThisUser:function(id){
                        selUser(this,id);
                    },
                    //选择部门
                    selectThisDept:function(id){
                        selDept(this,id);
                    }
                }
            },
            'mb-userlist-h': {
                props: ['message','selectdata','userselected'],
                template:userTemp_h,
                methods: {
                    //选择人员
                    selectThis:function(id){
                        selUser(this,id);
                    }
                }
            },
            'mb-userlist-d': {
                props: ['message','selectdata','userselected'],
                template:userTemp,
                methods: {
                    //选择人员
                    selectThis:function(id){
                        selUser(this,id);
                    }
                }
            },
            'mb-deptlist-d': {
                props: ['message'],
                template:user_deptTemp,
                methods: {
                    //展开部门
                    userStructureInit:function(id,name){
                        userStructureInitFunc(this.message,id,name)
                    }
                }
            },
            'mb-deptlist': {
                props: ['message','deptselected'],
                template:deptTemp,
                methods: {
                    //展开部门
                    deptListInit:function(id,name){
                        deptListInitFunc(this.message,id,name)
                    },
                    //选择部门
                    selectThis:function(id){
                        selDept(this,id);
                    }
                }
            },
            'mb-loadsearch': {
                props: ['message','selectdata','userselected'],
                template:userTemp,
                methods: {
                    //选择人员
                    selectThis:function(id){
                        selUser(this,id);
                    }
                }
            },
            'mb-rang': {
                props: ['message','selectdata','userselected'],
                template:userTemp,
                methods: {
                    //选择人员
                    selectThis:function(id){
                        selUser(this,id);
                    }
                }
            },
        },
        methods:{
            //切换tab
            switchTab:function(event){
                var clickObj = $(event.target);
                if(clickObj[0].className.indexOf("selectTab_item")==-1){
                    return
                };
                var type = clickObj.attr("dataType");
                this.tab.active = type;
                if(type=="dept"&&!this.deptList.firstOrg){
                    this.deptListInit();
                }
            },
            //标签显示
            tagShowFunc:function(){
                this.tagShow=this.tagShow?false:true;
            },
            //常用群组显示
            groupShowFunc:function(){
                this.groupShow=this.groupShow?false:true;
            },
            //选择结果页面显示
            showResult:function(){
                if(this.userSelected.data.length>0||this.deptSelected.data.length>0){
                    this.resultShow = true;
                    this.resultDemo = true;
                }
            },
            //关闭选择结果页面
            closeShowResult:function(){
                this.resultShow = false;
                this.resultDemo = false;
            },
            //搜索结果页面显示
            showSearch:function(){
                this.resultShow = false;
                this.resultDemo = true;
                this.searchData.focus = true;
            },
            //控制人员组织结构和按字母排序互相切换
            controlUserStructure:function(){
                if(this.userStructure == 1){
                    this.userStructure = 2;
                    if(this.orgUserList.deptList_d.length==0&&this.orgUserList.userList_d.length==0){
                        this.userStructureInit();
                    }
                }else{
                    this.userStructure = 1;
                }
            },
            //初始化常用群组和标签数据
            groupDataInit:function(){
                var self = this;
                var url = _this.actions.searchTagPage;
                var data = {};
                dataRequest(url,data,function(list){
                    var groupList = list.pageData;
                    if(groupList&&groupList.length>0){
                        self.groupData = groupList;
                    }
                    //添加公共群组
                    var publicListcc = list.tagList;
                    if(publicListcc&&publicListcc.length>0){
                        self.tagData = publicListcc;
                    }
                });
            },
            //初始化常用联系人
            commonUserInit:function(){
                var url = _this.actions.getCommonList;
                var data = {"agentCode":wxqyh.agent};
                var self = this;
                dataRequest(url,data,function(list){
                    self.commonList.data = list.commonList
                });
            },
            //初始化字母排序人员
            userListInit:function(){
                var url = _this.actions.userList;
                var data = {"agentCode":wxqyh.agent,"page":this.userList.page};
                var self = this;
                dataRequest(url,data,function(list){
                    self.userList.lock_roll=false;
                    for(var i=0;i<list.pageData.length;i++){
                        self.userList.data.push(list.pageData[i])
                    }
                    self.userList.maxPage = list.maxPage;
                })
            },
            //加载人员组织结构
            userStructureInit:function(id,name){
                userStructureInitFunc(this.orgUserList,id,name);
            },
            //组织选人返回上一级
            goBack_user:function(){
                var arr = this.orgUserList.upperLevel;
                userStructureInitFunc(this.orgUserList,arr[arr.length-1].id,arr[arr.length-1].name);
                arr.length = arr.length-2;
            },
            //加载部门数据
            deptListInit:function(id,name){
                deptListInitFunc(this.deptList,id,name)
            },
            //部门返回上一级
            goBack_dept:function(){
                var arr = this.deptList.upperLevel;
                deptListInitFunc(this.deptList,arr[arr.length-1].id,arr[arr.length-1].name);
                arr.length = arr.length-2;
            },
            //拼音/手机/名字搜索人员
            enterSearch:function(){
                this.searchData.url= _this.actions.keyWordSearch;
                this.searchData.page = 1;
                this.searchData.searchKeyWord = this.searchData.keyWord;
                this.loadSearch();
            },
            //加载搜索结果
            loadSearch:function(){
                var url = this.searchData.url;
                var data = {"agentCode":wxqyh.agent,"page":this.searchData.page,"keyWord":this.searchData.searchKeyWord};
                var self = this;
                dataRequest(url,data,function(list){
                    if(self.searchData.page==1){
                        self.searchData.focus = false;
                        $("#userOrDept_select_r")[0].scrollTop = 0;
                        self.searchData.data = list.pageData?list.pageData:[];
                    }else{
                        for(var i=0;i<list.pageData.length;i++){
                            self.searchData.data.push(list.pageData[i])
                        }
                    }
                    self.searchData.maxPage = list.maxPage;
                    self.searchData.lock_roll=false;
                });
            },
            //清空搜索框内容
            clearInputVal:function(){
                this.searchData.keyWord='';
                this.searchData.focus = true;
            },
            //字母搜索列表
            letterListShow:function(){
                this.letterList=this.letterList?false:true;
            },
            //关闭字母搜索列表
            closeLetterList:function(e){
                if(!(e.target.className.indexOf('ic_letterList')!=-1||e.target.className.indexOf('search_letter_btn')!=-1)){this.letterList=false;}
                this.searchData.focus = false;
            },
            //头字母搜索
            letterSearch:function(keyWord){
                this.searchData.keyWord='';
                this.resultShow = false;
                this.resultDemo = true;
                this.searchData.url= _this.actions.letterSearch;
                this.searchData.page = 1;
                this.searchData.searchKeyWord = keyWord=="*"?"":keyWord;
                this.loadSearch();
            },
            //取消选择
            cancel:function(){
                $("#userOrDept_select").hide();
                $(".wrap").eq(this.demoIndex).show();
                if(this.callBack.close){
                    var obj = {
                        "user":this.userSelected,
                        "dept":this.deptSelected
                    }
                    this.callBack.close(this.el,obj)
                }
            },
            //确定选择
            confirm:function(){
                $("#userOrDept_select").hide();
                $(".wrap").eq(this.demoIndex).show();
                if(window.selectConfig&&selectConfig[this.el]){
                    if(selectConfig[this.el].userSelected){
                        selectConfig[this.el].userSelected.splice(0);
                        for(var i=0;i<this.userSelected.data.length;i++){
                            selectConfig[this.el].userSelected.push(this.userSelected.data[i]);
                        }
                    }
                    if(selectConfig[this.el].deptSelected){
                        selectConfig[this.el].deptSelected.splice(0);
                        for(var i=0;i<this.deptSelected.data.length;i++){
                            selectConfig[this.el].deptSelected.push(this.deptSelected.data[i]);
                        }
                        $("#"+selectConfig[this.el].deptId).val(this.deptSelected.idStr)
                    }
                }
                if(this.callBack.confirm){
                    var obj = {
                        "user":this.userSelected,
                        "dept":this.deptSelected
                    }
                    this.callBack.confirm(this.el,obj)
                }
            }
        },
        directives: {
            focus: {//定义获得了焦点指令
                update: function (el, binding) {
                    if (binding.value) {
                        el.focus();
                    }
                }
            }
        },
    });
    //群组选择
    function selGroupAndTag(self,id,type){
        var self = self;
        var data = self.message;//群组列表数据
        var isCache = false;//判断是否已加载群组内人员数据
        var index = '';//当前选中群组的下标
        var userselectedData = self.userselected.data;//已选人员数据
        var userselectedIdStr = self.userselected.idStr;//已选人员id字符串
        var selectdataStr = self.selectdata.idStr;//已选择群组集合字符串
        for(var i=0;i<data.length;i++){
            if(data[i].id==id){
                index = i;
                if(data[i].person){
                    isCache = true;
                }
                break;
            }
        }
        if(!isCache){//没有群组人员缓存数据
            var url = '';
            var parameter = {
                "agentCode":wxqyh.agent
            };
            var userList;
            if(type=="tag"){
                url = _this.actions.getUserForTag;
                parameter.tagId=id;
                dataRequest(url,parameter,function(list){
                    userList = list.list
                },false)
            }else{
                url = _this.actions.getUserForGroup;
                parameter.groupId=id;
                dataRequest(url,parameter,function(list){
                    userList = list.pageData
                },false)
            }
            if(userList&&userList.length>0){
                data[index].person=userList;
                data[index].idStr='';
                selectdataStr+=id+"|";
                self.selectdata.data[id]=data[index];
                if(userselectedData.length!=0){
                    for(var i=0;i<userList.length;i++){
                        data[index].idStr+=userList[i].userId+"|";//群组内人员id拼接字符串
                        if(userselectedIdStr.indexOf(userList[i].userId)==-1){
                            userselectedData.push(userList[i]);
                            userselectedIdStr+=userList[i].userId+"|";
                        }
                    }
                }else{
                    for(var i=0;i<userList.length;i++){
                        data[index].idStr+=userList[i].userId+"|";//群组内人员id拼接字符串
                        userselectedData.push(userList[i]);
                        userselectedIdStr+=userList[i].userId+"|";
                    }
                }
            }else{
                _alert("提示","当前群组没有联系人！","确定")
            }
        }else{
            var userList = data[index].person;
            if(userList.length>0){
                if(selectdataStr.indexOf(id)!=-1){
                    delete self.selectdata.data[id];
                    selectdataStr = selectdataStr.replace(id+"|","");
                    for(var i=0;i<userList.length;i++){
                        var personId = userList[i].userId;
                        userselectedIdStr = userselectedIdStr.replace(personId+"|","");
                        for(var t = 0;t<userselectedData.length;t++){
                            if(userselectedData[t].userId==personId){
                                userselectedData.splice(t,1);
                            }
                        }
                        if(selectdataStr!=""){
                            for(var v in self.selectdata.data){
                                if(self.selectdata.data[v].idStr.indexOf(personId)!=-1){
                                    delete v;
                                    selectdataStr = selectdataStr.replace(v+"|","");
                                }
                            }
                        }
                    }
                }else{
                    selectdataStr+=id+"|";
                    self.selectdata.data[id]=data[index];
                    if(userselectedData.length!=0){
                        for(var i=0;i<userList.length;i++){
                            if(userselectedIdStr.indexOf(userList[i].userId)==-1){
                                userselectedData.push(userList[i]);
                                userselectedIdStr+=userList[i].userId+"|";
                            }
                        }
                    }else{
                        for(var i=0;i<userList.length;i++){
                            userselectedData.push(userList[i]);
                            userselectedIdStr+=userList[i].userId+"|";
                        }
                    }
                }
            }else{
                _alert("提示","当前群组没有联系人！","确定")
            }
        }
        self.userselected.idStr = userselectedIdStr;
        self.selectdata.idStr = selectdataStr;
    }
    //人员选择
    function selUser(self,id){
        var userselectedData = self.userselected.data;
        if(self.userselected.idStr.indexOf(id)!=-1){
            var personId = id;
            self.userselected.idStr =self.userselected.idStr.replace(personId+"|","");
            for(var t = 0;t<userselectedData.length;t++){
                if(userselectedData[t].userId==personId){
                    userselectedData.splice(t,1);
                }
            }
            if(self.selectdata.str!=""){
                for(var v in self.selectdata.data){
                    if(self.selectdata.data[v].idStr.indexOf(personId)!=-1){
                        delete v;
                        self.selectdata.idStr = self.selectdata.idStr.replace(v+"|","");
                    }
                }
            }
        }else{
            if(_this.configData.userRestriction==1){
                self.userselected.idStr='';
                userselectedData.length = 0;
            }else if(_this.configData.userRestriction<userselectedData.length+1){
                _tooltips("选择的人员不能超过"+_this.configData.userRestriction+"位");
                return
            }
            self.userselected.idStr+=id+"|";
            var userData = null;
            for(var i = 0;i<self.message.length;i++){
                if(self.message[i].userId == id){
                    userData = self.message[i];
                    break;
                }
            }
            userselectedData.push(userData);
        }
    }
    //部门选择
    function selDept(self,id){
        var deptselectedData = self.deptselected.data;
        if(self.deptselected.idStr.indexOf(id)!=-1){
            self.deptselected.idStr =self.deptselected.idStr.replace(id+"|","");
            for(var t = 0;t<deptselectedData.length;t++){
                if(deptselectedData[t].id==id){
                    deptselectedData.splice(t,1);
                }
            }
        }else{
            if(_this.configData.deptRestriction==1){
                self.deptselected.idStr='';
                deptselectedData.length = 0;
            }else if(_this.configData.deptRestriction<deptselectedData.length+1){
                _tooltips("选择的部门不能超过"+_this.configData.deptRestriction+"个");
                return
            }
            self.deptselected.idStr+=id+"|";
            var deptData = null;
            for(var i = 0;i<self.message.data.length;i++){
                if(self.message.data[i].id == id){
                    deptData = self.message.data[i];
                    break;
                }
            }
            deptselectedData.push(deptData);
        }
    }
    //加载人员组织结构
    function userStructureInitFunc(obj,id,name){
        var deptObj = {"id":obj.deptId,"name":obj.deptName};
        obj.upperLevel.push(deptObj);
        if(!id){
            obj.deptId = '';
            obj.deptName = '';
            obj.upperLevel = []
        }else{
            obj.deptId = id;
            obj.deptName = name;
        }
        var url = _this.actions.deptAndUser;
        var data = {"agentCode":wxqyh.agent,"sortTop":1,"deptId":obj.deptId};
        if(obj.deptId==''){
            if(!obj.firstOrg){
                dataRequest(url,data,function(list){
                    obj.upperLevel.length=0;
                    obj.firstOrg = list;
                    obj.deptList_d = list.deptlist;
                    obj.userList_d = list.userList;
                });
            }else{
                obj.deptList_d = obj.firstOrg.deptlist;
                obj.userList_d = obj.firstOrg.userList;
            }
        }else{
            if(!obj.cacheData[obj.deptId]){
                dataRequest(url,data,function(list){
                    obj.cacheData[obj.deptId] =list;
                    obj.deptList_d = list.deptlist;
                    obj.userList_d = list.userList;
                });
            }else{
                obj.deptList_d = obj.cacheData[obj.deptId].deptlist;
                obj.userList_d = obj.cacheData[obj.deptId].userList;
            }
        }
    }
    //加载部门数据方法
    function deptListInitFunc(obj,id,name){
        var deptObj = {"id":obj.deptId,"name":obj.deptName};
        obj.upperLevel.push(deptObj);
        if(!id){
            obj.deptId = '';
            obj.deptName = '';
            obj.upperLevel = []
        }else{
            obj.deptId = id
            obj.deptName = name;
        }
        var url = _this.actions.loadDeptUrl;
        var data = {"agentCode":wxqyh.agent,"searchDept":1,"deptId":obj.deptId};
        if(obj.deptId==''){
            if(!obj.firstOrg){
                dataRequest(url,data,function(list){
                    obj.upperLevel.length=0;
                    obj.firstOrg = list;
                    obj.data = list.deptlist;
                });
            }else{
                obj.data = obj.firstOrg.deptlist;
            }
        }else{
            if(!obj.cacheData[obj.deptId]){
                dataRequest(url,data,function(list){
                    obj.cacheData[obj.deptId] = list;
                    obj.data = list.deptlist;
                });
            }else{
                obj.data = obj.cacheData[obj.deptId].deptlist;
            }
        }
    }
    //数据接口请求
    function dataRequest(url,data,callback,async){
        var asyncs = async==false?false:true;
        var list = null;
        showLoading();
        $.ajax({
            url:baseURL+url,
            type:"post",
            data:data,
            dataType:"json",
            async:asyncs,
            success : function(result) {
                if ("0" == result.code) {
                    list = result.data;
                    if(callback){
                        callback(list);
                    }
                    hideLoading();
                }else{
                    _alert("提示",result.desc,"确定");
                }
            },
            error:function(){
                _alert("提示","网络错误","确定");
            }
        });
        return list;
    }

}
userOrDept_select.prototype={
    changeConfig:function(el,config){
        this.configData.el = el;
        this.configData.selectType = config.selectType;
        this.configData.groupDataSelected={//清空已选群组标签
            "data":{},
            "idStr":'',
        };

        //人员与常用数据初始化
        this.configData.userSelected.data.length=0;
        this.configData.deptSelected.data.length=0;
        if(config.selectType.indexOf("user")!=-1){
            this.configData.tab.active = "group";
            this.configData.tab.group.show=true;
            this.configData.tab.user.show=true;
            this.configData.userSelected.idStr = '';
            for(var i=0; i<config.userSelected.length;i++){
                this.configData.userSelected.data.push(config.userSelected[i]);
                this.configData.userSelected.idStr+=config.userSelected[i].userId+"|";
            }
            this.configData.tab.len=config.selectType.split("|").length+1;
        }else{
            this.configData.tab.group.show=false;
            this.configData.tab.user.show=false;
        }

        //只有人员数据初始化
        if(config.selectType.indexOf("onlyUser")!=-1){
            this.configData.tab.active = "user";
            this.configData.tab.group.show=false;
            this.configData.tab.user.show=true;
            this.configData.userSelected.idStr = '';
            for(var i=0; i<config.userSelected.length;i++){
                this.configData.userSelected.data.push(config.userSelected[i]);
                this.configData.userSelected.idStr+=config.userSelected[i].userId+"|";
            }
            this.configData.tab.len=1;
        }

        //部门数据初始化
        if(config.selectType.indexOf("dept")!=-1){
            if(config.selectType.indexOf("user")==-1){
                this.vue.deptListInit();
                this.configData.tab.active = "dept";
            }
            this.configData.tab.dept.show=true;
            this.configData.deptSelected.idStr = '';
            for(var i=0; i<config.deptSelected.length;i++){
                this.configData.deptSelected.data.push(config.deptSelected[i]);
                this.configData.deptSelected.idStr+=config.deptSelected[i].id+"|";
            }
            this.configData.tab.len=config.selectType.split("|").length;
        }else{
            this.configData.tab.dept.show=false;
        }

        //范围选人数据初始化
        if(config.selectType.indexOf("rang")!=-1){
            this.configData.tab.len=1;
            this.configData.tab.active = "rang";
            this.configData.rangData.data.splice(0);
            for(var i=0; i<config.rangData.length;i++){
                this.configData.rangData.data.push(config.rangData[i]);
            }
            this.configData.userSelected.idStr = '';
            for(var i=0; i<config.userSelected.length;i++){
                this.configData.userSelected.data.push(config.userSelected[i]);
                this.configData.userSelected.idStr+=config.userSelected[i].userId+"|";
            }
        }

        //选择数量控制
        this.configData.userRestriction = 1000;
        if(config.userRestriction){
            this.configData.userRestriction = config.userRestriction;
        }
        this.configData.deptRestriction = 500;
        if(config.deptRestriction){
            this.configData.deptRestriction = config.deptRestriction;
        }

        //回调
        this.configData.callBack.close=null;
        this.configData.callBack.confirm=null;
        if(config.callBack){
            if(config.callBack.confirm){
                this.configData.callBack.confirm = config.callBack.confirm;
            }
            if(config.callBack.close){
                this.configData.callBack.close = config.callBack.close;
            }
        }
    },
    changeDataInterface:function(config){
        if(config.loadDeptUrl&&this.actions.loadDeptUrl != config.loadDeptUrl){
            this.actions.loadDeptUrl = config.loadDeptUrl;
            this.configData.deptList.cacheData = {};
            this.configData.deptList.firstOrg = null;
            this.configData.deptList.upperLevel.splice(0);
            this.configData.deptList.deptId = '';
            this.configData.deptList.deptName = '';
            this.configData.deptList.data.splice(0);
            this.vue.deptListInit();
        }
    },
    changeUserInterface:function(config){
        if(config.userList&&this.actions.userList != config.userList){
            this.actions.userList = config.userList;
            this.configData.userList.page = 1;
            this.configData.userList.data.splice(0);
            this.vue.userListInit();
            this.configData.searchData.data.splice(0);
            this.configData.searchData.page=1;
            this.configData.searchData.maxPage=1;
        }
        if(config.keyWordSearch&&this.actions.keyWordSearch != config.keyWordSearch){
            this.actions.keyWordSearch = config.keyWordSearch;
        }
        if(config.letterSearch&&this.actions.letterSearch != config.letterSearch){
            this.actions.letterSearch = config.letterSearch;
        }
    }
};
function makeSelectEnt(el,SelectConfig){
    var SelectConfig = SelectConfig || selectConfig;
    var htmlTemp = '<ul class="clearfix">'+
        '<li v-for="(item, i) in deptSelected" v-show="i<is_showNum||showAll">' +
        '     <a class="remove_icon" style="display: inline;" @click="removeThisDept(item.id)" v-if="!isNotChange.enter"></a>' +
        '     <p class="img">' +
        '         <img :src="baseURL+\'/jsp/wap/images/img/aa.jpg\'" alt="">' +
        '     </p>' +
        '     <p class="name">{{item.departmentName}}</p>' +
        '</li>' +
        '<li v-for="(item, i) in userSelected" v-show="i<is_showNum-deptSelected.length||showAll">' +
        '     <a class="remove_icon" style="display: inline;" @click="removeThisUser(item.userId)" v-if="!isNotChange.enter"></a>' +
        '     <input type="hidden" :name="userName" :value="item.userId">' +
        '     <p class="img">' +
        '         <img :src="item.headPic==0?baseURL+\'/jsp/wap/images/img/touxiang02.png\':item.headPic" alt="">' +
        '     </p>' +
        '     <p class="name">{{item.personName}}</p>' +
        '</li>' +
        '<li class="ico-add" @click="openSelectUser()" v-if="!isNotChange.enter"></li>'+
        '</ul>'+
        '<div class="c999 tcenter pb10" v-show="deptSelected.length+userSelected.length>showNum" @click="showAllFunc">' +
        '   <span>{{!showAll?"展开":"收起"}}</span>' +
        '   <span class="" v-show="userSelected.length!=0">{{userSelected.length}} 人</span>' +
        '   <span class="" v-show="deptSelected.length!=0&&userSelected.length!=0">,</span>' +
        '   <span class="" v-show="deptSelected.length!=0"> {{deptSelected.length}} 部门</span>' +
        '   <i class="ml5 clickJt" style="display: inline-block;vertical-align: text-top;" :class="{clickJt_up:!showAll}"></i>'+
        '</div>';
    $("#"+el).html(htmlTemp);
    var data = {
        "userSelected":SelectConfig[el].userSelected||[],
        "deptSelected":SelectConfig[el].deptSelected||[],
        "userName":SelectConfig[el].userName||'',
        "isNotChange":SelectConfig[el].isNotChange||{},
        "showAll":false,
        "showNum":4,
        "is_showNum":4
    }
    if(SelectConfig[el].callBack&&SelectConfig[el].callBack.open){
        data.openCallBack = SelectConfig[el].callBack.open
    }
   var vue =  new Vue({
        el: "#"+el,
        data: data,
        methods:{
            openSelectUser:function(){
                openSelectUser(el,SelectConfig,data.openCallBack);
            },
            removeThisDept:function(id){
                for(var t = 0;t<this.deptSelected.length;t++){
                    if(this.deptSelected[t].id==id){
                        this.deptSelected.splice(t,1);
                    }
                }
            },
            removeThisUser:function(id){
                for(var t = 0;t<this.userSelected.length;t++){
                    if(this.userSelected[t].userId==id){
                        this.userSelected.splice(t,1);
                    }
                }
            },
            showAllFunc:function(){
                if(this.showAll){
                    this.showAll = false;
                    this.is_showNum = this.showNum;
                }else{
                    this.showAll = true;
                    //this.is_showNum = this.deptSelected.length+this.userSelected.length;
                }
            }
        },
    })
    return vue;
}
//var selectConfig ={
//        "ccPersonList":{//必配：选人块的id
//        "selectType":"user|dept",//必配：限制选部门或是人员（rang:可选的特定人员;onlyUser:仅仅只有人员）
//        "userName":"relatives",//选配：存人员id的name
//        "deptId":"deptIds",//选配：存部门id的input的id
//        "userSelected":[],//选配：存已选的人员数据
//        "deptSelected":[],//选配：存已选的部门数据
//        "rangData":[],//选配：可选的特定人员
//        "userRestriction":1,//选配：限制人员选择的个数
//        "deptRestriction":1,//选配：限制部门选择的个数
//        "isNotChange":{"enter":false},//选配：入口是否可编辑人员
//        "callBack":{//选配
//            "open":openCallBack,//打开选人界面前回调
//            "confirm":confirmCallBack,//确认选择的回调
//            "close":closeCallBack//关闭取消选择页面的回调
//        }
//    }
// };
// $(function(){
//    makeSelectEnt("ccPersonList");
// })
// function confirmCallBack(el,data){
//
// }
// function closeCallBack(){
//
// }
//html:<div class="f-item">
//        <div class="f-add-user clearfix">
//            <div class="inner-f-add-user">
//                <div class="f-add-user-list" id="ccPersonList">
//                </div>
//            </div>
//        </div>
//    </div>
//改变选部门接口：changeDataInterface({loadDeptUrl:接口url})
//改变选人接口（按字母排序的，搜索的，头字母搜索的）：changeUserInterface({
//    userList:按字母排序的接口url,
//    keyWordSearch:搜索的接口url,
//    letterSearch:头字母搜索的接口url,
//})
