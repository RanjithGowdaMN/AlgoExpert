using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    class GetPermutationsProgram
    {
        public static List<List<int>> GetPermutations(List<int> array)
        {
            // Write your code here.
            List<List<int>> permutaions = new List<List<int>>();
            GetPermutations(0, array, permutaions);
            return permutaions;
        }
        public static void GetPermutations(
            int i, List<int> array, List<List<int>> permutations
        )
        {
            if (i == array.Count - 1)
            {
                permutations.Add(new List<int>(array));
            }
            else
            {
                for (int j = i; j < array.Count; j++)
                {
                    swap(array, i, j);
                    GetPermutations(i + 1, array, permutations);
                    swap(array, i, j);
                }
            }
        }
        public static void swap(List<int> array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

/*
 
 using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> input = new List<int>() { 1, 2, 3 };
    List<List<int> > perms = Program.GetPermutations(input);
    Utils.AssertTrue(perms.Count == 6);
    Utils.AssertTrue(Contains(perms, new List<int>() { 1, 2, 3 }));
    Utils.AssertTrue(Contains(perms, new List<int>() { 1, 3, 2 }));
    Utils.AssertTrue(Contains(perms, new List<int>() { 2, 1, 3 }));
    Utils.AssertTrue(Contains(perms, new List<int>() { 2, 3, 1 }));
    Utils.AssertTrue(Contains(perms, new List<int>() { 3, 1, 2 }));
    Utils.AssertTrue(Contains(perms, new List<int>() { 3, 2, 1 }));
  }

  public bool Contains(List<List<int> > arr1, List<int> arr2) {
    foreach (List<int> subArray in arr1) {
      if (subArray.SequenceEqual(arr2)) {
        return true;
      }
    }
    return false;
  }
}


Test Case 1 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  [1, 2, 3],
  [1, 3, 2],
  [2, 1, 3],
  [2, 3, 1],
  [3, 1, 2],
  [3, 2, 1]
]
Your Code's Output
[
  [1, 2, 3],
  [1, 3, 2],
  [2, 1, 3],
  [2, 3, 1],
  [3, 2, 1],
  [3, 1, 2]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3]
}
Test Case 2 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": []
}
Test Case 3 passed!
Expected Output
[
  [1]
]
Your Code's Output
[
  [1]
]
View Outputs Side By Side
Input(s)
{
  "array": [1]
}
Test Case 4 passed!
Expected Output
[
  [1, 2],
  [2, 1]
]
Your Code's Output
[
  [1, 2],
  [2, 1]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2]
}
Test Case 5 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  [1, 2, 3, 4],
  [1, 2, 4, 3],
  [1, 3, 2, 4],
  [1, 3, 4, 2],
  [1, 4, 2, 3],
  [1, 4, 3, 2],
  [2, 1, 3, 4],
  [2, 1, 4, 3],
  [2, 3, 1, 4],
  [2, 3, 4, 1],
  [2, 4, 1, 3],
  [2, 4, 3, 1],
  [3, 1, 2, 4],
  [3, 1, 4, 2],
  [3, 2, 1, 4],
  [3, 2, 4, 1],
  [3, 4, 1, 2],
  [3, 4, 2, 1],
  [4, 1, 2, 3],
  [4, 1, 3, 2],
  [4, 2, 1, 3],
  [4, 2, 3, 1],
  [4, 3, 1, 2],
  [4, 3, 2, 1]
]
Your Code's Output
[
  [1, 2, 3, 4],
  [1, 2, 4, 3],
  [1, 3, 2, 4],
  [1, 3, 4, 2],
  [1, 4, 3, 2],
  [1, 4, 2, 3],
  [2, 1, 3, 4],
  [2, 1, 4, 3],
  [2, 3, 1, 4],
  [2, 3, 4, 1],
  [2, 4, 3, 1],
  [2, 4, 1, 3],
  [3, 2, 1, 4],
  [3, 2, 4, 1],
  [3, 1, 2, 4],
  [3, 1, 4, 2],
  [3, 4, 1, 2],
  [3, 4, 2, 1],
  [4, 2, 3, 1],
  [4, 2, 1, 3],
  [4, 3, 2, 1],
  [4, 3, 1, 2],
  [4, 1, 3, 2],
  [4, 1, 2, 3]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4]
}
Test Case 6 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
[
  [1, 2, 3, 4, 5],
  [1, 2, 3, 5, 4],
  [1, 2, 4, 3, 5],
  [1, 2, 4, 5, 3],
  [1, 2, 5, 3, 4],
  [1, 2, 5, 4, 3],
  [1, 3, 2, 4, 5],
  [1, 3, 2, 5, 4],
  [1, 3, 4, 2, 5],
  [1, 3, 4, 5, 2],
  [1, 3, 5, 2, 4],
  [1, 3, 5, 4, 2],
  [1, 4, 2, 3, 5],
  [1, 4, 2, 5, 3],
  [1, 4, 3, 2, 5],
  [1, 4, 3, 5, 2],
  [1, 4, 5, 2, 3],
  [1, 4, 5, 3, 2],
  [1, 5, 2, 3, 4],
  [1, 5, 2, 4, 3],
  [1, 5, 3, 2, 4],
  [1, 5, 3, 4, 2],
  [1, 5, 4, 2, 3],
  [1, 5, 4, 3, 2],
  [2, 1, 3, 4, 5],
  [2, 1, 3, 5, 4],
  [2, 1, 4, 3, 5],
  [2, 1, 4, 5, 3],
  [2, 1, 5, 3, 4],
  [2, 1, 5, 4, 3],
  [2, 3, 1, 4, 5],
  [2, 3, 1, 5, 4],
  [2, 3, 4, 1, 5],
  [2, 3, 4, 5, 1],
  [2, 3, 5, 1, 4],
  [2, 3, 5, 4, 1],
  [2, 4, 1, 3, 5],
  [2, 4, 1, 5, 3],
  [2, 4, 3, 1, 5],
  [2, 4, 3, 5, 1],
  [2, 4, 5, 1, 3],
  [2, 4, 5, 3, 1],
  [2, 5, 1, 3, 4],
  [2, 5, 1, 4, 3],
  [2, 5, 3, 1, 4],
  [2, 5, 3, 4, 1],
  [2, 5, 4, 1, 3],
  [2, 5, 4, 3, 1],
  [3, 1, 2, 4, 5],
  [3, 1, 2, 5, 4],
  [3, 1, 4, 2, 5],
  [3, 1, 4, 5, 2],
  [3, 1, 5... 
Your Code's Output
[
  [1, 2, 3, 4, 5],
  [1, 2, 3, 5, 4],
  [1, 2, 4, 3, 5],
  [1, 2, 4, 5, 3],
  [1, 2, 5, 4, 3],
  [1, 2, 5, 3, 4],
  [1, 3, 2, 4, 5],
  [1, 3, 2, 5, 4],
  [1, 3, 4, 2, 5],
  [1, 3, 4, 5, 2],
  [1, 3, 5, 4, 2],
  [1, 3, 5, 2, 4],
  [1, 4, 3, 2, 5],
  [1, 4, 3, 5, 2],
  [1, 4, 2, 3, 5],
  [1, 4, 2, 5, 3],
  [1, 4, 5, 2, 3],
  [1, 4, 5, 3, 2],
  [1, 5, 3, 4, 2],
  [1, 5, 3, 2, 4],
  [1, 5, 4, 3, 2],
  [1, 5, 4, 2, 3],
  [1, 5, 2, 4, 3],
  [1, 5, 2, 3, 4],
  [2, 1, 3, 4, 5],
  [2, 1, 3, 5, 4],
  [2, 1, 4, 3, 5],
  [2, 1, 4, 5, 3],
  [2, 1, 5, 4, 3],
  [2, 1, 5, 3, 4],
  [2, 3, 1, 4, 5],
  [2, 3, 1, 5, 4],
  [2, 3, 4, 1, 5],
  [2, 3, 4, 5, 1],
  [2, 3, 5, 4, 1],
  [2, 3, 5, 1, 4],
  [2, 4, 3, 1, 5],
  [2, 4, 3, 5, 1],
  [2, 4, 1, 3, 5],
  [2, 4, 1, 5, 3],
  [2, 4, 5, 1, 3],
  [2, 4, 5, 3, 1],
  [2, 5, 3, 4, 1],
  [2, 5, 3, 1, 4],
  [2, 5, 4, 3, 1],
  [2, 5, 4, 1, 3],
  [2, 5, 1, 4, 3],
  [2, 5, 1, 3, 4],
  [3, 2, 1, 4, 5],
  [3, 2, 1, 5, 4],
  [3, 2, 4, 1, 5],
  [3, 2, 4, 5, 1],
  [3, 2, 5... 
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5]
}
 
 */