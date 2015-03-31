using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace LIMS
{
    public partial class Login : System.Web.UI.Page
    {
        public static readonly string sessionRoles = "roles";//type is List<object>
        public static readonly string sessionCurrentUser = "cUser";//type is MemberInformation
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static readonly Dictionary<string, string> relation = new Dictionary<string, string>
        {
            {"10001","BLL.Role.CAdmin"},//--------------------//
            {"10002","BLL.Role.CCEO"},                      //
            {"10003","BLL.Role.CTreasurer"},                //有问题
            {"10004","BLL.Role.CStudyLeader"},              //少职务
            {"10005","BLL.Role.CStudyMember"},              //
            {"10006","BLL.Role.CActivityLeader"},//--------------------//
            {"10007","BLL.Role.CActivityMember"},
            {"10008","BLL.Role.CTechnologyLeader"},
            {"10009","BLL.Role.CProjectLeader"},
            {"10010","BLL.Role.CIntern"},
            {"10011","BLL.Rolr.COfficalMember"}
        };


        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void loginBox_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (string.IsNullOrEmpty(loginBox.UserName) || string.IsNullOrEmpty(loginBox.Password))
            {
                return;
            }
            else
            {
                //获取登陆注册对象
                var loginer = new BLL.Operator.CLoginAndRegister();
                //登陆并获取信息
                var minfo = loginer.Login(loginBox.UserName);
                if (minfo != null)//找到用户
                {
                    if (loginBox.Password == minfo.LoginPwd)
                    {//登陆成功
                        //创建用户Session
                        Session["sessionCurrentUser"] = minfo;
                        List<object> objList = new List<object>();
                         //获取对象所有职务Id
                        List<string> listDuty= RelationOfMemberDuty(minfo.StuNum);
                        //将职务ID保存至Session
                        Session["sessionDutyId"] = listDuty;
                        //获取用户职务并实例化所有职务对象
                        foreach (string typeName in  listDuty)
                        {
                            var asm = Assembly.GetAssembly(loginer.GetType());//wwww
                            //
                            objList.Add(asm.CreateInstance(typeName, true));

                        }
                        //将职务对象集合保存至Session以供以后使用
                        Session["sessionRoles"] = objList;
                        e.Authenticated = true;//登陆通过
                        Response.Redirect("Index.aspx");


                    }
                    else
                    {
                        Response.Write("<script>alert('登录失败!密码错误');</script>");
                        //登录失败!密码错误
                    }
                }
                else
                {
                    Response.Write("<script>alert('未找到用户!用户名不存在');</script>");
                    //未找到用户!用户名不存在
                }
            }
        }

        //成员所对应的职务
        private List<string> RelationOfMemberDuty(string stuNum)
        {
            List<string> list = new List<string>();
            BLL.Operator.CEnterDuty ed = new BLL.Operator.CEnterDuty();
            foreach (var di in ed.GetMemberDuty(stuNum))
            {
                list.Add(relation[di.DutyId.ToString()]);
            }
            return list;
        }
    }
}