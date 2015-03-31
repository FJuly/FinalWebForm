<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskRelease.aspx.cs" Inherits="LIMS.Task.TaskRelease" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../JS/jquery-1.9.1.js"></script>
    <script src="../JS/My97DatePicker/WdatePicker.js"></script>
    <script src="../JS/JSHelper.js"></script>
    <script src="JS/taskRelease.js"></script>
    <link href="CSS/taskRelease.css" rel="stylesheet" />
    <title>任务发布</title>
    <script>
        window.onload = function ()
        {
            loadMemberList(1);
            document.getElementById("slt-member-list").options[0].selected = true;
        }
    </script>
</head>
<body>
    <div id ="top-box">
            <div id="div-title">
                <div style="width: 950px;border-bottom: 2px solid #ABADB3;padding-bottom:3px;">
                        <span style="padding-left:10px;">任务发布</span>
                </div>
            </div>
    </div>
    <form id="form-task" method="post" action = "SaveTask.aspx">
        <div id = "left-box">

            <span class="span-title">
                任务标题：
            </span>
            <input type="text" id="task-title" name="txtTaskTitle" />

            <span class="span-title">
                任务类型：
            </span>
            <select id="task-type" onchange = "taskTypeChanged(this.options[this.selectedIndex].value)" name ="sltTaskType">
                <!--任务类型-->
                <%=sbSltTaskType%>>
            </select>

            <span id="sp-task-proj" class="span-title" style="display:none;">
                所属项目：
            </span>
            <select style="display:none;"  id="task-proj" name ="txtTaskProj" onchange = "projSltChanged()">
                <%=sbProjList %>>
            </select>

            <span id="sp-proj-phase" style="display:none;" class="span-title">
                项目阶段：
            </span>
            <select style="display:none;" id="slt-proj-phase" name ="sltProjPhase">
                <%=sbProjPhase %>>
            </select>


            <span class="span-title">
                开始时间：
            </span>
            <input type="text" onclick="WdatePicker({ dateFmt: 'yyyy年M月d日' })" id="date-beg" name="dateBeg" />

            <span class="span-title">截止时间：</span>
            <input type="text" onclick="WdatePicker({ dateFmt: 'yyyy年M月d日' })" id="date-end" name="dateEnd" />

            <span class="span-title">任务内容：</span>
            <textarea id="task-content" name="txtTaskContent" ></textarea>

            <input type="button" onclick="submitForm()" id="btn-confirm" value="发布"/>
            <input type="button" id="btn-cancel" value="取消" onclick="customClose()"/>
        </div>
        <div id = "right-box">
            <div style="width:1px;height:500px;float:left;background:#ffffff;"></div>
            <span style="margin-left:10px;margin-top:15px;float:left;color:#354D70;font-size:14px;height:16px;">范围约束</span>
            <select id="slt-member-list" onchange = "loadMemberList(this.options[this.selectedIndex].value)" name ="sltMemberList">
                <%=sbMemberList %>>
                <%--<option value="1">所有成员</option>
                <option value="2">实习生</option>
                <option value="3">正式成员</option>
                <option value="4">物联网方向成员</option>
                <option value="5">系统编程方向成员</option>
                <option value="6">应用开发方向成员</option>--%>
            </select>
                <div style="margin-top:10px;width:242px;float:left;">
                    <table id="tb-member-list">
                        <tr>
                            <th style="width:40px;"><input onclick = "checkAll(this)" type="checkbox"/></th>
                            <th style="width:80px;">姓名</th>
                            <th style="width:120px;">学号</th>
                        </tr>
                    </table>
                </div>
            </div>
    </form>
    <div style="height:50px;width:800px;float:left;">
    </div>
</body>
</html>
