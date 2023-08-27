using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._03_Very_Hard
{
    class PolindromePartitionatingMinCutsProgram
    {
        public static int PalindromePartitioningMinCuts(string str)
        {
            // O(n^2) time complexity | O(n^2) space complexity
            bool[,] palindromes = new bool[str.Length, str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (i == j)
                    {
                        palindromes[i, j] = true;
                    }
                    else
                    {
                        palindromes[i, j] = false;
                    }
                }
            }

            for (int length = 2; length < str.Length + 1; length++)
            {
                for (int i = 0; i < str.Length - length + 1; i++)
                {
                    int j = i + length - 1;
                    if (length == 2)
                    {
                        palindromes[i, j] = (str[i] == str[j]);
                    }
                    else
                    {
                        palindromes[i, j] = (str[i] == str[j] && palindromes[i + 1, j - 1]);
                    }
                }
            }

            int[] cuts = new int[str.Length];
            Array.Fill(cuts, Int32.MaxValue);
            for (int i = 0; i < str.Length; i++)
            {
                if (palindromes[0, i])
                {
                    cuts[i] = 0;
                }
                else
                {
                    cuts[i] = cuts[i - 1] + 1;
                    for (int j = 1; j < i; j++)
                    {
                        if (palindromes[j, i] && cuts[j - 1] + 1 < cuts[i])
                        {
                            cuts[i] = cuts[j - 1] + 1;
                        }
                    }
                }
            }

            return cuts[str.Length - 1];
        }
    }
}
/*
 * 
public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(Program.PalindromePartitioningMinCuts("noonabbad") == 2);
  }
}

 
 11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "noonabbad"
}
Test Case 2 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "a"
}
Test Case 3 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "abba"
}
Test Case 4 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "abbba"
}
Test Case 5 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "string": "abb"
}
Test Case 6 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "string": "abbb"
}
Test Case 7 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "string": "abcbm"
}
Test Case 8 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "string": "ababbbabbababa"
}
Test Case 9 passed!
Expected Output
4
Our Code's Output
4
View Outputs Side By Side
Input(s)
{
  "string": "abbbacecffgbgffab"
}
Test Case 10 passed!
Expected Output
25
Our Code's Output
25
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghijklmonpqrstuvwxyz"
}
Test Case 11 passed!
Expected Output
26
Our Code's Output
26
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghijklmracecaronpqrstuvwxyz"
}
 
 */