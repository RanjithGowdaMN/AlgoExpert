using System;

public class MinimumWaitingTimes
{

	public int MinimumWaitingTime(int[] queries)
	{
		// Write your code here.
		Array.Sort(queries);

		int sum = 0;
		for (int i = 0; i < queries.Length; i++)
		{
			int duration = queries[i];
			int queriesLeft = queries.Length - (i + 1);
			sum += duration * queriesLeft;
		}

		return sum;
	}
}

/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] queries = new int[] { 3, 2, 1, 2, 6 };
    int expected = 17;
    var actual = new Program().MinimumWaitingTime(queries);
    Utils.AssertTrue(actual == expected);
  }
}

5 / 15 test cases passed.

Test Case 1 passed!
Expected Output
17
Your Code's Output
17
View Outputs Side By Side
Input(s)
{
  "queries": [3, 2, 1, 2, 6]
}
Test Case 2 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "queries": [2, 1, 1, 1]
}
Test Case 3 passed!
Expected Output
23
Your Code's Output
23
View Outputs Side By Side
Input(s)
{
  "queries": [1, 2, 4, 5, 2, 1]
}
Test Case 4 passed!
Expected Output
32
Your Code's Output
32
View Outputs Side By Side
Input(s)
{
  "queries": [25, 30, 2, 1]
}
Test Case 5 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "queries": [1, 1, 1, 1, 1]
}
Test Case 6 passed!
Expected Output
19
Your Code's Output
19
View Outputs Side By Side
Input(s)
{
  "queries": [7, 9, 2, 3]
}
Test Case 7 passed!
Expected Output
45
Your Code's Output
45
View Outputs Side By Side
Input(s)
{
  "queries": [4, 3, 1, 1, 3, 2, 1, 8]
}
Test Case 8 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "queries": [2]
}
Test Case 9 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "queries": [7]
}
Test Case 10 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "queries": [8, 9]
}
Test Case 11 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "queries": [1, 9]
}
Test Case 12 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "queries": [5, 4, 3, 2, 1]
}
Test Case 13 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "queries": [1, 2, 3, 4, 5]
}
Test Case 14 passed!
Expected Output
81
Your Code's Output
81
View Outputs Side By Side
Input(s)
{
  "queries": [1, 1, 1, 4, 5, 6, 8, 1, 1, 2, 1]
}
Test Case 15 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "queries": [17, 4, 3]
}

 */