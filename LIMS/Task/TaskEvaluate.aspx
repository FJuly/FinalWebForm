<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskEvaluate.aspx.cs" Inherits="LIMS.Task.TaskEvaluate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../JS/jquery-1.9.1.js"></script>
    <script src="../JS/JSHelper.js"></script>
    <script src="JS/taskEvaluate.js"></script>
    <link href="CSS/taskEvaluate.css" rel="stylesheet" />
    <script>
        var taskCount = <%=taskCount%>;
        window.onload = function ()
        {

            loadData(1);

            makePageBar($("#pageBar"), taskCount);

        };

    </script>
    <title>发布记录</title>
</head>
<body>
    <div id ="top" style="margin:0px auto;width:1000px; height:50px;text-align:left;padding-left:30px;">
        <h2 style="color:#787878">任务列表>></h2>
    </div>
    <div id ="task-list">
        <table class="task-table" id="tbTask">
            <tr>
                <th style="width:350px">任务标题</th>
                <th style="width:90px">任务类型</th>
                <th style="width:140px">发布时间</th>
                <th style="width:140px">截止时间</th>
                <th style="width:180px">内容提要</th>
                <th style="width:90px">评价任务</th>
            </tr>
        </table>
        <div style="margin:0px auto;font-size:13px;width:1000px;padding-top:10px;" id="pageBar"></div>
    </div>
</body>
</html>
