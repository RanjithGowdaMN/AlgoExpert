using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02Medium
{
    class MajarityElementProgram
    {
        public int MajorityElementSol1(int[] array)
        {
            // Write your code here.
            int count = 0;
            int answer = array[0];

            foreach (var value in array)
            {
                if (count == 0)
                {
                    answer = value;
                }

                if (answer == value)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            return answer;
        }

        public int MajorityElementSol2(int[] array)
        {
            // Write your code here.
            int answer = 0;

            for (int currentBit = 0; currentBit < 32; currentBit++)
            {
                int currentBitValue = 1 << currentBit;
                int onesCount = 0;

                foreach (var num in array)
                {
                    if ((num & currentBitValue) != 0)
                    {
                        onesCount++;
                    }
                }

                if (onesCount > array.Length / 2)
                {
                    answer += currentBitValue;
                }
            }
            return answer;
        }
    }
}

/*
 * 
 * using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[] { 1, 0, 1, 0, 0, 0, 1 };
    var expected = 4;
    var actual = new Program().BestSeat(input);
    Utils.AssertTrue(expected == actual);
  }
}

 Test Case 1 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [2]
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 1]
}
Test Case 3 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [3, 3, 1]
}
Test Case 4 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "array": [4, 5, 5]
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 2, 2, 1, 2]
}
Test Case 6 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 2, 3, 2, 2, 4, 2]
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 1, 1, 1]
}
Test Case 8 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [5, 4, 3, 2, 1, 1, 1, 1, 1]
}
Test Case 9 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 1, 5, 4, 3, 2]
}
Test Case 10 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 2, 2, 2, 2, 2]
}
Test Case 11 passed!
Expected Output
6543
Your Code's Output
6543
View Outputs Side By Side
Input(s)
{
  "array": [435, 6543, 6543, 435, 535, 6543, 6543, 12, 43, 6543, 6543]
}
 
 */