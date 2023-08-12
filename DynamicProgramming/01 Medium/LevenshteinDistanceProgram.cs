using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._01_Medium
{
    class LevenshteinDistanceProgram
    {
        public static int LevenshteinDistance(string str1, string str2)
        {
            // Write your code here.
            int[,] edits = new int[str2.Length + 1, str1.Length + 1];
            for (int i = 0; i < str2.Length + 1; i++)
            {
                for (int j = 0; j < str1.Length + 1; j++)
                {
                    edits[i, j] = j;
                }
                edits[i, 0] = i;
            }

            for (int i = 1; i < str2.Length + 1; i++)
            {
                for (int j = 1; j < str1.Length + 1; j++)
                {
                    if (str2[i - 1] == str1[j - 1])
                    {
                        edits[i, j] = edits[i - 1, j - 1];
                    }
                    else
                    {
                        edits[i, j] = 1 + Math.Min(
                          edits[i - 1, j - 1], Math.Min(edits[i - 1, j], edits[i, j - 1])
                        );
                    }
                }
            }

            return edits[str2.Length, str1.Length];
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(Program.LevenshteinDistance("abc", "yabd") == 2);
  }
}
7 / 17 test cases passed.

Test Case 1 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "str1": "abc",
  "str2": "yabd"
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "str1": "",
  "str2": ""
}
Test Case 3 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "str1": "",
  "str2": "abc"
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "str1": "abc",
  "str2": "abc"
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "str1": "abc",
  "str2": "abx"
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "str1": "abc",
  "str2": "abcx"
}
Test Case 7 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "str1": "abc",
  "str2": "yabcx"
}
Test Case 8 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "str1": "algoexpert",
  "str2": "algozexpert"
}
Test Case 9 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "str1": "abcdefghij",
  "str2": "1234567890"
}
Test Case 10 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "str1": "abcdefghij",
  "str2": "a234567890"
}
Test Case 11 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "str1": "biting",
  "str2": "mitten"
}
Test Case 12 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "str1": "cereal",
  "str2": "saturday"
}
Test Case 13 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "str1": "cereal",
  "str2": "saturdzz"
}
Test Case 14 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "str1": "abbbbbbbbb",
  "str2": "bbbbbbbbba"
}
Test Case 15 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "str1": "xabc",
  "str2": "abcx"
}
Test Case 16 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "str1": "table",
  "str2": "bal"
}
Test Case 17 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "str1": "gumbo",
  "str2": "gambol"
}
 
 */