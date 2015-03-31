using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LIMS.PersonnelManagement
{
    /// <summary>
    /// 头像上传
    /// </summary>
    public class photo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                /*取得session值，为学号*/
                string StuNum = "201258080133";
                HttpPostedFile productImg = context.Request.Files["photo"];
                if (productImg != null)
                {
                     /*每个人的头像名是学号+图片拓展名，学号是唯一的*/
                    string filename = StuNum+Path.GetExtension(productImg.FileName);
                    string ext = Path.GetExtension(productImg.FileName).ToLower();
                    if (!ext.Equals(".gif") && !ext.Equals(".jpg") && !ext.Equals(".png") && !ext.Equals(".bmp"))
                    {

                        context.Response.Write("[{\"success\":\"你上传的文件格式不正确！上传格式有(.gif、.jpg、.png、.bmp)\"}]");
                    }
                    else if (productImg.ContentLength > 1048576 * 5)
                    {
                        context.Response.Write("[{\"success\":\"内容最大为5M\"}]");
                    }
                    else
                    {
                        string s = "[{\"success\":\"yes\"}," + "{\"filename\":\"" + filename + "\"}]";
                        /*这里应该还有一个人判断，将原先的头像删除*/

                        string path = context.Server.MapPath("/photo/"+filename);
                        productImg.SaveAs(path);
                        //将路径保存到数据库
                        if (new BLL.Operator.CInformationManger().UpdatePhoto("photo/"+filename, StuNum))
                        {
                            context.Response.Write("[{\"success\":\"yes\"}," + "{\"filename\":\"" + filename + "\"}]");
                        }
                        else
                        {
                            context.Response.Write("[{\"success\":\"上传失败\"}]");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("[{\"success\":\"上传失败\"}]");
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