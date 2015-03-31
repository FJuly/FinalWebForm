using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IActitviy
    {
        /// <summary>
        /// 创建一个新的活动
        /// </summary>
        /// <param name="activityInfo">活动Model</param>
        /// <param name="activityParts">活动参与Model</param>
        /// <returns></returns>
        bool CreateActivity(ActivityInfo activityInfo,ActivityParticipation[] activityParts);


        /// <summary>
        /// 修改一个活动
        /// </summary>
        /// <param name="activityInfo">活动Model</param>
        /// <param name="activityParts">活动参与Model</param>
        /// <returns></returns>
        bool UpdateActivity(ActivityInfo activityInfo, ActivityParticipation[] activityParts);

        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="Id">删除活动的Id</param>
        /// <returns>删除活动成功返回TRUE，失败返回false</returns>
        bool DeleteActivity(string activityId);
        

    }
}
