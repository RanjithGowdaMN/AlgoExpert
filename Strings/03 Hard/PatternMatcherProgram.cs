using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._03_Hard
{
    class PatternMatcherProgram
    {
        public static string[] PatternMatcher(string pattern, string str)
        {
            if (pattern.Length > str.Length)
            {
                return new string[] { };
            }
            char[] newPattern = getNewPattern(pattern);
            bool didSwitch = newPattern[0] != pattern[0];
            Dictionary<char, int> counts = new Dictionary<char, int>();
            counts['x'] = 0;
            counts['y'] = 0;
            int firstYPos = getCountAndFirstYPos(newPattern, counts);
            if (counts['y'] != 0)
            {
                for (int lenOfX = 1; lenOfX < str.Length; lenOfX++)
                {
                    double lenOfY =
                        ((double)str.Length - (double)lenOfX *
                         (double)counts['x']) /
                         (double)counts['y'];
                    if (lenOfY <= 0 || lenOfY % 1 != 0)
                    {
                        continue;
                    }
                    int yIdx = firstYPos * lenOfX;
                    string x = str.Substring(0, lenOfX);
                    string y = str.Substring(yIdx, (int)lenOfY);
                    string potentialMatch = buildPotentialMatch(newPattern, x, y);
                    if (str.Equals(potentialMatch))
                    {
                        return didSwitch ? new string[] { y, x } : new string[] { x, y };
                    }
                }
            }
            else
            {
                double lenOfX = str.Length / counts['x'];
                if (lenOfX % 1 == 0)
                {
                    string x = str.Substring(0, (int)lenOfX);
                    string potentialMatch = buildPotentialMatch(newPattern, x, "");
                    if (str.Equals(potentialMatch))
                    {
                        return didSwitch ? new string[] { "", x } : new string[] { x, "" };
                    }
                }
            }
            return new string[] { };
        }

        public static char[] getNewPattern(string pattern)
        {
            char[] patternLetters = pattern.ToCharArray();
            if (pattern[0] == 'x')
            {
                return patternLetters;
            }
            for (int i = 0; i < patternLetters.Length; i++)
            {
                if (patternLetters[i] == 'x')
                {
                    patternLetters[i] = 'y';
                }
                else
                {
                    patternLetters[i] = 'x';
                }
            }
            return patternLetters;
        }
        public static int getCountAndFirstYPos(char[] pattern, Dictionary<char, int> counts)
        {
            int firstYPos = -1;
            for (int i = 0; i < pattern.Length; i++)
            {
                char c = pattern[i];
                counts[c] = counts[c] + 1;
                if (c == 'y' && firstYPos == -1)
                {
                    firstYPos = i;
                }
            }
            return firstYPos;
        }

        public static string buildPotentialMatch(char[] pattern, string x, string y)
        {
            StringBuilder potentialMatch = new StringBuilder();
            foreach (char c in pattern)
            {
                if (c == 'x')
                {
                    potentialMatch.Append(x);
                }
                else
                {
                    potentialMatch.Append(y);
                }
            }
            return potentialMatch.ToString();
        }
    }
}

/*
 Test Case 1 passed!
Expected Output
["go", "powerranger"]
Your Code's Output
["go", "powerranger"]
View Outputs Side By Side
Input(s)
{
  "pattern": "xxyxxy",
  "string": "gogopowerrangergogopowerranger"
}
Test Case 2 passed!
Expected Output
["a", "b"]
Your Code's Output
["a", "b"]
View Outputs Side By Side
Input(s)
{
  "pattern": "xyxy",
  "string": "abab"
}
Test Case 3 passed!
Expected Output
["b", "a"]
Your Code's Output
["b", "a"]
View Outputs Side By Side
Input(s)
{
  "pattern": "yxyx",
  "string": "abab"
}
Test Case 4 passed!
Expected Output
["ma", "yo"]
Your Code's Output
["ma", "yo"]
View Outputs Side By Side
Input(s)
{
  "pattern": "yxx",
  "string": "yomama"
}
Test Case 5 passed!
Expected Output
["powerranger", "go"]
Your Code's Output
["powerranger", "go"]
View Outputs Side By Side
Input(s)
{
  "pattern": "yyxyyx",
  "string": "gogopowerrangergogopowerranger"
}
Test Case 6 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "pattern": "xyx",
  "string": "thisshouldobviouslybewrong"
}
Test Case 7 passed!
Expected Output
["test", ""]
Your Code's Output
["test", ""]
View Outputs Side By Side
Input(s)
{
  "pattern": "xxxx",
  "string": "testtesttesttest"
}
Test Case 8 passed!
Expected Output
["", "test"]
Your Code's Output
["", "test"]
View Outputs Side By Side
Input(s)
{
  "pattern": "yyyy",
  "string": "testtesttesttest"
}
Test Case 9 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "pattern": "xxyxyy",
  "string": "testtestwrongtestwrongtest"
}
Test Case 10 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "pattern": "xyxxxyyx",
  "string": "baddaddoombaddadoomibaddaddoombaddaddoombaddaddoombaddaddoomibaddaddoomibaddaddoom"
}
Test Case 11 passed!
Expected Output
["baddaddoomi", "baddaddoom"]
Your Code's Output
["baddaddoomi", "baddaddoom"]
View Outputs Side By Side
Input(s)
{
  "pattern": "yxyyyxxy",
  "string": "baddaddoombaddaddoomibaddaddoombaddaddoombaddaddoombaddaddoomibaddaddoomibaddaddoom"
}
Test Case 12 passed!
Expected Output
["baddaddoom", "baddaddoomi"]
Your Code's Output
["baddaddoom", "baddaddoomi"]
View Outputs Side By Side
Input(s)
{
  "pattern": "xyxxxyyx",
  "string": "baddaddoombaddaddoomibaddaddoombaddaddoombaddaddoombaddaddoomibaddaddoomibaddaddoom"
}
 */