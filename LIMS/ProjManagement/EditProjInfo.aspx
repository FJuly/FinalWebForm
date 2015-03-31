<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProjInfo.aspx.cs" Inherits="LIMS.ProjManagement.EditProjInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>   
    <script src="../JS/easyUI/jquery.min.js"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/default/easyui.css" rel="stylesheet" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../JS/easyUI/demo/demo.css" rel="stylesheet" />
    <script src="JS/ProjInfoEdit.js" type="text/javascript"></script>
    <link href="CSS/ProjInfo.css" rel="stylesheet" />
</head>
<body>
    <%------------------------------主窗体--------------------------------%>
       
    <div style="width:1000px;margin-left:auto; margin-right:auto; position:relative">
        

        <%-------------------------项目保存-------------------------------%>
        <div style="background-color:white;width:1000px;height:35px;text-align:left;margin-bottom:10px;border-radius:3px;">
            <div style="font-size:larger;padding-top:5px;padding-left:5px;font-family:宋体;float:left;font-weight:600">
                <h2>项目详情</h2>
            </div>
            <a id="projSave">保存</a>
        </div>
        <%-----------------------上传项目截图-----------------------------%>
        <form method="post" enctype="multipart/form-data" id="upload">
        <div id="editprojphoto">
            <table id="t_projphoto">
                <tr id="t_img">
                    <td>
                        <div>
                            <input type="hidden" name="ProjPhoto1" value="<%=ProjPhotoList[0].ProjPhotoId %>"/>
                            <img id="projimg1" src="<%=ProjPhotoList[0].ProjPhotoPath %>" />
                        </div>
                    </td>
                    <td>
                        <div>
                            <input type="hidden" name="ProjPhoto2" value="<%=ProjPhotoList[1].ProjPhotoId %>"/>
                            <img id="projimg2" src="<%=ProjPhotoList[1].ProjPhotoPath %>" />
                        </div>
                    </td>
                    <td>
                        <div>
                            <input type="hidden" name="ProjPhoto3" value="<%=ProjPhotoList[2].ProjPhotoId %>"/>
                            <img id="projimg3" src="<%=ProjPhotoList[2].ProjPhotoPath %>" />
                        </div>
                    </td>
                </tr>
                <tr id="t_upload">
                    <td>
                        <input id="photo1" name="photo1" type="file" onchange="handleFiles(this,'projimg1','btnphoto1')"/>
                        <button class="uploadimg" id="btnphoto1" isClick="unclicked">选择图片</button>
                    </td>
                    <td>
                        <input id="photo2" name="photo2" type="file" onchange="handleFiles(this,'projimg2','btnphoto2')"/>
                        <button class="uploadimg" id="btnphoto2" isClick="unclicked">选择图片</button>
                    </td>
                    <td>
                        <input id="photo3" name="photo3" type="file" onchange="handleFiles(this,'projimg3','btnphoto3')"/>
                        <button class="uploadimg" id="btnphoto3" isClick="unclicked">选择图片</button>
                    </td>
                </tr>
            </table>
        </div>
        </form>
        <%-------------------项目详细信息表单-----------------------------%>
        <form id="projFormInfo" action="SaveProjInfo.ashx" method="post">
            <%--项目基本信息--%>
            <div style="width:400px;height:270px;float:left;border:1px solid white;margin-top:20px;background-color:white">
                 <h2>项目基本信息</h2>
                <div style="width:380px;height:2px;background-color:#C3C3C3;float:left;"></div>
                <div id="e_projbaseinfo">
                    <table style="margin:0px;padding:0px;border-collapse:collapse;width:365px;height:214px;margin-left:10px">
                        <tr>
                            <td><span>项目名称：</span></td>
                            <td>
                                <input type="hidden" name="ProjId" value="<%=ProjDetailList[0].ProjId %>"/>
                                <input name="ProjName" class="easyui-validatebox textbox" value="<%=ProjDetailList[0].ProjName %>" data-options="required:true,validType:'length[2,10]'"/>
                            </td >
                        </tr>
                        <tr>
                            <td><span>项目类型：</span></td>
                            <td>
                                <select name="ProjTypeId" class="easyui-combobox" style="width:202px" id="ProjTypeId">
                                    <%--后台生成选项option--%>
                                    <%=sbHtml %>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td><span>项目主管：</span></td>
                            <td>
                                <select name="ProjLeaderNum" class="easyui-combobox" style="width:202px" id="Select1">
                                    <%--后台生成选项option--%>
                                    <%=leaderHtml %>
                                </select>
                                </td >
                        </tr>
