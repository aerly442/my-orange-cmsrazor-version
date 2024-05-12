$(document).ready(function () {
    


   $("#btnSubmit").click(function(){

    var content = $("#content1").val();
    if (content == "" || content =="输入留言内容"){

         $.cylater.alert({
             id: 'myLaterAlert',
             msg: "请输入留言内容"
         });
         return false;
     }

       var name = $("#name").val();
       if (name == "" || name == "姓名") {

           $.cylater.alert({
               id: 'myLaterAlert',
               msg: "请输入姓名"
           });
           return false;
       }

 
       var tel = $("#tel").val();
       if (MyValid.isMobile(tel) == false) {

           $.cylater.alert({
               id: 'myLaterAlert',
               msg: "请输入11位手机号码"
           });
           return false;
       }

       var email = $("#email").val();
       if (MyValid.isEmail(email) == false) {

           $.cylater.alert({
               id: 'myLaterAlert',
               msg: "请输入正确邮箱"
           });
           return false;
       }

       var address = $("#address").val();
       if (address == "" || address == "地址") {

           $.cylater.alert({
               id: 'myLaterAlert',
               msg: "请输入地址"
           });
           return false;
       }

       var json = {action:"1",content:content,name:name,tel:tel,email:email,address:address};

       $.cylater.loading({
           id: 'myLaterLoding',
           msg: '数据提交中，请稍候...'
       });

       $.ajax({
           url: '/index.php/question/save_data',
           data: json,
           type: 'post',
           cache: false,
           dataType: 'json',
           success: function (data) {

               $("#content1").val("");
               $("#name").val("");
               $("#tel").val("");
               $("#email").val("");
               $("#address").val("");
               

               var g_data = data;
               $.cylater.close({ id: 'myLaterLoding' });
               $.cylater.alert({
                   id: 'myLaterAlert',
                   msg: data.errorInfo,
                   callbackfun: function (data, type) {
                   }
               });
              
               off();


           },

           error: function (e) {

               console.log(e);
               $.cylater.close({ id: 'myLaterLoding' });

           }

       });


   });

});