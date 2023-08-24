using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._01_Medium
{
    internal class HightBalancedBinaryTreeProgram
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
        public class TreeInfo
        {
            public bool isBalanced;
            public int height;

            public TreeInfo(bool isBalanced, int height)
            {
                this.isBalanced = isBalanced;
                this.height = height;
            }
        }

        public bool HeightBalancedBinaryTree(BinaryTree tree)
        {
            // Write your code here.
            TreeInfo treeInfo = getTreeInfo(tree);
            return treeInfo.isBalanced;
        }
        public TreeInfo getTreeInfo(BinaryTree node)
        {
            if (node == null)
            {
                return new TreeInfo(true, -1);
            }

            TreeInfo leftSubtreeInfo = getTreeInfo(node.left);
            TreeInfo rightSubtreeInfo = getTreeInfo(node.right);

            bool isBalanced =
                leftSubtreeInfo.isBalanced && rightSubtreeInfo.isBalanced &&
                Math.Abs(leftSubtreeInfo.height - rightSubtreeInfo.height) <= 1;
            int height = Math.Max(leftSubtreeInfo.height, rightSubtreeInfo.height) + 1;
            return new TreeInfo(isBalanced, height);

        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree root = new Program.BinaryTree(1);
    root = new Program.BinaryTree(1);
    root.left = new Program.BinaryTree(2);
    root.right = new Program.BinaryTree(3);
    root.left.left = new Program.BinaryTree(4);
    root.left.right = new Program.BinaryTree(5);
    root.right.right = new Program.BinaryTree(6);
    root.left.right.left = new Program.BinaryTree(7);
    root.left.right.right = new Program.BinaryTree(8);
    bool expected = true;
    var actual = new Program().HeightBalancedBinaryTree(root);
    Utils.AssertTrue(expected == actual);
  }
}


14 / 14 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": null, "right": "6", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "7", "right": "8", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": null, "right": "6", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "7", "right": "8", "value": 5},
      {"id": "6", "left": "9", "right": "10", "value": 6},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "11", "right": "6", "value": 3},
      {"id": "11", "left": null, "right": null, "value": 11},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "7", "right": "8", "value": 5},
      {"id": "6", "left": "9", "right": "10", "value": 6},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": null, "right": "5", "value": 4},
      {"id": "4", "left": "6", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "7", "value": 2},
      {"id": "3", "left": "8", "right": "5", "value": 4},
      {"id": "4", "left": "6", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
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
Test Case 7 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
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
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "5", "left": "9", "right": "10", "value": 5},
      {"id": "6", "left": "11", "right": "12", "value": 6},
      {"id": "7", "left": "13", "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "11", "left": null, "right": null, "value": 11},
      {"id": "12", "left": null, "right": null, "value": 12},
      {"id": "13", "left": null, "right": null, "value": 13}
    ],
    "root": "1"
  }
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "5", "left": "9", "right": "10", "value": 5},
      {"id": "6", "left": null, "right": "12", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "11", "left": null, "right": null, "value": 11},
      {"id": "12", "left": null, "right": "13", "value": 12},
      {"id": "13", "left": null, "right": null, "value": 13}
    ],
    "root": "1"
  }
}
Test Case 11 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 12 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": "4", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 2},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 13 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": null, "value": 4},
      {"id": "5", "left": "12", "right": null, "value": 5},
      {"id": "6", "left": "9", "right": "10", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": "11", "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "11", "left": null, "right": null, "value": 11},
      {"id": "12", "left": null, "right": null, "value": 12}
    ],
    "root": "1"
  }
}
Test Case 14 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": null, "value": 4},
      {"id": "5", "left": "12", "right": null, "value": 5},
      {"id": "6", "left": "9", "right": "10", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "12", "left": null, "right": null, "value": 12}
    ],
    "root": "1"
  }
}
 
 */