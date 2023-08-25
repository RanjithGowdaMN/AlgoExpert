using Arrays._01_Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpertTestCases
{
    [TestClass]
    class TwoNumberSum
    {
        [TestMethod]
        public void TestCaseX()
        {
            Assert.AreEqual(CTwoNumberSum.TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10), new int[] { 11, -1 });
        }
    }
}
