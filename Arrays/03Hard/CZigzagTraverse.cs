using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03_Hard
{
    class CZigzagTraverse
    {
        public static List<int> ZigzagTraverse(List<List<int>> array)
        {
            // Write your code here.
            int height = array.Count - 1;
            int width = array[0].Count - 1;
            List<int> result = new List<int>();
            int row = 0;
            int col = 0;
            bool goingDown = true;
            while (!isOutOfBound(row, col, height, width))
            {
                result.Add(array[row][col]);
                if (goingDown)
                {
                    if (col == 0 || row == height)
                    {
                        goingDown = false;
                        if (row == height)
                        {
                            col++;
                        }
                        else
                        {
                            row++;
                        }
                    }
                    else
                    {
                        row++;
                        col--;
                    }
                }
                else
                {
                    if (col == width || row == 0)
                    {
                        goingDown = true;
                        if (col == width)
                        {
                            row++;
                        }
                        else
                        {
                            col++;
                        }
                    }
                    else
                    {
                        row--;
                        col++;
                    }
                }
            }
            return result;
        }

        public static bool isOutOfBound(int row, int col, int height, int width)
        {
            return row < 0 || row > height || col < 0 || col > width;
        }
    }
}
/*
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<List<int> > test = new List<List<int> >();
    test.Add(new List<int>() { 1, 3, 4, 10 });
    test.Add(new List<int>() { 2, 5, 9, 11 });
    test.Add(new List<int>() { 6, 8, 12, 15 });
    test.Add(new List<int>() { 7, 13, 14, 16 });
    List<int> expected =
      new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
    Utils.AssertTrue(Program.ZigzagTraverse(test).SequenceEqual(expected));
  }
}

 10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 3, 4, 10],
    [2, 5, 9, 11],
    [6, 8, 12, 15],
    [7, 13, 14, 16]
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
[1, 2, 3, 4, 5]
Your Code's Output
[1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 2, 3, 4, 5]
  ]
}
Test Case 4 passed!
Expected Output
[1, 2, 3, 4, 5]
Your Code's Output
[1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1],
    [2],
    [3],
    [4],
    [5]
  ]
}
Test Case 5 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 3],
    [2, 4],
    [5, 7],
    [6, 8],
    [9, 10]
  ]
}
Test Case 6 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 3, 4, 7, 8],
    [2, 5, 6, 9, 10]
  ]
}
Test Case 7 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 3, 4, 10, 11],
    [2, 5, 9, 12, 19],
    [6, 8, 13, 18, 20],
    [7, 14, 17, 21, 24],
    [15, 16, 22, 23, 25]
  ]
}
Test Case 8 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 3, 4, 10, 11, 20],
    [2, 5, 9, 12, 19, 21],
    [6, 8, 13, 18, 22, 27],
    [7, 14, 17, 23, 26, 28],
    [15, 16, 24, 25, 29, 30]
  ]
}
Test Case 9 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 3, 4, 10, 11],
    [2, 5, 9, 12, 20],
    [6, 8, 13, 19, 21],
    [7, 14, 18, 22, 27],
    [15, 17, 23, 26, 28],
    [16, 24, 25, 29, 30]
  ]
}
Test Case 10 passed!
Expected Output
[1, 10, 21, -3, 11, 6, 7, 8, 112, 4, 15, 12, 113, 2, 15, 16, 17, 18, 19, 20, 6, -7, -1, 21, 22, 23, 24, 27, 226, -27, 0, -2, 88, 9, -3, 0, 12, 28, 299, 30, -28, 32, 0, -4, 0, -111, -226, 29, 32, -23, 66, -17, 31, 88]
Your Code's Output
[1, 10, 21, -3, 11, 6, 7, 8, 112, 4, 15, 12, 113, 2, 15, 16, 17, 18, 19, 20, 6, -7, -1, 21, 22, 23, 24, 27, 226, -27, 0, -2, 88, 9, -3, 0, 12, 28, 299, 30, -28, 32, 0, -4, 0, -111, -226, 29, 32, -23, 66, -17, 31, 88]
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 21, -3, 4, 15, 6, -7, 88, 9],
    [10, 11, 112, 12, 20, -1, -2, -3, -4],
    [6, 8, 113, 19, 21, 0, 0, 0, 0],
    [7, 2, 18, 22, -27, 12, 32, -111, 66],
    [15, 17, 23, 226, 28, -28, -226, -23, -17],
    [16, 24, 27, 299, 30, 29, 32, 31, 88]
  ]
}
 
 */