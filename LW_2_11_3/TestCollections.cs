using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11_3
{
    internal class TestCollections
    {
        private List<Organization> _collection1 = new();
        private List<string> _collection2 = new();

        private SortedDictionary<Organization, Library> _collection3 = new();
        private SortedDictionary<string, Library> _collection4 = new();

        public List<Organization> Collection1 { get { return _collection1; } }
        public List<string> Collection2 { get { return _collection2; } }

        public SortedDictionary<Organization, Library> Collection3 { get { return _collection3; } }
        public SortedDictionary<string, Library> Collection4 { get { return _collection4; } }

        public int Length { get { return _collection1.Count; } }

        public TestCollections(int size, ref Random rn)
        {
            //for (int i = 0; i < size; i++)
            while (this.Length < size)
            {
                Add(new Library(ref rn));
            }
        }

        public void Add(Library value)
        {
            if (!_collection3.Keys.Contains(value.BaseOrganisation()))
            {
                _collection1.Add(value.BaseOrganisation());
                _collection2.Add(value.BaseOrganisation().ToString());

                _collection3.Add(value.BaseOrganisation(), value);
                _collection4.Add(value.BaseOrganisation().ToString(), value);
            }
        }

        public void Remove(Organization key)
        {
            int ind = _collection1.IndexOf(key);
            if (ind != -1)
            {
                _collection1.RemoveAt(ind);
                _collection2.RemoveAt(ind);

                _collection3.Remove(key);
                _collection4.Remove(key.ToString());
            }
        }

        public void Remove(string key)
        {
            int ind = _collection2.IndexOf(key);
            if (ind != -1)
            {
                Organization org = _collection1[ind];

                _collection1.RemoveAt(ind);
                _collection2.RemoveAt(ind);

                _collection3.Remove(org);
                _collection4.Remove(key.ToString());
            }
        }

        public string Print()
        {
            string res = "";
            for (int i = 0; i < this.Length; i++)
            {
                res += this[i].Print() + '\n';
            }
            return res;
        }

        public Organization GetKeyByIndex(int index)
        {
            return _collection1[index];
        }

        public string GetStringKeyByIndex(int index)
        {
            return _collection2[index];
        }

        public Library this[Organization key]
        {
            get
            {
                if (_collection3.ContainsKey(key))
                {
                    return _collection3[key];
                }
                else
                {
                    return null;
                }
            }
        }

        public Library this[string key]
        {
            get
            {
                if (_collection4.ContainsKey(key))
                {
                    return _collection4[key];
                }
                else
                {
                    return null;
                }
            }
        }

        public Library this[int index]
        {
            get
            {
                if (_collection3.ContainsKey(_collection1[index]))
                {
                    return _collection3.GetValueOrDefault(_collection1[index]);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
