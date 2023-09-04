using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class CaesarCypherEncriptor
    {
        public static void Main()
        {
            //Do Nothing
        }
        public static string caesarCypherEncriptor(string  str, int key)
        {
            char[] newString = new char[str.Length];
            string alphabets = "abcdefghijklmnopqrstuvwxyz";
            
            for (int i = 0; i < newString.Length; i++)
            {
                newString[i] = GetCharecter(str[i], key, alphabets);
            }

            return new string (newString);
        }

        private static char GetCharecter(char v, int key, string alphabets)
        {
            return alphabets[(alphabets.IndexOf(v) + key)%26];
        }
    }
}
/*
public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(Program.CaesarCypherEncryptor("xyz", 2).Equals("zab"));
  }
}

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
zab
Your Code's Output
zab
View Outputs Side By Side
Input(s)
{
  "key": 2,
  "string": "xyz"
}
Test Case 2 passed!
Expected Output
abc
Your Code's Output
abc
View Outputs Side By Side
Input(s)
{
  "key": 0,
  "string": "abc"
}
Test Case 3 passed!
Expected Output
def
Your Code's Output
def
View Outputs Side By Side
Input(s)
{
  "key": 3,
  "string": "abc"
}
Test Case 4 passed!
Expected Output
cde
Your Code's Output
cde
View Outputs Side By Side
Input(s)
{
  "key": 5,
  "string": "xyz"
}
Test Case 5 passed!
Expected Output
abc
Your Code's Output
abc
View Outputs Side By Side
Input(s)
{
  "key": 26,
  "string": "abc"
}
Test Case 6 passed!
Expected Output
abc
Your Code's Output
abc
View Outputs Side By Side
Input(s)
{
  "key": 52,
  "string": "abc"
}
Test Case 7 passed!
Expected Output
fgh
Your Code's Output
fgh
View Outputs Side By Side
Input(s)
{
  "key": 57,
  "string": "abc"
}
Test Case 8 passed!
Expected Output
wxy
Your Code's Output
wxy
View Outputs Side By Side
Input(s)
{
  "key": 25,
  "string": "xyz"
}
Test Case 9 passed!
Expected Output
hvtepmjpjpnnkwyykyhgpel
Your Code's Output
hvtepmjpjpnnkwyykyhgpel
View Outputs Side By Side
Input(s)
{
  "key": 25,
  "string": "iwufqnkqkqoolxzzlzihqfm"
}
Test Case 10 passed!
Expected Output
ovmqkwtujqmfkao
Your Code's Output
ovmqkwtujqmfkao
View Outputs Side By Side
Input(s)
{
  "key": 52,
  "string": "ovmqkwtujqmfkao"
}
Test Case 11 passed!
Expected Output
tcrshocqjuidxcabatmhmrdpbhnqrgtgdnm
Your Code's Output
tcrshocqjuidxcabatmhmrdpbhnqrgtgdnm
View Outputs Side By Side
Input(s)
{
  "key": 7,
  "string": "mvklahvjcnbwqvtutmfafkwiuagjkzmzwgf"
}
Test Case 12 passed!
Expected Output
zylbcipjkyycbhpvlvplzpvujpjvywplvcplvywplyvplquplvwthw
Your Code's Output
zylbcipjkyycbhpvlvplzpvujpjvywplvcplvywplyvplquplvwthw
View Outputs Side By Side
Input(s)
{
  "key": 15,
  "string": "kjwmntauvjjnmsagwgawkagfuaugjhawgnawgjhawjgawbfawghesh"
}

 
 */