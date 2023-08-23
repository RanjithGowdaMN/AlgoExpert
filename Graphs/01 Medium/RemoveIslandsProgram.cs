using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class RemoveIslandsProgram
    {
        public int[][] RemoveIslands(int[][] matrix)
        {
            // O(wh) time | O(wh) namespace
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool rowIsBorder = row == 0 || row == matrix.Length - 1;
                    bool colIsBorder = col == 0 || col == matrix[row].Length - 1;
                    bool isBorder = rowIsBorder || colIsBorder;

                    if (!isBorder)
                    {
                        continue;
                    }
                    if (matrix[row][col] != 1)
                    {
                        continue;
                    }
                    changeOnesConnectedToBorderToTwos(matrix, row, col);
                }
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int color = matrix[row][col];
                    if (color == 1)
                    {
                        matrix[row][col] = 0;
                    }
                    else if (color == 2)
                    {
                        matrix[row][col] = 1;
                    }
                }
            }
            return matrix;
        }
        public void changeOnesConnectedToBorderToTwos(
            int[][] matrix, int startRow, int startCol
        )
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(startRow, startCol));

            while (stack.Count > 0)
            {
                var currentPosition = stack.Pop();
                int currentRow = currentPosition.Item1;
                int currentCol = currentPosition.Item2;

                matrix[currentRow][currentCol] = 2;

                var neighbors = getNeighbors(matrix, currentRow, currentCol);
                foreach (var neighbor in neighbors)
                {
                    int row = neighbor.Item1;
                    int col = neighbor.Item2;

                    if (matrix[row][col] != 1)
                    {
                        continue;
                    }
                    stack.Push(neighbor);
                }
            }
        }

        public List<Tuple<int, int>> getNeighbors(int[][] matrix, int row, int col)
        {
            int numRows = matrix.Length;
            int numCols = matrix[row].Length;
            List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();

            if (row - 1 >= 0)
            {
                neighbors.Add(new Tuple<int, int>(row - 1, col));
            }
            if (row + 1 < numRows)
            {
                neighbors.Add(new Tuple<int, int>(row + 1, col));
            }
            if (col - 1 >= 0)
            {
                neighbors.Add(new Tuple<int, int>(row, col - 1));
            }
            if (col + 1 < numCols)
            {
                neighbors.Add(new Tuple<int, int>(row, col + 1));
            }
            return neighbors;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] input = new int[][] {
      new int[] { 1, 0, 0, 0, 0, 0 },
      new int[] { 0, 1, 0, 1, 1, 1 },
      new int[] { 0, 0, 1, 0, 1, 0 },
      new int[] { 1, 1, 0, 0, 1, 0 },
      new int[] { 1, 0, 1, 1, 0, 0 },
      new int[] { 1, 0, 0, 0, 0, 1 },
    };
    int[][] expected = new int[][] {
      new int[] { 1, 0, 0, 0, 0, 0 },
      new int[] { 0, 0, 0, 1, 1, 1 },
      new int[] { 0, 0, 0, 0, 1, 0 },
      new int[] { 1, 1, 0, 0, 1, 0 },
      new int[] { 1, 0, 0, 0, 0, 0 },
      new int[] { 1, 0, 0, 0, 0, 1 },
    };
    int[][] actual = new Program().RemoveIslands(input);
    for (int i = 0; i < actual.Length; i++) {
      for (int j = 0; j < actual[i].Length; j++) {
        Utils.AssertTrue(actual[i][j] == expected[i][j]);
      }
    }
  }
}

16 / 16 test cases passed.

