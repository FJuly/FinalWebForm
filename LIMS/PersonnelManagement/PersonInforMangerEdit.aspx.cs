using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.PersonnelManagement
{
    /// <summary>
    /// 修改成员信息
    /// </summary>
    public partial class PersonInforMangerEdit : System.Web.UI.Page
    {
        public Model.V_MemberInformation member;
        /*duty保存成员的职务信息*/
        public string duty = "";
        /*session里面去的字符串*/
        public string stuNum;
        protected void Page_Load(object sender, EventArgs e)
        {    /*修改完个人信息保存个人信息*/
            string IsPostBack = Request["IsPostBack"];
            //string stuNum=Request["stuNum"];
            stuNum = "201258080102";//测试用
            if (!string.IsNullOrEmpty(IsPostBack))
            {

                bool IsSuceess = new BLL.Operator.CInformationManger().PersonInforChange(GetModel());
                if (IsSuceess)
                {
                    Response.Write("修改成功");
                }
                else
                {
                    Response.Write("修改失败");
                }
                Response.End();

                #region 反射不好用，废弃
                //string[] a = Request.Form.AllKeys;
                //Model.MemberInformation model = new Model.MemberInformation();
                //Type t = typeof(Model.MemberInformation);
                //foreach (string s in a)
                //{
                //    PropertyInfo p = t.GetProperty(s);
                //    if (p != null)
                //        p.SetValue(model, Request.Form[s], null);
                //}
                //Response.Write(model.StuName); 
                #endregion
            }
            else {
                /*第一次进入页面获取成员信息*/
                member = new BLL.Operator.CInformationManger().GetPersonInfor(stuNum, ref duty);
            }
        }

        #region 获取成员实体

        private Model.MemberInformation GetModel()
        {
            Model.MemberInformation member = new Model.MemberInformation();
            member.StuName = Request["StuName"];
            member.Gender = Request["Gender"];
            member.QQNum = Request["QQNum"];
            member.Email = Request["Email"];
            member.LoginPwd = Request["LoginPwd"];
            member.Birthday = Convert.ToDateTime(Request["Birthday"]);
            member.Class = Request["Class"];
            member.Counselor = Request["Counselor"];
            member.HeadTeacher = Request["HeadTeacher"];
            member.UndergraduateTutor = Request["UndergraduateTutor"];
            member.TelephoneNumber = Request["TelephoneNumber"];
            member.HomPhoneNumber = Request["HomPhoneNumber"];
            member.FamilyAddress = Request["FamilyAddress"];
            member.Major = Request["Major"];
            member.StuNum = stuNum;
            return member;
            //Request
        } 
        #endregion
    }
}