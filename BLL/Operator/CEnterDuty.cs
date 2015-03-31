using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operator
{
    public class CEnterDuty
    {
        #region 获取职务信息
        /// <summary>
        /// 获取职务信息
        /// </summary>
        /// <returns></returns>
        public List<DutyInformation> GetDutyInfor()
        {
            return new DAL.DutyInformationDAL().GetDutyInfor();
        }
        /*
         * 10001录入总裁
         * 10002录入财务总管
         * 10003录入学习顾问团团长
         * 10004录入学习顾问团团员
         * 10005录入学习顾问团团员
         * 10006录入活动策划组组长
         * 10007录入技术方向负责人
         */
        public List<CheckMemberInfor> GetSelectMember(string id)
        {
            switch (id)
            {
                case "10002":
                    return new DAL.SelectDuty().SelectPresident();
                case "10003":
                    return new DAL.SelectDuty().SelectFiannce();
                case "10004":
                    return new DAL.SelectDuty().SelectStduyLeader();
                case "10005":
                    return new DAL.SelectDuty().SelectStduy();
                case "10006":
                    return new DAL.SelectDuty().ActivityLeader();
                case "10007":
                    return new DAL.SelectDuty().TechnicalLeader();
                default:
                    return null;
            }
        } 
        #endregion

        #region 录入职务
        /// <summary>
        ///   录入职务
        /// </summary>
        /// <param name="id">职务名称</param>
        /// <param name="num">一系列学号</param>
        /// <returns>成功返回true</returns>
        public bool EnterDuty(string id, string num)
        {
            int DutyId = Convert.ToInt32(id);
            string[] StuNum = num.Split(',');
            List<DutyAct> listAct = new List<DutyAct>();
            for (int i = 0; i < StuNum.Length - 1; i++)
            {
                DutyAct dutyAct = new DutyAct();
                dutyAct.DutyId = DutyId;
                dutyAct.DutyActor= StuNum[i];
                listAct.Add(dutyAct);
            }
            return new DAL.DutyActDAL().EnterDuty(listAct, DutyId);
        } 
        #endregion

        #region 获取对应职务的人
        /// <summary>
        /// 获取对应职务的人
        /// </summary>
        /// <param name="id">对应职务的id</param>
        /// <returns>返回符合职位的成员列表</returns>
        public List<CheckMemberInfor> GetDutyMember(string id)
        {
            int dutyId = Convert.ToInt32(id);
            return new DAL.DutyActDAL().GetDutyMember(dutyId);
        } 
        #endregion

        #region 获取人对应的职务
        /// <summary>
        /// 获取人对应的职务
        /// </summary>
        /// <param name="stuNum">对应职务的stuNum</param>
        /// <returns>返回成员符合的职位的列表</returns>
        public List<DutyAct> GetMemberDuty(string stuNum)
        {
            return new DAL.DutyActDAL().GetMemberDuty(stuNum);
        }
        #endregion

    }
}
