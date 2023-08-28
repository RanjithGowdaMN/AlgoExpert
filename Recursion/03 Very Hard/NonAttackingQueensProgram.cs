using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._03_Very_Hard
{
    class NonAttackingQueensProgram
    {
        public int NonAttackingQueens(int n)
        {
            // Upper Bound O(n!) time | O(n) space Complexity
            HashSet<int> blockedColumns = new HashSet<int>();
            HashSet<int> blockedUpDiagonals = new HashSet<int>();
            HashSet<int> blockedDownDiagonals = new HashSet<int>();
            return getNumberOfNonAttackingQueenPlacements(0, blockedColumns, blockedUpDiagonals, blockedDownDiagonals, n);

        }

        public int getNumberOfNonAttackingQueenPlacements(
          int row,
          HashSet<int> blockedColumns,
          HashSet<int> blockedUpDiagonals,
          HashSet<int> blockedDownDiagonals,
          int boardSize)
        {
            if (row == boardSize) return 1;

            int validPlacements = 0;
            for (int col = 0; col < boardSize; col++)
            {
                if (isNonAttackingPlacement(
                  row, col, blockedColumns, blockedUpDiagonals, blockedDownDiagonals
                ))
                {
                    placeQueen(row, col, blockedColumns, blockedUpDiagonals, blockedDownDiagonals);
                    validPlacements += getNumberOfNonAttackingQueenPlacements(
                      row + 1,
                      blockedColumns,
                      blockedUpDiagonals,
                      blockedDownDiagonals,
                      boardSize
                    );

                    removeQueen(row, col, blockedColumns, blockedUpDiagonals, blockedDownDiagonals);
                }
            }
            return validPlacements;
        }
        public bool isNonAttackingPlacement(
           int row,
          int col,
          HashSet<int> blockedColumns,
          HashSet<int> blockedUpDiagonals,
          HashSet<int> blockedDownDiagonals
        )
        {
            if (blockedColumns.Contains(col))
            {
                return false;
            }
            else if (blockedUpDiagonals.Contains(col + row))
            {
                return false;
            }
            else if (blockedDownDiagonals.Contains(row - col))
            {
                return false;
            }
            return true;
        }
        public void placeQueen(
          int row,
          int col,
          HashSet<int> blockedColumns,
          HashSet<int> blockedUpDiagonals,
          HashSet<int> blockedDownDiagonals
        )
        {
            blockedColumns.Add(col);
            blockedUpDiagonals.Add(row + col);
            blockedDownDiagonals.Add(row - col);
        }

        public void removeQueen(
          int row,
          int col,
          HashSet<int> blockedColumns,
          HashSet<int> blockedUpDiagonals,
          HashSet<int> blockedDownDiagonals
        )
        {
            blockedColumns.Remove(col);
            blockedUpDiagonals.Remove(row + col);
            blockedDownDiagonals.Remove(row - col);
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = 4;
    var expected = 2;
    var actual = new Program().NonAttackingQueens(input);
    Utils.AssertTrue(expected == actual);
  }
}

9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
2
Our Code's Output
2
View Outputs Side By Side
Input(s)
{
  "n": 4
}
Test Case 2 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "n": 2
}
Test Case 3 passed!
Expected Output
1
Our Code's Output
1
View Outputs Side By Side
Input(s)
{
  "n": 1
}
Test Case 4 passed!
Expected Output
0
Our Code's Output
0
View Outputs Side By Side
Input(s)
{
  "n": 3
}
Test Case 5 passed!
Expected Output
92
Our Code's Output
92
View Outputs Side By Side
Input(s)
{
  "n": 8
}
Test Case 6 passed!
Expected Output
10
Our Code's Output
10
View Outputs Side By Side
Input(s)
{
  "n": 5
}
Test Case 7 passed!
Expected Output
4
Our Code's Output
4
View Outputs Side By Side
Input(s)
{
  "n": 6
}
Test Case 8 passed!
Expected Output
40
Our Code's Output
40
View Outputs Side By Side
Input(s)
{
  "n": 7
}
Test Case 9 passed!
Expected Output
724
Our Code's Output
724
View Outputs Side By Side
Input(s)
{
  "n": 10
}
 
 */