using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.ProjManagement
{
    public partial class ProjDetailInfo : System.Web.UI.Page
    {
        protected string projId = "";
        protected List<Model.V_DetailProjInformation> ProjDetailList = new List<Model.V_DetailProjInformation>();
        protected List<Model.ProjectPhoto> ProjPhotoList = new List<Model.ProjectPhoto>();
        protected List<Model.ProjectParticipation> ProjParticipationList = new List<Model.ProjectParticipation>();
        protected string ProjParticipation = "";

        ///控制界面权限标志
        protected string aaa;

     //   BLL.DetailProjInformation bll = new BLL.DetailProjInformation();
        BLL.Operator.CProject bll = new BLL.Operator.CProject();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                List<object> roles = (List<object>)Session["sessionRoles"];
                bool isperson = false;              //个人项目的权限标志
                bool iswork = false;                //作品项目的权限标志
                bool isenterprise = false;          //企业项目的权限标志
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
                    aaa = "var iswork=" + iswork.ToString().ToLower() + ";var isperson=" + isperson.ToString().ToLower() + ";var isenterprise=" + isenterprise.ToString().ToLower() + ";";
                }

                if (Request.QueryString["ProjId"] != null)
                {
                    projId = Request.QueryString["ProjId"].ToString();
                    ProjDetailList = bll.GetDetailList(projId);
                    ProjPhotoList = bll.GetPhotoList(projId);
                    ProjParticipationList = bll.GetParticipantsList(projId);
                    //将成员列表转成字符串
                    for (int i = 0; i < ProjParticipationList.Count; i++)
                    {
                        //在除了第一个成员姓名前加“、”，如“张三、李四、王五”
                        if (i != 0)
                        {
                            ProjParticipation += "、";
                        }
                        ProjParticipation += ProjParticipationList[i].ProjReceiver;
                    }
                }
            }
        }
    }
}