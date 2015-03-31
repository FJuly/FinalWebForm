/**  。
* ActivityParticipation.cs
*
* 功 能： N/A
* 类 名： ActivityParticipation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:27 
*/
using System;
namespace Model
{
	/// <summary>
	/// ActivityParticipation:实体类
	/// </summary>
	
	public partial class ActivityParticipation
	{
		public ActivityParticipation()
		{}
		#region Model
		private int _actid;
		private bool _isorganizer= false;
		private bool _isread= false;
		private string _actreceiver;
		/// <summary>
		/// 
		/// </summary>
		public int ActId
		{
			set{ _actid=value;}
			get{return _actid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsOrganizer
		{
			set{ _isorganizer=value;}
			get{return _isorganizer;}
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
		public string ActReceiver
		{
			set{ _actreceiver=value;}
			get{return _actreceiver;}
		}
		#endregion Model

	}
}

