using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    public class RunLengthEncoding
    {
        public static string RunLengthEncodingT(string str)
        {
			StringBuilder sb = new StringBuilder();
			char PreviousChar = str[0];
			int count = 1;
			for (int i = 1; i < str.Length; i++)
			{
				PreviousChar = str[i - 1];
				if (str[i] != PreviousChar || count == 9)
				{
					sb.Append(count.ToString() + PreviousChar);
					count = 0;
				}
				count++;
			}

			sb.Append(count.ToString());
			sb.Append(str[str.Length - 1]);
			return sb.ToString();
		}
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = "AAAAAAAAAAAAABBCCCCDD";
    var expected = "9A4A2B4C2D";
    var actual = new Program().RunLengthEncoding(input);
    Utils.AssertTrue(expected.Equals(actual));
  }
}

15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
9A4A2B4C2D
Our Code's Output
9A4A2B4C2D
View Outputs Side By Side
Input(s)
{
  "string": "AAAAAAAAAAAAABBCCCCDD"
}
Test Case 2 passed!
Expected Output
1a1A
Our Code's Output
1a1A
View Outputs Side By Side
Input(s)
{
  "string": "aA"
}
Test Case 3 passed!
Expected Output
112233
Our Code's Output
112233
View Outputs Side By Side
Input(s)
{
  "string": "122333"
}
Test Case 4 passed!
Expected Output
9*3*7^6$7%6!9A9A2A
Our Code's Output
9*3*7^6$7%6!9A9A2A
View Outputs Side By Side
Input(s)
{
  "string": "************^^^^^^^$$$$$$%%%%%%%!!!!!!AAAAAAAAAAAAAAAAAAAA"
}
Test Case 5 passed!
Expected Output
1a1A1a1A5a1A3a4A1B3b4B
Our Code's Output
1a1A1a1A5a1A3a4A1B3b4B
View Outputs Side By Side
Input(s)
{
  "string": "aAaAaaaaaAaaaAAAABbbbBBBB"
}
Test Case 6 passed!
Expected Output
9 9 8 
Our Code's Output
9 9 8 
View Outputs Side By Side
Input(s)
{
  "string": "                          "
}
Test Case 7 passed!
Expected Output
112 321 334 342 35
Our Code's Output
112 321 334 342 35
View Outputs Side By Side
Input(s)
{
  "string": "1  222 333    444  555"
}
Test Case 8 passed!
Expected Output
111A122B133C144D
Our Code's Output
111A122B133C144D
View Outputs Side By Side
Input(s)
{
  "string": "1A2BB3CCC4DDDD"
}
Test Case 9 passed!
Expected Output
8.6_9=4A3 3A4B3 3B
Our Code's Output
8.6_9=4A3 3A4B3 3B
View Outputs Side By Side
Input(s)
{
  "string": "........______=========AAAA   AAABBBB   BBB"
}
Test Case 10 passed!
Expected Output
9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a1a
Our Code's Output
9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a1a
View Outputs Side By Side
Input(s)
{
  "string": "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
}
Test Case 11 passed!
Expected Output
8 9a9a9a9a9a4a
Our Code's Output
8 9a9a9a9a9a4a
View Outputs Side By Side
Input(s)
{
  "string": "        aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
}
Test Case 12 passed!
Expected Output
1 
Our Code's Output
1 
View Outputs Side By Side
Input(s)
{
  "string": " "
}
Test Case 13 passed!
Expected Output
1[1(7a1,7b1,5c1,6d1)1]
Our Code's Output
1[1(7a1,7b1,5c1,6d1)1]
View Outputs Side By Side
Input(s)
{
  "string": "[(aaaaaaa,bbbbbbb,ccccc,dddddd)]"
}
Test Case 14 passed!
Expected Output
9;3;9'9'2'111273524142311s
Our Code's Output
9;3;9'9'2'111273524142311s
View Outputs Side By Side
Input(s)
{
  "string": ";;;;;;;;;;;;''''''''''''''''''''1233333332222211112222111s"
}
Test Case 15 passed!
Expected Output
9A4A2B4C9D2D
Our Code's Output
9A4A2B4C9D2D
View Outputs Side By Side
Input(s)
{
  "string": "AAAAAAAAAAAAABBCCCCDDDDDDDDDDD"
}
 
 */