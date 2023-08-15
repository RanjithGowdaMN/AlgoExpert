using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    public class RevealMinesweeperProgram
    {
        public string[][] RevealMinesweeper(string[][] board, int row, int column)
        {
            // Write your code here.
            if (board[row][column].Equals("M"))
            {
                board[row][column] = "X";
                return board;
            }

            List<CellLocations> neighbors = getNeighbors(board, row, column);
            int adjacentMinesCount = 0;
            foreach (var neighbor in neighbors)
            {
                if (board[neighbor.row][neighbor.column].Equals("M"))
                {
                    adjacentMinesCount++;
                }
            }
            if (adjacentMinesCount > 0)
            {
                board[row][column] = adjacentMinesCount.ToString();
            }
            else
            {
                board[row][column] = "0";
                foreach (var neighbor in neighbors)
                {
                    if (board[neighbor.row][neighbor.column].Equals("H"))
                    {
                        RevealMinesweeper(board, neighbor.row, neighbor.column);
                    }
                }
            }
            return board;
        }

        private List<CellLocations> getNeighbors(
            string[][] board, int row, int column
        )
        {
            int[,] directions = new int[8, 2]{
            {0,1},
            {0,-1},
            {1,0},
            {-1,0},
            {1,1},
            {1,-1},
            {-1,1},
            {-1,-1}
        };
            List<CellLocations> neighbors = new List<CellLocations>();
            for (var i = 0; i < directions.GetLength(0); i++)
            {
                int newRow = row + directions[i, 0];
                int newColumn = column + directions[i, 1];
                if (0 <= newRow && newRow < board.Length && 0 <= newColumn &&
                   newColumn < board[0].Length)
                {
                    neighbors.Add(new CellLocations(newRow, newColumn));
                }
            }
            return neighbors;
        }

        public class CellLocations
        {
            public int row;
            public int column;
            public CellLocations(int row, int column)
            {
                this.row = row;
                this.column = column;
            }
        }
    }
}

