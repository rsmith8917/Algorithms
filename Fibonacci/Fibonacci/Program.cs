using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibRec(0));
            Console.WriteLine(fibIter(0));
            Console.WriteLine(fibRec(1));
            Console.WriteLine(fibIter(1));
            Console.WriteLine(fibRec(-12));
            Console.WriteLine(fibIter(-12));
            Console.WriteLine(fibRec(20));
            Console.WriteLine(fibIter(20));
            Console.ReadLine();
        }

        static int fibIter(int n)
        {
            int result = 0;

            if (n <= 0)
            {
                result = 0;
            }
            else if (n == 1)
            {
                result = 1;
            }
            else
            {
                int[] lastTwo = new int[2] { 1, 1 };

                for (int i = 0; i < n - 2; i++)
                {
                    result = lastTwo.Sum();
                    lastTwo[0] = lastTwo[1];
                    lastTwo[1] = result;
                }
            }

            return result;
        }

        static int fibRec(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return fibRec(n - 1) + fibRec(n - 2);
            }

        }
    }
}
