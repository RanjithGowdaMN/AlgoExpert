using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._04_Very_Hard
{
    class SmallestSubstringContainingProgram
    {
        public static string SmallestSubstringContaining(string bigstring, string smallstring)
        {
            // Write your code here.
            Dictionary<char, int> targetCharCounts = getCharCounts(smallstring);
            List<int> substringBounds = getSubstringBounds(bigstring, targetCharCounts);
            return getstringFromBounds(bigstring, substringBounds);
        }

        public static Dictionary<char, int> getCharCounts(string str)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                increaseCharCount(str[i], charCounts);
            }
            return charCounts;
        }

        public static List<int> getSubstringBounds(string str, Dictionary<char, int> targetCharCounts)
        {
            List<int> substringBounds = new List<int>(){
            0, Int32.MaxValue
        };
            Dictionary<char, int> substringCharCounts = new Dictionary<char, int>();
            int numUniqueChars = targetCharCounts.Count;
            int numUniqueCharsDone = 0;
            int leftIdx = 0;
            int rightIdx = 0;

            while (rightIdx < str.Length)
            {
                char rightChar = str[rightIdx];
                if (!targetCharCounts.ContainsKey(rightChar))
                {
                    rightIdx++;
                    continue;
                }
                increaseCharCount(rightChar, substringCharCounts);
                if (substringCharCounts[rightChar] == targetCharCounts[rightChar])
                {
                    numUniqueCharsDone++;
                }
                while (numUniqueCharsDone == numUniqueChars && leftIdx <= rightIdx)
                {
                    substringBounds = getCloserBounds(leftIdx, rightIdx, substringBounds[0], substringBounds[1]);
                    char leftChar = str[leftIdx];
                    if (!targetCharCounts.ContainsKey(leftChar))
                    {
                        leftIdx++;
                        continue;
                    }
                    if (substringCharCounts[leftChar] == targetCharCounts[leftChar])
                    {
                        numUniqueCharsDone--;
                    }
                    decreaseCharCount(leftChar, substringCharCounts);
                    leftIdx++;
                }
                rightIdx++;
            }
            return substringBounds;
        }

        public static List<int> getCloserBounds(int idx1, int idx2, int idx3, int idx4)
        {
            return idx2 - idx1 < idx4 - idx3 ? new List<int>() { idx1, idx2 } : new List<int>() { idx3, idx4 };
        }

        public static string getstringFromBounds(string str, List<int> bounds)
        {
            int start = bounds[0];
            int end = bounds[1];
            if (end == Int32.MaxValue)
            {
                return "";
            }
            return str.Substring(start, end + 1 - start);
        }
        public static void increaseCharCount(char c, Dictionary<char, int> charCounts)
        {
            if (!charCounts.ContainsKey(c))
            {
                charCounts[c] = 1;
            }
            else
            {
                charCounts[c] += 1;
            }
        }
        public static void decreaseCharCount(char c, Dictionary<char, int> charCounts)
        {
            charCounts[c] = charCounts[c] - 1;
        }
    }
}

/*
 
public class ProgramTest {
  [Test]
  public void TestCase1() {
    string bigstring = "abcd$ef$axb$c$";
    string smallstring = "$$abf";
    string expected = "f$axb$";
    Utils.AssertTrue(Program.SmallestSubstringContaining(bigstring, smallstring)
                       .Equals(expected));
  }
}


16 / 16 test cases passed.

Test Case 1 passed!
Expected Output
f$axb$
Your Code's Output
f$axb$
View Outputs Side By Side
Input(s)
{
  "bigString": "abcd$ef$axb$c$",
  "smallString": "$$abf"
}
Test Case 2 passed!
Expected Output
abcdef
Your Code's Output
abcdef
View Outputs Side By Side
Input(s)
{
  "bigString": "abcdef",
  "smallString": "fa"
}
Test Case 3 passed!
Expected Output
d
Your Code's Output
d
View Outputs Side By Side
Input(s)
{
  "bigString": "abcdef",
  "smallString": "d"
}
Test Case 4 passed!
Expected Output
 
Your Code's Output
 
View Outputs Side By Side
Input(s)
{
  "bigString": "abcdefghijklmnopqrstuvwxyz",
  "smallString": "aajjttwwxxzz"
}
Test Case 5 passed!
Expected Output
abzacdwejxjftghiwjtklmnopqrstuvwxyz
Your Code's Output
abzacdwejxjftghiwjtklmnopqrstuvwxyz
View Outputs Side By Side
Input(s)
{
  "bigString": "abzacdwejxjftghiwjtklmnopqrstuvwxyz",
  "smallString": "aajjttwwxxzz"
}
Test Case 6 passed!
Expected Output
abzacdwejxjfxztghiwjt
Your Code's Output
abzacdwejxjfxztghiwjt
View Outputs Side By Side
Input(s)
{
  "bigString": "abzacdwejxjfxztghiwjtklmnopqrstuvwxyz",
  "smallString": "aajjttwwxxzz"
}
Test Case 7 passed!
Expected Output
 
Your Code's Output
 
View Outputs Side By Side
Input(s)
{
  "bigString": "aaaa+a$+aaa++$+++++++aaa",
  "smallString": "a+$aaAaaaa$++"
}
Test Case 8 passed!
Expected Output
affa+a$Affab+a+a+$a
Your Code's Output
affa+a$Affab+a+a+$a
View Outputs Side By Side
Input(s)
{
  "bigString": "a$fuu+afff+affaffa+a$Affab+a+a+$a$",
  "smallString": "a+$aaAaaaa$++"
}
Test Case 9 passed!
Expected Output
affa+a$Affab+a+a+$a
Your Code's Output
affa+a$Affab+a+a+$a
View Outputs Side By Side
Input(s)
{
  "bigString": "a$fuu+afff+affaffa+a$Affab+a+a+$a$bccgtt+aaaacA+++aaa$",
  "smallString": "a+$aaAaaaa$++"
}
Test Case 10 passed!
Expected Output
1932
Your Code's Output
1932
View Outputs Side By Side
Input(s)
{
  "bigString": "145624356128828193236336541277356789901",
  "smallString": "123"
}
Test Case 11 passed!
Expected Output
2356789901!
Your Code's Output
2356789901!
View Outputs Side By Side
Input(s)
{
  "bigString": "1456243561288281932363365412356789901!",
  "smallString": "123!"
}
Test Case 12 passed!
Expected Output
!88281932363365$
Your Code's Output
!88281932363365$
View Outputs Side By Side
Input(s)
{
  "bigString": "14562435612!88281932363365$412356789901",
  "smallString": "$123!"
}
Test Case 13 passed!
Expected Output
 
Your Code's Output
 
View Outputs Side By Side
Input(s)
{
  "bigString": "14562435612!88281932363365$412356789901",
  "smallString": "#!123!"
}
Test Case 14 passed!
Expected Output
 
Your Code's Output
 
View Outputs Side By Side
Input(s)
{
  "bigString": "14562435612!88281932363365$412356789901",
  "smallString": "#!333333123!"
}
Test Case 15 passed!
Expected Output
z!8828!193236!336!5$41!23!5!6789901#
Your Code's Output
z!8828!193236!336!5$41!23!5!6789901#
View Outputs Side By Side
Input(s)
{
  "bigString": "14562435612z!8828!193236!336!5$41!23!5!6789901#",
  "smallString": "#!2z"
}
Test Case 16 passed!
Expected Output
#z2!
Your Code's Output
#z2!
View Outputs Side By Side
Input(s)
{
  "bigString": "14562435612z!8828!193236!336!5$41!23!5!6789901#z2!",
  "smallString": "#!2z"
}
 */