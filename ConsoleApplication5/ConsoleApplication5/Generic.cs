using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericClass<T>
    {
        public T _T;
    }
    class Generic<T> : GenericClass<T>
    {

    }
}
