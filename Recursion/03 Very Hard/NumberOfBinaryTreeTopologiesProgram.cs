using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._03_Very_Hard
{
    class NumberOfBinaryTreeTopologiesProgram
    {
        public static int NumberOfBinaryTreeTopologies(int n)
        {
            // Write your code here.
            //O(n^2) time | O(n) space
            List<int> cache = new List<int>();
            cache.Add(1);
            for (int m = 1; m < n + 1; m++)
            {
                int numberOfTrees = 0;
                for (int leftTreeSize = 0; leftTreeSize < m; leftTreeSize++)
                {
                    int rightTreeSize = m - 1 - leftTreeSize;
                    int numberOfLeftTrees = cache[leftTreeSize];
                    int numberOfRightTrees = cache[rightTreeSize];
                    numberOfTrees += numberOfLeftTrees * numberOfRightTrees;
                }
                cache.Add(numberOfTrees);
            }
            return cache[n];
        }
    }
}
/*
public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(Program.NumberOfBinaryTreeTopologies(3) == 5);
  }
}

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
5
Our Code's Output
5
View Outputs Side By Side
Input(s)
{
  "n": 3
}
Test Case 2 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "n": 0
}
Test Case 3 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "n": 1
}
Test Case 4 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "n": 2
}
Test Case 5 passed!
Expected Output
14
Our Code's Output
14
View Outputs Side By Side
Input(s)
{
  "n": 4
}
Test Case 6 passed!
Expected Output
42
Our Code's Output
42
View Outputs Side By Side
Input(s)
{
  "n": 5
}
Test Case 7 passed!
Expected Output
132
Our Code's Output
132
View Outputs Side By Side
Input(s)
{
  "n": 6
}
Test Case 8 passed!
Expected Output
429
Our Code's Output
429
View Outputs Side By Side
Input(s)
{
  "n": 7
}
Test Case 9 passed!
Expected Output
1430
Our Code's Output
1430
View Outputs Side By Side
Input(s)
{
  "n": 8
}
Test Case 10 passed!
Expected Output
4862
Our Code's Output
4862
View Outputs Side By Side
Input(s)
{
  "n": 9
}
Test Case 11 passed!
Expected Output
16796
Our Code's Output
16796
View Outputs Side By Side
Input(s)
{
  "n": 10
}
Test Case 12 passed!
Expected Output
58786
Our Code's Output
58786
View Outputs Side By Side
Input(s)
{
  "n": 11
} 

 
 */