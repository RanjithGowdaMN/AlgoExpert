using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03_Hard
{
    public static class SubArraySortProgram
    {
        public static int[] SubArraySort(int[] array)
        {
            // Write your code here.
            int leftValue = -1;
            int rightValue = -1;

            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < maxValue)
                {
                    leftValue = i;
                }
                else
                {
                    maxValue = array[i];
                }
            }

            int minValue = array[array.Length - 1];
            for (int j = array.Length - 1; j >= 0; j--)
            {
                if (array[j] > minValue)
                {
                    rightValue = j;
                }
                else
                {
                    minValue = array[j];
                }
            }
            return new int[] { rightValue, leftValue };
        }
    }
}
/*
 using System.Linq;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] expected = { 3, 9 };
    Utils.AssertTrue(Enumerable.SequenceEqual(
      Program.SubarraySort(
        new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 }
      ),
      expected
    ));
  }
}
17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
[3, 9]
Your Code's Output
[3, 9]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19]
}
Test Case 2 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2]
}
Test Case 3 passed!
Expected Output
[0, 1]
Your Code's Output
[0, 1]
View Outputs Side By Side
Input(s)
{
  "array": [2, 1]
}
Test Case 4 passed!
Expected Output
[4, 9]
Your Code's Output
[4, 9]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 4, 7, 10, 11, 7, 12, 7, 7, 16, 18, 19]
}
Test Case 5 passed!
Expected Output
[4, 6]
Your Code's Output
[4, 6]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 4, 7, 10, 11, 7, 12, 13, 14, 16, 18, 19]
}
Test Case 6 passed!
Expected Output
[2, 4]
Your Code's Output
[2, 4]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 8, 4, 5]
}
Test Case 7 passed!
Expected Output
[0, 12]
Your Code's Output
[0, 12]
View Outputs Side By Side
Input(s)
{
  "array": [4, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 51, 7]
}
Test Case 8 passed!
Expected Output
[0, 11]
Your Code's Output
[0, 11]
View Outputs Side By Side
Input(s)
{
  "array": [4, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 11, 57]
}
Test Case 9 passed!
Expected Output
[1, 11]
Your Code's Output
[1, 11]
View Outputs Side By Side
Input(s)
{
  "array": [-41, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 11, 57]
}
Test Case 10 passed!
Expected Output
[1, 12]
Your Code's Output
[1, 12]
View Outputs Side By Side
Input(s)
{
  "array": [-41, 8, 7, 12, 11, 9, -1, 3, 9, 16, -15, 51, 7]
}
Test Case 11 passed!
Expected Output
[6, 7]
Your Code's Output
[6, 7]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 8, 7, 9, 10, 11]
}
Test Case 12 passed!
Expected Output
[6, 16]
Your Code's Output
[6, 16]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 18, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19]
}
Test Case 13 passed!
Expected Output
[4, 24]
Your Code's Output
[4, 24]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 18, 21, 22, 7, 14, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19, 4, 14, 11, 6, 33, 35, 41, 55]
}
Test Case 14 passed!
Expected Output
[2, 19]
Your Code's Output
[2, 19]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 20, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
}
Test Case 15 passed!
Expected Output
[2, 19]
Your Code's Output
[2, 19]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 2]
}
Test Case 16 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]
}
Test Case 17 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
}

 
 */