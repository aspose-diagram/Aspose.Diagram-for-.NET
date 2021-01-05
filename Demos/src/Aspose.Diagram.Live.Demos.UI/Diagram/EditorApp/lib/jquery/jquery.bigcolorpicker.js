(function ($) {
    var bigColorPicker = new function () {
        this.sideLength = 6; //六个区域的每个边长
        this.targetEl = {};
        var allColorArray = []; //整个颜色区域分为前两列，后面所有列分为6个块，计算出各个区域的数组后放入一个总的二维数组里
        var sideLength = 6;
        var selectHex = "";
        this.init = function () {
            sideLength = this.sideLength;
            allColorArray = new Array(sideLength * 3);
            //计算第一列的数组
            var mixColorArray = [];
            var blackWhiteGradientArray = gradientColor(new RGB(0, 0, 0), new RGB(255, 255, 255));
            for (var i = 0; i < blackWhiteGradientArray.length; i++) {
                mixColorArray[i] = blackWhiteGradientArray[i];
            }
            var baseArray = [new RGB(255, 0, 0), new RGB(0, 255, 0), new RGB(0, 0, 255), new RGB(255, 255, 0), new RGB(0, 255, 255), new RGB(255, 0, 255), new RGB(204, 255, 0), new RGB(153, 0, 255), new RGB(102, 255, 255), new RGB(51, 0, 0)];
            mixColorArray = mixColorArray.concat(baseArray.slice(0, sideLength))
            allColorArray[0] = mixColorArray;

            //计算第二列的数组
            var blackArray = new Array(sideLength * 2);
            for (var i = 0; i < blackArray.length; i++) {
                blackArray[i] = new RGB(0, 0, 0);
            }
            allColorArray[1] = blackArray;

            //计算六个区域的数组
            var cornerColorArray = new Array(); //六个元素，每个元素放6个区域的四角颜色二维数组
            cornerColorArray.push(generateBlockcornerColor(0), generateBlockcornerColor(51), generateBlockcornerColor(102), generateBlockcornerColor(153), generateBlockcornerColor(204), generateBlockcornerColor(255));
            var count = 0;
            var halfOfAllArray1 = [];
            var halfOfAllArray2 = [];
            for (var i = 0; i < cornerColorArray.length; i++) {
                var startArray = gradientColor(cornerColorArray[i][0][0], cornerColorArray[i][0][1])
                var endArray = gradientColor(cornerColorArray[i][1][0], cornerColorArray[i][1][1])
                for (var j = 0; j < sideLength; j++) {
                    if (i < 3) {
                        halfOfAllArray1[count] = gradientColor(startArray[j], endArray[j]);
                    } else {
                        halfOfAllArray2[count - sideLength * 3] = gradientColor(startArray[j], endArray[j]);

                    }
                    count++;
                }
            }
            for (var i = 0; i < halfOfAllArray1.length; i++) {
                allColorArray[i + 2] = halfOfAllArray1[i].concat(halfOfAllArray2[i]);
            }

            //将数组里所有的RGB颜色转换成Hex形式
            for (var i = 0; i < allColorArray.length; i++) {
                for (var j = 0; j < allColorArray[i].length; j++) {
                    allColorArray[i][j] = RGBToHex(allColorArray[i][j]);
                }
            }
        }
        /*
         * callback:可以是undefined（不传参数时）、字符串、函数
         * 		undefined：把选择的颜色设置到绑定bigColorpicker的元素的value上。
         * 		字符串：把选择的颜色设置到id为"字符串"的元素的value上。
         * 		函数：执行传入的函数以实现自定义的获取颜色后的动作。
         * engine:可以是undefined、p(或P)、l(或L)，
         * 		在bigColorpicker展现颜色选择区域小格时有两种实现方式：
         *     一、是一张背景图片，采用光标定位的方式获取颜色。p(或P)
         *     二、每个小格就是一个li，设置li的背景颜色。l(或L)
         *     实现方式的不同，效率有所差异，可以自己在使用时选择，默认是p(或P)。
         *     undefined（不传参数时）：使用默认p(或P)
         * sideLength:设置颜色区域的大小取值范围为2～10，默认为6,只有engine为L时才生效
         */
        this.showPicker = function (callback, engine, sideLength_) {
            var sl_ = parseInt(sideLength_, 10);
            if (engine == "L" && !isNaN(sl_) && sl_ >= 2 && sl_ <= 10) {
                bigColorPicker.sideLength = sl_;
            } else {
                bigColorPicker.sideLength = 6;
            }
            bigColorPicker.init();
            bigColorPicker.targetEl = this;
            $(bigColorPicker.targetEl).data("bigpickerCallback", callback);
            $(bigColorPicker.targetEl).data("bigpickerId", "bigpicker");

            if ($("#bigpicker").length <= 0) {
                $(document.body).append('<div id="bigpicker" class="bigpicker"><ul class="bigpicker-bgview-text" ><li><div id="bigBgshowDiv"></div></li><li><input id="bigHexColorText" size="7" maxlength="7" value="#000000" /></li></ul><div id="bigSections" class="bigpicker-sections-color"></div><div id="bigLayout" class="biglayout" ></div></div>');

            }
            $("#bigLayout").unbind("hover").unbind("click").hover(function () {
                $(this).show();
            }, function () {
                $(this).hide();
            }).click(function () {
                invokeCallBack(selectHex);
                $("#bigpicker").hide();
            });

            //颜色拾取器text输入框注册事件
            $("#bigHexColorText").unbind("keypress").unbind("keyup").unbind("focus").keypress(function () {
                var text = $.trim($(this).val());
                $(this).val(text.replace(/[^A-Fa-f0-9#]/g, ''));
                if (text.length <= 0) return;
                text = text.charAt(0) == '#' ? text : "#" + text;
                var countChar = 7 - text.length;
                if (countChar < 0) {
                    text = text.substring(0, 7);
                } else if (countChar > 0) {
                    for (var i = 0; i < countChar; i++) {
                        text += "0";
                    };
                }
                $("#bigBgshowDiv").css("backgroundColor", text);
            }).keyup(function () {
                var text = $.trim($(this).val());
                $(this).val(text.replace(/[^A-Fa-f0-9#]/g, ''));
            }).focus(function () {
                this.select();
            })


            //给传入的拾取颜色的元素绑定click事件，显示颜色拾取器
            $(this).unbind("click").bind("click", bigpickerShow);

            function bigpickerShow(event) {
                bigColorPicker.targetEl = event.currentTarget;
                var $this = $(bigColorPicker.targetEl);
                if ($this[0].childNodes[2] != null) {
                    $("#bigBgshowDiv").css("backgroundColor", rgb2hex($this[0].childNodes[2].style.backgroundColor));
                    $("#bigHexColorText").val(rgb2hex($this[0].childNodes[2].style.backgroundColor));
                }
                else {
                    $("#bigBgshowDiv").css("backgroundColor", rgb2hex($this[0].style.backgroundColor));
                    $("#bigHexColorText").val(rgb2hex($this[0].style.backgroundColor));
                }

                var pos = calculatePosition($this);
                $("#bigpicker").css({ "left": pos.left + "px", "top": pos.top + "px", 'z-index': 10087 }).fadeIn(300);

                var bigSectionsP = $("#bigSections").position();
                $("#bigLayout").css({ "left": bigSectionsP.left, "top": bigSectionsP.top }).show();
            }

            //rgb 转16进制
            function rgb2hex(rgb) {

                if (rgb.charAt(0) == '#')
                    return rgb;

                var ds = rgb.split(/\D+/);
                var decimal = Number(ds[1]) * 65536 + Number(ds[2]) * 256 + Number(ds[3]);
                return "#" + zero_fill_hex(decimal, 6);
            }

            function zero_fill_hex(num, digits) {
                var s = num.toString(16).toUpperCase();
                while (s.length < digits)
                    s = "0" + s;
                return s;
            }

            //单击页面选择器以外的地方时选择器隐藏
            $(document).bind('mousedown', function (event) {
                if (!($(event.target).parents().addBack().is('#bigpicker'))) {
                    $("#bigpicker").hide();
                }
            })

            if (engine != undefined) {
                try {
                    engine = engine.toUpperCase();
                } catch (e) {
                    engine = "P";
                }
            }

            if (engine == "L") {
                $("#bigSections").unbind("mousemove").unbind("mouseout").unbind("click").removeClass("bigpicker-bgimage");;
                generateBgImage();
            } else {
                //预加载图片
                var bgmage = new Image();
                bgmage.src = "../images/big_bgcolor.jpg";

                //初始化为默认样式
                $("#bigSections").height(132).width(220).addClass("bigpicker-bgimage").empty();
                $("#bigpicker").width(227).height(163);
                //鼠标移动时计算光标的区间
                var xSections = getSections(sideLength * 3 + 2);
                var ySections = getSections(sideLength * 3);
                $("#bigSections").unbind("mousemove").unbind("mouseout").unbind("click").mousemove(function (event) {
                    var $this = $(this);
                    var cursorXPos = event.pageX - $this.offset().left;
                    var cursorYPos = event.pageY - $this.offset().top;
                    var xi = 0;
                    var yi = 0;
                    for (var i = 0; i < (sideLength * 3 + 2); i++) {
                        if (cursorXPos >= xSections[i][0] && cursorXPos <= xSections[i][1]) {
                            xi = i;
                            break;
                        }
                    }
                    for (var i = 0; i < (sideLength * 3); i++) {
                        if (cursorYPos >= ySections[i][0] && cursorYPos <= ySections[i][1]) {
                            yi = i;
                            break;
                        }
                    }
                    $("#bigLayout").css({ "left": $this.position().left + xi * 11, "top": $this.position().top + yi * 11 }).show();
                    var hex = allColorArray[xi][yi];
                    $("#bigBgshowDiv").css("backgroundColor", hex);
                    $("#bigHexColorText").val(hex);
                }).mouseout(function () {
                    $("#bigLayout").hide();
                });
            }

            /*
             */
        }

        this.hidePicker = function () {
            var id = $(bigColorPicker.targetEl).data("bigpickerId");
            $("#" + id).hide();
        }

        this.movePicker = function () {
            var $this = $(bigColorPicker.targetEl);
            var pos = calculatePosition($this);
            $("#bigpicker").css({ "left": pos.left + "px", "top": pos.top + "px" });
            $("#bigLayout").hide();
        }

        //计算出拾取器层的left,top坐标
        function calculatePosition($el) {
            var offset = $el.offset();
            var compatMode = document.compatMode == 'CSS1Compat';
            var w = compatMode ? document.documentElement.clientWidth : document.body.clientWidth;
            var h = compatMode ? document.documentElement.clientHeight : document.body.clientHeight;
            var pos = { left: offset.left, top: offset.top + $el.height() + 7 };
            if (offset.left + 227 > w) {
                pos.left = offset.left - 227 - 7;
                if (pos.left < 0) {
                    pos.left = 0;
                }
            }
            if (offset.top + $el.height() + 7 + 163 > h) {
                pos.top = offset.top - 163 - 7;
                if (pos.top < 0) {
                    pos.top = 0;
                }
            }
            return pos;
        }

        function invokeCallBack(hex) {
            var callback_ = $(bigColorPicker.targetEl).data("bigpickerCallback");
            if ($.isFunction(callback_)) {
                callback_(bigColorPicker.targetEl, hex);
            } else if (callback_ == undefined || callback_ == "") {
                $(bigColorPicker.targetEl).val(hex);
            } else {
                if (callback_.charAt(0) != "#") {
                    callback_ = "#" + callback_;
                }
                $(callback_).val(hex);
            }
        }

        //创建小区域的四个角的颜色二维数组
        function generateBlockcornerColor(r) {
            var a = new Array(2);
            a[0] = [new RGB(r, 0, 0), new RGB(r, 255, 0)];
            a[1] = [new RGB(r, 0, 255), new RGB(r, 255, 255)];
            return a;
        }

        //两个颜色的渐变颜色数组
        function gradientColor(startColor, endColor) {
            var gradientArray = [];
            gradientArray[0] = startColor;
            gradientArray[sideLength - 1] = endColor;
            var averageR = Math.round((endColor.r - startColor.r) / sideLength);
            var averageG = Math.round((endColor.g - startColor.g) / sideLength);
            var averageB = Math.round((endColor.b - startColor.b) / sideLength);
            for (var i = 1; i < sideLength - 1; i++) {
                gradientArray[i] = new RGB(startColor.r + i * averageR, startColor.g + i * averageG, startColor.b + i * averageB);
            }
            return gradientArray;
        }
        /*获取一个二维区间数组比如[0,11],[12,23],[24,37]..
         * sl:区间的长度
         */
        function getSections(sl) {
            var sections = new Array(sl);
            var initData = 0;
            for (var i = 0; i < sl; i++) {
                var temp = initData + 1;
                initData += 11;
                sections[i] = [temp, initData];
            }
            return sections;
        }

        function RGBToHex(rgb) {
            var hex = "#";
            for (c in rgb) {
                var h = rgb[c].toString(16).toUpperCase();
                if (h.length == 1) {
                    hex += "0" + h;
                } else {
                    hex += h;
                }
            }
            return hex;
        }

        //RGB对象函数，用于创建一个RGB颜色对象
        function RGB(r, g, b) {
            this.r = Math.max(Math.min(r, 255), 0);
            this.g = Math.max(Math.min(g, 255), 0);
            this.b = Math.max(Math.min(b, 255), 0);
        }


        //生成背景颜色
        function generateBgImage() {
            var ulArray = new Array();
            for (var i = 0; i < sideLength * 3 + 2; i++) {
                ulArray.push("<ul>");
                for (var j = 0; j < sideLength * 2; j++) {
                    ulArray.push("<li data-color='" + allColorArray[i][j] + "' style='background-color: " + allColorArray[i][j] + ";' ></li>");
                }
                ulArray.push("</ul>");
            }
            $("#bigSections").html(ulArray.join(""));
            var minBigpickerHeight = 90;
            var minBigpickerWidth = 129;
            var minSectionsHeight = minBigpickerHeight - 29;
            var minSectionsWidth = minBigpickerWidth - 5;

            var defaultSectionsWidth = (sideLength * 3 + 2) * 11;

            if (defaultSectionsWidth < minSectionsWidth) {
                $("#bigSections li,#bigLayout").width(minSectionsWidth / (sideLength * 3 + 2) - 1)
                    .height(minSectionsHeight / (sideLength * 2) - 1);
                $("#bigpicker").height(minBigpickerHeight).width(minBigpickerWidth);
                $("#bigSections").height(minSectionsHeight).width(minSectionsWidth);

            } else {
                $("#bigSections").width(defaultSectionsWidth)
                    .height(sideLength * 2 * 11);
                $("#bigpicker").width(defaultSectionsWidth + 5)
                    .height(sideLength * 2 * 11 + 29);

            }
            $("#bigSections li").hover(function () {
                var $this = $(this);
                $("#bigLayout").css({ "left": $this.position().left, "top": $this.position().top }).show();

                var cor = $this.attr("data-color");
                $("#bigBgshowDiv").css("backgroundColor", cor);
                $("#bigHexColorText").val(cor);
                selectHex = cor;
                //invokeCallBack(cor);
            }, function () {
                $("#bigLayout").hide();
            });
        }

    };

    $.fn.bigColorpicker = bigColorPicker.showPicker;
    $.fn.bigColorpickerMove = bigColorPicker.movePicker; //使用在拖拽的浮层上，在拖拽时拾取器随浮层移动位置
    $.fn.bigColorpickerHide = bigColorPicker.hidePicker; //对应一些特定的应用需要手动隐藏拾取器时使用。比如拖拽浮层时隐藏拾取器
})(jQuery)