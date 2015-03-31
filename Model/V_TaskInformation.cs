/**  。
* V_TaskInformation.cs
*
* 功 能： N/A
* 类 名： V_TaskInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:40 
*/
using System;
namespace Model
{
	/// <summary>
	/// V_TaskInformation:实体类
	/// </summary>
	
	public partial class V_TaskInformation
	{
		public V_TaskInformation()
		{}
		#region Model
		private int _taskid;
		private string _tasksender;
		private string _taskname;
		private string _tasktype;
		private string _taskcontent;
		private DateTime _taskbegtime;
		private DateTime _taskendtime;
		private int _projid;
		private string _projphase;
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
		public string TaskType
		{
			set{ _tasktype=value;}
			get{return _tasktype;}
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
		public string ProjPhase
		{
			set{ _projphase=value;}
			get{return _projphase;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskAttachmentPath
		{
			set{ _taskattachmentpath=value;}
			get{return _taskattachmentpath;}
		}
		#endregion Model

	}
}

