


<!DOCTYPE html>
<html>





<!-- 用于手机调用页面，不获取用户登录信息，避免抛出异常。"dgu" don't get user -->



<script>
    var baseURL = "/wxqyh";var resourceURL = "https://qy.do1.com.cn/qwy";var localport = "https://qwyimg.do1.com.cn/fileweb";var compressURL = "https://qwyimg.do1.com.cn/fileweb/compress";var unpressURL = compressURL.replace("/compress", "");var agentJson = "%5B%7B%22angentId%22%3A%22activity%22%2C%22regex%22%3A%22%5E.*activity.*%24%22%7D%2C%7B%22angentId%22%3A%22addressBook%22%2C%22regex%22%3A%22%5E.*addressbook.*%24%22%7D%2C%7B%22angentId%22%3A%22ask%22%2C%22regex%22%3A%22%5E.*%2Fask%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22chat%22%2C%22regex%22%3A%22%5E.*chat.*%24%22%7D%2C%7B%22angentId%22%3A%22checkwork%22%2C%22regex%22%3A%22%5E.*checkwork.*%24%22%7D%2C%7B%22angentId%22%3A%22crm%22%2C%22regex%22%3A%22%5E.*crm.*%24%22%7D%2C%7B%22angentId%22%3A%22diary%22%2C%22regex%22%3A%22%5E.*diary.*%24%22%7D%2C%7B%22angentId%22%3A%22dynamic%22%2C%22regex%22%3A%22%5E.*dynamicin.*%24%22%7D%2C%7B%22angentId%22%3A%22express%22%2C%22regex%22%3A%22%5E.*express.*%24%22%7D%2C%7B%22angentId%22%3A%22form%22%2C%22regex%22%3A%22%5E.*form.*%24%22%7D%2C%7B%22angentId%22%3A%22homework%22%2C%22regex%22%3A%22%5E.*homework.*%24%22%7D%2C%7B%22angentId%22%3A%22jdoa%22%2C%22regex%22%3A%22%5E.*%2Foa%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22jdoabhw%22%2C%22regex%22%3A%22%5E.*bhw.*%24%22%7D%2C%7B%22angentId%22%3A%22meetingassistant%22%2C%22regex%22%3A%22%5E.*meeting.*%24%22%7D%2C%7B%22angentId%22%3A%22moveapprove%22%2C%22regex%22%3A%22%5E.*moveapprove.*%24%22%7D%2C%7B%22angentId%22%3A%22outsidework%22%2C%22regex%22%3A%22%5E.*outwork.*%24%7C%5E.*movework.*%24%7C%5E.*moveworksign.*%24%7C%5E.*outsideworkinfo.*%24%22%7D%2C%7B%22angentId%22%3A%22productinfo%22%2C%22regex%22%3A%22%5E.*product.*%24%22%7D%2C%7B%22angentId%22%3A%22qwhelper%22%2C%22regex%22%3A%22%5E.*qwhelper.*%24%22%7D%2C%7B%22angentId%22%3A%22secretary%22%2C%22regex%22%3A%22%5E.*explain.*%24%22%7D%2C%7B%22angentId%22%3A%22survey%22%2C%22regex%22%3A%22%5E.*question.*%24%22%7D%2C%7B%22angentId%22%3A%22task%22%2C%22regex%22%3A%22%5E.*task.*%24%22%7D%2C%7B%22angentId%22%3A%22topic%22%2C%22regex%22%3A%22%5E.*topic.*%24%22%7D%2C%7B%22angentId%22%3A%22contract%22%2C%22regex%22%3A%22%5E.*%2Fcontract%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22learnonline%22%2C%22regex%22%3A%22%5E.*%2Flearnonline%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22sale%22%2C%22regex%22%3A%22%5E.*%2Fsale%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22idoofen%22%2C%22regex%22%3A%22%5E.*%2Fidoofen%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22qydisk%22%2C%22regex%22%3A%22%5E.*%2Fqydisk%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22examination%22%2C%22regex%22%3A%22%5E.*%2Fexamination%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22wifi%22%2C%22regex%22%3A%22%5E.*%2Fwifi%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22bizcard%22%2C%22regex%22%3A%22%5E.*%2Fbizcard%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22entdidi%22%2C%22regex%22%3A%22%5E.*%2Fentdidi%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22hrmanagement%22%2C%22regex%22%3A%22%5E.*%2Fhrmanagement%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22storecheck%22%2C%22regex%22%3A%22%5E.*%2Fstorecheck%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22formdiy%22%2C%22regex%22%3A%22%5E.*%2Fformdiy%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22wqqd%22%2C%22regex%22%3A%22%5E.*%2Fwqqd%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22todo%22%2C%22regex%22%3A%22%5E.*%2Ftodo%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22recruit%22%2C%22regex%22%3A%22%5E.*%2Frecruit%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22car%22%2C%22regex%22%3A%22%5E.*%2Fcar%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22qwim%22%2C%22regex%22%3A%22%5E.*%2Fqwim%2F.*%24%22%7D%2C%7B%22angentId%22%3A%22reimbursement%22%2C%22regex%22%3A%22%5E.*%2Freimbursement%2F.*%24%22%7D%5D";var wxqyh_corpId = "wx3a3a8ac86d65129e";var dqdp_csrf_token = "bd2a4b0b906f74aa";
    var downFileURL="/Struts2/fileUploadAction!exportFile.action?filePath=";var wxqyh_isOpen = false;var lastDeadline="2015-12-20 23:59";var wxqyh_terrace_type = "mobile";var wxqyh_scheme = "https";
    var fileDownURL = "https://qwyimg.do1.com.cn/fileweb";var baseHttpURL = "http://qy.do1.com.cn/open";var wxqyh_is_debug=""=="true"?true:false;
    var wxqyhURL="https://qy.do1.com.cn/wxqyh";var qwwebURL="https://qy.do1.com.cn/web";var qwyURL="https://qy.do1.com.cn/qwy";var openURL="https://qy.do1.com.cn/open";var uploadVipURL="https://vipfile.do1.com.cn//qwy";
    var websocketPort = "wss://qy.do1.com.cn:10002/register";
    var imgFilterExp="image/jpeg,image/jpg,image/png,image/gif";var jsVer="2017.11.23.06";

    var silverVipURL = "/wxqyh/qiweipublicity/companysrv/vip/vip_index.jsp";
    var goldVipUrl = "";
    var onTrialVipUrl = "https://qy.do1.com.cn/open/open/form/add.jsp?id=49dfc058-7afb-4d55-86e9-f431690e4eec&corp_id=&agentCode=form";
