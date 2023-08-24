using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._04VeryHard
{
    public class WaterFall_Stream
    {
        public double[] WaterfallStreams(double[][] array, int source)
        {
            // Write your code here.
            double[] rowAbove = array[0];
            rowAbove[source] = -1;

            for (int row = 1; row < array.Length; row++)
            {
                double[] currentRow = array[row];

                for (int idx = 0; idx < currentRow.Length; idx++)
                {
                    double valueAbove = rowAbove[idx];

                    bool hasWaterAbove = valueAbove < 0;
                    bool hasBlock = currentRow[idx] == 1.0;

                    if (!hasWaterAbove)
                    {
                        continue;
                    }
                    if (!hasBlock)
                    {
                        currentRow[idx] += valueAbove;
                        continue;
                    }

                    double splitWater = valueAbove / 2;
                    int rightIdx = idx;
                    while (rightIdx + 1 < rowAbove.Length)
                    {
                        rightIdx += 1;
                        if (rowAbove[rightIdx] == 1.0)
                        {
                            break;
                        }
                        if (currentRow[rightIdx] != 1.0)
                        {
                            currentRow[rightIdx] += splitWater;
                            break;
                        }
                    }

                    int leftIdx = idx;
                    while (leftIdx - 1 >= 0)
                    {
                        leftIdx -= 1;
                        if (rowAbove[leftIdx] == 1.0)
                        {
                            break;
                        }
                        if (currentRow[leftIdx] != 1.0)
                        {
                            currentRow[leftIdx] += splitWater;
                            break;
                        }
                    }
                }
                rowAbove = currentRow;
            }

            double[] finalPercentage = new double[rowAbove.Length];
            for (int i = 0; i < rowAbove.Length; i++)
            {
                double num = rowAbove[i];
                if (num == 0)
                {
                    finalPercentage[i] = num;
                }
                else
                {
                    finalPercentage[i] = (num * -100);
                }
            }
            return finalPercentage;
        }
    }

}
/*
 
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    double[][] array = new double[][] {
      new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
      new double[] { 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
      new double[] { 0.0, 0.0, 1.0, 1.0, 1.0, 0.0, 0.0 },
      new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
      new double[] { 1.0, 1.0, 1.0, 0.0, 0.0, 1.0, 0.0 },
      new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0 },
      new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
    };
    var source = 3;
    double[] expected = { 0.0, 0.0, 0.0, 25.0, 25.0, 0.0, 0.0 };
    double[] actual = new Program().WaterfallStreams(array, source);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < expected.Length; i++)
      Utils.AssertTrue(expected[i] == actual[i]);
  }
}

9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
[0, 0, 0, 25, 25, 0, 0]
Your Code's Output
[0, 0, 0, 25, 25, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [1, 1, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 2 passed!
Expected Output
[100]
Your Code's Output
[100]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0],
    [0],
    [0],
    [0],
    [0],
    [0],
    [0]
  ],
  "source": 0
}
Test Case 3 passed!
Expected Output
[0]
Your Code's Output
[0]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0],
    [0],
    [0],
    [0],
    [0],
    [1],
    [0]
  ],
  "source": 0
}
Test Case 4 passed!
Expected Output
[0, 0, 0, 0, 0, 0, 0]
Your Code's Output
[0, 0, 0, 0, 0, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 1, 0, 1, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [1, 1, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 5 passed!
Expected Output
[0, 0, 0, 0, 25, 0, 0]
Your Code's Output
[0, 0, 0, 0, 25, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 1, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [1, 1, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 6 passed!
Expected Output
[25, 6.25, 0, 0, 0, 6.25, 0]
Your Code's Output
[25, 6.25, 0, 0, 0, 6.25, 0]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 1, 0, 0, 0, 1],
    [0, 0, 1, 0, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 7 passed!
Expected Output
[0, 0, 0, 0, 0, 0, 0]
Your Code's Output
[0, 0, 0, 0, 0, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 1, 0, 0, 0, 1],
    [0, 0, 1, 0, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 0],
    [1, 1, 1, 1, 1, 1, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 6
}
Test Case 8 passed!
Expected Output
[25, 0, 12.5, 0, 4.6875, 0, 0, 0, 0, 7.8125, 0, 0, 3.125, 37.5]
Your Code's Output
[25, 0, 12.5, 0, 4.6875, 0, 0, 0, 0, 7.8125, 0, 0, 3.125, 37.5]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 8
}
Test Case 9 passed!
Expected Output
[25, 0, 12.5, 0, 0, 0, 12.5, 6.25, 0, 3.125, 0, 0, 3.125, 37.5]
Your Code's Output
[25, 0, 12.5, 0, 0, 0, 12.5, 6.25, 0, 3.125, 0, 0, 3.125, 37.5]
View Outputs Side By Side
Input(s)
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 8
}



{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [1, 1, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 2
{
  "array": [
    [0],
    [0],
    [0],
    [0],
    [0],
    [0],
    [0]
  ],
  "source": 0
}
Test Case 3
{
  "array": [
    [0],
    [0],
    [0],
    [0],
    [0],
    [1],
    [0]
  ],
  "source": 0
}
Test Case 4
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 1, 0, 1, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [1, 1, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 5
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 1, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [1, 1, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 6
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 1, 0, 0, 0, 1],
    [0, 0, 1, 0, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 3
}
Test Case 7
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 1, 0, 0, 0, 1],
    [0, 0, 1, 0, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 0],
    [1, 1, 1, 1, 1, 1, 1],
    [0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 6
}
Test Case 8
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 8
}
Test Case 9
{
  "array": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "source": 8
}
 */