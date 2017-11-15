//(function ($) {
//  'use strict';
//  $(function () {

//    var $fullText = $('.admin-fullText');
//    $('#admin-fullscreen').on('click', function() {
//      $.AMUI.fullscreen.toggle();
//    });

//    $(document).on($.AMUI.fullscreen.raw.fullscreenchange, function() {
//      $fullText.text($.AMUI.fullscreen.isFullscreen ? '退出全屏' : '开启全屏');
//    });
//  });
//})(jQuery);

Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
        RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}
function ConvertJsonTime(a) {
    var time = a.toString().substring(0, 10) + " " + a.substring(11, 19);
    return time;
}
function ConvertTimeSpan(a) {
    if (a == null || a == undefined || a == "") {
        return "";
    }
    else if (a.toString().substring(6, 7) == "-") {
        return "";
    }
    else {
        var timespan = a.toString().substring(6, 19);
        var newDate = new Date(parseInt(timespan));
        //newDate.setTime(timespan * 1000);
        return newDate.format('yyyy-MM-dd');
    }

}
function ConvertTimeSpan2(a) {
    if (a == null || a == undefined || a == "") {
        return "";
    }
    else if (a.toString().substring(6, 7) == "-") {
        return "";
    }
    else {
        var timespan = a.toString().substring(6, 19);
        var newDate = new Date(parseInt(timespan));
        //newDate.setTime(timespan * 1000);
        return newDate.format('yyyy-MM-dd hh:mm:ss');
    }

}
//function getNowFormatDate() {
//    var date = new Date();
//    var seperator1 = "-";
//    var seperator2 = ":";
//    var month = date.getMonth() + 1;
//    var strDate = date.getDate();
//    if (month >= 1 && month <= 9) {
//        month = "0" + month;
//    }
//    if (strDate >= 0 && strDate <= 9) {
//        strDate = "0" + strDate;
//    }
//    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
//            + " " + date.getHours() + seperator2 + date.getMinutes()
//            + seperator2 + date.getSeconds();
//    return currentdate;
//}
//获取当前时间
function getNowFormatDate() {
    var date = new Date();
    return date.format('yyyy-MM-dd hh:mm:ss');
}
/*1.用浏览器内部转换器实现html转码*/
function htmlEncode(html) {
    //1.首先动态创建一个容器标签元素，如DIV
    var temp = document.createElement("div");
    //2.然后将要转换的字符串设置为这个元素的innerText(ie支持)或者textContent(火狐，google支持)
    (temp.textContent != undefined) ? (temp.textContent = html) : (temp.innerText = html);
    //3.最后返回这个元素的innerHTML，即得到经过HTML编码转换的字符串了
    var output = temp.innerHTML;
    temp = null;
    return output;
}
/*2.用浏览器内部转换器实现html解码*/
function htmlDecode(text) {
    //1.首先动态创建一个容器标签元素，如DIV
    var temp = document.createElement("div");
    //2.然后将要转换的字符串设置为这个元素的innerHTML(ie，火狐，google都支持)
    temp.innerHTML = text;
    //3.最后返回这个元素的innerText(ie支持)或者textContent(火狐，google支持)，即得到经过HTML解码的字符串了。
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}
