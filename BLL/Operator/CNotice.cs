using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operator
{
    public class CNotice
    {
        /// <summary>
        /// 新建通知
        /// </summary>
        /// <param name="notice">通知信息</param>
        /// <param name="receiver">通知参与者</param>
        /// <returns></returns>
        //public bool CreateNotice(Model.Notice notice, Model.ReceiveNotice[] receiver)
        //{
        //    return true;
        //}

        /// <summary>
        ///    选择接收通知的人
        /// </summary>
        /// <param name="id">数据库查询字段</param>
        /// <returns></returns>
        public List<NoticeReceiver> SelectReceiver(string id)
        {
            switch (id)
            {
                case "10001": //10001选出应用方向的人员
                    return new DAL.NoticeDAL().SelectByDirection(id);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 增加一条新的通知
        /// </summary>
        /// <param name="notice">通知实体</param>
        /// <returns>返回新增通知的Id</returns>
        public int CreateNotice(Model.Notice notice)
        {
            return new DAL.NoticeReceiveDAL().CreateNotice(notice);
        }

        /// <summary>
        /// 通知接收
        /// </summary>
        /// <param name="receive">通知接收表实例数组</param>
        /// <returns></returns>
        public bool ReceiveNotice(ReceiveNotice[] receive)
        {
           return new DAL.NoticeReceiveDAL().ReceiveNotice(receive);
        }

         /// <summary>
         /// 获取一条通知
         /// </summary>
         /// <param name="noticeId">通知Id</param>
         /// <returns></returns>
        public Notice GetOneNotice(string noticeId)
        {
           return new DAL.NoticeDAL().GetOneNotice(Convert.ToInt32(noticeId));
        }


        /// <summary>
        /// 获取一个人的所有信息
        /// </summary>
        /// <param name="StuNum">学号</param>
        /// <returns></returns>
        public List<NoticeDateTime> GetAllNotices(string StuNum,int rows,int page,ref int sum)
        {
            List<NoticeDateTime> notices = new DAL.NoticeDAL().GetAllNotices(StuNum,rows, page, ref sum);
            return notices;
        }
    }
}
