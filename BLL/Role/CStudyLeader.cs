using BLL.Interface;
using BLL.Operator;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Role
{
    /// <summary>
    /// 学习顾问团团长
    /// </summary>
    public class CStudyLeader : INotice,IStudyTask
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

        //PS更改于2014年9年29日
        #region 创建学习任务CreateStudyTask(Model.TaskInformation studyTask, string[] studyTaskParts)
        /// <summary>
        /// 创建学习任务
        /// </summary>
        /// <param name="studyTask">学习任务Model</param>
        /// <param name="studyTaskParts">活动参与Model</param>
        /// <returns>创建成功过返回true，删除失败返回false</returns>
        public bool CreateStudyTask(Model.TaskInformation studyTask, string[] studyTaskParts)
        {
            if (new CTaskOperate().CreatTask(studyTask, studyTaskParts))
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
        #region 修改学习任务学习任务
        /// <summary>
        /// 修改学习任务学习任务
        /// </summary>
        /// <param name="studyTask">学习任务Model</param>
        /// <param name="studyTaskPar">活动参与Model</param>
        /// <returns>修改成功返回true，删除失败返回false</returns>
        public bool UpdateStudyTask(TaskInformation studyTask, string[] studyTaskParts)
        {
            if (CreateStudyTask(studyTask, studyTaskParts))
            {
                if (DeleteStudyTask(studyTask.TaskId))
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

        //PS更改于2014年9年29日
        #region 删除学习任务
        /// <summary>
        ///删除学习任务
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>删除成功返回true，返回失败返回false</returns>
        public bool DeleteStudyTask(int Id)
        {
            if (new CTaskOperate().DeleteTaskById(Id))
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
