using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonRepeatingInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NonRepeating(new string[10] { "123", "123", "234", "234", "315", "315", "315", "423", "412", "412" }));
            Console.ReadLine();
        }

        static T NonRepeating<T>(T[] items)
        {
            Dictionary<T, int> counts = new Dictionary<T, int>();

            foreach (var item in items)
            {
                try
                {
                    counts.Add(item, 1);
                }
                catch (Exception)
                {
                    counts[item] += 1;
                }
            }

            T returnVal = default(T);

            foreach (var item in items)
            {
                if (counts[item] < 2)
                {
                    returnVal = item;
                    break;
                }
            }

            return returnVal;
        }
    }
}
