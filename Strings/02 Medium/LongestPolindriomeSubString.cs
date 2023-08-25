namespace Strings._02_Medium
{
    public class LongestPalindromicSubstrings
    {
        public static string LongestPalindromicSubstring(string str)
        {
            // Write your code here.
            int[] currentLogest = { 0, 1 };

            for (int i = 1; i < str.Length; i++)
            {
                int[] odd = getLogestPolindromeFrom(str, i - 1, i + 1);
                int[] even = getLogestPolindromeFrom(str, i - 1, i);

                int[] longest = odd[1] - odd[0] > even[1] - even[0] ? odd : even;

                currentLogest = currentLogest[1] - currentLogest[0] > longest[1] - longest[0] ? currentLogest : longest;
            }

            return str.Substring(currentLogest[0], currentLogest[1] - currentLogest[0]);
        }

        public static int[] getLogestPolindromeFrom(string str, int leftIdx, int rightIdx)
        {
            while (leftIdx >= 0 && rightIdx < str.Length)
            {
                if (str[leftIdx] != str[rightIdx])
                {
                    break;
                }
                leftIdx--;
                rightIdx++;
            }
            return new int[] { leftIdx + 1, rightIdx };
        }
    }
}
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(
      Program.LongestPalindromicSubstring("abaxyzzyxf").Equals("xyzzyx")
    );
  }
}


14 / 14 test cases passed.

Test Case 1 passed!
Expected Output
xyzzyx
Our Code's Output
xyzzyx
View Outputs Side By Side
Input(s)
{
  "string": "abaxyzzyxf"
}
Test Case 2 passed!
Expected Output
a
Our Code's Output
a
View Outputs Side By Side
Input(s)
{
  "string": "a"
}
Test Case 3 passed!
Expected Output
noon
Our Code's Output
noon
View Outputs Side By Side
Input(s)
{
  "string": "it's highnoon"
}
Test Case 4 passed!
Expected Output
noon
Our Code's Output
noon
View Outputs Side By Side
Input(s)
{
  "string": "noon high it is"
}
Test Case 5 passed!
Expected Output
abccba
Our Code's Output
abccba
View Outputs Side By Side
Input(s)
{
  "string": "abccbait's highnoon"
}
Test Case 6 passed!
Expected Output
zzzzzzzzzzzzzzzzzzzz
Our Code's Output
zzzzzzzzzzzzzzzzzzzz
View Outputs Side By Side
Input(s)
{
  "string": "abcdefgfedcbazzzzzzzzzzzzzzzzzzzz"
}
Test Case 7 passed!
Expected Output
abcdefgfedcba
Our Code's Output
abcdefgfedcba
View Outputs Side By Side
Input(s)
{
  "string": "abcdefgfedcba"
}
Test Case 8 passed!
Expected Output
aa
Our Code's Output
aa
View Outputs Side By Side
Input(s)
{
  "string": "abcdefghfedcbaa"
}
Test Case 9 passed!
Expected Output
abcdefggfedcba
Our Code's Output
abcdefggfedcba
View Outputs Side By Side
Input(s)
{
  "string": "abcdefggfedcba"
}
Test Case 10 passed!
Expected Output
zz2345abbbba5432zz
Our Code's Output
zz2345abbbba5432zz
View Outputs Side By Side
Input(s)
{
  "string": "zzzzzzz2345abbbba5432zzbbababa"
}
Test Case 11 passed!
Expected Output
5abbbba5
Our Code's Output
5abbbba5
View Outputs Side By Side
Input(s)
{
  "string": "z234a5abbbba54a32z"
}
Test Case 12 passed!
Expected Output
5abbba5
Our Code's Output
5abbba5
View Outputs Side By Side
Input(s)
{
  "string": "z234a5abbba54a32z"
}
Test Case 13 passed!
Expected Output
b12365456321b
Our Code's Output
b12365456321b
View Outputs Side By Side
Input(s)
{
  "string": "ab12365456321bb"
}
Test Case 14 passed!
Expected Output
aca
Our Code's Output
aca
View Outputs Side By Side
Input(s)
{
  "string": "aca"
}
 
 
 */