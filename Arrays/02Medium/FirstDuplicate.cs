using System;
using System.Collections.Generic;

namespace Arrays
{
    public class FirstDuplicate
    {

        public static int FirstDuplicateValue(int[] array)
        {
            // Write your code here.
            HashSet<int> set = new HashSet<int>();
            foreach (var val in array)
            {
                int index = Math.Abs(val) - 1;
                if (array[index] < 0)
                {
                    return Math.Abs(val);
                }
                else
                {
                    array[index] *= -1;
                }
            }
            return -1;
        }

        
    }
}