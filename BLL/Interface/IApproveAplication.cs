using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    interface IApproveAplication
    {
        /// <summary>
        /// 申请审批，要进行比对，防止伪冒，在方法里面需要给申请人发通知
        /// </summary>
        /// <param name="NoticeId">通知Id</param>
        /// <param name="PublisherId">发布人Id</param>
        void IApproAplication(int NoticeId,int PublisherId);
    }
}