</script>




<script type="text/javascript">

function storage(trigger,fn){
	var url = document.location.href.split('#')[0];
	function triggerStorage() {
		var local = {};
        local['date'] = [new Date()];
        $('input').each(function(index, el) {
            var name = $(el).attr('name');
            if(name){
            	var type = $(el).attr('type');
                var tmp = local[name];
                tmp = $.isArray(tmp) ? tmp: [];
                if (type == 'checkbox' || type == 'radio') {
                    tmp.push($(el).prop('checked'));
                }else if (type == 'text'|| type == 'number') {
                    tmp.push($(el).val());
                }
                if($(el).hasClass('selectStorage')){
                	 tmp.push($(el).val());
                }
                local[name] = tmp;
            }
            
        });
        $('textarea').each(function(index, el) {
            var name = $(el).attr('name');
            if(name){
            	var tmp = local[name];
                tmp = $.isArray(tmp) ? tmp: [];
                tmp.push($(el).val());
                local[name] = tmp;
            }
            
        });
        $('select').each(function(index, el) {
            var name = $(el).attr('name');
            if(name){
            	var tmp = local[name];
                tmp = $.isArray(tmp) ? tmp: [];
                // tmp.push($(el).find('option:selected').val());
                 tmp.push($(el).find('option').not(function(){ return !this.selected }).val());
                local[name] = tmp;
            }
            
        });
        localStorage[url] = JSON.stringify(local);
    };
    function loadSotrage(fn){
    	if (!window.localStorage[url]){return}
        var json = JSON.parse(localStorage.getItem(url));     
        $('input').each(function(index, el) {
            var name = $(el).attr('name');
            if(name&&json[name]){
            	var type = $(el).attr('type');
                if (type == 'checkbox' || type == 'radio') {
                    $('input[name="' + name + '"]').each(function(index, el) {
                        $(el).prop('checked', (json[name][index]));
                    });
                }
                if (type == 'text' || type == 'number') {
                    $('input[name="' + name + '"]').each(function(index, el) {
                        $(el).val(json[name][index]);
                        if($(el).hasClass("selectStorage")&&$(el).val()){
                    		$(el).siblings('.selectStorage').html($(el).val());
                    	}
                    });
                }
            }
            
        });
        $('textarea').each(function(index, el) {
            var name = $(el).attr('name');
            if(name&&json[name]){
            	$('[name="' + name + '"]').each(function(index, el) {
                    $(el).val(json[name][index]);
                });
            }
            
        });
        $('select').each(function(index, el) {
            var name = $(el).attr('name');
            if(name&&json[name]){
            	$('[name="' + name + '"]').each(function(index, el) {
            		//$(el).html(json[name][index+1]);
                    $(el).find('option[value="' + json[name][index] + '"]').prop('selected', true);
                    // $(el).val(json[name][index])
                });
            }
            
        });  
        if(fn != undefined){
        	fn.call(this);
        }
        
    }; 
    if(!trigger){loadSotrage(fn)}
    $('input,textarea,select').on('focus input change',triggerStorage)
    //$(window).on('click',triggerStorage) 
    return triggerStorage;
}
//清除缓存
function removeStorage(){
	 var url=document.location.href;//@相关人缓存
	if(url.charAt(url.length-1)=='#'){
		url=url.substr(0,url.length-1);
	}
	if(window.localStorage){
		
	localStorage.removeItem(url)
	}
}

