var MyValid = new Object();

//根据身份证号码判断年龄
function getAgeByNumber(idcard) {
    var birthYear = idcard.substring(6, 10);
    var nowYear = new Date().getFullYear();
    if (nowYear - birthYear > 18) {
        return false;
    } else {
        return true;
    }
}

//判断是否一个合法的日期格式
MyValid.isDate = function(str){

    var reg = /^[0-9]{4}-[0-9]{2}-[0-9]{2}$/ig;

    if (reg.test(str)){

        var aryDate = str.split('-');
        var year = new Date().getFullYear();
        if (aryDate.length == 3 
            && (aryDate[0] > 1900 && aryDate[0]<=year)
            && (aryDate[1] > 0 && aryDate[1] <13)
            && (aryDate[2] > 0 && aryDate[1] < 32)
           ){

            return true ;
        }

    } 

    return false;  
}

//判断是否是一个email
MyValid.isEmail = function (str) {
    var reg = /^[0-9a-z]+([-\._][0-9a-z]+)*@[0-9a-z-]+(\.\w{2,4}){1,2}$/ig;
    return reg.test(str);
}
//判断是否是一个email
MyValid.isUserName = function (str) {
    var reg = /^[\u4E00-\u9FA50-9a-zA-Z]{3,20}$/ig;
    return reg.test(str);
}

//var pattern = /^[\u4E00-\u9FA5]{1,5}$/;

//判断是否是手机号码
MyValid.isMobile = function (str) {
    if (str && str.toString().length == 11 && isNaN(str) == false) {
        return true;
    } else {
        return false;
    }
}

//身份证号码
MyValid.isIDCard = function (str) {
    if ($.trim(str).length == 18) {
        return true;
    } else {
        return false;
    }
}

//是否是空白
MyValid.isBlank = function (str) {
    var result = str.replace(/(^\s*)|(\s*$)/g, "");
    return result == "";
}

//去空格
MyValid.trim = function (str) {
    var result = str.replace(/(^\s*)|(\s*$)/g, "");
    return result;
}

/**
 * [getAge 获取年龄]
 * @param  {[String]} birthdate [出生日期 两种形式：1、1993-01-01 2、18位身份证号]
 * @param  {[String]} start_ins [起保日期，非必填，默认当前日期，格式示例:2016-12-31]
 * @return {[Number]}           [年龄]
 */
MyValid.getAge = function (birthdate, start_ins) {
    //身份证转换日期510107197805070076
    if(birthdate != "" && !/-/.test(birthdate)){
        birthdate = birthdate.substr(6, 4) + "-" + birthdate.substr(10, 2) + '-' + birthdate.substr(12, 2);
    }
    start_ins = start_ins || MyValid.getStartDay(0);
    var user_year = birthdate.split('-')[0];
    var curr_year = start_ins.split('-')[0];
    var age       = curr_year - user_year;
    var s = start_ins.split('-')[1] + start_ins.split('-')[2];
    var u = birthdate.split('-')[1] + birthdate.split('-')[2];
    if (u > s) {
        age = age - 1;
    }
    return age;
}

//根据身份证获取出生日期
MyValid.getBirthdate = function(number) {
    var date = "";
    if (number != "" && number.length>8) {
        date = number.substr(6, 4) + "-" +number.substr(10, 2)+ "-" +number.substr(12, 2);
    }
    return date;
}

//车牌号判断
MyValid.isCarNumber = function (str) {
    var result = false;
    if (str.length == 7) {
        var express = /^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$/;
        result = express.test(str);
    }
    return result;
}

//获取起始日期：2017-01-01，默认明天
MyValid.getStartDay = function(days){
    days = Number(days)
    var d = new Date();
    if(days == 0){
        days = 0;
    }else{
        days = days || 1;
    }
    d.setDate(d.getDate() + days);

    var month = d.getMonth() + 1;
    var date = d.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;

    }
    if (date >= 0 && date <= 9) {
        date = "0" + date;
    }
    var start_ins  = d.getFullYear()+"-"+month+"-"+date;
    return start_ins;
}

//获取结束日期：2017-12-31，默认一年后明天
//options:json类型 days:天；months：月
//bool: 用于标识是否加减天
MyValid.getEndDay = function(){
    options = arguments[0] || {};
    bool = arguments[1] || false;
    if(typeof options == "boolean"){
        bool = arguments[0];
        options = arguments[1] || {};
    }
    options.days   = Number(options.days) || 365;
    options.months = Number(options.months) || 12;
    options.start  = options.start || MyValid.getStartDay();
    var d          = new Date(options.start);

    if (options.days == 365) {
        d.setMonth(d.getMonth() + options.months);
        //针对整数年年后进行修正几天
        if(typeof bool == "number"){
          d.setDate(d.getDate() + bool);
        }else if(!bool){
          d.setDate(d.getDate() - 1);
        }
    }else {
        d.setDate(d.getDate() + options.days);
    }
    var year  = d.getFullYear();
    var month = d.getMonth() + 1;
    var date  = d.getDate();

    if (month >= 1 && month <= 9) {
        month  = "0" + month;
    }
    if (date >= 0 && date <= 9) {
        date = "0" + date;
    }
    var end_ins  = year+"-"+month+"-"+date;
    return end_ins;
}

//银行卡号
MyValid.isBankCardId = function (str) {
    if (isNaN(str) == false && (MyValid.trim(str).length == 16 || MyValid.trim(str).length == 19)) {
        return true;
    } else {
        return false;
    }

}

//根据身份证获取性别
MyValid.getSex = function(number){
    var sexno,sex
    if(number.length==18){
        sexno=number.substring(16,17)
    }else if(number.length==15){
        sexno=number.substring(14,15)
    }else{
        alert("错误的身份证号码，请核对！")
        return false
    }
    var tempid=sexno%2;
    if(tempid==0){
        sex='F'
    }else{
        sex='M'
    }
    return sex
}