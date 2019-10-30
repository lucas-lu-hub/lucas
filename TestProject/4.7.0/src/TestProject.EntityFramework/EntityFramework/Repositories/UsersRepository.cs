using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Authorization.Repository;
using TestProject.Authorization.Users;

namespace TestProject.EntityFramework.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private DbContext Context = new TestAbpEntities();

        public User GetUser(Guid UserId)
        {
            var user = new User();
            return user;
        }

        public List<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }


    }
}
