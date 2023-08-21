using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._01_Medium
{
    class TreeTraversalTypes
    {
        public static List<int> InOrderTraverse(BST tree, List<int> array)
        {
            // Write your code here.
            if (tree.left != null)
            {
                InOrderTraverse(tree.left, array);
            }
            array.Add(tree.value);
            if (tree.right != null)
            {
                InOrderTraverse(tree.right, array);
            }
            return array;
        }

        public static List<int> PreOrderTraverse(BST tree, List<int> array)
        {
            // Write your code here.
            array.Add(tree.value);
            if (tree.left != null)
            {
                PreOrderTraverse(tree.left, array);
            }
            if (tree.right != null)
            {
                PreOrderTraverse(tree.right, array);
            }
            return array;
        }

        public static List<int> PostOrderTraverse(BST tree, List<int> array)
        {
            // Write your code here.
            if (tree.left != null)
            {
                PostOrderTraverse(tree.left, array);
            }
            if (tree.right != null)
            {
                PostOrderTraverse(tree.right, array);
            }
            array.Add(tree.value);
            return array;
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }
    }
}
/*
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var root = new Program.BST(10);
    root.left = new Program.BST(5);
    root.left.left = new Program.BST(2);
    root.left.left.left = new Program.BST(1);
    root.left.right = new Program.BST(5);
    root.right = new Program.BST(15);
    root.right.right = new Program.BST(22);

    List<int> inOrder = new List<int> { 1, 2, 5, 5, 10, 15, 22 };
    List<int> preOrder = new List<int> { 10, 5, 2, 1, 5, 15, 22 };
    List<int> postOrder = new List<int> { 1, 2, 5, 5, 22, 15, 10 };

    Utils.AssertTrue(Enumerable.SequenceEqual(
      Program.InOrderTraverse(root, new List<int>()), inOrder
    ));
    Utils.AssertTrue(Enumerable.SequenceEqual(
      Program.PreOrderTraverse(root, new List<int>()), preOrder
    ));
    Utils.AssertTrue(Enumerable.SequenceEqual(
      Program.PostOrderTraverse(root, new List<int>()), postOrder
    ));
  }
}

 6 / 6 test cases passed.

Test Case 1 passed!
Expected Output
{
  "inOrderArray": [1, 2, 5, 5, 10, 15, 22],
  "postOrderArray": [1, 2, 5, 5, 22, 15, 10],
  "preOrderArray": [10, 5, 2, 1, 5, 15, 22]
}
Your Code's Output
{
  "inOrderArray": [1, 2, 5, 5, 10, 15, 22],
  "postOrderArray": [1, 2, 5, 5, 22, 15, 10],
  "preOrderArray": [10, 5, 2, 1, 5, 15, 22]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": null, "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "10"
  }
}
Test Case 2 passed!
Expected Output
{
  "inOrderArray": [-403, -51, 1, 1, 1, 1, 1, 2, 3, 5, 5, 15, 22, 57, 60, 100, 203, 204, 205, 206, 207, 208, 502, 1001, 4500, 55000],
  "postOrderArray": [-403, -51, 1, 1, 1, 1, 1, 3, 2, 5, 60, 57, 22, 15, 5, 203, 206, 208, 207, 205, 204, 4500, 1001, 55000, 502, 100],
  "preOrderArray": [100, 5, 2, 1, -51, -403, 1, 1, 1, 1, 3, 15, 5, 22, 57, 60, 502, 204, 203, 205, 207, 206, 208, 55000, 1001, 4500]
}
Your Code's Output
{
  "inOrderArray": [-403, -51, 1, 1, 1, 1, 1, 2, 3, 5, 5, 15, 22, 57, 60, 100, 203, 204, 205, 206, 207, 208, 502, 1001, 4500, 55000],
  "postOrderArray": [-403, -51, 1, 1, 1, 1, 1, 3, 2, 5, 60, 57, 22, 15, 5, 203, 206, 208, 207, 205, 204, 4500, 1001, 55000, 502, 100],
  "preOrderArray": [100, 5, 2, 1, -51, -403, 1, 1, 1, 1, 3, 15, 5, 22, 57, 60, 502, 204, 203, 205, 207, 206, 208, 55000, 1001, 4500]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "100", "left": "5", "right": "502", "value": 100},
      {"id": "502", "left": "204", "right": "55000", "value": 502},
      {"id": "55000", "left": "1001", "right": null, "value": 55000},
      {"id": "1001", "left": null, "right": "4500", "value": 1001},
      {"id": "4500", "left": null, "right": null, "value": 4500},
      {"id": "204", "left": "203", "right": "205", "value": 204},
      {"id": "205", "left": null, "right": "207", "value": 205},
      {"id": "207", "left": "206", "right": "208", "value": 207},
      {"id": "208", "left": null, "right": null, "value": 208},
      {"id": "206", "left": null, "right": null, "value": 206},
      {"id": "203", "left": null, "right": null, "value": 203},
      {"id": "5", "left": "2", "right": "15", "value": 5},
      {"id": "15", "left": "5-2", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": "57", "value": 22},
      {"id": "57", "left": null, "right": "60", "value": 57},
      {"id": "60", "left": null, "right": null, "value": 60},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "1", "left": "-51", "right": "1-2", "value": 1},
      {"id": "1-2", "left": null, "right": "1-3", "value": 1},
      {"id": "1-3", "left": null, "right": "1-4", "value": 1},
      {"id": "1-4", "left": null, "right": "1-5", "value": 1},
      {"id": "1-5", "left": null, "right": null, "value": 1},
      {"id": "-51", "left": "-403", "right": null, "value": -51},
      {"id": "-403", "left": null, "right": null, "value": -403}
    ],
    "root": "100"
  }
}
Test Case 3 passed!
Expected Output
{
  "inOrderArray": [-22, -15, -5, -5, -2, -1, 1, 2, 5, 5, 10, 15, 22],
  "postOrderArray": [-22, -15, -1, -2, -5, -5, 1, 2, 5, 5, 22, 15, 10],
  "preOrderArray": [10, 5, 2, 1, -5, -15, -22, -5, -2, -1, 5, 15, 22]
}
Your Code's Output
{
  "inOrderArray": [-22, -15, -5, -5, -2, -1, 1, 2, 5, 5, 10, 15, 22],
  "postOrderArray": [-22, -15, -1, -2, -5, -5, 1, 2, 5, 5, 22, 15, 10],
  "preOrderArray": [10, 5, 2, 1, -5, -15, -22, -5, -2, -1, 5, 15, 22]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": null, "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": "-5", "right": null, "value": 1},
      {"id": "-5", "left": "-15", "right": "-5-2", "value": -5},
      {"id": "-5-2", "left": null, "right": "-2", "value": -5},
      {"id": "-2", "left": null, "right": "-1", "value": -2},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "-15", "left": "-22", "right": null, "value": -15},
      {"id": "-22", "left": null, "right": null, "value": -22}
    ],
    "root": "10"
  }
}
Test Case 4 passed!
Expected Output
{
  "inOrderArray": [10],
  "postOrderArray": [10],
  "preOrderArray": [10]
}
Your Code's Output
{
  "inOrderArray": [10],
  "postOrderArray": [10],
  "preOrderArray": [10]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "10", "left": null, "right": null, "value": 10}
    ],
    "root": "10"
  }
}
Test Case 5 passed!
Expected Output
{
  "inOrderArray": [1, 2, 5, 5, 10, 15, 22, 50, 200, 500, 1500, 2200, 10000],
  "postOrderArray": [1, 2, 5, 5, 200, 50, 2200, 10000, 1500, 500, 22, 15, 10],
  "preOrderArray": [10, 5, 2, 1, 5, 15, 22, 500, 50, 200, 1500, 10000, 2200]
}
Your Code's Output
{
  "inOrderArray": [1, 2, 5, 5, 10, 15, 22, 50, 200, 500, 1500, 2200, 10000],
  "postOrderArray": [1, 2, 5, 5, 200, 50, 2200, 10000, 1500, 500, 22, 15, 10],
  "preOrderArray": [10, 5, 2, 1, 5, 15, 22, 500, 50, 200, 1500, 10000, 2200]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": null, "right": "22", "value": 15},
      {"id": "22", "left": null, "right": "500", "value": 22},
      {"id": "500", "left": "50", "right": "1500", "value": 500},
      {"id": "1500", "left": null, "right": "10000", "value": 1500},
      {"id": "10000", "left": "2200", "right": null, "value": 10000},
      {"id": "2200", "left": null, "right": null, "value": 2200},
      {"id": "50", "left": null, "right": "200", "value": 50},
      {"id": "200", "left": null, "right": null, "value": 200},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "10"
  }
}
Test Case 6 passed!
Expected Output
{
  "inOrderArray": [1, 1, 1, 1, 1, 2, 3, 5, 5, 15, 22, 203, 204, 205, 206, 207, 208, 502, 5000, 55000],
  "postOrderArray": [1, 1, 1, 1, 1, 3, 2, 5, 203, 206, 208, 207, 205, 204, 502, 22, 15, 5, 55000, 5000],
  "preOrderArray": [5000, 5, 2, 1, 1, 1, 1, 1, 3, 15, 5, 22, 502, 204, 203, 205, 207, 206, 208, 55000]
}
Your Code's Output
{
  "inOrderArray": [1, 1, 1, 1, 1, 2, 3, 5, 5, 15, 22, 203, 204, 205, 206, 207, 208, 502, 5000, 55000],
  "postOrderArray": [1, 1, 1, 1, 1, 3, 2, 5, 203, 206, 208, 207, 205, 204, 502, 22, 15, 5, 55000, 5000],
  "preOrderArray": [5000, 5, 2, 1, 1, 1, 1, 1, 3, 15, 5, 22, 502, 204, 203, 205, 207, 206, 208, 55000]
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "5000", "left": "5", "right": "55000", "value": 5000},
      {"id": "55000", "left": null, "right": null, "value": 55000},
      {"id": "5", "left": "2", "right": "15", "value": 5},
      {"id": "15", "left": "5-2", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": "502", "value": 22},
      {"id": "502", "left": "204", "right": null, "value": 502},
      {"id": "204", "left": "203", "right": "205", "value": 204},
      {"id": "205", "left": null, "right": "207", "value": 205},
      {"id": "207", "left": "206", "right": "208", "value": 207},
      {"id": "208", "left": null, "right": null, "value": 208},
      {"id": "206", "left": null, "right": null, "value": 206},
      {"id": "203", "left": null, "right": null, "value": 203},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "1", "left": null, "right": "1-2", "value": 1},
      {"id": "1-2", "left": null, "right": "1-3", "value": 1},
      {"id": "1-3", "left": null, "right": "1-4", "value": 1},
      {"id": "1-4", "left": null, "right": "1-5", "value": 1},
      {"id": "1-5", "left": null, "right": null, "value": 1}
    ],
    "root": "5000"
  }
}
 */