﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._03VeryHard
{
    class AStarAlgorithmProgram
    {
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int startRow = 0;
    int startCol = 1;
    int endRow = 4;
    int endCol = 3;
    int[][] graph = new int[][] {
      new int[] { 0, 0, 0, 0, 0 },
      new int[] { 0, 1, 1, 1, 0 },
      new int[] { 0, 0, 0, 0, 0 },
      new int[] { 1, 0, 1, 1, 1 },
      new int[] { 0, 0, 0, 0, 0 },
    };
    int[][] expected = new int[][] {
      new int[] { 0, 1 },
      new int[] { 0, 0 },
      new int[] { 1, 0 },
      new int[] { 2, 0 },
      new int[] { 2, 1 },
      new int[] { 3, 1 },
      new int[] { 4, 1 },
      new int[] { 4, 2 },
      new int[] { 4, 3 }
    };
    var actual =
      new Program().AStarAlgorithm(startRow, startCol, endRow, endCol, graph);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < expected.Length; i++) {
      for (int j = 0; j < expected[i].Length; j++) {
        Utils.AssertTrue(expected[i][j] == actual[i][j]);
      }
    }
  }
}

8 / 8 test cases passed.

Test Case 1 passed!
Expected Output
[
  [0, 1],
  [0, 0],
  [1, 0],
  [2, 0],
  [2, 1],
  [3, 1],
  [4, 1],
  [4, 2],
  [4, 3]
]
Our Code's Output
[
  [0, 1],
  [0, 0],
  [1, 0],
  [2, 0],
  [2, 1],
  [3, 1],
  [4, 1],
  [4, 2],
  [4, 3]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 3,
  "endRow": 4,
  "graph": [
    [0, 0, 0, 0, 0],
    [0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0],
    [1, 0, 1, 1, 1],
    [0, 0, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 0
}
Test Case 2 passed!
Expected Output
[
  [1, 1],
  [1, 2],
  [1, 3],
  [1, 4],
  [1, 5],
  [1, 6],
  [1, 7],
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8]
]
Our Code's Output
[
  [1, 1],
  [1, 2],
  [1, 3],
  [1, 4],
  [1, 5],
  [1, 6],
  [1, 7],
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 8,
  "endRow": 8,
  "graph": [
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 0, 0, 0, 0, 0, 0, 0, 0, 1],
    [1, 1, 0, 1, 1, 1, 1, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 1, 1, 1, 1, 0, 0, 0, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 3 passed!
Expected Output
[
  [1, 1],
  [1, 2],
  [2, 2],
  [3, 2],
  [3, 3],
  [3, 4],
  [4, 4],
  [5, 4],
  [6, 4],
  [7, 4]
]
Our Code's Output
[
  [1, 1],
  [1, 2],
  [2, 2],
  [3, 2],
  [3, 3],
  [3, 4],
  [4, 4],
  [5, 4],
  [6, 4],
  [7, 4]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 4,
  "endRow": 7,
  "graph": [
    [1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [1, 1, 0, 1, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 0, 1, 1, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 1, 1, 1, 0],
    [0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 1, 1, 0, 1, 1, 1],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 4 passed!
Expected Output
[
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8],
  [9, 8],
  [9, 7],
  [9, 6],
  [9, 5],
  [9, 4],
  [9, 3],
  [9, 2],
  [9, 1],
  [8, 1]
]
Our Code's Output
[
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8],
  [9, 8],
  [9, 7],
  [9, 6],
  [9, 5],
  [9, 4],
  [9, 3],
  [9, 2],
  [9, 1],
  [8, 1]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 1,
  "endRow": 8,
  "graph": [
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 1, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 8,
  "startRow": 1
}
Test Case 5 passed!
Expected Output
[
  [0, 0],
  [0, 1],
  [0, 2],
  [0, 3],
  [0, 4],
  [0, 5],
  [0, 6],
  [0, 7],
  [0, 8],
  [0, 9],
  [0, 10],
  [0, 11],
  [0, 12],
  [1, 12],
  [2, 12],
  [2, 13],
  [3, 13],
  [4, 13],
  [4, 14],
  [4, 15],
  [4, 16],
  [5, 16],
  [6, 16],
  [6, 17],
  [6, 18],
  [6, 19],
  [5, 19],
  [4, 19],
  [3, 19],
  [2, 19],
  [1, 19],
  [0, 19]
]
Our Code's Output
[
  [0, 0],
  [0, 1],
  [0, 2],
  [0, 3],
  [0, 4],
  [0, 5],
  [0, 6],
  [0, 7],
  [0, 8],
  [0, 9],
  [0, 10],
  [0, 11],
  [0, 12],
  [1, 12],
  [2, 12],
  [2, 13],
  [3, 13],
  [4, 13],
  [4, 14],
  [4, 15],
  [4, 16],
  [5, 16],
  [6, 16],
  [6, 17],
  [6, 18],
  [6, 19],
  [5, 19],
  [4, 19],
  [3, 19],
  [2, 19],
  [1, 19],
  [0, 19]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 19,
  "endRow": 0,
  "graph": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 0,
  "startRow": 0
}
Test Case 6 passed!
Expected Output
[]
Our Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "endCol": 17,
  "endRow": 18,
  "graph": [
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0],
    [0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1],
    [0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 7 passed!
Expected Output
[
  [1, 1],
  [1, 2]
]
Our Code's Output
[
  [1, 1],
  [1, 2]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 2,
  "endRow": 1,
  "graph": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 1, 1, 0, 1, 1, 1, 0, 0, 0],
    [0, 1, 0, 1, 1, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 0, 1, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 8 passed!
Expected Output
[
  [1, 11],
  [1, 10],
  [1, 9],
  [1, 8],
  [1, 7],
  [1, 6],
  [1, 5],
  [1, 4],
  [1, 3],
  [1, 2],
  [1, 1],
  [1, 0],
  [2, 0],
  [3, 0],
  [4, 0],
  [5, 0],
  [6, 0],
  [7, 0],
  [8, 0],
  [9, 0],
  [10, 0],
  [11, 0],
  [12, 0],
  [13, 0],
  [14, 0],
  [15, 0],
  [16, 0],
  [17, 0],
  [18, 0],
  [19, 0],
  [20, 0],
  [21, 0],
  [22, 0],
  [23, 0],
  [24, 0],
  [24, 1],
  [24, 2],
  [23, 2],
  [22, 2],
  [21, 2],
  [21, 3],
  [21, 4],
  [22, 4]
]
Our Code's Output
[
  [1, 11],
  [1, 10],
  [1, 9],
  [1, 8],
  [1, 7],
  [1, 6],
  [1, 5],
  [1, 4],
  [1, 3],
  [1, 2],
  [1, 1],
  [1, 0],
  [2, 0],
  [3, 0],
  [4, 0],
  [5, 0],
  [6, 0],
  [7, 0],
  [8, 0],
  [9, 0],
  [10, 0],
  [11, 0],
  [12, 0],
  [13, 0],
  [14, 0],
  [15, 0],
  [16, 0],
  [17, 0],
  [18, 0],
  [19, 0],
  [20, 0],
  [21, 0],
  [22, 0],
  [23, 0],
  [24, 0],
  [24, 1],
  [24, 2],
  [23, 2],
  [22, 2],
  [21, 2],
  [21, 3],
  [21, 4],
  [22, 4]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 4,
  "endRow": 22,
  "graph": [
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 11,
  "startRow": 1
}
 
 */