using System;

namespace Arrays
{
    public class LongestPeak
    {

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
