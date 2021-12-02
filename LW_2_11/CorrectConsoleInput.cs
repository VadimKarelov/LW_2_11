using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11
{
    static class CorrectConsoleInput
    {        
        static public int GetInt(int lowerBound, int upperBound)
        {
            if (lowerBound > upperBound)
                throw new Exception("Lower bound more than upper bound");

            string vvod;
            int res;
            do
            {
                Console.Write($"Введите целое число ({lowerBound}-{upperBound - 1}):");
                vvod = Console.ReadLine();
            } while (!int.TryParse(vvod, out res) || res < lowerBound || res > upperBound - 1);

            return res;
        }
    }
}
