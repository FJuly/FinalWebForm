/**  。
* TaskInformation.cs
*
* 功 能： N/A
* 类 名： TaskInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:34 
*/
using System;
namespace Model
{
	/// <summary>
	/// TaskInformation:实体类
	/// </summary>
	
	public partial class TaskInformation
	{
		public TaskInformation()
		{}
		#region Model
		private int _taskid;
		private string _tasksender;
		private string _taskname;
		private int _tasktypeid;
		private string _taskcontent;
		private DateTime _taskbegtime;
		private DateTime _taskendtime;
		private int _projid;
		private int _projphaseid;
		private string _taskattachmentpath;
		/// <summary>
		/// 
		/// </summary>
		public int TaskId
		{
			set{ _taskid=value;}
			get{return _taskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskSender
		{
			set{ _tasksender=value;}
			get{return _tasksender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskName
		{
			set{ _taskname=value;}
			get{return _taskname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TaskTypeId
		{
			set{ _tasktypeid=value;}
			get{return _tasktypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskContent
		{
			set{ _taskcontent=value;}
			get{return _taskcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TaskBegTime
		{
			set{ _taskbegtime=value;}
			get{return _taskbegtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TaskEndTime
		{
			set{ _taskendtime=value;}
			get{return _taskendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProjId
		{
			set{ _projid=value;}
			get{return _projid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProjPhaseId
		{
			set{ _projphaseid=value;}
			get{return _projphaseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskAttachmentPath
		{
			set{ _taskattachmentpath=value;}
			get{return _taskattachmentpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		#endregion Model

	}
}

