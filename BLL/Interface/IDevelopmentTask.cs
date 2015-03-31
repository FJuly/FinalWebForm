using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BLL.Interface
{
    public interface IDevelopmentTask
    {
        /// <summary>
        /// 创建开发任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns>创建结果</returns>
        bool CreateDevelopmentTask(TaskInformation taskInfo,string[] taskParts);

        /// <summary>
        /// 删除开发任务
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <returns>删除结果</returns>
        bool DeleteDevelopmentTask(int taskId);

        /// <summary>
        /// 修改开发任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns>修改结果</returns>
        bool UpdateDevelopmentTask(TaskInformation taskInfo, string[] taskParts);
    }
}
