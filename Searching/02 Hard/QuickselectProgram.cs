using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching._02_Hard
{
    class QuickselectProgram
    {
        public static int Quickselect(int[] array, int k)
        {
            // Write your code here.
            int position = k - 1;
            return QuickSelect(array, 0, array.Length - 1, position);
        }

        public static int QuickSelect(
            int[] array, int startIdx, int endIdx, int position)
        {
            while (true)
            {
                if (startIdx > endIdx)
                {
                    throw new Exception("Your Algorithm should necer arrive here!");
                }
                int pivotIdx = startIdx;
                int leftIdx = startIdx + 1;
                int rightIdx = endIdx;

                while (leftIdx <= rightIdx)
                {
                    if (array[leftIdx] > array[pivotIdx] && array[rightIdx] < array[pivotIdx])
                    {
                        swap(leftIdx, rightIdx, array);
                    }
                    if (array[leftIdx] <= array[pivotIdx])
                    {
                        leftIdx++;
                    }
                    if (array[rightIdx] >= array[pivotIdx])
                    {
                        rightIdx--;
                    }
                }
                swap(pivotIdx, rightIdx, array);
                if (rightIdx == position)
                {
                    return array[rightIdx];
                }
                else if (rightIdx < position)
                {
                    startIdx = rightIdx + 1;
                }
                else
                {
                    endIdx = rightIdx - 1;
                }
            }
        }
        public static void swap(int i, int j, int[] array)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}

/*
 8 / 18 test cases passed.

Test Case 1 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [8, 5, 2, 9, 7, 6, 3],
  "k": 3
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [1],
  "k": 1
}
Test Case 3 passed!
Expected Output
24
Your Code's Output
24
View Outputs Side By Side
Input(s)
{
  "array": [43, 24, 37],
  "k": 1
}
Test Case 4 passed!
Expected Output
37
Your Code's Output
37
View Outputs Side By Side
Input(s)
{
  "array": [43, 24, 37],
  "k": 2
}
Test Case 5 passed!
Expected Output
43
Your Code's Output
43
View Outputs Side By Side
Input(s)
{
  "array": [43, 24, 37],
  "k": 3
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 1
}
Test Case 7 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 2
}
Test Case 8 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 3
}
Test Case 9 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 4
}
Test Case 10 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 5
}
Test Case 11 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 6
}
Test Case 12 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 7
}
Test Case 13 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "array": [8, 3, 2, 5, 1, 7, 4, 6],
  "k": 8
}
Test Case 14 passed!
Expected Output
25
Your Code's Output
25
View Outputs Side By Side
Input(s)
{
  "array": [102, 41, 58, 81, 2, -5, 1000, 10021, 181, -14515, 25, 15],
  "k": 5
}
Test Case 15 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "array": [102, 41, 58, 81, 2, -5, 1000, 10021, 181, -14515, 25, 15],
  "k": 4
}
Test Case 16 passed!
Expected Output
102
Your Code's Output
102
View Outputs Side By Side
Input(s)
{
  "array": [102, 41, 58, 81, 2, -5, 1000, 10021, 181, -14515, 25, 15],
  "k": 9
}
Test Case 17 passed!
Expected Output
55516151
Your Code's Output
55516151
View Outputs Side By Side
Input(s)
{
  "array": [1, 3, 71, 123, 124, 156, 814, 1294, 10024, 110000, 985181, 55516151],
  "k": 12
}
Test Case 18 passed!
Expected Output
123
Your Code's Output
123
View Outputs Side By Side
Input(s)
{
  "array": [1, 3, 71, 123, 124, 156, 814, 1294, 10024, 110000, 985181, 55516151],
  "k": 4
}
 */