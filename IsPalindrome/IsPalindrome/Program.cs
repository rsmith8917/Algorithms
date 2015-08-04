using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome("racecar"));
            Console.ReadLine();
        }

        static bool IsPalindrome(string str)
        {
            if (str != "")
            {
                for (int i = 0; i < str.Length / 2; i++)
                {
                    if (str[i] != str[str.Length - i - 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
