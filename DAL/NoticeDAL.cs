/**  。
* Notice.cs
*
* 功 能： N/A
* 类 名： Notice
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 20:59:59 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;
using System.Collections.Generic;
using System.Configuration;
namespace DAL
{
	/// <summary>
	/// 数据访问类:Notice
	/// </summary>
	public  class NoticeDAL
	{
        #region 根据技术方向id获取通知接收人
        /// <summary>
        /// 根据技术方向id获取通知接收人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<NoticeReceiver> SelectByDirection(string id)
        {
            List<NoticeReceiver> list = null;
            try
            {
                list = SQLHelper.ExcuteList<NoticeReceiver>("select StuName,StuNum from T_MemberInformation where TechDireId=" + id);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 获取一条通知
        /// <summary>
        /// 获取一条通知
        /// </summary>
        /// <param name="noticeId">通知Id</param>
        /// <returns></returns>
        public Notice GetOneNotice(int noticeId)
        {
            try
            {
                List<Notice> list = SQLHelper.ExcuteList<Notice>("select *from T_Notice where NoticeId=@noticeId", new SqlParameter("@noticeId", noticeId));
                return list[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        /// <summary>
        /// 获取一个人的所有信息
        /// </summary>
        /// <param name="StuNum">学号</param>
        /// <returns></returns>
        public List<NoticeDateTime> GetAllNotices(string StuNum, int rows, int page, ref int sum)
        {
            /*创建的分页存储过程（sum为查询出的记录总数）
               create procedure checknotice
               @sum int output,
               @rowBottom int=0,
               @rowUp int=10,
               @StuNum nvarchar(20)
               as
               select @sum=Count(*) from T_NoticeReceive where NoticeReceiver=@StuNum
               
               select *from
               (select *,ROW_NUMBER()over(order by StuName asc) as number from
               (select StuName,t1.NoticeId,NoticeTitle,NoticeTime,NoticeContent,IsRead from (T_Notice t1 inner join T_NoticeReceive t2 on t1.NoticeId=t2.NoticeId) inner join T_MemberInformation m on t1.Notifier= m.StuNum where t2.NoticeReceiver=@StuNum) as tb1) as tb2
               where number>@rowBottom and number<@rowUp
            */
            int rowBottom = rows * (page - 1);
            int rowUp = rows * page;
            sum = 0;
            try
            {    /*创建的存储过程名*/
                string strsql = "checknotice";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] paras = {
                                           new SqlParameter("@sum",sum),
                                           new SqlParameter("@rowBottom",rowBottom),
                                           new SqlParameter("@rowUp",rowUp),
                                           new SqlParameter("@StuNum",StuNum)
                                       };
                    paras[0].Direction = ParameterDirection.Output;
                    da.SelectCommand.Parameters.AddRange(paras);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    sum = Convert.ToInt32(da.SelectCommand.Parameters[0].Value);
                    return ToList(dt);
                }
            }
            catch (Exception ex)
            {
                return null;
            } 
        }

        /// <summary>
        /// 将DataTable转成List集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<NoticeDateTime> ToList(DataTable dt)
        {
            List<NoticeDateTime> notices = new List<NoticeDateTime>();
            foreach (DataRow row in dt.Rows)
            {
                NoticeDateTime notice = new NoticeDateTime();
                notice.NoticeId = Convert.ToInt32(row["NoticeId"]);
                notice.NoticeTitle = row["NoticeTitle"].ToString();
                notice.NoticeTime = Convert.ToDateTime(row["NoticeTime"]).ToLongDateString();
                notice.NoticeContent = row["NoticeContent"].ToString();
                notice.Notifier = row["StuName"].ToString();
                notice.IsRead = row["IsRead"].ToString();
                notices.Add(notice);
            }
            return notices;
        }
	}
}

