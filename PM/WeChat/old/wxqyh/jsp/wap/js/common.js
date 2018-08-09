function AjaxSend(objectOfXMLHttpRequest) {
	try{
		var s_ajaxListener = {};
		s_ajaxListener.tempOpen = objectOfXMLHttpRequest.prototype.open;

		objectOfXMLHttpRequest.prototype.open = function (method,url,async,name,password) {
			if (!url) var url = '';
			if(url.indexOf("dqdp_csrf_token")==-1){
				if(url.indexOf("?")==-1){
					url +="?dqdp_csrf_token=" + dqdp_csrf_token;
				}else{
					url +="&dqdp_csrf_token=" + dqdp_csrf_token;
				}
			}
			s_ajaxListener.tempOpen.apply(this, arguments);
		}
	}catch(err){
		alert(err);
	}
}

var xmlHttp;
if (window.XMLHttpRequest)
{// code for IE7+, Firefox, Chrome, Opera, Safari
	xmlHttp=XMLHttpRequest;
}
else
{// code for IE6, IE5
	xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
}
AjaxSend(xmlHttp);
try{
	try {
		if(window.$!=undefined){
			$(document).ajaxSend(function(event,xhr,options) {
				dqdp_csrf_token_fun(event,xhr,options);
			});
			$(function(){
				$(document).ajaxSend(function(event,xhr,options) {
					dqdp_csrf_token_fun(event,xhr,options);
				});
			})
		}else{
			/*alert(window.$);*/
		}
	}catch(err){
		$(document).on('ajaxSend', function(e, xhr, options){
			dqdp_csrf_token_fun(e,xhr,options);
		});
		$(function(){
			$(document).on('ajaxSend', function(e, xhr, options){
				dqdp_csrf_token_fun(e,xhr,options);
			})
		})
	}
}catch(err){
	if(wxqyh_is_debug){
		alert(err);
	}
}
/**手机端红色提示框*/
function _tooltips(message){
	var $tooltips = $('<div class="weui-toptips weui-toptips_warn js_tooltips" style="display: block;">'+message+'</div>');
	$('body').append($tooltips);
	restoreSubmit();
	setTimeout(function () {
		$tooltips.remove();
	}, 7000);
}
//手机端灰色弹出框
function _tooltips_succeed(message){
	var $tooltips = $(
		'<div class="topicdel_succeed">'
		+'<i class="icon-success-no-circle icon_toast"></i>'
		+'<p class="toast_content">'
		+message
		+'</p>'
		+'</div>'
		);
	$('body').append($tooltips);
	restoreSubmit();
	setTimeout(function (){
		$('.topicdel_succeed').fadeOut();
		$tooltips.remove();
	},1000);

}
function dqdp_csrf_token_fun(event,xhr,options){
	var tmp = true;
	//请求的url
	var dataUrl = options.url;
	var datas;
	if("POST" == options.type) {
		//如果post请求data数据不为空
		if(null != options.data && typeof options.data == 'string') {
			var dataStr = options.data;
			datas = dataStr.split("&");
			$.each(datas, function (index) {
				var keyvalue = datas[index].split("=");
				if (keyvalue[0] == "dqdp_csrf_token") {
					tmp = false;
				}
			});
			if(dataUrl.indexOf("dqdp_csrf_token")!=-1){
				tmp = false;
			}
		}
		else{
			if(dataUrl.indexOf("dqdp_csrf_token")!=-1){
				tmp = false;
			}
		}
	}
	//如果是get请求
	else{
		if(dataUrl.indexOf("dqdp_csrf_token")!=-1){
			tmp = false;
		}
	}
	if (tmp) {
		//当然这里还要判断url是不是有？了
		var url = options.url;
		if(dataUrl.indexOf("?")!=-1){
			options.url = options.url + "&dqdp_csrf_token=" + dqdp_csrf_token;
		}
		else{
			options.url = options.url + "?dqdp_csrf_token=" + dqdp_csrf_token;
		}
	}
}
    var notFilled="";
	var file;
	var dateId;
	var imgShowId;
	var lng="";//经度
	var lat="";//纬度
	var upLoadImgType;//上传图片后是否需要回调函数
	var upLoadImgHeightType;//上传图片显示高度类型
	var isDelImgNotify;//是否删除图片后通知，1为通知
	var internetErrorMsg="网络错误，请重试！";
	var chooseImageTypes=['album','camera'];//控制图片是拍照还是相册选择，默认两个都有
	var userIsMustPhoto="0"; //验证用户是否设置了必须上传图片才可以提交表单，0不是，1是
	var checkJsApi_image = true;//验证微信客户端是否可以使用上传图片的jssdk
	var wxqyh_wxjsapi = {
		checkjsapi_config: false,//验证签名是否成功
		is_check_config_error: false,//是否验证失败，默认成功
		ready: null,
		error: null
	};
    var wxqyh = {
    		agent: "",//应用code
    	    groupId: "",//用户附件关联的id
    	    orderId:"",
    	    init: function() {
    	    	var agentCode = getUrlParam('agentCode');
    	    	if(agentCode == null || agentCode == ""){
					agentCode = sessionStorage.getItem("wxqyhAgentCode");
					if(agentCode){
						wxqyh.agent = agentCode;
					}
					else{
						var url = window.location.href;
						var regS;
						var json = JSON.parse(decodeURIComponent(agentJson));
						for(var i=0;i<json.length;i++){
							regS = new RegExp(json[i].regex,"g");
							if(url.match(regS)){
								wxqyh.agent = json[i].angentId;
								return;
							}
						}
					}
    	    	}
    	    	else{
					sessionStorage.setItem("wxqyhAgentCode",agentCode);
	    			wxqyh.agent = agentCode;
	    	    	//清除的查询记录，查询所有数据
//	    			sessionStorage.removeItem('data_list');
//	    			sessionStorage.removeItem('list_cache');
    	    	}
    	    }
    };
	//系统的配置信息
	var wxqyhConfigReadyFunctionArray = [];//系统配置的ready function数组
	var wxqyhConfigReadyFunction = function(fun){
		if (wxqyhConfig.config_state > 0) {
			fun();
		}
		else {
			wxqyhConfigReadyFunctionArray.push(fun);
		}
	};
	var wxqyhConfig = {
		config_state : 0, // 0表示初始状态，尚未更新数据;1表示使用缓存;5重置
		is_vip: false,//是否vip
		is_pay_vip:false, //是不是支付VIP
		is_authen_org:false, //是不是认证企业
		is_in_vip_black_list:false,//是否在VIP黑名单
		is_in_vip_white_list:false,//是否在VIP白名单
		myInterfaceList:{ //金卡接口权限

		},
		vip_grade:0,
		vip_max_person:100,//VIP最大人数限制
		follow_user_member:100, //当前通讯录人数,
		is_over_vip_max_person:false,//是否超过VIP人数限制
		upload_image_max: 1,//上传图片大小控制
		upload_qydisk_image_silver_max: 5,//云盘银卡VIP图片大小控制
		upload_image_vip_max: 10,//金卡上传图片大小控制
		upload_voice_max: 2,//上传声音大小控制
		upload_video_max: 10,//上传视频大小控制
		upload_file_max: 10,//上传文件大小控制
		upload_qydisk_file_sliver_max:20,//云盘银卡VIP文件大小控制
		upload_file_vip_max: 50,//金卡用户上传文件大小控制
		is_qiweiyun: true, //是否企微云平台，false表示私有化
		is_use_yongzhong: false, //是否使用永中云转换预览
		yongzhong_url: "", //永中预览url
		orgConfigInfo : {//机构的一些信息
			orgName:"",
			orgLogo:"",
			isCooperation:false,//是否合作商
			type:1,//合作商类型，1渠道，2金卡
			createTime:""
		},
		org_config:{}, //机构配置
		orgSettingInfo:{
			isShowOpenFooter:"1", //是否显示外部分享底部：1是；0关闭；默认开启
			isShowNotInstallAgent:"1",//是否显示未安装应用：1是；0关闭；默认开启
			isSendHelpMsg:"1",//修改发送欢迎消息;1是；1是；0关闭；默认开启
			isShowCompanysrv:"1" //是否显示企业服务 1是；0关闭；默认开启
		},
		qwHistory:{
			historyData:"",
			historyMonth:"",
			historyExit:"",
			historyTip:"",
			historyAgentCode:"",
		},
		ready:wxqyhConfigReadyFunction
	};

	function readyWxqyhConfigRun(){
		for (var i=0; i<wxqyhConfigReadyFunctionArray.length; i++) {
			wxqyhConfigReadyFunctionArray[i]();
		}
	}
	//初始化配置信息，isRefresh 是否强制刷新
	function initWxqyhConfig(isRefresh) {
		if (wxqyh_isOpen) {
			return;
		}
		var temp = sessionStorage.getItem("wxqyhConfig");
		if(!isRefresh && temp){//如果是顶级页面刷新，强制重新获取一次
			wxqyhConfig = JSON.parse(temp);
			wxqyhConfig.config_state = 1;//表示使用缓存
			wxqyhConfig.ready = wxqyhConfigReadyFunction;
			readyWxqyhConfigRun();
		}
		else{
			$.ajax({
				url:baseURL+"/portal/vipPortalAction!wxqyhConfig.action",
				type:"post",
				dataType:"json",
				success:function(result){
					if(result.code=="0") {
						wxqyhConfig = result.data;
						sessionStorage.setItem("wxqyhConfig", JSON.stringify(wxqyhConfig));
						wxqyhConfig.config_state = 5;//表示已经初始化完成
						wxqyhConfig.ready = wxqyhConfigReadyFunction;
						readyWxqyhConfigRun();
					}
					else if(result.code=="-1"){
						showMsg("提示","系统出现异常，请重试");
						wxqyhConfig.config_state = -1;
					}
				},
				error: function () {
					showMsg("提示","网络错误");
					wxqyhConfig.config_state = -1;
				}
			});
		}
	}
    //方法一：
    //获取url中的参数
    function getUrlParam(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);  //匹配目标参数
        if (r != null) return unescape(r[2]); return null; //返回参数值
    }
/**
 * 获取本机的项目访问路径，包括域名+项目名
 * 如 https://qy.do1.com.cn/wxqyh
 * @sqh
 */
