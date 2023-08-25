using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    public class FirstNonReapitingCharacter
    {
        private static int FirstNonReapitingCharacterT(string str)
        {
            Dictionary<char, int> CharFrequency = new Dictionary<char, int>();
            //Alternativly below line can be used
            //CharFrequency.GetValueOrDefault(str, 0);
            foreach (char s in str)
            {
                if (CharFrequency.ContainsKey(s))
                {
                    CharFrequency[s] += 1;
                }
                else 
                {
                    CharFrequency[s] = 1;
                }
            }

            foreach (char s in str)
            {
                if (CharFrequency[s] == 1)
                {
                    return str.IndexOf(s);
                }
            }
            return -1;

        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    string input = "abcdcaf";
    int expected = 1;
    var actual = new Program().FirstNonRepeatingCharacter(input);
    Utils.AssertTrue(expected == actual);
  }
}

15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "string": "abcdcaf"
}
Test Case 2 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "string": "faadabcbbebdf"
}
Test Case 3 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "a"
}
Test Case 4 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "ab"
}
Test Case 5 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "string": "abc"
}
Test Case 6 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "string": "abac"
}
Test Case 7 passed!
Expected Output
5
Our Code's Output
5
View Outputs Side By Side
Input(s)
{
  "string": "ababac"
}
Test Case 8 passed!
Expected Output
-1
Our Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "string": "ababacc"
}
Test Case 9 passed!
Expected Output
7
Our Code's Output
7
View Outputs Side By Side
Input(s)
{
  "string": "lmnopqldsafmnopqsa"
}
Test Case 10 passed!
Expected Output
25
Our Code's Output
25
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxy"
}
Test Case 11 passed!
Expected Output
-1
Our Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"
}
Test Case 12 passed!
Expected Output
-1
Our Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "string": ""
}
Test Case 13 passed!
Expected Output
10
Our Code's Output
10
View Outputs Side By Side
Input(s)
{
  "string": "ggyllaylacrhdzedddjsc"
}
Test Case 14 passed!
Expected Output
-1
Our Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "string": "aaaaaaaaaaaaaaaaaaaabbbbbbbbbbcccccccccccdddddddddddeeeeeeeeffghgh"
}
Test Case 15 passed!
Expected Output
-1
Our Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "string": "aabbccddeeff"
}
 
 */