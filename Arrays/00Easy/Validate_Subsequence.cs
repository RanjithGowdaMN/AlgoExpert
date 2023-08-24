using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._00Easy
{
    public class Valid_Subsequence
    {
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            // Write your code here.
            int secPos = 0;
            for (int count = 0; count < array.Count; count++)
            {
                if (secPos == sequence.Count)
                {
                    break;
                }
                if (array[count] == sequence[secPos])
                {
                    secPos++;
                }

            }
            if (secPos == sequence.Count)
            {
                return true;
            }

            return false;
        }
    }


}
/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> array = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
    List<int> sequence = new List<int> { 1, 6, -1, 10 };
    Utils.AssertTrue(Program.IsValidSubsequence(array, sequence));
  }
}
24 / 24 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, 10]
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 25, 6, -1, 8, 10]
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 6, -1, 8, 10]
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [22, 25, 6]
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, 10]
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 10]
}
Test Case 7 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, -1, 8, 10]
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [25]
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 1],
  "sequence": [1, 1, 1]
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 25, 6, -1, 8, 10, 12]
}
Test Case 11 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [4, 5, 1, 22, 25, 6, -1, 8, 10]
}
Test Case 12 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 23, 6, -1, 8, 10]
}
Test Case 13 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 22, 25, 6, -1, 8, 10]
}
Test Case 14 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 22, 6, -1, 8, 10]
}
Test Case 15 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, -1]
}
Test Case 16 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, -1, 10]
}
Test Case 17 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, -2]
}
Test Case 18 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [26]
}
Test Case 19 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 25, 22, 6, -1, 8, 10]
}
Test Case 20 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 26, 22, 8]
}
Test Case 21 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 6, 1],
  "sequence": [1, 1, 1, 6]
}
Test Case 22 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, 10, 11, 11, 11, 11]
}
Test Case 23 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 25, 6, -1, 8, 10, 10]
}
Test Case 24 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, 5]
}


 */
/*
 Test Case 1
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, 10]
}
Test Case 2
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 25, 6, -1, 8, 10]
}
Test Case 3
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 6, -1, 8, 10]
}
Test Case 4
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [22, 25, 6]
}
Test Case 5
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, 10]
}
Test Case 6
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 10]
}
Test Case 7
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, -1, 8, 10]
}
Test Case 8
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [25]
}
Test Case 9
{
  "array": [1, 1, 1, 1, 1],
  "sequence": [1, 1, 1]
}
Test Case 10
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 25, 6, -1, 8, 10, 12]
}
Test Case 11
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [4, 5, 1, 22, 25, 6, -1, 8, 10]
}
Test Case 12
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 23, 6, -1, 8, 10]
}
Test Case 13
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 22, 25, 6, -1, 8, 10]
}
Test Case 14
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 22, 6, -1, 8, 10]
}
Test Case 15
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, -1]
}
Test Case 16
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, -1, 10]
}
Test Case 17
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, -2]
}
Test Case 18
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [26]
}
Test Case 19
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 25, 22, 6, -1, 8, 10]
}
Test Case 20
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 26, 22, 8]
}
Test Case 21
{
  "array": [1, 1, 6, 1],
  "sequence": [1, 1, 1, 6]
}
Test Case 22
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, 10, 11, 11, 11, 11]
}
Test Case 23
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [5, 1, 22, 25, 6, -1, 8, 10, 10]
}
Test Case 24
{
  "array": [5, 1, 22, 25, 6, -1, 8, 10],
  "sequence": [1, 6, -1, 5]
}
 */