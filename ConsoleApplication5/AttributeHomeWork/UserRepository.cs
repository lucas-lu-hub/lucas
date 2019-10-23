using AttributeHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeHomeWork
{
    public class UserRepository
    {
        public User Get(int Id)
        {
            User result = new User();
            string connectionString = "" ;
            SqlConnection connect = new SqlConnection(connectionString);
            string sql = "SELECT TOP (1000) [Name],[Account],[Password],[Email],[Mobile],[CompanyId],[CompanyName],[State],[UserType],[LastLoginTime],[CreateTime],[CreatorId],[LastModifyTime],[Id] FROM[Attribute].[dbo].[Users] where Id=@Id";
            using (connect)
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.Parameters.AddWithValue("Id", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.Id = int.Parse( reader["Id"].ToString());  
                    result.Name = reader["Name"].ToString();
                    result.Account = reader["Account"].ToString();
                    result.Password = reader["Password"].ToString();
                    result.Email = reader["Email"].ToString();
                    result.Mobile = reader["Mobile"].ToString();
                    result.CompanyId = int.Parse(reader["CompanyId"].ToString());
                    result.CompanyName = reader["CompanyName"].ToString();
                    result.state = short.Parse(reader["State"].ToString());
                    result.UserType = short.Parse(reader["UserType"].ToString());
                    result.LastLoginTime = DateTime.Parse(reader["LastLoginTime"].ToString());
                    result.CreateTime = DateTime.Parse(reader["CreateTime"].ToString());
                    result.CreatorId = int.Parse(reader["CreatorId"].ToString());
                    result.LastModifyTime = DateTime.Parse(reader["LastModifyTime"].ToString());
                }
            }

            return result;
        }
        public List<User> GetAll()
        {
            List<User> result = new List<User>();
            string connectionString =  "";
            SqlConnection connect = new SqlConnection(connectionString);
            string sql = "SELECT TOP (1000) [Name],[Account],[Password],[Email],[Mobile],[CompanyId],[CompanyName],[State],[UserType],[LastLoginTime],[CreateTime],[CreatorId],[LastModifyTime],[Id] FROM[Attribute].[dbo].[Users]";
            using (connect)
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new User()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Account = reader["Account"].ToString(),
                        Password = reader["Password"].ToString(),
                        Email = reader["Email"].ToString(),
                        Mobile = reader["Mobile"].ToString(),
                        CompanyId = int.Parse(reader["CompanyId"].ToString()),
                        CompanyName = reader["CompanyName"].ToString(),
                        state = short.Parse(reader["State"].ToString()),
                        UserType = short.Parse(reader["UserType"].ToString()),
                        LastLoginTime = DateTime.Parse(reader["LastLoginTime"].ToString()),
                        CreateTime = DateTime.Parse(reader["CreateTime"].ToString()),
                        CreatorId = int.Parse(reader["CreatorId"].ToString()),
                        LastModifyTime = DateTime.Parse(reader["LastModifyTime"].ToString())
                    });
                }
            }
            return result;
        }
    }
}
