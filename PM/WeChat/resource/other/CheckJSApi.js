var appid="";
var timestamp="";
var nonceStr="";
var signature="";
var count=0;

var wxqyh_checkjsapi_url;//jsapi验证方法
var wxqyh_isUsePublic = "";//jsapi验证方法返回的是否使用公用corpid
var wxJsCheckHasResult = false;//微信js认证是否有返回

$(document).ready(function () {
	var urls=window.location.href;
	if(!isWeChat()) {
		if(isHefeixin()){
			var e = wxqyh_wxjsapi.ready;
			e && e.call(e, null, null);
		}
		return false;
	}
	if(wxqyh_is_debug){
		alert("wx.ready开始");
	}
	/*var ua = navigator.userAgent.toLowerCase();
	 if((ua.match(/MicroMessenger/i)!="micromessenger")) {
	 return false;
	 }*/
	wx.ready(function(){//不管微信成功失败，都会调用此方法
		
		wxJsCheckHasResult = true;
		if(wxqyh_is_debug){
			alert("wx.ready开始执行");
		}
		if(isWeChatApp()){
			wx.checkJsApi({
				jsApiList: ['chooseImage','onHistoryBack'],
				success: function(res){
					if(res.checkResult.chooseImage){
						checkJsApi_image = true;
					}else{
						checkJsApi_image = false;
					}
				}
			});
			//证明第一次ready
			if (!wxqyh_wxjsapi.checkjsapi_config) {
				wxqyh_wxjsapi.checkjsapi_config = true;
				/*if(count==0 && !wxqyh_wxjsapi.is_check_config_error){//如果验证失败，不调用ready回调
				}*/
				var e = wxqyh_wxjsapi.ready;
				e && e.call(e, null, null);
			}
		}
		setOnMenuShare();
		// config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
	});
	wx.error(function(res){
		wxJsCheckHasResult = true;
		if(isWeChatApp()){
			checkJsApi_image = false;
			wxqyh_wxjsapi.is_check_config_error = true;
			if(count==0){
				var e = wxqyh_wxjsapi.error;
				e && e.call(e, null, null);
			}
		}
		if(res.errMsg.indexOf("signature")!=-1){
			if(count==0){
				errorFuntion(res.errMsg);
			}else{
				setTimeout(errorFuntion,1000);
			}
		}
	});
	if(!wxqyh_isOpen && (wxqyh.agent=="addressBook" || window.location.href.indexOf("dynamicinfoManage/private_detail.jsp")>-1
		|| window.location.href.indexOf("pay/wap/wxpay.jsp")>-1)){
		wxqyh_checkjsapi_url = baseURL+"/portal/weixinjs/weixinjsAction!authorizeMe.action";
	}
	else{
		wxqyh_checkjsapi_url = baseURL+"/portal/weixinjs/weixinjsAction!authorize.action";
	}
	$.ajax({
		url:wxqyh_checkjsapi_url,
		type:"POST",
		data:{url:urls,isOpen:wxqyh_isOpen},
		dataType:"json",
		success:function(result){
			//wxhideMenuItems();
			//setTimeout(wxhideMenuItems,2000);
			if(result.code=="0"){
				wxqyh_isUsePublic = result.data.isUsePublic;
				setTimeout(function(){gotoWeixinConfigRepeat(result.data.apijs);},5000);
				gotoWeixinConfig(result.data.apijs);
			}
			else{
				if(wxqyh_is_debug){
					alert("验证微信js-sdk失败："+JSON.stringify(result));
				}
				checkJsApi_image = false;
				if(isWeChatApp()){
					var e = wxqyh_wxjsapi.error;
					wxqyh_wxjsapi.is_check_config_error = true;
					if(e != null)
						e && e.call(e, null, null);
				}
			}
		},
		error:function(err){
			if(wxqyh_is_debug){
				alert("验证微信js-sdk网络异常："+JSON.stringify(err));
			}
			checkJsApi_image = false;
			if(isWeChatApp()){
				wxqyh_wxjsapi.is_check_config_error = true;
				var e = wxqyh_wxjsapi.error;
				if(e != null)
					e && e.call(e, null, null);
			}
		}
	});
});

