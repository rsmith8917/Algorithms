using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0} = 1100", IntToBinary(12));
            Console.WriteLine("{0} = 1100010", IntToBinary(98));
            Console.WriteLine("{0} = 0", IntToBinary(0));
            Console.ReadLine();
        }

        static string IntToBinary(int num)
        {
            if (num > 0)
            {
                int place = (int)Math.Pow(2, Math.Ceiling(Math.Log(num, 2)));

                StringBuilder result = new StringBuilder();

                bool firstOneSeen = false;

                while (place > 0)
                {
                    if (num >= place)
                    {
                        result.Append("1");
                        num = num - place;
                        firstOneSeen = true;
                    }
                    else
                    {
                        if (firstOneSeen)
                        {
                            result.Append("0");
                        }
                    }

                    place = (place > 1) ? place / 2 : 0;

                }

                return result.ToString();
            }
            else
            {
                return "0";
            }

        }
    }
}
