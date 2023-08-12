using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._01_Medium
{
    class MaxSubsetSumNoAdjacentProgram
    {
        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            // Write your code here.
            if (array.Length == 0)
            {
                return 0;
            }
            else if (array.Length == 1)
            {
                return array[0];
            }

            int[] maxSum = (int[])array.Clone();
            maxSum[1] = Math.Max(array[1], array[0]);

            for (int i = 2; i < array.Length; i++)
            {
                maxSum[i] = Math.Max(maxSum[i - 1], array[i] + maxSum[i - 2]);
            }

            return maxSum[array.Length - 1];
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = { 75, 105, 120, 75, 90, 135 };
    Utils.AssertTrue(Program.MaxSubsetSumNoAdjacent(input) == 330);
  }
}

4 / 14 test cases passed.

Test Case 1 passed!
Expected Output
330
Your Code's Output
330
View Outputs Side By Side
Input(s)
{
  "array": [75, 105, 120, 75, 90, 135]
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": []
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [1]
}
Test Case 4 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [1, 2]
}
Test Case 5 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3]
}
Test Case 6 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "array": [1, 15, 3]
}
Test Case 7 passed!
Expected Output
33
Your Code's Output
33
View Outputs Side By Side
Input(s)
{
  "array": [7, 10, 12, 7, 9, 14]
}
Test Case 8 passed!
Expected Output
207
Your Code's Output
207
View Outputs Side By Side
Input(s)
{
  "array": [4, 3, 5, 200, 5, 3]
}
Test Case 9 passed!
Expected Output
60
Your Code's Output
60
View Outputs Side By Side
Input(s)
{
  "array": [10, 5, 20, 25, 15, 5, 5, 15]
}
Test Case 10 passed!
Expected Output
90
Your Code's Output
90
View Outputs Side By Side
Input(s)
{
  "array": [10, 5, 20, 25, 15, 5, 5, 15, 3, 15, 5, 5, 15]
}
Test Case 11 passed!
Expected Output
675
Your Code's Output
675
View Outputs Side By Side
Input(s)
{
  "array": [125, 210, 250, 120, 150, 300]
}
Test Case 12 passed!
Expected Output
180
Your Code's Output
180
View Outputs Side By Side
Input(s)
{
  "array": [30, 25, 50, 55, 100]
}
Test Case 13 passed!
Expected Output
205
Your Code's Output
205
View Outputs Side By Side
Input(s)
{
  "array": [30, 25, 50, 55, 100, 120]
}
Test Case 14 passed!
Expected Output
72
Your Code's Output
72

 */