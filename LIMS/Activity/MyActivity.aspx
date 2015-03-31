<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyActivity.aspx.cs" Inherits="LIMS.Activity.MyActivity" %>
<%--/*------------------------------林志章-------------------------------------*/--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的活动</title>
    <link href="../JS/easyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="../JS/easyUI/themes/icon.css" rel="stylesheet" />
    <link href="../JS/easyUI/demo/demo.css" rel="stylesheet" />   
    <script src="../JS/easyUI/jquery.min.js"></script>
    <script src="../JS/easyUI/jquery.easyui.min.js"></script>
    <script src="../JS/easyUI/locale/easyui-lang-zh_CN.js"></script>
    <script src="../JS/JSHelper.js"></script>
</head>    
<body>
     
    <div style="width:1000px; margin-left:auto; margin-right:auto;">
    <%--<table id="tab_list" >
    </table>--%>
             <table id="tab_list" title="我的活动" class="easyui-datagrid" style="width:1000px;height:450px;"url="GetActInfoList.ashx"
             pagination="true" rownumbers="true" fitColumns="true" singleSelect="true">
        </table>

    <div id="tab_toolbar" style="padding: 0 2px;">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                
                <td style="text-align: right; padding-right: 15px">
                    <input id="ipt_search" menu="#search_menu" />
                    <div id="search_menu" style="width:120px">
                        <div name="ActTitle">
                            活动标题</div>
                        <div name="ActTypeName">
                            活动类型</div>
                        <div name="StuName">
                            活动负责人</div>
                    </div>
                </td>
            </tr>
        </table>
       
    </div>
             </div>



    </body>
</html>

<style type="text/css">
a:link,a:visited{
 text-decoration:none;  /*超链接无下划线*/
}
a:hover{
 text-decoration:underline;  /*鼠标放上去有下划线*/
}
</style>

    <script type="text/javascript">

        $(function () {
            InitGrid();
            InitSearch();
        });
        //初始化表格
        function InitGrid()
        {       
            $('#tab_list').datagrid({
                //title: '我的活动', //表格标题
                //url: 'GetActInfoList.ashx', //请求数据的页面
                //sortName: 'ActId', //排序字段
                idField: 'ActId', //标识字段，主键
                //iconCls: '', //标题左边的图标
                //width: '80%', //宽度
                //height: $(parent.document).find('#mainPanle').height() - 10 > 0 ? $(parent.document).find('mainPanle').height() - 10 : 500, //高度
                //nowrap: false, //是否换行，true就会把数据显示在一行里
                //striped: true, //true 奇偶行使用不同的背景色
                //collapsible: false, //可折叠
                //sortOrder: 'desc', //排序类型
                //remoteSort: true, //定义是否从服务器给数据排序
                frozenColumns: [[ //冻结的列，不会随横向滚动轴移动
                    {title:'活动标题',field:'ActTitle',width:150,sorttable:true},
                    {title:'活动地点',field:'ActAddress',width:150},
                    {title:'活动负责人',field:'StuName',width:150},
                    { title: '活动类型', field: 'ActTypeName', width: 150 },
                    { title: '活动开始时间', field: 'ActStartTime', width: 150 },
                    {
                        title: '操作', field: 'ActId', width: 120, formatter: function (value, rec) {
                            //return '<a style="color:red;"  href="AllActInfo.aspx?ActId=' + value + '">活动详情</a>'+" " + '<a style="color:red;"  href="AllActInfo.aspx?ActId=' + value + '">活动详情</a>';
                            return isDelete(value);
                        }
                    }
                ]],
                toolbar: '#tab_toolbar',
                queryParams: { "action": "query" }//,
                //pagination: true, //是否开启分页
                //pageNumber: 1, //默认索引页        
                //pageSize: 10, //默认一页数据条数
                //rownumbers: true //行号
            })
        }

        //判断是否添加删除按钮
        function isDelete(value)
        {
            <%=aaa %>
            if(isActLeader)
            {
                return '<a style="color:red;"  href="AllActInfo.aspx?ActId=' + value + '">活动详情</a>' + " " + '<a style="color:red;" onclick="del(this)"  id="'+value+'" href="javascript:void(0)">删除</a>';
            }
            else
            {
                return '<a style="color:red;"  href="AllActInfo.aspx?ActId=' + value + '">活动详情</a>';
            }
        }

        //初始化搜索框
        function InitSearch()
        {
            $("#ipt_search").searchbox({
                width: 200,
                iconCls: 'icon-save',
                searcher: function (val, name) {
                    $('#tab_list').datagrid('options').queryParams.search_type = name;
                    $('#tab_list').datagrid('options').queryParams.search_value = val;
                    $('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的内容'
            });
        }

        //提示是否要删除活动
        function del(obj)
        {
            $.messager.confirm("提示","确定要删除此活动么？",function(r){
                if (r) {
                    var actid = obj.getAttribute("id");
               
                    $.get("DeleteAct.aspx", { id: actid }, function (data, status) {
                        //alert(data);
                        if(data == "ok")
                        {
                            alert("删除成功！");
                            $('#tab_list').datagrid('reload');
                        }
                        else
                        {
                            
                            alert("删除失败！");
                            $('#tab_list').datagrid('reload');
                        }
                    });
            }
            })
        }
        //function del(obj)
        //{
        //    var actid = obj.getAttribute("id");
        //    alert(actid);
        //    if(confirm("确认删除此活动？"))
        //    {
        //        alert(actid);
        //        var xhrRequest = new AjaxRequest("get", "DeleteAct.aspx?ActId=" + actid, [], function (returnData) {
        //            if(returnData == "ok")
        //            {
        //                window.location.href = "MyActivity.aspx";
        //                alert("活动删除成功！");
        //            }else if(returnData == "nook")
        //            {
        //                alert("删除失败！请稍后重试！");
        //            }
        //        })
        //        xhrRequest.send();
        //    }
        //}

    </script>


