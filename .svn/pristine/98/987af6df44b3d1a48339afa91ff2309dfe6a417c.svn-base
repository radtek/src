/**
 * Created by lishanggang on 2017/9/8.
 */
    var imageObject,        //图片参数对象
        initialImage,       //初始图片对象
        imgUrlArr = [],     //全部可预览图片url
        templateDOM={};     //DOM对象

    function pushImageUrl() { //获取页面可预览的图片url,替换成预览url
        var totalIMG = $(".wrap_inner img");
        imgUrlArr = [];
        for (var i = 0; i < totalIMG.length; i++) {
            var url = totalIMG.eq(i).attr("src");
            if (url && url != "" && url.indexOf("/upload") != -1) {
                if (url.indexOf("/compress/upload/img/") != -1) {
                    url = url.split("compress/").join("");
                }
                imgUrlArr.push(url);
            }
        }
    }

    function imageOld(url) { //获取图片参数初始化，显示图片预览界面
        $(".inner_img_preview").children().remove();
        $(".inner_img_preview").append('<img  id="src_image"  src="' + url + '" alt=""/>');
        $(".icon-download a").attr("href", url);		//下载图片链接
        imageObject = {};
        var $image = $("#src_image");
        $("#src_image").on("load", function (event) {
            if (hasLoad) {
                return;
            }
            var aspectRatio = $image[0].naturalWidth / $image[0].naturalHeight;
            var mtH = ($(".img_preview").height() - $image.height()) / 2, mlW = ($(".img_preview").width() - $image.width()) / 2;
            imageObject = {
                naturalWidth: $image[0].naturalWidth,
                naturalHeight: $image[0].naturalHeight,
                aspectRatio: aspectRatio,
                ratio: $image.width() / $image[0].naturalWidth,
                width: $image.width(),
                height: $image.height(),
                imgRatio: $image.width() / $image.height(),
                left: mlW,
                top: mtH,
                rotateDeg: 0,
                action: false,
            };
            initialImage = $.extend({}, imageObject); //保存原图对象
            this.imageObject = imageObject;
            this.initialImage = initialImage;
            renderImage();			//设置图片样式
            hasLoad = true;
            templateDOM={
                limitWidth:650,                                         //大于650px,左右大图标显示，小图标隐藏
                winPreviewW: $(".img_preview").width(),                 //灰色背景宽度
                winPreviewH: $(".img_preview").height(),                //灰色背景高度
                middleIconPreview: $(".middleIconPreview"),             //左右图标按钮
                FooterPrevTool: $(".pcimg-preview-footer"),             //工具栏
                FooterPrevIcon: $(".pcimg-preview-footer .icon-prev"),  //底部左按钮
                FooterNextIcon: $(".pcimg-preview-footer .icon-next"),  //底部右按钮
                prevParent: $(".pcimg-preview-footer .icon-prev").parent(),
                nextParent: $(".pcimg-preview-footer .icon-next").parent(),
            }
            setToolStyle(templateDOM); 		//工具栏的显示隐藏
            setUrlPosition(url);	//上下张图标的显示隐藏
            clickIconView();		//全部图标点击事件
            mouseWheel(); 			//鼠标滑动放大缩小
            mouseDownImage();		// 鼠标按下拖动图片
        })

        $(".inner_img_preview,.closeIcon").on("click", function (event) { //关闭图标
            hideImage(event);
        })

        $(window).on("resize", function () {    //窗口变化改变图片的居中、工具栏控制
            templateDOM= {
                winPreviewW: $(".img_preview").width(),
                winPreviewH: $(".img_preview").height(),
                middleIconPreview: $(".middleIconPreview"),
                FooterPrevIcon: $(".pcimg-preview-footer .icon-prev"),
                FooterNextIcon: $(".pcimg-preview-footer .icon-next"),
            };
            this.initialImage.left=(templateDOM.winPreviewW-initialImage.width)/2;
            this.initialImage.top=(templateDOM.winPreviewH-initialImage.height)/2;
            imageObject.left = (templateDOM.winPreviewW - $image.width()) / 2;
            imageObject.top = (templateDOM.winPreviewH - $image.height()) / 2;
            if (templateDOM.winPreviewW > 650) {
                templateDOM.middleIconPreview.show();
                templateDOM.FooterPrevIcon.hide();
                templateDOM.FooterNextIcon.hide();
            }else{
                templateDOM.middleIconPreview.hide();
                templateDOM.FooterPrevIcon.show();
                templateDOM.FooterNextIcon.show();
            }
            renderImage();
        })
    }
//工具栏的显示隐藏
    function setToolStyle(templateDOM) {
        templateDOM.FooterPrevTool.show().animate({"bottom": "0"}, 200);
        if ($(".img_preview").width() > templateDOM.limitWidth) {
            templateDOM.middleIconPreview.show();
            templateDOM.FooterPrevIcon.hide();
            templateDOM.FooterNextIcon.hide();
        }
        $("#loading_image_div").on("mouseenter", function (event) {
            templateDOM.FooterPrevTool.show().animate({"bottom": "0"}, 200);
            if ($(".img_preview").width() > templateDOM.limitWidth) {
                templateDOM.middleIconPreview.show();
            }
        }).on("mouseleave", function (event) {
            templateDOM.middleIconPreview.hide();
            templateDOM.FooterPrevTool.hide().css("bottom", "-45px");
        })
    }
