using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.PersonnelManagement
{
    public partial class PositionManger : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string IsPost = Request["IsPost"];
            if (!string.IsNullOrEmpty(IsPost))
            {
                //这里可以通过json格式控制权限
                List<DutyInformation> dutyInfor = null;
                dutyInfor = new BLL.Operator.CEnterDuty().GetDutyInfor();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(dutyInfor);
                Response.Write(json);
                Response.End();
            }
        }
    }
}