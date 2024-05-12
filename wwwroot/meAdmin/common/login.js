$(document).ready(function () {

    $(".login-form").submit(function () {

        let userName = $("#username").val();
        let password = $("#password").val();

        if (userName == "" || password == "") {
            $("#divLoginError").show();
            return false;
        }
        else {
            return true;
        }


    });


});