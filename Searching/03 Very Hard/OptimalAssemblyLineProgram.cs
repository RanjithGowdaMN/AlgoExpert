using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching._03_Very_Hard
{
    class OptimalAssemblyLineProgram
    {

        public int OptimalAssemblyLine(int[] stepDurations, int numStations)
        {
            // Write your code here.
            int left = Int32.MinValue;
            int right = 0;
            int maxStationDuration = Int32.MaxValue;

            foreach (var stepDuration in stepDurations)
            {
                left = Math.Max(left, stepDuration);
                right += stepDuration;
            }

            while (left <= right)
            {
                int potentialMaxStationDuration = (left + right) / 2;

                if (isPotentialSolution(stepDurations, numStations, potentialMaxStationDuration))
                {
                    maxStationDuration = potentialMaxStationDuration;
                    right = potentialMaxStationDuration - 1;
                }
                else
                {
                    left = potentialMaxStationDuration + 1;
                }
            }
            return maxStationDuration;
        }
        static bool isPotentialSolution(
            int[] stepDurations, int numStations, int potentialMaxStationDuration
        )
        {
            int stationsRequired = 1;
            int currentDuration = 0;

            foreach (var stepDuration in stepDurations)
            {
                if (currentDuration + stepDuration > potentialMaxStationDuration)
                {
                    stationsRequired++;
                    currentDuration = stepDuration;
                }
                else
                {
                    currentDuration += stepDuration;
                }
            }

            return stationsRequired <= numStations;
        }
    }
}

/*

using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] stepDurations = new int[] { 15, 15, 30, 30, 45 };
    int numStations = 3;
    int actual = new Program().OptimalAssemblyLine(stepDurations, numStations);
    int expected = 60;
    Utils.AssertTrue(expected == actual);
  }
}



 30 / 30 test cases passed.

Test Case 1 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "numStations": 1,
  "stepDurations": [5]
}
Test Case 2 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [5, 7]
}
Test Case 3 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [1, 2, 3, 4, 5]
}
Test Case 4 passed!
Expected Output
35
Your Code's Output
35
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [5, 10, 20, 30]
}
Test Case 5 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "numStations": 4,
  "stepDurations": [1, 2, 3, 4, 5, 6]
}
Test Case 6 passed!
Expected Output
100
Your Code's Output
100
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [15, 25, 35, 45, 55, 65]
}
Test Case 7 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [5, 2, 9, 3]
}
Test Case 8 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [6, 8, 4, 2, 10]
}
Test Case 9 passed!
Expected Output
35
Your Code's Output
35
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [30, 5, 20, 10]
}
Test Case 10 passed!
Expected Output
60
Your Code's Output
60
View Outputs Side By Side
Input(s)
{
  "numStations": 4,
  "stepDurations": [40, 30, 10, 20, 60, 50]
}
Test Case 11 passed!
Expected Output
100
Your Code's Output
100
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [35, 65, 45, 15, 25, 55]
}
Test Case 12 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [1, 2, 2, 3]
}
Test Case 13 passed!
Expected Output
60
Your Code's Output
60
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [15, 15, 30, 30, 45]
}
Test Case 14 passed!
Expected Output
40
Your Code's Output
40
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [5, 5, 10, 20, 20]
}
Test Case 15 passed!
Expected Output
40
Your Code's Output
40
View Outputs Side By Side
Input(s)
{
  "numStations": 4,
  "stepDurations": [20, 10, 20, 30, 10, 30]
}
Test Case 16 passed!
Expected Output
70
Your Code's Output
70
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [25, 25, 35, 35]
}
Test Case 17 passed!
Expected Output
30
Your Code's Output
30
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [10, 20, 30]
}
Test Case 18 passed!
Expected Output
45
Your Code's Output
45
View Outputs Side By Side
Input(s)
{
  "numStations": 4,
  "stepDurations": [15, 25, 35, 45]
}
Test Case 19 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [5, 10, 20]
}
Test Case 20 passed!
Expected Output
53
Your Code's Output
53
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [12, 23, 38, 11, 47, 6]
}
Test Case 21 passed!
Expected Output
57
Your Code's Output
57
View Outputs Side By Side
Input(s)
{
  "numStations": 4,
  "stepDurations": [32, 41, 15, 27, 22, 9, 48]
}
Test Case 22 passed!
Expected Output
49
Your Code's Output
49
View Outputs Side By Side
Input(s)
{
  "numStations": 5,
  "stepDurations": [45, 8, 37, 49, 2, 23, 19, 26]
}
Test Case 23 passed!
Expected Output
194
Your Code's Output
194
View Outputs Side By Side
Input(s)
{
  "numStations": 1,
  "stepDurations": [32, 41, 15, 27, 22, 9, 48]
}
Test Case 24 passed!
Expected Output
209
Your Code's Output
209
View Outputs Side By Side
Input(s)
{
  "numStations": 1,
  "stepDurations": [45, 8, 37, 49, 2, 23, 19, 26]
}
Test Case 25 passed!
Expected Output
63
Your Code's Output
63
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [21, 14, 7, 42, 35, 28]
}
Test Case 26 passed!
Expected Output
65
Your Code's Output
65
View Outputs Side By Side
Input(s)
{
  "numStations": 4,
  "stepDurations": [37, 15, 8, 29, 43, 22, 50, 1]
}
Test Case 27 passed!
Expected Output
51
Your Code's Output
51
View Outputs Side By Side
Input(s)
{
  "numStations": 5,
  "stepDurations": [18, 33, 46, 27, 9, 12, 39, 24, 3]
}
Test Case 28 passed!
Expected Output
84
Your Code's Output
84
View Outputs Side By Side
Input(s)
{
  "numStations": 2,
  "stepDurations": [21, 14, 7, 42, 35, 28]
}
Test Case 29 passed!
Expected Output
73
Your Code's Output
73
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [37, 15, 8, 29, 43, 22, 50, 1]
}
Test Case 30 passed!
Expected Output
82
Your Code's Output
82
View Outputs Side By Side
Input(s)
{
  "numStations": 3,
  "stepDurations": [18, 33, 46, 27, 9, 12, 39, 24, 3]
}
 */