<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyNotice.aspx.cs" Inherits="LIMS.NoticeManagement.MyNotice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的通知</title>
    <link href="CSS/MyNotice.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="notice-center">
    <div class="title" style="margin-bottom:0px"><%=notice.NoticeTitle %></div>
    <div class="tip" style="">发布人:<%=notice.Notifier %>&nbsp;&nbsp;&nbsp;发布时间:<%=notice.NoticeTime.ToString("yyyy年MM月dd日") %></div>
    <div id="text" class="text" style="padding-left:5px;padding-right:5px">
<%--       放置通知内容--%>
        <%=notice.NoticeContent %>
    </div>
<%--    关闭时重定向--%>
    <div class="btn-div"><button id="btnCancel" style="margin-left:390px;width:70px;height:30px">关闭</button></div>
</div>
<%--引入的js代码--%>
<script src="JS/easyUI/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
            //str = "\"" + str + "\"";
    })

    $(function () {
        $("#btnCancel").bind('click', function () {
            window.location = "NoticeManagement/NoticeList.aspx";
        })
    })
    </script>
</body>
</html>
