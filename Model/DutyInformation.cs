/**  。
* DutyInformation.cs
*
* 功 能： N/A
* 类 名： DutyInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:28 
*/
using System;
namespace Model
{
	/// <summary>
	/// DutyInformation:实体类
	/// </summary>
	
	public partial class DutyInformation
	{
		public DutyInformation()
		{}
		#region Model
		private int _dutyid;
		private string _dutyname;
		/// <summary>
		/// 
		/// </summary>
		public int DutyId
		{
			set{ _dutyid=value;}
			get{return _dutyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DutyName
		{
			set{ _dutyname=value;}
			get{return _dutyname;}
		}
		#endregion Model

	}
}

