using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._02_Hard
{
    internal class FindNodesDistanceKProgram
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

        public List<int> FindNodesDistanceK(BinaryTree tree, int target, int k)
        {
            // Write your code here.
            List<int> nodeDistancek = new List<int>();
            findDistanceFromNodeToTarget(tree, target, k, nodeDistancek);
            return nodeDistancek;
        }
        public int findDistanceFromNodeToTarget(
            BinaryTree node, int target, int k, List<int> nodeDistancek
        )
        {
            if (node == null)
            {
                return -1;
            }
            if (node.value == target)
            {
                addSubtreeNodeAtDistanceK(node, 0, k, nodeDistancek);
                return 1;
            }
            int leftDistance =
                findDistanceFromNodeToTarget(node.left, target, k, nodeDistancek);
            int rightDistance =
                findDistanceFromNodeToTarget(node.right, target, k, nodeDistancek);
            if (leftDistance == k || rightDistance == k) nodeDistancek.Add(node.value);

            if (leftDistance != -1)
            {
                addSubtreeNodeAtDistanceK(
                    node.right, leftDistance + 1, k, nodeDistancek
                );
                return leftDistance + 1;
            }

            if (rightDistance != -1)
            {
                addSubtreeNodeAtDistanceK(
                    node.left, rightDistance + 1, k, nodeDistancek
                );
                return rightDistance + 1;
            }
            return -1;
        }
        void addSubtreeNodeAtDistanceK(
            BinaryTree node, int distance, int k, List<int> nodeDistanceK
        )
        {
            if (node == null) return;
            if (distance == k)
            {
                nodeDistanceK.Add(node.value);
            }
            else
            {
                addSubtreeNodeAtDistanceK(node.left, distance + 1, k, nodeDistanceK);
                addSubtreeNodeAtDistanceK(node.right, distance + 1, k, nodeDistanceK);
            }
        }
    }
}

/*
 using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree root = new Program.BinaryTree(1);
    root.left = new Program.BinaryTree(2);
    root.right = new Program.BinaryTree(3);
    root.left.left = new Program.BinaryTree(4);
    root.left.right = new Program.BinaryTree(5);
    root.right.right = new Program.BinaryTree(6);
    root.right.right.left = new Program.BinaryTree(7);
    root.right.right.right = new Program.BinaryTree(8);
    int target = 3;
    int k = 2;
    var expected = new List<int> { 2, 7, 8 };
    var actual = new Program().FindNodesDistanceK(root, target, k);
    actual.Sort();
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }
}


10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
[7, 8, 2]
Your Code's Output
[7, 8, 2]
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "target": 3,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": null, "right": "6", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": "7", "right": "8", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
[5]
Your Code's Output
[5]
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "target": 2,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": "4", "right": null, "value": 3},
      {"id": "4", "left": "5", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
[4]
Your Code's Output
[4]
View Outputs Side By Side
Input(s)
{
  "k": 6,
  "target": 8,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": "5", "right": "6", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": "8", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
[5, 6, 1]
Your Code's Output
[5, 6, 1]
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "target": 3,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": "5", "right": "6", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": "8", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 5 passed!
Expected Output
[4, 5, 6, 7]
Your Code's Output
[4, 5, 6, 7]
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "target": 1,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
[9, 2]
Your Code's Output
[9, 2]
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "target": 8,
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
Test Case 7 passed!
Expected Output
[7, 8]
Your Code's Output
[7, 8]
View Outputs Side By Side
Input(s)
{
  "k": 6,
  "target": 6,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": null, "right": "5", "value": 3},
      {"id": "4", "left": "6", "right": null, "value": 4},
      {"id": "5", "left": "7", "right": "8", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "target": 1,
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "k": 17,
  "target": 6,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": null, "right": "5", "value": 3},
      {"id": "4", "left": "6", "right": null, "value": 4},
      {"id": "5", "left": "7", "right": "8", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 10 passed!
Expected Output
[8, 9, 10, 11, 3]
Your Code's Output
[8, 9, 10, 11, 3]
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "target": 2,
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": "6", "right": "7", "value": 3},
      {"id": "4", "left": "8", "right": "9", "value": 4},
      {"id": "5", "left": "10", "right": "11", "value": 5},
      {"id": "6", "left": "12", "right": "13", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
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
 
 */