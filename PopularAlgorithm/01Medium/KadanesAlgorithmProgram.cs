using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._01Medium
{
    class KadanesAlgorithmProgram
    {
        public static int KadanesAlgorithm(int[] array)
        {
            // Write your code here.
            int maxEndingHere = array[0];
            int maxSoFar = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                int num = array[i];
                maxEndingHere = Math.Max(num, maxEndingHere + num);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 };
    Utils.AssertTrue(Program.KadanesAlgorithm(input) == 19);
  }
}

19 / 19 test cases passed.

Test Case 1 passed!
Expected Output
19
Your Code's Output
19
View Outputs Side By Side
Input(s)
{
  "array": [3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4]
}
Test Case 2 passed!
Expected Output
55
Your Code's Output
55
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
}
Test Case 3 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [-1, -2, -3, -4, -5, -6, -7, -8, -9, -10]
}
Test Case 4 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [-10, -2, -9, -4, -8, -6, -7, -1, -3, -5]
}
Test Case 5 passed!
Expected Output
35
Your Code's Output
35
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, -20, 7, 8, 9, 10]
}
Test Case 6 passed!
Expected Output
34
Your Code's Output
34
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, -22, 7, 8, 9, 10]
}
Test Case 7 passed!
Expected Output
11
Your Code's Output
11
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, -4, 3, 5, -9, 8, 1, 2]
}
Test Case 8 passed!
Expected Output
16
Your Code's Output
16
View Outputs Side By Side
Input(s)
{
  "array": [3, 4, -6, 7, 8]
}
Test Case 9 passed!
Expected Output
100
Your Code's Output
100
View Outputs Side By Side
Input(s)
{
  "array": [3, 4, -6, 7, 8, -18, 100]
}
Test Case 10 passed!
Expected Output
101
Your Code's Output
101
View Outputs Side By Side
Input(s)
{
  "array": [3, 4, -6, 7, 8, -15, 100]
}
Test Case 11 passed!
Expected Output
23
Your Code's Output
23
View Outputs Side By Side
Input(s)
{
  "array": [8, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4]
}
Test Case 12 passed!
Expected Output
24
Your Code's Output
24
View Outputs Side By Side
Input(s)
{
  "array": [8, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 6]
}
Test Case 13 passed!
Expected Output
22
Your Code's Output
22
View Outputs Side By Side
Input(s)
{
  "array": [8, 5, -9, 1, 3, -2, 3, 4, 7, 2, -18, 6, 3, 1, -5, 6]
}
Test Case 14 passed!
Expected Output
35
Your Code's Output
35
View Outputs Side By Side
Input(s)
{
  "array": [8, 5, -9, 1, 3, -2, 3, 4, 7, 2, -18, 6, 3, 1, -5, 6, 20, -23, 15, 1, -3, 4]
}
Test Case 15 passed!
Expected Output
135
Your Code's Output
135
View Outputs Side By Side
Input(s)
{
  "array": [100, 8, 5, -9, 1, 3, -2, 3, 4, 7, 2, -18, 6, 3, 1, -5, 6, 20, -23, 15, 1, -3, 4]
}
Test Case 16 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [-1000, -1000, 2, 4, -5, -6, -7, -8, -2, -100]
}
Test Case 17 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [-2, -1]
}
Test Case 18 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [-2, 1]
}
Test Case 19 passed!
Expected Output
-10
Your Code's Output
-10
View Outputs Side By Side
Input(s)
{
  "array": [-10]
}

 */