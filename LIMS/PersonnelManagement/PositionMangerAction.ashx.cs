using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LIMS.PersonnelManagement
{
    /// <summary>
    /// PositionMangerAction 的摘要说明
    /// </summary>
    public class PositionMangerAction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            //如果IsEnter不为空则为录入职位
            string IsEnter=context.Request["IsEnter"];
            //如果IsGet不为空则为是取相应职位的数据
            string IsGet=context.Request["IsGet"];
            //如果 IsAgain不为空录完职位后获取数据
            string IsAgain = context.Request["IsAgain"];
            string DutyId = context.Request["DutyId"];
            if (!string.IsNullOrEmpty(IsGet))
            {

                List<CheckMemberInfor> list = null;
                list = new BLL.Operator.CEnterDuty().GetSelectMember(DutyId);
                string json = js.Serialize(list);
                context.Response.Write(json);
            }
            if (!string.IsNullOrEmpty(IsEnter))
            {
                string StuNum = context.Request["StuNum"];
                if (new BLL.Operator.CEnterDuty().EnterDuty(DutyId, StuNum))
                {
                    context.Response.Write("录入成功！！");
                }
                else
                {
                    context.Response.Write("录入失败！！");
                }
            }

            if (!string.IsNullOrEmpty(IsAgain))
            {
                List<CheckMemberInfor> listDuty = null;
                listDuty = new BLL.Operator.CEnterDuty().GetDutyMember(DutyId);
                if (listDuty != null)
                {
                    string json = js.Serialize(listDuty);
                    context.Response.Write(json);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}