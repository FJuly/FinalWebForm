<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseHistoryDetail.aspx.cs" Inherits="LIMS.Task.ReleaseHistoryDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/releaseHistoryDetal.css" rel="stylesheet" />
    <script src="../JS/JSHelper.js"></script>
    <script src="JS/releaseHistoryDetal.js"></script>
    <title></title>
    <script>
        window.onload = function () {
            document.getElementById("return-list").onclick = function () {
                window.location.href = "ReleaseHistory.aspx";
            }
        }
    </script>
</head>
<body>
    <div id="top-box" style="width:1000px;text-align:left;padding-left:30px;height:50px;">
        <h2 style="color:#787878;">查看任务详情>></h2>
    </div>
    <div id="main-box">
        <table id="tb-detail">
            <%=sbTaskDetail %>
        </table>
    </div>
    <div style="width:1000px;height:40px">
        <div style="width:1000px;height:20px;margin-top:10px;">
            <a id="return-list" href="#" title="返回任务列表"><<返回任务列表</a>
        </div>
    </div>
    <div  style="width:1000px;text-align:left;padding-left:30px;height:30px;">
        <h3 style="color:#787878;">任务接收人列表>></h3>
    </div>
    <div id="member-list">
        <%=sbMemberList %>
    </div>
</body>
</html>
