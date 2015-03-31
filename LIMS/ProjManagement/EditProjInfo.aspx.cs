using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.ProjManagement
{
    public partial class EditProjInfo : System.Web.UI.Page
    {
 //     BLL.DetailProjInformation bll = new BLL.DetailProjInformation();
        BLL.Operator.CProject bll = new BLL.Operator.CProject();
        BLL.Operator.CInformationManger bll2 = new BLL.Operator.CInformationManger();

        protected string projId = "";
        /////////////////////////////////////定义与项目参与成员有关的变量/////////////////////////////////////////
        protected List<Model.MemberInformation> AllMemberList = new List<Model.MemberInformation>();//查找所有成员
        protected StringBuilder allMemberHtml = new StringBuilder(2000);
        protected List<Model.ProjectParticipation> ProjParticipationList = new List<Model.ProjectParticipation>();
        protected string ProjParticipation = "";
        protected string ProjParticipationNum = "";

        /////////////////////////////////////定义所有项目信息有关的变量////////////////////////////////////////////
        protected List<Model.V_DetailProjInformation> ProjDetailList = new List<Model.V_DetailProjInformation>();
        protected List<Model.ProjectType> ProjTypeList = new List<Model.ProjectType>();
        protected StringBuilder sbHtml = new System.Text.StringBuilder(2000);                      //项目类型
        protected StringBuilder leaderHtml = new System.Text.StringBuilder(2000);                  //项目主管
        protected string ProjStartTime;
        protected string ExFinishiTime;
        protected string AcFinishiTime;
        protected List<Model.MemberInformation> MemberList = new List<Model.MemberInformation>(); //项目主管候选人


        //////////////////////////////////////////定义项目截图列表/////////////////////////////////////////////////
        protected List<Model.ProjectPhoto> ProjPhotoList = new List<Model.ProjectPhoto>();

        //界面权限控制标志
        bool isperson = false;                  //个人项目的权限标志
        bool iswork = false;                    //作品项目的权限标志
        bool isenterprise = false;              //企业项目的权限标志
        //////////////////////////////////////////////////////实现方法/////////////////////////////////////////////        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                GetPermissions();
                if (Request.QueryString["ProjId"] != null)
                {
                    projId = Request.QueryString["ProjId"].ToString();
                    //获取项目信息
                    GetDetailList();

                   //将成员列表转成字符串
                    GetParticipantsList();

                    //项目主管下拉框option的数据
                    GetProjLeader();

                    //项目类型下拉框option的数据
                    GetAllProjType();

                    //查找所有成员信息
                    GetAllMemberList();
                }
            }

           
        }



        //获取权限
        private void GetPermissions()
        {
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

        //获取项目信息
        private void GetDetailList() {
            ProjDetailList = bll.GetDetailList(projId);
            //将时间2012/02/02 转成 2012-02-02格式
            ProjStartTime = ProjDetailList[0].ProjStartTime.ToString().Replace("/", "-");
            ExFinishiTime = ProjDetailList[0].ExFinishiTime.ToString().Replace("/", "-");
            AcFinishiTime = ProjDetailList[0].AcFinishiTime.ToString().Replace("/", "-");
            //获取项目截图列表
            ProjPhotoList = bll.GetPhotoList(projId);
        }

        //将成员列表转成字符串
        private void GetParticipantsList(){
            //获取项目成员列表
            ProjParticipationList = bll.GetParticipantsList(projId);
            for (int i = 0; i < ProjParticipationList.Count; i++)
            {
                //在除了第一个成员姓名前加“、”，如“张三、李四、王五”
                //在除了第一个成员学号前加 “/”,如"21023123/13213213/213213213/"
                if (i != 0)
                {
                    ProjParticipation += "、";
                    ProjParticipationNum += "/";
                }
                ProjParticipation += ProjParticipationList[i].ProjReceiver;
                ProjParticipationNum += ProjParticipationList[i].ProjReceiverNum;
            }
        }

        //项目主管下拉框option的数据
        private void GetProjLeader(){
            MemberList = bll2.GetProjLeader();
            for (int i = 0; i < MemberList.Count; i++)
            {
                if (ProjDetailList[0].ProjLeader.ToString() == MemberList[i].StuName.ToString())
                {
                    leaderHtml.Append("<option selected=\"selected\" value=" + MemberList[i].StuNum + ">");
                }
                else
                {
                    leaderHtml.Append("<option value=" + MemberList[i].StuNum + ">");
                }
                leaderHtml.Append(MemberList[i].StuName);
                leaderHtml.Append("</option>");
            }  
        }


        //查找所有成员信息
        private void GetAllMemberList() {
            AllMemberList = bll2.GetAllMemberList();
            for (int i = 0; i < AllMemberList.Count; i++)
            {   //<tr><td><input name="checkbox" type="checkbox" value="201202080217"/></td><td>201202080217</td><td>潘帅</td></tr>
                allMemberHtml.Append("<tr>");
                allMemberHtml.Append("<td><input name=\"checkbox\" type=\"checkbox\" value=" + AllMemberList[i].StuNum + "></td>");
                allMemberHtml.Append("<td>" + AllMemberList[i].StuNum + "</td>");
                allMemberHtml.Append("<td><span id=\"StuName" + i + "\">" + AllMemberList[i].StuName + "</span></td>");
                allMemberHtml.Append("</tr>");
            }
        }


        //项目类型下拉框option的数据
        private void GetAllProjType() {
            ProjTypeList = bll.GetAllProjType();
            for (int i = 0; i < ProjTypeList.Count; i++)
            {
                //控制项目类型的显示
                if (ProjTypeList[i].ProjTypeName.ToString() == "个人项目" && isperson || ProjTypeList[i].ProjTypeName.ToString() == "作品项目" && iswork || ProjTypeList[i].ProjTypeName.ToString() == "企业项目" && isenterprise)
                {
                    //设置默认选项，如果此项目的项目类型和下拉框里的一个选项相同，则显示这个选项
                    if (ProjDetailList[0].ProjTypeName.ToString() == ProjTypeList[i].ProjTypeName.ToString())
                    {
                        sbHtml.Append("<option selected=\"selected\" value=" + ProjTypeList[i].ProjTypeId + ">");
                    }
                    else
                    {
                        sbHtml.Append("<option value=" + ProjTypeList[i].ProjTypeId + ">");
                    }

                    sbHtml.Append(ProjTypeList[i].ProjTypeName);
                    sbHtml.Append("</option>");
                }
                else {
                    i++;
                }
            }
        }
        
    }
}