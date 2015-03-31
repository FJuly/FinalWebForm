using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace LIMS.Task
{
    /// <summary>
    /// 根据任务类型分页获取任务返回JSON数据格式
    ///  PS 2014.10.19
    /// </summary>
    public class GetTaskList : IHttpHandler, IRequiresSessionState
    {
        public  StringBuilder sbJSon = new StringBuilder(2000);
        public void ProcessRequest(HttpContext context)
        {
            sbJSon.Length = 0;
            context.Response.ContentType = "text/plain";

            //判断用户是否登陆，参数是否正确
            if (context.Session["sessionCurrentUser"] != null && context.Request.QueryString["pi"] != null && context.Request.QueryString["taskTypeId"] != null)
            {
                MemberInformation loginer = (MemberInformation)context.Session["sessionCurrentUser"];

                string strPageIndex = context.Request.QueryString["pi"];
                string strTaskTypeId = context.Request.QueryString["taskTypeId"];

                int taskTypeId;
                //判断参数是否正确
                if (Int32.TryParse(strTaskTypeId, out  taskTypeId))
                {
                    int pageIndex = 0;//页码
                    int rowCount = 0;//记录条数
                    int pageCount = 0;//页大小
                    //判断参数是否正确
                    if (int.TryParse(strPageIndex, out pageIndex))
                    {
                        //分页查找数据
                        VMemberTaskInfo[] taskInfo = new CTaskOperate().GetAllTaskInfoByPageIndex(loginer.StuNum, taskTypeId, pageIndex, 10, ref rowCount);
                        pageCount = rowCount / 5 + 1;

                        //JSON格式序列化
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string strJSon = jss.Serialize(taskInfo);
                        //返回数据
                        context.Response.Write(strJSon);
                    }
                }
            }
            else
            {
                context.Response.Write("");
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