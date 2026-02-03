using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCore
{
    public class InputFilter
    {
        public int FilterTyposToInt(string input)
        {
            input = input.Replace("&", "1");
            input = input.Replace("é", "2");
            input = input.Replace("\"", "3");
            input = input.Replace("\'", "4");
            input = input.Replace("(", "5");
            input = input.Replace("§", "6");
            input = input.Replace("è", "7");
            input = input.Replace("!", "8");
            input = input.Replace("ç", "9");
            input = input.Replace("à", "0");
            return Convert.ToInt32(input);
        }
    }
}
