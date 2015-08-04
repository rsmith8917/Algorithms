using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ParseInt("9834") + " = 9834");
            Console.WriteLine(ParseInt("000") + " = 0");
            Console.WriteLine(ParseInt("013") + " = 13");
            Console.WriteLine(ParseInt("-1234") + " = -1234");
            Console.WriteLine(ParseInt("") + " = 0");
            Console.ReadLine();

        }

        static int ParseInt(string str)
        {
            int result = 0;
            int multiplier = 1;
            int i = 0;

            try
            {
                if (str[0] == '-')
                {
                    multiplier = -1;
                    i = 1;
                }
            }
            catch (Exception)
            {
            }

            for (; i < str.Length; i++)
            {
                result = (result * 10) + (str[i] - '0');
            }

            return result*multiplier;
        }
    }
}
