/**  。
* V_ProjectInformation.cs
*
* 功 能： N/A
* 类 名： V_ProjectInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:10 
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
	/// 数据访问类:V_ProjectInformation
	/// </summary>
	public  class V_ProjectInformationDAL
	{
        /*************************************王顺 2014.10.24*********************************/
        //ws  2014.10.24
        #region 分页查找部分项目信息
        /// <summary>
        /// 分页查找部分项目信息
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns>项目信息列表</returns>
        public List<Model.PartProjInformation> GetPartList(int page, int size)
        {
            string strSql = "select TOP " + size + " *from V_PartProjInformation where ProjId not in(select TOP " + size * (page - 1) + " ProjId FROM V_PartProjInformation order BY ProjId desc)order by ProjId desc";
            return SQLHelper.ExcuteList<Model.PartProjInformation>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 分页按项目名称查找部分项目信息
        /// <summary>
        /// 分页按项目名称查找部分项目信息
        /// </summary>
        /// <param name="searchContent">项目名称</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.PartProjInformation> GetPartListByName(string searchContent, int page, int size)
        {
            string strSql = "select TOP " + size + " *from V_PartProjInformation where ProjName like '%" + searchContent + "%' and ProjId not in (select TOP " + size * (page - 1) + " ProjId FROM V_PartProjInformation order by ProjId desc) order by ProjId desc";
            return SQLHelper.ExcuteList<Model.PartProjInformation>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 分页按项目类型查找部分项目信息
        /// <summary>
        /// 分页按项目类型查找部分项目信息
        /// </summary>
        /// <param name="searchContent">项目类型名</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.PartProjInformation> GetPartListByType(string searchContent, int page, int size)
        {
            string strSql = "select TOP " + size + " *from V_PartProjInformation where ProjTypeName like '%" + searchContent + "%' and ProjId not in(select TOP " + size * (page - 1) + " ProjId FROM V_PartProjInformation order BY ProjId desc)order by ProjId desc";
            return SQLHelper.ExcuteList<Model.PartProjInformation>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 分页按项目主管名查找部分项目信息
        /// <summary>
        /// 分页按项目主管名查找部分项目信息
        /// </summary>
        /// <param name="searchContent">项目主管名</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.PartProjInformation> GetPartListByLeader(string searchContent, int page, int size)
        {
            string strSql = "select TOP " + size + " *from V_PartProjInformation where StuName like '%" + searchContent + "%' and ProjId not in(select TOP " + size * (page - 1) + " ProjId FROM V_PartProjInformation order BY ProjId desc)order by ProjId desc";
            return SQLHelper.ExcuteList<Model.PartProjInformation>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 获取项目个数
        /// <summary>
        /// 获取项目个数
        /// </summary>
        /// <returns>项目个数</returns>
        public int GetProjCount()
        {
            string strSql = "select count(0) from V_PartProjInformation";
            return (int)SQLHelper.ExcuteScalar(strSql);
        } 
        #endregion
	}
}

