
$(document).ready(function () {


    $("#imgSearch").click(function () {

        var clintPath = $("#clientPath").val();
        var searchKey = $("#txtSearch").val();

        if (searchKey != "") {

            window.location.href = clintPath + "/Urun/Arama/" + searchKey;
        }
        else {

            if (clintPath.search("tr") > 1) {
                alert("Lütfen arama degeri giriniz");
            }
            else if (clintPath.search("en") > 1) {
                alert("Please enter the search value");
            }
        }

    })


    if ($('#lofslidecontent45').length) {

        var buttons = { previous: $('#lofslidecontent45 .lof-previous'),
            next: $('#lofslidecontent45 .lof-next')
        };

        $obj = $('#lofslidecontent45').lofJSidernews({ interval: 4000,
            easing: 'easeInOutQuad',
            duration: 600,
            auto: true,
            maxItemDisplay: 5,
            startItem: 0,
            navPosition: 'horizontal', // horizontal
            navigatorHeight: 15,
            navigatorWidth: 25,
            mainWidth: 862,
            buttons: buttons
        });

    }


    //    var renk = "#333";
    //    var okrenk = "#f11f2a";

    $(".urunList li").hover
		(
			function () {

			    //	renk = $(this).children("a:first").css("color");
			    //	okrenk = $(this).children("span:first").css("color");

			    $(this).children("a:first").css("color", "#fff");
			    $(this).children("span:first").css("color", "#fff");
			},
			function () {

			    $(this).children("a:first").css("color", "#333");
			    $(this).children("span:first").css("color", "#f11f2a");
			}
		)

    checkActive();
    ProductMenuActive();


    $(".close").click(
			function () {
			    $(this).parent().fadeTo(400, 0, function () { // Links with the class "close" will close parent
			        $(this).slideUp(400);
			    });
			    return false;
			}
		);
})

/* ================================================================ Ürün Menu Aktif Sitil Seçimi=================================================================== */
function ProductMenuActive() {

    var a = $(".urunList li a");
    var loc = window.location.href;


    for (var i = 0; i < a.length; i++) {
        if (a[i].href == loc) {

            $(a[i]).parent().css("background-color", "#5779b0");
            $(a[i]).css("color", "#fff");
            $(a[i]).prev().css("color", "#fff");

        }
    }
}
/* ================================================================ Ana Menu Aktif Sitil Seçimi=================================================================== */
function checkActive() {
    var a = $("#ustMenu ul li a");
    if (window.location.href.substr(location.href.length - 1, 1) == '/') {        var loc = window.location.href + 'tr/index';    }    else {        var loc = window.location.href;    }
    for (var i = 0; i < a.length; i++) {
        if (a[i].href == loc) {
            $(a[i]).css("color", "#fff").css("background-color", "#5779b0"); ;
        }
    }
}


/* ================================================================ 
Slideto
=================================================================== */
(function ($) {
    $.fn.slideto = function (options) {
        var defaults = {
            slide_duration: "slow",
            highlight_duration: 3000,
            highlight: true,
            highlight_color: "#FFFF99"
        };
        var options = $.extend(defaults, options);
        return this.each(function () {
            var callback = false;
            obj = $(this);
            $('html,body').animate({ scrollTop: obj.offset().top }, options.slide_duration, function () {
                if (callback == false) {
                    if (options.highlight && $.ui.version) {
                        obj.effect("highlight", { 'color': options.highlight_color }, options.highlight_duration);
                    }
                    callback = true;
                }
            });
        });
    };
})(jQuery);


/* ================================================================ 
 Query String
=================================================================== */
function getQuerystring(key, default_) {
    if (default_ == null) default_ = "";
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
    var qs = regex.exec(window.location.href);
    if (qs == null)
        return default_;
    else
        return qs[1];
}
