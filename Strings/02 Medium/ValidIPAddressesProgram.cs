using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._02_Medium
{
    class ValidIPAddressesProgram
    {
        public List<string> ValidIPAddresses(string str)
        {
            // Write your code here.
            List<string> ipAddressesFound = new List<string>();
            for (int i = 1; i < Math.Min((int)str.Length, 4); i++)
            {
                string[] currentIPAddressParts = new string[] { "", "", "", "" };

                currentIPAddressParts[0] = str.Substring(0, i - 0);
                if (!isValidPart(currentIPAddressParts[0]))
                {
                    continue;
                }

                for (int j = i + 1; j < i + Math.Min((int)str.Length - i, 4); j++)
                {
                    currentIPAddressParts[1] = str.Substring(i, j - i);
                    if (!isValidPart(currentIPAddressParts[1]))
                    {
                        continue;
                    }
                    for (int k = j + 1; k < j + Math.Min((int)str.Length - j, 4); k++)
                    {
                        currentIPAddressParts[2] = str.Substring(j, k - j);
                        currentIPAddressParts[3] = str.Substring(k);
                        if (isValidPart(currentIPAddressParts[2]) &&
                          isValidPart(currentIPAddressParts[3]))
                        {
                            ipAddressesFound.Add(join(currentIPAddressParts));
                        }
                    }
                }
            }
            return ipAddressesFound;
        }

        public bool isValidPart(string str)
        {
            int strAsInt = Int32.Parse(str);
            if (strAsInt > 255)
            {
                return false;
            }
            return str.Length == strAsInt.ToString().Length;
        }

        public string join(string[] strings)
        {
            StringBuilder sb = new StringBuilder();
            for (int l = 0; l < strings.Length; l++)
            {
                sb.Append(strings[l]);
                if (l < strings.Length - 1)
                {
                    sb.Append(".");
                }
            }
            return sb.ToString();
        }
    }
}

/*
 * 
 using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    string input = "1921680";
    List<string> expected = new List<string>();
    expected.Add("1.9.216.80");
    expected.Add("1.92.16.80");
    expected.Add("1.92.168.0");
    expected.Add("19.2.16.80");
    expected.Add("19.2.168.0");
    expected.Add("19.21.6.80");
    expected.Add("19.21.68.0");
    expected.Add("19.216.8.0");
    expected.Add("192.1.6.80");
    expected.Add("192.1.68.0");
    expected.Add("192.16.8.0");
    var actual = new Program().ValidIPAddresses(input);
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }
}

 
 * Test Case 1 passed!
Expected Output
["1.9.216.80", "1.92.16.80", "1.92.168.0", "19.2.16.80", "19.2.168.0", "19.21.6.80", "19.21.68.0", "19.216.8.0", "192.1.6.80", "192.1.68.0", "192.16.8.0"]
Your Code's Output
["1.9.216.80", "1.92.16.80", "1.92.168.0", "19.2.16.80", "19.2.168.0", "19.21.6.80", "19.21.68.0", "19.216.8.0", "192.1.6.80", "192.1.68.0", "192.16.8.0"]
View Outputs Side By Side
Input(s)
{
  "string": "1921680"
}
Test Case 2 passed!
Expected Output
["3.70.0.100", "37.0.0.100"]
Your Code's Output
["3.70.0.100", "37.0.0.100"]
View Outputs Side By Side
Input(s)
{
  "string": "3700100"
}
Test Case 3 passed!
Expected Output
["9.7.4.3"]
Your Code's Output
["9.7.4.3"]
View Outputs Side By Side
Input(s)
{
  "string": "9743"
}
Test Case 4 passed!
Expected Output
["9.7.4.30", "9.7.43.0", "9.74.3.0", "97.4.3.0"]
Your Code's Output
["9.7.4.30", "9.7.43.0", "9.74.3.0", "97.4.3.0"]
View Outputs Side By Side
Input(s)
{
  "string": "97430"
}
Test Case 5 passed!
Expected Output
["9.9.74.30", "9.97.4.30", "9.97.43.0", "99.7.4.30", "99.7.43.0", "99.74.3.0"]
Your Code's Output
["9.9.74.30", "9.97.4.30", "9.97.43.0", "99.7.4.30", "99.7.43.0", "99.74.3.0"]
View Outputs Side By Side
Input(s)
{
  "string": "997430"
}
Test Case 6 passed!
Expected Output
["255.255.255.255"]
Your Code's Output
["255.255.255.255"]
View Outputs Side By Side
Input(s)
{
  "string": "255255255255"
}
Test Case 7 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "string": "255255255256"
}
Test Case 8 passed!
Expected Output
["99.99.99.99"]
Your Code's Output
["99.99.99.99"]
View Outputs Side By Side
Input(s)
{
  "string": "99999999"
}
Test Case 9 passed!
Expected Output
["33.13.33.13", "33.133.3.13", "33.133.31.3"]
Your Code's Output
["33.13.33.13", "33.133.3.13", "33.133.31.3"]
View Outputs Side By Side
Input(s)
{
  "string": "33133313"
}
Test Case 10 passed!
Expected Output
["0.0.0.10"]
Your Code's Output
["0.0.0.10"]
View Outputs Side By Side
Input(s)
{
  "string": "00010"
}
Test Case 11 passed!
Expected Output
["1.0.0.100", "10.0.10.0", "100.1.0.0"]
Your Code's Output
["1.0.0.100", "10.0.10.0", "100.1.0.0"]
View Outputs Side By Side
Input(s)
{
  "string": "100100"
}
Test Case 12 passed!
Expected Output
["10.7.23.10", "10.7.231.0", "10.72.3.10", "10.72.31.0", "107.2.3.10", "107.2.31.0", "107.23.1.0"]
Your Code's Output
["10.7.23.10", "10.7.231.0", "10.72.3.10", "10.72.31.0", "107.2.3.10", "107.2.31.0", "107.23.1.0"]
View Outputs Side By Side
Input(s)
{
  "string": "1072310"
}
Test Case 13 passed!
Test Case 14 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "string": "11"
}
Test Case 15 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "string": "111"
}
Test Case 16 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "string": "00001"
}
 */