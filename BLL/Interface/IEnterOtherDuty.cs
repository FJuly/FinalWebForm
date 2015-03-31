using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    interface IEnterOtherDuty
    {
        /// <summary>
        ///录入其他职务，录入之前要将先前所有拥有该职务的成员的职务删除，然后再插入
        /// </summary>
        /// <param name="dutyAct">职务担任Model</param>
        /// <returns>录入成功返回true，失败返回false</returns>
        bool EnterDuty(DutyAct dutyAct);
    }
}
