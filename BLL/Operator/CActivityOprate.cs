using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operator
{
    /*------------------------------林志章2014-10-24-------------------------------------*/
    public class CActivityOprate
    {

//---------------------------------------ActivityInfoBLL中转来的----------------------------------------------
        DAL.ActivityInfoDAL dal = new DAL.ActivityInfoDAL();

        #region 分页查找所有活动信息
        /// <summary>
        /// 分页查找所有活动信息
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartList(int page, int size)
        {
            return dal.GetPartList(page, size);
        } 
        #endregion

        #region 分页按活动名称查找所有活动信息
        /// <summary>
        /// 分页按活动名称查找所有活动信息
        /// </summary>
        /// <param name="searchContent">活动名称</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartListByActTitle(string searchContent, int page, int size)
        {
            return dal.GetPartListByActTitle(searchContent, page, size);
        } 
        #endregion

        #region 分页按活动类型查找所有活动信息
        /// <summary>
        /// 分页按活动类型查找所有活动信息
        /// </summary>
        /// <param name="searchContent">活动类型</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartListByActType(string searchContent, int page, int size)
        {
            return dal.GetPartListByActType(searchContent, page, size);
        } 
        #endregion

        #region 分页按活动负责人查找所有活动信息
        /// <summary>
        /// 分页按活动负责人查找所有活动信息
        /// </summary>
        /// <param name="searchContent">活动负责人</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页大小</param>
        /// <returns></returns>
        public List<Model.V_ActivityInformation> GetPartListByActLeader(string searchContent, int page, int size)
        {
            return dal.GetPartListByActLeader(searchContent, page, size);
        } 
        #endregion

        #region 通过活动ID修改活动信息
        /// <summary>
        /// 通过活动ID修改活动信息
        /// </summary>
        /// <param name="actinfo"></param>
        /// <returns></returns>
        public int SaveEditAct(ActivityInfo actinfo)
        {
            return dal.SaveEditAct(actinfo);
        } 
        #endregion

        #region 新增活动信息
        /// <summary>
        /// 新增活动信息
        /// </summary>
        /// <param name="projinfo"></param>
        /// <returns></returns>
        public int InsertActInfo(Model.ActivityInfo actinfo)
        {
            return dal.InsertActInfo(actinfo);

        } 
        #endregion

        #region 根据活动Id删除活动
        /// <summary>
        /// 根据活动Id删除活动
        /// </summary>
        /// <param name="actid"></param>
        /// <returns></returns>
        public int DeleteActById(string actid)
        {
            return dal.DeleteActById(actid);
        } 
        #endregion


//------------------------------------V_SeeActivityInfoDAL转来的--------------------------------------------------
        DAL.V_SeeActivityInfoDAL dal2 = new DAL.V_SeeActivityInfoDAL();

        #region 通过活动Id获得活动的详细信息
        /// <summary>
        /// 通过活动Id获得活动的详细信息
        /// </summary>
        /// <param name="id">活动Id</param>
        /// <returns></returns>
        public List<Model.V_SeeActivityInfo> GetActInfo(string id)
        {
            return dal2.GetActInfo(id);
        } 
        #endregion


        #region 获得所有成员信息
        /// <summary>
        /// 获得所有成员信息
        /// </summary>
        /// <returns></returns>
        public List<Model.MemberInformation> GetAllMemberList()
        {
            return dal2.GetAllMemberList();
        } 
        #endregion

        #region 获取总的活动条数
        /// <summary>
        /// 获取总的活动条数
        /// </summary>
        /// <returns></returns>
        public int GetActCount()
        {
            return dal2.GetActCount();
        } 
        #endregion

    }


}
