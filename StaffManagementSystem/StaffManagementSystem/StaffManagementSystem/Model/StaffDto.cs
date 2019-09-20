using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManagementSystem.Tools;
using System.Data;

namespace StaffManagementSystem.Model
{
    public class StaffDto
    {
        private DataTable table;

        public StaffDto(List<Staff> data)
        {
            Staffs = ConvertObjectInGrid(data);
            table = GenerateTable(Staffs);
            DataCount = data.Count;
            Index = -1;
            Status = PageStatus.View;

            // 填充空格
            FillGrid();
        }
        /// <summary>
        /// 表格中的全部数据
        /// </summary>
        public List<StaffInGrid> Staffs { get; set; }

        public DataTable Table {
            get
            {
                if (table == null)
                {
                    table = new DataTable();
                }
                return table;
            }
            set
            {
            }
        }
        /// <summary>
        /// 表格数据的行数
        /// </summary>
        public int DataCount { get; set; }

        /// <summary>
        /// 选中行的索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 页面编辑状态
        /// </summary>
        public PageStatus Status { get; set; }



        private void FillGrid()
        {
            if (DataCount >= 14) return;
            for (int i = 0; i < 14-DataCount; i++)
            {
                //Staffs.Add(new StaffInGrid());
            }
        }

        /// <summary>
        /// 将职员对象转成存储在Grid中的存储对象
        /// </summary>
        /// <param name="staffs">职员对象</param>
        /// <returns>Grid中存储对象的集合</returns>
        private List<StaffInGrid> ConvertObjectInGrid(List<Staff> staffs)
        {
            List<StaffInGrid> result = new List<StaffInGrid>();
            foreach (Staff staff in staffs)
            {
                StaffInGrid temp = new StaffInGrid();
                // 格式化
                temp.Id = staff.StaffId.ToString().PadLeft(4,'0');
                temp.Name = staff.Name;
                temp.Sex = staff.Sex.Equals("man") ? EnumInGrid.sex.男 : EnumInGrid.sex.女;
                temp.Department = staff.Department.Equals("Development") ? EnumInGrid.department.开发部 : EnumInGrid.department.销售部;
                temp.Salary = staff.Salary.ToString();
                temp.IsRetired = staff.IsRetired;
                result.Add(temp);
            }
            return result;
        }

        public Staff ConvertObjectFromRow(DataRow resource)
        {
            Staff result = new Staff();
            result.StaffId = Convert.ToInt32(resource["id"]);
            result.Name = resource["name"].ToString();
            result.Sex = Convert.ToInt32(resource["sex"]) == 1? "man" : "woman";
            result.Department = Convert.ToInt32(resource["department"]) == 0? "Development" : "Sales";
            result.Salary = Convert.ToInt32(resource["salary"]);
            result.IsRetired = (bool)resource["retirement"];

            return result;
        }

        private DataTable GenerateTable(List<StaffInGrid> resource)
        {
            Table.Clear();
            Table.Columns.Add("id", typeof(string));
            Table.Columns.Add("name", typeof(string));
            Table.Columns.Add("sex", typeof(EnumInGrid.sex));
            Table.Columns.Add("department", typeof(EnumInGrid.department));
            Table.Columns.Add("salary", typeof(string));
            Table.Columns.Add("retirement", typeof(bool));
		    
            foreach (StaffInGrid temp in resource)
            {
                table.Rows.Add(new object[] { temp.Id, temp.Name, temp.Sex, temp.Department, temp.Salary, temp.IsRetired });
            }
            Table.AcceptChanges();
            return Table;
        }
        public void add(int position)
        {
            //指定位插入
            DataRow temp = Table.NewRow();
            temp["id"] = string.Empty;
            temp["name"] = string.Empty;
            temp["sex"] = EnumInGrid.sex.男;
            temp["department"] = EnumInGrid.department.开发部;
            temp["salary"] = 0;
            temp["retirement"] = false;
            Table.Rows.InsertAt(temp, position);
            DataCount++;
        }

        public void add()
        {
            table.Rows.Add(new object[] { string.Empty, string.Empty, EnumInGrid.sex.男, EnumInGrid.department.开发部, 0, false });
            DataCount++;
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="position">要删除的行的index</param>
        public void Delete(int position)
        {
            //table.Rows.RemoveAt(position - 1);
            Table.Rows[position - 1].Delete();
            DataCount--;
        }

        public void commit()
        {
            Table.AcceptChanges();
        }

        public void rollBack()
        {
            Table.RejectChanges();
        }

        public void updateLocalData(List<Staff> data)
        {
            Staffs = ConvertObjectInGrid(data);
        }
    }
}
