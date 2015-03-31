using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIMS.ProjManagement
{
    /// <summary>
    /// SaveProjInfo 的摘要说明
    /// </summary>
    public class SaveProjInfo : IHttpHandler
    {
  //      BLL.DetailProjInformation bll = new BLL.DetailProjInformation();
        BLL.Operator.CProject bll = new BLL.Operator.CProject();

        Model.ProjectInformation projinfo = new Model.ProjectInformation();
        Model.ProjectParticipation projparti = new Model.ProjectParticipation();
        Model.ProjectPhoto projphoto = new Model.ProjectPhoto();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //将信息更新到数据库
            projinfo.ProjId = Convert.ToInt32(context.Request.Form["ProjId"]);
            projinfo.ProjName = context.Request.Form["ProjName"];
            projinfo.ProjTypeId = Convert.ToInt32(context.Request.Form["ProjTypeId"]);
            projinfo.ProjLeader = context.Request.Form["ProjLeaderNum"];
            projinfo.ProjPublisher = context.Request.Form["ProjPublisherNum"];
            projinfo.ProjStartTime = Convert.ToDateTime(context.Request.Form["ProjStartTime"]);
            projinfo.ExFinishiTime = Convert.ToDateTime(context.Request.Form["ExFinishiTime"]);
            projinfo.AcFinishiTime = Convert.ToDateTime(context.Request.Form["AcFinishiTime"]);
            projinfo.ProjProfile = context.Request.Form["ProjProfile"];
            projinfo.ProjMark = context.Request.Form["ProjMark"];

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //更新成员列表，先删除再插入
            string s = context.Request.Form["ProjReceiverNum"];
            int partiresult = 0;
            string[] a = s.Split(new char[] { '/' });
            projparti.ProjId = projinfo.ProjId;
            int dr = bll.DeleteProjParti(projparti.ProjId);
            if (dr > 0)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    projparti.ProjReceiverNum = a[i];
                    partiresult = bll.AddProjParti(projparti);
                }
            }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int inforesult = bll.UpdateProjInfo(projinfo);
         

            if (inforesult == 1)
            {
                context.Response.Write(projinfo.ProjId);
            }
            else
            {
                context.Response.Write("No");
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