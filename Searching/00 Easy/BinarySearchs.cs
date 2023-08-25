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
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertTrue(
      Program.BinarySearch(
        new int[] { 0, 1, 21, 33, 45, 45, 61, 71, 72, 73 }, 33
      ) == 3
    );
  }
}

17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 33
}
Test Case 2 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "array": [1, 5, 23, 111],
  "target": 111
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [1, 5, 23, 111],
  "target": 5
}
Test Case 4 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [1, 5, 23, 111],
  "target": 35
}
Test Case 5 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 0
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 1
}
Test Case 7 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 21
}
Test Case 8 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 45
}
Test Case 9 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 61
}
Test Case 10 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 71
}
Test Case 11 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 72
}
Test Case 12 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 73
}
Test Case 13 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73],
  "target": 70
}
Test Case 14 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73, 355],
  "target": 355
}
Test Case 15 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 21, 33, 45, 45, 61, 71, 72, 73, 355],
  "target": 354
}
Test Case 16 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [1, 5, 23, 111],
  "target": 120
}
Test Case 17 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "array": [5, 23, 111],
  "target": 3
}
 
 */