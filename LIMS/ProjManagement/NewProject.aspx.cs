using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.ProjManagement
{
    public partial class NewProject : System.Web.UI.Page
    {
        protected List<Model.ProjectType> ProjTypeList = new List<Model.ProjectType>();
   //     BLL.DetailProjInformation bll = new BLL.DetailProjInformation();
        BLL.Operator.CInformationManger bll = new BLL.Operator.CInformationManger();
        BLL.Operator.CProject bll2 = new BLL.Operator.CProject();

        protected StringBuilder sbHtml = new System.Text.StringBuilder(2000);

        protected List<Model.MemberInformation> AllMemberList = new List<Model.MemberInformation>();//查找所有成员
        protected StringBuilder allMemberHtml = new StringBuilder(2000);

        protected StringBuilder leaderHtml = new System.Text.StringBuilder(2000);  //项目主管
        protected List<Model.MemberInformation> MemberList = new List<Model.MemberInformation>(); //项目主管候选人

        //界面权限控制标志
        bool isperson = false;                  //个人项目的权限标志
        bool iswork = false;                    //作品项目的权限标志
        bool isenterprise = false;              //企业项目的权限标志

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                //获取权限
                GetPermissions();
 
               //获取项目类型
                GetAllProjType();

                //获取项目参与者合适人选
                GetAllMemberList();

                //项目主管下拉框option的数据
                GetProjLeader();

            }          
        }

        //获取权限
        private void GetPermissions() {
            List<object> roles = (List<object>)Session["sessionRoles"];

            foreach (object role in roles)
            {
                //角色是否继承个人项目接口
                if (role is BLL.Interface.IPersonalProj)
                {
                    isperson = true;
                }
                //角色是否继承作品项目接口
                if (role is BLL.Interface.IWorkProj)
                {
                    iswork = true;
                }
                //角色是否继承企业项目接口
                if (role is BLL.Interface.IEnterpriseProj)
                {
                    isenterprise = true;
                }
            }
        }

        //获取项目类型
        private void GetAllProjType() {
            ProjTypeList = bll2.GetAllProjType();
            for (int i = 0; i < ProjTypeList.Count; i++)
            {
                if (ProjTypeList[i].ProjTypeName.ToString() == "个人项目" && isperson || ProjTypeList[i].ProjTypeName.ToString() == "作品项目" && iswork || ProjTypeList[i].ProjTypeName.ToString() == "企业项目" && isenterprise)
                {
                    sbHtml.Append("<option value=" + ProjTypeList[i].ProjTypeId + ">");
                    sbHtml.Append(ProjTypeList[i].ProjTypeName);
                    sbHtml.Append("</option>");
                }
                else {
                    i++;
                }
            }
        }

        //获取项目参与者合适人选
        private void GetAllMemberList(){
            AllMemberList = bll.GetAllMemberList();
            for (int i = 0; i < AllMemberList.Count; i++)
            {   //<tr><td><input name="checkbox" type="checkbox" value="201202080217"/></td><td>201202080217</td><td>潘帅</td></tr>
                allMemberHtml.Append("<tr>");
                allMemberHtml.Append("<td><input name=\"checkbox\" type=\"checkbox\" value=" + AllMemberList[i].StuNum + "></td>");
                allMemberHtml.Append("<td>" + AllMemberList[i].StuNum + "</td>");
                allMemberHtml.Append("<td><span id=\"StuName" + i + "\">" + AllMemberList[i].StuName + "</span></td>");
                allMemberHtml.Append("</tr>");
            }    
        }

        //项目主管下拉框option的数据
        private void GetProjLeader() {
            MemberList = bll.GetProjLeader();
            for (int i = 0; i < MemberList.Count; i++)
            {
                leaderHtml.Append("<option value=" + MemberList[i].StuNum + ">");
                leaderHtml.Append(MemberList[i].StuName);
                leaderHtml.Append("</option>");
            }
        }

    }
}