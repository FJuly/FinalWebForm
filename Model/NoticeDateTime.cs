using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 由于DateTime类型不好转换，所以新加了一个类，没有想到较好的解决方法
    /// </summary>
    public class NoticeDateTime
    {

        public NoticeDateTime()
		{}
		#region Model
		private int _noticeid;
		private string _noticetitle;
		private string _noticecontent;
		private string _noticetime;
		private string _notifier;
        private string _isread;
		/// <summary>
		/// 
		/// </summary>
		public int NoticeId
		{
			set{ _noticeid=value;}
			get{return _noticeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NoticeTitle
		{
			set{ _noticetitle=value;}
			get{return _noticetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NoticeContent
		{
			set{ _noticecontent=value;}
			get{return _noticecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string NoticeTime
		{
			set{ _noticetime=value;}
			get{return _noticetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notifier
		{
			set{ _notifier=value;}
			get{return _notifier;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string IsRead
        {
            set { _isread = value; }
            get { return _isread; }
        }
		#endregion Model

    }
}
