using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class JuiceBotlingProgram
    {

        public List<int> JuiceBottling(int[] prices)
        {
            // Write your code here.
            int numSizes = prices.Length;
            int[] maxProfit = new int[numSizes];
            int[] dividingPoints = new int[numSizes];

            for (int size = 0; size < numSizes; size++)
            {
                for (int dividingPoint = 0; dividingPoint <= size; dividingPoint++)
                {
                    int possibleProfit = maxProfit[size - dividingPoint] +
                        prices[dividingPoint];
                    if (possibleProfit > maxProfit[size])
                    {
                        maxProfit[size] = possibleProfit;
                        dividingPoints[size] = dividingPoint;
                    }
                }
            }

            List<int> solution = new List<int>();
            int currentDividingPoint = numSizes - 1;
            while (currentDividingPoint > 0)
            {
                solution.Add(dividingPoints[currentDividingPoint]);
                currentDividingPoint -= dividingPoints[currentDividingPoint];
            }


            return solution;
        }

    }
}

/*

using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[] { 0, 2, 5, 6 };
    var expected = new int[] { 1, 2 };
    var actual = new Program().JuiceBottling(input);
    Utils.AssertTrue(expected.Length == actual.Count);
    for (int i = 0; i < actual.Count; i++) {
      Utils.AssertTrue(expected[i] == actual[i]);
    }
  }
}


 Test Case 1 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1]
}
Test Case 2 passed!
Expected Output
[2]
Your Code's Output
[2]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1, 3]
}
Test Case 3 passed!
Expected Output
[1, 1]
Your Code's Output
[1, 1]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 2, 3]
}
Test Case 4 passed!
Expected Output
[1, 1, 1]
Your Code's Output
[1, 1, 1]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 2, 3, 4]
}
Test Case 5 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 2, 5, 6]
}
Test Case 6 passed!
Expected Output
[2, 2]
Your Code's Output
[2, 2]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 2, 5, 6, 7]
}
Test Case 7 passed!
Expected Output
[4]
Your Code's Output
[4]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 2, 5, 6, 11]
}
Test Case 8 passed!
Expected Output
[1, 3]
Your Code's Output
[1, 3]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 2, 5, 10, 11]
}
Test Case 9 passed!
Expected Output
[1, 1, 1, 1, 1, 1]
Your Code's Output
[1, 1, 1, 1, 1, 1]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 5, 6, 7, 8, 9, 10]
}
Test Case 10 passed!
Expected Output
[2, 2]
Your Code's Output
[2, 2]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 2, 5, 4, 4]
}
Test Case 11 passed!
Expected Output
[1, 2]
Your Code's Output
[1, 2]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1, 3, 2]
}
Test Case 12 passed!
Expected Output
[2, 2]
Your Code's Output
[2, 2]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1, 3, 2, 4]
}
Test Case 13 passed!
Expected Output
[1, 3, 3, 3]
Your Code's Output
[1, 3, 3, 3]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 3, 5, 10, 8, 4, 12, 15, 20, 18, 25]
}
Test Case 14 passed!
Expected Output
[10]
Your Code's Output
[10]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1, 3, 7, 5, 4, 12, 15, 20, 18, 25]
}
Test Case 15 passed!
Expected Output
[1, 3, 6]
Your Code's Output
[1, 3, 6]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1, 3, 6, 5, 4, 17, 15, 20, 18, 21]
}
Test Case 16 passed!
Expected Output
[2, 8]
Your Code's Output
[2, 8]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1, 3, 5, 4, 8, 7, 12, 15, 13, 16]
}
Test Case 17 passed!
Expected Output
[5, 5]
Your Code's Output
[5, 5]
View Outputs Side By Side
Input(s)
{
  "prices": [0, 1, 3, 5, 4, 10, 7, 12, 15, 13, 16]
}
 */