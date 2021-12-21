using System;

namespace Arrays
{
    public class MinimumAbsDifference
    {

		public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
		{
			// Write your code here.

			Array.Sort(arrayOne);
			Array.Sort(arrayTwo);
			int Oidx = 0;
			int Tidx = 0;

			int smallest = Int32.MaxValue;
			int current = Int32.MaxValue;
			var res = new int[2];

			while (Oidx < arrayOne.Length && Tidx < arrayTwo.Length)
			{
                int first = arrayOne[Oidx];
				int second = arrayTwo[Tidx];

                if (first< second)
                {
					current = second - first;
					Oidx++;
				}
				else if (second < first)
                {
					current = first- second;
					Tidx++;
                }
                else
                {
					//return 0 if equal
					return new int[] { first, second};
                }

                if (current < smallest)
                {
					smallest = current;
					res[0] = first;
					res[1] = second;

				}

			}

            Console.WriteLine(res[0]);
			Console.WriteLine(res[1]);
			return res;
		}
	}
}
