using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int m = int.Parse(Console.ReadLine());
            int[] B = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            Dictionary<int, int> ACounts = new Dictionary<int, int>();
            Dictionary<int, int> BCounts = new Dictionary<int, int>();
            Dictionary<int, int> Missing = new Dictionary<int, int>();

            int aCount = 0;

            foreach (int a in A)
            {
                
                if (ACounts.TryGetValue(a, out aCount))
                {
                    ACounts.Remove(a);
                    ACounts.Add(a, aCount + 1);
                }
                else
                {
                    ACounts.Add(a, 1);
                }
            }

            int bCount = 0;

            foreach (int b in B)
            {

                if (BCounts.TryGetValue(b, out bCount))
                {
                    BCounts.Remove(b);
                    BCounts.Add(b, bCount + 1);
                    aCount = CheckMissing(ACounts, Missing, bCount, b);
                }
                else
                {
                    BCounts.Add(b, 1);
                    aCount = CheckMissing(ACounts, Missing, bCount, b);
                }
            }

            int[] missingNums = Missing.Select(x => x.Value).ToArray();

            Array.Sort(missingNums);

            foreach (int num in missingNums)
            {
                Console.WriteLine(num);
            }

            Console.ReadLine();
        }

        private static int CheckMissing(Dictionary<int, int> ACounts, Dictionary<int, int> Missing, int bCount, int b)
        {
            int aCount;
            if (ACounts.TryGetValue(b, out aCount))
            {
                if (bCount + 1 > aCount)
                {
                    try
                    {
                        Missing.Add(b, b);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return aCount;
        }
    }
}
