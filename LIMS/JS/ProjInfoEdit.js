//---------------------------王顺的js2014-10-18----------------------------
$(function () {
    //保存编辑的项目信息
    $('#projSave').click(
        function () {
            var Issuccess = 0;

            $("#projFormInfo").form('submit', {
                url: "SaveProjInfo.ashx",
                type: "POST",
                success: function (data) {
                    if (data!= "No" && Issuccess == 1) {
                        //    Issuccess = 1;
                        alert("保存成功");
                        window.location.href = "ProjDetailInfo.aspx?ProjId=" + data + "";
                    }
                    else {
                        alert("修改失败！");
                    }
                }
            })

            $("#upload").form('submit', {
                url: "SaveProjPhoto.ashx",
                type: "POST",
                /*onSubmit事件中上传的文件类型进行检查，文件现在还不能检查*/
                onSubmit: function () {
                    for (var i = 0; i < 3; i++) {
                            if ($('#btnphoto' + i).attr("isClick") == "clicked") {
                            $("#btnphoto" + i.toString()).text("上传中");
                        }
                    }
                },
                success: function (data) {
                    if (data == "Yes") {
                        Issuccess = 1;
                   //     alert("上传成功");
                        $(".uploadimg").text("选择图片");
                    }
                    else {
                        alert(data);
                    }
                }
            })
            //window.alert("333333="+document.getElementById('btnphoto'+3).getAttribute("isClick"));
        });


    //选择复选框所有项
    $('#checkall').click(
        function () {
            var x = document.getElementsByName("checkbox");
            //alert(x[0].checked);
            if (document.getElementById('checkall').checked == true) {
                for (var i = 0; i < x.length; i++) {
                    x[i].checked = true;
                }
            } else {
                for (var i = 0; i < x.length; i++) {
                    x[i].checked = false;
                }
            }

        });


    //确定复选框选中的项
    $('#btnOK').click(
        function () {
            var ProjReceiverNum = "";
            var ProjReceiver = "";
            var index1 = "";
            var index2 = "";
            var flag = 0;
            var x = document.getElementsByName("checkbox");
            for (var i = 0; i < x.length; i++) {
                if (x[i].checked) {
                    flag++;
                    index1 = x[i].value;
                    index2 = document.getElementById("StuName" + i).outerText;
                    if (flag > 1) { 
                        index1 = "/" + index1;
                        index2 = "、" + index2;
                    }
                    ProjReceiverNum += index1;
                    ProjReceiver += index2;
                }
            }
            alert(ProjReceiverNum + ProjReceiver);
            document.getElementsByName("ProjReceiver")[0].value = ProjReceiver;
            document.getElementsByName("ProjReceiverNum")[0].value = ProjReceiverNum;
            alert(document.getElementsByName("ProjReceiverNum")[0].value);
            document.getElementById('mcheckbox').style.display = 'none';
        });

    //取消退出复选框
    $('#btnCancel').click(
        function () {
            document.getElementById('mcheckbox').style.display = 'none';
        });

    //弹出复选框
    $('#showParti').click(
        function () {
            document.getElementById('mcheckbox').style.display = 'block';
        });
});