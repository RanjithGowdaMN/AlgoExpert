using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._03VeryHard
{
    class KnuthMorrisPrattAlgorithmProgram
    {
        public static bool KnuthMorrisPrattAlgorithm(string str, string substring)
        {
            // O(n+m) time | O(m) space
            int[] pattern = buildPattern(substring);
            return doesMatch(str, substring, pattern);
        }

        public static int[] buildPattern(string substring)
        {
            int[] pattern = new int[substring.Length];
            Array.Fill(pattern, -1);
            int j = 0;
            int i = 1;
            while (i < substring.Length)
            {
                if (substring[i] == substring[j])
                {
                    pattern[i] = j;
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = pattern[j - 1] + 1;
                }
                else
                {
                    i++;
                }
            }
            return pattern;
        }

        public static bool doesMatch(string str, string substring, int[] pattern)
        {
            int i = 0;
            int j = 0;
            while (i + substring.Length - j <= str.Length)
            {
                if (str[i] == substring[j])
                {
                    if (j == substring.Length - 1) return true;
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = pattern[j - 1] + 1;
                }
                else
                {
                    i++;
                }
            }
            return false;
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(
      Program.KnuthMorrisPrattAlgorithm("aefoaefcdaefcdaed", "aefcdaed") == true
    );
  }
}

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "aefoaefcdaefcdaed",
  "substring": "aefcdaed"
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "testwafwafawfawfawfawfawfawfawfa",
  "substring": "fawfawfawfawfa"
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "tesseatesgawatewtesaffawgfawtteafawtesftawfawfawfwfawftest",
  "substring": "test"
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "aaabaabacdedfaabaabaaa",
  "substring": "aabaabaaa"
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "abxabcabcaby",
  "substring": "abcaby"
}
Test Case 6 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "decadaafcdf",
  "substring": "daf"
}
Test Case 7 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "aefoaefcdaefcdaed",
  "substring": "aefcaefaeiaefcd"
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "aefcdfaecdaefaefcdaefeaefcdcdeae",
  "substring": "aefcdaefeaefcd"
}
Test Case 9 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "bccbefbcdabbbcabfdcfe",
  "substring": "abc"
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "string": "adafccfefbbbfeeccbcfd",
  "substring": "ecb"
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "testwherethefullstringmatches",
  "substring": "testwherethefullstringmatches"
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "string": "aabc",
  "substring": "abc"
}
 
 */
