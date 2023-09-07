using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._00Easy
{
    public static class  SortedSquared_Array
    {
            public static int[] SortedSquaredArray(int[] array)
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
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[] { 1, 2, 3, 5, 6, 8, 9 };
    var expected = new int[] { 1, 4, 9, 25, 36, 64, 81 };
    var actual = new Program().SortedSquaredArray(input);
    for (int i = 0; i < expected.Length; i++) {
      Utils.AssertTrue(expected[i] == actual[i]);
    }
  }
}
17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
[1, 4, 9, 25, 36, 64, 81]
Your Code's Output
[1, 4, 9, 25, 36, 64, 81]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 5, 6, 8, 9]
}
Test Case 2 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "array": [1]
}
Test Case 3 passed!
Expected Output
[1, 4]
Your Code's Output
[1, 4]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2]
}

Test Case 4 passed!
Expected Output
[1, 4, 9, 16, 25]
Your Code's Output
[1, 4, 9, 16, 25]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5]
}
Test Case 5 passed!
Expected Output
[0]
Your Code's Output
[0]
View Outputs Side By Side
Input(s)
{
  "array": [0]
}
Test Case 6 passed!
Expected Output
[100]
Your Code's Output
[100]
View Outputs Side By Side
Input(s)
{
  "array": [10]
}
Test Case 7 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "array": [-1]
}
Test Case 8 passed!
Expected Output
[1, 4]
Your Code's Output
[1, 4]
View Outputs Side By Side
Input(s)
{
  "array": [-2, -1]
}
Test Case 9 passed!
Expected Output
[1, 4, 9, 16, 25]
Your Code's Output
[1, 4, 9, 16, 25]
View Outputs Side By Side
Input(s)
{
  "array": [-5, -4, -3, -2, -1]
}
Test Case 10 passed!
Expected Output
[100]
Your Code's Output
[100]
View Outputs Side By Side
Input(s)
{
  "array": [-10]
}
Test Case 11 passed!
Expected Output
[0, 25, 25, 100, 100]
Your Code's Output
[0, 25, 25, 100, 100]
View Outputs Side By Side
Input(s)
{
  "array": [-10, -5, 0, 5, 10]
}
Test Case 12 passed!
Expected Output
[1, 9, 49, 81, 484, 900]
Your Code's Output
[1, 9, 49, 81, 484, 900]
View Outputs Side By Side
Input(s)
{
  "array": [-7, -3, 1, 9, 22, 30]
}
Test Case 13 passed!
Expected Output
[0, 0, 1, 1, 1, 4, 4, 9, 169, 361, 400, 2500]
Your Code's Output
[0, 0, 1, 1, 1, 4, 4, 9, 169, 361, 400, 2500]
View Outputs Side By Side
Input(s)
{
  "array": [-50, -13, -2, -1, 0, 0, 1, 1, 2, 3, 19, 20]
}
Test Case 14 passed!
Expected Output
[0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
Your Code's Output
[0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
}
Test Case 15 passed!
Expected Output
[1, 1, 4, 9, 9, 9, 16]
Your Code's Output
[1, 1, 4, 9, 9, 9, 16]
View Outputs Side By Side
Input(s)
{
  "array": [-1, -1, 2, 3, 3, 3, 4]
}
Test Case 16 passed!
Expected Output
[1, 4, 9]
Your Code's Output
[1, 4, 9]
View Outputs Side By Side
Input(s)
{
  "array": [-3, -2, -1]
}
Test Case 17 passed!
Expected Output
[1, 4, 9]
Your Code's Output
[1, 4, 9]
View Outputs Side By Side
Input(s)
{
  "array": [-3, -2, -1]
}

 
 */
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