/**  。
* TechnicaLevel.cs
*
* 功 能： N/A
* 类 名： TechnicaLevel
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:37 
*/
using System;
namespace Model
{
	/// <summary>
	/// TechnicaLevel:实体类
	/// </summary>
	
	public partial class TechnicaLevel
	{
		public TechnicaLevel()
		{}
		#region Model
		private int _teclevelid;
		private string _teclevelname;
		/// <summary>
		/// 
		/// </summary>
		public int TecLevelId
		{
			set{ _teclevelid=value;}
			get{return _teclevelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TecLevelName
		{
			set{ _teclevelname=value;}
			get{return _teclevelname;}
		}
		#endregion Model

	}
}

