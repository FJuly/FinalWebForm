using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PartProjInformation
    {
        private int _projectid;
        private string _projtype;
        private string _projname;
        private string _stuname;
        private DateTime _projstarttime;
        private DateTime _acfinishitime;

        public int ProjId
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjTypeName
        {
            set { _projtype = value; }
            get { return _projtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjName
        {
            set { _projname = value; }
            get { return _projname; }
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
        public DateTime ProjStartTime
        {
            set { _projstarttime = value; }
            get { return _projstarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AcFinishiTime
        {
            set { _acfinishitime = value; }
            get { return _acfinishitime; }
        }
    }
}