</script>

<head>
    <meta charset="utf-8">
    <title>新建日志</title>
    <meta name="description" content="">
    <meta name="HandheldFriendly" content="True">
    <meta name="MobileOptimized" content="320">
    <meta name="viewport"
          content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta content="telephone=no" name="format-detection"/>
    <meta content="email=no" name="format-detection"/>
    <link rel="stylesheet" href="/wxqyh/jsp/wap/css/ku.css?ver=2017.11.23.06"/>
    <link rel="stylesheet" href="/wxqyh/jsp/wap/css/font-awesome.min.css?ver=2017.11.23.06"/>
    <script src='/wxqyh/js/3rd-plug/jquery-ui-1.8/js/jquery-1.7.2.min.js'></script>
    <script type="text/javascript" src="/wxqyh/jsp/wap/js/detect-jquery.js"></script>
    <script type="text/javascript" src="/wxqyh/jsp/wap/js/flipsnap.js"></script>
    <script type="text/javascript" src="/wxqyh/jsp/wap/js/wechat.js"></script>
    <script type="text/javascript" src="/wxqyh/jsp/wap/js/emojify.min.js?ver=2017.11.23.06"></script>
    <script type="text/javascript" src="/wxqyh/jsp/wap/js/ku-jquery.js?ver=2017.11.23.06"></script>

    <script src='/wxqyh/jsp/wap/js/common.js?ver=2017.11.23.06'></script>
    <script src="/wxqyh/js/3rd-plug/jquery/jquery.form.js"></script>

    <!-- 上传媒体文件（手机端页面）引入  start -->
    <script src="/wxqyh/jsp/wap/js/uploadfile.js?ver=2017.11.23.06"></script>
    <!-- 上传媒体文件（手机端页面）引入  end -->
    <!-- 上传语音文件（手机端页面）引入  start -->
    <script src="/wxqyh/jsp/wap/js/uploadVoice.js?ver=2017.11.23.06"></script>
    <!-- 上传语音文件（手机端页面）引入  end -->

    <script src="/wxqyh/themes/wap/js/diary/add.js?ver=2017.11.23.06"></script>
