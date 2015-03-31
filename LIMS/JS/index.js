//界面加载完调用改方法
$(function () {
    InitLeftMenu();
    clockon();
	tabClose();
	tabCloseEven();
})
var _menus = {
    "menus": [
    {
        "menuid": "1", "icon": "icon-sys", "menuname": "人事管理",
        "menus": [
            { "menuid": "11", "menuname": "个人信息管理", "icon": "icon-users", "url": "PersonnelManagement/PersonInforManger.aspx" },
            { "menuid": "12", "menuname": "成员信息查看", "icon": "icon-users", "url": "PersonnelManagement/CheckMemberInfo.aspx" },
            { "menuid": "13", "menuname": "技术层次晋升", "icon": "icon-users", "url": "PersonnelManagement/MemberList.aspx" },
            { "menuid": "14", "menuname": "管理职位录入", "icon": "icon-users", "url": "PersonnelManagement/PositionManger.aspx" },
            { "menuid": "15", "menuname": "实习生晋升", "icon": "icon-users", "url": "demo.html" },
        ]
    },
    {
        "menuid": "2", "icon": "icon-sys", "menuname": "项目管理",
        "menus": [
            { "menuid": "21", "menuname": "项目查看", "icon": "icon-nav", "url": "ProjManagement/ProjView.aspx" },
            { "menuid": "22", "menuname": "项目发布", "icon": "icon-nav", "url": "ProjManagement/NewProject.aspx" }
        ]
    },
    {
        "menuid": "3", "icon": "icon-sys", "menuname": "任务管理",
        "menus": [
            { "menuid": "31", "menuname": "我的任务", "icon": "icon-nav", "url": "Task/MyTask.aspx" },
            { "menuid": "32", "menuname": "任务发布", "icon": "icon-nav", "url": "Task/TaskRelease.aspx" },
            { "menuid": "33", "menuname": "发布记录", "icon": "icon-nav", "url": "Task/ReleaseHistory.aspx" },
            { "menuid": "34", "menuname": "任务评价", "icon": "icon-nav", "url": "Task/TaskEvaluate.aspx" }
        ]
    },
    {
        "menuid": "4", "icon": "icon-sys", "menuname": "通知管理",
        "menus": [
            { "menuid": "41", "menuname": "我的通知", "icon": "icon-nav", "url": "NoticeManagement/NoticeList.aspx" },
            { "menuid": "42", "menuname": "发布通知", "icon": "icon-nav", "url": "NoticeManagement/Notice.aspx" },
        ]
    },
    {
        "menuid": "5", "icon": "icon-sys", "menuname": "活动管理",
        "menus": [
            { "menuid": "51", "menuname": "我的活动", "icon": "icon-nav", "url": "Activity/MyActivity.aspx" },
            { "menuid": "52", "menuname": "活动发布", "icon": "icon-nav", "url": "Activity/NewActivity.aspx" },
        ]
    },
    {
        "menuid": "6", "icon": "icon-sys", "menuname": "财务管理",
        "menus": [
        ]
    },
    {
        "menuid": "7", "icon": "icon-sys", "menuname": "注册管理",
        "menus": [
            { "menuid": "71", "menuname": "验证码生成", "icon": "icon-nav", "url": "demo1.html" },
        ]
    },
    {
        "menuid": "8", "icon": "icon-sys", "menuname": "系统设置",
                "menus": [
                ]
            },
    ]
};


//初始化左侧
function InitLeftMenu() {
    $(".easyui-accordion1").empty();//删除选中元素所有子节点
    var menulist = "";

    $.each(_menus.menus, function (i, n) {
        menulist += '<div title="' + n.menuname + '"  icon="' + n.icon + '" style="overflow:auto;">';
        menulist += '<ul>';
        $.each(n.menus, function (j, o) {
            menulist += '<li><div><a ref="' + o.menuid + '" href="#" rel="' + o.url + '" ><span class="icon ' + o.icon + '" >&nbsp;</span><span class="nav">' + o.menuname + '</span></a></div></li> ';
        })
        menulist += '</ul></div>';
    })

    $(".easyui-accordion1").append(menulist);
 
    
    $('.easyui-accordion1 li a').click(function () {
        var tabTitle = $(this).children('.nav').text();

        var url = $(this).attr("rel");
        var menuid = $(this).attr("ref");
        var icon = getIcon(menuid, icon);

        addTab(tabTitle, url, icon);
        $('.easyui-accordion1 li div').removeClass("selected");
        $(this).parent().addClass("selected");
    }).hover(function () {
        $(this).parent().addClass("hover");
    }, function () {
        $(this).parent().removeClass("hover");
    });

    //导航菜单绑定初始化
    $(".easyui-accordion1").accordion();
}

