using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace LIMS.Activity
{
    public partial class SaveNewAct : System.Web.UI.Page
    {
        MemberInformation loginer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionCurrentUser"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                loginer = (MemberInformation)Session["sessionCurrentUser"];

                string actTitle;
                string actLStuNum;
                string actPStuNum;
                string actReceiver;
                string actAddress;
                string actTypeId;
                string actStartTime;
                string actEndTime;
                string actExpenses;
                string actContent;
                string actRemark;
                //string actAttachmentPath = "123456789";

                actTitle = Request.Form["txtActTitle"];
                actLStuNum = Request.Form["txtActStuNum"];
                //actPStuNum = Request.Form["txtPStuNum"];
                actPStuNum = loginer.StuNum;
                //actReceiver = Request.Form[""];
                actAddress = Request.Form["txtActAddress"];
                actTypeId = Request.Form["acttype"];
                actStartTime = Request.Form["dtbActStartTime"];
                actEndTime = Request.Form["dtbActEndTime"];
                actExpenses = Request.Form["txtActExpenses"];
                actContent = Request.Form["txtaActContent"];
                actRemark = Request.Form["txtaActRemark"];

                ActivityInfo act = new ActivityInfo();

                act.ActTitle = actTitle;
                act.ActPublisher = actPStuNum;
                act.ActLeader = actLStuNum;
                act.ActAddress = actAddress;
                act.ActTypeId = Convert.ToInt32(actTypeId);
                act.ActStartTime = DateTime.Parse(actStartTime);
                act.ActEndTime = DateTime.Parse(actEndTime);
                act.ActContent = actContent;
                act.ActExpenses = Convert.ToDecimal(actExpenses);
                act.ActRemark = actRemark;
                act.ActAttachmentPath = "123456789";

                //--------------------------------------活动信息表的插入------------------------------------------

                BLL.Operator.CActivityOprate bll = new BLL.Operator.CActivityOprate();
                int actid = bll.InsertActInfo(act);


                //--------------------------------------活动参与表的插入------------------------------------------
                //ActivityParticipation part = new ActivityParticipation();
                //BLL.ActivityParticipationBLL bllpart = new BLL.ActivityParticipationBLL();

                //part.ActId = actid;
                //part.IsRead = false;
                //string s = Request.Form["txtReceiverNum"];
                //string[] a = s.Split(new char[] { '/' });
                //int result = -1;
                //for (int i = 0; i < a.Length; i++)
                //{
                //    part.ActReceiver = a[i];
                //    result = bllpart.AddActPart(part);
                //}

                if (actid > -1)
                {
                   // Response.Write("Yes");
                    Response.Redirect("../Activity/MyActivity.aspx");
                }
                else
                {
                    Response.Write("新建项目失败");
                }

            }
        }
    }
}