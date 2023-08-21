using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._01_Medium
{
    class constructMinHeightBstSol1
    {
        public static BST MinHeightBst(List<int> array)
        {
            // Write your code here.
            return constructMinHeightBst(array, null, 0, array.Count - 1);
        }
        public static BST constructMinHeightBst(
            List<int> array, BST bst, int startIdx, int endIdx
        )
        {
            if (endIdx < startIdx) return null;
            int midIdx = (startIdx + endIdx) / 2;
            int valueToAdd = array[midIdx];
            if (bst == null)
            {
                bst = new BST(valueToAdd);
            }
            else
            {
                bst.insert(valueToAdd);
            }
            constructMinHeightBst(array, bst, startIdx, midIdx - 1);
            constructMinHeightBst(array, bst, midIdx + 1, endIdx);
            return bst;
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }

            public void insert(int value)
            {
                if (value < this.value)
                {
                    if (left == null)
                    {
                        left = new BST(value);
                    }
                    else
                    {
                        left.insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new BST(value);
                    }
                    else
                    {
                        right.insert(value);
                    }
                }
            }
        }
    }
}
/*
 ____________________________________________________________________________________

  public static BST MinHeightBst(List<int> array) {
    // Write your code here.
    return constructMinHeightBst(array, null, 0, array.Count-1);
  }
    public static BST constructMinHeightBst(
        List<int> array, BST bst, int startIdx, int endIdx){
        if(endIdx < startIdx) return null;
        int midIdx = (startIdx + endIdx)/2;
        BST newBstNode = new BST(array[midIdx]);
        if(bst==null){
            bst = newBstNode;
        } else {
            if(array[midIdx] < bst.value){
                bst.left = newBstNode;
                bst = bst.left;
            } else {
                bst.right = newBstNode;
                bst = bst.right;
            }
        }
        constructMinHeightBst(array, bst, startIdx, midIdx-1);
        constructMinHeightBst(array, bst, midIdx+1, endIdx);
        return bst;
                                 
    }

  public class BST {
    public int value;
    public BST left;
    public BST right;

    public BST(int value) {
      this.value = value;
      left = null;
      right = null;
    }

    public void insert(int value) {
      if (value < this.value) {
        if (left == null) {
          left = new BST(value);
        } else {
          left.insert(value);
        }
      } else {
        if (right == null) {
          right = new BST(value);
        } else {
          right.insert(value);
        }
      }
    }
  }

__________________________________________________________________________________________________

  public static BST MinHeightBst(List<int> array) {
    //Solution 3 O(n) O(n)
    return constructMinHeightBst(array, 0, array.Count-1);
  }
    public static BST constructMinHeightBst(
        List<int> array, int startIdx, int endIdx
    ){
        if(endIdx < startIdx) return null;
        int midIdx = (startIdx + endIdx)/2;
        BST bst = new BST(array[midIdx]);
        bst.left = constructMinHeightBst(array, startIdx, midIdx -1);
        bst.right = constructMinHeightBst(array, midIdx +1, endIdx);
        return bst;
    }

  public class BST {
    public int value;
    public BST left;
    public BST right;

    public BST(int value) {
      this.value = value;
      left = null;
      right = null;
    }

    public void insert(int value) {
      if (value < this.value) {
        if (left == null) {
          left = new BST(value);
        } else {
          left.insert(value);
        }
      } else {
        if (right == null) {
          right = new BST(value);
        } else {
          right.insert(value);
        }
      }
    }
  }

____________________________________________________________________________________
 using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var array = new List<int> { 1, 2, 5, 7, 10, 13, 14, 15, 22 };
    var tree = Program.MinHeightBst(array);

    Utils.AssertTrue(validateBst(tree));
    Utils.AssertEquals(4, getTreeHeight(tree));

    var inOrder = inOrderTraverse(tree, new List<int> {});
    var expected = new List<int> { 1, 2, 5, 7, 10, 13, 14, 15, 22 };
    Utils.AssertTrue(Enumerable.SequenceEqual(inOrder, expected));
  }

  static bool validateBst(Program.BST tree) {
    return validateBst(tree, Int32.MinValue, Int32.MaxValue);
  }

  static bool validateBst(Program.BST tree, int minValue, int maxValue) {
    if (tree.value < minValue || tree.value >= maxValue) {
      return false;
    }
    if (tree.left != null && !validateBst(tree.left, minValue, tree.value)) {
      return false;
    }
    if (tree.right != null && !validateBst(tree.right, tree.value, maxValue)) {
      return false;
    }
    return true;
  }

  static List<int> inOrderTraverse(Program.BST tree, List<int> array) {
    if (tree.left != null) {
      inOrderTraverse(tree.left, array);
    }
    array.Add(tree.value);
    if (tree.right != null) {
      inOrderTraverse(tree.right, array);
    }
    return array;
  }

  static int getTreeHeight(Program.BST tree) {
    return getTreeHeight(tree, 0);
  }

  static int getTreeHeight(Program.BST tree, int height) {
    if (tree == null) return height;
    int leftTreeHeight = getTreeHeight(tree.left, height + 1);
    int rightTreeHeight = getTreeHeight(tree.right, height + 1);
    return Math.Max(leftTreeHeight, rightTreeHeight);
  }
}

17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "2", "right": "14", "value": 10},
    {"id": "14", "left": "13", "right": "15", "value": 14},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "2", "right": "14", "value": 10},
    {"id": "14", "left": "13", "right": "15", "value": 14},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22]
}
Test Case 2 passed!
Expected Output
{
  "nodes": [
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "1"
}
Your Code's Output
{
  "nodes": [
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "1"
}
View Outputs Side By Side
Input(s)
{
  "array": [1]
}
Test Case 3 passed!
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
  "array": [1, 2]
}
Test Case 4 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5]
}
Test Case 5 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7]
}
Test Case 6 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "1", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "10", "value": 7},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "1", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "10", "value": 7},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10]
}
Test Case 7 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "1", "right": "10", "value": 5},
    {"id": "10", "left": "7", "right": "13", "value": 10},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "1", "right": "10", "value": 5},
    {"id": "10", "left": "7", "right": "13", "value": 10},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13]
}
Test Case 8 passed!
Expected Output
{
  "nodes": [
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "7"
}
Your Code's Output
{
  "nodes": [
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "7"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14]
}
Test Case 9 passed!
Expected Output
{
  "nodes": [
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "7"
}
Your Code's Output
{
  "nodes": [
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "7"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15]
}
Test Case 10 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "2", "right": "14", "value": 10},
    {"id": "14", "left": "13", "right": "15", "value": 14},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "2", "right": "14", "value": 10},
    {"id": "14", "left": "13", "right": "15", "value": 14},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22]
}
Test Case 11 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "2", "right": "15", "value": 10},
    {"id": "15", "left": "13", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": "28", "value": 22},
    {"id": "28", "left": null, "right": null, "value": 28},
    {"id": "13", "left": null, "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "2", "right": "15", "value": 10},
    {"id": "15", "left": "13", "right": "22", "value": 15},
    {"id": "22", "left": null, "right": "28", "value": 22},
    {"id": "28", "left": null, "right": null, "value": 28},
    {"id": "13", "left": null, "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": "7", "value": 5},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22, 28]
}
Test Case 12 passed!
Expected Output
{
  "nodes": [
    {"id": "13", "left": "5", "right": "22", "value": 13},
    {"id": "22", "left": "14", "right": "28", "value": 22},
    {"id": "28", "left": null, "right": "32", "value": 28},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "5", "left": "1", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "10", "value": 7},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "13"
}
Your Code's Output
{
  "nodes": [
    {"id": "13", "left": "5", "right": "22", "value": 13},
    {"id": "22", "left": "14", "right": "28", "value": 22},
    {"id": "28", "left": null, "right": "32", "value": 28},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "5", "left": "1", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "10", "value": 7},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "13"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22, 28, 32]
}
Test Case 13 passed!
Expected Output
{
  "nodes": [
    {"id": "13", "left": "5", "right": "22", "value": 13},
    {"id": "22", "left": "14", "right": "32", "value": 22},
    {"id": "32", "left": "28", "right": "36", "value": 32},
    {"id": "36", "left": null, "right": null, "value": 36},
    {"id": "28", "left": null, "right": null, "value": 28},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "5", "left": "1", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "10", "value": 7},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "13"
}
Your Code's Output
{
  "nodes": [
    {"id": "13", "left": "5", "right": "22", "value": 13},
    {"id": "22", "left": "14", "right": "32", "value": 22},
    {"id": "32", "left": "28", "right": "36", "value": 32},
    {"id": "36", "left": null, "right": null, "value": 36},
    {"id": "28", "left": null, "right": null, "value": 28},
    {"id": "14", "left": null, "right": "15", "value": 14},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "5", "left": "1", "right": "7", "value": 5},
    {"id": "7", "left": null, "right": "10", "value": 7},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "13"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22, 28, 32, 36]
}
Test Case 14 passed!
Expected Output
{
  "nodes": [
    {"id": "14", "left": "5", "right": "28", "value": 14},
    {"id": "28", "left": "15", "right": "36", "value": 28},
    {"id": "36", "left": "32", "right": "89", "value": 36},
    {"id": "89", "left": null, "right": null, "value": 89},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "5", "left": "1", "right": "10", "value": 5},
    {"id": "10", "left": "7", "right": "13", "value": 10},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "14"
}
Your Code's Output
{
  "nodes": [
    {"id": "14", "left": "5", "right": "28", "value": 14},
    {"id": "28", "left": "15", "right": "36", "value": 28},
    {"id": "36", "left": "32", "right": "89", "value": 36},
    {"id": "89", "left": null, "right": null, "value": 89},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "15", "left": null, "right": "22", "value": 15},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "5", "left": "1", "right": "10", "value": 5},
    {"id": "10", "left": "7", "right": "13", "value": 10},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "14"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22, 28, 32, 36, 89]
}
Test Case 15 passed!
Expected Output
{
  "nodes": [
    {"id": "14", "left": "5", "right": "32", "value": 14},
    {"id": "32", "left": "22", "right": "89", "value": 32},
    {"id": "89", "left": "36", "right": "92", "value": 89},
    {"id": "92", "left": null, "right": null, "value": 92},
    {"id": "36", "left": null, "right": null, "value": 36},
    {"id": "22", "left": "15", "right": "28", "value": 22},
    {"id": "28", "left": null, "right": null, "value": 28},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "5", "left": "1", "right": "10", "value": 5},
    {"id": "10", "left": "7", "right": "13", "value": 10},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "14"
}
Your Code's Output
{
  "nodes": [
    {"id": "14", "left": "5", "right": "32", "value": 14},
    {"id": "32", "left": "22", "right": "89", "value": 32},
    {"id": "89", "left": "36", "right": "92", "value": 89},
    {"id": "92", "left": null, "right": null, "value": 92},
    {"id": "36", "left": null, "right": null, "value": 36},
    {"id": "22", "left": "15", "right": "28", "value": 22},
    {"id": "28", "left": null, "right": null, "value": 28},
    {"id": "15", "left": null, "right": null, "value": 15},
    {"id": "5", "left": "1", "right": "10", "value": 5},
    {"id": "10", "left": "7", "right": "13", "value": 10},
    {"id": "13", "left": null, "right": null, "value": 13},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "1", "left": null, "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2}
  ],
  "root": "14"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22, 28, 32, 36, 89, 92]
}
Test Case 16 passed!
Expected Output
{
  "nodes": [
    {"id": "15", "left": "7", "right": "36", "value": 15},
    {"id": "36", "left": "28", "right": "92", "value": 36},
    {"id": "92", "left": "89", "right": "9000", "value": 92},
    {"id": "9000", "left": null, "right": null, "value": 9000},
    {"id": "89", "left": null, "right": null, "value": 89},
    {"id": "28", "left": "22", "right": "32", "value": 28},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "15"
}
Your Code's Output
{
  "nodes": [
    {"id": "15", "left": "7", "right": "36", "value": 15},
    {"id": "36", "left": "28", "right": "92", "value": 36},
    {"id": "92", "left": "89", "right": "9000", "value": 92},
    {"id": "9000", "left": null, "right": null, "value": 9000},
    {"id": "89", "left": null, "right": null, "value": 89},
    {"id": "28", "left": "22", "right": "32", "value": 28},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "15"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22, 28, 32, 36, 89, 92, 9000]
}
Test Case 17 passed!
Expected Output
{
  "nodes": [
    {"id": "15", "left": "7", "right": "36", "value": 15},
    {"id": "36", "left": "28", "right": "92", "value": 36},
    {"id": "92", "left": "89", "right": "9000", "value": 92},
    {"id": "9000", "left": null, "right": "9001", "value": 9000},
    {"id": "9001", "left": null, "right": null, "value": 9001},
    {"id": "89", "left": null, "right": null, "value": 89},
    {"id": "28", "left": "22", "right": "32", "value": 28},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "15"
}
Your Code's Output
{
  "nodes": [
    {"id": "15", "left": "7", "right": "36", "value": 15},
    {"id": "36", "left": "28", "right": "92", "value": 36},
    {"id": "92", "left": "89", "right": "9000", "value": 92},
    {"id": "9000", "left": null, "right": "9001", "value": 9000},
    {"id": "9001", "left": null, "right": null, "value": 9001},
    {"id": "89", "left": null, "right": null, "value": 89},
    {"id": "28", "left": "22", "right": "32", "value": 28},
    {"id": "32", "left": null, "right": null, "value": 32},
    {"id": "22", "left": null, "right": null, "value": 22},
    {"id": "7", "left": "2", "right": "13", "value": 7},
    {"id": "13", "left": "10", "right": "14", "value": 13},
    {"id": "14", "left": null, "right": null, "value": 14},
    {"id": "10", "left": null, "right": null, "value": 10},
    {"id": "2", "left": "1", "right": "5", "value": 2},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "15"
}
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 5, 7, 10, 13, 14, 15, 22, 28, 32, 36, 89, 92, 9000, 9001]
}

 
 */