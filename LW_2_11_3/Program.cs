using System;

namespace LW_2_11_3
{
    internal class Program
    {
        private static Random rn = new();

        static void Main(string[] args)
        {            
            TestCollections coll = new(5, ref rn);
            Console.WriteLine(coll.Print());
        }
    }
}
