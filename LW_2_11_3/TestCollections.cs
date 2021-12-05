using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_11_3
{
    internal class TestCollections
    {
        private List<Organization> _collection1;
        private List<string> _collection2;

        private SortedDictionary<Organization, Library> _collection3;
        private SortedDictionary<string, Library> _collection4;

        public List<Organization> Collection1 { get { return _collection1; } }
        public List<string> Collection2 { get { return _collection2; } }

        public SortedDictionary<Organization, Library> Collection3 { get { return _collection3; } }
        public SortedDictionary<string, Library> Collection4 { get { return _collection4; } }

        public int Length { get { return _collection1.Count; } }

        public TestCollections(int size, ref Random rn)
        {
            for (int i = 0; i < size; i++)
            {
                Add(new Organization(ref rn), new Library(ref rn));
            }
        }

        public void Add(Organization key, Library value)
        {
            _collection1.Add(key);
            _collection2.Add(key.ToString());

            _collection3.Add(key, value);
            _collection4.Add(key.ToString(), value);
        }

        // REMOVE

        public Organization GetKeyByIndex(int index)
        {
            return _collection1[index];
        }

        public string GetStringKeyByIndex(int index)
        {
            return _collection2[index];
        }

        public Library GetValueByKey(Organization key)
        {
            return _collection3[key];
        }

        public Library GetValueByStringKey(string key)
        {
            return _collection4[key];
        }
    }
}
