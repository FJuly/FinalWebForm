/**  。
* ProjectPhoto.cs
*
* 功 能： N/A
* 类 名： ProjectPhoto
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:03 
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
	/// 数据访问类:ProjectPhoto
	/// </summary>
	public  class ProjectPhotoDAL
	{
        /*************************************王顺 2014.10.24*********************************/
        //ws  2014.10.24
        #region 根据Id查找项目截图
        /// <summary>
        /// 根据Id查找项目截图
        /// </summary>
        /// <param name="projId"></param>
        /// <returns>截图列表</returns>
        public List<Model.ProjectPhoto> GetPhotoList(string projId)
        {
            string strSql = "select ProjPhotoId,ProjId,ProjPhotoPath from T_ProjectPhoto where ProjId = '" + projId + "'";
            return SQLHelper.ExcuteList<Model.ProjectPhoto>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 更新项目截图
        /// <summary>
        /// 更新项目截图
        /// </summary>
        /// <param name="projphoto"></param>
        /// <returns>返回受影响行数</returns>
        public int UpdatePhoto(Model.ProjectPhoto projphoto)
        {
            string strSql = "update T_ProjectPhoto set ProjPhotoPath = @ProjPhotoPath where ProjPhotoId = @ProjPhotoId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ProjPhotoPath",projphoto.ProjPhotoPath),
                new SqlParameter("@ProjPhotoId",projphoto.ProjPhotoId)
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
	}
}

