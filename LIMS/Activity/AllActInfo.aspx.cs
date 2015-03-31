using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Interface;
using Model;

namespace LIMS.Activity
{
    public partial class AllActInfo : System.Web.UI.Page
    {
        public List<Model.V_SeeActivityInfo> list = new List<Model.V_SeeActivityInfo>();
        BLL.Operator.CActivityOprate bll = new BLL.Operator.CActivityOprate();

        protected StringBuilder editdelete = new StringBuilder(2000);

        MemberInformation loginer;
        List<object> roles = null;
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
               // Response.Write(roles);

                string actid = Request.QueryString["ActId"];
                if (Request.QueryString["ActId"] != null)
                {
                    list = bll.GetActInfo(actid);

                }

                //foreach (object obj in roles)
                //{
                //    if (obj is IActitviy)
                //    {
                //        editdelete.Append("<input type=\"button\" value=\"删除\" class=\"btn-dele\" id=\"dele-list\"/>");
                //        editdelete.Append("<input type=\"button\" value=\"编辑\" class=\"btn-edit\" id=\"edit-list\"/>");
                //        break;
                //    }

                //    editdelete.Append("");
                //}
                for (int i = 0; i < roles.Count; i++)
                {
                    object obj = roles[i];
                    if (obj is IActitviy)
                    {
                        //editdelete.Append("<input type=\"button\" value=\"删除\" class=\"btn-dele\" id=\"dele-list\"/>");
                        editdelete.Append("<input type=\"button\" value=\"编辑\" class=\"btn-edit\" id=\"edit-list\"/>");
                        break;
                    }

                    if (i == roles.Count - 1)
                    {
                        editdelete.Append("");
                    }
                }
                
            }
            
            
        }
    }
}