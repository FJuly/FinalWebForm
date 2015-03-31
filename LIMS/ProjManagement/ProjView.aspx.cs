using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.ProjManagement
{
    public partial class ProjView : System.Web.UI.Page
    {

        protected string aaa="";

        protected void Page_Load(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {

            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                List<object> roles = (List<object>)Session["sessionRoles"];
                bool isperson = false;                  //个人项目的权限标志
                bool iswork = false;                    //作品项目的权限标志
                bool isenterprise = false;              //企业项目的权限标志
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
                //控制界面标志
                aaa = "var iswork=" + iswork.ToString().ToLower() + ";var isperson=" + isperson.ToString().ToLower() + ";var isenterprise=" + isenterprise.ToString().ToLower() + ";";
                //aaa = "<a style=\"color:#ff6600\" href=\"ProjDetailInfo.aspx?ProjId='+value+'\">查看详情</a>&nbsp;"
                //   + "<a onclick=\"del(this)\" id='+value+' iswork=" + iswork + " isperson=" + isperson + " isenterprise=" + isenterprise + " href=\"javascript:void(0)\" style=\"color:red\">删除</a>";                      
            }
        }
    }
}