</head>

<body>
<div id="wrap_main" class="wrap">
    <div id="main" class="wrap_inner">
        <div id="isUnSubmit" class="topWarn" style="display: none;text-align: center;">
            <div class="topWarn-text">你有日志未提交，点击前往补交</div>
        </div>
        <form action="/wxqyh/portal/diaryAction!ajaxAdd.action" id="taskform" onsubmit="return false;">
            <input type="hidden" name="tbQyDiaryPO.currentDay" id="currentDate">
            <div class="form-style">
                <div class="f-item f-item-select">
                    <div class="inner-f-item item-text flexbox">
                        <span class="f-item-title">日志类型</span>
                        <div class="flexItem">
                            <select name="tbQyDiaryPO.diaryType" id="taskType"
                                    onchange="autoInput(this.value,this.options[this.selectedIndex].text)"
                                    class="flexItem item-select direction_rtl">
                            </select>
                        </div>
                    </div>
                </div>
                <div class="detaildata">
                    <div class="f-item">
                        <div class="inner-f-item">
                            <div class="flexItem">
                                <input type="text" name="tbQyDiaryPO.title" value="" id="title" valid="{maxLength:100}"
                                       placeholder="请输入日志标题" class="item-select inputStyle item-title maxlength"
                                       maxlength="100"/>
                            </div>
                        </div>
                    </div>
                    <div class="f-item">
                        <div class="inner-f-item tapeBox">
                            <div class="text_div">
                                <textarea class="item-select inputStyle item-content" name="tbQyDiaryPO.content"
                                          id="content" cols="30" rows="2" placeholder="请输入日志内容"
                                          maxLength="30000"></textarea>
                            </div>
                            <div class="fr">
                                <div class="icon-circular mt5 mr10" id="showActionSheet"><i
                                        class="icon-circular-ic icon-circular-book"></i></div>
                                <div class="tape" id="voiceIds"></div>
                            </div>
                        </div>
                    </div>
                    <div class="f-item">
                        <div class="loadImg clearfix" id="upPicDiv">
                            <div class="f-add-user-list" style="margin: 0;">
                                <ul id="imglist" class="impression clearfix">
                                    <li class="f-user-add" id="addimage">
                                        <input id="imageFileInput" class="imageFileInput" accept="image/jpeg,image/jpg,image/png,image/gif"
                                               type="file"></li>
                                    <li class="f-user-remove" show="0" onclick="removeImage(this,'imglist')"></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!-- 上传媒体文件（手机端页面）引入  start -->
                    <div class="form-style" id="medialist">
                        <div class="letter_bar file_top borderBottommNone">
                            <span class="file_top_tit">附件(0)</span>
                            <span class="file_top_btn" style="display:none;">
		               		<input type="file" name="file" id="fileFile1" fileName="mediaIds"
                                   class="upload_file_input"/><i>+</i>上传</span>
                        </div>
                    </div>
                    <!-- 上传媒体文件（手机端页面）引入  end -->
                </div>
                <div class="separate_bar separate_bar_h15"></div>
                <div class="letter_bar">负责人
                    <div class="loadlast_onoff">加载上次
                        <div class="onOff" id="onOff2">
                            <span class="onOff_off"><input type="hidden" name="toSelectId" id="toSelectId"
                                                           value="0"/></span>
                        </div>
                    </div>
                </div>
                <div class="f-item">
                    <div class="f-add-user clearfix">
                        <div class="inner-f-add-user">
                            <div class="f-add-user-list" id="toPersonList">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="letter_bar">相关人
                    <div class="loadlast_onoff">加载上次
                        <div class="onOff" id="onOff3">
                            <span class="onOff_off"><input type="hidden" name="ccSelectId" id="ccSelectId"
                                                           value="0"/></span>
                        </div>
                    </div>
                </div>
                <div class="f-item">
                    <div class="f-add-user clearfix">
                        <div class="inner-f-add-user">
                            <div class="f-add-user-list" id="ccPersonList">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form_btns mt10">
                    <div class="inner_form_btns">
                        <div class="fbtns flexbox">
                            <input type="hidden" name="tbQyDiaryPO.diaryStatus" id="taskStatus" value=""/>
                            <a class="fbtn btn qwui-btn_default flexItem" style="margin-right: 5px;"
                               href="javascript:commitTask('0')">保存为草稿</a>
                            <a class="fbtn btn flexItem" style="margin-left: 5px;" href="javascript:commitTask('1')">立即提交</a>
                        </div>
                        <div class="fbtns_desc"></div>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <div class="overlay" id="iosMask" style="display: none;"></div>
    <div class="qwui-actionsheet" id="qwui-actionsheet">
        <div class="qwui-actionsheet_title">将已有的日志内容合并到当前日志中</div>
        <div class="qwui-actionsheet_cell"><a href="javascript:summaryMy('1','1')">从我提交的日志汇总</a></div>
        <div class="qwui-actionsheet_cell"><a href="javascript:summaryMy('2','3')">从我负责的日志汇总</a></div>
        <div class="qwui-actionsheet__action">
            <div class="qwui-actionsheet_cell" id="qwui-actionsheetCancel">取消</div>
        </div>
    </div>
