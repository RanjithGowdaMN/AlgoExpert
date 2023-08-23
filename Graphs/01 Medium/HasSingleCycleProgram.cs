using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class HasSingleCycleProgram
    {
        public static bool HasSingleCycle(int[] array)
        {
            // O(n) time | O(1) space
            int numElementsVisited = 0;
            int currentIdx = 0;
            while (numElementsVisited < array.Length)
            {
                if (numElementsVisited > 0 && currentIdx == 0) return false;
                numElementsVisited++;
                currentIdx = getNextIdx(currentIdx, array);
            }
            return currentIdx == 0;
        }

        public static int getNextIdx(int currentIdx, int[] array)
        {
            int jump = array[currentIdx];
            int nextIdx = (currentIdx + jump) % array.Length;
            return nextIdx >= 0 ? nextIdx : nextIdx + array.Length;
        }
    }
}
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(Program.HasSingleCycle(new int[] { 2, 3, 1, -4, -4, 2 }));
  }
}

16 / 16 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [2, 3, 1, -4, -4, 2]
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [2, 2, -1]
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [2, 2, 2]
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 1]
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [-1, 2, 2]
}
Test Case 6 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 1, 1, 1]
}
Test Case 7 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 0, 1, 1]
}
Test Case 8 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 2]
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [3, 5, 6, -5, -2, -5, -12, -2, -1, 2, -6, 1, 1, 2, -5, 2]
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [3, 5, 5, -5, -2, -5, -12, -2, -1, 2, -6, 1, 1, 2, -5, 2]
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, -2, 3, 7, 8, 1]
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, -2, 3, 7, 8, -8]
}
Test Case 13 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, -2, 3, 7, 8, -26]
}
Test Case 14 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [10, 11, -6, -23, -2, 3, 88, 908, -26]
}
Test Case 15 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [10, 11, -6, -23, -2, 3, 88, 909, -26]
}
Test Case 16 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, -1, 1, -1]
}
 
 */