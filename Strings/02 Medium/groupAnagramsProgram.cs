using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._02_Medium
{
    class groupAnagramsProgram
    {
        public static List<List<string>> groupAnagrams(List<string> words)
        {
            // Write your code here.

            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

            foreach (string word in words)
            {
                char[] charArray = word.ToCharArray();
                Array.Sort(charArray);
                string sortedWord = new String(charArray);

                if (anagrams.ContainsKey(sortedWord))
                {
                    anagrams[sortedWord].Add(word);
                }
                else
                {
                    anagrams[sortedWord] = new List<string> { word };
                }
            }
            return anagrams.Values.ToList();
        }
    }
}

/*
 Test Case 1 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["foo"],
  ["flop", "olfp"],
  ["oy", "yo"],
  ["act", "cat", "tac"]
]
Your Code's Output
[
  ["yo", "oy"],
  ["act", "tac", "cat"],
  ["flop", "olfp"],
  ["foo"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["yo", "act", "flop", "tac", "foo", "cat", "oy", "olfp"]
}
Test Case 2 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "words": []
}
Test Case 3 passed!
Expected Output
[
  ["test"]
]
Your Code's Output
[
  ["test"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["test"]
}
Test Case 4 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["dabd", "ddba"],
  ["abc", "bca", "cab"]
]
Your Code's Output
[
  ["abc", "bca", "cab"],
  ["dabd", "ddba"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["abc", "dabd", "bca", "cab", "ddba"]
}
Test Case 5 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["abc", "bca", "cba"]
]
Your Code's Output
[
  ["abc", "cba", "bca"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["abc", "cba", "bca"]
}
Test Case 6 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["asd", "sda"],
  ["qwe", "weq"],
  ["xcz", "zxc"]
]
Your Code's Output
[
  ["zxc", "xcz"],
  ["asd", "sda"],
  ["weq", "qwe"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["zxc", "asd", "weq", "sda", "qwe", "xcz"]
}
Test Case 7 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["a"],
  ["meacyne"],
  ["cinema", "iceman"],
  ["flop", "lofp", "olfp"]
]
Your Code's Output
[
  ["cinema", "iceman"],
  ["a"],
  ["flop", "lofp", "olfp"],
  ["meacyne"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["cinema", "a", "flop", "iceman", "meacyne", "lofp", "olfp"]
}
Test Case 8 passed!
Expected Output
[
  ["abc"],
  ["abe"],
  ["abf"],
  ["abg"]
]
Your Code's Output
[
  ["abc"],
  ["abe"],
  ["abf"],
  ["abg"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["abc", "abe", "abf", "abg"]
}
Test Case 9 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["a"],
  ["aaa"]
]
Your Code's Output
[
  ["aaa"],
  ["a"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["aaa", "a"]
}
Test Case 10 passed!
Expected Output
[
  ["bob"],
  ["boo"]
]
Your Code's Output
[
  ["bob"],
  ["boo"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["bob", "boo"]
}
Test Case 11 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["duh"],
  ["ill"]
]
Your Code's Output
[
  ["ill"],
  ["duh"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["ill", "duh"]
}
Test Case 12 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["zn"],
  ["oy", "yo"]
]
Your Code's Output
[
  ["yo", "oy"],
  ["zn"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["yo", "oy", "zn"]
}
Test Case 13 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  ["yo"],
  ["yyo"]
]
Your Code's Output
[
  ["yyo"],
  ["yo"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["yyo", "yo"]
}
Test Case 14 passed!
Expected Output
[
  ["aca"],
  ["bba"]
]
Your Code's Output
[
  ["aca"],
  ["bba"]
]
View Outputs Side By Side
Input(s)
{
  "words": ["aca", "bba"]
}
 */