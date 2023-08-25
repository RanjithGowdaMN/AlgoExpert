using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting._03_Very_Hard
{
    class CountInversionsProgram
    {
        public int CountInversions(int[] array)
        {
            // Write your code here.
            return countSubArrayInversions(array, 0, array.Length);
        }

        public int countSubArrayInversions(int[] array, int start, int end)
        {
            if (end - start <= 1)
            {
                return 0;
            }

            int middle = start + (end - start) / 2;
            int leftInversions = countSubArrayInversions(array, start, middle);
            int rightInversions = countSubArrayInversions(array, middle, end);
            int mergedArrayInversions =
                mergeSortAndCountInversions(array, start, middle, end);
            return leftInversions + rightInversions + mergedArrayInversions;
        }

        public int mergeSortAndCountInversions(int[] array, int start, int middle, int end)
        {
            List<int> sortedArray = new List<int>();
            int left = start;
            int right = middle;
            int inversions = 0;

            while (left < middle && right < end)
            {
                if (array[left] <= array[right])
                {
                    sortedArray.Add(array[left]);
                    left += 1;
                }
                else
                {
                    inversions += middle - left;
                    sortedArray.Add(array[right]);
                    right += 1;
                }
            }

            for (int idx = left; idx < middle; idx++)
            {
                sortedArray.Add(array[idx]);
            }

            for (int idx = right; idx < end; idx++)
            {
                sortedArray.Add(array[idx]);
            }

            for (int idx = 0; idx < sortedArray.Count; idx++)
            {
                int num = sortedArray[idx];
                array[start + idx] = num;
            }

            return inversions;
        }
    }
}

/*
 
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = new int[] { 2, 3, 3, 1, 9, 5, 6 };
    var expected = 5;
    var actual = new Program().CountInversions(input);
    Utils.AssertTrue(expected == actual);
  }
}


15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [2, 3, 3, 1, 9, 5, 6]
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": []
}
Test Case 3 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, -1]
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [0, 2, 4, 5, 76]
}
Test Case 5 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [54, 1, 2, 3, 4]
}
Test Case 6 passed!
Expected Output
16
Your Code's Output
16
View Outputs Side By Side
Input(s)
{
  "array": [1, 10, 2, 8, 3, 7, 4, 6, 5]
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [2, -18]
}
Test Case 8 passed!
Expected Output
105
Your Code's Output
105
View Outputs Side By Side
Input(s)
{
  "array": [15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
}
Test Case 9 passed!
Expected Output
23
Your Code's Output
23
View Outputs Side By Side
Input(s)
{
  "array": [5, -1, 2, -4, 3, 4, 19, 87, 762, -8, 0]
}
Test Case 10 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 1, 1, 1, 1]
}
Test Case 11 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 0, 1, 1, 1]
}
Test Case 12 passed!
Expected Output
16
Your Code's Output
16
View Outputs Side By Side
Input(s)
{
  "array": [2, 2, 2, 2, 1, 1, 1, 1, 3, 3, 3, 3]
}
Test Case 13 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [3, 1, 2]
}
Test Case 14 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [3, 2, 1, 1]
}
Test Case 15 passed!
Expected Output
62
Your Code's Output
62
View Outputs Side By Side
Input(s)
{
  "array": [10, 7, 2, 3, 1, -9, -86, -862, 234, 312, 3421, 23, 0, 2, 1, 2]
}
 */