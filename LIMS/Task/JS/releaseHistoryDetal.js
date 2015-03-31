function saveGradeChange(taskGrade, stuNum, taskId) {
    //alert(taskGrade + "," + stuNum + "," + taskId);

    var xhrRequest = new AjaxRequest("get", "SaveTaskGrade.ashx?taskGrade=" + taskGrade + "&stuNum=" + stuNum + "&taskId=" + taskId, [], function (returnData) {

        //var obj = eval(returnData);
        //alert(returnData);
        if (returnData == "nook") {
            alert("对不起，服务器忙！请稍后重试！");
        } else {
            alert("任务评价已保存！");
        }
    })
    xhrRequest.send();
}