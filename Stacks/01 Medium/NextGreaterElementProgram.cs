using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    class NextGreaterElementProgram
    {
        public int[] NextGreaterElementSolution1(int[] array)
        {
            // Write your code here.
            int[] result = new int[array.Length];
            Array.Fill(result, -1);
            Stack<int> stack = new Stack<int>();
            for (int idx = 2 * array.Length - 1; idx >= 0; idx--)
            {
                int circularIdx = idx % array.Length;

                while (stack.Count > 0)
                {
                    if (stack.Peek() <= array[circularIdx])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result[circularIdx] = stack.Peek();
                        break;
                    }
                }
                stack.Push(array[circularIdx]);
            }
            return result;
        }
        public int[] NextGreaterElementSolution2(int[] array)
        {
            // Write your code here.
            int[] result = new int[array.Length];
            Array.Fill(result, -1);
            Stack<int> stack = new Stack<int>();
            for (int idx = 0; idx < 2 * array.Length; idx++)
            {
                int circularIdx = idx % array.Length;

                while (stack.Count > 0 && array[stack.Peek()] < array[circularIdx])
                {
                    int top = stack.Pop();
                    result[top] = array[circularIdx];
                }
                stack.Push(circularIdx);
            }
            return result;
        }
    }
}

/*
 using System;
using System.Linq;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = new int[] { 2, 5, -3, -4, 6, 7, 2 };
    int[] expected = new int[] { 5, 6, 6, 6, 7, -1, 5 };
    int[] actual = new Program().NextGreaterElement(input);
    Utils.AssertTrue(expected.SequenceEqual(actual));
  }
}

15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
[5, 6, 6, 6, 7, -1, 5]
Your Code's Output
[5, 6, 6, 6, 7, -1, 5]
View Outputs Side By Side
Input(s)
{
  "array": [2, 5, -3, -4, 6, 7, 2]
}
Test Case 2 passed!
Expected Output
[1, 2, 3, 4, -1]
Your Code's Output
[1, 2, 3, 4, -1]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 2, 3, 4]
}
Test Case 3 passed!
Expected Output
[7, 5, 7, -1, 3, 3, 6]
Your Code's Output
[7, 5, 7, -1, 3, 3, 6]
View Outputs Side By Side
Input(s)
{
  "array": [6, 4, 5, 7, 2, 1, 3]
}
Test Case 4 passed!
Expected Output
[-1, 1, -1, 1, -1, 1, -1]
Your Code's Output
[-1, 1, -1, 1, -1, 1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [1, 0, 1, 0, 1, 0, 1]
}
Test Case 5 passed!
Expected Output
[6, -1, 3, 4, 3, -1, 3, 4, 5, 6]
Your Code's Output
[6, -1, 3, 4, 3, -1, 3, 4, 5, 6]
View Outputs Side By Side
Input(s)
{
  "array": [5, 6, 1, 3, 1, -2, -1, 3, 4, 5]
}
Test Case 6 passed!
Expected Output
[-1, 7, 7, 7, 7, 7, 7]
Your Code's Output
[-1, 7, 7, 7, 7, 7, 7]
View Outputs Side By Side
Input(s)
{
  "array": [7, 6, 5, 4, 3, 2, 1]
}
Test Case 7 passed!
Expected Output
[6, -1, 2, 3, 4, 5]
Your Code's Output
[6, -1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "array": [5, 6, 1, 2, 3, 4]
}
Test Case 8 passed!
Expected Output
[-1, -1, -1, -1, -1, -1, -1, -1]
Your Code's Output
[-1, -1, -1, -1, -1, -1, -1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1, 1, 1, 1, 1]
}
Test Case 9 passed!
Expected Output
[-1]
Your Code's Output
[-1]
View Outputs Side By Side
Input(s)
{
  "array": [12]
}
Test Case 10 passed!
Expected Output
[-1, 12]
Your Code's Output
[-1, 12]
View Outputs Side By Side
Input(s)
{
  "array": [12, 4]
}
Test Case 11 passed!
Expected Output
[0, 1, 1, 3, 18, 18, -1, 5, 18, -1]
Your Code's Output
[0, 1, 1, 3, 18, 18, -1, 5, 18, -1]
View Outputs Side By Side
Input(s)
{
  "array": [-9, 0, -5, 1, 3, -2, 18, 2, 5, 18]
}
Test Case 12 passed!
Expected Output
[6, 7, -1, 6, 6, 6]
Your Code's Output
[6, 7, -1, 6, 6, 6]
View Outputs Side By Side
Input(s)
{
  "array": [2, 6, 7, 2, 2, 2]
}
Test Case 13 passed!
Expected Output
[2, 3, 4, 6, 2, 3, 4, 6, -7, 6, 17, 17, -1, 9, 9, 17, 2, 3]
Your Code's Output
[2, 3, 4, 6, 2, 3, 4, 6, -7, 6, 17, 17, -1, 9, 9, 17, 2, 3]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 1, 2, 3, 4, -8, -7, 6, 2, 17, 2, -8, 9, 0, 2]
}
Test Case 14 passed!
Expected Output
[-1, 0, 0, 0, 0, 0, 0, 8, -2, -2, 8, -1]
Your Code's Output
[-1, 0, 0, 0, 0, 0, 0, 8, -2, -2, 8, -1]
View Outputs Side By Side
Input(s)
{
  "array": [-8, -1, -1, -2, -4, -5, -6, 0, -9, -91, -2, 8]
}
Test Case 15 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": []
}
 
 */