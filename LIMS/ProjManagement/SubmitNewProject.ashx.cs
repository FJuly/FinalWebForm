using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIMS.ProjManagement
{
    /// <summary>
    /// SubmitNewProject 的摘要说明
    /// </summary>
    public class SubmitNewProject : IHttpHandler
    {
        BLL.Operator.CProject bll = new BLL.Operator.CProject();
        Model.ProjectInformation projinfo = new Model.ProjectInformation();

        Model.ProjectParticipation projparti = new Model.ProjectParticipation();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            projinfo.ProjName = context.Request.Form["ProjName"];
            projinfo.ProjTypeId = Convert.ToInt32(context.Request.Form["ProjTypeId"]);
            projinfo.ProjLeader = context.Request.Form["ProjLeaderNum"];
            projinfo.ProjPublisher = "201202080218";
            projinfo.ProjStartTime = Convert.ToDateTime(context.Request.Form["ProjStartTime"]);
            projinfo.ExFinishiTime = Convert.ToDateTime(context.Request.Form["ExFinishiTime"]);
            projinfo.AcFinishiTime = Convert.ToDateTime(context.Request.Form["AcFinishiTime"]);
            projinfo.ProjProfile = context.Request.Form["ProjProfile"];
            projinfo.ProjMark = context.Request.Form["ProjMark"];
            projinfo.ProjMoney = 0;
            projinfo.ProjAttachmentPath = "";

            bool insertResult = bll.InsertProjInfo(projinfo);

            //////////////////////////////////////////新增项目成员/////////////////////////////////////////////////////
            string s = context.Request.Form["ProjReceiverNum"];
            int partiresult = 0;
            string[] a = s.Split(new char[] { '/' });
            projparti.ProjId = projinfo.ProjId;
            for (int i = 0; i < a.Length; i++)
            {
               projparti.ProjReceiverNum = a[i];
               partiresult = bll.AddProjParti(projparti);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////

            if (insertResult)
            {
                context.Response.Write("Yes");
            }
            else
            {
                context.Response.Write("新建项目失败");
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