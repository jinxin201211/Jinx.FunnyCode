using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinx.J007.给string加个判断空字符串的扩展方法
{

    public static class StringExtension
    {
        public static bool IsBlank(this string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
