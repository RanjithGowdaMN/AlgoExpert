using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._01Medium
{
    class PowersetProgram
    {
        public static List<List<int>> PowersetSol1(List<int> array)
        {
            // Write your code here.
            return PowersetSol1(array, array.Count - 1);
        }

        public static List<List<int>> PowersetSol1(List<int> array, int idx)
        {
            if (idx < 0)
            {
                List<List<int>> emptyset = new List<List<int>>();
                emptyset.Add(new List<int>());
                return emptyset;
            }
            int ele = array[idx];
            List<List<int>> subsets = PowersetSol1(array, idx - 1);
            int length = subsets.Count;
            for (int i = 0; i < length; i++)
            {
                List<int> currentSubset = new List<int>(subsets[i]);
                currentSubset.Add(ele);
                subsets.Add(currentSubset);
            }
            return subsets;
        }
        //--------------
        public static List<List<int>> Powerset(List<int> array)
        {
            // Write your code here.
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int>());
            foreach (int ele in array)
            {
                int length = subsets.Count;
                for (int i = 0; i < length; i++)
                {
                    List<int> currentSubset = new List<int>(subsets[i]);
                    currentSubset.Add(ele);
                    subsets.Add(currentSubset);
                }
            }
            return subsets;
        }
    }
}


/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<List<int> > output = Program.Powerset(new List<int>() { 1, 2, 3 });
    Utils.AssertTrue(output.Count == 8);
    Utils.AssertTrue(Contains(output, new int[] {}));
    Utils.AssertTrue(Contains(output, new int[] { 1 }));
    Utils.AssertTrue(Contains(output, new int[] { 2 }));
    Utils.AssertTrue(Contains(output, new int[] { 1, 2 }));
    Utils.AssertTrue(Contains(output, new int[] { 3 }));
    Utils.AssertTrue(Contains(output, new int[] { 1, 3 }));
    Utils.AssertTrue(Contains(output, new int[] { 2, 3 }));
    Utils.AssertTrue(Contains(output, new int[] { 1, 2, 3 }));
  }

  public bool Contains(List<List<int> > arr1, int[] arr2) {
    foreach (List<int> subArr in arr1) {
      subArr.Sort();
      if (compare(subArr, arr2)) {
        return true;
      }
    }
    return false;
  }

  public bool compare(List<int> arr1, int[] arr2) {
    if (arr1.Count != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }
}


 7 / 7 test cases passed.

