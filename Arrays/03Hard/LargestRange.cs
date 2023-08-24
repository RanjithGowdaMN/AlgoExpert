using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03_Hard
{
    class CLargestRange
    {
        public static int[] LargestRange(int[] array)
        {
            // Write your code here.
            int[] bestRange = new int[2];
            int longestLength = 0;
            HashSet<int> nums = new HashSet<int>();

            foreach (int num in array)
            {
                nums.Add(num);
            }

            foreach (int num in array)
            {
                if (!nums.Contains(num))
                {
                    continue;
                }
                nums.Remove(num);
                int currentLength = 1;
                int left = num - 1;
                int right = num + 1;
                while (nums.Contains(left))
                {
                    nums.Remove(left);
                    left--;
                    currentLength++;
                }

                while (nums.Contains(right))
                {
                    nums.Remove(right);
                    currentLength++;
                    right++;
                }

                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    bestRange = new int[] { left + 1, right - 1 };
                }

            }
            return bestRange;
        }
    }
}
/*
 using System.Linq;

public class ProgramTest {
  [Test]
  public void TestCase6() {
    int[] expected = { 0, 7 };
    Utils.AssertTrue(Enumerable.SequenceEqual(
      Program.LargestRange(new int[] { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6 }
      ),
      expected
    ));
  }
}


 */
//Expected Output
//[0, 7]
//Your Code's Output
//[0, 7]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6]
//}
//Test Case 2 passed!
//Expected Output
//[1, 1]
//Your Code's Output
//[1, 1]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [1]
//}
//Test Case 3 passed!
//Expected Output
//[1, 2]
//Your Code's Output
//[1, 2]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [1, 2]
//}
//Test Case 4 passed!
//Expected Output
//[1, 4]
//Your Code's Output
//[1, 4]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [4, 2, 1, 3]
//}
//Test Case 5 passed!
//Expected Output
//[1, 4]
//Your Code's Output
//[1, 4]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [4, 2, 1, 3, 6]
//}
//Test Case 6 passed!
//Expected Output
//[6, 10]
//Your Code's Output
//[6, 10]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [8, 4, 2, 10, 3, 6, 7, 9, 1]
//}
//Test Case 7 passed!
//Expected Output
//[10, 19]
//Your Code's Output
//[10, 19]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [19, -1, 18, 17, 2, 10, 3, 12, 5, 16, 4, 11, 8, 7, 6, 15, 12, 12, 2, 1, 6, 13, 14]
//}
//Test Case 8 passed!
//Expected Output
//[-1, 19]
//Your Code's Output
//[-1, 19]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [0, 9, 19, -1, 18, 17, 2, 10, 3, 12, 5, 16, 4, 11, 8, 7, 6, 15, 12, 12, 2, 1, 6, 13, 14]
//}
//Test Case 9 passed!
//Expected Output
//[-7, 7]
//Your Code's Output
//[-7, 7]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [0, -5, 9, 19, -1, 18, 17, 2, -4, -3, 10, 3, 12, 5, 16, 4, 11, 7, -6, -7, 6, 15, 12, 12, 2, 1, 6, 13, 14, -2]
//}
//Test Case 10 passed!
//Expected Output
//[-8, 19]
//Your Code's Output
//[-8, 19]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [-7, -7, -7, -7, 8, -8, 0, 9, 19, -1, -3, 18, 17, 2, 10, 3, 12, 5, 16, 4, 11, -6, 8, 7, 6, 15, 12, 12, -5, 2, 1, 6, 13, 14, -4, -2]
//}
//Test Case 11 passed!
//Expected Output
//[3, 4]
//Your Code's Output
//[3, 4]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [1, 1, 1, 3, 4]
//}
//Test Case 12 passed!
//Expected Output
//[-1, 1]
//Your Code's Output
//[-1, 1]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [-1, 0, 1]
//}
//Test Case 13 passed!
//Expected Output
//[0, 1]
//Your Code's Output
//[0, 1]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [10, 0, 1]
//}