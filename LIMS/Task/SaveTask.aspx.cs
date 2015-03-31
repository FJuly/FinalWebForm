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
    public partial class SaveTask : System.Web.UI.Page
    {
        List<object> roles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string taskTitle;//任务标题
            string taskType;//任务类型
            string taskProj;
            string ProjPhaseId;
            string strDateBeg;
            string strDateEnd;
            string taskContent;
            string strMembers;

            //判断用户登陆
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //判断参数是否正确
                if (Request.Form["txtTaskTitle"] == null || Request.Form["sltTaskType"] == null || Request.Form["sltProjPhase"] == null || Request.Form["dateBeg"] == null || Request.Form["dateEnd"] == null || Request.Form["txtTaskContent"] == null || Request.Form["checkbox"] == null || Request.Form["txtTaskProj"] == null)
                {
                    Response.Write("<script>window.onload = function (){alert(\"服务器忙！\");window.location.href='TaskRelease.aspx'}</script>");
                }
                else
                {
                    roles = (List<object>)Session["sessionRoles"];

                    MemberInformation loginer = (MemberInformation)Session["sessionCurrentUser"];

                    //从表单获取数据
                    taskTitle = Request.Form["txtTaskTitle"];
                    taskType = Request.Form["sltTaskType"];
                    taskProj = Request.Form["txtTaskProj"];
                    ProjPhaseId = Request.Form["sltProjPhase"];
                    strDateBeg = Request.Form["dateBeg"];
                    strDateEnd = Request.Form["dateEnd"];
                    taskContent = Request.Form["txtTaskContent"];
                    strMembers = Request.Form["checkbox"];

                    string[] memberNums = strMembers.Split(new char[] { ',' });//接收人学号数组

                    TaskInformation taskInfo = new TaskInformation();
                    taskInfo.TaskName = taskTitle;
                    
                    taskInfo.TaskTypeId = int.Parse(taskType);

                    //10003为项目任务Id
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

                    if (CreateTask(taskInfo, memberNums))
                    {
                        Response.Redirect("ReleaseHistory.aspx?");
                    }
                    else
                    {
                        Response.Write("抱歉，服务器忙！请稍后重试！");
                    }
                }      
            }
        }

        /// <summary>
        /// 新建任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool CreateTask(TaskInformation taskInfo, string[] memberNums)
        {
            switch (taskInfo.TaskTypeId)
            {
                case 10001: return CreateStudyTask(taskInfo, memberNums);
                case 10002: return CreateDevelopmentTask(taskInfo, memberNums);
                case 10003: return CreateProjTask(taskInfo, memberNums);
                case 10004: return CreateLectureTask(taskInfo, memberNums);
                default: return false;
            }
        }

        /// <summary>
        /// 新建学习任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool CreateStudyTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IStudyTask)
                {
                    IStudyTask op = obj as IStudyTask;
                    if (op.CreateStudyTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 新建开发任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool CreateDevelopmentTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IDevelopmentTask)
                {
                    IDevelopmentTask op = obj as IDevelopmentTask;
                    if (op.CreateDevelopmentTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 新建项目任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool CreateProjTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IProjTask)
                {
                    IProjTask op = obj as IProjTask;
                    if (op.CreateProjTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 新建学生讲座
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="memberNums"></param>
        /// <returns></returns>
        private bool CreateLectureTask(TaskInformation taskInfo, string[] memberNums)
        {
            foreach (object obj in roles)
            {
                if (obj is IDevelopmentTask)
                {
                    IDevelopmentTask op = obj as IDevelopmentTask;
                    if (op.CreateDevelopmentTask(taskInfo, memberNums))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}