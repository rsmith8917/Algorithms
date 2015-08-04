using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairsThatAddToTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10] { 1, 2, 5, 7, 0, 3, 6, 12, 10, 9 };

            int target = 4;

            int num1 = 0;
            int num2 = 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var n in array)
            {
                try
                {
                    dict.Add(n, n);
                }
                catch (Exception)
                {
                }

            }

            foreach (var n in array)
            {
                try
                {
                    num1 = dict[target - n];
                    num2 = n;
                }
                catch (Exception)
                {
                }

            }

            Console.WriteLine("{0} and {1} add up to {2}", num1, num2, target);
            Console.ReadLine();
        }
    }
}
