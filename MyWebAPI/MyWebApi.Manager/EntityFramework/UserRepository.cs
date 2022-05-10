using MyWebApi.Manager.EntityFramework.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Manager.EntityFramework
{
    internal class UserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public User? GetUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id == id);
        }
    }
}
