using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] B = new int[8] { 10, 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine(IsRotated(A, B));
            Console.ReadLine();

        }

        static bool IsRotated(int[] A, int[] B)
        {
            int aIndex = 0;
            bool found = false;


            foreach (int a in A)
            {
                if (a == B[0])
                {
                    found = true;
                    break;
                }

                aIndex += 1;
            }

            if (found)
            {
                bool isRotated = true;
                foreach (int b in B)
                {
                    if (A[aIndex] != b)
                        isRotated = false;

                    aIndex += 1;
                    if (aIndex >= A.Length)
                        aIndex = 0;
                }

                return isRotated;
            }
            else
            {
                return false;
            }
        } 
    }
}
