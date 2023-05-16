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
 est Case 1
{
  "string": "clementisacap"
}
Test Case 2
{
  "string": "a"
}
Test Case 3
{
  "string": "abc"
}
Test Case 4
{
  "string": "abcb"
}
Test Case 5
{
  "string": "abcdeabcdefc"
}
Test Case 6
{
  "string": "abccdeaabbcddef"
}
Test Case 7
{
  "string": "abacacacaaabacaaaeaaafa"
}
Test Case 8
{
  "string": "abcdabcef"
}
Test Case 9
{
  "string": "abcbde"
}
Test Case 10
{
  "string": "clementisanarm"
}
 */