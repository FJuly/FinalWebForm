using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// V_DetailProjInformation:实体类
    /// </summary>
    public class V_DetailProjInformation
    {
        public V_DetailProjInformation() 
        { }

        #region 属性们
        private int _projectid;
        private int _projecttypeid;
        private string _projtypename;
        private string _projname;
        private string _projleadernum;
        private string _projleader;
        private string _projpublishernum;
        private string _projpublisher;
        private DateTime _projstarttime;
        private DateTime _exfinishitime;
        private DateTime _acfinishitime;
        private string _projprofile;
        private string _projmark;
        #endregion 属性们

        #region 字段们
        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjId
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 项目类型id
        /// </summary>
        public int ProjTypeId
        {
            set { _projecttypeid = value; }
            get { return _projecttypeid; }
        }
        /// <summary>
        /// 项目类型
        /// </summary>
        public string ProjTypeName
        {
            set { _projtypename = value; }
            get { return _projtypename; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjName
        {
            set { _projname = value; }
            get { return _projname; }
        }
        /// <summary>
        /// 项目主管学号
        /// </summary>
        public string ProjLeaderNum
        {
            set { _projleadernum = value; }
            get { return _projleadernum; }
        }
        /// <summary>
        /// 项目主管
        /// </summary>
        public string ProjLeader
        {
            set { _projleader = value; }
            get { return _projleader; }
        }
        /// <summary>
        /// 项目发布人学号
        /// </summary>
        public string ProjPublisherNum
        {
            set { _projpublishernum = value; }
            get { return _projpublishernum; }
        }
        /// <summary>
        /// 项目发布人
        /// </summary>
        public string ProjPublisher
        {
            set { _projpublisher = value; }
            get { return _projpublisher; }
        }
        /// <summary>
        /// 项目开始时间
        /// </summary>
        public DateTime ProjStartTime
        {
            set { _projstarttime = value; }
            get { return _projstarttime; }
        }
        /// <summary>
        /// 预计完成时间
        /// </summary>
        public DateTime ExFinishiTime
        {
            set { _exfinishitime = value; }
            get { return _exfinishitime; }
        }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public DateTime AcFinishiTime
        {
            set { _acfinishitime = value; }
            get { return _acfinishitime; }
        }
        /// <summary>
        /// 项目简介
        /// </summary>
        public string ProjProfile
        {
            set { _projprofile = value; }
            get { return _projprofile; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string ProjMark
        {
            set { _projmark = value; }
            get { return _projmark; }
        }
        #endregion Model
    }
}
