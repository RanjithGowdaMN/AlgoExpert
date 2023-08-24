using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._00Easy
{
    class TransposedMatixProgram
    {
        public int[,] TransposeMatrix(int[,] matrix)
        {
            // Write your code here.
            int[,] transposedMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    transposedMatrix[col, row] = matrix[row, col];
                }
            }
            return transposedMatrix;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[,] input = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
    int[,] expected = new int[3, 3] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } };
    int[,] actual = new Program().TransposeMatrix(input);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < expected.GetLength(0); i++) {
      for (int j = 0; j < expected.GetLength(1); j++) {
        Utils.AssertTrue(expected[i, j] == actual[i, j]);
      }
    }
  }
}

 
 */
/*
 Test Case 1 passed!
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
Test Case 2 passed!
Expected Output
[
  [1, -1]
]
Your Code's Output
[
  [1, -1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1],
    [-1]
  ]
}
Test Case 3 passed!
Expected Output
[
  [1],
  [2],
  [3]
]
Your Code's Output
[
  [1],
  [2],
  [3]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 2, 3]
  ]
}
Test Case 4 passed!
Expected Output
[
  [1, 2, 3]
]
Your Code's Output
[
  [1, 2, 3]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1],
    [2],
    [3]
  ]
}
Test Case 5 passed!
Expected Output
[
  [1, 4],
  [2, 5],
  [3, 6]
]
Your Code's Output
[
  [1, 4],
  [2, 5],
  [3, 6]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 2, 3],
    [4, 5, 6]
  ]
}
Test Case 6 passed!
Expected Output
[
  [0, 1],
  [0, 1],
  [0, 1]
]
Your Code's Output
[
  [0, 1],
  [0, 1],
  [0, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0],
    [1, 1, 1]
  ]
}
Test Case 7 passed!
Expected Output
[
  [0, 0, 0],
  [1, 1, 1]
]
Your Code's Output
[
  [0, 0, 0],
  [1, 1, 1]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 1],
    [0, 1],
    [0, 1]
  ]
}
Test Case 8 passed!
Expected Output
[
  [0, 0],
  [0, 0],
  [0, 0]
]
Your Code's Output
[
  [0, 0],
  [0, 0],
  [0, 0]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0],
    [0, 0, 0]
  ]
}
Test Case 9 passed!
Expected Output
[
  [1, 2, 3],
  [4, 5, 6]
]
Your Code's Output
[
  [1, 2, 3],
  [4, 5, 6]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4],
    [2, 5],
    [3, 6]
  ]
}
Test Case 10 passed!
Expected Output
[
  [-7, 100, -33],
  [-7, 12, 17]
]
Your Code's Output
[
  [-7, 100, -33],
  [-7, 12, 17]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-7, -7],
    [100, 12],
    [-33, 17]
  ]
}
Test Case 11 passed!
Expected Output
[
  [1, 4, 7],
  [2, 5, 8],
  [3, 6, 9]
]
Your Code's Output
[
  [1, 4, 7],
  [2, 5, 8],
  [3, 6, 9]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
  ]
}
Test Case 12 passed!
Expected Output
[
  [1, 2, 3],
  [4, 5, 6],
  [7, 8, 9]
]
Your Code's Output
[
  [1, 2, 3],
  [4, 5, 6],
  [7, 8, 9]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7],
    [2, 5, 8],
    [3, 6, 9]
  ]
}
Test Case 13 passed!
Expected Output
[
  [5, -3, 0],
  [6, 6, 0],
  [3, 5, 3],
  [-3, 2, 12],
  [12, -1, 3]
]
Your Code's Output
[
  [5, -3, 0],
  [6, 6, 0],
  [3, 5, 3],
  [-3, 2, 12],
  [12, -1, 3]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [5, 6, 3, -3, 12],
    [-3, 6, 5, 2, -1],
    [0, 0, 3, 12, 3]
  ]
}
Test Case 14 passed!
Expected Output
[
  [0, 4, 2, 42],
  [-1, 5, 3, 100],
  [-2, 6, -2, 30],
  [-3, 7, -3, -42]
]
Your Code's Output
[
  [0, 4, 2, 42],
  [-1, 5, 3, 100],
  [-2, 6, -2, 30],
  [-3, 7, -3, -42]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, -1, -2, -3],
    [4, 5, 6, 7],
    [2, 3, -2, -3],
    [42, 100, 30, -42]
  ]
}
Test Case 15 passed!
Expected Output
[
  [1234, -23459, 100],
  [6935, 314159, 3],
  [4205, 0, 987654]
]
Your Code's Output
[
  [1234, -23459, 100],
  [6935, 314159, 3],
  [4205, 0, 987654]
]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1234, 6935, 4205],
    [-23459, 314159, 0],
    [100, 3, 987654]
  ]
}
 */