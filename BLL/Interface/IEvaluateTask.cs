using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Interface
{
    public interface IEvaluateTask
    {
        /// <summary>
        /// 任务评价
        /// </summary>
        /// <param name="stuNum"></param>
        /// <param name="taskId"></param>
        /// <param name="taskGrade"></param>
        /// <returns></returns>
        bool EvaluateTask(string stuNum, int taskId, string taskGrade);
    }
}
