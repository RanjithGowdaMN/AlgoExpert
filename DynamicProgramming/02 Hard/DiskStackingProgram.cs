using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    public static class DiskStackingProgram
    {
        public static void Main()
        {
            DiskStacking(new List<int[]> { new int[] {2,2,1 },
                                            new int[] {2,1,2 },
                                            new int[] {3,2,3 },
                                            new int[] {2,3,4 },
                                            new int[] {4,4,5 },
                                            new int[] {2,2,8 }});
        }
        public static List<int[]> DiskStacking(List<int[]> disks)
        {
            // Write your code here.
            disks.Sort((disk1, disk2) => disk1[2].CompareTo(disk2[2]));
            int[] heights = new int[disks.Count];
            for (int i = 0; i < disks.Count; i++)
            {
                heights[i] = disks[i][2];
            }
            int[] sequences = new int[disks.Count];
            for (int i = 0; i < disks.Count; i++)
            {
                sequences[i] = Int32.MinValue;
            }
            int maxHeightIdx = 0;
            for (int i = 1; i < disks.Count; i++)
            {
                int[] currentDisk = disks[i];
                for (int j = 0; j < i; j++)
                {
                    int[] otherDisk = disks[j];
                    if (areValidDimentions(otherDisk, currentDisk))
                    {
                        if (heights[i] <= currentDisk[2] + heights[j])
                        {
                            heights[i] = currentDisk[2] + heights[j];
                            sequences[i] = j;
                        }
                    }
                }
                if (heights[i] >= heights[maxHeightIdx])
                {
                    maxHeightIdx = i;
                }
            }
            return buildSequence(disks, sequences, maxHeightIdx);
        }

        public static bool areValidDimentions(int[] o, int[] c)
        {
            return o[0] < c[0] && o[1] < c[1] && o[2] < c[2];
        }

        public static List<int[]> buildSequence(List<int[]> array, int[] sequences, int currentIdx)
        {
            List<int[]> sequence = new List<int[]>();
            while (currentIdx != Int32.MinValue)
            {
                sequence.Insert(0, array[currentIdx]);
                currentIdx = sequences[currentIdx];
            }
            return sequence;
        }
    }
}

/*
 * 
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int[]> input = new List<int[]>();
    input.Add(new int[] { 2, 1, 2 });
    input.Add(new int[] { 3, 2, 3 });
    input.Add(new int[] { 2, 2, 8 });
    input.Add(new int[] { 2, 3, 4 });
    input.Add(new int[] { 2, 2, 1 });
    input.Add(new int[] { 4, 4, 5 });
    List<int[]> expected = new List<int[]>();
    expected.Add(new int[] { 2, 1, 2 });
    expected.Add(new int[] { 3, 2, 3 });
    expected.Add(new int[] { 4, 4, 5 });
    Utils.AssertTrue(compare(Program.DiskStacking(input), expected));
  }

  private static bool compare(List<int[]> arr1, List<int[]> arr2) {
    if (arr1.Count != arr2.Count) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      for (int j = 0; j < arr1[i].Length; j++) {
        if (!arr1[i][j].Equals(arr2[i][j])) {
          return false;
        }
      }
    }
    return true;
  }
}


 Test Case 1 passed!
Expected Output
[
  [2, 1, 2],
  [3, 2, 3],
  [4, 4, 5]
]
Your Code's Output
[
  [2, 1, 2],
  [3, 2, 3],
  [4, 4, 5]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2],
    [3, 2, 3],
    [2, 2, 8],
    [2, 3, 4],
    [1, 3, 1],
    [4, 4, 5]
  ]
}
Test Case 2 passed!
Expected Output
[
  [2, 1, 2]
]
Your Code's Output
[
  [2, 1, 2]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2]
  ]
}
Test Case 3 passed!
Expected Output
[
  [2, 1, 2],
  [3, 2, 3]
]
Your Code's Output
[
  [2, 1, 2],
  [3, 2, 3]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2],
    [3, 2, 3]
  ]
}
Test Case 4 passed!
Expected Output
[
  [2, 2, 8]
]
Your Code's Output
[
  [2, 2, 8]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2],
    [3, 2, 3],
    [2, 2, 8]
  ]
}
Test Case 5 passed!
Expected Output
[
  [2, 1, 2],
  [3, 2, 3]
]
Your Code's Output
[
  [2, 1, 2],
  [3, 2, 3]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2],
    [3, 2, 3],
    [2, 3, 4]
  ]
}
Test Case 6 passed!
Expected Output
[
  [2, 1, 2],
  [3, 2, 3],
  [4, 4, 5]
]
Your Code's Output
[
  [2, 1, 2],
  [3, 2, 3],
  [4, 4, 5]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2],
    [3, 2, 3],
    [2, 2, 8],
    [2, 3, 4],
    [2, 2, 1],
    [4, 4, 5]
  ]
}
Test Case 7 passed!
Expected Output
[
  [2, 3, 4],
  [4, 4, 5]
]
Your Code's Output
[
  [2, 3, 4],
  [4, 4, 5]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2],
    [3, 2, 5],
    [2, 2, 8],
    [2, 3, 4],
    [2, 2, 1],
    [4, 4, 5]
  ]
}
Test Case 8 passed!
Expected Output
[
  [1, 1, 4],
  [2, 2, 8]
]
Your Code's Output
[
  [1, 1, 4],
  [2, 2, 8]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [2, 1, 2],
    [3, 2, 3],
    [2, 2, 8],
    [2, 3, 4],
    [1, 2, 1],
    [4, 4, 5],
    [1, 1, 4]
  ]
}
Test Case 9 passed!
Expected Output
[
  [2, 2, 3],
  [3, 3, 4],
  [4, 4, 5],
  [5, 5, 6]
]
Your Code's Output
[
  [2, 2, 3],
  [3, 3, 4],
  [4, 4, 5],
  [5, 5, 6]
]
View Outputs Side By Side
Input(s)
{
  "disks": [
    [3, 3, 4],
    [2, 1, 2],
    [3, 2, 3],
    [2, 2, 8],
    [2, 3, 4],
    [5, 5, 6],
    [1, 2, 1],
    [4, 4, 5],
    [1, 1, 4],
    [2, 2, 3]
  ]
}
 
 */