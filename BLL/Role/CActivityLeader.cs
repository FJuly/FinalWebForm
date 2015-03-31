using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Role
{
    /// <summary>
    /// 活动策划组组长
    /// </summary>
    class CActivityLeader:IActitviy,INotice
    {


        public bool CreateActivity(ActivityInfo activityInfo, ActivityParticipation[] activityParts)
        {
            throw new NotImplementedException();
        }

        public bool UpdateActivity(ActivityInfo activityInfo, ActivityParticipation[] activityParts)
        {
            throw new NotImplementedException();
        }

        public bool DeleteActivity(int activityId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteActivity(string activityId)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public bool CreateNotice(Model.Notice notice, Model.ReceiveNotice[] receiver)
        {
            throw new NotImplementedException();
        }
    }
}
