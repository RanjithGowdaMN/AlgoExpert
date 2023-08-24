using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._03_Very_Hard
{
    internal class IterativeInOrderTraversalProgram
    {
        public static void IterativeInOrderTraversal(
  BinaryTree tree, Action<BinaryTree> callback
)
        {
            // O(n) time complexity | O(1) space complexity
            BinaryTree previousNode = null;
            BinaryTree currentNode = tree;
            while (currentNode != null)
            {
                BinaryTree nextNode;
                if (previousNode == null || previousNode == currentNode.parent)
                {
                    if (currentNode.left != null)
                    {
                        nextNode = currentNode.left;
                    }
                    else
                    {
                        callback(currentNode);
                        nextNode = currentNode.right != null ? currentNode.right : currentNode.parent;
                    }
                }
                else if (previousNode == currentNode.left)
                {
                    callback(currentNode);
                    nextNode = currentNode.right != null ? currentNode.right : currentNode.parent;
                }
                else
                {
                    nextNode = currentNode.parent;
                }
                previousNode = currentNode;
                currentNode = nextNode;
            }
        }

        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;
            public BinaryTree parent;

            public BinaryTree(int value)
            {
                this.value = value;
            }

            public BinaryTree(int value, BinaryTree parent)
            {
                this.value = value;
                this.parent = parent;
            }
        }
    }
}
/*
 using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  public List<int> testArray = new List<int>();

  void testCallback(Program.BinaryTree tree) {
    if (tree == null) {
      return;
    }
    testArray.Add(tree.value);
    return;
  }

  [Test]
  public void TestCase1() {
    var root = new Program.BinaryTree(1);
    root.left = new Program.BinaryTree(2, root);
    root.left.left = new Program.BinaryTree(4, root.left);
    root.left.left.right = new Program.BinaryTree(9, root.left.left);
    root.right = new Program.BinaryTree(3, root);
    root.right.left = new Program.BinaryTree(6, root.right);
    root.right.right = new Program.BinaryTree(7, root.right);

    testArray.Clear();
    Program.IterativeInOrderTraversal(root, testCallback);
    Utils.AssertTrue(
      Enumerable.SequenceEqual(testArray, new List<int> { 4, 9, 2, 1, 6, 3, 7 })
    );
  }
}

7 / 7 test cases passed.

Test Case 1 passed!
Expected Output
{
  "traversalOrder": [4, 9, 2, 1, 6, 3, 7]
}
Our Code's Output
{
  "traversalOrder": [4, 9, 2, 1, 6, 3, 7]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": null, "right": "9", "value": 4},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
{
  "traversalOrder": [1]
}
Our Code's Output
{
  "traversalOrder": [1]
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
  "traversalOrder": [4, 2, 1, 3]
}
Our Code's Output
{
  "traversalOrder": [4, 2, 1, 3]
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
Test Case 4 passed!
Expected Output
{
  "traversalOrder": [4, 2, 5, 1, 6, 3, 7]
}
Our Code's Output
{
  "traversalOrder": [4, 2, 5, 1, 6, 3, 7]
}
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
Test Case 5 passed!
Expected Output
{
  "traversalOrder": [8, 4, 9, 2, 10, 5, 1, 6, 3, 7]
}
Our Code's Output
{
  "traversalOrder": [8, 4, 9, 2, 10, 5, 1, 6, 3, 7]
}
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
      {"id": "5", "left": "10", "right": null, "value": 5},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
{
  "traversalOrder": [8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 7]
}
Our Code's Output
{
  "traversalOrder": [8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 7]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "7", "left": null, "right": null, "value": 7},
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
Test Case 7 passed!
Expected Output
{
  "traversalOrder": [16, 8, 17, 4, 18, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15]
}
Our Code's Output
{
  "traversalOrder": [16, 8, 17, 4, 18, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15]
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
      {"id": "9", "left": "18", "right": null, "value": 9},
      {"id": "18", "left": null, "right": null, "value": 18},
      {"id": "8", "left": "16", "right": "17", "value": 8},
      {"id": "17", "left": null, "right": null, "value": 17},
      {"id": "16", "left": null, "right": null, "value": 16}
    ],
    "root": "1"
  }
}

 */
