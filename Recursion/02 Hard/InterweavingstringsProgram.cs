using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._02_Hard
{
    class InterweavingstringsProgram
    {
        public static bool InterweavingstringsSol1(string one, string two, string three)
        {
            // Write your code here.
            if (three.Length != one.Length + two.Length)
            {
                return false;
            }
            return areInterwoven(one, two, three, 0, 0);
        }
        public static bool areInterwoven(
            string one, string two, string three, int i, int j
        )
        {
            int k = i + j;
            if (k == three.Length) return true;

            if (i < one.Length && one[i] == three[k])
            {
                if (areInterwoven(one, two, three, i + 1, j)) return true;
            }
            if (j < two.Length && two[j] == three[k])
            {
                return areInterwoven(one, two, three, i, j + 1);
            }
            return false;
        }

        public static bool InterweavingstringsSol2(string one, string two, string three)
        {
            // Write your code here.
            if (three.Length != one.Length + two.Length)
            {
                return false;
            }

            bool?[,] cache = new bool?[one.Length + 1, two.Length + 1];
            return areInterwoven(one, two, three, 0, 0, cache);
        }
        public static bool areInterwoven(
            string one, string two, string three, int i, int j, bool?[,] cache
        )
        {
            if (cache[i, j].HasValue)
            {
                return cache[i, j].Value;
            }
            int k = i + j;

            if (k == three.Length)
            {
                return true;
            }
            if (i < one.Length && one[i] == three[k])
            {
                cache[i, j] = areInterwoven(one, two, three, i + 1, j, cache);
                if (cache[i, j].HasValue && cache[i, j].Value)
                {
                    return true;
                }
            }
            if (j < two.Length && two[j] == three[k])
            {
                cache[i, j] = areInterwoven(one, two, three, i, j + 1, cache);
                return cache[i, j].Value;
            }
            cache[i, j] = false;
            return false;
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    string one = "algoexpert";
    string two = "your-dream-job";
    string three = "your-algodream-expertjob";
    Utils.AssertTrue(Program.Interweavingstrings(one, two, three) == true);
  }
}

 20 / 20 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "algoexpert",
  "three": "your-algodream-expertjob",
  "two": "your-dream-job"
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "a",
  "three": "ab",
  "two": "b"
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "a",
  "three": "ba",
  "two": "b"
}
Test Case 4 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "a",
  "three": "ac",
  "two": "b"
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "abc",
  "three": "abcdef",
  "two": "def"
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "abc",
  "three": "adbecf",
  "two": "def"
}
Test Case 7 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "abc",
  "three": "deabcf",
  "two": "def"
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "aabcc",
  "three": "aadbbcbcac",
  "two": "dbbca"
}
Test Case 9 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "aabcc",
  "three": "aadbbbaccc",
  "two": "dbbca"
}
Test Case 10 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "algoexpert",
  "three": "ayloguore-xdpreeratm-job",
  "two": "your-dream-job"
}
Test Case 11 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "aaaaaaa",
  "three": "aaaaaaaaaaaaaab",
  "two": "aaaabaaa"
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "aaaaaaa",
  "three": "aaaaaaaaaaaaaa",
  "two": "aaaaaaa"
}
Test Case 13 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "aacaaaa",
  "three": "aaaabacaaaaaaa",
  "two": "aaabaaa"
}
Test Case 14 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "aacaaaa",
  "three": "aaaacabaaaaaaa",
  "two": "aaabaaa"
}
Test Case 15 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "aacaaaa",
  "three": "aaaaaacbaaaaaa",
  "two": "aaabaaa"
}
Test Case 16 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "algoexpert",
  "three": "1your-algodream-expertjob",
  "two": "your-dream-job"
}
Test Case 17 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "algoexpert",
  "three": "your-algodream-expertjob1",
  "two": "your-dream-job"
}
Test Case 18 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "algoexpert",
  "three": "your-algodream-expertjo",
  "two": "your-dream-job"
}
Test Case 19 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "one": "ae",
  "three": "see",
  "two": "e"
}
Test Case 20 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "one": "algo",
  "three": "fralgogo",
  "two": "frog"
}
 */