function getLocalURL(){
	var curWwwPath = window.document.location.href;
	//获取主机地址之后的目录，如： uimcardprj/share/meun.jsp
	var pathName = window.document.location.pathname;
	var pos = curWwwPath.indexOf(pathName);
	//获取主机地址，如： http://localhost:8083
	return curWwwPath.substring(0, pos) + baseURL;
}
	/*var dataForWeixin={
		   appId:"",
		   MsgImg:"消息图片路径",
		   TLImg:"时间线图路径",
		   url:"分享url路径",
		   title:"标题",
		   desc:"描述",
		   fakeid:"",
		   callback:function(){}
		};
	 */
	var dataForWeixin={
			   appId:"",
			   MsgImg:"",
			   TLImg:"",
			   url:"",
			   title:"",
			   desc:"",
			   fakeid:"",
			   callback:function(){}
	};
	function DqdpForm() {
	    DqdpForm.prototype.submitCheck = function ($formId) {
	        var fieldList = $("#" + $formId + " [valid]");
	        var canSubmit = true;
	        var firstError = null;
			var isSelectCity=false;//用于判断是否选择了省市
			var fieldName ="";
	        $.each(fieldList, function (index, content) {
				var eleStatus = "";

				var validStr = $(content).attr("valid");
				var validJson = eval("(" + validStr + ")");

				if(validJson.type == "CheckBox"||validJson.type == "RadioButton"||validJson.type=="ImageField"){
					fieldName=$(content).find("input").attr("name");
				}else if(validJson.type =="AccessoryField"){
					fieldName=$(content).attr("type").split("|")[1];
				}else if(validJson.type == "ChildField"){
					fieldName=$(content).parent().parent().attr("id");
				}else{
					fieldName = $(content).attr("name");//获取name查看是否需要过滤不必验证的字段
				}
				var isFilter = true;
				try {
					if (isFilterField(fieldName))
						isFilter = false;
				} catch (e) {
				}
				if (isFilter){
					var intputType = $(content).attr("type");
				validJson.tip = _getDqdpFormTip(validJson.tip);
				if (validJson.type == "RadioButton") {
					if (validJson.must && _isNotChoose(content)) {
						eleStatus = "请填写" + validJson.tip;
						canSubmit = _appendErrorTip(content, eleStatus);
					} else {
						_removeErrorTip(content);
					}
				}
				else if (validJson.type == "CheckBox") {
					eleStatus = _checkChoose(content, validJson.minLength, validJson.maxLength, validJson.must);
					if (eleStatus != "") {
						canSubmit = _appendErrorTip(content, eleStatus);
					} else {
						_removeErrorTip(content);
					}
				}
				
				// 数据源
				else if (validJson.type == "Datasource") {
					var div = $(content).parent();
					var ref_type = div.data("ref_type");
					if(ref_type=="DSCheckBox"){
						eleStatus = _checkChoose(div, div.data("min"), div.data("max"), validJson.must);
						if (eleStatus != "") {
							canSubmit = _appendErrorTip(content, eleStatus);
						} else {
							_removeErrorTip(content);
						}
					}
				}
				
				// 表单关联minmax验证
				else if (validJson.type == "FORMREFCustomerField") {
					var div = $(content).parent();
					var parent = div.parent();
					if(parent.hasClass("refForm") && parent.is(":visible")){
						
						if(validJson.must){
							var cfg = div.data("cfg");
							var min = cfg.min;
							var max = cfg.max;
							var length = parent.find(".childForm-item").length;
							if(min > 0 && length < min){
								canSubmit = _appendErrorTip(content, validJson.tip+"请选择"+min+"项以上");
							}
							else if(max > 0 && length > max){
								canSubmit = _appendErrorTip(content,validJson.tip+"请选择"+max+"项以内");
							}
							else if(length == 0){
								canSubmit = _appendErrorTip(content,"请选择"+validJson.tip);
							}else{
								_removeErrorTip(content);
							}
							
							
						}
						else {
							_removeErrorTip(content);
						}

					}
				}
				
				
				else if (validJson.type == "DropDown") {
					var validValue = $(content).val();
					if (_isNullValue(validValue) || _isNull(validValue)) {
						if (validJson.must) {
							eleStatus = "请填写" + validJson.tip;
							canSubmit = _appendErrorTip(content, eleStatus);
						} else {
							_removeErrorTip(content);
						}
					} else {
						_removeErrorTip(content);
					}
				}
				else if (validJson.type == "GeoField") {
					var validValue = $(content).val();
					if (validJson.must) {
						if (!isWeChatApp()) {
							eleStatus = "该表单需要获取微信位置信息，请使用企业微信填写";
							canSubmit = _appendErrorTip(content, eleStatus);
						}
						else if (_isNullValue(validValue) || _isNull(validValue)) {
							eleStatus = "需要打开GPS，并开启该应用的‘提供位置信息’";
							canSubmit = _appendErrorTip(content, eleStatus);
						} else {
							_removeErrorTip(content);
						}
					} else {
						_removeErrorTip(content);
					}
				}
				else if (validJson.type == "TimeField") {
					var validValue = $(content).val();
					if (validJson.must && ( _isNullValue(validValue) || _isNull(validValue))) {
						eleStatus = "请填写" + validJson.tip;
						canSubmit = _appendErrorTip(content, eleStatus);
					} else if (content.tagName == "SELECT") {
						//需要完善如果选择了其中一项，另一项必须选择的问题
						var nullIndex = 0;
						var els = document.getElementsByName($(content).attr("name"));
						var length = els.length;
						for (var i = 0; i < length; i++) {
							if (_isNullValue(els[i].value) || _isNull(els[i].value)) {
								nullIndex++;
							}
						}
						if (nullIndex < length && nullIndex > 0) {
							eleStatus = "请将" + validJson.tip + "填写完整";
							canSubmit = _appendErrorTip(content, eleStatus);
							if (!firstError)firstError = els[i];
						}
						else {
							_removeErrorTip(content);
						}
					} else {
						_removeErrorTip(content);
					}
				}
				else if (validJson.type == "ChildField") {
					var validValue = $(content).parent().parent().find(".childForm-item").length;
					var min = validJson.minLength;
					var max = validJson.maxLength;
					if (validJson.must) {
						min = min == 0 ? 1 : min;
					}
					if (max > 0 && min == 0) {
						if (validValue > max) {
							eleStatus = "不能添加大于" + max + "项";
						}
					}
					else if (max == 0 && min > 0) {
						if (validValue < min) {
							eleStatus = "不能添加小于" + min + "项";
						}
					}
					else if (max > 0 && min > 0) {
						if (validValue > max || validValue < min) {
							eleStatus = "只能添加" + min + "-" + max + "项";
						}
					}
					if (eleStatus == "")_removeErrorTip(content);
					else {
						_appendErrorTip(content, validJson.tip + eleStatus);
					}
				}
				else if ("undefined" != typeof(intputType) && intputType == "city") {//必须选择了省市才能去判断下面内容
					if ($(content).val() != "") {
						isSelectCity = true;
					} else {
						isSelectCity = false;
					}
				} else if ("undefined" != typeof(intputType) && intputType.indexOf("imageUrlField|") > -1) {//上传图片
					if (validJson.must) {
						var imageFieldNameVal = document.getElementsByName(intputType.split("|")[1]);
						if (imageFieldNameVal.length == 1) {
							eleStatus = "请上传" + validJson.tip + "的图片";
							canSubmit = _appendErrorTip(content, eleStatus);
						} else if(imageFieldNameVal.length == 0) {//子表单的图片判断
							var itemKeyName = $(content).find(".imageFileInput").eq(0).attr("name");
							var imageSonFieldNameVal = document.getElementsByName(itemKeyName);
							if (imageSonFieldNameVal.length == 1) {
								eleStatus = "请上传" + validJson.tip + "的图片";
								canSubmit = _appendErrorTip(content, eleStatus);
							}else{
								_removeErrorTip(content);
							}
						} else{
							_removeErrorTip(content);
						}
					} else {
						_removeErrorTip(content);
					}
				}
				else if ("undefined" != typeof(intputType) && intputType.indexOf("AccessoryField|") > -1) {//上传附件
					if (validJson.must) {
						var accessoryFieldNameVal = document.getElementsByName(intputType.split("|")[1]);
						if (typeof(accessoryFieldNameVal)=="undefined"||accessoryFieldNameVal.length == 0) {
							eleStatus = "请上传" + validJson.tip + "的附件";
							canSubmit = _appendErrorTip(content, eleStatus);
						} else {
							_removeErrorTip(content);
						}
					} else {
						_removeErrorTip(content);
					}
				}
				else if (isSelectCity && intputType == "area" && $(content).find("option").length == 1) {//因为区域有的只有市没有县
					_removeErrorTip(content);
				}
				else {
					var validValue = $(content).val();
					if (_isNullValue(validValue) || _isNull(validValue)) {
						if (validJson.must) {
							eleStatus = "请填写" + validJson.tip;
							canSubmit = _appendErrorTip(content, eleStatus);
						} else {
							_removeErrorTip(content);
						}
					}
					else {
						var isIdCard=false;//判断是否为身份证的验证
						switch (validJson.fieldType) {
							case "datetime":
							{
								eleStatus = checkDate(validValue, 'yyyy-MM-dd HH:mm:ss');
								break;
							}
							case "date":
							{
								eleStatus = checkDate(validValue, 'yyyy-mm-dd');
								if (eleStatus == "") {
									eleStatus = checkTime(validJson.stratTime, validJson.endTime, validValue);
								}
								break;
							}
							case "certId":
							{
								eleStatus = checkCertID(validValue);
								break;
							}
							case "pattern":
							{
								var temp = new RegExp(validJson.regex, "g");
								if (!temp.test(validValue)) {
									eleStatus = "输入的格式不正确或者输入了换行符";
								}
								break;
							}
							case "func":
							{
								var result = eval(validJson.regex);
								if (!result) {
									eleStatus = "格式不正确";
								}
								break;
							}
							default:
							{
							}
						}
						if (validJson.type == "TextField"&&$(content).attr("isCard")=="true") {//验证单行文本的身份证信息
						  var cardMsg=checkCard( $(content));
							if(cardMsg!=""){
								eleStatus = cardMsg;
								isIdCard=true;
							}
						}
						var min = validJson.minLength;
						var max = validJson.maxLength;
						if (validJson.type == "NumberField") {
							if (max > 0 && min == 0) {
								if (validValue > max) {
									eleStatus = "只能输入不大于" + max + "的数字";
								}
							}
							else if (max == 0 && min > 0) {
								if (validValue < min) {
									eleStatus = "只能输入不小于" + min + "的数字";
								}
							}
							else if (max > 0 && min > 0 || (max <= 0 || max > 0) && min < 0) {
								if (validValue > max || validValue < min) {
									eleStatus = "只能输入" + min + "-" + max + "之间的数";
								}
							}
						}
						else {
							var num = _strlength(validValue);
							if (max > 0 && min == 0) {
								if (num > max) {
									eleStatus = "只能输入不大于" + max + "个字";
									isIdCard=false;
								}
							}
							else if (max == 0 && min > 0) {
								if (num < min) {
									eleStatus = "只能输入不小于" + min + "个字";
									isIdCard=false;
								}
							}
							if (max > 0 && min > 0) {
								if (num > max || num < min) {
									eleStatus = "只能输入" + min + "-" + max + "个字";
									isIdCard=false;
								}
							}
							if (num > 2000) {
								eleStatus = "只能输入不大于" + 2000 + "个字";
								isIdCard=false;
							}
						}
						if (eleStatus == "")_removeErrorTip(content);
						else {
							if(isIdCard)
								_appendErrorTip(content,eleStatus);
							else
							   _appendErrorTip(content, validJson.tip + eleStatus);
						}
					}
				}
				if (eleStatus != "") {
					canSubmit = false;
					if (!firstError)firstError = content;
				}
			}
	        });
	        if (firstError)
	            firstError.focus();
	        //_resetFrameHeight();
	        return canSubmit;
	    };
	}
	function _getDqdpFormTip($tip){
		return ($tip && $tip !="")? $tip.replaceAll("&§&","'") : $tip;
	}
	function _appendErrorTip($ele, $tip) {
		var errorhtml = $("<p class='error'><font color='red'>" + $tip + "</font></p>");
		if ($(".error", $($ele).parent()).html() == null){
			$($ele).parent().append(errorhtml);
		}
		else{
			$(".error", $($ele).parent()).remove();
			$($ele).parent().append(errorhtml);
		}
		var top = $('.wrap_inner').scrollTop()-( $(window).height()-$('p.error:eq(0)').offset().top)+300;
		$('.wrap_inner').animate({
			scrollTop: top
		}, 500);
		return false;
	}
	function _removeErrorTip($ele) {
	    if ($(".error", $($ele).parent()).html() != null)
	        $(".error", $($ele).parent()).remove();
	    return false;
	}
	/**-------------校验方法区开始---------------------*/
	var regYyyy_mm_dd_A = /^(\d{4})-(\d{1,2})-(\d{1,2})$/;
	var regDateTime = /^(\d{4})-(\d{1,2})-(\d{1,2})\s(\d{1,2}):(\d{1,2}):(\d{1,2})$/;
	var regChineseY_m_d = /^(\d{4})年(\d{1,2})月(\d{1,2})$/;
	var regSlashY_m_d = /^(\d{4})\/(\d{1,2})\/(\d{1,2})$/;
	var regSlashYmd = /^(\d{4})(\d{1,2})(\d{1,2})$/;
	var sDateFormatA = "yyyy-mm-dd";
	//默认的日期格式
	var sDateFormatB = "yyyy年mm月dd日";
	//中文格式
	var sDateFormatC = "yyyy/mm/dd";
	var MONTH_LENGTH = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
	var LEAP_MONTH_LENGTH = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

	function _isNull($value) {
	    if (typeof($value) == "object")$value = $value.toString();
	    if ($value == "" || $value.replace(/\s+/g, "") == "")
	        return true;
	    return false;
	}

	function checkCertID($cerValue) {
	    var rs = true;
	    var certID = $cerValue;
	    //先去掉身份证前后的空格
	    certID = certID.replace(/(^\s+)|(\s+$)/g, "");
	    if (certID != "") { }
	    else return "身份证号格式错误";
	    if (certID.length == 15 || certID.length == 18) {
	        if (certID.length == 15) {
	            year = "19" + certID.substring(6, 8);
	            month = certID.substring(8, 10);
	            day = certID.substring(10, 12);
	        } else {
	            year = certID.substring(6, 10);
	            month = certID.substring(10, 12);
	            day = certID.substring(12, 14);
	        }

	        rs = checkDate(year + month + day, "yyyymmdd")
	    } else {
	        return "不应为" + certID.length + "位，请纠正\n";
	    }
	    return rs == "" ? "" : "身份证号中的日期错误";
	}

	function checkDate(sValue, sFormat) {
	    if (sValue != "") {
	        var regUseFormat = null;
	        /**
	         * 默认值为YYYY-mm-dd
	         */
	        if (sFormat == null) {
	            sFormat = sDateFormatA;
	            regUseFormat = regYyyy_mm_dd_A;
	        }

	        if (sFormat == "yyyy-mm-dd") {
	            regUseFormat = regYyyy_mm_dd_A;
	            //yyyy-mm-dd
	        } else if (sFormat == "yyyy年mm月dd日") {
	            regUseFormat = regChineseY_m_d;
	            //yyyy年mm月dd日
	        } else if (sFormat == "yyyy/mm/dd") {
	            regUseFormat = regSlashY_m_d;
	            //yyyy/mm/dd
	        } else if (sFormat == "yyyymmdd") {
	            regUseFormat = regSlashYmd;
	            //yyyy/mm/dd
	        } else if (sFormat == "yyyy-MM-dd HH:mm:ss") {
	            regUseFormat = regDateTime;
	            //yyyy/mm/dd
	        } else {
	            return  "正确的格式应为:" + sFormat + "!\n";
	        }

	        if (!regUseFormat.test(sValue)) {
	            return "应为日期类型!";
	        }

	        /**
	         * 检查日期的年月日是否正确
	         */
	        var aryYmd = sValue.match(regUseFormat);
	        var iYear = aryYmd[1];
	        var iMonth = aryYmd[2];
	        var iDay = aryYmd[3];

	        if (iYear < 1 || iYear > 9999 || iMonth < 1 || iMonth > 12 || iDay < 1 || iDay > getMonthDay(iMonth - 1, iYear)) {
	            return "中的日期有误!";
	        }
	        return "";
	    }
	    else return "";
	}

	function checkTime(begintime, endtime, userTime) {
	    if (userTime != "") {
		    //var bt = document.getElementsByName(begintime)[0].value;
		    //var et = document.getElementsByName(endtime)[0].value;
		    var ut = userTime.replaceAll("-", "/");
		    var dut = new Date(ut);
		    if(begintime != ""){
			    var bt = begintime.replaceAll("-", "/");
			    var dbt = new Date(bt);
			    if (dbt.getTime() > dut.getTime()) {
			        return "不能早于"+begintime;
			    }
		    }
		    if(endtime != ""){
			    var et = endtime.replaceAll("-", "/");
			    var det = new Date(et);
			    if (det.getTime() < dut.getTime()) {
			        return "不能晚于"+endtime;
			    }
		    }
		    //var today = new Date();
		    //today = today.getFullYear() + "/" + (today.getMonth() + 1) + "/" + today.getDate();
		    //today = new Date(today);
	    }
	    return "";
	}

	function getMonthDay(iMonth, iYear) {
	    return isLeapYear(iYear) ? LEAP_MONTH_LENGTH[iMonth] : MONTH_LENGTH[iMonth];
	}

	function isLeapYear(iYear) {
	    return ((iYear % 4 == 0) && ((iYear % 100 != 0) || (iYear % 400 == 0)));
	}
	
	
	/**判断区*/
	//判断字符串的长度
	function _strlength($str) {
		return $str.length;
		/*var l = $str.length;
	    var n = l;
	    for (var i = 0; i < l; i++) {
	        if ($str.charCodeAt(i) < 0 || $str.charCodeAt(i) > 255) n++;
	    }
	    return n;*/
	}
	function _isNullValue($value) {
	    return $value == undefined || $value == null;
	}
    function _isNotChoose($value){
    	var isChoose = true;
    	var radio = $($value).find("input");
		for(var i=0;i<radio.length;i++){
			if ($(radio[i]).attr("checked")) {
				return false;
			}
		}
    	return isChoose;
    }
    function _checkChoose($value,min,max,must){
    	var checkedIndex = 0;
    	var radio = $($value).find("input");
    	var size = radio.length;
		for(var i=0;i<size;i++){
			if ($(radio[i]).attr("checked")) {
				checkedIndex = checkedIndex+1;
			}
		}
    	if(must && min == 0){
    		min = 1;
    	}
    	else if(min>size){
    		min = size;
		}
    	if(max>size){
    		max = size;
    	}
    	if(checkedIndex == 0 && min>0){
			return "请至少选择"+min+"项";
    	}
		if(checkedIndex<min || (max>0 && checkedIndex>max)){
			if(min == max){
				return "只能选择"+min+"项";
			}
			else if(min>0 && max==0){
				return "至少选择"+min+"项";
			}
			else if(min>0 && max>0){
				return "只能选择"+min+"-"+max+"项";
			}
			else{
				return "最多选择"+max+"项";
			}
		}
    	return "";
    }

	/**--------------校验方法区结束--------------------*/
	
    /**--------------初始化编辑页面---*/
    function _doEleValueDispathc($ele, $value) {
    	var objArgs = [];
    	objArgs.push($value);
        var valueTargets = $("[name]", $ele);
        $.each(valueTargets, function (index, content) {
            var targetObj = $(this);
            var names = targetObj.attr("name");
			if(names=="file")//附件字段时
				names = targetObj.attr("filename");
            names=names.split(".");
            var value = "";
            for (var i = 0; i < names.length; i++) {
                value = i == 0 ? $value : value[names[i]];
                if (value == null || value == undefined)value = "";
            }
            _doElementValueSet(this, value);
        });
    }
    
    
    /**
     * 加载省市区代码，并回调
     * @param callback
     */
    function loadDistpicker_data(callback){
    	if(!$().distpicker){
    		if(window.distpicker_data_callback == undefined){
    			window.distpicker_data_callback=[];
    			if(callback)window.distpicker_data_callback.push(callback);
    			loadJs(baseURL+"/open/distpicker_data.jsp");
    		}
    		else{if(callback)window.distpicker_data_callback.push(callback);}
        	
    	}else{
    		if(callback)callback();
    	}
    	
    }
    
    
    function _doElementValueSet($ele, $value) {
    	if ($.type($value) == "object") {
            $value = JSON.stringify($value);
        }
        var targetObj = $($ele);
        if ($ele.tagName == "INPUT" || $ele.tagName == "TEXTAREA" || $ele.tagName == "SELECT") {
            if ($ele.tagName == "TEXTAREA") {
                targetObj.val($value);
            }
            else if ($ele.tagName == "SELECT") {
                switch (targetObj.attr("type")) {
	                case "hour":
	                	targetObj.val($value.split(":")[0]);
	                    break;
	                case "minute":
	                	targetObj.val($value.split(":")[1]);
	                    break;
	                case "province":case "city": case "area":

	                	if(typeof $value != "string"){
	                		break;
	                	}
	                	if(!$value){
	                		break;
	                	}
	                	if(getProvince){
	                		getProvince();
		                	var values = $value.split(":");
		                	if(values.length==3){
		                		if(targetObj.attr("type")=="province"){
		                			targetObj.val(values[0]).change();
		                		}else if(targetObj.attr("type")=="city"){
		                			targetObj.val(values[1]).change();
		                		}else if(targetObj.attr("type")=="area"){
		                			targetObj.val(values[2]).change();
		                		}
		                	}
	                		
	                		
	                	}
	                	
//	                		loadDistpicker_data(function(){
//			                	var values = $value.split(":");
//			                	if(values.length==3){
//			                		targetObj.parent().distpicker();
//			                		if(targetObj.attr("type")=="province"){
//			                			targetObj.val(values[0]).change();
//			                		}else if(targetObj.attr("type")=="city"){
//			                			targetObj.val(values[1]).change();
//			                		}else if(targetObj.attr("type")=="area"){
//			                			targetObj.val(values[2]).change();
//			                		}
//			                		
//			                	}
//		               			 
//		               		 });
	                	
	                	break;
	                	
				/**	case "province":
					    if(""!=$value){
					    	try{//因为创建人过滤两级下拉时出错了，所以对之前的数据try catch
							oldpid=$value.split(":")[0];
					    	}catch(e){
					    		oldpid="";
							}
							targetObj.val(oldpid);//根据市获取区信息
							getOldCity(targetObj,oldpid);//根据省获取市信息
						}
					    break;
					case "city":
						if(""!=$value){
							try{//因为创建人过滤两级下拉时出错了，所以对之前的数据try catch
							 oldcid=$value.split(":")[1];
							}catch(e){
								oldcid="";
							}
							getOldArea(targetObj,oldcid);
							targetObj.val(oldcid);//根据市获取区信息
						}
						break;
					case "area":
						if(""!=$value){
							try{//因为创建人过滤两级下拉时出错了，所以对之前的数据try catch
							targetObj.val($value.split(":")[2]);
							}catch(e){
							}
						}
						break;**/
					case "parent_select":
						if($value){
							if($.type($value) != "array"){
								var cascadeDropDownVal="";
								try{//因为创建人过滤两级下拉时出错了，所以对之前的数据try catch
									cascadeDropDownVal=$value.split(":")[0];
								}catch(e){
									cascadeDropDownVal="";
								}
								if(typeof cascadeDropDownVal!="string"){
									return;
								}
								if(cascadeDropDownVal.indexOf("&#58;")>-1)
									cascadeDropDownVal=cascadeDropDownVal.replaceAll("&#58;",":");
								getOldChildSelect(targetObj,cascadeDropDownVal);
								targetObj.val(cascadeDropDownVal);
							}else{
								var cascadeDropDownVal="";
								try{//因为创建人过滤两级下拉时出错了，所以对之前的数据try catch
									cascadeDropDownVal=$value[0];
								}catch(e){
									cascadeDropDownVal="";
								}
								if(typeof cascadeDropDownVal!="string"){
									return;
								}
								if(cascadeDropDownVal.indexOf("&#58;")>-1)
									cascadeDropDownVal=cascadeDropDownVal.replaceAll("&#58;",":");
								getOldChildSelect(targetObj,cascadeDropDownVal);
								targetObj.val(cascadeDropDownVal);
							}
						}
					break;
					case "child_select":
						
					if($value){
						
						if($.type($value) != "array") {
							var cascadeDropDownVal = "";
							try {//因为创建人过滤两级下拉时出错了，所以对之前的数据try catch
								cascadeDropDownVal = $value.split(":")[1];
							} catch (e) {
								cascadeDropDownVal = "";
							}
							if(typeof cascadeDropDownVal!="string"){
								return;
							}
							if (cascadeDropDownVal.indexOf("&#58;") > -1)
								cascadeDropDownVal = cascadeDropDownVal.replaceAll("&#58;", ":");
							targetObj.val(cascadeDropDownVal);
						}else if($value.length>=2){
								var cascadeDropDownVal = "";
								try {//因为创建人过滤两级下拉时出错了，所以对之前的数据try catch
									cascadeDropDownVal = $value[1];
								} catch (e) {
									cascadeDropDownVal = "";
								}
								if(typeof cascadeDropDownVal!="string"){
									return;
								}
								if (cascadeDropDownVal.indexOf("&#58;") > -1)
									cascadeDropDownVal = cascadeDropDownVal.replaceAll("&#58;", ":");
								targetObj.val(cascadeDropDownVal);
						}
					}
					break;
	                default:
	                	targetObj.val($value);
                }
				
            } else {
                switch (targetObj.attr("type")) {
                    case "radio":
                        if (targetObj.val() == $value)
                        	radioSelect(targetObj.parent());
                        break;
                    case "checkbox":
                    	if($.type($value) != "array"){
                            if (targetObj.val() == $value)
                            	mutipleSelect(targetObj.parent());
                    	}
                    	else{
                            for (var j = 0; j < $value.length; j++) {
                                if (targetObj.val() == $value[j])
                                	mutipleSelect(targetObj.parent());
                            }
                    	}
                        break;
				    case "file":
								if($.type($value) != "array"){
									if (null!=$value&&""!=$value){
										if($value.indexOf(":")==-1) {
											getImageField(targetObj.parent(), $(targetObj).attr("name"), $value);
										}else{
											getAccessoryField(targetObj.parent().parent().next().find(".f-item"),$(targetObj).attr("filename"),$value);
										}
									}

								}
								else {
									for (var j = 0; j < $value.length; j++) {
										if (null!=$value[j]&&"" != $value[j]) {
											if( $value[j].indexOf(":")==-1) {
												getImageField(targetObj.parent(), $(targetObj).attr("name"), $value[j]);
											}else{
												getAccessoryField(targetObj.parent().parent().next().find(".f-item"),$(targetObj).attr("filename"), $value[j]);
											}
										}
									}
								}
					    break;

                    case "hidden":
                    	if(targetObj.attr("fields") == "ratingfield"){
                    		if($value>0){
                            	targetObj.val($value);
                    			var sib = targetObj.siblings('i');
                    			var size = (sib.length+1)/3;//加一是为了让有三个时1个为灰，有5个时两个为灰，有10个时三个为灰
                    			for(var i=0;i<$value;i++){
       			            	   if($value<=size){
       			            		   sib.eq(i).addClass('checked1');
       			                   }else{
       			            		   sib.eq(i).addClass('checked');
       			                   }
       			                }
                    		}
                    	}else if(targetObj.attr("fields") == "CRMCustomer"){
							if($value!=""){
								targetObj.val($value);
								initialCRMCustomerFieldInfo(targetObj,$value);
							}
						}else if(targetObj.attr("fields") == "MEMBERCustomer"){// 通讯录
							if($value!=""){
								targetObj.val($value);
								initialMEMBERCustomerFieldInfo(targetObj,$value);
							}
						}else if(targetObj.attr("fields") == "DEPTCustomer"){// 部门
							if($value!=""){
								targetObj.val($value);
								initialDEPTCustomerFieldInfo(targetObj,$value);
							}
						}else if(targetObj.attr("fields") == "FORMREFCustomer"){// 表单关联
							// 旧版同时兼容
							if($value!=""){
								initialFORMREFCustomerFieldInfo(targetObj,$value);
							}
						}else if(targetObj.attr("fields") == "Datasource"){// 表单关联
							if($value!=""){
								initialDatasource(targetObj,$value);
							}
						}
                        break;
                    default:
                    	targetObj.val($value);
                }
            }
        } else if ($ele.tagName == "IMG") {
            targetObj.attr("src", targetObj.attr("src") + $value);
        } else {
            /*var charLength = targetObj.attr("charLength");
            if ($value == null || $value == undefined)$value = targetObj.attr("defaultValue");
            else {
                if (charLength != undefined && charLength != null && charLength != "") {
                    targetObj.attr("title", $value);
                    $value = _getStrByLen($value, charLength);
                }
            }*/
        	
        	if(typeof $value != "string"){
        		targetObj.html($value);
        		return;
        	}
        	
			var reg0=new RegExp("\r\n","g");
			var reg1=new RegExp("\r","g");
			var reg2=new RegExp("\n","g");
			$value = $value.toString().replace(reg0,"</br>");
			$value = $value.replace(reg1,"</br>");
			$value = $value.replace(reg2,"</br>");
			if(typeof(targetObj.attr('iscapital'))!='unfined'&&targetObj.attr('iscapital')=="true"){
				getCapitalVal(targetObj,$value);
			}
			else{
				var reg3=new RegExp("<script","g");
				var reg4=new RegExp("</script","g");
				$value = $value.replace(reg3,"&lt;script");
				$value = $value.replace(reg4,"&lt;/script");
            	targetObj.html(checkURL($value));
			}
        }
    }
    
    function getImageField(obj, name, imgVal) {
    	var self = $(obj);
    	var html = "";
    	var imgVal = imgVal.split(",");
    	for(var i = 0;i < imgVal.length;i++){
    		html = html.concat("<li><input type=\"hidden\" name=\"" + name + "\" value=\"" + imgVal[i] + "\" />" +
    		"<a class=\"remove_icon\" onclick=\"doDelLi(this);\" href=\"javascript:void(0)\" style=\"display: none;\"></a>" +
    		"<p class=\"img\"><img onclick=\"comPreviewImg(this);\" src=\""+compressURL + imgVal[i] + "\"/></p></li>");
    	}
    	obj.before(html);
    }
    
