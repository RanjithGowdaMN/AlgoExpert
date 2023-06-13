using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class MinNumberOfJumpsProgram
    {
        public static void Main()
        {
            MinNumberOfJumpsSol2(new int[] { 3,4,2,1,2,3,7,1,1,1,3 });
        }
        public static int MinNumberOfJumpsSol1(int[] array)
        {
            // Write your code here.
            int[] jumps = new int[array.Length];
            Array.Fill(jumps, Int32.MaxValue);
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] + j > i)
                    {
                        jumps[i] = Math.Min(jumps[j] + 1, jumps[i]);
                    }
                }
            }
            return jumps[jumps.Length - 1];
        }

        public static int MinNumberOfJumpsSol2(int[] array)
        {
            // Write your code here.
            if (array.Length == 1)
            {
                return 0;
            }
            int jumps = 0;
            int maxReach = array[0];
            int steps = array[0];
            for (int i = 1; i < array.Length - 1; i++)
            {
                maxReach = Math.Max(maxReach, i + array[i]);
                steps--;
                if (steps == 0)
                {
                    jumps++;
                    steps = maxReach - i;
                }
            }

            return jumps + 1;
        }
    }
}

/*
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3]
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [1]
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [1, 1]
}
Test Case 4 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [3, 1]
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1]
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [2, 1, 1]
}
Test Case 7 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [2, 1, 2, 3, 1]
}
Test Case 8 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [2, 1, 2, 3, 1, 1, 1]
}
Test Case 9 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [2, 1, 2, 2, 1, 1, 1]
}
Test Case 10 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3, 2, 6, 2, 1, 1, 1, 1]
}
Test Case 11 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "array": [3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3, 2, 3, 2, 1, 1, 1, 1]
}
Test Case 12 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [3, 10, 2, 1, 2, 3, 7, 1, 1, 1, 3, 2, 3, 2, 1, 1, 1, 1]
}
Test Case 13 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [3, 12, 2, 1, 2, 3, 7, 1, 1, 1, 3, 2, 3, 2, 1, 1, 1, 1]
}
Test Case 14 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [3, 12, 2, 1, 2, 3, 15, 1, 1, 1, 3, 2, 3, 2, 1, 1, 1, 1]
}
*/