
define('register', [], function(require, exports, module) {
    "require:nomunge,exports:nomunge,module:nomunge"; // yui 压缩配置，不混淆这三个变量
    module.exports = {
        init: function() {
        	 $('.imageFileInput').on('change', function() {
                  //   $('body').on('change','.imageFileInput', function() {
               	//显示上传中的层
        		showLoading('图片上传中...');
                $.DIC.rendPreview(this, 'imglist', 118, 118);
            });
            $('.imageFileInput').on('click',function(event){
            	//    $('body').on('click','.imageFileInput',function(event){
        		if(checkJsApi_image && isWeChatApp()) {
        			event.preventDefault();
        			chooseImage22(this);
        	    }
        	});
        },
        step: function(n) {
            for(var i = 1;i <= 2;i++) {
                if(n == i) {
                    $('#step_' + i).show();
                    $('#navStep_' + i).attr('class', 'current');
                } else {
                    $('#step_' + i).hide();
                    $('#navStep_' + i).attr('class', '');
                }
            }
            if(n == 1) {
                $('#registersite input[name=step]').val(1);
                $('#navStep_1').html('<i class="mral fl"></i>基本信息<i class="fr"></i>');
                $('#navStep_2').html('社区资料<em class="fr"></em>');
            }
            if(n == 2) {
                $('#registersite input[name=step]').val(2);
                $('#navStep_1').html('基本信息');
                $('#navStep_2').html('<i class="mral fl"></i>社区资料<i class="fr"></i>');
            }
        },
        checkForm: function() {
//            var content = $('#content').val();
//            var contentLen = jq.DIC.mb_strlen(jq.DIC.trim(content));
//            if (contentLen < 15) {
//                jq.DIC.dialog({content:'内容过短', autoClose:true});
//                return false;
//            }

            return true;
        },
    }
});