</div>
<div class="popBox1 tapePop">
    <div class="popBox_title"></div>
    <div class="popBox1_con tcenter">
        <img src="/wxqyh/jsp/wap/images/tapePlay.gif">
        <div class="tapeTime">00:60</div>
    </div>
    <div class="popBox_error"></div>
    <div class="popBox_foot flexbox">
        <a class="popBox_cancel_btn flexItem" href="javascript:;">取消</a>
        <a class="popBox_submit_btn flexItem" href="javascript:;">说完了</a>
    </div>
</div>
<div class="text_tips" id="voice_div" style="display: none; position: fixed; left: 50%;width:280px;">
    <div class="inner_text_tips">
        <div class="textarea_tips_content">
            <textarea id="voiceContent" cols="30" rows="2" style="width:260px;"></textarea>
        </div>

        <div class="text_tips_btns flexbox">
            <a class="btn tips_cancel_btn  flexItem" style="margin-right: 5px;" href="javascript:cancelVoice()">取消</a>
            <a class="btn tips_submit_btn flexItem" style="margin-left: 5px;" href="javascript:addToContent()">确定</a>
        </div>
    </div>
</div>
<script src="/wxqyh/jsp/wap/js/vue.min.js"></script>
<script src="/wxqyh/jsp/wap/js/userOrDept_select.js?ver=2017.11.23.06"></script>

