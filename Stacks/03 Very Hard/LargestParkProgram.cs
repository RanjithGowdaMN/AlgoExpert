using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._03_Very_Hard
{
    class LargestParkProgram
    {
        public int LargestPark(bool[][] land)
        {
            // Write your code here.
            int[] heights = new int[land[0].Length];
            int maxArea = 0;

            foreach (var row in land)
            {
                for (int columnIndex = 0; columnIndex < land[0].Length; columnIndex++)
                {
                    heights[columnIndex] =
                        row[columnIndex] == false ? heights[columnIndex] + 1 : 0;
                }
                maxArea = Math.Max(maxArea, largestRectangleHistogram(heights));
            }

            return maxArea;
        }
        static int largestRectangleHistogram(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;

            for (int columnIndex = 0; columnIndex < heights.Length; columnIndex++)
            {
                while (stack.Count > 0 && heights[columnIndex] < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width =
                        (stack.Count == 0) ? columnIndex : columnIndex - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, width * height);
                }
                stack.Push(columnIndex);
            }
            while (stack.Count > 0)
            {
                int height = heights[stack.Pop()];
                int width =
                    (stack.Count == 0) ? heights.Length : heights.Length - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, width * height);
            }
            return maxArea;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    bool[][] land = new bool[][] {
      new bool[] { false, true, true, true, false },
      new bool[] { false, false, false, true, false },
      new bool[] { false, false, false, false, false },
      new bool[] { false, true, true, true, true },
    };
    int expected = 6;
    int actual = new Program().LargestPark(land);
    Utils.AssertTrue(expected == actual);
  }
}

40 / 40 test cases passed.

