using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11
{
    class Organization : IComparable, IComparer, ICloneable, IExecutable
    {
        public string Name { get; set; }
        public string City { get; set; }

        public Organization(string name, string locationCity)
        {
            Name = name;
            City = locationCity;
        }

        public Organization(ref Random rn)
        {
            string[] names = { "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf", "Hotel" };
            string[] cities = { "Magadan", "Arhangelsk", "Sochi", "Moscow", "Omsk" };
            Name = names[rn.Next(0, names.Length)];
            City = cities[rn.Next(0, cities.Length)];
        }

        public virtual string Print()
        {
            string res = "";
            res += "Organisation name: " + Name + "\n";
            res += "Location city: " + City + "\n";
            return res;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var org = obj as Organization;
            if (org != null && this.City == org.City && this.Name == org.Name)
                return 0;
            else
                return this.Name.CompareTo(org.Name);
        }

        public int Compare(object x, object y)
        {
            if (x == y) return 0;

            if (x is Organization o1 && y is Organization o2)
                return o1.CompareTo(o2);
            else
                return 0;
        }

        public object Clone()
        {
            var res = (Organization)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }
    }
}
