using BLL.Interface;
using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.Task
{
    /// <summary>
    /// 
    ///  PS 2014.10.19
    /// </summary>
    public partial class TaskEvaluate : System.Web.UI.Page
    {
        public StringBuilder sbHtml = new StringBuilder(2000);
        public int taskCount = 0;
        private MemberInformation loginer = null;
        private List<object> roles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///判断用户是否登录

            bool havePower = false;

            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {

                loginer = (MemberInformation)Session["sessionCurrentUser"];

                roles = (List<object>)Session["sessionRoles"];

                taskCount = new CTaskOperate().GetStuStudyTaskCount(loginer.StuNum);

                foreach (object obj in roles)
                {
                    if (obj is IEvaluateTask)
                    {
                        havePower = true;
                        break;
                    }
                }

                if (!havePower)
                {
                    Response.Redirect("../PermissionDenied.html");
                }

            }

        }
    }
}