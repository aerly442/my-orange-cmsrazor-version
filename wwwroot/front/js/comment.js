$(document).ready(function () {



    function loadNewsComment(){

            //** 显示评论 */
        let newsId = $("#txtNewsId").val();
        $.get("/Article/Comment?id="+newsId, function(data){
                
            $("#cmt-content-list").html(data);

        });

    }

    loadNewsComment();

    $("#btnAddComment").click(function(){

        //
        let userId  = $("#txtUserId").val();
        let content = $("#txtComment").val();
        let newsId  = $("#txtNewsId").val();
        let data = "newsId="+newsId+"&userId="+userId+"&content="+content;
        $.ajax({
           method: "post",
           url: "/Article/Comment",
           data: data,
           success: function (data) {

            $("#txtComment").val("");
            $("#cmt-content-list").html(data);
            //loadNewsComment();

           },
           error: function(err) {
            console.log("失败了: " + err);
           }
        });
        


    });
});
