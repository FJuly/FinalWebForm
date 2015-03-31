/**  。
* Notice.cs
*
* 功 能： N/A
* 类 名： Notice
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:31 
*/
using System;
namespace Model
{
	/// <summary>
	/// Notice:实体类
	/// </summary>
	
	public partial class Notice
	{
		public Notice()
		{}
		#region Model
		private int _noticeid;
		private string _noticetitle;
		private string _noticecontent;
		private DateTime _noticetime;
		private string _notifier;
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
		public string NoticeTitle
		{
			set{ _noticetitle=value;}
			get{return _noticetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NoticeContent
		{
			set{ _noticecontent=value;}
			get{return _noticecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
        public DateTime NoticeTime
		{
			set{ _noticetime=value;}
			get{return _noticetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notifier
		{
			set{ _notifier=value;}
			get{return _notifier;}
		}
		#endregion Model

	}
}

