/**  。
* ProjectType.cs
*
* 功 能： N/A
* 类 名： ProjectType
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:04 
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
	/// 数据访问类:ProjectType
	/// </summary>
	public  class ProjectTypeDAL
	{
        /*************************************王顺 2014.10.24*********************************/
        //ws  2014.10.24
        #region 查找项目类型列表
        /// <summary>
        ///  查找项目类型列表
        /// </summary>
        /// <returns>项目类型列表</returns>
        public List<Model.ProjectType> GetAllProjType()
        {
            string strSql = "select *from T_ProjectType";
            return SQLHelper.ExcuteList<Model.ProjectType>(strSql);
        } 
        #endregion
	}
}

