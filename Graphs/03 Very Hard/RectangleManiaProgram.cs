using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._03_Very_Hard
{
    class RectangleManiaProgram
    {
        public static int RectangleMania(List<int[]> coords)
        {
            // Write your code here.
            HashSet<string> coordsTable = getCoordsTable(coords);
            return getRectangleCount(coords, coordsTable);
        }

        public static HashSet<string> getCoordsTable(List<int[]> coords)
        {
            HashSet<string> coordsTable = new HashSet<string>();
            foreach (var coord in coords)
            {
                string coordstring = coordTostring(coord);
                coordsTable.Add(coordstring);
            }
            return coordsTable;
        }

        public static int getRectangleCount(
            List<int[]> coords, HashSet<string> coordsTable
        )
        {
            int rectangleCount = 0;
            foreach (var coord1 in coords)
            {
                foreach (var coord2 in coords)
                {
                    if (!isInUpperRight(coord1, coord2)) continue;
                    string upperCoordstring =
                        coordTostring(new int[] { coord1[0], coord2[1] });
                    string rightCoordstring =
                        coordTostring(new int[] { coord2[0], coord1[1] });
                    if (coordsTable.Contains(upperCoordstring) && coordsTable.Contains(rightCoordstring))
                        rectangleCount++;
                }
            }
            return rectangleCount;
        }


        public static bool isInUpperRight(int[] coord1, int[] coord2)
        {
            return coord2[0] > coord1[0] && coord2[1] > coord1[1];
        }

        public static string coordTostring(int[] coord)
        {
            return coord[0].ToString() + "-" + coord[1].ToString();
        }
    }
}
/*
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int[]> coords = new List<int[]> {
      new int[] { 0, 0 },
      new int[] { 0, 1 },
      new int[] { 1, 1 },
      new int[] { 1, 0 },
      new int[] { 2, 1 },
      new int[] { 2, 0 },
      new int[] { 3, 1 },
      new int[] { 3, 0 }
    };
    Utils.AssertTrue(Program.RectangleMania(coords) == 6);
  }
}


10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
6
Our Code's Output
6
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0],
    [3, 1],
    [3, 0]
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
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0]
  ]
}
Test Case 3 passed!
Expected Output
3
Our Code's Output
3
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0]
  ]
}
Test Case 4 passed!
Expected Output
8
Our Code's Output
8
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0],
    [3, 1],
    [3, 0],
    [1, 3],
    [3, 3]
  ]
}
Test Case 5 passed!
Expected Output
10
Our Code's Output
10
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0],
    [3, 1],
    [3, 0],
    [1, 3],
    [3, 3],
    [0, -4],
    [3, -4]
  ]
}
Test Case 6 passed!
Expected Output
13
Our Code's Output
13
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0],
    [3, 1],
    [3, 0],
    [1, 3],
    [3, 3],
    [0, -4],
    [3, -4],
    [1, -3],
    [3, -3]
  ]
}
Test Case 7 passed!
Expected Output
13
Our Code's Output
13
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0],
    [3, 1],
    [3, 0],
    [1, 3],
    [3, 3],
    [0, -4],
    [3, -4],
    [1, -3],
    [3, -3],
    [-1, 0],
    [-10, 0],
    [-1, -1],
    [2, -2]
  ]
}
Test Case 8 passed!
Expected Output
23
Our Code's Output
23
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1],
    [1, 0],
    [2, 1],
    [2, 0],
    [3, 1],
    [3, 0],
    [1, 3],
    [3, 3],
    [0, -4],
    [3, -4],
    [1, -3],
    [3, -3],
    [-1, 0],
    [-10, 0],
    [-1, -1],
    [2, -2],
    [0, -1],
    [1, -4],
    [-10, -4]
  ]
}
Test Case 9 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 0],
    [2, 1],
    [1, 3],
    [3, 3],
    [0, -4],
    [3, -5],
    [1, -3],
    [3, -2],
    [-1, 0],
    [-10, 0],
    [-1, -1],
    [2, -2]
  ]
}
Test Case 10 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "coords": [
    [0, 0],
    [0, 1],
    [1, 1]
  ]
}
 
 */