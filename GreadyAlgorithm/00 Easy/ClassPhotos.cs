using System.Collections.Generic;
using System;


public static class ClassPhoto
{
	public static void Main()
	{

	}
	public static bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
	{
		// Write your code here.
		redShirtHeights.Sort((a, b) => b.CompareTo(a));
		blueShirtHeights.Sort((a, b) => b.CompareTo(a));

		string shirtInFrontRow = (redShirtHeights[0] > blueShirtHeights[0]) ? "RED" : "BLUE";

		for (int i = 0; i < blueShirtHeights.Count; i++)
		{
			int redShirtHeight = redShirtHeights[i];
			int blueShirtHeight = blueShirtHeights[i];

			if (shirtInFrontRow == "RED")
			{
				if (redShirtHeight <= blueShirtHeight)
				{
					return false;
				}
			}
			else
			{
				if (redShirtHeight >= blueShirtHeight)
				{
					return false;
				}
			}
		}
		return true;
	}
}
/*
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> redShirtHeights = new List<int> { 5, 8, 1, 3, 4 };
    List<int> blueShirtHeights = new List<int> { 6, 9, 2, 4, 5 };
    bool expected = true;
    bool actual = new Program().ClassPhotos(redShirtHeights, blueShirtHeights);
    Utils.AssertTrue(expected == actual);
  }
}

15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [6, 9, 2, 4, 5],
  "redShirtHeights": [5, 8, 1, 3, 4]
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [5, 8, 1, 3, 4],
  "redShirtHeights": [6, 9, 2, 4, 5]
}
Test Case 3 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [5, 8, 1, 3, 4, 9],
  "redShirtHeights": [6, 9, 2, 4, 5, 1]
}
Test Case 4 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [6],
  "redShirtHeights": [6]
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [125],
  "redShirtHeights": [126]
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [2, 3, 4, 5, 6],
  "redShirtHeights": [1, 2, 3, 4, 5]
}
Test Case 7 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [5, 6, 7, 2, 3, 1, 2, 3],
  "redShirtHeights": [1, 1, 1, 1, 1, 1, 1, 1]
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [2, 2, 2, 2, 2, 2, 2, 2],
  "redShirtHeights": [1, 1, 1, 1, 1, 1, 1, 1]
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [126],
  "redShirtHeights": [125]
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [21, 5, 4, 4, 4, 4, 4, 4, 4],
  "redShirtHeights": [19, 2, 4, 6, 2, 3, 1, 1, 4]
}
Test Case 11 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [20, 5, 4, 4, 4, 4, 4, 4],
  "redShirtHeights": [19, 19, 21, 1, 1, 1, 1, 1]
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [2, 4, 7, 5, 1],
  "redShirtHeights": [3, 5, 6, 8, 2]
}
Test Case 13 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [2, 4, 7, 5, 1, 6],
  "redShirtHeights": [3, 5, 6, 8, 2, 1]
}
Test Case 14 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [5, 4],
  "redShirtHeights": [4, 5]
}
Test Case 15 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "blueShirtHeights": [5, 4],
  "redShirtHeights": [5, 6]
}

 */
