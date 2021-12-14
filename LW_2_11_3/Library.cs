﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11_3
{
    public class Library : Organization, IComparable, ICloneable, IExecutable
    {
        public int NumberOfBooks { get; set; }

        public Library(string name, string locationCity, int numOfBooks, double avgSalary) : base(name, locationCity, avgSalary)
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

        public override string ToString()
        {
            return $"{base.ToString()}:{NumberOfBooks}";
        }

        public new int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var org = obj as Library;
            int res = this.Name.CompareTo(org.Name);

            if (res == 0)
            {
                res = this.City.CompareTo(org.City);
            }
            if (res == 0)
            {
                //res = this.AverageSalary.CompareTo(org.AverageSalary);
            }
            if (res == 0)
            {
                res = this.NumberOfBooks.CompareTo(org.NumberOfBooks);
            }

            return res;
        }

        public new object Clone()
        {
            var res = (Library)this.MemberwiseClone();
            res.Name += " clone";
            return res;
        }

        public Organization BaseOrganisation()
        {
            return new Organization(Name, City, AverageSalary);
        }
    }
}
