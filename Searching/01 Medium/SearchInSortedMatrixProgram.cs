using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching._01_Medium
{
    class SearchInSortedMatrixProgram
    {
        public static int[] SearchInSortedMatrix(int[,] matrix, int target)
        {
            // Write your code here.
            int row = 0;
            int col = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(0) && col >= 0)
            {
                if (matrix[row, col] > target)
                {
                    col--;
                }
                else if (matrix[row, col] < target)
                {
                    row++;
                }
                else
                {
                    return new int[] { row, col };
                }
            }

            return new int[] { -1, -1 };
        }
    }
}
/*
 Test Case 1 passed!
Expected Output
[3, 3]
Your Code's Output
[3, 3]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 44
}
Test Case 2 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 1
}
Test Case 3 passed!
Expected Output
[1, 0]
Your Code's Output
[1, 0]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 2
}
Test Case 4 passed!
Expected Output
[0, 1]
Your Code's Output
[0, 1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 4
}
Test Case 5 passed!
Expected Output
[0, 4]
Your Code's Output
[0, 4]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 15
}
Test Case 6 passed!
Expected Output
[0, 3]
Your Code's Output
[0, 3]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 12
}
Test Case 7 passed!
Expected Output
[1, 4]
Your Code's Output
[1, 4]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 32
}
Test Case 8 passed!
Expected Output
[4, 0]
Your Code's Output
[4, 0]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 99
}
Test Case 9 passed!
Expected Output
[4, 1]
Your Code's Output
[4, 1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 100
}
Test Case 10 passed!
Expected Output
[3, 0]
Your Code's Output
[3, 0]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 40
}
Test Case 11 passed!
Expected Output
[4, 4]
Your Code's Output
[4, 4]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 128
}
Test Case 12 passed!
Expected Output
[4, 3]
Your Code's Output
[4, 3]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 106
}
Test Case 13 passed!
Expected Output
[3, 4]
Your Code's Output
[3, 4]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 45
}
Test Case 14 passed!
Expected Output
[2, 2]
Your Code's Output
[2, 2]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 24
}
Test Case 15 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 43
}
Test Case 16 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": -1
}
Test Case 17 passed!
Expected Output
[0, 5]
Your Code's Output
[0, 5]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 1000
}
Test Case 18 passed!
Expected Output
[4, 5]
Your Code's Output
[4, 5]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 4, 7, 12, 15, 1000],
    [2, 5, 19, 31, 32, 1001],
    [3, 8, 24, 33, 35, 1002],
    [40, 41, 42, 44, 45, 1003],
    [99, 100, 103, 106, 128, 1004]
  ],
  "target": 1004
}
 
 */