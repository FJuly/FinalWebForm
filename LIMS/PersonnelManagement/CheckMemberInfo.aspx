<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckMemberInfo.aspx.cs" Inherits="LIMS.PersonnelManagement.CheckMemberInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>网络与信息安全实验室</title>
    <script src="../JS/easyUI/jquery.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../JS/easyUI/datagrid-detailview.js" type="text/javascript"></script>
    <link href="CSS/CheckMemberInfo.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $('#tabmemer').datagrid({
                url: 'CheckMemberInfo.aspx?IsPost=true',
                singleSelect: "true",
                title: "成员信息",
                fitColumns: true,
                view: detailview,
                pagination: true,
                pageSize: 10,//每页显示的记录条数，默认为10
                pageList: [10, 20, 30, 40, 50],
                detailFormatter: function (rowIndex, rowData) {
                    return "<p style='width:100%;height:100%'>个人简介:</p><div id='personIntro'style='height:100px;width:450px;line-height:25px;word-wrap:break-word; word-break:normal;'></div>";
                },
                toolbar: "#tab",
                columns: [[
                    { field: 'StuNum', title: '学号', width: 100, resizable: false },
                    { field: 'StuName', title: '姓名', width: 100, resizable: false },
                    { field: 'TelephoneNumber', title: '联系方式', width: 100, resizable: false },
                    { field: 'Major', title: '专业', width: 100, resizable: false },
                    { field: 'TechDireName', title: '技术方向', width: 100, resizable: false },
                    { field: 'TechLevelName', title: '技术水平', width: 100, resizable: false },
                    { field: 'Duty', title: '职务', width: 100, resizable: false },

                ]],
                onExpandRow: function (index, row) {
                    var ddv = $(this).datagrid('getRowDetail', index).find('#personIntro');
                    ddv.text("　　我们定义 'detailFormatter' 函数，告诉数据网格（datagrid）如何渲染详细视图。在这种情况下,我们返回一个简单的元素它将充当详细内容的容器。请注意<div>，详细信息为空。");

                }
            });
        });

        $(function () {
            $('#ss').searchbox({
                searcher: function (value, name) {
                    var option = $('#tabmemer').datagrid('options');
                    /*改变datagrid的url*/
                    option.url = "CheckMemberInfo.aspx?IsPost=true&IsSearch=true&checkName=" + name + "&value=" + value;
                    $('#tabmemer').datagrid('load');
                },
                menu: '#mm',
                prompt: '请输入值'
            });
        });

        $(function () {
            /*编辑成员信息*/
            $(function () {
                $('#edit').bind('click', function () {
                    var row = $("#tabmemer").datagrid('getSelected');
                    if (row != undefined)
                        window.location.href = "PersonInforMangerEdit.aspx?StuNum=" + row.StuNum;  
                });
            });
            /* 查看成员详细信息*/
            $("#add").bind('click', function () {

                var row = $("#tabmemer").datagrid('getSelected');
                if (row != undefined)
                    window.location.href = "PersonInforManger.aspx?StuNum=" + row.StuNum;
            });
            /*移除某个成员*/
            $("#remove").bind('click', function () {
                var row = $("#tabmemer").datagrid('getSelected');
                //获取行的索引
                if (row != undefined) {
                    $.messager.confirm('确认', '确定删除?顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶娃娃哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇哇', function (r) {
                        if (r) {
                            var rowIndex = $("#tabmemer").datagrid('getRowIndex', row);
                            //jquery ajaxqingqiu
                            $.post("DeleteMember.ashx?StuNum=" + row.StuNum, function () {
                                $("#tabmemer").datagrid('deleteRow', rowIndex);
                                $.messager.alert('提示', '删除成功');
                            })

                        }
                    });

                }
            })
        });
    </script>                                     
</head>
<body>
    <div style="border:1px solid #d1d1d1;margin:0 auto;width:1000px;height:569px; background:#fff;">
<div style="width:1000px;height:450px;margin-top:50px">
    <table id="tabmemer" style="width:1000px;height:450px"></table>
</div>
        <div id="tab" style="height:20px;padding:5px">
            <div>
                <div style="border: 1px solid 1px; float: left">
                    <a id="add" href="#" title="查看详情" class="easyui-linkbutton" iconcls="icon-add" plain="true"></a>
                    <%=EditStr %>
                    <%=DeleteStr %>
                </div>
            </div>
            <div style="float: right">                                              
                <input id="ss"/>
                <div id="mm" style="width: 120px">
                    <div data-options="name:'StuNum'">学号</div>
                    <div data-options="name:'StuName'">姓名</div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>



