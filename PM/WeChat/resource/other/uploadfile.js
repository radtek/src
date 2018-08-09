/**
 * 上传媒体文件（移动版）
 * 20150208
 * sunqinghai
 */
  //上传图片完成后的通知
    function wxqyh_showfile(mediaInfos,ulobj,name){
    	if(name==undefined || name ==""){
    		name = "mediaIds";
    	}
    	var _test="";
    	var temp;
	    var isFormFiled=name.indexOf("searchValue.")==-1?false:true;
	    var value="";
    	for(var i=0;i<mediaInfos.length;i++){
    		temp = mediaInfos[0];
            var fileData = JSON.stringify(temp);
            var url=temp.url, fileName=temp.fileName, fileExt=temp.fileExt, mediaId = temp.id;
            var downLoadURL = fileDownURL + downFileURL + encodeURIComponent(url) + "&fileFileName=" + encodeURIComponent(fileName);
            var href = 'javascript:sendFile(\''+mediaId+'\',\''+downLoadURL+'\')';
            var showpreviewBtn = '<span class="wrap" onclick="wxqyh_sendFileToMe(\'' + temp.id + '\');"><i class="qw-operate-icon qw-operate-icon-preview"></i></span>';
            if(/ZIP|RAR/.test(fileExt) || (/MP4|WMV/.test(fileExt) && isWeChatApp() && isIOS()) ){
                showpreviewBtn = ''
            }
			if(isFormFiled){
				value=temp.id+":"+temp.url+":"+temp.fileName+":"+temp.fileExt+":"+temp.fileSizeStr;
			}else{
				value=temp.id;
			}

            _test = '<div class="settings-item" id="'+temp.id+'">' +
                '<input type="hidden" name="' + name + '" value="' + value+ '" />' +
                '<div class="inner-settings-item flexbox fujian">' +
                '<p class="' + temp.fileExt + '"></p><div class="fujian_text flexItem"><p class="name">' + temp.fileName + '</p>' +
                '<p class="fujian_size">' + temp.fileSizeStr + '</p>' +
                '<p class="arrow">' +showpreviewBtn +
                '<a class="wrap" href="'+href+'"><i class="qw-operate-icon qw-operate-icon-download"></i></a>' +
                '<span class="wrap" onclick="doDelFileLi(this);"><i class="qw-operate-icon qw-operate-icon-del"></i></span>'+
                '</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            ulobj.append(_test);
            $('#' + temp.id).attr('data-file',fileData)
    	}
	   if(!isFormFiled)
         	$(ulobj.find(".file_top_tit")).html("附件("+(ulobj.children().length-1)+")");
    }

    /**
     * 删除li
     * @param $this  点击的a标签的对象
     */
    function doDelFileLi($this){
    	var temp = $($this).parent().parent().parent();
    	var mediaId = $(temp.siblings("input")[0]).val();
    	if(mediaId){
        	$.ajax({
        		url:baseURL+"/portal/imageupload/imageUploadAction!doDelFile.action?agent="+wxqyh.agent+"&isOpen="+wxqyh_isOpen+"&mediaId="+mediaId+'&groupId='+wxqyh_uploadfile.groupId+"&dqdp_csrf_token="+dqdp_csrf_token,
        		type:"GET",
        		dataType:"json",
        		success:function(result){
                    if('0'!=result.code){
            			showMsg("错误提示",data.desc,1,null);
                    }
                    else{
                       	$(temp.parent().parent().find(".file_top_tit")).html("附件("+(temp.parent().parent().children().length-2)+")");
                    	temp.parent().remove();
                    }
        		},
                error: function () {showMsg("错误提示","网络连接失败，请检查网络连接",1,null);}
        	});
    	}
    	else{
        	$($this).parent().remove();
    	}
    }
    /**
     * 显示媒体文件
     * @param mediaInfos 文件list
     * @param ulId 放入的div或者ul id
     * @param name input的名称
     * @param type 类型1表示展示，2表示编辑，如果不填写默认为展示
     * @returns
     */
    function previewFiles(mediaInfos,ulId,name,type){
    	if(!mediaInfos || mediaInfos.length==0){
    		return;
    	}
    	if(ulId==undefined || ulId ==""){
    		ulId = "medialist";
    	}
    	if(name==undefined || name ==""){
    		name = "mediaIds";
    	}
    	if(type==undefined || type ==""){
    		type = 1;
    	}
    	var _test="";
    	var temp;
        for(var i=0;i<mediaInfos.length;i++){
            temp = mediaInfos[i];
            var fileData = JSON.stringify(temp);
            var url=temp.url, fileName=temp.fileName, fileExt=temp.fileExt, mediaId = temp.id;
            var downLoadURL = fileDownURL + downFileURL + encodeURIComponent(url) + "&fileFileName=" + encodeURIComponent(fileName);
            var href = 'javascript:sendFile(\''+mediaId+'\',\''+downLoadURL+'\')';
            // 预览按钮
            var showpreviewBtn = '<span class="wrap" onclick="wxqyh_sendFileToMe(\'' + temp.id + '\');"><i class="qw-operate-icon qw-operate-icon-preview"></i></span>';
            showpreviewBtn = (/ZIP|RAR/.test(fileExt) || (/MP4|WMV/.test(fileExt) && isWeChatApp() && isIOS())) ? '' : showpreviewBtn;     // 压缩包不显示预览按钮
            // 下载按钮
            var showDownLoadBtn = '<a class="wrap" href="'+href+'"><i class="qw-operate-icon qw-operate-icon-download"></i></a>';
            var Btn = showpreviewBtn + showDownLoadBtn + '<span class="wrap" onclick="doDelFileLi(this);"><i class="qw-operate-icon qw-operate-icon-del"></i></span>';
            Btn = (type == 2) ? Btn : (showpreviewBtn + showDownLoadBtn);
            _test = '<div class="settings-item" id="'+temp.id+'" >' +
                '<input type="hidden" name="' + name + '" value="' + temp.id + '" />' +
                '<div class="inner-settings-item flexbox fujian">' +
                '<p class="' + temp.fileExt + '"></p><div class="fujian_text flexItem"><p class="name">' + temp.fileName + '</p>' +
                '<p class="fujian_size">' + temp.fileSizeStr + '</p>' +
                '<p class="arrow">'+Btn+'</p>' +
                '</div>' +
                '</div>' +
                '</div>';
            $("#"+ulId).append(_test);
            $('#' + temp.id).attr('data-file',fileData);
        }
       	$($("#"+ulId).find(".file_top_tit")).html("附件("+mediaInfos.length+")");
    }
    
    /**
     * 上传媒体文件
     * @param fileElementId
     * @param mediaName
     * @param ulobj
     */
    function wxqyh_uploadFile(fileElementId,mediaName,ulobj){
    	try {
    		var agent = wxqyh_uploadfile.agent;
            var fileObj = document.getElementById(fileElementId).files[0]; // js 获取文件对象
            var FileController = baseURL+"/portal/imageupload/imageUploadAction!doUploadFile.action?agent="+wxqyh.agent+"&isOpen="+wxqyh_isOpen+"&orderId="+wxqyh_uploadfile.orderId+"&dqdp_csrf_token="+dqdp_csrf_token;// 接收上传文件的后台地址

            // FormData 对象
            var form = new FormData();
            form.append("author", "hooyes");                        // 可以增加表单数据
            form.append("file", fileObj);                           // 文件对象

            // XMLHttpRequest 对象
            var xhr = new XMLHttpRequest();
            try{
                xhr.open("post", FileController, true);
            }catch(e){
            	wxqyh_uploadfile.unbind();
            	wxqyh_uploadfile.afreshinit();
            	hideLoading();
            	showMsg("提示","该手机暂不支持上传文件（ios和部分安卓手机），请使用PC客户端上传附件资料",1,null);
            	return
            }
            xhr.onload = function () {
            	var data = eval("(" +xhr.responseText + ")");
            	if('0'==data.code){
            		//显示上传的文件
					wxqyh_showfile([data.data.mediaInfo],ulobj,mediaName);
            		//上传完成后都需要重新绑定一下事件
            		wxqyh_uploadfile.unbind();
            		wxqyh_uploadfile.afreshinit();
            		hideLoading();
            	}else{
            		//上传完成后都需要重新绑定一下事件
            		wxqyh_uploadfile.unbind();
            		wxqyh_uploadfile.afreshinit();
            		hideLoading();
            		showMsg("错误提示",data.desc,1,null);
            	}
            };

            xhr.send(form);
        } catch (e) {
        	//上传完成后都需要重新绑定一下事件
        	wxqyh_uploadfile.unbind();
        	wxqyh_uploadfile.afreshinit();
        	hideLoading();
        	showMsg("错误提示","暂时无法上传，请重试",1,null);
        }
    }
    
    /**
     * 预览附件
     * @param fileElementId(必须参数)
     * @param mediaName	// 兼容以前的传参
     * @param ulobj	// 兼容以前的传参
     */
    function wxqyh_sendFileToMe(mediaId,url,fileName){
        var id = mediaId;
        var fileData = $('#' + id).attr('data-file');

        if(!wxqyh_uploadfile.isInit){
            wxqyh_uploadfile.isInit = true;//标识已经初始化判断是否微信打开
        }
        var href = '';
        if(fileData){
            var data =JSON.parse(fileData);
            var url=data.url, fileName=data.fileName, fileExt=data.fileExt;
            href = fileDownURL + downFileURL + encodeURIComponent(url) + "&fileFileName=" + encodeURIComponent(fileName);
            if(fileExt == 'PDF'){
                href = baseURL+'/jsp/wap/learnonline/generic/web/viewer.html?url='+href;
            }else if(/DOC|DOCX|PPT|PPTX|XLS|XLSX|TXT|XML/.test(fileExt) && wxqyhConfig.is_use_yongzhong) {
                href = wxqyhConfig.yongzhong_url + href+"&dqdp_csrf_token="+dqdp_csrf_token;
            }else if(/MP3|AMR|MP4|WMA/.test(fileExt)){
                if(isWeChatApp()) {
                    href = baseURL + '/jsp/wap/uploadfile/viewer.jsp?type='+fileExt+'&url=' +  href;
                }else {
                    href = baseURL + '/manager/uploadfile/viewer.jsp?type=' + fileExt + '&url=' + href;
                }

            }
            if(isWeChatApp()) {
                location.href = href;
            }else {
                window.open(href);
            }

        }else {
            href = fileDownURL + downFileURL + encodeURIComponent(url) + "&fileFileName=" + encodeURIComponent(fileName);
            sendFile(mediaId,href);
        }
    }

    // 判断对象是否为空
    function isEmptyObject(obj) {
        var pro, val = true;
        for(var pro in obj ){
            val = false;
        }
        return val;
    }

