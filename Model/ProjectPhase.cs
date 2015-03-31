using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProjectPhase
    {
        int _projphaseid;
        string _projphase;

        public int ProjPhaseId
        {
            set { _projphaseid = value; }
            get { return _projphaseid; }
        }

        public string ProjPhase 
        {
            set { _projphase = value; }
            get { return _projphase; }
        }
    }
}
