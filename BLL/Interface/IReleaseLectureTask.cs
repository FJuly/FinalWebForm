using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IReleaseLectureTask
    {
        /// <summary>
        /// 总裁发布讲座任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns>发布结果</returns>
        bool CreateLectureTask(TaskInformation taskInfo,string[] taskParts);

        /// <summary>
        /// 修改讲座任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns></returns>
        bool UpdateLectureTask(TaskInformation taskInfo, string[] taskParts);

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <returns>修改成功与否</returns>
        bool DeleteLectureTask(int taskId);
    }
}
