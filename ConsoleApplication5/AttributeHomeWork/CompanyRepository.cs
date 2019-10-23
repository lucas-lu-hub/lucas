using AttributeHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeHomeWork
{
    public class CompanyRepository
    {
        public Company Get(int Id)
        {

            Company result = new Company();
            string connectionString = "";
            SqlConnection connect = new SqlConnection(connectionString);
            string sql = "select [Id], [Name] ,[Corporation],[CEO],[CreateTime],[CreatorId],[LastModifierId],[LastModifyTime] from Company where Id=@Id";
            using (connect)
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.Parameters.AddWithValue("Id", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.Id = int.Parse(reader["Id"].ToString());
                    result.Name = reader["Name"].ToString();
                    result.Corporation = reader["Corporation"].ToString();
                    result.CEO = reader["CEO"].ToString();
                    result.CreateTime = DateTime.Parse(reader["CreateTime"].ToString());
                    result.CreatorId = int.Parse(reader["CreatorId"].ToString());
                    result.LastModifierId = int.Parse(reader["LastModifierId"].ToString());
                    result.LastModifyTime = DateTime.Parse(reader["LastModifyTime"].ToString());
                }
            }
            
            return result;
        }
        public List<Company> GetAll()
        {
            List<Company> result = new List<Company>();
            string connectionString = "";
            SqlConnection connect = new SqlConnection(connectionString);
            string sql = "select [Id], [Name] ,[Corporation],[CEO],[CreateTime],[CreatorId],[LastModifierId],[LastModifyTime] from Company";
            using (connect)
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Company()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Corporation = reader["Corporation"].ToString(),
                        CEO = reader["CEO"].ToString(),
                        CreateTime = DateTime.Parse(reader["CreateTime"].ToString()),
                        CreatorId = int.Parse(reader["CreatorId"].ToString()),
                        LastModifierId = int.Parse(reader["LastModifierId"].ToString()),
                        LastModifyTime = DateTime.Parse(reader["LastModifyTime"].ToString())
                    });
                }
                cmd.Dispose();
                connect.Close();
            }
            return result;
        }
    }
}
