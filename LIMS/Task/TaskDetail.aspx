<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskDetail.aspx.cs" Inherits="LIMS.Task.TaskDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/taskDetail.css" rel="stylesheet" />
    <title></title>
    <script>
        window.onload = function ()
        {
            document.getElementById("return-list").onclick = function ()
            {
                window.location.href = "MyTask.aspx";
            }
        }
    </script>
</head>
<body>
    <div>
        <h3 style="color:#0099FF;">>>查看任务详情</h3>
    </div>
    <div id="main-box">
        <table id="tb-detail">
            <%=sbTaskDetail %>
        </table>
    </div>
        <div style="width:1000px;height:60px">
        <div style="width:1000px;height:20px;margin-top:10px;">
            <a id="return-list" href="#" title="返回任务列表"><<返回任务列表</a>
        </div>
    </div>
</body>
</html>