/***初始化Crm客户字段的展示信息***/
function initialCRMCustomerFieldInfo(obj,$value){
	var key=obj.attr("name").split(".")[1];
	var valHtml="";
	var cRMCustomerFieldCodeAndName=$value.split("_");
	var cRMCustomerFieldCode=cRMCustomerFieldCodeAndName[0].split("|");
	var cRMCustomerFieldVal=cRMCustomerFieldCodeAndName[1].split("|");
	for(var i=0;i<cRMCustomerFieldCode.length;i++){
		valHtml+=" <span class='item-selected' onclick=\"showCrmCustomerInfo('"+cRMCustomerFieldCode[i]+"');\">"+cRMCustomerFieldVal[i]+"</span>";
	}
	var paEle =obj.next();
	var aEle = paEle.find('a');
	paEle.html(valHtml).append(aEle);
}

/**
 * 初始化通讯录编辑字段
 * @param obj
 * @param $value
 */
function initialMEMBERCustomerFieldInfo(obj,$value){
	var key=obj.attr("id");
	var selectId="selected"+key;
	var strinputId="strinput"+key;
	
	var vv = $value.split("_");
	
	if(vv.length > 2){
		var index = $value.lastIndexOf("_");
		vv[0] = $value.substring(0,index);
	}
	var ids=vv[0].split("|");
	
	
	$.ajax({
		type:"POST",
		url: baseURL+"/portal/portalFormAction!getUserRedundancyListByUserId.action",
		data:{"id":ids.join(",")},
		dataType: "json",
		success: function(data){
			if ("0" == data.code) {
				var html="";
				var html2 = "";
				
				$(ids).each(function(i,vo){
					var userInfo = data.data[vo];
					html=html.concat('<span class="item-selected" onclick="atThisPersonUtil(\''+userInfo.userId+'\',\''+userInfo.personName+'\',\''+userInfo.headPic+'\');">'+userInfo.personName+'</span>&nbsp;');
					if(i != 0){
						html2=html2.concat(",");
					}
					html2=html2.concat(userInfo.userId+'|'+userInfo.personName+"|"+userInfo.headPic);
					
				});
				$("#"+selectId+" span").remove();
				$("#"+selectId+" a.ic_add").before(html);
				$("."+selectId).html(html);
				$("#"+strinputId).val(html2);
			}
		}
	});
	
	
}
/**
 * 初始化部门编辑字段
 * @param obj
 * @param $value
 */
