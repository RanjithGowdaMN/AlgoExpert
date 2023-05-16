using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._04VeryHard
{
    public class MinimumArea_Rectangle
    {

        public int MinimumAreaRectangle(int[][] points)
        {
            // Write your code here.
            HashSet<string> pointSet = createPointSet(points);
            int minimumAreaFound = Int32.MaxValue;

            for (int currentIdx = 0; currentIdx < points.Length; currentIdx++)
            {
                int p2x = points[currentIdx][0];
                int p2y = points[currentIdx][1];

                for (int previousIdx = 0; previousIdx < currentIdx; previousIdx++)
                {
                    int p1x = points[previousIdx][0];
                    int p1y = points[previousIdx][1];
                    bool pointsShareValue = p1x == p2x || p1y == p2y;

                    if (pointsShareValue) continue;

                    bool point1OnOppDiaExist = pointSet.Contains(convertPointToString(p1x, p2y));
                    bool point2OnOppDiaExist = pointSet.Contains(convertPointToString(p2x, p1y));

                    bool oppositeDiagonalExist = point1OnOppDiaExist && point2OnOppDiaExist;

                    if (oppositeDiagonalExist)
                    {
                        int currentArea = Math.Abs(p2x - p1x) * Math.Abs(p2y - p1y);
                        minimumAreaFound = Math.Min(minimumAreaFound, currentArea);
                    }
                }
            }

            return (minimumAreaFound != Int32.MaxValue) ? minimumAreaFound : 0;
        }

        public string convertPointToString(int x, int y)
        {
            return x.ToString() + ":" + y.ToString();

        }

        public HashSet<string> createPointSet(int[][] points)
        {
            HashSet<string> pointSet = new HashSet<string>();
            foreach (var point in points)
            {
                int x = point[0];
                int y = point[1];
                string pointString = convertPointToString(x, y);
                pointSet.Add(pointString);
            }

            return pointSet;
        }
    }


}
/*
 {
  "points": [
    [1, 5],
    [5, 1],
    [4, 2],
    [2, 4],
    [2, 2],
    [1, 2],
    [4, 5],
    [2, 5],
    [-1, -2]
  ]
}
Test Case 2
{
  "points": [
    [-4, 4],
    [4, 4],
    [4, -2],
    [-4, -2],
    [0, -2],
    [4, 2],
    [0, 2]
  ]
}
Test Case 3
{
  "points": [
    [-4, 4],
    [4, 4],
    [4, -2],
    [-4, -2],
    [0, -2],
    [4, 2],
    [0, 2],
    [0, 4],
    [2, 3],
    [0, 3],
    [2, 4]
  ]
}
Test Case 4
{
  "points": [
    [0, 0],
    [4, 4],
    [8, 8],
    [0, 8]
  ]
}
Test Case 5
{
  "points": [
    [0, 0],
    [4, 4],
    [8, 8],
    [0, 8],
    [0, 4],
    [6, 0],
    [6, 4]
  ]
}
Test Case 6
{
  "points": [
    [0, 0],
    [4, 4],
    [8, 8],
    [0, 8],
    [0, 4],
    [6, 0],
    [6, 4],
    [8, 0],
    [8, 4],
    [6, 2],
    [2, 4],
    [2, 0]
  ]
}
Test Case 7
{
  "points": [
    [0, 0],
    [1, 1],
    [2, 2],
    [-1, -1],
    [-2, -2],
    [-1, 1],
    [-2, 2],
    [1, -1],
    [2, -2]
  ]
}
Test Case 8
{
  "points": [
    [0, 1],
    [0, 0],
    [2, 1],
    [2, 0],
    [4, 0],
    [4, 1],
    [0, 2],
    [2, 2],
    [4, 2],
    [6, 0],
    [6, 1],
    [6, 2],
    [7, 1],
    [7, 0]
  ]
}
Test Case 9
{
  "points": [
    [0, 1],
    [0, 0],
    [2, 1],
    [2, 0],
    [4, 0],
    [4, 1],
    [0, 2],
    [2, 2],
    [4, 2],
    [6, 0],
    [6, 1],
    [6, 2],
    [7, 1]
  ]
}
Test Case 10
{
  "points": [
    [100, 100],
    [76, 67],
    [-100, 100],
    [65, 76],
    [100, -100],
    [3, 4],
    [-100, -100],
    [5, 6],
    [78, 54],
    [-87, 7],
    [1, 4],
    [4, 1],
    [-1, 5]
  ]
}
Test Case 11
{
  "points": []
}
Test Case 12
{
  "points": [
    [1, 2],
    [4, 2]
  ]
}
Test Case 13
{
  "points": [
    [2, 2],
    [3, 2],
    [4, 2]
  ]
}
 */