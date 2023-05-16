using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03_Hard
{
    public class SubArraySort
    {
        public static int[] SubarraySort(int[] array)
        {
            // Write your code here.
            int leftValue = -1;
            int rightValue = -1;

            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < maxValue)
                {
                    leftValue = i;
                }
                else
                {
                    maxValue = array[i];
                }
            }

            int minValue = array[array.Length - 1];
            for (int j = array.Length - 1; j >= 0; j--)
            {
                if (array[j] > minValue)
                {
                    rightValue = j;
                }
                else
                {
                    minValue = array[j];
                }
            }
            return new int[] { rightValue, leftValue };
        }
    }
}
