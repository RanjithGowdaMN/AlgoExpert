using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03Hard
{
    public class Count_Squares
    {
        public int CountSquares(int[][] points)
        {
            // Write your code here.
            HashSet<string> pointSet = new HashSet<string>();
            foreach (var point in points)
            {
                pointSet.Add(pointToString(point));
            }
            int count = 0;
            foreach (var pointA in points)
            {
                foreach (var pointB in points)
                {
                    if (pointA == pointB)
                    {
                        continue;
                    }

                    double[] midPoint = new double[]{
                    (pointA[0] + pointB[0])/2.0,
                    (pointA[1] + pointB[1])/2.0
                };
                    double xDistanceFromMid = pointA[0] - midPoint[0];
                    double yDistanceFromMid = pointA[1] - midPoint[1];

                    double[] PointC = new double[]{
                    midPoint[0] + yDistanceFromMid,
                    midPoint[1] - xDistanceFromMid
                };
                    double[] PointD = new double[]{
                    midPoint[0] - yDistanceFromMid,
                    midPoint[1] + xDistanceFromMid
                };

                    if (pointSet.Contains(dbpointToString(PointC)) &&
                      pointSet.Contains(dbpointToString(PointD)))
                    {
                        count++;
                    }
                }
            }
            return count / 4;
        }

        private string pointToString(int[] points)
        {
            return points[0] + "," + points[1];
        }

        private string dbpointToString(double[] points)
        {
            if (points[0] % 1 == 0 && points[1] % 1 == 0)
            {
                return (int)points[0] + "," + (int)points[1];
            }
            return points[0] + "," + points[1];
        }

    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[][] {
      new int[] { 1, 1 },
      new int[] { 0, 0 },
      new int[] { 0, 1 },
      new int[] { 1, 0 }
    };
    var expected = 1;
    var actual = new Program().CountSquares(input);
    Utils.AssertTrue(expected == actual);
  }
}

18 / 18 test cases passed.

Test Case 1 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "points": []
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, 0]
  ]
}
Test Case 3 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "points": [
    [0, 1],
    [1, 0]
  ]
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "points": [
    [0, 0],
    [0, 1],
    [1, 0]
  ]
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [1, 0]
  ]
}
Test Case 6 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, 1],
    [0, 0],
    [-4, 2],
    [-2, -1],
    [0, 1],
    [1, 0],
    [-1, 4]
  ]
}
Test Case 7 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, 1],
    [3, -3],
    [0, 0],
    [0, 1],
    [-1, 3],
    [6, 2],
    [0, -2],
    [1, 0],
    [4, 0],
    [5, 1],
    [1, 5],
    [-2, 0]
  ]
}
Test Case 8 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [2, 0]
  ]
}
Test Case 9 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "points": [
    [-1, -1],
    [1, 1],
    [-1, 1],
    [1, -1]
  ]
}
Test Case 10 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "points": [
    [-2, -2],
    [2, 2],
    [0, 0],
    [-2, 2],
    [2, -2]
  ]
}
Test Case 11 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "points": [
    [0, 0],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0]
  ]
}
Test Case 12 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, -1],
    [-1, 3],
    [3, 5],
    [5, 1]
  ]
}
Test Case 13 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [1, 0],
    [2, 2],
    [1, 2],
    [2, 1]
  ]
}
Test Case 14 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [1, 0],
    [-1, 3],
    [3, 5],
    [5, 1],
    [1, -1]
  ]
}
Test Case 15 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "points": [
    [3, 1],
    [1, 1],
    [0, 0],
    [0, 1],
    [3, 7],
    [1, 0],
    [-1, 3],
    [3, 5],
    [5, 1],
    [9, 1],
    [1, -1],
    [9, 7]
  ]
}
Test Case 16 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "points": [
    [3, 1],
    [1, 1],
    [0, 0],
    [0, 1],
    [3, 7],
    [1, 0],
    [-4, -2],
    [27, -5],
    [-1, 3],
    [3, 5],
    [5, 1],
    [10, -19],
    [9, 1],
    [1, -1],
    [9, 7],
    [13, 12]
  ]
}
Test Case 17 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "points": [
    [3, 1],
    [1, 1],
    [21, 19],
    [0, 0],
    [0, 1],
    [3, 7],
    [1, 0],
    [12, -14],
    [-4, -2],
    [27, -5],
    [-1, 3],
    [3, 5],
    [5, 1],
    [10, -19],
    [9, 1],
    [1, -1],
    [9, 7],
    [13, 12],
    [0, 7],
    [33, -2]
  ]
}
Test Case 18 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "points": [
    [21, 1],
    [3, 1],
    [1, 1],
    [21, 19],
    [0, 0],
    [0, 1],
    [2, 3],
    [22, 2],
    [3, 7],
    [1, 0],
    [12, -14],
    [-4, -2],
    [-22, 22],
    [27, -5],
    [-1, 3],
    [3, 5],
    [5, 1],
    [10, -19],
    [9, 1],
    [1, -1],
    [9, 7],
    [13, 12],
    [0, 7],
    [3, 19],
    [33, -2]
  ]
}
 
 
 */
