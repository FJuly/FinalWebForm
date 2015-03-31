<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionManger.aspx.cs" Inherits="LIMS.PersonnelManagement.PositionManger" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>网络与信息安全实验室</title>
    <script src="../JS/easyUI/jquery.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="CSSPositionManger.css" rel="stylesheet" type="text/css" />
    <script>
        //定义全局变量记录目前录入的职位的Id
        var recordId = undefined;
        //记录被选中的行
        var select = undefined;
        $(function () {
            $('#positonmemer').datagrid({
                url: 'PositionMangerAction.ashx',
                nowrap:false,
                fitColumns: true,
                title: "职位晋升",
                //singleSelect: "true",
                toolbar: "#toolbar",
                columns: [[
                    {checkbox: true },
                    { field: 'StuNum', title: '学号', width: 100, resizable: false},
                    { field: 'StuName', title: '姓名', width: 100, resizable: false },
                    { field: 'TelephoneNumber', title: '联系方式', width: 100, resizable: false },
                    { field: 'Major', title: '专业', width: 100, resizable: false },
                    { field: 'TechDireName', title: '技术方向', width: 100, resizable: false },
                    { field: 'TechLevelName', title: '技术水平', width: 100, resizable: false },
                    { field: 'Duty', title: '职务', width: 200, resizable: false},

                ]],
                onSelect: function (index,data) {
                    /*如果recordId=10002或者10003则录入的为总裁和财务主管，只允许录入一位*/
                    if (recordId == '10002' || recordId == '10003' || recordId == '10006' || recordId == '10004')
                    {
                        //判断选中多少行，如果行数大于1
                        if ($("#positonmemer").datagrid('getSelections').length > 1) {
                            alert("只允许录入一位！！");
                            $("#positonmemer").datagrid('uncheckRow', index);
                        }
                    }
                }
            });
        });

        $(function () {
            /*easyui combox初始化绑定*/
            $('#position').combobox({
                url: 'PositionManger.aspx?IsPost=true',
                valueField: 'DutyId',
                textField: 'DutyName',
                onSelect: function (record) {
                    //职位Id赋值
                    recordId = record.DutyId;
                    //清除所有行
                    $('#positonmemer').datagrid('loadData', { total: 0, rows: [] });
                    /*根据所选的录入的职位录入成员，record.DutyId为对应职务Id*/
                    $("#positonmemer").datagrid('load', { DutyId: record.DutyId,IsGet:'true'});
                }
            });
        });

        $(function () {
            $("#enter").bind('click', function () {
                var str =""
                var selected = $("#positonmemer").datagrid('getSelections');
                if (selected.length<=0)  
                    alert("为空");
                else {
                    $.each(selected, function (i, e) {
                        str += e.StuNum + ",";
                    })
                    $.messager.confirm('确认', '确定录入?', function (r) {
                        if (r) {
                            //注意： {StuNum:str}
                            $.post('PositionMangerAction.ashx?IsEnter=true&DutyId=' + recordId, { StuNum: str }, function (data) {
                                $.messager.show({
                                    title: '提示',
                                    msg: data,
                                    showType: 'slide',
                                });
                                //清除所有行
                                $('#positonmemer').datagrid('loadData', { total: 0, rows: [] });
                                //再次请求数据，请求的数据是被录入相应职位的成员
                                $("#positonmemer").datagrid('load', { DutyId: recordId, IsAgain: 'true' });
                            });
                        }
                    })
                }
            })
        })

    </script>
</head>
<body style="">
    <div style="border:1px solid #d1d1d1;margin:0 auto;width:1000px;height:569px;margin-top:0px; background:#fff;">
        <div style="width:1000px;height:450px;margin-top:50px";>
    <table id="positonmemer" style="width:1000px;height:450px"></table>
        </div>
    </div>

    <div id="toolbar" style="padding:5px;margin:0px;height:20px">
        <div style="border: 1px solid 1px; float: left">
            请选择:<input id="position" name="dept"/>
        </div>
        <div style="float:right">
            <a id="enter" href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true">录入</a>
        </div>
    </div>
</body>
</html>
