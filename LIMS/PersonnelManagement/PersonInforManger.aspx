<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonInforManger.aspx.cs" Inherits="LIMS.PersonnelManagement.PersonInforManger" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../JS/easyUI/jquery.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="CSS/PersonInforManger.css"/>
<script type="text/javascript" charset="utf-8">
    //$(function(){
    //    $('#tt').datagrid({
    //        url: 'PersonInforManger.aspx?IsPost=true',//在这里应该有一个ajax请求
    //        title: "Json",
    //        columns:[[
    //            {field:'code',title:'Code',width:100},
    //            {field:'name',title:'Name',width:100},
    //            {field:'price',title:'Price',width:100,align:'right'}
    //        ]]
    //    })
    //});
</script>
</head>
<body>

<div id="nav">
<div class="divtitle divtitleone">
    <span>个人资料</span>
    <button>编辑</button>
</div>
<div class="div-center">
    <div class="divtitle">   
        <span>基本信息</span>
    </div>
    <ul class="ul-nav">
        <li >
            <span class="ul-span">姓名:</span>
            <span><%=member.StuName %></span>
        </li>
        <li>
            <span class="ul-span">性别:</span>
            <span><%=member.Gender %></span>
        </li>
        <li>
            <span class="ul-span">QQ:</span>
            <span><%=member.QQNum %></span>
        </li>
        <li>
            <span class="ul-span">邮箱:</span>
            <span><%=member.Email %></span>
        </li>
        <li>
            <span class="ul-span">登陆密码:</span>
            <span><%=member.LoginPwd %></span>
        </li>
        <li>
            <span class="ul-span">生日:</span>
            <span><%=member.Birthday.ToString("yyyy年MM月dd日") %></span>
        </li>
        <li>
            <span class="ul-span">班级:</span>
            <span><%=member.Class %></span>
        </li>
        <li>
            <span class="ul-span">专业:</span>
            <span><%=member.Major %></span>
        </li>
        <li>
            <span class="ul-span">辅导员:</span>
            <span><%=member.Counselor %></span>
        </li>
        <li>
            <span class="ul-span">班主任:</span>
            <span><%=member.HeadTeacher %></span>
        </li>
        <li>
            <span class="ul-span">本科生导师:</span>
            <span><%=member.UndergraduateTutor %></span>
        </li>
        <li>
            <span class="ul-span">联系方式:</span>
            <span><%=member.TelephoneNumber %></span>
        </li>
        <li>
            <span class="ul-span">家庭联系电话:</span>
            <span><%=member.HomPhoneNumber %></span>
        </li>
        <li>
            <span class="ul-span">家庭住址:</span>
            <span><%=member.FamilyAddress %></span>
        </li>

    </ul>
</div>
    <div class="divleft">
    <div class="divtitle">
        <span>实验室信息</span>
    </div>
    <ul class="ul-nav ulnav-one">
        <li >
            <span class="ul-span">技术方向:</span>
            <span><%=member.TechDireName %></span>
        </li>
        <li>
            <span class="ul-span">技术层次:</span>
            <span><%=member.TechLevelName %></span>
        </li>
        <li>
            <span class="ul-span">加入时间:</span>
            <span><%=member.JoinTime.ToString("yyyy年MM月dd日") %></span>
        </li>
        <li>
            <span class="ul-span">退出时间:</span>
            <span><%=member.EndTime.ToString("yyyy年MM月dd日") %></span>
        </li>

        <li>
            <span class="ul-span">担任职务:</span>
            <span><%=duty%></span>
        </li>
    </ul>
    </div>
    <div class="divleftone" style="border-collapse:collapse">
    <div class="divtitle">   
        <span>个人简介</span>
    </div>
        <div id="divguide">
            <img src="<%=member.PhotoPath %>" style="width:100%;height:100%" />
        </div>
        <div id="divintro">
            <span style="display:inline-block">个人简介：长沙理工大学学生</span>
        </div>
    </div>
</div>
</body>
</html>