<script type="text/javascript" src="https://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
<script type="text/javascript" src="/wxqyh/jsp/wap/js/CheckJSApi.js?ver=2017.11.23.06"></script>
<script type="text/javascript" language="javascript">

	var operationNeedHandle = "";

    var width = $(this).width(),
        height = $(this).height(),
        win_width = $(window).width(),
        win_height = ($(window).height())*0.9;//需要减去微信上方的头的2倍高度
	var hasLoad=false; //是否已加载
	/**
	 * 关闭消息窗口 operationRCD{0:确定, -1:取消，1:关闭}
	 */
	function closeMsgBox(flag) {
		$("#hmsgTitle").html("");
		$("#pmsgContent").html("");
		$(".overlay").hide();
		document.getElementById("showMsg_div").style.display = "none";

		if (operationNeedHandle == undefined || operationNeedHandle == "") {
			return;
		} else if (operationNeedHandle == 1) {
			if (0 == flag) {
				try {
					handle();
				} catch (e) {

				}
			}
		} else {
			//执行操作事件
			if (0 == flag) {
				e = operationNeedHandle.ok;
			} else {
				e = operationNeedHandle.fail;
			}
			if (e != null) {
				e && e.call(e, null, null);
			}
		}
	}

	 /**
	 *显示加载页面
	 *msgContent 加载页面显示的内容，如果不传，默认为"加载中..."
	 */
	function showLoading(msgContent) {
		//传入的信息为空
		if(msgContent == undefined || msgContent==""){
			$("#loading_text").html("加载中...");
		}
		else{
			$("#loading_text").html(msgContent);
		}
		$(".overlay").show();
		win_height = document.getElementById("overlayImage").offsetHeight/5;
		win_width = document.getElementById("overlayImage").offsetWidth;

		document.getElementById("loading_simple_div").style.display = "block";
		//让加载中剧中对齐
        var tips_width = document.getElementById("loading_simple_div").offsetWidth,
        tips_height= document.getElementById("loading_simple_div").offsetHeight,
        top = (win_height-tips_height)/2,
        left = (win_width-tips_width)/2;
		$("#loading_simple_div").css({
			'top' : top + "px",
			'left' : left + "px"
		});
	}

	 /**
	 *隐藏加载页面
	 */
	function hideLoading() {
		$(".overlay").hide();
		document.getElementById("loading_simple_div").style.display = "none";
	}

	 /**
	  * show original image
	  */
	function showImage(url) {
		 if(!url || url=="" || url.indexOf("/upload")== -1){
			return;
		 }
		 if(isWeChatApp()){
			 wx.previewImage({
				 current: url, // 当前显示的图片链接
				 urls: [url] // 需要预览的图片链接列表
			 });
			 return;
		 }
		 $("#overlayImage").addClass("overlayBackgroud").show();
		 $("#loading_image_div").show();
		 imageOld(url);
		 pushImageUrl();
	}

	 /**
	  * hide original image
	  */
	 function hideImage(event) {
		 if(event.target.className=="inner_img_preview"||event.target.className=="closeIcon"){
			 $("#overlayImage").hide();
			 $("#loading_image_div").hide();
			 hasLoad=false;
		 }
	 }


	/**
	 * option 选项
	 * msgTitle 标题
	 * needHandle 传入成功或者失败的处理函数，如下{ok:function(result){},fail:function(result){}}
	 */
	function showChooseBox(option, msgTitle, needHandle,flowId) {
		if(1<arguments.length && msgTitle != ""){
			$("#chooseMsgTital").html("<p>"+msgTitle+"</p>");
		}
		else{
			$("#chooseMsgTital").hide();
		}
		if(option.length>0){
			var temp = "";
			if(flowId){
				for(var i=0;i<option.length;i++){
					if(flowId==option[i].id){
						temp += '<li class="active"><input type="radio" style="display:none" name="radio_choose" checked="checked" vname="'+option[i].name+'" value="'+option[i].id+'">'+
						'<div class="xian_option"><i class="fa"></i>'+option[i].name+'</div></li>';
					}
					else{
						temp += '<li><input type="radio" style="display:none" name="radio_choose" vname="'+option[i].name+'" value="'+option[i].id+'">'+
						'<div class="xian_option"><i class="fa"></i>'+option[i].name+'</div></li>';
					}
				}
			}
			else{
				for(var i=0;i<option.length;i++){
					temp += '<li><input type="radio" style="display:none" name="radio_choose" vname="'+option[i].name+'" value="'+option[i].id+'">'+
					'<div class="xian_option"><i class="fa"></i>'+option[i].name+'</div></li>';
				}
			}
			$("#chooseMsgUl").html(temp);
		}

		$(".overlay").show();
		win_height = document.getElementById("overlayImage").offsetHeight/5;
		win_width = document.getElementById("overlayImage").offsetWidth;
		//$("#showMsg_div").show();
		document.getElementById("chooseMsg_div").style.display = "block";
		//让加载中剧中对齐
        var tips_width = document.getElementById("chooseMsg_div").offsetWidth,
        tips_height= document.getElementById("chooseMsg_div").offsetHeight,
        top = (win_height-tips_height)/2,
        left = (win_width-tips_width)/2;
		$("#chooseMsg_div").css({
			'top' : top + "px",
			'left' : left + "px"
		});
		if(2<arguments.length){
			operationNeedHandle = needHandle;
		}
        $('#chooseMsgUl').on('click','li',function(event){
            var self = $(this),
            context = self.parent(),
            siblings = $('.active',context);

    	    siblings.removeClass('active');
    	    self.addClass('active');

    	    context.find("input[type='radio']").attr("checked", false);
    	    self.find("input[type='radio']").attr("checked", true);
        });
	}
	/**
	 * 关闭消息窗口 operationRCD{0:确定, -1:取消，1:关闭}
	 */
	function closeChooseMsgBox(flag) {
		//console.log($("#chooseMsgUl input[name='radio_choose'][checked]"));
		var choose =  $("#chooseMsgUl input[name='radio_choose'][checked]");
		$("#chooseMsgTital").html("");
		$("#chooseMsgUl").html("");
		$(".overlay").hide();
		document.getElementById("chooseMsg_div").style.display = "none";

		if (operationNeedHandle == "") {
			return;
		}
		else {
			//执行操作事件
			if (0 == flag) {
				e = operationNeedHandle.ok;
			} else {
				e = operationNeedHandle.fail;
			}
			if (e != null) {
				var chooseValue = {};
				chooseValue.id = choose.val();
				chooseValue.name = choose.attr("vname");
				e && e.call(e, chooseValue, null);
			}
		}
	}

