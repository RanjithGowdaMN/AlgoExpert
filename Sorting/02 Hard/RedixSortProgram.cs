using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting._02_Hard
{
    class RedixSortProgram
    {
        public List<int> RadixSort(List<int> array)
        {
            // Write your code here.
            if (array.Count == 0)
            {
                return array;
            }

            int maxNumber = array.Max();
            int digit = 0;
            while ((maxNumber / Math.Pow(10, digit)) > 0)
            {
                countingSort(array, digit);
                digit += 1;
            }
            return array;
        }
        public void countingSort(List<int> array, int digit)
        {
            int[] sortedArray = new int[array.Count];
            int[] countArray = new int[10];

            int digitColumn = (int)Math.Pow(10, digit);
            foreach (var num in array)
            {
                int countIndex = (num / digitColumn) % 10;
                countArray[countIndex] += 1;
            }

            for (int idx = 1; idx < 10; idx++)
            {
                countArray[idx] += countArray[idx - 1];
            }
            for (int idx = array.Count - 1; idx > -1; idx--)
            {
                int countIndex = (array[idx] / digitColumn) % 10;
                countArray[countIndex] -= 1;
                int sortedIndex = countArray[countIndex];
                sortedArray[sortedIndex] = array[idx];
            }

            for (int idx = 0; idx < array.Count; idx++)
            {
                array[idx] = sortedArray[idx];
            }

        }
    }
}

