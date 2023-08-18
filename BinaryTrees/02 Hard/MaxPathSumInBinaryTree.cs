using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._02_Hard
{
    internal class MaxPathSumInBinaryTree
    {
        public static int MaxPathSum(BinaryTree tree)
        {
            // Write your code here.
            List<int> maxSumArray = findMaxSum(tree);
            return maxSumArray[1];
        }
        public static List<int> findMaxSum(BinaryTree tree)
        {
            if (tree == null)
            {
                return new List<int>() { 0, Int32.MinValue };
            }
            List<int> leftMaxSumArray = findMaxSum(tree.left);
            int leftMaxSumAsBranch = leftMaxSumArray[0];
            int leftMaxPathSum = leftMaxSumArray[1];

            List<int> rightMaxSumArray = findMaxSum(tree.right);
            int rightMaxSumAsBranch = rightMaxSumArray[0];
            int rightMaxPathSum = rightMaxSumArray[1];

            int maxChildSumAsBranch = Math.Max(leftMaxSumAsBranch, rightMaxSumAsBranch);
            int maxSumAsBranch = Math.Max(maxChildSumAsBranch + tree.value, tree.value);
            int maxSumAsRootNode = Math.Max(
                leftMaxSumAsBranch + tree.value + rightMaxSumAsBranch, maxSumAsBranch
            );
            int maxPathSum = Math.Max(
                leftMaxPathSum, Math.Max(rightMaxPathSum, maxSumAsRootNode)
            );
            return new List<int>() { maxSumAsBranch, maxPathSum };
        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
    }
}

/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    TestBinaryTree test = new TestBinaryTree(1);
    test.insert(new int[] { 2, 3, 4, 5, 6, 7 }, 0);
    Utils.AssertTrue(Program.MaxPathSum(test) == 18);
  }

  public class TestBinaryTree : Program.BinaryTree {
    public TestBinaryTree(int value) : base(value) {}

    public void insert(int[] values, int i) {
      if (i >= values.Length) {
        return;
      }
      List<Program.BinaryTree> queue = new List<Program.BinaryTree>();
      queue.Add(this);
      var index = 0;
      while (index < queue.Count) {
        Program.BinaryTree current = queue[index];
        index += 1;
        if (current.left == null) {
          current.left = new Program.BinaryTree(values[i]);
          break;
        }
        queue.Add(current.left);
        if (current.right == null) {
          current.right = new Program.BinaryTree(values[i]);
          break;
        }
        queue.Add(current.right);
      }
      insert(values, i + 1);
    }
  }
}


16 / 16 test cases passed.

Test Case 1 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
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
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "-1", "value": 1},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-5", "right": "3", "value": 1},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "-5", "left": "6", "right": null, "value": -5},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 5 passed!
Expected Output
154
Your Code's Output
154
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-10", "right": "-5", "value": 1},
      {"id": "-5", "left": "-20", "right": "-21", "value": -5},
      {"id": "-21", "left": "100-2", "right": "1-3", "value": -21},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "100-2", "left": null, "right": null, "value": 100},
      {"id": "-20", "left": "100", "right": "2", "value": -20},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "100", "left": null, "right": null, "value": 100},
      {"id": "-10", "left": "30", "right": "45", "value": -10},
      {"id": "45", "left": "3", "right": "-3", "value": 45},
      {"id": "-3", "left": null, "right": null, "value": -3},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "30", "left": "5", "right": "1-2", "value": 30},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
201
Your Code's Output
201
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-10", "right": "-5", "value": 1},
      {"id": "-5", "left": "-20", "right": "-21", "value": -5},
      {"id": "-21", "left": "100-3", "right": "1-3", "value": -21},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "100-3", "left": null, "right": null, "value": 100},
      {"id": "-20", "left": "100-2", "right": "2", "value": -20},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "100-2", "left": null, "right": null, "value": 100},
      {"id": "-10", "left": "30", "right": "45", "value": -10},
      {"id": "45", "left": "3", "right": "-3", "value": 45},
      {"id": "-3", "left": null, "right": null, "value": -3},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "30", "left": "5", "right": "1-2", "value": 30},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "5", "left": "100", "right": null, "value": 5},
      {"id": "100", "left": null, "right": null, "value": 100}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
