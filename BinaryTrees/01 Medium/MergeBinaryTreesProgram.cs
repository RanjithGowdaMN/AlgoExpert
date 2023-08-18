using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._01_Medium
{
    class MergeBinaryTreesProgram
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

        public BinaryTree MergeBinaryTreesSol1(BinaryTree tree1, BinaryTree tree2)
        {
            // Write your code here.
            if (tree1 == null) return tree2;
            if (tree2 == null) return tree1;
            tree1.value += tree2.value;
            tree1.left = MergeBinaryTreesSol1(tree1.left, tree2.left);
            tree1.right = MergeBinaryTreesSol1(tree1.right, tree2.right);
            return tree1;
        }

        public BinaryTree MergeBinaryTrees(BinaryTree tree1, BinaryTree tree2)
        {
            // Write your code here.
            if (tree1 == null)
            {
                return tree2;
            }
            Stack<BinaryTree> tree1Stack = new Stack<BinaryTree>();
            tree1Stack.Push(tree1);
            Stack<BinaryTree> tree2Stack = new Stack<BinaryTree>();
            tree2Stack.Push(tree2);

            while (tree1Stack.Count != 0)
            {
                BinaryTree tree1Node = tree1Stack.Pop();
                BinaryTree tree2Node = tree2Stack.Pop();
                if (tree2Node == null)
                {
                    continue;
                }
                tree1Node.value += tree2Node.value;
                if (tree1Node.left == null)
                {
                    tree1Node.left = tree2Node.left;
                }
                else
                {
                    tree1Stack.Push(tree1Node.left);
                    tree2Stack.Push(tree2Node.left);
                }

                if (tree1Node.right == null)
                {
                    tree1Node.right = tree2Node.right;
                }
                else
                {
                    tree1Stack.Push(tree1Node.right);
                    tree2Stack.Push(tree2Node.right);
                }
            }
            return tree1;
        }
    }
}

/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree tree1 = new Program.BinaryTree(1);
    tree1.left = new Program.BinaryTree(3);
    tree1.left.left = new Program.BinaryTree(7);
    tree1.left.right = new Program.BinaryTree(4);
    tree1.right = new Program.BinaryTree(2);

    Program.BinaryTree tree2 = new Program.BinaryTree(1);
    tree2.left = new Program.BinaryTree(5);
    tree2.left.left = new Program.BinaryTree(2);
    tree2.right = new Program.BinaryTree(9);
    tree2.right.left = new Program.BinaryTree(7);
    tree2.right.right = new Program.BinaryTree(6);

    Program.BinaryTree expected = new Program.BinaryTree(2);
    expected.left = new Program.BinaryTree(8);
    expected.left.left = new Program.BinaryTree(9);
    expected.left.right = new Program.BinaryTree(4);
    expected.right = new Program.BinaryTree(11);
    expected.right.left = new Program.BinaryTree(7);
    expected.right.right = new Program.BinaryTree(6);

    Program.BinaryTree actual = new Program().MergeBinaryTrees(tree1, tree2);

    Utils.AssertTrue(areTreesEqual(expected, actual));
  }

  public bool areTreesEqual(
    Program.BinaryTree tree1, Program.BinaryTree tree2
  ) {
    if (tree1 == null && tree2 == null) return true;

    if (tree1 == null && tree2 != null) {
      return false;
    } else if (tree1 != null && tree2 == null) {
      return false;
    }

    if (tree1.value != tree2.value) return false;
    return areTreesEqual(tree1.left, tree2.left) &&
           areTreesEqual(tree1.right, tree2.right);
  }
}