</script>
<script type="text/javascript" src="/wxqyh/jsp/wap/js/showMsg.js?ver=2017.11.23.06"></script>
<div class="text_tips" id="showMsg_div" style="display: none; position: fixed; left: 50%;">
	<div class="inner_text_tips">
		<div class="text_tips_content" id="pmsgContent"></div>
		<div class="text_tips_btns flexbox">
			<a id="btnConfirm" class="btn tips_submit_btn flexItem" href="javascript:closeMsgBox(0);">确定</a>
			<a id="btnCancel" class="btn tips_cancel_btn  flexItem" href="javascript:closeMsgBox(-1);">取消</a>
		</div>
	</div>
	<input type="hidden" value="" id="operationNeedHandle" />
</div>

<div class="simple_tips" id="loading_simple_div" style="display: none; position: fixed;">
    <div class="simple_tips_content text-center">
        <div id="loading" class="loading ma">
            <div><span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span><span></span>
			</div>
        </div>
        <div class="simple_tips_text mt10">
            <p id="loading_text">加载中...</p>
        </div>
    </div>
</div>

<div class="overlay" id="overlayImage" style="display: none;"></div>
<div class="commentBtnBoxBg"></div>
<!--图片预览-->
<div class="img_preview" id="loading_image_div" style="display:none;height: 100%;">
	<div class="inner_img_preview">
	</div>
	<span class="middleIconPreview prevShow" data-id="prev"></span>
	<span class="middleIconPreview nextShow" data-id="next"></span>
	<div class="pcimg-preview-footer ">
		<ul class="pcimg-operate-list clearfix">
			<li class="item"><i class="icon icon-prev" data-id="prev"></i></li>
			<li class="item"><i class="icon icon-zoomIn" data-id="zoomIn"></i></li>
			<li class="item"><i class="icon icon-zoomOut" data-id="zoomOut"></i></li>
			<li class="item disable"><i class="icon icon-resize" data-id="reset"></i></li>
			<li class="item"><i class="icon icon-rotate" data-id="rotate"></i></li>
			<li class="item"><i class="icon icon-download" data-id="download"><a href="" download></a></i></li>
			<li class="item"><i class="icon icon-next" data-id="next"></i></li>
		</ul>
		<div class="ft-maskP"></div>
	</div>
	<span class="closeIcon"></span>
