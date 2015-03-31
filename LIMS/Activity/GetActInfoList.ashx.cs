using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

/*------------------------------林志章-------------------------------------*/
namespace LIMS.Activity
{
    /// <summary>
    /// GetActInfoList 的摘要说明
    /// </summary>
    public class GetActInfoList : IHttpHandler
    {
        //BLL.ActivityInfoBLL bll = new BLL.ActivityInfoBLL();
        BLL.Operator.CActivityOprate bll = new BLL.Operator.CActivityOprate();

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.Write("aaa");
            context.Response.ContentType = "application/json";
            List<Model.V_ActivityInformation> list = new List<Model.V_ActivityInformation>();

            //获取搜索框的值，没有则为空
            StringBuilder sbl = new StringBuilder("1=1");
            string searchType = context.Request.Form["search_type"] != "" ? context.Request.Form["search_type"] : string.Empty;
            string searchContent = context.Request.Form["search_value"] != "" ? context.Request.Form["search_value"] : string.Empty;

            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int size = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;

            //按照不同的要求查找
            if (searchType != null && searchContent != null)
            {
                //通过活动标题查找
                if (searchType.ToString() == "ActTitle")
                {
                    list = bll.GetPartListByActTitle(searchContent, page, size);
                }
                //通过活动类型查找
                else if (searchType.ToString() == "ActTypeName")
                {
                    list = bll.GetPartListByActType(searchContent, page, size);
                }
                //通过活动负责人查找
                else
                {
                    list = bll.GetPartListByActLeader(searchContent, page, size);
                }
            }

            else if (searchContent == null)
            {
                //context.Response.Write("aaa");
                list = bll.GetPartList(page, size);
            }
            else
            {
                context.Response.Write("查不到您所查找的信息！");
            }

            //将list中的元素按照下列类型序列化
            var fin_list = from li in list
                           select
                               new
                               {
                                   li.ActId,
                                   li.ActTitle,
                                   li.ActAddress,
                                   li.StuName,
                                   li.ActTypeName,
                                   ActStartTime = li.ActStartTime.ToString("yyyy年MM月dd日"),                               
                               };

            JavaScriptSerializer jss = new JavaScriptSerializer();
            //将list对象转成JS数组字符串
            string str = jss.Serialize(fin_list);
            context.Response.Write("{\"rows\":"+str+",\"total\":\""+bll.GetActCount()+"\"}");

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