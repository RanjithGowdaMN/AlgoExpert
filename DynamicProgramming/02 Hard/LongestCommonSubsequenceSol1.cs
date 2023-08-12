using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class LongestCommonSubsequenceSol1
    {

        //public static void Main()
        //{
        //    LongestCommonSubsequence("ZXVVYZW", "XKYKZPW");
        //}

        public static List<char> LongestCommonSubsequence(string str1, string str2)
        {
            // Write your code here.
            List<List<List<char>>> lcs = new List<List<List<char>>>();

            for (int i = 0; i < str2.Length + 1; i++)
            {
                lcs.Add(new List<List<char>>());
                for (int j = 0; j < str1.Length + 1; j++)
                {
                    lcs[i].Add(new List<char>());
                }
            }
            for (int i = 1; i < str2.Length + 1; i++)
            {
                for (int j = 1; j < str1.Length + 1; j++)
                {
                    if (str2[i - 1] == str1[j - 1])
                    {
                        List<char> copy = new List<char>(lcs[i - 1][j - 1]);
                        lcs[i][j] = copy;
                        lcs[i][j].Add(str2[i - 1]);
                    }
                    else
                    {
                        if (lcs[i - 1][j].Count > lcs[i][j - 1].Count)
                        {
                            lcs[i][j] = lcs[i - 1][j];
                        }
                        else
                        {
                            lcs[i][j] = lcs[i][j - 1];
                        }
                    }
                }
            }
            return lcs[str2.Length][str1.Length];
        }
    }
}
/*
 
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    char[] expected = { 'X', 'Y', 'Z', 'W' };
    Utils.AssertTrue(
      compare(Program.LongestCommonSubsequence("ZXVVYZW", "XKYKZPW"), expected)
    );
  }

  private static bool compare(List<char> arr1, char[] arr2) {
    if (arr1.Count != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }
}

0 / 10 test cases passed.

Test Case 1 passed!
Expected Output
["X", "Y", "Z", "W"]
Your Code's Output
["X", "Y", "Z", "W"]
View Outputs Side By Side
Input(s)
{
  "str1": "ZXVVYZW",
  "str2": "XKYKZPW"
}
Test Case 2 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "str1": "",
  "str2": ""
}
Test Case 3 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "str1": "",
  "str2": "ABCDEFG"
}
Test Case 4 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "str1": "ABCDEFG",
  "str2": ""
}
Test Case 5 passed!
Expected Output
["A", "B", "C", "D", "E", "F", "G"]
Your Code's Output
["A", "B", "C", "D", "E", "F", "G"]
View Outputs Side By Side
Input(s)
{
  "str1": "ABCDEFG",
  "str2": "ABCDEFG"
}
Test Case 6 passed!
Expected Output
["A", "E"]
Your Code's Output
["A", "E"]
View Outputs Side By Side
Input(s)
{
  "str1": "ABCDEFG",
  "str2": "APPLES"
}
Test Case 7 passed!
Expected Output
["n", "t"]
Your Code's Output
["n", "t"]
View Outputs Side By Side
Input(s)
{
  "str1": "clement",
  "str2": "antoine"
}
Test Case 8 passed!
Expected Output
["8", "4", "2"]
Your Code's Output
["8", "4", "2"]
View Outputs Side By Side
Input(s)
{
  "str1": "8111111111111111142",
  "str2": "222222222822222222222222222222433333333332"
}
Test Case 9 passed!
Expected Output
["C", "D", "E", "G", "H", "J", "K", "L", "W"]
Your Code's Output
["C", "D", "E", "G", "H", "J", "K", "L", "W"]
View Outputs Side By Side
Input(s)
{
  "str1": "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
  "str2": "CCCDDEGDHAGKGLWAJWKJAWGKGWJAKLGGWAFWLFFWAGJWKAG"
}
Test Case 10 passed!
Expected Output
["C", "D", "E", "G", "H", "J", "K", "L", "T", "U", "V"]
Your Code's Output
["C", "D", "E", "G", "H", "J", "K", "L", "T", "U", "V"]
View Outputs Side By Side
Input(s)
{
  "str1": "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
  "str2": "CCCDDEGDHAGKGLWAJWKJAWGKGWJAKLGGWAFWLFFWAGJWKAGTUV"
}
 
 */