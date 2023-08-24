using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02Medium
{
    public class ZeroSum_Subarray
    {
        public bool ZeroSumSubarray(int[] nums)
        {
            // Write your code here.
            HashSet<int> sums = new HashSet<int>();
            int currentSum = 0;
            sums.Add(0);
            foreach (int num in nums)
            {
                currentSum += num;

                if (sums.Contains(currentSum))
                {
                    return true;
                }
                sums.Add(currentSum);
            }
            return false;
        }
    }

}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[] { 4, 2, -1, -1, 3 };
    var expected = true;
    var actual = new Program().ZeroSumSubarray(input);
    Utils.AssertTrue(expected == actual);
  }
}

17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nums": []
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [0]
}
Test Case 3 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nums": [1]
}
Test Case 4 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 3]
}
Test Case 5 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nums": [1, 1, 1]
}
Test Case 6 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nums": [-1, -1, -1]
}
Test Case 7 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [0, 0, 0]
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, -2, 3]
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [2, -2]
}
Test Case 10 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [-1, 2, 3, 4, -5, -3, 1, 2]
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [-2, -3, -1, 2, 3, 4, -5, -3, 1, 2]
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [2, 3, 4, -5, -3, 4, 5]
}
Test Case 13 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nums": [2, 3, 4, -5, -3, 5, 5]
}
Test Case 14 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 3, 4, 0, 5, 6, 7]
}
Test Case 15 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [1, 2, 3, -2, -1]
}
Test Case 16 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "nums": [-8, -22, 104, 73, -120, 53, 22, -12, 1, 14, -90, 13, -22]
}
Test Case 17 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "nums": [-8, -22, 104, 73, -120, 53, 22, 20, 25, -12, 1, 14, -90, 13, -22]
}
 
 */
/*
 Test Case 1
{
  "nums": []
}
Test Case 2
{
  "nums": [0]
}
Test Case 3
{
  "nums": [1]
}
Test Case 4
{
  "nums": [1, 2, 3]
}
Test Case 5
{
  "nums": [1, 1, 1]
}
Test Case 6
{
  "nums": [-1, -1, -1]
}
Test Case 7
{
  "nums": [0, 0, 0]
}
Test Case 8
{
  "nums": [1, 2, -2, 3]
}
Test Case 9
{
  "nums": [2, -2]
}
Test Case 10
{
  "nums": [-1, 2, 3, 4, -5, -3, 1, 2]
}
Test Case 11
{
  "nums": [-2, -3, -1, 2, 3, 4, -5, -3, 1, 2]
}
Test Case 12
{
  "nums": [2, 3, 4, -5, -3, 4, 5]
}
Test Case 13
{
  "nums": [2, 3, 4, -5, -3, 5, 5]
}
Test Case 14
{
  "nums": [1, 2, 3, 4, 0, 5, 6, 7]
}
Test Case 15
{
  "nums": [1, 2, 3, -2, -1]
}
Test Case 16
{
  "nums": [-8, -22, 104, 73, -120, 53, 22, -12, 1, 14, -90, 13, -22]
}
Test Case 17
{
  "nums": [-8, -22, 104, 73, -120, 53, 22, 20, 25, -12, 1, 14, -90, 13, -22]
}
 */
