using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class DiceThrowsProgram
    {
        public int DiceThrows(int numDice, int numSides, int target)
        {
            // O(d*s*t) time | O(d*t) space
            int[,] storedResults = new int[numDice + 1, target + 1];
            for (var i = 0; i < storedResults.GetLength(0); i++)
            {
                for (var j = 0; j < storedResults.GetLength(1); j++)
                {
                    storedResults[i, j] = -1;
                }
            }
            return DiceThrowsHelper(numDice, numSides, target, storedResults);
        }
        private int DiceThrowsHelper(
            int numDice, int numSides, int target, int[,] storedResults
        )
        {
            if (numDice == 0)
            {
                return target == 0 ? 1 : 0;
            }

            if (storedResults[numDice, target] != -1)
            {
                return storedResults[numDice, target];
            }
            int numWaysToReachTarget = 0;
            for (int currentTarget = Math.Max(0, target - numSides); currentTarget < target; currentTarget++)
            {
                numWaysToReachTarget += DiceThrowsHelper(numDice - 1, numSides, currentTarget, storedResults);
            }
            storedResults[numDice, target] = numWaysToReachTarget;

            return numWaysToReachTarget;
        }
    }
}
/*
__________________________________________________________________________________
 public int DiceThrows(int numDice, int numSides, int target) {
    // O(d*s*t) time | O(d*t) space
      int[,] storedResults = new int[numDice + 1, target + 1];
      storedResults[0,0]=1;

      for(int currentNumDice  =1; currentNumDice <= numDice; currentNumDice++){
          for(int currentTarget = 0; currentTarget <= target; currentTarget++){
              int numWaysToReachTarget = 0;
              for(int currentNumSides = 1; currentNumSides <= Math.Min(currentTarget, numSides); currentNumSides++ ){
                  numWaysToReachTarget +=
                      storedResults[currentNumDice -1, currentTarget- currentNumSides];
              }
              storedResults[currentNumDice, currentTarget] = numWaysToReachTarget;
          }
      }

      return storedResults[numDice, target];
  }

__________________________________________________________________________________


 public int DiceThrows(int numDice, int numSides, int target) {
    // O(d*s*t) time | O(d*t) space
      int[,] storedResults = new int[2, target + 1];
      storedResults[0,0]=1;

        int previousNumDiceIndex = 0;
        int newNumDiceIndex = 1;
      
      for(int currentNumDice  =0; currentNumDice < numDice; currentNumDice++){
          for(int currentTarget = 0; currentTarget <= target; currentTarget++){
              int numWaysToReachTarget = 0;
              for(int currentNumSides = 1; currentNumSides <= Math.Min(currentTarget, numSides); currentNumSides++ ){
                  numWaysToReachTarget +=
                      storedResults[previousNumDiceIndex, currentTarget- currentNumSides];
              }
              storedResults[newNumDiceIndex, currentTarget] = numWaysToReachTarget;
          }
          int tempPreviousNumDiceIndex = previousNumDiceIndex;
          previousNumDiceIndex = newNumDiceIndex;
          newNumDiceIndex = tempPreviousNumDiceIndex;
      }

      return storedResults[previousNumDiceIndex, target];
  }
__________________________________________________________________________________
 
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var numDice = 2;
    var numSides = 6;
    var target = 7;
    var expected = 6;
    var actual = new Program().DiceThrows(numDice, numSides, target);
    Utils.AssertTrue(expected == actual);
  }
}

 13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "numDice": 1,
  "numSides": 6,
  "target": 7
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "numDice": 2,
  "numSides": 1,
  "target": 3
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "numDice": 1,
  "numSides": 6,
  "target": 5
}
Test Case 4 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "numDice": 2,
  "numSides": 6,
  "target": 12
}
Test Case 5 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "numDice": 2,
  "numSides": 6,
  "target": 7
}
Test Case 6 passed!
Expected Output
55
Your Code's Output
55
View Outputs Side By Side
Input(s)
{
  "numDice": 3,
  "numSides": 10,
  "target": 12
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "numDice": 12,
  "numSides": 9,
  "target": 108
}
Test Case 8 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "numDice": 12,
  "numSides": 9,
  "target": 12
}
Test Case 9 passed!
Expected Output
7875
Your Code's Output
7875
View Outputs Side By Side
Input(s)
{
  "numDice": 7,
  "numSides": 5,
  "target": 22
}
Test Case 10 passed!
Expected Output
140
Your Code's Output
140
View Outputs Side By Side
Input(s)
{
  "numDice": 4,
  "numSides": 6,
  "target": 15
}
Test Case 11 passed!
Expected Output
45
Your Code's Output
45
View Outputs Side By Side
Input(s)
{
  "numDice": 3,
  "numSides": 9,
  "target": 11
}
Test Case 12 passed!
Expected Output
4221
Your Code's Output
4221
View Outputs Side By Side
Input(s)
{
  "numDice": 6,
  "numSides": 6,
  "target": 20
}
Test Case 13 passed!
Expected Output
37254789
Your Code's Output
37254789
View Outputs Side By Side
Input(s)
{
  "numDice": 11,
  "numSides": 9,
  "target": 32
}
 
 */