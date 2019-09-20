using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagementSystem.tools
{
    public interface IStaffView
    {

        /// <summary>
        /// 初始化界面
        /// </summary>
        void InitForm();

        /// <summary>
        /// 初始化表格
        /// </summary>
        void InitGrid();
    }
}
