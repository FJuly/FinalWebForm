using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Operator;

namespace BLL.Role
{
    /// <summary>
    /// 总裁
    /// </summary>
    class CCEO : IPersonalProj, IEnterOtherDuty, IReleaseLectureTask, INotice
    {

        public bool CreateProj(Model.ProjectInformation projInfo, Model.ProjectParticipation[] projParts)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProj(int projId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProj(Model.ProjectInformation projInfo, Model.ProjectParticipation[] projParts)
        {
            throw new NotImplementedException();
        }

        public bool EnterDuty(Model.DutyAct dutyAct)
        {
            throw new NotImplementedException();
        }


        public bool CreateNotice(Model.Notice notice, Model.ReceiveNotice[] receiver)
        {
            throw new NotImplementedException();
        }

        //PS 2014.10.19
        #region 发布讲座任务
        /// <summary>
        /// 发布讲座任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="taskParts"></param>
        /// <returns></returns>
        public bool CreateLectureTask(Model.TaskInformation taskInfo, string[] taskParts)
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

        //PS 2014.10.19
        #region 修改任务
        /// <summary>
        /// 修改任务
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="taskParts"></param>
        /// <returns></returns>
        public bool UpdateLectureTask(Model.TaskInformation taskInfo, string[] taskParts)
        {
            if (CreateLectureTask(taskInfo, taskParts))
            {
                if (DeleteLectureTask(taskInfo.TaskId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        } 
        #endregion

        //PS 2014.10.19
        #region 删除任务
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public bool DeleteLectureTask(int taskId)
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
    }
}
