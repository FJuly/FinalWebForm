<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjDetailInfo.aspx.cs" Inherits="LIMS.ProjManagement.ProjDetailInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="CSS/ProjInfo.css" rel="stylesheet" />
    <script src="../JS/easyUI/jquery.min.js"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/default/easyui.css" rel="stylesheet" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../JS/easyUI/demo/demo.css" rel="stylesheet" />
    <script src="../JS/easyUI/datagrid-groupview.js"></script>
    <script src="JS/ProjDetailInfo.js" type="text/javascript"></script>

</head>
<body>
    <div style="width:1000px;margin-left:auto; margin-right:auto;">
        <%------项目编辑-----%>
        <div id="DivEdit">
            <div id="divEditTitle">
                <h2>项目详情</h2>
            </div>
            <div id="divEdit"><a id="projEdit" projid="<%=projId %>">编辑</a></div>
        </div>

        <%------项目截图-----%>
        <%--<div style="width:1000px;height:350px; float:left;background-color:white;position:relative;">
            <div id="turnLeft"><img src="../Images/btn-prev.png" alt="&gt;"/></div>
            <div id="turnRight"><img src="../Images/btn-next.png" alt="&gt;" /></div>
            <div id="leftdiv">
                <img id="leftimg" src="<%=ProjPhotoList[0].ProjPhotoPath %>" />
            </div>
            <div id="rightdiv">
                <img id="rightimg" src="<%=ProjPhotoList[1].ProjPhotoPath %>" />
            </div>
            <div id="middiv">
                <img id="midimg" src="<%=ProjPhotoList[2].ProjPhotoPath %>" />
            </div>
        </div>--%>
        
        <%----项目基本信息---%>
        <div id="DivProjInfo">
             <h2>项目基本信息</h2>
            <div id="divprojinfo"></div>
            <div id="projbaseinfo">
                <table id="projtable">
                    <tr>
                        <td><span>项目名称：</span></td>
                        <td><input type="text" readonly="true" value="<%=ProjDetailList[0].ProjName %>"/></td>
                    </tr>
                    <tr>
                        <td><span>项目类型：</span></td>
                        <td><input type="text" id="ProjType" readonly="true" value="<%=ProjDetailList[0].ProjTypeName %>"/></td>
                    </tr>
                    <tr>
                        <td><span>项目主管：</span></td>
                        <td><input type="text" readonly="true" value="<%=ProjDetailList[0].ProjLeader %>"/></td>
                    </tr>
<%--                    <tr>                          
                        <td><span>项目成员：</span></td>
                        <td><input type="text" readonly="true" value="<%=ProjParticipation %>"/></td>
                    </tr>--%>
                    <tr>
                        <td><span>项目发布人：</span></td>
                        <td><input type="text" readonly="true" value="<%=ProjDetailList[0].ProjPublisher %>"/></td>
                    </tr>
                    <tr>
                        <td><span>立&nbsp&nbsp项&nbsp&nbsp时&nbsp&nbsp间：</span></td>
                        <td><input type="text"  readonly="true" value="<%=ProjDetailList[0].ProjStartTime %>"/></td>
                    </tr>
                    <tr>
                        <td><span>预定完成时间：</span></td>
                        <td><input type="text" readonly="true" value="<%=ProjDetailList[0].ExFinishiTime %>"/></td>
                    </tr>
                    <tr>
                        <td><span>实际完成时间：</span></td>
                        <td><input type="text" readonly="true" value="<%=ProjDetailList[0].AcFinishiTime %>"/></td>
                    </tr>
                </table>
                </div>
        </div>

        <%-----项目成员------%>
        <div id ="v_projreceive">
            <h2>项目成员</h2>
            <textarea  name="ProjReceiver" readonly="true" id="showParti"><%=ProjParticipation %></textarea>
        </div>

        <%-----项目简介------%>
        <div id="projprofile">
            <h2>项目简介</h2>
            <textarea readonly="true"><%=ProjDetailList[0].ProjProfile %></textarea>
        </div>

        <%-----项目备注------%>
        <div id="projmark">
            <h2>备注</h2>
            <textarea readonly="true"><%=ProjDetailList[0].ProjMark %></textarea>
        </div>   

        <%----项目进度表-----%>
        <div id="t_projplan">
          <table class="easyui-datagrid" title="项目进度" style="width:998px;height:250px;"
            data-options="
                url:'GetProjectPlan.ashx',
                singleSelect:true,
                collapsible:true,
                rownumbers:true,
                fitColumns:true,
                view:groupview,
                groupField:'ProjPhase',
                groupFormatter:function(value,rows){
                    return value + ' - ' + rows.length + ' Item(s)';
                }
            ">
        <thead>
            <tr>
                <th data-options="field:'TaskName',width:50">项目任务</th>
                <th data-options="field:'TaskBegTime',width:50">开始时间</th>
                <th data-options="field:'TaskEndTime',width:50">结束时间</th>
                <th data-options="field:'TaskReceiver',width:50">执行人员</th>
                <%--<th data-options="field:'status',width:50,align:'center'">Status</th>--%>
            </tr>
        </thead>
    </table>
    <script type="text/javascript">
    </script> 
       </div> 

            <%-------项目截图-------------%>
        <div id="projphoto">
            <div>
                <img src="<%=ProjPhotoList[0].ProjPhotoPath %>"/>
            </div>
            <div>
                <img src="<%=ProjPhotoList[1].ProjPhotoPath %>"/>
            </div>
            <div>
                <img src="<%=ProjPhotoList[2].ProjPhotoPath %>"/>
            </div>
        </div>

        <%------弹出项目截图表-----%>
        <div id="showphoto">
            <h2>项目截图</h2>
            <div id="showphotoicon"></div>
            <%--<img id="showphotoicon" src="../JS/easyUI/themes/gray/images/accordion_arrows.png" />--%>
        </div>



    </div>
    
    <!--js控制界面元素-->
    <script type="text/javascript">
        $(function () {
            JudgPermissions();
        });


        //界面权限控制
        function JudgPermissions() {
            <%=aaa%> 
            if (document.getElementById("ProjType").value == "个人项目") {
                if (!isperson) {
                    document.getElementById("divEdit").style.display = 'none';
                }
            }
            else if (document.getElementById("ProjType").value.toString() == "作品项目") {
                if (!iswork) {
                    document.getElementById("divEdit").style.display = 'none';
                }
            }
            else if (document.getElementById("ProjType").value == "企业项目") {
                if (!isenterprise) {
                    document.getElementById("divEdit").style.display = 'none';
                }
            }
            else {
                console.log("系统错误");
            }
        }
    </script>
</body>
</html>
