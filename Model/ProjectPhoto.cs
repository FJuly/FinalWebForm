/**  。
* ProjectPhoto.cs
*
* 功 能： N/A
* 类 名： ProjectPhoto
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:33 
*/
using System;
namespace Model
{
	/// <summary>
	/// ProjectPhoto:实体类
	/// </summary>
	
	public partial class ProjectPhoto
	{
		public ProjectPhoto()
		{}
		#region Model
        private int _projphotoid;
		private int _projid;
		private string _projphotopath;
        /// <summary>
        /// 
        /// </summary>
        public int ProjPhotoId {
            set { _projphotoid = value; }
            get { return _projphotoid; }
        }
        /// <summary>
		/// 
		/// </summary>
		public int ProjId
		{
			set{ _projid=value;}
			get{return _projid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjPhotoPath
		{
			set{ _projphotopath=value;}
			get{return _projphotopath;}
		}
		#endregion Model

	}
}

