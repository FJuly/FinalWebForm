using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    /// <summary>
    /// 录入总裁、副总裁操作接口
    /// </summary>
    interface IEnterCEO
    {
        /// <summary>
        /// 录入总裁、副总裁
        /// </summary>
        /// <param name="dutyId">职位Id</param>
        /// <param name="stuNum">学号</param>
        void EnterDuty(int dutyId, string[] stuNum);
    }
}
