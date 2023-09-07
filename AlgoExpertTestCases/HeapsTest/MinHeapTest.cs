using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heaps._01_Medium;
using static Heaps._01_Medium.MinHeapProgram;

namespace AlgoExpertTestCases.HeapsTest
{
    [TestClass]
    public class MinHeapTest
    {
        [TestMethod]
        public void TestCase1()
        {
            MinHeap minHeap = new MinHeap(new List<int>(
            ) { 48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41 });
            minHeap.Insert(76);
            Assert.IsTrue(isMinHeapPropertySatisfied(minHeap.heap));
            Assert.IsTrue(minHeap.Peek() == -5);
            Assert.IsTrue(minHeap.Remove() == -5);
            Assert.IsTrue(isMinHeapPropertySatisfied(minHeap.heap));
            Assert.IsTrue(minHeap.Peek() == 2);
            Assert.IsTrue(minHeap.Remove() == 2);
            Assert.IsTrue(isMinHeapPropertySatisfied(minHeap.heap));
            Assert.IsTrue(minHeap.Peek() == 6);
            minHeap.Insert(87);
            Assert.IsTrue(isMinHeapPropertySatisfied(minHeap.heap));
        }

        bool isMinHeapPropertySatisfied(List<int> array)
        {
            for (int currentIdx = 1; currentIdx < array.Count; currentIdx++)
            {
                int parentIdx = (currentIdx - 1) / 2;
                if (parentIdx < 0)
                {
                    return true;
                }
                if (array[parentIdx] > array[currentIdx])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
