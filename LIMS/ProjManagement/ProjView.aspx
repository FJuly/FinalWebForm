<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjView.aspx.cs" Inherits="LIMS.ProjManagement.ProjView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../JS/easyUI/jquery.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/default/easyui.css" rel="stylesheet" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:#ECECEC">
    <div style="width:1000px; border:1px solid white;margin-left:auto; margin-right:auto;">
        <%----按条件搜索----%>
        <table>
            <tr>
                <td><h2 style="color:#40626E">实验室项目基本信息</h2></td> 
                    <td><form><div style="margin-left:515px; margin-top:30px"><input id="ipt_search" menu="#search_menu" />
                                <div id="search_menu" style="width:120px">
                                    <div name="ProjName"> 项目名称</div>
                                    <div name="ProjTypeName">项目类型</div>
                                    <div name="StuName">项目主管</div>
                                </div>
                       </div></form></td>
                </tr>
            </table>
        <%--项目基本信息表--%>
        <table id="tab_list" title="项目列表" class="easyui-datagrid" style="width:1000px;height:450px;" url="GetProjList.ashx"
             pagination="true" rownumbers="true" fitColumns="true" singleSelect="true">
        </table>
    </div>

    <%--界面初始化--%>
    <script type="text/javascript">

             $(function () {
                InitGird();
                InitSearch();
             });
             //初始化表格
             function InitGird() {
                 $('#tab_list').datagrid({
                     idField: 'ProjId', //标识字段,主键
                     columns: [[
                   //      { title: '项目名称', field: 'ProjName', width: 50, formatter: function (value, rec) { return '<a style="color:#ff6600" href="ProjDetailInfo.aspx">' + value + '</a>'; } },
                      { title: '项目名称', field: 'ProjName', width: 50 },
                     { title: '项目类型', field: 'ProjTypeName', width: 50 },
                         { title: '项目主管', field: 'StuName', width: 50 },
                         { title: '项目开始时间', field: 'ProjStartTime', width: 50 },
                         { title: '项目结束时间', field: 'AcFinishiTime', width: 50 },
                         {
                             title: '操作', field: 'IdAndType', width: 50, formatter: function (value, rec) {
                                 //InAndType 的格式为10001个人项目
                                 //分割InAndType的ProjId
                                 var projid = value.substr(0, 5);
                                 //分割InAndType的ProjTypeName
                                 var projtype = value.substr(5, value.length);
                                 //判断权限
                                 return JudgPermissions(projid, projtype);
                             }
                         }
                     ]],
                     queryParams: { "action": "query" }
                 });
             }

             //权限判断
             function JudgPermissions(projid, projtype) {
                <%=aaa %>
                if (projtype == "个人项目") {
                    if (isperson) {
                        return '<a style="color:#ff6600" href="ProjDetailInfo.aspx?ProjId=' + projid + '">查看详情</a>&nbsp;<a onclick="del(this)" aid="' + projid + '" href="javascript:void(0)" style="color:red">删除</a>';
                    }
                    else {
                        return '<a style="color:#ff6600" href="ProjDetailInfo.aspx?ProjId=' + projid + '">查看详情</a>&nbsp;<a aid="' + projid + '" href="javascript:void(0)" style="color:gray">删除</a>';
                    }
                }
                else if (projtype == "作品项目") {
                    if (iswork) {
                        return '<a style="color:#ff6600" href="ProjDetailInfo.aspx?ProjId=' + projid + '">查看详情</a>&nbsp;<a onclick="del(this)" aid="' + projid + '" href="javascript:void(0)" style="color:red">删除</a>';
                    }
                    else {
                        return '<a style="color:#ff6600" href="ProjDetailInfo.aspx?ProjId=' + projid + '">查看详情</a>&nbsp;<a aid="' + projid + '" href="javascript:void(0)" style="color:gray">删除</a>';
                    }
                }
                else if (projtype == "企业项目") {
                    if (isenterprise) {
                        return '<a style="color:#ff6600" href="ProjDetailInfo.aspx?ProjId=' + projid + '">查看详情</a>&nbsp;<a onclick="del(this)" aid="' + projid + '" href="javascript:void(0)" style="color:red">删除</a>';
                    }
                    else {
                        return '<a style="color:#ff6600" href="ProjDetailInfo.aspx?ProjId=' + projid + '">查看详情</a>&nbsp;<a aid="' + projid + '" href="javascript:void(0)" style="color:gray">删除</a>';
                    }
                }
                else {
                    console.log("系统错误！");
                }
            }      

             //初始化搜索框
             function InitSearch() {
                 $("#ipt_search").searchbox({
                     width: 250,
                     iconCls: 'icon-save',
                     searcher: function (val, name) {
                         $('#tab_list').datagrid('options').queryParams.search_type = name;
                         $('#tab_list').datagrid('options').queryParams.search_value = val;
                         $('#tab_list').datagrid('reload');
                     },
                     prompt: '请输入您的查询'
                 });
             }

            //删除与项目有关的所有信息
             function del(obj) {
                 $.messager.confirm("提示", "确定要删除此条信息", function (r) {    
                     if (r) {
                         var projid = obj.getAttribute("id");
                         //        alert(projid);
                         var iswork = obj.getAttribute("iswork");
                         var isperson = obj.getAttribute("isperson");
                         var isenterprise = obj.getAttribute("isenterprise");
                         $.get("DelProject.ashx", { id: projid, iswork: iswork, isperson: isperson, isenterprise: isenterprise }, function (data, status) {
                             if (data == "ok") {
                                 alert("删除成功！");
                                 $('#tab_list').datagrid('reload');
                             }
                             else {
                                 alert("删除失败！");
                             }
                         })
                     }
                 });
                 
             }            
        </script>

    <%-----样式-----%>
    <style type="text/css">
            #fm{
                margin:0;
                padding:10px 30px;
            }
        </style>
</body>
</html>
