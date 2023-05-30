using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._02_Medium
{
    class OneEditProgram
    {
        public bool OneEdit(string stringOne, string stringTwo)
        {
            // Write your code here.
            int lenOne = stringOne.Length;
            int lenTwo = stringTwo.Length;
            if (Math.Abs(lenOne - lenTwo) > 1)
            {
                return false;
            }

            bool madeEdit = false;
            int idxOne = 0;
            int idxTwo = 0;

            while (idxOne < lenOne && idxTwo < lenTwo)
            {
                if (stringOne[idxOne] != stringTwo[idxTwo])
                {
                    if (madeEdit)
                    {
                        return false;
                    }
                    madeEdit = true;

                    if (lenOne > lenTwo)
                    {
                        idxOne++;
                    }
                    else if (lenTwo > lenOne)
                    {
                        idxTwo++;
                    }
                    else
                    {
                        idxOne++;
                        idxTwo++;
                    }
                }
                else
                {
                    idxOne++;
                    idxTwo++;
                }
            }

            return true;
        }
    }
}
/*
 Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "a",
  "stringTwo": "a"
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "aaa",
  "stringTwo": "aaa"
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "a",
  "stringTwo": "b"
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "ab",
  "stringTwo": "b"
}
Test Case 5 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "abc",
  "stringTwo": "b"
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "ab",
  "stringTwo": "a"
}
Test Case 7 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "b",
  "stringTwo": "ab"
}
Test Case 8 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "bb",
  "stringTwo": "a"
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "a",
  "stringTwo": "ab"
}
Test Case 10 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "bb",
  "stringTwo": "ab"
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "ab",
  "stringTwo": "bb"
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "helo"
}
Test Case 13 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "heo"
}
Test Case 14 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "heloo"
}
Test Case 15 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "heloos"
}
Test Case 16 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "heloos"
}
Test Case 17 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "helllo"
}
Test Case 18 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "helllos"
}
Test Case 19 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "ello"
}
Test Case 20 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "llo"
}
Test Case 21 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "ellos"
}
Test Case 22 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "hello",
  "stringTwo": "elllos"
}
Test Case 23 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "helo",
  "stringTwo": "helle"
}
Test Case 24 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "abcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklmnopqrstuvwxyz"
}
Test Case 25 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "bcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklmnopqrstuvwxyz"
}
Test Case 26 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "bcdefgijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklmnopqrstuvwxyz"
}
Test Case 27 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "bcdefghijklmnopqrstuvwxyz",
  "stringTwo": "acdefghijklmnopqrstuvwxyz"
}
Test Case 28 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "bcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abdefghijklmnopqrstuvwxyz"
}
Test Case 29 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "bcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklmnopqrstuvwxy"
}
Test Case 30 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "stringOne": "bcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklmnopqrstuvwxyza"
}
Test Case 31 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "abcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklnopqrstuvwxyz"
}
Test Case 32 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "abcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklmmnopqrstuvwxyz"
}
Test Case 33 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "stringOne": "abcdefghijklmnopqrstuvwxyz",
  "stringTwo": "abcdefghijklnnopqrstuvwxyz"
}
 
 */