using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Manager.EntityFramework.DBContext
{
    internal class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
