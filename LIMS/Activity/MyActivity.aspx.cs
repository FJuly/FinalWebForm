using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Interface;
using Model;

namespace LIMS.Activity
{
    public partial class MyActivity : System.Web.UI.Page
    {
        protected StringBuilder hrefa = new StringBuilder(2000);

        MemberInformation loginer;
        List<object> roles = null;
        protected string aaa = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                loginer = (MemberInformation)Session["sessionCurrentUser"];

                roles = (List<object>)Session["sessionRoles"];

                bool isActLeader = false;

                for (int k = 0; k < roles.Count; k++)
                {
                    object obj = roles[k];
                    if (obj is IActitviy)
                    {
                        //hrefa.Append("'<a style=\"color:red;\"  href=\"AllActInfo.aspx?ActId='+value+'\">活动详情</a>'");
                        //hrefa.Append("'<a style=\"color:red;\"  href=\"AllActInfo.aspx?ActId='+value+'\">活动详情</a>'");
                        isActLeader = true;
                        break;
                    }
                }

                aaa = "var isActLeader=" + isActLeader.ToString().ToLower()+";";
            }
        }
    }
}