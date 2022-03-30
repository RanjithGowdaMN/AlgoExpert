using System;

public class SelectionSorts
{
	public static int[] SelectionSort(int[] array)
	{
		// Write your code here.
		int currentIdx = 0;
		while (currentIdx < array.Length - 1)
		{
			int smallestIdx = currentIdx;
			for (int i = currentIdx + 1; i < array.Length; i++)
			{
				if (array[smallestIdx] > array[i])
				{
					smallestIdx = i;
				}
			}
			int temp = array[smallestIdx];
			array[smallestIdx] = array[currentIdx];
			array[currentIdx] = temp;
			currentIdx++;
		}
		return array;
	}
}