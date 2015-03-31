/**  。
* DutyAct.cs
*
* 功 能： N/A
* 类 名： DutyAct
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:28 
*/
using System;
namespace Model
{
	/// <summary>
	/// DutyAct:实体类
	/// </summary>
	
	public partial class DutyAct
	{
		public DutyAct()
		{}
		#region Model
		private int _dutyid;
        private string _dutyactor;
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
		public string DutyActor
		{
            set { _dutyactor = value; }
            get { return _dutyactor; }
		}
		#endregion Model

	}
}

