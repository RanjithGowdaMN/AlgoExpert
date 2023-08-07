using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching._03_Very_Hard
{
    class MedianOfTwoSortedArraysProgram
    {
        public float MedianOfTwoSortedArrays(int[] arrayOne, int[] arrayTwo)
        {
            // Write your code here.
            int[] smallArray = arrayOne.Length <= arrayTwo.Length ? arrayOne : arrayTwo;
            int[] bigArray = arrayOne.Length > arrayTwo.Length ? arrayOne : arrayTwo;

            int leftIdx = 0;
            int rightIdx = smallArray.Length - 1;
            int mergedLeftIdx = (smallArray.Length + bigArray.Length - 1) / 2;

            while (true)
            {
                int smallPartitionIdx =
                    (int)Math.Floor(((double)(leftIdx + rightIdx)) / 2);
                int bigPartitionIdx = mergedLeftIdx - smallPartitionIdx - 1;

                int smallMaxLeftValue =
                    smallPartitionIdx >= 0 ? smallArray[smallPartitionIdx] : Int32.MinValue;
                int smallMinRightValue = smallPartitionIdx + 1 < smallArray.Length
                                        ? smallArray[smallPartitionIdx + 1] : Int32.MaxValue;

                int bigMaxLeftValue =
                    bigPartitionIdx >= 0 ? bigArray[bigPartitionIdx] : Int32.MinValue;
                int bigMinRightValue = bigPartitionIdx + 1 < bigArray.Length ? bigArray[bigPartitionIdx + 1] : Int32.MaxValue;

                if (smallMaxLeftValue > bigMinRightValue)
                {
                    rightIdx = smallPartitionIdx - 1;
                }
                else if (bigMaxLeftValue > smallMinRightValue)
                {
                    leftIdx = smallPartitionIdx + 1;
                }
                else
                {
                    if ((smallArray.Length + bigArray.Length) % 2 == 0)
                    {
                        return (float)(Math.Max(smallMaxLeftValue, bigMaxLeftValue) +
                                      Math.Min(smallMinRightValue, bigMinRightValue)) / 2;
                    }
                    return Math.Max(smallMaxLeftValue, bigMaxLeftValue);
                }
            }
        }
    }
}

/*
 33 / 33 test cases passed.

Test Case 1 passed!
Expected Output
1.5
Your Code's Output
1.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1],
  "arrayTwo": [2]
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1],
  "arrayTwo": [1]
}
Test Case 3 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1],
  "arrayTwo": [2, 3]
}
Test Case 4 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 3],
  "arrayTwo": [2]
}
Test Case 5 passed!
Expected Output
5.5
Your Code's Output
5.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 3, 4, 5],
  "arrayTwo": [6, 7, 8, 9]
}
Test Case 6 passed!
Expected Output
5.5
Your Code's Output
5.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [6, 7, 8, 9],
  "arrayTwo": [1, 3, 4, 5]
}
Test Case 7 passed!
Expected Output
3.5
Your Code's Output
3.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 3, 4, 5],
  "arrayTwo": [2, 3, 6, 7]
}
Test Case 8 passed!
Expected Output
3.5
Your Code's Output
3.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [2, 3, 6, 7],
  "arrayTwo": [1, 3, 4, 5]
}
Test Case 9 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 3, 4],
  "arrayTwo": [2, 3, 6, 7]
}
Test Case 10 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 3, 4],
  "arrayTwo": [2, 3, 6]
}
Test Case 11 passed!
Expected Output
5.5
Your Code's Output
5.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 3, 5, 6],
  "arrayTwo": [7, 8]
}
Test Case 12 passed!
Expected Output
5.5
Your Code's Output
5.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [7, 8],
  "arrayTwo": [1, 3, 5, 6]
}
Test Case 13 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "arrayOne": [3, 4, 5],
  "arrayTwo": [1, 2]
}
Test Case 14 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 2],
  "arrayTwo": [3, 4, 5]
}
Test Case 15 passed!
Expected Output
3.5
Your Code's Output
3.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [3, 4, 5, 6],
  "arrayTwo": [1, 2]
}
Test Case 16 passed!
Expected Output
3.5
Your Code's Output
3.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 2],
  "arrayTwo": [3, 4, 5, 6]
}
Test Case 17 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 4, 5, 6, 7, 8],
  "arrayTwo": [1, 2, 3]
}
Test Case 18 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 5, 6, 7, 8],
  "arrayTwo": [1, 2, 3]
}
Test Case 19 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 2, 3],
  "arrayTwo": [1, 4, 5, 6, 7, 8]
}
Test Case 20 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 2, 3],
  "arrayTwo": [1, 5, 6, 7, 8]
}
Test Case 21 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1],
  "arrayTwo": [5, 6, 7, 8]
}
Test Case 22 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "arrayOne": [5, 6, 7, 8],
  "arrayTwo": [1]
}
Test Case 23 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "arrayOne": [6],
  "arrayTwo": [1, 5, 7, 8]
}
Test Case 24 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 5, 7, 8],
  "arrayTwo": [6]
}
Test Case 25 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
  "arrayTwo": [5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
}
Test Case 26 passed!
Expected Output
2.5
Your Code's Output
2.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [2, 2, 2, 2, 2],
  "arrayTwo": [3, 3, 3, 3, 3]
}
Test Case 27 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "arrayOne": [2, 2, 2, 2, 2],
  "arrayTwo": [3, 3, 3, 3]
}
Test Case 28 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "arrayOne": [-5, -4, -2, 3, 7, 243],
  "arrayTwo": [-1, 0, 0, 32, 100]
}
Test Case 29 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "arrayOne": [-100, -50, -1, 0, 1],
  "arrayTwo": [-1, 0, 1, 50, 100]
}
Test Case 30 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "arrayOne": [-100, -50, -1, 15, 30],
  "arrayTwo": [1, 20, 50, 100]
}
Test Case 31 passed!
Expected Output
17.5
Your Code's Output
17.5
View Outputs Side By Side
Input(s)
{
  "arrayOne": [-100, -50, 15, 30],
  "arrayTwo": [1, 20, 50, 100]
}
Test Case 32 passed!
Expected Output
30
Your Code's Output
30
View Outputs Side By Side
Input(s)
{
  "arrayOne": [-10, -5, 10, 20, 70],
  "arrayTwo": [40, 50, 60]
}
Test Case 33 passed!
Expected Output
30
Your Code's Output
30
View Outputs Side By Side
Input(s)
{
  "arrayOne": [40, 50, 60],
  "arrayTwo": [-10, -5, 10, 20, 70]
}
 
 */