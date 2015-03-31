using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class V_ProjectPhase
    {
        string _projphase;
        int _taskid;
        string _taskname;
        DateTime _taskbegtime;
        DateTime _taskendtime;

        public string ProjPhase 
        {
            get { return _projphase; }
            set { _projphase = value; }
        }
        public int TaskId
        {
            get { return _taskid; }
            set { _taskid = value; }
        }

        public string TaskName
        {
            get { return _taskname; }
            set { _taskname = value; }
        }
        
        public DateTime TaskBegTime 
        {
            get { return _taskbegtime; }
            set { _taskbegtime = value; }    
         }
        
        public DateTime TaskEndTime 
        {
            get { return _taskendtime; }
            set { _taskendtime = value; }
        }
    }
}
