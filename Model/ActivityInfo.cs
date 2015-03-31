/**  。
* ActivityInfo.cs
*
* 功 能： N/A
* 类 名： ActivityInfo
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:26 
*/
using System;
namespace Model
{
	/// <summary>
	/// ActivityInfo:实体类
	/// </summary>
	
	public partial class ActivityInfo
	{
		public ActivityInfo()
		{}
		#region Model
		private int _actid;
		private string _acttitle;
		private string _actcontent;
		private string _actaddress;
		private string _actleader;
		private string _actpublisher;
		private int _acttypeid;
		private DateTime _actstarttime;
		private DateTime _actendtime;
		private decimal _actexpenses;
		private string _actremark;
		private string _actattachmentpath;
		private string _standbya;
		private string _standbyb;
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
		public string ActTitle
		{
			set{ _acttitle=value;}
			get{return _acttitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActContent
		{
			set{ _actcontent=value;}
			get{return _actcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActAddress
		{
			set{ _actaddress=value;}
			get{return _actaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActLeader
		{
			set{ _actleader=value;}
			get{return _actleader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActPublisher
		{
			set{ _actpublisher=value;}
			get{return _actpublisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActTypeId
		{
			set{ _acttypeid=value;}
			get{return _acttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ActStartTime
		{
			set{ _actstarttime=value;}
			get{return _actstarttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ActEndTime
		{
			set{ _actendtime=value;}
			get{return _actendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ActExpenses
		{
			set{ _actexpenses=value;}
			get{return _actexpenses;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActRemark
		{
			set{ _actremark=value;}
			get{return _actremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActAttachmentPath
		{
			set{ _actattachmentpath=value;}
			get{return _actattachmentpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StandbyA
		{
			set{ _standbya=value;}
			get{return _standbya;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StandbyB
		{
			set{ _standbyb=value;}
			get{return _standbyb;}
		}
		#endregion Model

	}
}

