/**  。
* ProjectType.cs
*
* 功 能： N/A
* 类 名： ProjectType
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:34 
*/
using System;
namespace Model
{
	/// <summary>
	/// ProjectType:实体类
	/// </summary>
	
	public partial class ProjectType
	{
		public ProjectType()
		{}
		#region Model
		private int _projtypeid;
		private string _projtypename;
		/// <summary>
		/// 
		/// </summary>
		public int ProjTypeId
		{
			set{ _projtypeid=value;}
			get{return _projtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjTypeName
		{
			set{ _projtypename=value;}
			get{return _projtypename;}
		}
		#endregion Model

	}
}

