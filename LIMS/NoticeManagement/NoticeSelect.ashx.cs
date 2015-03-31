using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LIMS
{
    /// <summary>
    /// 在通知,选择人员时请求该文件得到响应类型的数据
    /// </summary>
    public class NoticeSelect : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string selectId = context.Request["selectId"];
            //获取数据查询字段
            string id = GetDbProperity(selectId);
            //得到json数据
            List<NoticeReceiver> list = new List<NoticeReceiver>();
            list = new BLL.Operator.CNotice().SelectReceiver(id);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(list);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        //获取对应的数据库查询字段
        public string GetDbProperity(string id)
        {
            switch (id)
            {    /*返回10001是是指对应数据库里技术方向的应用方向*/
                case "0":
                    return "10001";
                default:
                    return null;
            }
        }
    }
}