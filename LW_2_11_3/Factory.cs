using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11_3
{
    class Factory : Organization, IComparable, ICloneable, IExecutable
    {
        public string Production { get; set; }

        public Organization HeadOrganization { get; set; }

        public Factory(string name, string locationCity, string production, double avgSalary) : base(name, locationCity, avgSalary)
        {
            Production = production;
            HeadOrganization = null;
        }

        public Factory(ref Random rn) : base(ref rn)
        {
            string[] products = { "Phones", "Tables", "Chairs", "Lamps" };
            Production = products[rn.Next(0, products.Length)];
            HeadOrganization = null;
        }

        public override string Print()
        {
            string res = base.Print();
            res += $"Type of production: {Production}\n";
            if (HeadOrganization != null) res += $"Head organisation: {HeadOrganization.Name}\n";
            return res;
        }

        public new int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var org = obj as Factory;
            if (org == null || org != null && this == org)
                return 0;
            else
                return this.Name.CompareTo(org.Name);
        }

        /*
        public new int Compare(object x, object y)
        {
            if (x == y) return 0;

            if (x is Factory o1 && y is Factory o2)
                return o1.CompareTo(o2);
            else
                return 0;
        }
        */

        // copy == clone
        // shallow
        public new Factory Clone()
        {
            Factory res = (Factory)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }

        // deep
        public Factory DeepClone()
        {
            Factory res = (Factory)this.MemberwiseClone();
            res.Name += " clone";
            res.HeadOrganization = (Organization)HeadOrganization.Clone();
            return res;
        }
    }
}
