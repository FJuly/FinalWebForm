using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LIMS.ProjManagement
{
    /// <summary>
    /// SaveProjPhoto 的摘要说明
    /// </summary>
    public class SaveProjPhoto : IHttpHandler
    {
   //     BLL.DetailProjInformation bll = new BLL.DetailProjInformation();
        BLL.Operator.CProject bll = new BLL.Operator.CProject();

        Model.ProjectPhoto projphoto = new Model.ProjectPhoto();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                //图片存入数据库成功次数的标志
                int flag = 0;

                for (int i = 1; i <= 3; i++)
                {
                    HttpPostedFile productImg = context.Request.Files["photo"+i.ToString()];
                    projphoto.ProjPhotoId = Convert.ToInt32(context.Request.Form["ProjPhoto" + i.ToString()]);
                    if (Path.GetExtension(productImg.FileName).ToLower() != "")
                    {

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(productImg.FileName);
                        string ext = Path.GetExtension(productImg.FileName).ToLower();
                        if (!ext.Equals(".gif") && !ext.Equals(".jpg") && !ext.Equals(".png") && !ext.Equals(".bmp"))
                        {

                            context.Response.Write("[{\"success\":\"你上传的文件格式不正确！上传格式有(.gif、.jpg、.png、.bmp)\"}]");
                            break;
                        }
                        else if (productImg.ContentLength > 1048576 * 5)
                        {
                            context.Response.Write("[{\"success\":\"内容最大为5M\"}]");
                            break;
                        }
                        else
                        {
                            /*这里应该还有一个人判断，将原先的头像删除*/
                            //path 的路径是 ....\\ProjMangerment\\图片.jpg要将他改为...\\ProjMangerment\\Images\\图片.jpg
                            string path = context.Server.MapPath(filename);
                            string[] s = path.Split(new char[] { '\\' });
                            string path1 = "";
                            s[s.Length - 2] = "ProjManagement\\Images";
                            for (int j = 0; j < s.Length; j++)
                            {
                                if (j != 0)
                                {
                                    s[j] = "\\" + s[j];
                                }
                                path1 += s[j];
                            }

                            //将图片上传到path1指定的路径
                            productImg.SaveAs(path1);
                            //存数据库的路径为../Images/图片.jpg
                            path = "Images/" + s[s.Length - 1];
                            projphoto.ProjPhotoPath = path;
                          
                            
                            //将路径保存到数据库
                            if (bll.UpdatePhoto(projphoto) == 1)
                            {
                            //    context.Response.Write("[{\"success\":\"Yes\"}," + "{\"filename\":\"" + filename + "\"}]");
                            //    context.Response.Write("Yes");
                                flag++;
                            }
                            //else
                            //{
                            //    //    context.Response.Write("[{\"success\":\"上传失败\"}]");
                            //    context.Response.Write("图片更新失败");
                            //    break;
                            //}

                        }
                    }
                    else
                    {
                        //    context.Response.Write("[{\"success\":\"Yes\"}]");
                        //如果图片没有修改，也算成功存入图片，标志+1
                        flag++;
                    }
                }
                //如果成功存入三张图片，返回Yes
                if (flag == 3)
                {
                    context.Response.Write("Yes");
                }
                else {
                    context.Response.Write("图片更新失败"+flag);
                }
            }
            catch (Exception ex)
            {
             //   context.Response.Write("[{\"success\":\"上传失败\"}]");
                context.Response.Write("图片更新异常");
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