Test Case 1 passed!
Expected Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3]
]
Your Code's Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3]
}
Test Case 2 passed!
Expected Output
[
  []
]
Your Code's Output
[
  []
]
View Outputs Side By Side
Input(s)
{
  "array": []
}
Test Case 3 passed!
Expected Output
[
  [],
  [1]
]
Your Code's Output
[
  [],
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
  [],
  [1],
  [2],
  [1, 2]
]
Your Code's Output
[
  [],
  [1],
  [2],
  [1, 2]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2]
}
Test Case 5 passed!
Expected Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3],
  [4],
  [1, 4],
  [2, 4],
  [1, 2, 4],
  [3, 4],
  [1, 3, 4],
  [2, 3, 4],
  [1, 2, 3, 4]
]
Your Code's Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3],
  [4],
  [1, 4],
  [2, 4],
  [1, 2, 4],
  [3, 4],
  [1, 3, 4],
  [2, 3, 4],
  [1, 2, 3, 4]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4]
}
Test Case 6 passed!
Expected Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3],
  [4],
  [1, 4],
  [2, 4],
  [1, 2, 4],
  [3, 4],
  [1, 3, 4],
  [2, 3, 4],
  [1, 2, 3, 4],
  [5],
  [1, 5],
  [2, 5],
  [1, 2, 5],
  [3, 5],
  [1, 3, 5],
  [2, 3, 5],
  [1, 2, 3, 5],
  [4, 5],
  [1, 4, 5],
  [2, 4, 5],
  [1, 2, 4, 5],
  [3, 4, 5],
  [1, 3, 4, 5],
  [2, 3, 4, 5],
  [1, 2, 3, 4, 5]
]
Your Code's Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3],
  [4],
  [1, 4],
  [2, 4],
  [1, 2, 4],
  [3, 4],
  [1, 3, 4],
  [2, 3, 4],
  [1, 2, 3, 4],
  [5],
  [1, 5],
  [2, 5],
  [1, 2, 5],
  [3, 5],
  [1, 3, 5],
  [2, 3, 5],
  [1, 2, 3, 5],
  [4, 5],
  [1, 4, 5],
  [2, 4, 5],
  [1, 2, 4, 5],
  [3, 4, 5],
  [1, 3, 4, 5],
  [2, 3, 4, 5],
  [1, 2, 3, 4, 5]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5]
}
Test Case 7 passed!
Expected Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3],
  [4],
  [1, 4],
  [2, 4],
  [1, 2, 4],
  [3, 4],
  [1, 3, 4],
  [2, 3, 4],
  [1, 2, 3, 4],
  [5],
  [1, 5],
  [2, 5],
  [1, 2, 5],
  [3, 5],
  [1, 3, 5],
  [2, 3, 5],
  [1, 2, 3, 5],
  [4, 5],
  [1, 4, 5],
  [2, 4, 5],
  [1, 2, 4, 5],
  [3, 4, 5],
  [1, 3, 4, 5],
  [2, 3, 4, 5],
  [1, 2, 3, 4, 5],
  [6],
  [1, 6],
  [2, 6],
  [1, 2, 6],
  [3, 6],
  [1, 3, 6],
  [2, 3, 6],
  [1, 2, 3, 6],
  [4, 6],
  [1, 4, 6],
  [2, 4, 6],
  [1, 2, 4, 6],
  [3, 4, 6],
  [1, 3, 4, 6],
  [2, 3, 4, 6],
  [1, 2, 3, 4, 6],
  [5, 6],
  [1, 5, 6],
  [2, 5, 6],
  [1, 2, 5, 6],
  [3, 5, 6],
  [1, 3, 5, 6],
  [2, 3, 5, 6],
  [1, 2, 3, 5, 6],
  [4, 5, 6],
  [1, 4, 5, 6],
  [2, 4, 5, 6],
  [1, 2, 4, 5, 6],
  [3, 4, 5, 6],
  [1, 3, 4, 5, 6],
  [2, 3, 4, 5, 6],
  [1, 2, 3, 4, 5, 6]
]
Your Code's Output
[
  [],
  [1],
  [2],
  [1, 2],
  [3],
  [1, 3],
  [2, 3],
  [1, 2, 3],
  [4],
  [1, 4],
  [2, 4],
  [1, 2, 4],
  [3, 4],
  [1, 3, 4],
  [2, 3, 4],
  [1, 2, 3, 4],
  [5],
  [1, 5],
  [2, 5],
  [1, 2, 5],
  [3, 5],
  [1, 3, 5],
  [2, 3, 5],
  [1, 2, 3, 5],
  [4, 5],
  [1, 4, 5],
  [2, 4, 5],
  [1, 2, 4, 5],
  [3, 4, 5],
  [1, 3, 4, 5],
  [2, 3, 4, 5],
  [1, 2, 3, 4, 5],
  [6],
  [1, 6],
  [2, 6],
  [1, 2, 6],
  [3, 6],
  [1, 3, 6],
  [2, 3, 6],
  [1, 2, 3, 6],
  [4, 6],
  [1, 4, 6],
  [2, 4, 6],
  [1, 2, 4, 6],
  [3, 4, 6],
  [1, 3, 4, 6],
  [2, 3, 4, 6],
  [1, 2, 3, 4, 6],
  [5, 6],
  [1, 5, 6],
  [2, 5, 6],
  [1, 2, 5, 6],
  [3, 5, 6],
  [1, 3, 5, 6],
  [2, 3, 5, 6],
  [1, 2, 3, 5, 6],
  [4, 5, 6],
  [1, 4, 5, 6],
  [2, 4, 5, 6],
  [1, 2, 4, 5, 6],
  [3, 4, 5, 6],
  [1, 3, 4, 5, 6],
  [2, 3, 4, 5, 6],
  [1, 2, 3, 4, 5, 6]
]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6]
}
 */