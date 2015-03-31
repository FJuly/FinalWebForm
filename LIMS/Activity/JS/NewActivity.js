
/*------------------------------林志章-------------------------------------*/

function submitForm() {
    var $actTitle = $("#act-title");
    var $actLStuName = $("#act-lstuname");
    //var $actPStuName = $("#act-pstuname");
    var $actReceiver = $("#act-receiver");
    var $actAddress = $("#act-address");
    // var $actTypeName = $("#act-typename");
    var $actTypeName = $("#act-type");
    //var $actStartTime = $("#act-starttime");
    //var $actEndTime = $("#act-endtime");
    var $actExpenses = $("#act-expenses");
    var $actContent = $("#act-content");
    var $actRemark = $("#act-remark");

    //alert(document.getElementsByName("dtbActStartTime")[0].value);
    //alert(document.getElementsByName("dtbActEndTime")[0].value);

    if ($.trim($actTitle.val()) == "") {
        alert("请填写活动标题！");
    }
    else if ($.trim($actLStuName.val()) == "") {
        alert("请选择活动负责人！");
    }
    else if ($.trim($actReceiver.val()) == "") {
        alert("请选择活动参与人！");
    }
    else if ($.trim($actAddress.val()) == "") {
        alert("请填写活动地点！");
    }
    else if ($.trim($actTypeName.val()) == "") {
        alert("请选择活动类型！");
    }
    else if (document.getElementsByName("dtbActStartTime")[0].value == "") {
        alert("请选择活动开始时间！");
    }
    else if (document.getElementsByName("dtbActEndTime")[0].value == "") {
        alert("请填写活动结束时间！");
    }
    else if($.trim($actExpenses.val())==""){
        alert("请填写活动开销！");
    }
    else if ($.trim($actContent.val()) == "") {
        alert("请填写活动内容！");
    }
    else {
        if (confirm("确认新建此活动么？"))
        {
            $("#form-newact").submit();
        }
    }
}



//---------------------------------选择负责人------------------------------
//关闭复选框
function LSCancel() {
    document.getElementById('LScheckbox').style.display = 'none';
}

//打开复选框
function LSChoose() {
    document.getElementById('LScheckbox').style.display = 'block';
}

//确认选中的成员
function LSbtnOK() {
    var txtActStuNum = "";
    var txtLStuName = "";
    var index1 = "";
    var index2 = "";
    var flag = 0;
    var x = document.getElementsByName("LScheckbox");
    for (var i = 0; i < x.length; i++) {
        if (x[i].checked) {
            flag++;
            index1 = x[i].value;
            index2 = document.getElementById("StuName" + i).outerText;
            if (flag > 1) {
                index1 = "/" + index1;
                index2 = "、" + index2;
            }
            txtActStuNum += index1;
            txtLStuName += index2;
        }
    }
    //alert(txtActStuNum + txtLStuName);
    document.getElementsByName("txtLStuName")[0].value = txtLStuName;
    document.getElementsByName("txtActStuNum")[0].value = txtActStuNum;
    //alert(document.getElementsByName("txtActStuNum")[0].value);
    document.getElementById('LScheckbox').style.display = 'none';
}

//---------------------------------选择参与人------------------------------

//选中所有复选框中成员
function Checkall() {
    var x = document.getElementsByName("Reccheckbox");
    //alert(x[0].checked);
    if (document.getElementById('Reccheckall').checked == true) {
        for (var i = 0; i < x.length; i++) {
            x[i].checked = true;
        }
    } else {
        for (var i = 0; i < x.length; i++) {
            x[i].checked = false;
        }
    }
}

//关闭复选框
function RecCancel() {
    document.getElementById('Reccheckbox').style.display = 'none';
}

//打开复选框
function RecChoose() {
    document.getElementById('Reccheckbox').style.display = 'block';
}

//确认选中的成员
function RecbtnOK() {
    var txtReceiverNum = "";
    var txtReceiver = "";
    var index1 = "";
    var index2 = "";
    var flag = 0;
    var x = document.getElementsByName("Reccheckbox");
    for (var i = 0; i < x.length; i++) {
        if (x[i].checked) {
            flag++;
            index1 = x[i].value;
            index2 = document.getElementById("StuName" + i).outerText;
            if (flag > 1) {
                index1 = "/" + index1;
                index2 = "、" + index2;
            }
            txtReceiverNum += index1;
            txtReceiver += index2;
        }
    }
    //alert(txtReceiverNum + txtReceiver);
    document.getElementsByName("txtReceiver")[0].value = txtReceiver;
    document.getElementsByName("txtReceiverNum")[0].value = txtReceiverNum;
    //alert(document.getElementsByName("txtReceiverNum")[0].value);
    document.getElementById('Reccheckbox').style.display = 'none';
}


//---------------------------------选择发布人------------------------------
//关闭复选框
function PCancel() {
    document.getElementById('Pcheckbox').style.display = 'none';
}

//打开复选框
function PChoose() {
    document.getElementById('Pcheckbox').style.display = 'block';
}

//确认选中的成员
function PbtnOK() {
    var txtPStuNum = "";
    var txtPStuName = "";
    var index1 = "";
    var index2 = "";
    var flag = 0;
    var x = document.getElementsByName("Pcheckbox");
    for (var i = 0; i < x.length; i++) {
        if (x[i].checked) {
            flag++;
            index1 = x[i].value;
            index2 = document.getElementById("StuName" + i).outerText;
            if (flag > 1) {
                index1 = "/" + index1;
                index2 = "、" + index2;
            }
            txtPStuNum += index1;
            txtPStuName += index2;
        }
    }
    //alert(txtPStuNum + txtPStuName);
    document.getElementsByName("txtPStuName")[0].value = txtPStuName;
    document.getElementsByName("txtPStuNum")[0].value = txtPStuNum;
    //alert(document.getElementsByName("txtPStuNum")[0].value);
    document.getElementById('Pcheckbox').style.display = 'none';
}
