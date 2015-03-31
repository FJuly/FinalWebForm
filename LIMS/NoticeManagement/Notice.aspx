<%@ Page validateRequest="false"  Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="LIMS.NoticeManagement.Notice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>通知</title>
<%--    百度富文本编辑器引入的外部文件--%>
    <!-- 样式文件 -->
    <link rel="stylesheet" href="../umeditor/themes/default/css/umeditor.css"/>
    <!-- 引用jquery -->
    <script src="../umeditor/third-party/jquery.min.js"></script>
    <!-- 配置文件 -->
    <script type="text/javascript" src="../umeditor/umeditor.config.js"></script>
    <!-- 编辑器源码文件 -->
    <script type="text/javascript" src="../umeditor/umeditor.js"></script>
    <!-- 语言包文件 -->
    <script type="text/javascript" src="../umeditor/lang/zh-cn/zh-cn.js"></script>

<%--    easyui引用的外部文件--%>
    <script src="../JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>    
<%--    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>--%>
    <link href="../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="CSS/Notice.css"/>


    <script type="text/javascript">
        $(function () {
            window.um = UM.getEditor('container-edtior', {
                /* 传入配置参数,可配参数列表看umeditor.config.js */
            });
        });


        //全局变量，准备传递到后接收通知人的学号
        var str = "";
        $(function () {
            $('#ss').searchbox({
                searcher: function (value, name) {
                    alert(value + "," + name)
                },
                //menu: '#mm',
                prompt: '按姓名搜索'
            });
        })

        $(function () {
            $("#aa").accordion({
                onSelect: function () {
                    //取得相应展开的条目的数据
                    var p = $('#aa').accordion('getSelected'); //取得展开的panel
                    if (p) {
                        var index = $('#aa').accordion('getPanelIndex', p);//获得panel的索引
                        //传回的是json数据
                        $.get("NoticeSelect.ashx?selectId="+index, function (data) {
                            obj = $.parseJSON(data);
                            //在生成数据之前删除所有的行
                            $("#tb").empty();
                            //生成表行数据
                            $.each(obj, function (i, e) {
                                //没有匹配返回true，生成表格
                                if (Match(e)) {
                                    GetTable(e);
                                }
                            })
                        });
                    }
                }
            });
        })
        //匹配元素，如果元素在生成框里面已经存在，那生成的时候就不需要再生成，这里算法不太好
        function Match(m) {
            var list = $("#tb-selected").find("input");
            if (list != undefined) {
                //循环进行匹配，一旦匹配立即返回false
                for (var i = 0; i < list.length; i++)
                {
                    if (m.StuNum == $(list[i]).val())
                        return false;
                }
            }
            return true;
        }


         /*生成表格的函数*/
        function GetTable(obj)
        {
            //console.info(obj);
            var tb = document.getElementById("tb");
            var row = tb.insertRow(-1);
            var cell = row.insertCell(-1);
            //设置隐藏域是为了提交表单时获取学号
            cell.innerHTML = "<a href='javascript:void(0);' onclick=Remove(this)>" + obj.StuName + "</a>" + "<input type='hidden' value='" + obj.StuNum + "'/>";
        }

        //点击时将数据移动到选中框
        function Remove(obj)
        {
           //得到td
            var cell = $(obj).parent();
            //得到tr引用
            var tr = cell.parent();
            //移除这个子节点
            tr.remove();
            //改变被选中的a的点击事件
            obj.onclick = function () {
                RemoveSelect(this);
            }
            $("#tb-selected").append(tr);
        }

        //被选中框里面的a标签的点击事件
        function RemoveSelect(obj)
        {
            //得到td
            var cell = $(obj).parent();
            //得到tr引用
            var tr = cell.parent();
            //移除这个子节点
            tr.remove();
            //改变被选中的a的点击事件
            obj.onclick = function () {
                Remove(this);
            }
            $("#tb").append(tr);

        }
        //当选定人之后点击确定出发此事件
        function ok()
        {
            var list = "";
            var people = $("#tb-selected").find("input");
            $.each(people, function (i, e) {
                var td = $(e).parent();

                // $(td).text()姓名， $(e).val()学号
                list += "<a href='#'>" + $(td).text() + "<" + $(e).val() + ">;" + "</a>"
                //同时生成数据准备传递到后台
                str += $(e).val() + ";";
            })
            $(".per").append(list);
        }

        //想后台发送接收通知的学号
        function send() {
            //获取通知的标题和内容
            var title = $("#title").val();
            var text = $("#text").val();
            //向后台传送数据，str为通知接收人学号
            $("#hidden-reciver").val(str);
            //提交表单
            $("#form").submit();
        }


        $(function () {
            $("#select-person").click(function () {
                $("#mask").show(0);
                //改变recevier样式，显示出来
                $("#recevier").css({ "left": "50%", "top": "50%", "margin-left": "-300px", "margin-top": "-230px" });
                /*让滚动条消失，方便遮罩*/
                $("#notice-body").css({"overflow-y":"hidden"});
                //$("#recevier").addClass("center-person");
            });

        });

        function cancel() {
            $("#mask").hide(0);
            //改变recevier样式，显示出来
            $("#recevier").css({ "left": "-100000px" });
            /*取消遮罩时将滚动条显现出来*/
            $("#notice-body").css({ "overflow-y": "auto" });
        }
    </script>
