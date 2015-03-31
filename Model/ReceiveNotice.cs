/**  。
* NoticeReceive.cs
*
* 功 能： N/A
* 类 名： NoticeReceive
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:31 
*/
using System;
namespace Model
{
	/// <summary>
	/// NoticeReceive:实体类
	/// </summary>
	
	public partial class ReceiveNotice
	{
        public ReceiveNotice()
		{}
		#region Model
		private int _noticeid;
		private string _noticereceiver;
		private bool _isread= false;
		/// <summary>
		/// 
		/// </summary>
		public int NoticeId
		{
			set{ _noticeid=value;}
			get{return _noticeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NoticeReceiver
		{
			set{ _noticereceiver=value;}
			get{return _noticereceiver;}
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

