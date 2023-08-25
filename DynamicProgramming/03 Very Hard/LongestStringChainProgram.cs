using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._03_Very_Hard
{
    class LongestStringChainProgram
    {
    }
}
/*
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<string> strings = new List<string>(
      new[] { "abde", "abc", "abd", "abcde", "ade", "ae", "1abde", "abcdef" }
    );
    List<string> expected =
      new List<string>() { "abcdef", "abcde", "abde", "ade", "ae" };
    Utils.AssertTrue(Program.LongestStringChain(strings).SequenceEqual(expected)
    );
  }
}

7 / 7 test cases passed.

Test Case 1 passed!
Expected Output
["abcdef", "abcde", "abde", "ade", "ae"]
Our Code's Output
["abcdef", "abcde", "abde", "ade", "ae"]
View Outputs Side By Side
Input(s)
{
  "strings": ["abde", "abc", "abd", "abcde", "ade", "ae", "1abde", "abcdef"]
}
Test Case 2 passed!
Expected Output
["abcdefg", "abcdef", "abcde", "abcd", "abc", "ab", "a"]
Our Code's Output
["abcdefg", "abcdef", "abcde", "abcd", "abc", "ab", "a"]
View Outputs Side By Side
Input(s)
{
  "strings": ["abcdefg", "abcdef", "abcde", "abcd", "abc", "ab", "a"]
}
Test Case 3 passed!
Expected Output
["abcdefg", "abdefg", "abdfg", "bdfg", "bfg", "bg", "g"]
Our Code's Output
["abcdefg", "abdefg", "abdfg", "bdfg", "bfg", "bg", "g"]
View Outputs Side By Side
Input(s)
{
  "strings": ["abcdefg", "abdefg", "abdfg", "bdfg", "bfg", "bg", "g"]
}
Test Case 4 passed!
Expected Output
["12a345", "12345", "1234", "123", "12"]
Our Code's Output
["12a345", "12345", "1234", "123", "12"]
View Outputs Side By Side
Input(s)
{
  "strings": ["abcdefg", "1234", "abdefg", "abdfg", "123", "12", "bg", "g", "12345", "12a345"]
}
Test Case 5 passed!
Expected Output
[]
Our Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "strings": ["abcdefg1", "1234c", "abdefg2", "abdfg", "123", "122", "bgg", "g", "1a2345", "12a345"]
}
Test Case 6 passed!
Expected Output
["algoexpert", "algoxpert", "algoxprt", "lgoxprt", "lgoprt", "lgopt", "lgpt"]
Our Code's Output
["algoexpert", "algoxpert", "algoxprt", "lgoxprt", "lgoprt", "lgopt", "lgpt"]
View Outputs Side By Side
Input(s)
{
  "strings": ["lgoprt", "12345678", "algoxpert", "abcde", "123468", "lgoxprt", "abde", "lgopt", "1234678", "ade", "ae", "algoxprt", "a", "1abde", "lgpt", "123456789", "234678", "algoexpert"]
}
Test Case 7 passed!
Expected Output
["1abde", "abde", "ade", "ae", "a"]
Our Code's Output
["1abde", "abde", "ade", "ae", "a"]
View Outputs Side By Side
Input(s)
{
  "strings": ["12345678", "algoxpert", "123468", "abde", "lgopt", "1234678", "ade", "ae", "a", "1abde", "lgpt", "123456789", "234678", "algoexpert"]
}
 
 */