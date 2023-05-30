using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._02_Medium
{
    class MinimumCharactersForWordsProgram
    {
        public char[] MinimumCharactersForWords(string[] words)
        {
            Dictionary<char, int> maximumCharFrequency = new Dictionary<char, int>();

            foreach (var word in words)
            {
                Dictionary<char, int> charFrequence = countCharFrequency(word);
                updateMaximumFrequency(charFrequence, maximumCharFrequency);
            }

            return makeArrayFromCharFrequency(maximumCharFrequency);
        }

        public Dictionary<char, int> countCharFrequency(string word)
        {
            Dictionary<char, int> currentWordFrequency = new Dictionary<char, int>();
            foreach (var v in word.ToCharArray())
            {
                currentWordFrequency[v] = currentWordFrequency.GetValueOrDefault(v, 0) + 1;
            }
            return currentWordFrequency;
        }

        public void updateMaximumFrequency(Dictionary<char, int> currentWord,
                                           Dictionary<char, int> maxCharFrequency)
        {

            foreach (var frequency in currentWord)
            {
                char character = frequency.Key;
                int charFrequency = frequency.Value;

                if (maxCharFrequency.ContainsKey(character))
                {
                    maxCharFrequency[character] = Math.Max(charFrequency, maxCharFrequency[character]);
                }
                else
                {
                    maxCharFrequency[character] = charFrequency;
                }
            }
        }

        public char[] makeArrayFromCharFrequency(Dictionary<char, int> finalCharFrequency)
        {
            List<char> characters = new List<char>();

            foreach (var frequency in finalCharFrequency)
            {
                char character = frequency.Key;
                int charFrequency = frequency.Value;

                for (int i = 0; i < charFrequency; i++)
                {
                    characters.Add(character);
                }
            }

            char[] charArray = new char[characters.Count];
            for (int j = 0; j < characters.Count; j++)
            {
                charArray[j] = characters[j];
            }
            return charArray;
        }
    }
}

