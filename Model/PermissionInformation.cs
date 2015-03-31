/**  。
* PermissionInformation.cs
*
* 功 能： N/A
* 类 名： PermissionInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:32 
*/
using System;
namespace Model
{
	/// <summary>
	/// PermissionInformation:实体类
	/// </summary>
	
	public partial class PermissionInformation
	{
		public PermissionInformation()
		{}
		#region Model
		private int _permid;
		private string _permname;
		/// <summary>
		/// 
		/// </summary>
		public int PermId
		{
			set{ _permid=value;}
			get{return _permid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PermName
		{
			set{ _permname=value;}
			get{return _permname;}
		}
		#endregion Model

	}
}