/*
 
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    string[][] board = new string[][] {
      new string[] { "H", "H", "H", "H", "M" },
      new string[] { "H", "H", "M", "H", "H" },
      new string[] { "H", "H", "H", "H", "H" },
      new string[] { "H", "H", "H", "H", "H" }
    };
    int row = 3;
    int column = 4;
    string[][] expected = new string[][] {
      new string[] { "0", "1", "H", "H", "M" },
      new string[] { "0", "1", "M", "2", "1" },
      new string[] { "0", "1", "1", "1", "0" },
      new string[] { "0", "0", "0", "0", "0" }
    };
    string[][] actual = new Program().RevealMinesweeper(board, row, column);

    Utils.AssertTrue(expected.Length == actual.Length);
    Utils.AssertTrue(expected[0].Length == actual[0].Length);

    for (int currRow = 0; currRow < expected.Length; currRow++) {
      for (int currColumn = 0; currColumn < expected[0].Length; currColumn++) {
        Utils.AssertTrue(
          expected[currRow][currColumn].Equals(actual[currRow][currColumn])
        );
      }
    }
  }
}

34 / 34 test cases passed.

Test Case 1 passed!
Expected Output
[
  ["0"]
]
Your Code's Output
[
  ["0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H"]
  ],
  "column": 0,
  "row": 0
}
Test Case 2 passed!
Expected Output
[
  ["X"]
]
Your Code's Output
[
  ["X"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M"]
  ],
  "column": 0,
  "row": 0
}
Test Case 3 passed!
Expected Output
[
  ["1", "M"]
]
Your Code's Output
[
  ["1", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M"]
  ],
  "column": 0,
  "row": 0
}
Test Case 4 passed!
Expected Output
[
  ["0", "0"]
]
Your Code's Output
[
  ["0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H"]
  ],
  "column": 0,
  "row": 0
}
Test Case 5 passed!
Expected Output
[
  ["0", "0"],
  ["0", "0"]
]
Your Code's Output
[
  ["0", "0"],
  ["0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H"],
    ["H", "H"]
  ],
  "column": 0,
  "row": 0
}
Test Case 6 passed!
Expected Output
[
  ["0", "0"],
  ["0", "0"]
]
Your Code's Output
[
  ["0", "0"],
  ["0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H"],
    ["H", "H"]
  ],
  "column": 0,
  "row": 1
}
Test Case 7 passed!
Expected Output
[
  ["0", "0"],
  ["0", "0"]
]
Your Code's Output
[
  ["0", "0"],
  ["0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H"],
    ["H", "H"]
  ],
  "column": 1,
  "row": 1
}
Test Case 8 passed!
Expected Output
[
  ["0", "0"],
  ["0", "0"]
]
Your Code's Output
[
  ["0", "0"],
  ["0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H"],
    ["H", "H"]
  ],
  "column": 1,
  "row": 0
}
Test Case 9 passed!
Expected Output
[
  ["H", "X"],
  ["H", "H"]
]
Your Code's Output
[
  ["H", "X"],
  ["H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M"],
    ["H", "H"]
  ],
  "column": 1,
  "row": 0
}
Test Case 10 passed!
Expected Output
[
  ["H", "M"],
  ["H", "1"]
]
Your Code's Output
[
  ["H", "M"],
  ["H", "1"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M"],
    ["H", "H"]
  ],
  "column": 1,
  "row": 1
}
Test Case 11 passed!
Expected Output
[
  ["H", "M"],
  ["1", "H"]
]
Your Code's Output
[
  ["H", "M"],
  ["1", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M"],
    ["H", "H"]
  ],
  "column": 0,
  "row": 1
}
Test Case 12 passed!
Expected Output
[
  ["1", "M"],
  ["H", "H"]
]
Your Code's Output
[
  ["1", "M"],
  ["H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M"],
    ["H", "H"]
  ],
  "column": 0,
  "row": 0
}
Test Case 13 passed!
Expected Output
[
  ["X", "M"],
  ["M", "M"]
]
Your Code's Output
[
  ["X", "M"],
  ["M", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M"],
    ["M", "M"]
  ],
  "column": 0,
  "row": 0
}
Test Case 14 passed!
Expected Output
[
  ["M", "M"],
  ["X", "M"]
]
Your Code's Output
[
  ["M", "M"],
  ["X", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M"],
    ["M", "M"]
  ],
  "column": 0,
  "row": 1
}
Test Case 15 passed!
Expected Output
[
  ["X", "M"],
  ["H", "H"],
  ["H", "H"]
]
Your Code's Output
[
  ["X", "M"],
  ["H", "H"],
  ["H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M"],
    ["H", "H"],
    ["H", "H"]
  ],
  "column": 0,
  "row": 0
}
Test Case 16 passed!
Expected Output
[
  ["M", "M"],
  ["2", "H"],
  ["H", "H"]
]
Your Code's Output
[
  ["M", "M"],
  ["2", "H"],
  ["H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M"],
    ["H", "H"],
    ["H", "H"]
  ],
  "column": 0,
  "row": 1
}
Test Case 17 passed!
Expected Output
[
  ["M", "M"],
  ["2", "2"],
  ["0", "0"]
]
Your Code's Output
[
  ["M", "M"],
  ["2", "2"],
  ["0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M"],
    ["H", "H"],
    ["H", "H"]
  ],
  "column": 0,
  "row": 2
}
Test Case 18 passed!
Expected Output
[
  ["M", "M", "M"],
  ["M", "8", "M"],
  ["M", "M", "M"]
]
Your Code's Output
[
  ["M", "M", "M"],
  ["M", "8", "M"],
  ["M", "M", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M", "M"],
    ["M", "H", "M"],
    ["M", "M", "M"]
  ],
  "column": 1,
  "row": 1
}
Test Case 19 passed!
Expected Output
[
  ["M", "M", "M", "M"],
  ["M", "7", "H", "M"],
  ["M", "M", "M", "M"]
]
Your Code's Output
[
  ["M", "M", "M", "M"],
  ["M", "7", "H", "M"],
  ["M", "M", "M", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M", "M", "M"],
    ["M", "H", "H", "M"],
    ["M", "M", "M", "M"]
  ],
  "column": 1,
  "row": 1
}
Test Case 20 passed!
Expected Output
[
  ["0", "1", "H", "H", "M"],
  ["0", "1", "M", "2", "1"],
  ["0", "1", "1", "1", "0"],
  ["0", "0", "0", "0", "0"]
]
Your Code's Output
[
  ["0", "1", "H", "H", "M"],
  ["0", "1", "M", "2", "1"],
  ["0", "1", "1", "1", "0"],
  ["0", "0", "0", "0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "H", "H", "M"],
    ["H", "H", "M", "H", "H"],
    ["H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H"]
  ],
  "column": 0,
  "row": 3
}
Test Case 21 passed!
Expected Output
[
  ["0", "1", "H", "H", "M"],
  ["0", "1", "M", "2", "1"],
  ["0", "1", "1", "1", "0"],
  ["0", "0", "0", "0", "0"]
]
Your Code's Output
[
  ["0", "1", "H", "H", "M"],
  ["0", "1", "M", "2", "1"],
  ["0", "1", "1", "1", "0"],
  ["0", "0", "0", "0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "H", "H", "M"],
    ["H", "H", "M", "H", "H"],
    ["H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H"]
  ],
  "column": 4,
  "row": 3
}
Test Case 22 passed!
Expected Output
[
  ["H", "H", "1", "H", "M"],
  ["H", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H"]
]
Your Code's Output
[
  ["H", "H", "1", "H", "M"],
  ["H", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "H", "H", "M"],
    ["H", "H", "M", "H", "H"],
    ["H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H"]
  ],
  "column": 2,
  "row": 0
}
Test Case 23 passed!
Expected Output
[
  ["0", "1", "H", "H", "M"],
  ["0", "1", "M", "2", "1"],
  ["0", "1", "1", "1", "0"],
  ["0", "0", "0", "0", "0"]
]
Your Code's Output
[
  ["0", "1", "H", "H", "M"],
  ["0", "1", "M", "2", "1"],
  ["0", "1", "1", "1", "0"],
  ["0", "0", "0", "0", "0"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "H", "H", "M"],
    ["H", "1", "M", "H", "1"],
    ["H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H"]
  ],
  "column": 4,
  "row": 3
}
Test Case 24 passed!
Expected Output
[
  ["0", "1", "M", "H", "H", "M", "H", "H", "H"],
  ["1", "2", "H", "H", "M", "H", "H", "M", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "M", "H", "M", "H", "H", "M"],
  ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "M", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "M", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"]
]
Your Code's Output
[
  ["0", "1", "M", "H", "H", "M", "H", "H", "H"],
  ["1", "2", "H", "H", "M", "H", "H", "M", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "M", "H", "M", "H", "H", "M"],
  ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "M", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "M", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "M", "H", "H", "M", "H", "H", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "M", "H"],
    ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "M", "H", "M", "H", "H", "M"],
    ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
    ["H", "H", "M", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "M", "H", "H"],
    ["H", "M", "H", "H", "H", "H", "H", "H", "H"]
  ],
  "column": 0,
  "row": 0
}
Test Case 25 passed!
Expected Output
[
  ["H", "H", "M", "H", "H", "M", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "M", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "M", "H", "M", "1", "H", "M"],
  ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "M", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "M", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"]
]
Your Code's Output
[
  ["H", "H", "M", "H", "H", "M", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "M", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "M", "H", "M", "1", "H", "M"],
  ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "M", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "M", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "M", "H", "H", "M", "H", "H", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "M", "H"],
    ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "M", "H", "M", "H", "H", "M"],
    ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
    ["H", "H", "M", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "M", "H", "H"],
    ["H", "M", "H", "H", "H", "H", "H", "H", "H"]
  ],
  "column": 6,
  "row": 3
}
Test Case 26 passed!
Expected Output
[
  ["H", "H", "M", "H", "H", "M", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "M", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "M", "H", "M", "H", "H", "M"],
  ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "M", "2", "1", "3", "H", "H", "H"],
  ["H", "H", "2", "1", "0", "1", "M", "H", "H"],
  ["H", "M", "1", "0", "0", "1", "H", "H", "H"]
]
Your Code's Output
[
  ["H", "H", "M", "H", "H", "M", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "M", "H"],
  ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "M", "H", "M", "H", "H", "M"],
  ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "M", "2", "1", "3", "H", "H", "H"],
  ["H", "H", "2", "1", "0", "1", "M", "H", "H"],
  ["H", "M", "1", "0", "0", "1", "H", "H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "M", "H", "H", "M", "H", "H", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "M", "H"],
    ["H", "M", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "M", "H", "M", "H", "H", "M"],
    ["M", "H", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "M", "H", "M", "H", "H"],
    ["H", "H", "M", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "M", "H", "H"],
    ["H", "M", "H", "H", "H", "H", "H", "H", "H"]
  ],
  "column": 4,
  "row": 7
}
Test Case 27 passed!
Expected Output
[
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["1", "1", "1", "1", "M", "H", "H", "H"],
  ["0", "0", "0", "1", "H", "H", "H", "M"]
]
Your Code's Output
[
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["1", "1", "1", "1", "M", "H", "H", "H"],
  ["0", "0", "0", "1", "H", "H", "H", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M", "H", "H", "H", "H", "M", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "H"],
    ["M", "H", "H", "M", "H", "M", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "M", "H", "H", "H", "H", "M", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "M"]
  ],
  "column": 0,
  "row": 6
}
Test Case 28 passed!
Expected Output
[
  ["H", "M", "1", "H", "1", "H", "M", "1"],
  ["H", "H", "H", "H", "M", "H", "2", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["1", "M", "H", "H", "H", "H", "M", "H"],
  ["1", "1", "1", "1", "M", "H", "H", "H"],
  ["0", "0", "0", "1", "H", "H", "H", "M"]
]
Your Code's Output
[
  ["H", "M", "1", "H", "1", "H", "M", "1"],
  ["H", "H", "H", "H", "M", "H", "2", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["1", "M", "H", "H", "H", "H", "M", "H"],
  ["1", "1", "1", "1", "M", "H", "H", "H"],
  ["0", "0", "0", "1", "H", "H", "H", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M", "1", "H", "1", "H", "M", "1"],
    ["H", "H", "H", "H", "M", "H", "2", "H"],
    ["M", "H", "H", "M", "H", "M", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "H"],
    ["1", "M", "H", "H", "H", "H", "M", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "M"]
  ],
  "column": 0,
  "row": 6
}
Test Case 29 passed!
Expected Output
[
  ["H", "M", "1", "H", "1", "H", "M", "1"],
  ["H", "H", "H", "H", "M", "H", "2", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["1", "M", "H", "H", "H", "H", "M", "H"],
  ["1", "1", "1", "1", "M", "H", "H", "H"],
  ["0", "0", "0", "1", "H", "H", "H", "M"]
]
Your Code's Output
[
  ["H", "M", "1", "H", "1", "H", "M", "1"],
  ["H", "H", "H", "H", "M", "H", "2", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["1", "M", "H", "H", "H", "H", "M", "H"],
  ["1", "1", "1", "1", "M", "H", "H", "H"],
  ["0", "0", "0", "1", "H", "H", "H", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M", "1", "H", "1", "H", "M", "1"],
    ["H", "H", "H", "H", "M", "H", "2", "H"],
    ["M", "H", "H", "M", "H", "M", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "H"],
    ["1", "M", "H", "H", "H", "H", "M", "H"],
    ["1", "1", "H", "H", "M", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "M"]
  ],
  "column": 0,
  "row": 6
}
Test Case 30 passed!
Expected Output
[
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "X"]
]
Your Code's Output
[
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H"],
  ["M", "H", "H", "M", "H", "M", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "M", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "X"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "M", "H", "H", "H", "H", "M", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "H"],
    ["M", "H", "H", "M", "H", "M", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "M", "H", "H", "H", "H", "M", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "M"]
  ],
  "column": 7,
  "row": 6
}
Test Case 31 passed!
Expected Output
[
  ["H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "M", "H", "H", "H", "H", "H"],
  ["H", "H", "M", "H", "H", "H", "H", "H", "H", "H", "M", "H"],
  ["H", "2", "1", "2", "M", "H", "H", "H", "H", "M", "H", "H"],
  ["M", "1", "0", "1", "1", "1", "1", "H", "H", "H", "H", "H"],
  ["H", "1", "0", "0", "0", "0", "1", "M", "H", "H", "H", "H"]
]
Your Code's Output
[
  ["H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "M", "H"],
  ["H", "H", "H", "H", "M", "H", "H", "H", "H", "H", "H", "H"],
  ["H", "H", "H", "H", "H", "H", "M", "H", "H", "H", "H", "H"],
  ["H", "H", "M", "H", "H", "H", "H", "H", "H", "H", "M", "H"],
  ["H", "2", "1", "2", "M", "H", "H", "H", "H", "M", "H", "H"],
  ["M", "1", "0", "1", "1", "1", "1", "H", "H", "H", "H", "H"],
  ["H", "1", "0", "0", "0", "0", "1", "M", "H", "H", "H", "H"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "M", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "M", "H", "H", "H", "H", "H"],
    ["H", "H", "M", "H", "H", "H", "H", "H", "H", "H", "M", "H"],
    ["H", "H", "H", "H", "M", "H", "H", "H", "H", "M", "H", "H"],
    ["M", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H"],
    ["H", "H", "H", "H", "H", "H", "H", "M", "H", "H", "H", "H"]
  ],
  "column": 2,
  "row": 6
}
Test Case 32 passed!
Expected Output
[
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "5", "H", "H", "H", "M", "M", "M"],
  ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
  ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
]
Your Code's Output
[
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "5", "H", "H", "H", "M", "M", "M"],
  ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
  ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
  ],
  "column": 3,
  "row": 4
}
Test Case 33 passed!
Expected Output
[
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "3", "0", "0", "3", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
]
Your Code's Output
[
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "3", "0", "0", "3", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
  ],
  "column": 5,
  "row": 5
}
Test Case 34 passed!
Expected Output
[
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "3", "0", "0", "3", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
]
Your Code's Output
[
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "3", "0", "0", "3", "M", "M", "M"],
  ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
  ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "5", "3", "3", "5", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "H", "H", "H", "H", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"],
    ["M", "M", "M", "M", "M", "M", "M", "M", "M", "M"]
  ],
  "column": 5,
  "row": 5
}


 */