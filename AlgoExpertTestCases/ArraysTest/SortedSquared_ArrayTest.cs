using Arrays._00Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpertTestCases.ArraysTest
{
    [TestClass]
    public class SortedSquared_ArrayTest
    {
        [TestMethod]
        public void TestCase1()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { 1, 2, 3, 5, 6, 8, 9 }), new int[] { 1, 4, 9, 25, 36, 64, 81 });
        }
        [TestMethod]
        public void TestCase2()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { 1 }), new int[] { 1 });
        }
        [TestMethod]
        public void TestCase3()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { 1, 2 }), new int[] { 1, 4 });
        }
        [TestMethod]
        public void TestCase4()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { 1, 2, 3, 4, 5 }), new int[] { 1, 4, 9, 16, 25 });
        }
        [TestMethod]
        public void TestCase5()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { 0 }), new int[] { 0 });
        }
        [TestMethod]
        public void TestCase6()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { 10 }), new int[] { 100 });
        }
        [TestMethod]
        public void TestCase7()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -1 }), new int[] { 1 });
        }
        [TestMethod]
        public void TestCase8()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -2, -1 }), new int[] { 1, 4 });
        }
        [TestMethod]
        public void TestCase9()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -5, -4, -3, -2, -1 }), new int[] { 1, 4, 9, 16, 25 });
        }
        [TestMethod]
        public void TestCase10()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -10 }), new int[] { 100 });
        }
        [TestMethod]
        public void TestCase11()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -10, -5, 0, 5, 10 }), new int[] { 0, 25, 25, 100, 100 });
        }
        [TestMethod]
        public void TestCase12()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -7, -3, 1, 9, 22, 30 }), new int[] { 1, 9, 49, 81, 484, 900 });
        }
        [TestMethod]
        public void TestCase13()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -50, -13, -2, -1, 0, 0, 1, 1, 2, 3, 19, 20 }), new int[] { 0, 0, 1, 1, 1, 4, 4, 9, 169, 361, 400, 2500 });
        }
        [TestMethod]
        public void TestCase14()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }), new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }
        [TestMethod]
        public void TestCase15()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -1, -1, 2, 3, 3, 3, 4 }), new int[] { 1, 1, 4, 9, 9, 9, 16 });
        }
        [TestMethod]
        public void TestCase16()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -3, -2, -1 }), new int[] { 1, 4, 9 });
        }
        [TestMethod]
        public void TestCase17()
        {
            CollectionAssert.AreEqual(SortedSquared_Array.SortedSquaredArray(new int[] { -3, -2, -1 }), new int[] { 1, 4, 9 });
        }


    }
}
