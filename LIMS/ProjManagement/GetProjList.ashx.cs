using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace LIMS.ProjManagement
{
    /// <summary>
    /// GetProjList 的摘要说明
    /// </summary>
    public class GetProjList : IHttpHandler,IRequiresSessionState
    {
    //    BLL.ProjectInformation bll = new BLL.ProjectInformation();   
        BLL.Operator.CProject bll = new BLL.Operator.CProject();

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["sessionCurrentUser"] == null)
            {
                context.Response.Redirect("../Login.aspx");
            }
            else
            {
                context.Response.ContentType = "application/json";
                List<Model.PartProjInformation> list = new List<Model.PartProjInformation>();

                ///获取搜索框的值，没有则为空
                StringBuilder sb = new StringBuilder("1=1");
                string searchType = context.Request.Form["search_type"] != "" ? context.Request.Form["search_type"] : string.Empty;
                string searchContent = context.Request.Form["search_value"] != "" ? context.Request.Form["search_value"] : string.Empty;
                int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
                int size = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;


                //按照不同的要求查找
                if (searchType != null && searchContent != null)
                {
                    ///通过项目名称查找
                    if (searchType.ToString() == "ProjName")
                    {
                        list = bll.GetPartListByName(searchContent, page, size);
                    }
                    ///通过项目类型查找
                    else if (searchType.ToString() == "ProjTypeName")
                    {
                        list = bll.GetPartListByType(searchContent, page, size);
                    }
                    ///通过项目主管查找
                    else
                    {
                        list = bll.GetPartListByLeader(searchContent, page, size);
                    }
                }
                else if (searchContent == null)
                {

                    list = bll.GetPartList(page, size);
                }
                else
                {
                    context.Response.Write("查不到您需要的信息");
                }
                ///将list中的元素按照下列类型序列化
                var fin_list = from li in list
                               select
                                   new
                                   {
                                       li.ProjId,
                                       li.StuName,
                                       li.ProjName,
                                       li.ProjTypeName,
                                       ProjStartTime = li.ProjStartTime.ToString("yyyy年MM月dd日"),
                                       AcFinishiTime = li.AcFinishiTime.ToString("yyyy年MM月dd日"),
                                       IdAndType = li.ProjId.ToString() + li.ProjTypeName
                                   };
                JavaScriptSerializer jss = new JavaScriptSerializer();
                //将 list 对象 转成 js数组字符串
                string str = jss.Serialize(fin_list);
                context.Response.Write("{\"rows\":" + str + ",\"total\":\"" + bll.GetProjCount() + "\"}");

                //context.Response.Write(str);
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