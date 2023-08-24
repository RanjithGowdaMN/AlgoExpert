using System.Collections.Generic;

namespace Arrays
{
    public class FourNumberSums
    {
        public static List<int[]> FourNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            Dictionary<int, List<int[]>> HashDict = new Dictionary<int, List<int[]>>();
            List<int[]> result = new List<int[]>();

            for (int i = 1; i < array.Length - 1; i++)
            {

                for (int j = i + 1; j < array.Length; j++)
                {
                    int currentSum = array[i] + array[j];
                    int difference = targetSum - currentSum;
                    if (HashDict.ContainsKey(difference))
                    {
                        foreach (int[] pair in HashDict[difference])
                        {
                            result.Add(new int[] { pair[0], pair[1], array[i], array[j] });
                        }
                    }
                }

                for (int k = 0; k < i; k++)
                {
                    int currentSum = array[i] + array[k];
                    int[] newPair = { array[i], array[k] };
                    int difference = targetSum - currentSum;
                    if (!HashDict.ContainsKey(currentSum))
                    {
                        List<int[]> TempList = new List<int[]>();

                        TempList.Add(newPair);
                        HashDict.Add(currentSum, TempList);
                    }
                    else
                    {
                        HashDict[currentSum].Add(newPair);
                    }
                }

            }

            return result;
        }

    }
}
/*
 using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  private bool compare(List<int[]> quads1, List<int[]> quads2) {
    foreach (int[] quad in quads2) {
      Array.Sort(quad);
    }
    foreach (int[] quad in quads1) {
      Array.Sort(quad);
    }
    foreach (int[] quad2 in quads2) {
      bool found = false;
      foreach (int[] quad1 in quads1) {
        if (Enumerable.SequenceEqual(quad2, quad1)) {
          found = true;
          break;
        }
      }
      if (found == false) {
        return false;
      }
    }
    return true;
  }

  [Test]
  public void TestCase1() {
    List<int[]> output =
      Program.FourNumberSum(new int[] { 7, 6, 4, -1, 1, 2 }, 16);
    List<int[]> quadruplets = new List<int[]>();
    quadruplets.Add(new int[] { 7, 6, 4, -1 });
    quadruplets.Add(new int[] { 7, 6, 1, 2 });
    Utils.AssertTrue(quadruplets.Count == output.Count);
    Utils.AssertTrue(this.compare(quadruplets, output));
  }
}

8 / 8 test cases passed.

Test Case 1 passed!
Expected Output
[
  [7, 6, 4, -1],
  [7, 6, 1, 2]
]
Your Code's Output
[
  [7, 6, 4, -1],
  [7, 6, 1, 2]
]
View Outputs Side By Side
Input(s)
{
  "array": [7, 6, 4, -1, 1, 2],
  "targetSum": 16
}
Test Case 2 passed!
Expected Output
[
  [1, 2, 3, 4]
]
Your Code's Output
[
  [1, 2, 3, 4]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 7],
  "targetSum": 10
}
Test Case 3 passed!
Expected Output
[
  [5, -5, -2, 2],
  [5, -5, 3, -3],
  [-2, 2, 3, -3]
]
Your Code's Output
[
  [5, -5, -2, 2],
  [5, -5, 3, -3],
  [-2, 2, 3, -3]
]
View Outputs Side By Side
Input(s)
{
  "array": [5, -5, -2, 2, 3, -3],
  "targetSum": 0
}
Test Case 4 passed!
Expected Output
[
  [-2, -1, 1, 6],
  [-2, 1, 2, 3],
  [-2, -1, 2, 5],
  [-2, -1, 3, 4]
]
Your Code's Output
[
  [-2, -1, 1, 6],
  [-2, 1, 2, 3],
  [-2, -1, 2, 5],
  [-2, -1, 3, 4]
]
View Outputs Side By Side
Input(s)
{
  "array": [-2, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9],
  "targetSum": 4
}
Test Case 5 passed!
Expected Output
[
  [-1, 22, 7, 2],
  [22, 4, 7, -3],
  [-1, 18, 11, 2],
  [18, 4, 11, -3],
  [22, 11, 2, -5]
]
Your Code's Output
[
  [-1, 22, 7, 2],
  [22, 4, 7, -3],
  [-1, 18, 11, 2],
  [18, 4, 11, -3],
  [22, 11, 2, -5]
]
View Outputs Side By Side
Input(s)
{
  "array": [-1, 22, 18, 4, 7, 11, 2, -5, -3],
  "targetSum": 30
}
Test Case 6 passed!
Expected Output
[
  [-5, 2, 15, 8],
  [-3, 2, -7, 28],
  [-10, -3, 28, 5],
  [-10, 28, -6, 8],
  [-7, 28, -6, 5],
  [-5, 2, 12, 11],
  [-5, 12, 8, 5]
]
Your Code's Output
[
  [-5, 2, 15, 8],
  [-3, 2, -7, 28],
  [-10, -3, 28, 5],
  [-10, 28, -6, 8],
  [-7, 28, -6, 5],
  [-5, 2, 12, 11],
  [-5, 12, 8, 5]
]
View Outputs Side By Side
Input(s)
{
  "array": [-10, -3, -5, 2, 15, -7, 28, -6, 12, 8, 11, 5],
  "targetSum": 20
}
Test Case 7 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5],
  "targetSum": 100
}
Test Case 8 passed!
Expected Output
[
  [2, 3, 5, -5],
  [1, 4, 5, -5],
  [2, 4, 5, -6],
  [1, 3, -5, 6],
  [2, 3, 6, -6],
  [1, 4, 6, -6]
]
Your Code's Output
[
  [2, 3, 5, -5],
  [1, 4, 5, -5],
  [2, 4, 5, -6],
  [1, 3, -5, 6],
  [2, 3, 6, -6],
  [1, 4, 6, -6]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, -5, 6, -6],
  "targetSum": 5
}
 
 */