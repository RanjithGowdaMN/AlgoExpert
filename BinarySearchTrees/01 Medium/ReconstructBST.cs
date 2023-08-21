using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._01_Medium
{
    internal class ReconstructBSTProgram
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

        public BST ReconstructBst(List<int> preOrderTraversalValues)
        {
            // Write your code here.
            if (preOrderTraversalValues.Count == 0)
            {
                return null;
            }
            int currentValue = preOrderTraversalValues[0];
            int rightSubtreeRootIdx = preOrderTraversalValues.Count;

            for (int idx = 1; idx < preOrderTraversalValues.Count; idx++)
            {
                int value = preOrderTraversalValues[idx];
                if (value >= currentValue)
                {
                    rightSubtreeRootIdx = idx;
                    break;
                }
            }

            BST leftSubtree = ReconstructBst(
                preOrderTraversalValues.GetRange(1, rightSubtreeRootIdx - 1));

            BST rightSubtree = ReconstructBst(
                preOrderTraversalValues.GetRange(rightSubtreeRootIdx, preOrderTraversalValues.Count - rightSubtreeRootIdx));
            BST bst = new BST(currentValue);
            bst.left = leftSubtree;
            bst.right = rightSubtree;

            return bst;
        }
    }
}
/*
 
 -------------------------------------------------------------------------------------
  public class BST {
    public int value;
    public BST left = null;
    public BST right = null;

    public BST(int value) {
      this.value = value;
    }
  }

    public class TreeInfo{
        public int rootIdx;
        public TreeInfo(int rootIdx){
            this.rootIdx = rootIdx;
        }
    }
  public BST ReconstructBst(List<int> preOrderTraversalValues) {
    // Write your code here.
      TreeInfo treeInfo = new TreeInfo(0);
      return ReconstructBstFromRange(
          Int32.MinValue, Int32.MaxValue, preOrderTraversalValues, treeInfo
      );
  }
    public BST ReconstructBstFromRange(
        int lowerBound,
        int upperBound,
        List<int> preOrderTraversalValues,
        TreeInfo currentSubtreeInfo
    ){
        if(currentSubtreeInfo.rootIdx == preOrderTraversalValues.Count){
            return null;
        }
        int rootValue = preOrderTraversalValues[currentSubtreeInfo.rootIdx];
        if(rootValue < lowerBound || rootValue >= upperBound){
            return null;
        }
        currentSubtreeInfo.rootIdx +=1;
        BST leftSubtree = ReconstructBstFromRange(
            lowerBound, rootValue, preOrderTraversalValues, currentSubtreeInfo
        );
        BST rightSubtree = ReconstructBstFromRange(
            rootValue, upperBound, preOrderTraversalValues, currentSubtreeInfo
        );
        BST bst = new BST(rootValue);
        bst.left = leftSubtree;
        bst.right = rightSubtree;
        return bst;
    }
 
 -------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  public List<int> getDfsOrder(Program.BST node, List<int> values) {
    values.Add(node.value);
    if (node.left != null) {
      getDfsOrder(node.left, values);
    }
    if (node.right != null) {
      getDfsOrder(node.right, values);
    }
    return values;
  }

  [Test]
  public void TestCase1() {
    List<int> preOrderTraversalValues =
      new List<int> { 10, 4, 2, 1, 3, 17, 19, 18 };
    Program.BST tree = new Program.BST(10);
    tree.left = new Program.BST(4);
    tree.left.left = new Program.BST(2);
    tree.left.left.left = new Program.BST(1);
    tree.left.right = new Program.BST(3);
    tree.right = new Program.BST(17);
    tree.right.right = new Program.BST(19);
    tree.right.right.left = new Program.BST(18);
    List<int> expected = getDfsOrder(tree, new List<int>());
    var actual = new Program().ReconstructBst(preOrderTraversalValues);
    List<int> actualValues = getDfsOrder(actual, new List<int>());
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actualValues));
  }

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "4", "right": "17", "value": 10},
    {"id": "17", "left": null, "right": "19", "value": 17},
    {"id": "19", "left": "18", "right": null, "value": 19},
    {"id": "18", "left": null, "right": null, "value": 18},
    {"id": "4", "left": "2", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "4", "right": "17", "value": 10},
    {"id": "17", "left": null, "right": "19", "value": 17},
    {"id": "19", "left": "18", "right": null, "value": 19},
    {"id": "18", "left": null, "right": null, "value": 18},
    {"id": "4", "left": "2", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": null, "value": 5},
    {"id": "2", "left": "1", "right": null, "value": 2},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [10, 4, 2, 1, 5, 17, 19, 18]
}
Test Case 2 passed!
Expected Output
{
  "nodes": [
    {"id": "100", "left": null, "right": null, "value": 100}
  ],
  "root": "100"
}
Your Code's Output
{
  "nodes": [
    {"id": "100", "left": null, "right": null, "value": 100}
  ],
  "root": "100"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [100]
}
Test Case 3 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "9", "right": null, "value": 10},
    {"id": "9", "left": "8", "right": null, "value": 9},
    {"id": "8", "left": "7", "right": null, "value": 8},
    {"id": "7", "left": "6", "right": null, "value": 7},
    {"id": "6", "left": "5", "right": null, "value": 6},
    {"id": "5", "left": null, "right": null, "value": 5}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "9", "right": null, "value": 10},
    {"id": "9", "left": "8", "right": null, "value": 9},
    {"id": "8", "left": "7", "right": null, "value": 8},
    {"id": "7", "left": "6", "right": null, "value": 7},
    {"id": "6", "left": "5", "right": null, "value": 6},
    {"id": "5", "left": null, "right": null, "value": 5}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [10, 9, 8, 7, 6, 5]
}
Test Case 4 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": null, "right": "6", "value": 5},
    {"id": "6", "left": null, "right": "7", "value": 6},
    {"id": "7", "left": null, "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": null, "right": "6", "value": 5},
    {"id": "6", "left": null, "right": "7", "value": 6},
    {"id": "7", "left": null, "right": "8", "value": 7},
    {"id": "8", "left": null, "right": null, "value": 8}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [5, 6, 7, 8]
}
Test Case 5 passed!
Expected Output
{
  "nodes": [
    {"id": "5", "left": "-10", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": "9", "value": 6},
    {"id": "9", "left": "7", "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "-10", "left": null, "right": "-5", "value": -10},
    {"id": "-5", "left": null, "right": null, "value": -5}
  ],
  "root": "5"
}
Your Code's Output
{
  "nodes": [
    {"id": "5", "left": "-10", "right": "6", "value": 5},
    {"id": "6", "left": null, "right": "9", "value": 6},
    {"id": "9", "left": "7", "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "-10", "left": null, "right": "-5", "value": -10},
    {"id": "-5", "left": null, "right": null, "value": -5}
  ],
  "root": "5"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [5, -10, -5, 6, 9, 7]
}
Test Case 6 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "4", "right": "17", "value": 10},
    {"id": "17", "left": null, "right": "19", "value": 17},
    {"id": "19", "left": "18", "right": null, "value": 19},
    {"id": "18", "left": null, "right": null, "value": 18},
    {"id": "4", "left": "2", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "6", "value": 5},
    {"id": "6", "left": null, "right": "9", "value": 6},
    {"id": "9", "left": "7", "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "4", "right": "17", "value": 10},
    {"id": "17", "left": null, "right": "19", "value": 17},
    {"id": "19", "left": "18", "right": null, "value": 19},
    {"id": "18", "left": null, "right": null, "value": 18},
    {"id": "4", "left": "2", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "6", "value": 5},
    {"id": "6", "left": null, "right": "9", "value": 6},
    {"id": "9", "left": "7", "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "10"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [10, 4, 2, 1, 3, 5, 6, 9, 7, 17, 19, 18]
}
Test Case 7 passed!
Expected Output
{
  "nodes": [
    {"id": "1", "left": "0", "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2},
    {"id": "0", "left": null, "right": null, "value": 0}
  ],
  "root": "1"
}
Your Code's Output
{
  "nodes": [
    {"id": "1", "left": "0", "right": "2", "value": 1},
    {"id": "2", "left": null, "right": null, "value": 2},
    {"id": "0", "left": null, "right": null, "value": 0}
  ],
  "root": "1"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [1, 0, 2]
}
Test Case 8 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": null, "value": 2},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": null, "value": 2},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [2, 0, 1]
}
Test Case 9 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": "4", "value": 2},
    {"id": "4", "left": "3", "right": null, "value": 4},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": "4", "value": 2},
    {"id": "4", "left": "3", "right": null, "value": 4},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [2, 0, 1, 4, 3]
}
Test Case 10 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": "4", "value": 2},
    {"id": "4", "left": "3", "right": null, "value": 4},
    {"id": "3", "left": null, "right": "3-2", "value": 3},
    {"id": "3-2", "left": null, "right": null, "value": 3},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": "4", "value": 2},
    {"id": "4", "left": "3", "right": null, "value": 4},
    {"id": "3", "left": null, "right": "3-2", "value": 3},
    {"id": "3-2", "left": null, "right": null, "value": 3},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [2, 0, 1, 4, 3, 3]
}
Test Case 11 passed!
Expected Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": "4", "value": 3},
    {"id": "4", "left": "3-2", "right": null, "value": 4},
    {"id": "3-2", "left": null, "right": null, "value": 3},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
Your Code's Output
{
  "nodes": [
    {"id": "2", "left": "0", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": "4", "value": 3},
    {"id": "4", "left": "3-2", "right": null, "value": 4},
    {"id": "3-2", "left": null, "right": null, "value": 3},
    {"id": "0", "left": null, "right": "1", "value": 0},
    {"id": "1", "left": null, "right": null, "value": 1}
  ],
  "root": "2"
}
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [2, 0, 1, 3, 4, 3]
}
Test Case 12 passed!
Expected Output
{
  "nodes": [
    {"id": "10", "left": "4", "right": "17", "value": 10},
    {"id": "17", "left": null, "right": "19", "value": 17},
    {"id": "19", "left": "18", "right": "19-2", "value": 19},
    {"id": "19-2", "left": null, "right": null, "value": 19},
    {"id": "18", "left": null, "right": "18-2", "value": 18},
    {"id": "18-2", "left": null, "right": null, "value": 18},
    {"id": "4", "left": "2", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "5-2", "value": 5},
    {"id": "5-2", "left": null, "right": "6", "value": 5},
    {"id": "6", "left": "5-3", "right": "9", "value": 6},
    {"id": "9", "left": "7", "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "5-3", "left": null, "right": "5-4", "value": 5},
    {"id": "5-4", "left": null, "right": null, "value": 5},
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "1", "left": null, "right... 
Your Code's Output
{
  "nodes": [
    {"id": "10", "left": "4", "right": "17", "value": 10},
    {"id": "17", "left": null, "right": "19", "value": 17},
    {"id": "19", "left": "18", "right": "19-2", "value": 19},
    {"id": "19-2", "left": null, "right": null, "value": 19},
    {"id": "18", "left": null, "right": "18-2", "value": 18},
    {"id": "18-2", "left": null, "right": null, "value": 18},
    {"id": "4", "left": "2", "right": "5", "value": 4},
    {"id": "5", "left": null, "right": "5-2", "value": 5},
    {"id": "5-2", "left": null, "right": "6", "value": 5},
    {"id": "6", "left": "5-3", "right": "9", "value": 6},
    {"id": "9", "left": "7", "right": null, "value": 9},
    {"id": "7", "left": null, "right": null, "value": 7},
    {"id": "5-3", "left": null, "right": "5-4", "value": 5},
    {"id": "5-4", "left": null, "right": null, "value": 5},
    {"id": "2", "left": "1", "right": "3", "value": 2},
    {"id": "3", "left": null, "right": null, "value": 3},
    {"id": "1", "left": null, "right... 
View Outputs Side By Side
Input(s)
{
  "preOrderTraversalValues": [10, 4, 2, 1, 3, 5, 5, 6, 5, 5, 9, 7, 17, 19, 18, 18, 19]
}

 */