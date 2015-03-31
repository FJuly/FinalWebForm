using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Interface
{
    public interface ITechnicalBackbone
    {
        /// <summary>
        /// 申请技术骨干，系统发送通知
        /// </summary>
        void ApplyTechBackbone();
    }
}
