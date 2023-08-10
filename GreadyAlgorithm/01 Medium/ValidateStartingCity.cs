using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreadyAlgorithm._01_Medium
{
    public class ValidateStartingCityProgram
    {
        public int ValidStartingCity(int[] distances, int[] fuel, int mpg)
        {
            // Write your code here.
            int numberOfCities = distances.Length;
            int milesRemaining = 0;

            int indexOfStartingCityCandidate = 0;
            int milesRemainingAtStartingCityCandidate = 0;

            for (int cityIdx = 1; cityIdx < numberOfCities; cityIdx++)
            {
                int distanceFromPreviousCity = distances[cityIdx - 1];
                int fuelFromPreviousCity = fuel[cityIdx - 1];
                milesRemaining += fuelFromPreviousCity * mpg - distanceFromPreviousCity;

                if (milesRemaining < milesRemainingAtStartingCityCandidate)
                {
                    milesRemainingAtStartingCityCandidate = milesRemaining;
                    indexOfStartingCityCandidate = cityIdx;
                }
            }
            return indexOfStartingCityCandidate;
        }
    }
}

/*
 
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] distances = new int[] { 5, 25, 15, 10, 15 };
    int[] fuel = new int[] { 1, 2, 1, 0, 3 };
    int mpg = 10;
    int expected = 4;
    var actual = new Program().ValidStartingCity(distances, fuel, mpg);
    Utils.AssertTrue(expected == actual);
  }
}

10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "distances": [5, 25, 15, 10, 15],
  "fuel": [1, 2, 1, 0, 3],
  "mpg": 10
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "distances": [10, 20, 10, 15, 5, 15, 25],
  "fuel": [0, 2, 1, 0, 0, 1, 1],
  "mpg": 20
}
Test Case 3 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "distances": [30, 25, 5, 100, 40],
  "fuel": [3, 2, 1, 0, 4],
  "mpg": 20
}
Test Case 4 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "distances": [1, 3, 10, 6, 7, 7, 2, 4],
  "fuel": [1, 1, 1, 1, 1, 1, 1, 1],
  "mpg": 5
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "distances": [5, 2, 3],
  "fuel": [1, 0, 1],
  "mpg": 5
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "distances": [4, 6],
  "fuel": [1, 9],
  "mpg": 1
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "distances": [30, 40, 10, 10, 17, 13, 50, 30, 10, 40],
  "fuel": [1, 2, 0, 1, 1, 0, 3, 1, 0, 1],
  "mpg": 25
}
Test Case 8 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "distances": [30, 40, 10, 10, 17, 13, 50, 30, 10, 40],
  "fuel": [10, 0, 0, 0, 0, 0, 0, 0, 0, 0],
  "mpg": 25
}
Test Case 9 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "distances": [15, 20, 25, 30, 35, 5],
  "fuel": [0, 3, 0, 0, 1, 1],
  "mpg": 26
}
Test Case 10 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "distances": [10, 10, 10, 10],
  "fuel": [1, 2, 3, 4],
  "mpg": 4
}
 */