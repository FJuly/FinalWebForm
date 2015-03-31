using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.Activity
{
    public partial class EditActInfo : System.Web.UI.Page
    {
        protected List<Model.V_SeeActivityInfo> actinfo = new List<Model.V_SeeActivityInfo>();
        //BLL.V_SeeActivityInfoBLL bll = new BLL.V_SeeActivityInfoBLL();
        BLL.Operator.CActivityOprate bll = new BLL.Operator.CActivityOprate();

        protected List<Model.MemberInformation> AllMemberList = new List<Model.MemberInformation>();//查找所有成员
        protected StringBuilder allMemberHtml = new StringBuilder(2000);
     

        protected void Page_Load(object sender, EventArgs e)
        {
            string actid = Request.QueryString["ActId"];

            if (Request.QueryString["ActId"] != null)
            {
                actinfo = bll.GetActInfo(actid);

                ////////////////////////////////////////////查找所有成员信息//////////////////////////////////////////////
                AllMemberList = bll.GetAllMemberList();
                for (int i = 0; i < AllMemberList.Count; i++)
                {   //<tr><td><input name="checkbox" type="checkbox" value="201202080217"/></td><td>201202080217</td><td>潘帅</td></tr>
                    allMemberHtml.Append("<tr>");
                    allMemberHtml.Append("<td><input name=\"checkbox\" type=\"radio\" value=" + AllMemberList[i].StuNum + "></td>");
                    allMemberHtml.Append("<td>" + AllMemberList[i].StuNum + "</td>");
                    allMemberHtml.Append("<td><span id=\"StuName" + i + "\">" + AllMemberList[i].StuName + "</span></td>");
                    allMemberHtml.Append("</tr>");
                }

            }
        }
    }
}