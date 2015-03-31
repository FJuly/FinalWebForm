<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTask.aspx.cs" Inherits="LIMS.MyTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../JS/easyUI/jquery.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="CSS/myTask.css" rel="stylesheet" type="text/css"/>
    <script src="../JS/jquery.simplePagination.js"></script>
    <link href="../CSS/simplePagination.css" rel="stylesheet" />
    <script src="../JS/JSHelper.js"></script>
    <script src="JS/myTask.js"></script>
    <script>
        var stuTaskCount = <%=stdTaskCount%>;
        var developTaskCount = <%=developTaskCount%>;
        var projTaskCount = <%=projTaskCount%>;
        var chairTaskCount = <%=chairTaskCount%>;
        window.onload = function ()
        {
            loadData(1, 10001);
            loadData(1, 10002);
            loadData(1, 10003);
            loadData(1, 10004);
            makePageBar($("#pageBar" + 10001), stuTaskCount,10001);
            makePageBar($("#pageBar" + 10002), developTaskCount,10002);
            makePageBar($("#pageBar" + 10003), projTaskCount,10003);
            makePageBar($("#pageBar" + 10004), chairTaskCount,10004);
        };

    </script>
    <title>我的任务</title>
</head>
<body style="width:1166px;height:550px;margin:0px auto; padding:0px;">
    <div class="easyui-accordion" style="width:1166px;height:550px;margin:0px auto; padding:0px;">
        <%=sbHtml.ToString()%>
    </div>
</body>
</html>
