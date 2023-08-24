using System;
using System.Collections.Generic;

namespace Arrays
{
    public class ThreeNoSum
	{

		public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
		{
			// Write your code here.
			List<int[]> final = new List<int[]>();

			for (int i = 1; i < array.Length - 1; i++)
			{
				HashSet<int> result = new HashSet<int>();
				result.Add(array[0]);
				for (int j = i + 1; j < array.Length; j++)
				{
					if (!result.Contains(targetSum - array[i] - array[j]  ))
					{
						result.Add(array[j]);
					}
					else
					{
						final.Add(new int[] { array[i], array[j], targetSum - array[i] - array[j] });
						break;
					}
				}
			}

			return final;
		}

		public static List<int[]> ThreeNumberSumSol2(int[] array, int targetSum)
		{
			// Write your code here.
			List<int[]> triplet = new List<int[]>();
			Array.Sort(array);
            for (int i = 0; i < array.Length-2; i++)
            {
				int[] trip = new int[3];

				int left = i + 1;
				int right = array.Length - 1;

                while (left < right)
                {
					int cursum = array[i] + array[left] + array[right];
					

					if (cursum == targetSum)
					{
						int[] newTriplet = { array[i], array[left], array[right] };
						triplet.Add(newTriplet);
						left++;
						right--;
					}
					else if (cursum < targetSum)
					{
						left++;
					}
					else if (cursum > targetSum)
					{
						right--;
					}
                }
            }
			return triplet;
		}

	}


	public class Program1
	{

		public int[] SortedSquaredArray(int[] array)
		{
			// Write your code here.
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i] * array[i];
			}
			return QuickSort(array, 0, array.Length - 1);
		}
		public int[] QuickSort(int[] A, int l, int h)
		{
			if (l < h)
			{
				int j = Partition(A, l, h);
				QuickSort(A, l, j);
				QuickSort(A, j + 1, h);
			}
			return A;
		}

		public int Partition(int[] A, int l, int h)
		{
			int pivot = A[l];
			int i = l;
			int j = h;
			while (i < j)
			{
				do
				{
					i++;
				}
				while (A[i] < pivot);
				do
				{
					j--;
				} while (A[j] > pivot);

				if (i < j)
				{
					Swap(A, i, j);
				}
			}
			Swap(A, l, j);

			return j;
		}

		public void Swap(int[] A, int i, int j)
		{
			int temp = A[i];
			A[i] = A[j];
			A[j] = temp;
		}


	}
}
/*
 
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  private bool compare(List<int[]> triplets1, List<int[]> triplets2) {
    if (triplets1.Count != triplets2.Count) return false;
    for (int i = 0; i < triplets1.Count; i++) {
      if (!Enumerable.SequenceEqual(triplets1[i], triplets2[i])) {
        return false;
      }
    }
    return true;
  }

  [Test]
  public void TestCase1() {
    List<int[]> expected = new List<int[]>();
    expected.Add(new int[] { -8, 2, 6 });
    expected.Add(new int[] { -8, 3, 5 });
    expected.Add(new int[] { -6, 1, 5 });
    List<int[]> output =
      Program.ThreeNumberSum(new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, 0);
    Utils.AssertTrue(this.compare(output, expected));
  }
}


 */

//Test Case 1 passed!
//Expected Output
//[
//  [-8, 2, 6],
//  [-8, 3, 5],
//  [-6, 1, 5]
//]
//Your Code's Output
//[
//  [-8, 2, 6],
//  [-8, 3, 5],
//  [-6, 1, 5]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [12, 3, 1, 2, -6, 5, -8, 6],
//  "targetSum": 0
//}
//Test Case 2 passed!
//Expected Output
//[
//  [1, 2, 3]
//]
//Your Code's Output
//[
//  [1, 2, 3]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [1, 2, 3],
//  "targetSum": 6
//}
//Test Case 3 passed!
//Expected Output
//[]
//Your Code's Output
//[]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [1, 2, 3],
//  "targetSum": 7
//}
//Test Case 4 passed!
//Expected Output
//[
//  [-2, 10, 49]
//]
//Your Code's Output
//[
//  [-2, 10, 49]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [8, 10, -2, 49, 14],
//  "targetSum": 57
//}
//Test Case 5 passed!
//Expected Output
//[
//  [-8, 3, 5],
//  [-6, 1, 5],
//  [-1, 0, 1]
//]
//Your Code's Output
//[
//  [-8, 3, 5],
//  [-6, 1, 5],
//  [-1, 0, 1]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [12, 3, 1, 2, -6, 5, 0, -8, -1],
//  "targetSum": 0
//}
//Test Case 6 passed!
//Expected Output
//[
//  [-8, 2, 6],
//  [-8, 3, 5],
//  [-6, 0, 6],
//  [-6, 1, 5],
//  [-1, 0, 1]
//]
//Your Code's Output
//[
//  [-8, 2, 6],
//  [-8, 3, 5],
//  [-6, 0, 6],
//  [-6, 1, 5],
//  [-1, 0, 1]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [12, 3, 1, 2, -6, 5, 0, -8, -1, 6],
//  "targetSum": 0
//}
//Test Case 7 passed!
//Expected Output
//[
//  [-8, 2, 6],
//  [-8, 3, 5],
//  [-6, 0, 6],
//  [-6, 1, 5],
//  [-5, -1, 6],
//  [-5, 0, 5],
//  [-5, 2, 3],
//  [-1, 0, 1]
//]
//Your Code's Output
//[
//  [-8, 2, 6],
//  [-8, 3, 5],
//  [-6, 0, 6],
//  [-6, 1, 5],
//  [-5, -1, 6],
//  [-5, 0, 5],
//  [-5, 2, 3],
//  [-1, 0, 1]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [12, 3, 1, 2, -6, 5, 0, -8, -1, 6, -5],
//  "targetSum": 0
//}
//Test Case 8 passed!
//Expected Output
//[
//  [1, 2, 15],
//  [1, 8, 9],
//  [2, 7, 9],
//  [3, 6, 9],
//  [3, 7, 8],
//  [4, 5, 9],
//  [4, 6, 8],
//  [5, 6, 7]
//]
//Your Code's Output
//[
//  [1, 2, 15],
//  [1, 8, 9],
//  [2, 7, 9],
//  [3, 6, 9],
//  [3, 7, 8],
//  [4, 5, 9],
//  [4, 6, 8],
//  [5, 6, 7]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 15],
//  "targetSum": 18
//}
//Test Case 9 passed!
//Expected Output
//[
//  [8, 9, 15]
//]
//Your Code's Output
//[
//  [8, 9, 15]
//]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 15],
//  "targetSum": 32
//}
//Test Case 10 passed!
//Expected Output
//[]
//Your Code's Output
//[]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 15],
//  "targetSum": 33
//}
//Test Case 11 passed!
//Expected Output
//[]
//Your Code's Output
//[]
//View Outputs Side By Side
//Input(s)
//{
//	"array": [1, 2, 3, 4, 5, 6, 7, 8, 9, 15],
//  "targetSum": 5
//}