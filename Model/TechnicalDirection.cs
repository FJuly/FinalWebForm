/**  。
* TechnicalDirection.cs
*
* 功 能： N/A
* 类 名： TechnicalDirection
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:37 
*/
using System;
namespace Model
{
	/// <summary>
	/// TechnicalDirection:实体类
	/// </summary>
	
	public partial class TechnicalDirection
	{
		public TechnicalDirection()
		{}
		#region Model
		private int _tecdirid;
		private string _tecdirname;
		/// <summary>
		/// 
		/// </summary>
		public int TecDirId
		{
			set{ _tecdirid=value;}
			get{return _tecdirid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TecDirName
		{
			set{ _tecdirname=value;}
			get{return _tecdirname;}
		}
		#endregion Model

	}
}

