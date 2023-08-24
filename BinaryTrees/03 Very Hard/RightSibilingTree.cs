using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._03_Very_Hard
{
    internal class RightSibilingTreeProgram
    {
    }
}
/*
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree root = new Program.BinaryTree(1);
    insert(root, new int[] { 2, 3, 4, 5, 6, 7, 8, 9 });
    root.left.right.right = new Program.BinaryTree(10);
    root.right.left.left = new Program.BinaryTree(11);
    root.right.right.left = new Program.BinaryTree(12);
    root.right.right.right = new Program.BinaryTree(13);
    root.right.left.left.left = new Program.BinaryTree(14);
    Program.BinaryTree mutatedRoot = Program.RightSiblingTree(root);
    List<int> actual = getDfsOrder(mutatedRoot);
    var expected = new List<int> {
      1, 2, 4, 8, 9, 5, 6, 11, 14, 7, 12, 13, 3, 6, 11, 14, 7, 12, 13
    };
    Utils.AssertTrue(expected.SequenceEqual(actual));
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

  public List<int> getDfsOrder(Program.BinaryTree tree) {
    List<int> values = new List<int>();
    values.Add(tree.value);
    if (tree.left != null) {
      values.AddRange(getDfsOrder(tree.left));
    }
    if (tree.right != null) {
      values.AddRange(getDfsOrder(tree.right));
    }
    return values;
  }
}


9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": "11", "right": "7", "value": 6},
    {"id": "7", "left": "12", "right": null, "value": 7},
    {"id": "12", "left": null, "right": "13", "value": 12},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "11", "left": "14", "right": null, "value": 11},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "4", "left": "8", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "6", "value": 5},
    {"id": "8", "left": null, "right": "9", "value": 8},
    {"id": "9", "left": null, "right": null, "value": 9}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": "11", "right": "7", "value": 6},
    {"id": "7", "left": "12", "right": null, "value": 7},
    {"id": "12", "left": null, "right": "13", "value": 12},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "11", "left": "14", "right": null, "value": 11},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "4", "left": "8", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "6", "value": 5},
    {"id": "8", "left": null, "right": "9", "value": 8},
    {"id": "9", "left": null, "right": null, "value": 9}
  ],
  "root": "1"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "7", "left": "12", "right": "13", "value": 7},
      {"id": "13", "left": null, "right": null, "value": 13},
      {"id": "12", "left": null, "right": null, "value": 12},
      {"id": "6", "left": "11", "right": null, "value": 6},
      {"id": "11", "left": "14", "right": null, "value": 11},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "5", "left": null, "right": "10", "value": 5},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "8", "left": null, "right": null, "value": 8}
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
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "1"
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
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": null, "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": null, "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3}
  ],
  "root": "1"
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
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4}
  ],
  "root": "1"
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
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "4", "left": null, "right": "5", "value": 4},
    {"id": "5", "left": null, "right": null, "value": 5}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "4", "left": null, "right": "5", "value": 4},
    {"id": "5", "left": null, "right": null, "value": 5}
  ],
  "root": "1"
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
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "4", "left": null, "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "6", "value": 5}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "4", "left": null, "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "6", "value": 5}
  ],
  "root": "1"
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
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "4", "left": null, "right": "5", "value": 4},
    {"id": "5", "left": "7", "right": "6", "value": 5},
    {"id": "7", "left": null, "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "4", "left": null, "right": "5", "value": 4},
    {"id": "5", "left": "7", "right": "6", "value": 5},
    {"id": "7", "left": null, "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8}
  ],
  "root": "1"
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
Test Case 9 passed!
Expected Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": "12", "right": "7", "value": 6},
    {"id": "7", "left": "14", "right": null, "value": 7},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "12", "left": null, "right": "13", "value": 12},
    {"id": "13", "left": null, "right": "14", "value": 13},
    {"id": "4", "left": "8", "right": "5", "value": 4},
    {"id": "5", "left": "10", "right": "6", "value": 5},
    {"id": "10", "left": null, "right": "11", "value": 10},
    {"id": "11", "left": null, "right": "12", "value": 11},
    {"id": "8", "left": null, "right": "9", "value": 8},
    {"id": "9", "left": null, "right": "10", "value": 9}
  ],
  "root": "1"
}
Our Code's Output
{
  "nodes": [
    {"id": "1", "left": "2", "right": null, "value": 1},
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": "6", "right": null, "value": 3},
    {"id": "6", "left": "12", "right": "7", "value": 6},
    {"id": "7", "left": "14", "right": null, "value": 7},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "12", "left": null, "right": "13", "value": 12},
    {"id": "13", "left": null, "right": "14", "value": 13},
    {"id": "4", "left": "8", "right": "5", "value": 4},
    {"id": "5", "left": "10", "right": "6", "value": 5},
    {"id": "10", "left": null, "right": "11", "value": 10},
    {"id": "11", "left": null, "right": "12", "value": 11},
    {"id": "8", "left": null, "right": "9", "value": 8},
    {"id": "9", "left": null, "right": "10", "value": 9}
  ],
  "root": "1"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "7", "left": "14", "right": "15", "value": 7},
      {"id": "15", "left": null, "right": null, "value": 15},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "6", "left": "12", "right": "13", "value": 6},
      {"id": "13", "left": null, "right": null, "value": 13},
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