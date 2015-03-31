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

    public partial class NewActivity : System.Web.UI.Page
    {
        protected List<Model.V_SeeActivityInfo> actinfo = new List<Model.V_SeeActivityInfo>();
        //BLL.V_SeeActivityInfoBLL bll = new BLL.V_SeeActivityInfoBLL();
        BLL.Operator.CActivityOprate bll = new BLL.Operator.CActivityOprate();

        protected List<Model.MemberInformation> AllMemberList1 = new List<Model.MemberInformation>();//查找所有成员
        protected List<Model.MemberInformation> AllMemberList2 = new List<Model.MemberInformation>();//查找所有成员
        protected StringBuilder LSallMemberHtml = new StringBuilder(2000);
        protected StringBuilder RecallMemberHtml = new StringBuilder(2000);
        protected StringBuilder PallMemberHtml = new StringBuilder(2000);

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
                
                //foreach (object obj in roles)
                for (int k = 0; k < roles.Count;k++ )
                {
                    object obj = roles[k];
                    if (obj is IActitviy)
                    {

                        ////////////////////////////////////////////查找所有成员信息为负人//////////////////////////////////////////
                        AllMemberList1 = bll.GetAllMemberList();
                        for (int i = 0; i < AllMemberList1.Count; i++)
                        {   //<tr><td><input name="checkbox" type="checkbox" value="201202080217"/></td><td>201202080217</td><td>潘帅</td></tr>
                            LSallMemberHtml.Append("<tr>");
                            LSallMemberHtml.Append("<td><input name=\"LScheckbox\" type=\"radio\" value=" + AllMemberList1[i].StuNum + "></td>");
                            LSallMemberHtml.Append("<td>" + AllMemberList1[i].StuNum + "</td>");
                            LSallMemberHtml.Append("<td><span id=\"StuName" + i + "\">" + AllMemberList1[i].StuName + "</span></td>");
                            LSallMemberHtml.Append("</tr>");
                        }

                        ////////////////////////////////////////////查找所有成员信息为参与人//////////////////////////////////////////
                        AllMemberList2 = bll.GetAllMemberList();
                        for (int i = 0; i < AllMemberList2.Count; i++)
                        {   //<tr><td><input name="checkbox" type="checkbox" value="201202080217"/></td><td>201202080217</td><td>潘帅</td></tr>
                            RecallMemberHtml.Append("<tr>");
                            RecallMemberHtml.Append("<td><input name=\"Reccheckbox\" type=\"checkbox\" value=" + AllMemberList2[i].StuNum + "></td>");
                            RecallMemberHtml.Append("<td>" + AllMemberList2[i].StuNum + "</td>");
                            RecallMemberHtml.Append("<td><span id=\"StuName" + i + "\">" + AllMemberList2[i].StuName + "</span></td>");
                            RecallMemberHtml.Append("</tr>");
                        }

                        ////////////////////////////////////////////查找所有成员信息为发布人//////////////////////////////////////////
                        AllMemberList2 = bll.GetAllMemberList();
                        for (int i = 0; i < AllMemberList2.Count; i++)
                        {   //<tr><td><input name="checkbox" type="checkbox" value="201202080217"/></td><td>201202080217</td><td>潘帅</td></tr>
                            PallMemberHtml.Append("<tr>");
                            PallMemberHtml.Append("<td><input name=\"Pcheckbox\" type=\"radio\" value=" + AllMemberList2[i].StuNum + "></td>");
                            PallMemberHtml.Append("<td>" + AllMemberList2[i].StuNum + "</td>");
                            PallMemberHtml.Append("<td><span id=\"StuName" + i + "\">" + AllMemberList2[i].StuName + "</span></td>");
                            PallMemberHtml.Append("</tr>");
                        }

                        break;
                    }
                    if (k == (roles.Count - 1))
                    {
                        //Response.Write("您没有该权限！");
                        Response.Write("<script>window.onload = function(){alert(\"您没有该权限！\");window.location.href='../Activity/MyActivity.aspx'}</script>");
                    }
                    
                }

       
            }
        }
    }
}