using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operator
{
    public class CPromote
    {
        /// <summary>
        /// 技术层次晋升申请
        /// </summary>
        /// <param name="stuNum">申请人学号</param>
        /// <returns></returns>
        public bool PromoteApply(string stuNum)
        {
            return true;
        }

        /// <summary>
        /// 申请审核操作
        /// </summary>
        /// <param name="result">审核结果，true表示同意，false表示不同意</param>
        /// <param name="stuNum">申请人学号</param>
        /// <param name="noticeId">通知Id</param>
        /// <returns></returns>
        public bool CheckApply(bool result, string stuNum, int noticeId)
        {
            return true;
        }
    }
}
