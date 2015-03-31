/**  。
* V_MemberInformation.cs
*
* 功 能： N/A
* 类 名： V_MemberInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:09 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;
using System.Collections.Generic;
using System.Configuration;
namespace DAL
{
	/// <summary>
	/// 数据访问类:V_MemberInformation
	/// </summary>
	public  class V_MemberInformationDAL
	{
        #region 获取个人信息
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="stuNum">获取成员的学号</param>
        /// <returns></returns>
        public V_MemberInformation GetPersonInfor(string stuNum, ref string duty)
        {
            try
            {
                /*获取除职务外的个人信息*/
                List<V_MemberInformation> listMember;
                listMember = SQLHelper.ExcuteList<V_MemberInformation>("select *from V_MemberInformation where StuNum=@StuNum", new SqlParameter("@StuNum", stuNum));
                /*获取职务信息*/
                DataTable dt = null;
                dt = SQLHelper.ExcuteDataTable(@"select DutyName from T_DutyInformation where DutyId in(select DutyID from T_DutyAct where DutyActor=@StuNum)",
              new SqlParameter("@StuNum", stuNum));
                foreach (DataRow row in dt.Rows)
                {
                    duty += row["DutyName"].ToString() + "、";
                }
                duty = duty.TrimEnd('、');
                if (listMember == null)
                    return null;
                else
                {
                    return listMember[0];
                }
            }
            catch (Exception)
            {
                return null;
            }

        } 
        #endregion

        #region 查看成员信息，返回所有成员列表
        /// <summary>
        /// 查看成员信息，返回所有成员列表
        /// </summary>
        /// <returns>返回所有成员的信息列表</returns>
        public List<Model.CheckMemberInfor> CheckMemberInfo(int rows, int page,ref int sum)
        {
             /*创建的分页存储过程（sum为查询出的记录总数）
            create procedure  checkmember
            @sum int output,
            @rowBottom int=0,
            @rowUp int=10
            as
            select @sum=COUNT(*) from V_MemberInformation
            select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from (select *,ROW_NUMBER()over(order by StuNum asc) as number from V_MemberInformation ) as tb1  
            where number>@rowBottom and number<=@rowUp
             */
            //这里可以使用存储过程,total没有选出来
            int rowBottom = rows * (page - 1);
            int rowUp = rows * page;
            sum = 0;
            try
            {    /*创建的存储过程名*/
                string strsql = "checkmember";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] paras = {
                                           new SqlParameter("@sum",sum),
                                           new SqlParameter("@rowBottom",rowBottom),
                                           new SqlParameter("@rowUp",rowUp),
                                       };
                    paras[0].Direction = ParameterDirection.Output;
                    da.SelectCommand.Parameters.AddRange(paras);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    sum = Convert.ToInt32(da.SelectCommand.Parameters[0].Value);
                    /*SelectDuty.GetMemberList将数据库里面的数据转换成list泛型,SelectDuty.GetDuty然后依次获取每个人的职务*/
                    return SelectDuty.GetDuty((SelectDuty.GetMemberList(dt)));
                }
            }
            catch (Exception ex)
            {
                return null;
            }                                

        } 
        #endregion

        #region 根据指定的条件查询成员信息
        /// <summary>
        /// 根据指定的条件查询成员信息
        /// </summary>
        /// <returns>返回所有成员的信息列表</returns>
        public List<Model.CheckMemberInfor> SelectMember(string checkName, string value)
        {
            DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where " + checkName + "=@value",
                new SqlParameter("@value", value)
                );
            /*SelectDuty.GetMemberList将数据库里面的数据转换成list泛型,SelectDuty.GetDuty然后依次获取每个人的职务*/
            return SelectDuty.GetDuty((SelectDuty.GetMemberList(dt)));
        } 
        #endregion


        //PS  2014.10.19
        #region 获取所有成员信息
        /// <summary>
        /// 获取所有成员信息
        /// </summary>
        /// <returns></returns>
        public List<V_MemberInformation> GetAll()
        {
            return SQLHelper.ExcuteList<V_MemberInformation>(@"select * from V_MemberInformation");
        } 
        #endregion

	} 
}

