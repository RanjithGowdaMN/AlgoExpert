using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    class CommonCharactersProgram
    {
        public string[] CommonCharacters(string[] strings)
        {
            // Write your code here.
            string smallestString = getsmallestString(strings);
            HashSet<char> potentialCommonCharacters = new HashSet<char>();
            for (int i = 0; i < smallestString.Length; i++)
            {
                potentialCommonCharacters.Add(smallestString[i]);
            }

            foreach (var str in strings)
            {
                removeNonExistentCharacters(str, potentialCommonCharacters);
            }
            string[] output = new string[potentialCommonCharacters.Count];
            int j = 0;
            foreach (var character in potentialCommonCharacters)
            {
                output[j] = character.ToString();
                j++;
            }
            return output;
        }

        public string getsmallestString(string[] strings)
        {
            string smallest = strings[0];
            foreach (string str in strings)
            {
                if (str.Length < smallest.Length)
                {
                    smallest = str;
                }
            }
            return smallest;
        }
        private void removeNonExistentCharacters(string str,
                                                HashSet<char> potentialCommonCharacters)
        {
            HashSet<char> uniqueStringChar = new HashSet<char>();
            for (int i = 0; i < str.Length; i++)
            {
                uniqueStringChar.Add(str[i]);
            }
            HashSet<char> charactersToRemove = new HashSet<char>();
            foreach (var character in potentialCommonCharacters)
            {
                if (!uniqueStringChar.Contains(character))
                {
                    charactersToRemove.Add(character);
                }
            }
            foreach (var character in charactersToRemove)
            {
                potentialCommonCharacters.Remove(character);
            }
        }
    }
}
/*
 Test Case 1 passed!
Expected Output
["b", "c"]
Your Code's Output
["b", "c"]
View Outputs Side By Side
Input(s)
{
  "strings": ["abc", "bcd", "cbad"]
}
Test Case 2 passed!
Expected Output
["a"]
Your Code's Output
["a"]
View Outputs Side By Side
Input(s)
{
  "strings": ["a"]
}
Test Case 3 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "strings": ["a", "b", "c"]
}
Test Case 4 passed!
Expected Output
["a"]
Your Code's Output
["a"]
View Outputs Side By Side
Input(s)
{
  "strings": ["aa", "aa"]
}
Test Case 5 passed!
Expected Output
["a"]
Your Code's Output
["a"]
View Outputs Side By Side
Input(s)
{
  "strings": ["aaaa", "a"]
}
Test Case 6 passed!
Expected Output
["a"]
Your Code's Output
["a"]
View Outputs Side By Side
Input(s)
{
  "strings": ["abcde", "aa", "foobar", "foobaz", "and this is a string", "aaaaaaaa", "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeea"]
}
Test Case 7 passed!
Expected Output
["a", "b", "c", "d", "e", "f"]
Your Code's Output
["a", "b", "c", "d", "e", "f"]
View Outputs Side By Side
Input(s)
{
  "strings": ["abcdef", "fedcba", "abcefd", "aefbcd", "efadbc", "effffffffffffbcda", "eeeeeffffffbbbbbaaaaaccccdddd", "**************abdcef************"]
}
Test Case 8 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["!", "&"]
Your Code's Output
["&", "!"]
View Outputs Side By Side
Input(s)
{
  "strings": ["ab&cdef!", "f!ed&cba", "a&bce!d", "ae&fb!cd", "efa&!dbc", "eff!&fff&fffffffbcda", "eeee!efff&fffbbbbbaaaaaccccdddd", "*******!***&****abdcef************", "*******!***&****a***********f*", "*******!***&****b***********c*"]
}
Test Case 9 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["*", "d"]
Your Code's Output
["d", "*"]
View Outputs Side By Side
Input(s)
{
  "strings": ["*abcd", "def*", "******d*****"]
}
Test Case 10 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["!", "*", "d"]
Your Code's Output
["d", "!", "*"]
View Outputs Side By Side
Input(s)
{
  "strings": ["*abc!d", "de!f*", "**!!!****d*****"]
}
 */