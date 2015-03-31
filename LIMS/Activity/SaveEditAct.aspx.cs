using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace LIMS.Activity
{
    public partial class SaveEditAct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string actId;
            string actTitle;
            string actLStuName;
            string actLStuNum;
            string actPStuName;
            string actAddress;
            string actTypeName;
            string actTypeId;
            string actStartTime;
            string actEndTime;
            string actExpenses;
            string actContent;
            string actRemark;

            if (Request.Form["txtActTitle"] == null || Request.Form["txtLStuName"] == null || Request.Form["txtPStuName"] == null || Request.Form["txtActAddress"] == null || Request.Form["dtbActStartTime"] == null || Request.Form["dtbActEndTime"] == null || Request.Form["txtActExpenses"] == null || Request.Form["txtaActContent"] == null)
            {
                Response.Write("<script>window.onload = function(){alert(\"服务器忙！\");window.location.href='../Activity/MyActivity.aspx'}</script>");
            }
            else
            {
                actId = Request.Form["txtActId"];
                actTitle = Request.Form["txtActTitle"];
                //actLStuName = Request.Form["txtActStuNum"];
                actLStuNum = Request.Form["txtActStuNum"];
                //actPStuName = Request.Form["txtPStuName"];
                actAddress = Request.Form["txtActAddress"];
                //actTypeName = Request.Form["txtActTypeName"];
                //actTypeId = Request.Form["txtActTypeId"];
                //actTypeId = Request.Form["acttype"];
                actTypeId = Request.Form["acttype"];
                actStartTime = Request.Form["dtbActStartTime"];
                actEndTime = Request.Form["dtbActEndTime"];
                actExpenses = Request.Form["txtActExpenses"];
                actContent = Request.Form["txtaActContent"];
                actRemark = Request.Form["txtaActRemark"];

                ActivityInfo val = new ActivityInfo();
                val.ActId = Convert.ToInt32(actId);
                val.ActTitle = actTitle;
                val.ActLeader = actLStuNum;
                val.ActAddress = actAddress;
                val.ActTypeId = Convert.ToInt32(actTypeId);
                val.ActStartTime = DateTime.Parse(actStartTime);
                val.ActEndTime = DateTime.Parse(actEndTime);
                val.ActExpenses = Convert.ToDecimal(actExpenses);
                val.ActContent = actContent;
                val.ActRemark = actRemark;

               // BLL.ActivityInfoBLL bll = new BLL.ActivityInfoBLL();
                BLL.Operator.CActivityOprate bll = new BLL.Operator.CActivityOprate();
                bll.SaveEditAct(val);

                if (bll.SaveEditAct(val)>-1)
                {
                    Response.Write("<script>window.onload = function(){alert(\"修改成功！\");window.location.href='../Activity/AllActInfo.aspx?ActId=" + actId + "'}</script>");
                }
            }

        }
    }
}