//---------------------------王顺的js2014-10-18----------------------------
$(function () {
    //点击向左按键
    //$("#turnLeft img").click(
    //    function () {
    //        //            alert("点击了左边");  
    //        $("#leftimg").animate({
    //            left: '650px',
    //            top: '50px',
    //            height: '250px',
    //            width: '150px'
    //        });
    //        $("#midimg").animate({
    //            left: '200px',
    //            top: '50px',
    //            height: '250px',
    //            width: '150px'
    //        });
    //        $("#rightimg").animate({
    //            left: '350px',
    //            top: '35px',
    //            height: '300px',
    //            width: '300px'
    //        });
    //        $("#leftimg").attr("id", "a");
    //        $("#midimg").attr("id", "leftimg");
    //        $("#rightimg").attr("id", "midimg");
    //        $("#a").attr("id", "rightimg");
    //    });
    ////点击向右按键
    //$('#turnRight img').click(
    //    function () {
    //        $("#leftimg").animate({
    //            left: '350px',
    //            top: '35px',
    //            height: '300px',
    //            width: '300px'
    //        });
    //        $("#rightimg").animate({
    //            left: '200px',
    //            top: '50px',
    //            height: '250px',
    //            width: '150px'
    //        });
    //        $("#midimg").animate({
    //            left: '650px',
    //            top: '50px',
    //            height: '250px',
    //            width: '150px'
    //        });
    //        $("#leftimg").attr("id", "a");
    //        $("#rightimg").attr("id", "leftimg");
    //        $("#midimg").attr("id", "rightimg");
    //        $("#a").attr("id", "midimg");
    //    });



    //点击展开或收起项目截图
    $('#showphotoicon').click(
        function () {
            //如果项目截图是隐藏的
            if (document.getElementById('projphoto').style.display == 'none' || document.getElementById('projphoto').style.display == '') {
                //显示表格
                $('#projphoto').show(2000);
                $('#showphotoicon').css({ "backgroundPosition": "left top" });
            }
                //如果项目截图是显示的，则隐藏表
            else {
                $('#projphoto').hide(2000);
                $('#showphotoicon').css({ "backgroundPosition": "right top" });
            }
        });
    //点击编辑跳到编辑项目信息页面
    $('#projEdit').click(
        function () {
            var str = document.getElementById('projEdit').getAttribute('projid');
            window.alert("ProjId="+document.getElementById('projEdit').getAttribute('projid'));       
            window.location = "EditProjInfo.aspx?ProjId=" + str + "";
        });

})

