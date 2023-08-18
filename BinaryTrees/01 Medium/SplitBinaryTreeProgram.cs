using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    class SplitBinaryTreeProgram
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }

        public int SplitBinaryTree(BinaryTree tree)
        {
            // Write your code here.
            int treeSum = getTreeSum(tree);
            if (treeSum % 2 != 0)
            {
                return 0;
            }

            int desiredSubtreeSum = treeSum / 2;
            bool canBeSplit = trySubTrees(tree, desiredSubtreeSum).canBeSplit;
            return canBeSplit == true ? desiredSubtreeSum : 0; ;
        }
        public class ResultPair
        {
            public int currentTreeSum;
            public bool canBeSplit;

            public ResultPair(int currentTreeSum, bool canBeSplit)
            {
                this.currentTreeSum = currentTreeSum;
                this.canBeSplit = canBeSplit;
            }
        }
        ResultPair trySubTrees(BinaryTree tree, int desiredSubtreeSum)
        {
            if (tree == null)
            {
                return new ResultPair(0, false);
            }
            ResultPair leftResultPair = trySubTrees(tree.left, desiredSubtreeSum);
            ResultPair rightResultPair = trySubTrees(tree.right, desiredSubtreeSum);

            int currentTreeSum = tree.value + leftResultPair.currentTreeSum +
                                rightResultPair.currentTreeSum;
            bool canBeSplit = leftResultPair.canBeSplit || rightResultPair.canBeSplit ||
                            currentTreeSum == desiredSubtreeSum;
            return new ResultPair(currentTreeSum, canBeSplit);
        }
        int getTreeSum(BinaryTree tree)
        {
            if (tree == null)
            {
                return 0;
            }
            return tree.value + getTreeSum(tree.left) + getTreeSum(tree.right);
        }
    }
}

/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree tree = new Program.BinaryTree(2);
    tree.left = new Program.BinaryTree(4);
    tree.left.left = new Program.BinaryTree(4);
    tree.left.right = new Program.BinaryTree(6);
    tree.right = new Program.BinaryTree(10);
    tree.right.left = new Program.BinaryTree(3);
    tree.right.right = new Program.BinaryTree(3);
    int expected = 16;
    int actual = new Program().SplitBinaryTree(tree);
    Utils.AssertTrue(expected == actual);
  }
}

 30 / 30 test cases passed.

Test Case 1 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 0}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
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
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": -2}
    ],
    "root": "1"
  }
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 2},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
3
Your Code's Output
3
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
Test Case 8 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "4", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 1},
      {"id": "4", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 10 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 1},
      {"id": "4", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 11 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 6},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 12 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "5", "right": null, "value": 6},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 10},
      {"id": "5", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 13 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "5", "right": null, "value": 6},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 8},
      {"id": "5", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 14 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "5", "right": null, "value": 6},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 15 passed!
Expected Output
11
Your Code's Output
11
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": null, "right": "7", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "7", "left": null, "right": null, "value": 7}
    ],
    "root": "1"
  }
}
Test Case 16 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "2", "value": 1},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "2", "left": "15", "right": "10", "value": 2},
      {"id": "15", "left": null, "right": null, "value": 15},
      {"id": "10", "left": "100", "right": "200", "value": 10},
      {"id": "100", "left": null, "right": null, "value": 100},
      {"id": "200", "left": null, "right": null, "value": 200}
    ],
    "root": "1"
  }
}
Test Case 17 passed!
Expected Output
60
Your Code's Output
60
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "20", "value": 1},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "20", "left": "30", "right": "10", "value": 20},
      {"id": "30", "left": null, "right": null, "value": 30},
      {"id": "10", "left": "35", "right": "15", "value": 10},
      {"id": "35", "left": null, "right": null, "value": 35},
      {"id": "15", "left": null, "right": null, "value": 15}
    ],
    "root": "1"
  }
}
Test Case 18 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "20", "value": 1},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "20", "left": "30", "right": "10", "value": 20},
      {"id": "30", "left": null, "right": null, "value": 30},
      {"id": "10", "left": "35", "right": "25", "value": 10},
      {"id": "35", "left": null, "right": null, "value": 35},
      {"id": "25", "left": null, "right": null, "value": 25}
    ],
    "root": "1"
  }
}
Test Case 19 passed!
Expected Output
70
Your Code's Output
70
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "20", "value": 1},
      {"id": "9", "left": "5", "right": "2", "value": 9},
      {"id": "20", "left": "30", "right": "10", "value": 20},
      {"id": "30", "left": null, "right": null, "value": 30},
      {"id": "10", "left": "35", "right": "25", "value": 10},
      {"id": "35", "left": null, "right": null, "value": 35},
      {"id": "25", "left": null, "right": null, "value": 25},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 20 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "20", "value": 1},
      {"id": "9", "left": "5", "right": "2", "value": 9},
      {"id": "20", "left": "30", "right": "10", "value": 20},
      {"id": "30", "left": null, "right": null, "value": 30},
      {"id": "10", "left": "35", "right": "25", "value": 10},
      {"id": "35", "left": "3", "right": null, "value": 35},
      {"id": "25", "left": null, "right": null, "value": 25},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 21 passed!
