using System;

public class FindThreeLargestNumber
{
	public static int[] FindThreeLargestNumbers(int[] array)
	{
		// Write your code here.
		int[] threeLargest = { Int32.MinValue, Int32.MinValue, Int32.MinValue };

		for (int i = 0; i < array.Length; i++)
		{
			UpdateLargest(threeLargest, array[i]);
		}
		return threeLargest;
	}

	public static void UpdateLargest(int[] threeLargest, int num)
	{
		if (threeLargest[2] < num)
		{
			UpdateResultArray(num, threeLargest, 2); //TODO
		}
		else if (threeLargest[1] < num)
		{
			UpdateResultArray(num, threeLargest, 1); //TODO
		}
		else if (threeLargest[0] < num)
		{
			UpdateResultArray(num, threeLargest, 0); //TODO
		}
	}

	public static void UpdateResultArray(int num, int[] resultArray, int idx)
	{
		for (int i = 0; i <= idx; i++)
		{
			if (i == idx)
			{
				resultArray[i] = num;
			}
			else
			{
				resultArray[i] = resultArray[i + 1];
			}
		}
	}
}