Test Case 1 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "land": [
    [true]
  ]
}
Test Case 2 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "land": [
    [false]
  ]
}
Test Case 3 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, true]
  ]
}
Test Case 4 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, true, false]
  ]
}
Test Case 5 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false]
  ]
}
Test Case 6 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, true, true]
  ]
}
Test Case 7 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false],
    [false, false, false]
  ]
}
Test Case 8 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, true, false],
    [false, false, false]
  ]
}
Test Case 9 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false],
    [false, true, false]
  ]
}
Test Case 10 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, true, false],
    [false, true, false]
  ]
}
Test Case 11 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, true, false],
    [false, true, false],
    [false, true, false]
  ]
}
Test Case 12 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, true, false],
    [false, false, false],
    [false, true, false]
  ]
}
Test Case 13 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false],
    [false, false, false],
    [false, true, false]
  ]
}
Test Case 14 passed!
Expected Output
9
Our Code's Output
9
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false],
    [false, false, false],
    [false, false, false]
  ]
}
Test Case 15 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false],
    [false, false, false],
    [false, false, true]
  ]
}
Test Case 16 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false],
    [false, false, false],
    [true, false, false]
  ]
}
Test Case 17 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, false],
    [false, false, false],
    [false, false, false]
  ]
}
Test Case 18 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, true],
    [false, false, false],
    [false, false, false]
  ]
}
Test Case 19 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, true, false, true, false],
    [false, true, false, false, false],
    [true, false, false, false, false],
    [false, true, true, false, true]
  ]
}
Test Case 20 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, true, true],
    [true, true, true],
    [true, true, true]
  ]
}
Test Case 21 passed!
Expected Output
4
Our Code's Output
4
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false],
    [false, false]
  ]
}
Test Case 22 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, true, false],
    [false, true, false, true],
    [true, false, true, false],
    [false, true, false, true]
  ]
}
Test Case 23 passed!
Expected Output
10
Our Code's Output
10
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false, false, false],
    [false, false, false, false, false],
    [false, false, true, false, false],
    [false, false, false, false, false],
    [false, false, false, false, false]
  ]
}
Test Case 24 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, false, true, true, false],
    [false, true, true, false, true, false],
    [true, true, false, false, true, false]
  ]
}
Test Case 25 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, true, true, true],
    [true, true, true, true],
    [true, true, true, true],
    [true, true, true, true]
  ]
}
Test Case 26 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, false, true, true, false],
    [false, true, true, false, true, false],
    [true, true, false, true, true, false]
  ]
}
Test Case 27 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "land": [
    [true],
    [false],
    [true],
    [false],
    [true],
    [false],
    [true]
  ]
}
Test Case 28 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "land": [
    [true],
    [true],
    [true],
    [true],
    [true],
    [true],
    [true]
  ]
}
Test Case 29 passed!
Expected Output
7
Our Code's Output
7
View Outputs Side By Side
Input(s)
{
  "land": [
    [false],
    [false],
    [false],
    [false],
    [false],
    [false],
    [false]
  ]
}
Test Case 30 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, true, false, false, true, false],
    [true, false, true, false, false, true],
    [false, true, false, true, false, false],
    [false, false, true, false, true, false],
    [true, false, false, true, false, true],
    [false, true, false, false, true, false]
  ]
}
Test Case 31 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, true, false, false],
    [false, true, false, true, true],
    [false, true, true, false, false],
    [false, true, false, false, true],
    [true, false, true, false, false]
  ]
}
Test Case 32 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, true, true, false, false, true],
    [false, true, false, false, true, true, false],
    [true, false, true, true, false, false, true]
  ]
}
Test Case 33 passed!
Expected Output
4
Our Code's Output
4
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, true, false, false, true, true],
    [true, true, false, true, true, false, false],
    [false, true, false, true, false, false, false],
    [false, true, false, false, true, true, true]
  ]
}
Test Case 34 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, true, false, false, true, false, true, false, true],
    [false, true, false, true, true, false, true, false, true, false],
    [true, false, true, false, false, true, false, true, false, true],
    [false, true, false, true, true, false, true, false, true, false],
    [true, false, true, false, false, true, false, true, false, true],
    [false, true, false, true, true, false, true, false, true, false],
    [true, false, true, false, false, true, false, true, false, true],
    [false, true, false, true, true, false, true, false, true, false],
    [true, false, true, false, false, true, false, true, false, true],
    [false, true, false, true, true, false, true, false, true, false]
  ]
}
Test Case 35 passed!
Expected Output
14
Our Code's Output
14
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false, false, false, false],
    [false, false, false, false, false, false],
    [false, false, true, true, true, false],
    [false, false, true, true, true, false],
    [false, false, true, true, true, false],
    [false, false, false, false, false, false],
    [false, false, false, false, false, false]
  ]
}
Test Case 36 passed!
Expected Output
24
Our Code's Output
24
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, true, true, false, false, false],
    [true, true, true, false, false, false],
    [true, true, true, false, false, false],
    [false, false, false, false, false, false],
    [false, false, false, false, false, false],
    [false, false, false, false, false, false],
    [false, false, false, false, false, false]
  ]
}
Test Case 37 passed!
Expected Output
12
Our Code's Output
12
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, true, true, true, true, true],
    [true, true, true, true, true, true],
    [true, false, false, false, false, true],
    [true, false, false, false, false, true],
    [true, false, false, false, false, true],
    [true, true, true, true, true, true],
    [true, true, true, true, true, true]
  ]
}
Test Case 38 passed!
Expected Output
12
Our Code's Output
12
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false, true, true, true],
    [false, false, false, true, true, true],
    [false, false, false, true, true, true],
    [false, false, false, true, true, true],
    [true, true, true, true, true, true],
    [true, true, true, true, true, true],
    [true, true, true, true, true, true]
  ]
}
Test Case 39 passed!
Expected Output
12
Our Code's Output
12
View Outputs Side By Side
Input(s)
{
  "land": [
    [false, false, false, true, true, true],
    [false, true, true, true, true, true],
    [true, false, false, false, false, true],
    [true, false, false, false, false, true],
    [true, false, false, false, false, true],
    [true, true, true, true, true, false],
    [false, false, true, true, false, false]
  ]
}
Test Case 40 passed!
Expected Output
15
Our Code's Output
15
View Outputs Side By Side
Input(s)
{
  "land": [
    [true, false, true, false, true, false, true, false, false, true, false, false, true, false, false],
    [false, false, true, true, false, true, false, false, true, false, true, false, false, false, false],
    [true, true, false, false, false, false, false, true, false, false, true, true, false, false, false],
    [true, true, false, false, false, false, false, true, false, false, true, true, false, false, true],
    [false, false, false, false, false, false, false, false, true, true, false, false, true, false, true],
    [true, false, true, true, false, true, false, true, true, false, false, true, false, false, true],
    [false, true, false, false, true, false, true, true, false, true, false, true, false, false, true],
    [false, true, false, true, false, true, false, false, true, false, true, true, false, true, false],
    [false, true, true, false, false, true, false, false, true, true, false, false, true, false, true],
    [true, false, true, true, false, true, false, true, true, false, false, true, false, false, true],
    [false, true, false, false, true, false, true, true, false, false, false, true, false, false, true],
    [false, true, false, true, false, true, false, false, true, false, true, true, false, true, false],
    [false, true, true, false, false, true, false, false, true, true, false, false, true, false, true],
    [true, false, true, true, false, true, false, true, true, false, false, true, false, false, false],
    [false, false, false, false, false, false, false, true, false, false, false, false, false, false, false]
  ]
}
 
 */