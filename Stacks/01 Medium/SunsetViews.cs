using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    public class SunsetViewsProgram
    {
        public List<int> SunsetViews(int[] buildings, string direction)
        {
            // Write your code here.
            List<int> candidateBuildings = new List<int>();

            int startIdx = buildings.Length - 1;
            int step = -1;

            if (direction.Equals("EAST"))
            {
                startIdx = 0;
                step = 1;
            }

            int idx = startIdx;
            while (idx >= 0 && idx < buildings.Length)
            {
                int buildingHeight = buildings[idx];
                while (candidateBuildings.Count > 0 &&
                     buildings[candidateBuildings[candidateBuildings.Count - 1]] <= buildingHeight)
                {
                    candidateBuildings.RemoveAt(candidateBuildings.Count - 1);
                }
                candidateBuildings.Add(idx);
                idx += step;
            }

            if (direction.Equals("WEST"))
            {
                candidateBuildings.Reverse();
            }
            return candidateBuildings;
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
    int[] buildings = new int[] { 3, 5, 4, 4, 3, 1, 3, 2 };
    string direction = "EAST";
    List<int> expected = new List<int>();
    expected.Add(1);
    expected.Add(3);
    expected.Add(6);
    expected.Add(7);
    var actual = new Program().SunsetViews(buildings, direction);
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }
}


13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
[1, 3, 6, 7]
Your Code's Output
[1, 3, 6, 7]
View Outputs Side By Side
Input(s)
{
  "buildings": [3, 5, 4, 4, 3, 1, 3, 2],
  "direction": "EAST"
}
Test Case 2 passed!
Expected Output
[0, 1]
Your Code's Output
[0, 1]
View Outputs Side By Side
Input(s)
{
  "buildings": [3, 5, 4, 4, 3, 1, 3, 2],
  "direction": "WEST"
}
Test Case 3 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "buildings": [10, 11],
  "direction": "EAST"
}
Test Case 4 passed!
Expected Output
[0, 1]
Your Code's Output
[0, 1]
View Outputs Side By Side
Input(s)
{
  "buildings": [2, 4],
  "direction": "WEST"
}
Test Case 5 passed!
Expected Output
[0]
Your Code's Output
[0]
View Outputs Side By Side
Input(s)
{
  "buildings": [1],
  "direction": "EAST"
}
Test Case 6 passed!
Expected Output
[0]
Your Code's Output
[0]
View Outputs Side By Side
Input(s)
{
  "buildings": [1],
  "direction": "WEST"
}
Test Case 7 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "buildings": [],
  "direction": "EAST"
}
Test Case 8 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "buildings": [],
  "direction": "WEST"
}
Test Case 9 passed!
Expected Output
[4, 5, 6, 7, 11]
Your Code's Output
[4, 5, 6, 7, 11]
View Outputs Side By Side
Input(s)
{
  "buildings": [7, 1, 7, 8, 9, 8, 7, 6, 5, 4, 2, 5],
  "direction": "EAST"
}
Test Case 10 passed!
Expected Output
[5]
Your Code's Output
[5]
View Outputs Side By Side
Input(s)
{
  "buildings": [1, 2, 3, 4, 5, 6],
  "direction": "EAST"
}
Test Case 11 passed!
Expected Output
[0, 1, 2, 3, 4, 5]
Your Code's Output
[0, 1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "buildings": [1, 2, 3, 4, 5, 6],
  "direction": "WEST"
}
Test Case 12 passed!
Expected Output
[0, 1, 2, 4, 5, 6, 10, 13]
Your Code's Output
[0, 1, 2, 4, 5, 6, 10, 13]
View Outputs Side By Side
Input(s)
{
  "buildings": [1, 2, 3, 1, 5, 6, 9, 1, 9, 9, 11, 10, 9, 12, 8],
  "direction": "WEST"
}
Test Case 13 passed!
Expected Output
[0, 13, 14]
Your Code's Output
[0, 13, 14]
View Outputs Side By Side
Input(s)
{
  "buildings": [20, 2, 3, 1, 5, 6, 9, 1, 9, 9, 11, 10, 9, 12, 8],
  "direction": "EAST"
}
 
 
 */