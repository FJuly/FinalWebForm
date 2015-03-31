/**  。
* DutyAct.cs
*
* 功 能： N/A
* 类 名： DutyAct
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 20:59:55 
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
	/// 数据访问类:DutyAct
	/// </summary>
	public  class DutyActDAL
	{
        #region DAL录入职务
        /// <summary>
        /// DAL录入职务
        /// </summary>
        /// <param name="listAct">录入人员列表，职务id</param>
        /// <param name="id"></param>
        /// <returns>成功返回true</returns>
        public bool EnterDuty(List<DutyAct> listAct, int id)
        {
            /*在插入每个人的职务之前先将这个职务的所有人先删除*/
            string[] sql = new string[listAct.Count+1];
            sql[0] = "delete from T_DutyAct where DutyID=" + id.ToString();
            //然后插入每条数据
            for (int i = 1; i < listAct.Count+1; i++)
            {
                sql[i] = "insert into T_DutyAct (DutyID,DutyActor) values(" + listAct[i-1].DutyId +",'" +listAct[i-1].DutyActor+ "')";
            }
            return SQLHelper.Transaction(sql);
        }
        #endregion 

        #region 获取对应职务的人
        /// <summary>
        /// 获取对应职务的人
        /// </summary>
        /// <param name="id">对应职务的id</param>
        /// <returns>返回符合职位的成员列表</returns>
        public List<CheckMemberInfor> GetDutyMember(int id)
        {
            List<CheckMemberInfor> list = null;
            /*这里Model存在问题，一时不知道怎么解决*/
            list = SQLHelper.ExcuteList<CheckMemberInfor>(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from  V_MemberInformation where StuNum in (select DutyActor from T_DutyAct where DutyId=@id)"
                , new SqlParameter("@id", id));
            return list;
        } 
        #endregion


        #region 获取人的对应职务
        /// <summary>
        /// 获取人的对应职务
        /// </summary>
        /// <param name="stuNum">对应人的stuNum</param>
        /// <returns>返回符合人的职务列表</returns>
        public List<DutyAct> GetMemberDuty(string stuNum)
        {
            List<DutyAct> list = null;
            /*这里Model存在问题，一时不知道怎么解决*/
            list = SQLHelper.ExcuteList<DutyAct>(@"select * from [LIMS].[dbo].[T_DutyAct] where DutyActor = @DutyActor"
                , new SqlParameter("@DutyActor", stuNum));
            return list;
        }
        #endregion
	}
}

