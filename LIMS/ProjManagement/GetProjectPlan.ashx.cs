using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LIMS.ProjManagement
{
    /// <summary>
    /// GetProjectPlan 的摘要说明
    /// </summary>
    public class GetProjectPlan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BLL.Operator.CProject bll = new BLL.Operator.CProject();
            context.Response.ContentType = "application/json";

            List<Model.ProjectPhase> glist = new List<Model.ProjectPhase>();            //获取项目阶段大标题
            List<Model.V_ProjectPhase> vlist = new List<Model.V_ProjectPhase>();        //获取项目阶段详细信息
            List<Model.TaskParticipation> tlist = new List<Model.TaskParticipation>();  //获取任务执行人员
            
            glist = bll.GetPlanList();
            vlist = bll.GetPlanInfoList();

            ///将list中的元素按照下列类型序列化
            var fin_list = from li in vlist
                           select
                               new
                               {
                                   li.TaskId,
                                   li.ProjPhase,
                                   li.TaskName,
                                   TaskBegTime = li.TaskBegTime.ToString("yyyy年MM月dd日"),
                                   TaskEndTime = li.TaskEndTime.ToString("yyyy年MM月dd日"),
                                   TaskReceiver = bll.GetTaskReceive(li.TaskId)
                               };

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string str = jss.Serialize(fin_list);
            context.Response.Write(str);
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