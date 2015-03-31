using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Role
{
    class CStudyMember :  INotice,IEvaluateTask
    {
        /// <summary>
        /// 新建通知
        /// </summary>
        /// <param name="notice">通知信息</param>
        /// <param name="receiver">通知接受</param>
        /// <returns>新建通知结果</returns>
        public bool CreateNotice(Model.Notice notice, Model.ReceiveNotice[] receiver)
        {
            throw new NotImplementedException();
        }


        //PS 更改于2014.10.19
        #region 评价任务
        /// <summary>
        /// 评价任务
        /// </summary>
        /// <param name="stuNum"></param>
        /// <param name="taskId"></param>
        /// <param name="taskGrade"></param>
        /// <returns></returns>
        public bool EvaluateTask(string stuNum, int taskId, string taskGrade)
        {
            return new Operator.CTaskOperate().SaveTaskGrade(stuNum, taskId, taskGrade);
        } 
        #endregion
    }
}
