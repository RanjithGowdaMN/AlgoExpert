using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._02_Hard
{
    class AmbiguousMeasurementsProgram
    {
        public bool AmbiguousMeasurements(int[][] measuringCups, int low, int high)
        {
            // Write your code here.
            Dictionary<string, bool> memo = new Dictionary<string, bool>();
            return canMeasureInRange(measuringCups, low, high, memo);
        }
        public bool canMeasureInRange(
            int[][] measuringCups,
            int low,
            int high,
            Dictionary<string, bool> memo
        )
        {
            string memoKey = createHashTableKey(low, high);
            if (memo.ContainsKey(memoKey))
            {
                return memo[memoKey];
            }
            if (low <= 0 && high <= 0)
            {
                return false;
            }
            bool canMeasure = false;
            foreach (var cup in measuringCups)
            {
                int cupLow = cup[0];
                int cupHigh = cup[1];
                if (low <= cupLow && cupHigh <= high)
                {
                    canMeasure = true;
                    break;
                }
                int newLow = Math.Max(0, low - cupLow);
                int newHigh = Math.Max(0, high - cupHigh);
                canMeasure =
                    canMeasureInRange(measuringCups, newLow, newHigh, memo);
                if (canMeasure) break;
            }
            memo[memoKey] = canMeasure;
            return canMeasure;
        }
        public string createHashTableKey(int low, int high)
        {
            return low.ToString() + ":" + high.ToString();
        }
    }
}


/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] cups = new int[][] {
      new int[] { 200, 210 }, new int[] { 450, 465 }, new int[] { 800, 850 }
    };
    int low = 2100;
    int high = 2300;
    bool expected = true;
    var actual = new Program().AmbiguousMeasurements(cups, low, high);
    Utils.AssertTrue(expected == actual);
  }
}

18 / 18 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 2300,
  "low": 2100,
  "measuringCups": [
    [200, 210],
    [450, 465],
    [800, 850]
  ]
}
Test Case 2 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 20,
  "low": 10,
  "measuringCups": [
    [200, 210]
  ]
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 2300,
  "low": 2100,
  "measuringCups": [
    [230, 240],
    [290, 310],
    [500, 515]
  ]
}
Test Case 4 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 101,
  "low": 100,
  "measuringCups": [
    [1, 3],
    [2, 4],
    [5, 6]
  ]
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 120,
  "low": 100,
  "measuringCups": [
    [1, 3],
    [2, 4],
    [5, 6]
  ]
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 12,
  "low": 10,
  "measuringCups": [
    [1, 3],
    [2, 4],
    [5, 6],
    [10, 20]
  ]
}
Test Case 7 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 12,
  "low": 10,
  "measuringCups": [
    [1, 3],
    [2, 4],
    [5, 7],
    [10, 20]
  ]
}
Test Case 8 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 1050,
  "low": 1000,
  "measuringCups": [
    [50, 60],
    [100, 120],
    [20, 40],
    [10, 15],
    [400, 500]
  ]
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 1200,
  "low": 1000,
  "measuringCups": [
    [50, 65],
    [100, 120],
    [20, 40],
    [10, 15],
    [400, 500]
  ]
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 3300,
  "low": 3000,
  "measuringCups": [
    [50, 65],
    [100, 120],
    [20, 40],
    [10, 15],
    [400, 500],
    [300, 350],
    [10, 25]
  ]
}
Test Case 11 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 1050,
  "low": 1000,
  "measuringCups": [
    [50, 60],
    [100, 120],
    [20, 40],
    [400, 500]
  ]
}
Test Case 12 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 200,
  "low": 200,
  "measuringCups": [
    [50, 65]
  ]
}
Test Case 13 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 200,
  "low": 200,
  "measuringCups": [
    [50, 50]
  ]
}
Test Case 14 passed!
Test Case 15 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 1000,
  "low": 0,
  "measuringCups": [
    [100, 150],
    [1000, 2000]
  ]
}
Test Case 16 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 20,
  "low": 10,
  "measuringCups": [
    [10, 20]
  ]
}
Test Case 17 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "high": 20,
  "low": 10,
  "measuringCups": [
    [15, 18]
  ]
}
Test Case 18 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "high": 20,
  "low": 10,
  "measuringCups": [
    [15, 22]
  ]
}

 
 */