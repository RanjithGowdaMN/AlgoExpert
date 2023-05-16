namespace Arrays
{
    public class Monotonic
    {

		public static bool IsMonotonic(int[] array)
		{
			// Write your code here.
			if (array.Length <= 2)
			{
				return true;
			}
			var direction = array[1] - array[0];
			for (int i = 2; i < array.Length; i++)
			{
				if (direction == 0)
				{
					direction = array[i] - array[i - 1];
					continue;
				}

				if (breakDirection(direction, array[i - 1], array[i]))
				{
					return false;
				}

			}
			return true;
		}

		public static bool breakDirection(int direction, int previous, int current)
		{
			var difference = current - previous;
			if (direction > 0) return difference < 0;
			return difference > 0;
		}


	}
}
