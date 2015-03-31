using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    interface IMemberInformation
    {
        /// <summary>
        /// 修改成员信息SSS
        /// </summary>
        /// <param name="member">被修改成员信息Model</param>
        /// <returns>修改成功返回true，失败返回false</returns>
        bool UpdateMemberInfor(MemberInformation member);


        /// <summary>
        ///删除成员
        /// </summary>
        /// <param name="Id">删除成员的Id</param>
        /// <returns></returns>
        bool DeleteMember(int Id);

    }
}
