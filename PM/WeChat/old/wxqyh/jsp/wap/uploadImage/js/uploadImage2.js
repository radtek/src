
		function chooseImage22(obj) {
			var localId= [];
			var serverId= [];
		    wx.chooseImage({
		    sourceType: chooseImageTypes,
		    success: function (res) {
		    	//选择图片成功后
		        localId = res.localIds;
		        if (localId.length == 0) {
				    showMsg("", '请选择图片');
				    return;
				}
		        //上传图片
		        if (localId.length == 0) {
		            showMsg("", '请选择图片');
		            return;
		            }
		        showLoading('正在准备上传'+localId.length+'张图片...');
				var i = 0, length = localId.length;
				setTimeout(upload2,500);
	            function upload2() {
	            wx.uploadImage({
	                localId: localId[i],
	                isShowProgressTips:0,
	                success: function (res2) {
	                showLoading('正在上传第'+(i+1)+'张图片');
	                i++;
	                serverId.push(res2.serverId);
	                if (i < length) {
	                    setTimeout(upload2,500);
	                }
	                if(serverId.length==localId.length){
	                	newimageupload(serverId,obj);
	                }
	                },
	                fail: function (res2) {
	                	showMsg("", "图片上传失败:"+res2.errMsg+"，请重新上传！");
	                	hideLoading();
	                }
	            });
	            }
		    },
		    error : function(){
		    	hideLoading();
		    	showMsg("", '网络出错');
		    }
		    });
		};
		function newimageupload(serverId,obj){
			var serverIds="";
			var drawString = $("#uploadImgDrawString").val();
			if (!drawString) {
				drawString = '';
			}
			/*showMsg("", 1111);
			hideLoading();*/
			for(var i=0;i<serverId.length;i++){
				serverIds+=serverId[i]+",";
			}
			$.ajax({
				url:baseURL+"/portal/newimageupload/newimageUploadAction!newimageUpload.action?agent="+wxqyh.agent+"&orderId="+wxqyh.orderId,
				type:"POST",
				data: {
					serverIds: serverIds,
					isOpen: wxqyh_isOpen,
					isUsePublic: wxqyh_isUsePublic,
					drawString: drawString
				},
				dataType:"json",
				success:function(result){
					if(result.code!="0"){
						hideLoading();
						showMsg("", result.desc);
						return;
					}
					var urlList=result.data.urlList;
					var previewImgName = $(obj).attr("imgName");
					if(urlList.length>0){
						notifyImage(urlList,$(obj).parent(),previewImgName);
					}
				},
				error:function(){
					hideLoading();
					showMsg("", '网络出错');
				}
			});
			/*for(var i=0;i<serverId.length;i++){
				//serverIds+=serverId[i]+",";
				
				$.ajax({
					url:baseURL+"/portal/newimageupload/newimageUploadAction!newimageUpload.action",
					type:"POST",
					data:{serverIds:serverId[i]},
					dataType:"json",
					success:function(result){
						var urlList=result.data.urlList;
						if(urlList.length>0){
							notifyImage(urlList,$(obj).parent(),"");
						}
						hideLoading();
					},
					error:function(){
						hideLoading();
					}
				});
			}*/
		}
		/*// 5.2 图片预览
		document.querySelector('#previewImage').onclick = function () {
		    wx.previewImage({
		    current: 'http://img5.douban.com/view/photo/photo/public/p1353993776.jpg',
		    urls: [
		        'http://img3.douban.com/view/photo/photo/public/p2152117150.jpg',
		        'http://img5.douban.com/view/photo/photo/public/p1353993776.jpg',
		        'http://img3.douban.com/view/photo/photo/public/p2152134700.jpg'
		    ]
		    });
		};

		// 5.3 上传图片
		document.querySelector('#uploadImage').onclick = function () {
		    if (images.localId.length == 0) {
		    showMsg("", '请先使用 chooseImage 接口选择图片');
		    return;
		    }
		    var i = 0, length = images.localId.length;
		    images.serverId = [];
		    function upload() {
		    wx.uploadImage({
		        localId: images.localId[i],
		        success: function (res) {
		        i++;
		        showMsg("", '已上传：' + i + '/' + length);
		        images.serverId.push(res.serverId);
		        if (i < length) {
		            upload();
		        }
		        },
		        fail: function (res) {
		        showMsg("", JSON.stringify(res));
		        }
		    });
		    }
		    $.ajax({
				url:"${baseURL}/portal/newimageupload/newimageUploadAction!newimageUpload.action",
				type:"POST",
				data:serverId,
				dataType:"json",
				success:function(result){
					var apijs=result.data.apijs;
					appid=apijs.corpId;
					timestamp=apijs.timestamp;
					nonceStr=apijs.noncestr;
					signature=apijs.signature;
				},
				error:function(){
				}
			});
		    
		};*/

