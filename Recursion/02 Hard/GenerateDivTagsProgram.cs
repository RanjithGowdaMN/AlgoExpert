using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._02_Hard
{
    class GenerateDivTagsProgram
    {
        public List<string> GenerateDivTags(int numberOfTags)
        {
            // Write your code here.
            List<string> matchedDivTags = new List<string>();
            GenerateDivTagsFromPrefix(numberOfTags, numberOfTags, "", matchedDivTags);
            return matchedDivTags;
        }
        public void GenerateDivTagsFromPrefix(
            int openingTagsNeeded,
            int closingTagsNeeded,
            string prefix,
            List<string> result
        )
        {
            if (openingTagsNeeded > 0)
            {
                string newPrefix = prefix + "<div>";
                GenerateDivTagsFromPrefix(
                    openingTagsNeeded - 1, closingTagsNeeded, newPrefix, result
                );
            }
            if (openingTagsNeeded < closingTagsNeeded)
            {
                string newPrefix = prefix + "</div>";
                GenerateDivTagsFromPrefix(
                    openingTagsNeeded, closingTagsNeeded - 1, newPrefix, result
                );
            }
            if (closingTagsNeeded == 0)
            {
                result.Add(prefix);
            }
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
    int input = 3;
    List<string> expected = new List<string> {
      "<div><div><div></div></div></div>",
      "<div><div></div><div></div></div>",
      "<div><div></div></div><div></div>",
      "<div></div><div><div></div></div>",
      "<div></div><div></div><div></div>"
    };
    var actual = new Program().GenerateDivTags(input);
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }
}

6 / 6 test cases passed.

Test Case 1 passed!
Expected Output
["<div><div><div></div></div></div>", "<div><div></div><div></div></div>", "<div><div></div></div><div></div>", "<div></div><div><div></div></div>", "<div></div><div></div><div></div>"]
Your Code's Output
["<div><div><div></div></div></div>", "<div><div></div><div></div></div>", "<div><div></div></div><div></div>", "<div></div><div><div></div></div>", "<div></div><div></div><div></div>"]
View Outputs Side By Side
Input(s)
{
  "numberOfTags": 3
}
Test Case 2 passed!
Expected Output
["<div><div></div></div>", "<div></div><div></div>"]
Your Code's Output
["<div><div></div></div>", "<div></div><div></div>"]
View Outputs Side By Side
Input(s)
{
  "numberOfTags": 2
}
Test Case 3 passed!
Expected Output
["<div></div>"]
Your Code's Output
["<div></div>"]
View Outputs Side By Side
Input(s)
{
  "numberOfTags": 1
}
Test Case 4 passed!
Expected Output
["<div><div><div><div></div></div></div></div>", "<div><div><div></div><div></div></div></div>", "<div><div><div></div></div><div></div></div>", "<div><div><div></div></div></div><div></div>", "<div><div></div><div><div></div></div></div>", "<div><div></div><div></div><div></div></div>", "<div><div></div><div></div></div><div></div>", "<div><div></div></div><div><div></div></div>", "<div><div></div></div><div></div><div></div>", "<div></div><div><div><div></div></div></div>", "<div></div><div><div></div><div></div></div>", "<div></div><div><div></div></div><div></div>", "<div></div><div></div><div><div></div></div>", "<div></div><div></div><div></div><div></div>"]
Your Code's Output
["<div><div><div><div></div></div></div></div>", "<div><div><div></div><div></div></div></div>", "<div><div><div></div></div><div></div></div>", "<div><div><div></div></div></div><div></div>", "<div><div></div><div><div></div></div></div>", "<div><div></div><div></div><div></div></div>", "<div><div></div><div></div></div><div></div>", "<div><div></div></div><div><div></div></div>", "<div><div></div></div><div></div><div></div>", "<div></div><div><div><div></div></div></div>", "<div></div><div><div></div><div></div></div>", "<div></div><div><div></div></div><div></div>", "<div></div><div></div><div><div></div></div>", "<div></div><div></div><div></div><div></div>"]
View Outputs Side By Side
Input(s)
{
  "numberOfTags": 4
}
Test Case 5 passed!
Expected Output
["<div><div><div><div><div></div></div></div></div></div>", "<div><div><div><div></div><div></div></div></div></div>", "<div><div><div><div></div></div><div></div></div></div>", "<div><div><div><div></div></div></div><div></div></div>", "<div><div><div><div></div></div></div></div><div></div>", "<div><div><div></div><div><div></div></div></div></div>", "<div><div><div></div><div></div><div></div></div></div>", "<div><div><div></div><div></div></div><div></div></div>", "<div><div><div></div><div></div></div></div><div></div>", "<div><div><div></div></div><div><div></div></div></div>", "<div><div><div></div></div><div></div><div></div></div>", "<div><div><div></div></div><div></div></div><div></div>", "<div><div><div></div></div></div><div><div></div></div>", "<div><div><div></div></div></div><div></div><div></div>", "<div><div></div><div><div><div></div></div></div></div>", "<div><div></div><div><div></div><div></div></div></div>", "<div><div></div><div><div></div></div><div></div></div... 
Your Code's Output
["<div><div><div><div><div></div></div></div></div></div>", "<div><div><div><div></div><div></div></div></div></div>", "<div><div><div><div></div></div><div></div></div></div>", "<div><div><div><div></div></div></div><div></div></div>", "<div><div><div><div></div></div></div></div><div></div>", "<div><div><div></div><div><div></div></div></div></div>", "<div><div><div></div><div></div><div></div></div></div>", "<div><div><div></div><div></div></div><div></div></div>", "<div><div><div></div><div></div></div></div><div></div>", "<div><div><div></div></div><div><div></div></div></div>", "<div><div><div></div></div><div></div><div></div></div>", "<div><div><div></div></div><div></div></div><div></div>", "<div><div><div></div></div></div><div><div></div></div>", "<div><div><div></div></div></div><div></div><div></div>", "<div><div></div><div><div><div></div></div></div></div>", "<div><div></div><div><div></div><div></div></div></div>", "<div><div></div><div><div></div></div><div></div></div... 
View Outputs Side By Side
Input(s)
{
  "numberOfTags": 5
}
Test Case 6 passed!
Expected Output
["<div><div><div><div><div><div></div></div></div></div></div></div>", "<div><div><div><div><div></div><div></div></div></div></div></div>", "<div><div><div><div><div></div></div><div></div></div></div></div>", "<div><div><div><div><div></div></div></div><div></div></div></div>", "<div><div><div><div><div></div></div></div></div><div></div></div>", "<div><div><div><div><div></div></div></div></div></div><div></div>", "<div><div><div><div></div><div><div></div></div></div></div></div>", "<div><div><div><div></div><div></div><div></div></div></div></div>", "<div><div><div><div></div><div></div></div><div></div></div></div>", "<div><div><div><div></div><div></div></div></div><div></div></div>", "<div><div><div><div></div><div></div></div></div></div><div></div>", "<div><div><div><div></div></div><div><div></div></div></div></div>", "<div><div><div><div></div></div><div></div><div></div></div></div>", "<div><div><div><div></div></div><div></div></div><div></div></div>", "<div><div><div><di... 
Your Code's Output
["<div><div><div><div><div><div></div></div></div></div></div></div>", "<div><div><div><div><div></div><div></div></div></div></div></div>", "<div><div><div><div><div></div></div><div></div></div></div></div>", "<div><div><div><div><div></div></div></div><div></div></div></div>", "<div><div><div><div><div></div></div></div></div><div></div></div>", "<div><div><div><div><div></div></div></div></div></div><div></div>", "<div><div><div><div></div><div><div></div></div></div></div></div>", "<div><div><div><div></div><div></div><div></div></div></div></div>", "<div><div><div><div></div><div></div></div><div></div></div></div>", "<div><div><div><div></div><div></div></div></div><div></div></div>", "<div><div><div><div></div><div></div></div></div></div><div></div>", "<div><div><div><div></div></div><div><div></div></div></div></div>", "<div><div><div><div></div></div><div></div><div></div></div></div>", "<div><div><div><div></div></div><div></div></div><div></div></div>", "<div><div><div><di... 
View Outputs Side By Side
Input(s)
{
  "numberOfTags": 6
}

 
 */