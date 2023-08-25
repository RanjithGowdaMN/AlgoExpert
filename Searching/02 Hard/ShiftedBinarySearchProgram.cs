using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching._02_Hard
{
    class ShiftedBinarySearchProgram
    {
        public static int ShiftedBinarySearch(int[] array, int target)
        {
            // Write your code here.
            return ShiftedBinarySearch(array, target, 0, array.Length - 1);
        }
        public static int ShiftedBinarySearch(
            int[] array, int target, int left, int right
        )
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;
                int potentialMatch = array[middle];
                int leftNum = array[left];
                int rightNum = array[right];
                if (target == potentialMatch)
                {
                    return middle;
                }
                else if (leftNum <= potentialMatch)
                {
                    if (target < potentialMatch && target >= leftNum)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                else
                {
                    if (target > potentialMatch && target <= rightNum)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
            }
            return -1;
        }
    }
}

/*
 
public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(
      Program.ShiftedBinarySearch(
        new int[] { 45, 61, 71, 72, 73, 0, 1, 21, 33, 37 }, 33
      ) == 8
    );
  }
}


31 / 31 test cases passed.

Test Case 1 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 33
}
Test Case 2 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [5, 23, 111, 1],
  "target": 111
}
Test Case 3 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [111, 1, 5, 23],
  "target": 5
}
Test Case 4 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [23, 111, 1, 5],
  "target": 35
}
Test Case 5 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "array": [61, 71, 72, 73, 0, 1, 21, 33, 37, 45],
  "target": 33
}
Test Case 6 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [72, 73, 0, 1, 21, 33, 37, 45, 61, 71],
  "target": 72
}
Test Case 7 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [71, 72, 73, 0, 1, 21, 33, 37, 45, 61],
  "target": 73
}
Test Case 8 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [73, 0, 1, 21, 33, 37, 45, 61, 71, 72],
  "target": 70
}
Test Case 9 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "array": [33, 37, 45, 61, 71, 72, 73, 355, 0, 1, 21],
  "target": 355
}
Test Case 10 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [33, 37, 45, 61, 71, 72, 73, 355, 0, 1, 21],
  "target": 354
}
Test Case 11 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 45
}
Test Case 12 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 61
}
Test Case 13 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 71
}
Test Case 14 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 72
}
Test Case 15 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 73
}
Test Case 16 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 0
}
Test Case 17 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 1
}
Test Case 18 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 21
}
Test Case 19 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 37
}
Test Case 20 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [45, 61, 71, 72, 73, 0, 1, 21, 33, 37],
  "target": 38
}
Test Case 21 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 0
}
Test Case 22 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 1
}
Test Case 23 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 21
}
Test Case 24 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 33
}
Test Case 25 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 37
}
Test Case 26 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 45
}
Test Case 27 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 61
}
Test Case 28 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 71
}
Test Case 29 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 72
}
Test Case 30 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 73
}
Test Case 31 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 37, 45, 61, 71, 72, 73],
  "target": 38
}
 */
