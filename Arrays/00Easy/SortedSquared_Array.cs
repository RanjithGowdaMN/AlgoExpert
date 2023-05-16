using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._00Easy
{
    class SortedSquared_Array
    {
            public int[] SortedSquaredArray(int[] array)
            {
                // Write your code here.
                int start = 0;
                int end = array.Length - 1;
                int[] output = new int[array.Length];

                for (int count = array.Length - 1; count >= 0; count--)
                {

                    if (Math.Abs(array[start]) < Math.Abs(array[end]))
                    {
                        output[count] = array[end] * array[end];
                        end--;
                    }
                    else
                    {
                        output[count] = array[start] * array[start];
                        start++;
                    }
                }
                return output;
            }
        }


    }
/*
 Test Case 1
{
  "array": [1, 2, 3, 5, 6, 8, 9]
}
Test Case 2
{
  "array": [1]
}
Test Case 3
{
  "array": [1, 2]
}
Test Case 4
{
  "array": [1, 2, 3, 4, 5]
}
Test Case 5
{
  "array": [0]
}
Test Case 6
{
  "array": [10]
}
Test Case 7
{
  "array": [-1]
}
Test Case 8
{
  "array": [-2, -1]
}
Test Case 9
{
  "array": [-5, -4, -3, -2, -1]
}
Test Case 10
{
  "array": [-10]
}
Test Case 11
{
  "array": [-10, -5, 0, 5, 10]
}
Test Case 12
{
  "array": [-7, -3, 1, 9, 22, 30]
}
Test Case 13
{
  "array": [-50, -13, -2, -1, 0, 0, 1, 1, 2, 3, 19, 20]
}
Test Case 14
{
  "array": [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
}
Test Case 15
{
  "array": [-1, -1, 2, 3, 3, 3, 4]
}
Test Case 16
{
  "array": [-3, -2, -1]
}
Test Case 17
{
  "array": [-3, -2, -1]
}
 */