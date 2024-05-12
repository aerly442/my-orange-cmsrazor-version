$(document).ready(function () {

    function createPayOrder(newsId) {

        $("#alinkPay").text("支付二维码生成中....");
        $.ajax({
            type: "GET",
            url: "/index.php/order/submit/" + newsId, //
            success: function(data) {
                var j = JSON.parse(data);
                if (j.code == "1") {
                    showPayDlg(j.pay_url,j.reallyPrice);
    
                } else {
                    alert(j.msg);
                }
            }
        });
    
    
    }


    function checkSubscribeCode(newsId){

        var code = $("#txtCode").val();
        if (code ==""){
            alert("请输入提取码");
        }
        else{
    
            location.href = "/index.php/article/show/"+newsId+".html?code="+code;
        }
     
    }

    function addOrder(newsId,userId){
        $.get("/FrontUser/createorder?newsId="+newsId+"&userId="+userId, function(data){
              
            alert(data);

        });

    }

    function showSubscribeDlg(newsId,productPrice) {

        let btnInfo = $("#btnPayContent").html();
        $("#btnPayContent").html("正在创建订单，请稍后 ...");
        $.get("/FrontUser/checklogin", function(data){
            
            var u = JSON.parse(data);
            if (u!=null && u.userId>0){

                addOrder(newsId,u.userId);

                var pay_qrcode_url    = "http://www.gfrjxz.com/upload/images/ecd5016451be27164ec8ff8a12ce0bfa.png";
                var price             = '<b style="color:red"> ' +(productPrice / 100).toFixed(2)+" 元</b> ";
                var qrcode_url        = pay_qrcode_url;
                var tips              ="提示：请使用微信扫描以下二维码支付:"+price;
                var code_html         = "";
                var tip_html          = '<div align="center"><img width="200px" height="200px"   src="' + qrcode_url + '"/>'+code_html+'</div>';
                roar(tips,tip_html,{
                    cancel: false,
                    confirm: true,
                    confirmText: '关闭',
                    confirmCallBack: function(event) {
                        $("#btnPayContent").html(btnInfo);
                       //location.href = "/FrontUser/login?returnUrl=/article/show?id="+newsId;
                    }    
    
                })

            }
            else{ //没登录

                roar("提示","<h3>您还没有登录，请先登录</h3>",{
                    cancel: false,
                    confirm: true,
                    confirmText: '确定',
                    confirmCallBack: function(event) {
                       $("#btnPayContent").html(btnInfo);
                       location.href = "/FrontUser/login?returnUrl=/article/show?id="+newsId;
                    }    
    
                })

            }

    
        });
    
        /* 
        var wechat_qrcode_url ="http://www.gfrjxz.com/upload/image/20220824/1661313109242268.jpg";
        var pay_qrcode_url    = "http://www.gfrjxz.com/upload/images/ecd5016451be27164ec8ff8a12ce0bfa.png";
        var price             = '<b style="color:red"> ' +(productPrice / 100).toFixed(2)+" 元</b> ";
        var qrcode_url        = productPrice<=1?wechat_qrcode_url:pay_qrcode_url;
        var tips              = productPrice<=1?"提示：请使用微信扫描以下二维码关注公众号获取提取码":"提示：请使用微信扫描以下二维码添加联系人支付"+price+"取提取码";
        var code_html         = '<p style="color:red">提取码：</p> \
        <p><input style="border:1px solid " type="text" id="txtCode"></p> \
        <p> <a href="javascript:checkSubscribeCode('+newsId+');" class="btn btn-success "><b>确定</b></a></p>';
        var tip_html = '<div align="center"><img width="200px"   src="' + qrcode_url + '"/>'+code_html+'</div>';
        roar(tips, tip_html, {
            // shows cancel button
            cancel: false,
            // cancel text
            cancelText: '取消',
            // cancel callback
            cancelCallBack: function(event) {
                console.log('options.cancelCallBack');
            },
    
            // shows confirm button
            confirm: true,
    
            // confirm text
            confirmText: '关闭',
    
            // confirm callback
            confirmCallBack: function(event) {
                console.log('options.confirmCallBack');
            }
    
        });
        */
    
    }
    
    function showPayDlg(pay_qrcode_url,price) {
    
        var tip_html = '<div align="center"><p style="color:red">价格：'+price+'</p><img width="200px" height="200px"  src="' + pay_qrcode_url + '"/></div>';
        roar('提示请使用支付宝扫描以下二维码支付', tip_html, {
            // shows cancel button
            cancel: false,
            // cancel text
            cancelText: '取消',
            // cancel callback
            cancelCallBack: function(event) {
                console.log('options.cancelCallBack');
            },
    
            // shows confirm button
            confirm: true,
    
            // confirm text
            confirmText: '关闭',
    
            // confirm callback
            confirmCallBack: function(event) {
                console.log('options.confirmCallBack');
            }
    
        });
    
    }


    $("#btnPayContent,#btnPayResource").click(function(){

        let id    = $("#txtNewsId").val();
        let price = $("#txtNewsPrice").val();
        showSubscribeDlg(id,price); 

    });



});





