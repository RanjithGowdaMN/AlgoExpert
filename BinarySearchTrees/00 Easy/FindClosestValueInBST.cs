using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._00_Easy
{
    public static class FindClosestValueInBSTProgram
    {
        public static void Main()
        {

        }

        public static int FindClosestValueInBst(BST tree, int target)
        {
            // Write your code here.
            return FindClosestValueInBst(tree, target, tree.value);
        }
        public static int FindClosestValueInBst(BST tree, int target, int closest)
        {
            if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
            {
                closest = tree.value;
            }
            if (target < tree.value && tree.left != null)
            {
                return FindClosestValueInBst(tree.left, target, closest);
            }
            else if (target > tree.value && tree.right != null)
            {
                return FindClosestValueInBst(tree.right, target, closest);
            }
            else
            {
                return closest;
            }
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

        public static int FindClosestValueInBstSol2(BST tree, int target, int closest)
        {
            BST currentNode = tree;
            while (currentNode != null)
            {
                if (Math.Abs(target - closest) > Math.Abs(target - currentNode.value))
                {
                    closest = currentNode.value;
                }
                if (target < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if (target > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    break;
                }
            }
            return closest;
        }

    }
}
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    var root = new Program.BST(10);
    root.left = new Program.BST(5);
    root.left.left = new Program.BST(2);
    root.left.left.left = new Program.BST(1);
    root.left.right = new Program.BST(5);
    root.right = new Program.BST(15);
    root.right.left = new Program.BST(13);
    root.right.left.right = new Program.BST(14);
    root.right.right = new Program.BST(22);

    var expected = 13;
    var actual = Program.FindClosestValueInBst(root, 12);
    Utils.AssertEquals(expected, actual);
  }
}

 
 12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "target": 12,
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": "13", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "13", "left": null, "right": "14", "value": 13},
      {"id": "14", "left": null, "right": null, "value": 14},
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
100
Your Code's Output
100
View Outputs Side By Side
Input(s)
{
  "target": 100,
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
208
Your Code's Output
208
View Outputs Side By Side
Input(s)
{
  "target": 208,
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
Test Case 4 passed!
Expected Output
4500
Your Code's Output
4500
View Outputs Side By Side
Input(s)
{
  "target": 4500,
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
Test Case 5 passed!
Expected Output
4500
Your Code's Output
4500
View Outputs Side By Side
Input(s)
{
  "target": 4501,
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
Test Case 6 passed!
Expected Output
-51
Your Code's Output
-51
View Outputs Side By Side
Input(s)
{
  "target": -70,
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
Test Case 7 passed!
Expected Output
1001
Your Code's Output
1001
View Outputs Side By Side
Input(s)
{
  "target": 2000,
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
Test Case 8 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "target": 6,
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
Test Case 9 passed!
Expected Output
55000
Your Code's Output
55000
View Outputs Side By Side
Input(s)
{
  "target": 30000,
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
Test Case 10 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "target": -1,
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
Test Case 11 passed!
Expected Output
55000
Your Code's Output
55000
View Outputs Side By Side
Input(s)
{
  "target": 29751,
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
Test Case 12 passed!
Expected Output
4500
Your Code's Output
4500
View Outputs Side By Side
Input(s)
{
  "target": 29749,
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
 */