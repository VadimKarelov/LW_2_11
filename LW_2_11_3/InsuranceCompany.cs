using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11_3
{
    class InsuranceCompany : Organization, IComparable, ICloneable, IExecutable
    {
        public int NumberOfClients { get; set; }

        public InsuranceCompany(string name, string locationCity, int numOfClients) : base(name, locationCity)
        {
            NumberOfClients = numOfClients;
        }

        public InsuranceCompany(ref Random rn) : base(ref rn)
        {
            NumberOfClients = rn.Next(0, 100);
        }

        public override string Print()
        {
            string res = base.Print();
            res += $"Number of clients: {NumberOfClients}\n";
            return res;
        }

        public new int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var org = obj as InsuranceCompany;
            if (org == null || org != null && this == org)
                return 0;
            else
                return this.NumberOfClients.CompareTo(org.NumberOfClients);
        }

        /*
        public new int Compare(object x, object y)
        {
            if (x == y) return 0;

            if (x is InsuranceCompany o1 && y is InsuranceCompany o2)
                return o1.CompareTo(o2);
            else
                return 0;
        }
        */

        public new object Clone()
        {
            var res = (InsuranceCompany)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }
    }
}