//获取左侧导航的图标
function getIcon(menuid){
	var icon = 'icon';
	$.each(_menus.menus, function(i, n) {
		 $.each(n.menus, function(j, o) {
		 	if(o.menuid==menuid){
				icon += o.icon;
			}
		 })
	})
	
	return icon;
}

function addTab(subtitle, url, icon) {
    /*如果先前存在则删除*/
    if ($('#tabs').tabs('exists', subtitle))
    {
        $('#tabs').tabs('close', subtitle);
    }
		$('#tabs').tabs('add',{
			title:subtitle,
			content:createFrame(url),
			closable:true,
			icon:icon
		});
		var $tab = $('#tabs').tabs('getTab', subtitle);
		$tab.css("overflow-y","hidden");
	tabClose();
}

function createFrame(url)
{
	var s = '<iframe scrolling="auto" frameborder="0"  src="'+url+'" style="width:100%;height:100%;"></iframe>';
	return s;
}

function tabClose()
{
	/*双击关闭TAB选项卡*/
	$(".tabs-inner").dblclick(function(){
		var subtitle = $(this).children(".tabs-closable").text();
		$('#tabs').tabs('close',subtitle);
	})
	/*为选项卡绑定右键*/
	$(".tabs-inner").bind('contextmenu',function(e){
		$('#mm').menu('show', {
			left: e.pageX,
			top: e.pageY
		});
		
		var subtitle =$(this).children(".tabs-closable").text();
		
		$('#mm').data("currtab",subtitle);
		$('#tabs').tabs('select',subtitle);
		return false;
	});
}
//绑定右键菜单事件
function tabCloseEven()
{
	//关闭当前
	$('#mm-tabclose').click(function(){
		var currtab_title = $('#mm').data("currtab");
		$('#tabs').tabs('close',currtab_title);
	})
	//全部关闭
	$('#mm-tabcloseall').click(function(){
		$('.tabs-inner span').each(function(i,n){
			var t = $(n).text();
			$('#tabs').tabs('close',t);
		});	
	});
	//关闭除当前之外的TAB
	$('#mm-tabcloseother').click(function(){
		var currtab_title = $('#mm').data("currtab");
		$('.tabs-inner span').each(function(i,n){
			var t = $(n).text();
			if(t!=currtab_title)
				$('#tabs').tabs('close',t);
		});	
	});
	//关闭当前右侧的TAB
	$('#mm-tabcloseright').click(function(){
		var nextall = $('.tabs-selected').nextAll();
		if(nextall.length==0){
			//msgShow('系统提示','后边没有啦~~','error');
			alert('后边没有啦~~');
			return false;
		}
		nextall.each(function(i,n){
			var t=$('a:eq(0) span',$(n)).text();
			$('#tabs').tabs('close',t);
		});
		return false;
	});
	//关闭当前左侧的TAB
	$('#mm-tabcloseleft').click(function(){
		var prevall = $('.tabs-selected').prevAll();
		if(prevall.length==0){
			alert('到头了，前边没有啦~~');
			return false;
		}
		prevall.each(function(i,n){
			var t=$('a:eq(0) span',$(n)).text();
			$('#tabs').tabs('close',t);
		});
		return false;
	});

	//退出
	$("#mm-exit").click(function(){
		$('#mm').menu('hide');
	})
}

//弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
function msgShow(title, msgString, msgType) {
	$.messager.alert(title, msgString, msgType);
}

//本地时钟
function clockon() {
    var now = new Date();
    var year = now.getFullYear(); //getFullYear getYear
    var month = now.getMonth();
    var date = now.getDate();
    var day = now.getDay();
    var hour = now.getHours();
    var minu = now.getMinutes();
    var sec = now.getSeconds();
    var week;
    month = month + 1;
    if (month < 10) month = "0" + month;
    if (date < 10) date = "0" + date;
    if (hour < 10) hour = "0" + hour;
    if (minu < 10) minu = "0" + minu;
    if (sec < 10) sec = "0" + sec;
    var arr_week = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");
    week = arr_week[day];
    var time = "";
    time = year + "年" + month + "月" + date + "日" + " " + hour + ":" + minu + ":" + sec + " " + week;

    $("#bgclock").html(time);

    var timer = setTimeout("clockon()", 1000);
}
