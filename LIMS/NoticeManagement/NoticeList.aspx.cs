using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS
{
    public partial class NoticeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*请求消息的实体*/
           string IsPost=Request["IsPost"];
           int rows = Convert.ToInt32(Request["rows"]);
           int page = Convert.ToInt32(Request["page"]);
           int sum = 0;
           if (!string.IsNullOrEmpty(IsPost))
           {
               //从session中取出的学生学号
               string StuNum="201258080102";
               List<Model.NoticeDateTime> list = new BLL.Operator.CNotice().GetAllNotices(StuNum, rows, page, ref sum);
               JavaScriptSerializer js = new JavaScriptSerializer();
               string json = js.Serialize(list);
               StringBuilder res = new StringBuilder();
               res.Append("{\"rows\":").Append(json).Append(",\"total\":\"").Append(sum.ToString()).Append("\"}");
               Response.Write(res.ToString());
               Response.End();
           }
        }
    }
}