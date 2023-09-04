using Arrays._03_Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoExpertTestCases.ArraysTest
{
    [TestClass]
    public class SubArraySortTest
    {
        [TestMethod]
        public void TestCase1()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 }), new int[] { 3, 9 });
        }
        [TestMethod]
        public void TestCase2()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2 }), new int[] { -1, -1 });
        }
        [TestMethod]
        public void TestCase3()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 2, 1 }), new int[] { 0, 1 });
        }
        [TestMethod]
        public void TestCase4()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 7, 7, 16, 18, 19 }), new int[] { 4, 9 });
        }
        [TestMethod]
        public void TestCase5()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 13, 14, 16, 18, 19 }), new int[] { 4, 6 });
        }
        [TestMethod]
        public void TestCase6()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 8, 4, 5 }), new int[] { 2, 4 });
        }
        [TestMethod]
        public void TestCase7()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 4, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 51, 7 }), new int[] { 0, 12 });
        }
        [TestMethod]
        public void TestCase8()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 4, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 11, 57 }), new int[] { 0, 11 });
        }
        [TestMethod]
        public void TestCase9()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { -41, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 11, 57 }), new int[] { 1, 11 });
        }
        [TestMethod]
        public void TestCase10()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { -41, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 51, 7 }), new int[] { 1, 12 });
        }
        [TestMethod]
        public void TestCase11()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 3, 4, 5, 6, 8, 7, 9, 10, 11 }), new int[] { 6, 7 });
        }
        [TestMethod]
        public void TestCase12()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 3, 4, 5, 6, 18, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19 }), new int[] { 6, 16 });
        }
        [TestMethod]
        public void TestCase13()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 3, 4, 5, 6, 18, 21, 22, 7, 14, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19, 4, 14, 11, 6, 33, 35, 41, 55 }), new int[] { 4, 24 });
        }
        [TestMethod]
        public void TestCase14()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 20, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }), new int[] { 2, 19 });
        }
        [TestMethod]
        public void TestCase15()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 2 }), new int[] { 2, 19 });
        }
        [TestMethod]
        public void TestCase16()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }), new int[] { -1, -1 });
        }
        [TestMethod]
        public void TestCase17()
        {
            CollectionAssert.AreEqual(SubArraySortProgram.SubArraySort(new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 }), new int[] { -1, -1 });
        }
    }
}