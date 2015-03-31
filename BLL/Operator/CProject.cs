using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operator
{
    public class CProject
    {

        /***************************************************王顺 2014.10.13*********************************************************/

        DAL.V_ProjectInformationDAL vdal = new DAL.V_ProjectInformationDAL();
        DAL.ProjectParticipationDAL partidal = new DAL.ProjectParticipationDAL();
        DAL.ProjectPhotoDAL photodal = new DAL.ProjectPhotoDAL();
        DAL.ProjectTypeDAL typedal = new DAL.ProjectTypeDAL();
        DAL.ProjectInformationDAL dal = new DAL.ProjectInformationDAL();

        //////////////////////////////////////////项目基本信息///////////////////////////////////////

        //ws  2014.10.13
        #region 分页查找所有项目信息
        /// <summary>
        /// 分页查找所有项目信息
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns>项目信息列表</returns>
        public List<Model.PartProjInformation> GetPartList(int page, int size)
        {
            return vdal.GetPartList(page, size);
        } 
        #endregion

        //ws  2014.10.13
        #region 分页按项目名称查找所有项目信息
        /// <summary>
        /// 分页按项目名称查找所有项目信息
        /// </summary>
        /// <param name="searchContent">项目名称</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.PartProjInformation> GetPartListByName(string searchContent, int page, int size)
        {
            return vdal.GetPartListByName(searchContent, page, size);
        } 
        #endregion

        //ws  2014.10.13
        #region 分页按项目类型查找所有项目信息
        /// <summary>
        /// 分页按项目类型查找所有项目信息
        /// </summary>
        /// <param name="searchContent">项目类型名</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.PartProjInformation> GetPartListByType(string searchContent, int page, int size)
        {
            return vdal.GetPartListByType(searchContent, page, size);
        } 
        #endregion

        //ws  2014.10.13
        #region 分页按项目主管名字查找
        /// <summary>
        /// 分页按项目主管名字查找
        /// </summary>
        /// <param name="searchContent">主管姓名</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.PartProjInformation> GetPartListByLeader(string searchContent, int page, int size)
        {
            return vdal.GetPartListByLeader(searchContent, page, size);
        } 
        #endregion

        //ws  2014.10.13
        #region 获取项目数目
        /// <summary>
        /// 获取项目数目
        /// </summary>
        /// <returns>数据条数</returns>
        public int GetProjCount()
        {
            return vdal.GetProjCount();
        } 
        #endregion



        //////////////////////////////////////////项目详细信息///////////////////////////////////////

        DAL.DetailProjInformationDAL dal2 = new DAL.DetailProjInformationDAL();

        //ws  2014.10.13
        #region 根据Id查找项目详细信息
        /// <summary>
        /// 根据Id查找项目详细信息
        /// </summary>
        /// <param name="projId"></param>
        /// <returns>项目详细信息表</returns>
        public List<Model.V_DetailProjInformation> GetDetailList(string projId)
        {
            return dal2.GetDetailList(projId);
        } 
        #endregion

        //ws  2014.10.13
        #region 根据Id查找项目截图
        /// <summary>
        /// 根据Id查找项目截图
        /// </summary>
        /// <param name="projId"></param>
        /// <returns>项目截图列表</returns>
        public List<Model.ProjectPhoto> GetPhotoList(string projId)
        {
            return photodal.GetPhotoList(projId);
        } 
        #endregion

        //ws  2014.10.13
        #region 根据项目Id查找项目成员
        /// <summary>
        /// 根据项目Id查找项目成员
        /// </summary>
        /// <param name="projId"></param>
        /// <returns>返回成员表</returns>
        public List<Model.ProjectParticipation> GetParticipantsList(string projId)
        {
            return partidal.GetParticipantsList(projId);
        } 
        #endregion

        //ws  2014.10.13
        #region 查找项目类型列表
        /// <summary>
        ///  查找项目类型列表
        /// </summary>
        /// <returns>项目类型列表</returns>
        public List<Model.ProjectType> GetAllProjType()
        {
            return typedal.GetAllProjType();
        } 
        #endregion

        //ws  2014.10.13
        #region 更新项目信息
        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="projinfo"></param>
        /// <returns>返回受影响行数</returns>
        public int UpdateProjInfo(Model.ProjectInformation projinfo)
        {
            return dal.UpdateProjInfo(projinfo);
        } 
        #endregion

        //ws  2014.10.13
        #region 更新项目截图
        /// <summary>
        /// 更新项目截图
        /// </summary>
        /// <param name="projphoto"></param>
        /// <returns>返回受影响行数</returns>
        public int UpdatePhoto(Model.ProjectPhoto projphoto)
        {
            return photodal.UpdatePhoto(projphoto);
        } 
        #endregion

        //ws  2014.10.13
        #region 新建项目
        /// <summary>
        /// 新建项目
        /// </summary>
        /// <param name="projinfo"></param>
        /// <returns>返回结果</returns>
        public bool InsertProjInfo(Model.ProjectInformation projinfo)
        {
            if (dal.InsertProjInfo(projinfo) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        //ws  2014.10.13
        #region 根据项目Id删除项目成员信息
        /// <summary>
        /// 根据项目Id删除项目成员信息
        /// </summary>
        /// <param name="projid"></param>
        /// <returns>受影响行数</returns>
        public int DeleteProjParti(int p)
        {
            return partidal.DeleteProjParti(p);
        } 
        #endregion

        //ws  2014.10.13
        #region 根据项目Id增加项目成员信息
        /// <summary>
        ///  根据项目Id增加项目成员信息
        /// </summary>
        /// <param name="projparti"></param>
        /// <returns></returns>
        public int AddProjParti(Model.ProjectParticipation projparti)
        {
            return partidal.AddProjParti(projparti);
        } 
        #endregion

        //ws  2014.10.13
        #region 获取项目阶段列表
        /// <summary>
        /// 获取项目阶段列表
        /// </summary>
        /// <returns></returns>
        public List<Model.ProjectPhase> GetPlanList()
        {
            return dal.GetPlanList();
        } 
        #endregion

        //ws  2014.10.13
        #region 获取项目阶段详细信息
        /// <summary>
        /// 获取项目阶段详细信息
        /// </summary>
        /// <returns></returns>
        public List<Model.V_ProjectPhase> GetPlanInfoList()
        {
            return dal.GetPlanInfoList();
        } 
        #endregion

        //ws  2014.10.13
        #region 获取任务接受者
        /// <summary>
        /// 获取任务接受者
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetTaskReceive(int taskid)
        {
            string TaskReceive = "";
            List<Model.TaskParticipation> list = dal.GetTaskReceive(taskid);
            for (int i = 0; i < list.Count; i++)
            {
                if (i != 0)
                {
                    TaskReceive += "、";
                }
                TaskReceive += list[i].TaskReceiverName;    //PS 2014.10.19 TaskReceiver改为TaskReceiverId 
            }
            return TaskReceive;
        } 
        #endregion

        //ws  2014.10.13
        #region 删除项目信息
        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="projId"></param>
        /// <returns></returns>
        public bool DelProject(string projId)
        {
            if (dal.DelProject(projId) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

/****************************潘帅 2014.10.19***********************************************/

        
        //PS 2014.10.13
        #region 获取项目阶段信息
        /// <summary>
        /// 获取项目阶段信息
        /// </summary>
        /// <returns></returns>
        public List<ProjectPhase> GetAllProjectPhase()
        {
            return new ProjectPhaseDAL().GetAllProjectPhase();
        } 
        #endregion

        //PS  2014.10.13
        #region 根据项目主管查询项目信息
        /// <summary>
        /// 根据项目主管查询项目信息
        /// </summary>
        /// <param name="projLeader"></param>
        /// <returns></returns>
        public List<ProjectInformation> GetProjByLeader(string projLeader)
        {
            return new ProjectInformationDAL().GetProjByLeader(projLeader);
        } 
        #endregion

        //PS  2014.10.13
        #region 根据项目Id获取项目名称
        /// <summary>
        ///  根据项目Id获取项目名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetProjNameById(int id)
        {
            return new ProjectInformationDAL().GetProjNameById(id);
        } 
        #endregion

        //PS 2014.10.13
        #region 获取所有项目成员信息
        /// <summary>
        /// 获取所有项目成员信息
        /// </summary>
        /// <param name="projId"></param>
        /// <returns></returns>
        public List<MemberInformation> GetProjMemberList(int projId)
        {
            return new ProjectInformationDAL().GetProjMemberList(projId);
        } 
        #endregion

    }
}
