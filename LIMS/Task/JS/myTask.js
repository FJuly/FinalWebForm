/// <reference path="../Task/TaskDetail.aspx" />
function makePageBar($container, count,type) {
    $container.append("共   " + count + "  条记录      ");
    $container.append("[<a href = \"#\" onclick = \"loadData(1,"+type+")\">首页</a>]  ");
    $container.append("[<a href = \"#\" onclick = \"loadData(" + Math.ceil(count / 10) + ","+type+")\">尾页</a>]    ");
    $container.append("跳转到第");
    $container.append("<select  id=\"select"+type+"\" onChange = \"loadData(this.options[this.selectedIndex].value,"+type+")\" value='1'></select>");
    var sel = document.getElementById("select"+type);
    for (var i = 0; i < Math.ceil(count / 10) ; i++)
    {
        sel.options[sel.length] = new Option(i + 1, i + 1);
    }
    $container.append("页");
};

function loadData(pi,type)
{
    var xhrRequest = new AjaxRequest("get", "GetTaskList.ashx?pi="+pi+"&taskTypeId="+type, [], function (returnData) {
        //alert(returnData);
        var obj = eval(returnData);
        //$("#taskType" + type).hide("slow", "linear");

        makeTable(obj, type);
        //$("#taskType" + type).show("slow", "linear");
    })
    xhrRequest.send();
}

//由JSON数组和tasktype绘制数据表格
function makeTable(data,type) {
    var tb = document.getElementById("tb" + type);
    var $tb = $("#tb" + type + " tr:not(:first)");
    $tb.remove();
    if (type == 10001)
    {
        //学习任务
        for (var i = 0; i < data.length ; i++) {
            var row = tb.insertRow(-1);
            var cell1 = row.insertCell(-1);
            cell1.innerHTML = "<a href=\"#\" title =\"点击查看详情\"  onclick = \"showDetail('" + data[i].TaskId + "')\" >" + data[i].TaskName + "</a>";
            var cell2 = row.insertCell(-1);
            cell2.innerHTML = ChangeDateFormat(data[i].TaskBegTime);
            var cell3 = row.insertCell(-1);
            cell3.innerHTML = ChangeDateFormat(data[i].TaskEndTime);
            var cell4 = row.insertCell(-1);
            if (data[i].TaskGrade == '') {
                cell4.innerHTML = "待评价";
            } else {
                cell4.innerHTML = data[i].TaskGrade;
            }
            
            var cell5 = row.insertCell(-1);
            cell5.innerHTML = data[i].TaskSender;
            var cell6 = row.insertCell(-1);
            if (data[i].IsComplete == false)
            {
                cell6.innerHTML = "<a href=\"#\" title =\"点击确认完成\" onclick = confirmComplete(" + data[i].TaskId + ",this)>确认完成<a>";
            } else
            {
                cell6.innerHTML = "已完成";
            }
            
        }
    } else if (type == 10003) {
        for (var i = 0; i < data.length ; i++) {
            var row = tb.insertRow(-1);
            //标题
            var cell1 = row.insertCell(-1);
            cell1.innerHTML = "<a href=\"#\"  onclick = \"showDetail('" + data[i].TaskId + "')\" >" + data[i].TaskName + "</a>";
            //所属项目
            var cell2 = row.insertCell(-1);
            cell2.innerHTML = data[i].ProjName;
            //项目阶段
            var cell3 = row.insertCell(-1);
            cell3.innerHTML = data[i].ProjPhase;

            var cell4 = row.insertCell(-1);
            cell4.innerHTML = ChangeDateFormat(data[i].TaskBegTime);
            var cell5 = row.insertCell(-1);
            cell5.innerHTML = ChangeDateFormat(data[i].TaskEndTime);
            //var cell5 = row.insertCell(-1);
            //if (data[i].TaskGrade == '') {
            //    cell5.innerHTML = "";
            //} else {
            //    cell5.innerHTML = data[i].TaskGrade;
            //}
            var cell6 = row.insertCell(-1);
            cell6.innerHTML = data[i].TaskSender;
        }
    } else {
        for (var i = 0; i < data.length ; i++) {
            var row = tb.insertRow(-1);
            var cell1 = row.insertCell(-1);
            cell1.innerHTML = "<a href=\"#\" title =\"点击查看详情\"  onclick = \"showDetail('" + data[i].TaskId + "')\" >" + data[i].TaskName + "</a>";
            var cell2 = row.insertCell(-1);
            cell2.innerHTML = ChangeDateFormat(data[i].TaskBegTime);
            var cell3 = row.insertCell(-1);
            cell3.innerHTML = ChangeDateFormat(data[i].TaskEndTime);

            var cell4 = row.insertCell(-1);
            cell4.innerHTML = data[i].TaskContent.trim().substr(0, 12);

            var cell5 = row.insertCell(-1);
            cell5.innerHTML = data[i].TaskSender;
        }
    }
    
};



function showDetail(taskId)
{
    location.href = "TaskDetail.aspx?taskId="+taskId;
}


function confirmComplete(taskId,ele)
{
    if (confirm("确认此任务已完成？"))
    {
        var $ele = $(ele).parent();
        var data;
        var xhrRequest = new AjaxRequest("get", "ComfirmTaskComplete.ashx?taskId=" + taskId, [], function (returnData) {
            data = returnData;
            //alert(data);
            if (data == 1) {
                $ele.empty();
                $ele.append("已完成");
            }
        })
        xhrRequest.send();
    }
}