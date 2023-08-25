using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    public class GenerateDocumentName
    {
        private static bool GenerateDocument(string characters, string document)
        {
            Dictionary<char, int> character = new Dictionary<char, int>();

            for (int i = 0; i < characters.Length; i++)
            {
                if (character.ContainsKey(characters[i]))
                {
                    character[characters[i]] +=1;
                }
                else
                {
                    character[characters[i]] = 1;
                }
            }

            for (int j = 0; j < document.Length; j++)
            {
                if (character.ContainsKey(document[j]) )
                {
                    if (character[document[j]] > 0)
                    {
                        character[document[j]] -= 1;
                    }
                    else
                    { 
                    return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
/*
 
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    string characters = "Bste!hetsi ogEAxpelrt x ";
    string document = "AlgoExpert is the Best!";
    bool expected = true;
    var actual = new Program().GenerateDocument(characters, document);
    Utils.AssertTrue(expected == actual);
  }
}

15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "Bste!hetsi ogEAxpelrt x ",
  "document": "AlgoExpert is the Best!"
}
Test Case 2 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "characters": "A",
  "document": "a"
}
Test Case 3 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "a",
  "document": "a"
}
Test Case 4 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "a hsgalhsa sanbjksbdkjba kjx",
  "document": ""
}
Test Case 5 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "characters": " ",
  "document": "hello"
}
Test Case 6 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "     ",
  "document": "     "
}
Test Case 7 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "aheaollabbhb",
  "document": "hello"
}
Test Case 8 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "characters": "aheaolabbhb",
  "document": "hello"
}
Test Case 9 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "characters": "estssa",
  "document": "testing"
}
Test Case 10 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "characters": "Bste!hetsi ogEAxpert",
  "document": "AlgoExpert is the Best!"
}
Test Case 11 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "characters": "helloworld ",
  "document": "hello wOrld"
}
Test Case 12 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "characters": "helloworldO",
  "document": "hello wOrld"
}
Test Case 13 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "helloworldO ",
  "document": "hello wOrld"
}
Test Case 14 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "&*&you^a%^&8766 _=-09     docanCMakemthisdocument",
  "document": "Can you make this document &"
}
Test Case 15 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "characters": "abcabcabcacbcdaabc",
  "document": "bacaccadac"
}

 
 */