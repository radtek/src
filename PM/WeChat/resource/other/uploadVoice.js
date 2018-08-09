
var voiceEdit_template=''
	+'<div class="list">'
	+' <div class="tapeEnd flexCenter">'
	+'	<div class="play">'
	+'		<img class="tapeEndImg" src="'+baseURL+'/jsp/wap/images/tapeEndNoPlay.png">'
	+'		<span>播放语音</span>'
	+'	</div>'
	+'	<input type="hidden" name="voiceIds" value="@mediaId">'
	+'	<div class="time">@voiceTime"</div>'
	+'	<div class="flexItem"><div class="wen"></div></div>'
	+'	<div class="del"></div>'
	+' </div>'
	+'</div>'

var voiceDetail_template=''
	+'<div class="list">'
	+'	<div class="tapeEnd flexCenter">'
	+'		<div class="play">'
	+'			<img class="tapeEndImg" src="'+baseURL+'/jsp/wap/images/tapeEndNoPlay.png">'
	+'			<span>播放语音</span>'
	+'		</div>'
	+'		<input type="hidden" value="@mediaId">'
	+'		<div class="time">@voiceTime"</div>'
	+'	</div>'
	+'</div>';
/**
 * 播放语音
 */
var voice_lock=false;
/*var stopVoiceIds=""; 
var oldMediaId="";
function wxqyh_playVoice(mId){
	if(mId==undefined||mId==""){
		$('body').find('.tapeEnd .play img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.png');
		$('body').find('.tapeEnd .play span').html('播放语音');
		voice_lock=false;
		return;
	}
	if(!isWeChatApp()){
		$('body').find('.tapeEnd .play img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.png');
		$('body').find('.tapeEnd .play span').html('播放语音');
		voice_lock=false;
		showMsg("提示","请在微信端进行播放",1,null);
		return;
	}
	oldMediaId=mId;
	$.ajax({
		url: baseURL+"/portal/imageupload/imageUploadAction!getServerIdByMid.action?mediaId=" + mId,
		type:"POST",				
		dataType:"json",
		success:function(result){
			var serverId= result.data.serverId;
			//alert("serverId:"+serverId);
			if(serverId==""||serverId==undefined){
				$('body').find('.tapeEnd .play img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.png');
				$('body').find('.tapeEnd .play span').html('播放语音');
				voice_lock=false;
				oldMediaId="";
            	showMsg("错误提示",result.desc,1,null);
            	return;
			}
			wx.downloadVoice({
			    serverId: serverId, // 需要下载的音频的服务器端ID，由uploadVoice接口获得
			    isShowProgressTips: 1,// 默认为1，显示进度提示
			    success: function (res) {
			        var localId = res.localId; // 返回音频的本地ID
			        stopVoiceIds=localId;
			        wx.playVoice({
					    localId: localId, // 需要播放的音频的本地ID，由stopRecord接口获得
					    
					});
			        wx.onVoicePlayEnd({
					    serverId: serverId, // 需要下载的音频的服务器端ID，由uploadVoice接口获得
					    success: function (res) {
					        var localId2 = res.localId; // 返回音频的本地ID
					        $('body').find('.tapeEnd .play img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.png');
					        $('body').find('.tapeEnd .play span').html('播放语音');
					        oldMediaId="";
					        voice_lock=false;
					    },
					    fail: function (res2) {
					    	$('body').find('.tapeEnd .play img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.png');
					        $('body').find('.tapeEnd .play span').html('播放语音');
					        oldMediaId="";
					        voice_lock=false;
		                }
					});
			    },
			    fail: function (res2) {
			    	$('body').find('.tapeEnd .play img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.png');
			        $('body').find('.tapeEnd .play span').html('播放语音');
			    	showMsg("提示","你的手机不支持语音下载播放",1,null);
			    	voice_lock=false;
                }
			
			});
		},
		error: function () {
			voice_lock=false;
			oldMediaId="";
			showMsg("错误提示","网络连接失败，请检查网络连接",1,null);
		}
	});
}*/

/**
 * 识别音频并返回识别结果
 */
