$(document).ready(function () {

    $(".pagination>li>a").click(function (e) {
        //alert($(this).data)
        //$("$frmPage").submit();
        let pageNumber = this.dataset.pagenumber;
        $("#MyPageNumber").val(pageNumber);
        $("#MyActionType").val("split");
        $("#frmPage").submit();
    })

    $(".btn-upload").click(function () {

        let url = this.dataset.url;
        window.open(url);


    });

    $(".frmNews").submit(function () {


        var c =       UE.getEditor('myEditor').getContent();
        var content = UE.getEditor('myEditor').getPlainTxt();

        if (c == '' || content == "") {
            alert('请输入内容');
            return false;
        }
        else {

            $('#News_Content').val(c);
            return true;
        }
        return false;
    });

    //设置菜单也得默认选项

    let menuId = $("#Menu_ruler_Menuid").val();
    if (menuId) {

        let aryMenuId = eval(menuId);

        for (var i = 0; i < aryMenuId.length;i++) {

            let ctrlId = "#chbMenu" + aryMenuId[i].toString();
            $(ctrlId).attr("checked", true);

        }


    }

    ///修改用户菜单
    $(".frmMenuRulers").submit(
        function () {

        let aryMenu = document.getElementsByName("chbMenu");
        let aryResult = "";
        aryMenu.forEach(function (e) {

            if (e.checked) {
                aryResult += e.value + ",";
            }

        })

        aryResult = "[" + aryResult + "0]";
        $("#Menu_ruler_Menuid").val(aryResult);

        return true;



        }
    )

    $("#btnCreate_orange").click(function(){


        let tableName = $("#TableName").val();
        $.get("/Admin/Create_oranges/create?tableName="+tableName+"&aType=model", function(data){
            
            $("#ModelValue").val(data);

        });

        $.get("/Admin/Create_oranges/create?tableName="+tableName+"&aType=dto", function(data){
            
            $("#DtoValue").val(data);

        });

        $.get("/Admin/Create_oranges/create?tableName="+tableName+"&aType=html", function(data){
            
            $("#HtmlValue").val(data);

        });

        $.get("/Admin/Create_oranges/create?tableName="+tableName+"&aType=cs", function(data){
            
            $("#CsValue").val(data);

        });
  
         
         



    });

    $(".chbParent").click(function () {

        let id = this.value;
        let blnChecked = this.checked;
       
        let aryChb = $(".divChb" + id.toString() + " input[type='checkbox']");
        if (aryChb) {
            for (let i = 0; i < aryChb.length; i++) {
                aryChb[i].checked = blnChecked;
            }
        }
 


    });
});
