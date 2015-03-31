using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LIMS.PersonnelManagement
{
    /// <summary>
    /// DeleteMember 的摘要说明
    /// </summary>
    public class DeleteMember : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string StuNum = context.Request["StuNum"];

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