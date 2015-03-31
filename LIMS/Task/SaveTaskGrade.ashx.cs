using BLL;
using BLL.Interface;
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
    /// SaveTaskGrade 的摘要说明
    ///  PS 2014.10.19
    /// </summary>
    public class SaveTaskGrade : IHttpHandler, IRequiresSessionState
    {
        List<object> roles = null;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string stuNum = context.Request.QueryString["stuNum"].Trim();
            string strTaskId = context.Request.QueryString["taskId"];
            string taskGrade = context.Request.QueryString["taskGrade"].Trim();
            int taskId = 0;

            if (context.Session["sessionCurrentUser"] == null)
            {
                context.Response.Redirect("../Login.aspx");
            }
            else
            {

               // loginer = (MemberInformation)Session["sessionCurrentUser"];

                roles = (List<object>)context.Session["sessionRoles"];

                if (Int32.TryParse(strTaskId, out taskId))
                {
                    if (taskGrade.Equals("优") || taskGrade.Equals("良") || taskGrade.Equals("差") || taskGrade.Equals("不合格"))
                    {

                        foreach (object obj in roles)
                        {
                            if (obj is IEvaluateTask)
                            {
                                if (new CTaskOperate().SaveTaskGrade(stuNum, taskId, taskGrade))
                                {
                                    context.Response.Write("ok");
                                }
                                else
                                {
                                    context.Response.Write("nook");
                                }
                            }
                        }


                    }
                    else
                    {
                        context.Response.Write("nook");
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