// 给自己发送媒体文件
function sendFile(mediaId,href) {
    if(isWeChatApp()) {
        if(wxqyh_isOpen){
            if(isIOS()){
                showMsg("提示","IOS系统不支持下载附件，请使用PC客户端或电脑浏览器下载",1,null);
                return;
            }
            showMsg("提示","请点击右上角，使用浏览器打开才可查看",1,null);
            return;
        }
        var agent = wxqyh_uploadfile.agent;
        if(agent==""){
            showMsg("错误提示","页面存在问题，请稍后再试",1,null);
            return;
        }
        showLoading('发送中...');
        $.ajax({
            url:baseURL+'/portal/imageupload/imageUploadAction!doSendFileToMe.action?mediaId='+mediaId+'&agent='+agent+"&dqdp_csrf_token="+dqdp_csrf_token,
            type:"GET",
            dataType:"json",
            success:function(data){
                if('0'==data.code){
                    hideLoading();
                    //如果是手机端，提示用户是否现在查看
                    if(isWeChatApp()) {
                        showMsg("温馨提示","附件已推送到应用主界面，消息可能会有1分钟左右的延时，请耐心等待；现在去查看？",2,
                            {ok:function(result){WeixinJSBridge.invoke('closeWindow',{},function(res){});}}
                        );
                    }
                    else{
                        showMsg("温馨提示","附件已推送到你的企业微信应用主界面，请打开企业微信查看，消息可能会有1分钟左右的延时，请耐心等待",1,null);
                    }
                }else{
                    hideLoading();
                    showMsg("错误提示",data.desc,1,null);
                }
            },
            error: function () {hideLoading();showMsg("错误提示","网络连接失败，请检查网络连接",1,null);}
        });
    }
    else{
        if(isIOS()){
            showMsg("提示","IOS系统不支持下载附件，请使用PC客户端或电脑浏览器下载",1,null);
            return;
        }
        window.open(href);
    }
}

