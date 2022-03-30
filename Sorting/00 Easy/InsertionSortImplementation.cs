using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting._00_Easy
{
	
	public class InsertionSortImplementation
	{
		public static int[] InsertionSort(int[] array)
		{
			// Write your code here.
			for (int i = 1; i < array.Length; i++)
			{
				int j = i;
				while (j > 0 && array[j] < array[j - 1])
				{
					int temp = array[j];
					array[j] = array[j - 1];
					array[j - 1] = temp;
					j--;
				}
			}
			return array;
		}
	}

}
