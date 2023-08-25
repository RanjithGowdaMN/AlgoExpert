using System;

namespace Strings
{
    internal class CheckPolindrome
	{
        private static bool checkPolindrome(string str)
        {
			int left = 0;
			int right = str.Length - 1;

			while (left < right)
			{
				if (str[left] != str[right])
				{
					return false;
				}
				else
				{
					left++;
					right--;
				}
			}
			return true;
		}
    }
}
/*
  public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(Program.IsPalindrome("abcdcba"));
  }
}

9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "abcdcba"
}
Test Case 2 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "a"
}
Test Case 3 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "ab"
}
Test Case 4 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "aba"
}
Test Case 5 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "abb"
}
Test Case 6 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "abba"
}
Test Case 7 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghhgfedcba"
}
Test Case 8 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghihgfedcba"
}
Test Case 9 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghihgfeddcba"
}
 
 */