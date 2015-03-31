/**  。
* V_MemberTaskInfo.cs
*
* 功 能： N/A
* 类 名： V_MemberTaskInfo
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-29 13:26:55 
*/
using System;
namespace Model
{
	/// <summary>
	/// 成员任务信息详情:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class VMemberTaskInfo
	{
		#region Model
		private int _taskid;//任务id
		private string _tasksender;//任务发布者
		private string _taskname;//任务标题
		private int _tasktypeid;//任务类型Id
		private string _taskcontent;//任务内容
		private DateTime _taskbegtime;//开始时间
		private DateTime _taskendtime;//结束时间
		private int _projid;//项目Id
        private string _projname;

        public string ProjName
        {
            get { return _projname; }
            set { _projname = value; }
        }
		private int _projphaseid;//项目阶段
        public int ProjPhaseId
        {
            get { return _projphaseid; }
            set { _projphaseid = value; }
        }
        private string _projphase;
		private string _taskattachmentpath;//任务附件路径
		private string _taskreceiver;//任务接收人
		private string _taskgrade;//任务评分
		private bool _isread;//是否已读
		private bool _iscomplete;//是否完成
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
		/// <summary>
		/// 
		/// </summary>
		public string TaskReceiver
		{
			set{ _taskreceiver=value;}
			get{return _taskreceiver;}
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
		/// <summary>
		/// 
		/// </summary>
		public bool IsComplete
		{
			set{ _iscomplete=value;}
			get{return _iscomplete;}
		}
		#endregion Model

	}
}

