/*------------------------------林志章-------------------------------------*/

function submitForm()
{
    var $actTitle = $("#act-title");
    var $actLStuName = $("#act-lstuname");
    var $actPStuName = $("#act-pstuname");
    var $actAddress = $("#act-address");
   // var $actTypeName = $("#act-typename");
    var $actTypeName = $("#act-type");
    var $actStartTime = $("#act-starttime");
    var $actEndTime = $("#act-endtime");
    var $actExpenses = $("#act-expenses");
    var $actContent = $("#act-content");
    var $actRemark = $("#act-remark");

    if($.trim($actTitle.val())=="")
    {
        alert("请填写活动标题！");
    }
    else if($.trim($actLStuName.val())=="")
    {
        alert("请选择活动负责人！");
    }
    else if ($.trim($actPStuName.val())=="")
    {
        alert("请选择活动发布人！");
    }
    else if ($.trim($actAddress.val())=="")
    {
        alert("请填写活动地点！");
    }
    else if ($.trim($actTypeName.val())=="")
    {
        alert("请选择活动类型！");
    }
    else if ($.trim($actStartTime.val())=="")
    {
        alert("请选择活动开始时间！");
    }
    else if ($.trim($actEndTime.val())=="")
    {
        alert("请选择活动结束时间！");
    }
    else if($.trim($actExpenses.val())=="")
    {
        alert("请填写活动开销！");
    }
    else if ($.trim($actContent.val()) == "") {
        alert("请填写活动内容！");
    }
    else {
        if (confirm("确认保存此活动的修改么？")) {
            $("#form-editact").submit();
        }
    }
}

//将下拉框中的活动类型设置为当前的类型
function setActType(acttypeid)
{
    //alert(acttypeid);
    //把select的value改成了acttypeid了
    $("#act-type").val(acttypeid);
    //将与传入的ID相匹配的option的select设置为selected
    $("#act-type").find("option[value='" + acttypeid + "']").attr("selected",true);
}

//选中所有复选框中成员
function Checkall()
{
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
}

//关闭复选框
function Cancel()
{
    document.getElementById('mcheckbox').style.display = 'none';
}

//打开复选框
function Choose()
{
    document.getElementById('mcheckbox').style.display = 'block';
}

//确认选中的成员
function btnOK()
{
    var txtActStuNum = "";
    var txtLStuName = "";
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
            txtActStuNum += index1;
            txtLStuName += index2;
        }
    }
    //alert(txtActStuNum + txtLStuName);
    document.getElementsByName("txtLStuName")[0].value = txtLStuName;
    document.getElementsByName("txtActStuNum")[0].value = txtActStuNum;
    //alert(document.getElementsByName("txtActStuNum")[0].value);
    document.getElementById('mcheckbox').style.display = 'none';
}

//$(function () {
   
//    $('#checkall').click(
//        function () {
//            var x = document.getElementsByName("checkbox");
//            //alert(x[0].checked);
//            if (document.getElementById('checkall').checked == true) {
//                for (var i = 0; i < x.length; i++) {
//                    x[i].checked = true;
//                }
//            } else {
//                for (var i = 0; i < x.length; i++) {
//                    x[i].checked = false;
//                }
//            }

//        });

//    $('#btnOK').click(
//        function () {
//            var ProjReceiverNum = "";
//            var ProjReceiver = "";
//            var index1 = "";
//            var index2 = "";
//            var flag = 0;
//            var x = document.getElementsByName("checkbox");
//            for (var i = 0; i < x.length; i++) {
//                if (x[i].checked) {
//                    flag++;
//                    index1 = x[i].value;
//                    index2 = document.getElementById("StuName" + i).outerText;
//                    if (flag > 1) {
//                        index1 = "/" + index1;
//                        index2 = "、" + index2;
//                    }
//                    ProjReceiverNum += index1;
//                    ProjReceiver += index2;
//                }
//            }
//            alert(ProjReceiverNum + ProjReceiver);
//            document.getElementsByName("ProjReceiver")[0].value = ProjReceiver;
//            document.getElementsByName("ProjReceiverNum")[0].value = ProjReceiverNum;
//            alert(document.getElementsByName("ProjReceiverNum")[0].value);
//            document.getElementById('mcheckbox').style.display = 'none';
//        });

//    $('#btnCancel').click(
//        function () {
//            document.getElementById('mcheckbox').style.display = 'none';
//        });

//    $('#act-lstuname').click(
//        function () {
//            document.getElementById('mcheckbox').style.display = 'block';
//        });
//});