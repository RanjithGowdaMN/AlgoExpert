using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees._01_Medium
{
    internal class FindSuccessorProgram
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;
            public BinaryTree parent = null;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }

        public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
        {
            // Write your code here.
            List<BinaryTree> inOrderTraversalOrder = new List<BinaryTree>();
            getInOrderTraversalOrder(tree, inOrderTraversalOrder);

            for (int i = 0; i < inOrderTraversalOrder.Count; i++)
            {
                BinaryTree currentNode = inOrderTraversalOrder[i];
                if (currentNode != node)
                {
                    continue;
                }

                if (i == inOrderTraversalOrder.Count - 1)
                {
                    return null;
                }
                return inOrderTraversalOrder[i + 1];
            }
            return null;
        }
        void getInOrderTraversalOrder(BinaryTree node, List<BinaryTree> order)
        {
            if (node == null)
            {
                return;
            }
            getInOrderTraversalOrder(node.left, order);
            order.Add(node);
            getInOrderTraversalOrder(node.right, order);
        }
    }
}
/*
  public class BinaryTree {
    public int value;
    public BinaryTree left = null;
    public BinaryTree right = null;
    public BinaryTree parent = null;

    public BinaryTree(int value) {
      this.value = value;
    }
  }

  public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node) {
    // Write your code here.
      if(node.right != null) return getLeftmostChild(node.right);
    return getRightmostParent(node);
  }
    public BinaryTree getLeftmostChild(BinaryTree node){
        BinaryTree currentNode = node;
        while(currentNode.left != null){
            currentNode = currentNode.left;
        }
        return currentNode;
    }
    public BinaryTree getRightmostParent(BinaryTree node){
        BinaryTree currentNode = node;
        while(currentNode.parent != null && currentNode.parent.right == currentNode){
            currentNode = currentNode.parent;
        }
        return currentNode.parent;
    } 


using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.BinaryTree root = new Program.BinaryTree(1);
    root.left = new Program.BinaryTree(2);
    root.left.parent = root;
    root.right = new Program.BinaryTree(3);
    root.right.parent = root;
    root.left.left = new Program.BinaryTree(4);
    root.left.left.parent = root.left;
    root.left.right = new Program.BinaryTree(5);
    root.left.right.parent = root.left;
    root.left.left.left = new Program.BinaryTree(6);
    root.left.left.left.parent = root.left.left;
    Program.BinaryTree node = root.left.right;
    Program.BinaryTree expected = root;
    Program.BinaryTree actual = new Program().FindSuccessor(root, node);
    Utils.AssertEquals(expected, actual);
  }
}


12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodeId": "1"
}
Your Code's Output
{
  "nodeId": "1"
}
View Outputs Side By Side
Input(s)
{
  "node": "5",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": "3", "value": 1},
      {"id": "2", "left": "4", "parent": "1", "right": "5", "value": 2},
      {"id": "3", "left": null, "parent": "1", "right": null, "value": 3},
      {"id": "4", "left": "6", "parent": "2", "right": null, "value": 4},
      {"id": "5", "left": null, "parent": "2", "right": null, "value": 5},
      {"id": "6", "left": null, "parent": "4", "right": null, "value": 6}
    ],
    "root": "1"
  }
}
Test Case 2 passed!
Expected Output
{
  "nodeId": "8"
}
Your Code's Output
{
  "nodeId": "8"
}
View Outputs Side By Side
Input(s)
{
  "node": "5",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": "3", "value": 1},
      {"id": "2", "left": "4", "parent": "1", "right": "5", "value": 2},
      {"id": "3", "left": null, "parent": "1", "right": null, "value": 3},
      {"id": "4", "left": null, "parent": "2", "right": null, "value": 4},
      {"id": "5", "left": "6", "parent": "2", "right": "7", "value": 5},
      {"id": "6", "left": null, "parent": "5", "right": null, "value": 6},
      {"id": "7", "left": "8", "parent": "5", "right": null, "value": 7},
      {"id": "8", "left": null, "parent": "7", "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 3 passed!
Expected Output
{
  "nodeId": "3"
}
Your Code's Output
{
  "nodeId": "3"
}
View Outputs Side By Side
Input(s)
{
  "node": "6",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": "3", "value": 1},
      {"id": "2", "left": "4", "parent": "1", "right": "5", "value": 2},
      {"id": "3", "left": "6", "parent": "1", "right": "7", "value": 3},
      {"id": "4", "left": null, "parent": "2", "right": null, "value": 4},
      {"id": "5", "left": null, "parent": "2", "right": null, "value": 5},
      {"id": "6", "left": null, "parent": "3", "right": null, "value": 6},
      {"id": "7", "left": null, "parent": "3", "right": null, "value": 7}
    ],
    "root": "1"
  }
}
Test Case 4 passed!
Expected Output
null
Your Code's Output
null
View Outputs Side By Side
Input(s)
{
  "node": "2",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "parent": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "parent": "1", "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 5 passed!
Expected Output
{
  "nodeId": "7"
}
Your Code's Output
{
  "nodeId": "7"
}
View Outputs Side By Side
Input(s)
{
  "node": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": "3", "value": 1},
      {"id": "2", "left": null, "parent": "1", "right": null, "value": 2},
      {"id": "3", "left": "4", "parent": "1", "right": null, "value": 3},
      {"id": "4", "left": "5", "parent": "3", "right": null, "value": 4},
      {"id": "5", "left": "6", "parent": "4", "right": null, "value": 5},
      {"id": "6", "left": "7", "parent": "5", "right": null, "value": 6},
      {"id": "7", "left": null, "parent": "6", "right": null, "value": 7}
    ],
    "root": "1"
  }
}
Test Case 6 passed!
Expected Output
{
  "nodeId": "2"
}
Your Code's Output
{
  "nodeId": "2"
}
View Outputs Side By Side
Input(s)
{
  "node": "3",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": null, "value": 1},
      {"id": "2", "left": "3", "parent": "1", "right": null, "value": 2},
      {"id": "3", "left": "4", "parent": "2", "right": null, "value": 3},
      {"id": "4", "left": "5", "parent": "3", "right": null, "value": 4},
      {"id": "5", "left": null, "parent": "4", "right": null, "value": 5}
    ],
    "root": "1"
  }
}
Test Case 7 passed!
Expected Output
{
  "nodeId": "7"
}
Your Code's Output
{
  "nodeId": "7"
}
View Outputs Side By Side
Input(s)
{
  "node": "2",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": null, "value": 1},
      {"id": "2", "left": "3", "parent": "1", "right": "6", "value": 2},
      {"id": "3", "left": "4", "parent": "2", "right": null, "value": 3},
      {"id": "4", "left": "5", "parent": "3", "right": null, "value": 4},
      {"id": "5", "left": null, "parent": "4", "right": null, "value": 5},
      {"id": "6", "left": "7", "parent": "2", "right": "8", "value": 6},
      {"id": "7", "left": null, "parent": "6", "right": null, "value": 7},
      {"id": "8", "left": null, "parent": "6", "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 8 passed!
Expected Output
null
Your Code's Output
null
View Outputs Side By Side
Input(s)
{
  "node": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "parent": null, "right": null, "value": 1}
    ],
    "root": "1"
  }
}
Test Case 9 passed!
Expected Output
{
  "nodeId": "2"
}
Your Code's Output
{
  "nodeId": "2"
}
View Outputs Side By Side
Input(s)
{
  "node": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "parent": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "parent": "1", "right": null, "value": 2}
    ],
    "root": "1"
  }
}
Test Case 10 passed!
Expected Output
{
  "nodeId": "5"
}
Your Code's Output
{
  "nodeId": "5"
}
View Outputs Side By Side
Input(s)
{
  "node": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": "5", "value": 1},
      {"id": "2", "left": null, "parent": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "parent": "2", "right": "4", "value": 3},
      {"id": "4", "left": null, "parent": "3", "right": null, "value": 4},
      {"id": "5", "left": null, "parent": "1", "right": "6", "value": 5},
      {"id": "6", "left": "7", "parent": "5", "right": "8", "value": 6},
      {"id": "7", "left": null, "parent": "6", "right": null, "value": 7},
      {"id": "8", "left": null, "parent": "6", "right": null, "value": 8}
    ],
    "root": "1"
  }
}
Test Case 11 passed!
Expected Output
{
  "nodeId": "11"
}
Your Code's Output
{
  "nodeId": "11"
}
View Outputs Side By Side
Input(s)
{
  "node": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": "5", "value": 1},
      {"id": "2", "left": null, "parent": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "parent": "2", "right": "4", "value": 3},
      {"id": "4", "left": null, "parent": "3", "right": null, "value": 4},
      {"id": "5", "left": "9", "parent": "1", "right": "6", "value": 5},
      {"id": "6", "left": "7", "parent": "5", "right": "8", "value": 6},
      {"id": "7", "left": null, "parent": "6", "right": null, "value": 7},
      {"id": "8", "left": null, "parent": "6", "right": null, "value": 8},
      {"id": "9", "left": "10", "parent": "5", "right": null, "value": 9},
      {"id": "10", "left": "11", "parent": "9", "right": null, "value": 10},
      {"id": "11", "left": null, "parent": "10", "right": null, "value": 11}
    ],
    "root": "1"
  }
}
Test Case 12 passed!
Expected Output
{
  "nodeId": "3"
}
Your Code's Output
{
  "nodeId": "3"
}
View Outputs Side By Side
Input(s)
{
  "node": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": "2", "parent": null, "right": "3", "value": 1},
      {"id": "2", "left": "4", "parent": "1", "right": "5", "value": 2},
      {"id": "3", "left": null, "parent": "1", "right": "7", "value": 3},
      {"id": "4", "left": "6", "parent": "2", "right": null, "value": 4},
      {"id": "5", "left": null, "parent": "2", "right": null, "value": 5},
      {"id": "6", "left": null, "parent": "4", "right": null, "value": 6},
      {"id": "7", "left": null, "parent": "3", "right": "8", "value": 7},
      {"id": "8", "left": null, "parent": "7", "right": null, "value": 8}
    ],
    "root": "1"
  }
}

 */