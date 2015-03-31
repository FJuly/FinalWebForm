<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewActivity.aspx.cs" Inherits="LIMS.Activity.NewActivity" %>
<%--/*------------------------------林志章-------------------------------------*/--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/NewActivity.css" rel="stylesheet" />
    <script src="JS/NewActivity.js"></script>

    <script src="../JS/easyUI/jquery.min.js"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js"></script>
    <link href="../JS/easyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" />

    <script>
        window.onload = function () {
            document.getElementById("btn-cancel").onclick = function () {
                if (confirm("确认取消新建此活动么？"))
                {
                    window.location.href = "MyActivity.aspx";
                }
            }

        }

    </script>

    <title>新建活动</title>
</head>
<body style="background-color:#ECECEC">
    
     <%-- --------------------------------选活动负责人-----------------------------------------%>
        <div id="LScheckbox" style="left:435px;top:120px;width:300px;height:350px;background-color:#ECECEC;position:absolute;display:none;border:1px solid #CCCCCC">

            <div style="width:300px;height:35px;background-color:#83DA8A;padding-top:5px">
                <input type="radio" id="checkall" style="padding-left:0px;margin-left:25px;" />
                <span style="margin-left:13px;">学号</span>
                <span style="margin-left:125px;">姓名</span>
                </div>

            <div style="width:300px;height:274px;overflow:scroll">
                <table style="margin:0;padding:0;border-collapse:collapse;width:250px;height:250px;margin-left:20px;">
                    <%=LSallMemberHtml%>
                    <tr><td><div style="height:250px;width:1px;"></div></td></tr>
                    </table>
            </div>

            <div style="width:300px;height:35px;background-color:white;top:300px;position:absolute;">
               <button id="LSbtnOK" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:60px" onclick="LSbtnOK()">确定</button>
                <button id="LSbtnCancel" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:70px" onclick="LSCancel()">取消</button>
            </div>

        </div>

    <%-- --------------------------------选活动发布人-----------------------------------------%>
        <%--<div id="Pcheckbox" style="left:435px;top:160px;width:300px;height:350px;background-color:#ECECEC;position:absolute;display:none;border:1px solid #CCCCCC">

            <div style="width:300px;height:35px;background-color:#83DA8A;padding-top:5px">
                <input type="radio" id="Radio1" style="padding-left:0px;margin-left:25px;"/>
                <span style="margin-left:13px;">学号</span>
                <span style="margin-left:125px;">姓名</span>
                </div>

            <div style="width:300px;height:274px;overflow:scroll">
                <table style="margin:0;padding:0;border-collapse:collapse;width:250px;height:250px;margin-left:20px;">
                    <%=PallMemberHtml%>
                    <tr><td><div style="height:250px;width:1px;"></div></td></tr>
                    </table>
            </div>

            <div style="width:300px;height:35px;background-color:white;top:300px;position:absolute;">
               <button id="Button1" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:60px" onclick="PbtnOK()">确定</button>
                <button id="Button2" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:70px" onclick="PCancel()">取消</button>
            </div>

        </div>--%>


    <%-- --------------------------------选活动参与人-----------------------------------------%>
        <div id="Reccheckbox" style="left:435px;top:200px;width:300px;height:350px;background-color:#ECECEC;position:absolute;display:none;border:1px solid #CCCCCC">

            <div style="width:300px;height:35px;background-color:#83DA8A;padding-top:5px">
                <input type="checkbox" id="Reccheckall" style="padding-left:0px;margin-left:25px;" onclick="Checkall()"/>
                <span style="margin-left:13px;">学号</span>
                <span style="margin-left:125px;">姓名</span>
                </div>

            <div style="width:300px;height:274px;overflow:scroll">
                <table style="margin:0;padding:0;border-collapse:collapse;width:250px;height:250px;margin-left:20px;">
                    <%=RecallMemberHtml%>
                    <tr><td><div style="height:250px;width:1px;"></div></td></tr>
                    </table>
            </div>

            <div style="width:300px;height:35px;background-color:white;top:300px;position:absolute;">
               <button id="RecbtnOK" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:60px" onclick="RecbtnOK()">确定</button>
                <button id="RecCancel" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:70px" onclick="RecCancel()">取消</button>
            </div>

        </div>
   

    <form id="form-newact" method="post" action="SaveNewAct.aspx"> 

    <div id="total">
       
        <div id="d_head1">
        <span id="sp_title">活动新建</span>
            </div>

        <div id="d_table1">
        <table id="table">

        	<tr>
        		<td><span class="t_span">活动标题:</span></td>
                <td >
                    <input type="hidden" name="txtActId"/>
                    <input class="t_ipt" type="text" name="txtActTitle" id="act-title"/>
                </td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动负责人:</span></td>
                <input type="hidden" id="act-lstunum" name="txtActStuNum" />
                <td><input readonly="true" class="t_ipt" type="text" name="txtLStuName" id="act-lstuname" onclick="LSChoose()"/></td>
            </tr>

            <%--<tr>
                <td><span class="t_span">活动发布人:</span></td>
                <input type="hidden" id="act-pstunum" name="txtPStuNum" />
                <td><input  readonly="true" class="t_ipt" type="text" name="txtPStuName" id="act-pstuname" onclick="PChoose()"/></td>
        	</tr>--%>

            <tr>
        		<td><span class="t_span">活动参与人:</span></td>
                <input type="hidden" id="act-receivernum" name="txtReceiverNum" />
                
                <td><input readonly="true" class="t_ipt" type="text" name="txtReceiver" id="act-receiver" onclick="RecChoose()"/></td>
            </tr>
            <%--<textarea id="act-receiver" name="txtReceiver" readonly="true" onclick="RecChoose()" style="font:12px;width:220px;height:40px;"></textarea>--%>

            <tr>
        		<td><span class="t_span">活动地点:</span></td>
                <td><input   class="t_ipt" type="text" name="txtActAddress" id="act-address"/></td>
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
                <td><input class="easyui-datetimebox" required style="width:225px;font-size:12px;" name="dtbActStartTime" id="act-starttime"/></td>
            </tr>

            <tr>
                <td><span class="t_span">活动结束时间:</span></td>
                <td><input  class="easyui-datetimebox" required style="width:225px;font-size:12px;" name="dtbActEndTime" id="act-endtime"/></td>
        	</tr>

            <tr>
        		<td><span class="t_span">活动开销:</span></td>
                <td><input class="t_ipt" type="text" name="txtActExpenses" id="act-expenses"/></td>
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
            <textarea class="texta" name="txtaActContent" id="act-content"></textarea>
        </div> 

        <div id="d_remark">
            <span style="font-weight:bold;">活动备注</span></br>
            <textarea  class="texta" name="txtaActRemark" id="act-remark"></textarea>
        </div> 

        <input type="button" value="提交" class="btn-sbmit"  id="btn-submit" onclick="submitForm()"/>
        <input type="button" value="取消" class="btn-cancel" id="btn-cancel"/>
        <%--<a id="return-list" href="#" title="返回活动列表">返回活动列表</a>--%>

    </div>
        </form>
</body>
</html>
