using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LIMS.ProjManagement
{
    /// <summary>
    /// DelProject 的摘要说明
    /// </summary>
    public class DelProject : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["sessionCurrentUser"] == null)
            {
                context.Response.Redirect("../Login.aspx");
            }
            else
            {
                string projId = context.Request.QueryString["id"];
                string iswork = context.Request.QueryString["iswork"];
                string isperson = context.Request.QueryString["isperson"];
                string isenterprise = context.Request.QueryString["isenterprise"];

                int intId = -1;

                if (int.TryParse(projId, out intId))
                {

                    //           BLL.DetailProjInformation bll = new BLL.DetailProjInformation();
                    BLL.Operator.CProject bll = new BLL.Operator.CProject();

                    if (bll.DelProject(projId))
                    {
                        context.Response.Write("ok");
                    }
                    else
                    {
                        context.Response.Write("nook");
                    }
                }
                else
                {
                    context.Response.Write("nook~");
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