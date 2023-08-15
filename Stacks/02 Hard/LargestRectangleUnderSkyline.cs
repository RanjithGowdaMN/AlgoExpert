using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._02_Hard
{
    public class LargestRectangleUnderSkylineProgram
    {
        public int LargestRectangleUnderSkyline(List<int> buildings)
        {
            // Write your code here.
            Stack<int> pillarIndices = new Stack<int>();
            int maxArea = 0;
            List<int> extendedBuildings = new List<int>(buildings);
            extendedBuildings.Add(0);
            for (int idx = 0; idx < extendedBuildings.Count; idx++)
            {
                int height = extendedBuildings[idx];
                while (pillarIndices.Count != 0 && extendedBuildings[pillarIndices.Peek()] >= height)
                {
                    int pillerHeight = extendedBuildings[pillarIndices.Pop()];
                    int width = (pillarIndices.Count == 0) ? idx : idx - pillarIndices.Peek() - 1;
                    maxArea = Math.Max(width * pillerHeight, maxArea);
                }
                pillarIndices.Push(idx);
            }
            return maxArea;
        }
    }
}

/*
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> input = new List<int> { 1, 3, 3, 2, 4, 1, 5, 3, 2 };
    int expected = 9;
    var actual = new Program().LargestRectangleUnderSkyline(input);
    Utils.AssertTrue(expected == actual);
  }
}

 
 16 / 16 test cases passed.

Test Case 1 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "buildings": [1, 3, 3, 2, 4, 1, 5, 3, 2]
}
Test Case 2 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "buildings": [4, 4, 4, 2, 2, 1]
}
Test Case 3 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "buildings": [1, 3, 3, 2, 4, 1, 5, 3]
}
Test Case 4 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "buildings": [5, 5, 2, 2, 4, 1]
}
Test Case 5 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "buildings": [1, 2, 3, 4, 5, 11]
}
Test Case 6 passed!
Expected Output
25
Your Code's Output
25
View Outputs Side By Side
Input(s)
{
  "buildings": [25, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
}
Test Case 7 passed!
Expected Output
24
Your Code's Output
24
View Outputs Side By Side
Input(s)
{
  "buildings": [20, 2, 2, 2, 2, 2, 10, 5, 5, 5, 4, 4]
}
Test Case 8 passed!
Expected Output
30
Your Code's Output
30
View Outputs Side By Side
Input(s)
{
  "buildings": [5, 10, 5, 15, 10, 25]
}
Test Case 9 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "buildings": [1, 1, 1, 1]
}
Test Case 10 passed!
Expected Output
21
Your Code's Output
21
View Outputs Side By Side
Input(s)
{
  "buildings": [10, 21]
}
Test Case 11 passed!
Expected Output
22
Your Code's Output
22
View Outputs Side By Side
Input(s)
{
  "buildings": [11, 21]
}
Test Case 12 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "buildings": [3, 3, 3, 4, 4, 4, 1, 3, 1, 2, 8, 9, 1]
}
Test Case 13 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "buildings": [5]
}
Test Case 14 passed!
Expected Output
16
Your Code's Output
16
View Outputs Side By Side
Input(s)
{
  "buildings": [10, 1, 2, 3, 4, 5, 6, 7]
}
Test Case 15 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "buildings": [10, 1, 2, 3, 3, 5, 6, 7]
}
Test Case 16 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "buildings": []
}
 */