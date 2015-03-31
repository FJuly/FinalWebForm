using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    interface INotice
    {
        /// <summary>
        /// 新建通知
        /// </summary>
        /// <param name="notice">通知信息</param>
        /// <param name="receiver">通知接受</param>
        /// <returns>新建通知结果</returns>
        bool CreateNotice(Model.Notice notice,Model.ReceiveNotice[] receiver);
    }
}
