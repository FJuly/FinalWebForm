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

namespace LIMS.Task
{
    /// <summary>
    /// 
    ///  PS 2014.10.19
    /// </summary>
    public partial class UpdateTask : System.Web.UI.Page
    {
        public TaskInformation taskInfo = new TaskInformation();
        public string taskProjName;//任务所属项目名称
        public string JSonMembers;
        public StringBuilder sbSltTaskType = new StringBuilder(500);//任务类型下拉框
        public StringBuilder sbProjPhase = new StringBuilder(500);
        public StringBuilder sbProjList = new StringBuilder(500);
        public StringBuilder sbMemberList = new StringBuilder(500);
        public MemberInformation loginer = null;

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
                List<object> roles = (List<object>)Session["sessionRoles"];

                MakeSbProjPhase();
                MakeSbProjList();

                string strTaskId = Request.QueryString["taskId"];
                string[] members;
                int taskId;

                if (int.TryParse(strTaskId, out taskId))
                {
                    taskInfo = new CTaskOperate().GetTaskInfoById(taskId);

                    //判断任务是否是此人发的若不是则重定向
                    if (taskInfo.TaskSender != loginer.StuNum)
                    {
                        Response.Redirect("PermissionDenied.html");
                    }

                    members = new CTaskOperate().GetMemberListByTaskId(taskInfo.TaskId);
                    JSonMembers = string.Join(",", members);
                    //Response.Write(JSonMembers);
                }

                #region 打印成员选项下拉框
                //<option value="1">所有成员</option>
                //<option value="2">实习生</option>
                //<option value="3">正式成员</option>
                //<option value="4">物联网方向成员</option>
                //<option value="5">系统编程方向成员</option>
                //<option value="6">应用开发方向成员</option>
                //<option value="7">项目参与成员</option>
                sbMemberList.Append("<option value=\"1\">所有成员</option>");
                sbMemberList.Append("<option value=\"2\">实习生</option>");
                sbMemberList.Append("<option value=\"3\">正式成员</option>");
                sbMemberList.Append("<option value=\"4\">物联网方向成员</option>");
                sbMemberList.Append("<option value=\"5\">系统编程方向成员</option>");
                sbMemberList.Append("<option value=\"6\">应用开发方向成员</option>"); 
                #endregion

                #region 打印任务类型下拉框

                ///不同的人对应发布不同类型的任务
                ///一种任务类型只需要写一次
                bool[] flag = { true, true, true, true };

                foreach (object role in roles)
                {
                    if (role is BLL.Interface.IStudyTask && flag[0])
                    {
                        flag[0] = false;
                        sbSltTaskType.Append("<option value=\"10001\">学习任务</option>");
                        //sbMemberList.Append("<option value=\"2\">实习生</option>");
                    }
                    if (role is BLL.Interface.IDevelopmentTask && flag[1])
                    {
                        flag[1] = false;
                        sbSltTaskType.Append("<option value=\"10002\">开发任务</option>");
                    }
                    if (role is BLL.Interface.IProjTask && flag[2])
                    {
                        flag[2] = false;
                        sbSltTaskType.Append("<option value=\"10003\">项目任务</option>");
                        sbMemberList.Append("<option value=\"7\">项目参与成员</option>");
                    }
                    if (role is BLL.Interface.IReleaseLectureTask && flag[3])
                    {
                        flag[3] = false;
                        sbSltTaskType.Append("<option value=\"10004\">学生讲座</option>");
                    }
                }
                if (flag[0] && flag[1] && flag[2] && flag[3])
                {
                    Response.Redirect("../PermissionDenied.html");
                }
            } 
                #endregion



        }

        /// <summary>
        /// 项目阶段下拉框选项
        /// </summary>
        private void MakeSbProjPhase()
        {
            sbProjPhase.Length = 0;

            List<ProjectPhase> list = new CProject().GetAllProjectPhase();

            foreach (ProjectPhase projectPhase in list)
            {
                sbProjPhase.Append("<option value=\"" + projectPhase.ProjPhaseId + "\">" + projectPhase.ProjPhase + "</option>");
            }
        }

        private void MakeSbProjList()
        {
            sbProjList.Length = 0;

            List<ProjectInformation> list = new CProject().GetProjByLeader(loginer.StuNum);

            if (list != null)
            {
                foreach (ProjectInformation project in list)
                {
                    sbProjList.Append("<option value=\"" + project.ProjId + "\">" + project.ProjName + "</option>");
                }
            }
        }
    }
}