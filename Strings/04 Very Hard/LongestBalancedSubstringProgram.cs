using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._04_Very_Hard
{
    class LongestBalancedSubstringProgram
    {
        public int LongestBalancedSubstring(string str)
        {
            // Write your code here.
            return Math.Max(GetLongestBalancedDirection(str, true),
                           GetLongestBalancedDirection(str, false));
        }

        public int GetLongestBalancedDirection(string str, bool leftToRight)
        {
            char openingParens = leftToRight ? '(' : ')';
            int startIdx = leftToRight ? 0 : str.Length - 1;
            int step = leftToRight ? 1 : -1;

            int maxLength = 0;
            int openingCount = 0;
            int closingCount = 0;

            int idx = startIdx;
            while (idx >= 0 && idx < str.Length)
            {
                char c = str[idx];

                if (c == openingParens)
                {
                    openingCount++;
                }
                else
                {
                    closingCount++;
                }

                if (openingCount == closingCount)
                {
                    maxLength = Math.Max(maxLength, closingCount * 2);
                }
                else if (closingCount > openingCount)
                {
                    openingCount = 0;
                    closingCount = 0;
                }

                idx += step;
            }

            return maxLength;
        }
    }
}

/*
 
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = "(()))(";
    var expected = 4;
    var actual = new Program().LongestBalancedSubstring(input);
    Utils.AssertTrue(expected == actual);
  }
}



77 / 77 test cases passed.

Test Case 1 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": "(()))("
}
Test Case 2 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "())()(()())"
}
Test Case 3 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "string": "()()()()()()()()()()"
}
Test Case 4 passed!
Expected Output
26
Your Code's Output
26
View Outputs Side By Side
Input(s)
{
  "string": "((()))()()()()()()()()()()"
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "()"
}
Test Case 6 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": "(())"
}
Test Case 7 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "string": "((((((((()))))))))"
}
Test Case 8 passed!
Expected Output
34
Your Code's Output
34
View Outputs Side By Side
Input(s)
{
  "string": "((((((((((((((((()))))))))))))))))"
}
Test Case 9 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "string": "(((()))()())))(()()()())()()"
}
Test Case 10 passed!
Expected Output
26
Your Code's Output
26
View Outputs Side By Side
Input(s)
{
  "string": "((((((()()()())()))((())))()"
}
Test Case 11 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "(("
}
Test Case 12 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "))"
}
Test Case 13 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "("
}
Test Case 14 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": ")"
}
Test Case 15 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "(((((((((((((((((("
}
Test Case 16 passed!
Test Case 17 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "(((((((((((((((((()"
}
Test Case 18 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "()))))))))))))))))))"
}
Test Case 19 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": ")("
}
Test Case 20 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "string": "(((((((((())))))))))"
}
Test Case 21 passed!
Expected Output
22
Your Code's Output
22
View Outputs Side By Side
Input(s)
{
  "string": "(((((((((()())))))))))"
}
Test Case 22 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "string": "(((((((((()))))))))))"
}
Test Case 23 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "))))))))))(((((((((("
}
Test Case 24 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": ""
}
Test Case 25 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "())()"
}
Test Case 26 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "()(()"
}
Test Case 27 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": ")))))))()))))())(((("
}
Test Case 28 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "))())(())((())(())(("
}
Test Case 29 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "string": ")())()(()(()())))((("
}
Test Case 30 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "((()))())()()()()))("
}
Test Case 31 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": ")(())))(())()))))))("
}
Test Case 32 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "string": "()()((((()()))()()()"
}
Test Case 33 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "string": "()(())()(()()))((())"
}
Test Case 34 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": ")(()((()()(()()()((("
}
Test Case 35 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": ")())()(()))()((()))("
}
Test Case 36 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": "()()))))(())((()(()("
}
Test Case 37 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "string": "(()())())()((())())("
}
Test Case 38 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "(()))((())()))))))()"
}
Test Case 39 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "string": "(((()()()(())((()()("
}
Test Case 40 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": ")(()())((()(()())((("
}
Test Case 41 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "string": "))()(()()()(()()()))"
}
Test Case 42 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": "(((((((((((((()(()()"
}
Test Case 43 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": ")))(()(()(()()()((()"
}
Test Case 44 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "()(()((()((()(((((()"
}
Test Case 45 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": ")((())(((()(()()(())"
}
Test Case 46 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "string": ")((((((()))(()))()(("
}
Test Case 47 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "string": "()(()()(()(()))((())"
}
Test Case 48 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "string": ")))((())()()))())(()"
}
Test Case 49 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": "()())()((()()(((()))"
}
Test Case 50 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": ")(()))))(()())))(()("
}
Test Case 51 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "string": "))(()()((()))()))()("
}
Test Case 52 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": ")()()))()(())))))))("
}
Test Case 53 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "string": "(((())(())()())()()("
}
Test Case 54 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "string": "()()(()()())((((()))"
}
Test Case 55 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "string": "((()()((()(((()))())"
}
Test Case 56 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "))(())()())())))()))"
}
Test Case 57 passed!
Expected Output
16
Your Code's Output
16
View Outputs Side By Side
Input(s)
{
  "string": "(()(()()())())()((()"
}
Test Case 58 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "()()())))()()()())()"
}
Test Case 59 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "string": "))((((()))()))()))))"
}
Test Case 60 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": ")())(())((((((()((()"
}
Test Case 61 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": ")((()())))((()((()))"
}
Test Case 62 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": "())(())))(((()()((()"
}
Test Case 63 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": ")()))((()))(((((((()"
}
Test Case 64 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": ")((((((((()())((())("
}
Test Case 65 passed!
Test Case 66 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": ")()()))((((())))((()"
}
Test Case 67 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "string": "(()(())(()((()))()()"
}
Test Case 68 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "(((()(((()()))((())("
}
Test Case 69 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": ")()()())()))(())()()"
}
Test Case 70 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "((()))())(((()((())("
}
Test Case 71 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "string": ")((((()()(()))))()))"
}
Test Case 72 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "string": "((()(())))))((()))(("
}
Test Case 73 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "(()()))())()()(())(("
}
Test Case 74 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "(()))((())()()(((((("
}
Test Case 75 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "string": "((()(()))(((((())((("
}
Test Case 76 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": "())))))())(((())((()"
}
Test Case 77 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "(()(()"
}
 */