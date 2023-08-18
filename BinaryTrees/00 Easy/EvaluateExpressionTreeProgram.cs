using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._00_Easy
{
    class EvaluateExpressionTreeProgram
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

        public int EvaluateExpressionTree(BinaryTree tree)
        {
            // Write your code here.
            if (tree.value >= 0)
            {
                return tree.value;
            }
            int leftValue = EvaluateExpressionTree(tree.left);
            int rightValue = EvaluateExpressionTree(tree.right);
            if (tree.value == -1)
            {
                return leftValue + rightValue;
            }
            else if (tree.value == -2)
            {
                return leftValue - rightValue;
            }
            else if (tree.value == -3)
            {
                return leftValue / rightValue;
            }
            return leftValue * rightValue;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree tree = new Program.BinaryTree(-1);
    tree.left = new Program.BinaryTree(2);
    tree.right = new Program.BinaryTree(-2);
    tree.right.left = new Program.BinaryTree(5);
    tree.right.right = new Program.BinaryTree(1);
    var expected = 6;
    var actual = new Program().EvaluateExpressionTree(tree);
    Utils.AssertTrue(expected == actual);
  }
}

 17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -2},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "3", "right": "2", "value": -2},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
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
      {"id": "1", "left": "2", "right": "3", "value": -3},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
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
  "tree": {
    "nodes": [
      {"id": "1", "left": "3", "right": "2", "value": -3},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -4},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": "4", "right": "5", "value": -2},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
-5
Your Code's Output
-5
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "10", "right": "3", "value": -3},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "3", "left": "4", "right": "6", "value": -2},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
-4
Your Code's Output
-4
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "3", "value": -3},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "3", "left": "4", "right": "6", "value": -2},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 10 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "9", "right": "3", "value": -3},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "3", "left": "6", "right": "4", "value": -2},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 11 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -2},
      {"id": "2", "left": "4", "right": "5", "value": -1},
      {"id": "3", "left": "6", "right": "7", "value": -3},
      {"id": "4", "left": null, "right": null, "value": 7},
      {"id": "5", "left": null, "right": null, "value": 10},
      {"id": "6", "left": null, "right": null, "value": 12},
      {"id": "7", "left": "8", "right": "9", "value": -4},
      {"id": "8", "left": null, "right": null, "value": 1},
      {"id": "9", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 12 passed!
Expected Output
21
Your Code's Output
21
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -1},
      {"id": "2", "left": "4", "right": "5", "value": -2},
      {"id": "3", "left": "6", "right": "7", "value": -4},
      {"id": "4", "left": null, "right": null, "value": 7},
      {"id": "5", "left": null, "right": null, "value": 10},
      {"id": "6", "left": null, "right": null, "value": 12},
      {"id": "7", "left": "8", "right": "9", "value": -3},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 13 passed!
Expected Output
41
Your Code's Output
41
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -1},
      {"id": "2", "left": "4", "right": "5", "value": -1},
      {"id": "3", "left": "6", "right": "7", "value": -1},
      {"id": "4", "left": null, "right": null, "value": 7},
      {"id": "5", "left": null, "right": null, "value": 10},
      {"id": "6", "left": null, "right": null, "value": 12},
      {"id": "7", "left": "8", "right": "9", "value": -1},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 14 passed!
Expected Output
-11
Your Code's Output
-11
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -2},
      {"id": "2", "left": "4", "right": "5", "value": -2},
      {"id": "3", "left": "6", "right": "7", "value": -2},
      {"id": "4", "left": null, "right": null, "value": 7},
      {"id": "5", "left": null, "right": null, "value": 10},
      {"id": "6", "left": null, "right": null, "value": 12},
      {"id": "7", "left": "8", "right": "9", "value": -2},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 15 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -3},
      {"id": "2", "left": "4", "right": "5", "value": -3},
      {"id": "3", "left": "6", "right": "7", "value": -3},
      {"id": "4", "left": null, "right": null, "value": 100},
      {"id": "5", "left": null, "right": null, "value": 10},
      {"id": "6", "left": null, "right": null, "value": 4},
      {"id": "7", "left": "8", "right": "9", "value": -3},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 16 passed!
Expected Output
224
Your Code's Output
224
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": -4},
      {"id": "2", "left": "4", "right": "5", "value": -4},
      {"id": "3", "left": "6", "right": "7", "value": -4},
      {"id": "4", "left": null, "right": null, "value": 2},
      {"id": "5", "left": null, "right": null, "value": 1},
      {"id": "6", "left": null, "right": null, "value": 7},
      {"id": "7", "left": "8", "right": "9", "value": -4},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 17 passed!
Expected Output
96
Your Code's Output
96
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "9", "value": -4},
      {"id": "2", "left": "4", "right": "3", "value": -1},
      {"id": "3", "left": null, "right": null, "value": 8},
      {"id": "4", "left": "5", "right": "6", "value": -1},
      {"id": "5", "left": null, "right": null, "value": 7},
      {"id": "6", "left": "7", "right": "8", "value": -2},
      {"id": "7", "left": null, "right": null, "value": 22},
      {"id": "8", "left": null, "right": null, "value": 5},
      {"id": "9", "left": "10", "right": "11", "value": -3},
      {"id": "10", "left": null, "right": null, "value": 100},
      {"id": "11", "left": "12", "right": "13", "value": -2},
      {"id": "12", "left": null, "right": null, "value": 42},
      {"id": "13", "left": "14", "right": "15", "value": -3},
      {"id": "14", "left": "16", "right": "17", "value": -4},
      {"id": "15", "left": null, "right": null, "value": 2},
      {"id": "16", "left": null, "right": null, "value": 3},
      {"id": "17", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
 */