using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
	/// V_ActivityInformation:实体类
	/// </summary>
	
	public partial class V_ActivityInformation
	{
		public V_ActivityInformation()
		{}
		#region Model
		private int _actid;
		private string _acttitle;
		private string _actaddress;
		private string _stuname;
		private string _acttypename;
		private DateTime _actstarttime;
		
		/// <summary>
		/// 
		/// </summary>
		public int ActId
		{
            set { _actid = value; }
            get { return _actid; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string ActTitle
		{
            set { _acttitle = value; }
            get { return _acttitle; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string ActAddress
		{
            set { _actaddress = value; }
            get { return _actaddress; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuName
		{
            set { _stuname = value; }
            get { return _stuname; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActTypeName
		{
            set { _acttypename = value; }
            get { return _acttypename; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ActStartTime
		{
            set { _actstarttime = value; }
            get { return _actstarttime; }
		}
		
		#endregion Model

	}
}
