using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._02_Medium
{
    class ReverseWordsInStringProgram
    {
        public string ReverseWordsInString(string str)
        {
            // Write your code here.
            char[] charatcters = str.ToCharArray();
            reverseListString(charatcters, 0, charatcters.Length - 1);

            int startOfWord = 0;
            while (startOfWord < charatcters.Length)
            {
                int endOfWord = startOfWord;
                while (endOfWord < charatcters.Length && charatcters[endOfWord] != ' ')
                {
                    endOfWord++;
                }
                reverseListString(charatcters, startOfWord, endOfWord - 1);
                startOfWord = endOfWord + 1;
            }

            return new string(charatcters);
        }

        public char[] reverseListString(char[] list, int start, int end)
        {
            while (start < end)
            {

                char temp = list[start];
                list[start] = list[end];
                list[end] = temp;
                start++;
                end--;
            }
            return list;
        }
    }
}

/*
 
 Test Case 1 passed!
Expected Output
best! the is AlgoExpert
Your Code's Output
best! the is AlgoExpert
View Outputs Side By Side
Input(s)
{
  "string": "AlgoExpert is the best!"
}
Test Case 2 passed!
Expected Output
Words These Reverse
Your Code's Output
Words These Reverse
View Outputs Side By Side
Input(s)
{
  "string": "Reverse These Words"
}
Test Case 3 passed!
Expected Output
678 hello ..H,,
Your Code's Output
678 hello ..H,,
View Outputs Side By Side
Input(s)
{
  "string": "..H,, hello 678"
}
Test Case 4 passed!
Expected Output
this words this this this words this this
Your Code's Output
this words this this this words this this
View Outputs Side By Side
Input(s)
{
  "string": "this this words this this this words this"
}
Test Case 5 passed!
Expected Output
56 34 23 12 1
Your Code's Output
56 34 23 12 1
View Outputs Side By Side
Input(s)
{
  "string": "1 12 23 34 56"
}
Test Case 6 passed!
Expected Output
ORANGE PLUM PEAR APPLE
Your Code's Output
ORANGE PLUM PEAR APPLE
View Outputs Side By Side
Input(s)
{
  "string": "APPLE PEAR PLUM ORANGE"
}
Test Case 7 passed!
Expected Output
this-is-one-word
Your Code's Output
this-is-one-word
View Outputs Side By Side
Input(s)
{
  "string": "this-is-one-word"
}
Test Case 8 passed!
Expected Output
a
Your Code's Output
a
View Outputs Side By Side
Input(s)
{
  "string": "a"
}
Test Case 9 passed!
Expected Output
ab
Your Code's Output
ab
View Outputs Side By Side
Input(s)
{
  "string": "ab"
}
Test Case 10 passed!
Expected Output
 
Your Code's Output
 
View Outputs Side By Side
Input(s)
{
  "string": ""
}
Test Case 11 passed!
Expected Output
interviews! coding for prepare to use to platform best the is algoexpert
Your Code's Output
interviews! coding for prepare to use to platform best the is algoexpert
View Outputs Side By Side
Input(s)
{
  "string": "algoexpert is the best platform to use to prepare for coding interviews!"
}
Test Case 12 passed!
Expected Output
commas by, separated, words,
Your Code's Output
commas by, separated, words,
View Outputs Side By Side
Input(s)
{
  "string": "words, separated, by, commas"
}
Test Case 13 passed!
Expected Output
whitespace   of lot     a has     string      this
Your Code's Output
whitespace   of lot     a has     string      this
View Outputs Side By Side
Input(s)
{
  "string": "this      string     has a     lot of   whitespace"
}
Test Case 14 passed!
Expected Output
a ab a
Your Code's Output
a ab a
View Outputs Side By Side
Input(s)
{
  "string": "a ab a"
}
Test Case 15 passed!
Expected Output
        test
Your Code's Output
        test
View Outputs Side By Side
Input(s)
{
  "string": "test        "
}
Test Case 16 passed!
Expected Output
 
Your Code's Output
 
View Outputs Side By Side
Input(s)
{
  "string": " "
}
 */