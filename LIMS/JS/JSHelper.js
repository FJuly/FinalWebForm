function AjaxRequest(method, url, data, callback) {
    this.method = method;
    this.url = url;
    this.data = data;
    this.callback = callback;
    this.send = function () {
        //0.1.创建异步对象
        var xhr = new XMLHttpRequest();
        //0.2.设置异步对象请求参数
        this.url = (this.data.length > 0 && this.method == "get") ? this.url + "?" + this.data : this.url;
        xhr.open(this.method, this.url, true);

        //0.3.根据请求方式 设置 相应的 请求头状态航
        if (this.method == "get") {
            xhr.setRequestHeader("If-Modified-Since", 0);
        } else {
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        }
        //0.4.设置回调函数
        xhr.onreadystatechange = this.bind(this, function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                this.callback(xhr.responseText);
            }
        });
        //0.5.发送请求报文
        if (this.method == "get") {
            xhr.send(null);
        } else {
            xhr.send(this.data);
        }
    };
}

AjaxRequest.prototype = {
    bind: function (object, fun) { return function () { return fun.apply(object, arguments); } }
}


function ChangeDateFormat(jsondate)
{
    jsondate = jsondate.replace("/Date(", "").replace(")/", "");
    if (jsondate.indexOf("+") > 0)
    {
        jsondate = jsondate.substring(0, jsondate.indexOf("+"));
    }
    else if (jsondate.indexOf("-") > 0)
    {
        jsondate = jsondate.substring(0, jsondate.indexOf("-"));
    }
    var date = new Date(parseInt(jsondate, 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    return date.getFullYear() + "年" + month + "月" + currentDate + "日";
}