using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._02_Hard
{
    class SolveSudokuProgram
    {
        public List<List<int>> SolveSudoku(List<List<int>> board)
        {
            // Write your code here.
            solvePartialSuduku(0, 0, board);
            return board;
        }
        public bool solvePartialSuduku(int row, int col, List<List<int>> board)
        {
            int currentRow = row;
            int currentCol = col;

            if (currentCol == board[currentRow].Count)
            {
                currentRow += 1;
                currentCol = 0;
                if (currentRow == board.Count)
                {
                    return true;
                }
            }
            if (board[currentRow][currentCol] == 0)
            {
                return tryDigitsAtPosition(currentRow, currentCol, board);
            }
            return solvePartialSuduku(currentRow, currentCol + 1, board);
        }
        public bool tryDigitsAtPosition(int row, int col, List<List<int>> board)
        {
            for (int digit = 1; digit < 10; digit++)
            {
                if (isValidAtPosition(digit, row, col, board))
                {
                    board[row][col] = digit;
                    if (solvePartialSuduku(row, col + 1, board))
                    {
                        return true;
                    }
                }
            }
            board[row][col] = 0;
            return false;
        }
        public bool isValidAtPosition(
            int value, int row, int col, List<List<int>> board
        )
        {
            bool rowIsValid = !board[row].Contains(value);
            bool columnIsValid = true;

            for (int r = 0; r < board.Count; r++)
            {
                if (board[r][col] == value) columnIsValid = false;
            }
            if (!rowIsValid || !columnIsValid)
            {
                return false;
            }
            int subgridRowStart = (row / 3) * 3;
            int subgridColStart = (col / 3) * 3;
            for (int rowIdx = 0; rowIdx < 3; rowIdx++)
            {
                for (int colIdx = 0; colIdx < 3; colIdx++)
                {
                    int rowToCheck = subgridRowStart + rowIdx;
                    int colToCheck = subgridColStart + colIdx;
                    int existingValue = board[rowToCheck][colToCheck];
                    if (existingValue == value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
/*
 using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] inputValues = new int[][] {
      new int[] { 7, 8, 0, 4, 0, 0, 1, 2, 0 },
      new int[] { 6, 0, 0, 0, 7, 5, 0, 0, 9 },
      new int[] { 0, 0, 0, 6, 0, 1, 0, 7, 8 },
      new int[] { 0, 0, 7, 0, 4, 0, 2, 6, 0 },
      new int[] { 0, 0, 1, 0, 5, 0, 9, 3, 0 },
      new int[] { 9, 0, 4, 0, 6, 0, 0, 0, 5 },
      new int[] { 0, 7, 0, 3, 0, 0, 0, 1, 2 },
      new int[] { 1, 2, 0, 0, 0, 7, 4, 0, 0 },
      new int[] { 0, 4, 9, 2, 0, 6, 0, 0, 7 }
    };
    int[][] expectedValues = new int[][] {
      new int[] { 7, 8, 5, 4, 3, 9, 1, 2, 6 },
      new int[] { 6, 1, 2, 8, 7, 5, 3, 4, 9 },
      new int[] { 4, 9, 3, 6, 2, 1, 5, 7, 8 },
      new int[] { 8, 5, 7, 9, 4, 3, 2, 6, 1 },
      new int[] { 2, 6, 1, 7, 5, 8, 9, 3, 4 },
      new int[] { 9, 3, 4, 1, 6, 2, 7, 8, 5 },
      new int[] { 5, 7, 8, 3, 9, 4, 6, 1, 2 },
      new int[] { 1, 2, 6, 5, 8, 7, 4, 9, 3 },
      new int[] { 3, 4, 9, 2, 1, 6, 8, 5, 7 }
    };

    var input = new List<List<int> >();
    for (int i = 0; i < inputValues.Length; i++) {
      List<int> row = new List<int>();
      for (int j = 0; j < inputValues[i].Length; j++) {
        row.Add(inputValues[i][j]);
      }
      input.Add(row);
    }

    var actual = new Program().SolveSudoku(input);
    for (int i = 0; i < expectedValues.Length; i++) {
      for (int j = 0; j < expectedValues[i].Length; j++) {
        Utils.AssertEquals(actual[i][j], expectedValues[i][j]);
      }
    }
  }
}

4 / 4 test cases passed.

Test Case 1 passed!
Expected Output
[
  [7, 8, 5, 4, 3, 9, 1, 2, 6],
  [6, 1, 2, 8, 7, 5, 3, 4, 9],
  [4, 9, 3, 6, 2, 1, 5, 7, 8],
  [8, 5, 7, 9, 4, 3, 2, 6, 1],
  [2, 6, 1, 7, 5, 8, 9, 3, 4],
  [9, 3, 4, 1, 6, 2, 7, 8, 5],
  [5, 7, 8, 3, 9, 4, 6, 1, 2],
  [1, 2, 6, 5, 8, 7, 4, 9, 3],
  [3, 4, 9, 2, 1, 6, 8, 5, 7]
]
Your Code's Output
[
  [7, 8, 5, 4, 3, 9, 1, 2, 6],
  [6, 1, 2, 8, 7, 5, 3, 4, 9],
  [4, 9, 3, 6, 2, 1, 5, 7, 8],
  [8, 5, 7, 9, 4, 3, 2, 6, 1],
  [2, 6, 1, 7, 5, 8, 9, 3, 4],
  [9, 3, 4, 1, 6, 2, 7, 8, 5],
  [5, 7, 8, 3, 9, 4, 6, 1, 2],
  [1, 2, 6, 5, 8, 7, 4, 9, 3],
  [3, 4, 9, 2, 1, 6, 8, 5, 7]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    [7, 8, 0, 4, 0, 0, 1, 2, 0],
    [6, 0, 0, 0, 7, 5, 0, 0, 9],
    [0, 0, 0, 6, 0, 1, 0, 7, 8],
    [0, 0, 7, 0, 4, 0, 2, 6, 0],
    [0, 0, 1, 0, 5, 0, 9, 3, 0],
    [9, 0, 4, 0, 6, 0, 0, 0, 5],
    [0, 7, 0, 3, 0, 0, 0, 1, 2],
    [1, 2, 0, 0, 0, 7, 4, 0, 0],
    [0, 4, 9, 2, 0, 6, 0, 0, 7]
  ]
}
Test Case 2 passed!
Expected Output
[
  [1, 8, 5, 7, 3, 6, 2, 4, 9],
  [3, 4, 6, 5, 2, 9, 1, 7, 8],
  [2, 9, 7, 4, 8, 1, 6, 5, 3],
  [5, 7, 8, 2, 9, 3, 4, 1, 6],
  [9, 3, 2, 1, 6, 4, 7, 8, 5],
  [6, 1, 4, 8, 5, 7, 9, 3, 2],
  [4, 6, 3, 9, 1, 8, 5, 2, 7],
  [7, 2, 9, 3, 4, 5, 8, 6, 1],
  [8, 5, 1, 6, 7, 2, 3, 9, 4]
]
Your Code's Output
[
  [1, 8, 5, 7, 3, 6, 2, 4, 9],
  [3, 4, 6, 5, 2, 9, 1, 7, 8],
  [2, 9, 7, 4, 8, 1, 6, 5, 3],
  [5, 7, 8, 2, 9, 3, 4, 1, 6],
  [9, 3, 2, 1, 6, 4, 7, 8, 5],
  [6, 1, 4, 8, 5, 7, 9, 3, 2],
  [4, 6, 3, 9, 1, 8, 5, 2, 7],
  [7, 2, 9, 3, 4, 5, 8, 6, 1],
  [8, 5, 1, 6, 7, 2, 3, 9, 4]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    [0, 0, 0, 0, 3, 0, 0, 0, 9],
    [0, 4, 0, 5, 0, 0, 0, 7, 8],
    [2, 9, 0, 0, 0, 1, 0, 5, 0],
    [0, 7, 8, 0, 0, 3, 0, 0, 6],
    [0, 3, 0, 0, 6, 0, 0, 8, 0],
    [6, 0, 0, 8, 0, 0, 9, 3, 0],
    [0, 6, 0, 9, 0, 0, 0, 2, 7],
    [7, 2, 0, 0, 0, 5, 0, 6, 0],
    [8, 0, 0, 0, 7, 0, 0, 0, 0]
  ]
}
Test Case 3 passed!
Expected Output
[
  [5, 3, 8, 9, 1, 7, 6, 4, 2],
  [2, 7, 9, 6, 4, 8, 5, 1, 3],
  [6, 1, 4, 3, 5, 2, 7, 9, 8],
  [9, 8, 7, 1, 2, 3, 4, 6, 5],
  [1, 2, 5, 4, 8, 6, 3, 7, 9],
  [4, 6, 3, 7, 9, 5, 8, 2, 1],
  [8, 9, 6, 2, 3, 4, 1, 5, 7],
  [3, 4, 1, 5, 7, 9, 2, 8, 6],
  [7, 5, 2, 8, 6, 1, 9, 3, 4]
]
Your Code's Output
[
  [5, 3, 8, 9, 1, 7, 6, 4, 2],
  [2, 7, 9, 6, 4, 8, 5, 1, 3],
  [6, 1, 4, 3, 5, 2, 7, 9, 8],
  [9, 8, 7, 1, 2, 3, 4, 6, 5],
  [1, 2, 5, 4, 8, 6, 3, 7, 9],
  [4, 6, 3, 7, 9, 5, 8, 2, 1],
  [8, 9, 6, 2, 3, 4, 1, 5, 7],
  [3, 4, 1, 5, 7, 9, 2, 8, 6],
  [7, 5, 2, 8, 6, 1, 9, 3, 4]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    [5, 3, 8, 0, 1, 0, 0, 0, 0],
    [0, 7, 9, 6, 0, 0, 0, 0, 0],
    [0, 0, 4, 0, 0, 2, 0, 0, 0],
    [0, 0, 7, 0, 2, 3, 4, 0, 0],
    [0, 0, 5, 0, 8, 0, 0, 0, 9],
    [4, 6, 0, 0, 9, 0, 0, 0, 1],
    [0, 9, 0, 2, 3, 4, 1, 5, 0],
    [0, 4, 1, 5, 0, 0, 2, 0, 0],
    [0, 0, 0, 8, 6, 1, 0, 3, 0]
  ]
}
Test Case 4 passed!
Expected Output
[
  [5, 2, 4, 3, 9, 6, 1, 7, 8],
  [3, 6, 7, 8, 4, 1, 9, 5, 2],
  [1, 8, 9, 7, 5, 2, 3, 6, 4],
  [2, 5, 1, 9, 7, 4, 8, 3, 6],
  [9, 4, 3, 6, 8, 5, 2, 1, 7],
  [8, 7, 6, 2, 1, 3, 5, 4, 9],
  [6, 1, 5, 4, 2, 8, 7, 9, 3],
  [7, 3, 2, 1, 6, 9, 4, 8, 5],
  [4, 9, 8, 5, 3, 7, 6, 2, 1]
]
Your Code's Output
[
  [5, 2, 4, 3, 9, 6, 1, 7, 8],
  [3, 6, 7, 8, 4, 1, 9, 5, 2],
  [1, 8, 9, 7, 5, 2, 3, 6, 4],
  [2, 5, 1, 9, 7, 4, 8, 3, 6],
  [9, 4, 3, 6, 8, 5, 2, 1, 7],
  [8, 7, 6, 2, 1, 3, 5, 4, 9],
  [6, 1, 5, 4, 2, 8, 7, 9, 3],
  [7, 3, 2, 1, 6, 9, 4, 8, 5],
  [4, 9, 8, 5, 3, 7, 6, 2, 1]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    [0, 2, 0, 0, 9, 0, 1, 0, 0],
    [0, 0, 7, 8, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 3, 6, 0],
    [0, 0, 1, 9, 0, 4, 0, 0, 0],
    [0, 0, 0, 6, 0, 5, 0, 0, 7],
    [8, 0, 0, 0, 0, 0, 0, 0, 9],
    [0, 0, 0, 0, 2, 0, 0, 0, 0],
    [7, 0, 0, 0, 0, 0, 0, 8, 5],
    [4, 9, 0, 0, 3, 0, 0, 0, 0]
  ]
}
 
 */