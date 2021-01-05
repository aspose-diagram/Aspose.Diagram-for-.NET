jQuery.bootstrapLoading = {
    start: function(options) {
        var defaults = {
            opacity: 0.45,
            //loading页面透明度
            backgroundColor: "#4e4e4e",
            //loading页面背景色
            borderColor: "#4e4e4e",
            //提示边框颜色
            borderWidth: 1,
            //提示边框宽度
            borderStyle: "solid",
            //提示边框样式
            loadingTips: "",
            //提示文本
            TipsColor: "#fff",
            //提示颜色
            delayTime: 1000,
            //页面加载完成后，加载页面渐出速度
            zindex: 9999,
            //loading页面层次
            sleep: 0
                //设置挂起,等于0时则无需挂起

        }
        var options = $.extend(defaults, options);

        //获取页面宽高
        var _PageHeight = document.documentElement.clientHeight,
            _PageWidth = document.documentElement.clientWidth;


        var _LoadingHtml = '<div id="loadingPage" style="position:fixed;left:0;top:0;_position: absolute;width:100%;height:' + _PageHeight + 'px;background:' + options.backgroundColor + ';opacity:' + options.opacity +
            ';filter:alpha(opacity=' + options.opacity * 100 + ');z-index:' + options.zindex + ';">' +
            '<div id="loadingTips" style="left: 50%;top:32%;position: absolute;text-align:center"><img style="width:20%;" src="/Diagram/EditorApp/images/loading.gif"><span></span></div>' +
            '</div>';
        //呈现loading效果
        $("body").append(_LoadingHtml);


        //监听页面加载状态
        document.onreadystatechange = PageLoaded;

        //当页面加载完成后执行
        function PageLoaded() {
            if (document.readyState == "complete") {
                var loadingMask = $('#loadingPage');

                setTimeout(function() {
                        loadingMask.animate({
                                "opacity": 0
                            },
                            options.delayTime,
                            function() {
                                $(this).hide();

                            });

                    },
                    options.sleep);

            }
        }
    },
    end: function() {
        $("#loadingPage").remove();
    }
}