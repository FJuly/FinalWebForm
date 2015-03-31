using DBUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 录入人员所用，根据不同的条件得到不同的人员列表
    /// </summary>
    public class SelectDuty
    {
        #region 录入总裁 ，总裁必须为大二成员且必须是正式成员
        /// <summary>
        ///录入总裁 ，总裁必须为大二成员且必须是正式成员
        /// </summary>
        /// <param name="id">id为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> SelectPresident()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-2).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 选择财务主管，财务主管必须为正式成员
        /// <summary>
        /// 选择财务主管，财务主管必须为正式成员
        /// </summary>
        /// <param name="id">id为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> SelectFiannce()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-2).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region  选择学习顾问团团长，顾问团团长必须是大二成员
        /// <summary>
        ///   选择学习顾问团团长，顾问团团长必须是大二成员
        /// </summary>
        /// <param name="id">id为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> SelectStduyLeader()
        {

            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-2).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 选择学习顾问团成员，必须是大二成员
        /// <summary>
        /// 选择学习顾问团成员，必须是大二成员
        /// </summary>
        /// <param name="id">为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> SelectStduy()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-2).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 选择活动策划组成员，为大一成员
        /// <summary>
        /// 选择活动策划组成员，为大一成员
        /// </summary>
        /// <param name="id">为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> ActivityLeader()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-1).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 技术方向负责人录入，技术方向负责人为大三成员
        /// <summary>
        /// 技术方向负责人录入，技术方向负责人为大三成员
        /// </summary>
        /// <param name="id">为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> TechnicalLeader()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-3).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 项目主管录入，项目主管为大三成员
        /// <summary>
        /// 项目主管录入，项目主管为大三成员
        /// </summary>
        /// <param name="id">为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> ProjLeader()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-3).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 录入项目组成员，项目组成员为实验室正式成员
        /// <summary>
        /// 录入项目组成员，项目组成员为实验室正式成员
        /// </summary>                  
        /// <param name="id">为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> ProjMember()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-3).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 录入活动策划组成员，为大一成员
        /// <summary>
        /// 录入活动策划组成员，为大一成员
        /// </summary>
        /// <param name="id">为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> ActivityMember()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-1).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        #region 录入活动负责人，活动负责人为大一成员
        /// <summary>
        /// 录入活动负责人，活动负责人为大一成员
        /// </summary>
        /// <param name="id">为对应职务名称</param>
        /// <returns>返回符合条件的成员列表</returns>
        public List<CheckMemberInfor> ActivityManger()
        {
            try
            {
                //获取大二成员入学年份
                string year = DateTime.Now.AddYears(-1).Year.ToString();
                DataTable dt = SQLHelper.ExcuteDataTable(@"select StuNum,StuName,Major,TechDireName,TechLevelName,TelephoneNumber from V_MemberInformation where StuNum like '%" + year + "%'");
                List<CheckMemberInfor> list = GetMemberList(dt);
                list = GetDuty(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        #endregion

        /* 获取每个成员的职务*/
        public static List<CheckMemberInfor> GetDuty(List<CheckMemberInfor> list)
        {
            DataTable dt = null;
            string duty = "";
            foreach (CheckMemberInfor member in list)
            {
                dt = SQLHelper.ExcuteDataTable(@"select DutyName from T_DutyInformation where DutyId in(select DutyID from T_DutyAct where DutyActor=@StuNum)",
                new SqlParameter("@StuNum",member.StuNum));
                foreach (DataRow row in dt.Rows)
                {
                    duty += row["DutyName"].ToString() + "、";
                }
               member.Duty= duty.TrimEnd('、');
               duty = "";
            }
            return list;
                                
        }
        /*将成员转成list*/
        public static List<CheckMemberInfor> GetMemberList(DataTable table)
        {
            List<CheckMemberInfor> list = new List<CheckMemberInfor>(); ;
            foreach (DataRow row in table.Rows)
            {
                CheckMemberInfor member = new CheckMemberInfor();
                member.StuNum = row["StuNum"].ToString();
                member.StuName = row["StuName"].ToString();
                member.Major = row["Major"].ToString();
                member.TechDireName = row["TechDireName"].ToString();
                member.TechLevelName = row["TechLevelName"].ToString();
                member.TelephoneNumber = row["TelephoneNumber"].ToString();
                list.Add(member);
            }
            return list;
        }
 
    }
}
