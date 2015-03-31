/**  。
* InviteCode.cs
*
* 功 能： N/A
* 类 名： InviteCode
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:29 
*/
using System;
namespace Model
{
	/// <summary>
	/// InviteCode:实体类
	/// </summary>
	
	public partial class InviteCode
	{
		public InviteCode()
		{}
		#region Model
		private int _invicodeid;
		private string _invicode;
		/// <summary>
		/// 
		/// </summary>
		public int InviCodeId
		{
			set{ _invicodeid=value;}
			get{return _invicodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InviCode
		{
			set{ _invicode=value;}
			get{return _invicode;}
		}
		#endregion Model

	}
}

