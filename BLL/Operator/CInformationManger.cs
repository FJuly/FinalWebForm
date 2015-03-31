using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operator
{
    public class CInformationManger
    {
        /// <summary>
        /// 更新个人照片路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool UpdatePhoto(string path,string stuNum)
        {
            return new DAL.MemberInformationDAL().UpdatePhoto(path,stuNum);
        }
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="stuNum">获取成员的学号</param>
        /// <returns></returns>
        public V_MemberInformation GetPersonInfor(string stuNum,ref string duty)//这是新增加的方法，2014-8-18 by方刚
        {
            return new DAL.V_MemberInformationDAL().GetPersonInfor(stuNum,ref duty);
        }
        /// <summary>
        /// 个人信息修改
        /// </summary>
        /// <param name="member">修改后成员信息Model</param>
        /// <returns>修改成功返回true，修改失败返回false</returns>
        public bool PersonInforChange(MemberInformation member)
        {
            return new DAL.MemberInformationDAL().PersonInforChange(member);
        }


        /// <summary>
        /// 查看成员信息，返回所有成员列表
        /// </summary>
        /// <returns>返回所有成员的信息列表</returns>
        public List<Model.CheckMemberInfor> CheckMemberInfo(int rows,int page,ref int sum)
        {
            return new DAL.V_MemberInformationDAL().CheckMemberInfo(rows,page,ref sum); ;
        }

        /// <summary>
        /// 根据指定的条件查询成员信息
        /// </summary>
        /// <returns>返回所有符合成员的信息列表</returns>
        public List<Model.CheckMemberInfor> SelectMember(string checkName,string value)
        {
            return new DAL.V_MemberInformationDAL().SelectMember(checkName, value); ;
        }

        /// <summary>
        /// 修改成员信息
        /// </summary>
        /// <param name="member">被修改成员信息Model</param>
        /// <returns>修改成功返回true，失败返回false</returns>
        public bool UpdateMemberInfor(MemberInformation member)
        {
            return true;
        }


        /// <summary>
        ///删除成员
        /// </summary>
        /// <param name="Id">删除成员的Id</param>
        /// <returns></returns>
        public bool DeleteMember(int Id)
        {
            return new MemberInformationDAL().DeleteMember(Id);
        }

        /*-------------王顺的代码2014-10-18--------------------*/

        DAL.MemberInformationDAL dal = new DAL.MemberInformationDAL();

        //ws  2014.10.24
        #region 查找项目主管候选人
        /// <summary>
        /// 查找项目主管候选人
        /// </summary>
        /// <returns>候选人列表</returns>
        public List<Model.MemberInformation> GetProjLeader()
        {
            return dal.GetProjLeader();
        } 
        #endregion

        //ws  2014.10.24
        #region 获取所有成员
        /// <summary>
        /// 获取所有成员
        /// </summary>                  
        /// <returns></returns>
        public List<Model.MemberInformation> GetAllMemberList()
        {
            return dal.GetAllMemberList();
        } 
        #endregion


        /*---------------------PS 2014-10-19-----------------*/
        // 2014.10.1  PS
        #region 获取所有实验室成员信息
        /// <summary>
        /// 获取所有实验室成员信息
        /// </summary>
        /// <returns></returns>
        public List<MemberInformation> GetAll()
        {
            return new MemberInformationDAL().GetAll();
        } 
        #endregion

        //2014.10.1 PS
        #region 根据技术层次Id获取成员信息
        /// <summary>
        /// 根据技术层次Id获取成员信息
        /// </summary>
        /// <param name="techLevelId"></param>
        /// <returns></returns>
        public List<MemberInformation> GetByTechLevelId(int techLevelId)
        {
            return new MemberInformationDAL().GetByTechLevelId(techLevelId);
        } 
        #endregion

        //2014.10.1 PS
        #region 获取正式成员信息
        /// <summary>
        /// 获取正式成员信息
        /// </summary>
        /// <returns></returns>
        public List<MemberInformation> GetRegularMember()
        {
            return new MemberInformationDAL().GetRegularMember();
        } 
        #endregion

        //2014.10.1 PS
        #region 根据技术方向Id或去成员信息
        /// <summary>
        ///根据技术方向Id或去成员信息
        /// </summary>
        /// <param name="techDireId"></param>
        /// <returns></returns>
        public List<MemberInformation> GetByTechDireId(int techDireId)
        {
            return new MemberInformationDAL().GetByTechDireId(techDireId);
        } 
        #endregion

    }
}
