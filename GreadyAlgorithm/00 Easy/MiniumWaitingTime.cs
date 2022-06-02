using System;

public class MinimumWaitingTimes
{

	public int MinimumWaitingTime(int[] queries)
	{
		// Write your code here.
		Array.Sort(queries);

		int sum = 0;
		for (int i = 0; i < queries.Length; i++)
		{
			int duration = queries[i];
			int queriesLeft = queries.Length - (i + 1);
			sum += duration * queriesLeft;
		}

		return sum;
	}
}