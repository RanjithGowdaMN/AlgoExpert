using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._00Easy
{
    public class NonConstructible_Change
    {
        public int NonConstructibleChange(int[] coins)
        {
            // Write your code here.
            Array.Sort(coins);

            int curChange = 0;
            foreach (var coin in coins)
            {
                if (coin > curChange + 1)
                {
                    return curChange + 1;
                }
                curChange += coin;
            }

            return curChange + 1;
        }
    }
}

/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = new int[] { 5, 7, 1, 1, 2, 3, 22 };
    int expected = 20;
    var actual = new Program().NonConstructibleChange(input);
    Utils.AssertTrue(expected == actual);
  }
}
13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "coins": [5, 7, 1, 1, 2, 3, 22]
}
Test Case 2 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "coins": [1, 1, 1, 1, 1]
}
Test Case 3 passed!
Expected Output
55
Your Code's Output
55
View Outputs Side By Side
Input(s)
{
  "coins": [1, 5, 1, 1, 1, 10, 15, 20, 100]
}
Test Case 4 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "coins": [6, 4, 5, 1, 1, 8, 9]
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "coins": []
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "coins": [87]
}
Test Case 7 passed!
Expected Output
32
Your Code's Output
32
View Outputs Side By Side
Input(s)
{
  "coins": [5, 6, 1, 1, 2, 3, 4, 9]
}
Test Case 8 passed!
Expected Output
19
Your Code's Output
19
View Outputs Side By Side
Input(s)
{
  "coins": [5, 6, 1, 1, 2, 3, 43]
}
Test Case 9 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "coins": [1, 1]
}
Test Case 10 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "coins": [2]
}
Test Case 11 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "coins": [1]
}
Test Case 12 passed!
Expected Output
87
Your Code's Output
87
View Outputs Side By Side
Input(s)
{
  "coins": [109, 2000, 8765, 19, 18, 17, 16, 8, 1, 1, 2, 4]
}
Test Case 13 passed!
Expected Output
29
Your Code's Output
29
View Outputs Side By Side
Input(s)
{
  "coins": [1, 2, 3, 4, 5, 6, 7]
}
 */

/*
 Test Case 1
{
  "coins": [5, 7, 1, 1, 2, 3, 22]
}
Test Case 2
{
  "coins": [1, 1, 1, 1, 1]
}
Test Case 3
{
  "coins": [1, 5, 1, 1, 1, 10, 15, 20, 100]
}
Test Case 4
{
  "coins": [6, 4, 5, 1, 1, 8, 9]
}
Test Case 5
{
  "coins": []
}
Test Case 6
{
  "coins": [87]
}
Test Case 7
{
  "coins": [5, 6, 1, 1, 2, 3, 4, 9]
}
Test Case 8
{
  "coins": [5, 6, 1, 1, 2, 3, 43]
}
Test Case 9
{
  "coins": [1, 1]
}
Test Case 10
{
  "coins": [2]
}
Test Case 11
{
  "coins": [1]
}
Test Case 12
{
  "coins": [109, 2000, 8765, 19, 18, 17, 16, 8, 1, 1, 2, 4]
}
Test Case 13
{
  "coins": [1, 2, 3, 4, 5, 6, 7]
}
 */