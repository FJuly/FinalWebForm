using BLL;
using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS
{
    /// <summary>
    /// 
    ///  PS 2014.10.19
    /// </summary>
    public partial class MyTask : System.Web.UI.Page
    {
        public StringBuilder sbHtml = new StringBuilder(2000);
        public int stdTaskCount = 0;
        public int developTaskCount = 0;
        public int projTaskCount = 0;
        public int chairTaskCount = 0;
        private MemberInformation loginer = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///判断用户是否登录
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                loginer = (MemberInformation)Session["sessionCurrentUser"];

                //获取所有任务类型
                TaskType[] taskTypes = new CTaskOperate().GetAllTaskType();

                //获取任务条数
                stdTaskCount = new CTaskOperate().GetTaskCount(loginer.StuNum, 10001);
                developTaskCount = new CTaskOperate().GetTaskCount(loginer.StuNum, 10002);
                projTaskCount = new CTaskOperate().GetTaskCount(loginer.StuNum, 10003);
                chairTaskCount = new CTaskOperate().GetTaskCount(loginer.StuNum, 10004);




                #region 打印任务分类下拉面板
                for (int i = 0; i < taskTypes.Length; i++)
                {
                    sbHtml.Append("<div class=\"task-type\" id = \"taskType" + taskTypes[i].TaskTypeId + "\" title=\"" + taskTypes[i].TaskTypeName + "\" data-options=\"iconCls:'icon-ok'\">");

                    sbHtml.Append("<h2 style=\"color:#787878;\">&nbsp&nbsp&nbsp&nbsp任务列表>></h2>");

                    if (taskTypes[i].TaskTypeId == 10003)//项目任务
                    {
                        sbHtml.Append("<table class=\"task-table\" id=\"tb" + taskTypes[i].TaskTypeId + "\"><tr>");
                        sbHtml.Append("<th style=\"width:340px\">任务标题</th><th style=\"width:150px\">所属项目</th><th style=\"width:70px\">项目阶段</th><th style=\"width:120px\">发布时间</th><th style=\"width:120px\">截止时间</th><th style=\"width:120px\">发布人</th></tr>");
                        sbHtml.Append("</table>");
                    }
                    else if(taskTypes[i].TaskTypeId  == 10001)//学习任务
                    {
                        sbHtml.Append("<table class=\"task-table\" id=\"tb" + taskTypes[i].TaskTypeId + "\"><tr>");
                        sbHtml.Append("<th style=\"width:420px\">任务标题</th><th style=\"width:150px\">发布时间</th><th style=\"width:150px\">截止时间</th><th style=\"width:80px\">评分</th><th style=\"width:130px\">发布人</th><th style=\"width:70px\">是否完成</th></tr>");
                        sbHtml.Append("</table>");
                    }
                    else//其他任务
                    {
                        sbHtml.Append("<table class=\"task-table\" id=\"tb" + taskTypes[i].TaskTypeId + "\"><tr>");
                        sbHtml.Append("<th style=\"width:380px\">任务标题</th><th style=\"width:150px\">发布时间</th><th style=\"width:190px\">截止时间</th><th style=\"width:150px\">内容摘要</th><th style=\"width:130px\">发布人</th></tr>");
                        sbHtml.Append("</table>");
                    }
                    sbHtml.Append("<div style=\"margin-left:70px;font-size:13px\" id=\"pageBar" + taskTypes[i].TaskTypeId + "\"></div>");
                    sbHtml.Append("</div>");

                }
                #endregion
                
            }
        }
    }
}