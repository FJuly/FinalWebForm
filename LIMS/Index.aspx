<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LIMS.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="JS/easyUI/jquery.min.js" type="text/javascript"></script>
    <script src="JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="JS/index.js" type="text/javascript"></script>
    <link href="CSS/index.css" rel="stylesheet" type="text/css" />
    <title>网络与信息安全实验室</title>
    <script type="text/javascript">
        /*通知窗口滑动效果*/
        $(function () {
            $("#notice-title").bind('click', function () {
                $("#notice-window").slideToggle();
            })
        })
    </script>                                
</head>
<body class="easyui-layout" style="overflow-y: hidden">
    <noscript>
        <div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
            <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>

    <div region="north" class="nav-bg";split="false" border="false" style="overflow: hidden; height: 30px;
        background-repeat:repeat-x;background-position:center -361px;
        line-height: 20px;color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float:right; padding-right:20px;height:30px" class="head">
            <a href="#" id="editpass" >修改密码</a> 
            <a href="#" id="loginOut">安全退出</a>
        </span>
        <span style="padding-left:10px; font-size: 16px; font-family:'Microsoft YaHei';height:30px;margin-top:5px;display:inline-block">
            <img src="/images/blocks.gif" width="20" height="20" align="absmiddle" />
             网络与信息安全实验室
        </span>
        <span id="bgclock"></span>
        <a href="#" id="notice-title"><div class="nav-bg" style="width:22px;height:19px;margin-right:5px;background-position:-218px -171px;margin-top:9px;float:right"> </div> </a>
    </div>

    <div region="south" split="false" style="height:30px; background: #D2E0F2; ">
        <div class="footer">By 网络与信息安全实验室&nbsp;&nbsp;&nbsp;copy</div>
    </div>

    <div region="west" split="false" title="导航菜单" style="width: 180px;" id="west">
        <div class="easyui-accordion1" fit="true" border="false">
                <%--  导航内容 --%>
        </div>
    </div>

    <div id="mainPanle" region="center" style="background: #eee; overflow-y:hidden">
        <div id="tabs" class="easyui-tabs" fit="true" border="false" >
			<div title="欢迎使用" data-options="closable:false" style="padding:20px;overflow:hidden;" id="home">
                <h1>Welcome to using The  LIMS  !</h1>
            </div>
		</div>
    </div>                                                   
<%--    通知小窗口--%>
    <div id="notice-window">
      <a href="#" class="notice-a" style="text-decoration:none">
          <span>3</span>
          未读通知
      </a>
        <ul class="notice-ul">
<%--            控制字数--%>
            <a href="#"><li>英语作业没有做</li></a>
            <a href="#"><li>英语作业没有做</li></a>
            <a href="#"><li>英语作业没有做</li></a>
            <a href="#"><li>英语作业没有做</li></a>
            <a href="#"><li>英语作业没有做</li></a>
            <a href="#"><li>英语作业没有做</li></a>
            <a href="#"><li>英语作业没有做</li></a>
        </ul>
        <div class="notice-div">
            <a href="#">查看全部</a>
            <a href="#" style="margin-left:10px">忽略全部</a>
        </div>
    </div>

    <!--右键菜单-->
	<div id="mm" class="easyui-menu" style="width:150px;">
		<div id="mm-tabclose">关闭</div>
		<div id="mm-tabcloseall">全部关闭</div>
		<div id="mm-tabcloseother">除此之外全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-tabcloseright">当前页右侧全部关闭</div>
		<div id="mm-tabcloseleft">当前页左侧全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-exit">退出</div>
	</div>
</body>
</html>