var lock_translate=false;
/*function wxqyh_translateVoice(mId,obj){
	if(mId==undefined||mId==""){
		lock_translate=false;
		return;
	}
	showLoading('识别中...');
	$.ajax({
		url: baseURL+"/portal/imageupload/imageUploadAction!getServerIdByMid.action?mediaId=" + mId,
		type:"POST",				
		dataType:"json",
		success:function(result){
			hideLoading();
			var serverId= result.data.serverId;
			//alert("serverId:"+serverId);
			if(serverId==""||serverId==undefined){
				showMsg("错误提示",result.desc,1,null);
				lock_translate=false;
				return;
			}
			wx.downloadVoice({
			    serverId: serverId, // 需要下载的音频的服务器端ID，由uploadVoice接口获得
			    isShowProgressTips: 1,// 默认为1，显示进度提示
			    success: function (res) {
			        var localId = res.localId; // 返回音频的本地ID
			        //alert("localId:"+localId);
			        wx.translateVoice({
			 		   localId: localId, // 需要识别的音频的本地Id，由录音相关接口获得
			 		    isShowProgressTips: 1, // 默认为1，显示进度提示
			 		    success: function (res2) {
			 		       //alert(res.translateResult); // 语音识别的结果
			 		    	lock_translate=false;
			 		    	if($(obj).val()==""){
			 		    		$(obj).val(res2.translateResult);
			 		    	}else{
			 		    		$(obj).val($(obj).val()+"\n"+res2.translateResult);
			 		    	}
			 		    	$(obj).trigger('click');
				 		    $(obj).focus();
			 		    },
			 		   fail: function (res2) {
					    	lock_translate=false;
					    	showMsg("错误提示","语音识别失败",1,null);
					    }
			 		});
			    },
			    fail: function (res2) {
			    	lock_translate=false;
			    	showMsg("错误提示","你的手机不支持语音识别",1,null);
			    }
			});
		},
		error: function () {showMsg("错误提示","网络连接失败，请检查网络连接",1,null);}
	});
}*/

/**
 * 删除语音
 * @param mediaId
 */
/*function wxqyh_delVoice(mediaId){
	if(mediaId==""||mediaId==undefined){
		return;
	}
	$.ajax({
		url:baseURL+"/portal/imageupload/imageUploadAction!doDelFile.action?mediaId="+mediaId+'&groupId='+wxqyh_uploadfile.groupId,
		type:"GET",
		dataType:"json",
		success:function(result){
			if('0'!=result.code){
    			showMsg("错误提示",result.desc,1,null);
            }
		},
		error: function () {showMsg("错误提示","网络连接失败，请检查网络连接",1,null);}
		
	});
}*/



