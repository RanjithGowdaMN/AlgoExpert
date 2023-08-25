using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    public class SemordnilapClass
    {
        public List<List<string>> Semordnilap(string[] words)
        {
            // Write your code here.
            HashSet<string> wordsSet = new HashSet<string>(words);
            List<List<string>> Semords = new List<List<string>>();

            foreach (string ele in words)
            {
                char[] word = ele.ToCharArray();
                Array.Reverse(word);
                string reverse = new string(word);
                if (wordsSet.Contains(reverse) && !reverse.Equals(ele))
                {
                    List<string> newPair = new List<string>() { reverse, ele };
                    Semords.Add(newPair);
                    wordsSet.Remove(ele);
                    wordsSet.Remove(reverse);

                }
            }

            return Semords;
        }
    }

}
/*

using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new string[] { "desserts", "stressed", "hello" };
    List<List<string> > expected = new List<List<string> >();
    List<string> pair = new List<string> { "desserts", "stressed" };
    expected.Add(pair);
    var actual = new Program().Semordnilap(input);
    Utils.AssertTrue(expected.Count == actual.Count);
    for (var i = 0; i < expected.Count; i++) {
      Utils.AssertTrue(Enumerable.SequenceEqual(expected[i], actual[i]));
    }
  }
}


10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
[]
Our Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "words": []
}
Test Case 2 passed!
Expected Output
[]
Our Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "words": ["aaa", "bbbb"]
}
Test Case 3 passed!
Expected Output
[
  ["dog", "god"]
]
Our Code's Output
[
  ["dog", "god"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["dog", "god"]
}
Test Case 4 passed!
Expected Output
[
  ["dog", "god"]
]
Our Code's Output
[
  ["dog", "god"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["dog", "hello", "god"]
}
Test Case 5 passed!
Expected Output
[
  ["dog", "god"],
  ["desserts", "stressed"]
]
Our Code's Output
[
  ["dog", "god"],
  ["desserts", "stressed"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["dog", "desserts", "god", "stressed"]
}
Test Case 6 passed!
Expected Output
[
  ["dog", "god"],
  ["desserts", "stressed"]
]
Our Code's Output
[
  ["dog", "god"],
  ["desserts", "stressed"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["dog", "hello", "desserts", "test", "god", "stressed"]
}
Test Case 7 passed!
Expected Output
[
  ["abcde", "edcba"],
  ["cbde", "edbc"]
]
Our Code's Output
[
  ["abcde", "edcba"],
  ["cbde", "edbc"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["abcde", "edcba", "edbc", "edb", "cbde", "abc"]
}
Test Case 8 passed!
Expected Output
[
  ["abcde", "edcba"],
  ["bcd", "dcb"]
]
Our Code's Output
[
  ["abcde", "edcba"],
  ["bcd", "dcb"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["abcde", "bcd", "dcb", "edcba", "aaa"]
}
Test Case 9 passed!
Expected Output
[
  ["abcdefghijk", "kjihgfedcba"]
]
Our Code's Output
[
  ["abcdefghijk", "kjihgfedcba"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["abcdefghijk", "aaa", "hello", "racecar", "kjihgfedcba"]
}
Test Case 10 passed!
Expected Output
[
  ["dog", "god"],
  ["desserts", "stressed"],
  ["evil", "live"],
  ["palindromes", "semordnilap"]
]
Our Code's Output
[
  ["dog", "god"],
  ["desserts", "stressed"],
  ["evil", "live"],
  ["palindromes", "semordnilap"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["liver", "dog", "hello", "desserts", "evil", "test", "god", "stressed", "racecar", "palindromes", "semordnilap", "abcd", "live"]
}




 Test Case 1
{
  "words": []
}
Test Case 2
{
  "words": ["aaa", "bbbb"]
}
Test Case 3
{
  "words": ["dog", "god"]
}
Test Case 4
{
  "words": ["dog", "hello", "god"]
}
Test Case 5
{
  "words": ["dog", "desserts", "god", "stressed"]
}
Test Case 6
{
  "words": ["dog", "hello", "desserts", "test", "god", "stressed"]
}
Test Case 7
{
  "words": ["abcde", "edcba", "edbc", "edb", "cbde", "abc"]
}
Test Case 8
{
  "words": ["abcde", "bcd", "dcb", "edcba", "aaa"]
}
Test Case 9
{
  "words": ["abcdefghijk", "aaa", "hello", "racecar", "kjihgfedcba"]
}
Test Case 10
{
  "words": ["liver", "dog", "hello", "desserts", "evil", "test", "god", "stressed", "racecar", "palindromes", "semordnilap", "abcd", "live"]
}
 */