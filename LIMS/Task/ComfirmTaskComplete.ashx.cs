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
    /// 确认任务已完成
    /// PS 2014.10.19
    /// </summary>
    public class ComfirmTaskComplete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

             ///判断用户是否登录，参数是否正确
            if (context.Session["sessionCurrentUser"] == null || context.Request.QueryString["taskId"]==null)
            {
                context.Response.Write(-1);
            }
            else
            {
                MemberInformation loginer = (MemberInformation)context.Session["sessionCurrentUser"];

                string strTaskId = context.Request.QueryString["taskId"];

                int taskId = 0;
                if (Int32.TryParse(strTaskId, out taskId))
                {
                    //根据学号和任务Id确认任务完成
                    if (new CTaskOperate().ConfirmTaskCompleteById(loginer.StuNum, taskId))
                    {
                        context.Response.Write(1);
                    }
                    else
                    {
                        context.Response.Write(-1);
                    }                    
                }
                else
                {
                    context.Response.Write(-1);
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