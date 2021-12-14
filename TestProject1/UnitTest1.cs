using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LW_2_11_3;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static Random rn = new();

        [TestMethod]
        public void TestConstructor()
        {
            TestCollections t = new(5, ref rn);
            int actual = t.Length;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemove()
        {
            TestCollections t = new(5, ref rn);
            t.Remove(t[0].BaseOrganisation().ToString());
            int actual = t.Length;
            int expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPrint()
        {
            TestCollections t = new(1, ref rn);
            string actual = t[0].Print() + "\n";
            string expected = t.Print();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetKeyByIndex()
        {
            TestCollections t = new(1, ref rn);
            Organization actual = t.Collection1[0];
            Organization expected = t.GetKeyByIndex(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetStringKeyByIndex()
        {
            TestCollections t = new(1, ref rn);
            string actual = t.Collection2[0];
            string expected = t.GetStringKeyByIndex(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCollections()
        {
            TestCollections t = new(1, ref rn);
            Library actual;
            t.Collection3.TryGetValue(t[0].BaseOrganisation(), out actual);
            Library expected;
            t.Collection4.TryGetValue(actual.BaseOrganisation().ToString(), out expected);

            Assert.AreEqual(expected, actual);
        }
    }
}