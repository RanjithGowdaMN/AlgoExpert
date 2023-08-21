using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._02_Hard
{
    internal class ValidateThreeNodesProgram
    {
        //O(d) | O(1)
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

        public bool ValidateThreeNodes(BST nodeOne, BST nodeTwo, BST nodeThree)
        {
            // Write your code here.
            BST searchOne = nodeOne;
            BST searchTwo = nodeThree;

            while (true)
            {
                bool foundThreeFromOne = searchOne == nodeThree;
                bool foundOneFromThree = searchTwo == nodeOne;
                bool foundNodeTwo = (searchOne == nodeTwo) || (searchTwo == nodeTwo);
                bool finishedSearching = (searchOne == null) && (searchTwo == null);
                if (foundThreeFromOne || foundOneFromThree || foundNodeTwo || finishedSearching)
                {
                    break;
                }
                if (searchOne != null)
                {
                    searchOne =
                        (searchOne.value > nodeTwo.value) ? searchOne.left : searchOne.right;
                }
                if (searchTwo != null)
                {
                    searchTwo =
                        (searchTwo.value > nodeTwo.value) ? searchTwo.left : searchTwo.right;
                }
            }
            bool foundNodeFromOther =
                (searchOne == nodeThree) || (searchTwo == nodeOne);
            bool foundNodeTwoFinal = (searchOne == nodeTwo) || (searchTwo == nodeTwo);
            if (!foundNodeTwoFinal || foundNodeFromOther)
            {
                return false;
            }

            return searchForTarget(
                nodeTwo, (searchOne == nodeTwo) ? nodeThree : nodeOne
            );
        }
        public bool searchForTarget(BST node, BST target)
        {
            while (node != null && node != target)
            {
                node = (target.value < node.value) ? node.left : node.right;
            }
            return node == target;
        }
    }
}
/*
 _______________________________________________________________________________________________________________
public class BST {
    public int value;
    public BST left = null;
    public BST right = null;

    public BST(int value) {
      this.value = value;
    }
  }
    //O(h) time || O(1) space
  public bool ValidateThreeNodes(BST nodeOne, BST nodeTwo, BST nodeThree) {
    // Write your code here.
    if(isDescendant(nodeTwo, nodeOne)){
          return isDescendant(nodeThree, nodeTwo);
      }
    if(isDescendant(nodeTwo, nodeThree)){
          return isDescendant(nodeOne, nodeTwo);
      }
    return false;
  }
    public bool isDescendant(BST node, BST target){
        while(node != null && node!= target){
            node = (target.value < node.value) ? node.left : node.right;
        }
        return node == target;
    }


_______________________________________________________________________________________________________________
 
  public class BST {
    public int value;
    public BST left = null;
    public BST right = null;

    public BST(int value) {
      this.value = value;
    }
  }
//O(h) time || O(h) space
  public bool ValidateThreeNodes(BST nodeOne, BST nodeTwo, BST nodeThree) {
    // Write your code here.
      if(isDescendant(nodeTwo, nodeOne)){
          return isDescendant(nodeThree, nodeTwo);
      }
    if(isDescendant(nodeTwo, nodeThree)){
          return isDescendant(nodeOne, nodeTwo);
      }
      
    return false;
  }
    public bool isDescendant(BST node, BST target){
        if(node==null){
            return false;
        }
        if(node==target){
            return true;
        }

        return (target.value < node.value) ? isDescendant(node.left, target) : isDescendant(node.right, target);
    }
 
 --------------------------------------------------------------------------------
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var root = new Program.BST(5);
    root.left = new Program.BST(2);
    root.right = new Program.BST(7);
    root.left.left = new Program.BST(1);
    root.left.right = new Program.BST(4);
    root.right.left = new Program.BST(6);
    root.right.right = new Program.BST(8);
    root.left.left.left = new Program.BST(0);
    root.left.right.left = new Program.BST(3);

    var nodeOne = root;
    var nodeTwo = root.left;
    var nodeThree = root.left.right.left;
    bool expected = true;
    bool actual = new Program().ValidateThreeNodes(nodeOne, nodeTwo, nodeThree);
    Utils.AssertTrue(expected == actual);
  }
}

15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nodeOne": "5",
  "nodeThree": "3",
  "nodeTwo": "2",
  "tree": {
    "nodes": [
      {"id": "0", "left": null, "right": null, "value": 0},
      {"id": "1", "left": "0", "right": null, "value": 1},
      {"id": "2", "left": "1", "right": "4", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "4", "left": "3", "right": null, "value": 4},
      {"id": "5", "left": "2", "right": "7", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": "6", "right": "8", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "5"
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
  "nodeOne": "5",
  "nodeThree": "1",
  "nodeTwo": "8",
  "tree": {
    "nodes": [
      {"id": "0", "left": null, "right": null, "value": 0},
      {"id": "1", "left": "0", "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "3", "right": "7", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": "6", "right": "8", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "5"
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
  "nodeOne": "8",
  "nodeThree": "2",
  "nodeTwo": "5",
  "tree": {
    "nodes": [
      {"id": "0", "left": null, "right": null, "value": 0},
      {"id": "1", "left": "0", "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "3", "right": "7", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": "6", "right": "8", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "5"
  }
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nodeOne": "2",
  "nodeThree": "8",
  "nodeTwo": "5",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": "5", "value": 4},
      {"id": "5", "left": null, "right": "6", "value": 5},
      {"id": "6", "left": null, "right": "7", "value": 6},
      {"id": "7", "left": null, "right": "8", "value": 7},
      {"id": "8", "left": null, "right": "9", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "2"
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
  "nodeOne": "4",
  "nodeThree": "2",
  "nodeTwo": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": "1", "right": null, "value": 3},
      {"id": "4", "left": "3", "right": null, "value": 4},
      {"id": "5", "left": null, "right": "5", "value": 5},
      {"id": "6", "left": "4", "right": "8", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": "7", "right": "9", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "6"
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
  "nodeOne": "1",
  "nodeThree": "3",
  "nodeTwo": "2",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4}
    ],
    "root": "2"
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
  "nodeOne": "2",
  "nodeThree": "13",
  "nodeTwo": "4",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": null, "value": 3},
      {"id": "4", "left": "3", "right": "5", "value": 4},
      {"id": "5", "left": null, "right": "7", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": "6", "right": null, "value": 7},
      {"id": "8", "left": "4", "right": "10", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": "9", "right": "14", "value": 10},
      {"id": "11", "left": null, "right": null, "value": 11},
      {"id": "12", "left": "11", "right": "13", "value": 12},
      {"id": "13", "left": null, "right": null, "value": 13},
      {"id": "14", "left": "12", "right": null, "value": 14}
    ],
    "root": "8"
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
  "nodeOne": "8",
  "nodeThree": "1",
  "nodeTwo": "7",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": null, "value": 3},
      {"id": "4", "left": "3", "right": null, "value": 4},
      {"id": "5", "left": "4", "right": null, "value": 5},
      {"id": "6", "left": "5", "right": null, "value": 6},
      {"id": "7", "left": "6", "right": null, "value": 7},
      {"id": "8", "left": "7", "right": "9", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "8"
  }
}
Test Case 9 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nodeOne": "2",
  "nodeThree": "3",
  "nodeTwo": "1",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": null, "value": 3}
    ],
    "root": "3"
  }
}
Test Case 10 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nodeOne": "1",
  "nodeThree": "3",
  "nodeTwo": "2",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": null, "value": 3}
    ],
    "root": "3"
  }
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nodeOne": "9",
  "nodeThree": "6",
  "nodeTwo": "8",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": null, "value": 1},
      {"id": "2", "left": "1", "right": "3", "value": 2},
      {"id": "3", "left": null, "right": null, "value": 3},
      {"id": "4", "left": "2", "right": "5", "value": 4},
      {"id": "5", "left": null, "right": null, "value": 5},
      {"id": "6", "left": "4", "right": "8", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": "7", "right": "9", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9}
    ],
    "root": "6"
  }
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nodeOne": "12",
  "nodeThree": "15",
  "nodeTwo": "13",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": "1", "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "3", "right": null, "value": 5},
      {"id": "6", "left": "5", "right": "8", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": "7", "right": "9", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": "6", "right": "15", "value": 10},
      {"id": "11", "left": null, "right": "12", "value": 11},
      {"id": "12", "left": null, "right": null, "value": 12},
      {"id": "13", "left": "11", "right": null, "value": 13},
      {"id": "14", "left": "13", "right": null, "value": 14},
      {"id": "15", "left": "14", "right": "18", "value": 15},
      {"id": "16", "left": null, "right": null, "value": 16},
      {"id": "17", "left": "16", "right": null, "value": 17},
      {"id": "18", "left": "17", "right": null, "value": 18}
    ],
    "root": "10"
  }
}
Test Case 13 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nodeOne": "5",
  "nodeThree": "15",
  "nodeTwo": "10",
  "tree": {
    "nodes": [
      {"id": "1", "left": null, "right": "2", "value": 1},
      {"id": "2", "left": null, "right": null, "value": 2},
      {"id": "3", "left": "1", "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "3", "right": null, "value": 5},
      {"id": "6", "left": "5", "right": "8", "value": 6},
      {"id": "7", "left": null, "right": null, "value": 7},
      {"id": "8", "left": "7", "right": "9", "value": 8},
      {"id": "9", "left": null, "right": null, "value": 9},
      {"id": "10", "left": "6", "right": "15", "value": 10},
      {"id": "11", "left": null, "right": "12", "value": 11},
      {"id": "12", "left": null, "right": null, "value": 12},
      {"id": "13", "left": "11", "right": null, "value": 13},
      {"id": "14", "left": "13", "right": null, "value": 14},
      {"id": "15", "left": "14", "right": "18", "value": 15},
      {"id": "16", "left": null, "right": null, "value": 16},
      {"id": "17", "left": "16", "right": null, "value": 17},
      {"id": "18", "left": "17", "right": null, "value": 18}
    ],
    "root": "10"
  }
}
Test Case 14 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nodeOne": "5",
  "nodeThree": "4",
  "nodeTwo": "3",
  "tree": {
    "nodes": [
      {"id": "0", "left": null, "right": null, "value": 0},
      {"id": "1", "left": "0", "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "3", "right": "7", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": "6", "right": "8", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "5"
  }
}
Test Case 15 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nodeOne": "5",
  "nodeThree": "1",
  "nodeTwo": "3",
  "tree": {
    "nodes": [
      {"id": "0", "left": null, "right": null, "value": 0},
      {"id": "1", "left": "0", "right": null, "value": 1},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "3", "left": "2", "right": "4", "value": 3},
      {"id": "4", "left": null, "right": null, "value": 4},
      {"id": "5", "left": "3", "right": "7", "value": 5},
      {"id": "6", "left": null, "right": null, "value": 6},
      {"id": "7", "left": "6", "right": "8", "value": 7},
      {"id": "8", "left": null, "right": null, "value": 8}
    ],
    "root": "5"
  }
}

 */