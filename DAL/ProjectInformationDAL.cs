/**  。
* ProjectInformation.cs
*
* 功 能： N/A
* 类 名： ProjectInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:01 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections.Generic;
using Model;
namespace DAL
{
	/// <summary>
	/// 数据访问类:ProjectInformation
	/// </summary>
	public  class ProjectInformationDAL
	{
        /*************************************王顺 2014.10.24*********************************/
        //ws  2014.10.24
        #region 更新项目信息
        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="projinfo"></param>
        /// <returns>返回受影响行数</returns>
        public int UpdateProjInfo(Model.ProjectInformation projinfo)
        {
            string strSql = "update T_ProjectInformation set " +
            "ProjName = @ProjName," +
            "ProjTypeId = @ProjTypeId," +
            "ProjLeader = @ProjLeader," +
            "ProjPublisher = @ProjPublisher," +
            "ProjStartTime = @ProjStartTime," +
            "ExFinishiTime = @ExFinishiTime," +
            "AcFinishiTime = @AcFinishiTime," +
            "ProjProfile = @ProjProfile," +
            "ProjMark = @ProjMark " +
            "where ProjId = @ProjId";

            SqlParameter[] para = new SqlParameter[]
            {                         
              new SqlParameter("@ProjName", projinfo.ProjName),                  
              new SqlParameter("@ProjLeader", projinfo.ProjLeader),
              new SqlParameter("@ProjTypeId",projinfo.ProjTypeId),
              new SqlParameter("@ProjPublisher", projinfo.ProjPublisher),
              new SqlParameter("@ProjStartTime", projinfo.ProjStartTime),
              new SqlParameter("@ExFinishiTime", projinfo.ExFinishiTime),
              new SqlParameter("@AcFinishiTime", projinfo.AcFinishiTime),
              new SqlParameter("@ProjProfile", projinfo.ProjProfile),
              new SqlParameter("@ProjMark", projinfo.ProjMark),
              new SqlParameter("@ProjId", projinfo.ProjId)
            };
            try
            {
                return SQLHelper.ExcuteNonQuery(strSql, para);
            }
            catch
            {
                return -1;
            }
        } 
        #endregion

        //ws  2014.10.24
        #region 新增项目信息
        /// <summary>
        ///  新增项目信息
        /// </summary>
        /// <param name="projinfo"></param>
        /// <returns></returns>
        public int InsertProjInfo(Model.ProjectInformation projinfo)
        {
            string strSql = "insert into T_ProjectInformation values " +
                "(@ProjId,@ProjName," +
                "@ProjLeader,@ProjPublisher," +
                "@ProjStartTime,@ExFinishiTime," +
                "@AcFinishiTime,@ProjProfile," +
                "@ProjMoney,@ProjAttachmentPath,@ProjMark)";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("@ProjName", projinfo.ProjName),
              new SqlParameter("@ProjTypeId",projinfo.ProjTypeId),
              new SqlParameter("@ProjLeader", projinfo.ProjLeader),
              new SqlParameter("@ProjPublisher", projinfo.ProjPublisher),
              new SqlParameter("@ProjStartTime", projinfo.ProjStartTime),
              new SqlParameter("@ExFinishiTime", projinfo.ExFinishiTime),
              new SqlParameter("@AcFinishiTime", projinfo.AcFinishiTime),
              new SqlParameter("@ProjProfile", projinfo.ProjProfile),
              new SqlParameter("@ProjMoney",projinfo.ProjMoney),
              new SqlParameter("@ProjAttachmentPath",projinfo.ProjAttachmentPath),
              new SqlParameter("@ProjMark", projinfo.ProjMark)
            };
            return SQLHelper.ExcuteNonQuery(strSql, para);
        } 
        #endregion

        //ws  2014.10.24
        #region 获取项目进度列表
        /// <summary>
        /// 获取项目进度列表
        /// </summary>
        /// <returns></returns>
        public List<Model.ProjectPhase> GetPlanList()
        {
            string strSql = "select ProjPhaseId,ProjPhase from T_ProjectPhase";
            return SQLHelper.ExcuteList<Model.ProjectPhase>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 获取项目进度信息
        /// <summary>
        /// 获取项目进度信息
        /// </summary>
        /// <returns></returns>
        public List<Model.V_ProjectPhase> GetPlanInfoList()
        {
            string strSql = "select *from V_ProjectPhase";
            return SQLHelper.ExcuteList<Model.V_ProjectPhase>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 获取项目接受者
        /// <summary>
        /// 获取项目接受者
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        /// 反射要用模型
        public List<Model.TaskParticipation> GetTaskReceive(int taskid)
        {
            string strSql = "select TaskId,TaskReceiverName  = StuName,TaskGrade,IsRead,IsComplete from T_MemberInformation,T_TaskParticipation where T_MemberInformation.StuNum = T_TaskParticipation.TaskReceiver and TaskId = @TaskId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TaskId",taskid)
            };
            return SQLHelper.ExcuteList<Model.TaskParticipation>(strSql, para);
        } 
        #endregion

        //ws  2014.10.24
        #region 删除与项目有关的所有信息
        /// <summary>
        /// 删除与项目有关的所有信息
        /// </summary>
        /// <param name="projId"></param>
        /// <returns></returns>
        public int DelProject(string projId)
        {
            string strSql = "delete T_ProjectInformation where ProjId = @projId";
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@projId",projId)
            };
            return SQLHelper.ExcuteNonQuery(strSql, para);

        } 
        #endregion

        /*************************************潘帅 2014.10.19*********************************/
        #region 通过id查找项目名称
        /// <summary>
        /// 通过id查找项目名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetProjNameById(int id)
        {
            return (string)SQLHelper.ExcuteScalar(@"select ProjName from T_ProjectInformation where ProjId = @ProjId", new SqlParameter("@ProjId", id));

        }

        #endregion

        //PS  2014.10.13
        #region 根据项目主管查询项目信息
        /// <summary>
        /// 根据项目主管查询项目信息
        /// </summary>
        /// <param name="projLeader"></param>
        /// <returns></returns>
        public List<ProjectInformation> GetProjByLeader(string projLeader)
        {
            return (List<ProjectInformation>)SQLHelper.ExcuteList<ProjectInformation>("select * from T_ProjectInformation where ProjLeader = @ProjLeader", new SqlParameter("@ProjLeader", projLeader));
        } 
        #endregion

        //PS 2014.10.13
        #region 获取所有项目成员信息
        /// <summary>
        /// 获取所有项目成员信息
        /// </summary>
        /// <param name="projId"></param>
        /// <returns></returns>
        public List<MemberInformation> GetProjMemberList(int projId)
        {
            List<MemberInformation> list = new List<MemberInformation>();
            list = SQLHelper.ExcuteList<MemberInformation>(@"select * from T_MemberInformation where StuNum in (select ProjReceiver from T_ProjectParticipation where ProjId = @ProjId)",
                new SqlParameter("@ProjId", projId));
            return list;
        } 
        #endregion

    }
}

