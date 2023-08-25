using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching._02_Hard
{
    public class SearchForRangeProgram
    {
        public static int[] SearchForRange(int[] array, int target)
        {
            // Write your code here.
            int[] finalRange = { -1, -1 };
            alteredBinarySearch(array, target, 0, array.Length - 1, finalRange, true);
            alteredBinarySearch(array, target, 0, array.Length - 1, finalRange, false);

            return finalRange;
        }
        public static void alteredBinarySearch(
            int[] array, int target, int left, int right, int[] finalRange, bool goLeft
        )
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else if (array[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    if (goLeft)
                    {
                        if (mid == 0 || array[mid - 1] != target)
                        {
                            finalRange[0] = mid;
                            return;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    else
                    {
                        if (mid == array.Length - 1 || array[mid + 1] != target)
                        {
                            finalRange[1] = mid;
                            return;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                }
            }
        }
    }
}

/*

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] expected = { 4, 9 };
    int[] output = Program.SearchForRange(
      new int[] { 0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 61, 71, 73 }, 45
    );
    Utils.AssertTrue(compare(output, expected));
  }

  public bool compare(int[] arr1, int[] arr2) {
    if (arr1.Length != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Length; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }
}
 

9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
[4, 9]
Your Code's Output
[4, 9]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 61, 71, 73],
  "target": 45
}
Test Case 2 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [5, 7, 7, 8, 8, 10],
  "target": 5
}
Test Case 3 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "array": [5, 7, 7, 8, 8, 10],
  "target": 7
}
Test Case 4 passed!
Expected Output
[3, 4]
Your Code's Output
[3, 4]
View Outputs Side By Side
Input(s)
{
  "array": [5, 7, 7, 8, 8, 10],
  "target": 8
}
Test Case 5 passed!
Expected Output
[5, 5]
Your Code's Output
[5, 5]
View Outputs Side By Side
Input(s)
{
  "array": [5, 7, 7, 8, 8, 10],
  "target": 10
}
Test Case 6 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [5, 7, 7, 8, 8, 10],
  "target": 9
}
Test Case 7 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 61, 71, 73],
  "target": 47
}
Test Case 8 passed!
Expected Output
[-1, -1]
Your Code's Output
[-1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 61, 71, 73],
  "target": -1
}
Test Case 9 passed!
Expected Output
[4, 12]
Your Code's Output
[4, 12]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 45, 45, 45],
  "target": 45
}
 
 */