using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// V_SeeActivityInfo:实体类
    /// </summary>

    public partial class V_SeeActivityInfo
    {
        public V_SeeActivityInfo()
        { }
        #region Model
        private int _actid;
        private string _acttitle;
        private string _actcontent;
        private string _actaddress;
        private string _lstuname;
        private string _lstunum;
        private string _pstuname;
        private string _acttypename;
        private int _acttypeid;
        private DateTime _actstarttime;
        private DateTime _actendtime;
        private double _actexpenses;
        private string _actremark;
        private string _actattachmentpath;

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
        public string ActContent
        {
            set { _actcontent = value; }
            get { return _actcontent; }
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
        public string LStuName
        {
            set { _lstuname = value; }
            get { return _lstuname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LStuNum
        {
            set { _lstunum = value; }
            get { return _lstunum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PStuName
        {
            set { _pstuname = value; }
            get { return _pstuname; }
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
        public int ActTypeId
        {
            set { _acttypeid = value; }
            get { return _acttypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ActStartTime
        {
            set { _actstarttime = value; }
            get { return _actstarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ActEndTime
        {
            set { _actendtime = value; }
            get { return _actendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double ActExpenses
        {
            set { _actexpenses = value; }
            get { return _actexpenses; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActRemark
        {
            set { _actremark = value; }
            get { return _actremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActAttachmentPath
        {
            set { _actattachmentpath = value; }
            get { return _actattachmentpath; }
        }

        #endregion Model

    }
}
