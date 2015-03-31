<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllActInfo.aspx.cs" Inherits="LIMS.Activity.AllActInfo" %>
<%--/*------------------------------林志章-------------------------------------*/--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/AllActInfo.css" rel="stylesheet" />
    <script src="JS/AllActInfo.js"></script>

    <script>
        window.onload = function () {
            //编辑按钮的事件
            var actid = document.getElementById('ActId').value;
            document.getElementById("edit-list").onclick = function () {
                window.location.href = "EditActInfo.aspx?ActId=" + actid;
            }

            //删除按钮事件
            document.getElementById("dele-list").onclick = function () {
                if (confirm("确认删除此活动么？"))
                {                  
                    window.location.href = "DeleteAct.aspx?ActId=" + actid;
                  
                }
                
            }

        }

        

        //window.onload = function ()
        //{
        //    loadEdit(ActId);
        //}
    </script>

    <title>活动详情</title>
</head>

<body style="background-color:#ECECEC">
    <form id="form1" runat="server">

    <div id="total">

        <div id="d_head1">
        <span id="sp_title">活动信息</span>
            <%--<input type="button" value="删除" class="btn-dele" id="dele-list"/>
            <input type="button" value="编辑" class="btn-edit" id="edit-list"/>--%>
            <%=editdelete%>
            </div>

        

        <div id="d_table1">
        <table id="table">

        	<tr>
        		<td><span class="t_span">活动标题:</span></td>
                <td >
                    <input type="hidden" id="ActId" value="<%=list[0].ActId%>"/>
                    <input class="t_ipt" readonly="true" value="<%=list[0].ActTitle%>" type="text"/>
                </td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动负责人:</span></td>
                <td><input class="t_ipt" readonly="true" value="<%=list[0].LStuName%>" type="text"/></td>
            </tr>

            <tr>
                <td><span class="t_span">活动发布人:</span></td>
                <td><input class="t_ipt" readonly="true" value="<%=list[0].PStuName%>" type="text"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动地点:</span></td>
                <td><input class="t_ipt" readonly="true" value="<%=list[0].ActAddress%>" type="text"/></td>
            </tr>

            <tr>
                <td><span class="t_span">活动类型:</span></td>
                <td><input class="t_ipt" readonly="true" value="<%=list[0].ActTypeName%>" type="text"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动开始时间:</span></td>
                <td><input class="t_ipt" readonly="true" value="<%=list[0].ActStartTime%>" type="text"/></td>
            </tr>

            <tr>
                <td><span class="t_span">活动结束时间:</span></td>
                <td><input class="t_ipt" readonly="true"  value="<%=list[0].ActEndTime%>" type="text"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动开销:</span></td>
                <td><input class="t_ipt" readonly="true" value="<%=list[0].ActExpenses%>" type="text"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">附件:</span></td>
                <td><input class="t_ipt" readonly="true"  value="<%=list[0].ActAttachmentPath%>" type="text"/></td>
        	</tr>

        </table>    
            </div>
        
        <div id="d_content">
            <span style="font-weight:bold;">活动内容</span></br>
            <textarea readonly="true" class="texta"><%=list[0].ActContent%></textarea>
        </div> 

        <div id="d_remark">
            <span style="font-weight:bold;">活动备注</span></br>
            <textarea readonly="true"  class="texta"><%=list[0].ActRemark%></textarea>
        </div> 

        <%--<a id="return-list" href="#" title="返回活动列表">返回活动列表</a>--%>

    </div>

    </form>
</body>
</html>
