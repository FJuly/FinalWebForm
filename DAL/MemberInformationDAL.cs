/**  。
* MemberInformation.cs
*
* 功 能： N/A
* 类 名： MemberInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 20:59:58 
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
	/// 数据访问类:
	/// </summary>MemberInformation
	public  class MemberInformationDAL
	{
        #region 修改个人信息
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool PersonInforChange(MemberInformation member)
        {
            string sql =
                "UPDATE T_MemberInformation " +
                "SET "
                + "Gender = @Gender"
                + ", QQNum = @QQNum"
                + ", Email = @Email"
                + ", LoginPwd = @LoginPwd"
                + ", Birthday = @Birthday"
                //+ ", PhotoPath = @PhotoPath"
                + ", Class = @Class"
                + ", Major = @Major"
                + ", Counselor = @Counselor"
                + ", HeadTeacher = @HeadTeacher"
                + ", UndergraduateTutor = @UndergraduateTutor"
                + ", TelephoneNumber = @TelephoneNumber"
                + ", HomPhoneNumber = @HomPhoneNumber"
                + ", FamilyAddress = @FamilyAddress"
                //+ ", TechnicalDirection = @TechnicalDirection"
                //+ ", TechnicalLevel = @TechnicalLevel"
                //+ ", GuideNumber = @GuideNumber"
                + ", IsDelete = @IsDelete"
                + ", StandbyA = @StandbyA"
                + ", StandbyB = @StandbyB"

            + " WHERE StuNum = @StuNum";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@StuNum", member.StuNum)
					,new SqlParameter("@StuName", ToDBValue(member.StuName))
					,new SqlParameter("@Gender", ToDBValue(member.Gender))
					,new SqlParameter("@QQNum", ToDBValue(member.QQNum))
					,new SqlParameter("@Email", ToDBValue(member.Email))
					,new SqlParameter("@LoginPwd", ToDBValue(member.LoginPwd))
					,new SqlParameter("@Birthday", ToDBValue(member.Birthday.ToString()))
                    //,new SqlParameter("@PhotoPath", ToDBValue(member.PhotoPath))
					,new SqlParameter("@Class", ToDBValue(member.Class))
					,new SqlParameter("@Major", ToDBValue(member.Major))
					,new SqlParameter("@Counselor", ToDBValue(member.Counselor))
					,new SqlParameter("@HeadTeacher", ToDBValue(member.HeadTeacher))
					,new SqlParameter("@UndergraduateTutor", ToDBValue(member.UndergraduateTutor))
					,new SqlParameter("@TelephoneNumber", ToDBValue(member.TelephoneNumber))
					,new SqlParameter("@HomPhoneNumber", ToDBValue(member.HomPhoneNumber))
					,new SqlParameter("@FamilyAddress", ToDBValue(member.FamilyAddress))
					,new SqlParameter("@TechDireId", ToDBValue(member.TechDireId))
					,new SqlParameter("@TechLevelId", ToDBValue(member.TechLevelId))
					,new SqlParameter("@GuideNumber", ToDBValue(member.GuideNumber))
					,new SqlParameter("@IsDelete", ToDBValue(member.IsDelete))
			};
            try
            {
                SQLHelper.ExcuteNonQuery(sql, para);
                return true;
            }
            catch
            {
                return false;
            }
        } 
        #endregion

        #region 更新个人照片路径
        /// <summary>
        /// 更新个人照片路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool UpdatePhoto(string path, string stuNum)
        {

            int isSuccess = SQLHelper.ExcuteNonQuery("update T_MemberInformation set PhotoPath = @path where StuNum = @stuNum",
                new SqlParameter("@path", path), new SqlParameter("@stuNum", stuNum));
            if (isSuccess > 0)
                return true;
            else
                return false;
        } 
        #endregion

        #region 删除成员
        /// <summary>
        ///删除成员
        /// </summary>
        /// <param name="Id">删除成员的Id</param>
        /// <returns></returns>
        public bool DeleteMember(int Id)
        {
            return true;
        } 
        #endregion

        #region 获取成员信息
        /// <summary>
        /// 获取成员信息
        /// </summary>
        /// <param name="stuNum">学号</param>
        /// <returns>该成员实体，若不存在，返回null</returns>
        public MemberInformation GetMemberInformation(string stuNum)
        {
            string sql = "select * from T_MemberInformation where StuNum = @StuNum";
            List<MemberInformation> list = new List<MemberInformation>();
            list =  SQLHelper.ExcuteList<MemberInformation>(sql, new SqlParameter("@StuNum", stuNum));
            if (list == null)
            {
                return null;
            }
            else if (list.Count > 1)
            {
                throw new Exception("严重错误! T_MemberInformation表中发现主键有重复项");
            }
            else if (list.Count < 1)
            {
                return null;
            }
            else
            {
               return list[0];
            }                

        } 
        #endregion

        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }


        public List<MemberInformation> GetAll()
        {
            return SQLHelper.ExcuteList<MemberInformation>(@"select * from T_MemberInformation");
        }

        public List<MemberInformation> GetByTechLevelId(int techLevelId)
        {
            return SQLHelper.ExcuteList<MemberInformation>(@"select * from T_MemberInformation where TechLevelId =@TechLevelId", new SqlParameter("@TechLevelId", techLevelId));
        }

        public List<MemberInformation> GetRegularMember()
        {
            return SQLHelper.ExcuteList<MemberInformation>(@"select * from T_MemberInformation where TechLevelId = 10002 or TechLevelId = 10003 or TechLevelId = 10004");
        }


        public List<MemberInformation> GetByTechDireId(int techDireId)
        {
            return SQLHelper.ExcuteList<MemberInformation>(@"select * from T_MemberInformation where TechDireId =@TechDireId", new SqlParameter("@TechDireId", techDireId));
        }

        /*----------------------王顺代码2014-10-18----------------------*/
        //ws  2014.10.24
        #region 查找项目主管候选人
        /// <summary>
        /// 查找项目主管候选人
        /// </summary>
        /// <returns>候选人列表</returns>
        public List<Model.MemberInformation> GetProjLeader()
        {
            string strSql = "select *from T_MemberInformation where TechLevelId > 10002";
            return SQLHelper.ExcuteList<Model.MemberInformation>(strSql);
        } 
        #endregion

        //ws  2014.10.24
        #region 获取所有项目成员
        /// <summary>
        /// 获取所有项目成员
        /// </summary>
        /// <returns>所有成员列表</returns>
        public List<Model.MemberInformation> GetAllMemberList()
        {
            string strSql = "select *from T_MemberInformation";
            return SQLHelper.ExcuteList<Model.MemberInformation>(strSql);
        } 
        #endregion
	}
}

