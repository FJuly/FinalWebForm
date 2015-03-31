using BLL;
using BLL.Interface;
using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.Task
{
    /// <summary>
    /// 
    ///  PS 2014.10.19
    /// </summary>
    public partial class SaveTaskUpDate : System.Web.UI.Page
    {
        string strTaskId;
        string taskTitle;
        string taskType;
        string taskProj;
        string ProjPhaseId;
        string strDateBeg;
        string strDateEnd;
        string taskContent;
        string strMembers;
        MemberInformation loginer;
        List<object> roles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                loginer = (MemberInformation)Session["sessionCurrentUser"];

                roles = (List<object>)Session["sessionRoles"];

                SaveTask();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveTask()
        {
            //判断是否所有值都已传过来
            if (Request.Form["txtTaskId"] == null || Request.Form["txtTaskTitle"] == null || Request.Form["sltTaskType"] == null || Request.Form["sltProjPhase"] == null || Request.Form["dateBeg"] == null || Request.Form["dateEnd"] == null || Request.Form["txtTaskContent"] == null || Request.Form["checkbox"] == null || Request.Form["txtTaskProj"] == null)
            {
                Response.Write("<script>window.onload = function (){alert(\"对不起！服务器忙！\");window.location.href='ReleaseHistory.aspx'}</script>");
            }
            else
            {
                //取值
                strTaskId = Request.Form["txtTaskId"];
                taskTitle = Request.Form["txtTaskTitle"];
                taskType = Request.Form["sltTaskType"];
                taskProj = Request.Form["txtTaskProj"];
                ProjPhaseId = Request.Form["sltProjPhase"];
                strDateBeg = Request.Form["dateBeg"];
                strDateEnd = Request.Form["dateEnd"];
                taskContent = Request.Form["txtTaskContent"];
                strMembers = Request.Form["checkbox"];

                //获取参与人学号数组
                string[] memberNums = strMembers.Split(new char[] { ',' });

                TaskInformation taskInfo = new TaskInformation();
                taskInfo.TaskId = int.Parse(strTaskId);
                taskInfo.TaskName = taskTitle;
                taskInfo.TaskTypeId = int.Parse(taskType);
                if (taskInfo.TaskTypeId == 10003)
                {
                    taskInfo.ProjId = int.Parse(taskProj);
                    taskInfo.ProjPhaseId = int.Parse(ProjPhaseId);
                }
                else
                {

                    taskInfo.ProjId = 10001;
                    taskInfo.ProjPhaseId = 10001;
                }
                taskInfo.TaskBegTime = DateTime.Parse(strDateBeg);
                taskInfo.TaskEndTime = DateTime.Parse(strDateEnd);
                taskInfo.TaskContent = taskContent;
                taskInfo.TaskSender = loginer.StuNum;
                taskInfo.TaskAttachmentPath = "..img/img/i.rar";

                //先删除原有记录，再插入新数据

                

                if (UpdateTask(taskInfo,memberNums))
                {
                    Response.Redirect("ReleaseHistory.aspx");
                }
                else
                {
                    Response.Write("<script>window.onload = function (){alert(\"Sorry！服务器忙！\");window.location.href='ReleaseHistory.aspx'}</script>");
                }

            }
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool UpdateTask(TaskInformation taskInfo, string[] memberNums)
        {
            switch (taskInfo.TaskTypeId)
            {
                case 10001 : return UpdateStudyTask(taskInfo,memberNums); 
                case 10002 : return UpdateDevelopmentTask(taskInfo, memberNums);
                case 10003: return UpdateProjTask(taskInfo, memberNums);
                case 10004: return UpdateLectureTask(taskInfo, memberNums);
                default: return false;
            }
        }

        /// <summary>
        /// 更新学习任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool UpdateStudyTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IStudyTask)
                {
                    IStudyTask op = obj as IStudyTask;
                    if (op.UpdateStudyTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 更新开发任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool UpdateDevelopmentTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IDevelopmentTask)
                {
                    IDevelopmentTask op = obj as IDevelopmentTask;
                    if (op.UpdateDevelopmentTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 更新学习项目任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool UpdateProjTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IProjTask)
                {
                    IProjTask op = obj as IProjTask;
                    if (op.UpdateProjTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 更新学生讲座
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool UpdateLectureTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IDevelopmentTask)
                {
                    IDevelopmentTask op = obj as IDevelopmentTask;
                    if (op.UpdateDevelopmentTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}