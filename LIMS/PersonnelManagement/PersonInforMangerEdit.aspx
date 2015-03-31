<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonInforMangerEdit.aspx.cs" Inherits="LIMS.PersonnelManagement.PersonInforMangerEdit" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../JS/easyUI/jquery.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="CSS/PersonInforMangerEdit.css"/>
<script type="text/javascript" charset="utf-8">

    $(function () {
        $("#save").click(function () {
            /*使用easyui里面表单提交方法*/
            $("#formInfor").form('submit', {
                url: "PersonInforMangerEdit.aspx",
                onSubmit: function () {
                    var isValid = $(this).form('validate');
                    if (isValid)
                        return true;
                    else
                        return false;
                },
                success:function(data){
                    alert(data)
                }
            });
        })
    });

    //$(function () {
    //    $("#fileupload").change(function () {
    //        $("#upload").form('submit', {
    //            url: "photo.ashx",
    //            type: "POST",
    //            dataType: "json",
    //            /*onSubmit事件中上传的文件类型进行检查，文件现在还不能检查*/
    //            onSubmit: function () {
    //                file = $("#fileupload").val();
    //                if (!/.(gif|jpg|jpeg|png|gif|jpg|png)$/.test(file)) {
    //                    alert("图片类型必须是.gif,jpeg,jpg,png中的一种")
    //                    return false;
    //                }
    //                else {
    //                    $("#button").text("上传中..");
    //                }
    //            },
    //            success: function (data) {
    //                data = eval("(" + data + ")");
    //                if (data[0].success == "yes") {
    //                    alert("修改成功");
    //                    $("#p-img").attr("src", data[1].filename);
    //                    $("#button").html("上传头像");
    //                    $("#mask").hide(0);
    //                    $("#divphoto").hide(0);
    //                }
    //                else {
    //                    alert(data[0].success);
    //                    $("#button").html("上传头像");
    //                }
    //            }
    //        })
    //    });
    //});

    $(function () {
        $("#a-photo").click(function () {
            $("#mask").show(0);
            $("#divphoto").show(0);
        });

    });

    $(function () {
        $(".btnOk").click(function () {
            $("#upload").form('submit', {
                url: "photo.ashx",
                type: "POST",
                dataType: "json",
                /*onSubmit事件中上传的文件类型进行检查，文件现在还不能检查*/
                onSubmit: function () {
                    file = $("#fileupload").val();
                    if (!/.(gif|jpg|jpeg|png|gif|jpg|png)$/.test(file)) {
                        alert("图片类型必须是.gif,jpeg,jpg,png中的一种")
                        return false;
                    }
                    else {
                        $("#button").text("上传中..");
                    }
                },
                success: function (data) {
                    data = eval("(" + data + ")");
                    if (data[0].success == "yes") {
                        alert("修改成功");
                        $("#p-img").attr("src", data[1].filename);
                        $("#button").html("上传头像");
                        $("#mask").hide(0);
                        $("#divphoto").hide(0);
                    }
                    else {
                        alert(data[0].success);
                        $("#button").html("上传头像");
                    }
                }
            })
        })
    });
     //检查textarea输入字数
    function textdown(e) {
        textevent = e;
        if (textevent.keyCode == 8) {
            return;
        }
        if (document.getElementById('text').value.length >= 200) {
            alert("最多输入200个字")
            if (!document.all) {
                textevent.preventDefault();
            }
            else {
                textevent.returnValue = false;
            }
        }
    };
    function textup() {
        var s = document.getElementById('text').value;
        //判断ID为text的文本区域字数是否超过1000个   
        if (s.length > 30) {
            document.getElementById('text').value = s.substring(0, 200);
        }
    };

    /*htm5实现图片本地预览，js代码*/
    function preImg(sourceId, targetId) {
        if (typeof FileReader === 'undefined') {
            alert('你的浏览器不支持...');
            return;
        }
        var reader = new FileReader();

        reader.onload = function (e) {
            var img = document.getElementById(targetId);
            img.src = this.result;
        }
        reader.readAsDataURL(document.getElementById(sourceId).files[0]);
    }

    /*获得焦点事件*/
    $(function () {
        $("#mask").click(function () {
            $("#mask").hide(0);
            $("#divphoto").hide(0);
        })
    })
</script>

</head>
<body>
<div id="mask" class="mask" tabindex="0"></div>
        <%-- 修改头像的html代码--%>
