using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._03_Very_Hard
{
    internal class CompareLeafTraversal
    {
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree tree1 = new Program.BinaryTree(1);
    tree1.left = new Program.BinaryTree(2);
    tree1.right = new Program.BinaryTree(3);
    tree1.left.left = new Program.BinaryTree(4);
    tree1.left.right = new Program.BinaryTree(5);
    tree1.right.right = new Program.BinaryTree(6);
    tree1.left.right.left = new Program.BinaryTree(7);
    tree1.left.right.right = new Program.BinaryTree(8);

    Program.BinaryTree tree2 = new Program.BinaryTree(1);
    tree2.left = new Program.BinaryTree(2);
    tree2.right = new Program.BinaryTree(3);
    tree2.left.left = new Program.BinaryTree(4);
    tree2.left.right = new Program.BinaryTree(7);
    tree2.right.right = new Program.BinaryTree(5);
    tree2.right.right.left = new Program.BinaryTree(8);
    tree2.right.right.right = new Program.BinaryTree(6);

    var expected = true;
    var actual = new Program().CompareLeafTraversal(tree1, tree2);
    Utils.AssertTrue(expected == actual);
  }
}


12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree1": {
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
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "7", "value": 2},
      {"id": "3", "left": null, "right": "5", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "8", "right": "6", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
true
Our Code's Output
true
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
Test Case 3 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": "3", "right": null, "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": "5", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": "4", "right": null, "value": 3},
      {"id": "4", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree1": {
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
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "7", "value": 2},
      {"id": "3", "left": null, "right": "5", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "8", "right": "6", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": "9", "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
Test Case 5 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "2", "left": null, "right": null, "value": 2}
    ],
    "root": "2"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "2", "left": null, "right": "1", "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "2"
  },
  "tree2": {
    "nodes": [
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "1", "left": "2", "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": null, "value": 2},
      {"id": "3", "left": null, "right": "5", "value": 3},
      {"id": "4", "left": "7", "right": null, "value": 4},
      {"id": "5", "left": "8", "right": "9", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": "6", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "2", "right": "3", "value": 1},
      {"id": "2", "left": "4", "right": "5", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "4", "left": "6", "right": null, "value": 4},
      {"id": "5", "left": "8", "right": "9", "value": 5},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
true
Our Code's Output
true
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
      {"id": "6", "left": "8", "right": null, "value": 6},
      {"id": "7", "left": null, "right": "9", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "2", "right": null, "value": 1},
      {"id": "2", "left": "4", "right": "3", "value": 2},
      {"id": "3", "left": "5", "right": "6", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": "7", "right": "9", "value": 6},
      {"id": "7", "left": "8", "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "8", "value": 1},
      {"id": "2", "left": "3", "right": "5", "value": 2},
      {"id": "3", "left": "4", "right": "6", "value": 3},
      {"id": "4", "left": null, "right": "7", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "8", "right": "2", "value": 1},
      {"id": "2", "left": "5", "right": "3", "value": 2},
      {"id": "3", "left": "6", "right": "4", "value": 3},
      {"id": "4", "left": "7", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 10 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "8", "value": 1},
      {"id": "2", "left": "3", "right": "5", "value": 2},
      {"id": "3", "left": "4", "right": null, "value": 3},
      {"id": "4", "left": "6", "right": "7", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "8", "right": "2", "value": 1},
      {"id": "2", "left": "5", "right": "3", "value": 2},
      {"id": "3", "left": "6", "right": "4", "value": 3},
      {"id": "4", "left": "7", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 11 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "8", "value": 1},
      {"id": "2", "left": "3", "right": "5", "value": 2},
      {"id": "3", "left": "4", "right": "6", "value": 3},
      {"id": "4", "left": null, "right": "7", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "7", "right": "2", "value": 1},
      {"id": "2", "left": "6", "right": "3", "value": 2},
      {"id": "3", "left": "5", "right": "4", "value": 3},
      {"id": "4", "left": "8", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 12 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "tree1": {
    "nodes": [
      {"id": "1", "left": "2", "right": "8", "value": 1},
      {"id": "2", "left": "3", "right": "5", "value": 2},
      {"id": "3", "left": "4", "right": "6", "value": 3},
      {"id": "4", "left": null, "right": "7", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": "1-2", "value": 8},
      {"id": "1-2", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  },
  "tree2": {
    "nodes": [
      {"id": "1", "left": "7", "right": "2", "value": 1},
      {"id": "2", "left": "6", "right": "3", "value": 2},
      {"id": "3", "left": "5", "right": "4", "value": 3},
      {"id": "4", "left": "8", "right": null, "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": null, "right": "1-2", "value": 8},
      {"id": "1-2", "left": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
 
 */