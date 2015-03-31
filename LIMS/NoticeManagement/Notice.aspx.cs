using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.NoticeManagement
{
    public partial class Notice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // reciver为string，通知接受人的学号
            string reciver = Request["reciver"];
            string title=Request["title"];
            string text=Request["text"];
            int id = 0;
            if (!string.IsNullOrEmpty(reciver))
            {
                string[] StuNums = reciver.Split(';');
                Model.Notice notice = new Model.Notice();
                ReceiveNotice[] receive = new ReceiveNotice[StuNums.Length-1];
                /*填充通知实体 */
                notice.NoticeContent = text;
                notice.NoticeTitle = title;
                //通知发布人的学号，到时从session中读出
                notice.Notifier = "201258080133";
                notice.NoticeTime = DateTime.Now;
                id=new BLL.Operator.CNotice().CreateNotice(notice);
                /*当id==0是插入异常*/                                      
                if (id == 0)
                {

                }
                else
                {                    
                    /*填充通知接收人实体*/
                    for (int i = 0; i < StuNums.Length - 1; i++)
                    {
                        receive[i] = new ReceiveNotice();
                        receive[i].NoticeId = id;
                        receive[i].NoticeReceiver = StuNums[i];
                    }
                    //插入数据到通知接受表
                    if (new BLL.Operator.CNotice().ReceiveNotice(receive))
                    {
                       //通知发布成功，转到通知查看页面
                    }
                }

            }
        }
    }
}