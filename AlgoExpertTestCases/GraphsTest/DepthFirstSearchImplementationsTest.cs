using Graphs._00_Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpertTestCases.GraphsTest
{
    [TestClass]
    public class DepthFirstSearchImplementationsTest
    {
        [TestMethod]
        public void TestCase1()
        {
            DepthFirstSearchImplementations.Node graph = new DepthFirstSearchImplementations.Node("A");
            graph.AddChild("B").AddChild("C").AddChild("D");
            graph.children[0].AddChild("E").AddChild("F");
            graph.children[2].AddChild("G").AddChild("H");
            graph.children[0].children[1].AddChild("I").AddChild("J");
            graph.children[2].children[0].AddChild("K");
            string[] expected = {
                "A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"
                };
            List<string> inputArray = new List<string>();

            Assert.IsTrue(compare(graph.DepthFirstSearchImplementation(inputArray), expected));
        }

        public static bool compare(List<string> arr1, string[] arr2)
        {
            if (arr1.Count != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Count; i++)
            {
                if (!arr1[i].Equals(arr2[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
