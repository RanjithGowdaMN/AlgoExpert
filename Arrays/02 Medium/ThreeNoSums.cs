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