Test Case 1 passed!
Expected Output
[
  [1, 0, 0, 0, 0, 0],
  [0, 0, 0, 1, 1, 1],
  [0, 0, 0, 0, 1, 0],
  [1, 1, 0, 0, 1, 0],
  [1, 0, 0, 0, 0, 0],
  [1, 0, 0, 0, 0, 1]
]
Your Code's Output
[
  [1, 0, 0, 0, 0, 0],
  [0, 0, 0, 1, 1, 1],
  [0, 0, 0, 0, 1, 0],
  [1, 1, 0, 0, 1, 0],
  [1, 0, 0, 0, 0, 0],
  [1, 0, 0, 0, 0, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 0, 0, 0],
    [0, 1, 0, 1, 1, 1],
    [0, 0, 1, 0, 1, 0],
    [1, 1, 0, 0, 1, 0],
    [1, 0, 1, 1, 0, 0],
    [1, 0, 0, 0, 0, 1]
  ]
}
Test Case 2 passed!
Expected Output
[
  [1, 0, 0, 0, 1],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [1, 0, 0, 0, 1]
]
Your Code's Output
[
  [1, 0, 0, 0, 1],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [1, 0, 0, 0, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 0, 1],
    [0, 1, 0, 1, 0],
    [0, 0, 1, 0, 0],
    [0, 1, 0, 1, 0],
    [1, 0, 0, 0, 1]
  ]
}
Test Case 3 passed!
Expected Output
[
  [1, 0, 0, 1, 0],
  [0, 0, 0, 1, 0],
  [0, 0, 1, 1, 0]
]
Your Code's Output
[
  [1, 0, 0, 1, 0],
  [0, 0, 0, 1, 0],
  [0, 0, 1, 1, 0]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 1, 0],
    [0, 1, 0, 1, 0],
    [0, 0, 1, 1, 0]
  ]
}
Test Case 4 passed!
Expected Output
[
  [1, 1, 1, 1, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 1, 0, 1],
  [1, 0, 1, 0, 1],
  [1, 0, 1, 1, 1],
  [1, 0, 1, 0, 1]
]
Your Code's Output
[
  [1, 1, 1, 1, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 1, 0, 1],
  [1, 0, 1, 0, 1],
  [1, 0, 1, 1, 1],
  [1, 0, 1, 0, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1, 1, 1],
    [1, 0, 0, 0, 1],
    [1, 0, 1, 0, 1],
    [1, 0, 0, 0, 1],
    [1, 0, 1, 0, 1],
    [1, 0, 1, 0, 1],
    [1, 0, 1, 1, 1],
    [1, 0, 1, 0, 1]
  ]
}
Test Case 5 passed!
Expected Output
[
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0]
]
Your Code's Output
[
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0, 0, 0],
    [0, 1, 1, 1, 0],
    [0, 1, 1, 1, 0],
    [0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0]
  ]
}
Test Case 6 passed!
Expected Output
[
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1]
]
Your Code's Output
[
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1]
  ]
}
Test Case 7 passed!
Expected Output
[
  [1]
]
Your Code's Output
[
  [1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1]
  ]
}
Test Case 8 passed!
Expected Output
[
  [1, 0, 0, 0, 1, 0, 0, 0],
  [1, 0, 0, 0, 1, 0, 0, 0],
  [1, 1, 0, 1, 0, 0, 0, 0],
  [1, 1, 0, 1, 1, 0, 0, 0],
  [1, 0, 0, 0, 1, 0, 0, 0]
]
Your Code's Output
[
  [1, 0, 0, 0, 1, 0, 0, 0],
  [1, 0, 0, 0, 1, 0, 0, 0],
  [1, 1, 0, 1, 0, 0, 0, 0],
  [1, 1, 0, 1, 1, 0, 0, 0],
  [1, 0, 0, 0, 1, 0, 0, 0]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 0, 1, 0, 0, 0],
    [1, 0, 1, 0, 1, 0, 1, 0],
    [1, 1, 0, 1, 0, 0, 1, 0],
    [1, 1, 0, 1, 1, 0, 1, 0],
    [1, 0, 0, 0, 1, 0, 0, 0]
  ]
}
Test Case 9 passed!
Expected Output
[
  [1, 1, 1, 1, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 1, 1, 1, 1]
]
Your Code's Output
[
  [1, 1, 1, 1, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 1, 1, 1, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1, 1, 1],
    [1, 0, 0, 0, 1],
    [1, 0, 1, 0, 1],
    [1, 0, 0, 0, 1],
    [1, 1, 1, 1, 1]
  ]
}
Test Case 10 passed!
Expected Output
[
  [1, 0, 1, 0, 1],
  [0, 0, 1, 0, 0],
  [1, 1, 0, 1, 1],
  [0, 0, 1, 0, 0],
  [1, 0, 1, 0, 1]
]
Your Code's Output
[
  [1, 0, 1, 0, 1],
  [0, 0, 1, 0, 0],
  [1, 1, 0, 1, 1],
  [0, 0, 1, 0, 0],
  [1, 0, 1, 0, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 1, 0, 1],
    [0, 0, 1, 0, 0],
    [1, 1, 0, 1, 1],
    [0, 0, 1, 0, 0],
    [1, 0, 1, 0, 1]
  ]
}
Test Case 11 passed!
Expected Output
[
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0]
]
Your Code's Output
[
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0, 0, 0],
    [0, 0, 1, 0, 0],
    [0, 1, 1, 1, 0],
    [0, 0, 1, 0, 0],
    [0, 0, 0, 0, 0]
  ]
}
Test Case 12 passed!
Expected Output
[
  [1, 0, 1, 0, 1, 0],
  [0, 0, 0, 0, 0, 1],
  [1, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 1],
  [1, 0, 0, 0, 0, 0],
  [0, 1, 0, 1, 0, 1]
]
Your Code's Output
[
  [1, 0, 1, 0, 1, 0],
  [0, 0, 0, 0, 0, 1],
  [1, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 1],
  [1, 0, 0, 0, 0, 0],
  [0, 1, 0, 1, 0, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 1],
    [1, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 1],
    [1, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 1]
  ]
}
Test Case 13 passed!
Expected Output
[
  [1, 0, 1, 1, 1, 0],
  [1, 1, 0, 1, 0, 1],
  [1, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 1],
  [1, 0, 1, 0, 0, 0],
  [0, 1, 1, 1, 0, 1]
]
Your Code's Output
[
  [1, 0, 1, 1, 1, 0],
  [1, 1, 0, 1, 0, 1],
  [1, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 1],
  [1, 0, 1, 0, 0, 0],
  [0, 1, 1, 1, 0, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 1, 1, 1, 0],
    [1, 1, 0, 1, 0, 1],
    [1, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 1],
    [1, 0, 1, 0, 1, 0],
    [0, 1, 1, 1, 0, 1]
  ]
}
Test Case 14 passed!
Expected Output
[
  [0, 1, 0],
  [0, 1, 0],
  [1, 0, 0]
]
Your Code's Output
[
  [0, 1, 0],
  [0, 1, 0],
  [1, 0, 0]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 1, 0],
    [0, 1, 0],
    [1, 0, 0]
  ]
}
Test Case 15 passed!
Expected Output
[
  [1, 1],
  [1, 1]
]
Your Code's Output
[
  [1, 1],
  [1, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1],
    [1, 1]
  ]
}
Test Case 16 passed!
Expected Output
[
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
]
Your Code's Output
[
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ]
}

 
 */