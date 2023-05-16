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

//Expected Output
//[28, 26]
//Your Code's Output
//[28, 26]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [-1, 5, 10, 20, 28, 3],
//  "arrayTwo": [26, 134, 135, 15, 17]
//}
//Test Case 2 passed!
//Expected Output
//[20, 17]
//Your Code's Output
//[20, 17]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [-1, 5, 10, 20, 3],
//  "arrayTwo": [26, 134, 135, 15, 17]
//}
//Test Case 3 passed!
//Expected Output
//[25, 1005]
//Your Code's Output
//[25, 1005]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [10, 0, 20, 25],
//  "arrayTwo": [1005, 1006, 1014, 1032, 1031]
//}
//Test Case 4 passed!
//Expected Output
//[25, 1005]
//Your Code's Output
//[25, 1005]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [10, 0, 20, 25, 2200],
//  "arrayTwo": [1005, 1006, 1014, 1032, 1031]
//}
//Test Case 5 passed!
//Expected Output
//[2000, 1032]
//Your Code's Output
//[2000, 1032]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [10, 0, 20, 25, 2000],
//  "arrayTwo": [1005, 1006, 1014, 1032, 1031]
//}
//Test Case 6 passed!
//Expected Output
//[954, 954]
//Your Code's Output
//[954, 954]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [240, 124, 86, 111, 2, 84, 954, 27, 89],
//  "arrayTwo": [1, 3, 954, 19, 8]
//}
//Test Case 7 passed!
//Expected Output
//[20, 21]
//Your Code's Output
//[20, 21]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [0, 20],
//  "arrayTwo": [21, -2]
//}
//Test Case 8 passed!
//Expected Output
//[1000, 1014]
//Your Code's Output
//[1000, 1014]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [10, 1000],
//  "arrayTwo": [-1441, -124, -25, 1014, 1500, 660, 410, 245, 530]
//}
//Test Case 9 passed!
//Expected Output
//[-123, -124]
//Your Code's Output
//[-123, -124]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [10, 1000, 9124, 2142, 59, 24, 596, 591, 124, -123],
//  "arrayTwo": [-1441, -124, -25, 1014, 1500, 660, 410, 245, 530]
//}
//Test Case 10 passed!
//Expected Output
//[530, 530]
//Your Code's Output
//[530, 530]
//View Outputs Side By Side
//Input(s)
//{
//	"arrayOne": [10, 1000, 9124, 2142, 59, 24, 596, 591, 124, -123, 530],
//  "arrayTwo": [-1441, -124, -25, 1014, 1500, 660, 410, 245, 530]
//}