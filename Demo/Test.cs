using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
   public static class Test
    {

        public static string GetStr(this string a)
        {
            return a;
        }

        public static string GetDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
        
    }
}
