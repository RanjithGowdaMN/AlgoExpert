using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._03_Very_Hard
{
    public class AllKindsOfNodeDepthsProgram
    {
        public static int AllKindsOfNodeDepths(BinaryTree root)
        {
            // Write your code here.
            return allKindsOfNodeDepthsHelper(root, 0);
        }

        public static int allKindsOfNodeDepthsHelper(BinaryTree root, int depth)
        {
            if (root == null) return 0;

            var depthSum = (depth * (depth + 1)) / 2;
            return depthSum + allKindsOfNodeDepthsHelper(root.left, depth + 1) +
                allKindsOfNodeDepthsHelper(root.right, depth + 1);
        }

        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }
    }
}
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    var root = new Program.BinaryTree(1);
    root.left = new Program.BinaryTree(2);
    root.left.left = new Program.BinaryTree(4);
    root.left.left.left = new Program.BinaryTree(8);
    root.left.left.right = new Program.BinaryTree(9);
    root.left.right = new Program.BinaryTree(5);
    root.right = new Program.BinaryTree(3);
    root.right.left = new Program.BinaryTree(6);
    root.right.right = new Program.BinaryTree(7);
    int actual = Program.AllKindsOfNodeDepths(root);
    Utils.AssertEquals(26, actual);
  }
}

9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
26
Our Code's Output
26
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 5 passed!
Expected Output
5
Our Code's Output
5
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
56
Our Code's Output
56
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": "4", "right": null, "value": 3},
      {"id": "4", "left": "5", "right": null, "value": 4},
      {"id": "5", "left": "6", "right": null, "value": 5},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
112
Our Code's Output
112
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "8", "value": 1},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": "4", "right": null, "value": 3},
      {"id": "4", "left": "5", "right": null, "value": 4},
      {"id": "5", "left": "6", "right": null, "value": 5},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": "9", "value": 8},
      {"id": "9", "left": null, "right": "10", "value": 9},
      {"id": "10", "left": null, "right": "11", "value": 10},
      {"id": "11", "left": null, "right": "12", "value": 11},
      {"id": "12", "left": "13", "right": null, "value": 12},
      {"id": "13", "left": null, "right": null, "value": 13}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
135
Our Code's Output
135
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": "10", "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": "11", "value": 10},
      {"id": "11", "left": "12", "right": "13", "value": 11},
      {"id": "12", "left": "14", "right": null, "value": 12},
      {"id": "13", "left": "15", "right": "16", "value": 13},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "15", "left": null, "right": null, "value": 15},
      {"id": "16", "left": null, "right": null, "value": 16}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
120
Our Code's Output
120
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": "4", "right": null, "value": 3},
      {"id": "4", "left": "5", "right": null, "value": 4},
      {"id": "5", "left": "6", "right": null, "value": 5},
      {"id": "6", "left": "7", "right": null, "value": 6},
      {"id": "7", "left": "8", "right": null, "value": 7},
      {"id": "8", "left": "9", "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
 
 */