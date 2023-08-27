using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._03_Very_Hard
{
    public class FlattenBinaryTreeProgram
    {
        public static BinaryTree FlattenBinaryTree(BinaryTree root)
        {
            // Write your code here.
            //O(n) time | O(d) space complexity 
            BinaryTree leftMost = flattenTree(root)[0];
            return leftMost;
        }

        public static BinaryTree[] flattenTree(BinaryTree node)
        {
            BinaryTree leftMost;
            BinaryTree rightMost;

            if (node.left == null)
            {
                leftMost = node;
            }
            else
            {
                BinaryTree[] leftAndRightMostNodes = flattenTree(node.left);
                connectNodes(leftAndRightMostNodes[1], node);
                leftMost = leftAndRightMostNodes[0];
            }
            if (node.right == null)
            {
                rightMost = node;
            }
            else
            {
                BinaryTree[] leftAndRightMostNodes = flattenTree(node.right);
                connectNodes(node, leftAndRightMostNodes[0]);
                rightMost = leftAndRightMostNodes[1];
            }
            return new BinaryTree[] { leftMost, rightMost };
        }

        public static void connectNodes(BinaryTree left, BinaryTree right)
        {
            left.right = right;
            right.left = left;
        }

        // This is the class of the input root. Do not edit it.
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
    }


}
/*
 using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree root = new Program.BinaryTree(1);
    insert(root, new int[] { 2, 3, 4, 5, 6 });
    root.left.right.left = new Program.BinaryTree(7);
    root.left.right.right = new Program.BinaryTree(8);
    Program.BinaryTree leftMostNode = Program.FlattenBinaryTree(root);
    List<int> leftToRightToLeft = this.leftToRightToLeft(leftMostNode);
    List<int> expected =
      new List<int>() { 4, 2, 7, 5, 8, 1, 6, 3, 3, 6, 1, 8, 5, 7, 2, 4 };
    Utils.AssertTrue(expected.SequenceEqual(leftToRightToLeft));
  }

  public void insert(Program.BinaryTree root, int[] values) {
    insert(root, values, 0);
  }

  public void insert(Program.BinaryTree root, int[] values, int i) {
    if (i >= values.Length) {
      return;
    }
    Queue<Program.BinaryTree> queue = new Queue<Program.BinaryTree>();
    queue.Enqueue(root);
    while (queue.Count > 0) {
      Program.BinaryTree current = queue.Dequeue();
      if (current.left == null) {
        current.left = new Program.BinaryTree(values[i]);
        break;
      }
      queue.Enqueue(current.left);
      if (current.right == null) {
        current.right = new Program.BinaryTree(values[i]);
        break;
      }
      queue.Enqueue(current.right);
    }
    insert(root, values, i + 1);
  }

  public List<int> leftToRightToLeft(Program.BinaryTree leftMost) {
    List<int> nodes = new List<int>();
    Program.BinaryTree current = leftMost;
    while (current.right != null) {
      nodes.Add(current.value);
      current = current.right;
    }
    nodes.Add(current.value);
    while (current != null) {
      nodes.Add(current.value);
      current = current.left;
    }
    return nodes;
  }
}


8 / 8 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "7", "value": 2},
    {"id": "7", "left": "2", "right": "5", "value": 7},
    {"id": "5", "left": "7", "right": "8", "value": 5},
    {"id": "8", "left": "5", "right": "1", "value": 8},
    {"id": "1", "left": "8", "right": "6", "value": 1},
    {"id": "6", "left": "1", "right": "3", "value": 6},
    {"id": "3", "left": "6", "right": null, "value": 3}
  ],
  "root": "4"
}
Our Code's Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "7", "value": 2},
    {"id": "7", "left": "2", "right": "5", "value": 7},
    {"id": "5", "left": "7", "right": "8", "value": 5},
    {"id": "8", "left": "5", "right": "1", "value": 8},
    {"id": "1", "left": "8", "right": "6", "value": 1},
    {"id": "6", "left": "1", "right": "3", "value": 6},
    {"id": "3", "left": "6", "right": null, "value": 3}
  ],
  "root": "4"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": "6", "right": null, "value": 3},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "5", "left": "7", "right": "8", "value": 5},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
{
  "nodes": [
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "1"
}
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
{
  "nodes": [
    {"id": "2", "left": null, "right": "1", "value": 2},
    {"id": "1", "left": "2", "right": null, "value": 1}
  ],
  "root": "2"
}
Our Code's Output
{
  "nodes": [
    {"id": "2", "left": null, "right": "1", "value": 2},
    {"id": "1", "left": "2", "right": null, "value": 1}
  ],
  "root": "2"
}
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
{
  "nodes": [
    {"id": "2", "left": null, "right": "1", "value": 2},
    {"id": "1", "left": "2", "right": "3", "value": 1},
    {"id": "3", "left": "1", "right": null, "value": 3}
  ],
  "root": "2"
}
Our Code's Output
{
  "nodes": [
    {"id": "2", "left": null, "right": "1", "value": 2},
    {"id": "1", "left": "2", "right": "3", "value": 1},
    {"id": "3", "left": "1", "right": null, "value": 3}
  ],
  "root": "2"
}
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
Test Case 5 passed!
Expected Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "1", "value": 2},
    {"id": "1", "left": "2", "right": "3", "value": 1},
    {"id": "3", "left": "1", "right": null, "value": 3}
  ],
  "root": "4"
}
Our Code's Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "1", "value": 2},
    {"id": "1", "left": "2", "right": "3", "value": 1},
    {"id": "3", "left": "1", "right": null, "value": 3}
  ],
  "root": "4"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "5", "value": 2},
    {"id": "5", "left": "2", "right": "1", "value": 5},
    {"id": "1", "left": "5", "right": "3", "value": 1},
    {"id": "3", "left": "1", "right": null, "value": 3}
  ],
  "root": "4"
}
Our Code's Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "5", "value": 2},
    {"id": "5", "left": "2", "right": "1", "value": 5},
    {"id": "1", "left": "5", "right": "3", "value": 1},
    {"id": "3", "left": "1", "right": null, "value": 3}
  ],
  "root": "4"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "5", "value": 2},
    {"id": "5", "left": "2", "right": "1", "value": 5},
    {"id": "1", "left": "5", "right": "6", "value": 1},
    {"id": "6", "left": "1", "right": "3", "value": 6},
    {"id": "3", "left": "6", "right": null, "value": 3}
  ],
  "root": "4"
}
Our Code's Output
{
  "nodes": [
    {"id": "4", "left": null, "right": "2", "value": 4},
    {"id": "2", "left": "4", "right": "5", "value": 2},
    {"id": "5", "left": "2", "right": "1", "value": 5},
    {"id": "1", "left": "5", "right": "6", "value": 1},
    {"id": "6", "left": "1", "right": "3", "value": 6},
    {"id": "3", "left": "6", "right": null, "value": 3}
  ],
  "root": "4"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": "6", "right": null, "value": 3},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
{
  "nodes": [
    {"id": "8", "left": null, "right": "4", "value": 8},
    {"id": "4", "left": "8", "right": "9", "value": 4},
    {"id": "9", "left": "4", "right": "2", "value": 9},
    {"id": "2", "left": "9", "right": "10", "value": 2},
    {"id": "10", "left": "2", "right": "5", "value": 10},
    {"id": "5", "left": "10", "right": "11", "value": 5},
    {"id": "11", "left": "5", "right": "1", "value": 11},
    {"id": "1", "left": "11", "right": "12", "value": 1},
    {"id": "12", "left": "1", "right": "6", "value": 12},
    {"id": "6", "left": "12", "right": "3", "value": 6},
    {"id": "3", "left": "6", "right": "7", "value": 3},
    {"id": "7", "left": "3", "right": null, "value": 7}
  ],
  "root": "8"
}
Our Code's Output
{
  "nodes": [
    {"id": "8", "left": null, "right": "4", "value": 8},
    {"id": "4", "left": "8", "right": "9", "value": 4},
    {"id": "9", "left": "4", "right": "2", "value": 9},
    {"id": "2", "left": "9", "right": "10", "value": 2},
    {"id": "10", "left": "2", "right": "5", "value": 10},
    {"id": "5", "left": "10", "right": "11", "value": 5},
    {"id": "11", "left": "5", "right": "1", "value": 11},
    {"id": "1", "left": "11", "right": "12", "value": 1},
    {"id": "12", "left": "1", "right": "6", "value": 12},
    {"id": "6", "left": "12", "right": "3", "value": 6},
    {"id": "3", "left": "6", "right": "7", "value": 3},
    {"id": "7", "left": "3", "right": null, "value": 7}
  ],
  "root": "8"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "6", "left": "12", "right": null, "value": 6},
      {"id": "12", "left": null, "right": null, "value": 12},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "5", "left": "10", "right": "11", "value": 5},
      {"id": "11", "left": null, "right": null, "value": 11},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
 
 */