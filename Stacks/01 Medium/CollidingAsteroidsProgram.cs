using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    class CollidingAsteroidsProgram
    {
        public int[] CollidingAsteroids(int[] asteroids)
        {
            // Write your code here.
            Stack<int> resultStack = new Stack<int>();
            foreach (var asteroid in asteroids)
            {
                if (resultStack.Count == 0 || asteroid > 0 || resultStack.Peek() < 0)
                {
                    resultStack.Push(asteroid);
                    continue;
                }
                while (resultStack.Count > 0)
                {
                    if (resultStack.Peek() < 0)
                    {
                        resultStack.Push(asteroid);
                        break;
                    }

                    int asteroidSize = Math.Abs(asteroid);
                    if (resultStack.Peek() > asteroidSize) break;
                    if (resultStack.Peek() == asteroidSize)
                    {
                        resultStack.Pop();
                        break;
                    }
                    resultStack.Pop();
                    if (resultStack.Count == 0)
                    {
                        resultStack.Push(asteroid);
                        break;
                    }
                }
            }
            int[] output = new int[resultStack.Count];
            for (int i = resultStack.Count - 1; i >= 0; i--)
            {
                output[i] = resultStack.Pop();
            }
            return output;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = new int[] { -3, 5, -8, 6, 7, -4, -7 };
    int[] expected = new int[] { -3, -8, 6 };
    int[] actual = new Program().CollidingAsteroids(input);
    Utils.AssertTrue(expected.Length == actual.Length);

    for (int i = 0; i < expected.Length; i++) {
      Utils.AssertTrue(expected[i] == actual[i]);
    }
  }
}


 20 / 20 test cases passed.

Test Case 1 passed!
Expected Output
[5]
Your Code's Output
[5]
View Outputs Side By Side
Input(s)
{
  "asteroids": [5]
}
Test Case 2 passed!
Expected Output
[-5]
Your Code's Output
[-5]
View Outputs Side By Side
Input(s)
{
  "asteroids": [-5]
}
Test Case 3 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "asteroids": [5, -5]
}
Test Case 4 passed!
Expected Output
[-5, 5]
Your Code's Output
[-5, 5]
View Outputs Side By Side
Input(s)
{
  "asteroids": [-5, 5]
}
Test Case 5 passed!
Expected Output
[-5, -5]
Your Code's Output
[-5, -5]
View Outputs Side By Side
Input(s)
{
  "asteroids": [-5, -5]
}
Test Case 6 passed!
Expected Output
[5, 5]
Your Code's Output
[5, 5]
View Outputs Side By Side
Input(s)
{
  "asteroids": [5, 5]
}
Test Case 7 passed!
Expected Output
[1, 2, 3, 4, 5]
Your Code's Output
[1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "asteroids": [1, 2, 3, 4, 5]
}
Test Case 8 passed!
Expected Output
[34, 2, 5, 42, 100, 20]
Your Code's Output
[34, 2, 5, 42, 100, 20]
View Outputs Side By Side
Input(s)
{
  "asteroids": [34, 2, 5, 42, 100, 20]
}
Test Case 9 passed!
Expected Output
[-6, -2, -10, -100, -30]
Your Code's Output
[-6, -2, -10, -100, -30]
View Outputs Side By Side
Input(s)
{
  "asteroids": [-6, -2, -10, -100, -30]
}
Test Case 10 passed!
Expected Output
[-4]
Your Code's Output
[-4]
View Outputs Side By Side
Input(s)
{
  "asteroids": [1, 2, 3, -4]
}
Test Case 11 passed!
Expected Output
[4]
Your Code's Output
[4]
View Outputs Side By Side
Input(s)
{
  "asteroids": [4, -1, -2, -3]
}
Test Case 12 passed!
Expected Output
[-3, -8, 6]
Your Code's Output
[-3, -8, 6]
View Outputs Side By Side
Input(s)
{
  "asteroids": [-3, 7, -8, 6, 7, -5, -7]
}
Test Case 13 passed!
Expected Output
[-5, -5, -5]
Your Code's Output
[-5, -5, -5]
View Outputs Side By Side
Input(s)
{
  "asteroids": [4, -5, -5, -5]
}
Test Case 14 passed!
Expected Output
[6]
Your Code's Output
[6]
View Outputs Side By Side
Input(s)
{
  "asteroids": [6, -5, -5, -5]
}
Test Case 15 passed!
Expected Output
[-10, 100, 99]
Your Code's Output
[-10, 100, 99]
View Outputs Side By Side
Input(s)
{
  "asteroids": [4, 7, -3, -5, 6, -10, 100, -50, 99]
}
Test Case 16 passed!
Expected Output
[-70, 100]
Your Code's Output
[-70, 100]
View Outputs Side By Side
Input(s)
{
  "asteroids": [-70, 100, 23, 42, -50, -75, 1, -2, -3]
}
Test Case 17 passed!
Expected Output
[-70, -50, -75, -2, -3]
Your Code's Output
[-70, -50, -75, -2, -3]
View Outputs Side By Side
Input(s)
{
  "asteroids": [-70, 10, 23, 42, -50, -75, 1, -2, -3]
}
Test Case 18 passed!
Expected Output
[42, 30, 12, 65, 32]
Your Code's Output
[42, 30, 12, 65, 32]
View Outputs Side By Side
Input(s)
{
  "asteroids": [42, 30, 12, 65, -50, 32, -15, -25]
}
Test Case 19 passed!
Expected Output
[5123, 2432, 4242, 1267, 1337]
Your Code's Output
[5123, 2432, 4242, 1267, 1337]
View Outputs Side By Side
Input(s)
{
  "asteroids": [5123, -34, 654, -3636, 2432, 4242, 1267, 1337, -43, -864, 38, 38, 1, -400]
}
Test Case 20 passed!
Expected Output
[-1246, 754, 1252, 5468, 1]
Your Code's Output
[-1246, 754, 1252, 5468, 1]
View Outputs Side By Side
Input(s)
{
  "asteroids": [651, 13, -1246, 754, 1252, -300, 5468, -5200, 22, 17, -100, 87, 100, -250, 1]
}
 */
