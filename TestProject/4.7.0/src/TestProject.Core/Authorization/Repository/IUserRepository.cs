using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Authorization.Users;

namespace TestProject.Authorization.Repository
{
    public interface IUserRepository
    {
        User GetUser(Guid UserId);
        List<User> GetAllUser();
        int AddUser(User user);
        int DeleteUser(Guid userId);
    }
}