/*
 {
  "points": []
}
Test Case 2
{
  "points": [
    [1, 0]
  ]
}
Test Case 3
{
  "points": [
    [0, 1],
    [1, 0]
  ]
}
Test Case 4
{
  "points": [
    [0, 0],
    [0, 1],
    [1, 0]
  ]
}
Test Case 5
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [1, 0]
  ]
}
Test Case 6
{
  "points": [
    [1, 1],
    [0, 0],
    [-4, 2],
    [-2, -1],
    [0, 1],
    [1, 0],
    [-1, 4]
  ]
}
Test Case 7
{
  "points": [
    [1, 1],
    [3, -3],
    [0, 0],
    [0, 1],
    [-1, 3],
    [6, 2],
    [0, -2],
    [1, 0],
    [4, 0],
    [5, 1],
    [1, 5],
    [-2, 0]
  ]
}
Test Case 8
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [2, 0]
  ]
}
Test Case 9
{
  "points": [
    [-1, -1],
    [1, 1],
    [-1, 1],
    [1, -1]
  ]
}
Test Case 10
{
  "points": [
    [-2, -2],
    [2, 2],
    [0, 0],
    [-2, 2],
    [2, -2]
  ]
}
Test Case 11
{
  "points": [
    [0, 0],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0]
  ]
}
Test Case 12
{
  "points": [
    [1, -1],
    [-1, 3],
    [3, 5],
    [5, 1]
  ]
}
Test Case 13
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [1, 0],
    [2, 2],
    [1, 2],
    [2, 1]
  ]
}
Test Case 14
{
  "points": [
    [1, 1],
    [0, 0],
    [0, 1],
    [1, 0],
    [-1, 3],
    [3, 5],
    [5, 1],
    [1, -1]
  ]
}
Test Case 15
{
  "points": [
    [3, 1],
    [1, 1],
    [0, 0],
    [0, 1],
    [3, 7],
    [1, 0],
    [-1, 3],
    [3, 5],
    [5, 1],
    [9, 1],
    [1, -1],
    [9, 7]
  ]
}
Test Case 16
{
  "points": [
    [3, 1],
    [1, 1],
    [0, 0],
    [0, 1],
    [3, 7],
    [1, 0],
    [-4, -2],
    [27, -5],
    [-1, 3],
    [3, 5],
    [5, 1],
    [10, -19],
    [9, 1],
    [1, -1],
    [9, 7],
    [13, 12]
  ]
}
Test Case 17
{
  "points": [
    [3, 1],
    [1, 1],
    [21, 19],
    [0, 0],
    [0, 1],
    [3, 7],
    [1, 0],
    [12, -14],
    [-4, -2],
    [27, -5],
    [-1, 3],
    [3, 5],
    [5, 1],
    [10, -19],
    [9, 1],
    [1, -1],
    [9, 7],
    [13, 12],
    [0, 7],
    [33, -2]
  ]
}
Test Case 18
{
  "points": [
    [21, 1],
    [3, 1],
    [1, 1],
    [21, 19],
    [0, 0],
    [0, 1],
    [2, 3],
    [22, 2],
    [3, 7],
    [1, 0],
    [12, -14],
    [-4, -2],
    [-22, 22],
    [27, -5],
    [-1, 3],
    [3, 5],
    [5, 1],
    [10, -19],
    [9, 1],
    [1, -1],
    [9, 7],
    [13, 12],
    [0, 7],
    [3, 19],
    [33, -2]
  ]
}
 */