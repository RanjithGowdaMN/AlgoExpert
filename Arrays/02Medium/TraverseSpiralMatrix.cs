using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class TraverseSpiralMatrix
    {

        public static List<int> SpiralTraverse(int[,] array)
        {
            // Write your code here.

            int[] result= new int[array.GetLength(0) * array.GetLength(1)];

            int startRow = 0;
            int endRow = array.GetLength(0)-1;
            int startCol = 0;
            int endCol = array.GetLength(1)-1;
            int index = 0;
            while (startRow<=endRow && startRow<=endCol)
            {

                //Right
                for (int i = startCol; i <= endCol; i++)
                {
                    result[index++] = array[startRow, i];
                }

                //Down
                for (int i = startRow + 1; i <= endRow ; i++)
                {
                    result[index++] = array[i, endCol];
                }
                for (int i = endCol-1; i >= startCol; i--)
                {
                    if (startRow == endRow)
                    {
                        break;
                    }
                    result[index++] = array[endRow, i];
                }
                for (int i = endRow - 1; i > startRow; i--)
                {
                    if (startCol == endCol)
                    {
                        break;
                    }
                    result[index++] = array[i, startCol];
                }

                startRow++;
                endRow--;
                startCol++;
                endCol--;
            }


            return result.ToList();
        }



    }


}
/*
 using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[,] input = {
      { 1, 2, 3, 4 },
      { 12, 13, 14, 5 },
      { 11, 16, 15, 6 },
      { 10, 9, 8, 7 },
    };
    var expected =
      new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
    var actual = Program.SpiralTraverse(input);
    Utils.AssertTrue(expected.SequenceEqual(actual));
  }
}

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 2, 3, 4],
    [12, 13, 14, 5],
    [11, 16, 15, 6],
    [10, 9, 8, 7]
  ]
}
Test Case 2 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1]
  ]
}
Test Case 3 passed!
Expected Output
[1, 2, 3, 4]
Your Code's Output
[1, 2, 3, 4]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 2],
    [4, 3]
  ]
}
Test Case 4 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 2, 3],
    [8, 9, 4],
    [7, 6, 5]
  ]
}
Test Case 5 passed!
Expected Output
[19, 32, 33, 34, 25, 8, 11, 9, 6, 7, 10, 27, 28, 29, 30, 17, 20, 1, 18, 16, 15, 14, 13, 12, 26, 5, 24, 23, 22, 21, 2, 31, 36, 35, 4, 3]
Your Code's Output
[19, 32, 33, 34, 25, 8, 11, 9, 6, 7, 10, 27, 28, 29, 30, 17, 20, 1, 18, 16, 15, 14, 13, 12, 26, 5, 24, 23, 22, 21, 2, 31, 36, 35, 4, 3]
View Outputs Side By Side
Input(s)
{
  "array": [
    [19, 32, 33, 34, 25, 8],
    [16, 15, 14, 13, 12, 11],
    [18, 31, 36, 35, 26, 9],
    [1, 2, 3, 4, 5, 6],
    [20, 21, 22, 23, 24, 7],
    [17, 30, 29, 28, 27, 10]
  ]
}
Test Case 6 passed!
Expected Output
[4, 2, 3, 6, 7, 8, 1, 9, 5, 10, 14, 11, 17, 13, 18, 20, 16, 15, 19, 12]
Your Code's Output
[4, 2, 3, 6, 7, 8, 1, 9, 5, 10, 14, 11, 17, 13, 18, 20, 16, 15, 19, 12]
View Outputs Side By Side
Input(s)
{
  "array": [
    [4, 2, 3, 6, 7, 8, 1, 9, 5, 10],
    [12, 19, 15, 16, 20, 18, 13, 17, 11, 14]
  ]
}
Test Case 7 passed!
Expected Output
[27, 12, 35, 26, 11, 56, 18, 94, 16, 90, 11, 93, 96, 55, 19, 25, 21, 94, 43, 10, 31, 83, 36, 96]
Your Code's Output
[27, 12, 35, 26, 11, 56, 18, 94, 16, 90, 11, 93, 96, 55, 19, 25, 21, 94, 43, 10, 31, 83, 36, 96]
View Outputs Side By Side
Input(s)
{
  "array": [
    [27, 12, 35, 26],
    [25, 21, 94, 11],
    [19, 96, 43, 56],
    [55, 36, 10, 18],
    [96, 83, 31, 94],
    [93, 11, 90, 16]
  ]
}
Test Case 8 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 2, 3, 4],
    [10, 11, 12, 5],
    [9, 8, 7, 6]
  ]
}
Test Case 9 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 2, 3],
    [12, 13, 4],
    [11, 14, 5],
    [10, 15, 6],
    [9, 8, 7]
  ]
}
Test Case 10 passed!
Expected Output
[1, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2]
Your Code's Output
[1, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 11],
    [2, 12],
    [3, 13],
    [4, 14],
    [5, 15],
    [6, 16],
    [7, 17],
    [8, 18],
    [9, 19],
    [10, 20]
  ]
}
Test Case 11 passed!
Expected Output
[1, 3, 2, 5, 4, 7, 6]
Your Code's Output
[1, 3, 2, 5, 4, 7, 6]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 3, 2, 5, 4, 7, 6]
  ]
}
Test Case 12 passed!
Expected Output
[1, 3, 2, 5, 4, 7, 6]
Your Code's Output
[1, 3, 2, 5, 4, 7, 6]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1],
    [3],
    [2],
    [5],
    [4],
    [7],
    [6]
  ]
}
 
 */