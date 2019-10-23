using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(List<>));//`1
            GenericClass<int> a = new GenericClass<int>()
            {
                _T = 123
            };
            GenericClass<string> b = new GenericClass<string>()
            {
                _T = "123"
            };
            CommonMethod.Show<int>(1);
            Console.ReadLine();
        }
    }
    class CommonMethod
    {
        /// <summary>
        /// 普通方法
        /// </summary>
        /// <param name="i"></param>
        public static void ShowInt(int i)
        {
            Console.WriteLine("");
        }
        /// <summary>
        /// .Net Framework1.0 1.1
        /// object是一个引用类型，当传入值类型时会有装箱拆箱操作，造成性能损失
        /// </summary>
        /// <param name="o"></param>
        public static void ShowObject(object o)
        {
            Console.WriteLine("This is {0}, parameter = {1}, type = {2}", typeof(CommonMethod).Name,
                o.GetType().Name, o);
        }
        
        /// <summary>
        /// 2.0推出新语法
        /// 用一个方法，满足不同参数类型，做相同的事
        /// 调用的时候才指定类型
        /// 延迟声明，把参数类型的声明推迟到调用的时候
        /// 推迟一切可以推迟的（延迟思想）（惰性加载、linq的延迟加载等）
        /// 
        /// 泛型不是语法糖， 2.0由框架升级提供的功能
        /// 需要编译期支持+JIT支持
        /// 性能约等于普通方法 》 object方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0}, parameterType = {1}, value ={2}", typeof(CommonMethod).Name, tParameter.GetType().Name, tParameter.ToString());
        }
    }
}
