using BLL;
using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LIMS.Task
{
    /// <summary>
    /// 
    /// PS 2014.10.19
    /// </summary>
    public class DeleteTaskById : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //判断参数是否正确
            if (context.Request.QueryString["taskId"] == null)
            {
                context.Response.Write("nook");
            }
            else
            {
                string strTaskId = context.Request.QueryString["taskId"];
                int taskId = 0;

                if (int.TryParse(strTaskId, out taskId))
                {
                    ///判断用户是否登录
                    if (context.Session["sessionCurrentUser"] == null)
                    {
                        context.Response.Redirect("../Login.aspx");
                    }
                    else
                    {
                        MemberInformation loginer = (MemberInformation)context.Session["sessionCurrentUser"];
                        TaskInformation infor = new CTaskOperate().GetTaskInfoById(taskId);

                        ///判断此任务是否是此人发的
                        if (infor.TaskSender.Equals(loginer.StuNum))
                        {
                            new CTaskOperate().DeleteTaskById(taskId);
                            context.Response.Write("ok");
                        }
                    }
                }
                else
                {
                    context.Response.Write("nook");
                }
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}