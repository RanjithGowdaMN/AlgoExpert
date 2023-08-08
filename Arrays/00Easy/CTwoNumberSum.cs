using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._01_Easy
{
    public static class CTwoNumberSum
    {
        public static void Main()
        {

        }
        public static int[] TwoNumberSum(int[] array, int targetsum)
        {
            // Write your code here.
            HashSet<int> visited = new HashSet<int>();

            for (int count = 0; count < array.Length; count++)
            {
                if (visited.Contains(targetsum - array[count]))
                {
                    return new int[] { targetsum - array[count], array[count] };
                }
                else
                {
                    visited.Add(array[count]);
                }
            }

            return new int[0];
        }
    }
}
//Test Case 1 passed!
//Expected Output
//[11, -1]
//Your Code's Output
//[11, -1]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [3, 5, -4, 8, 11, 1, -1, 6],
//  "targetSum": 10
//}
//Test Case 2 passed!
//Expected Output
//[4, 6]
//Your Code's Output
//[4, 6]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [4, 6],
//  "targetSum": 10
//}
//Test Case 3 passed!
//Expected Output
//[4, 1]
//Your Code's Output
//[4, 1]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [4, 6, 1],
//  "targetSum": 5
//}
//Test Case 4 passed!
//Expected Output
//[6, -3]
//Your Code's Output
//[6, -3]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [4, 6, 1, -3],
//  "targetSum": 3
//}
//Test Case 5 passed!
//Expected Output
//[8, 9]
//Your Code's Output
//[8, 9]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [1, 2, 3, 4, 5, 6, 7, 8, 9],
//  "targetSum": 17
//}
//Test Case 6 passed!
//Expected Output
//[3, 15]
//Your Code's Output
//[3, 15]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 15],
//  "targetSum": 18
//}
//Test Case 7 passed!
//Expected Output
//[-5, 0]
//Your Code's Output
//[-5, 0]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [-7, -5, -3, -1, 0, 1, 3, 5, 7],
//  "targetSum": -5
//}
//Test Case 8 passed!
//Expected Output
//[210, -47]
//Your Code's Output
//[210, -47]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [-21, 301, 12, 4, 65, 56, 210, 356, 9, -47],
//  "targetSum": 163
//}
//Test Case 9 passed!
//Expected Output
//[]
//Your Code's Output
//[]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [-21, 301, 12, 4, 65, 56, 210, 356, 9, -47],
//  "targetSum": 164
//}
//Test Case 10 passed!
//Expected Output
//[]
//Your Code's Output
//[]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [3, 5, -4, 8, 11, 1, -1, 6],
//  "targetSum": 15
//}
//Test Case 11 passed!
//Expected Output
//[]
//Your Code's Output
//[]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [14],
//  "targetSum": 15
//}
//Test Case 12 passed!
//Expected Output
//[]
//Your Code's Output
//[]
//View Outputs Side By Side
//Input(s)
//{
//    "array": [15],
//  "targetSum": 15
//}