$(function () {
		/**
		 * 录音
		 */
		if (!isQiyeweixin()) {
			$(".tape").show();//非企业微信客户端显示录音图标
		}
    	$('.tape').on('click',function(){//
    		if(!isWeChatApp()){//非手机端不能进行录音
				showMsg("错误提示","请在手机微信端进行录音",1,null);
				return;
			}
			/*if (isQiyeweixin()) {
				showMsg("错误提示", "企业微信端不支持录音识别", 1, null);
				return;
			}*/
    		if(voice_lock||lock_translate){//播音或识别时不能进行录音
    			return;
    		}
			var _this=this;
			$div=$('.tapePop');
			$div.find('img').attr('src',baseURL+'/jsp/wap/images/tapePlay.gif');
			$div.show();
			$('.overlay').show();									
			
		wx.startRecord();
		var time=60;
		var timer=setInterval(function(){
			time-=1;
			if(time<10){
				if(time<=0){
					time=0;
					$div.find('img').attr('src',baseURL+'/jsp/wap/images/tapeNoPlay.jpg');
					clearInterval(timer);
				};
				$div.find('.tapeTime').html('00:0'+time);
			}else{
				$div.find('.tapeTime').html('00:'+time);
			}
		},1000);
		wx.onVoiceRecordEnd({
		    // 录音时间超过一分钟没有停止的时候会执行 complete 回调
		    complete: function (res) {
		        var localId = res.localId;
		        $div.hide();
				$('.overlay').hide();
				clearInterval(timer);
				$div.find('.tapeTime').html('00:60');
				wx.translateVoice({
					   localId: localId, // 需要识别的音频的本地Id，由录音相关接口获得
					    isShowProgressTips: 1, // 默认为1，显示进度提示
					    success: function (res1) {
					    	
				 		    $("#voiceContent").val(res1.translateResult);
					    	$("#voice_div").show();
					    	var cwidth = document.getElementById("voice_div").offsetWidth,
					        cheight= document.getElementById("voice_div").offsetHeight,
					        ctop = (win_height-cheight)/2,
					        cleft = (win_width-cwidth)/2;
					    	$("#voice_div").css({
					    		'top' : ctop + "px",
					    		'left' : cleft + "px"
					    	});
					    	$(".overlay").height($(window).height()*5);
					    }
					});
		        /*wx.uploadVoice({
		    	    localId: localId, // 需要上传的音频的本地ID，由stopRecord接口获得
		    	    isShowProgressTips: 1,// 默认为1，显示进度提示
		    	    success: function (res) {
		    	        var serverId = res.serverId; // 返回音频的服务器端ID	
		    	        showLoading('上传中...');	    	        
		    	        $.ajax({
							url:baseURL+"/portal/newimageupload/newimageUploadAction!newVoiceUpload.action?agent="+wxqyh.agent+"&seconds=60",
					     	type:"POST",
							data:{serverIds:serverId,isOpen:wxqyh_isOpen,isUsePublic:wxqyh_isUsePublic},
					     	dataType:"json",
					     	success:function(result){
					     		if(result.code=="0"){
					     			hideLoading();
					    			var mediaId = result.data.mediaId;
					        		
					    			var tmp=voiceEdit_template.replace("@voiceTime","60");
					    				tmp=tmp.replace("@mediaId",mediaId);
					                 var $parents=$(_this).parents('.f-item');
					                 if($parents.next('.tapeEndBox').length==0){
					                	 $parents.after('<div class="tapeEndBox"></div>');
					                	 $parents.next('.tapeEndBox').append(tmp);
					                 }else{
					                	 $parents.next('.tapeEndBox').append(tmp);
					                 }
					    		}else{
					    			showMsg("错误提示",data.desc,1,null);
					    		}
					     	},
					     	error : function(){	
					    		showMsg("错误提示","网络连接失败，请检查网络连接",1,null);
							}
		    	        });
		    	    }
		        });*/
			    }
			});
		/**
		 * 录音说完了
		 */
			$div.find('.popBox_submit_btn').off('click').on('click',function(){//确定
				$div.hide();
				$('.overlay').hide();
				clearInterval(timer);
				$div.find('.tapeTime').html('00:60');
				if(time==60){
					time=59
				};
				var voiceTime=60-time;
				wx.stopRecord({
			    	success: function (res) {
			        var localId = res.localId;
			        wx.translateVoice({
						   localId: localId, // 需要识别的音频的本地Id，由录音相关接口获得
						    isShowProgressTips: 1, // 默认为1，显示进度提示
						    success: function (res1) {
						        //alert(res1.translateResult); // 语音识别的结果
						    	//var obj=$(this).parents(".f-item").find("textarea");
						        $("#voiceContent").val(res1.translateResult);
					    	$("#voice_div").show();
					    	var cwidth = document.getElementById("voice_div").offsetWidth,
					        cheight= document.getElementById("voice_div").offsetHeight,
					        ctop = (win_height-cheight)/2,
					        cleft = (win_width-cwidth)/2;
					    	$("#voice_div").css({
					    		'top' : ctop + "px",
					    		'left' : cleft + "px"
					    	});
					    	$(".overlay").height($(window).height()*5);
						    }
						});
			       /*if(localId){
			        	wx.uploadVoice({
				    	    localId: localId, // 需要上传的音频的本地ID，由stopRecord接口获得
				    	    isShowProgressTips: 1,// 默认为1，显示进度提示
				    	    success: function (res1) {
				    	        var serverId = res1.serverId; // 返回音频的服务器端ID
				    	        showLoading('上传中...');
				    	        $.ajax({
									url:baseURL+"/portal/newimageupload/newimageUploadAction!newVoiceUpload.action?agent="+wxqyh.agent+"&seconds="+voiceTime,
							     	type:"POST",
									data:{serverIds:serverId,isOpen:wxqyh_isOpen,isUsePublic:wxqyh_isUsePublic},
							     	dataType:"json",
							     	success:function(result){
							     		if(result.code=="0"){
							     			hideLoading();
							    			var mediaId = result.data.mediaId;
							        		
							    			var tmp=voiceEdit_template.replace("@voiceTime",voiceTime);
						    					tmp=tmp.replace("@mediaId",mediaId);
							                 var $parents=$(_this).parents('.f-item');
							                 if($parents.next('.tapeEndBox').length==0){
							                	 $parents.after('<div class="tapeEndBox"></div>');
							                	 $parents.next('.tapeEndBox').append(tmp);
							                 }else{
							                	 $parents.next('.tapeEndBox').append(tmp);
							                 }
							    		}else{
							    			showMsg("错误提示",data.desc,1,null);
							    		}
							     	},
							     	error : function(){	showMsg("错误提示","网络连接失败，请检查网络连接",1,null);}
					    	        });
							 
				    	    }
				        });
			        }else{
			        	showMsg("错误提示","录音失败,请重新录音",1,null);
			        	return;
			        }*/
			        
			    	}
				});
				
			});
			$div.find('.popBox_cancel_btn').off('click').on('click',function(){//取消
				$div.hide();
				$('.overlay').hide();
				clearInterval(timer);
				$div.find('.tapeTime').html('00:60');
				wx.stopRecord({
					success: function (res) {
						var localId = res.localId;
					}
				})		
			});
			
		});
		/*$('body').on('click','.tapeEnd .play',function(){//播放录音
			
			if(stopVoiceIds!=""){
				wx.stopVoice({
				    localId: stopVoiceIds, // 需要停止的音频的本地ID，由stopRecord接口获得
				});
			}
			if(lock_translate){
				return;
			}
			if(voice_lock){
				$('body').find('.tapeEnd .play img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.png');
				$('body').find('.tapeEnd .play span').html('播放语音');
				voice_lock=false;
			}			
			var mediaId=$(this).parents('.tapeEnd').children('input').val();
			if(mediaId==oldMediaId){
				oldMediaId="";
				return;
			}
			$(this).children('img').attr('src',baseURL+'/jsp/wap/images/tapeEndPlay.gif');
			$(this).children('span').html('停止播放');
			voice_lock=true;
			wxqyh_playVoice(mediaId);
			//$(this).children('img').attr('src',baseURL+'/jsp/wap/images/tapeEndNoPlay.gif');
			
		});*/
		/*$('body').on('click','.tapeEnd .del',function(){//删除录音
			if(voice_lock||lock_translate){//播音或识别时不能删除录音
    			return;
    		}
			var mediaId=$(this).parents('.tapeEnd').children('input').val();
			//alert(mediaId);
			wxqyh_delVoice(mediaId);
			$(this).parents('.list').remove();
		});*/
		/*$('body').on('click','.tapeEnd .wen',function(){//语音识别
			if(!isWeChatApp()){//非手机端不能进行录音
				showMsg("错误提示","请在手机微信端进行语音识别",1,null);
				return;
			}
			if(voice_lock||lock_translate){//播音时不能识别语音
    			return;
    		}
			var mediaId=$(this).parents('.tapeEnd').children('input').val();
			lock_translate=true;
			var obj=$(this).parents('.tapeEndBox').prev(".f-item").find("textarea");
			wxqyh_translateVoice(mediaId,obj)
		});*/
		
		$('body').on('click','.tips_submit_btn',function(){//识别确认
			var voiceContent=$("#voiceContent").val();
			 var obj=$('.tape').parents('.f-item').find("textarea");
			 if($(obj).val()==""){
			   $(obj).val(voiceContent);
			  }else{
			   $(obj).val($(obj).val()+"\n"+voiceContent);
			  }
			  $(obj).trigger('click');
			     $(obj).focus();
			 restoreSubmit();
			 $(".overlay").hide();
			 $("#voice_div").hide();
		});
		$('body').on('click','.tips_cancel_btn',function(){//识别取消
			restoreSubmit();
			 $(".overlay").hide();
			 $("#voice_div").hide();
		});

});




