jQuery.extend(jQuery.DIC, {
    // 扩展新方法即可
    mb_strlen: function(str) {
        var len = 0;
        for(var i = 0; i < str.length; i++) {
            len += str.charCodeAt(i) < 0 || str.charCodeAt(i) > 255 ? 2 : 1;
        }
        return len;
    },
    rendPreview: function (obj, previewDivId, width, height) {
        //var inputId = $(obj).attr('id');
    	var jqObj = $(obj);
        var picPath = jqObj.val();
        var previewImgName = jqObj.attr("imgName");
        if(wxqyh_is_debug){
            alert("上传图片开始,picPath="+picPath+",previewImgName="+previewImgName);
        }
        //var ua = navigator.userAgent.toLowerCase();
        //如果上传图片的后缀为空，不过滤，直接上传
        if(chooseImageTypes&&chooseImageTypes.length==1&&chooseImageTypes[0]=='camera'){
            hideLoading();
            _alert('提示',"请在手机上拍照上传","确认",function(){return false;});
            return false;
        }
        if(picPath.lastIndexOf('.')>-1){
            var type = picPath.substring(picPath.lastIndexOf('.') + 1, picPath.length).toLowerCase();
            if (type != undefined && type != "" && type != 'jpg' && type != 'png' && type != 'jpeg') {
//                $('#' + previewDivId).html('');
               	//隐藏上传中的层
               	hideLoading();
    			showMsg("提示信息标题","图片支持jpg/png/jpeg格式，请上传正确的图片格式！",1,null);
                return false;
            }
        }

        if (obj.files && obj.files[0]) {
            var file = obj.files[0];
            var URL = window.URL || window.webkitURL;
            var blob = URL.createObjectURL(file);

            // 执行前函数
            //if($.isFunction(obj.before)) { obj.before(this, blob, file) };
			
            _create(blob,obj,previewImgName);
            /*var reader = new FileReader();
            reader.onload = function(e){
                //$('#' + previewDivId).html('<img src="" id="' + previewDivId + '_img">');
                //$('#' + previewDivId + '_img').attr('src', e.target.result).width(width).height(height);
                //var temp = encodeURIComponent(e.target.result);
            };
            reader.readAsDataURL(obj.files[0]);*/
        } else {
           	//隐藏上传中的层
           	hideLoading();
        }
    }
});
function _create(blob,obj,previewImgName) {
    if(wxqyh_is_debug){
        alert("准备上传图片,previewImgName="+previewImgName);
    }
    var img = new Image();
    img.src = blob;
    img.onload = function () {
        var that = this;
        var quality=1;
        var maxWidth=2560;

        /**
         * 生成base64
         * 兼容修复移动设备需要引入mobileBUGFix.js
         */
        var base64 = "";
        
        //生成比例
        var w = that.width,
            h = that.height,
            scale = w / maxWidth;
        //如果图片大于最大宽度
        if(w> maxWidth){
            quality = 0.8;//压缩图片质量0-1，值越大质量越好
        	w = maxWidth;
        	h = h / scale;
            //生成canvas
            var canvas = document.createElement('canvas');
            var ctx = canvas.getContext('2d');
            $(canvas).attr({width : w, height : h});
            ctx.drawImage(that, 0, 0, w, h);
            var useragent = navigator.userAgent;
	        // 修复IOS
	        if( useragent.match(/iphone/i) || useragent.match(/ipod/i) || useragent.match(/ipad/i)) {
	            var mpImg = new MegaPixImage(img);
	            mpImg.render(canvas, { maxWidth: w, maxHeight: h, quality: quality});
	            base64 = canvas.toDataURL('image/jpeg', quality );
	        }
	
	        else if( useragent.match(/Android/i) ) {
		        // 修复android
	            var encoder = new JPEGEncoder();
	            base64 = encoder.encode(ctx.getImageData(0,0,w,h), quality * 100 );
	        }
	        else{
	        	//非ios和Android系统
	        	base64 = canvas.toDataURL('image/jpeg', quality );
	        }
        }
        else{
            //生成canvas
            var canvas = document.createElement('canvas');
            var ctx = canvas.getContext('2d');
            $(canvas).attr({width : w, height : h});
            ctx.drawImage(that, 0, 0, w, h);
            
        	base64 = canvas.toDataURL('image/jpeg', quality );
        }
        
        $("#imgFileBase").val(base64);
        if(wxqyh_is_debug){
            alert("下面开始上传图片");
        }
        $("#imgFileBaseForm").ajaxSubmit({
            dataType:'json',
            type:'POST',
            async: false,
            success:function(data){
                if(wxqyh_is_debug){
                    alert("上传图片完成，返回结果："+JSON.stringify(data));
                }
                if ("0" == data.code) {
                	var urls = [data.data.imgurl];
                    //$('#' + previewDivId).html('<img src="http://172.20.15.188:8080/cjhapp'+data.data.imgurl+'" width="'+width+'px" height="'+height+'px" id="' + previewDivId + '_img">');
                	notifyImage(urls,$(obj).parent(),previewImgName);
                }
                else{
                   	//隐藏上传中的层
                   	hideLoading();
                    showMsg("", data.desc, 1, 1);
                }
            },
            error:function() {
               	//隐藏上传中的层
               	hideLoading();
    			showMsg("提示信息标题","系统繁忙，请稍后再试！",1,null);
            }
        });
        //alert('成功'+base64);
        // 执行后函数
        //obj.success(result);
    };
}
