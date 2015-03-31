<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditActInfo.aspx.cs" Inherits="LIMS.Activity.EditActInfo" %>
<%--/*------------------------------林志章-------------------------------------*/--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link href="CSS/EditActInfo.css" rel="stylesheet" />
    <script src="JS/EditActInfo.js"></script>

    <link href="../JS/easyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" />
<%--    <link href="../JS/easyUI/demo/demo.css" rel="stylesheet" />--%>
    <script src="../JS/easyUI/jquery.min.js"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js"></script>
    <script src="../JS/jquery-1.9.1.js"></script>

    <script>
        window.onload = function () {
            setActType("<%=actinfo[0].ActTypeId%>"); //设置活动类型的JS函数
            var actid = document.getElementById('ActId').value;
            document.getElementById("btn-cancel").onclick = function () {
                if (confirm("确认取消此次修改操作么？"))
                {
                    //window.location.href = "MyActivity.aspx";
                    window.location.href = "AllActInfo.aspx?ActId=" + actid;
                }
               
                }
        
        }

    </script>

    <title>活动编辑</title>
</head>
<body style="background-color:#ECECEC">

    <%-- --------------------------------选活动负责人-----------------------------------------%>
        <div id="mcheckbox" style="left:435px;top:125px;width:300px;height:350px;background-color:#ECECEC;position:absolute;display:none;border:1px solid #CCCCCC">

            <div style="width:300px;height:35px;background-color:#83DA8A;padding-top:5px">
                <input type="radio" id="checkall" style="padding-left:0px;margin-left:25px;" onclick="Checkall()"/>
                <span style="margin-left:13px;">学号</span>
                <span style="margin-left:125px;">姓名</span>
                </div>

            <div style="width:300px;height:274px;overflow:scroll">
                <table style="margin:0;padding:0;border-collapse:collapse;width:250px;height:250px;margin-left:20px;">
                    <%=allMemberHtml%>
                    <tr><td><div style="height:250px;width:1px;"></div></td></tr>
                    </table>
            </div>

            <div style="width:300px;height:35px;background-color:white;top:300px;position:absolute;">
               <button id="btnOK" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:60px" onclick="btnOK()">确定</button>
                <button id="btnCancel" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:70px" onclick="Cancel()">取消</button>
            </div>

        </div>

    <form id="form-editact" method="post" action="SaveEditAct.aspx"> 

    <div id="total">
       
        <div id="d_head1">
        <span id="sp_title">活动信息修改</span>
            </div>

        <div id="d_table1">
        <table id="table">

        	<tr>
        		<td><span class="t_span">活动标题:</span></td>
                <td >
                    <input type="hidden" name="txtActId" id="ActId" value="<%=actinfo[0].ActId%>"/>
                    <input value="<%=actinfo[0].ActTitle%>" class="t_ipt" type="text" name="txtActTitle" id="act-title"/>
                </td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动负责人:</span></td>
                <input type="hidden" value="<%=actinfo[0].LStuNum%>" id="act-lstunum" name="txtActStuNum" />
                <td><input value="<%=actinfo[0].LStuName%>" readonly="true" class="t_ipt" type="text" name="txtLStuName" id="act-lstuname" onclick="Choose()"/></td>
            </tr>

            <tr>
                <td><span class="t_span">活动发布人:</span></td>
                <td><input value="<%=actinfo[0].PStuName%>" readonly="true" class="t_ipt" type="text" name="txtPStuName" id="act-pstuname"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动地点:</span></td>
                <td><input value="<%=actinfo[0].ActAddress%>"  class="t_ipt" type="text" name="txtActAddress" id="act-address"/></td>
            </tr>

            <tr>
                <td><span class="t_span">活动类型:</span></td>
                <td>
                    <select style="width:225px;font-size:12px;" id="act-type" name="acttype">
                        <option value="10001">娱乐活动</option>
                        <option value="10002">文体比赛</option>
                        <option value="10003">团队宣传</option>
                        <option value="10004">文化建设</option>
                        <option value="10005">日常活动</option>
                        </select>
                    <%--<input type="hidden" value="<%=actinfo[0].ActTypeId%>" id="act-typeid" name="txtActTypeId"/>
                    <input type="text" class="t_ipt" value="<%=actinfo[0].ActTypeName%>" name="txtActTypeName" id="act-typename"/>--%>
                </td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动开始时间:</span></td>
                <td><input value="<%=actinfo[0].ActStartTime%>" class="easyui-datetimebox" required style="width:225px;font-size:12px;" name="dtbActStartTime" id="act-starttime"/></td>
            </tr>

            <tr>
                <td><span class="t_span">活动结束时间:</span></td>
                <td><input value="<%=actinfo[0].ActEndTime%>" class="easyui-datetimebox" required style="width:225px;font:1em 微软雅黑" name="dtbActEndTime" id="act-endtime"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动开销:</span></td>
                <td><input value="<%=actinfo[0].ActExpenses%>" class="t_ipt" type="text" name="txtActExpenses" id="act-expenses"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">附件:</span></td>
                <%--<td><input value="<%=actinfo[0].ActAttachmentPath%>" class="t_ipt" type="text"/></td>--%>
                <td><input type="file" /></td>
                
        	</tr>
                <%--<asp:FileUpload runat="Server"/>--%>
        </table>    
            </div>
        
        <div id="d_content">
            <span style="font-weight:bold;">活动内容</span></br>
            <textarea class="texta" name="txtaActContent" id="act-content"><%=actinfo[0].ActContent%></textarea>
        </div> 

        <div id="d_remark">
            <span style="font-weight:bold;">活动备注</span></br>
            <textarea  class="texta" name="txtaActRemark" id="act-remark"><%=actinfo[0].ActRemark%></textarea>
        </div> 

        <input type="button" value="提交" class="btn-sbmit" onclick="submitForm()" id="btn-submit"/>
        <input type="button" value="取消" class="btn-cancel" id="btn-cancel"/>
        <%--<a id="return-list" href="#" title="返回活动列表">返回活动列表</a>--%>

    </div>

    </form>
</body>
</html>
