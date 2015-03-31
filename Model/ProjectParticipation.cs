/**  。
* ProjectParticipation.cs
*
* 功 能： N/A
* 类 名： ProjectParticipation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:33 
*/
using System;
namespace Model
{
	/// <summary>
	/// ProjectParticipation:实体类
	/// </summary>
	
	public partial class ProjectParticipation
	{
		public ProjectParticipation()
		{}
		#region Model
		private int _projid;
        private string _projreceicernum;
		private string _projreceiver;
		/// <summary>
		///  项目id
		/// </summary>
		public int ProjId
		{
			set{ _projid=value;}
			get{return _projid;}
		}
		/// <summary>
		///  项目接收人学号
		/// </summary>
		public string ProjReceiverNum
		{
            set { _projreceicernum = value; }
            get { return _projreceicernum; }
		}
        /// <summary>
        ///  项目接收人姓名
        /// </summary>
        public string ProjReceiver
        {
            set { _projreceiver = value; }
            get { return _projreceiver; }
        }
		#endregion Model

	}
}

