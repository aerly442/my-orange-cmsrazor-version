$(document).ready(function () {
    $("article").fadeIn(0);

    var swiper = new Swiper('.swiper-container', {
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',
        width: 733,
        heigth: 424,
        hashnav: true,
        autoplay: 5000,
        loop: true
    });

    var swiper1 = new Swiper('.swiper-container1', {
        heigth: 300,
        autoplay: 5000,
        loop: true
    });

  
    $(".pannel-rank .rank-tit a").hover(function () {
        $(".pannel-rank .rank-tit a").removeClass('current');
        $(this).addClass('current');
        var a = $(this).text();
        if (a == '鏃ユ帓琛�') {
            $(".pannel-rank #day-list").show();
            $(".pannel-rank #week-list").hide();
        }
        if (a == '鍛ㄦ帓琛�') {
            $(".pannel-rank #day-list").hide();
            $(".pannel-rank #week-list").show();
        }
    })


    $(".menu-button").click(function () {
        if ($(".nav-overlay").css("display") == 'none') {
            $(".nav-overlay").css("display", "block");
        } else {
            $(".nav-overlay").css("display", "none");
        }
        $(".menu-mini-nav").slideToggle();
    })

    // 
    $('#shang').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 500)
    });
    $("#xia").click(function () {
        $('body,html').animate({
            scrollTop: $(".footer").offset().top
        }, 500)

    });
    $('#go_top').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 500)
    });
    /* 首页数据加载-start */
    function GetSearchString() {

        let result = "";
        let dataType = $("#DataType").val();
        if (dataType && dataType == "listall") {

            let code = $("#Code").val();
            let tag = $("#Tag").val();
            let keyword = $("#Keyword").val();

            if (code && code != "") {
                result += "code=" + code ;
            }
            if (tag && tag != "") {
                result += "&tag=" + tag ;
            }

            if (keyword && keyword != "") {
                result += "&keyword=" + keyword ;
            }

            result = "&" + result;

 

        }

        return result;
   


    }
    var pageIndex = 0;
    function GetIndexData() {

        $(".ajax-more-btn").text("Loading...").addClass('loading');
        var cid = $("#Code").val();
        var limit_start = pageIndex + 1;
        let otherSearchString = GetSearchString();
        $.ajax({
            type: "GET",
            url: "/Front/GetIndex?p=" + limit_start + otherSearchString ,// + "&code=" + cid, //
            success: function (data) { //
                if (data != '-1') {
                    $(".ajax-more-btn").text("数据加载中").removeClass('loading');
                    $('.news_box').append(data);
                    $("article").fadeIn(800);
                    pageIndex = limit_start;
                } else {
                    $(".ajax-more-btn").addClass("disabled");
                    $(".ajax-more-btn").text("没有数据了");
                }
            }
        });

    }
    $(".ajax-more-btn").on('click', function () {
        if (!$(".ajax-more-btn").hasClass('disabled')) {

            GetIndexData(pageIndex);
        }
    });

    let indexContent = $(".news_box").html();
    if (indexContent == "") {

        GetIndexData();
    }

    /* 首页数据加载-end */

    /*listall数据*/



    $(".article-nav-list a").on('click', function () {
        $(".article-nav-list a").removeClass('active');
        $(this).addClass('active');
        var cid = $(this).attr("cid");
        var box = '#box_' + cid;
        $(".news_box").hide();
        $(box).fadeIn(800);

        if ($(box).find('article').length > 0) {
            $(".page-nav").show();
        } else {
            $(".page-nav").hide();
        }
    })

    /*搜索*/

    //设置搜索款默认值

    let url = location.href;
    if (url.indexOf("keyword") > 0) {
        let aryUrl = url.split("?");
        aryUrl.forEach(function (w) {

            if (w.indexOf("keyword") >= 0) {

                let aryParameter = w.split("=");
                if (aryParameter.length > 1) {
                    let keyword = aryParameter[1];
                    keyword = unescape(keyword);
                    $("#q").val(keyword);
                }
            }

        })
  
    }

    $('.search-t').bind('keypress', function (event) {
        if (event.keyCode == "13") {
            $(".search-btn").click();
        }
    })

    $(".search-btn").click(function () {

        let keyword = $(".search-t").val();
        if (keyword == "" || keyword.length<2) {
            alert("请输入要搜索的名称,至少2个字")
        }
        else {
            pageIndex = 0;
            keyword = keyword.length > 20 ? keyword.substring(0, 20) : keyword;
            keyword = escape(keyword);           
            location.href = "/article/listall?keyword=" + keyword;

        }


    });

});
