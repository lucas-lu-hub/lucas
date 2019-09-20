using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagementSystem.Model
{
    /// <summary>
    /// 职工的实体类
    /// </summary>
    public class Staff
    {
        /// <summary>
        /// 构造函数(无参)
        /// </summary>
        public Staff()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">ID</param>
        public Staff(int id)
        {
            StaffId = id;
        }

        /// <summary>
        /// id
        /// </summary>
        public int StaffId { get; set;}

        /// <summary>
        /// Name 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sex 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Department 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Salary 工资
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// IsRetired 是否退休
        /// </summary>
        public bool IsRetired { get; set; }
    }
}
