/**  。
* NoticeReceive.cs
*
* 功 能： N/A
* 类 名： NoticeReceive
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:00 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;
namespace DAL
{
	/// <summary>
	/// 数据访问类:NoticeReceive
	/// </summary>
	public  class NoticeReceiveDAL
	{
        /// <summary>
        /// 增加一条新的通知
        /// </summary>
        /// <param name="notice">通知实体</param>
        /// <returns>返回新增通知的Id</returns>
        public int CreateNotice(Model.Notice notice)
        {
            try
            {
                object obj = SQLHelper.ExcuteScalar(@"insert into T_Notice (NoticeTitle,NoticeContent,NoticeTime,Notifier) values(@NoticeTitle, @NoticeContent,@NoticeTime,@Notifier);select @@identity", 
                    new SqlParameter("@NoticeTitle", notice.NoticeTitle),
                    new SqlParameter("@NoticeContent", notice.NoticeContent),
                    new SqlParameter("@NoticeTime", notice.NoticeTime),
                    new SqlParameter("@Notifier", notice.Notifier));
                int id = Convert.ToInt32(obj);
                return id;
            }
            catch (Exception ex)
            {
                //返回代表出现异常
                return 0;
            }
        }

        /// <summary>
        /// 通知接收
        /// </summary>
        /// <param name="receive">通知接收表实例数组</param>
        /// <returns></returns>
        public bool ReceiveNotice(ReceiveNotice[] receive)
        {
            return SQLHelper.ReceiveNoticeTrans(receive);
        }
	}
}

