/**  。
* V_ProjectInformation.cs
*
* 功 能： N/A
* 类 名： V_ProjectInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:39 
*/
using System;
namespace Model
{
	/// <summary>
	/// V_ProjectInformation:实体类
	/// </summary>
	
	public partial class V_ProjectInformation
	{
		public V_ProjectInformation()
		{}
		#region Model
		private int _projectid;
		private string _projtypename;
		private string _projname;
		private string _projleader;
		private string _projpublisher;
		private DateTime _projstarttime;
		private DateTime _exfinishitime;
		private DateTime _acfinishitime;
		private string _projprofile;
		private decimal _projmoney;
		private string _projattachmentpath;
		private string _projmark;
		/// <summary>
		/// 
		/// </summary>
		public int ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjTypeName
		{
			set{ _projtypename=value;}
			get{return _projtypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjName
		{
			set{ _projname=value;}
			get{return _projname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjLeader
		{
			set{ _projleader=value;}
			get{return _projleader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjPublisher
		{
			set{ _projpublisher=value;}
			get{return _projpublisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ProjStartTime
		{
			set{ _projstarttime=value;}
			get{return _projstarttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ExFinishiTime
		{
			set{ _exfinishitime=value;}
			get{return _exfinishitime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AcFinishiTime
		{
			set{ _acfinishitime=value;}
			get{return _acfinishitime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjProfile
		{
			set{ _projprofile=value;}
			get{return _projprofile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ProjMoney
		{
			set{ _projmoney=value;}
			get{return _projmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjAttachmentPath
		{
			set{ _projattachmentpath=value;}
			get{return _projattachmentpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjMark
		{
			set{ _projmark=value;}
			get{return _projmark;}
		}
		#endregion Model

	}
}

