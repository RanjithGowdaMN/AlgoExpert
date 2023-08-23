using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class MinimumPassesOfMatrixProgram
    {
        public int MinimumPassesOfMatrix(int[][] matrix)
        {
            // O(w*h) time | O(w*h) space
            int passes = convertNegatives(matrix);
            return (!containsNegative(matrix)) ? passes - 1 : -1;
        }
        public int convertNegatives(int[][] matrix)
        {
            List<int[]> nextPassQueue = getAllPositivePositions(matrix);
            int passes = 0;

            while (nextPassQueue.Count > 0)
            {
                List<int[]> currentPassQueue = nextPassQueue;
                nextPassQueue = new List<int[]>();

                while (currentPassQueue.Count > 0)
                {
                    int[] vals = currentPassQueue[0];
                    currentPassQueue.RemoveAt(0);
                    int currentRow = vals[0];
                    int currentCol = vals[1];
                    List<int[]> adjacentPositions =
                        getAdjacentPositions(currentRow, currentCol, matrix);
                    foreach (var position in adjacentPositions)
                    {
                        int row = position[0];
                        int col = position[1];

                        int value = matrix[row][col];
                        if (value < 0)
                        {
                            matrix[row][col] *= -1;
                            nextPassQueue.Add(new int[] { row, col });
                        }
                    }
                }
                passes += 1;
            }
            return passes;
        }
        public List<int[]> getAllPositivePositions(int[][] matrix)
        {
            List<int[]> positivePositions = new List<int[]>();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int value = matrix[row][col];
                    if (value > 0)
                    {
                        positivePositions.Add(new int[] { row, col });
                    }
                }
            }
            return positivePositions;
        }

        public List<int[]> getAdjacentPositions(int row, int col, int[][] matrix)
        {
            List<int[]> adjacentPositions = new List<int[]>();

            if (row > 0)
            {
                adjacentPositions.Add(new int[] { row - 1, col });
            }
            if (row < matrix.Length - 1)
            {
                adjacentPositions.Add(new int[] { row + 1, col });
            }
            if (col > 0)
            {
                adjacentPositions.Add(new int[] { row, col - 1 });
            }
            if (col < (matrix[0].Length - 1))
            {
                adjacentPositions.Add(new int[] { row, col + 1 });
            }
            return adjacentPositions;
        }
        public bool containsNegative(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var value in row)
                {
                    if (value < 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
/*
 ___________________________________________________________________________
  public int MinimumPassesOfMatrix(int[][] matrix) {
    // Write your code here.
      int passes = convertNegatives(matrix);
      return (!containsNegative(matrix)) ? passes -1 : -1;
  }
    public int convertNegatives(int[][] matrix){
        List<int[]> queue = getAllPositivePositions(matrix);
        int passes = 0;
        while(queue.Count > 0){
            int currentSize = queue.Count;
            while(currentSize > 0){
                int[] vals = queue[0];
                queue.RemoveAt(0);
                int currentRow = vals[0];
                int currentCol = vals[1];

                List<int[]> adjacentPositions = 
                    getAdjacentPositions(currentRow, currentCol, matrix);
                foreach(var position in adjacentPositions){
                    int row = position[0];
                    int col = position[1];

                    int value = matrix[row][col];
                    if(value < 0){
                        matrix[row][col] *=-1;
                        queue.Add(new int[] {row, col});
                    }
                }
                currentSize -=1;
            }
            passes += 1;
        }
        return passes;
    }

       public List<int[]> getAllPositivePositions(int[][] matrix){
        List<int[]> positivePositions = new List<int[]>();

        for(int row = 0; row < matrix.Length; row++){
            for(int col=0; col < matrix[row].Length; col++){
                int value = matrix[row][col];
                if(value > 0){
                    positivePositions.Add(new int[] {row, col});
                }
            }
        }
        return positivePositions;
    }

    public List<int[]> getAdjacentPositions(int row, int col, int[][] matrix){
        List<int[]> adjacentPositions = new List<int[]>();

        if(row > 0){
            adjacentPositions.Add(new int[] {row-1, col});
        }
        if(row < matrix.Length-1){
            adjacentPositions.Add(new int[] {row+1, col});
        }
        if(col>0){
            adjacentPositions.Add(new int[] {row, col-1});
        }
        if(col < (matrix[0].Length-1)){
            adjacentPositions.Add(new int[] {row, col+1});
        }
        return adjacentPositions;
    }
    public bool containsNegative(int[][] matrix){
        foreach(var row in matrix){
            foreach(var

___________________________________________________________________________

using System;
using System.Linq;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] matrix = new int[][] {
      new int[] { 0, -1, -3, 2, 0 },
      new int[] { 1, -2, -5, -1, -3 },
      new int[] { 3, 0, 0, -4, -1 },
    };
    int expected = 3;
    int actual = new Program().MinimumPassesOfMatrix(matrix);
    Utils.AssertTrue(expected == actual);
  }
}


16 / 16 test cases passed.

Test Case 1 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, -1, -3, 2, 0],
    [1, -2, -5, -1, -3],
    [3, 0, 0, -4, -1]
  ]
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1]
  ]
}
Test Case 3 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, -2, -3],
    [-4, -5, -6, -2, -1],
    [0, 0, 0, 0, -1],
    [1, 2, 3, 0, -2]
  ]
}
Test Case 4 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, -2, -3],
    [-4, -5, -6, -2, -1],
    [0, 0, 0, 0, -1],
    [1, 2, 3, 0, 3]
  ]
}
Test Case 5 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, -2, -3],
    [-4, -5, -6, -2, -1],
    [0, 0, 0, 0, -1],
    [-1, 0, 3, 0, 3]
  ]
}
Test Case 6 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1]
  ]
}
Test Case 7 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 2, 3],
    [4, 5, 6]
  ]
}
Test Case 8 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, -9, 0, -1, 0],
    [-9, -4, -5, 4, -8],
    [2, 0, 0, -3, 0],
    [0, -17, -4, 2, -5]
  ]
}
Test Case 9 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-2, -3, -4, -1, -9],
    [-4, -3, -4, -1, -2],
    [-6, -7, -2, -1, -1],
    [0, 0, 0, 0, -3],
    [1, -2, -3, -6, -1]
  ]
}
Test Case 10 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, 2, 3],
    [4, 5, 6]
  ]
}
Test Case 11 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, 2, 3],
    [4, -5, -6]
  ]
}
Test Case 12 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, 0, 3],
    [0, -5, -6]
  ]
}
Test Case 13 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, 0, 3],
    [0, -5, -6]
  ]
}
Test Case 14 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, -1, -2],
    [-2, -3, 4, -1],
    [-2, -3, 1, -3],
    [-14, -15, 2, 0],
    [0, 0, 0, 0],
    [1, -1, -1, -1]
  ]
}
Test Case 15 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, -1, -2],
    [-2, -3, 4, -1],
    [-2, -3, 1, -3],
    [-14, -15, 2, 0],
    [0, 0, 0, 0],
    [1, -1, -1, 1]
  ]
}
Test Case 16 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-2, 0, -2, 1],
    [-2, -1, -1, -1]
  ]
}
 
 */