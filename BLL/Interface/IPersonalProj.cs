using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Interface
{
    /// <summary>
    /// 个人项目操作接口
    /// </summary>
    public interface IPersonalProj
    {
        /// <summary>
        /// 新建个人项目
        /// </summary>
        /// <param name="projInfo">项目信息</param>
        /// <param name="projPart">项目参与表</param>
        /// <returns>创建结果</returns>
        bool CreateProj(ProjectInformation projInfo, ProjectParticipation[] projParts);

        /// <summary>
        /// 删除个人项目
        /// </summary>
        /// <param name="projId">项目Id</param>
        /// <returns>删除结果</returns>
        bool DeleteProj(int projId);

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="projInfo">项目信息</param>
        /// <param name="projPart">项目参与表</param>
        /// <returns>更新结果</returns>
        bool UpdateProj(ProjectInformation projInfo, ProjectParticipation[] projParts);
    }
}
