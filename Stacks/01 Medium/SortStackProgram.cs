using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    class SortStackProgram
    {
        public List<int> SortStack(List<int> stack)
        {

            if (stack.Count == 0)
            {
                return stack;
            }
            int top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);

            SortStack(stack);
            insertInSortedOrder(stack, top);
            return stack;
        }
        public void insertInSortedOrder(List<int> stack, int value)
        {
            if (stack.Count == 0 || (stack[stack.Count - 1] <= value))
            {
                stack.Add(value);
                return;
            }

            int top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            insertInSortedOrder(stack, value);
            stack.Add(top);
        }
    }
}

/*
 * 
using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> stack = new List<int> { -5, 2, -2, 4, 3, 1 };
    List<int> expected = new List<int> { -5, -2, 1, 2, 3, 4 };
    var actual = new Program().SortStack(stack);
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }
}


 15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
[-5, -2, 1, 2, 3, 4]
Your Code's Output
[-5, -2, 1, 2, 3, 4]
View Outputs Side By Side
Input(s)
{
  "stack": [-5, 2, -2, 4, 3, 1]
}
Test Case 2 passed!
Expected Output
[1, 2, 3, 4, 5]
Your Code's Output
[1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "stack": [3, 4, 5, 1, 2]
}
Test Case 3 passed!
Expected Output
[-9, -2, 0, 1, 3, 4, 8]
Your Code's Output
[-9, -2, 0, 1, 3, 4, 8]
View Outputs Side By Side
Input(s)
{
  "stack": [0, -2, 3, 4, 1, -9, 8]
}
Test Case 4 passed!
Expected Output
[-9, -2, 0, 1, 1, 2, 4, 6, 22, 23]
Your Code's Output
[-9, -2, 0, 1, 1, 2, 4, 6, 22, 23]
View Outputs Side By Side
Input(s)
{
  "stack": [2, 4, 22, 1, -9, 0, 6, 23, -2, 1]
}
Test Case 5 passed!
Expected Output
[1, 2, 3, 4, 5]
Your Code's Output
[1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "stack": [3, 4, 5, 1, 2]
}
Test Case 6 passed!
Expected Output
[-1, 0, 1, 1, 1, 2, 3, 4]
Your Code's Output
[-1, 0, 1, 1, 1, 2, 3, 4]
View Outputs Side By Side
Input(s)
{
  "stack": [-1, 0, 2, 3, 4, 1, 1, 1]
}
Test Case 7 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "stack": []
}
Test Case 8 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "stack": [1]
}
Test Case 9 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
View Outputs Side By Side
Input(s)
{
  "stack": [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
}
Test Case 10 passed!
Expected Output
[1, 2, 8, 9]
Your Code's Output
[1, 2, 8, 9]
View Outputs Side By Side
Input(s)
{
  "stack": [9, 2, 8, 1]
}
Test Case 11 passed!
Expected Output
[-9, -7, -5, -2, -2, -2, 0, 2, 2, 33, 44]
Your Code's Output
[-9, -7, -5, -2, -2, -2, 0, 2, 2, 33, 44]
View Outputs Side By Side
Input(s)
{
  "stack": [2, 33, 44, 2, -9, -7, -5, -2, -2, -2, 0]
}
Test Case 12 passed!
Expected Output
[3, 3, 3, 3, 3, 3]
Your Code's Output
[3, 3, 3, 3, 3, 3]
View Outputs Side By Side
Input(s)
{
  "stack": [3, 3, 3, 3, 3, 3]
}
Test Case 13 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "stack": [0, 0]
}
Test Case 14 passed!
Expected Output
[-9, -2, 2, 2, 3, 3, 3, 9, 22, 33, 33, 222, 312]
Your Code's Output
[-9, -2, 2, 2, 3, 3, 3, 9, 22, 33, 33, 222, 312]
View Outputs Side By Side
Input(s)
{
  "stack": [2, 22, 222, 3, 33, 33, 9, 2, 3, 312, -9, -2, 3]
}
Test Case 15 passed!
Expected Output
[-1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 5, 5]
Your Code's Output
[-1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 5, 5]
View Outputs Side By Side
Input(s)
{
  "stack": [3, 4, 5, 1, 2, 2, 2, 1, 3, 4, 5, 3, 1, 3, -1, 2, 3]
}
 
 */