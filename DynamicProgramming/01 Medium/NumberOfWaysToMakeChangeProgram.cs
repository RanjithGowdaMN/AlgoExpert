using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._01_Medium
{
    class NumberOfWaysToMakeChangeProgram
    {
        public static int NumberOfWaysToMakeChange(int n, int[] denoms)
        {
            // Write your code here.

            int[] ways = new int[n + 1];
            ways[0] = 1;
            foreach (int denom in denoms)
            {
                for (int amount = 1; amount < n + 1; amount++)
                {
                    if (denom <= amount)
                    {
                        ways[amount] = ways[amount] + ways[amount - denom];
                    }
                }
            }
            return ways[n];
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = { 1, 5 };
    Utils.AssertTrue(Program.NumberOfWaysToMakeChange(6, input) == 2);
  }
}

0 / 10 test cases passed.

Test Case 1 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5],
  "n": 6
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "denoms": [2, 3, 4, 7],
  "n": 0
}
Test Case 3 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "denoms": [5],
  "n": 9
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "denoms": [2, 4],
  "n": 7
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10, 25],
  "n": 4
}
Test Case 6 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10, 25],
  "n": 5
}
Test Case 7 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10, 25],
  "n": 10
}
Test Case 8 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "denoms": [1, 5, 10, 25],
  "n": 25
}
Test Case 9 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "denoms": [2, 3, 7],
  "n": 12
}
Test Case 10 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "denoms": [2, 3, 4, 7],
  "n": 7
}
 */