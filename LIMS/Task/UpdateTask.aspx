<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTask.aspx.cs" Inherits="LIMS.Task.UpdateTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../JS/jquery-1.9.1.js"></script>
    <script src="../JS/My97DatePicker/WdatePicker.js"></script>
    <script src="../JS/JSHelper.js"></script>
    <script src="JS/updateTask.js"></script>
    <link href="CSS/taskRelease.css" rel="stylesheet" />
    <title>任务发布</title>
    <script>
        window.onload = function () {
            loadMemberList(1,"<%=JSonMembers%>");
            setTaskType(<%=taskInfo.TaskTypeId%>);

            setTaskProj(<%=taskInfo.ProjId%>);

            setTaskProjPhase(<%=taskInfo.ProjPhaseId%>)

           
        }
    </script>
</head>
<body>
    <div id ="top-box">
    </div>
    <form id="form-task" method="post" action = "SaveTaskUpDate.aspx">
        <div id = "left-box">
            <input type="hidden" id="task-id" name="txtTaskId" value="<%=taskInfo.TaskId %>"/>
            <span class="span-title">
                任务标题：
            </span>
            <input type="text" id="task-title" name="txtTaskTitle" value="<%=taskInfo.TaskName %>" />

            <span class="span-title">
                任务类型：
            </span>
            <select id="task-type" onchange = "taskTypeChanged(this.options[this.selectedIndex].value)" name ="sltTaskType">
                <!--任务类型-->
                <%=sbSltTaskType%>>
            </select>

            <span id="sp-task-proj" style="display:block;" class="span-title">
                所属项目：
            </span>
            <select style="display:none;"  id="task-proj" name ="txtTaskProj" onchange = "projSltChanged()">
                <%=sbProjList %>>
            </select>

            <span id="sp-proj-phase" style="display:block;" class="span-title">
                项目阶段：
            </span>
            <select style="display:none;" id="slt-proj-phase" name ="sltProjPhase">
                <%=sbProjPhase %>>
            </select>

            <span class="span-title">
                开始时间：
            </span>
            <input type="text" onclick="WdatePicker({ dateFmt: 'yyyy年M月d日' })" id="date-beg" name="dateBeg" value ="<%=taskInfo.TaskBegTime.ToString("yyyy年M月d日") %>" />

            <span class="span-title">
                截止时间：
            </span>
            <input type="text" onclick="WdatePicker({ dateFmt: 'yyyy年M月d日' })" id="date-end" name="dateEnd" value ="<%=taskInfo.TaskEndTime.ToString("yyyy年M月d日") %>"  />

            <span class="span-title">
                任务内容：
            </span>
            <textarea id="task-content" name="txtTaskContent" ><%=taskInfo.TaskContent %></textarea>

            <input type="button" onclick="submitForm();" id="btn-confirm" value="保存"/>
            <input type="button" id="btn-cancel" value="取消" onclick="cancel()" />

        </div>


        <div id = "right-box">
            <div style="width:1px;height:500px;float:left;background:#ffffff;"></div>
            <span style="margin-left:10px;margin-top:15px;float:left;color:#354D70;font-size:14px;height:16px;">范围约束</span>
            <select id="slt-member-list" onchange = "loadMemberList(this.options[this.selectedIndex].value,'<%=JSonMembers%>')" name ="sltMemberList">
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