<div class="divphoto center"  style="opacity:1;display:none" id="divphoto">
    <div class="divphoto-one">
        <h3 class="title-h3">当前照片</h3>
        <div>
           <img src="<%=member.PhotoPath %>" class="imag" id="update-photo-img"/>
        </div>
    </div>
    <div class="divleft-set">
        <h3 class="title-h3">设置新照片</h3>
        <div class="div-tip">使用真实姓名，上传真实头像，图片尺寸最好为***</div>
        <button class="button" id="button">上传照片</button>
        <button class="btnOk" id="btnOk">确定</button>
<%--        提交头像的表单--%>
<form method="post" enctype="multipart/form-data" id="upload">
        <input type="file" id="fileupload" name="photo" onchange="preImg(this.id,'update-photo-img')"/>
</form>
    </div>
</div>



<div id="nav">
<div class="divtitle divtitleone">
    <span>个人资料</span>
    <button id="save">保存</button>
</div>
<form action="PersonInforMangerEdit.aspx" method="post" id="formInfor">
<input type="hidden" name="IsPostBack" value="true"/>
<div class="div-center">
    <div class="divtitle">   
        <span>基本信息</span>
    </div>
    <ul class="ul-nav">
        <li>
            <span class="ul-span">姓名:</span>
            <div class="divtxtbox"><input name="StuName" class="easyui-validatebox textbox" required="required" value="<%=member.StuName %>"/></div>
        </li>
        <li>
            <span class="ul-span">性别:</span>
            <div class="divtxtbox"><input name="Gender" class="easyui-validatebox textbox" required="required" value="<%=member.Gender %>"/></div>
        </li>
        <li>
            <span class="ul-span">QQ:</span>
            <div class="divtxtbox"><input name="QQNum" class="easyui-validatebox textbox" required="required" value="<%=member.QQNum %>" /></div>
        </li>
        <li>
            <span class="ul-span">邮箱:</span>
            <div class="divtxtbox"><input name="Email" class="easyui-validatebox textbox" validType="email";required="required" value="<%=member.Email %>" /></div>
        </li>
        <li>
            <span class="ul-span">登陆密码:</span>
            <div class="divtxtbox"><input name="LoginPwd" class="easyui-validatebox textbox" required="required" value="<%=member.LoginPwd %>" /></div>
        </li>
        <li>
            <span class="ul-span">生日:</span>
            <div class="divtxtbox"><input name="Birthday" class="easyui-datebox" required="required" value="<%=member.Birthday.ToString("yyyy年MM月dd日") %>"/></div>
        </li>
        <li>
            <span class="ul-span">班级:</span>
            <div class="divtxtbox"><input name="Class" class="easyui-validatebox textbox" required="required" value="<%=member.Class %>" /></div>
        </li>
        <li>
            <span class="ul-span">专业:</span>
            <div class="divtxtbox"><input name="Major" class="easyui-validatebox textbox" required="required" value="<%=member.Major %>" /></div>
        </li>
        <li>
            <span class="ul-span">辅导员:</span>
            <div class="divtxtbox"><input name="Counselor" class="easyui-validatebox textbox" required="required" value="<%=member.Counselor %>" /></div>
        </li>
        <li>
            <span class="ul-span">班主任:</span>
            <div class="divtxtbox"><input name="HeadTeacher" class="easyui-validatebox textbox" required="required" value="<%=member.HeadTeacher %>" /></div>
        </li>
        <li>
            <span class="ul-span">本科生导师:</span>
            <div class="divtxtbox"><input name="UndergraduateTutor" class="easyui-validatebox textbox" required="required" value="<%=member.UndergraduateTutor %>" /></div>
        </li>
        <li>
            <span class="ul-span">联系方式:</span>
            <div class="divtxtbox"><input name="TelephoneNumber" class="easyui-validatebox textbox" required="required" value="<%=member.TelephoneNumber %>" /></div>
        </li>
        <li>
            <span class="ul-span">家庭联系电话:</span>
            <div class="divtxtbox"><input name="HomPhoneNumber"class="easyui-validatebox textbox" required="required" value="<%=member.HomPhoneNumber %>" /></div>
        </li>
        <li>
            <span class="ul-span">家庭住址:</span>
            <div class="divtxtbox"><input name="FamilyAddress" class="easyui-validatebox textbox" required="required" value="<%=member.FamilyAddress %>" /></div>
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
            <span><%=duty %></span>
        </li>
    </ul>
    </div>

    <div class="divleftone" style="border-collapse:collapse">
    <div class="divtitle">   
        <span>个人简介</span>
    </div>
        <div id="divguide">
            <a href="#" id="a-photo"><img src="<%=member.PhotoPath %>" id="p-img" style="width:100%;height:100%;border:none" /></a>
        </div>
        <div id="divintro">
            <textarea id="text" onKeyDown="textdown(event)" onKeyUp="textup()">个人简介：</textarea>
        </div>
    </div>
</form>
</div>



</body>
</html>