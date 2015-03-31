/**  。
* DutyInformation.cs
*
* 功 能： N/A
* 类 名： DutyInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 20:59:56 
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
	/// 数据访问类:DutyInformation
	/// </summary>
	public  class DutyInformationDAL
	{
        #region 获取职务信息
        /// <summary>
        /// 获取职务信息
        /// </summary>
        /// <returns></returns>
        public List<DutyInformation> GetDutyInfor()
        {
            try
            {
                List<DutyInformation> dutyInfor = null;
                dutyInfor = SQLHelper.ExcuteList<DutyInformation>("select *from T_DutyInformation where DutyId!=10001and DutyId!=10008");
                return dutyInfor;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion
	}
}