/*
 Test Case 1 passed!
Expected Output
[2, 12, 65, 87, 234, 345, 654, 3008, 8762]
Your Code's Output
[2, 12, 65, 87, 234, 345, 654, 3008, 8762]
View Outputs Side By Side
Input(s)
{
  "array": [8762, 654, 3008, 345, 87, 65, 234, 12, 2]
}
Test Case 2 passed!
Expected Output
[2, 12, 65, 87, 234, 345, 654, 3008, 8762]
Your Code's Output
[2, 12, 65, 87, 234, 345, 654, 3008, 8762]
View Outputs Side By Side
Input(s)
{
  "array": [2, 12, 65, 87, 234, 345, 654, 3008, 8762]
}
Test Case 3 passed!
Expected Output
[0, 1, 11, 11, 111]
Your Code's Output
[0, 1, 11, 11, 111]
View Outputs Side By Side
Input(s)
{
  "array": [111, 11, 11, 1, 0]
}
Test Case 4 passed!
Expected Output
[2, 3, 12, 34, 123, 456, 543, 986, 34200, 97654]
Your Code's Output
[2, 3, 12, 34, 123, 456, 543, 986, 34200, 97654]
View Outputs Side By Side
Input(s)
{
  "array": [12, 123, 456, 986, 2, 3, 34, 543, 97654, 34200]
}
Test Case 5 passed!
Expected Output
[3, 4, 22, 33, 44, 88, 444, 888, 1111, 1234, 2222]
Your Code's Output
[3, 4, 22, 33, 44, 88, 444, 888, 1111, 1234, 2222]
View Outputs Side By Side
Input(s)
{
  "array": [4, 44, 444, 888, 88, 33, 3, 22, 2222, 1111, 1234]
}
Test Case 6 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
View Outputs Side By Side
Input(s)
{
  "array": [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
}
Test Case 7 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": []
}
Test Case 8 passed!
Expected Output
[100]
Your Code's Output
[100]
View Outputs Side By Side
Input(s)
{
  "array": [100]
}
Test Case 9 passed!
Expected Output
[0, 1, 10, 11, 100, 101, 10000, 10001, 10101, 100001]
Your Code's Output
[0, 1, 10, 11, 100, 101, 10000, 10001, 10101, 100001]
View Outputs Side By Side
Input(s)
{
  "array": [10000, 100001, 10001, 10101, 101, 11, 100, 10, 1, 0]
}
Test Case 10 passed!
Expected Output
[23, 34, 56, 87, 232, 234, 332, 2312, 2321, 3421, 4556, 7373, 7878, 8272, 230983, 23892831]
Your Code's Output
[23, 34, 56, 87, 232, 234, 332, 2312, 2321, 3421, 4556, 7373, 7878, 8272, 230983, 23892831]
View Outputs Side By Side
Input(s)
{
  "array": [34, 56, 7373, 2321, 3421, 8272, 232, 23892831, 230983, 2312, 7878, 87, 234, 23, 332, 4556]
}
Test Case 11 passed!
Expected Output
[1, 9, 10, 65, 87, 231, 321, 323, 325, 421, 789, 2312, 2321, 2342, 3221, 3223, 4002, 6542, 7632]
Your Code's Output
[1, 9, 10, 65, 87, 231, 321, 323, 325, 421, 789, 2312, 2321, 2342, 3221, 3223, 4002, 6542, 7632]
View Outputs Side By Side
Input(s)
{
  "array": [10, 87, 2321, 3221, 2312, 7632, 6542, 3223, 231, 2342, 321, 9, 1, 323, 421, 325, 65, 789, 4002]
}
Test Case 12 passed!
Expected Output
[0, 0, 0, 0, 1, 1, 2, 3, 11, 11, 21, 21, 21, 22, 33, 111]
Your Code's Output
[0, 0, 0, 0, 1, 1, 2, 3, 11, 11, 21, 21, 21, 22, 33, 111]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 2, 22, 11, 3, 33, 0, 0, 0, 21, 21, 21, 1, 11, 111]
}
Test Case 13 passed!
Expected Output
[0, 1, 4, 5, 8, 8, 21, 23, 34, 234, 444, 987]
Your Code's Output
[0, 1, 4, 5, 8, 8, 21, 23, 34, 234, 444, 987]
View Outputs Side By Side
Input(s)
{
  "array": [8, 4, 5, 34, 234, 987, 444, 23, 21, 8, 1, 0]
}
Test Case 14 passed!
Expected Output
[1, 11]
Your Code's Output
[1, 11]
View Outputs Side By Side
Input(s)
{
  "array": [1, 11]
}
Test Case 15 passed!
Expected Output
[1, 1, 9, 11, 11, 99, 101, 432, 441]
Your Code's Output
[1, 1, 9, 11, 11, 99, 101, 432, 441]
View Outputs Side By Side
Input(s)
{
  "array": [1, 11, 1, 11, 101, 9, 99, 432, 441]
}
Test Case 16 passed!
Expected Output
[0, 1, 1, 1, 10, 10, 100, 100, 1000, 1000, 1001, 10001, 10201]
Your Code's Output
[0, 1, 1, 1, 10, 10, 100, 100, 1000, 1000, 1001, 10001, 10201]
View Outputs Side By Side
Input(s)
{
  "array": [1000, 100, 10, 1, 10, 100, 1000, 10001, 10201, 1001, 0, 1, 1]
}
Test Case 17 passed!
Expected Output
[9, 109, 190, 290, 876, 908, 999, 1099, 9999]
Your Code's Output
[9, 109, 190, 290, 876, 908, 999, 1099, 9999]
View Outputs Side By Side
Input(s)
{
  "array": [9, 109, 908, 876, 1099, 190, 290, 999, 9999]
}
Test Case 18 passed!
Expected Output
[0, 89892, 92012, 181730, 234892, 782731, 785239, 812723, 891932, 999999, 1231421, 1892193, 2314451, 10000009]
Your Code's Output
[0, 89892, 92012, 181730, 234892, 782731, 785239, 812723, 891932, 999999, 1231421, 1892193, 2314451, 10000009]
View Outputs Side By Side
Input(s)
{
  "array": [0, 999999, 234892, 10000009, 89892, 782731, 891932, 92012, 1892193, 181730, 785239, 2314451, 1231421, 812723]
}
 
 */