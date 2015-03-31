/**  。
* TaskInformation.cs
*
* 功 能： N/A
* 类 名： TaskInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:05 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;
using System.Collections.Generic;
namespace DAL
{
	/// <summary>
	/// 任务信息数据访问类
	/// </summary>
	public  class TaskInformationDAL
    {
        #region 根据学号获取所有任务，返回VMemberTaskInfo数组
        /// <summary>
        /// 根据学号获取所有任务
        /// </summary>
        /// <param name="stuNum">成员学号</param>
        /// <returns>任务数组</returns>
        public VMemberTaskInfo[] GetAllTaskInfoByStuNum(string stuNum)
        {
            DataTable dataTable = SQLHelper.ExcuteDataTable(@"select * from V_MemberTaskInfo where TaskReceiver = @TaskReceiver", new SqlParameter("@TaskReceiver", stuNum));
            VMemberTaskInfo[] tasks = new VMemberTaskInfo[dataTable.Rows.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = ToVMemberTaskInfo(dataTable.Rows[i]);
            }
            return tasks;
        } 
        #endregion

        #region 根据学号获取指定类型的任务条数，返回int的任务条数
        /// <summary>
        ///  根据学号获取指定类型的任务条数
        /// </summary>
        /// <param name="stuNum">学号</param>
        /// <param name="taskTypeId">任务类型Id</param>
        /// <returns></returns>
        public int GetTaskCount(string stuNum, int taskTypeId)
        {
            int count = (int)SQLHelper.ExcuteScalar(@"select count(*) from V_MemberTaskInfo where TaskReceiver=@TaskReceiver and TaskTypeId=@TaskTypeId",
                new SqlParameter("@TaskReceiver", stuNum),
                new SqlParameter("@TaskTypeId", taskTypeId));
            return count;
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
            int count = 0;
            count = (int)SQLHelper.ExcuteScalar(@"select count(*) from T_TaskInformation where TaskSender = @TaskSender",
                new SqlParameter("@TaskSender", stuNum));
            return count;
        } 
        #endregion

        #region 根据学号分页查找指定类型的任务，返回VMemberTaskInfo数组
        /// <summary>
        /// 根据学号分页查找任务
        /// </summary>
        /// <param name="stuNum">学号</param>
        /// <param name="taskTypeId">任务类型</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="count">页大小</param>
        /// <param name="rowCount">记录条数（引用类型）</param>
        /// <returns>VMemberTaskInfo数组</returns>
        public VMemberTaskInfo[] GetAllTaskInfoByPageIndex(string stuNum, int taskTypeId, int pageIndex, int count, ref int rowCount)
        {
            rowCount = (int)SQLHelper.ExcuteScalar("select count(*) from V_MemberTaskInfo where TaskReceiver=@TaskReceiver", new SqlParameter("@TaskReceiver", stuNum));

            DataTable dataTable = SQLHelper.ExcuteDataTable(@"SELECT TOP " + count + @" * FROM V_MemberTaskInfo WHERE TaskId  NOT IN  (SELECT  TOP " + count * (pageIndex - 1) + @" +  TaskId  FROM V_MemberTaskInfo where TaskReceiver=@TaskReceiver and TaskTypeId=@TaskTypeId ORDER BY TaskId desc) and TaskReceiver=@TaskReceiver and TaskTypeId=@TaskTypeId  ORDER BY TaskId desc",
                new SqlParameter("@TaskReceiver", stuNum),
                new SqlParameter("@TaskTypeId", taskTypeId));

            VMemberTaskInfo[] tasks = new VMemberTaskInfo[dataTable.Rows.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = ToVMemberTaskInfo(dataTable.Rows[i]);
            }

            return tasks;
        }
        #endregion

        #region 根据学号分页查找发布过的任务，返回TaskInformation数组
        /// <summary>
        /// 根据学号分页查找发布过的任务，返回TaskInformation数组
        /// </summary>
        /// <param name="stuNum">学号</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="count">页大小</param>
        /// <returns></returns>
        public TaskInformation[] GetAllReleaseHistoryByPageIndex(string stuNum, int pageIndex, int count)
        {
            DataTable dataTable = SQLHelper.ExcuteDataTable(@"SELECT TOP " + count + " * FROM T_TaskInformation WHERE  TaskId  NOT IN  (SELECT  TOP " + count * (pageIndex - 1) + "  TaskId  FROM T_TaskInformation where TaskSender=@TaskSender ORDER BY TaskId desc) and TaskSender=@TaskSender ORDER BY TaskId desc",
                new SqlParameter("@TaskSender", stuNum));

            TaskInformation[] tasks = new TaskInformation[dataTable.Rows.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = ToTaskInformation(dataTable.Rows[i]);
            }

            return tasks;
        } 
        #endregion

        #region 根据学号和任务Id查找任务，返回VMemberTaskInfo
        /// <summary>
        /// 根据学号和任务Id查找任务
        /// </summary>
        /// <param name="stuNum">学号</param>
        /// <param name="taskId">任务Id</param>
        /// <returns>VMemberTaskInfo</returns>
        public VMemberTaskInfo GetTaskByStuNumAndTaskId(string stuNum, int taskId)
        {
            VMemberTaskInfo taskInfo = null;
            DataTable dataTable = SQLHelper.ExcuteDataTable(@"select * from V_MemberTaskInfo where TaskReceiver = @TaskReceiver and TaskId = @TaskId",
                new SqlParameter("@TaskReceiver", stuNum),
                new SqlParameter("@TaskId", taskId));
            try
            {
                taskInfo = ToVMemberTaskInfo(dataTable.Rows[0]);
            }
            catch {
                return null;
            }
            

            return taskInfo;
        }
        #endregion

        #region 确认任务已完成
        /// <summary>
        /// 确认任务已完成
        /// </summary>
        /// <param name="stuNum">成员学号</param>
        /// <param name="taskId">任务Id</param>
        /// <returns></returns>
        public bool ConfirmTaskCompleteById(string stuNum, int taskId)
        {

            if (SQLHelper.ExcuteNonQuery(@"UPDATE T_TaskParticipation SET  IsComplete = 1 WHERE TaskId = @TaskId and TaskReceiver = @TaskReceiver",
            new SqlParameter("@TaskId", taskId),
            new SqlParameter("@TaskReceiver", stuNum)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 新建任务并返回新建任务的Id
        /// <summary>
        /// 新建任务并返回新建的任务id
        /// </summary>
        /// <param name="taskInfo">任务model</param>
        /// <returns>新建的任务id</returns>
        public int CreatTask(TaskInformation taskInfo)
        {

            int taskId = (int)SQLHelper.ExcuteScalar(@"INSERT INTO T_TaskInformation (TaskSender,TaskName,TaskTypeId,TaskContent,
                TaskBegTime,TaskEndTime ,ProjId,ProjPhaseId,TaskAttachmentPath) VALUES
                (@TaskSender,@TaskName,@TaskTypeId,@TaskContent,
                @TaskBegTime,@TaskEndTime ,@ProjId,@ProjPhaseId,@TaskAttachmentPath) select top 1 TaskId from T_TaskInformation order by TaskId desc",
                                                                                new SqlParameter("@TaskSender", taskInfo.TaskSender),
                                                                                new SqlParameter("@TaskName", taskInfo.TaskName),
                                                                                new SqlParameter("@TaskTypeId", taskInfo.TaskTypeId),
                                                                                new SqlParameter("@TaskContent", taskInfo.TaskContent),
                                                                                new SqlParameter("@TaskBegTime", taskInfo.TaskBegTime),
                                                                                new SqlParameter("@TaskEndTime", taskInfo.TaskEndTime),
                                                                                new SqlParameter("@ProjId", taskInfo.ProjId),
                                                                                new SqlParameter("@ProjPhaseId", taskInfo.ProjPhaseId),
                                                                                new SqlParameter("@TaskAttachmentPath", taskInfo.TaskAttachmentPath));

            return taskId;
        } 
        #endregion

        #region 插入数据到任务参与表
        /// <summary>
        /// 插入数据到任务参与表
        /// </summary>
        /// <param name="taskParticipation">参与记录信息model</param>
        /// <returns>插入结果</returns>
        public bool CreatTaskParticipation(TaskParticipation taskParticipation)
        {

            SQLHelper.ExcuteNonQuery(@"INSERT INTO T_TaskParticipation (TaskId,TaskReceiver,TaskGrade,IsRead,IsComplete)
                VALUES(@TaskId,@TaskReceiver,@TaskGrade,@IsRead,@IsComplete)",
                                                             new SqlParameter("@TaskId", taskParticipation.TaskId),
                                                             new SqlParameter("@TaskReceiver", taskParticipation.TaskReceiverId),
                                                             new SqlParameter("@TaskGrade", taskParticipation.TaskGrade),
                                                             new SqlParameter("@IsRead", taskParticipation.IsRead),
                                                             new SqlParameter("@IsComplete", taskParticipation.IsComplete));

            return true;
        } 
        #endregion

        #region table转VMemberTaskInfo
        /// <summary>
        /// table转VMemberTaskInfo
        /// </summary>
        /// <param name="row">table行</param>
        /// <returns>VMemberTaskInfo</returns>
        private VMemberTaskInfo ToVMemberTaskInfo(DataRow row)
        {
            VMemberTaskInfo task = new VMemberTaskInfo();

            task.TaskId = (int)row["TaskId"];
            task.TaskSender = (string)row["TaskSender"];
            task.TaskName = (string)row["TaskName"];
            task.TaskTypeId = (int)row["TaskTypeId"];
            task.TaskContent = (string)row["TaskContent"];
            task.TaskBegTime = (DateTime)row["TaskBegTime"];
            task.TaskEndTime = (DateTime)row["TaskEndTime"];
            task.ProjId = (int)row["ProjId"];
            task.ProjName = (string)row["ProjName"];
            task.ProjPhaseId = (int)row["ProjPhaseId"];
            task.ProjPhase = (string)row["ProjPhase"];
            task.TaskAttachmentPath = (string)row["TaskAttachmentPath"];
            task.TaskReceiver = (string)row["TaskReceiver"];
            task.TaskGrade = (string)row["TaskGrade"];
            task.IsRead = (bool)row["IsRead"];
            task.IsComplete = (bool)row["IsComplete"];
            return task;
        }
        #endregion

        #region 根据任务Id删除任务（包括任务信息表和任务参与表中的所有记录）
        /// <summary>
        /// 根据任务Id删除任务
        /// </summary>
        /// <param name="taskId">任务Id</param>
        /// <returns>删除结果</returns>
        public bool DeleteTaskById(int taskId)
        {
            SQLHelper.ExcuteNonQuery(@"delete from T_TaskInformation where TaskId = @TaskId delete from T_TaskParticipation where TaskId = @TaskId", new SqlParameter("@TaskId", taskId));
            return true;
        }
        #endregion

        #region 根据Id获取任务信息
        /// <summary>
        /// 根据Id获取任务信息
        /// </summary>
        /// <param name="taskId">任务Id</param>
        /// <returns>任务信息</returns>
        public TaskInformation GetTaskInfoById(int taskId)
        {
            DataTable dataTable = SQLHelper.ExcuteDataTable(@"select * from T_TaskInformation where TaskId = @TaskId", new SqlParameter("@TaskId", taskId));

            TaskInformation taskInfo = ToTaskInformation(dataTable.Rows[0]);

            return taskInfo;
        } 
        #endregion

        #region table转TaskInformation
        /// <summary>
        /// table转TaskInformation
        /// </summary>
        /// <param name="row">table行</param>
        /// <returns>TaskInformation</returns>
        private TaskInformation ToTaskInformation(DataRow row)
        {
            TaskInformation task = new TaskInformation();

            task.TaskId = (int)row["TaskId"];
            task.TaskSender = (string)row["TaskSender"];
            task.TaskName = (string)row["TaskName"];
            task.TaskTypeId = (int)row["TaskTypeId"];
            task.TaskContent = (string)row["TaskContent"];
            task.TaskBegTime = (DateTime)row["TaskBegTime"];
            task.TaskEndTime = (DateTime)row["TaskEndTime"];
            task.ProjId = (int)row["ProjId"];
            task.ProjPhaseId = (int)row["ProjPhaseId"];
            task.TaskAttachmentPath = (string)row["TaskAttachmentPath"];
            return task;
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
            DataTable dataTable = SQLHelper.ExcuteDataTable(@"select TaskReceiver from T_TaskParticipation where TaskId = @TaskId", new SqlParameter("@TaskId", taskId));
            string[] members = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                members[i] = (string)dataTable.Rows[i]["TaskReceiver"];
            }
            return members;
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
            if (SQLHelper.ExcuteNonQuery(@"update T_TaskParticipation set TaskGrade = @TaskGrade where TaskId=@TaskId and TaskReceiver=@TaskReceiver"
                , new SqlParameter("@TaskGrade", taskGrade)
                , new SqlParameter("@TaskId", taskId)
                , new SqlParameter("@TaskReceiver", stuNum)) >0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            List<TaskParticipation> memberList = SQLHelper.ExcuteList<TaskParticipation>(@"select TaskReceiver as 'TaskReceiverId' 
                    ,TaskId,TaskGrade,IsRead,IsComplete,stuName as 'TaskReceiverName'
                    from T_TaskParticipation, T_MemberInformation 
                    where TaskId = @TaskId  and TaskReceiver = StuNum",
                                                                      new SqlParameter("@TaskId", taskId));
            return memberList;
        }
        #endregion

        #region 获取实习生学习任务条数
        /// <summary>
        /// 获取实习生学习任务条数
        /// </summary>
        /// <returns></returns>
        public int GetStuStudyTaskCount(string guideNumber)
        {
            return (int)SQLHelper.ExcuteScalar(@"select COUNT(*) from T_TaskInformation where TaskTypeId = 10001 and TaskId in(select TaskId from T_TaskParticipation where TaskReceiver in(select StuNum from T_MemberInformation where GuideNumber=@GuideNumber))",new SqlParameter("@GuideNumber",guideNumber));
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
            DataTable dataTable = SQLHelper.ExcuteDataTable(@"select  top " + count + " * from T_TaskInformation where TaskTypeId = 10001 and TaskId not in (select top " + (pageIndex - 1) * count + "  TaskId from T_TaskInformation where TaskTypeId = 10001 and TaskId in(select TaskId from T_TaskParticipation where  TaskReceiver in(select StuNum from T_MemberInformation where GuideNumber=@GuideNumber)) ORDER BY TaskId desc ) and TaskId in (select   TaskId from T_TaskInformation where TaskTypeId = 10001 and TaskId in(select TaskId from T_TaskParticipation where  TaskReceiver in(select StuNum from T_MemberInformation where GuideNumber=@GuideNumber))) ORDER BY TaskId desc",
                new SqlParameter("@GuideNumber", stuNum));

            TaskInformation[] tasks = new TaskInformation[dataTable.Rows.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = ToTaskInformation(dataTable.Rows[i]);
            }

            return tasks;
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

            List<TaskParticipation> memberList = SQLHelper.ExcuteList<TaskParticipation>(@"select TaskReceiver as 'TaskReceiverId' 
                    ,TaskId,TaskGrade,IsRead,IsComplete,stuName as 'TaskReceiverName'
                    from T_TaskParticipation, T_MemberInformation 
                    where TaskId = @TaskId and GuideNumber = @GuideNumber   and TaskReceiver = StuNum",
                                                                      new SqlParameter("@TaskId", taskId),
                                                                      new SqlParameter("@GuideNumber", guideNum));
            return memberList;
        } 
        #endregion
	}
}



