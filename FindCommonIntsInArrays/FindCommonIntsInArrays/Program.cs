using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCommonIntsInArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[10] { 1, 2, 5, 17, 0, 3, 6, 12, 10, 87 };
            int[] B = new int[10] { 3, 4, 7, 18, 23, 2, 5, 99, 1, 6 };

            List<int> common = new List<int>();

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var a in A)
            {
                try
                {
                    dict.Add(a, a);
                }
                catch (Exception)
                {
                }

            }

            foreach (var b in B)
            {
                try
                {
                    common.Add(dict[b]);
                }
                catch (Exception)
                {
                }

            }

            foreach (var num in common)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
}
