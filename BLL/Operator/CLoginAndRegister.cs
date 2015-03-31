using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operator
{
    public class CLoginAndRegister
    {
        /// <summary>
        /// 生成邀请码
        /// </summary>
        /// <param name="count">生成邀请码数量</param>
        /// <param name="length">邀请码长度</param>
        /// <returns></returns>
        public bool CreateInviteCode(int count,int length)
        {
            string strInviteCode;
            for (int i = 0; i < count; i++)
            {
               strInviteCode = CreateSecurityCode(length);
               new DAL.InviteCodeDAL().AddInviteCode(strInviteCode);
            }
            
            return true;
        }

        /// <summary>
        /// 验证码生成
        /// </summary>
        /// <param name="length">生成验证码的长度</param>
        /// <returns>生成的验证码</returns>
        public String CreateSecurityCode(int length)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            string strCode = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sbCode = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sbCode.Append(strCode[random.Next(strCode.Length)]);
            }
            return sbCode.ToString();
        }

        /// <summary>
        /// 成员注册
        /// </summary>
        /// <param name="stu">成员信息表</param>
        /// <returns>注册结果</returns>
        public bool Register(MemberInformation memberInfo)
        {

            return true;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="stuNum">登陆学号</param>
        /// <returns>登陆人信息，若查不到返回null</returns>
        public MemberInformation Login(string stuNum)
        {
            return new DAL.MemberInformationDAL().GetMemberInformation(stuNum);
        }

    }
}