function setOnMenuShare(){
	if(!dataForWeixin.title && !dataForWeixin.url){
		return;
	}
	wx.onMenuShareAppMessage({
		title: dataForWeixin.title, // 分享标题
		desc: dataForWeixin.desc, // 分享描述
		link: dataForWeixin.url, // 分享链接
		imgUrl: dataForWeixin.MsgImg, // 分享图标
		type: 'link', // 分享类型,music、video或link，不填默认为link
		dataUrl: '', // 如果type是music或video，则要提供数据链接，默认为空
		success: function () {
			// 用户确认分享后执行的回调函数
			if(dataForWeixin.successCallback)dataForWeixin.successCallback();
		},
		cancel: function () {
			// 用户取消分享后执行的回调函数
			if(dataForWeixin.cancelCallback)dataForWeixin.cancelCallback();
		}
	});
    wx.onMenuShareWechat({
        title: dataForWeixin.title, // 分享标题
        desc: dataForWeixin.desc, // 分享描述
        link: dataForWeixin.url, // 分享链接
        imgUrl: dataForWeixin.MsgImg, // 分享图标
        type: 'link', // 分享类型,music、video或link，不填默认为link
        dataUrl: '', // 如果type是music或video，则要提供数据链接，默认为空
        success: function () {
            // 用户确认分享后执行的回调函数
            if(dataForWeixin.successCallback)dataForWeixin.successCallback();
        },
        cancel: function () {
            // 用户取消分享后执行的回调函数
            if(dataForWeixin.cancelCallback)dataForWeixin.cancelCallback();
        }
    });
	wx.onMenuShareTimeline({
		title: dataForWeixin.title, // 分享标题
		link: dataForWeixin.url, // 分享链接
		imgUrl: dataForWeixin.MsgImg, // 分享图标
		success: function () {
			// 用户确认分享后执行的回调函数
			if(dataForWeixin.successCallback)dataForWeixin.successCallback();
		},
		cancel: function () {
			// 用户取消分享后执行的回调函数
			if(dataForWeixin.cancelCallback)dataForWeixin.cancelCallback();
		}
	});
	wx.onMenuShareQQ({
		title: dataForWeixin.title, // 分享标题
		link: dataForWeixin.url, // 分享链接
		imgUrl: dataForWeixin.MsgImg, // 分享图标
		desc: dataForWeixin.desc, // 分享描述
		success: function () {
			// 用户确认分享后执行的回调函数
			if(dataForWeixin.successCallback)dataForWeixin.successCallback();
		},
		cancel: function () {
			// 用户取消分享后执行的回调函数
			if(dataForWeixin.cancelCallback)dataForWeixin.cancelCallback();
		}
	});
	wx.onMenuShareWeibo({
		title: dataForWeixin.title, // 分享标题
		link: dataForWeixin.url, // 分享链接
		imgUrl: dataForWeixin.MsgImg, // 分享图标
		desc: dataForWeixin.desc, // 分享描述
		success: function () {
			// 用户确认分享后执行的回调函数
			if(dataForWeixin.successCallback)dataForWeixin.successCallback();
		},
		cancel: function () {
			// 用户取消分享后执行的回调函数
			if(dataForWeixin.cancelCallback)dataForWeixin.cancelCallback();
		}
	});
}

