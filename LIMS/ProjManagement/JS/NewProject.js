//---------------------------王顺的js2014-10-18----------------------------
$(function () {
    $('#projsubmit').click(
        function () {
            window.alert("123");
            $("#fm_newProj").form('submit', {
                url: "SubmitNewProject.ashx",
                type: "POST",
                success: function (data) {
                    if (data == "Yes") {
                        alert("提交成功！");
                    }
                    else {
                        alert(data);
                    }
                }
            })
        });

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

    $('#btnCancel').click(
        function () {
            document.getElementById('mcheckbox').style.display = 'none';
        });

    $('#showParti').click(
        function () {
            document.getElementById('mcheckbox').style.display = 'block';
        });
});