using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class AuthAttribute : Attribute
    {
        public AuthAttribute()
        {

        }
        public string Show()
        {
            return "I'm Lucas";
        }
    }
}