203
Your Code's Output
203
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-10", "right": "-5", "value": 1},
      {"id": "-5", "left": "-20", "right": "-21", "value": -5},
      {"id": "-21", "left": "100-3", "right": "1-3", "value": -21},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "100-3", "left": null, "right": null, "value": 100},
      {"id": "-20", "left": "100-2", "right": "2", "value": -20},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "100-2", "left": null, "right": null, "value": 100},
      {"id": "-10", "left": "30", "right": "75", "value": -10},
      {"id": "75", "left": "3", "right": "-3", "value": 75},
      {"id": "-3", "left": null, "right": null, "value": -3},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "30", "left": "5", "right": "1-2", "value": 30},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "5", "left": "100", "right": null, "value": 5},
      {"id": "100", "left": null, "right": null, "value": 100}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
228
Your Code's Output
228
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-150", "right": "-5", "value": 1},
      {"id": "-5", "left": "-20", "right": "-21", "value": -5},
      {"id": "-21", "left": "100-4", "right": "1-3", "value": -21},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "100-4", "left": null, "right": null, "value": 100},
      {"id": "-20", "left": "100-3", "right": "2", "value": -20},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "100-3", "left": null, "right": null, "value": 100},
      {"id": "-150", "left": "30", "right": "75", "value": -150},
      {"id": "75", "left": "3", "right": "-3", "value": 75},
      {"id": "-3", "left": null, "right": null, "value": -3},
      {"id": "3", "left": "150", "right": "-8", "value": 3},
      {"id": "-8", "left": null, "right": null, "value": -8},
      {"id": "150", "left": null, "right": null, "value": 150},
      {"id": "30", "left": "5", "right": "1-2", "value": 30},
      {"id": "1-2", "left": "5-2", "right": "10", "value": 1},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "5", "left": "100", "right": "100-2", "value": 5},
      {"id": "100-2", "left": null, "right": null, "value": 100},
      {"id": "100", "left": null, "right": null, "value": 100}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
