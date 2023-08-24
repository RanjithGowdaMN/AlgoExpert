using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02Medium
{
    public class Best_Seat
    {
        public int BestSeat(int[] seats)
        {
            // Write your code here.
            int bestSeat = -1;
            int maxSpace = 0;
            int left = 0;
            while (left < seats.Length)
            {
                int right = left + 1;
                while (right < seats.Length && seats[right] == 0)
                {
                    right++;
                }

                int availableSpace = right - left - 1;
                if (availableSpace > maxSpace)
                {
                    maxSpace = availableSpace;
                    bestSeat = (right + left) / 2;
                }
                left = right;
            }
            return bestSeat;
        }
    }

}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[] { 1, 0, 1, 0, 0, 0, 1 };
    var expected = 4;
    var actual = new Program().BestSeat(input);
    Utils.AssertTrue(expected == actual);
  }
}

14 / 14 test cases passed.

Test Case 1 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "seats": [1]
}
Test Case 2 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 1, 0, 0, 0, 1]
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 1]
}
Test Case 4 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 1]
}
Test Case 5 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "seats": [1, 1, 1]
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 1, 0, 0, 1]
}
Test Case 7 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1]
}
Test Case 8 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1]
}
Test Case 9 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 10 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 11 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 12 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "seats": [1, 0, 0, 0, 1, 0, 0, 0, 0, 1]
}
Test Case 13 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "seats": [1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1]
}
Test Case 14 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "seats": [1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1]
}

 */
/*
 Test Case 1
{
  "seats": [1]
}
Test Case 2
{
  "seats": [1, 0, 1, 0, 0, 0, 1]
}
Test Case 3
{
  "seats": [1, 0, 1]
}
Test Case 4
{
  "seats": [1, 0, 0, 1]
}
Test Case 5
{
  "seats": [1, 1, 1]
}
Test Case 6
{
  "seats": [1, 0, 0, 1, 0, 0, 1]
}
Test Case 7
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1]
}
Test Case 8
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1]
}
Test Case 9
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 10
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 11
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 12
{
  "seats": [1, 0, 0, 0, 1, 0, 0, 0, 0, 1]
}
Test Case 13
{
  "seats": [1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1]
}
Test Case 14
{
  "seats": [1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1]
}

 */