function initialDEPTCustomerFieldInfo(obj,$value){
	var key=obj.attr("id");
	var selectId="selected"+key;
	var strinputId="strinput"+key;
	
	var vv = $value.split("_");
	var html="";
	var html2 = "";
	
	
	var vvv = vv[0].split("|");
	var vvv2 = vv[1].split("|");
	for(var i = 0;i < vvv.length;i++){
		
		html=html.concat('<span class="item-selected">'+vvv2[i]+'</span>&nbsp;');
		if(i != 0){
			html2=html2.concat(",");
		}
		html2=html2.concat('|'+vvv[i]+"|"+vvv2[i]);
		
		
	}
	
	
	
	$("#"+selectId+" span").remove();
	$("#"+selectId+" a.ic_add").before(html);
	$("."+selectId).html(html);
	$("#"+strinputId).val(html2);
	
	
	
}
/**
 * 初始化表单关联编辑字段
 * @param obj
 * @param $value
 */
function initialFORMREFCustomerFieldInfo(targetObj,$value){
	if(typeof $value=="string"){
		$value=new Array($value);
	}
	var id=$(targetObj).attr("id");
	var html="";
	var empty =true;
	
	
	var chosen=new Array();
	
	for(var i =0;i< $value.length;i++){
		var v=$value[i];
		if(v.split("_").length!=2){
			continue;
		}
		var xid=v.split("_")[0];
		chosen.push(xid);
		var xtext=v.split("_")[1];
		empty=false;
		html=html.concat(' <span class="item-selected" data-id="'+xid+'" onclick=\"FormRefSelect.showInfo(\''+xid+'\',this);\"><input type="hidden" value="'+xid+"_"+xtext+'" name="searchValue.'+id+'" />'+xtext+'</span>');
		$(targetObj).val(1);
	}
	if(!window.FormRefSelect){
		loadJs(baseURL+"/themes/wap/js/include/FormRefSelect.js");
	}
	if(!empty){
		$("#selected"+id).find(".item-selected,.c999").remove();
		$("#selected"+id).append(html);
	}

	
}
function initialFORMREFCustomerFieldInfoVersion2(targetObj,$value,itemMap){
	
	if(typeof $value=="undefined"){
		return;
	}
	
	if(typeof $value=="string"){
		$value=new Array($value);
	}
	var id=$(targetObj).attr("id");
	
	var chosen=new Array();
	
	if(!window.FormRefSelect){
		loadJs(baseURL+"/themes/wap/js/include/FormRefSelect.js");
	}
	// 后台管理端
	if(window.isMana){
		FormRefSelect.action="/form/formAction!{method}.action";
	}
	// 外部表单采用不同的地址
	if(window.isOpen){
		FormRefSelect.action="/open/openFormAction!{method}.action";
	}

	
	for(var i =0;i< $value.length;i++){
		var v=$value[i];
		if(v.split("_").length!=2){
			continue;
		}
		var xid=v.split("_")[0];
		chosen.push(xid);
	}
	if(targetObj.hasClass("version2") && chosen.length > 0){
		
		var $this =$(targetObj).parent();
		chosen=FormRefSelect.queryData(chosen,targetObj);
		
		if(addFormRefCallback){
			addFormRefCallback(chosen,$this.parent().parent(),$this,id,itemMap);
		}
		$this.val(1);
	}

	
}


var initialDatasourceCallback={};

/**
 * 初始化数据源字段
 * @param obj
 * @param $value
 */
function initialDatasource(targetObj,$value){
	if(typeof $value=="string"){
		$value=new Array($value);
	}
	
	var id=$(targetObj).attr("id");
	var html="";
	var empty =true;
	
	var p = targetObj.parent();
	var ref_type = p.data("ref_type");
	var cfg = p.data("cfg");
	
	var MainField;
	var IdKey;
	var ParentId;
	
	$(cfg.datasource_fields).each(function(i,ivo){
		if(ivo.field_type=="IdShow" || ivo.field_type=="Id"){
			IdKey=ivo.field_key;
		}
		if(ivo.field_type=="MainField"){
			MainField=ivo.field_key;
		}
		
		if(ivo.field_type=="ParentId"){
			ParentId=ivo.field_key;
		}
	});
	
	if(!window.DsSelect){
		loadJs(baseURL+"/themes/wap/js/include/DsSelect.js");
	}
	initialDatasourceCallback[id]=function(){
	
	for(var i =0;i< $value.length;i++){
		var v=$value[i];
		var vo = JSON.parse(v);
		if(typeof vo != "object"){
			continue;
		}
		$(targetObj).val(1);
		
		if(ref_type=="DSDatasource"){
			html=html.concat(' <span class="item-selected" data-id="'+forHTML(vo[IdKey])+'" onclick=\"DsSelect.showInfo(\''+id+'\',this);\"><input type="hidden" value="'+forHTML(v)+'" name="searchValue.'+id+'" />'+forHTML(vo[MainField])+'</span>');
			$("#selected"+id).find(".item-selected,.c999").remove();
			$("#selected"+id).append(html);
		}else if(ref_type=="DSCascadeDropDown"){
			var input = $("#selected"+id).find("select");
			if(i == 0){
				input.eq(0).find("option[data-value='"+forHTML(vo[IdKey])+"']").attr("selected",true).change();
			}else{
				input.eq(i).data("value",vo[IdKey]);
			}
		}else if(ref_type=="DSRadio"){
			var input = $("#selected"+id).find("input[data-value='"+forHTML(vo[IdKey])+"']");
			radioSelect(input.parents("li")[0]);
		}else if(ref_type=="DSCheckBox"){
			var input = $("#selected"+id).find("input[data-value='"+forHTML(vo[IdKey])+"']");
			mutipleSelect(input.parents("li")[0]);
		}else if(ref_type=="DSSelect"){
			var input = $("#selected"+id).find("option[data-value='"+forHTML(vo[IdKey])+"']");
			input.attr("selected",true);
			// input.val(v);
		}
		

		
	}
	
	};
	if(ref_type=="DSDatasource"){
		initialDatasourceCallback[id]();
	}

	
}

    function _isNullValue($value) {
        return $value == undefined || $value == null;
    }
    function _getStrByLen($str, $len) {
        if ($str == "")return "";
        var len = _strlength($str);
        var s = "";
        var n = 0;
        for (var i = 0; n < $len; i++) {
            n++;
            if ($str.charCodeAt(i) < 0 || $str.charCodeAt(i) > 255)n++;
            if (n > len) {
                break;
            }
            if (n <= $len + 1) {
                s = s + $str.charAt(i);
                if (n > $len || (n == $len && $len != len))s = s + "......";
            }
        }
        return s;
    }
    
    /**---------------初始化编辑页面结束-----------*/
	
    var reg_url =/(http:\/\/|https:\/\/)([\w].+\/?)\s*/g;
  //上传图片完成后的通知
    function notifyImage(paths,obj,name){
    	if(name==undefined || name ==""){
    		name = "imageUrls";
    	}
		if("imageUrlField"==name){
			name=$(obj).children().attr("name");
		}
		//imgShowId = imgUlId;
    	/*isDelImgNotify = 0;
    	var width = 65;
    	var height = 65;
    	//如果高度为屏幕款第的1/2
    	if(upLoadImgHeightType == 1){
    		width = "100%";
    		if(company_img_height == undefined){
    			height = $(window).width()/2;
    		}
    		else{
            	height = company_img_height+"px";
    		}
    	}*/
    	var _test="";
    	for(var i=0;i<paths.length;i++){
    		_test+="<li><input type=\"hidden\" name=\""+name+"\" value=\""+paths[i]+"\" />"+
        		"<a class=\"remove_icon\" onclick=\"doDelLi(this);\" href=\"javascript:void(0)\" style=\"display: none;\"></a>" +
        		"<p class=\"img\"><img onclick=\"viewImage('"+localport+paths[i]+"');\" src=\""+compressURL+paths[i]+"\"/></p></li>";
    	}

    	obj.before(_test);
       	//隐藏上传中的层
       	hideLoading();
       	if($('#imglist').find('li').length>2){
    		var url=document.location.href;
    		if(window.localStorage[url]){
    			var jsonStorage=JSON.parse(localStorage.getItem(url));
    			jsonStorage['uploadImgList']=$('#imglist').html();
    			localStorage[url]=JSON.stringify(jsonStorage);
    		}
        }
    	
    }//删除部门
    function removeImage(obj,imgUlId){
    	var arry;
    	arry = $(obj).parent().find("a");
    	var show = $(obj).attr("show");
    	if(show==0){
    		$(obj).attr("show","1");
    		for(var i=0;i<arry.length;i++){
    			$(arry[i]).show();
    		}
    	}else{
    		$(obj).attr("show","0");
    		for(var i=0;i<arry.length;i++){
    			$(arry[i]).hide();
    		}
    	}
    	
    }
    /**
     * 删除li
     * @param $this  点击的a标签的对象
     */
    function doDelLi($this){
    	$($this).parent().remove();
    		var url=document.location.href;
    		if(window.localStorage[url]){
    			var jsonStorage=JSON.parse(localStorage.getItem(url));
    			jsonStorage['uploadImgList']=$('#imglist').html();
    			localStorage[url]=JSON.stringify(jsonStorage);
    		}
   
    }
    /**
     * 预览图片
     * @param imageVOs  图片的list
     */
    function previewImages(imageVOs,ulId,name){
    	if(!imageVOs || imageVOs.length==0){
    		return;
    	}
    	if(ulId==undefined || ulId ==""){
    		ulId = "imglist";
    	}
    	if(name==undefined || name ==""){
    		name = "imageUrls";
    	}
    	var _test="";
    	for(var i=0;i<imageVOs.length;i++){
    		_test+="<li><input type=\"hidden\" name=\""+name+"\" value=\""+imageVOs[i].picPath+"\" />"+
    		"<a class=\"remove_icon\" onclick=\"doDelLi(this);\" href=\"javascript:void()\" style=\"display: none;\"></a>" +
        		"<p class=\"img\"><img onclick=\"viewImage('"+localport+imageVOs[i].picPath+"')\" src=\""+compressURL+imageVOs[i].picPath+"\"/></p></li>";
    	}
       	$("#"+ulId).prepend(_test);
    }
    
    var loadMore = 
    {
    	viewMoreText: "",
    	loading: function() {
    		viewMoreText = $("#listMore").find("a").first().html();
    		$("#listMore").find("a").html("努力加载中...").attr("href", "javascript:void(0)");
    		$("#listMore").css("display", "block");
    	},
    	
    	afterLoad: function() {
    		$("#listMore").find("a").html(viewMoreText).attr("href", "javascript:listMore()");
    		$("#listMore").css("display", "block");
    	},
    	
    	finish: function() {
    		$("#listMore").find("a").html("已没有更多").attr("href", "javascript:void(0)");
    		$("#listMore").css("display", "block");
    	},
    	
    	showTag: function(hasMore) {
    		if (hasMore) this.afterLoad();
    		else this.finish();
    	}
    };
    
    function preLoadImage(url, $imgPlaceHolder) {
        var img = new Image(); //创建一个Image对象，实现图片的预下载
        img.src = url;
       
        if (img.complete) { // 如果图片已经存在于浏览器缓存，直接调用回调函数
        	$imgPlaceHolder.attr("src", img.src).css("display", "block");
            return; // 直接返回，不用再处理onload事件
        }

        img.onload = function () { //图片下载完毕
        	$imgPlaceHolder.attr("src", img.src).css("display", "block");
        };
    }
/**
     * 替换没有头像的图片
     * @param obj
     */
    function replaceUserHeadImage(obj){
		$(obj).attr("src",baseURL+"/jsp/wap/images/img/touxiang02.png");
	}
    /**
     * 判断是否校友会或者企业微信用户
     * @param obj
     */
    function judgeClient(obj){
    	var url = window.location.href;
        if((isWeChatApp() && url.indexOf("wxqyh") >= 0)) {
        	return false;
        }
    	$("#aLink").click();
    	return true;
	}
    var wxqyh_iswechatapp = null;//是否微信手机客户端打开
    /**
     * 判断是否微信打开
     * @returns {Boolean}
     */
    function isWeChatApp(){
    	if(wxqyh_iswechatapp == null){
			var ua = navigator.userAgent.toLowerCase();
			if(ua.indexOf("wxwork")>0){
				if(isIOS() || isAndroid()){
					wxqyh_iswechatapp = true;
				}
				else{
					wxqyh_iswechatapp = false;
				}
			}
			else if((ua.match(/MicroMessenger/i)=="micromessenger" && ua.indexOf("windowswechat")==-1)) {
				wxqyh_iswechatapp = true;
			}
			else{
				wxqyh_iswechatapp = false;
			}
    	}
        return wxqyh_iswechatapp;
    }
	var wxqyh_iswechat = null;//是否微信客户端或者PC端打开
	/**
	 * 判断是否微信客户端或者PC端打开
	 * @returns {Boolean}
	 */
	function isWeChat(){
		if(wxqyh_iswechat == null){
			var ua = navigator.userAgent.toLowerCase();
			if((ua.match(/MicroMessenger/i)=="micromessenger")) {
				wxqyh_iswechat = true;
			}
			else{
				wxqyh_iswechat = false;
			}
		}
		return wxqyh_iswechat;
	}
	var wxqyh_isqiyeweixin = null;//是否微信客户端或者PC端打开
	/**
	 * 判断是否企业微信客户端或者PC端打开
	 * @returns {Boolean}
	 */
	function isQiyeweixin(){
		if(wxqyh_isqiyeweixin == null){
			var ua = navigator.userAgent.toLowerCase();
			if(ua.indexOf("wxwork")>0){
				wxqyh_isqiyeweixin = true;
			}
			else{
				wxqyh_isqiyeweixin = false;
			}
		}
		return wxqyh_isqiyeweixin;
	}
	/**
	 * 判断是否企业微信客户端,包括Android和ios
	 * @returns {Boolean}
	 */
	function isQiyeweixinApp(){
		isQiyeweixin();
		if (wxqyh_isqiyeweixin) {
			if(isIOS() || isAndroid()){
				return true;
			}
		}
		return false;
	}
