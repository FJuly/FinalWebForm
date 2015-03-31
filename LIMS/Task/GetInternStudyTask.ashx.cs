using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace LIMS.Task
{
    /// <summary>
    /// GetInternStudyTask 的摘要说明
    ///  PS 2014.10.19
    /// </summary>
    public class GetInternStudyTask : IHttpHandler, IRequiresSessionState
    {

        MemberInformation loginer = null;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            ///判断用户是否登录
            if (context.Session["sessionCurrentUser"] == null)
            {
                context.Response.Redirect("../Login.aspx");
            }
            else
            {
                loginer = (MemberInformation)context.Session["sessionCurrentUser"];

                //检查参数是否存在
                if (context.Request.QueryString["pi"] != null)
                {
                    string strPageIndex = context.Request.QueryString["pi"];
                    int pageIndex = 0;
                    ///检查参数是否正确
                    if (int.TryParse(strPageIndex, out pageIndex))
                    {
                        //查找数据
                        TaskInformation[] taskInfo = new CTaskOperate().GetStuStudyTaskByPageIndex(loginer.StuNum, pageIndex, 10);
                        //转JSON格式
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string strJSon = jss.Serialize(taskInfo);
                        ///返回数据
                        context.Response.Write(strJSon);
                    }

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