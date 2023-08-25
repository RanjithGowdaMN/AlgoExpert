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
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] expected = { 18, 141, 541 };
    Utils.AssertTrue(compare(
      Program.FindThreeLargestNumbers(
        new int[] { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 }
      ),
      expected
    ));
  }

  public bool compare(int[] arr1, int[] arr2) {
    if (arr1.Length != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Length; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }
}


8 / 8 test cases passed.

Test Case 1 passed!
Expected Output
[18, 141, 541]
Our Code's Output
[18, 141, 541]
View Outputs Side By Side
Input(s)
{
  "array": [141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7]
}
Test Case 2 passed!
Expected Output
[7, 8, 55]
Our Code's Output
[7, 8, 55]
View Outputs Side By Side
Input(s)
{
  "array": [55, 7, 8]
}
Test Case 3 passed!
Expected Output
[11, 43, 55]
Our Code's Output
[11, 43, 55]
View Outputs Side By Side
Input(s)
{
  "array": [55, 43, 11, 3, -3, 10]
}
Test Case 4 passed!
Expected Output
[11, 43, 55]
Our Code's Output
[11, 43, 55]
View Outputs Side By Side
Input(s)
{
  "array": [7, 8, 3, 11, 43, 55]
}
Test Case 5 passed!
Expected Output
[11, 43, 55]
Our Code's Output
[11, 43, 55]
View Outputs Side By Side
Input(s)
{
  "array": [55, 7, 8, 3, 43, 11]
}
Test Case 6 passed!
Expected Output
[7, 7, 7]
Our Code's Output
[7, 7, 7]
View Outputs Side By Side
Input(s)
{
  "array": [7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7]
}
Test Case 7 passed!
Expected Output
[7, 7, 8]
Our Code's Output
[7, 7, 8]
View Outputs Side By Side
Input(s)
{
  "array": [7, 7, 7, 7, 7, 7, 8, 7, 7, 7, 7]
}
Test Case 8 passed!
Expected Output
[-2, -1, 7]
Our Code's Output
[-2, -1, 7]
View Outputs Side By Side
Input(s)
{
  "array": [-1, -2, -3, -7, -17, -27, -18, -541, -8, -7, 7]
}

 
 */