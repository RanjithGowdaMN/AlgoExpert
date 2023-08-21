using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._02_Hard
{
    class RepairBstProgram
    {
        public class BST
        {
            public int value;
            public BST left = null;
            public BST right = null;

            public BST(int value)
            {
                this.value = value;
            }
        }

        public BST RepairBst(BST tree)
        {
            // O(n) time | O(h)
            BST nodeOne = null, nodeTwo = null, previousNode = null;

            Stack<BST> stack = new Stack<BST>();
            BST currentNode = tree;
            while (currentNode != null || stack.Count > 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                currentNode = stack.Pop();

                if (previousNode != null && previousNode.value > currentNode.value)
                {
                    if (nodeOne == null)
                    {
                        nodeOne = previousNode;
                    }
                    nodeTwo = currentNode;
                }
                previousNode = currentNode;
                currentNode = currentNode.right;
            }
            int tempNodeOneValue = nodeOne.value;
            nodeOne.value = nodeTwo.value;
            nodeTwo.value = tempNodeOneValue;
            return tree;
        }
    }
}

/*
  public class BST {
    public int value;
    public BST left = null;
    public BST right = null;

    public BST(int value) {
      this.value = value;
    }
  }
private BST nodeOne = null, nodeTwo = null, previousNode = null;
  public BST RepairBst(BST tree) {
    // O(n) time | O(h) space
      this.inOrderTraversal(tree);
      int tempNodeOneValue = nodeOne.value;
      nodeOne.value = nodeTwo.value;
      nodeTwo.value = tempNodeOneValue;
    return tree;
  }
    private void inOrderTraversal(BST node){
        if(node==null){
            return;
        }
        inOrderTraversal(node.left);

        if(this.previousNode != null && this.previousNode.value > node.value){
            if(this.nodeOne == null){
                this.nodeOne = this.previousNode;
            }
            this.nodeTwo = node;
        }
        this.previousNode = node;
        inOrderTraversal(node.right);
    }
 
 ------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BST tree = new Program.BST(2);
    tree.left = new Program.BST(1);
    tree.right = new Program.BST(3);
    tree.left.left = new Program.BST(4);
    tree.right.right = new Program.BST(0);
    List<int> expected = new List<int> { 0, 1, 2, 3, 4 };
    List<int> actual =
      inOrderTraverse(new Program().RepairBst(tree), new List<int>());
    Utils.AssertTrue(Enumerable.SequenceEqual(actual, expected));
  }

  private static List<int> inOrderTraverse(Program.BST tree, List<int> array) {
    if (tree.left != null) {
      inOrderTraverse(tree.left, array);
    }
    array.Add(tree.value);
    if (tree.right != null) {
      inOrderTraverse(tree.right, array);
    }
    return array;
  }
}



 10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodes": [
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "1"
}
Your Code's Output
{
  "nodes": [
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "1"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "2", "left": null, "right": "1", "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "2"
  }
}
Test Case 2 passed!
Expected Output
{
  "nodes": [
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3}
  ],
  "root": "1"
}
Your Code's Output
{
  "nodes": [
    {"id": "1", "left": null, "right": "2", "value": 1},
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
      {"id": "1", "left": null, "right": "3", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": null, "right": "2", "value": 3}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "2", "left": "3", "right": "1", "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "3", "left": null, "right": null, "value": 3}
    ],
    "root": "2"
  }
}
Test Case 4 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": "4", "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "1", "left": "0", "right": null, "value": 1},
    {"id": "0", "left": null, "right": null, "value": 0}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": "4", "value": 3},
    {"id": "4", "left": null, "right": null, "value": 4},
    {"id": "1", "left": "0", "right": null, "value": 1},
    {"id": "0", "left": null, "right": null, "value": 0}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "0", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "1", "left": "4", "right": null, "value": 1},
      {"id": "0", "left": null, "right": null, "value": 0}
    ],
    "root": "2"
  }
}
Test Case 5 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "5", "right": "15", "value": 10},
    {"id": "15", "left": "13", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "13", "left": null, "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "5", "left": "2", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "5", "right": "15", "value": 10},
    {"id": "15", "left": "13", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "13", "left": null, "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "5", "left": "2", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "13", "value": 10},
      {"id": "13", "left": "15", "right": "22", "value": 13},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "15", "left": null, "right": "14", "value": 15},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "5", "left": "2", "right": "6", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "10"
  }
}
Test Case 6 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "5", "right": "15", "value": 10},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "5", "left": "2", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": "-5", "right": null, "value": 1},
    {"id": "-5", "left": "-15", "right": "-4", "value": -5},
    {"id": "-4", "left": null, "right": "-2", "value": -4},
    {"id": "-2", "left": null, "right": "-1", "value": -2},
    {"id": "-1", "left": null, "right": null, "value": -1},
    {"id": "-15", "left": "-22", "right": null, "value": -15},
    {"id": "-22", "left": null, "right": null, "value": -22}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "5", "right": "15", "value": 10},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "5", "left": "2", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": "-5", "right": null, "value": 1},
    {"id": "-5", "left": "-15", "right": "-4", "value": -5},
    {"id": "-4", "left": null, "right": "-2", "value": -4},
    {"id": "-2", "left": null, "right": "-1", "value": -2},
    {"id": "-1", "left": null, "right": null, "value": -1},
    {"id": "-15", "left": "-22", "right": null, "value": -15},
    {"id": "-22", "left": null, "right": null, "value": -22}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": null, "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "5", "left": "2", "right": "-15", "value": 5},
      {"id": "-15", "left": null, "right": null, "value": -15},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": "-5", "right": null, "value": 1},
      {"id": "-5", "left": "7", "right": "-4", "value": -5},
      {"id": "-4", "left": null, "right": "-2", "value": -4},
      {"id": "-2", "left": null, "right": "-1", "value": -2},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "7", "left": "-22", "right": null, "value": 7},
      {"id": "-22", "left": null, "right": null, "value": -22}
    ],
    "root": "10"
  }
}
Test Case 7 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "5", "right": "15", "value": 10},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "5", "left": "2", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": "-5", "right": null, "value": 1},
    {"id": "-5", "left": "-15", "right": "-4", "value": -5},
    {"id": "-4", "left": null, "right": "-2", "value": -4},
    {"id": "-2", "left": null, "right": "-1", "value": -2},
    {"id": "-1", "left": null, "right": null, "value": -1},
    {"id": "-15", "left": "-22", "right": null, "value": -15},
    {"id": "-22", "left": null, "right": null, "value": -22}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "5", "right": "15", "value": 10},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "5", "left": "2", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": "-5", "right": null, "value": 1},
    {"id": "-5", "left": "-15", "right": "-4", "value": -5},
    {"id": "-4", "left": null, "right": "-2", "value": -4},
    {"id": "-2", "left": null, "right": "-1", "value": -2},
    {"id": "-1", "left": null, "right": null, "value": -1},
    {"id": "-15", "left": "-22", "right": null, "value": -15},
    {"id": "-22", "left": null, "right": null, "value": -22}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "10", "left": "-5", "right": "15", "value": 10},
      {"id": "15", "left": null, "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "-5", "left": "2", "right": "6", "value": -5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": "5", "right": null, "value": 1},
      {"id": "5", "left": "-15", "right": "-4", "value": 5},
      {"id": "-4", "left": null, "right": "-2", "value": -4},
      {"id": "-2", "left": null, "right": "-1", "value": -2},
      {"id": "-1", "left": null, "right": null, "value": -1},
      {"id": "-15", "left": "-22", "right": null, "value": -15},
      {"id": "-22", "left": null, "right": null, "value": -22}
    ],
    "root": "10"
  }
}
Test Case 8 passed!
Expected Output
{
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
    {"id": "5", "left": "2", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
Your Code's Output
{
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
    {"id": "5", "left": "2", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": null, "value": 6},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "1", "left": "5", "right": "15", "value": 1},
      {"id": "15", "left": null, "right": "22", "value": 15},
      {"id": "22", "left": null, "right": "500", "value": 22},
      {"id": "500", "left": "50", "right": "1500", "value": 500},
      {"id": "1500", "left": null, "right": "10000", "value": 1500},
      {"id": "10000", "left": "2200", "right": null, "value": 10000},
      {"id": "2200", "left": null, "right": null, "value": 2200},
      {"id": "50", "left": null, "right": "200", "value": 50},
      {"id": "200", "left": null, "right": null, "value": 200},
      {"id": "5", "left": "2", "right": "6", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "2", "left": "10", "right": null, "value": 2},
      {"id": "10", "left": null, "right": null, "value": 10}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
{
  "nodes": [
    {"id": "5000", "left": "5", "right": "55000", "value": 5000},
    {"id": "55000", "left": null, "right": null, "value": 55000},
    {"id": "5", "left": "2", "right": "15", "value": 5},
    {"id": "15", "left": "14", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": "502", "value": 22},
    {"id": "502", "left": "204", "right": null, "value": 502},
    {"id": "204", "left": "203", "right": "205", "value": 204},
    {"id": "205", "left": null, "right": "207", "value": 205},
    {"id": "207", "left": "206", "right": "208", "value": 207},
    {"id": "208", "left": null, "right": null, "value": 208},
    {"id": "206", "left": null, "right": null, "value": 206},
    {"id": "203", "left": null, "right": null, "value": 203},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "2", "left": "-3", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "-3", "left": null, "right": "-2", "value": -3},
... 
Your Code's Output
{
  "nodes": [
    {"id": "5000", "left": "5", "right": "55000", "value": 5000},
    {"id": "55000", "left": null, "right": null, "value": 55000},
    {"id": "5", "left": "2", "right": "15", "value": 5},
    {"id": "15", "left": "14", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": "502", "value": 22},
    {"id": "502", "left": "204", "right": null, "value": 502},
    {"id": "204", "left": "203", "right": "205", "value": 204},
    {"id": "205", "left": null, "right": "207", "value": 205},
    {"id": "207", "left": "206", "right": "208", "value": 207},
    {"id": "208", "left": null, "right": null, "value": 208},
    {"id": "206", "left": null, "right": null, "value": 206},
    {"id": "203", "left": null, "right": null, "value": 203},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "2", "left": "-3", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "-3", "left": null, "right": "-2", "value": -3},
... 
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "5000", "left": "5", "right": "55000", "value": 5000},
      {"id": "55000", "left": null, "right": null, "value": 55000},
      {"id": "5", "left": "2", "right": "15", "value": 5},
      {"id": "15", "left": "14", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": "502", "value": 22},
      {"id": "502", "left": "1", "right": null, "value": 502},
      {"id": "1", "left": "203", "right": "205", "value": 1},
      {"id": "205", "left": null, "right": "207", "value": 205},
      {"id": "207", "left": "206", "right": "208", "value": 207},
      {"id": "208", "left": null, "right": null, "value": 208},
      {"id": "206", "left": null, "right": null, "value": 206},
      {"id": "203", "left": null, "right": null, "value": 203},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "2", "left": "-3", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "-3", "left": null, "right": "-2", "value": -3},
      {"id": "-2", "left": null, "right": "-1", "value": -2},
      {"id": "-1", "left": null, "right": "204", "value": -1},
      {"id": "204", "left": null, "right": null, "value": 204}
    ],
    "root": "5000"
  }
}
Test Case 10 passed!
Expected Output
{
  "nodes": [
    {"id": "5000", "left": "8", "right": "55000", "value": 5000},
    {"id": "55000", "left": null, "right": null, "value": 55000},
    {"id": "8", "left": "6", "right": "15", "value": 8},
    {"id": "15", "left": "10", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": "502", "value": 22},
    {"id": "502", "left": "204", "right": null, "value": 502},
    {"id": "204", "left": "203", "right": "205", "value": 204},
    {"id": "205", "left": null, "right": "207", "value": 205},
    {"id": "207", "left": "206", "right": "208", "value": 207},
    {"id": "208", "left": null, "right": null, "value": 208},
    {"id": "206", "left": null, "right": null, "value": 206},
    {"id": "203", "left": null, "right": null, "value": 203},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "6", "left": "1", "right": "7", "value": 6},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    ... 
Your Code's Output
{
  "nodes": [
    {"id": "5000", "left": "8", "right": "55000", "value": 5000},
    {"id": "55000", "left": null, "right": null, "value": 55000},
    {"id": "8", "left": "6", "right": "15", "value": 8},
    {"id": "15", "left": "10", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": "502", "value": 22},
    {"id": "502", "left": "204", "right": null, "value": 502},
    {"id": "204", "left": "203", "right": "205", "value": 204},
    {"id": "205", "left": null, "right": "207", "value": 205},
    {"id": "207", "left": "206", "right": "208", "value": 207},
    {"id": "208", "left": null, "right": null, "value": 208},
    {"id": "206", "left": null, "right": null, "value": 206},
    {"id": "203", "left": null, "right": null, "value": 203},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "6", "left": "1", "right": "7", "value": 6},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    ... 
View Outputs Side By Side
Input(s)
{
  "tree": {
    "nodes": [
      {"id": "5000", "left": "8", "right": "203", "value": 5000},
      {"id": "203", "left": null, "right": null, "value": 203},
      {"id": "8", "left": "6", "right": "15", "value": 8},
      {"id": "15", "left": "10", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": "502", "value": 22},
      {"id": "502", "left": "204", "right": null, "value": 502},
      {"id": "204", "left": "55000", "right": "205", "value": 204},
      {"id": "205", "left": null, "right": "207", "value": 205},
      {"id": "207", "left": "206", "right": "208", "value": 207},
      {"id": "208", "left": null, "right": null, "value": 208},
      {"id": "206", "left": null, "right": null, "value": 206},
      {"id": "55000", "left": null, "right": null, "value": 55000},
      {"id": "10", "left": null, "right": null, "value": 10},
      {"id": "6", "left": "1", "right": "7", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5}
    ],
    "root": "5000"
  }
}
 
 */