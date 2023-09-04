using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    internal class BalancedBracketsProgram
    {
        public static void Main()
        {
            //Do Nothing
        }

        public static bool BalancedBrackets(string str)
        {
            // Write your code here.
            string openingBrackets = "([{";
            string closingBrackets = ")]}";
            Dictionary<char, char> matchingBrackets = new Dictionary<char, char>();
            matchingBrackets.Add(')', '(');
            matchingBrackets.Add(']', '[');
            matchingBrackets.Add('}', '{');
            List<char> stack = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                char letter = str[i];
                if (openingBrackets.IndexOf(letter) != -1)
                {
                    stack.Add(letter);
                }
                else if (closingBrackets.IndexOf(letter) != -1)
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    if (stack[stack.Count - 1] == matchingBrackets[letter])
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0; ;
        }
    }
}
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    string input = "([])(){}(())()()";
    Utils.AssertTrue(Program.BalancedBrackets(input));
  }
}


23 / 23 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "([])(){}(())()()"
}
Test Case 2 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "()[]{}{"
}
Test Case 3 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "(((((({{{{{[[[[[([)])]]]]]}}}}}))))))"
}
Test Case 4 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "()()[{()})]"
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "(()())((()()()))"
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "{}()"
}
Test Case 7 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "()([])"
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "((){{{{[]}}}})"
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "((({})()))"
}
Test Case 10 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "(([]()()){})"
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "(((((([[[[[[{{{{{{{{{{{{()}}}}}}}}}}}}]]]]]]))))))((([])({})[])[])[]([]){}(())"
}
Test Case 12 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "{[[[[({(}))]]]]}"
}
Test Case 13 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "[((([])([]){}){}){}([])[]((())"
}
Test Case 14 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": ")[]}"
}
Test Case 15 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "(a)"
}
Test Case 16 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "(a("
}
Test Case 17 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "(141[])(){waga}((51afaw))()hh()"
}
Test Case 18 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "aafwgaga()[]a{}{gggg"
}
Test Case 19 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "(((((({{{{{safaf[[[[[([)]safsafsa)]]]]]}}}gawga}}))))))"
}
Test Case 20 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "()(agawg)[{()gawggaw})]"
}
Test Case 21 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "(()agwg())((()agwga()())gawgwgag)"
}
Test Case 22 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "{}gawgw()"
}
Test Case 23 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "(agwgg)([ghhheah%&@Q])"
}
 
 */