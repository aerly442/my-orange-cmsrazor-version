/**
 * Created by Administrator on 2015/8/23.
 */
var winwidth=window.innerWidth;
var winheight=window.innerHeight;
//╪сть
window.onload=function(){

    fm();


};

function on(){
    var fmid=document.getElementById("wyzx");

    fmid.style.display="block";
}
function off(){
    var fmid=document.getElementById("wyzx");
    fmid.style.display="none";
}

function fm(){
    var fmid=document.getElementById("wyzx");
    fmid.style.top=(innerHeight-400)/2+"px";
    fmid.style.left=(innerWidth-600)/2+"px";
}