function errorFuntion(errMsg){
	$.ajax({
		url:wxqyh_checkjsapi_url,
		type:"GET",
		data:{url:urls,errMsg:errMsg,isOpen:wxqyh_isOpen},
		dataType:"json",
		success:function(result){
			if(result.code=="0"){
				wxqyh_wxjsapi.is_check_config_error = false;
				wxqyh_isUsePublic = result.data.isUsePublic;
				gotoWeixinConfig(result.data.apijs);
			}
			else if(count<2){
				count = count+1;
				setTimeout(errorFuntion,1000);
			}
		}
	});
}
/**
 * 如果500毫秒还未返回结果，重试
 * @param obj
 */
function gotoWeixinConfigRepeat(obj){
	if(count < 4 &&  !wxJsCheckHasResult){
		//没有返回，0.5秒后重试，最多重复3次
		if(wxqyh_is_debug){
			alert("wx.config 第"+(count+1));
		}
		setTimeout(function(){gotoWeixinConfigRepeat(obj);},2000);
		gotoWeixinConfig(obj);
	}
}
function gotoWeixinConfig(obj){
	count = count+1;
	var apijs=obj;
	if(apijs==null){
		return ;
	}
	appid=apijs.corpId;
	timestamp=apijs.timestamp;
	nonceStr=apijs.noncestr;
	signature=apijs.signature;
	if(wxqyh_is_debug) {
		alert(JSON.stringify(apijs));
	}
	wx.config({
		beta: true,
		debug: wxqyh_is_debug,
		appId: appid,
		timestamp: timestamp,
		nonceStr: nonceStr,
		signature: signature,
		jsApiList: ['chooseInvoice','getSupportSoter','requireSoterBiometricAuthentication',
			'checkJsApi',
			'onMenuShareTimeline',
			'onMenuShareAppMessage',
			'onMenuShareWechat',
			'onMenuShareQQ',
			'onMenuShareWeibo',
			'hideMenuItems',
			'showMenuItems',
			'hideAllNonBaseMenuItem',
			'showAllNonBaseMenuItem',
			'translateVoice',
			'startRecord',
			'stopRecord',
			'onRecordEnd',
			'playVoice',
			'pauseVoice',
			'stopVoice',
			'uploadVoice',
			'downloadVoice',
			'chooseImage',
			'previewImage',
			'uploadImage',
			'downloadImage',
			'getNetworkType',
			'openLocation',
			'getLocation',
			'hideOptionMenu',
			'showOptionMenu',
			'closeWindow',
			'scanQRCode',
			'chooseWXPay',
			'openProductSpecificView',
			'addCard',
			'chooseCard',
			'openCard',
			'openEnterpriseChat',
			'onHistoryBack'
		]
	});
}

//禁用分享等功能
function wxhideMenuItems(){
	/* wx.hideMenuItems({
	 menuList: [
	 'menuItem:share:qq', // 阅读模式
	 'menuItem:share:weiboApp', // 阅读模式
	 'menuItem:share:appMessage', // 阅读模式
	 'menuItem:readMode', // 阅读模式
	 'menuItem:share:timeline', // 分享到朋友圈
	 'menuItem:copyUrl' // 复制链接
	 ],
	 success: function (res) {
	 //alert('已隐藏“阅读模式”，“分享到朋友圈”，“复制链接”等按钮');
	 },
	 fail: function (res) {
	 //alert(JSON.stringify(res));
	 }
	 });*/
}


function _checkWxJsApi(type,callback){
	wx.checkJsApi({
		jsApiList: [type],
		success: function(res){
			var result;
			if(res.checkResult[type]){
				result = true;
			}else{
				result = false;
			}
			if(callback)
				callback.call(callback, result);
		}
	});
};

function createWxChat(wxUserId){
	wx.openEnterpriseChat({
		userIds: wxUserId,
		groupName: '', //openEnterpriseChat讨论组
		success: function(res){
			// 回调
		},
		fail: function(res){
			if(res.errMsg.indexOf('function not exist') > 0){
				_alert('提示', '版本过低请升级');
			}else{
				_alert('提示', '该功能不能使用，企业微信已停止提供企业消息会话服务。');
			}
		}
	});
}