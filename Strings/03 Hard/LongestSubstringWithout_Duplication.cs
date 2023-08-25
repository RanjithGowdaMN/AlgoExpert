using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._03_Hard
{
    public class LongestSubstringWithout_Duplication
    {
        public static string LongestSubstringWithoutDuplication(string str)
        {
            // Write your code here
            Dictionary<char, int> lastseen = new Dictionary<char, int>();
            int strIdx = 0;
            int[] longest = { 0, 1 };
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (lastseen.ContainsKey(c))
                {
                    strIdx = Math.Max(strIdx, lastseen[c] + 1);
                }
                if ((longest[1] - longest[0]) < i + 1 - strIdx)
                {
                    longest = new int[] { strIdx, i + 1 };
                }
                lastseen[c] = i;
            }
            string longstr = str.Substring(longest[0], longest[1] - longest[0]);
            return longstr;
        }
    }

}

/*
public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(Program.LongestSubstringWithoutDuplication("clementisacap")
                       .Equals("mentisac"));
  }
}

10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
mentisac
Our Code's Output
mentisac
View Outputs Side By Side
Input(s)
{
  "string": "clementisacap"
}
Test Case 2 passed!
Expected Output
a
Our Code's Output
a
View Outputs Side By Side
Input(s)
{
  "string": "a"
}
Test Case 3 passed!
Expected Output
abc
Our Code's Output
abc
View Outputs Side By Side
Input(s)
{
  "string": "abc"
}
Test Case 4 passed!
Expected Output
abc
Our Code's Output
abc
View Outputs Side By Side
Input(s)
{
  "string": "abcb"
}
Test Case 5 passed!
Expected Output
abcdef
Our Code's Output
abcdef
View Outputs Side By Side
Input(s)
{
  "string": "abcdeabcdefc"
}
Test Case 6 passed!
Expected Output
cdea
Our Code's Output
cdea
View Outputs Side By Side
Input(s)
{
  "string": "abccdeaabbcddef"
}
Test Case 7 passed!
Expected Output
bac
Our Code's Output
bac
View Outputs Side By Side
Input(s)
{
  "string": "abacacacaaabacaaaeaaafa"
}
Test Case 8 passed!
Expected Output
dabcef
Our Code's Output
dabcef
View Outputs Side By Side
Input(s)
{
  "string": "abcdabcef"
}
Test Case 9 passed!
Expected Output
cbde
Our Code's Output
cbde
View Outputs Side By Side
Input(s)
{
  "string": "abcbde"
}
Test Case 10 passed!
Expected Output
mentisa
Our Code's Output
mentisa
View Outputs Side By Side
Input(s)
{
  "string": "clementisanarm"
} 



 */