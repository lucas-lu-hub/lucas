using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StaffManagementSystem.Model;
using System.Data;

namespace StaffManagementSystem.Tools
{
    public class DataBaseAccess
    {
        private string connectionString;

        /// <summary>
        /// 构建函数
        /// </summary>
        public DataBaseAccess()
        {
            connectionString =
            "Data Source= 10.32.1.73;Initial Catalog=StaffManagementSysterm;"
            + "User Id=zhy;Password=QWer1234;";
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>数据集合</returns>
        public List<Staff> getData()
        {
            // 创建连接对象
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;

            List<Staff> result = new List<Staff>();
            string sql = "select * from staff ";
            using (conn)
            {
                // 建立连接
                conn.Open();

                // 创建SQL语句
                SqlCommand queryCmd = new SqlCommand(sql, conn); 
                //执行SQL命令
                SqlDataReader reader = queryCmd.ExecuteReader();

                while (reader.Read())
                {
                    // 数据绑定
                    Staff staff = new Staff();
                    staff.StaffId = (int)reader["StaffId"];
                    staff.Name = reader["StaffName"].ToString();
                    staff.Sex = Convert.ToInt32(reader["StaffSex"]) == 1 ? "man" : "woman";
                    staff.Department = reader["Department"].ToString();
                    staff.Salary = (int)reader["salary"];
                    staff.IsRetired = Convert.ToInt32(reader["retirement"]) == 1? false : true;

                    result.Add(staff);
                }
                reader.Close();
                conn.Close();
            }
            return result;
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="staff">被更新的对象数据</param>
        /// <returns>更新的数据条数</returns>
        public int Update(Staff staff)
        {
            // 创建连接对象
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;

            int result = 0;
            string sql = "update staff set StaffName = @Name, " +
                "StaffSex = @Sex," +
                "Department = @Department," +
                "salary = @Salary," + 
                "retirement = @retirement " + 
                "where StaffId = @id";

            using (conn)
            {
                // 建立连接
                conn.Open();

                // 创建SQL语句
                SqlCommand queryCmd = new SqlCommand(sql, conn);

                // 创建参数列表
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter() { ParameterName = "Name", SqlDbType = SqlDbType.NVarChar, Value = staff.Name});
                list.Add(new SqlParameter() { ParameterName = "Sex", SqlDbType = SqlDbType.SmallInt, Value = staff.Sex.Equals("man")? 1 : 0});
                list.Add(new SqlParameter() { ParameterName = "Department", SqlDbType = SqlDbType.VarChar, Value = staff.Department });
                list.Add(new SqlParameter() { ParameterName = "Salary", SqlDbType = SqlDbType.Int, Value = staff.Salary });
                list.Add(new SqlParameter() { ParameterName = "retirement", SqlDbType = SqlDbType.SmallInt, Value = staff.IsRetired == true? 0 : 1});
                list.Add(new SqlParameter() { ParameterName = "id", SqlDbType = SqlDbType.Int, Value = staff.StaffId });

                // 添加参数
                queryCmd.Parameters.AddRange(list.ToArray());

                //执行SQL命令
                result = queryCmd.ExecuteNonQuery();

                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="staff">被删除的对象</param>
        /// <returns>删除是否成功</returns>
        public bool Delete(Staff staff)
        {
            bool result = false;
            // 创建连接对象
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;

            string sql = "delete from staff where StaffId = @id";

            using (conn)
            {
                conn.Open();

                SqlCommand queryCmd = new SqlCommand(sql, conn);

                // 获取并添加参数
                SqlParameter parameter = new SqlParameter() { ParameterName = "id", SqlDbType = SqlDbType.Int, Value = staff.StaffId };
                queryCmd.Parameters.Add(parameter);

                // 执行语句
                if (queryCmd.ExecuteNonQuery() != 0)
                {
                    result = true;
                }

                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// 新建操作
        /// </summary>
        /// <param name="staff">新建对象</param>
        /// <returns>是否成功创建</returns>
        public bool Create(Staff staff)
        {
            bool result = true;
            // 创建连接对象
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;

            string sql = "insert into staff values(@id,@Name,@Sex,@Department,@Salary,@retirement)";

            using (conn)
            {
                conn.Open();

                SqlCommand queryCmd = new SqlCommand(sql, conn);

                // 创建参数列表
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter() { ParameterName = "id", SqlDbType = SqlDbType.Int, Value = staff.StaffId });
                list.Add(new SqlParameter() { ParameterName = "Name", SqlDbType = SqlDbType.NVarChar, Value = staff.Name });
                list.Add(new SqlParameter() { ParameterName = "Sex", SqlDbType = SqlDbType.SmallInt, Value = staff.Sex.Equals("man") ? 1 : 0 });
                list.Add(new SqlParameter() { ParameterName = "Department", SqlDbType = SqlDbType.VarChar, Value = staff.Department });
                list.Add(new SqlParameter() { ParameterName = "Salary", SqlDbType = SqlDbType.Int, Value = staff.Salary });
                list.Add(new SqlParameter() { ParameterName = "retirement", SqlDbType = SqlDbType.SmallInt, Value = staff.IsRetired == true ? 0 : 1 });

                // 添加参数
                queryCmd.Parameters.AddRange(list.ToArray());

                //执行SQL命令
                try
                {
                    queryCmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }


        //public SqlDataAdapter GetAdapter()
        //{
        //    SqlDataAdapter result = new SqlDataAdapter("select * from staff",connectionString);
        //    result.DeleteCommand;
        //}
    }
}
