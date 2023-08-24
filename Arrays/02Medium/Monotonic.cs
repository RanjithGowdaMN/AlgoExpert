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
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    var array = new int[] { -1, -5, -10, -1100, -1100, -1101, -1102, -9001 };
    var expected = true;
    var actual = Program.IsMonotonic(array);
    Utils.AssertEquals(expected, actual);
  }
}

19 / 19 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [-1, -5, -10, -1100, -1100, -1101, -1102, -9001]
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": []
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1]
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 2]
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [2, 1]
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 5, 10, 1100, 1101, 1102, 9001]
}
Test Case 7 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [-1, -5, -10, -1100, -1101, -1102, -9001]
}
Test Case 8 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [-1, -5, -10, -1100, -900, -1101, -1102, -9001]
}
Test Case 9 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 0]
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 2, 3, 4, 5, 5, 5, 6, 7, 8, 7, 9, 10, 11]
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 2, 3, 4, 5, 5, 5, 6, 7, 8, 8, 9, 10, 11]
}
Test Case 12 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [-1, -1, -2, -3, -4, -5, -5, -5, -6, -7, -8, -7, -9, -10, -11]
}
Test Case 13 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [-1, -1, -2, -3, -4, -5, -5, -5, -6, -7, -8, -8, -9, -10, -11]
}
Test Case 14 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "array": [-1, -1, -1, -1, -1, -1, -1, -1]
}
Test Case 15 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, -1, -2, -5]
}
Test Case 16 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [-1, -5, 10]
}
Test Case 17 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [2, 2, 2, 1, 4, 5]
}
Test Case 18 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 2, 3, 4, 1]
}
Test Case 19 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 3, 2, 1]
}

 */