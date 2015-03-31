using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface IStudyTask
    {
        /// <summary>
        /// 创建学习任务
        /// </summary>
        /// <param name="studyTask">学习任务Model</param>
        /// <param name="studyTaskParts">活动参与Model</param>
        /// <returns>创建成功过返回true，删除失败返回false</returns>
        bool CreateStudyTask(TaskInformation studyTask,string[] studyTaskParts) ;

        /// <summary>
        /// 修改学习任务学习任务
        /// </summary>
        /// <param name="studyTask">学习任务Model</param>
        /// <param name="studyTaskPar">活动参与Model</param>
        /// <returns>修改成功返回true，删除失败返回false</returns>
        bool UpdateStudyTask(TaskInformation studyTask, string[] studyTaskParts);

        /// <summary>
        ///删除学习任务
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>删除成功返回true，返回失败返回false</returns>
        bool DeleteStudyTask(int Id);

    }
}