//上下张图标的显示隐藏
    function setUrlPosition(url) {
        var prevShow = $(".middleIconPreview.prevShow"), nextShow = $(".middleIconPreview.nextShow");
        $(".pcimg-preview-footer .icon-resize").parent().addClass("disable");
        var num = url.lastIndexOf("\/");
        url = url.substring(num + 1, url.length);
        if (imgUrlArr[0].indexOf(url) > 0) {
            templateDOM.prevParent.addClass("disable");
            prevShow.addClass("disable");
        } else {
            templateDOM.prevParent.removeClass("disable");
            prevShow.removeClass("disable");
        }
        if (imgUrlArr[imgUrlArr.length - 1].indexOf(url) > 0) {
            templateDOM.nextParent.addClass("disable");
            nextShow.addClass("disable");
        } else {
            templateDOM.nextParent.removeClass("disable");
            nextShow.removeClass("disable");
        }
    }
//全部图标点击事件
    function clickIconView() {
        $(".pcimg-operate-list li,.middleIconPreview").off('click').on("click", function (e) {
            var $target = $(e.target);
            var action = $target.attr('data-id');
            if ($(this).hasClass("disable")) {
                return;
            }
            switch (action) {
                case 'reset':
                    resetImage();
                    break;
                case 'rotate':
                    rotateImage(90);
                    break;
                case 'zoomIn':
                    zoomInOut(0.1, "zoomIn");
                    break;
                case 'zoomOut':
                    zoomInOut(-0.1, "zoomOut");
                    break;
                case "prev":
                    viewUpDown("prev");
                    break;
                case "next":
                    viewUpDown("next");
                    break;
            }
        })
    }
