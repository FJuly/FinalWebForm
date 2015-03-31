using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.NoticeManagement
{
    public partial class MyNotice : System.Web.UI.Page
    {
         
        public Model.Notice notice=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*获取学号session，将通知标识为已读*/
            /*获取通知的Id*/
            string noticeId=Request["noticeId"];
            notice = new BLL.Operator.CNotice().GetOneNotice(noticeId);
        }                                                                                   
    }
}