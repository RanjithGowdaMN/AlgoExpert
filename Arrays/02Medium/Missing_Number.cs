using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02Medium
{
    public class Missing_Numbers
    {
        public int[] MissingNumbers(int[] nums)
        {
            // Write your code here.
            HashSet<int> included = new HashSet<int>();

            foreach (var num in nums)
            {
                included.Add(num);
            }
            int[] solution = new int[] { -1, -1 };
            for (int i = 1; i < nums.Length + 3; i++)
            {
                if (!included.Contains(i))
                {
                    if (solution[0] == -1)
                    {
                        solution[0] = i;
                    }
                    else
                    {
                        solution[1] = i;
                    }
                }
            }

            return solution;
        }
    }


}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[] { 4, 5, 1, 3 };
    var expected = new int[] { 2, 6 };
    var actual = new Program().MissingNumbers(input);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < expected.Length; i++) {
      Utils.AssertTrue(expected[i] == actual[i]);
    }
  }
}


24 / 24 test cases passed.

Test Case 1 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "nums": []
}
Test Case 2 passed!
Expected Output
[2, 3]
Your Code's Output
[2, 3]
View Outputs Side By Side
Input(s)
{
  "nums": [1]
}
Test Case 3 passed!
Expected Output
[1, 3]
Your Code's Output
[1, 3]
View Outputs Side By Side
Input(s)
{
  "nums": [2]
}
Test Case 4 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "nums": [3]
}
Test Case 5 passed!
Expected Output
[2, 4]
Your Code's Output
[2, 4]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 3]
}
Test Case 6 passed!
Expected Output
[2, 4]
Your Code's Output
[2, 4]
View Outputs Side By Side
Input(s)
{
  "nums": [3, 1]
}
Test Case 7 passed!
Expected Output
[4, 5]
Your Code's Output
[4, 5]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 3]
}
Test Case 8 passed!
Expected Output
[4, 5]
Your Code's Output
[4, 5]
View Outputs Side By Side
Input(s)
{
  "nums": [3, 2, 1]
}
Test Case 9 passed!
Expected Output
[4, 5]
Your Code's Output
[4, 5]
View Outputs Side By Side
Input(s)
{
  "nums": [3, 1, 2]
}
Test Case 10 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "nums": [3, 4, 5]
}
Test Case 11 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "nums": [4, 5, 3]
}
Test Case 12 passed!
Expected Output
[2, 6]
Your Code's Output
[2, 6]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 3, 4, 5]
}
Test Case 13 passed!
Expected Output
[2, 6]
Your Code's Output
[2, 6]
View Outputs Side By Side
Input(s)
{
  "nums": [4, 5, 1, 3]
}
Test Case 14 passed!
Expected Output
[3, 6]
Your Code's Output
[3, 6]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 4, 5, 7]
}
Test Case 15 passed!
Expected Output
[3, 6]
Your Code's Output
[3, 6]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 7, 5, 4]
}
Test Case 16 passed!
Expected Output
[8, 9]
Your Code's Output
[8, 9]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 3, 4, 5, 6, 7]
}
Test Case 17 passed!
Expected Output
[8, 9]
Your Code's Output
[8, 9]
View Outputs Side By Side
Input(s)
{
  "nums": [7, 6, 5, 4, 3, 2, 1]
}
Test Case 18 passed!
Expected Output
[8, 9]
Your Code's Output
[8, 9]
View Outputs Side By Side
Input(s)
{
  "nums": [3, 5, 1, 2, 4, 7, 6]
}
Test Case 19 passed!
Expected Output
[14, 19]
Your Code's Output
[14, 19]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 16, 17, 18, 20, 21, 22]
}
Test Case 20 passed!
Expected Output
[14, 19]
Your Code's Output
[14, 19]
View Outputs Side By Side
Input(s)
{
  "nums": [3, 5, 7, 8, 1, 10, 11, 2, 4, 13, 17, 22, 18, 21, 16, 20, 6, 9, 15, 12]
}
Test Case 21 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "nums": [3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
}
Test Case 22 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "nums": [14, 15, 16, 17, 18, 19, 20, 21, 22, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
}
Test Case 23 passed!
Expected Output
[23, 24]
Your Code's Output
[23, 24]
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
}
Test Case 24 passed!
Expected Output
[23, 24]
Your Code's Output
[23, 24]
View Outputs Side By Side
Input(s)
{
  "nums": [11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
}
 */
/*
 Test Case 1
{
  "nums": []
}
Test Case 2
{
  "nums": [1]
}
Test Case 3
{
  "nums": [2]
}
Test Case 4
{
  "nums": [3]
}
Test Case 5
{
  "nums": [1, 3]
}
Test Case 6
{
  "nums": [3, 1]
}
Test Case 7
{
  "nums": [1, 2, 3]
}
Test Case 8
{
  "nums": [3, 2, 1]
}
Test Case 9
{
  "nums": [3, 1, 2]
}
Test Case 10
{
  "nums": [3, 4, 5]
}
Test Case 11
{
  "nums": [4, 5, 3]
}
Test Case 12
{
  "nums": [1, 3, 4, 5]
}
Test Case 13
{
  "nums": [4, 5, 1, 3]
}
Test Case 14
{
  "nums": [1, 2, 4, 5, 7]
}
Test Case 15
{
  "nums": [1, 2, 7, 5, 4]
}
Test Case 16
{
  "nums": [1, 2, 3, 4, 5, 6, 7]
}
Test Case 17
{
  "nums": [7, 6, 5, 4, 3, 2, 1]
}
Test Case 18
{
  "nums": [3, 5, 1, 2, 4, 7, 6]
}
Test Case 19
{
  "nums": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 16, 17, 18, 20, 21, 22]
}
Test Case 20
{
  "nums": [3, 5, 7, 8, 1, 10, 11, 2, 4, 13, 17, 22, 18, 21, 16, 20, 6, 9, 15, 12]
}
Test Case 21
{
  "nums": [3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
}
Test Case 22
{
  "nums": [14, 15, 16, 17, 18, 19, 20, 21, 22, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
}
Test Case 23
{
  "nums": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
}
Test Case 24
{
  "nums": [11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
}
 */