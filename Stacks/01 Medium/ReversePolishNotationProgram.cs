using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    class ReversePolishNotationProgram
    {
        public int ReversePolishNotation(string[] tokens)
        {
            // Write your code here.
            Stack<int> stack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (token.Equals("+"))
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (token.Equals("-"))
                {
                    int firstNum = stack.Pop();
                    stack.Push(stack.Pop() - firstNum);
                }
                else if (token.Equals("*"))
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
                else if (token.Equals("/"))
                {
                    int firstNum = stack.Pop();
                    stack.Push(stack.Pop() / firstNum);
                }
                else
                {
                    stack.Push(Int32.Parse(token));
                }
            }
            return stack.Pop();
        }
    }
}

/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new string[] { "3", "2", "+", "7", "*" };
    var expected = 35;
    var actual = new Program().ReversePolishNotation(input);
    Utils.AssertTrue(expected == actual);
  }
}

27 / 27 test cases passed.

Test Case 1 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "tokens": ["10"]
}
Test Case 2 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "5", "+"]
}
Test Case 3 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "5", "-"]
}
Test Case 4 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "5", "/"]
}
Test Case 5 passed!
Expected Output
50
Your Code's Output
50
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "5", "*"]
}
Test Case 6 passed!
Expected Output
-50
Your Code's Output
-50
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "-5", "*"]
}
Test Case 7 passed!
Expected Output
-50
Your Code's Output
-50
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "5", "*"]
}
Test Case 8 passed!
Expected Output
50
Your Code's Output
50
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "-5", "*"]
}
Test Case 9 passed!
Expected Output
-2
Your Code's Output
-2
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "-5", "/"]
}
Test Case 10 passed!
Expected Output
-2
Your Code's Output
-2
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "5", "/"]
}
Test Case 11 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "-5", "/"]
}
Test Case 12 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "3", "/"]
}
Test Case 13 passed!
Expected Output
-3
Your Code's Output
-3
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "-3", "/"]
}
Test Case 14 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "-5", "+"]
}
Test Case 15 passed!
Expected Output
-5
Your Code's Output
-5
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "5", "+"]
}
Test Case 16 passed!
Expected Output
-15
Your Code's Output
-15
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "-5", "+"]
}
Test Case 17 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "tokens": ["10", "-5", "-"]
}
Test Case 18 passed!
Expected Output
-15
Your Code's Output
-15
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "5", "-"]
}
Test Case 19 passed!
Expected Output
-5
Your Code's Output
-5
View Outputs Side By Side
Input(s)
{
  "tokens": ["-10", "-5", "-"]
}
Test Case 20 passed!
Expected Output
35
Your Code's Output
35
View Outputs Side By Side
Input(s)
{
  "tokens": ["3", "2", "+", "7", "*"]
}
Test Case 21 passed!
Expected Output
-5
Your Code's Output
-5
View Outputs Side By Side
Input(s)
{
  "tokens": ["4", "2", "/", "7", "-"]
}
Test Case 22 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "tokens": ["3", "4", "+", "2", "/", "4", "-"]
}
Test Case 23 passed!
Expected Output
42
Your Code's Output
42
View Outputs Side By Side
Input(s)
{
  "tokens": ["4", "-7", "2", "6", "+", "10", "-", "/", "*", "2", "+", "3", "*"]
}
Test Case 24 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tokens": ["4", "-7", "2", "6", "+", "10", "-", "/", "*", "2", "+", "3", "*", "0", "*"]
}
Test Case 25 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "tokens": ["50", "3", "17", "+", "2", "-", "/"]
}
Test Case 26 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "tokens": ["0", "3", "17", "+", "2", "-", "/"]
}
Test Case 27 passed!
Expected Output
-34
Your Code's Output
-34
View Outputs Side By Side
Input(s)
{
  "tokens": ["0", "3", "17", "+", "2", "-", "/", "2", "-", "7", "10", "+", "*"]
}
 
 */