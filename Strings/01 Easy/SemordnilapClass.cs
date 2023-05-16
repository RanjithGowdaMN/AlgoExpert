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