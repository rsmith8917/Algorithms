using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchOnArrayOfInts
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = new int[11] { 1, 2, 4, 5, 7, 8, 10, 11, 12, 14, 15 };

            int index = Find(5, nums);

            Console.WriteLine("Index of 5: {0}", Find(5, nums));
            Console.WriteLine("Index of 0: {0}", Find(0, nums));
            Console.WriteLine("Index of 12: {0}", Find(12, nums));
            Console.WriteLine("Index of 1: {0}", Find(1, nums));
            Console.WriteLine("Index of 13: {0}", Find(13, nums));
            Console.WriteLine("Index of 100: {0}", Find(100, nums));
            Console.WriteLine("Index of 8: {0}", Find(8, nums));
            Console.WriteLine("Index of -8: {0}", Find(-8, nums));
            Console.WriteLine("Index of 7: {0}", Find(7, nums));
            Console.WriteLine("Index of 6: {0}", Find(6, nums));
            Console.WriteLine("Index of 800: {0}", Find(800, nums));
            Console.WriteLine("Index of -87: {0}", Find(-87, nums));
            Console.ReadLine();
        }

        static int Find(int n, int[] nums)
        {
            int midIndex = nums.Length / 2;
            int midNum = nums[midIndex];
            int indexDelta = midIndex / 2;
            bool notFound = false;

            while (midNum != n || notFound)
            {
                try
                {
                    if (midNum < n)
                    {
                        midIndex += indexDelta;
                        midNum = nums[midIndex];
                    }
                    else
                    {
                        midIndex -= indexDelta;
                        midNum = nums[midIndex];
                    }

                    indexDelta -= Math.Max(indexDelta / 2, 1);

                    if (midNum != n && indexDelta == 0)
                    {
                        notFound = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    notFound = true;
                    break;
                }
            }

            if (notFound)
            {
                return -1;
            }
            else
            {
                return midIndex;
            }

        }
    }
}
