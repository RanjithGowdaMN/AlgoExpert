using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class WaterAreaProgram
    {
        public static int WaterArea(int[] heights)
        {
            // Write your code here.
            int[] maxes = new int[heights.Length];
            int leftmax = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int height = heights[i];
                maxes[i] = leftmax;
                leftmax = Math.Max(leftmax, height);
            }
            int rightmax = 0;
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                int height = heights[i];
                int minHeight = Math.Min(rightmax, maxes[i]);
                if (height < minHeight)
                {
                    maxes[i] = minHeight - height;
                }
                else
                {
                    maxes[i] = 0;
                }
                rightmax = Math.Max(rightmax, height);
            }
            int total = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                total += maxes[i];
            }


            return total;
        }
    }
}

/*
 
public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 };
    Utils.AssertTrue(Program.WaterArea(input) == 48);
  }
}


 14 / 14 test cases passed.

Test Case 1 passed!
Expected Output
48
Your Code's Output
48
View Outputs Side By Side
Input(s)
{
  "heights": [0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3]
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "heights": []
}
Test Case 3 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "heights": [0, 0, 0, 0, 0]
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "heights": [0, 1, 0, 0, 0]
}
Test Case 5 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "heights": [0, 1, 1, 0, 0]
}
Test Case 6 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "heights": [0, 1, 2, 1, 1]
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "heights": [0, 1, 0, 1, 0]
}
Test Case 8 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "heights": [0, 1, 0, 1, 0, 2, 0, 3]
}
Test Case 9 passed!
Expected Output
49
Your Code's Output
49
View Outputs Side By Side
Input(s)
{
  "heights": [0, 8, 0, 0, 10, 0, 0, 10, 0, 0, 1, 1, 0, 3]
}
Test Case 10 passed!
Expected Output
1075
Your Code's Output
1075
View Outputs Side By Side
Input(s)
{
  "heights": [0, 100, 0, 0, 10, 1, 1, 10, 1, 0, 1, 1, 0, 100]
}
Test Case 11 passed!
Expected Output
39
Your Code's Output
39
View Outputs Side By Side
Input(s)
{
  "heights": [0, 100, 0, 0, 10, 1, 1, 10, 1, 0, 1, 1, 0, 0]
}
Test Case 12 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "heights": [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8]
}
Test Case 13 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "heights": [8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 14 passed!
Expected Output
19
Your Code's Output
19
View Outputs Side By Side
Input(s)
{
  "heights": [1, 8, 6, 2, 5, 4, 8, 3, 7]
}
 */