<%--                        <tr>
                            <td><span>项目成员：</span></td>
                            <td>--%>
                                <%--receiverHtml --%>
<%--                                <input type="hidden" name="ProjReceiverNum" value="<%=ProjParticipationNum %>"/> 
                                <input name="ProjReceiver" readonly="true" id="showParti" class="easyui-validatebox textbox" value="<%=ProjParticipation %>" data-options="required:true,validType:'length[2,18]'"/>
                            </td>
                        </tr>--%>
                        <tr>
                            <td><span>项目发布人：</span></td>
                            <td>
                                <input type="hidden" name="ProjPublisherNum" value="<%=ProjDetailList[0].ProjPublisherNum %>"/>
                                <input name="ProjPublisher" class="easyui-validatebox textbox" value="<%=ProjDetailList[0].ProjPublisher %>" data-options="required:true,validType:'length[2,10]'"/></td >
                        </tr>
                         <tr>
                            <td><span>立&nbsp&nbsp项&nbsp&nbsp时&nbsp&nbsp间&nbsp：</span></td>
                            <td><input name="ProjStartTime" class="easyui-datetimebox" value="<%=ProjStartTime %>" required="required" style="width:203px"/></td>
                        </tr>
                        <tr>
                            <td><span>预定完成时间：</span></td>
                            <td><input name="ExFinishiTime" class="easyui-datetimebox" value="<%=ExFinishiTime %>" required="required" style="width:203px;"/></td>
                        </tr>
                        <tr>
                            <td><span>实际完成时间：</span></td>
                            <td><input name="AcFinishiTime" class="easyui-datetimebox" value="<%=AcFinishiTime %>" required="required" style="width:203px"/></td>
                        </tr>
                    </table>
                    <script>
                                           
                    </script>                        
                </div>
            </div>

            <%--项目成员--%>
            <div id ="e_projreceive">
                <h2>项目成员</h2>
                 <input type="hidden" name="ProjReceiverNum" value="<%=ProjParticipationNum %>"/> 
                 <textarea  name="ProjReceiver" readonly="true" id="showParti"><%=ProjParticipation %></textarea>
            </div>
            <%--项目简介--%>
            <div id="e_projprofile">
                <h2>项目简介</h2>
                <textarea name="ProjProfile"><%=ProjDetailList[0].ProjProfile %></textarea>
            </div>

            <%--项目备注--%>
            <div id="e_projmark">
                <h2>备注</h2>
                <textarea name="ProjMark"><%=ProjDetailList[0].ProjMark %></textarea>
            </div>
        </form>

        <%-------------------------选项目成员的div----------------------------%>
        <div id="mcheckbox" class="easyui-draggable" style="left:424px;top:500px; width:300px;height:350px;background-color:#ECECEC;position:absolute;display:none;border:1px solid #CCCCCC">
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
    </div>

    

    <%--------------------------预览照片js代码----------------------------%>
    <script>
        function handleFiles(obj, imgid,btn) {
            //标记哪个btn被按了
            document.getElementById(btn).setAttribute("isClick", "clicked");

            window.URL = window.URL || window.webkitURL;
            var fileElem = document.getElementById("fileElem"),
            fileList = document.getElementById("fileList");
            var files = obj.files,
                img = new Image();
            if (window.URL) {
                //File API
                //alert(files[0].name + "," + files[0].size + " bytes");
                img.src = window.URL.createObjectURL(files[0]); //创建一个object URL，并不是你的本地路径
                $("#"+imgid).attr({ "src": img.src });
                img.width = 200;
                img.onload = function (e) {
                    window.URL.revokeObjectURL(this.src); //图片加载后，释放object URL
                }
                //fileList.appendChild(img);
            } else if (window.FileReader) {
                //opera不支持createObjectURL/revokeObjectURL方法。我们用FileReader对象来处理
                var reader = new FileReader();
                reader.readAsDataURL(files[0]);
                reader.onload = function (e) {
                    alert(files[0].name + "," + e.total + " bytes");
                    img.src = this.result;
                    $("#" + imgid).attr({ "src": img.src });
                    img.width = 200;
                    //fileList.appendChild(img);
                }
            } else {
                //ie
                obj.select();
                obj.blur();
                var nfile = document.selection.createRange().text;
                document.selection.empty();
                img.src = nfile;
                $("#" + imgid).attr({ "src": img.src });
                img.width = 200;
                img.onload = function () {
                    alert(nfile + "," + img.fileSize + " bytes");
                }
                //fileList.appendChild(img);
                //fileList.style.filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod='image',src='"+nfile+"')";
            }
            
            
        }
</script>
</body>
</html>
