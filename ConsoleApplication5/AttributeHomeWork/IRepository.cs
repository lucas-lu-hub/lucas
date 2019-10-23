using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeHomeWork
{
    interface IRepository<T>
    {
        T Get(int Id);
        List<T> GetAll();
    }
}
