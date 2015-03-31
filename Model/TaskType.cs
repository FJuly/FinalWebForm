/**  。
* TaskType.cs
*
* 功 能： N/A
* 类 名： TaskType
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:36 
*/
using System;
namespace Model
{
	/// <summary>
	/// TaskType:实体类
	/// </summary>
	
	public partial class TaskType
	{
		public TaskType()
		{}
		#region Model
		private int _tasktypeid;
		private string _tasktypename;
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
		public string TaskTypeName
		{
			set{ _tasktypename=value;}
			get{return _tasktypename;}
		}
		#endregion Model

	}
}

