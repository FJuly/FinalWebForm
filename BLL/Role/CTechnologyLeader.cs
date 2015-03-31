using BLL.Interface;
using BLL.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Role
{
    public class CTechnologyLeader : IWorkProj, IDevelopmentTask, INotice
    {
        /// <summary>
        /// 新建作品项目
        /// </summary>
        /// <param name="projInfo">项目信息</param>
        /// <param name="projPart">项目参与表</param>
        /// <returns>创建结果</returns>
        public bool CreateProj(Model.ProjectInformation projInfo, Model.ProjectParticipation[] projParts)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除作品项目
        /// </summary>
        /// <param name="projId">项目Id</param>
        /// <returns>删除结果</returns>
        public bool DeleteProj(int projId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="projInfo">项目信息</param>
        /// <param name="projPart">项目参与表</param>
        /// <returns>更新结果</returns>
        public bool UpdateProj(Model.ProjectInformation projInfo, Model.ProjectParticipation[] projParts)
        {
            throw new NotImplementedException();
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

        //PS更改于2014年9年29日
        #region 创建开发任务
        /// <summary>
        /// 创建开发任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns>创建结果</returns>
        public bool CreateDevelopmentTask(Model.TaskInformation taskInfo, string[] taskParts)
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
        #endregion

        //PS更改于2014年9年29日
        #region 删除开发任务
        /// <summary>
        /// 删除开发任务
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <returns>删除结果</returns>
        public bool DeleteDevelopmentTask(int taskId)
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
        #endregion

        //PS更改于2014年9年29日
        #region 修改开发任务
        /// <summary>
        /// 修改开发任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <param name="taskParts">任务参与</param>
        /// <returns>修改结果</returns>
        public bool UpdateDevelopmentTask(Model.TaskInformation taskInfo, string[] taskParts)
        {
            if (new CTaskOperate().CreatTask(taskInfo, taskParts))
            {
                if (new CTaskOperate().DeleteTaskById(taskInfo.TaskId))
                {
                    return true;
                }
            }
            return false;
        } 
        #endregion
    }
}