</div>

<div class="text_tips" id="chooseMsg_div" style="display: none;position: fixed; left: 40%;">
	<div class="inner_text_tips">
		<div id="question1" class="question_detail" style="">
			<div class="inner_question_detail">
				<div class="ask_info" id="chooseMsgTital"></div>
				<div class="ask_info">
					<div class="answer-list radio_btn">
						<ul id="chooseMsgUl">
						</ul>
					</div>
				</div>
			</div>
		</div>
		<div class="text_tips_btns flexbox">
			<a id="btnConfirm" class="btn tips_submit_btn flexItem" href="javascript:closeChooseMsgBox(0);">确定</a>
			<a id="btnCancel" class="btn tips_cancel_btn  flexItem" href="javascript:closeChooseMsgBox(-1);">取消</a>
		</div>
	</div>
</div>

<script type="text/javascript" charset="utf-8" src="/wxqyh/jsp/wap/uploadImage/js/global.js"></script>
<script type="text/javascript" charset="utf-8" src="/wxqyh/jsp/wap/uploadImage/js/global1.js?ver=2017.11.23.06"></script>
<script type="text/javascript" charset="utf-8" id="sea" src="/wxqyh/jsp/wap/uploadImage/js/seajs.js"></script>
<script type="text/javascript" charset="utf-8" src="/wxqyh/jsp/wap/uploadImage/js/register.js?ver1=2017.11.23.06"></script>
<script type="text/javascript" charset="utf-8" src="/wxqyh/jsp/wap/uploadImage/js/mobileBUGFix.mini.js"></script>
<script type="text/javascript" charset="utf-8" src="/wxqyh/jsp/wap/uploadImage/js/uploadImage2.js?ver1=2017.11.23.06"></script>

<form action="/wxqyh/portal/imageupload/imageUploadAction!doUploadImageBase64.action" method="post" id="imgFileBaseForm" encType="multipart/form-data">
	<input type="hidden" name="imgFileBase" id="imgFileBase" value="">
	<input type="hidden" name="agent" id="uploadImgAgent" value="">
	<input type="hidden" name="orderId" id="uploadImgOrderId" value="">
	<input type="hidden" name="drawString" id="uploadImgDrawString" value="">
</form>

<script type="text/javascript">
$(function() {
	//alert(wxqyh.agent);
	//如果是后台使用手机端的上传图片
	if(wxqyh_terrace_type && wxqyh_terrace_type=="mgr"){
		$("#imgFileBaseForm").attr("action", "/wxqyh/imageupload/imageUploadAction!doUploadMgrImageBase64.action");
	}
	if(null!=wxqyh.agent && "undefined"!=wxqyh.agent && ""!=$.trim(wxqyh.agent)){
		$("#uploadImgAgent").val(wxqyh.agent);
	}
	
	if("undefined"!=typeof(wxqyh_uploadfile)){
		if(null!=wxqyh_uploadfile.orderId && "undefined"!=wxqyh_uploadfile.orderId && ""!=$.trim(wxqyh_uploadfile.orderId)){
			$("#uploadImgOrderId").val(wxqyh_uploadfile.orderId)
		}
	}
	
    seajs.use(['register'], function(register) {
        register.init();
        //city.init();
    });
});
</script>
    
<script>
    var userId = "4fdd0f411adf4e70bf75659f644bdc47";
</script>
</body>
</html>