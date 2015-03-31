using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BLL.Interface
{
    public interface IProjTask
    {
        /// <summary>
        /// 新建项目任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns>创建结果</returns>
        bool CreateProjTask(TaskInformation taskInfo,string[] taskParts);

        /// <summary>
        /// 修改项目任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns></returns>
        bool UpdateProjTask(TaskInformation taskInfo, string[] taskParts);

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <returns>修改成功与否</returns>
        bool DeleteProjTask(int taskId);
    }
}
