<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="LIMS.ProjManagement.NewProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/easyUI/jquery.min.js"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../JS/easyUI/demo/demo.css" rel="stylesheet" />
    <script src="JS/NewProject.js"></script>
    <link href="CSS/NewProject.css" rel="stylesheet" />
</head>
<body style="background: #ECECEC;">
    <div id="DivArea">
        <div id="divTitle">
            <h2>新建项目</h2>
            <a id="projsubmit">提交</a>
            <%--<div style="float:left;width: 1000px; height: 20px; background-color: #40626E; border-radius: 5px"></div>--%>
        </div>
        <form id="fm_newProj" method="post" action="SubmitNewProject.ashx">
            <%-- 项目信息--%>
            <div id="DivProjInfo">
                <h2>项目基本信息</h2>
                <div id="spitbar"></div>
                <table id="t_projinfo">
                    <tr>
                        <td><span style="margin-left: 40px">项目名称:</span></td>
                        <td>
                            <input name="ProjName" class="easyui-validatebox textbox" data-options="required:true,validType:'length[2,10]'" style="width: 200px" /></td>
                    </tr>
                    <tr>
                        <td><span style="margin-left: 40px">项目类型:</span></td>
                        <td>
                            <select name="ProjTypeId" class="easyui-combobox" style="width: 200px">
                                <%=sbHtml %>
                            </select>
                        </td>
                    </tr>
<%--                    <tr>
                        <td><span style="margin-left: 40px">项目主管:</span></td>
                        <td>
                            <input type="hidden" name="ProjLeaderNum" value="2313" />
                            <input name="ProjLeader" class="easyui-validatebox textbox" data-options="required:true,validType:'length[2,10]'" style="width: 200px" />
                        </td>
                    </tr>--%>
                    <tr>
                            <td><span style="margin-left: 40px">项目主管:</span></td>
                            <td>
                                <select name="ProjLeaderNum" class="easyui-combobox" style="width:200px" id="Select1">
                                    <%--后台生成选项option--%>
                                    <%=leaderHtml %>
                                </select>
                                </td >
                        </tr>
                    <%--                <tr>
                    <td><span style="margin-left:40px">项目成员:</span></td>
                    <td>
                        <input type="hidden" name="ProjReceiverNum" value="123/234"/>
                        <input name="ProjReceiver" class="easyui-validatebox textbox" data-options="required:true,validType:'length[2,10]'" style="width:200px"/>
                    </td>
                </tr>--%>
                    <tr>
                        <td><span style="margin-left: 40px">立项时间:</span></td>
                        <td>
                            <input name="ProjStartTime" class="easyui-datetimebox" style="width: 200px" /></td>
                    </tr>
                    <tr>
                        <td><span style="margin-left: 40px">预计完成时间:</span></td>
                        <td>
                            <input name="ExFinishiTime" class="easyui-datetimebox" style="width: 200px" /></td>
                    </tr>
                    <tr>
                        <td><span style="margin-left: 40px">实际完成时间:</span></td>
                        <td>
                            <input name="AcFinishiTime" class="easyui-datetimebox" style="width: 200px" /></td>
                    </tr>
                    <%--                 <tr>
                    <td><span style="margin-left:40px">项目简介:</span></td>
                    <td><textarea name="ProjProfile" style="height:60px;width:200px"></textarea></td>
                </tr>--%>
                </table>
                <script>
                                           
                </script>
            </div>
            <%---------------------------------------------------项目成员---------------------------------------------%>
            <div id="projparti">
                <h2>项目成员</h2>
                 <input type="hidden" name="ProjReceiverNum"/> 
                 <textarea  name="ProjReceiver" id="showParti" readonly="true"></textarea>
            </div>


            <%---------------------------------------------------项目简介-------------------------------------------%>
            <div id="DivProfile">
                <h2>项目简介</h2>
                <textarea name="ProjProfile"></textarea>
            </div>

            <%--备注--%>
            <div id="DivProjMark">
                <h2>项目备注</h2>
                <textarea name="ProjMark"></textarea>
            </div>
        </form>
       
        
        
        <%-------------------------------------------------------选择项目成员---------------------------------------------------------------%>
        <div id="mcheckbox"  class="easyui-draggable" style="left:300px;top:100px; width:300px;height:350px;background-color:#ECECEC;position:absolute;display:none;border:1px solid #CCCCCC">
            <div style="width:300px;height:35px;background-color:#069DD5;padding-top:5px">
                <input type="checkbox" id="checkall" style="padding-left:0;margin-left:25px"/>
                <span style="margin-left:13px">学号</span>
                <span style="margin-left:125px">姓名</span>
            </div>
            <div style="width:300px;height:274px;overflow:scroll">
                <table style="margin:0;padding:0;border-collapse:collapse;width:250px;height:250px;margin-left:20px;">
                    <%=allMemberHtml %>
                    <tr><td><div style="height:250px;width:1px"></div></td></tr>
                </table>
                
            </div>
            <div style="width:300px;height:35px;background-color:white;top:300px;position:absolute">
                <button id="btnOK" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:60px">确定</button>
                <button id="btnCancel" style="border:1px solid #0D4F87;background:#1D6BAE;color:white;border-radius:3px;width:59px;height:33px;text-align:center;margin-left:70px">取消</button>
            </div>
        </div>
        <%--------------------------------------------------------------------------------------------------------------------------%>
    </div>
</body>
</html>
