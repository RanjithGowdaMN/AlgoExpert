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
            int[] test = new int[] { 3, 9 };
            List<int> test1 = new List<int>() {3,9 };
            int[] test2 = new int[2];

            test2 = SubArraySort.SortSubArray(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 });

            
            Assert.AreEqual(test2, test, "Some Error in the output!!!");


        }
    }
}