//滑轮滚动
    function mouseWheel() {
        $("#loading_image_div").off("wheel mousewheel DOMMouseScroll").on("wheel mousewheel DOMMouseScroll", function (event) {
            var event = event || window.event;
            event.preventDefault();
            var e = event.originalEvent;
            var delta = 1;
            var ratio = 0.1;

            if (e.deltaY) {
                delta = e.deltaY > 0 ? 1 : -1;
            } else if (e.wheelDelta) {
                delta = -e.wheelDelta / 120;
            } else if (e.detail) {
                delta = e.detail > 0 ? 1 : -1;
            }
            zoomInOut(-delta * ratio, true);
        });
    }

    function mouseDownImage() { //鼠标按下
        var EVENT_MOUSEDOWN = "mousedown touchstart pointerdown MSPointerDown",//按下鼠标
            EVENT_MOUSEMOVE = "mousemove touchmove pointermove MSPointerMove",  //鼠标移动
            EVENT_MOUSEUP = "mouseup touchend touchcancel pointerup pointercancel MSPointerUp MSPointerCancel";  //松开鼠标
        var mouseOptions = {};
        var $image = $("#src_image");
        //按下鼠标事件
        $image.off(EVENT_MOUSEDOWN).on(EVENT_MOUSEDOWN, function (event) {
            var event = event || window.event;
            var originalEvent = event.originalEvent;
            imageObject.action = true;
            mouseOptions.startX = event.pageX || originalEvent && originalEvent.pageX || event.clientX;
            mouseOptions.startY = event.pageY || originalEvent && originalEvent.pageY || event.clientY;
            event.preventDefault();
        }).off(EVENT_MOUSEMOVE).on(EVENT_MOUSEMOVE, function (event) {		//移动鼠标事件
            var event = event || window.event;
            var originalEvent = event.originalEvent;
            event.preventDefault();

            //鼠标按下状态且左右或者上下宽度大于预览的大小
            if (imageObject.action) {
                mouseOptions.endX = event.pageX || originalEvent && originalEvent.pageX || event.clientX;
                mouseOptions.endY = event.pageY || originalEvent && originalEvent.pageY || event.clientY;

                var offsetX = mouseOptions.endX - mouseOptions.startX;
                var offsetY = mouseOptions.endY - mouseOptions.startY;
                if (offsetY === undefined) {
                    offsetY = offsetX;
                }
                isNumber(parseFloat(offsetX)) ? offsetX : offsetX = 0;
                isNumber(parseFloat(offsetY)) ? offsetY : offsetY = 0;
                var $imageW = $image.width(),$imageH = $image.height();
                var $imageNew_left = $image.offset().left + offsetX;
                var $imageNew_top = $image.offset().top + offsetY;

                if(imageObject.rotateDeg % 180 != 0){
                    $imageW = [$imageH, $imageH = $imageW][0];
                }
                if ($imageW > templateDOM.winPreviewW) {
                    if ($imageNew_left > 0) {
                        $imageNew_left = 0;
                    } else if ($imageNew_left < templateDOM.winPreviewW - $imageW) {
                        $imageNew_left = templateDOM.winPreviewW - $imageW;
                    }
                } else {
                    $imageNew_left=$image.offset().left;
                }
                if ($imageH > templateDOM.winPreviewH) {
                    if ($imageNew_top > 0) {
                        $imageNew_top = 0;
                    }else if ($imageNew_top < templateDOM.winPreviewH - $imageH) {
                        $imageNew_top = templateDOM.winPreviewH - $imageH;
                    }
                }else{
                    $imageNew_top = $image.offset().top;
                }

                $image.offset({
                    left : $imageNew_left,
                    top : $imageNew_top
                });
                imageObject.left=Number(parseInt($image.css("left")));
                imageObject.top=Number(parseInt($image.css("top")));
                mouseOptions.startX = mouseOptions.endX;
                mouseOptions.startY = mouseOptions.endY;
            }
        }).on(EVENT_MOUSEUP, function (event) {//图片松开鼠标事件
            imageObject.action = false;
        }).on("mouseout", function (){
            imageObject.action = false;
        })
    }

    function rotateImage(degrees) { //旋转
        var $PreviewWight=templateDOM.winPreviewW,$PreviewHight=templateDOM.winPreviewH;
        if (isNumber(degrees)) {
            var totalDegress = ((imageObject.rotateDeg || 0) + degrees);
        }
        if (totalDegress % 180 != 0) {
            $PreviewWight=[templateDOM.winPreviewH,$PreviewHight = templateDOM.winPreviewW][0];
        }

        var width = Math.min(initialImage.width, $PreviewWight), height = Math.min(initialImage.height, $PreviewHight);
        if (width / height > imageObject.aspectRatio) {
            width = height * imageObject.aspectRatio;
        } else {
            height = width / imageObject.aspectRatio;
        }

        imageObject.width = width;
        imageObject.height = height;
        imageObject.left = (templateDOM.winPreviewW - width) / 2;
        imageObject.top = (templateDOM.winPreviewH - height) / 2;
        imageObject.rotateDeg = totalDegress;
        renderImage();
        if (imageObject.rotateDeg > 0) {
            $(".pcimg-preview-footer .icon-resize").parent().removeClass("disable");
        }
    }

    function isNumber(n) {
        return typeof n === 'number' && !isNaN(n);
    }

    function resetImage() { //重置
        imageObject.rotateDeg = 0;
        $(".pcimg-preview-footer .icon-resize").parent().addClass("disable");
        this.imageObject = $.extend({}, this.initialImage);
        renderImage();
    }

    function zoomInOut(ratio, hasZoom) { //放大放小
        var width, height;
        ratio = parseFloat(ratio);
        if (isNumber(ratio)) {
            if (ratio < 0) {
                ratio = 1 / (1 - ratio);
            } else {
                ratio = 1 + ratio;
            }
        }
        width = imageObject.width * ratio;
        height = imageObject.height * ratio;
        if (hasZoom == "zoomOut") {
            var percent = (imageObject.width / ratio / imageObject.naturalWidth * 100).toFixed(0);			//缩小百分比
        } else {
            var percent = (width / imageObject.naturalWidth * 100).toFixed(0);							//放大百分比
        }
        if (percent <= 5) {
            percent = 5;
            width = imageObject.naturalWidth / 20;
            height = imageObject.naturalHeight / 20;
        } else if (percent > 90 && percent < 110) {
            percent = 100;
        } else if (percent > 1600) {
            percent = 1600;
            width = imageObject.naturalWidth * 16;
            height = imageObject.naturalHeight * 16;
        }
        imageObject.top = (templateDOM.winPreviewH - height) / 2;
        imageObject.left = (templateDOM.winPreviewW - width) / 2;
        imageObject.width = width;
        imageObject.height = height;
        imageObject.ratio = ratio;
        renderImage();
        if (ratio != 1) {
            $(".pcimg-preview-footer .icon-resize").parent().removeClass("disable");
        }
    }
//设置图片样式
    function renderImage() {
        var endImage = this.imageObject;
        $("#src_image").css({
            maxWidth: "",
            maxHeight: "",
        })
        $("#src_image").css({
            maxWidth: endImage.width,
            maxHeight: endImage.height,
            width: endImage.width,
            height: endImage.height,
            left: endImage.left,
            top: endImage.top,
            transform: 'rotate(' + endImage.rotateDeg + 'deg)'
        });
    }

//上下张
    function viewUpDown(type) {
        var nowUrl = $("#src_image").attr("src"), sub;
        for (var i = 0; i < imgUrlArr.length; i++) {
            if (imgUrlArr[i].indexOf(nowUrl) != -1) {
                sub = i;
            }
        }
        var imgLength = imgUrlArr.length;
        if (sub > 0 && type == "prev") {
            hasLoad = false;
            imgUrlArr[sub - 1] && imgUrlArr[sub - 1] != "" ? imageOld(imgUrlArr[sub - 1]) : false;
        }
        if (sub < imgLength && type == "next") {
            hasLoad = false;
            imgUrlArr[sub + 1] && imgUrlArr[sub + 1] != "" ? imageOld(imgUrlArr[sub + 1]) : false;
        }
    }