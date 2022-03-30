public class BinarySearchs
{
	public static int BinarySearch(int[] array, int target)
	{
		// Write your code here.
		int low = 0;
		int high = array.Length - 1;
		while (high >= low)
		{
			int mid = (low + high) / 2;
			if (target == array[mid])
			{
				return mid;
			}
			else if (array[mid] > target)
			{
				high = mid - 1;
			}
			else
			{
				low = mid + 1;
			}
		}
		return -1;
	}
}