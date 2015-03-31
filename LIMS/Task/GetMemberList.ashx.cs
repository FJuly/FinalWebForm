using BLL;
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
    /// 获取成员表
    ///  PS 2014.10.19
    /// </summary>
    public class GetMemberList : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.ContentType = "text/plain";
            List<MemberInformation> memberList = new List<MemberInformation>();
            string strType;

             ///判断用户是否登录
            if (context.Session["sessionCurrentUser"] == null)
            {
                context.Response.Redirect("../Login.aspx");
            }
            else
            {
                strType = context.Request.QueryString["type"];

                int type = 0;
                int projId = 10001;

                

                if (Int32.TryParse(strType, out type))
                {
                    switch (type)
                    {
                        case 1:
                            memberList = new CInformationManger().GetAll();
                            break;
                        case 2:
                            memberList = new CInformationManger().GetByTechLevelId(10001);
                            break;
                        case 3:
                            memberList = new CInformationManger().GetRegularMember();
                            break;
                        case 4:
                            memberList = new CInformationManger().GetByTechDireId(10001);
                            break;
                        case 5:
                            memberList = new CInformationManger().GetByTechDireId(10002);
                            break;
                        case 6:
                            memberList = new CInformationManger().GetByTechDireId(10003);
                            break;
                        case 7:
                            try
                            {
                                projId = Int32.Parse(context.Request.QueryString["proj"]);
                            }
                            catch
                            {
                                context.Response.Write("");
                            }
                            memberList = new CProject().GetProjMemberList(projId);
                            break;
                    }
                }

                if (memberList != null)
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string strJSon = jss.Serialize(memberList);
                    context.Response.Write(strJSon);
                }
                else
                {
                    context.Response.Write("");
                }
            }
            
            
            
        }

        //private List<MemberInformation> GetAllMember(HttpContext context)
        //{
        //    List<object> roles = (List<object>)context.Session["sessionRoles"];

        //    foreach (object role in roles)
        //    {
        //        if (role is BLL.Interface.IProjTask)
        //        {
        //            BLL.Interface.IProjTask op = role as BLL.Interface.IProjTask;
        //            //op.CreateProjTask();
        //        }
        //    }

        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}