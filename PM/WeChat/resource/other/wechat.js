/**
 * 微信网页端调用JS
 * @author dodge
 * @contact dodgepudding@gmail.com
 * @link http://blog.4wer.com/wechat-timeline-share
 * @version 1.1
 * 
 * 自定义分享使用：
 * WeixinJS.hideOptionMenu() 隐藏右上角按钮
 * WeixinJS.hideToolbar() 隐藏工具栏
 * WeixinJS.isWeixin() 判断是否微信内置浏览器
*/
WeixinJS = typeof WeixinJS!='undefined' || {};
WeixinJS.hideOptionMenu = function() {
	document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
		if (typeof WeixinJSBridge!='undefined')	WeixinJSBridge.call('hideOptionMenu');
	});
};
WeixinJS.hideToolbar = function() {
	document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
		if (typeof WeixinJSBridge!='undefined') WeixinJSBridge.call('hideToolbar');
	});
};

//判断是否微信内置浏览器
/*WeixinJS.isWeixin = function() {
	var ua = navigator.userAgent.toLowerCase();
	if(ua.match(/MicroMessenger/i)=="micromessenger") {
		return true;
	} else {
		return false;
	}
};*/

(function(){
   var onBridgeReady=function(){
   /*WeixinJSBridge.on('menu:share:appmessage', function(argv){
	   
      WeixinJSBridge.invoke('sendAppMessage',{
         "appid":dataForWeixin.appId,
         "img_url":dataForWeixin.MsgImg,
         "img_width":"120",
         "img_height":"120",
         "link":"http://www.oschina.net/code/snippet_1399261_37142",
         "desc":dataForWeixin.desc,
         "title":dataForWeixin.title
      }, function(res){alert(dataForWeixin.url);(dataForWeixin.callback)();});
   });
   WeixinJSBridge.on('menu:share:timeline', function(argv){
	   alert(dataForWeixin.url);
      (dataForWeixin.callback)();
      WeixinJSBridge.invoke('shareTimeline',{
         "img_url":dataForWeixin.TLImg,
         "img_width":"120",
         "img_height":"120",
         "link":dataForWeixin.url,
         "desc":dataForWeixin.desc,
         "title":dataForWeixin.title
      }, function(res){});
   });
   WeixinJSBridge.on('menu:share:weibo', function(argv){
      WeixinJSBridge.invoke('shareWeibo',{
         "content":dataForWeixin.title,
         "url":dataForWeixin.url
      }, function(res){(dataForWeixin.callback)();});
   });
   WeixinJSBridge.on('menu:share:facebook', function(argv){
      (dataForWeixin.callback)();
      WeixinJSBridge.invoke('shareFB',{
         "img_url":dataForWeixin.TLImg,
         "img_width":"120",
         "img_height":"120",
         "link":dataForWeixin.url,
         "desc":dataForWeixin.desc,
         "title":dataForWeixin.title
      }, function(res){(dataForWeixin.callback)();});
   });*/
};
if(document.addEventListener){
   document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
}else if(document.attachEvent){
   document.attachEvent('WeixinJSBridgeReady'   , onBridgeReady);
   document.attachEvent('onWeixinJSBridgeReady' , onBridgeReady);
}
})();

//微信后退操作
WeixinJS.back = function() {
	var length = window.history.length;
	//判断当前打开的页面的个数
	if(length<2){
		WeixinJSBridge.invoke('closeWindow',{},function(res){
			//返回错误提示
		    //alert(res.err_msg);
		});
	}
	else{
		history.back();
	}
};
//关闭网页进入微信窗口
WeixinJS.goWxWindow = function() {
	WeixinJSBridge.invoke('closeWindow',{},function(res){
		//返回错误提示
	    //alert(res.err_msg);
	});
};

