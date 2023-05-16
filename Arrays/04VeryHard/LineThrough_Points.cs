
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._04VeryHard
{
    public class LineThrough_Points
    {

        public int LineThroughPoints(int[][] points)
        {
            // Write your code here.
            int maxNumberOfPointsOnLine = 1;

            for (int idx1 = 0; idx1 < points.Length; idx1++)
            {
                int[] p1 = points[idx1];
                Dictionary<string, int> slopes = new Dictionary<string, int>();

                for (int idx2 = idx1 + 1; idx2 < points.Length; idx2++)
                {
                    int[] p2 = points[idx2];
                    int[] slopeOfLineBetweenPoints =
                        getSlopeOfLineBetweenPoints(p1, p2);
                    int rise = slopeOfLineBetweenPoints[0];
                    int run = slopeOfLineBetweenPoints[1];

                    string slopeKey = createHashableKeyForRational(rise, run);
                    if (!slopes.ContainsKey(slopeKey))
                    {
                        slopes[slopeKey] = 1;
                    }
                    slopes[slopeKey] = slopes[slopeKey] + 1;
                }

                int currentMaxNumberOfPointsOnLine = maxSlope(slopes);
                maxNumberOfPointsOnLine = Math.Max(maxNumberOfPointsOnLine,
                                                  currentMaxNumberOfPointsOnLine);
            }
            return maxNumberOfPointsOnLine;
        }

        public int[] getSlopeOfLineBetweenPoints(int[] p1, int[] p2)
        {
            int p1x = p1[0];
            int p1y = p1[1];
            int p2x = p2[0];
            int p2y = p2[1];

            int[] slope = new int[] { 1, 0 };

            if (p1x != p2x)
            {
                int xDiff = p1x - p2x;
                int yDiff = p1y - p2y;
                int gcd = getGreatestCommonDivisor(Math.Abs(xDiff), Math.Abs(yDiff));
                xDiff = xDiff / gcd;
                yDiff = yDiff / gcd;

                if (xDiff < 0)
                {
                    xDiff *= -1;
                    yDiff *= -1;
                }
                slope = new int[] { yDiff, xDiff };
            }
            return slope;
        }

        public string createHashableKeyForRational(int numerator, int denominator)
        {
            return numerator.ToString() + ":" + denominator.ToString();
        }
        public int maxSlope(Dictionary<string, int> slopes)
        {
            int currentMax = 0;
            foreach (var slope in slopes)
            {
                currentMax = Math.Max(slope.Value, currentMax);
            }
            return currentMax;
        }

        public int getGreatestCommonDivisor(int num1, int num2)
        {
            int a = num1;
            int b = num2;
            while (true)
            {
                if (a == 0)
                {
                    return b;
                }
                if (b == 0)
                {
                    return a;
                }
                int temp = a;
                a = b;
                b = temp % b;
            }
        }
    }


}
/*
 {
  "points": [
    [1, 1],
    [2, 2],
    [3, 3],
    [0, 4],
    [-2, 6],
    [4, 0],
    [2, 1]
  ]
}
Test Case 2
{
  "points": [
    [3, 3],
    [0, 4],
    [-2, 6],
    [4, 0],
    [2, 1],
    [3, 4],
    [5, 6],
    [0, 0]
  ]
}
Test Case 3
{
  "points": [
    [1, 4],
    [3, 5],
    [7, 1],
    [5, 4],
    [4, 5],
    [9, 2],
    [1, 3],
    [2, 8]
  ]
}
Test Case 4
{
  "points": [
    [1, 4],
    [4, 1],
    [3, 3]
  ]
}
Test Case 5
{
  "points": [
    [0, 0]
  ]
}
Test Case 6
{
  "points": [
    [1, 4],
    [4, 1],
    [1, 1],
    [4, 4],
    [2, 3],
    [3, 2],
    [3, 3],
    [2, 2],
    [0, 3]
  ]
}
Test Case 7
{
  "points": [
    [1, 4],
    [4, 1],
    [1, 1],
    [4, 4],
    [2, 3],
    [3, 2],
    [3, 3],
    [2, 2],
    [0, 3],
    [5, 3],
    [3, -1],
    [2, -3],
    [1, -5]
  ]
}
Test Case 8
{
  "points": [
    [-1, -1],
    [-3, -1],
    [-4, -1],
    [1, 1],
    [4, 1]
  ]
}
Test Case 9
{
  "points": [
    [1, 1],
    [1, 2],
    [1, 3],
    [1, 4],
    [1, 5],
    [2, 1],
    [2, 2],
    [2, 3],
    [2, 4],
    [2, 5],
    [3, 1],
    [3, 2],
    [3, 4],
    [3, 5],
    [4, 1],
    [4, 2],
    [4, 3],
    [4, 4],
    [4, 5],
    [5, 1],
    [5, 2],
    [5, 3],
    [5, 4],
    [5, 5],
    [6, 6],
    [2, 6]
  ]
}
Test Case 10
{
  "points": [
    [1, 1],
    [1, 2],
    [1, 3],
    [1, 4],
    [1, 5],
    [2, 1],
    [2, 2],
    [2, 4],
    [2, 5],
    [4, 1],
    [4, 2],
    [4, 4],
    [4, 5],
    [5, 1],
    [5, 2],
    [5, 4],
    [5, 5],
    [6, 6],
    [2, 6],
    [-1, -1],
    [0, 0],
    [-2, -2]
  ]
}
Test Case 11
{
  "points": [
    [-78, -9],
    [67, 87],
    [46, 87],
    [4, 5],
    [9, 83],
    [34, 47]
  ]
}
Test Case 12
{
  "points": [
    [1000000001, 1],
    [1, 1],
    [0, 0]
  ]
}
 */