/*function wxqyh_uploadVoice(serverId,seconds){
	showLoading('上传中...');
	 $.ajax({
		url:baseURL+"/portal/newimageupload/newimageUploadAction!newVoiceUpload.action?agent="+wxqyh.agent+"&seconds="+seconds,
     	type:"POST",
		data:{serverIds:serverId,isOpen:wxqyh_isOpen,isUsePublic:wxqyh_isUsePublic},
     	dataType:"json",
     	success:function(result){
     		hideLoading();
     		if(result.code=="0"){
    			var mediaId = result.data.mediaId;
    			//alert(mediaId);
    			var tmp=voiceEdit_template.replace("@voiceTime",seconds);
					tmp=tmp.replace("@mediaId",mediaId);
                 var $parents=$('.tape').parents('.f-item');
                 if($parents.next('.tapeEndBox').length==0){
                	 $parents.after('<div class="tapeEndBox"></div>');
                	 $parents.next('.tapeEndBox').append(tmp);
                 }else{
                	 $parents.next('.tapeEndBox').append(tmp);
                 }
    		}else{
    			showMsg("错误提示",data.desc,1,null);
    		}
     	},
     	error : function(){	
    		showMsg("错误提示","网络连接失败，请检查网络连接",1,null);
		}
	 });
}
*/

function previewVoice(voiceInfos,ulId,isEdit){
	if(!voiceInfos || voiceInfos.length==0){
		return;
	}
	var _test="";
	var temp;
	if(isEdit){
		for(var i=0;i<voiceInfos.length;i++){
			temp = voiceInfos[i];
			_test+=voiceEdit_template.replace("@voiceTime",temp.ext).replace("@mediaId",temp.id);
		}
		$("#"+ulId).parents('.f-item').after('<div class="tapeEndBox"></div>');
		$("#"+ulId).parents('.f-item').next('.tapeEndBox').append(_test);
	}else{
		for(var i=0;i<voiceInfos.length;i++){
			temp = voiceInfos[i];
			
			_test+=voiceDetail_template.replace("@voiceTime",temp.ext).replace("@mediaId",temp.id);
		}
		$("#"+ulId).append(_test);
	}
}
