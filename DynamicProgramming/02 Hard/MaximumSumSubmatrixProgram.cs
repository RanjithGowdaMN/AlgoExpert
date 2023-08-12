using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class MaximumSumSubmatrixProgram
    {
        public int MaximumSumSubmatrix(int[,] matrix, int size)
        {
            // Write your code here.
            int[,] sums = createSumMatrix(matrix);
            int maxSubSum = Int32.MinValue;

            for (int row = size - 1; row < matrix.GetLength(0); row++)
            {
                for (int col = size - 1; col < matrix.GetLength(1); col++)
                {
                    int total = sums[row, col];

                    bool touchesTopBorder = (row - size < 0);
                    if (!touchesTopBorder)
                    {
                        total -= sums[row - size, col];
                    }

                    bool touchesLeftBorder = (col - size < 0);
                    if (!touchesLeftBorder)
                    {
                        total -= sums[row, col - size];
                    }

                    bool touchesTopOrLeft = (touchesTopBorder || touchesLeftBorder);
                    if (!touchesTopOrLeft)
                    {
                        total += sums[row - size, col - size];
                    }

                    maxSubSum = Math.Max(maxSubSum, total);
                }
            }
            return maxSubSum;
        }

        public int[,] createSumMatrix(int[,] matrix)
        {
            int[,] sums = new int[matrix.GetLength(0), matrix.GetLength(1)];
            sums[0, 0] = matrix[0, 0];

            //fill the first row
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                sums[0, i] = sums[0, i - 1] + matrix[0, i];
            }
            //fill the first col
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                sums[i, 0] = sums[i - 1, 0] + matrix[i, 0];
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    sums[row, col] = sums[row - 1, col] +
                                     sums[row, col - 1] -
                                     sums[row - 1, col - 1] +
                                     matrix[row, col];

                }
            }
            return sums;
        }
    }
}

/*
 * 
 *
using System;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = { 10, 70, 20, 30, 50, 11, 30 };
    Tuple<int, int[]> expected =
      Tuple.Create(110, new int[] { 10, 20, 30, 50 });
    Utils.AssertTrue(
      compare(Program.MaxSumIncreasingSubsequence(input), expected)
    );
  }

  private static bool compare(List<List<int> > arr1, Tuple<int, int[]> arr2) {
    if (arr1[0][0] != arr2.Item1) {
      return false;
    }
    if (arr1[1].Count != arr2.Item2.Length) {
      return false;
    }
    for (int i = 0; i < arr1[1].Count; i++) {
      if (arr1[1][i] != arr2.Item2[i]) {
        return false;
      }
    }
    return true;
  }
}



 Test Case 1 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [5, 3, -1, 5],
    [-7, 3, 7, 4],
    [12, 8, 0, 0],
    [1, -8, -8, 2]
  ],
  "size": 2
}
Test Case 2 passed!
Expected Output
28
Your Code's Output
28
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [3, -4, 6, -5, 1],
    [1, -2, 8, -4, -2],
    [3, -8, 9, 3, 1],
    [-7, 3, 4, 2, 7],
    [-3, 7, -5, 7, -6]
  ],
  "size": 3
}
Test Case 3 passed!
Expected Output
17
Your Code's Output
17
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [2, 4],
    [5, 6],
    [-3, 2]
  ],
  "size": 2
}
Test Case 4 passed!
Expected Output
38
Your Code's Output
38
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [3, -4, 6, -5, 1],
    [1, -2, 8, -4, -2],
    [3, -8, 9, 3, 1],
    [-7, 3, 4, 2, 7],
    [-3, 7, -5, 7, -6],
    [2, 4, 5, 2, 3]
  ],
  "size": 4
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1]
  ],
  "size": 1
}
Test Case 6 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1],
    [1, 1]
  ],
  "size": 2
}
Test Case 7 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 2, -1],
    [1, 1, 2, -1]
  ],
  "size": 2
}
Test Case 8 passed!
Expected Output
25
Your Code's Output
25
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
  ],
  "size": 5
}
Test Case 9 passed!
Expected Output
45
Your Code's Output
45
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [2, 1, 1, 1, 1, 4, -1, 1, 1, 5],
    [1, -1, 1, 1, 1, 1, -1, 1, 4, 1],
    [-50, 12, -1, 1, 5, 1, -1, 1, 1, 1],
    [-52, 99, 1, -1, 1, 1, -1, 1, 1, 1],
    [1, -10, -287, 9, -1, 1, -1, 1, 1, 1],
    [1, 2, 1, 8, 1, -1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, -1, 1, 1, 1]
  ],
  "size": 6
}
Test Case 10 passed!
Expected Output
-12
Your Code's Output
-12
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, -2, -3, -4, -5],
    [-5, -4, -3, -2, -1],
    [-1, -2, -3, -4, -5]
  ],
  "size": 2
}
Test Case 11 passed!
Expected Output
-24
Your Code's Output
-24
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, -2, -3, -4, -5],
    [-5, -4, -3, -2, -1],
    [-1, -2, -3, -4, -5],
    [-5, -4, -3, -2, -1],
    [-5, -4, -3, -2, -1]
  ],
  "size": 3
}
Test Case 12 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, -2, -3, -4, -5],
    [1, 1, 1, 1, 1],
    [-1, -10, -10, -4, -5],
    [5, 5, 5, 5, 5],
    [-5, -4, -3, -10, -1]
  ],
  "size": 1
}
Test Case 13 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [-1, -2, -3, -4, -5],
    [1, 1, 1, 1, 1],
    [-1, -10, -10, -4, -5],
    [5, 5, 5, 5, 5],
    [-5, -4, -3, -10, -1]
  ],
  "size": 2
}
Test Case 14 passed!
Expected Output
24
Your Code's Output
24
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [3, -4, 6, -5, 1],
    [1, -2, 8, -4, -2],
    [3, -8, 9, 3, 1],
    [-7, 3, 4, 2, 7],
    [-3, 7, -5, 7, -6]
  ],
  "size": 4
}
Test Case 15 passed!
Expected Output
19
Your Code's Output
19
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [3, -4, 6, -5, 1],
    [1, -2, 8, -4, -2],
    [3, -8, 9, 3, 1],
    [-7, 3, 4, 2, 7],
    [-3, 7, -5, 7, -6]
  ],
  "size": 5
}
Test Case 16 passed!
Expected Output
176
Your Code's Output
176
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [22, 24, -9, 23],
    [12, 10, -19, 35],
    [45, -20, -20, 99],
    [0, 0, 0, 0],
    [0, 0, 0, 0],
    [-100, 200, -50, 5],
    [5, 6, 7, 8]
  ],
  "size": 3
}
 
 */
