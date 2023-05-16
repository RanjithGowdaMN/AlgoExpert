using System;

namespace Arrays
{
    public class LongestPeak
    {
        public static int LongestPeakOriginal(int[] array)
        {
            // Write your code here.
            int longestpeak = 0;
            int i = 1;
            while (i < array.Length - 1)
            {
                bool isPeak = array[i] > array[i - 1] && array[i] > array[i + 1];
                if (!isPeak)
                {
                    i++;
                    continue;
                }
                int left = i - 2;
                while (left >= 0 && array[left] < array[left + 1])
                {
                    left--;
                }

                int right = i + 2;
                while (right < array.Length && array[right] < array[right - 1])
                {
                    right++;

                }
                int currentLength = right - left - 1;
                if (currentLength > longestpeak)
                {
                    longestpeak = currentLength;
                }
                i = right;
            }
            return longestpeak;
        }


        public static int LongestPeakSol(int[] array)
        {
            // Write your code here.

            int maxLength = 0;

            for (int i = 1; i < array.Length-1; i++)
            {
                Console.WriteLine($"{array[i]} is > than {array[i - 1]} and {array[i ]} is > than {array[i+1]}");
                if ((array[i] > array[i-1]) && (array[i] > array[i+1]))
                {
                    int curLen = FindPeakLength(array, i)[0];
                    
                    if (curLen > maxLength)
                    {
                        maxLength = curLen;
                    }
                }
                else 
                {
                    continue;
                }

            }
            return maxLength;
        }

        public static int[] FindPeakLength(int[] array, int peakIdx)
        {
            //counter
            int left = 0;
            int right = 0;

            int lefftIdx = peakIdx;
            int rightIdx = peakIdx;

            //Traverse left
            while (lefftIdx > 0)
            {
                if (array[lefftIdx] > array[lefftIdx - 1])
                {
                    left++;
                    lefftIdx--;
                }
                else 
                { 
                    break; 
                }
                
            }

            //traverse right
            while (rightIdx < array.Length -1)
            {
                if (array[rightIdx] > array[rightIdx + 1])
                {
                    right++;
                    rightIdx++;
                }
                else
                {
                    break;
                }
            }

            return new int[] { left+right+1, rightIdx};
        }

    }

}
/*
 * Test Case 1
{
  "array": [1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3]
}
Test Case 2
{
  "array": []
}
Test Case 3
{
  "array": [1, 3, 2]
}
Test Case 4
{
  "array": [1, 2, 3, 4, 5, 1]
}
Test Case 5
{
  "array": [5, 4, 3, 2, 1, 2, 1]
}
Test Case 6
{
  "array": [5, 4, 3, 2, 1, 2, 10, 12, -3, 5, 6, 7, 10]
}
Test Case 7
{
  "array": [5, 4, 3, 2, 1, 2, 10, 12]
}
Test Case 8
{
  "array": [1, 2, 3, 4, 5, 6, 10, 100, 1000]
}
Test Case 9
{
  "array": [1, 2, 3, 3, 2, 1]
}
Test Case 10
{
  "array": [1, 1, 3, 2, 1]
}
Test Case 11
{
  "array": [1, 2, 3, 2, 1, 1]
}
Test Case 12
{
  "array": [1, 1, 1, 2, 3, 10, 12, -3, -3, 2, 3, 45, 800, 99, 98, 0, -1, -1, 2, 3, 4, 5, 0, -1, -1]
}
Test Case 13
{
  "array": [1, 2, 3, 3, 4, 0, 10]
}
 * 
 */