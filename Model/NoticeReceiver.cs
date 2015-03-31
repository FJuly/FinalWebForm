using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 通知接收者model
    /// </summary>
    public class NoticeReceiver
    {
        private string _stunum;
        private string _stuname;
        /// </summary>
        public string StuNum
        {
            set { _stunum = value; }
            get { return _stunum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StuName
        {
            set { _stuname = value; }
            get { return _stuname; }
        }
    }
}
