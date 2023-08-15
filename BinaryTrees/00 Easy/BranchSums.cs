using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._00_Easy
{
    public static class BranchSumsprogram
    {
        public static void Main()
        {

        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }

        public static List<int> BranchSums(BinaryTree root)
        {
            // Write your code here.
            List<int> sums = new List<int>();
            calculateBranchSums(root, 0, sums);
            return sums;
        }
        public static void calculateBranchSums(
            BinaryTree node, int runningSum, List<int> sums
        )
        {
            if (node == null) return;
            int newRunningSum = runningSum + node.value;
            if (node.left == null && node.right == null)
            {
                sums.Add(newRunningSum);
                return;
            }
            calculateBranchSums(node.left, newRunningSum, sums);
            calculateBranchSums(node.right, newRunningSum, sums);
        }

    }
}

/*
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  public class TestBinaryTree : Program.BinaryTree {
    public TestBinaryTree(int value) : base(value) {}

    public TestBinaryTree Insert(List<int> values) {
      return Insert(values, 0);
    }

    public TestBinaryTree Insert(List<int> values, int i) {
      if (i >= values.Count) return null;

      List<TestBinaryTree> queue = new List<TestBinaryTree>();
      queue.Add(this);
      while (queue.Count > 0) {
        TestBinaryTree current = queue[0];
        queue.RemoveAt(0);
        if (current.left == null) {
          current.left = new TestBinaryTree(values[i]);
          break;
        }
        queue.Add((TestBinaryTree)current.left);
        if (current.right == null) {
          current.right = new TestBinaryTree(values[i]);
          break;
        }
        queue.Add((TestBinaryTree)current.right);
      }
      Insert(values, i + 1);
      return this;
    }
  }

  [Test]
  public void TestCase1() {
    TestBinaryTree tree = new TestBinaryTree(1).Insert(new List<int>(
    ) { 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    List<int> expected = new List<int>() { 15, 16, 18, 10, 11 };
    Utils.AssertTrue(Program.BranchSums(tree).SequenceEqual(expected));
  }
}


 9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
[15, 16, 18, 10, 11]
Your Code's Output
[15, 16, 18, 10, 11]
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "5", "left": "10", "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
[1]
Your Code's Output
[1]
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
[3]
Your Code's Output
[3]
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
[3, 4]
Your Code's Output
[3, 4]
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
[7, 8, 4]
Your Code's Output
[7, 8, 4]
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
[15, 16, 18, 9, 11, 11, 11]
Your Code's Output
[15, 16, 18, 9, 11, 11, 11]
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "5", "left": "10", "right": "1-2", "value": 5},
      {"id": "6", "left": "1-3", "right": "1-4", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "1-2", "left": null, "right": null, "value": 1},
      {"id": "1-3", "left": null, "right": null, "value": 1},
      {"id": "1-4", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
[111]
Your Code's Output
[111]
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "0", "left": "1", "right": null, "value": 0},
      {"id": "1", "left": "10", "right": null, "value": 1},
      {"id": "10", "left": "100", "right": null, "value": 10},
      {"id": "100", "left": null, "right": null, "value": 100}
    ],
    "root": "0"
  }
}
Test Case 8 passed!
Expected Output
[111]
Your Code's Output
[111]
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "0", "left": null, "right": "1", "value": 0},
      {"id": "1", "left": null, "right": "10", "value": 1},
      {"id": "10", "left": null, "right": "100", "value": 10},
      {"id": "100", "left": null, "right": null, "value": 100}
    ],
    "root": "0"
  }
}
Test Case 9 passed!
Expected Output
[9, 16, 111, 211]
Your Code's Output
[9, 16, 111, 211]
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "0", "left": "9", "right": "1", "value": 0},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "1", "left": "15", "right": "10", "value": 1},
      {"id": "15", "left": null, "right": null, "value": 15},
      {"id": "10", "left": "100", "right": "200", "value": 10},
      {"id": "100", "left": null, "right": null, "value": 100},
      {"id": "200", "left": null, "right": null, "value": 200}
    ],
    "root": "0"
  }
}
 
 */