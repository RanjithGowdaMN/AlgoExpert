using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    class BestDigitStringProgram
    {
        public string BestDigits(string number, int numDigits)
        {
            // Write your code here.
            Stack<char> stack = new Stack<char>();

            for (int idx = 0; idx < number.Length; idx++)
            {
                char character = number[idx];
                while (numDigits > 0 && stack.Count > 0 && character > stack.Peek())
                {
                    numDigits--;
                    stack.Pop();
                }
                stack.Push(character);
            }
            while (numDigits > 0)
            {
                numDigits--;
                stack.Pop();
            }

            StringBuilder bestDigitString = new StringBuilder();
            while (stack.Count > 0)
            {
                bestDigitString.Append(stack.Pop());
            }
            var charArray = bestDigitString.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    string number = "462839";
    int numDigits = 2;
    string expected = "6839";
    var actual = new Program().BestDigits(number, numDigits);
    Utils.AssertTrue(expected.Equals(actual));
  }
}


8 / 18 test cases passed.

Test Case 1 passed!
Expected Output
6839
Your Code's Output
6839
View Outputs Side By Side
Input(s)
{
  "numDigits": 2,
  "number": "462839"
}
Test Case 2 passed!
Expected Output
98763
Your Code's Output
98763
View Outputs Side By Side
Input(s)
{
  "numDigits": 4,
  "number": "129847563"
}
Test Case 3 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "numDigits": 1,
  "number": "19"
}
Test Case 4 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "numDigits": 1,
  "number": "22"
}
Test Case 5 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "numDigits": 1,
  "number": "23"
}
Test Case 6 passed!
Expected Output
23
Your Code's Output
23
View Outputs Side By Side
Input(s)
{
  "numDigits": 1,
  "number": "123"
}
Test Case 7 passed!
Expected Output
32
Your Code's Output
32
View Outputs Side By Side
Input(s)
{
  "numDigits": 1,
  "number": "321"
}
Test Case 8 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "numDigits": 2,
  "number": "123"
}
Test Case 9 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "numDigits": 2,
  "number": "321"
}
Test Case 10 passed!
Expected Output
9999999999
Your Code's Output
9999999999
View Outputs Side By Side
Input(s)
{
  "numDigits": 10,
  "number": "11111111119999999999"
}
Test Case 11 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "numDigits": 9,
  "number": "10000000002"
}
Test Case 12 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "numDigits": 10,
  "number": "10000000002"
}
Test Case 13 passed!
Expected Output
34050
Your Code's Output
34050
View Outputs Side By Side
Input(s)
{
  "numDigits": 5,
  "number": "1020304050"
}
Test Case 14 passed!
Expected Output
30200004
Your Code's Output
30200004
View Outputs Side By Side
Input(s)
{
  "numDigits": 4,
  "number": "100300200004"
}
Test Case 15 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "numDigits": 9,
  "number": "9999999999"
}
Test Case 16 passed!
Expected Output
221
Your Code's Output
221
View Outputs Side By Side
Input(s)
{
  "numDigits": 3,
  "number": "111221"
}
Test Case 17 passed!
Expected Output
12345
Your Code's Output
12345
View Outputs Side By Side
Input(s)
{
  "numDigits": 0,
  "number": "12345"
}
Test Case 18 passed!
Expected Output
54321
Your Code's Output
54321
View Outputs Side By Side
Input(s)
{
  "numDigits": 0,
  "number": "54321"
}
 
 */