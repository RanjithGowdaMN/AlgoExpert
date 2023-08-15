using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    class PhoneNumberMnemonicsProgram
    {
        public static Dictionary<char, string[]> DIGIT_LETTERS =
    new Dictionary<char, string[]>{
        {'0', new string[]{"0"}},
        {'1', new string[]{"1"}},
        {'2', new string[]{"a", "b", "c"}},
        {'3', new string[]{"d", "e", "f"}},
        {'4', new string[]{"g", "h", "i"}},
        {'5', new string[]{"j", "k", "l"}},
        {'6', new string[]{"m", "n", "o"}},
        {'7', new string[]{"p", "q", "r", "s"}},
        {'8', new string[]{"t", "u", "v"}},
        {'9', new string[]{"w", "x", "y", "z"}}
    };
        public List<string> PhoneNumberMnemonics(string phoneNumber)
        {
            // Write your code here.
            string[] currentMnemonic = new string[phoneNumber.Length];
            Array.Fill(currentMnemonic, "0");

            List<string> mnemonicsFound = new List<string>();
            PhoneNumberMnemonicsHelper(0, phoneNumber, currentMnemonic, mnemonicsFound);

            return mnemonicsFound;
        }
        public void PhoneNumberMnemonicsHelper(
            int idx,
            string phoneNumber,
            string[] currentMnemonic,
            List<string> mnemonicsFound
        )
        {
            if (idx == phoneNumber.Length)
            {
                string mnemonic = String.Join("", currentMnemonic);
                mnemonicsFound.Add(mnemonic);
            }
            else
            {
                char digit = phoneNumber[idx];
                string[] letters = DIGIT_LETTERS[digit];
                foreach (var letter in letters)
                {
                    currentMnemonic[idx] = letter;
                    PhoneNumberMnemonicsHelper(
                      idx + 1, phoneNumber, currentMnemonic, mnemonicsFound
                    );
                }
            }
        }
    }
}
/*
 
 using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    string phoneNumber = "1905";
    string[] expectedValues = new string[] {
      "1w0j",
      "1w0k",
      "1w0l",
      "1x0j",
      "1x0k",
      "1x0l",
      "1y0j",
      "1y0k",
      "1y0l",
      "1z0j",
      "1z0k",
      "1z0l"
    };
    List<string> expected = new List<string>();
    for (int i = 0; i < expectedValues.Length; i++) {
      expected.Add(expectedValues[i]);
    }
    var actual = new Program().PhoneNumberMnemonics(phoneNumber);
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }
}

 12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
["1w0j", "1w0k", "1w0l", "1x0j", "1x0k", "1x0l", "1y0j", "1y0k", "1y0l", "1z0j", "1z0k", "1z0l"]
Your Code's Output
["1w0j", "1w0k", "1w0l", "1x0j", "1x0k", "1x0l", "1y0j", "1y0k", "1y0l", "1z0j", "1z0k", "1z0l"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "1905"
}
Test Case 2 passed!
Expected Output
["1111"]
Your Code's Output
["1111"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "1111"
}
Test Case 3 passed!
Expected Output
["00a", "00b", "00c"]
Your Code's Output
["00a", "00b", "00c"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "002"
}
Test Case 4 passed!
Expected Output
["ggg", "ggh", "ggi", "ghg", "ghh", "ghi", "gig", "gih", "gii", "hgg", "hgh", "hgi", "hhg", "hhh", "hhi", "hig", "hih", "hii", "igg", "igh", "igi", "ihg", "ihh", "ihi", "iig", "iih", "iii"]
Your Code's Output
["ggg", "ggh", "ggi", "ghg", "ghh", "ghi", "gig", "gih", "gii", "hgg", "hgh", "hgi", "hhg", "hhh", "hhi", "hig", "hih", "hii", "igg", "igh", "igi", "ihg", "ihh", "ihi", "iig", "iih", "iii"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "444"
}
Test Case 5 passed!
Expected Output
["w0jmmm1adg", "w0jmmm1adh", "w0jmmm1adi", "w0jmmm1aeg", "w0jmmm1aeh", "w0jmmm1aei", "w0jmmm1afg", "w0jmmm1afh", "w0jmmm1afi", "w0jmmm1bdg", "w0jmmm1bdh", "w0jmmm1bdi", "w0jmmm1beg", "w0jmmm1beh", "w0jmmm1bei", "w0jmmm1bfg", "w0jmmm1bfh", "w0jmmm1bfi", "w0jmmm1cdg", "w0jmmm1cdh", "w0jmmm1cdi", "w0jmmm1ceg", "w0jmmm1ceh", "w0jmmm1cei", "w0jmmm1cfg", "w0jmmm1cfh", "w0jmmm1cfi", "w0jmmn1adg", "w0jmmn1adh", "w0jmmn1adi", "w0jmmn1aeg", "w0jmmn1aeh", "w0jmmn1aei", "w0jmmn1afg", "w0jmmn1afh", "w0jmmn1afi", "w0jmmn1bdg", "w0jmmn1bdh", "w0jmmn1bdi", "w0jmmn1beg", "w0jmmn1beh", "w0jmmn1bei", "w0jmmn1bfg", "w0jmmn1bfh", "w0jmmn1bfi", "w0jmmn1cdg", "w0jmmn1cdh", "w0jmmn1cdi", "w0jmmn1ceg", "w0jmmn1ceh", "w0jmmn1cei", "w0jmmn1cfg", "w0jmmn1cfh", "w0jmmn1cfi", "w0jmmo1adg", "w0jmmo1adh", "w0jmmo1adi", "w0jmmo1aeg", "w0jmmo1aeh", "w0jmmo1aei", "w0jmmo1afg", "w0jmmo1afh", "w0jmmo1afi", "w0jmmo1bdg", "w0jmmo1bdh", "w0jmmo1bdi", "w0jmmo1beg", "w0jmmo1beh", "w0jmmo1bei", "w0jmmo1bfg", "w0jmmo1bfh", "w0jm... 
Your Code's Output
["w0jmmm1adg", "w0jmmm1adh", "w0jmmm1adi", "w0jmmm1aeg", "w0jmmm1aeh", "w0jmmm1aei", "w0jmmm1afg", "w0jmmm1afh", "w0jmmm1afi", "w0jmmm1bdg", "w0jmmm1bdh", "w0jmmm1bdi", "w0jmmm1beg", "w0jmmm1beh", "w0jmmm1bei", "w0jmmm1bfg", "w0jmmm1bfh", "w0jmmm1bfi", "w0jmmm1cdg", "w0jmmm1cdh", "w0jmmm1cdi", "w0jmmm1ceg", "w0jmmm1ceh", "w0jmmm1cei", "w0jmmm1cfg", "w0jmmm1cfh", "w0jmmm1cfi", "w0jmmn1adg", "w0jmmn1adh", "w0jmmn1adi", "w0jmmn1aeg", "w0jmmn1aeh", "w0jmmn1aei", "w0jmmn1afg", "w0jmmn1afh", "w0jmmn1afi", "w0jmmn1bdg", "w0jmmn1bdh", "w0jmmn1bdi", "w0jmmn1beg", "w0jmmn1beh", "w0jmmn1bei", "w0jmmn1bfg", "w0jmmn1bfh", "w0jmmn1bfi", "w0jmmn1cdg", "w0jmmn1cdh", "w0jmmn1cdi", "w0jmmn1ceg", "w0jmmn1ceh", "w0jmmn1cei", "w0jmmn1cfg", "w0jmmn1cfh", "w0jmmn1cfi", "w0jmmo1adg", "w0jmmo1adh", "w0jmmo1adi", "w0jmmo1aeg", "w0jmmo1aeh", "w0jmmo1aei", "w0jmmo1afg", "w0jmmo1afh", "w0jmmo1afi", "w0jmmo1bdg", "w0jmmo1bdh", "w0jmmo1bdi", "w0jmmo1beg", "w0jmmo1beh", "w0jmmo1bei", "w0jmmo1bfg", "w0jmmo1bfh", "w0jm... 
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "9056661234"
}
Test Case 6 passed!
Expected Output
["g1mdga0000", "g1mdgb0000", "g1mdgc0000", "g1mdha0000", "g1mdhb0000", "g1mdhc0000", "g1mdia0000", "g1mdib0000", "g1mdic0000", "g1mega0000", "g1megb0000", "g1megc0000", "g1meha0000", "g1mehb0000", "g1mehc0000", "g1meia0000", "g1meib0000", "g1meic0000", "g1mfga0000", "g1mfgb0000", "g1mfgc0000", "g1mfha0000", "g1mfhb0000", "g1mfhc0000", "g1mfia0000", "g1mfib0000", "g1mfic0000", "g1ndga0000", "g1ndgb0000", "g1ndgc0000", "g1ndha0000", "g1ndhb0000", "g1ndhc0000", "g1ndia0000", "g1ndib0000", "g1ndic0000", "g1nega0000", "g1negb0000", "g1negc0000", "g1neha0000", "g1nehb0000", "g1nehc0000", "g1neia0000", "g1neib0000", "g1neic0000", "g1nfga0000", "g1nfgb0000", "g1nfgc0000", "g1nfha0000", "g1nfhb0000", "g1nfhc0000", "g1nfia0000", "g1nfib0000", "g1nfic0000", "g1odga0000", "g1odgb0000", "g1odgc0000", "g1odha0000", "g1odhb0000", "g1odhc0000", "g1odia0000", "g1odib0000", "g1odic0000", "g1oega0000", "g1oegb0000", "g1oegc0000", "g1oeha0000", "g1oehb0000", "g1oehc0000", "g1oeia0000", "g1oeib0000", "g1oe... 
Your Code's Output
["g1mdga0000", "g1mdgb0000", "g1mdgc0000", "g1mdha0000", "g1mdhb0000", "g1mdhc0000", "g1mdia0000", "g1mdib0000", "g1mdic0000", "g1mega0000", "g1megb0000", "g1megc0000", "g1meha0000", "g1mehb0000", "g1mehc0000", "g1meia0000", "g1meib0000", "g1meic0000", "g1mfga0000", "g1mfgb0000", "g1mfgc0000", "g1mfha0000", "g1mfhb0000", "g1mfhc0000", "g1mfia0000", "g1mfib0000", "g1mfic0000", "g1ndga0000", "g1ndgb0000", "g1ndgc0000", "g1ndha0000", "g1ndhb0000", "g1ndhc0000", "g1ndia0000", "g1ndib0000", "g1ndic0000", "g1nega0000", "g1negb0000", "g1negc0000", "g1neha0000", "g1nehb0000", "g1nehc0000", "g1neia0000", "g1neib0000", "g1neic0000", "g1nfga0000", "g1nfgb0000", "g1nfgc0000", "g1nfha0000", "g1nfhb0000", "g1nfhc0000", "g1nfia0000", "g1nfib0000", "g1nfic0000", "g1odga0000", "g1odgb0000", "g1odgc0000", "g1odha0000", "g1odhb0000", "g1odhc0000", "g1odia0000", "g1odib0000", "g1odic0000", "g1oega0000", "g1oegb0000", "g1oegc0000", "g1oeha0000", "g1oehb0000", "g1oehc0000", "g1oeia0000", "g1oeib0000", "g1oe... 
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "4163420000"
}
Test Case 7 passed!
Expected Output
["1"]
Your Code's Output
["1"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "1"
}
Test Case 8 passed!
Expected Output
["0"]
Your Code's Output
["0"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "0"
}
Test Case 9 passed!
Expected Output
["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"]
Your Code's Output
["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "23"
}
Test Case 10 passed!
Expected Output
["1a1a", "1a1b", "1a1c", "1b1a", "1b1b", "1b1c", "1c1a", "1c1b", "1c1c"]
Your Code's Output
["1a1a", "1a1b", "1a1c", "1b1a", "1b1b", "1b1c", "1c1a", "1c1b", "1c1c"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "1212"
}
Test Case 11 passed!
Expected Output
["wp", "wq", "wr", "ws", "xp", "xq", "xr", "xs", "yp", "yq", "yr", "ys", "zp", "zq", "zr", "zs"]
Your Code's Output
["wp", "wq", "wr", "ws", "xp", "xq", "xr", "xs", "yp", "yq", "yr", "ys", "zp", "zq", "zr", "zs"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "97"
}
Test Case 12 passed!
Expected Output
["wt001m", "wt001n", "wt001o", "wu001m", "wu001n", "wu001o", "wv001m", "wv001n", "wv001o", "xt001m", "xt001n", "xt001o", "xu001m", "xu001n", "xu001o", "xv001m", "xv001n", "xv001o", "yt001m", "yt001n", "yt001o", "yu001m", "yu001n", "yu001o", "yv001m", "yv001n", "yv001o", "zt001m", "zt001n", "zt001o", "zu001m", "zu001n", "zu001o", "zv001m", "zv001n", "zv001o"]
Your Code's Output
["wt001m", "wt001n", "wt001o", "wu001m", "wu001n", "wu001o", "wv001m", "wv001n", "wv001o", "xt001m", "xt001n", "xt001o", "xu001m", "xu001n", "xu001o", "xv001m", "xv001n", "xv001o", "yt001m", "yt001n", "yt001o", "yu001m", "yu001n", "yu001o", "yv001m", "yv001n", "yv001o", "zt001m", "zt001n", "zt001o", "zu001m", "zu001n", "zu001o", "zv001m", "zv001n", "zv001o"]
View Outputs Side By Side
Input(s)
{
  "phoneNumber": "980016"
}
 */