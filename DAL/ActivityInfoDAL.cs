/**  。
* ActivityInfo.cs
*
* 功 能： N/A
* 类 名： ActivityInfo
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
 * -------------------------------------林志章2014-10-24---------------------------------
* V0.01  2014-07-27 20:59:51 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;
using System.Collections.Generic;
namespace DAL
{
	/// <summary>
	/// 数据访问类:ActivityInfo
	/// </summary>
	public class ActivityInfoDAL
	{
        #region 分页查找部分活动信息
        /// <summary>
        /// 分页查找部分活动信息
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartList(int page, int size)
        {
            string strSql = "select TOP " + size + " * from V_ActivityInformation where ActId not in(select TOP " + size * (page - 1) + " ActId from V_ActivityInformation order by ActId DESC)order by ActId desc";
            //string strSql = "select * from(select top 10 * from (select top  10 * from V_ActivityInformation order by ActId desc )as a order by ActId desc )as b order by ActId desc";
            //string strSql = "select * from V_ActivityInformation where ActId order by desc";
            return SQLHelper.ExcuteList<Model.V_ActivityInformation>(strSql);
        } 
        #endregion

        #region 分页按活动名称查找部分活动信息
        /// <summary>
        /// 分页按活动名称查找部分活动信息
        /// </summary>
        /// <param name="searchContent">活动名称</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartListByActTitle(string searchContent, int page, int size)
        {
            string strSql = "select TOP " + size + " * from V_ActivityInformation where ActTitle like'%" + searchContent + "%' and ActId not in (select TOP " + size * (page - 1) + " ActId from V_ActivityInformation order by ActId desc) order by ActId desc";
            return SQLHelper.ExcuteList<Model.V_ActivityInformation>(strSql);
        } 
        #endregion

        #region 分页按活动类型查找部分活动信息
        /// <summary>
        /// 分页按活动类型查找部分活动信息
        /// </summary>
        /// <param name="searchContent">活动类型名</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartListByActType(string searchContent, int page, int size)
        {
            string strSql = "select TOP " + size + " * from V_ActivityInformation where ActTypeName like '%" + searchContent + "%' and ActId not in(select TOP " + size * (page - 1) + " ActId FROM V_ActivityInformation order BY ActId desc)order by ActId desc";
            return SQLHelper.ExcuteList<Model.V_ActivityInformation>(strSql);
        } 
        #endregion

        #region 分页按活动负责人查找部分活动信息
        /// <summary>
        /// 分页按活动负责人查找部分活动信息
        /// </summary>
        /// <param name="searchContent">活动负责人</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartListByActLeader(string searchContent, int page, int size)
        {
            string strSql = "select TOP " + size + " * from V_ActivityInformation where StuName like '%" + searchContent + "%' and ActId not in(select TOP " + size * (page - 1) + " ActId FROM V_ActivityInformation order BY ActId desc)order by ActId desc";
            return SQLHelper.ExcuteList<Model.V_ActivityInformation>(strSql);
        } 
        #endregion

        #region 通过活动ID来修改活动信息
        /// <summary>
        /// 通过活动ID来修改活动信息
        /// </summary>
        /// <param name="actinfo"></param>
        public int SaveEditAct(ActivityInfo actinfo)
        {
            int sqlpart = -1;
            int sqlsnum = -1;

            sqlpart = SQLHelper.ExcuteNonQuery("update T_ActivityInfo set ActTitle = @ActTitle, ActContent = @ActContent,ActLeader = @ActLeader, ActAddress = @ActAddress,ActTypeId=@ActTypeId,ActStartTime = @ActStartTime, ActEndTime = @ActEndTime, ActExpenses = @ActExpenses, ActRemark = @ActRemark where ActId = @ActId",
               new SqlParameter("@ActTitle", actinfo.ActTitle),
               new SqlParameter("@ActContent", actinfo.ActContent),
               new SqlParameter("@ActLeader", actinfo.ActLeader),
               new SqlParameter("@ActAddress", actinfo.ActAddress),
                // new SqlParameter("@LStuNum",actinfo.LStuNum),
               new SqlParameter("@ActTypeId", actinfo.ActTypeId),
               new SqlParameter("@ActStartTime", actinfo.ActStartTime),
               new SqlParameter("@ActEndTime", actinfo.ActEndTime),
               new SqlParameter("@ActExpenses", actinfo.ActExpenses),
               new SqlParameter("@ActRemark", actinfo.ActRemark),
               new SqlParameter("@ActId", actinfo.ActId)
               );


            return sqlpart;
        } 
        #endregion

        #region 新增活动信息
        /// <summary>
        /// 新增活动信息
        /// </summary>
        /// <param name="actinfo"></param>
        /// <returns></returns>
        public int InsertActInfo(Model.ActivityInfo actinfo)
        {
            int act = -1;
            act = (int)SQLHelper.ExcuteScalar("insert into T_ActivityInfo(ActTitle,ActContent,ActAddress,ActLeader,ActPublisher,ActTypeId,ActStartTime,ActEndTime,ActExpenses,ActRemark,ActAttachmentPath) values (@ActTitle,@ActContent,@ActAddress,@ActLeader,@ActPublisher,@ActTypeId,@ActStartTime,@ActEndTime,@ActExpenses,@ActRemark,@ActAttachmentPath) select top 1 ActId from T_ActivityInfo order by ActId desc",
                new SqlParameter("@ActTitle", actinfo.ActTitle),
                new SqlParameter("@ActContent", actinfo.ActContent),
                new SqlParameter("@ActAddress", actinfo.ActAddress),
                new SqlParameter("@ActLeader", actinfo.ActLeader),
                new SqlParameter("@ActPublisher", actinfo.ActPublisher),
                new SqlParameter("@ActTypeId", actinfo.ActTypeId),
                new SqlParameter("@ActStartTime", actinfo.ActStartTime),
                new SqlParameter("@ActEndTime", actinfo.ActEndTime),
                new SqlParameter("@ActExpenses", actinfo.ActExpenses),
                new SqlParameter("@ActRemark", actinfo.ActRemark),
                new SqlParameter("@ActAttachmentPath", actinfo.ActAttachmentPath)

            );

            return act;
        } 
        #endregion


        #region 根据活动ID删除活动
        /// <summary>
        /// 根据活动ID删除活动
        /// </summary>
        /// <param name="actid"></param>
        /// <returns></returns>
        public int DeleteActById(string actid)
        {
            int act = -1;

            act = SQLHelper.ExcuteNonQuery("DELETE FROM T_ActivityInfo WHERE ActId = @ActId ",
                new SqlParameter("@ActId", actid));

            return act;
        } 
        #endregion
        
	}
}

