using DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DetailProjInformationDAL
    {
        /// <summary>
        /// 根据Id查找项目详细信息
        /// </summary>
        /// <param name="projId"></param>
        /// <returns>项目信息列表</returns>
        public List<Model.V_DetailProjInformation> GetDetailList(string projId)
        {
            string strSql = "select *from V_DetailProjInformation where ProjId = '"+projId+"'";
            return SQLHelper.ExcuteList<Model.V_DetailProjInformation>(strSql);
        }
    }
}
