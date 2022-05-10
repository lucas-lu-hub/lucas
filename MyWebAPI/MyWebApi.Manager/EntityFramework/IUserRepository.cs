using MyWebApi.Manager.EntityFramework.DBContext;
using MyWebAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Manager.EntityFramework
{
    public interface IUserRepository : IRepository
    {
        User? GetUser(int id);
    }
}
