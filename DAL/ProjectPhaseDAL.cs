using DBUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProjectPhaseDAL
    {
        /*************************************王顺 2014.10.24*********************************/
        //ws  2014.10.24
        #region 获取所有项目阶段
        /// <summary>
        /// 获取所有项目阶段
        /// </summary>
        /// <returns>项目阶段列表</returns>
        public List<ProjectPhase> GetAllProjectPhase()
        {
            List<ProjectPhase> list = new List<ProjectPhase>();
            list = (List<ProjectPhase>)SQLHelper.ExcuteList<ProjectPhase>("select * from T_ProjectPhase");
            return list;
        } 
        #endregion
    }
}
