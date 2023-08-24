using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MergeOverlapInterval
    { 

        public static int[][]  MergeOverlapIntervals(int[,] intervals)
        {
            int[][] sortedIntervals = intervals.Clone() as int[][];
            Array.Sort(sortedIntervals, (a, b) => a[0].CompareTo(b[0]) );

            List<int[]> result = new List<int[]>();
            int[] currentInterval = sortedIntervals[0];
            result.Add(currentInterval);

            foreach (int[] nextInterval in sortedIntervals)
            {
                int currentIntervalEnd = currentInterval[1];
                int nextIntervalStart = nextInterval[0];
                int nextIntervalEnd = nextInterval[1];

                if (currentIntervalEnd >= nextIntervalStart)
                {
                    currentInterval[1] = Math.Max(currentIntervalEnd, nextIntervalEnd);
                }
                else
                {
                    currentInterval = nextInterval;
                    result.Add(currentInterval);
                }

            }
            return result.ToArray();
        }
    }

}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] intervals = new int[][] {
      new int[] { 1, 2 },
      new int[] { 3, 5 },
      new int[] { 4, 7 },
      new int[] { 6, 8 },
      new int[] { 9, 10 },
    };
    int[][] expected = new int[][] {
      new int[] { 1, 2 },
      new int[] { 3, 8 },
      new int[] { 9, 10 },
    };
    int[][] actual = new Program().MergeOverlappingIntervals(intervals);
    for (int i = 0; i < actual.Length; i++) {
      for (int j = 0; j < actual[i].Length; j++) {
        Utils.AssertTrue(expected[i][j] == actual[i][j]);
      }
    }
  }
}

13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
[
  [1, 2],
  [3, 8],
  [9, 10]
]
Your Code's Output
[
  [1, 2],
  [3, 8],
  [9, 10]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [1, 2],
    [3, 5],
    [4, 7],
    [6, 8],
    [9, 10]
  ]
}
Test Case 2 passed!
Expected Output
[
  [1, 8],
  [9, 10]
]
Your Code's Output
[
  [1, 8],
  [9, 10]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [1, 3],
    [2, 8],
    [9, 10]
  ]
}
Test Case 3 passed!
Expected Output
[
  [1, 100]
]
Your Code's Output
[
  [1, 100]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [1, 10],
    [10, 20],
    [20, 30],
    [30, 40],
    [40, 50],
    [50, 60],
    [60, 70],
    [70, 80],
    [80, 90],
    [90, 100]
  ]
}
Test Case 4 passed!
Expected Output
[
  [1, 10],
  [11, 20],
  [21, 30],
  [31, 40],
  [41, 50],
  [51, 60],
  [61, 70],
  [71, 80],
  [81, 90],
  [91, 100]
]
Your Code's Output
[
  [1, 10],
  [11, 20],
  [21, 30],
  [31, 40],
  [41, 50],
  [51, 60],
  [61, 70],
  [71, 80],
  [81, 90],
  [91, 100]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [1, 10],
    [11, 20],
    [21, 30],
    [31, 40],
    [41, 50],
    [51, 60],
    [61, 70],
    [71, 80],
    [81, 90],
    [91, 100]
  ]
}
Test Case 5 passed!
Expected Output
[
  [1, 105]
]
Your Code's Output
[
  [1, 105]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [100, 105],
    [1, 104]
  ]
}
Test Case 6 passed!
Expected Output
[
  [-50, 20],
  [70, 95]
]
Your Code's Output
[
  [-50, 20],
  [70, 95]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [89, 90],
    [-10, 20],
    [-50, 0],
    [70, 90],
    [90, 91],
    [90, 95]
  ]
}
Test Case 7 passed!
Expected Output
[
  [-5, 0]
]
Your Code's Output
[
  [-5, 0]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [-5, -4],
    [-4, -3],
    [-3, -2],
    [-2, -1],
    [-1, 0]
  ]
}
Test Case 8 passed!
Expected Output
[
  [9, 90],
  [91, 93]
]
Your Code's Output
[
  [9, 90],
  [91, 93]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [43, 49],
    [9, 12],
    [12, 54],
    [45, 90],
    [91, 93]
  ]
}
Test Case 9 passed!
Expected Output
[
  [0, 0]
]
Your Code's Output
[
  [0, 0]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0]
  ]
}
Test Case 10 passed!
Expected Output
[
  [0, 1]
]
Your Code's Output
[
  [0, 1]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 1]
  ]
}
Test Case 11 passed!
Expected Output
[
  [-20, 30]
]
Your Code's Output
[
  [-20, 30]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [1, 22],
    [-20, 30]
  ]
}
Test Case 12 passed!
Expected Output
[
  [0, 1],
  [3, 4],
  [5, 6],
  [7, 19],
  [20, 21],
  [22, 24],
  [25, 27]
]
Your Code's Output
[
  [0, 1],
  [3, 4],
  [5, 6],
  [7, 19],
  [20, 21],
  [22, 24],
  [25, 27]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [20, 21],
    [22, 23],
    [0, 1],
    [3, 4],
    [23, 24],
    [25, 27],
    [5, 6],
    [7, 19]
  ]
}
Test Case 13 passed!
Expected Output
[
  [1, 10]
]
Your Code's Output
[
  [1, 10]
]
View Outputs Side By Side
Input(s)
{
  "intervals": [
    [2, 3],
    [4, 5],
    [6, 7],
    [8, 9],
    [1, 10]
  ]
}
 
 */