304
Your Code's Output
304
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-150", "right": "-5", "value": 1},
      {"id": "-5", "left": "-20", "right": "-21", "value": -5},
      {"id": "-21", "left": "100-4", "right": "1-3", "value": -21},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "100-4", "left": null, "right": null, "value": 100},
      {"id": "-20", "left": "100-3", "right": "2", "value": -20},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "100-3", "left": null, "right": null, "value": 100},
      {"id": "-150", "left": "30", "right": "75", "value": -150},
      {"id": "75", "left": "3", "right": "-3", "value": 75},
      {"id": "-3", "left": null, "right": null, "value": -3},
      {"id": "3", "left": "150", "right": "151", "value": 3},
      {"id": "151", "left": null, "right": null, "value": 151},
      {"id": "150", "left": null, "right": null, "value": 150},
      {"id": "30", "left": "5", "right": "1-2", "value": 30},
      {"id": "1-2", "left": "5-2", "right": "10", "value": 1},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "5", "left": "100", "right": "100-2", "value": 5},
      {"id": "100-2", "left": null, "right": null, "value": 100},
      {"id": "100", "left": null, "right": null, "value": 100}
    ],
    "root": "1"
  }
}
Test Case 10 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-5", "right": "-3-2", "value": 1},
      {"id": "-3-2", "left": "2-2", "right": "1-7", "value": -3},
      {"id": "1-7", "left": "1-8", "right": "1-10", "value": 1},
      {"id": "1-10", "left": "-5-2", "right": "0-5", "value": 1},
      {"id": "0-5", "left": null, "right": null, "value": 0},
      {"id": "-5-2", "left": null, "right": null, "value": -5},
      {"id": "1-8", "left": "0-4", "right": "1-9", "value": 1},
      {"id": "1-9", "left": null, "right": null, "value": 1},
      {"id": "0-4", "left": null, "right": null, "value": 0},
      {"id": "2-2", "left": "0-3", "right": "5", "value": 2},
      {"id": "5", "left": "2-3", "right": "1-6", "value": 5},
      {"id": "1-6", "left": null, "right": null, "value": 1},
      {"id": "2-3", "left": null, "right": null, "value": 2},
      {"id": "0-3", "left": "-9", "right": "-91", "value": 0},
      {"id": "-91", "left": null, "right": null, "value": -91},
      {"id": "-9", "left": null, "right": null, "value": -9},
      {"id": "-5", "left": "0", "right": "2", "value": -5},
      {"id": "2", "left": "1-4", "right": "1-5", "value": 2},
      {"id": "1-5", "left": "-1-3", "right": "-100", "value": 1},
      {"id": "-100", "left": null, "right": null, "value": -100},
      {"id": "-1-3", "left": null, "right": null, "value": -1},
      {"id": "1-4", "left": "-1-2", "right": "-6", "value": 1},
      {"id": "-6", "left": null, "right": null, "value": -6},
      {"id": "-1-2", "left": null, "right": null, "value": -1},
      {"id": "0", "left": "-3", "right": "3", "value": 0},
      {"id": "3", "left": "1-3", "right": "-1", "value": 3},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "-3", "left": "0-2", "right": "1-2", "value": -3},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "0-2", "left": null, "right": null, "value": 0}
    ],
    "root": "1"
  }
}
Test Case 11 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-5", "right": "-3-2", "value": 1},
      {"id": "-3-2", "left": "2-2", "right": "1-6", "value": -3},
      {"id": "1-6", "left": "1-7", "right": "1-9", "value": 1},
      {"id": "1-9", "left": "-5-2", "right": "0-5", "value": 1},
      {"id": "0-5", "left": null, "right": null, "value": 0},
      {"id": "-5-2", "left": null, "right": null, "value": -5},
      {"id": "1-7", "left": "0-4", "right": "1-8", "value": 1},
      {"id": "1-8", "left": null, "right": null, "value": 1},
      {"id": "0-4", "left": null, "right": null, "value": 0},
      {"id": "2-2", "left": "0-3", "right": "5", "value": 2},
      {"id": "5", "left": "2-3", "right": "1-5", "value": 5},
      {"id": "1-5", "left": null, "right": null, "value": 1},
      {"id": "2-3", "left": null, "right": null, "value": 2},
      {"id": "0-3", "left": "-9", "right": "-91", "value": 0},
      {"id": "-91", "left": null, "right": null, "value": -91},
      {"id": "-9", "left": null, "right": null, "value": -9},
      {"id": "-5", "left": "0", "right": "2", "value": -5},
      {"id": "2", "left": "1-3", "right": "1-4", "value": 2},
      {"id": "1-4", "left": "-1-3", "right": "-100", "value": 1},
      {"id": "-100", "left": null, "right": null, "value": -100},
      {"id": "-1-3", "left": null, "right": null, "value": -1},
      {"id": "1-3", "left": "-1-2", "right": "-6", "value": 1},
      {"id": "-6", "left": null, "right": null, "value": -6},
      {"id": "-1-2", "left": null, "right": null, "value": -1},
      {"id": "0", "left": "-3", "right": "-4", "value": 0},
      {"id": "-4", "left": "10", "right": "-1", "value": -4},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "-3", "left": "0-2", "right": "1-2", "value": -3},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "0-2", "left": null, "right": null, "value": 0}
    ],
    "root": "1"
  }
}
Test Case 12 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-5", "right": "-3-2", "value": 1},
      {"id": "-3-2", "left": "2-4", "right": "1-7", "value": -3},
      {"id": "1-7", "left": "1-8", "right": "1-10", "value": 1},
      {"id": "1-10", "left": "-5-3", "right": "0-5", "value": 1},
      {"id": "0-5", "left": null, "right": null, "value": 0},
      {"id": "-5-3", "left": null, "right": null, "value": -5},
      {"id": "1-8", "left": "0-4", "right": "1-9", "value": 1},
      {"id": "1-9", "left": null, "right": null, "value": 1},
      {"id": "0-4", "left": null, "right": null, "value": 0},
      {"id": "2-4", "left": "0-3", "right": "5", "value": 2},
      {"id": "5", "left": "2-5", "right": "1-6", "value": 5},
      {"id": "1-6", "left": null, "right": null, "value": 1},
      {"id": "2-5", "left": null, "right": null, "value": 2},
      {"id": "0-3", "left": "-9", "right": "-91", "value": 0},
      {"id": "-91", "left": null, "right": null, "value": -91},
      {"id": "-9", "left": null, "right": null, "value": -9},
      {"id": "-5", "left": "0", "right": "2-3", "value": -5},
      {"id": "2-3", "left": "1-4", "right": "1-5", "value": 2},
      {"id": "1-5", "left": "-1-3", "right": "-100", "value": 1},
      {"id": "-100", "left": null, "right": null, "value": -100},
      {"id": "-1-3", "left": null, "right": null, "value": -1},
      {"id": "1-4", "left": "-1-2", "right": "-6", "value": 1},
      {"id": "-6", "left": null, "right": null, "value": -6},
      {"id": "-1-2", "left": null, "right": null, "value": -1},
      {"id": "0", "left": "-3", "right": "-4", "value": 0},
      {"id": "-4", "left": "3-2", "right": "-1", "value": -4},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "3-2", "left": "7", "right": "-5-2", "value": 3},
      {"id": "-5-2", "left": null, "right": null, "value": -5},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "-3", "left": "0-2", "right": "1-3", "value": -3},
      {"id": "1-3", "left": "2", "right": "2-2", "value": 1},
      {"id": "2-2", "left": null, "right": null, "value": 2},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "0-2", "left": "3", "right": "1-2", "value": 0},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 13 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "-5", "right": "-3-2", "value": 1},
      {"id": "-3-2", "left": "2-2", "right": "1-7", "value": -3},
      {"id": "1-7", "left": "1-8", "right": "1-10", "value": 1},
      {"id": "1-10", "left": "5-2", "right": "0-5", "value": 1},
      {"id": "0-5", "left": null, "right": null, "value": 0},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "1-8", "left": "0-4", "right": "1-9", "value": 1},
      {"id": "1-9", "left": null, "right": null, "value": 1},
      {"id": "0-4", "left": null, "right": null, "value": 0},
      {"id": "2-2", "left": "0-3", "right": "5", "value": 2},
      {"id": "5", "left": "2-3", "right": "1-6", "value": 5},
      {"id": "1-6", "left": null, "right": null, "value": 1},
      {"id": "2-3", "left": null, "right": null, "value": 2},
      {"id": "0-3", "left": "-9", "right": "-91", "value": 0},
      {"id": "-91", "left": null, "right": null, "value": -91},
      {"id": "-9", "left": null, "right": null, "value": -9},
      {"id": "-5", "left": "0", "right": "2", "value": -5},
      {"id": "2", "left": "1-4", "right": "1-5", "value": 2},
      {"id": "1-5", "left": "-1-3", "right": "-100", "value": 1},
      {"id": "-100", "left": null, "right": null, "value": -100},
      {"id": "-1-3", "left": null, "right": null, "value": -1},
      {"id": "1-4", "left": "-1-2", "right": "-6", "value": 1},
      {"id": "-6", "left": null, "right": null, "value": -6},
      {"id": "-1-2", "left": null, "right": null, "value": -1},
      {"id": "0", "left": "-3", "right": "3", "value": 0},
      {"id": "3", "left": "1-3", "right": "-1", "value": 3},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "-3", "left": "0-2", "right": "1-2", "value": -3},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "0-2", "left": null, "right": null, "value": 0}
    ],
    "root": "1"
  }
}
Test Case 14 passed!
Expected Output
-2
Your Code's Output
-2
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "-2", "left": null, "right": null, "value": -2}
    ],
    "root": "-2"
  }
}
Test Case 15 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "-2", "left": "-1", "right": null, "value": -2},
      {"id": "-1", "left": null, "right": null, "value": -1}
    ],
    "root": "-2"
  }
}
Test Case 16 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "-2", "left": "-1", "right": null, "value": -2},
      {"id": "-1", "left": "2", "right": "3", "value": -1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "-2"
  }
}
 
 */