var wxqyh_ishefeixin = null;//是否和飞信客户端打开
function isHefeixin(){
	if(wxqyh_ishefeixin == null){
		var ua = navigator.userAgent.toLowerCase();
		if(ua.indexOf("hefeixin") > -1) {
			wxqyh_ishefeixin = true;
		}
		else{
			wxqyh_ishefeixin = false;
		}
	}
	return wxqyh_ishefeixin;
}

	/**
	 * 是否android终端
	 * @sunqinghai
	 */
	function isAndroid(){
		var u = navigator.userAgent.toLowerCase();
		return u.indexOf('android') > -1;
	}

	/**
	 * 是否ios终端
	 * @sunqinghai
	 */
	function isIOS(){
		var u = navigator.userAgent.toLowerCase();
		return /iphone|ipod|ipad/i.test(u);
	}
	/**
	 * 获取微信版本号
	 * @returns
	 * @sunqinghai
     */
	function getWeChatVersion(){
		if(isWeChatApp()){
			var u = navigator.userAgent.toLowerCase();
			if(u.match(/micromessenger\/.*nettype/i)){
				var ver = u.match(/micromessenger\/.*nettype/i)[0];
				return ver.replace("micromessenger/","").replace("nettype","").trim();
			}
		}
		return "";
	}
   
    var sy = $.extend({}, sy);/* 定义一个全局变量 */
    sy.serializeObject = function(form) { /* 将form表单内的元素序列化为对象，扩展Jquery的一个方法 */
    	var o = {};
    	$.each(form.serializeArray(), function(index) {
    		if (o[this['name']]) {
    			o[this['name']] = o[this['name']] + "," + this['value'];
    		} else {
    			o[this['name']] = this['value'];
    		}
    	});
    	return o;
    };

    function Map()   
    {    
       this.container = {};    
    }    
     
    //将key-value放入map中   
    Map.prototype.put = function(key,value){    
     try{    
          
       if(key!=null && key != "")   
          this.container[key] = value;    
     
      }catch(e){    
        return e;    
       }    
    };    
     
    //根据key从map中取出对应的value   
    Map.prototype.get = function(key){    
     try{    
     
        return this.container[key];    
     
     }catch(e){    
        return e;    
     }    
    }; 
    
    Array.prototype.indexOf = function(val) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == val) return i;
        }
        return -1;
    };
    Array.prototype.remove = function(val) {
        var index = this.indexOf(val);
        if (index > -1) {
            this.splice(index, 1);
        }
    };
    function strToJson(str){ 
    	var json = (new Function("return " + str))(); 
    	return json; 
  	}
    
    (function($) {    
        /** 
         * 将form表单中的值转换为json格式 
         */  
        $.fn.formtojson = function() {     
            var obj={};  
            var serializedParams = this.serialize();  
            function evalThem (str) {  
                var attributeName =  str.split("=")[0];  
                var attributeValue = str.split("=")[1];  
                if(!attributeValue){  
                    attributeValue = '';  
                }  
                var array = attributeName.split(".");  
                for (var i = 1; i < array.length; i++) {  
                    var tmpArray = Array();  
                    tmpArray.push("obj");  
                    for (var j = 0; j < i; j++) {  
                        tmpArray.push(array[j]);

                    }
                    var evalString = tmpArray.join(".");  
                    if(!eval(evalString)){  
                        eval(evalString+"={};");                  
                    }

                }
                eval("obj."+attributeName+"='"+unescape(attributeValue).replace(/'/, "\\'")+"';");

            }
            var properties = serializedParams.split("&");  
            for (var i = 0; i < properties.length; i++) {  
                evalThem(properties[i]);

            }
            return obj;  
        };
    }($));
    
    String.prototype.replaceAll = function(reallyDo, replaceWith, ignoreCase) {  
        if (!RegExp.prototype.isPrototypeOf(reallyDo)) {  
            return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi": "g")), replaceWith);  
        } else {  
            return this.replace(reallyDo, replaceWith);  
        }  
    };
	Date.prototype.Format = function(fmt)   
	{ //author: meizz   
	  var o = {   
	    "M+" : this.getMonth()+1,                 //月份   
	    "d+" : this.getDate(),                    //日   
	    "h+" : this.getHours(),                   //小时   
	    "m+" : this.getMinutes(),                 //分   
	    "s+" : this.getSeconds(),                 //秒   
	    "q+" : Math.floor((this.getMonth()+3)/3), //季度   
	    "S"  : this.getMilliseconds()             //毫秒   
	  };   
	  if(/(y+)/.test(fmt))   
	    fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length));   
	  for(var k in o)   
	    if(new RegExp("("+ k +")").test(fmt))   
	  fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length)));   
	  return fmt;   
	};
	//去除左右空格
	function trimLR(sendComment){
		sendComment = sendComment.replace(/(^\s*)/g, ""); 
   	    //去除右空格
   		sendComment = sendComment.replace(/(\s*$)/g, "");  
   		return sendComment;
	}
	//评论输入内容转换（表情标签转编码）
	function imgToCode(){
		var html = $("#inputDiv").val();
		var emojis = html.match(/\[.*?\]/g);
		emojis = (emojis==null)?"":emojis;
		if(typeof(emojis)=="object"){
			for(var i=0;i<emojis.length;i++){
				var word = emojis[i];
				var code = wordToCode(word.substring(1,word.length-1));
				if(code!=null){
					html = html.replace(word," "+code);
				}
			}
		}
		return html;
	}
	function tranImgToCode(){
		var html = $("#inputDiv").val();
		var list = $("#inputDiv").find("img");
		for(var i=0;i<list.length;i++){
			var img = list[i];
			var title = $(img).attr("title");
			var tmp = document.createElement("div");
			tmp.appendChild(img);
			html = html.replace(tmp.innerHTML," "+title);
		}
		return html;
	}
	function htmlEncode(str) {
	    var div = document.createElement("div");
	    div.appendChild(document.createTextNode(str));
	    return div.innerHTML;
	}
	function getUrlHtml(str) {//因为上面的htmlEncode方法在global.js也有此方法，导致超级表单的checkurl方法返回的链接有问题  add by tanwq 2016-6-12
	    var div = document.createElement("div");
	    div.appendChild(document.createTextNode(str));
	    return div.innerHTML;
	}
	function closeEmoji(){
		var plus_btns = $("#plus_btns"),
        emoji_list = $("#emoji_list"),
        text_input = $(".text_input");

	    text_input.blur();
	    if( !plus_btns.ishide() || !emoji_list.ishide() ){
	        plus_btns.hide();
	        emoji_list.hide();
	        //text_input.focus();
	    }
	}
    // 计算选人的图片长度
    function setSelectUserWidth(){
        var totalWidth = 0;
        $(".selected_user li").each(function(index){
            $(this).find("img").on("load", function(){
                totalWidth += ($(this).parent().width()+5);
                if($(".selected_user li").length = index+1){
                    $(".selected_user_inner").width(totalWidth);
                }

            });
        });
    }
    
    /**
     * 上传图片后预览图片，此时显示的为小图
     * @param src
     */
    function viewImage(src){
		var index = src.indexOf(compressURL);
		if (index == 0) {
			src = src.replace(compressURL, localport);
		}
    	showImage(src);
    }
    
    /**
     * 迭代判断父节点中是否含有a标签
     * @param $this
     * @returns
     */
    function isALabel($this){
    	if($this[0].tagName == "A"){
    		return true;
    	}
    	else if($this[0].tagName == "BODY"){
    		return false;
    	}
    	else{
    		return isALabel($this.parent());
    	}
    }
    
	$(function() {
		//给wrap_inner高度
		var win_height = $(window).height();
		$(".wrap_inner").height(win_height);
		//内容图片预览
		$(".article_content,.preview_max_img").on("click","img",function(){
			//评论图片预览
			if(isALabel($(this).parent())){
				return;
			}
			if(checkJsApi_image && isWeChatApp()) {
				var contentPicList=[];	//当前页面图片集合
				var cureentpath=$(this).attr("src");//当前点击的图片链接
				var tempimg = cureentpath.substring(cureentpath.lastIndexOf('.') + 1, cureentpath.length).toLowerCase();
				if($(this).hasClass('tapeEndImg')){
					return;
                }
                //js生成的二维码图片在安卓手机显示大图 hejinjiao 2016/01/26
				if(navigator.userAgent.toLowerCase().indexOf('android') > -1&&$(this).parent().attr("id")=="qrcodeImage"){
					var src = $(this).attr("src");
					viewImage(src);
					return;
				}
				cureentpath = cureentpath.replace("/compress/upload/img/", "/upload/img/");
				if(tempimg!="jpg" && tempimg!="png" && tempimg!="jpeg"){//解决非jpg等图片的预览
					contentPicList.push(cureentpath);
				}
				else{
					//缩略图变成原图
					$('.article_detail,.preview_max_img').find("img").each(function(i){
						var path=$(this).attr('src');
						var temp = path.substring(path.lastIndexOf('.') + 1, path.length).toLowerCase();
						if(path!='' &&  path!=undefined && path.indexOf("/jsp/wap/images")<0){
							if(temp=="jpg" || temp=="png" || temp=="jpeg"){
								//缩略图变成原图
								path = path.replace("/compress/upload/img/", "/upload/img/");
								//alert($(this).attr('src'));
								contentPicList.push(path);
							}
						}
					});
				}
				wx.previewImage({
				    current: cureentpath, // 当前显示的图片链接
				    urls: contentPicList // 需要预览的图片链接列表
				});
		    }else{
		    	//alert($(this).parent().attr("id"));
				var src = $(this).attr("src");
				viewImage(src);
				//window.location.href = baseURL + "/jsp/wap/tips/show_image.jsp?imgSrc="+src;
			}
		});
		wxqyh.init();
		if (getUrlParam('agentCode')) {
			initWxqyhConfig(true);//如果是顶级页面刷新，强制重新获取一次
		}
		else {
			initWxqyhConfig(false);
		}

		//展开收起功能
		$(".qw-tg-f-item").on("click",function(){
			if ($(this).next().is(":hidden")) {
				$(this).next().show();
				$(this).css("border-bottom", "1px solid #e5e5e5");
				$(this).find(".clickJt").removeClass("clickJt_up");
				$(this).find(".tg-text").html("收起");
			} else {
				$(this).next().hide();
				$(this).css("border-bottom", "none");
				$(this).find(".clickJt").addClass("clickJt_up");
				$(this).find(".tg-text").html("展开");
			}
		});

		//	简化版搜索框
		$(".qw-search_text").on('click',function(){
			$(this).hide();
			$('.qw-search_input').val('').focus();
		});
		$(".qw-search_Title").on('click',function(){
			$(".search_Popsan").toggle();
			$(".search_Pop").toggle();
		});
		$(".qw-icon_del").on('click',function(){
			$('.qw-search_input').val('').focus();
		});
		$(".qw-search_input").focus(function(){
			$(".search_Popsan").hide();
			$(".search_Pop").hide();
		});
		$(".qw-search_Pop").on("click","li",function(){
			$('.onetitle').text($(this).text());
		});
		//底部操作菜单显示隐藏
		var $iosActionsheet = $('#qwui-actionsheet');
		var $iosMask = $('#iosMask');

		function hideActionSheet() {
			$iosActionsheet.removeClass('qwui-actionsheet_toggle');
			$iosMask.fadeOut(200);
		}

		$iosMask.on('click', hideActionSheet);
		$('#qwui-actionsheetCancel').on('click', hideActionSheet);
		$("#showActionSheet").on("click", function(){
			$iosActionsheet.addClass('qwui-actionsheet_toggle');
			$iosMask.fadeIn(200);
		});
	});
	function comPreviewImg(obj) {
		try{
			if(checkJsApi_image && isWeChatApp()) {
				var contentPicList=[];	//当前页面图片集合
				var cureentpath=$(obj).attr("src");//当前点击的图片链接
				var tempimg = cureentpath.substring(cureentpath.lastIndexOf('.') + 1, cureentpath.length).toLowerCase();
				cureentpath = cureentpath.replace("/compress/upload/img/", "/upload/img/");
				if(tempimg!="jpg" && tempimg!="png" && tempimg!="jpeg"){//解决非jpg等图片的预览
					contentPicList.push(cureentpath);
				}
				else{
					//缩略图变成原图
					$('.article_detail').find("img").each(function(i){
						var path=$(this).attr('src');
						var temp = path.substring(path.lastIndexOf('.') + 1, path.length).toLowerCase();
						if(path!='' &&  path!=undefined && path.indexOf("/jsp/wap/images")<0){
							if(temp=="jpg" || temp=="png" || temp=="jpeg"){
								//缩略图变成原图
								path = path.replace("/compress/upload/img/", "/upload/img/");
								//alert($(this).attr('src'));
								contentPicList.push(path);
							}
						}
					});
					if(contentPicList.length == 0){
						contentPicList.push(cureentpath);
					}
				}
				wx.previewImage({
					current: cureentpath, // 当前显示的图片链接
					urls: contentPicList // 需要预览的图片链接列表
				});
			}else{
				var src = $(obj).attr("src");
				viewImage(src);
				//window.location.href = baseURL + "/jsp/wap/tips/show_image.jsp?imgSrc="+src;
			}
		}catch (e){
			var src = $(obj).attr("src");
			viewImage(src);
		}

	}
	//URL识别
	function checkURL(obj,repalceSpace){
		if(!obj || obj==null){
			return "";
		}
		var str = obj;
        if (typeof str != "string") {
            str = JSON.stringify(str)
        }
        if(repalceSpace){
			//替换转义
			str=getUrlHtml(str.replace(/&nbsp;/g,'').replace(/<br>/g,''));//兼容以前的代码
			//替换空格
			str=str.replace(/\n\n/g,'<br>').replace(/\n/g,'<br>').replace(/\u3000/g,'&nbsp;&nbsp;&nbsp;&nbsp;').replace(/\u0020/g,'&nbsp;&nbsp;');
		}
		str = str.replace(/([rl("]?[rl(']?[rl(]?[=]?['"]?)(http(s)?\:\/\/[a-zA-Z0-9]+.[a-zA-Z0-9]+[a-zA-Z0-9\$\%\#\&\/\?\-\=\.\_\;\:]+)/gi,function(match,first,second,pos,origin){
			if(first == '="' || first == "='"|| first == "rl('"|| first == "rl('"||first == "rl("){//判断url是否为元素中的属性值
				return match;
			}else {
				if(isHefeixin()){
					return first+"<a class='URLlink' title="+second+" href='"+second+"'><span>网页链接</span></a>";
				}else{
					return first+"<a class='URLlink' target='_blank' title="+second+" href='"+second+"'><span>网页链接</span></a>";
				}
			}
		});
		/*//电话号码替换
		str = str.replace(/(\d{5,15})(\d+)/g,function(s) {
			if (s.length > 15) {
				return s;
			} else {
				return "<a href='tel:" + s + "'>" + s + "</a>";
			}
		});
		//替换空格
		if('ontouchstart' in window){
			str=str.replace(/\u3000/g,'&nbsp;&nbsp;').replace(/\u0020/g,'&nbsp;').replace(/\n/g,'<br>');
		}else{
			str=str.replace(/\u3000/g,'&nbsp;&nbsp;&nbsp;&nbsp;').replace(/\u0020/g,'&nbsp;&nbsp;').replace(/\n/g,'<br>');
		}*/
		return str;
	}
	//input的div处理经过后台编辑器编辑过的内容
	function htmlTagcodeToInput(content){
	    var div = document.createElement("div");
	    div.innerHTML=htmlEncode(content).replace(/<p>/g,'').replace(/<\/p><br\/>/g,'<br/>').replace(/<\/p>/g,'<br/>');
	    return div.innerText?div.innerText.replace(/&nbsp;/g,' '):div.textContent.replace(/&nbsp;/g,' ');
	}
	/**
	 * 过滤html的标签的方法
	 * 
	 */
	function htmlTagReplace(content){
		return content.replace(/<[^>]*>/g,'');
	}
	/**
	 * @author lishengtao
	 * 2015-6-4
	 * 设置分享的属性
	 */
	function setDataForWeixinValue(title,img,summary,shareUrl,successCallback,cancelCallback){
		
		if(img!="" && img!=compressURL){
			dataForWeixin.MsgImg=img;
		}else{
			//如果图片为空，用默认图片
			dataForWeixin.MsgImg=resourceURL+"/themes/qw/images/logo/logo400.png";
		}
		
		dataForWeixin.successCallback=successCallback;
		dataForWeixin.cancelCallback=cancelCallback;
		
		
		title=$.trim(title);
		if(title!=""){
			dataForWeixin.title=title;
		}
		
		summary=$.trim(summary);
		if(summary!=""){
			dataForWeixin.desc=summary;
		}
		
		if(shareUrl.indexOf("&corp_id=")==-1){
			if(shareUrl.indexOf("?")==-1){
				shareUrl += "?";
			}
			else{
				shareUrl += "&";
			}
			shareUrl += "corp_id="+wxqyh_corpId;
			if(shareUrl.indexOf("&agentCode=")==-1){
				shareUrl += "&agentCode="+wxqyh.agent;
			}
		}
		dataForWeixin.url=shareUrl;
		if(isWeChat()){//手机端
			try{
				setOnMenuShare();
			}catch(e){
			}    
		}
	}
	
	function restoreSubmit(){
    	setTimeout(function(){
    		$('.form_btns a.fbtn').css('pointer-events','auto');
    		},500)//还原提交按钮
    };
var noImg_inList="/themes/default/images/qw/pic_normal.png";//没有显示图片，方形，用在列表中
var secretImg_inList="/themes/default/images/qw/ic_secret.png";//保密图片，方形，用在列表中
var secretImg="/themes/default/images/qw/secret.jpg";//保密图片，用在封面和发送消息

var pageAgentCode="";//记录页面的agentCode-表明模块和应用

//=======水印功能===========
var secretName="";
function shuiying(){//添加水印功能
	$('.article_detail').css('-webkit-user-select','none');
	var h=$(window).height();
    var w=$(window).width()-150;
    var t=h/3+50;
    var div=$('.article_detail');
	var h1=div.height();
    for(var i=0;i<Math.ceil(h1/t);i++){
    	div.append($('<div class="nameAfter" data-content="'+secretName+'" style="top:'+(Math.round(t*i+100))+'px;left:50%; transform: translate(-50px)"></div>'));
    }
	$(window).on('touchstart',function(){
		var top=parseInt($('.nameAfter:last').css('top'));
		var h1=div.height();
		if(h1-top>=(t+100)){
			for(var i=1;i<Math.ceil((h1-top)/t);i++){
		    	div.append($('<div class="nameAfter" data-content="'+secretName+'" style="top:'+(Math.round(t*i+100+top))+'px;left:50%; transform: translate(-50px)"></div>'));
		    }
		}

	})
}
function getUserInfo(){
    $.ajax({
        type:"POST",
        url: baseURL+"/portal/userLoginAction!getLoginUser.action",
        async: false,//设置成同步操作，为了获取用户名才执行其它操作
        cache:false,
        dataType: "json",
        success: function(result){
        	 if ("0" == result.code) {
        		 if(result.data.userVO.personName!=""&&result.data.userVO.personName!=""){
        			 secretName=result.data.userVO.personName;
        		 }
        	 }
        }
    });
}
//=======水印功能===========
//获取用户只允许拍照上传设置
function getUserSetting(agentCode,index){//index,如果你的应用只配置一个，那么可以传null,如果多个，请传你需要获取的位数
	$.ajax({
		url: baseURL+"/portal/intercalateAction!getPhotoSetting.action",
		type:"get",
		dataType:"json",
		data:{agentCode:agentCode},
		success:function(result){
			if(result.code=="0"){
				 if(result.data.is_photograph) {
					 var isPhotographs = result.data.is_photograph;
					 if(isPhotographs.indexOf("|")>=0){
						 var temp=isPhotographs.split("|");
						 if(temp[index]=='1'){
		     				chooseImageTypes=['camera'];
		     			 }
					 }else{
						 if(isPhotographs=='1'){
			     			chooseImageTypes=['camera'];
						 }
					 }
				 }
			}
		}
	});
}
//获取用户必须上传图片才可以提交表单设置
function getUserIsMustPhotoSetting(agentCode,index){//index,如果你的应用只配置一个，那么可以传null,如果多个，请传你需要获取的位数
	$.ajax({
		url: baseURL+"/portal/intercalateAction!getIsMustPhotoSetting.action",
		type:"get",
		dataType:"json",
		data:{agentCode:agentCode},
		success:function(result){
			if(result.code=="0"){
				 if(result.data.isMust) {
					 var isMusts = result.data.isMust;
					 if(isMusts.indexOf("|")>=0){
						 var temp=isMusts.split("|");
						 if(temp[index]=='1'){
		     				userIsMustPhoto='1';
		     			 }
					 }else{
						 if(isPhotographs=='1'){
							 userIsMustPhoto='1';
						 }
					 }
				 }
			}
		}
	});
}


/***---------------------模板区------------------------------**/
function HashMap() {

    /** Map 大小 **/
    var size = 0;
    /** 对象 **/
    var entry = {};

    /** 存 **/
    this.put = function (key, value) {
        if (!this.containsKey(key)) {
            size++;
        }
        entry[key] = value;
    };

    /** 取 **/
    this.get = function (key) {
        return this.containsKey(key) ? entry[key] : null;
    };

    /** 删除 **/
    this.remove = function (key) {
        if (this.containsKey(key) && ( delete entry[key] )) {
            size--;
        }
    };

    /** 是否包含 Key **/
    this.containsKey = function (key) {
        return (key in entry);
    };

    /** 是否包含 Value **/
    this.containsValue = function (value) {
        for (var prop in entry) {
            if (entry[prop] == value) {
                return true;
            }
        }
        return false;
    };

    /** 所有 Value **/
    this.values = function () {
        var values = [];
        for (var prop in entry) {
            values.push(entry[prop]);
        }
        return values;
    };

    /** 所有 Key **/
    this.keys = function () {
        var keys = [];
        for (var prop in entry) {
            keys.push(prop);
        }
        return keys;
    };

    /** Map Size **/
    this.size = function () {
        return size;
    };

    /* 清空 */
    this.clear = function () {
        size = 0;
        entry = {};
    };
}

//获取地址栏参数
function getParam(paramName){
	paramValue = "";
	isFound = false;
	if (window.location.search.indexOf("?") == 0 && window.location.search.indexOf("=")>1){
		arrSource = decodeURIComponent(window.location.search).substring(1,window.location.search.length).split("&");
		i = 0;
		while (i < arrSource.length && !isFound){
			if (arrSource[i].indexOf("=") > 0){
				 if (arrSource[i].split("=")[0].toLowerCase()==paramName.toLowerCase()){
					paramValue = arrSource[i].split("=")[1];
					isFound = true;
				 }
			}
			i++;
		}
	}
	return paramValue;
}

function GetQueryString(name){
	var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if(r!=null)return  unescape(r[2]); return null;
}
/** 
* 乘法运算，避免数据相乘小数点后产生多位数和计算精度损失。 
* 
* @param num1被乘数 | num2乘数 
*/ 
function numMulti(num1, num2) { 
	var baseNum = 0; 
	try { 
	baseNum += num1.toString().split(".")[1].length; 
	} catch (e) { 
	} 
	try { 
	baseNum += num2.toString().split(".")[1].length; 
	} catch (e) { 
	} 
	return Number(num1.toString().replace(".", "")) * Number(num2.toString().replace(".", "")) / Math.pow(10, baseNum);

}
/**
 * msgTitle 标题
 * msgContent 消息内容
 * type 1 确认；2确认，取消
 * needHandle 传入成功或者失败的处理函数，如下{ok:function(result){},fail:function(result){}}
 */
function showMsg(msgTitle, msgContent, type, needHandle) {
	var buttonText;
	if(type && type == 2){
		buttonText = "取消|确认";
	}
	else{
		buttonText = "确认";
	}
	_alert(msgTitle,msgContent,buttonText,needHandle);
}
/**确认框弹出层 
 * 示例
//_alert('自定义标题','内容内容');
//_alert('自定义标题','内容内容'，function(){console.log('确认回调函数')});
//_alert('自定义标题','内容内容',{'ok':function(){console.log('确认回调函数')},'fail':function(){console.log('取消回调函数')}})//如果没有buttonText参数,默认 取消|确认
//_alert('自定义标题','内容内容',"确认",{'ok':function(){console.log('确认回调函数')},'fail':function(){console.log('取消回调函数')}})
//_alert('自定义标题','内容内容',"取消|确认",{'ok':function(){console.log('确认回调函数')},'fail':function(){console.log('取消回调函数')}})*/
function _alert(title,text,buttonText,callback){
    var title=title||"提示";
    if(typeof(buttonText)=='string'&&buttonText.split("|").length==1){
        buttonText1=buttonText.split("|")[0];
        var buttonHtml='<div class="weui_dialog_ft">'
              +'<a href="javascript:;" class="weui_btn_dialog primary">'+buttonText1+'</a>'
              +'</div>';
        var boxClass="weui_dialog_alert custom_dialog";
    }else {
        if(typeof(buttonText)=='string'&&buttonText.split("|").length>=2){
            var buttonText1=buttonText.split("|")[0];
            var buttonText2=buttonText.split("|")[1];
        }else if(typeof(buttonText)=='function'||typeof(buttonText)=='object'&&buttonText['ok']||typeof(buttonText)=='object'&&buttonText['fail']){
            callback=buttonText;
            var buttonText1="取消";
            var buttonText2="确认";
        }else{
            var buttonText1="取消";
            var buttonText2="确认";
        }
        var buttonHtml='<div class="weui_dialog_ft">'
            +'<a href="javascript:;" class="weui_btn_dialog default">'+buttonText1+'</a>'
            +'<a href="javascript:;" class="weui_btn_dialog primary">'+buttonText2+'</a>'
            +'</div>';
        var boxClass="weui_dialog_confirm custom_dialog";
    }
    var html='<div class="'+boxClass+'">'
            +'<div class="weui_mask"></div>'
            +'<div class="weui_dialog">'
                +'<div class="weui_dialog_hd"><strong class="weui_dialog_title">'+title+'</strong></div>'
                +'<div class="weui_dialog_bd">'+text+'</div>'
                +buttonHtml
           +' </div>'
       +' </div>';
    $('body').append(html);
    $('.weui_btn_dialog.primary').off('click').on('click',function(){//确认
    	$('.weui_btn_dialog.primary').off('click');
        if(callback&&typeof(callback)=='function'){
           callback(); 
        }else if(callback&&typeof(callback)=='object'&&callback['ok']){
            callback['ok']();
        }
        $(this).parents('.custom_dialog').remove();
    });
    $('.weui_btn_dialog.default').off('click').on('click',function(){//取消
        if(callback&&typeof(callback)=='object'&&callback['fail']){
            callback['fail']();
        }
        $(this).parents('.custom_dialog').remove();
    });

}
/**
 * 打电话方法：只兼容父标签中包含a标签的方法
 * @param obj
 */
function telFunction(obj){
	if(isWeChatApp()){//手机端
		var href=$.trim($(obj).find("a").eq(0).attr("href"));
		if(href!="" && href!="#"){
			document.location.href=href;
		}
	}
}
/**
 * 复制对象的方法
 * @param obj
 * @returns {___anonymous51220_51221}
 */
 function clone(obj){  
    var o;  
    switch(typeof obj){  
    case 'undefined': break;  
    case 'string'   : o = obj + '';break;  
    case 'number'   : o = obj - 0;break;  
    case 'boolean'  : o = obj;break;  
    case 'object'   :  
        if(obj === null){  
            o = null;  
        }else{  
            if(obj instanceof Array){  
                o = [];  
                for(var i = 0, len = obj.length; i < len; i++){  
                    o.push(clone(obj[i]));  
                }  
            }else{  
                o = {};  
                for(var k in obj){  
                    o[k] = clone(obj[k]);  
                }  
            }  
        }  
        break;  
    default:          
        o = obj;break;  
    }  
    return o;     
	}
//格式化金钱:Fixed保留的位数：以分为单位，转化为元
 function formatMoney(strNumber,Fixed){
	var num=parseFloat(strNumber);
 	var returnStr="";
 	var tmpStr=num.toFixed(Fixed);
 	var splitIndex=0;
 	var hasPoint=false;
 	if(tmpStr.indexOf(".")>0){
 		hasPoint=true;
 	}
 	var beginPoint=false;
 	for(var i=tmpStr.length-1;i>=0;i--){
 		if(beginPoint){
 			if(3==splitIndex){
 				returnStr=tmpStr[i]+","+returnStr;
 				splitIndex=1;
 			}else{
 				returnStr=tmpStr[i]+returnStr;
 				splitIndex=splitIndex+1;
 			}
 		}else if("."==tmpStr[i]){
 			beginPoint=true;
 			returnStr=tmpStr[i]+returnStr;
 		}else{
 			returnStr=tmpStr[i]+returnStr;
 		}
 	}
 	return returnStr;
 }
	function checkimgURL(str,compressURL){
		var pat=/\/upload\/img(.*).png$/;
		var r=pat.exec(str);
		if(r==null)
			return str;
		str = str.replace("/upload/img"+r[1]+".png",'<p class="commentImg"><img onclick=\"comPreviewImg(this)\" src="'+compressURL+'/upload/img'+r[1]+'.png"></p>');
		return str

	}
	function isSignkImageURL(str){
		var pat=/\/upload\/img(.*).png$/;
		var r=pat.exec(str);
		if(r==null)
			return false;
		str = str.replace("/upload/img"+r[1]+".png",'');
		if(str==""){
			return false;
		}
		return true;

	}

/**
 * 获取地理位置方法
 * sunqinghai
 */
var _getLocation_times = 1;
/**
 * 获取GPS经纬度的方法，返回的经纬度信息是GPS坐标
 */
function _getGPSLocation(fuc) {
	_chooseLocation(fuc, true);
}
/**
 * 获取百度经纬度的方法，返回的经纬度信息是百度坐标
 */
function _getLocation(fuc) {
	_chooseLocation(fuc, false);
}
function _chooseLocation(fuc, isGPS) {
	//如果非微信
	if(!isWeChatApp()){
		if (isHefeixin()) {
			_getRCSCurrLocation(fuc, isGPS);
			return;
		}
		else {
			_getSysLocation(fuc, isGPS);
			return;
		}
	}
	if(wxqyh_wxjsapi.is_check_config_error){//如果已经校验过jssdk，is_check_config_error为false的情况为没有验证或者验证通过
		_getSysLocation(fuc, isGPS);

	}
	else if(wxqyh_wxjsapi.checkjsapi_config){//checkjsapi_config有没有验证通过
		_getWxLocation(fuc, isGPS);

	}
	else{//如果微信没有准备好
		if(_getLocation_times>3){//最多循环3次
			_getSysLocation(fuc, isGPS);
			return;
		}
		_getLocation_times = _getLocation_times+1;
		setTimeout(function(){
			_chooseLocation(fuc, isGPS);
		}, 500);
	}
}
/**
 * 获取当前位置
 * @param {Object} backFunc 回调函数，成功后会调用backFunc并带一个参数，该参数是json字符串，'{longitude:"xx",latitude:"xx",backId:"xx"}'
 * @param {Object} backId 请求标识
 */
var _backRCSCurrLocation;

function _getRCSCurrLocation(fuc, isGPS) {
	if(wxqyh_is_debug){
		alert("获取和飞信经纬度");
	}
	var d = {};
	d.backFunc = "_backRCSCurrLocation";
	if(isAndroid()) {
		window.WebContainer.rcsGetCurrentLocation(JSON.stringify(d));
	}
	else {
		navigator.WebContainer.rcsGetCurrentLocation(JSON.stringify(d));
	}

	_backRCSCurrLocation = function (gpsPoint){
		if(wxqyh_is_debug){
			alert("和飞信经纬度"+gpsPoint);
		}
		var obj = JSON.parse(gpsPoint);
		_getAddress(obj.longitude,obj.latitude,fuc, isGPS);
	}
}

function _getAddress(longitude,latitude,fuc, isGPS){
	if(wxqyh_is_debug){
		alert("转换位置信息");
	}
	var point=new BMap.Point(longitude,latitude);
	try {
		var pointArr = [];
		pointArr.push(point);
		var convertor = new BMap.Convertor();
		convertor.translate(pointArr, 1, 5, function(data) {
			if (wxqyh_is_debug) {
				alert("纠偏后的信息：" + JSON.stringify(data));
			}
			if(data.status === 0) {
				poi = data.points[0];
				if (wxqyh_is_debug) {
					alert("获取前" + poi.lat + ";" + poi.lng);
				}
				if (!poi.lat || poi.lat == 0 || !poi.lng || poi.lng == 0) {
					_callError(err, fuc);
					return;
				}
				if(!isGPS){
					latitude = poi.lat; // 纬度，浮点数，范围为90 ~ -90
					longitude = poi.lng;
				}
				var geoc = new BMap.Geocoder();
				geoc.getLocation(poi, function (rs) {
					var address = rs.address;
					var addComp = rs.addressComponents;
					//泰国返回json如下{"point":{"lng":100.53779,"lat":13.756313},"address":"","addressComponents":{"streetNumber":"","street":"","district":"","city":"Ratchathewi","province":"Bangkok Metropolis"},"surroundingPois":[{"title":"Bangkok Christian Church","uid":"9fee3e11c0cfce470e0a70ca","point":{"lng":100.537778,"lat":13.75675},"city":"Ratchathewi","Ti":"","type":0,"address":"","postcode":null,"phoneNumber":null},{"title":"Bun Wisut Building","uid":"3f89c1e8f91d160e6dc02c15","point":{"lng":100.538263,"lat":13.756776},"city":"Ratchathewi","Ti":"","type":0,"address":"","postcode":null,"phoneNumber":null},{"title":"Suan Pakkard Palace","uid":"2269fa5d3370194b9ce32157","point":{"lng":100.536996,"lat":13.756495},"city":"Ratchathewi","Ti":"","type":0,"address":"","postcode":null,"phoneNumber":null}],"business":""}
					if (!address && addComp) {//泰国存在addComp，单不存在rs.address
						address = "";
						if (addComp.province) {
							address += "," + addComp.province;
						}
						if (addComp.city) {
							address += "," + addComp.city;
						}
						if (addComp.district) {
							address += "," + addComp.district;
						}
						if (addComp.street) {
							address += "," + addComp.street;
						}
						if (addComp.streetNumber) {
							address += "," + addComp.streetNumber;
						}
						address = address.replace(",","");
					}
					if (wxqyh_is_debug) {
						alert(longitude + ";" + latitude + ";" + address);
					}
					var e = fuc.ok;
					if (e) {
						e.call(e, longitude, latitude, address, addComp);
					}
				});
			}
			else if(data.status === 4){
				_getGoogleAddress(longitude, latitude, fuc);
			}
			else {
				_callError("百度纠偏异常："+data.status+","+data.message, fuc);
			}
		});
	} catch (err){
		_localBaiduConvert(longitude,latitude,fuc, isGPS);
	}
}
function _localBaiduConvert(longitude,latitude,fuc, isGPS){
	if(wxqyh_is_debug){
		alert("通过本地服务转换位置信息");
	}
	try {
		$.ajax({
			url : baseURL+"/portal/errcode/errcodeAction!baiduConvert.action?longitude="+longitude+"&latitude="+latitude,
			type:"GET",
			dataType:"json",
			success:function(result){
				if(result.code != "0"){
					_callError(result.desc, fuc);
					return;
				}
				var poi=new BMap.Point(result.data.longitude,result.data.latitude);
				var geoc = new BMap.Geocoder();
				if(!isGPS){
					latitude = result.data.latitude; // 纬度，浮点数，范围为90 ~ -90
					longitude = result.data.longitude;
				}
				geoc.getLocation(poi, function (rs) {
					var address = rs.address;
					if (wxqyh_is_debug) {
						alert(longitude + ";" + latitude + ";" + address);
					}
					var addComp = rs.addressComponents;
					var e = fuc.ok;
					if (e) {
						e.call(e, longitude, latitude, address, addComp);
					}
				});
			},
			error:function(err){
				_callError("服务百度纠偏网络错误："+JSON.stringify(err), fuc);
			}
		});
	} catch (err){
		_callError("服务百度纠偏错误："+JSON.stringify(err), fuc);
	}
}
//获取谷歌的地址信息
function _getGoogleAddress(longitude, latitude, fuc){
	if(wxqyh_is_debug){
		alert("google转换位置信息");
	}
	$.ajax({
		url : wxqyh_scheme+"://maps.google.com/maps/api/geocode/json?latlng="+latitude+","+longitude+"&language=zh-CN&sensor=false",
		type:"GET",
		dataType:"json",
		success:function(result){
			if(result.status === 'OK'){
				results = result.results[0];
				if (results) {
					var addComp = {};
					address_components = results.address_components;
					if(address_components && address_components.length > 0){
						for(var i=0;i<address_components.length;i++){
							types = address_components[i].types;
							for(var j=0;j<types.length;j++) {
								var type = types[j];
								if (type == "country") {
									addComp.country = address_components[i].long_name;
								}
								if (type == "administrative_area_level_1") {
									addComp.province = address_components[i].long_name;
								}
								if (type == "locality") {
									addComp.city = address_components[i].long_name;
								}
								if (type == "sublocality_level_1") {
									addComp.district = address_components[i].long_name;
								}
								if (type == "route") {
									addComp.street = address_components[i].long_name;
								}
								if (type == "street_number") {
									addComp.streetNumber = address_components[i].long_name;
								}
							}
						}
					}
					var address = results.formatted_address;
					var e = fuc.ok;
					if (e) {
						e.call(e, longitude, latitude, address, addComp);
					}
				}
				else{
					_callError("获取google位置为空", fuc);
				}
			}else{
				_callError("获取google位置失败", fuc);
				if (wxqyh_is_debug) {
					alert(JSON.stringify(result));
				}
			}
		},
		error:function(err){
			_callError("google转换位置网络错误："+JSON.stringify(err), fuc);
		}
	});
}
function _callError(errMsg, fuc){
	if(fuc){
		var e = fuc.fail;
		if (e) {
			e.call(e, errMsg);
		}
	}
}
function _getWxLocation(fuc, isGPS) {
	if(wxqyh_is_debug){
		alert("通过微信获取地理位置");
	}
	wx.getLocation({
		success: function (res) {
			var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
			var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
			if (longitude != "" && longitude != null && latitude != "" && latitude != null) {
				_getAddress(longitude,latitude,fuc, isGPS);
			} else {
				_getSysLocation(fuc, isGPS);
			}
		},
		fail: function (err) {
			_getSysLocation(fuc, isGPS);
		}
	});
}
function _getSysLocation(fuc, isGPS) {
	if(wxqyh_is_debug){
		alert("通过浏览器获取地理位置");
	}
	if (navigator.geolocation){
		navigator.geolocation.getCurrentPosition(function showPosition(gpsPoint){
			_getAddress(gpsPoint.coords.longitude+"",gpsPoint.coords.latitude+"",fuc, isGPS);
		}, function(error){_getSysLocationError(error,fuc);},{timeout:20000});
	}else{
		var e = fuc.fail;
		if (e) {
			e.call(e, "你的浏览器不支持获取位置信息");
		}
	}
}

/**
 * 根据GPS的经纬度显示百度地图
 */
function _showBaiduFromGPS(baiduDiv, longitude, latitude, address) {
	var point=new BMap.Point(longitude, latitude);
	var pointArr = [];
	pointArr.push(point);
	var convertor = new BMap.Convertor();
	convertor.translate(pointArr, 1, 5, function(data) {
		if(data.status === 0) {
			point = data.points[0];
			_showBaidu(baiduDiv, point, address);
		}
	});
}
/**
 * 根据百度的经纬度显示百度地图
 */
function _showBaidurFromBaidu(baiduDiv, longitude, latitude, address) {
	var point=new BMap.Point(longitude, latitude);
	_showBaidu(baiduDiv, point, address);
}
function _showBaidu(baiduDiv, point, address) {
	// 百度地图API功能
	var map = new BMap.Map(baiduDiv);
	//var point = new BMap.Point(position.coords.longitude,position.coords.latitude);
	map.centerAndZoom(point, 15);

	var opts = {
		width : 250,     // 信息窗口宽度
		height: 40,     // 信息窗口高度
		title : ""  // 信息窗口标题
	};
	var infoWindow = new BMap.InfoWindow("地址：" + address, opts);  // 创建信息窗口对象
	map.openInfoWindow(infoWindow,point); //开启信息窗口
	var my_icon =new BMap.Icon(baseURL+"/jsp/wap/images/point2.png", new BMap.Size(26, 26));
	var my_marker= new BMap.Marker(point,{icon:my_icon});
	map.addOverlay(my_marker);
	/* var label = new BMap.Label('<div class="myPlace" style="left: 9px;bottom: -43px;"><img src="${baseURL}/wap/component/images/point2.png" alt=""/><div class="popdiv2" style="left:-82px;top:-40px;" ><h3>在这里</h3>  </div></div>',{"offset":new BMap.Size(-10,-20)});
	 my_marker.setLabel(label); */
	//map.addOverlay(my_marker);
	map.addControl(new BMap.OverviewMapControl());
	//map.addControl(new BMap.ZoomControl());          //添加地图缩放控件
}
	function _getSysLocationError(error,fuc) {
		var e = fuc.fail;
		if (e) {
			var msg;
			switch (error.code) {
				case error.PERMISSION_DENIED:
					msg = "暂未获取到位置信息，请确认手机设置中已经允许本应用使用定位服务";
					break;
				case error.POSITION_UNAVAILABLE:
					msg = "获取不到位置信息，请检查GPS定位设置并重新进入页面，如不能解决请尝试重启微信或重启手机";
					break;
				case error.TIMEOUT:
					msg = "获取位置信息超时，请重试";
					break;
				default:
					msg = "暂未获取到位置信息，请重试";
					break;
			}
			if(wxqyh_is_debug){
				alert(msg);
			}
			e.call(e, msg);
		}
	}


	//视频播放兼容http
	function videoPlayback(){
		var video_obj=$("#content").find("iframe,embed");
		if(video_obj==0){

		}else{
			var k = 608/88;
			video_obj.each(function(i){
				var video_src = video_obj.eq(i).attr("src");
				var video_width = video_obj.eq(i).width();
				if(video_src!=""&&video_src!=null&&video_src!=undefined){
					if(video_src.indexOf(wxqyh_scheme)==-1){
						video_obj.eq(i).attr("src","");
						video_obj.eq(i).after('<div class="video_div" style="position:relative;"></div>');
						$(".video_div:last").append(video_obj.eq(i));
						$(".video_div:last").append('<div class="video_div_c"></div>');
						video_obj.eq(i).width("100%");
						$(".video_div_c").width("100%");
						if($("#content").width()>608){
							video_obj.eq(i).width("608px");
							$(".video_div_c").width("608px");
							video_obj.eq(i).height("88px");
							$(".video_div_c").height("88px");
						}else{
							video_obj.eq(i).height(($(window).width()-20)*88/608);
							$(".video_div_c").height(($(window).width()-20)*88/608);
						}
						/*if(video_obj.eq(i).height()<45){
							var oh = video_obj.eq(i).height()*0.9
							$(".video_div:last").append('<div class="video_div_c" style="background-size: '+oh+'px; background-position: 5px"></div>');
						}else{
							$(".video_div:last").append('<div class="video_div_c"></div>');
						}*/
						$(".video_div_c:last").on("click",function(){
							window.top.location.href=baseHttpURL+"/open/ueditor/play.jsp?link="+video_src;
						});
					}
				}
			})
		}
	}

	//后台管理页面获取地址头
	function getImgURLHead(URL) {
		if (URL != null && (URL.indexOf("/manager/images/") >= 0 || URL.indexOf("/upload/img/zhounian/") >= 0 || URL.indexOf("/upload/img/birthday/")>=0)) {
			 return baseURL;
		} else {
			return compressURL;
		}
	}

	// 图片原比例标识图片
	function drawImage(ImgD,iwidth,iheight){
		var image=new Image();
		image.src=ImgD.src;
		if(image.width>0 && image.height>0){
			if(image.width >= image.height){
				if(image.width>iwidth){ 
					ImgD.width=iwidth;
					ImgD.height=image.height*(iwidth/image.width);
				}else{
					ImgD.width=iwidth; 
					ImgD.height=image.height*(iwidth/image.width);
				}
			}else{
				if(image.height>iheight){ 
					ImgD.height=iheight;
					ImgD.width=image.width*(iheight/image.height); 
				}else{
					ImgD.width=image.width*(iheight/image.height); 
					ImgD.height=iheight;
				}
			}
		}
	}

	/**
	 * 动态加载js,js文件跨站时，无法同步加载，请使用callback参数
	 * @param a
	 * @param callback
	 */

	function loadJs(a,callback) {
		/**var script = $('<script  type="text/javascript"></script>').attr("src",a);;
		$(document.head).append(script);**/
		
		
		if(a.indexOf("?") > 0){
			a = a +"&jsVer="+jsVer;
		}else{
			a = a +"?jsVer="+jsVer;
		}
		
		$.ajax({
	        url: a,
	        type: "GET",
	        dataType: "script",
	        async: false,
	        global: false,
	        cache:true,
	        "throws": true,
	        success:function(){
	        	if(callback)callback();
	        }
        });
    }

// 获取当前时间
function getCurrentTime() {
    var date = new Date();
    this.year = date.getFullYear();
    this.month = date.getMonth() + 1;
    this.date = date.getDate();
    this.day = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"][date.getDay()];
    this.hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    this.minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    this.second = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();

    var currentTime = {
        year: this.year,
        month: this.month,
        date: this.date,
        day: this.day,
        hour: this.hour,
        minute: this.minute,
        second: this.second,
    };
    return currentTime;
}

//获取时间:不是今年的返回年月日,当年的返回月和天,当日的返回时和分
function getFormatTime(str){
	var str=str.replace(/-/g,"/");
	var nowTime = new Date(),
		time = new Date(str),
		nowYear = +nowTime.getFullYear(),
		getFullYear = time.getFullYear()<10?"0"+time.getFullYear():time.getFullYear(),
		getMonth = (time.getMonth()+1)<10?"0"+(time.getMonth()+1):(time.getMonth()+1),
		getDate = time.getDate()<10?"0"+time.getDate():time.getDate();
	if(getFullYear!=nowYear){
		return getFullYear+"-"+getMonth+"-"+getDate;
	}else{
		if(nowTime.getMonth()==time.getMonth()&&nowTime.getDate()==time.getDate()){
			var getHours = time.getHours()<10?"0"+time.getHours():time.getHours();
			var getMinutes = time.getMinutes()<10?"0"+time.getMinutes():time.getMinutes();
			return getHours+":"+getMinutes;
		}else{
			return getMonth+"-"+getDate;
		}
	}
}

$(document).ready(function(){
	wxqyhConfig.ready(function(){
		if(wxqyhConfig.is_qiweiyun && showQw()){
			$(".oemClass").show();
		}else{
			$(".oemClass").hide();
		}
	});
});


/**
 * 保持session心跳
 * @param linkTime 单位：毫秒，重新请求间隔，默认300000（5分钟）
 * @param maxSessionCounts 最大请求次数，默认30次
 */
function continueSession(linkTime, maxSessionCounts){
	if(!linkTime){
		linkTime = 300000; //默认5分钟请求一次
	}
	if(!maxSessionCounts){
		maxSessionCounts = 30 ;
	}
	var continueSessionCounts = 0,myContinueSession;
	myContinueSession = setInterval(function(){
		//console.log(continueSessionCounts);
		if(continueSessionCounts>maxSessionCounts){
			clearInterval(myContinueSession);
			//console.log(continueSessionCounts);
		}else{
			$.ajax({
				url : baseURL+"/portal/cooperationOpen/cooperationOpenAction!continueSession.action",
				type : "POST",
				dataType : "json",
				success : function(result) {
					continueSessionCounts = continueSessionCounts + 1;
				},
				error : function() {
					continueSessionCounts = continueSessionCounts + 1;
				}
			});
		}
	},linkTime); //每5分钟执行一次
}
loadJs(baseURL+"/themes/manager/js/vip_portal.js"); //加载VIP判断信息
/**
 * HTML格式化输出
 */
function forHTML(s){
	if(typeof s == "string"){
		return s.replaceAll('<','&lt;').replaceAll('>','&gt;').replaceAll('"','&quot;').replaceAll('\'','&#39;').replaceAll(' ','&#32;').replaceAll('\t','&#9;').replaceAll('\n','&#13;');
	}
	if(typeof s == "object"){
		for(var k in s){
			s[k]=forHTML(s[k]);
		}
		return s;
	}
	return s;
}
/**
 * 复制文本到剪切板
 * @param text
 */
function copyText(text,successCall,errorCall){
	if(typeof window.hasLoadClipboard=="undefined" ){
		loadJs(baseURL+"/manager/js/clipboard.js");
		window.hasLoadClipboard=1;
	}
	if(!window.cpIndex){
		window.cpIndex=1;
	}else{
		window.cpIndex=	window.cpIndex+1;
	}
	$(document.body).append('<button data-clipboard-text="'+text+'" style="display:none;" id="copyText'+window.cpIndex+'">Copy</button>');
	 var clipboard = new Clipboard($("#copyText"+window.cpIndex)[0]);

	    if(successCall)clipboard.on('success', function(e) {
	    	successCall(text,e);
	    });

	    if(errorCall)clipboard.on('error', function(e) {
	    	errorCall(text,e);
	    });
    $("#copyText"+window.cpIndex).click();
}

/**
 * 判断某应用是否托管
 * @param agentCode
 */
function isTrustAgent(agentCode){
    //判断考试测评是否有托管， 无托管点击考试内容则进考试引导页， 有的话直接进页面
    var isTrust =  false;
    $.ajax({
        url: baseURL+'/portal/application/application!ajaxIsTrustAgentForPortal.action',
        type: 'post',
        data: {"agentCode": agentCode},
        dataType: 'json',
        async:false,
        success: function (result) {
            if ('0' == result.code) {
                //如果没有托管，进引导页
                isTrust = result.data.isTrust;
            }else {
                isTrust = false;
            }
        },
        error :function(result){
            isTrust = false;
        }
    });
    return isTrust;
}
/**
 * 是否可调用扫码
 * @returns {boolean}
 */
function isGetCode(){
	if(isHefeixin()){
		return true;
	}
	return false;
}

/**
 * 是否可使用定位
 */
function isGetLocation(){
	if(isWeChatApp() || isHefeixin()){
		return true;
	}
	return false;
}

/**
 * 调取扫一扫接口
 * @param {Object} backFunc
 */
function getQRContent(backFunc){
	var d = {};
	d.backFunc = backFunc;
	if(isAndroid()){
		window.WebContainer.getQRContent(JSON.stringify(d));
	}else{
		navigator.WebContainer.getQRContent(JSON.stringify(d));
	}
}
/**
 * 参考java String.format 
 * 用法1："Hello {0}!".format("World");
 * 用法2："Hello {name}!".format({name:"World"});
 */
String.prototype.format = function(args) {
    var result = this;
    if (arguments.length > 0) {    
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if(args[key]!=undefined){
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined) {
　　　　　　　　　　　　var reg= new RegExp("({)" + i + "(})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
}
/**前往后台提示框
 title：标题；text：内容；isLoginMsg：是否加固定内容；buttonText：默认取消|确定；callbak:回调
 */
function _alertDialog(title, text, isLoginMsg, buttonText, callback) {
	var title = title || "提示";
	if (typeof(buttonText) == 'string' && buttonText.split("|").length == 1) {
		buttonText1 = buttonText.split("|")[0];
		var buttonHtml = '<div class="weui-dialog-ft">' +
			'<a href="javascript:;" class="weui-dialog-btn weui-dialog-btn_primary">' + buttonText1 + '</a>' +
			'</div>';
		var boxClass = "js-weui-dialog";
	} else {
		if (typeof(buttonText) == 'string' && buttonText.split("|").length >= 2) {
			var buttonText1 = buttonText.split("|")[0];
			var buttonText2 = buttonText.split("|")[1];
		} else if (typeof(buttonText) == 'function' || typeof(buttonText) == 'object' && buttonText['ok'] || typeof(buttonText) == 'object' && buttonText['fail']) {
			callback = buttonText;
			var buttonText1 = "取消";
			var buttonText2 = "确认";
		} else {
			var buttonText1 = "取消";
			var buttonText2 = "确认";
		}
		var buttonHtml = '<div class="weui-dialog-ft">' +
			'<a href="javascript:;" class="weui-dialog-btn weui-dialog-btn_default mr10">' + buttonText1 + '</a>' +
			'<a href="javascript:;" class="weui-dialog-btn weui-dialog-btn_primary">' + buttonText2 + '</a>' +
			'</div>';
		var boxClass = "js-weui-dialog";
	}
	if (isLoginMsg == "1") {
		text = '<p>' + text + '</p> ' +
			'<div class="weui-dialog-line"></div> ' +
			'<p>登录企业微信后台，请访问：<br>https://work.weixin.qq.com/login</p>'
	}
	var html = '<div class="' + boxClass + '">' +
		'<div class="weui-dialog-mask"></div>' +
		'<div class="weui-dialog">' +
		'<div class="weui-dialog-hd">' + title + '</div>' +
		'<div class="weui-dialog-bd"><p>' + text + '<p></div>' +
		buttonHtml +
		' </div>' +
		' </div>';
	$('body').append(html);
	$('.weui-dialog-btn_primary').off('click').on('click', function() { //确认
		$('.weui-dialog-btn_primary').off('click');
		if (callback && typeof(callback) == 'function') {
			callback();
		} else if (callback && typeof(callback) == 'object' && callback['ok']) {
			callback['ok']();
		}
		$(this).parents('.js-weui-dialog').remove();
	});
	$('.weui-dialog-btn_default').off('click').on('click', function() { //取消
		if (callback && typeof(callback) == 'object' && callback['fail']) {
			callback['fail']();
		}
		$(this).parents('.js-weui-dialog').remove();
	});
}
function closeGuideDialog() {
	$.ajax({
		type: "POST",
		url: baseURL + "/portal/managesetting!ajaxUpdateRemindUser.action",
		data: {"agentCode": wxqyh.agent},
		dataType: "json",
		success: function (result) {
			if ("0" != result.code) {
				_alert('提示', result.desc, '确定');
			}
		}
	});
}

/*企业微信返回事件*/
function historyBack(config){
	if(config.type=='index'){
		/*返回退出-start*/
		$(function(){
			wx.ready(function(){
				wx.onHistoryBack(function(){
					wx.closeWindow();
				});
			})
		})
		/*返回退出-end*/
	}else if(config.type=='order'){
		/*返回-start*/
		$(function(){
			wx.ready(function(){
				wx.onHistoryBack(function(){
					location.href=config.url
					return false
				});
			})
		})
	}
}
