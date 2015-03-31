using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.Activity
{
    public partial class DeleteAct : System.Web.UI.Page
    {
        //BLL.ActivityInfoBLL bll = new BLL.ActivityInfoBLL();
        BLL.Operator.CActivityOprate bll = new BLL.Operator.CActivityOprate();

        protected void Page_Load(object sender, EventArgs e)
        {
     
            string actid = Request.QueryString["id"];
            int result = -1;

            if (actid != null)
            {
                result = bll.DeleteActById(actid);

                if(result>0)
                {
                    Response.Write("ok");
                    Response.End();
                }
                else
                {
                    Response.Write("nook");
                    Response.End();
                }
                
            }
            

            //if (result > 0)
            //{
            //    Response.Write("<script>window.onload = function(){alert(\"删除成功！\");window.location.href='../Activity/MyActivity.aspx'}</script>");
            //}
        }
    }
}