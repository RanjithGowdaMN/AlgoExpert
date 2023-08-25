using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching._02_Hard
{
    class IndexEqualsValueProgram
    {
        public int IndexEqualsValue(int[] array)
        {
            // Write your code here.
            int leftIndex = 0;
            int rightIndex = array.Length - 1;

            while (leftIndex <= rightIndex)
            {
                int middleIndex = rightIndex + (leftIndex - rightIndex) / 2;
                int middleValue = array[middleIndex];

                if (middleValue < middleIndex)
                {
                    leftIndex = middleIndex + 1;
                }
                else if ((middleValue == middleIndex) && (middleIndex == 0))
                {
                    return middleIndex;
                }
                else if ((middleValue == middleIndex) && (array[middleIndex - 1] < (middleIndex - 1)))
                {
                    return middleIndex;
                }
                else
                {
                    rightIndex = middleIndex - 1;
                }
            }
            return -1;
        }
    }
}
/*

using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(
      new Program().IndexEqualsValue(new int[] { -5, -3, 0, 3, 4, 5, 9 }) == 3
    );
  }
}


 17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [-5, -3, 0, 3, 4, 5, 9]
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [-12, 1, 2, 3, 12]
}
Test Case 3 passed!
Expected Output
11
Your Code's Output
11
View Outputs Side By Side
Input(s)
{
  "array": [-5, -4, -3, -2, -1, 0, 1, 3, 5, 6, 7, 11, 12, 14, 19, 20]
}
Test Case 4 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [-3, -1, 1, 3, 5, 7, 9]
}
Test Case 5 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5]
}
Test Case 6 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
}
Test Case 7 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
}
Test Case 8 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [0]
}
Test Case 9 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [0, 1]
}
Test Case 10 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [1, 2]
}
Test Case 11 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [-50, 1, 2, 3, 4]
}
Test Case 12 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [-40, -20, 0, 2, 4, 6, 8, 10]
}
Test Case 13 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [-1000, 0, 1, 5000, 5001, 5002, 5005]
}
Test Case 14 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [-1000, 0, 1, 2, 3, 4, 6, 5000, 5001, 5002, 5005]
}
Test Case 15 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [-999, 0, 2, 500, 1000, 1500, 2000, 2500, 3000, 3500]
}
Test Case 16 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "array": [-9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 18]
}
Test Case 17 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": []
}
 
 */