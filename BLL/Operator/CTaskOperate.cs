using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL.Operator
{
    /// <summary>
    /// 任务操作类
    /// PS 2014.10.19
    /// </summary>
    public class CTaskOperate
    {
        #region 根据学号获取所有任务
        /// <summary>
        /// 根据学号获取所有任务
        /// </summary>
        /// <param name="stuNum">成员学号</param>
        /// <returns>任务数组</returns>
        public VMemberTaskInfo[] GetAllTaskInfoByStuNum(string stuNum)
        {
            return new TaskInformationDAL().GetAllTaskInfoByStuNum(stuNum);
        }
        #endregion

        #region 分页获取任务信息
        /// <summary>
        /// 分页获取任务信息
        /// </summary>
        /// <param name="stuNum">接收人学号</param>
        /// <param name="taskTypeId">任务类型</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="count">页大小</param>
        /// <param name="rowCount">记录条数</param>
        /// <returns></returns>
        public VMemberTaskInfo[] GetAllTaskInfoByPageIndex(string stuNum, int taskTypeId, int pageIndex, int count, ref int rowCount)
        {
            return new TaskInformationDAL().GetAllTaskInfoByPageIndex(stuNum, taskTypeId, pageIndex, count, ref rowCount);
        }
        #endregion

        #region 获取任务记录条数
        /// <summary>
        /// 获取任务记录条数
        /// </summary>
        /// <param name="stuNum">接收人学号</param>
        /// <param name="taskTypeId">任务类型</param>
        /// <returns></returns>
        public int GetTaskCount(string stuNum, int taskTypeId)
        {
            return new TaskInformationDAL().GetTaskCount(stuNum, taskTypeId);
        }
        #endregion

        #region 获取任务详情
        /// <summary>
        /// 获取任务详情
        /// </summary>
        /// <param name="stuNum">接收人学号</param>
        /// <param name="taskId">任务Id</param>
        /// <returns></returns>
        public VMemberTaskInfo GetTaskByStuNumAndTaskId(string stuNum, int taskId)
        {
            return new TaskInformationDAL().GetTaskByStuNumAndTaskId(stuNum, taskId);
        }
        #endregion

        #region 确认任务已完成
        /// <summary>
        /// 确认任务已完成
        /// </summary>
        /// <param name="stuNum">接收人学号</param>
        /// <param name="taskId">任务Id</param>
        /// <returns>修改成功返回TRUE</returns>
        public bool ConfirmTaskCompleteById(string stuNum, int taskId)
        {
            return new TaskInformationDAL().ConfirmTaskCompleteById(stuNum, taskId);
        }
        #endregion

        #region 创建任务
        /// <summary>
        /// 新建一个任务
        /// </summary>
        /// <param name="taskInfo">任务信息model</param>
        /// <param name="stuNums">参与人学号数组</param>
        /// <returns>创建结果</returns>
        public bool CreatTask(TaskInformation taskInfo, string[] stuNums)
        {

            int taskId = new TaskInformationDAL().CreatTask(taskInfo);

            for (int i = 0; i < stuNums.Length; i++)
            {
                TaskParticipation taskParticipation = new TaskParticipation();
                taskParticipation.TaskId = taskId;
                taskParticipation.TaskReceiverId = stuNums[i].Trim();
                taskParticipation.TaskGrade = "";
                taskParticipation.IsComplete = false;
                taskParticipation.IsRead = false;

                new TaskInformationDAL().CreatTaskParticipation(taskParticipation);
            }

            return true;
        }
        #endregion

        #region 根据学号查找此人发布过的所有任务记录条数
        /// <summary>
        /// 根据学号查找此人发布过的所有任务记录条数
        /// </summary>
        /// <param name="stuNum">学号</param>
        /// <returns>记录条数</returns>
        public int GetReleaseTaskCount(string stuNum)
        {
            return new TaskInformationDAL().GetReleaseTaskCount(stuNum);
        }
        #endregion

        #region 根据任务Id删除任务（包括任务信息表和任务参与表中的所有记录）
        /// <summary>
        /// 根据任务Id删除任务（包括任务信息表和任务参与表中的所有记录）
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public bool DeleteTaskById(int taskId)
        {
            return new TaskInformationDAL().DeleteTaskById(taskId);
        }
        #endregion

        #region 根据Id获取任务信息
        /// <summary>
        /// 根据Id获取任务信息
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public TaskInformation GetTaskInfoById(int taskId)
        {
            return new TaskInformationDAL().GetTaskInfoById(taskId);
        }
        #endregion

        #region 通过任务Id获取任务参与者学号数组
        /// <summary>
        /// 通过任务Id获取任务参与者学号数组
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public string[] GetMemberListByTaskId(int taskId)
        {
            return new TaskInformationDAL().GetMemberListByTaskId(taskId);
        }
        #endregion

        #region 分页获取任务发布记录
        /// <summary>
        /// 分页获取任务发布记录
        /// </summary>
        /// <param name="stuNum">发布人学号</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="count">页大小</param>
        /// <returns></returns>
        public TaskInformation[] GetAllReleaseHistoryByPageIndex(string stuNum, int pageIndex, int count)
        {
            return new TaskInformationDAL().GetAllReleaseHistoryByPageIndex(stuNum, pageIndex, count);
        }
        #endregion

        #region 通过任务Id获取参与人信息
        /// <summary>
        /// 通过任务Id获取参与人信息
        /// </summary>
        /// <param name="taskId">任务Id</param>
        /// <returns></returns>
        public List<TaskParticipation> GetMembersByTaskId(int taskId)
        {
            return new TaskInformationDAL().GetMembersByTaskId(taskId);
        }
        #endregion

        #region 保存任务评价
        /// <summary>
        ///  保存任务评价
        /// </summary>
        /// <param name="stuNum">接收人学号</param>
        /// <param name="taskId">任务Id</param>
        /// <param name="taskGrade">任务评价</param>
        /// <returns></returns>
        public Boolean SaveTaskGrade(string stuNum, int taskId, string taskGrade)
        {
            return new TaskInformationDAL().SaveTaskGrade(stuNum, taskId, taskGrade);
        }
        #endregion

        #region 获取所有的任务类型GetAllTaskType()
        /// <summary>
        /// 获取所有的任务类型
        /// </summary>
        /// <returns></returns>
        public TaskType[] GetAllTaskType()
        {
            return new TaskTypeDAL().GetAllTaskType();
        } 
        #endregion

        #region 通过任务类型Id获取任务类型名称GetTypeNameByTypeId(int typeId)
        /// <summary>
        /// 通过任务类型Id获取任务类型名称
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public string GetTypeNameByTypeId(int typeId)
        {
            return new TaskTypeDAL().GetTypeNameByTypeId(typeId);
        } 
        #endregion


        #region 获取实习生学习任务条数
        /// <summary>
        /// 获取实习生学习任务条数
        /// </summary>
        /// <param name="guideNumber"></param>
        /// <returns></returns>
        public int GetStuStudyTaskCount(string guideNumber)
        {
            return new TaskInformationDAL().GetStuStudyTaskCount(guideNumber);
        } 
        #endregion

        #region 根据学号分页查找管理的实习生的任务，返回TaskInformation数组
		/// <summary>
        /// 根据学号分页查找管理的实习生的任务，返回TaskInformation数组
        /// </summary>
        /// <param name="stuNum">学号</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="count">页大小</param>
        /// <returns></returns>
        public TaskInformation[] GetStuStudyTaskByPageIndex(string stuNum, int pageIndex, int count)
        {
            return new TaskInformationDAL().GetStuStudyTaskByPageIndex(stuNum, pageIndex, count);
        } 
	#endregion


        #region 根据任务Id和顾问团成员学号获取参与人列表
        /// <summary>
        /// 根据任务Id和顾问团成员学号获取参与人列表
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="guideNum"></param>
        /// <returns></returns>
        public List<TaskParticipation> GetMembersByTaskIdAndGuide(int taskId, string guideNum)
        {
            return new TaskInformationDAL().GetMembersByTaskIdAndGuide(taskId, guideNum);
        } 
        #endregion

    }
}
