using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class MaximizeExpressionProgram
    {
        public int MaximizeExpression(int[] array)
        {
            // Write your code here.
            if (array.Length < 4)
            {
                return 0;
            }

            List<int> maxOfA = new List<int>{
          array[0]
        };

            List<int> maxOfAminusB = new List<int>{
          Int32.MinValue
        };

            List<int> maxOfAminusBplusC = new List<int>{
          Int32.MinValue, Int32.MinValue
        };

            List<int> maxOfAminusBplusCminusD = new List<int>{
          Int32.MinValue, Int32.MinValue, Int32.MinValue
        };

            for (int i = 1; i < array.Length; i++)
            {
                int currentMax = Math.Max(maxOfA[i - 1], array[i]);
                maxOfA.Add(currentMax);
            }

            for (int i = 1; i < array.Length; i++)
            {
                int currentMax = Math.Max(maxOfAminusB[i - 1], maxOfA[i - 1] - array[i]);
                maxOfAminusB.Add(currentMax);
            }

            for (int i = 2; i < array.Length; i++)
            {
                int currentMax = Math.Max(maxOfAminusBplusC[i - 1], maxOfAminusB[i - 1] + array[i]);
                maxOfAminusBplusC.Add(currentMax);
            }

            for (int i = 3; i < array.Length; i++)
            {
                int currentMax = Math.Max(maxOfAminusBplusCminusD[i - 1], maxOfAminusBplusC[i - 1] - array[i]);
                maxOfAminusBplusCminusD.Add(currentMax);
            }

            return maxOfAminusBplusCminusD[maxOfAminusBplusCminusD.Count - 1];
        }
    }
}
/*
 Test Case 1 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
 "array": [3, 6, 1, -3, 2, 7]
}
Test Case 2 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
 "array": [3, 9, 10, 1, 30, 40]
}
Test Case 3 passed!
Expected Output
46
Your Code's Output
46
View Outputs Side By Side
Input(s)
{
 "array": [40, 30, 1, 10, 9, 3]
}
Test Case 4 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
 "array": [-1, 2, -1, -2, -2, 1, -1]
}
Test Case 5 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
 "array": [10, 5, 10, 5]
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
 "array": [0, 0, 0, 0, 0, 0, 0, 1, 1, 0]
}
Test Case 7 passed!
Expected Output
209
Your Code's Output
209
View Outputs Side By Side
Input(s)
{
 "array": [34, 21, 22, 0, -98, -72, 100, 23]
}
Test Case 8 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
 "array": [5, 2, 2, 1, -2, 2, -9, 0]
}
Test Case 9 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
 "array": [1, 1, 1, 1]
}
Test Case 10 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
 "array": [1, -1, 1, -1]
}
Test Case 11 passed!
Expected Output
22
Your Code's Output
22
View Outputs Side By Side
Input(s)
{
 "array": [3, 6, 1, 2, -9, -2, 1, 3, 4, -3, 2]
}
Test Case 12 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
 "array": [1, -1, 1, -1, -2]
}
Test Case 13 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
 "array": [3, -1, 1, -1, -2, 4, 5, -4]
}
Test Case 14 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
 "array": [-1, 2, -3, -3, 2, -1]
}
Test Case 15 passed!
Expected Output
24
Your Code's Output
24
View Outputs Side By Side
Input(s)
{
 "array": [6, 2, 3, 4, 1, -1, -2, 3, 1, 7, 8, -8, 2, 5, 1]
}
Test Case 16 passed!
Expected Output
-10
Your Code's Output
-10
View Outputs Side By Side
Input(s)
{
 "array": [5, 10, 5, 10]
}
Test Case 17 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
 "array": [2, 3]
}
Test Case 18 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
 "array": [2, 3, 4]
}
Test Case 19 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
 "array": [1]
}
Test Case 20 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
 "array": []
}
 */