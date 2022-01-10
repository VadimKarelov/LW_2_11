using System;
using System.Diagnostics;

namespace LW_2_11_3
{
    internal class Program
    {
        private static Random rn = new();

        static void Main(string[] args)
        {   
            // init collection to check
            TestCollections coll = new(10000, ref rn);
            Console.WriteLine(coll.Print());
            Console.WriteLine("Number of elements:" + coll.Length);

            Console.WriteLine("\n\nTIME OF SEARCH");

            Console.WriteLine("First element");
            Organization key = coll.Collection1[0];
            Console.WriteLine(GetTimeOfSearch(coll, key));

            Console.WriteLine("Middle element");
            key = coll.Collection1[coll.Length / 2];
            Console.WriteLine(GetTimeOfSearch(coll, key));

            Console.WriteLine("Last element");
            key = coll.Collection1[coll.Length - 1];
            Console.WriteLine(GetTimeOfSearch(coll, key));

            Console.WriteLine("No in collection element");
            key = new Organization("", "", 0);
            Console.WriteLine(GetTimeOfSearch(coll, key));
        }

        private static string GetTimeOfSearch(TestCollections coll, Organization key)
        {
            Stopwatch sw = new();
            string res = "";

            // collection 1
            sw.Start();
            coll.Collection1.Contains(key);
            sw.Stop();
            res += $"Time of search in collection 1 (ticks): {sw.ElapsedTicks}\n";

            // collection 2
            sw.Reset();
            sw.Start();
            coll.Collection2.Contains(key.ToString());
            sw.Stop();
            res += $"Time of search in collection 2 (ticks): {sw.ElapsedTicks}\n";

            // collection 3
            sw.Reset();
            sw.Start();
            coll.Collection3.ContainsKey(key);
            sw.Stop();
            res += $"Time of search in collection 3 (ticks): {sw.ElapsedTicks}\n";

            // collection 4
            sw.Reset();
            sw.Start();
            coll.Collection4.ContainsKey(key.ToString());
            sw.Stop();
            res += $"Time of search in collection 4 (ticks): {sw.ElapsedTicks}\n";

            return res;
        }
    }
}
