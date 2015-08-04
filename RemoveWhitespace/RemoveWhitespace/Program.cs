using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveWhitespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "   Hello      World!    ";
            Console.WriteLine("->" + str + "<-");
            Console.WriteLine("->" + RemoveSpaces(str.ToCharArray()) + "<-");
            Console.WriteLine("");

            str = "Hello      World!";
            Console.WriteLine("->" + str + "<-");
            Console.WriteLine("->" + RemoveSpaces(str.ToCharArray()) + "<-");
            Console.WriteLine("");

            str = "Hello World!";
            Console.WriteLine("->" + str + "<-");
            Console.WriteLine("->" + RemoveSpaces(str.ToCharArray()) + "<-");
            Console.WriteLine("");

            str = "Hello";
            Console.WriteLine("->" + str + "<-");
            Console.WriteLine("->" + RemoveSpaces(str.ToCharArray()) + "<-");
            Console.WriteLine("");

            str = "    ";
            Console.WriteLine("->" + str + "<-");
            Console.WriteLine("->" + RemoveSpaces(str.ToCharArray()) + "<-");
            Console.WriteLine("");

            str = "";
            Console.WriteLine("->" + str + "<-");
            Console.WriteLine("->" + RemoveSpaces(str.ToCharArray()) + "<-");
            Console.WriteLine("");

            Console.ReadLine();
        }

        static public string RemoveSpaces(char[] str)
        {
            if (str != new char[0])
            {
                int i = 0;
                int k = 0;
                bool seenChar = false;

                foreach (char c in str)
                {
                    if (c != ' ')
                    {
                        str[i] = c;
                        i += 1;
                        seenChar = true;
                    }
                    else if (k + 1 < str.Length && str[k + 1] != ' ' && seenChar)
                    {
                        str[i] = c;
                        i += 1;
                    }

                    k += 1;
                }

                return new string(str, 0, i);
            }
            else
            {
                return "";
            }

        }
    }
}
