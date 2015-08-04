using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            int[] ar = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int unsorted = ar[ar.Length - 1];

            int i = ar.Length - 2;
            for (int i = 0; i < length; i++)
            {

            }
            while (ar[i] > unsorted)
            {
                
                ShiftArray(ar, i);
                PrintArray(ar);
                i -= 1;

            }
            ar[i+1] = unsorted;
            PrintArray(ar);

            Console.ReadLine();
        }

        static void ShiftArray(int[] array, int index)
        {
            array[index + 1] = array[index];
        }

        static void PrintArray(int[] array)
        {
            string str = "";

            foreach (var num in array)
            {
                str += num + " ";
            }

            Console.WriteLine(str.Substring(0, str.Length - 1));
        }
    }
}