</head>
<body id="notice-body" style="overflow:hidden">
    <div id="mask" class="mask"></div>
    <div class="nav">
    <div class="toolbar">
        <button style="height:25px;margin-top:6px;width:52px;margin-left:5px" onclick="send()">发送</button>
    </div>
    <div class="center">
          <form id="form" method="post" action="Notice.aspx"> 
    <div class="list" style="height:50px;padding:0px">
<%--        准备一个隐藏的input,value为接收者学号，提交表单时使用--%>
        <input type="hidden" name="reciver" id="hidden-reciver"/>
        <a href="#" id="select-person" onclick="select()">接收人:</a>
        <div class="per" style="overflow-y:auto">
<%--            <a href="#" style="padding:3px;display:inline-block">方刚<201258080133>;</a>--%>
        </div>
    </div>

    <div class="list">
        <span style="float:left;margin-left: 20px">标题:</span>
        <input autocomplete ="off" id="title" name="title" style="margin-left:18px;border:1px solid #d1d1d1"/>
    </div>
        <div class="text">
                <span style="margin-left: 22px">内容:</span>
<%--                <div style="margin-left:65px;width:843px;height:322px;margin-bottom:0px"><textarea id="text" name="text" style="border:1px solid #d1d1d1"></textarea></div>--%>
            <div style="margin-left: 65px; width: 843px; height: 280px; margin-bottom: 0px">
                <!-- 加载编辑器的容器 -->
                <script id="container-edtior" name="text" type="text/plain" style="width: 843px; height: 280px;">
                </script>
            </div>
        </div>
          </form>

        <div class="person"><span>发件人:</span></div>
        <div style="float:left;height:25px;margin-left:5px">
            <span style="font-weight:bold">方刚</span>
            <a href="#"style="margin-left:5px"><201258080133></a>
        </div>
    </div>
</div>

<%--添加联系人html代码--%>
<div class="recevier hidden" id="recevier">
       <div class="title">
           <span style="margin-left:5px;font-weight:bold;display:inline-block;margin-top:9px">从联系人中添加</span>
       </div>
       <div class="context">
           <table class="tab" cellspacing="0";>
               <tr style="height:32px;width:100%">
                   <td style="width:2%"></td>
                   <td style="width:46%;font-weight:bold;font-size:15px">联系人</td>
                   <td style="width:4%"></td>
                   <td style="width:46%;font-weight:bold;font-size:15px">收件人</td>
                   <td style="width:2%"></td>
               </tr>
               <tr style="height:340px;width:100%">
                   <td style="width:2%"></td>
                   <td style="width: 46%">
                       <div class="contact">
                           <%--                           easyui搜索框代码--%>
                           <div style="margin-top:8px;height:25px"><input id="ss" style="width:207px;height:25px"/></div>

                           <%--                           easyui代码--%>
                           <div id="aa" class="easyui-accordion" style="width: 207px; height: 296px;margin-top:5px">
                               <div title="应用方向"  style="overflow:auto; padding: 10px;height:20px">
                                   <table id="tb">
<%--                                       在生成表格的同时生成input保存学号--%>
<%--                                       <tr><td>hahh<input type="hidden" value="201258080133"/></td></tr>
                                       <tr><td>hahh</td></tr>
                                       <tr><td>hahh</td></tr>
                                       <tr><td>hahh</td></tr>--%>
                                   </table>
                               </div>
                               <div title="系统编程"  style="padding: 10px;height:20px">
                                   content2
                               </div>
                               <div title="物联网" style="height:20px">
                                   content3
                               </div>
                           </div>
                           <%--                           easyui代码--%>
                       </div>
                   </td>
                   <td style="width: 4%">>></td>
                   <td style="width: 46%">
                       <div class="contact" style="overflow:auto;background-color:#FFFFFF">
                                   <table id="tb-selected">
<%--                                       在生成表格的同时生成input保存学号--%>
<%--                                       <tr><td>hahh<input type="hidden" value="201258080133"/></td></tr>
                                       <tr><td>hahh</td></tr>
                                       <tr><td>hahh</td></tr>
                                       <tr><td>hahh</td></tr>--%>
                                   </table>
                       </div>                                                                    
                   </td>
                   <td style="width:2%"></td>
               </tr>
           </table>
       </div>

       <div class="bottom">
         <button class="btn" onclick="cancel()">取消</button>
         <button class="btn" onclick="ok()">确定</button>
       </div>
       </div>  
</body>
</html>
