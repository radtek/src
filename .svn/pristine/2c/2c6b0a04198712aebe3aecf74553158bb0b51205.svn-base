var smile_array = {
       '微笑':':smile:',                                       
       '心眼':':heart_eyes:',                           
       '吐舌头':':stuck_out_tongue_closed_eyes:',       
       '冷汗':':cold_sweat:',                           
       '魔鬼':':smiling_imp:',                          
       '爱心':':heart:',                             	 
       '大笑':':grin:',                                 
       '心碎':':broken_heart:',                         
       '开心':':relieved:',                            	
       '睡觉':':sleeping:',                             
       '+1':':+1:',                                     
       '-1':':-1:',                                     
       '胜利':':v:',                                    
       'OK':':ok_hand:',                                
       '鼓掌':':clap:',                                 
       '祈祷':':pray:',                              	 
       '激动':':flushed:',                              
       '喜极而泣':':joy:',                              
       '哭泣':':sob:',                                  
       '丘比特':':cupid:',                              
       '愤怒':':rage:',	                               
		'脸红':':blush:', 				                           
		'味道好':':yum:', 				                           
		'墨镜':':sunglasses:', 			                         
		'失望':':disappointed:',                             
		'惊讶':':astonished:', 					                     
		'络腮胡':':neckbeard:', 	                           
		'流汗':':sweat:', 			                             
		'害怕':':fearful:', 	                               
		'尖叫':':scream:',                                   
		'无嘴':':no_mouth:',						                     
		'无语':':neutral_face:',				                     
		'张嘴':':open_mouth:',					                     
		'鬼':':ghost:',								                       
		'月脸':':new_moon_with_face:',	                     
		'不好':':no_good:',							                     
		'便便':':shit:',						                     
		'感叹号':':exclamation:',					                   
		'问号':':question:',												                         
		'雨伞':':umbrella:',						                     
		'太阳':':sunny:',								                     
		'音乐':':musical_note:'	,  
		'木槿':':hibiscus:',            
		'玫瑰':':rose:',                
		'四叶草':':four_leaf_clover:',    
		'啤酒':':beers:',               
		'鸡尾酒':':cocktail:',            
		'红酒杯':':wine_glass:',          
		'批萨':':pizza:',               
		'意面':':spaghetti:',           
		'米饭':':rice:',                
		'冰激凌':':icecream:',            
		'生日蛋糕':':birthday:',            
		'西瓜':':watermelon:',          
		'步行':':walking:',             
		'自行车':':bike:',                
		'公交车':':bus:',                 
		'火车':':train:',               
		'子弹头':':bullettrain_side:',    
		'爆炸':':boom:',                
		'星星':':star:',                
		'闪电':':zap:',                 
		'打针':':syringe:',
		'波板糖':':lollipop:',
		'美元':':dollar:',
		'花束':':bouquet:',
		'礼物':':gift:',
		'祝':':congratulations:',
		'密':':secret:',
		'吉他':':guitar:',
		'天真':':innocent:',
		'钱袋':':moneybag:',
		'祈祷':':pray:',
		'跑步':':running:',
		'王冠':':crown:',
		'水晶':':crystal_ball:',
		'礼帽':':tophat:',
		'说话':':speak_no_evil:',
		'消息泡泡':':speech_balloon:',
		'猴脸':':monkey_face:'
    };
	function codeToWord(code){
		for(var s in smile_array){
			if(smile_array[s]==code)
				return s;
		}
		return null;
	}
	function wordToCode(word){
		for(var s in smile_array){
			if(s==word)
				return smile_array[s];
		}
		return null;
	};
	function removeAD(){
 	   ad=document.querySelector('.AD');
 	   ad.parentElement.removeChild(ad);
    };
	var _touch = 'ontouchstart' in window,
    _start = _touch ? 'touchstart' : 'mousedown',
	_move=_touch ? 'touchmove' : 'mousemove',
	_end=_touch ? 'touchend' : 'mouseup';
    // 搜索框字母导航
    /*弹出框*/

	    $(function(){
	    	var win_height = $(window).height(),
	  	    	win_width = $(window).width();
	    	//定义
	    	
	        var hasTouch = true,
	            START_EV = hasTouch?"touchstart":"mousedown",
	            MOVE_EV = hasTouch?"touchmove":"mousemove",
	            END_EV = hasTouch?"touchend":"mouseup";

	       
	        var actions = {
	            openLink: function(href, opt){
	                opt = opt || {};
	                if (typeof href !== 'string') {
	                    var node = href;
	                    href = node.href;
	                    opt.target = opt.target || node.target;
	                }
	                if (opt.target && opt.target !== '_self') {
	                    window.open(href, opt.target);
	                } else {
	                    location.href = href;
	                }
	            }
	        }; 


	        

	        $(".wrap_inner").not(".sp").height(win_height);
	       
	        //$(".wrap").height(win_height);

	        // 加载中控制
	        window.ku = {};
	        ku.simple_tips = function(obj){
	            var tipsDom = $(".simple_tips"),
	                tips_width = tipsDom.actual('width'),
	                tips_height= tipsDom.actual('height'),
	                top = (win_height-tips_height)/2-(tips_height/2),
	                left = (win_width-tips_width)/2;

	            obj = obj || {};

	            if(!obj.show){
	                tipsDom.show().css({
	                    top:top,
	                    left:left,
	                    opacity:0,
	                    display:"none"
	                });
	            }else{
	                tipsDom.show().css({
	                    top:top,
	                    left:left,
	                    opacity:1,
	                    display:"inline-block"
	                });
	            }

	        };

	        // 定义选择器
	        var address_link = $(".settings-item .a_link");

	        // 模拟高亮事件
	        address_link.on(START_EV,function(){
	            $(this).closest(".settings-item").addClass('highlight');
	        }).on(END_EV,function(){
	            $(this).closest(".settings-item").removeClass('highlight');
	        });

	        // 控制跳转
	        address_link.on("click", function(e){
	            e.preventDefault();
	            actions.openLink(this);
	        });

	        // 如果是安卓微信，则显示后退
	        /*if(WeixinJS.isWeixin){
	            WeixinJS.hideToolbar();
	        }*/
	        $(".img_preview img").on("load",function(){

	            var width = $(this).width(),
	                height = $(this).height();
	     /*           win_width = $(window).width(),
	                win_height = $(window).height();*/

	            if(width>win_width){
	                $(this).width(win_width);
	                $(this).height(height*(win_width/width));
	            }
/*
	            $(this).css({
	                'position':"absolute",
	                'top':  (win_height-$(this).height())/2+"px",
	                "left": (win_width-$(this).width())/2+"px"
	            });
*/
	            // 返回
	            $(this).siblings(".img_preview_top").find(".back_btn").click(function(){
	                alert("返回事件");
	                $(this).off();
	            });

	            // 删除
	            $(this).siblings(".img_preview_top").find(".red_btn").click(function(){
	                alert("删除事件");
	                $(this).off();
	            });

	        });

	        /*弹出框*/
	        function show_tips(){
	            if(!$(".over_lay").length){
	                $("body").append('<div class="over_lay"></div>');
	            }
	            $(".over_lay").css({
	                "display": "block",
	                "opacity":1
	            })
	        }

	        /*弹出框*/
	        function hide_tips(){
	            $(".over_lay").css({
	                "display": "none",
	                "opacity":0
	            });
	        }

	        /*多选按钮事件*/
	        $(".multiple_btn li").on("click", function(){
	            $(this).toggleClass('active');
	            return false;
	        });

	        /*单选选按钮事件*/
	        $(".radio_btn li").on("click", function(){
	            $(this).addClass('active').siblings('li').removeClass("active");
	            return false;
	        });

	        /*添加回答*/
	        $("#ask_btn").on("click", function(){
	            show_tips();
	            $(".text_tips").show().css({
	                "left":(win_width-$(".text_tips").width())/2,
	                "top":(win_height-$(".text_tips").height())/2
	            });
	            return false;
	        });
	    	
	    	/* 锚点跳转 */
	    	function jump_point(obj){
	    		
	    		var $obj = $(obj)[0],
	    		top_offset =  $obj.offsetTop,
	    		top_scroll = $obj.scrollTop,
	    		tatolTop = top_offset - top_scroll;
	    	
	    	$(".wrap_inner").scrollTop(tatolTop);
	    	}

	    	/* 锚点跳转 */
	    	function jump_point2(obj){
	    		
	    		var $obj = $(obj)[0],
	    		top_offset =  $obj.offsetTop,
	    		top_scroll = $obj.scrollTop,
	    		tatolTop = top_offset - top_scroll-$(window).height()/2;
	    	
	    	$(".wrap_inner").scrollTop(tatolTop);
	    	}
	        
	        //非微信浏览器，不显示页面菜单；
	    	if(!isWeChatApp()) {
	    		$(".return_top_inner").remove();
	    	} 
	        
	        
	        //修改菜单显示的时间为3.5秒
	      /*  setInterval(function(){
	        	$("#return_top").hide(500);
	        },3500)*/

	    	$("#sendComment").on("click", function(){
	    		jump_point2("#comments-box");
	    	});
	    	

	    	$("#down_comment").on("click", function(){
	    		jump_point("#comments-box");
	    	});

	        $("#up_top").on("click", function(){
	            $(".wrap_inner").scrollTop(0);
	        });

	        $("#down_refresh").on("click", function(){
	        	
	        	loadNew();
	        });
	        function hide_lay(){}//防止未知地方调用
	        function show_lay(){}
	    $("body").on('input',".search-input", function(){
	        var val = $(this).val();
	        var input_colse=$('<span class="input_colse"></span>');
	         if(val!=""){
	             $("#letter_search").hide();
	             $("#users_search").show();
	             $(".letter_list").hide();
	             $('.input_colse').remove();
	  	         $(this).after(input_colse)
	         }else{
	             $("#letter_search").show();
	             $("#users_search").hide();
	             $('.input_colse').remove();
	         }
	         $('.input_colse').click(function(){//新增搜索框清空文字样式	
	  	            $(this).prev('.search-input').val('');
	  	            $('#users_search').hide();
	  	            $('#letter_search').show();
	  	            $(this).remove();
	  	     })
	     });
	
	     $("#letter_search").on("click", function(){
	         $(".letter_list").toggle();
	         var over_opactiy_lay = $(".over_opactiy_lay");
	         if(over_opactiy_lay.length){
	             over_opactiy_lay.on("click", function(){
	                 $(".letter_list").hide();
	                 over_opactiy_lay.off();
	             });
	         }
	     });
	     // 判断元素是否隐藏
	     $.fn.ishide = function(){
	         return $(this).css("display") === "none";
	     };

	     // 加号功能
	     var hasTouch = 'ontouchstart' in window;
	     var tap = hasTouch ? 'touchstart' : 'mousedown';

	     $("#sendmsg").on('click',function(){
	    	 commitComment();
	    	 $("#inputDiv").blur();
	    	 $("#inputDiv").css('height','36px');
	    	 $('.wrap_inner').css('padding-bottom','0');
	    	 setTimeout(function(){
	    		 $('.commentBtnBoxBg').hide();
		 		 $('.commentBtnBox').removeClass('active');
		 		 $('#plus_btns').hide(); 
	    	 },250)
	     });
	     $("#plus_btn").on("click", function(){
	         var plus_btns = $("#plus_btns"),
	             emoji_list = $("#emoji_list"),
	             text_input = $(".text_input");

	         text_input.blur();
	         if( !plus_btns.ishide() || !emoji_list.ishide() ){
	             plus_btns.hide();
	             emoji_list.hide();
	             //text_input.focus(); 
	         }else {
	             plus_btns.show();
	             var over_opactiy_lay = $(".over_opactiy_lay");
	             over_opactiy_lay.css({ "z-index": "50" });
	             if(over_opactiy_lay.length){
	                 over_opactiy_lay.on("click", function(){
	                     plus_btns.hide();
	                     emoji_list.hide();
	                     text_input.blur();
	                     over_opactiy_lay.off();
	                     over_opactiy_lay.css({ "z-index": "90" });
	                 });
	             }
	         }
	         return false;
	     });

	     
	     // 展开表情
	     $("#get_smile").on("click",function(){
	         var plus_btns = $("#plus_btns"),
	             emoji_list = $("#emoji_list"),
	             text_input = $(".text_input");

	         plus_btns.hide();
	         emoji_list.show();
	         text_input.blur();
	         var w=$(window).width();
	         function LJZ(){
	        	 $('.foot_plus_bar').find('.item').each(function(index, el) {
		          	 	if($(el).offset().left<parseInt(w)){
		          	 		$(el).find('img[data-src]').each(function(i,el){
		          	 			 var Oimg=$(el).clone();
				                 Oimg.attr({'src':$(el).attr('data-src'),'title':$(el).attr('data-title'),'alt':$(el).attr('data-alt')})
				                 .removeAttr('data-src data-title data-alt')
				                 .hide();
				                 $(el).replaceWith(Oimg);
				                 Oimg.fadeIn();
		          	 		})
		          	 	}
		          	 }); 
	         }
	         LJZ();
	           $('.foot_plus_bar').on(_move,function(event){
	        	   LJZ();
	           })
	         
	     });

	     // 表情列表
	     $(".emoji_list li a").each(function(){
	         emojify.run($(this)[0],'','dataURL');
	     });

	     emojify.run($('.text_input')[0]);
	     if($('.emoji_list_viewport').length){
			 var win_width = $(window).width();
			 if(win_width<1024){
				 $(".emoji_list_viewport").width(win_width);
				 $(".emoji_list_viewport .flipsnap").width(win_width*$(".emoji_list_viewport .item").length);
				 $(".emoji_list_viewport .item").width(win_width);

				 var $pointer = $('.pointer span');
				 var emoji_list_flipsnap = Flipsnap('.emoji_list_viewport .flipsnap', {
					 distance: win_width
				 });
			 }else{
				 $(".emoji_list_viewport").width('740');
				 $(".emoji_list_viewport .flipsnap").width(740*$(".emoji_list_viewport .item").length);
				 $(".emoji_list_viewport .item").width('740');

				 var $pointer = $('.pointer span');
				 var emoji_list_flipsnap = Flipsnap('.emoji_list_viewport .flipsnap', {
					 distance: '740'
				 });
			 }
	         emoji_list_flipsnap.element.addEventListener('fspointmove', function() {
	             $pointer.filter('.current').removeClass('current');
	             $pointer.eq(emoji_list_flipsnap.currentPoint).addClass('current');
	             $pointer.hide().show();
	         }, false);
	     }

	     //插入表情示例
	     $(".emoji_list a").on("click", function(){

	         var plus_btns = $("#plus_btns"),
	             emoji_list = $("#emoji_list"),
	             text_input = $(".text_input");
	         var newVal = $("#inputDiv").val() + '['+codeToWord($(this).attr("title"))+']';
	         newVal = $.trim(newVal);
	         $("#inputDiv").val(newVal);
	         //$(".text_input").trigger("input");

	         setTimeout(function(){
	             emojify.run($('#inputDiv')[0]);
	         },10);

	     });

	     $('.form_btns a.fbtn').on('click',function(){//防止重复提交
	    	 $(this).css('pointer-events', 'none');
	     });
       (function($){
    	 var max_length=30;
    	  $('input.maxlength').parent('div').css('padding-right','40px');
	      $('body').on('input','input.maxlength',function(){//标题显示剩余字数提示
	          	 try{
	          		 if(eval('('+$(this).attr("valid")+')')['maxLength']){
	              		 max_length=eval('('+$(this).attr("valid")+')')['maxLength'];
	              		 $(this).attr('maxlength',max_length);
	              	 } 
	          	 }
	          	 catch(e){
	          	 }
	          	var length=$(this).val().length;
	     		 if(length>max_length){
	     			 return false;
	     		 }
	          	 $(this).attr('maxlength',max_length);
	          	 if(!$(this).next('span').length){
	              		$(this).after('<span id="maxlengthId" style="position:absolute;right:6px;top:18px;color:#999;font-size:12px">'+length+'/'+max_length+'</span>');
	          	 }else{
	          		 $(this).next('span').html(length+'/'+max_length);
	          	 }
	          	 
	      });
	     $('body').on('input','textarea',function(){//textarea显示剩余字数提示
	    	 if($(this).attr('maxlength')){
	    		 var max_length=$(this).attr('maxlength');
	    		 var length=$(this).val().length;
	    		 if($(this).siblings('.tright').length==0){
		             $(this).after('<p class="tright c999">'+length+'/'+max_length+'</p>');
	          	 }else{
	          		 $(this).siblings('.tright').html(length+'/'+max_length);
	          	 } 
	    	 };
	     })
	     var max_height=win_height*0.6;
	     $('body').append($('#inputDiv').clone().attr('id','cloneinputDiv'));
		   $('body').on('input click','.wrap textarea.inputStyle',function(){//textarea高度自适应
			   var index=$('.wrap textarea.inputStyle').index(this);
			   if($('body .cloneTextarea'+index+'').length==0){
				   var cloneTextarea=$(this).clone().removeAttr('id rows').addClass('cloneTextarea cloneTextarea'+index+'').css({'font-size':$(this).css('fontSize'),'height':$(this).height()});
				   $('body').append(cloneTextarea);
			   };
			   var w=$(this).width();
			   $('.cloneTextarea'+index+'').val($(this).val()).css('width',w);
			   if($('.cloneTextarea'+index+'')){
				   var h=$('.cloneTextarea'+index+'')[0].scrollHeight;
				   h=h>max_height?max_height:h;
				   $(this).height(h);
			   }
		   });
    	 $('#inputDiv').on('input',function(event){
    		 var val=$(this).val();
	         var html=val.split('');
    		 $('#cloneinputDiv').val(val).css('width',$(this)[0].scrollWidth);//inputDiv适应高度
    		 var h=$('#cloneinputDiv')[0].scrollHeight;
    		 h=h>96?96:(h>36?h+2:36);
    		 //if(h>=36&&hasTouch){$('#main').css('padding-bottom',h-36)};
			 $(this).height(h);
	         /*for(var i=0;i<html.length;i++){//评论框过滤emoji
	        	 if(html[i].charCodeAt()>=55356&&html[i].charCodeAt()<=59000||html[i].charCodeAt()==9786){
	                  html[i]='';
	                  $(this).val(html.join(''));
	                  $('.topTips').remove();
	                  $('body').append($('<div class="topTips">暂不支持第三方输入法表情</div>'));
	                  setTimeout(function(){
	                	  $('.topTips').remove();
	                  },2000)
              }
	         } */
    	 })
        }($));
       //$('.new_title_box .title').on('input click',function(event){//超级表单新标题样式
       //    var length=$(this).val().length;
       //    var max_length=$(this).attr('maxlength');
       //    if(!max_length){max_length=50;$(this).attr('maxlength',50)}
       //    var w=$(this).width();
       //    if($('.cloneTextareatitle').length==0){
       //        var cloneTextare=$(this).clone().attr({'id':'','class':'cloneTextareatitle'});
       //        $('body').append(cloneTextare);
       //    };
       //    $(this).siblings('.title_state').children('span').html(length+'/'+max_length);
       //    $('.cloneTextareatitle').val($(this).val()).css('width',w);
       //    var h=$('.cloneTextareatitle')&&$('.cloneTextareatitle')[0].scrollHeight;
       //     $(this).height(h);
       //});
       $('body').on('blur','input[type="tel"]',function(){
		   //填写表单页面的样式处理
		   if(location.href.indexOf('wap/form/add.jsp')!=-1){
			   if(this.value&&!(/^(\+)?\d+(\-\d+)?$/g).test($(this).val())){
				   if($(this).parent().find('p.error').length==0){
					   $(this).parent().append("<p class='error'><font color='red'>" + '当前字段格式不对' + "</font></p>");
				   }
			   }else{
				   $(this).parent().find('p.error').remove();
			   }
		   }else{
			   if(this.value&&!(/^[-]?\d+(\.\d+)?$/g).test($(this).val())){
				   _tooltips('当前字段格式不对');
			   }
		   }
       });
       $('body').on('blur','input[type="number"]',function(){
			   if(this.value&&!(/^[-]?\d+(\.\d+)?$/g).test($(this).val())){
				   _tooltips('当前字段格式不对');
			   }
       });
	  $('#inputDiv').on('click',function(e){//评论框弹上去
	 		e.stopPropagation();
	 		if(!$('.commentBtnBox').hasClass('active')){
	 			$('.commentBtnBox').addClass('active fadeIn');
	 			$('.commentBtnBoxBg').addClass('fadeIn').show();
	 			$('#plus_btns').show();
				window.scrollBy(0,0);
	 			setTimeout(function(){
	 				$('.commentBtnBox').removeClass('fadeIn');
	 				$('.commentBtnBoxBg').removeClass('fadeIn');
	 			},250)
	 		}
	  })
	  $('.commentBtnBoxBg').on("click",function(){//评论框遮罩层
	 		   $('.commentBtnBoxBg').hide();
	 		   $('.commentBtnBox').removeClass('active');
	 		   $('#plus_btns').hide();
	  })
});
    	

