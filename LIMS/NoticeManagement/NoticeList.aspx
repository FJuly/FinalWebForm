<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="LIMS.NoticeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div style="border: 1px solid #d1d1d1; margin: 0 auto; width: 1000px; height: 550px; background: #fff;">
    <div style="width:1000px;height:450px;margin-top:50px">
        <table id="dg" style="width: 1000px; height: 450px"></table>
    </div>
</div>
<%--    引入js代码--%>
<script src="../JS/easyUI/jquery.min.js" type="text/javascript"></script>
<script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
<script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>    
<script type="text/javascript">
    $('#dg').datagrid({
        url: 'NoticeList.aspx?IsPost=true',
        singleSelect: "true",
        title: "通知信息" ,
        fitColumns: true,
        pagination: true,
        pageSize: 10,//每页显示的记录条数，默认为10
        pageList: [10, 20, 30, 40, 50],
        columns: [[
            { field: 'NoticeTitle', title: '标题', width: 100 },
            { field: 'Notifier', title: '发布人', width: 100 },
            { field: 'NoticeTime', title: '时间', width: 100 },
            { field: 'IsRead', title: '是否已读', width: 100 },
            {
                field: 'NoticeId', title: '查看', formatter: function () {
                    return "<a href='MyNotice.aspx?noticeId=" + arguments[0] + "'>查看</a>";
                }
            }
            
        ]],
        onClickRow: function () {
            /*不给选中任何行*/
            $('#dg').datagrid('uncheckAll');
        }
    });
</script>
</body>
</html>
