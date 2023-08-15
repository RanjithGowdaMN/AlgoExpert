using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    class BlackjackProbabilityProgram
    {
        public double BlackjackProbability(int target, int startingHand)
        {
            // Write your code here.
            Dictionary<int, double> memo = new Dictionary<int, double>();
            return Math.Round(
                calculateProbality(target, startingHand, memo) * 1000f
            ) / 1000f;
        }
        private double calculateProbality(
            int target, int currentHand, Dictionary<int, double> memo
        )
        {
            if (memo.ContainsKey(currentHand))
            {
                return memo[currentHand];
            }
            if (currentHand > target)
            {
                return 1;
            }
            if (currentHand + 4 >= target)
            {
                return 0;
            }
            double totalProbability = 0;
            for (int drawnCard = 1; drawnCard <= 10; drawnCard++)
            {
                totalProbability +=
                    .1 * calculateProbality(target, currentHand + drawnCard, memo);
            }
            memo[currentHand] = totalProbability;
            return totalProbability;
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    int target = 21;
    int startingHand = 15;
    double expected = 0.45;
    double actual = new Program().BlackjackProbability(target, startingHand);
    Utils.AssertTrue(expected == actual);
  }
}

 18 / 18 test cases passed.

Test Case 1 passed!
Expected Output
0.5
Your Code's Output
0.5
View Outputs Side By Side
Input(s)
{
  "startingHand": 16,
  "target": 21
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "startingHand": 21,
  "target": 21
}
Test Case 3 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "startingHand": 20,
  "target": 21
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "startingHand": 17,
  "target": 21
}
Test Case 5 passed!
Expected Output
0.45
Your Code's Output
0.45
View Outputs Side By Side
Input(s)
{
  "startingHand": 15,
  "target": 21
}
Test Case 6 passed!
Expected Output
0.268
Your Code's Output
0.268
View Outputs Side By Side
Input(s)
{
  "startingHand": 12,
  "target": 21
}
Test Case 7 passed!
Expected Output
0.295
Your Code's Output
0.295
View Outputs Side By Side
Input(s)
{
  "startingHand": 5,
  "target": 21
}
Test Case 8 passed!
Expected Output
0.261
Your Code's Output
0.261
View Outputs Side By Side
Input(s)
{
  "startingHand": 1,
  "target": 21
}
Test Case 9 passed!
Expected Output
0.5
Your Code's Output
0.5
View Outputs Side By Side
Input(s)
{
  "startingHand": 95,
  "target": 100
}
Test Case 10 passed!
Expected Output
0.195
Your Code's Output
0.195
View Outputs Side By Side
Input(s)
{
  "startingHand": 90,
  "target": 100
}
Test Case 11 passed!
Expected Output
0.273
Your Code's Output
0.273
View Outputs Side By Side
Input(s)
{
  "startingHand": 20,
  "target": 100
}
Test Case 12 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "startingHand": 100,
  "target": 100
}
Test Case 13 passed!
Expected Output
0.268
Your Code's Output
0.268
View Outputs Side By Side
Input(s)
{
  "startingHand": 1,
  "target": 10
}
Test Case 14 passed!
Expected Output
0.395
Your Code's Output
0.395
View Outputs Side By Side
Input(s)
{
  "startingHand": 3,
  "target": 10
}
Test Case 15 passed!
Expected Output
0.271
Your Code's Output
0.271
View Outputs Side By Side
Input(s)
{
  "startingHand": 3,
  "target": 30
}
Test Case 16 passed!
Expected Output
0.276
Your Code's Output
0.276
View Outputs Side By Side
Input(s)
{
  "startingHand": 7,
  "target": 30
}
Test Case 17 passed!
Expected Output
0.314
Your Code's Output
0.314
View Outputs Side By Side
Input(s)
{
  "startingHand": 15,
  "target": 30
}
Test Case 18 passed!
Expected Output
0.5
Your Code's Output
0.5
View Outputs Side By Side
Input(s)
{
  "startingHand": 25,
  "target": 30
}
 */