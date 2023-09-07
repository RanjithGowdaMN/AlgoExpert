using BinarySearchTrees._00_Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpertTestCases.BinarySearchTreesTest
{
    [TestClass]
    public class FindClosestValueInBSTtest
    {
        [TestMethod]
        public void TestCase1()
        {
            var root = new FindClosestValueInBSTProgram.BST(10);
            root.left = new FindClosestValueInBSTProgram.BST(5);
            root.left.left = new FindClosestValueInBSTProgram.BST(2);
            root.left.left.left = new FindClosestValueInBSTProgram.BST(1);
            root.left.right = new FindClosestValueInBSTProgram.BST(5);
            root.right = new FindClosestValueInBSTProgram.BST(15);
            root.right.left = new FindClosestValueInBSTProgram.BST(13);
            root.right.left.right = new FindClosestValueInBSTProgram.BST(14);
            root.right.right = new FindClosestValueInBSTProgram.BST(22);

            var expected = 13;
            var actual = FindClosestValueInBSTProgram.FindClosestValueInBst(root, 12);

            Assert.AreEqual(expected, actual);

        }
    }
    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
        }
    }
}
/*
 

 {
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": "13", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "13", "left": null, "right": "14", "value": 13},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "10"
  },
  "target": 12
}


 */