using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    class SymmetricalTreeProgram
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

        public bool SymmetricalTreeSol1(BinaryTree tree)
        {
            // Write your code here.

            return treesAreMirrored(tree.left, tree.right);
        }
        private bool treesAreMirrored(BinaryTree left, BinaryTree right)
        {
            if (left != null && right != null && left.value == right.value)
            {
                return treesAreMirrored(left.left, right.right) &&
                    treesAreMirrored(left.right, right.left);
            }
            return left == right;
        }

        public bool SymmetricalTree(BinaryTree tree)
        {
            // Write your code here.
            Stack<BinaryTree> stackLeft = new Stack<BinaryTree>();
            stackLeft.Push(tree.left);
            Stack<BinaryTree> stackRight = new Stack<BinaryTree>();
            stackRight.Push(tree.right);

            while (stackLeft.Count != 0 && stackRight.Count != 0)
            {
                BinaryTree left = stackLeft.Pop();
                BinaryTree right = stackRight.Pop();

                if (left == null && right == null)
                {
                    continue;
                }
                if (left == null || right == null || left.value != right.value)
                {
                    return false;
                }
                stackLeft.Push(left.left);
                stackLeft.Push(left.right);
                stackRight.Push(right.right);
                stackRight.Push(right.left);
            }
            return stackLeft.Count == 0 && stackRight.Count == 0;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree tree = new Program.BinaryTree(10);
    tree.left = new Program.BinaryTree(5);
    tree.right = new Program.BinaryTree(5);
    tree.left.left = new Program.BinaryTree(7);
    tree.left.right = new Program.BinaryTree(9);
    tree.right.left = new Program.BinaryTree(9);
    tree.right.right = new Program.BinaryTree(7);
    var expected = true;
    var actual = new Program().SymmetricalTree(tree);
    Utils.AssertTrue(expected == actual);
  }
}

13 / 13 test cases passed.

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
      {"id": "1", "left": null, "right": null, "value": 1}
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
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2}
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
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
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
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "2-2", "left": null, "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "2-2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3}
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
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": "3", "right": "3-2", "value": 2},
      {"id": "2-2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "3-2", "left": null, "right": null, "value": 3}
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
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": "3", "right": "3-2", "value": 2},
      {"id": "2-2", "left": "3-3", "right": "3-4", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "3-2", "left": null, "right": null, "value": 3},
      {"id": "3-3", "left": null, "right": null, "value": 3},
      {"id": "3-4", "left": null, "right": null, "value": 3}
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
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": "3", "right": "4", "value": 2},
      {"id": "2-2", "left": "4-2", "right": "3-2", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "3-2", "left": null, "right": null, "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "4-2", "left": null, "right": null, "value": 4}
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
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": "3", "right": "4", "value": 2},
      {"id": "2-2", "left": "3-2", "right": "4-2", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "3-2", "left": null, "right": null, "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "4-2", "left": null, "right": null, "value": 4}
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
      {"id": "1", "left": "2", "right": "5", "value": 1},
      {"id": "2", "left": "3", "right": "4", "value": 2},
      {"id": "5", "left": "4-2", "right": "3-2", "value": 5},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "3-2", "left": null, "right": null, "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "4-2", "left": null, "right": null, "value": 4}
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
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": "3", "right": "4", "value": 2},
      {"id": "2-2", "left": "4-2", "right": "3-2", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "3-2", "left": null, "right": null, "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "4-2", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 13 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "right": "2-2", "value": 1},
      {"id": "2", "left": "3", "right": "4", "value": 2},
      {"id": "2-2", "left": "4-2", "right": "3-2", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "3-2", "left": null, "right": null, "value": 3},
      {"id": "4", "left": "5-2", "right": null, "value": 4},
      {"id": "4-2", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
 
 */