Expected Output
121
Your Code's Output
121
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "20", "value": 1},
      {"id": "9", "left": "5", "right": "2", "value": 9},
      {"id": "20", "left": "30", "right": "10", "value": 20},
      {"id": "30", "left": null, "right": null, "value": 30},
      {"id": "10", "left": "35", "right": "25", "value": 10},
      {"id": "35", "left": null, "right": null, "value": 35},
      {"id": "25", "left": null, "right": null, "value": 25},
      {"id": "5", "left": "102", "right": null, "value": 5},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "102", "left": null, "right": null, "value": 102}
    ],
    "root": "1"
  }
}
Test Case 22 passed!
Expected Output
121
Your Code's Output
121
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "20", "right": "9", "value": 1},
      {"id": "9", "left": "5", "right": "2", "value": 9},
      {"id": "20", "left": "30", "right": "10", "value": 20},
      {"id": "30", "left": null, "right": null, "value": 30},
      {"id": "10", "left": "35", "right": "25", "value": 10},
      {"id": "35", "left": null, "right": null, "value": 35},
      {"id": "25", "left": null, "right": null, "value": 25},
      {"id": "5", "left": "102", "right": null, "value": 5},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "102", "left": null, "right": null, "value": 102}
    ],
    "root": "1"
  }
}
Test Case 23 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": "6", "value": 5},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7}
    ],
    "root": "1"
  }
}
Test Case 24 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": "6", "value": 5},
      {"id": "6", "left": null, "right": "9", "value": 6},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
Test Case 25 passed!
Expected Output
-2
Your Code's Output
-2
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "-2", "left": null, "right": "-2-2", "value": -2},
      {"id": "-2-2", "left": null, "right": null, "value": -2}
    ],
    "root": "-2"
  }
}
Test Case 26 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "-2", "left": null, "right": "0", "value": -2},
      {"id": "0", "left": null, "right": null, "value": 0}
    ],
    "root": "-2"
  }
}
Test Case 27 passed!
Expected Output
-5
Your Code's Output
-5
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "3", "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "-5", "value": 2},
      {"id": "3", "left": "12", "right": null, "value": 1},
      {"id": "12", "left": null, "right": "-21", "value": 12},
      {"id": "-21", "left": null, "right": null, "value": -21},
      {"id": "-5", "left": null, "right": null, "value": -5}
    ],
    "root": "1"
  }
}
Test Case 28 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "-4", "value": 3},
      {"id": "-4", "left": null, "right": "5", "value": -4},
      {"id": "5", "left": null, "right": "6", "value": 5},
      {"id": "6", "left": null, "right": "9", "value": 6},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
Test Case 29 passed!
Expected Output
11
Your Code's Output
11
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "-4", "value": 3},
      {"id": "-4", "left": null, "right": "9", "value": -4},
      {"id": "9", "left": null, "right": "5", "value": 9},
      {"id": "5", "left": null, "right": "6", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 30 passed!
Expected Output
-7
Your Code's Output
-7
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-20", "right": "9", "value": 1},
      {"id": "9", "left": "-13", "right": "4", "value": 9},
      {"id": "-20", "left": "-30", "right": "17", "value": -20},
      {"id": "-30", "left": "8", "right": null, "value": -30},
      {"id": "17", "left": "-26", "right": "-17", "value": 17},
      {"id": "-26", "left": "19", "right": null, "value": -26},
      {"id": "-17", "left": null, "right": null, "value": -17},
      {"id": "-13", "left": "42", "right": null, "value": -13},
      {"id": "4", "left": "3", "right": "-11", "value": 4},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "42", "left": null, "right": null, "value": 42},
      {"id": "19", "left": null, "right": null, "value": 19},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "-11", "left": null, "right": null, "value": -11}
    ],
    "root": "1"
  }
}
 
 */