/**  。
* ActivityType.cs
*
* 功 能： N/A
* 类 名： ActivityType
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:27 
*/
using System;
namespace Model
{
	/// <summary>
	/// ActivityType:实体类
	/// </summary>
	
	public partial class ActivityType
	{
		public ActivityType()
		{}
		#region Model
		private int _acttypeid;
		private string _acttypename;
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
		public string ActTypeName
		{
			set{ _acttypename=value;}
			get{return _acttypename;}
		}
		#endregion Model

	}
}

