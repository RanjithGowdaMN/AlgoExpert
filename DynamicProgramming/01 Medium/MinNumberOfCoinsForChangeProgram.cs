using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._01_Medium
{
    class MinNumberOfCoinsForChangeProgram
    {
        public static int MinNumberOfCoinsForChange(int n, int[] denoms)
        {
            // Write your code here.
            int[] ways = new int[n + 1];
            Array.Fill(ways, Int32.MaxValue);
            ways[0] = 0;
            int toCompare = 0;
            foreach (int denom in denoms)
            {
                for (int amount = 0; amount <= n; amount++)
                {
                    if (denom <= amount)
                    {
                        if (ways[amount - denom] == Int32.MaxValue)
                        {
                            toCompare = ways[amount - denom];
                        }
                        else
                        {
                            toCompare = ways[amount - denom] + 1;
                        }
                        ways[amount] = Math.Min(ways[amount], toCompare);
                    }
                }
            }
            return ways[n] != Int32.MaxValue ? ways[n] : -1;
        }
    }
}

/*

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = { 1, 5, 10 };
    Utils.AssertTrue(Program.MinNumberOfCoinsForChange(7, input) == 3);
  }
}


7 / 17 test cases passed.

Test Case 1 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10],
  "n": 7
}
Test Case 2 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 10, 5],
  "n": 7
}
Test Case 3 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [10, 1, 5],
  "n": 7
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 2, 3],
  "n": 0
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "denoms": [2, 1],
  "n": 3
}
Test Case 6 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10],
  "n": 4
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10],
  "n": 10
}
Test Case 8 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10],
  "n": 11
}
Test Case 9 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10],
  "n": 24
}
Test Case 10 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10],
  "n": 25
}
Test Case 11 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "denoms": [2, 4],
  "n": 7
}
Test Case 12 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "denoms": [3, 7],
  "n": 7
}
Test Case 13 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [3, 5],
  "n": 9
}
Test Case 14 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "denoms": [3, 4, 5],
  "n": 9
}
Test Case 15 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [39, 45, 130, 40, 4, 1],
  "n": 135
}
Test Case 16 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "denoms": [39, 45, 130, 40, 4, 1, 60, 75],
  "n": 135
}
Test Case 17 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 3, 4],
  "n": 10
}

*/