var wxqyh_uploadfile = {
    	isUpload: false,
    	isInit: false,//标识初始化判断是否微信打开
        agent: "",
        groupId: "",
        orderId:"",
        limitSize: '',
		maxSize: '',
		init: function(limitSize) {
            wxqyh_uploadfile.limitSize = limitSize ? limitSize : 10;
            wxqyh_uploadfile.maxSize = wxqyh_uploadfile.limitSize*1024*1024;
        	wxqyh_uploadfile.isInit = true;
			var ua = navigator.userAgent.toLowerCase();
			var isAndroid = ua.indexOf('android') > -1 || ua.indexOf('linux') > -1; //android终端或者uc浏览器
	        if(!isWeChatApp() || isAndroid) {
	        	wxqyh_uploadfile.isUpload = true;
                $('.file_top_btn').show();
                if(isIOS()&& wxqyh_uploadfile.agent=="reimbursement"){
                    $('.file_top_btn').hide();
                }

	            $('.upload_file_input').bind('change', function() {
	               	//显示上传中的层
	            	var ulobj = $(this);
	            	var file = ulobj.get(0).files[0];
	                if (file) {
	                	var path = ulobj.get(0).value;
	                	var ext = path.lastIndexOf(".");
	                	if(ext==-1){
	                		//如果不能获取到文件名，不允许上传
	                		wxqyh_uploadfile.isAndroid = false;
	                		wxqyh_uploadfile.isUpload = false;
	            	        $('.upload_file_input').unbind('change');
	        	            $('.upload_file_input').click(function(event){
	        	            	event.preventDefault();
	        	               	//显示提示信息
								//showMsg("提示","该手机暂不支持上传文件，请使用微信PC版或个人网页版上传附件资料<br/>个人网页版登录账号申请方式：通讯录->我的资料->WEB账号管理",1,null);
	                			showMsg("提示","该手机暂不支持上传文件（ios和部分安卓手机），请使用PC客户端上传附件资料",1,null);
	        	            });
                			showMsg("提示","该手机暂不支持上传文件（ios和部分安卓手机），请使用PC客户端上传附件资料",1,null);
	        	            return;
	                	}
	                	var fileExt = path.substr(ext).toLowerCase();//获得文件后缀名
	                	if(fileExt=="" || ".txt.xml.pdf.doc.ppt.xls.docx.pptx.xlsx.mp3.wma.amr.mp4.rar.zip.".indexOf(fileExt+".")<0){
	                    	showMsg("错误提示","只能上传txt,xml,pdf,doc,ppt,xls,docx,pptx,xlsx,mp3,wma,amr,mp4,rar,zip；如需上传其它格式文件请先将其压缩后再上传",1,null);
	                    	return;
	                	}
	                    if (file.size > wxqyh_uploadfile.maxSize){//10485760
	                    	showMsg("错误提示","文件大小不能超过"+wxqyh_uploadfile.limitSize+"M，请重新选择",1,null);
	                    	return;
	                    }
						if (file.size <= 0){//0
							showMsg("提示","该手机暂不支持上传文件（ios和部分安卓手机），请使用PC客户端上传附件资料",1,null);
							return;
						}
	                }
	                else{
                    	showMsg("错误提示","文件为空，请重新选择",1,null);
                    	return;
	                }
	        		showLoading('文件上传中...');
	            	var mediaName = ulobj.attr("fileName");
	            	var fileElementId = ulobj.attr("id");
					if(mediaName.indexOf("searchValue.")==-1)
	            	     ulobj = ulobj.parent().parent().parent();
					else//超级表单附件字段的
						ulobj = ulobj.parent().parent().next().find(".f-item");
						wxqyh_uploadFile(fileElementId,mediaName,ulobj);
	            });
			}
	        else{
                $('.file_top_btn').show();
                if(isIOS()&& wxqyh_uploadfile.agent=="reimbursement"){
                    $('.file_top_btn').hide();
                }
	            $('.upload_file_input').click(function(event){
	            	event.preventDefault();
	               	//显示提示信息
					showMsg("提示","该手机暂不支持上传文件（ios和部分安卓手机），请使用PC客户端上传附件资料",1,null);
	            });
	        }
        },
        afreshinit: function() {
	        if(wxqyh_uploadfile.isUpload) {
	        	//如果不是微信网页版
	            $('.upload_file_input').bind('change', function() {
	               	//显示上传中的层
	            	var ulobj = $(this);
	            	var file = ulobj.get(0).files[0];
	                if (file) {
	                	var path = ulobj.get(0).value;
	                	var fileExt = path.substr(path.lastIndexOf(".")).toLowerCase();//获得文件后缀名
	                	if(fileExt=="" || ".txt.xml.pdf.zip.doc.ppt.xls.docx.pptx.xlsx.rar.mp3.wma.mp4.amr.".indexOf(fileExt+".")<0){
	                    	showMsg("错误提示","只能上传txt,xml,pdf,doc,ppt,xls,docx,pptx,xlsx,mp3,wma,amr,mp4,rar,zip；如需上传其它格式文件请先将其压缩后再上传",1,null);
	                    	return;
	                	}
	                    if (file.size > wxqyh_uploadfile.maxSize){//10485760
	                    	showMsg("错误提示","文件大小不能超过10M，请重新选择",1,null);
	                    	return;
	                    }
	                }
	                else{
                    	showMsg("错误提示","文件为空，请重新选择",1,null);
                    	return;
	                }
	        		showLoading('文件上传中...');
	            	var mediaName = ulobj.attr("fileName");
	            	var fileElementId = ulobj.attr("id");
					if(mediaName.indexOf("searchValue.")==-1)
						ulobj = ulobj.parent().parent().parent();
					else//超级表单附件字段的
						ulobj = ulobj.parent().parent().next().find(".f-item");
	            	wxqyh_uploadFile(fileElementId,mediaName,ulobj);
	            });
			}
        },
        unbind: function() {
	        $('.upload_file_input').unbind('change');
	    }
    };

    function _loadJqueryUI() {
		writeJs(baseURL + "/js/do1/common/jquery-1.6.3.min.js");
		writeJs(baseURL + "/js/3rd-plug/jquery/jquery.form.js");
    }
    function writeJs(url) {
        var d = document;
        var head = document.getElementsByTagName("head")[0];
        var script = d.createElement("script");
        script.setAttribute("type", "text/javascript");
        script.setAttribute("src", url);
        script.setAttribute("async", true);
        script.onerror = function (e) {
            head.removeChild(script);
        };
        head.appendChild(script);
    }