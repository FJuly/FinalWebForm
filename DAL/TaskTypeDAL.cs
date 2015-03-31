/**  。
* TaskType.cs
*
* 功 能： N/A
* 类 名： TaskType
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-27 21:00:06 
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;
namespace DAL
{
	/// <summary>
	/// 数据访问类:TaskType
	/// </summary>
	public  class TaskTypeDAL
	{
        public TaskType[] GetAllTaskType()
        {
            DataTable dataTable = SQLHelper.ExcuteDataTable("select * from T_TaskType");
            TaskType[] taskTypes = new TaskType[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                taskTypes[i] = ToTaskType(dataTable.Rows[i]);
            }

            return taskTypes;
        }

        public string GetTypeNameByTypeId(int typeId)
        {
            return (string)SQLHelper.ExcuteScalar(@"select TaskTypeName from T_TaskType where TaskTypeId = @TaskTypeId",
                new SqlParameter("@TaskTypeId", typeId));
        }

        private TaskType ToTaskType(DataRow row)
        {
            TaskType taskType = new TaskType();

            taskType.TaskTypeId = (int)row["TaskTypeId"];
            taskType.TaskTypeName = (string)row["TaskTypeName"];

            return taskType;
        }
	}
}

