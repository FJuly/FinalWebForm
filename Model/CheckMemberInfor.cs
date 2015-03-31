using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CheckMemberInfor
    {    //新建的Model，供查询成员信息时使用
        public CheckMemberInfor()
        { }

        private string _stunum;
        private string _stuname;
        private string _major;
        private string _techdirename;
        private string _techlevelname;
        private string _telephonenumber;
        private string _duty;

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

        /// <summary>
        /// 
        /// </summary>
        public string Major
        {
            set { _major = value; }
            get { return _major; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TechDireName
        {
            set { _techdirename = value; }
            get { return _techdirename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TechLevelName
        {
            set { _techlevelname = value; }
            get { return _techlevelname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TelephoneNumber
        {
            set { _telephonenumber = value; }
            get { return _telephonenumber; }
        }

        public string Duty
        {
            set { _duty = value; }
            get { return _duty; }
        }
    }
}
