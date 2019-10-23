using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            UserStatus us = UserStatus.Normal;
            Console.WriteLine(us.GetRemark());
            Console.ReadLine();
        }

        [Auth]
        public void PrintString(string str)
        {
            Console.WriteLine(str);
        }
    }
}
