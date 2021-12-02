using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11
{
    class ShipConstructingCompany : Organization, IComparable, IComparer, ICloneable, IExecutable
    {
        public int ShipConstructed { get; set; }

        public ShipConstructingCompany(string name, string locationCity) : base(name, locationCity)
        {
            ShipConstructed = 0;
        }

        public ShipConstructingCompany(ref Random rn) : base(ref rn)
        {
            ShipConstructed = rn.Next(0, 1000);
        }

        public override string Print()
        {
            string res = base.Print();
            res += $"Number of constructed ships: {ShipConstructed}\n";
            return res;
        }

        public new int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var org = obj as ShipConstructingCompany;
            if (org == null || org != null && this == org)
                return 0;
            else
                return this.ShipConstructed.CompareTo(org.ShipConstructed);
        }

        public new int Compare(object x, object y)
        {
            if (x == y) return 0;

            if (x is ShipConstructingCompany o1 && y is ShipConstructingCompany o2)
                return o1.CompareTo(o2);
            else
                return 0;
        }

        public new object Clone()
        {
            var res = (ShipConstructingCompany)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }
    }
}
