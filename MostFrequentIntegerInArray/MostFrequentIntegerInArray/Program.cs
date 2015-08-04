using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentIntegerInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20] { 1, 2, 2, 3, 3, 4, 2, 2, 5, 6, 6, 10, 3, 5, 3, 1, 3, 8, 7, 6 };

            Dictionary<int, int> counts = new Dictionary<int, int>();

            int max = 0;
            int mostFreqNum = 0;

            foreach (var num in array)
            {
                try
                {
                    counts.Add(num, 1);
                    if (1 > max)
                    {
                        mostFreqNum = num;
                        max = 1;
                    }
                }
                catch (Exception)
                {
                    counts[num] += 1;

                    if (counts[num] > max)
                    {
                        mostFreqNum = num;
                        max = counts[num];
                    }
                }
            }

            Console.WriteLine("The most frequent number is {0}", mostFreqNum);
            Console.WriteLine("It occurs {0} times", max);

            Console.ReadLine();

        }
    }
}
