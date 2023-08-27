using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._03_Very_Hard
{
    class LongestIncreasingSubsequenceProgram
    {
        public static List<int> LongestIncreasingSubsequence(int[] array)
        {
            // O(nlogn) time | O(n) complexity
            int[] sequences = new int[array.Length];
            int[] indices = new int[array.Length + 1];
            Array.Fill(indices, Int32.MinValue);
            int length = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i];
                int newLength = BinarySearch(1, length, indices, array, num);
                sequences[i] = indices[newLength - 1];
                indices[newLength] = i;
                length = Math.Max(length, newLength);
            }
            return buildSequences(array, sequences, indices[length]);
        }

        public static int BinarySearch(int startIdx, int endIdx, int[] indices, int[] array, int num)
        {
            if (startIdx > endIdx)
            {
                return startIdx;
            }
            int middleIdx = (startIdx + endIdx) / 2;
            if (array[indices[middleIdx]] < num)
            {
                startIdx = middleIdx + 1;
            }
            else
            {
                endIdx = middleIdx - 1;
            }
            return BinarySearch(startIdx, endIdx, indices, array, num);
        }
        public static List<int> buildSequences(
          int[] array, int[] sequences, int currentIdx
        )
        {
            List<int> sequence = new List<int>();
            while (currentIdx != Int32.MinValue)
            {
                sequence.Insert(0, array[currentIdx]);
                currentIdx = sequences[currentIdx];
            }
            return sequence;
        }
    }
}
/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] expected = { -24, 2, 3, 5, 6, 35 };
    Utils.AssertTrue(compare(
      Program.LongestIncreasingSubsequence(
        new int[] { 5, 7, -24, 12, 10, 2, 3, 12, 5, 6, 35 }
      ),
      expected
    ));
  }

  public static bool compare(List<int> arr1, int[] arr2) {
    if (arr1.Count != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }
}


10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
[-24, 2, 3, 5, 6, 35]
Our Code's Output
[-24, 2, 3, 5, 6, 35]
View Outputs Side By Side
Input(s)
{
  "array": [5, 7, -24, 12, 10, 2, 3, 12, 5, 6, 35]
}
Test Case 2 passed!
Expected Output
[-1]
Our Code's Output
[-1]
View Outputs Side By Side
Input(s)
{
  "array": [-1]
}
Test Case 3 passed!
Expected Output
[-1, 2]
Our Code's Output
[-1, 2]
View Outputs Side By Side
Input(s)
{
  "array": [-1, 2]
}
Test Case 4 passed!
Expected Output
[-1, 1, 2]
Our Code's Output
[-1, 1, 2]
View Outputs Side By Side
Input(s)
{
  "array": [-1, 2, 1, 2]
}
Test Case 5 passed!
Expected Output
[1, 5, 10]
Our Code's Output
[1, 5, 10]
View Outputs Side By Side
Input(s)
{
  "array": [1, 5, -1, 10]
}
Test Case 6 passed!
Expected Output
[-1, 0, 2, 4]
Our Code's Output
[-1, 0, 2, 4]
View Outputs Side By Side
Input(s)
{
  "array": [1, 5, -1, 0, 6, 2, 4]
}
Test Case 7 passed!
Expected Output
[3, 4]
Our Code's Output
[3, 4]
View Outputs Side By Side
Input(s)
{
  "array": [3, 4, -1]
}
Test Case 8 passed!
Expected Output
[2, 12, 30, 31]
Our Code's Output
[2, 12, 30, 31]
View Outputs Side By Side
Input(s)
{
  "array": [29, 2, 32, 12, 30, 31]
}
Test Case 9 passed!
Expected Output
[10, 22, 33, 41, 60, 80]
Our Code's Output
[10, 22, 33, 41, 60, 80]
View Outputs Side By Side
Input(s)
{
  "array": [10, 22, 9, 33, 21, 61, 41, 60, 80]
}
Test Case 10 passed!
Expected Output
[1, 2, 3, 4, 101]
Our Code's Output
[1, 2, 3, 4, 101]
View Outputs Side By Side
Input(s)
{
  "array": [100, 1, 2, 3, 4, 101]
}
 
 
 */