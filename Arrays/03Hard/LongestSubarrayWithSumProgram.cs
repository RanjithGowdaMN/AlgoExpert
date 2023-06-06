using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03Hard
{
    class LongestSubarrayWithSumProgram
    {
        public int[] LongestSubarrayWithSum(int[] array, int targetSum)
        {
            // Write your code here.
            int[] indices = new int[] { };

            int currentSubArraySum = 0;
            int startIdx = 0;
            int endIdx = 0;

            while (endIdx < array.Length)
            {
                currentSubArraySum += array[endIdx];
                while (startIdx < endIdx && currentSubArraySum > targetSum)
                {
                    currentSubArraySum -= array[startIdx];
                    startIdx++;
                }

                if (currentSubArraySum == targetSum)
                {
                    if (indices.Length == 0 ||
                      indices[1] - indices[0] < endIdx - startIdx)
                    {
                        indices = new int[] { startIdx, endIdx };
                    }
                }
                endIdx++;
            }


            return indices;
        }
    }
}

/*
 Test Case 1 passed!
Expected Output
[4, 8]
Your Code's Output
[4, 8]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 3, 3, 1, 2, 1],
  "targetSum": 10
}
Test Case 2 passed!
Expected Output
[4, 13]
Your Code's Output
[4, 13]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 0, 0, 0, 0, 0, 3, 3, 1, 2, 1],
  "targetSum": 10
}
Test Case 3 passed!
Expected Output
[0, 9]
Your Code's Output
[0, 9]
View Outputs Side By Side
Input(s)
{
  "array": [0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
  "targetSum": 1
}
Test Case 4 passed!
Expected Output
[0, 9]
Your Code's Output
[0, 9]
View Outputs Side By Side
Input(s)
{
  "array": [0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
  "targetSum": 1
}
Test Case 5 passed!
Expected Output
[4, 11]
Your Code's Output
[4, 11]
View Outputs Side By Side
Input(s)
{
  "array": [25, 25, 25, 25, 100, 0, 0, 0, 0, 0, 0, 0],
  "targetSum": 100
}
Test Case 6 passed!
Expected Output
[0, 4]
Your Code's Output
[0, 4]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 5, 5, 5],
  "targetSum": 15
}
Test Case 7 passed!
Expected Output
[11, 23]
Your Code's Output
[11, 23]
View Outputs Side By Side
Input(s)
{
  "array": [0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 5, 5, 5, 5, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1],
  "targetSum": 20
}
Test Case 8 passed!
Expected Output
[0, 7]
Your Code's Output
[0, 7]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 0, 0, 0, 6, 7, 8, 9, 10],
  "targetSum": 15
}
Test Case 9 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [61, 54, 1, 499, 2212, 4059, 1, 2, 3, 1, 3],
  "targetSum": 19
}
Test Case 10 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0],
  "targetSum": 0
}
Test Case 11 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [10],
  "targetSum": 10
}
Test Case 12 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [5],
  "targetSum": 0
}
Test Case 13 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [5],
  "targetSum": 10
}
Test Case 14 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 0, 1],
  "targetSum": 3
}
Test Case 15 passed!
Expected Output
[0, 9]
Your Code's Output
[0, 9]
View Outputs Side By Side
Input(s)
{
  "array": [0, 0, 0, 0, 39, 0, 0, 0, 0, 0, 28, 10],
  "targetSum": 39
}
Test Case 16 passed!
Expected Output
[6, 15]
Your Code's Output
[6, 15]
View Outputs Side By Side
Input(s)
{
  "array": [1, 4, 10, 15, 31, 7, 1, 40, 0, 20, 1, 1, 1, 1, 2, 1],
  "targetSum": 68
}
 */