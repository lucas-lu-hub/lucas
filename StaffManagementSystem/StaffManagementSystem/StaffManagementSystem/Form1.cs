using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using StaffManagementSystem.tools;
using StaffManagementSystem.Model;
using StaffManagementSystem.Tools;
using System.Data.Common;
using System.Data.SqlClient;

namespace StaffManagementSystem
{
    public partial class StaffView : Form , IStaffView
    {
        private StaffDto Dto;

        public StaffView()
        {
            InitializeComponent();
            InitForm();

            // 初始化
            
        }

        public enum department
        {
            Sales,
            Department
        }
        private void StaffGrid_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        public void InitForm()
        {
            //DataBaseAccess DB = new DataBaseAccess();
            // 测试 临时
            //List<Staff> staffs = DB.getData();
            //staffs[0].Salary = 4500;
            //staffs[0].Name = "西野";
            //DB.Update(staffs[0]);
            //DB.Delete(new Staff(2));
            //DB.Create(new Staff() { StaffId = 2, Name = "小孙", Sex = "man", Department = "Development", Salary = 6000, IsRetired = false });
            //label.Text = staffs[0].StaffId.ToString();
            InitGrid();

        }

        public void InitGrid()
        {
            DataBaseAccess DB = new DataBaseAccess();
            Dto = new StaffDto(DB.getData());
            StaffGrid.DataSource = Dto.Table;

            // 颜色
            CellStyle cs = StaffGrid.Styles.Add("green");
            cs.BackColor = Color.FromArgb(199,224,202);
            for (int index = StaffGrid.Rows.Fixed; index <= StaffGrid.Rows.Count - 1; index += 2)
            {
                StaffGrid.Rows[index].Style = cs;
            }
            
            //StaffGrid.Cols["Department"].Format = 
            StaffGrid.Cols[1].Caption = "职员编号";
            StaffGrid.Cols[2].Caption = "职员姓名";
            StaffGrid.Cols[3].Caption = "性别";
            StaffGrid.Cols[4].Caption = "部门";
            StaffGrid.Cols[5].Caption = "工资";
            StaffGrid.Cols[6].Caption = "退休";

            //StaffGrid.Cols[1].EditMask = "0000";
            StaffGrid.Cols[1].Format = "#";
            Dto.Status = PageStatus.Edit;

            // 事件处理(对Id进行格式化)
             StaffGrid.SelChange += new EventHandler(this.FormatId);
        }

        void StaffGrid_SelChange(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            //StaffGrid.Rows.Add(new StaffInGrid[] { "New", 0, Gender.不明, Job.その他 });
            //bool temp = StaffGrid.IsCellSelected(1,1);
            int position = GetPosition();
            Dto.add(position);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            StaffGrid.AllowEditing = true;
            EditBtn.Enabled = false;
            EditPanel.Visible = true;
            Dto.Status = PageStatus.Edit;
        }

        private int GetPosition()
        {
            int index = 0;
            for (int i = 1; i <= Dto.DataCount; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (StaffGrid.IsCellSelected(i, j))
                    {
                        index = i;
                        return index;
                    }
                }
            }
            return 0;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int position = GetPosition();
            
            Dto.Delete(position);
        }

        private void CommitBtn_Click(object sender, EventArgs e)
        {
            // 测试保存记录
            SaveData();
            //控件状态修改
            StaffGrid.AllowEditing = false;
            EditBtn.Enabled = true;
            EditPanel.Visible = false;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Dto.rollBack();

            //控件状态修改
            StaffGrid.AllowEditing = false;
            EditBtn.Enabled = true;
            EditPanel.Visible = false;
        }

        public void SaveData()
        {
            DataBaseAccess DB = new DataBaseAccess();
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable temp = Dto.Table.GetChanges();

            // 如果未修改则直接退出
            if (temp == null)
            {
                return;
            }
            
            foreach (DataRow row in temp.Rows)
            {
                // 新建的记录
                if (row.RowState == DataRowState.Added)
                {
                    Staff newStaff = Dto.ConvertObjectFromRow(row);
                    DB.Create(newStaff);
                }
                // 删除的记录
                else if (row.RowState == DataRowState.Deleted)
                {
                    int id = Convert.ToInt32(row["id", DataRowVersion.Original]);
                    Staff newStaff = new Staff(id);
                    DB.Delete(newStaff);
                }
                // 更新的记录
                else if(row.RowState == DataRowState.Modified)
                {
                    Staff newStaff = Dto.ConvertObjectFromRow(row);
                    DB.Update(newStaff);
                }  
            }

            // 确认操作
            Dto.commit();
            
            // 更新本地数据
            Dto.updateLocalData(DB.getData());
            
        }

        private void FormatId(object sender, EventArgs e)
        {
            int index = StaffGrid.RowSel;
            string temp = StaffGrid.Rows[index][1].ToString();
            StaffGrid.Rows[index][1] = temp.PadLeft(4, '0');
        }
    }
}
