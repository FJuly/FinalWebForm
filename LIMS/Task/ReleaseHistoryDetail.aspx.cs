using BLL;
using BLL.Operator;
using BLL.Role;
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
    /// 
    ///  PS 2014.10.19
    /// </summary>
    public partial class ReleaseHistoryDetail : System.Web.UI.Page
    {
        public int taskId = -1;
        //public string historyPage;
        public StringBuilder sbTaskDetail = new StringBuilder(2000);
        public StringBuilder sbMemberList = new StringBuilder(2000); 
        TaskInformation taskInfo = new TaskInformation();
        MemberInformation loginer = null;
        List<object> roles = null;
        string strTaskId;
        protected void Page_Load(object sender, EventArgs e)
        {
            sbTaskDetail.Length = 0;
            sbMemberList.Length = 0;
            strTaskId = Request.QueryString["taskId"];

            ///判断用户是否登录
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                loginer = (MemberInformation)Session["sessionCurrentUser"];
                if (Int32.TryParse(strTaskId, out taskId))
                {
                    TaskInformation infor = new CTaskOperate().GetTaskInfoById(taskId);

                    ///判断此任务是否是此人发的
                    if (infor.TaskSender.Equals(loginer.StuNum))
                    {
                        MakeTaskDetail();
                        MakeMemberList();
                    }
                }
                else
                {
                    Response.Redirect("ReleaseHistory.aspx");
                }
                
            }
        }

        /// <summary>
        /// 显示任务详情
        /// </summary>
        private void MakeTaskDetail()
        {
            taskInfo = new CTaskOperate().GetTaskInfoById(taskId);
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
                sbTaskDetail.Append("<td class=\"td-content\">" + taskInfo.ProjPhaseId + "</td>");
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
        }

        /// <summary>
        /// 显示参与人列表
        /// </summary>
        private void MakeMemberList()
        {
            List<TaskParticipation> memberList = new CTaskOperate().GetMembersByTaskId(taskId);


            sbMemberList.Append("<table id=\"tb-member-list\">");

            sbMemberList.Append("<tr>");
            sbMemberList.Append("<th style=\"width:140px\">学号</th>");
            sbMemberList.Append("<th style=\"width:140px\">姓名</th>");
            sbMemberList.Append("<th style=\"width:90px\">任务评价</th>");
            sbMemberList.Append("<th style=\"width:90px\">是否查看</th>");
            sbMemberList.Append("<th style=\"width:90px\">是否完成</th>");
            sbMemberList.Append("</tr>");


            foreach (TaskParticipation infor in memberList)
            {
                
                sbMemberList.Append("<tr>");
                sbMemberList.Append("<td>"+infor.TaskReceiverId+"</td>");
                sbMemberList.Append("<td>" + infor.TaskReceiverName + "</td>");
                sbMemberList.Append("<td>" + TaskGrade(infor.TaskGrade,infor.TaskReceiverId,infor.TaskId) + "</td>");
                sbMemberList.Append("<td>" + TaskIsRead(infor.IsRead) + "</td>");
                sbMemberList.Append("<td>" + TaskIsComplete(infor.IsComplete) + "</td>");
                sbMemberList.Append("</tr>");
            }

            sbMemberList.Append("</table>");
        }

        /// <summary>
        /// boolTOString
        /// </summary>
        /// <param name="taskIsRead"></param>
        /// <returns></returns>
        private string TaskIsRead(Boolean taskIsRead)
        {
            if (taskIsRead == true)
            {
                return "已查看";
            }
            else
            {
                return "未查看";
            }
        }

        /// <summary>
        /// boolTOString
        /// </summary>
        /// <param name="taskIsComplete"></param>
        /// <returns></returns>
        private string TaskIsComplete(Boolean taskIsComplete)
        {
            if (taskIsComplete == true)
            {
                return "已完成";
            }
            else
            {
                return "未完成";
            }
        }

        /// <summary>
        /// 任务评价下拉框
        /// </summary>
        /// <param name="taskGrade"></param>
        /// <param name="stuNum"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        private string TaskGrade(string taskGrade,string stuNum,int taskId)
        {
            StringBuilder sb = new StringBuilder(500);
            if (taskInfo.TaskTypeId != 10001)
            {
                sb.Append("<span style=\"color:#787878\">不用评价</span>");
            }
            else
            {
                sb.Append("<select style=\"width:75px;\" id=\"slt-task-grade\" onchange = \"saveGradeChange(this.options[this.selectedIndex].value," + stuNum + "," + taskId + ")\">");
                if (taskGrade.Equals(""))
                {

                    sb.Append("<option style=\"display: none;\" value=\"点击评价\">点击评价</option>");
                    sb.Append("<option value=\"优\">优</option>");
                    sb.Append("<option value=\"良\">良</option>");
                    sb.Append("<option value=\"差\">差</option>");
                    sb.Append("<option value=\"不合格\">不合格</option>");
                }
                else
                {

                    switch (taskGrade)
                    {
                        case "优":
                            sb.Append("<option selected = \"selected\" value=\"优\">优</option>");
                            sb.Append("<option value=\"良\">良</option>");
                            sb.Append("<option value=\"差\">差</option>");
                            sb.Append("<option value=\"不合格\">不合格</option>");
                            ; break;
                        case "良":
                            sb.Append("<option value=\"优\">优</option>");
                            sb.Append("<option selected = \"selected\" value=\"良\">良</option>");
                            sb.Append("<option value=\"差\">差</option>");
                            sb.Append("<option value=\"不合格\">不合格</option>");
                            ; break;
                        case "差":
                            sb.Append("<option value=\"优\">优</option>");
                            sb.Append("<option value=\"良\">良</option>");
                            sb.Append("<option selected = \"selected\" value=\"差\">差</option>");
                            sb.Append("<option value=\"不合格\">不合格</option>");
                            ; break;
                        case "不合格":
                            sb.Append("<option value=\"优\">优</option>");
                            sb.Append("<option value=\"良\">良</option>");
                            sb.Append("<option value=\"差\">差</option>");
                            sb.Append("<option selected = \"selected\" value=\"不合格\">不合格</option>");
                            ; break;
                    }
                }

                sb.Append("</select>");
            }
            

            return sb.ToString();
        }
    }


}