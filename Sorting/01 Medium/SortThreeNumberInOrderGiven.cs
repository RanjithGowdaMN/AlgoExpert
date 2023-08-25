using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting._01_Medium
{
    class SortThreeNumberInOrderGiven
    {
        public int[] ThreeNumberSort(int[] array, int[] order)
        {
            // Write your code here.
            int firstValue = order[0];
            int secondValue = order[1];

            int firstIdx = 0;
            int secondIdx = 0;
            int thirdIdx = array.Length - 1;

            while (secondIdx <= thirdIdx)
            {
                int value = array[secondIdx];
                if (value == firstValue)
                {
                    Swap(firstIdx, secondIdx, array);
                    firstIdx++;
                    secondIdx++;
                }
                else if (value == secondValue)
                {
                    secondIdx++;
                }
                else
                {
                    Swap(secondIdx, thirdIdx, array);
                    thirdIdx--;
                }
            }

            return array;
        }

        public void Swap(int i, int j, int[] array)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}


/*
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var array = new int[] { 1, 0, 0, -1, -1, 0, 1, 1 };
    var order = new int[] { 0, 1, -1 };
    var expected = new int[] { 0, 0, 0, 1, 1, 1, -1, -1 };
    var actual = new Program().ThreeNumberSort(array, order);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < expected.Length; i++) {
      Utils.AssertTrue(expected[i] == actual[i]);
    }
  }
}

 

Test Case 1 passed!
Expected Output
[0, 0, 0, 1, 1, 1, -1, -1]
Your Code's Output
[0, 0, 0, 1, 1, 1, -1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [1, 0, 0, -1, -1, 0, 1, 1],
  "order": [0, 1, -1]
}
Test Case 2 passed!
Expected Output
[8, 8, 7, 7, 9, 9, 9, 9, 9, 9, 9, 9]
Your Code's Output
[8, 8, 7, 7, 9, 9, 9, 9, 9, 9, 9, 9]
View Outputs Side By Side
Input(s)
{
  "array": [7, 8, 9, 7, 8, 9, 9, 9, 9, 9, 9, 9],
  "order": [8, 7, 9]
}
Test Case 3 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [],
  "order": [0, 7, 9]
}
Test Case 4 passed!
Expected Output
[-2, -2, -2, -3, -3, -3, -3, -3, -3]
Your Code's Output
[-2, -2, -2, -3, -3, -3, -3, -3, -3]
View Outputs Side By Side
Input(s)
{
  "array": [-2, -3, -3, -3, -3, -3, -2, -2, -3],
  "order": [-2, -3, 0]
}
Test Case 5 passed!
Expected Output
[25, 25, 25, 25, 25, 10, 10, 10, 10, 10, 0]
Your Code's Output
[25, 25, 25, 25, 25, 10, 10, 10, 10, 10, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0, 10, 10, 10, 10, 10, 25, 25, 25, 25, 25],
  "order": [25, 10, 0]
}
Test Case 6 passed!
Expected Output
[6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6]
Your Code's Output
[6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6]
View Outputs Side By Side
Input(s)
{
  "array": [6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6],
  "order": [4, 5, 6]
}
Test Case 7 passed!
Expected Output
[1, 1, 1, 1, 1, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 3, 3, 3, 3]
Your Code's Output
[1, 1, 1, 1, 1, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 3, 3, 3, 3]
View Outputs Side By Side
Input(s)
{
  "array": [1, 3, 4, 4, 4, 4, 3, 3, 3, 4, 1, 1, 1, 4, 4, 1, 3, 1, 4, 4],
  "order": [1, 4, 3]
}
Test Case 8 passed!
Expected Output
[3, 1, 2]
Your Code's Output
[3, 1, 2]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3],
  "order": [3, 1, 2]
}
Test Case 9 passed!
Expected Output
[1, 1, 1, 1, 1, 2, 2, 2, 2, 0, 0, 0, 0]
Your Code's Output
[1, 1, 1, 1, 1, 2, 2, 2, 2, 0, 0, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 1, 2],
  "order": [1, 2, 0]
}
Test Case 10 passed!
Expected Output
[11, 11, 11, 7, 7, 7, 7, 7]
Your Code's Output
[11, 11, 11, 7, 7, 7, 7, 7]
View Outputs Side By Side
Input(s)
{
  "array": [7, 7, 7, 11, 11, 7, 11, 7],
  "order": [11, 7, 9]
}
Test Case 11 passed!
Expected Output
[7, 7, 7, 9, 9, 9, 9, 9, 9, 9]
Your Code's Output
[7, 7, 7, 9, 9, 9, 9, 9, 9, 9]
View Outputs Side By Side
Input(s)
{
  "array": [9, 9, 9, 7, 9, 7, 9, 9, 7, 9],
  "order": [11, 7, 9]
}
Test Case 12 passed!
Expected Output
[7, 7, 7, 9, 9, 9, 9, 9, 9, 9]
Your Code's Output
[7, 7, 7, 9, 9, 9, 9, 9, 9, 9]
View Outputs Side By Side
Input(s)
{
  "array": [9, 9, 9, 7, 9, 7, 9, 9, 7, 9],
  "order": [7, 11, 9]
}
Test Case 13 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "array": [1],
  "order": [0, 1, 2]
}
Test Case 14 passed!
Expected Output
[1, 0]
Your Code's Output
[1, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1],
  "order": [1, 2, 0]
}
 
 */