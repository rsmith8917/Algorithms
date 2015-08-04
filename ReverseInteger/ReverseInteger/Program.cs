using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The reverse of {0} is {1}", 1234567, ReverseInt(1234567));
            Console.ReadLine();
        }

        public static int ReverseInt (int num)
        {
            int multiplier = 1;
            int reversedNum = 0;
            int nextDigit = 0;

            if (num < 0)
                multiplier = -1;

            num *= multiplier;

            while (num > 0)
            {
                nextDigit = num % 10;  //Extract last digit (1234 -> 4)
                num = (num - nextDigit) / 10;  //Remove last digit from num (1234 -> 123)
                reversedNum = reversedNum * 10 + nextDigit; //Add digit to reversedNum (123 -> 1234)
            }

            return reversedNum*multiplier;
        }
    }
}
