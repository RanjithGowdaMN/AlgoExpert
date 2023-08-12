using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class KnapsackProblemProgram
    {
        public static List<List<int>> KnapsackProblem(int[,] items, int capacity)
        {
            // Write your code here.
            // Replace the code below.
            int[,] knapsackValues = new int[items.GetLength(0) + 1, capacity + 1];
            for (int i = 1; i < items.GetLength(0) + 1; i++)
            {
                int currentWeight = items[i - 1, 1];
                int currentValue = items[i - 1, 0];
                for (int c = 0; c < capacity + 1; c++)
                {
                    if (currentWeight > c)
                    {
                        knapsackValues[i, c] = knapsackValues[i - 1, c];
                    }
                    else
                    {
                        knapsackValues[i, c] = Math.Max(knapsackValues[i - 1, c],
                        knapsackValues[i - 1, c - currentWeight] + currentValue
                        );
                    }
                }
            }
            return getKnapSackItems(knapsackValues, items, knapsackValues[items.GetLength(0), capacity]);

        }

        public static List<List<int>> getKnapSackItems(int[,] knapsackValues, int[,] items, int weight)
        {
            List<List<int>> sequence = new List<List<int>>();
            List<int> totalWeight = new List<int>();
            totalWeight.Add(weight);
            sequence.Add(totalWeight);
            sequence.Add(new List<int>());

            int i = knapsackValues.GetLength(0) - 1;
            int c = knapsackValues.GetLength(1) - 1;
            while (i > 0)
            {
                if (knapsackValues[i, c] == knapsackValues[i - 1, c])
                {
                    i--;
                }
                else
                {
                    sequence[1].Insert(0, i - 1);
                    c = c - items[i - 1, 1];
                    i--;
                }
                if (c == 0)
                {
                    break;
                }
            }
            return sequence;
        }
    }
}

/*
 using System;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[,] input = { { 1, 2 }, { 4, 3 }, { 5, 6 }, { 6, 7 } };
    Tuple<int, int[]> expected = Tuple.Create(10, new int[] { 1, 3 });
    Utils.AssertTrue(compare(Program.KnapsackProblem(input, 10), expected));
  }

  private static bool compare(List<List<int> > arr1, Tuple<int, int[]> arr2) {
    if (arr1[0][0] != arr2.Item1) {
      return false;
    }
    if (arr1[1].Count != arr2.Item2.Length) {
      return false;
    }
    for (int i = 0; i < arr1[1].Count; i++) {
      if (arr1[1][i] != arr2.Item2[i]) {
        return false;
      }
    }
    return true;
  }
}

7 / 7 test cases passed.

Test Case 1 passed!
Expected Output
[10, [1, 3]]
Your Code's Output
[10, [1, 3]]
View Outputs Side By Side
Input(s)
{
  "capacity": 10,
  "items": [
    [1, 2],
    [4, 3],
    [5, 6],
    [6, 7]
  ]
}
Test Case 2 passed!
Expected Output
[10, [0, 1, 2]]
Your Code's Output
[10, [0, 1, 2]]
View Outputs Side By Side
Input(s)
{
  "capacity": 11,
  "items": [
    [1, 2],
    [4, 3],
    [5, 6],
    [6, 9]
  ]
}
Test Case 3 passed!
Expected Output
[1500, [3, 12, 14]]
Your Code's Output
[1500, [3, 12, 14]]
View Outputs Side By Side
Input(s)
{
  "capacity": 200,
  "items": [
    [465, 100],
    [400, 85],
    [255, 55],
    [350, 45],
    [650, 130],
    [1000, 190],
    [455, 100],
    [100, 25],
    [1200, 190],
    [320, 65],
    [750, 100],
    [50, 45],
    [550, 65],
    [100, 50],
    [600, 70],
    [240, 40]
  ]
}
Test Case 4 passed!
Expected Output
[1505, [7, 12, 14, 15]]
Your Code's Output
[1505, [7, 12, 14, 15]]
View Outputs Side By Side
Input(s)
{
  "capacity": 200,
  "items": [
    [465, 100],
    [400, 85],
    [255, 55],
    [350, 45],
    [650, 130],
    [1000, 190],
    [455, 100],
    [100, 25],
    [1200, 190],
    [320, 65],
    [750, 100],
    [50, 45],
    [550, 65],
    [100, 50],
    [600, 70],
    [255, 40]
  ]
}
Test Case 5 passed!
Expected Output
[101, [0, 2, 3]]
Your Code's Output
[101, [0, 2, 3]]
View Outputs Side By Side
Input(s)
{
  "capacity": 100,
  "items": [
    [2, 1],
    [70, 70],
    [30, 30],
    [69, 69],
    [100, 100]
  ]
}
Test Case 6 passed!
Expected Output
[100, [1, 2]]
Your Code's Output
[100, [1, 2]]
View Outputs Side By Side
Input(s)
{
  "capacity": 100,
  "items": [
    [1, 2],
    [70, 70],
    [30, 30],
    [69, 69],
    [99, 100]
  ]
}
Test Case 7 passed!
Expected Output
[0, []]
Your Code's Output
[0, []]
View Outputs Side By Side
Input(s)
{
  "capacity": 0,
  "items": [
    [1, 2],
    [70, 70],
    [30, 30],
    [69, 69],
    [100, 100]
  ]
} 

 */