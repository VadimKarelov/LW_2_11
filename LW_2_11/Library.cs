using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11
{
    class Library : Organization, IComparable, IComparer, ICloneable, IExecutable
    {
        public int NumberOfBooks { get; set; }

        public Library(string name, string locationCity, int numOfBooks) : base(name, locationCity)
        {
            NumberOfBooks = numOfBooks;
        }

        public Library(ref Random rn) : base(ref rn)
        {
            NumberOfBooks = rn.Next(0, 1000);
        }

        public override string Print()
        {
            string res = base.Print();
            res += $"Number of books: {NumberOfBooks}\n";
            return res;
        }

        public new int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var org = obj as Library;
            if (org == null || org != null && this == org)
                return 0;
            else
                return this.NumberOfBooks.CompareTo(org.NumberOfBooks);
        }

        public new int Compare(object x, object y)
        {
            if (x == y) return 0;

            if (x is Library o1 && y is Library o2)
                return o1.CompareTo(o2);
            else
                return 0;
        }

        public new object Clone()
        {
            var res = (Library)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }
    }
}
