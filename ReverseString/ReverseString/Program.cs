using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! -> " + ReverseString("Hello World!"));
            Console.ReadLine();
        }

        static string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            char tmp;

            for (int i = 0; i < chars.Length/2; i++)
            {
                tmp = chars[i];
                chars[i] = chars[chars.Length - i - 1];
                chars[chars.Length - i - 1] = tmp;
            }

            return new string(chars);
        }
    }
}
