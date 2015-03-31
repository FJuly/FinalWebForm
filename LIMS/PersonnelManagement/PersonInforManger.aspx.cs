using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.PersonnelManagement
{
    /// <summary>
    /// 获取个人所有信息
    /// </summary>
    public partial class PersonInforManger : System.Web.UI.Page
    {                                                          
        public Model.V_MemberInformation member;
        /*duty为每个人的职务*/
        public string duty="";
        protected void Page_Load(object sender, EventArgs e)
        {
            string stuNum = Request["StuNum"];
            stuNum = "201258080102";
            /*因为这里不对应具体的权限，所以直接调用操作类的方法*/
            member = new BLL.Operator.CInformationManger().GetPersonInfor(stuNum,ref duty);
            /* 截取图片的后缀名*/
            if (member == null)
            {
                member = new Model.V_MemberInformation();
            }
        }
    }
}