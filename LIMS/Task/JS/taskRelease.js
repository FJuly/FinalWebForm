﻿
///加载成员列表
function loadMemberList(type)
{
    //alert(type);
    ///利用AJAX异步请求GetMemberList.ashx成员列表
    var slt = document.getElementById("task-proj");
    //alert(slt.options[slt.selectedIndex].value);
    var xhrRequest = new AjaxRequest("get", "GetMemberList.ashx?type=" + type + "&proj=" + slt.options[slt.selectedIndex].value, [], function (returnData) {
        //alert(returnData);
        var obj = eval(returnData);
        //alert(obj);
        makeMemberTable(obj);
    })
    xhrRequest.send();
}

///传入js数组绘制成员信息表格
function makeMemberTable(data) {
    var tb = document.getElementById("tb-member-list");
    var $tb = $("#tb-member-list tr:not(:first)");
    $tb.remove();

    for (var i = 0; i < data.length ; i++) {
        var row = tb.insertRow(-1);
        var cell1 = row.insertCell(-1);
        cell1.innerHTML = "<input type=\"checkbox\" name=\"checkbox\" value=\"" + data[i].StuNum + "\"/>";
        var cell2 = row.insertCell(-1);
        cell2.innerHTML = data[i].StuNum;
        var cell3 = row.insertCell(-1);
        cell3.innerHTML = data[i].StuName;
    }

}

///获取选中的Checkbox
function getChecked()
{
    var x = document.getElementsByName("checkbox");

    strStuNum = x[0].value;

    for (var i = 1; i < x.length; i++)
    {
        strStuNum +="," +x[i].value;
    }

    return strStuNum;
}


///选中所有Checkbox
function checkAll(obj)
{
    //alert(obj.checked);
    var x = document.getElementsByName("checkbox");
    //alert(x[0].checked);
    if (obj.checked == true)
    {
        for (var i = 0; i < x.length; i++)
        {
            x[i].checked = true;
        }
    } else
    {
        for (var i = 0; i < x.length; i++) {
            x[i].checked = false;
        }
    }
}

//提交表单
function submitForm()
{
    var $taskTitle = $("#task-title");
    var $taskType = $("#task-type");
    var $taskProj = $("#task-proj");
    var $projPhase = $("#slt-proj-phase");
    var $dateBeg = $("#date-beg");
    var $dateEnd = $("#date-end");
    var $taskContent = $("#task-content");

    if($.trim($taskTitle.val()) == "")
    {
        alert("请填写任务标题！");
    }else if ($.trim($dateBeg.val()) == "")
    {
        alert("请选择任务开始时间！");
    } else if ($.trim($dateEnd.val()) == "")
    {
        alert("请选择任务结束时间！");
    } else if ($taskContent.val() == "") {
        alert("请填写任务内容！");
    } else if (!selectedMember())
    {
        alert("请选择任务接收人！");
    }else{
        $("#form-task").submit();
    }
}


//任务类型下拉框Changed事件
function taskTypeChanged(value) {

    //获取成员选择下拉框
    var sltMemberList = document.getElementById('slt-member-list');

    if (value != 10003) {
        document.getElementById("sp-task-proj").style.display = "none";
        document.getElementById("sp-proj-phase").style.display = "none";
        document.getElementById("slt-proj-phase").style.display = "none";
        document.getElementById("task-proj").style.display = "none";
        sltMemberList.disabled = false;
    } else {
        document.getElementById("sp-task-proj").style.display = "block";
        document.getElementById("sp-proj-phase").style.display = "block";
        document.getElementById("slt-proj-phase").style.display = "block";
        document.getElementById("task-proj").style.display = "block";
        //如果是项目任务，则不可编辑
        sltMemberList.disabled = true;
        projSltChanged();
    }
}

//项目列表下拉框Changed事件
function projSltChanged()
{
    var sltMemberList = document.getElementById('slt-member-list');
    for (var i = 0; i < sltMemberList.options.length; i++)
    {
        if (sltMemberList.options[i].value == 7)
        {
            sltMemberList.options[i].selected = true;
            loadMemberList(7);
        }
    }
}

//取消按钮Click事件
function customClose() {
    if(confirm("您确定要离开本页吗？")) {
        self.opener = null;
        self.open('', '_self');
        self.close();
    }
}



function selectedMember() {
    var x = document.getElementsByName("checkbox");

    for (var i = 1; i < x.length; i++) {
        if (x[i].checked == true) {
            return true
        }
    }
    return false;
}
