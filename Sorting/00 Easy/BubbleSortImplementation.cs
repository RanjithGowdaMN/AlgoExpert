using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting._00_Easy
{
    public class BubbleSortImplementation
    {
		public static int[] BubbleSort(int[] array)
		{
			// Write your code here.

			bool isSorted = false;
			int counter = 0;
			while (!isSorted)
			{
				isSorted = true;
				for (int i = 0; i < array.Length - 1 - counter; i++)
				{
					if (array[i] > array[i + 1])
					{
						isSorted = false;
						int temp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = temp;
					}
				}
				counter++;
			}
			return array;
		}

	}
}
