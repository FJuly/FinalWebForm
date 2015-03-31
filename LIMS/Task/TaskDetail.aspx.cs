using BLL;
using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.Task
{
    /// <summary>
    /// 任务详情
    ///  PS 2014.10.19
    /// </summary>
    public partial class TaskDetail : System.Web.UI.Page
    {
        public int taskId = -1;

        public StringBuilder sbTaskDetail = new StringBuilder(2000);
        private MemberInformation loginer = new MemberInformation();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                loginer = (MemberInformation)Session["sessionCurrentUser"];

                sbTaskDetail.Length = 0;
                VMemberTaskInfo taskInfo = new VMemberTaskInfo();
                string strTaskId = Request.QueryString["taskId"];


                if (Int32.TryParse(strTaskId, out taskId))
                {
                    //获取任务详情
                    taskInfo = new CTaskOperate().GetTaskByStuNumAndTaskId(loginer.StuNum, taskId);
                    if (taskInfo == null) 
                    {
                        Response.Redirect("../PermissionDenied.html");
                    }
                    #region 打印任务详情
                    sbTaskDetail.Append("<tr>");
                    sbTaskDetail.Append("<td style = \"border-top:1px solid #787878;\" class=\"td-title\">任务标题：</td>");
                    sbTaskDetail.Append("<td style = \"border-top:1px solid #787878;\" class=\"td-content\">" + taskInfo.TaskName + "</td>");
                    sbTaskDetail.Append("</tr>");

                    sbTaskDetail.Append("<tr>");
                    sbTaskDetail.Append("<td class=\"td-title\">任务类型：</td>");
                    sbTaskDetail.Append("<td class=\"td-content\">" + new CTaskOperate().GetTypeNameByTypeId(taskInfo.TaskTypeId) + "</td>");
                    sbTaskDetail.Append("</tr>");

                    if (taskInfo.TaskTypeId == 10003)
                    {
                        sbTaskDetail.Append("<tr>");
                        sbTaskDetail.Append("<td class=\"td-title\">所属项目：</td>");
                        sbTaskDetail.Append("<td class=\"td-content\">" + taskInfo.ProjId + "</td>");
                        sbTaskDetail.Append("</tr>");
                        sbTaskDetail.Append("<tr>");
                        sbTaskDetail.Append("<td class=\"td-title\">项目阶段：</td>");
                        sbTaskDetail.Append("<td class=\"td-content\">" + taskInfo.ProjPhase + "</td>");
                        sbTaskDetail.Append("</tr>");
                    }

                    sbTaskDetail.Append("<tr>");
                    sbTaskDetail.Append("<td class=\"td-title\">发布时间：</td>");
                    sbTaskDetail.Append("<td class=\"td-content\">" + string.Format(DateTimeFormatInfo.InvariantInfo, "{0:yyyy年M月d日}", taskInfo.TaskBegTime) + "</td>");
                    sbTaskDetail.Append("</tr>");

                    sbTaskDetail.Append("<tr>");
                    sbTaskDetail.Append("<td class=\"td-title\">截止时间：</td>");
                    sbTaskDetail.Append("<td class=\"td-content\">" + string.Format(DateTimeFormatInfo.InvariantInfo, "{0:yyyy年M月d日}", taskInfo.TaskEndTime) + "</td>");
                    sbTaskDetail.Append("</tr>");

                    sbTaskDetail.Append("<tr>");
                    sbTaskDetail.Append("<td valign=\"top\" style = \"border-bottom:1px solid #787878;\" class=\"td-title\">任务内容：</td>");
                    sbTaskDetail.Append("<td style = \"border-bottom:1px solid #787878;padding-right:200px\" class=\"td-content\"></br>" + taskInfo.TaskContent + "</td>");
                    sbTaskDetail.Append("</tr>"); 
                    #endregion

                }
                else
                {
                    Response.Redirect("MyTask.aspx");
                }

            }

            
        }
    }
}