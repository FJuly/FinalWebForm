var pageIndex = 1;

function makePageBar($container, count) {
    $container.append("共   " + count + "  条记录      ");
    $container.append("[<a href = \"#\" onclick = \"loadData(1)\">首页</a>]  ");
    $container.append("[<a href = \"#\" onclick = \"loadData(" + Math.ceil(count / 10) + ")\">尾页</a>]    ");
    $container.append("跳转到第");
    $container.append("<select  id=\"selectPageBar\" onChange = \"loadData(this.options[this.selectedIndex].value)\"  value='1'></select>");

    var sel = document.getElementById("selectPageBar");
    for (var i = 0; i < Math.ceil(count / 10) ; i++) {
        sel.options[sel.length] = new Option(i + 1, i + 1);
    }
    $container.append("页");
};

function loadData(pi) {
    pageIndex = pi;
    var xhrRequest = new AjaxRequest("get", "GetInternStudyTask.ashx?pi=" + pi, [], function (returnData) {
        //alert(returnData);
        var obj = eval(returnData);
        //alert(obj);
        makeTable(obj);
    })
    xhrRequest.send();
}

//由JSON数组和tasktype绘制数据表格
function makeTable(data) {
    var tb = document.getElementById("tbTask");
    var $tb = $("#tbTask tr:not(:first)");
    //alert(data[0].TaskId);
    $tb.remove();
    for (var i = 0; i < data.length ; i++) {
        var row = tb.insertRow(-1);
        var cell1 = row.insertCell(-1);
        cell1.innerHTML = "<a href=\"#\" title =\"点击查看详情\"  onclick = \"showDetail('" + data[i].TaskId + "')\" >" + data[i].TaskName + "</a>";
        var cell2 = row.insertCell(-1);
        cell2.innerHTML = taskTypeIdToTypeName(data[i].TaskTypeId);
        var cell3 = row.insertCell(-1);
        cell3.innerHTML = ChangeDateFormat(data[i].TaskBegTime);
        var cell4 = row.insertCell(-1);
        cell4.innerHTML = ChangeDateFormat(data[i].TaskEndTime);

        var cell5 = row.insertCell(-1);
        cell5.innerHTML = data[i].TaskContent.trim().substr(0,12);
        var cell6 = row.insertCell(-1);
        if (data[i].TaskTypeId == 10001) {
            cell6.innerHTML = "<a href=\"#\" title =\"点击评价任务\" onclick = evaluateTaskById(" + data[i].TaskId + ")>评价<a>";
        } else {
            cell6.innerHTML = "<span style=\'color:#787878\'>不评</span>";
        }
    }
};

function showDetail(taskId) {
    location.href = "TaskEvaluateDetail.aspx?taskId=" + taskId;
};

function evaluateTaskById(taskId) {
    location.href = "TaskEvaluateDetail.aspx?taskId=" + taskId;
};

function taskTypeIdToTypeName(taskTypeId) {
    if (taskTypeId == 10001) {
        return "学习任务";
    } else if (taskTypeId == 10002) {
        return "开发任务";
    } else if (taskTypeId == 10003) {
        return "项目任务";
    } else if (taskTypeId == 10004) {
        return "学生讲座";
    }
};