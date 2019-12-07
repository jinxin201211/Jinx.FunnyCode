using Jinx.J007.给string加个判断空字符串的扩展方法;
using Jinx.J008.让List自定义排序规则;
using System;

namespace Jinx.FunnyCode.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "";
            string str2 = "     ";
            string str3 = "1313";
            Console.WriteLine(str1 + ":" + str1.IsBlank());
            Console.WriteLine(str2 + ":" + str2.IsBlank());
            Console.WriteLine(str3 + ":" + str3.IsBlank());
            Class1.MySort();
        }
    }
}
