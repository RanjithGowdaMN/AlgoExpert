using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._03_Hard
{
    public class Underscorify_Substring
    {
        public static string UnderscorifySubstring(string str, string substring)
        {
            // Write your code here.
            List<int[]> locations = collapse(getLocations(str, substring));
            return underscorify(str, locations);
        }

        public static List<int[]> getLocations(string str, string substring)
        {
            List<int[]> locations = new List<int[]>();
            int startIdx = 0;
            while (startIdx < str.Length)
            {
                int nextIdx = str.IndexOf(substring, startIdx);
                if (nextIdx != -1)
                {
                    locations.Add(new int[] { nextIdx, nextIdx + substring.Length });
                    startIdx = nextIdx + 1;
                }
                else
                {
                    break;
                }
            }
            return locations;
        }

        public static List<int[]> collapse(List<int[]> locations)
        {
            if (locations.Count == 0)
            {
                return locations;
            }
            List<int[]> newLocations = new List<int[]>();
            newLocations.Add(locations[0]);
            int[] previous = newLocations[0];
            for (int i = 1; i < locations.Count; i++)
            {
                int[] current = locations[i];
                if (current[0] <= previous[1])
                {
                    previous[1] = current[1];
                }
                else
                {
                    newLocations.Add(current);
                    previous = current;
                }
            }
            return newLocations;
        }

        public static string underscorify(string str, List<int[]> locations)
        {
            int locationsIdx = 0;
            int stringIdx = 0;
            bool inBetweenUS = false;
            int i = 0;
            List<string> finalChars = new List<string>();
            while (stringIdx < str.Length && locationsIdx < locations.Count)
            {
                if (stringIdx == locations[locationsIdx][i])
                {
                    finalChars.Add("_");
                    inBetweenUS = !inBetweenUS;
                    if (!inBetweenUS)
                    {
                        locationsIdx++;
                    }
                    i = i == 1 ? 0 : 1;
                }
                finalChars.Add(str[stringIdx].ToString());
                stringIdx++;
            }
            if (locationsIdx < locations.Count)
            {
                finalChars.Add("_");
            }
            else if (stringIdx < str.Length)
            {
                finalChars.Add(str.Substring(stringIdx));
            }
            return String.Join("", finalChars);
        }
    }

}

/*
public class ProgramTest {
  [Test]
  public void TestCase1() {
    string expected =
      "_test_this is a _testtest_ to see if _testestest_ it works";
    string output = Program.UnderscorifySubstring(
      "testthis is a testtest to see if testestest it works", "test"
    );
    Utils.AssertTrue(expected.Equals(output));
  }
}


11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
_test_this is a _testtest_ to see if _testestest_ it works
Our Code's Output
_test_this is a _testtest_ to see if _testestest_ it works
View Outputs Side By Side
Input(s)
{
  "string": "testthis is a testtest to see if testestest it works",
  "substring": "test"
}
Test Case 2 passed!
Expected Output
this is a _test_ to see if it works
Our Code's Output
this is a _test_ to see if it works
View Outputs Side By Side
Input(s)
{
  "string": "this is a test to see if it works",
  "substring": "test"
}
Test Case 3 passed!
Expected Output
_test_ this is a _test_ to see if it works
Our Code's Output
_test_ this is a _test_ to see if it works
View Outputs Side By Side
Input(s)
{
  "string": "test this is a test to see if it works",
  "substring": "test"
}
Test Case 4 passed!
Expected Output
_test_this is a _test_ to see if it works
Our Code's Output
_test_this is a _test_ to see if it works
View Outputs Side By Side
Input(s)
{
  "string": "testthis is a test to see if it works",
  "substring": "test"
}
Test Case 5 passed!
Expected Output
_test_this is a _testest_ to see if _testest_es it works
Our Code's Output
_test_this is a _testest_ to see if _testest_es it works
View Outputs Side By Side
Input(s)
{
  "string": "testthis is a testest to see if testestes it works",
  "substring": "test"
}
Test Case 6 passed!
Expected Output
this is a _test_ to see if it works and _test_
Our Code's Output
this is a _test_ to see if it works and _test_
View Outputs Side By Side
Input(s)
{
  "string": "this is a test to see if it works and test",
  "substring": "test"
}
Test Case 7 passed!
Expected Output
this is a test to see if it works and test
Our Code's Output
this is a test to see if it works and test
View Outputs Side By Side
Input(s)
{
  "string": "this is a test to see if it works and test",
  "substring": "bfjawkfja"
}
Test Case 8 passed!
Expected Output
_tttttttttttttt_b_ttttt_ctatawta_ttttt_astvb
Our Code's Output
_tttttttttttttt_b_ttttt_ctatawta_ttttt_astvb
View Outputs Side By Side
Input(s)
{
  "string": "ttttttttttttttbtttttctatawtatttttastvb",
  "substring": "ttt"
}
Test Case 9 passed!
Expected Output
tzttz_ttt_z
Our Code's Output
tzttz_ttt_z
View Outputs Side By Side
Input(s)
{
  "string": "tzttztttz",
  "substring": "ttt"
}
Test Case 10 passed!
Expected Output
_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_aa_b_a_b_aaa_bb_a_b_a_b_aa_
Our Code's Output
_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_a_b_aa_b_a_b_aaa_bb_a_b_a_b_aa_
View Outputs Side By Side
Input(s)
{
  "string": "abababababababababababababaababaaabbababaa",
  "substring": "a"
}
Test Case 11 passed!
Expected Output
_abcabcabcabcabcabcabcabcabcabcabcabcabcabc_
Our Code's Output
_abcabcabcabcabcabcabcabcabcabcabcabcabcabc_
View Outputs Side By Side
Input(s)
{
  "string": "abcabcabcabcabcabcabcabcabcabcabcabcabcabc",
  "substring": "abc"
} 



Test Case 1
{
  "string": "testthis is a testtest to see if testestest it works",
  "substring": "test"
}
Test Case 2
{
  "string": "this is a test to see if it works",
  "substring": "test"
}
Test Case 3
{
  "string": "test this is a test to see if it works",
  "substring": "test"
}
Test Case 4
{
  "string": "testthis is a test to see if it works",
  "substring": "test"
}
Test Case 5
{
  "string": "testthis is a testest to see if testestes it works",
  "substring": "test"
}
Test Case 6
{
  "string": "this is a test to see if it works and test",
  "substring": "test"
}
Test Case 7
{
  "string": "this is a test to see if it works and test",
  "substring": "bfjawkfja"
}
Test Case 8
{
  "string": "ttttttttttttttbtttttctatawtatttttastvb",
  "substring": "ttt"
}
Test Case 9
{
  "string": "tzttztttz",
  "substring": "ttt"
}
Test Case 10
{
  "string": "abababababababababababababaababaaabbababaa",
  "substring": "a"
}
Test Case 11
{
  "string": "abcabcabcabcabcabcabcabcabcabcabcabcabcabc",
  "substring": "abc"
}
 */