12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodes": [
    {"id": "9", "left": "3", "right": "6", "value": 9},
    {"id": "6", "left": null, "right": "7", "value": 6},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "3", "left": null, "right": "4", "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4}
  ],
  "root": "9"
}
Your Code's Output
{
  "nodes": [
    {"id": "9", "left": "3", "right": "6", "value": 9},
    {"id": "6", "left": null, "right": "7", "value": 6},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "3", "left": null, "right": "4", "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4}
  ],
  "root": "9"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "7", "left": null, "right": null, "value": 7}
    ],
    "root": "7"
  },
  "tree2": {
    "nodes": [
      {"id": "2", "left": "3", "right": "6", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "7", "left": null, "right": null, "value": 7}
    ],
    "root": "2"
  }
}
Test Case 2 passed!
Expected Output
{
  "nodes": [
    {"id": "3", "left": "6", "right": "8", "value": 3},
    {"id": "8", "left": null, "right": "7", "value": 8},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "6", "left": "5", "right": "4", "value": 6},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "5", "left": null, "right": null, "value": 5}
  ],
  "root": "3"
}
Your Code's Output
{
  "nodes": [
    {"id": "3", "left": "6", "right": "8", "value": 3},
    {"id": "8", "left": null, "right": "7", "value": 8},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "6", "left": "5", "right": "4", "value": 6},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "5", "left": null, "right": null, "value": 5}
  ],
  "root": "3"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "3", "right": "2", "value": 1},
      {"id": "3", "left": "5", "right": null, "value": 3},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "2", "left": "3", "right": "6", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "7", "left": null, "right": null, "value": 7}
    ],
    "root": "2"
  }
}
Test Case 3 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "8", "right": "11", "value": 2},
    {"id": "11", "left": "7", "right": "6", "value": 11},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "8", "left": "9", "right": "4", "value": 8},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "9", "left": null, "right": null, "value": 9}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "8", "right": "11", "value": 2},
    {"id": "11", "left": "7", "right": "6", "value": 11},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "8", "left": "9", "right": "4", "value": 8},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "9", "left": null, "right": null, "value": 9}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "3", "right": "2", "value": 1},
      {"id": "3", "left": "7", "right": "4", "value": 3},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "5", "right": "9", "value": 1},
      {"id": "5", "left": "2", "right": null, "value": 5},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "9", "left": "7", "right": "6", "value": 9},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "4", "left": "5", "right": "6", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "4"
  }
}
Test Case 5 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "7", "left": "1", "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "7", "left": "1", "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "4", "left": "5", "right": "6", "value": 4},
      {"id": "5", "left": "1", "right": "8", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "4"
  }
}
Test Case 6 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": "10", "right": "15", "value": 9},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "7", "left": "1", "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": "10", "right": "15", "value": 9},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "7", "left": "1", "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "4", "left": "5", "right": "6", "value": 4},
      {"id": "5", "left": "1", "right": "8", "value": 5},
      {"id": "6", "left": "10", "right": "15", "value": 6},
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "15", "left": null, "right": null, "value": 15}
    ],
    "root": "4"
  }
}
Test Case 7 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "7", "left": "5-2", "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "5-2", "left": null, "right": null, "value": 5}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "7", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "7", "left": "5-2", "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "5-2", "left": null, "right": null, "value": 5}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "5", "right": "8", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "4", "left": "5", "right": "6", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "4"
  }
}
Test Case 8 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "5-2", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "5-2", "left": "6", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "6", "left": null, "right": null, "value": 6}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "5-2", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8},
    {"id": "5-2", "left": "6", "right": "9", "value": 5},
    {"id": "9", "left": null, "right": null, "value": 9},
    {"id": "6", "left": null, "right": null, "value": 6}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "2", "left": "4", "right": "1", "value": 2},
      {"id": "4", "left": "6", "right": null, "value": 4},
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "6", "left": null, "right": null, "value": 6}
    ],
    "root": "2"
  },
  "tree2": {
    "nodes": [
      {"id": "3", "left": "1", "right": "6", "value": 3},
      {"id": "1", "left": null, "right": "9", "value": 1},
      {"id": "6", "left": null, "right": "8", "value": 6},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "3"
  }
}
Test Case 9 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "4", "right": "6", "value": 2},
    {"id": "6", "left": "12", "right": "14", "value": 6},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "12", "left": null, "right": null, "value": 12},
    {"id": "4", "left": "8", "right": "10", "value": 4},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "8", "left": null, "right": null, "value": 8}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "4", "right": "6", "value": 2},
    {"id": "6", "left": "12", "right": "14", "value": 6},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "12", "left": null, "right": null, "value": 12},
    {"id": "4", "left": "8", "right": "10", "value": 4},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "8", "left": null, "right": null, "value": 8}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
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
  },
  "tree2": {
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
Test Case 10 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 11 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "3", "right": "4", "value": 2},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "3", "left": null, "right": null, "value": 3}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "3", "right": "4", "value": 2},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "3", "left": null, "right": null, "value": 3}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "3", "right": null, "value": 1},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": null, "right": "4", "value": 1},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  }
}
Test Case 12 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "4", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "4", "right": null, "value": 1},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": null, "right": "3", "value": 1},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "1"
  }
}
 
 
 */