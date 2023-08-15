using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    class StaircaseTraversalProgram
    {
        public int StaircaseTraversalSol1(int height, int maxSteps)
        {
            // Sol1
            Dictionary<int, int> memoize = new Dictionary<int, int>();
            memoize[0] = 1;
            memoize[1] = 1;
            return numberOfWaystoTopSol1(height, maxSteps, memoize);
        }
        public int numberOfWaystoTopSol1(
            int height, int maxSteps, Dictionary<int, int> memoize
        )
        {
            if (memoize.ContainsKey(height))
            {
                return memoize[height];
            }
            int numberOfWays = 0;
            for (int step = 1; step < Math.Min(maxSteps, height) + 1; step++)
            {
                numberOfWays += numberOfWaystoTopSol1(height - step, maxSteps, memoize);
            }
            memoize[height] = numberOfWays;
            return numberOfWays;
        }

        //--------------------------------
        public int StaircaseTraversalSol2(int height, int maxSteps)
        {
            // sol2
            int[] waysToTop = new int[height + 1];
            waysToTop[0] = 1;
            waysToTop[1] = 1;
            for (int currentHeight = 2; currentHeight < height + 1; currentHeight++)
            {
                int step = 1;
                while (step <= maxSteps && step <= currentHeight)
                {
                    waysToTop[currentHeight] =
                        waysToTop[currentHeight] + waysToTop[currentHeight - step];
                    step += 1;
                }
            }
            return waysToTop[height];
        }

        public int StaircaseTraversalSol3(int height, int maxSteps)
        {
            // sol3
            int currentNumberOfWays = 0;
            List<int> waysToTop = new List<int>();
            waysToTop.Add(1);

            for (int currentHeight = 1; currentHeight < height + 1; currentHeight++)
            {
                int startOfWindow = currentHeight - maxSteps - 1;
                int endOfWindow = currentHeight - 1;

                if (startOfWindow >= 0)
                {
                    currentNumberOfWays -= waysToTop[startOfWindow];

                }
                currentNumberOfWays += waysToTop[endOfWindow];
                waysToTop.Add(currentNumberOfWays);
            }

            return waysToTop[height];
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int stairs = 4;
    int maxSteps = 2;
    int expected = 5;
    int actual = new Program().StaircaseTraversal(stairs, maxSteps);
    Utils.AssertTrue(expected == actual);
  }
}
 13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "height": 4,
  "maxSteps": 2
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "height": 10,
  "maxSteps": 1
}
Test Case 3 passed!
Expected Output
89
Your Code's Output
89
View Outputs Side By Side
Input(s)
{
  "height": 10,
  "maxSteps": 2
}
Test Case 4 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "height": 4,
  "maxSteps": 3
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "height": 1,
  "maxSteps": 1
}
Test Case 6 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "height": 5,
  "maxSteps": 2
}
Test Case 7 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "height": 4,
  "maxSteps": 4
}
Test Case 8 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "height": 6,
  "maxSteps": 2
}
Test Case 9 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "height": 100,
  "maxSteps": 1
}
Test Case 10 passed!
Expected Output
13624
Your Code's Output
13624
View Outputs Side By Side
Input(s)
{
  "height": 15,
  "maxSteps": 5
}
Test Case 11 passed!
Expected Output
21
Your Code's Output
21
View Outputs Side By Side
Input(s)
{
  "height": 7,
  "maxSteps": 2
}
Test Case 12 passed!
Expected Output
24
Your Code's Output
24
View Outputs Side By Side
Input(s)
{
  "height": 6,
  "maxSteps": 3
}
Test Case 13 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "height": 3,
  "maxSteps": 2
}
 
 
 */