/**  。
* DutyPermission.cs
*
* 功 能： N/A
* 类 名： DutyPermission
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:29 
*/
using System;
namespace Model
{
	/// <summary>
	/// DutyPermission:实体类
	/// </summary>
	
	public partial class DutyPermission
	{
		public DutyPermission()
		{}
		#region Model
		private int _dutyid;
		private int _permid;
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
		public int PermId
		{
			set{ _permid=value;}
			get{return _permid;}
		}
		#endregion Model

	}
}