/*
 Test Case 1 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["!", "a", "d", "d", "e", "e", "h", "i", "m", "s", "t", "t"]
Your Code's Output
["t", "t", "h", "i", "s", "a", "d", "d", "e", "e", "m", "!"]
View Outputs Side By Side
Input(s)
{
  "words": ["this", "that", "did", "deed", "them!", "a"]
}
Test Case 2 passed!
Expected Output
["a", "b", "c", "o", "o"]
Your Code's Output
["a", "b", "c", "o", "o"]
View Outputs Side By Side
Input(s)
{
  "words": ["a", "abc", "ab", "boo"]
}
Test Case 3 passed!
Expected Output
["a"]
Your Code's Output
["a"]
View Outputs Side By Side
Input(s)
{
  "words": ["a"]
}
Test Case 4 passed!
Expected Output
["a", "b", "c"]
Your Code's Output
["a", "b", "c"]
View Outputs Side By Side
Input(s)
{
  "words": ["abc", "ab", "b", "bac", "c"]
}
Test Case 5 passed!
Expected Output
["!", "!", "!", "2", "2", "2", "3", "4"]
Your Code's Output
["!", "!", "!", "2", "2", "2", "3", "4"]
View Outputs Side By Side
Input(s)
{
  "words": ["!!!2", "234", "222", "432"]
}
Test Case 6 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["a", "e", "e", "h", "i", "m", "r", "s", "t", "t", "y"]
Your Code's Output
["t", "t", "h", "i", "s", "a", "e", "e", "y", "m", "r"]
View Outputs Side By Side
Input(s)
{
  "words": ["this", "that", "they", "them", "their", "there", "time", "is"]
}
Test Case 7 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["a", "e", "g", "i", "m", "r", "s", "t"]
Your Code's Output
["t", "i", "m", "s", "g", "r", "e", "a"]
View Outputs Side By Side
Input(s)
{
  "words": ["tim", "is", "great"]
}
Test Case 8 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["a", "a", "a", "a", "b", "c", "c", "d", "e", "f", "g", "v"]
Your Code's Output
["a", "a", "a", "a", "b", "c", "c", "v", "d", "e", "f", "g"]
View Outputs Side By Side
Input(s)
{
  "words": ["abc", "bavcc", "aaaa", "cde", "efg", "gead"]
}
Test Case 9 passed!
Expected Output
["a"]
Your Code's Output
["a"]
View Outputs Side By Side
Input(s)
{
  "words": ["a", "a", "a"]
}
Test Case 10 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["a", "b", "e", "h", "k", "m", "n", "o", "o", "s", "t", "t", "u", "y"]
Your Code's Output
["t", "t", "h", "e", "m", "y", "a", "s", "o", "o", "n", "b", "u", "k"]
View Outputs Side By Side
Input(s)
{
  "words": ["them", "they", "that", "that", "yes", "yo", "no", "boo", "you", "okay", "too"]
}
Test Case 11 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["a", "c", "t"]
Your Code's Output
["c", "t", "a"]
View Outputs Side By Side
Input(s)
{
  "words": ["cta", "cat", "tca", "tac", "a", "c", "t"]
}
Test Case 12 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["a", "c", "d", "e", "g", "i", "k", "l", "l", "m", "n", "o", "r", "s", "s", "t", "y"]
Your Code's Output
["m", "y", "c", "o", "d", "i", "n", "g", "s", "s", "k", "l", "l", "a", "r", "e", "t"]
View Outputs Side By Side
Input(s)
{
  "words": ["my", "coding", "skills", "are", "great"]
}
Test Case 13 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "words": []
}
Test Case 14 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["#", "$", "%", "&", "(", ")", "*", "0", "1", "1", "1", "2", "3", "6", "7", "7", "8", "8", "9", "9", ";", "@", "R", "T", "T", "^", "_", "a", "a", "a", "d", "d", "h", "h", "h", "j", "j", "k", "l", "n", "n", "s", "s", "x"]
Your Code's Output
["1", "1", "1", "6", "8", "8", "7", "7", "2", "h", "h", "h", "n", "n", "3", ";", "l", "s", "s", "d", "d", "j", "j", "a", "a", "a", "k", "x", "0", "9", "9", "@", "#", "$", "R", "T", "T", "%", "^", "&", "*", "(", ")", "_"]
View Outputs Side By Side
Input(s)
{
  "words": ["168712hn3;nlsdjhahjdksaxa097918@#$RT%T^&*()_"]
}
Test Case 15 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["A", "C", "a", "c", "t"]
Your Code's Output
["c", "a", "t", "A", "C"]
View Outputs Side By Side
Input(s)
{
  "words": ["cat", "cAt", "tAc", "Act", "Cat"]
}
Test Case 16 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["A", "E", "V", "a", "a", "a", "a", "b", "c", "c", "d", "e", "f", "g"]
Your Code's Output
["A", "b", "c", "c", "a", "a", "a", "a", "V", "d", "e", "E", "f", "g"]
View Outputs Side By Side
Input(s)
{
  "words": ["Abc", "baVcc", "aaaa", "cdeE", "efg", "gead"]
}
Test Case 17 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["a", "c", "e", "e", "g", "h", "i", "i", "i", "i", "k", "l", "m", "n", "o", "p", "p", "r", "s", "s", "s", "s", "t", "y"]
Your Code's Output
["m", "i", "i", "i", "i", "s", "s", "s", "s", "p", "p", "e", "e", "r", "c", "n", "g", "k", "l", "a", "y", "t", "h", "o"]
View Outputs Side By Side
Input(s)
{
  "words": ["mississippi", "piper", "icing", "ice", "pickle", "piping", "pie", "pi", "sassy", "serpent", "python", "ascii", "sister", "mister"]
}
 */