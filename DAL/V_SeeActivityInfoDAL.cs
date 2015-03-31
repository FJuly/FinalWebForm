using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using Model;

//------------------------------------林志章2014-10-24----------------------------------------

namespace DAL
{
    public class V_SeeActivityInfoDAL
    {

        #region 通过活动Id获得活动的详细信息
        /// <summary>
        /// 通过活动Id获得活动的详细信息
        /// </summary>
        /// <param name="id">活动Id</param>
        /// <returns></returns>
        public List<Model.V_SeeActivityInfo> GetActInfo(string id)
        {
            string strSql = "select * from V_SeeActivityInfo where ActId = " + id + "";
            return SQLHelper.ExcuteList<Model.V_SeeActivityInfo>(strSql);
        } 
        #endregion


        #region 获得所有成员的信息
        /// <summary>
        /// 获得所有成员的信息
        /// </summary>
        /// <returns></returns>
        public List<Model.MemberInformation> GetAllMemberList()
        {
            string strSql = "select *from T_MemberInformation";
            return SQLHelper.ExcuteList<Model.MemberInformation>(strSql);
        } 
        #endregion

        #region 获取总的活动条数
        /// <summary>
        /// 获取总的活动条数
        /// </summary>
        /// <returns></returns>
        public int GetActCount()
        {
            int sql = -1;
            sql = (int)SQLHelper.ExcuteScalar("select count(*) from V_ActivityInformation");
            return sql;
        } 
        #endregion
    }
}
