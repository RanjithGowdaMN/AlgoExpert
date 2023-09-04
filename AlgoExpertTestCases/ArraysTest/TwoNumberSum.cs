using Arrays._01_Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpertTestCases.ArraysTest
{
    [TestClass]
    public class TwoNumberSum
    {
        [TestMethod]
        public void TestCase1()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10), new int[] { 11, -1 });
        }
        [TestMethod]
        public void TestCase2()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 4, 6 }, 10), new int[] { 4, 6 });
        }
        [TestMethod]
        public void TestCase3()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 4, 6, 1 }, 5), new int[] { 4, 1 });
        }
        [TestMethod]
        public void TestCase4()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 4, 6, 1, -3 }, 3), new int[] { 6, -3 });
        }
        [TestMethod]
        public void TestCase5()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 17), new int[] { 8, 9 });
        }
        [TestMethod]
        public void TestCase6()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 15 }, 18), new int[] { 3, 15 });
        }
        [TestMethod]
        public void TestCase7()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { -7, -5, -3, -1, 0, 1, 3, 5, 7 }, -5), new int[] { -5, 0 });
        }
        [TestMethod]
        public void TestCase8()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { -21, 301, 12, 4, 65, 56, 210, 356, 9, -47 }, 163), new int[] { 210, -47 });
        }
        [TestMethod]
        public void TestCase9()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { -21, 301, 12, 4, 65, 56, 210, 356, 9, -47 }, 164), new int[] { });
        }
        [TestMethod]
        public void TestCase10()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 15), new int[] { });
        }
        [TestMethod]
        public void TestCase11()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 14 }, 15), new int[] { });
        }
        [TestMethod]
        public void TestCase12()
        {
            CollectionAssert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 15 }, 15), new int[] { });
        }

    }
}
