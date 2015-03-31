/**  。
* TaskParticipation.cs
*
* 功 能： N/A
* 类 名： TaskParticipation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:35 
*/
using System;
namespace Model
{
	/// <summary>
	/// TaskParticipation:实体类
	/// </summary>
	
	public partial class TaskParticipation
	{
		public TaskParticipation()
		{}
		#region Model
		private int _taskid;
		private string _taskreceiverid;
        private string _taskreceiverName;
		private string _taskgrade;
		private bool _isread= false;
        private bool _iscomplete;

        public bool IsComplete
        {
            set { _iscomplete = value; }
            get { return _iscomplete; }
        }

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
		public string TaskReceiverId
		{
            set { _taskreceiverid = value; }
            get { return _taskreceiverid; }
		}
        public string TaskReceiverName
        {
            set { _taskreceiverName = value; }
            get { return _taskreceiverName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string TaskGrade
		{
			set{ _taskgrade=value;}
			get{return _taskgrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		#endregion Model

	}
}

