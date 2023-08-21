using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._01_Medium
{
    class FindKthLargestValueInBstProgram
    {
        public class BST
        {
            public int value;
            public BST left = null;
            public BST right = null;

            public BST(int value)
            {
                this.value = value;
            }
        }

        public class TreeInfo
        {
            public int numberOfNodesVisited;
            public int latestVisitedNodeValue;
            //O(h+k) O(h)
            public TreeInfo(int numberOfNodesVisited, int latestVisitedNodeValue)
            {
                this.numberOfNodesVisited = numberOfNodesVisited;
                this.latestVisitedNodeValue = latestVisitedNodeValue;
            }
        }
        public int FindKthLargestValueInBst(BST tree, int k)
        {
            TreeInfo treeInfo = new TreeInfo(0, -1);
            reverseInOrderTraverse(tree, k, treeInfo);
            return treeInfo.latestVisitedNodeValue;
        }

        public void reverseInOrderTraverse(BST node, int k, TreeInfo treeInfo)
        {
            if (node == null || treeInfo.numberOfNodesVisited >= k) return;
            reverseInOrderTraverse(node.right, k, treeInfo);
            if (treeInfo.numberOfNodesVisited < k)
            {
                treeInfo.numberOfNodesVisited += 1;
                treeInfo.latestVisitedNodeValue = node.value;
                reverseInOrderTraverse(node.left, k, treeInfo);
            }
        }
    }
}
/*
   public class BST {
    public int value;
    public BST left = null;
    public BST right = null;

    public BST(int value) {
      this.value = value;
    }
  }

  public int FindKthLargestValueInBst(BST tree, int k) {
    // O(n) time || O(n) space
      List<int> sortedNodeValues = new List<int>();
      inOrderTraverse(tree, sortedNodeValues);
      return sortedNodeValues[sortedNodeValues.Count-k];
  }
    public void inOrderTraverse(BST node, List<int> sortedNodeValues){
        if(node==null) return;
        inOrderTraverse(node.left, sortedNodeValues);
        sortedNodeValues.Add(node.value);
        inOrderTraverse(node.right, sortedNodeValues);
    }
 ---------------------------------------------------------------------------------------------------
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BST root = new Program.BST(15);
    root.left = new Program.BST(5);
    root.left.left = new Program.BST(2);
    root.left.left.left = new Program.BST(1);
    root.left.left.right = new Program.BST(3);
    root.left.right = new Program.BST(5);
    root.right = new Program.BST(20);
    root.right.left = new Program.BST(17);
    root.right.right = new Program.BST(22);
    int k = 3;
    int expected = 17;
    var actual = new Program().FindKthLargestValueInBst(root, k);
    Utils.AssertTrue(expected == actual);
  }
}

11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
17
Your Code's Output
17
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "tree": {
    "nodes": [
      {"id": "15", "left": "5", "right": "20", "value": 15},
      {"id": "20", "left": "17", "right": "22", "value": 20},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "17", "left": null, "right": null, "value": 17},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "15"
  }
}
Test Case 2 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "tree": {
    "nodes": [
      {"id": "5", "left": "4", "right": "6", "value": 5},
      {"id": "4", "left": "3", "right": null, "value": 4},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "5"
  }
}
Test Case 3 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "tree": {
    "nodes": [
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "5"
  }
}
Test Case 4 passed!
Expected Output
22
Your Code's Output
22
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "tree": {
    "nodes": [
      {"id": "20", "left": "15", "right": "25", "value": 20},
      {"id": "15", "left": "10", "right": "19", "value": 15},
      {"id": "25", "left": "21", "right": "30", "value": 25},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "19", "left": null, "right": null, "value": 19},
      {"id": "21", "left": null, "right": "22", "value": 21},
      {"id": "30", "left": null, "right": null, "value": 30},
      {"id": "22", "left": null, "right": null, "value": 22}
    ],
    "root": "20"
  }
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "tree": {
    "nodes": [
      {"id": "10", "left": "8", "right": null, "value": 10},
      {"id": "8", "left": "6", "right": null, "value": 8},
      {"id": "6", "left": "4", "right": null, "value": 6},
      {"id": "4", "left": "2", "right": null, "value": 4},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "10"
  }
}
Test Case 7 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "tree": {
    "nodes": [
      {"id": "10", "left": "8", "right": null, "value": 10},
      {"id": "8", "left": "6", "right": "9", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "6", "left": "4", "right": "7", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "4", "left": "2", "right": "5", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "10"
  }
}
Test Case 8 passed!
Expected Output
99727
Your Code's Output
99727
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "tree": {
    "nodes": [
      {"id": "99727", "left": "99", "right": null, "value": 99727},
      {"id": "99", "left": null, "right": "727", "value": 99},
      {"id": "727", "left": null, "right": null, "value": 727}
    ],
    "root": "99727"
  }
}
Test Case 9 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "k": 7,
  "tree": {
    "nodes": [
      {"id": "15", "left": "5", "right": "20", "value": 15},
      {"id": "20", "left": "17", "right": "22", "value": 20},
      {"id": "22", "left": null, "right": "24", "value": 22},
      {"id": "24", "left": "23", "right": "25", "value": 24},
      {"id": "23", "left": null, "right": null, "value": 23},
      {"id": "25", "left": null, "right": null, "value": 25},
      {"id": "17", "left": null, "right": null, "value": 17},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "15"
  }
}
Test Case 10 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "tree": {
    "nodes": [
      {"id": "15", "left": "5", "right": "20", "value": 15},
      {"id": "20", "left": "17", "right": "22", "value": 20},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "17", "left": null, "right": null, "value": 17},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "15"
  }
}
Test Case 11 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "k": 6,
  "tree": {
    "nodes": [
      {"id": "15", "left": "5", "right": "20", "value": 15},
      {"id": "20", "left": "17", "right": "22", "value": 20},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "17", "left": null, "right": null, "value": 17},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "15"
  }
}


 */