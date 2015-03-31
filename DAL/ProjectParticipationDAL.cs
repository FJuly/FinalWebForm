/**  。
* ProjectParticipation.cs
*
* 功 能： N/A
* 类 名： ProjectParticipation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:02 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections.Generic;
namespace DAL
{
   
	/// <summary>
	/// 数据访问类:ProjectParticipation
	/// </summary>
	public  class ProjectParticipationDAL
	{

        /*************************************王顺 2014.10.24*********************************/
        //ws  2014.10.24
        #region 获取项目参与者列表
        /// <summary>
        /// 获取项目参与者列表
        /// </summary>
        /// <param name="projId">ProjId</param>
        /// <returns>成员列表</returns>
        public List<Model.ProjectParticipation> GetParticipantsList(string projId)
        {
            string strSql = "select ProjId,ProjReceiverNum = p.ProjReceiver,ProjReceiver = p1.StuName from T_ProjectParticipation p,T_MemberInformation p1 where p.ProjReceiver = p1.StuNum and ProjId = '" + projId + "'";
            return SQLHelper.ExcuteList<Model.ProjectParticipation>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 根据项目Id删除成员信息
        /// <summary>
        /// 根据项目Id删除成员信息
        /// </summary>
        /// <param name="projid"></param>
        /// <returns>受影响行数</returns>
        public int DeleteProjParti(int projid)
        {
            string strSql = "delete from T_ProjectParticipation where ProjId = @ProjId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ProjId",projid)
            };

            return SQLHelper.ExcuteNonQuery(strSql, para);
        } 
        #endregion

        //ws  2014.10.24
        #region 新增项目成员
        /// <summary>
        /// 新增项目成员
        /// </summary>
        /// <param name="projparti"></param>
        /// <returns>受影响行数</returns>
        public int AddProjParti(Model.ProjectParticipation projparti)
        {
            string strSql = "insert into T_ProjectParticipation values(@ProjId,@ProjParti)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ProjId",projparti.ProjId),
                 new SqlParameter("@ProjParti",projparti.ProjReceiverNum)
            };
            return SQLHelper.ExcuteNonQuery(strSql, para);
        } 
        #endregion
	}
}

