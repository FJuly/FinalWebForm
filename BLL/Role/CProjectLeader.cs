using BLL.Interface;
using BLL.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Role
{
    public class CProjectLeader : IProjTask,INotice
    {
        /// <summary>
        /// 新建项目任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns>创建结果</returns>
        public bool CreateProjTask(Model.TaskInformation taskInfo, string[] taskParts)
        {
            if (new CTaskOperate().CreatTask(taskInfo, taskParts))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改项目任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns></returns>
        public bool UpdateProjTask(Model.TaskInformation taskInfo, string[] taskParts)
        {
            if (CreateProjTask(taskInfo, taskParts))
            {
                if (DeleteProjTask(taskInfo.TaskId))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <returns>修改成功与否</returns>
        public bool DeleteProjTask(int taskId)
        {
            if (new CTaskOperate().DeleteTaskById(taskId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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
    }
}
