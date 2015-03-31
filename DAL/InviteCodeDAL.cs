/**  。
* InviteCode.cs
*
* 功 能： N/A
* 类 名： InviteCode
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 20:59:57 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
namespace DAL
{
	/// <summary>
	/// 数据访问类:InviteCode
	/// </summary>
	public  class InviteCodeDAL
	{
        public void AddInviteCode(string strInviteCode)
        {
            SQLHelper.ExcuteNonQuery(@"INSERT INTO T_InviteCode InviCode VALUES @InviCode",
                new SqlParameter("@InviCode", strInviteCode));
        }
	}
}

